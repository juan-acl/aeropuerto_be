------------------------------------------------------------
-- Paquete CRUD para la tabla GRUPOS_EMBARQUE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_grupos_embarque AS
    PROCEDURE insert_grupo(
        p_id_vuelo        IN grupos_embarque.id_vuelo%TYPE,
        p_numero_grupo    IN grupos_embarque.numero_grupo%TYPE,
        p_descripcion     IN grupos_embarque.descripcion%TYPE,
        p_orden           IN grupos_embarque.orden%TYPE,
        p_tiempo_estimado IN grupos_embarque.tiempo_estimado%TYPE
    );

    PROCEDURE get_grupo(
        p_id_grupo_embarque IN grupos_embarque.id_grupo_embarque%TYPE
    );

    PROCEDURE update_grupo(
        p_id_grupo_embarque IN grupos_embarque.id_grupo_embarque%TYPE,
        p_id_vuelo        IN grupos_embarque.id_vuelo%TYPE,
        p_numero_grupo    IN grupos_embarque.numero_grupo%TYPE,
        p_descripcion     IN grupos_embarque.descripcion%TYPE,
        p_orden           IN grupos_embarque.orden%TYPE,
        p_tiempo_estimado IN grupos_embarque.tiempo_estimado%TYPE
    );

    PROCEDURE delete_grupo(
        p_id_grupo_embarque IN grupos_embarque.id_grupo_embarque%TYPE
    );
END pkg_grupos_embarque;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_grupos_embarque AS

    PROCEDURE insert_grupo(
        p_id_vuelo        IN grupos_embarque.id_vuelo%TYPE,
        p_numero_grupo    IN grupos_embarque.numero_grupo%TYPE,
        p_descripcion     IN grupos_embarque.descripcion%TYPE,
        p_orden           IN grupos_embarque.orden%TYPE,
        p_tiempo_estimado IN grupos_embarque.tiempo_estimado%TYPE
    ) IS
    BEGIN
        INSERT INTO grupos_embarque (
            id_vuelo, numero_grupo, descripcion,
            orden, tiempo_estimado
        ) VALUES (
            p_id_vuelo, p_numero_grupo, p_descripcion,
            p_orden, p_tiempo_estimado
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23201, 'Error al insertar grupo de embarque: ' || SQLERRM);
    END insert_grupo;

    PROCEDURE get_grupo(
        p_id_grupo_embarque IN grupos_embarque.id_grupo_embarque%TYPE
    ) IS
        r grupos_embarque%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM grupos_embarque
        WHERE id_grupo_embarque = p_id_grupo_embarque;

        DBMS_OUTPUT.PUT_LINE('ID Grupo embarque: ' || r.id_grupo_embarque);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Número grupo: ' || r.numero_grupo);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Orden: ' || r.orden);
        DBMS_OUTPUT.PUT_LINE('Tiempo estimado: ' || r.tiempo_estimado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Grupo de embarque no encontrado.');
    END get_grupo;

    PROCEDURE update_grupo(
        p_id_grupo_embarque IN grupos_embarque.id_grupo_embarque%TYPE,
        p_id_vuelo        IN grupos_embarque.id_vuelo%TYPE,
        p_numero_grupo    IN grupos_embarque.numero_grupo%TYPE,
        p_descripcion     IN grupos_embarque.descripcion%TYPE,
        p_orden           IN grupos_embarque.orden%TYPE,
        p_tiempo_estimado IN grupos_embarque.tiempo_estimado%TYPE
    ) IS
    BEGIN
        UPDATE grupos_embarque
        SET id_vuelo        = p_id_vuelo,
            numero_grupo    = p_numero_grupo,
            descripcion     = p_descripcion,
            orden           = p_orden,
            tiempo_estimado = p_tiempo_estimado
        WHERE id_grupo_embarque = p_id_grupo_embarque;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23202, 'No se encontró el grupo de embarque para actualizar.');
        END IF;
    END update_grupo;

    PROCEDURE delete_grupo(
        p_id_grupo_embarque IN grupos_embarque.id_grupo_embarque%TYPE
    ) IS
    BEGIN
        DELETE FROM grupos_embarque
        WHERE id_grupo_embarque = p_id_grupo_embarque;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23203, 'No se encontró el grupo de embarque para eliminar.');
        END IF;
    END delete_grupo;

END pkg_grupos_embarque;
/