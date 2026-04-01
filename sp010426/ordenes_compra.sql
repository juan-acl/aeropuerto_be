------------------------------------------------------------
-- Paquete CRUD para la tabla ORDENES_COMPRA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_ordenes_compra AS
    PROCEDURE insert_orden(
        p_id_proveedor           IN NUMBER,
        p_fecha_orden            IN DATE,
        p_fecha_entrega_estimada IN DATE,
        p_fecha_entrega_real     IN DATE,
        p_estado                 IN VARCHAR2 DEFAULT 'PENDIENTE',
        p_subtotal               IN NUMBER,
        p_impuestos              IN NUMBER,
        p_total                  IN NUMBER,
        p_condiciones_entrega    IN VARCHAR2,
        p_solicitado_por         IN NUMBER,
        p_autorizado_por         IN NUMBER
    );

    PROCEDURE get_orden(
        p_id_orden IN NUMBER
    );

    PROCEDURE update_orden(
        p_id_orden               IN NUMBER,
        p_id_proveedor           IN NUMBER,
        p_fecha_orden            IN DATE,
        p_fecha_entrega_estimada IN DATE,
        p_fecha_entrega_real     IN DATE,
        p_estado                 IN VARCHAR2,
        p_subtotal               IN NUMBER,
        p_impuestos              IN NUMBER,
        p_total                  IN NUMBER,
        p_condiciones_entrega    IN VARCHAR2,
        p_solicitado_por         IN NUMBER,
        p_autorizado_por         IN NUMBER
    );

    PROCEDURE delete_orden(
        p_id_orden IN NUMBER
    );
END pkg_ordenes_compra;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_ordenes_compra AS

    PROCEDURE insert_orden(
        p_id_proveedor           IN NUMBER,
        p_fecha_orden            IN DATE,
        p_fecha_entrega_estimada IN DATE,
        p_fecha_entrega_real     IN DATE,
        p_estado                 IN VARCHAR2,
        p_subtotal               IN NUMBER,
        p_impuestos              IN NUMBER,
        p_total                  IN NUMBER,
        p_condiciones_entrega    IN VARCHAR2,
        p_solicitado_por         IN NUMBER,
        p_autorizado_por         IN NUMBER
    ) IS
    BEGIN
        INSERT INTO ordenes_compra (
            id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real,
            estado, subtotal, impuestos, total, condiciones_entrega,
            solicitado_por, autorizado_por
        ) VALUES (
            p_id_proveedor, p_fecha_orden, p_fecha_entrega_estimada, p_fecha_entrega_real,
            NVL(p_estado,'PENDIENTE'), p_subtotal, p_impuestos, p_total, p_condiciones_entrega,
            p_solicitado_por, p_autorizado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27601, 'Error al insertar orden de compra: ' || SQLERRM);
    END insert_orden;

    PROCEDURE get_orden(
        p_id_orden IN NUMBER
    ) IS
        r ordenes_compra%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM ordenes_compra
        WHERE id_orden = p_id_orden;

        DBMS_OUTPUT.PUT_LINE('ID Orden: ' || r.id_orden);
        DBMS_OUTPUT.PUT_LINE('Proveedor: ' || r.id_proveedor);
        DBMS_OUTPUT.PUT_LINE('Fecha orden: ' || r.fecha_orden);
        DBMS_OUTPUT.PUT_LINE('Entrega estimada: ' || r.fecha_entrega_estimada);
        DBMS_OUTPUT.PUT_LINE('Entrega real: ' || r.fecha_entrega_real);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Subtotal: ' || r.subtotal);
        DBMS_OUTPUT.PUT_LINE('Impuestos: ' || r.impuestos);
        DBMS_OUTPUT.PUT_LINE('Total: ' || r.total);
        DBMS_OUTPUT.PUT_LINE('Condiciones entrega: ' || r.condiciones_entrega);
        DBMS_OUTPUT.PUT_LINE('Solicitado por: ' || r.solicitado_por);
        DBMS_OUTPUT.PUT_LINE('Autorizado por: ' || r.autorizado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Orden de compra no encontrada.');
    END get_orden;

    PROCEDURE update_orden(
        p_id_orden               IN NUMBER,
        p_id_proveedor           IN NUMBER,
        p_fecha_orden            IN DATE,
        p_fecha_entrega_estimada IN DATE,
        p_fecha_entrega_real     IN DATE,
        p_estado                 IN VARCHAR2,
        p_subtotal               IN NUMBER,
        p_impuestos              IN NUMBER,
        p_total                  IN NUMBER,
        p_condiciones_entrega    IN VARCHAR2,
        p_solicitado_por         IN NUMBER,
        p_autorizado_por         IN NUMBER
    ) IS
    BEGIN
        UPDATE ordenes_compra
        SET id_proveedor           = p_id_proveedor,
            fecha_orden            = p_fecha_orden,
            fecha_entrega_estimada = p_fecha_entrega_estimada,
            fecha_entrega_real     = p_fecha_entrega_real,
            estado                 = p_estado,
            subtotal               = p_subtotal,
            impuestos              = p_impuestos,
            total                  = p_total,
            condiciones_entrega    = p_condiciones_entrega,
            solicitado_por         = p_solicitado_por,
            autorizado_por         = p_autorizado_por
        WHERE id_orden = p_id_orden;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27602, 'No se encontró la orden de compra para actualizar.');
        END IF;
    END update_orden;

    PROCEDURE delete_orden(
        p_id_orden IN NUMBER
    ) IS
    BEGIN
        DELETE FROM ordenes_compra
        WHERE id_orden = p_id_orden;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27603, 'No se encontró la orden de compra para eliminar.');
        END IF;
    END delete_orden;

END pkg_ordenes_compra;
/
