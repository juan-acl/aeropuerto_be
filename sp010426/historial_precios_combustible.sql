------------------------------------------------------------
-- Paquete CRUD para la tabla HISTORIAL_PRECIOS_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_historial_precios_combustible AS
    PROCEDURE insert_precio(
        p_fecha_precio                IN DATE,
        p_tipo_combustible            IN VARCHAR2,
        p_precio_compra_local         IN NUMBER,
        p_precio_venta_aerolineas     IN NUMBER,
        p_moneda                      IN VARCHAR2,
        p_precio_internacional_ref    IN NUMBER,
        p_variacion_porcentual        IN NUMBER,
        p_factor_ajuste               IN NUMBER,
        p_vigente                     IN NUMBER DEFAULT 1
    );

    PROCEDURE get_precio(
        p_id_precio_combustible IN NUMBER
    );

    PROCEDURE update_precio(
        p_id_precio_combustible       IN NUMBER,
        p_fecha_precio                IN DATE,
        p_tipo_combustible            IN VARCHAR2,
        p_precio_compra_local         IN NUMBER,
        p_precio_venta_aerolineas     IN NUMBER,
        p_moneda                      IN VARCHAR2,
        p_precio_internacional_ref    IN NUMBER,
        p_variacion_porcentual        IN NUMBER,
        p_factor_ajuste               IN NUMBER,
        p_vigente                     IN NUMBER
    );

    PROCEDURE delete_precio(
        p_id_precio_combustible IN NUMBER
    );
END pkg_historial_precios_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_historial_precios_combustible AS

    PROCEDURE insert_precio(
        p_fecha_precio                IN DATE,
        p_tipo_combustible            IN VARCHAR2,
        p_precio_compra_local         IN NUMBER,
        p_precio_venta_aerolineas     IN NUMBER,
        p_moneda                      IN VARCHAR2,
        p_precio_internacional_ref    IN NUMBER,
        p_variacion_porcentual        IN NUMBER,
        p_factor_ajuste               IN NUMBER,
        p_vigente                     IN NUMBER
    ) IS
    BEGIN
        INSERT INTO historial_precios_combustible (
            fecha_precio, tipo_combustible, precio_compra_local,
            precio_venta_aerolineas, moneda, precio_internacional_referencia,
            variacion_porcentual, factor_ajuste, vigente
        ) VALUES (
            p_fecha_precio, p_tipo_combustible, p_precio_compra_local,
            p_precio_venta_aerolineas, p_moneda, p_precio_internacional_ref,
            p_variacion_porcentual, p_factor_ajuste, NVL(p_vigente,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30901, 'Error al insertar precio de combustible: ' || SQLERRM);
    END insert_precio;

    PROCEDURE get_precio(
        p_id_precio_combustible IN NUMBER
    ) IS
        r historial_precios_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM historial_precios_combustible
        WHERE id_precio_combustible = p_id_precio_combustible;

        DBMS_OUTPUT.PUT_LINE('ID Precio: ' || r.id_precio_combustible);
        DBMS_OUTPUT.PUT_LINE('Fecha precio: ' || r.fecha_precio);
        DBMS_OUTPUT.PUT_LINE('Tipo combustible: ' || r.tipo_combustible);
        DBMS_OUTPUT.PUT_LINE('Precio compra local: ' || r.precio_compra_local);
        DBMS_OUTPUT.PUT_LINE('Precio venta aerolíneas: ' || r.precio_venta_aerolineas);
        DBMS_OUTPUT.PUT_LINE('Moneda: ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Precio internacional referencia: ' || r.precio_internacional_referencia);
        DBMS_OUTPUT.PUT_LINE('Variación porcentual: ' || r.variacion_porcentual);
        DBMS_OUTPUT.PUT_LINE('Factor ajuste: ' || r.factor_ajuste);
        DBMS_OUTPUT.PUT_LINE('Vigente: ' || r.vigente);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Precio de combustible no encontrado.');
    END get_precio;

    PROCEDURE update_precio(
        p_id_precio_combustible       IN NUMBER,
        p_fecha_precio                IN DATE,
        p_tipo_combustible            IN VARCHAR2,
        p_precio_compra_local         IN NUMBER,
        p_precio_venta_aerolineas     IN NUMBER,
        p_moneda                      IN VARCHAR2,
        p_precio_internacional_ref    IN NUMBER,
        p_variacion_porcentual        IN NUMBER,
        p_factor_ajuste               IN NUMBER,
        p_vigente                     IN NUMBER
    ) IS
    BEGIN
        UPDATE historial_precios_combustible
        SET fecha_precio                = p_fecha_precio,
            tipo_combustible            = p_tipo_combustible,
            precio_compra_local         = p_precio_compra_local,
            precio_venta_aerolineas     = p_precio_venta_aerolineas,
            moneda                      = p_moneda,
            precio_internacional_referencia = p_precio_internacional_ref,
            variacion_porcentual        = p_variacion_porcentual,
            factor_ajuste               = p_factor_ajuste,
            vigente                     = p_vigente
        WHERE id_precio_combustible = p_id_precio_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30902, 'No se encontró el precio de combustible para actualizar.');
        END IF;
    END update_precio;

    PROCEDURE delete_precio(
        p_id_precio_combustible IN NUMBER
    ) IS
    BEGIN
        DELETE FROM historial_precios_combustible
        WHERE id_precio_combustible = p_id_precio_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30903, 'No se encontró el precio de combustible para eliminar.');
        END IF;
    END delete_precio;

END pkg_historial_precios_combustible;
/
