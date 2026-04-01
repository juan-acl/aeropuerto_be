------------------------------------------------------------
-- Paquete CRUD para la tabla GASTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_gastos AS
    PROCEDURE insert_gasto(
        p_fecha          IN DATE,
        p_concepto       IN VARCHAR2,
        p_tipo_gasto     IN VARCHAR2,
        p_id_departamento IN NUMBER,
        p_proveedor      IN VARCHAR2,
        p_monto          IN NUMBER,
        p_moneda         IN VARCHAR2,
        p_factura        IN VARCHAR2,
        p_autorizado_por IN NUMBER
    );

    PROCEDURE get_gasto(
        p_id_gasto IN NUMBER
    );

    PROCEDURE update_gasto(
        p_id_gasto        IN NUMBER,
        p_fecha           IN DATE,
        p_concepto        IN VARCHAR2,
        p_tipo_gasto      IN VARCHAR2,
        p_id_departamento IN NUMBER,
        p_proveedor       IN VARCHAR2,
        p_monto           IN NUMBER,
        p_moneda          IN VARCHAR2,
        p_factura         IN VARCHAR2,
        p_autorizado_por  IN NUMBER
    );

    PROCEDURE delete_gasto(
        p_id_gasto IN NUMBER
    );
END pkg_gastos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_gastos AS

    PROCEDURE insert_gasto(
        p_fecha          IN DATE,
        p_concepto       IN VARCHAR2,
        p_tipo_gasto     IN VARCHAR2,
        p_id_departamento IN NUMBER,
        p_proveedor      IN VARCHAR2,
        p_monto          IN NUMBER,
        p_moneda         IN VARCHAR2,
        p_factura        IN VARCHAR2,
        p_autorizado_por IN NUMBER
    ) IS
    BEGIN
        INSERT INTO gastos (
            fecha, concepto, tipo_gasto, id_departamento,
            proveedor, monto, moneda, factura, autorizado_por
        ) VALUES (
            p_fecha, p_concepto, p_tipo_gasto, p_id_departamento,
            p_proveedor, p_monto, p_moneda, p_factura, p_autorizado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27401, 'Error al insertar gasto: ' || SQLERRM);
    END insert_gasto;

    PROCEDURE get_gasto(
        p_id_gasto IN NUMBER
    ) IS
        r gastos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM gastos
        WHERE id_gasto = p_id_gasto;

        DBMS_OUTPUT.PUT_LINE('ID Gasto: ' || r.id_gasto);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha);
        DBMS_OUTPUT.PUT_LINE('Concepto: ' || r.concepto);
        DBMS_OUTPUT.PUT_LINE('Tipo gasto: ' || r.tipo_gasto);
        DBMS_OUTPUT.PUT_LINE('Departamento: ' || r.id_departamento);
        DBMS_OUTPUT.PUT_LINE('Proveedor: ' || r.proveedor);
        DBMS_OUTPUT.PUT_LINE('Monto: ' || r.monto || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Factura: ' || r.factura);
        DBMS_OUTPUT.PUT_LINE('Autorizado por: ' || r.autorizado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Gasto no encontrado.');
    END get_gasto;

    PROCEDURE update_gasto(
        p_id_gasto        IN NUMBER,
        p_fecha           IN DATE,
        p_concepto        IN VARCHAR2,
        p_tipo_gasto      IN VARCHAR2,
        p_id_departamento IN NUMBER,
        p_proveedor       IN VARCHAR2,
        p_monto           IN NUMBER,
        p_moneda          IN VARCHAR2,
        p_factura         IN VARCHAR2,
        p_autorizado_por  IN NUMBER
    ) IS
    BEGIN
        UPDATE gastos
        SET fecha           = p_fecha,
            concepto        = p_concepto,
            tipo_gasto      = p_tipo_gasto,
            id_departamento = p_id_departamento,
            proveedor       = p_proveedor,
            monto           = p_monto,
            moneda          = p_moneda,
            factura         = p_factura,
            autorizado_por  = p_autorizado_por
        WHERE id_gasto = p_id_gasto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27402, 'No se encontró el gasto para actualizar.');
        END IF;
    END update_gasto;

    PROCEDURE delete_gasto(
        p_id_gasto IN NUMBER
    ) IS
    BEGIN
        DELETE FROM gastos
        WHERE id_gasto = p_id_gasto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27403, 'No se encontró el gasto para eliminar.');
        END IF;
    END delete_gasto;

END pkg_gastos;
/
