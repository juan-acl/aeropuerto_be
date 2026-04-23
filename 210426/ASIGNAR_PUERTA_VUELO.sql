CREATE OR REPLACE PROCEDURE sp_asignar_puerta_embarque(
    p_id_vuelo     IN NUMBER,
    p_id_puerta    IN NUMBER,
    p_tipo_vuelo   IN VARCHAR2 -- 'Nacional' o 'Internacional'
) IS
    v_hora_salida TIMESTAMP;
    v_estado_vuelo VARCHAR2(20);
    v_count NUMBER;
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que el vuelo exista y obtener hora de salida
    -----------------------------------------------------------------
    SELECT hora_salida_programada, estado_vuelo
    INTO v_hora_salida, v_estado_vuelo
    FROM vuelos
    WHERE id_vuelo = p_id_vuelo;

    IF v_estado_vuelo <> 'PROGRAMADO' THEN
        RAISE_APPLICATION_ERROR(-37501, 'Solo se pueden asignar puertas a vuelos programados.');
    END IF;

    -----------------------------------------------------------------
    -- 2. Validar que la asignación se haga entre 2h y 30min antes de salida
    -----------------------------------------------------------------
    IF SYSTIMESTAMP < (v_hora_salida - INTERVAL '2' HOUR)
       OR SYSTIMESTAMP > (v_hora_salida - INTERVAL '30' MINUTE) THEN
        RAISE_APPLICATION_ERROR(-37502, 'La puerta solo puede asignarse entre 2h y 30min antes de la salida.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Validar que la puerta exista y esté activa
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM puertas_embarque
    WHERE id_puerta = p_id_puerta
      AND activo = 1;

    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-37503, 'La puerta no existe o no está activa.');
    END IF;

    -----------------------------------------------------------------
    -- 4. Validar que no haya traslape de horarios en la misma puerta
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM vuelos
    WHERE id_puerta_salida = p_id_puerta
      AND estado_vuelo = 'PROGRAMADO'
      AND (
            (hora_salida_programada BETWEEN v_hora_salida - INTERVAL '90' MINUTE AND v_hora_salida + INTERVAL '90' MINUTE)
          );

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-37504, 'La puerta ya está asignada a otro vuelo en horario traslapado.');
    END IF;

    -----------------------------------------------------------------
    -- 5. Validar tipo de vuelo vs tipo de puerta (por parámetro)
    -----------------------------------------------------------------
    IF p_tipo_vuelo NOT IN ('Nacional','Internacional') THEN
        RAISE_APPLICATION_ERROR(-37505, 'El tipo de vuelo debe ser Nacional o Internacional.');
    END IF;
    -- Aquí la validación se hace contra el parámetro, ya que la tabla no tiene columna tipo.

    -----------------------------------------------------------------
    -- 6. Asignar la puerta al vuelo
    -----------------------------------------------------------------
    UPDATE vuelos
    SET id_puerta_salida = p_id_puerta
    WHERE id_vuelo = p_id_vuelo;

    DBMS_OUTPUT.PUT_LINE('Puerta ' || p_id_puerta || ' asignada correctamente al vuelo ' || p_id_vuelo);
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-37506, 'El vuelo especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-37599, 'Error al asignar puerta: ' || SQLERRM);
END sp_asignar_puerta_embarque;
/


