------------------------------------------------------------
-- Paquete CRUD para la tabla VENTAS_DETALLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_ventas_detalle AS
    PROCEDURE insert_detalle(
        p_id_venta          IN NUMBER,
        p_id_producto       IN NUMBER,
        p_cantidad          IN NUMBER,
        p_precio_unitario   IN NUMBER,
        p_descuento_aplicado IN NUMBER,
        p_subtotal_linea    IN NUMBER
    );

    PROCEDURE get_detalle(
        p_id_detalle IN NUMBER
    );

    PROCEDURE update_detalle(
        p_id_detalle        IN NUMBER,
        p_id_venta          IN NUMBER,
        p_id_producto       IN NUMBER,
        p_cantidad          IN NUMBER,
        p_precio_unitario   IN NUMBER,
        p_descuento_aplicado IN NUMBER,
        p_subtotal_linea    IN NUMBER
    );

    PROCEDURE delete_detalle(
        p_id_detalle IN NUMBER
    );
END pkg_ventas_detalle;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_ventas_detalle AS

    PROCEDURE insert_detalle(
        p_id_venta          IN NUMBER,
        p_id_producto       IN NUMBER,
        p_cantidad          IN NUMBER,
        p_precio_unitario   IN NUMBER,
        p_descuento_aplicado IN NUMBER,
        p_subtotal_linea    IN NUMBER
    ) IS
    BEGIN
        INSERT INTO ventas_detalle (
            id_venta, id_producto, cantidad,
            precio_unitario, descuento_aplicado, subtotal_linea
        ) VALUES (
            p_id_venta, p_id_producto, p_cantidad,
            p_precio_unitario, p_descuento_aplicado, p_subtotal_linea
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25001, 'Error al insertar detalle de venta: ' || SQLERRM);
    END insert_detalle;

    PROCEDURE get_detalle(
        p_id_detalle IN NUMBER
    ) IS
        r ventas_detalle%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM ventas_detalle
        WHERE id_detalle = p_id_detalle;

        DBMS_OUTPUT.PUT_LINE('ID Detalle: ' || r.id_detalle);
        DBMS_OUTPUT.PUT_LINE('Venta: ' || r.id_venta);
        DBMS_OUTPUT.PUT_LINE('Producto: ' || r.id_producto);
        DBMS_OUTPUT.PUT_LINE('Cantidad: ' || r.cantidad);
        DBMS_OUTPUT.PUT_LINE('Precio unitario: ' || r.precio_unitario);
        DBMS_OUTPUT.PUT_LINE('Descuento aplicado: ' || r.descuento_aplicado);
        DBMS_OUTPUT.PUT_LINE('Subtotal línea: ' || r.subtotal_linea);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Detalle de venta no encontrado.');
    END get_detalle;

    PROCEDURE update_detalle(
        p_id_detalle        IN NUMBER,
        p_id_venta          IN NUMBER,
        p_id_producto       IN NUMBER,
        p_cantidad          IN NUMBER,
        p_precio_unitario   IN NUMBER,
        p_descuento_aplicado IN NUMBER,
        p_subtotal_linea    IN NUMBER
    ) IS
    BEGIN
        UPDATE ventas_detalle
        SET id_venta          = p_id_venta,
            id_producto       = p_id_producto,
            cantidad          = p_cantidad,
            precio_unitario   = p_precio_unitario,
            descuento_aplicado = p_descuento_aplicado,
            subtotal_linea    = p_subtotal_linea
        WHERE id_detalle = p_id_detalle;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25002, 'No se encontró el detalle de venta para actualizar.');
        END IF;
    END update_detalle;

    PROCEDURE delete_detalle(
        p_id_detalle IN NUMBER
    ) IS
    BEGIN
        DELETE FROM ventas_detalle
        WHERE id_detalle = p_id_detalle;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25003, 'No se encontró el detalle de venta para eliminar.');
        END IF;
    END delete_detalle;

END pkg_ventas_detalle;
/