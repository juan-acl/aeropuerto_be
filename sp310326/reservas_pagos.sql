------------------------------------------------------------
-- Paquete CRUD para la tabla RESERVAS_PAGOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_reservas_pagos AS
    PROCEDURE insert_pago(
        p_id_reserva        IN reservas_pagos.id_reserva%TYPE,
        p_id_metodo_pago    IN reservas_pagos.id_metodo_pago%TYPE,
        p_monto             IN reservas_pagos.monto%TYPE,
        p_moneda            IN reservas_pagos.moneda%TYPE,
        p_fecha_pago        IN reservas_pagos.fecha_pago%TYPE,
        p_codigo_transaccion IN reservas_pagos.codigo_transaccion%TYPE,
        p_estado_pago       IN reservas_pagos.estado_pago%TYPE DEFAULT 'COMPLETADO',
        p_comprobante_pago  IN reservas_pagos.comprobante_pago%TYPE
    );

    PROCEDURE get_pago(
        p_id_pago IN reservas_pagos.id_pago%TYPE
    );

    PROCEDURE update_pago(
        p_id_pago           IN reservas_pagos.id_pago%TYPE,
        p_id_reserva        IN reservas_pagos.id_reserva%TYPE,
        p_id_metodo_pago    IN reservas_pagos.id_metodo_pago%TYPE,
        p_monto             IN reservas_pagos.monto%TYPE,
        p_moneda            IN reservas_pagos.moneda%TYPE,
        p_fecha_pago        IN reservas_pagos.fecha_pago%TYPE,
        p_codigo_transaccion IN reservas_pagos.codigo_transaccion%TYPE,
        p_estado_pago       IN reservas_pagos.estado_pago%TYPE,
        p_comprobante_pago  IN reservas_pagos.comprobante_pago%TYPE
    );

    PROCEDURE delete_pago(
        p_id_pago IN reservas_pagos.id_pago%TYPE
    );
END pkg_reservas_pagos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_reservas_pagos AS

    PROCEDURE insert_pago(
        p_id_reserva        IN reservas_pagos.id_reserva%TYPE,
        p_id_metodo_pago    IN reservas_pagos.id_metodo_pago%TYPE,
        p_monto             IN reservas_pagos.monto%TYPE,
        p_moneda            IN reservas_pagos.moneda%TYPE,
        p_fecha_pago        IN reservas_pagos.fecha_pago%TYPE,
        p_codigo_transaccion IN reservas_pagos.codigo_transaccion%TYPE,
        p_estado_pago       IN reservas_pagos.estado_pago%TYPE,
        p_comprobante_pago  IN reservas_pagos.comprobante_pago%TYPE
    ) IS
    BEGIN
        INSERT INTO reservas_pagos (
            id_reserva, id_metodo_pago, monto, moneda,
            fecha_pago, codigo_transaccion, estado_pago, comprobante_pago
        ) VALUES (
            p_id_reserva, p_id_metodo_pago, p_monto, p_moneda,
            p_fecha_pago, p_codigo_transaccion, NVL(p_estado_pago,'COMPLETADO'), p_comprobante_pago
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22201, 'Error al insertar pago: ' || SQLERRM);
    END insert_pago;

    PROCEDURE get_pago(
        p_id_pago IN reservas_pagos.id_pago%TYPE
    ) IS
        r reservas_pagos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM reservas_pagos
        WHERE id_pago = p_id_pago;

        DBMS_OUTPUT.PUT_LINE('ID Pago: ' || r.id_pago);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Método pago: ' || r.id_metodo_pago);
        DBMS_OUTPUT.PUT_LINE('Monto: ' || r.monto || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Fecha pago: ' || r.fecha_pago);
        DBMS_OUTPUT.PUT_LINE('Código transacción: ' || r.codigo_transaccion);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado_pago);
        DBMS_OUTPUT.PUT_LINE('Comprobante: (BLOB)');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Pago no encontrado.');
    END get_pago;

    PROCEDURE update_pago(
        p_id_pago           IN reservas_pagos.id_pago%TYPE,
        p_id_reserva        IN reservas_pagos.id_reserva%TYPE,
        p_id_metodo_pago    IN reservas_pagos.id_metodo_pago%TYPE,
        p_monto             IN reservas_pagos.monto%TYPE,
        p_moneda            IN reservas_pagos.moneda%TYPE,
        p_fecha_pago        IN reservas_pagos.fecha_pago%TYPE,
        p_codigo_transaccion IN reservas_pagos.codigo_transaccion%TYPE,
        p_estado_pago       IN reservas_pagos.estado_pago%TYPE,
        p_comprobante_pago  IN reservas_pagos.comprobante_pago%TYPE
    ) IS
    BEGIN
        UPDATE reservas_pagos
        SET id_reserva        = p_id_reserva,
            id_metodo_pago    = p_id_metodo_pago,
            monto             = p_monto,
            moneda            = p_moneda,
            fecha_pago        = p_fecha_pago,
            codigo_transaccion = p_codigo_transaccion,
            estado_pago       = p_estado_pago,
            comprobante_pago  = p_comprobante_pago
        WHERE id_pago = p_id_pago;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22202, 'No se encontró el pago para actualizar.');
        END IF;
    END update_pago;

    PROCEDURE delete_pago(
        p_id_pago IN reservas_pagos.id_pago%TYPE
    ) IS
    BEGIN
        DELETE FROM reservas_pagos
        WHERE id_pago = p_id_pago;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22203, 'No se encontró el pago para eliminar.');
        END IF;
    END delete_pago;

END pkg_reservas_pagos;
/