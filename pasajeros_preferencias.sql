------------------------------------------------------------
-- Paquete CRUD para la tabla PASAJEROS_PREFERENCIAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pasajeros_preferencias AS
    PROCEDURE insert_preferencia(
        p_id_pasajero       IN pasajeros_preferencias.id_pasajero%TYPE,
        p_tipo_preferencia  IN pasajeros_preferencias.tipo_preferencia%TYPE,
        p_descripcion       IN pasajeros_preferencias.descripcion%TYPE,
        p_activo            IN pasajeros_preferencias.activo%TYPE DEFAULT 1,
        p_fecha_actualizacion IN pasajeros_preferencias.fecha_actualizacion%TYPE
    );

    PROCEDURE get_preferencia(
        p_id_preferencia IN pasajeros_preferencias.id_preferencia%TYPE
    );

    PROCEDURE update_preferencia(
        p_id_preferencia   IN pasajeros_preferencias.id_preferencia%TYPE,
        p_id_pasajero      IN pasajeros_preferencias.id_pasajero%TYPE,
        p_tipo_preferencia IN pasajeros_preferencias.tipo_preferencia%TYPE,
        p_descripcion      IN pasajeros_preferencias.descripcion%TYPE,
        p_activo           IN pasajeros_preferencias.activo%TYPE,
        p_fecha_actualizacion IN pasajeros_preferencias.fecha_actualizacion%TYPE
    );

    PROCEDURE delete_preferencia(
        p_id_preferencia IN pasajeros_preferencias.id_preferencia%TYPE
    );
END pkg_pasajeros_preferencias;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pasajeros_preferencias AS

    PROCEDURE insert_preferencia(
        p_id_pasajero       IN pasajeros_preferencias.id_pasajero%TYPE,
        p_tipo_preferencia  IN pasajeros_preferencias.tipo_preferencia%TYPE,
        p_descripcion       IN pasajeros_preferencias.descripcion%TYPE,
        p_activo            IN pasajeros_preferencias.activo%TYPE,
        p_fecha_actualizacion IN pasajeros_preferencias.fecha_actualizacion%TYPE
    ) IS
    BEGIN
        INSERT INTO pasajeros_preferencias (
            id_pasajero, tipo_preferencia, descripcion,
            activo, fecha_actualizacion
        ) VALUES (
            p_id_pasajero, p_tipo_preferencia, p_descripcion,
            NVL(p_activo,1), p_fecha_actualizacion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21901, 'Error al insertar preferencia: ' || SQLERRM);
    END insert_preferencia;

    PROCEDURE get_preferencia(
        p_id_preferencia IN pasajeros_preferencias.id_preferencia%TYPE
    ) IS
        r pasajeros_preferencias%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM pasajeros_preferencias
        WHERE id_preferencia = p_id_preferencia;

        DBMS_OUTPUT.PUT_LINE('ID Preferencia: ' || r.id_preferencia);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Tipo preferencia: ' || r.tipo_preferencia);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        DBMS_OUTPUT.PUT_LINE('Fecha actualización: ' || r.fecha_actualizacion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Preferencia no encontrada.');
    END get_preferencia;

    PROCEDURE update_preferencia(
        p_id_preferencia   IN pasajeros_preferencias.id_preferencia%TYPE,
        p_id_pasajero      IN pasajeros_preferencias.id_pasajero%TYPE,
        p_tipo_preferencia IN pasajeros_preferencias.tipo_preferencia%TYPE,
        p_descripcion      IN pasajeros_preferencias.descripcion%TYPE,
        p_activo           IN pasajeros_preferencias.activo%TYPE,
        p_fecha_actualizacion IN pasajeros_preferencias.fecha_actualizacion%TYPE
    ) IS
    BEGIN
        UPDATE pasajeros_preferencias
        SET id_pasajero      = p_id_pasajero,
            tipo_preferencia = p_tipo_preferencia,
            descripcion      = p_descripcion,
            activo           = p_activo,
            fecha_actualizacion = p_fecha_actualizacion
        WHERE id_preferencia = p_id_preferencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21902, 'No se encontró la preferencia para actualizar.');
        END IF;
    END update_preferencia;

    PROCEDURE delete_preferencia(
        p_id_preferencia IN pasajeros_preferencias.id_preferencia%TYPE
    ) IS
    BEGIN
        DELETE FROM pasajeros_preferencias
        WHERE id_preferencia = p_id_preferencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21903, 'No se encontró la preferencia para eliminar.');
        END IF;
    END delete_preferencia;

END pkg_pasajeros_preferencias;
/