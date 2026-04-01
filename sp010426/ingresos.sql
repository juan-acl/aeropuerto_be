------------------------------------------------------------
-- Paquete CRUD para la tabla INGRESOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_ingresos AS
    PROCEDURE insert_ingreso(
        p_fecha          IN DATE,
        p_concepto       IN VARCHAR2,
        p_tipo_ingreso   IN VARCHAR2,
        p_id_concesion   IN NUMBER,
        p_id_vuelo       IN NUMBER,
        p_monto          IN NUMBER,
        p_moneda         IN VARCHAR2,
        p_metodo_pago    IN VARCHAR2,
        p_comprobante    IN VARCHAR2,
        p_registrado_por IN NUMBER
    );

    PROCEDURE get_ingreso(
        p_id_ingreso IN NUMBER
    );

    PROCEDURE update_ingreso(
        p_id_ingreso     IN NUMBER,
        p_fecha          IN DATE,
        p_concepto       IN VARCHAR2,
        p_tipo_ingreso   IN VARCHAR2,
        p_id_concesion   IN NUMBER,
        p_id_vuelo       IN NUMBER,
        p_monto          IN NUMBER,
        p_moneda         IN VARCHAR2,
        p_metodo_pago    IN VARCHAR2,
        p_comprobante    IN VARCHAR2,
        p_registrado_por IN NUMBER
    );

    PROCEDURE delete_ingreso(
        p_id_ingreso IN NUMBER
    );
END pkg_ingresos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_ingresos AS

    PROCEDURE insert_ingreso(
        p_fecha          IN DATE,
        p_concepto       IN VARCHAR2,
        p_tipo_ingreso   IN VARCHAR2,
        p_id_concesion   IN NUMBER,
        p_id_vuelo       IN NUMBER,
        p_monto          IN NUMBER,
        p_moneda         IN VARCHAR2,
        p_metodo_pago    IN VARCHAR2,
        p_comprobante    IN VARCHAR2,
        p_registrado_por IN NUMBER
    ) IS
    BEGIN
        INSERT INTO ingresos (
            fecha, concepto, tipo_ingreso, id_concesion, id_vuelo,
            monto, moneda, metodo_pago, comprobante, registrado_por
        ) VALUES (
            p_fecha, p_concepto, p_tipo_ingreso, p_id_concesion, p_id_vuelo,
            p_monto, p_moneda, p_metodo_pago, p_comprobante, p_registrado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27301, 'Error al insertar ingreso: ' || SQLERRM);
    END insert_ingreso;

    PROCEDURE get_ingreso(
        p_id_ingreso IN NUMBER
    ) IS
        r ingresos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM ingresos
        WHERE id_ingreso = p_id_ingreso;

        DBMS_OUTPUT.PUT_LINE('ID Ingreso: ' || r.id_ingreso);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha);
        DBMS_OUTPUT.PUT_LINE('Concepto: ' || r.concepto);
        DBMS_OUTPUT.PUT_LINE('Tipo ingreso: ' || r.tipo_ingreso);
        DBMS_OUTPUT.PUT_LINE('Concesión: ' || r.id_concesion);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Monto: ' || r.monto || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Método pago: ' || r.metodo_pago);
        DBMS_OUTPUT.PUT_LINE('Comprobante: ' || r.comprobante);
        DBMS_OUTPUT.PUT_LINE('Registrado por: ' || r.registrado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Ingreso no encontrado.');
    END get_ingreso;

    PROCEDURE update_ingreso(
        p_id_ingreso     IN NUMBER,
        p_fecha          IN DATE,
        p_concepto       IN VARCHAR2,
        p_tipo_ingreso   IN VARCHAR2,
        p_id_concesion   IN NUMBER,
        p_id_vuelo       IN NUMBER,
        p_monto          IN NUMBER,
        p_moneda         IN VARCHAR2,
        p_metodo_pago    IN VARCHAR2,
        p_comprobante    IN VARCHAR2,
        p_registrado_por IN NUMBER
    ) IS
    BEGIN
        UPDATE ingresos
        SET fecha          = p_fecha,
            concepto       = p_concepto,
            tipo_ingreso   = p_tipo_ingreso,
            id_concesion   = p_id_concesion,
            id_vuelo       = p_id_vuelo,
            monto          = p_monto,
            moneda         = p_moneda,
            metodo_pago    = p_metodo_pago,
            comprobante    = p_comprobante,
            registrado_por = p_registrado_por
        WHERE id_ingreso = p_id_ingreso;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27302, 'No se encontró el ingreso para actualizar.');
        END IF;
    END update_ingreso;

    PROCEDURE delete_ingreso(
        p_id_ingreso IN NUMBER
    ) IS
    BEGIN
        DELETE FROM ingresos
        WHERE id_ingreso = p_id_ingreso;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27303, 'No se encontró el ingreso para eliminar.');
        END IF;
    END delete_ingreso;

END pkg_ingresos;
/
