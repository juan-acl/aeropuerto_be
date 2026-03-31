------------------------------------------------------------
-- Paquete CRUD para la tabla TIENDAS_PRODUCTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tiendas_productos AS
    PROCEDURE insert_producto(
        p_id_concesion       IN NUMBER,
        p_codigo_producto    IN VARCHAR2,
        p_nombre_producto    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_categoria          IN VARCHAR2,
        p_precio             IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_stock_actual       IN NUMBER,
        p_stock_minimo       IN NUMBER,
        p_iva_aplicable      IN NUMBER,
        p_activo             IN NUMBER DEFAULT 1
    );

    PROCEDURE get_producto(
        p_id_producto IN NUMBER
    );

    PROCEDURE update_producto(
        p_id_producto        IN NUMBER,
        p_id_concesion       IN NUMBER,
        p_codigo_producto    IN VARCHAR2,
        p_nombre_producto    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_categoria          IN VARCHAR2,
        p_precio             IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_stock_actual       IN NUMBER,
        p_stock_minimo       IN NUMBER,
        p_iva_aplicable      IN NUMBER,
        p_activo             IN NUMBER
    );

    PROCEDURE delete_producto(
        p_id_producto IN NUMBER
    );
END pkg_tiendas_productos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tiendas_productos AS

    PROCEDURE insert_producto(
        p_id_concesion       IN NUMBER,
        p_codigo_producto    IN VARCHAR2,
        p_nombre_producto    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_categoria          IN VARCHAR2,
        p_precio             IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_stock_actual       IN NUMBER,
        p_stock_minimo       IN NUMBER,
        p_iva_aplicable      IN NUMBER,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        INSERT INTO tiendas_productos (
            id_concesion, codigo_producto, nombre_producto,
            descripcion, categoria, precio, moneda,
            stock_actual, stock_minimo, iva_aplicable, activo
        ) VALUES (
            p_id_concesion, p_codigo_producto, p_nombre_producto,
            p_descripcion, p_categoria, p_precio, p_moneda,
            p_stock_actual, p_stock_minimo, p_iva_aplicable, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24801, 'Error al insertar producto en tienda: ' || SQLERRM);
    END insert_producto;

    PROCEDURE get_producto(
        p_id_producto IN NUMBER
    ) IS
        r tiendas_productos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tiendas_productos
        WHERE id_producto = p_id_producto;

        DBMS_OUTPUT.PUT_LINE('ID Producto: ' || r.id_producto);
        DBMS_OUTPUT.PUT_LINE('Concesión: ' || r.id_concesion);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_producto);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_producto);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Categoría: ' || r.categoria);
        DBMS_OUTPUT.PUT_LINE('Precio: ' || r.precio || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Stock actual: ' || r.stock_actual);
        DBMS_OUTPUT.PUT_LINE('Stock mínimo: ' || r.stock_minimo);
        DBMS_OUTPUT.PUT_LINE('IVA aplicable: ' || r.iva_aplicable);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Producto no encontrado.');
    END get_producto;

    PROCEDURE update_producto(
        p_id_producto        IN NUMBER,
        p_id_concesion       IN NUMBER,
        p_codigo_producto    IN VARCHAR2,
        p_nombre_producto    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_categoria          IN VARCHAR2,
        p_precio             IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_stock_actual       IN NUMBER,
        p_stock_minimo       IN NUMBER,
        p_iva_aplicable      IN NUMBER,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        UPDATE tiendas_productos
        SET id_concesion     = p_id_concesion,
            codigo_producto  = p_codigo_producto,
            nombre_producto  = p_nombre_producto,
            descripcion      = p_descripcion,
            categoria        = p_categoria,
            precio           = p_precio,
            moneda           = p_moneda,
            stock_actual     = p_stock_actual,
            stock_minimo     = p_stock_minimo,
            iva_aplicable    = p_iva_aplicable,
            activo           = p_activo
        WHERE id_producto = p_id_producto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24802, 'No se encontró el producto para actualizar.');
        END IF;
    END update_producto;

    PROCEDURE delete_producto(
        p_id_producto IN NUMBER
    ) IS
    BEGIN
        DELETE FROM tiendas_productos
        WHERE id_producto = p_id_producto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24803, 'No se encontró el producto para eliminar.');
        END IF;
    END delete_producto;

END pkg_tiendas_productos;
/