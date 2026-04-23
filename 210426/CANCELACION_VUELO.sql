CREATE OR REPLACE PROCEDURE sp_cancelar_vuelo(
    p_id_vuelo            IN NUMBER,
    p_motivo_cancelacion  IN VARCHAR2
) IS
    v_estado_actual VARCHAR2(20);
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que el vuelo exista
    -----------------------------------------------------------------
    SELECT estado_vuelo
    INTO v_estado_actual
    FROM vuelos
    WHERE id_vuelo = p_id_vuelo;

    -----------------------------------------------------------------
    -- 2. Validar que el vuelo no esté ya cancelado o aterrizado
    -----------------------------------------------------------------
    IF v_estado_actual IN ('CANCELADO','ATERRIZADO') THEN
        RAISE_APPLICATION_ERROR(-37401, 'El vuelo ya está cancelado o finalizado.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Actualizar estado a CANCELADO y registrar motivo
    -----------------------------------------------------------------
    UPDATE vuelos
    SET estado_vuelo = 'CANCELADO',
        motivo_cancelacion = p_motivo_cancelacion,
        fecha_reprogramado = NULL
    WHERE id_vuelo = p_id_vuelo;

    DBMS_OUTPUT.PUT_LINE('Vuelo ' || p_id_vuelo || ' cancelado correctamente.');
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-37402, 'El vuelo especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-37499, 'Error al cancelar vuelo: ' || SQLERRM);
END sp_cancelar_vuelo;
/
