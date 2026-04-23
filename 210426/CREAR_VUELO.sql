CREATE OR REPLACE PROCEDURE sp_crear_vuelo(
    p_id_programa        IN NUMBER,
    p_fecha_vuelo        IN DATE,
    p_hora_salida        IN TIMESTAMP,
    p_hora_llegada       IN TIMESTAMP,
    p_id_modelo_avion    IN NUMBER,
    p_matricula_avion    IN VARCHAR2
) IS
    v_count NUMBER;
    v_capacidad NUMBER;
    v_id_aerolinea NUMBER;
BEGIN
    -----------------------------------------------------------------
    -- 1. No se pueden crear dos vuelos con el mismo programa en la misma fecha
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM vuelos
    WHERE id_programa = p_id_programa
      AND TRUNC(fecha_vuelo) = TRUNC(p_fecha_vuelo);

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-37301, 'Ya existe un vuelo con ese programa en la misma fecha.');
    END IF;

    -----------------------------------------------------------------
    -- 2. No se puede asignar un avión ocupado en horario traslapado
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM vuelos
    WHERE matricula_avion = p_matricula_avion
      AND (
            (p_hora_salida BETWEEN hora_salida_programada AND hora_llegada_programada)
         OR (p_hora_llegada BETWEEN hora_salida_programada AND hora_llegada_programada)
         OR (hora_salida_programada BETWEEN p_hora_salida AND p_hora_llegada)
         OR (hora_llegada_programada BETWEEN p_hora_salida AND p_hora_llegada)
          );

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-37302, 'El avión ya está asignado a otro vuelo en ese horario.');
    END IF;

    -----------------------------------------------------------------
    -- 3. La hora de llegada debe ser posterior a la hora de salida
    -----------------------------------------------------------------
    IF p_hora_llegada <= p_hora_salida THEN
        RAISE_APPLICATION_ERROR(-37303, 'La hora de llegada debe ser posterior a la hora de salida.');
    END IF;

    -----------------------------------------------------------------
    -- 4. La fecha de salida no puede ser pasada
    -----------------------------------------------------------------
    IF p_fecha_vuelo < TRUNC(SYSDATE) THEN
        RAISE_APPLICATION_ERROR(-37304, 'La fecha de salida no puede ser una fecha pasada.');
    END IF;

    -----------------------------------------------------------------
    -- 5. Validar que el avión tenga capacidad > 0 (desde tipo_aeronave)
    -----------------------------------------------------------------
    SELECT t.capacidad_pax_max
    INTO v_capacidad
    FROM aeronave a
    JOIN tipo_aeronave t ON a.codigo_icao_tipo = t.codigo_icao
    WHERE a.matricula = p_matricula_avion;

    IF v_capacidad <= 0 THEN
        RAISE_APPLICATION_ERROR(-37305, 'El avión debe tener capacidad mayor a 0 asientos.');
    END IF;

    -----------------------------------------------------------------
    -- 6. Validar que el avión pertenezca a la aerolínea del programa
    -----------------------------------------------------------------
    SELECT a.id_aerolinea INTO v_id_aerolinea
    FROM aeronave a
    WHERE a.matricula = p_matricula_avion;

    SELECT COUNT(*)
    INTO v_count
    FROM programas_vuelo p
    WHERE p.id_programa = p_id_programa
      AND p.id_aerolinea = v_id_aerolinea;

    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-37306, 'El avión no pertenece a la aerolínea del programa.');
    END IF;

    -----------------------------------------------------------------
    -- 7. Insertar vuelo en estado 'PROGRAMADO'
    -----------------------------------------------------------------
    INSERT INTO vuelos (
        id_programa, fecha_vuelo,
        hora_salida_programada, hora_llegada_programada,
        id_modelo_avion, matricula_avion,
        estado_vuelo
    ) VALUES (
        p_id_programa, p_fecha_vuelo,
        p_hora_salida, p_hora_llegada,
        p_id_modelo_avion, p_matricula_avion,
        'PROGRAMADO'
    );

    DBMS_OUTPUT.PUT_LINE('Vuelo creado correctamente en estado PROGRAMADO.');
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-37307, 'El avión especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-37399, 'Error al crear vuelo: ' || SQLERRM);
END sp_crear_vuelo;
/

