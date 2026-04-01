------------------------------------------------------------
-- Paquete CRUD para la tabla ORDENES_DETALLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_ordenes_detalle AS
    PROCEDURE insert_detalle(
        p_id_orden        IN NUMBER,
        p_descripcion     IN VARCHAR2,
        p_cantidad        IN NUMBER,
        p_precio_unitario IN NUMBER,
        p_subtotal_linea  IN NUMBER,
        p_observaciones   IN VARCHAR2
    );

    PROCEDURE get_detalle(
        p_id_detalle IN NUMBER
    );

    PROCEDURE update_detalle(
        p_id_detalle      IN NUMBER,
        p_id_orden        IN NUMBER,
        p_descripcion     IN VARCHAR2,
        p_cantidad        IN NUMBER,
        p_precio_unitario IN NUMBER,
        p_subtotal_linea  IN NUMBER,
        p_observaciones   IN VARCHAR2
    );

    PROCEDURE delete_detalle(
        p_id_detalle IN NUMBER
    );
END pkg_ordenes_detalle;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_ordenes_detalle AS

    PROCEDURE insert_detalle(
        p_id_orden        IN NUMBER,
        p_descripcion     IN VARCHAR2,
        p_cantidad        IN NUMBER,
        p_precio_unitario IN NUMBER,
        p_subtotal_linea  IN NUMBER,
        p_observaciones   IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO ordenes_detalle (
            id_orden, descripcion, cantidad, precio_unitario,
            subtotal_linea, observaciones
        ) VALUES (
            p_id_orden, p_descripcion, p_cantidad, p_precio_unitario,
            p_subtotal_linea, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27701, 'Error al insertar detalle de orden: ' || SQLERRM);
    END insert_detalle;

    PROCEDURE get_detalle(
        p_id_detalle IN NUMBER
    ) IS
        r ordenes_detalle%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM ordenes_detalle
        WHERE id_detalle = p_id_detalle;

        DBMS_OUTPUT.PUT_LINE('ID Detalle: ' || r.id_detalle);
        DBMS_OUTPUT.PUT_LINE('Orden: ' || r.id_orden);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Cantidad: ' || r.cantidad);
        DBMS_OUTPUT.PUT_LINE('Precio unitario: ' || r.precio_unitario);
        DBMS_OUTPUT.PUT_LINE('Subtotal línea: ' || r.subtotal_linea);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Detalle de orden no encontrado.');
    END get_detalle;

    PROCEDURE update_detalle(
        p_id_detalle      IN NUMBER,
        p_id_orden        IN NUMBER,
        p_descripcion     IN VARCHAR2,
        p_cantidad        IN NUMBER,
        p_precio_unitario IN NUMBER,
        p_subtotal_linea  IN NUMBER,
        p_observaciones   IN VARCHAR2
    ) IS
    BEGIN
        UPDATE ordenes_detalle
        SET id_orden        = p_id_orden,
            descripcion     = p_descripcion,
            cantidad        = p_cantidad,
            precio_unitario = p_precio_unitario,
            subtotal_linea  = p_subtotal_linea,
            observaciones   = p_observaciones
        WHERE id_detalle = p_id_detalle;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27702, 'No se encontró el detalle de orden para actualizar.');
        END IF;
    END update_detalle;

    PROCEDURE delete_detalle(
        p_id_detalle IN NUMBER
    ) IS
    BEGIN
        DELETE FROM ordenes_detalle
        WHERE id_detalle = p_id_detalle;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27703, 'No se encontró el detalle de orden para eliminar.');
        END IF;
    END delete_detalle;

END pkg_ordenes_detalle;
/
