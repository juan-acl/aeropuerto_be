CREATE OR REPLACE PROCEDURE sp_actualizar_estado_reserva(
    p_id_reserva   IN NUMBER,
    p_nuevo_estado IN VARCHAR2
) IS
    v_estado_actual VARCHAR2(20);
BEGIN
    -----------------------------------------------------------------
    -- 1. Obtener estado actual de la reservación
    -----------------------------------------------------------------
    SELECT estado_reserva
    INTO v_estado_actual
    FROM reservas
    WHERE id_reserva = p_id_reserva;

    -----------------------------------------------------------------
    -- 2. Validar transición permitida
    -----------------------------------------------------------------
    CASE v_estado_actual
        WHEN 'PENDIENTE PAGO' THEN
            IF p_nuevo_estado NOT IN ('CONFIRMADA','CANCELADA') THEN
                RAISE_APPLICATION_ERROR(-40501, 'Transición inválida desde PENDIENTE PAGO.');
            END IF;
        WHEN 'CONFIRMADA' THEN
            IF p_nuevo_estado NOT IN ('CHECK_IN','CANCELADA') THEN
                RAISE_APPLICATION_ERROR(-40502, 'Transición inválida desde CONFIRMADA.');
            END IF;
        WHEN 'CHECK_IN' THEN
            IF p_nuevo_estado NOT IN ('ABORDADO','NO_SHOW') THEN
                RAISE_APPLICATION_ERROR(-40503, 'Transición inválida desde CHECK_IN.');
            END IF;
        WHEN 'ABORDADO' THEN
            RAISE_APPLICATION_ERROR(-40504, 'La reservación ya está ABORDADA. No se permiten más transiciones.');
        WHEN 'CANCELADA' THEN
            RAISE_APPLICATION_ERROR(-40505, 'La reservación está CANCELADA. No se permiten más transiciones.');
        WHEN 'NO_SHOW' THEN
            RAISE_APPLICATION_ERROR(-40506, 'La reservación está marcada como NO SHOW. No se permiten más transiciones.');
        ELSE
            RAISE_APPLICATION_ERROR(-40507, 'Estado actual desconocido.');
    END CASE;

    -----------------------------------------------------------------
    -- 3. Actualizar estado
    -----------------------------------------------------------------
    UPDATE reservas
    SET estado_reserva = p_nuevo_estado
    WHERE id_reserva = p_id_reserva;

    DBMS_OUTPUT.PUT_LINE('Reservación ' || p_id_reserva || ' actualizada de ' || v_estado_actual || ' a ' || p_nuevo_estado);
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-40508, 'La reservación especificada no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-40599, 'Error al actualizar estado de reservación: ' || SQLERRM);
END sp_actualizar_estado_reserva;
/
