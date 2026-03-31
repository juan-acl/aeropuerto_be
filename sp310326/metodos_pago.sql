------------------------------------------------------------
-- Paquete CRUD para la tabla METODOS_PAGO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_metodos_pago AS
    PROCEDURE insert_metodo(
        p_descripcion IN metodos_pago.descripcion%TYPE,
        p_tipo_pago   IN metodos_pago.tipo_pago%TYPE,
        p_procesador  IN metodos_pago.procesador%TYPE,
        p_activo      IN metodos_pago.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE
    );

    PROCEDURE update_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE,
        p_descripcion    IN metodos_pago.descripcion%TYPE,
        p_tipo_pago      IN metodos_pago.tipo_pago%TYPE,
        p_procesador     IN metodos_pago.procesador%TYPE,
        p_activo         IN metodos_pago.activo%TYPE
    );

    PROCEDURE delete_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE
    );
END pkg_metodos_pago;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_metodos_pago AS

    PROCEDURE insert_metodo(
        p_descripcion IN metodos_pago.descripcion%TYPE,
        p_tipo_pago   IN metodos_pago.tipo_pago%TYPE,
        p_procesador  IN metodos_pago.procesador%TYPE,
        p_activo      IN metodos_pago.activo%TYPE
    ) IS
    BEGIN
        INSERT INTO metodos_pago (
            descripcion, tipo_pago, procesador, activo
        ) VALUES (
            p_descripcion, p_tipo_pago, p_procesador, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22101, 'Error al insertar método de pago: ' || SQLERRM);
    END insert_metodo;

    PROCEDURE get_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE
    ) IS
        r metodos_pago%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM metodos_pago
        WHERE id_metodo_pago = p_id_metodo_pago;

        DBMS_OUTPUT.PUT_LINE('ID Método: ' || r.id_metodo_pago);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Tipo pago: ' || r.tipo_pago);
        DBMS_OUTPUT.PUT_LINE('Procesador: ' || r.procesador);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Método de pago no encontrado.');
    END get_metodo;

    PROCEDURE update_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE,
        p_descripcion    IN metodos_pago.descripcion%TYPE,
        p_tipo_pago      IN metodos_pago.tipo_pago%TYPE,
        p_procesador     IN metodos_pago.procesador%TYPE,
        p_activo         IN metodos_pago.activo%TYPE
    ) IS
    BEGIN
        UPDATE metodos_pago
        SET descripcion = p_descripcion,
            tipo_pago   = p_tipo_pago,
            procesador  = p_procesador,
            activo      = p_activo
        WHERE id_metodo_pago = p_id_metodo_pago;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22102, 'No se encontró el método de pago para actualizar.');
        END IF;
    END update_metodo;

    PROCEDURE delete_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE
    ) IS
    BEGIN
        DELETE FROM metodos_pago
        WHERE id_metodo_pago = p_id_metodo_pago;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22103, 'No se encontró el método de pago para eliminar.');
        END IF;
    END delete_metodo;

END pkg_metodos_pago;
/