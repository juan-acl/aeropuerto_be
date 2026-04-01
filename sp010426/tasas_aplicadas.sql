------------------------------------------------------------
-- Paquete CRUD para la tabla TASAS_APLICADAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tasas_aplicadas AS
    PROCEDURE insert_aplicacion(
        p_id_tasa          IN NUMBER,
        p_id_vuelo         IN NUMBER,
        p_id_reserva       IN NUMBER,
        p_fecha_aplicacion IN DATE,
        p_monto_aplicado   IN NUMBER,
        p_facturado        IN NUMBER DEFAULT 0,
        p_fecha_factura    IN DATE
    );

    PROCEDURE get_aplicacion(
        p_id_aplicacion IN NUMBER
    );

    PROCEDURE update_aplicacion(
        p_id_aplicacion    IN NUMBER,
        p_id_tasa          IN NUMBER,
        p_id_vuelo         IN NUMBER,
        p_id_reserva       IN NUMBER,
        p_fecha_aplicacion IN DATE,
        p_monto_aplicado   IN NUMBER,
        p_facturado        IN NUMBER,
        p_fecha_factura    IN DATE
    );

    PROCEDURE delete_aplicacion(
        p_id_aplicacion IN NUMBER
    );
END pkg_tasas_aplicadas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tasas_aplicadas AS

    PROCEDURE insert_aplicacion(
        p_id_tasa          IN NUMBER,
        p_id_vuelo         IN NUMBER,
        p_id_reserva       IN NUMBER,
        p_fecha_aplicacion IN DATE,
        p_monto_aplicado   IN NUMBER,
        p_facturado        IN NUMBER,
        p_fecha_factura    IN DATE
    ) IS
    BEGIN
        INSERT INTO tasas_aplicadas (
            id_tasa, id_vuelo, id_reserva, fecha_aplicacion,
            monto_aplicado, facturado, fecha_factura
        ) VALUES (
            p_id_tasa, p_id_vuelo, p_id_reserva, p_fecha_aplicacion,
            p_monto_aplicado, NVL(p_facturado,0), p_fecha_factura
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27901, 'Error al insertar aplicación de tasa: ' || SQLERRM);
    END insert_aplicacion;

    PROCEDURE get_aplicacion(
        p_id_aplicacion IN NUMBER
    ) IS
        r tasas_aplicadas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tasas_aplicadas
        WHERE id_aplicacion = p_id_aplicacion;

        DBMS_OUTPUT.PUT_LINE('ID Aplicación: ' || r.id_aplicacion);
        DBMS_OUTPUT.PUT_LINE('Tasa: ' || r.id_tasa);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Fecha aplicación: ' || r.fecha_aplicacion);
        DBMS_OUTPUT.PUT_LINE('Monto aplicado: ' || r.monto_aplicado);
        DBMS_OUTPUT.PUT_LINE('Facturado: ' || r.facturado);
        DBMS_OUTPUT.PUT_LINE('Fecha factura: ' || r.fecha_factura);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Aplicación de tasa no encontrada.');
    END get_aplicacion;

    PROCEDURE update_aplicacion(
        p_id_aplicacion    IN NUMBER,
        p_id_tasa          IN NUMBER,
        p_id_vuelo         IN NUMBER,
        p_id_reserva       IN NUMBER,
        p_fecha_aplicacion IN DATE,
        p_monto_aplicado   IN NUMBER,
        p_facturado        IN NUMBER,
        p_fecha_factura    IN DATE
    ) IS
    BEGIN
        UPDATE tasas_aplicadas
        SET id_tasa          = p_id_tasa,
            id_vuelo         = p_id_vuelo,
            id_reserva       = p_id_reserva,
            fecha_aplicacion = p_fecha_aplicacion,
            monto_aplicado   = p_monto_aplicado,
            facturado        = p_facturado,
            fecha_factura    = p_fecha_factura
        WHERE id_aplicacion = p_id_aplicacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27902, 'No se encontró la aplicación de tasa para actualizar.');
        END IF;
    END update_aplicacion;

    PROCEDURE delete_aplicacion(
        p_id_aplicacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM tasas_aplicadas
        WHERE id_aplicacion = p_id_aplicacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27903, 'No se encontró la aplicación de tasa para eliminar.');
        END IF;
    END delete_aplicacion;

END pkg_tasas_aplicadas;
/
