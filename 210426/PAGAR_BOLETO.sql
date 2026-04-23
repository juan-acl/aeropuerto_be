CREATE OR REPLACE PROCEDURE sp_pagar_boleto(
    p_id_reserva        IN NUMBER,
    p_id_metodo_pago    IN NUMBER,
    p_monto             IN NUMBER,
    p_moneda            IN VARCHAR2,
    p_codigo_transaccion IN VARCHAR2,
    p_comprobante       IN BLOB
) IS
    v_estado_reserva VARCHAR2(20);
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que la reserva exista y esté en estado PENDIENTE
    -----------------------------------------------------------------
    SELECT estado_reserva
    INTO v_estado_reserva
    FROM reservas
    WHERE id_reserva = p_id_reserva;

    IF v_estado_reserva <> 'PENDIENTE' THEN
        RAISE_APPLICATION_ERROR(-38001, 'La reserva no está en estado PENDIENTE, no puede pagarse.');
    END IF;

    -----------------------------------------------------------------
    -- 2. Registrar el pago en reservas_pagos
    -----------------------------------------------------------------
    INSERT INTO reservas_pagos (
        id_reserva, id_metodo_pago, monto, moneda,
        fecha_pago, codigo_transaccion, estado_pago, comprobante_pago
    ) VALUES (
        p_id_reserva, p_id_metodo_pago, p_monto, p_moneda,
        SYSTIMESTAMP, p_codigo_transaccion, 'COMPLETADO', p_comprobante
    );

    -----------------------------------------------------------------
    -- 3. Actualizar la reserva a CONFIRMADA
    -----------------------------------------------------------------
    UPDATE reservas
    SET estado_reserva = 'CONFIRMADA',
        precio_pagado = p_monto,
        moneda = p_moneda,
        fecha_modificacion = SYSDATE
    WHERE id_reserva = p_id_reserva;

    DBMS_OUTPUT.PUT_LINE('Pago de boleto registrado y reserva ' || p_id_reserva || ' confirmada correctamente.');
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-38002, 'La reserva especificada no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-38099, 'Error al procesar pago de boleto: ' || SQLERRM);
END sp_pagar_boleto;
/
