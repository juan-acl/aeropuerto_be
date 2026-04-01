------------------------------------------------------------
-- Paquete CRUD para la tabla PROVEEDORES_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_proveedores_combustible AS
    PROCEDURE insert_proveedor_combustible(
        p_id_proveedor              IN NUMBER,
        p_tipo_combustible_suministrado IN VARCHAR2,
        p_precio_compra_galon       IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_contrato_vigente          IN NUMBER DEFAULT 1,
        p_fecha_inicio_contrato     IN DATE,
        p_fecha_fin_contrato        IN DATE,
        p_volumen_minimo_contrato   IN NUMBER,
        p_condiciones_especiales    IN VARCHAR2
    );

    PROCEDURE get_proveedor_combustible(
        p_id_proveedor_combustible IN NUMBER
    );

    PROCEDURE update_proveedor_combustible(
        p_id_proveedor_combustible IN NUMBER,
        p_id_proveedor             IN NUMBER,
        p_tipo_combustible_suministrado IN VARCHAR2,
        p_precio_compra_galon      IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_contrato_vigente         IN NUMBER,
        p_fecha_inicio_contrato    IN DATE,
        p_fecha_fin_contrato       IN DATE,
        p_volumen_minimo_contrato  IN NUMBER,
        p_condiciones_especiales   IN VARCHAR2
    );

    PROCEDURE delete_proveedor_combustible(
        p_id_proveedor_combustible IN NUMBER
    );
END pkg_proveedores_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_proveedores_combustible AS

    PROCEDURE insert_proveedor_combustible(
        p_id_proveedor              IN NUMBER,
        p_tipo_combustible_suministrado IN VARCHAR2,
        p_precio_compra_galon       IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_contrato_vigente          IN NUMBER,
        p_fecha_inicio_contrato     IN DATE,
        p_fecha_fin_contrato        IN DATE,
        p_volumen_minimo_contrato   IN NUMBER,
        p_condiciones_especiales    IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO proveedores_combustible (
            id_proveedor, tipo_combustible_suministrado, precio_compra_galon,
            moneda, contrato_vigente, fecha_inicio_contrato, fecha_fin_contrato,
            volumen_minimo_contrato, condiciones_especiales
        ) VALUES (
            p_id_proveedor, p_tipo_combustible_suministrado, p_precio_compra_galon,
            p_moneda, NVL(p_contrato_vigente,1), p_fecha_inicio_contrato, p_fecha_fin_contrato,
            p_volumen_minimo_contrato, p_condiciones_especiales
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30401, 'Error al insertar proveedor de combustible: ' || SQLERRM);
    END insert_proveedor_combustible;

    PROCEDURE get_proveedor_combustible(
        p_id_proveedor_combustible IN NUMBER
    ) IS
        r proveedores_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM proveedores_combustible
        WHERE id_proveedor_combustible = p_id_proveedor_combustible;

        DBMS_OUTPUT.PUT_LINE('ID Proveedor Combustible: ' || r.id_proveedor_combustible);
        DBMS_OUTPUT.PUT_LINE('Proveedor: ' || r.id_proveedor);
        DBMS_OUTPUT.PUT_LINE('Tipo combustible suministrado: ' || r.tipo_combustible_suministrado);
        DBMS_OUTPUT.PUT_LINE('Precio compra galón: ' || r.precio_compra_galon || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Contrato vigente: ' || r.contrato_vigente);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio contrato: ' || r.fecha_inicio_contrato);
        DBMS_OUTPUT.PUT_LINE('Fecha fin contrato: ' || r.fecha_fin_contrato);
        DBMS_OUTPUT.PUT_LINE('Volumen mínimo contrato: ' || r.volumen_minimo_contrato);
        DBMS_OUTPUT.PUT_LINE('Condiciones especiales: ' || r.condiciones_especiales);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Proveedor de combustible no encontrado.');
    END get_proveedor_combustible;

    PROCEDURE update_proveedor_combustible(
        p_id_proveedor_combustible IN NUMBER,
        p_id_proveedor             IN NUMBER,
        p_tipo_combustible_suministrado IN VARCHAR2,
        p_precio_compra_galon      IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_contrato_vigente         IN NUMBER,
        p_fecha_inicio_contrato    IN DATE,
        p_fecha_fin_contrato       IN DATE,
        p_volumen_minimo_contrato  IN NUMBER,
        p_condiciones_especiales   IN VARCHAR2
    ) IS
    BEGIN
        UPDATE proveedores_combustible
        SET id_proveedor              = p_id_proveedor,
            tipo_combustible_suministrado = p_tipo_combustible_suministrado,
            precio_compra_galon       = p_precio_compra_galon,
            moneda                    = p_moneda,
            contrato_vigente          = p_contrato_vigente,
            fecha_inicio_contrato     = p_fecha_inicio_contrato,
            fecha_fin_contrato        = p_fecha_fin_contrato,
            volumen_minimo_contrato   = p_volumen_minimo_contrato,
            condiciones_especiales    = p_condiciones_especiales
        WHERE id_proveedor_combustible = p_id_proveedor_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30402, 'No se encontró el proveedor de combustible para actualizar.');
        END IF;
    END update_proveedor_combustible;

    PROCEDURE delete_proveedor_combustible(
        p_id_proveedor_combustible IN NUMBER
    ) IS
    BEGIN
        DELETE FROM proveedores_combustible
        WHERE id_proveedor_combustible = p_id_proveedor_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30403, 'No se encontró el proveedor de combustible para eliminar.');
        END IF;
    END delete_proveedor_combustible;

END pkg_proveedores_combustible;
/
