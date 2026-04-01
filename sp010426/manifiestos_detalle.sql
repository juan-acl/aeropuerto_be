------------------------------------------------------------
-- Paquete CRUD para la tabla MANIFIESTOS_DETALLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_manifiestos_detalle AS
    PROCEDURE insert_detalle(
        p_id_manifiesto IN NUMBER,
        p_id_envio      IN NUMBER,
        p_numero_orden  IN NUMBER,
        p_observaciones IN VARCHAR2
    );

    PROCEDURE get_detalle(
        p_id_detalle IN NUMBER
    );

    PROCEDURE update_detalle(
        p_id_detalle    IN NUMBER,
        p_id_manifiesto IN NUMBER,
        p_id_envio      IN NUMBER,
        p_numero_orden  IN NUMBER,
        p_observaciones IN VARCHAR2
    );

    PROCEDURE delete_detalle(
        p_id_detalle IN NUMBER
    );
END pkg_manifiestos_detalle;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_manifiestos_detalle AS

    PROCEDURE insert_detalle(
        p_id_manifiesto IN NUMBER,
        p_id_envio      IN NUMBER,
        p_numero_orden  IN NUMBER,
        p_observaciones IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO manifiestos_detalle (
            id_manifiesto, id_envio, numero_orden, observaciones
        ) VALUES (
            p_id_manifiesto, p_id_envio, p_numero_orden, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28801, 'Error al insertar detalle de manifiesto: ' || SQLERRM);
    END insert_detalle;

    PROCEDURE get_detalle(
        p_id_detalle IN NUMBER
    ) IS
        r manifiestos_detalle%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM manifiestos_detalle
        WHERE id_detalle = p_id_detalle;

        DBMS_OUTPUT.PUT_LINE('ID Detalle: ' || r.id_detalle);
        DBMS_OUTPUT.PUT_LINE('Manifiesto: ' || r.id_manifiesto);
        DBMS_OUTPUT.PUT_LINE('Envío: ' || r.id_envio);
        DBMS_OUTPUT.PUT_LINE('Número orden: ' || r.numero_orden);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Detalle de manifiesto no encontrado.');
    END get_detalle;

    PROCEDURE update_detalle(
        p_id_detalle    IN NUMBER,
        p_id_manifiesto IN NUMBER,
        p_id_envio      IN NUMBER,
        p_numero_orden  IN NUMBER,
        p_observaciones IN VARCHAR2
    ) IS
    BEGIN
        UPDATE manifiestos_detalle
        SET id_manifiesto = p_id_manifiesto,
            id_envio      = p_id_envio,
            numero_orden  = p_numero_orden,
            observaciones = p_observaciones
        WHERE id_detalle = p_id_detalle;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28802, 'No se encontró el detalle de manifiesto para actualizar.');
        END IF;
    END update_detalle;

    PROCEDURE delete_detalle(
        p_id_detalle IN NUMBER
    ) IS
    BEGIN
        DELETE FROM manifiestos_detalle
        WHERE id_detalle = p_id_detalle;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28803, 'No se encontró el detalle de manifiesto para eliminar.');
        END IF;
    END delete_detalle;

END pkg_manifiestos_detalle;
/
