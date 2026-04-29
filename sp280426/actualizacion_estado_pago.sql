CREATE OR REPLACE PROCEDURE sp_actualizar_estado_pago(
    p_id_pago      IN NUMBER,
    p_nuevo_estado IN VARCHAR2
) IS
    v_estado_actual VARCHAR2(20);
BEGIN
    -----------------------------------------------------------------
    -- 1. Obtener estado actual del pago
    -----------------------------------------------------------------
    SELECT estado_pago
    INTO v_estado_actual
    FROM reservas_pagos
    WHERE id_pago = p_id_pago;

    -----------------------------------------------------------------
    -- 2. Validar transición permitida
    -----------------------------------------------------------------
    CASE v_estado_actual
        WHEN 'PENDIENTE' THEN
            IF p_nuevo_estado NOT IN ('COMPLETADO','FALLIDO') THEN
                RAISE_APPLICATION_ERROR(-40701, 'Transición inválida desde PENDIENTE.');
            END IF;
        WHEN 'COMPLETADO' THEN
            IF p_nuevo_estado NOT IN ('REEMBOLSADO_TOTAL','REEMBOLSADO_PARCIAL') THEN
                RAISE_APPLICATION_ERROR(-40702, 'Transición inválida desde COMPLETADO.');
            END IF;
        WHEN 'FALLIDO' THEN
            RAISE_APPLICATION_ERROR(-40703, 'El pago está FALLIDO. No se permiten más transiciones.');
        WHEN 'REEMBOLSADO_TOTAL' THEN
            RAISE_APPLICATION_ERROR(-40704, 'El pago ya fue REEMBOLSADO TOTAL. No se permiten más transiciones.');
        WHEN 'REEMBOLSADO_PARCIAL' THEN
            RAISE_APPLICATION_ERROR(-40705, 'El pago ya fue REEMBOLSADO PARCIAL. No se permiten más transiciones.');
        ELSE
            RAISE_APPLICATION_ERROR(-40706, 'Estado actual desconocido.');
    END CASE;

    -----------------------------------------------------------------
    -- 3. Actualizar estado
    -----------------------------------------------------------------
    UPDATE reservas_pagos
    SET estado_pago = p_nuevo_estado
    WHERE id_pago = p_id_pago;

    DBMS_OUTPUT.PUT_LINE('Pago ' || p_id_pago || ' actualizado de ' || v_estado_actual || ' a ' || p_nuevo_estado);
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-40707, 'El pago especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-40799, 'Error al actualizar estado de pago: ' || SQLERRM);
END sp_actualizar_estado_pago;
/
