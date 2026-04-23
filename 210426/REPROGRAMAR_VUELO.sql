CREATE OR REPLACE PROCEDURE sp_reprogramar_vuelo(
    p_id_vuelo          IN NUMBER,
    p_nueva_fecha       IN DATE,
    p_nueva_hora_salida IN TIMESTAMP,
    p_nueva_hora_llegada IN TIMESTAMP
) IS
    v_estado_actual VARCHAR2(20);
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que el vuelo exista y obtener estado actual
    -----------------------------------------------------------------
    SELECT estado_vuelo
    INTO v_estado_actual
    FROM vuelos
    WHERE id_vuelo = p_id_vuelo;

    -----------------------------------------------------------------
    -- 2. Validar que el vuelo no esté ya cancelado o aterrizado
    -----------------------------------------------------------------
    IF v_estado_actual IN ('CANCELADO','ATERRIZADO') THEN
        RAISE_APPLICATION_ERROR(-37601, 'El vuelo ya está cancelado o finalizado, no puede reprogramarse.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Validar que la nueva fecha no sea pasada
    -----------------------------------------------------------------
    IF p_nueva_fecha < TRUNC(SYSDATE) THEN
        RAISE_APPLICATION_ERROR(-37602, 'La nueva fecha de salida no puede ser pasada.');
    END IF;

    -----------------------------------------------------------------
    -- 4. Validar que la hora de llegada sea posterior a la hora de salida
    -----------------------------------------------------------------
    IF p_nueva_hora_llegada <= p_nueva_hora_salida THEN
        RAISE_APPLICATION_ERROR(-37603, 'La nueva hora de llegada debe ser posterior a la hora de salida.');
    END IF;

    -----------------------------------------------------------------
    -- 5. Actualizar vuelo a estado REPROGRAMADO
    -----------------------------------------------------------------
    UPDATE vuelos
    SET fecha_vuelo = p_nueva_fecha,
        hora_salida_programada = p_nueva_hora_salida,
        hora_llegada_programada = p_nueva_hora_llegada,
        estado_vuelo = 'REPROGRAMADO',
        fecha_reprogramado = SYSDATE
    WHERE id_vuelo = p_id_vuelo;

    DBMS_OUTPUT.PUT_LINE('Vuelo ' || p_id_vuelo || ' reprogramado correctamente.');
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-37604, 'El vuelo especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-37699, 'Error al reprogramar vuelo: ' || SQLERRM);
END sp_reprogramar_vuelo;
/
