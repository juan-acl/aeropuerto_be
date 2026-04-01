------------------------------------------------------------
-- Paquete CRUD para la tabla PROVEEDORES_REPUESTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_proveedores_repuestos AS
    PROCEDURE insert_proveedor_repuesto(
        p_id_proveedor        IN NUMBER,
        p_id_pieza            IN NUMBER,
        p_precio_contrato     IN NUMBER,
        p_tiempo_entrega_dias IN NUMBER,
        p_calificacion        IN NUMBER,
        p_ultima_compra       IN DATE,
        p_activo              IN NUMBER DEFAULT 1
    );

    PROCEDURE get_proveedor_repuesto(
        p_id_proveedor_repuesto IN NUMBER
    );

    PROCEDURE update_proveedor_repuesto(
        p_id_proveedor_repuesto IN NUMBER,
        p_id_proveedor          IN NUMBER,
        p_id_pieza              IN NUMBER,
        p_precio_contrato       IN NUMBER,
        p_tiempo_entrega_dias   IN NUMBER,
        p_calificacion          IN NUMBER,
        p_ultima_compra         IN DATE,
        p_activo                IN NUMBER
    );

    PROCEDURE delete_proveedor_repuesto(
        p_id_proveedor_repuesto IN NUMBER
    );
END pkg_proveedores_repuestos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_proveedores_repuestos AS

    PROCEDURE insert_proveedor_repuesto(
        p_id_proveedor        IN NUMBER,
        p_id_pieza            IN NUMBER,
        p_precio_contrato     IN NUMBER,
        p_tiempo_entrega_dias IN NUMBER,
        p_calificacion        IN NUMBER,
        p_ultima_compra       IN DATE,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO proveedores_repuestos (
            id_proveedor, id_pieza, precio_contrato,
            tiempo_entrega_dias, calificacion,
            ultima_compra, activo
        ) VALUES (
            p_id_proveedor, p_id_pieza, p_precio_contrato,
            p_tiempo_entrega_dias, p_calificacion,
            p_ultima_compra, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29901, 'Error al insertar proveedor de repuesto: ' || SQLERRM);
    END insert_proveedor_repuesto;

    PROCEDURE get_proveedor_repuesto(
        p_id_proveedor_repuesto IN NUMBER
    ) IS
        r proveedores_repuestos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM proveedores_repuestos
        WHERE id_proveedor_repuesto = p_id_proveedor_repuesto;

        DBMS_OUTPUT.PUT_LINE('ID Proveedor Repuesto: ' || r.id_proveedor_repuesto);
        DBMS_OUTPUT.PUT_LINE('Proveedor: ' || r.id_proveedor);
        DBMS_OUTPUT.PUT_LINE('Pieza: ' || r.id_pieza);
        DBMS_OUTPUT.PUT_LINE('Precio contrato: ' || r.precio_contrato);
        DBMS_OUTPUT.PUT_LINE('Tiempo entrega (días): ' || r.tiempo_entrega_dias);
        DBMS_OUTPUT.PUT_LINE('Calificación: ' || r.calificacion);
        DBMS_OUTPUT.PUT_LINE('Última compra: ' || r.ultima_compra);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Proveedor de repuesto no encontrado.');
    END get_proveedor_repuesto;

    PROCEDURE update_proveedor_repuesto(
        p_id_proveedor_repuesto IN NUMBER,
        p_id_proveedor          IN NUMBER,
        p_id_pieza              IN NUMBER,
        p_precio_contrato       IN NUMBER,
        p_tiempo_entrega_dias   IN NUMBER,
        p_calificacion          IN NUMBER,
        p_ultima_compra         IN DATE,
        p_activo                IN NUMBER
    ) IS
    BEGIN
        UPDATE proveedores_repuestos
        SET id_proveedor        = p_id_proveedor,
            id_pieza            = p_id_pieza,
            precio_contrato     = p_precio_contrato,
            tiempo_entrega_dias = p_tiempo_entrega_dias,
            calificacion        = p_calificacion,
            ultima_compra       = p_ultima_compra,
            activo              = p_activo
        WHERE id_proveedor_repuesto = p_id_proveedor_repuesto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29902, 'No se encontró el proveedor de repuesto para actualizar.');
        END IF;
    END update_proveedor_repuesto;

    PROCEDURE delete_proveedor_repuesto(
        p_id_proveedor_repuesto IN NUMBER
    ) IS
    BEGIN
        DELETE FROM proveedores_repuestos
        WHERE id_proveedor_repuesto = p_id_proveedor_repuesto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29903, 'No se encontró el proveedor de repuesto para eliminar.');
        END IF;
    END delete_proveedor_repuesto;

END pkg_proveedores_repuestos;
/
