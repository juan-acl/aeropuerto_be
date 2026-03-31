------------------------------------------------------------
-- Paquete CRUD para la tabla FACTURAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_facturas AS
    PROCEDURE insert_factura(
        p_id_reserva       IN facturas.id_reserva%TYPE,
        p_numero_factura   IN facturas.numero_factura%TYPE,
        p_fecha_emision    IN facturas.fecha_emision%TYPE,
        p_subtotal         IN facturas.subtotal%TYPE,
        p_impuestos        IN facturas.impuestos%TYPE,
        p_total            IN facturas.total%TYPE,
        p_moneda           IN facturas.moneda%TYPE,
        p_datos_fiscales   IN facturas.datos_fiscales%TYPE,
        p_pdf_factura      IN facturas.pdf_factura%TYPE
    );

    PROCEDURE get_factura(
        p_id_factura IN facturas.id_factura%TYPE
    );

    PROCEDURE update_factura(
        p_id_factura       IN facturas.id_factura%TYPE,
        p_id_reserva       IN facturas.id_reserva%TYPE,
        p_numero_factura   IN facturas.numero_factura%TYPE,
        p_fecha_emision    IN facturas.fecha_emision%TYPE,
        p_subtotal         IN facturas.subtotal%TYPE,
        p_impuestos        IN facturas.impuestos%TYPE,
        p_total            IN facturas.total%TYPE,
        p_moneda           IN facturas.moneda%TYPE,
        p_datos_fiscales   IN facturas.datos_fiscales%TYPE,
        p_pdf_factura      IN facturas.pdf_factura%TYPE
    );

    PROCEDURE delete_factura(
        p_id_factura IN facturas.id_factura%TYPE
    );
END pkg_facturas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_facturas AS

    PROCEDURE insert_factura(
        p_id_reserva       IN facturas.id_reserva%TYPE,
        p_numero_factura   IN facturas.numero_factura%TYPE,
        p_fecha_emision    IN facturas.fecha_emision%TYPE,
        p_subtotal         IN facturas.subtotal%TYPE,
        p_impuestos        IN facturas.impuestos%TYPE,
        p_total            IN facturas.total%TYPE,
        p_moneda           IN facturas.moneda%TYPE,
        p_datos_fiscales   IN facturas.datos_fiscales%TYPE,
        p_pdf_factura      IN facturas.pdf_factura%TYPE
    ) IS
    BEGIN
        INSERT INTO facturas (
            id_reserva, numero_factura, fecha_emision,
            subtotal, impuestos, total, moneda,
            datos_fiscales, pdf_factura
        ) VALUES (
            p_id_reserva, p_numero_factura, p_fecha_emision,
            p_subtotal, p_impuestos, p_total, p_moneda,
            p_datos_fiscales, p_pdf_factura
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22301, 'Error al insertar factura: ' || SQLERRM);
    END insert_factura;

    PROCEDURE get_factura(
        p_id_factura IN facturas.id_factura%TYPE
    ) IS
        r facturas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM facturas
        WHERE id_factura = p_id_factura;

        DBMS_OUTPUT.PUT_LINE('ID Factura: ' || r.id_factura);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Número factura: ' || r.numero_factura);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Subtotal: ' || r.subtotal);
        DBMS_OUTPUT.PUT_LINE('Impuestos: ' || r.impuestos);
        DBMS_OUTPUT.PUT_LINE('Total: ' || r.total || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Datos fiscales: ' || r.datos_fiscales);
        DBMS_OUTPUT.PUT_LINE('PDF Factura: (BLOB)');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Factura no encontrada.');
    END get_factura;

    PROCEDURE update_factura(
        p_id_factura       IN facturas.id_factura%TYPE,
        p_id_reserva       IN facturas.id_reserva%TYPE,
        p_numero_factura   IN facturas.numero_factura%TYPE,
        p_fecha_emision    IN facturas.fecha_emision%TYPE,
        p_subtotal         IN facturas.subtotal%TYPE,
        p_impuestos        IN facturas.impuestos%TYPE,
        p_total            IN facturas.total%TYPE,
        p_moneda           IN facturas.moneda%TYPE,
        p_datos_fiscales   IN facturas.datos_fiscales%TYPE,
        p_pdf_factura      IN facturas.pdf_factura%TYPE
    ) IS
    BEGIN
        UPDATE facturas
        SET id_reserva     = p_id_reserva,
            numero_factura = p_numero_factura,
            fecha_emision  = p_fecha_emision,
            subtotal       = p_subtotal,
            impuestos      = p_impuestos,
            total          = p_total,
            moneda         = p_moneda,
            datos_fiscales = p_datos_fiscales,
            pdf_factura    = p_pdf_factura
        WHERE id_factura = p_id_factura;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22302, 'No se encontró la factura para actualizar.');
        END IF;
    END update_factura;

    PROCEDURE delete_factura(
        p_id_factura IN facturas.id_factura%TYPE
    ) IS
    BEGIN
        DELETE FROM facturas
        WHERE id_factura = p_id_factura;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22303, 'No se encontró la factura para eliminar.');
        END IF;
    END delete_factura;

END pkg_facturas;
/