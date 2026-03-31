------------------------------------------------------------
-- Paquete CRUD para la tabla GRUPOS_VIAJE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_grupos_viaje AS
    PROCEDURE insert_grupo(
        p_nombre_grupo        IN grupos_viaje.nombre_grupo%TYPE,
        p_tipo_grupo          IN grupos_viaje.tipo_grupo%TYPE,
        p_cantidad_pasajeros  IN grupos_viaje.cantidad_pasajeros%TYPE,
        p_contacto_responsable IN grupos_viaje.contacto_responsable%TYPE,
        p_telefono_responsable IN grupos_viaje.telefono_responsable%TYPE,
        p_email_responsable   IN grupos_viaje.email_responsable%TYPE,
        p_observaciones       IN grupos_viaje.observaciones%TYPE
    );

    PROCEDURE get_grupo(
        p_id_grupo IN grupos_viaje.id_grupo%TYPE
    );

    PROCEDURE update_grupo(
        p_id_grupo            IN grupos_viaje.id_grupo%TYPE,
        p_nombre_grupo        IN grupos_viaje.nombre_grupo%TYPE,
        p_tipo_grupo          IN grupos_viaje.tipo_grupo%TYPE,
        p_cantidad_pasajeros  IN grupos_viaje.cantidad_pasajeros%TYPE,
        p_contacto_responsable IN grupos_viaje.contacto_responsable%TYPE,
        p_telefono_responsable IN grupos_viaje.telefono_responsable%TYPE,
        p_email_responsable   IN grupos_viaje.email_responsable%TYPE,
        p_observaciones       IN grupos_viaje.observaciones%TYPE
    );

    PROCEDURE delete_grupo(
        p_id_grupo IN grupos_viaje.id_grupo%TYPE
    );
END pkg_grupos_viaje;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_grupos_viaje AS

    PROCEDURE insert_grupo(
        p_nombre_grupo        IN grupos_viaje.nombre_grupo%TYPE,
        p_tipo_grupo          IN grupos_viaje.tipo_grupo%TYPE,
        p_cantidad_pasajeros  IN grupos_viaje.cantidad_pasajeros%TYPE,
        p_contacto_responsable IN grupos_viaje.contacto_responsable%TYPE,
        p_telefono_responsable IN grupos_viaje.telefono_responsable%TYPE,
        p_email_responsable   IN grupos_viaje.email_responsable%TYPE,
        p_observaciones       IN grupos_viaje.observaciones%TYPE
    ) IS
    BEGIN
        INSERT INTO grupos_viaje (
            nombre_grupo, tipo_grupo, cantidad_pasajeros,
            contacto_responsable, telefono_responsable,
            email_responsable, observaciones
        ) VALUES (
            p_nombre_grupo, p_tipo_grupo, p_cantidad_pasajeros,
            p_contacto_responsable, p_telefono_responsable,
            p_email_responsable, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22601, 'Error al insertar grupo de viaje: ' || SQLERRM);
    END insert_grupo;

    PROCEDURE get_grupo(
        p_id_grupo IN grupos_viaje.id_grupo%TYPE
    ) IS
        r grupos_viaje%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM grupos_viaje
        WHERE id_grupo = p_id_grupo;

        DBMS_OUTPUT.PUT_LINE('ID Grupo: ' || r.id_grupo);
        DBMS_OUTPUT.PUT_LINE('Nombre grupo: ' || r.nombre_grupo);
        DBMS_OUTPUT.PUT_LINE('Tipo grupo: ' || r.tipo_grupo);
        DBMS_OUTPUT.PUT_LINE('Cantidad pasajeros: ' || r.cantidad_pasajeros);
        DBMS_OUTPUT.PUT_LINE('Responsable: ' || r.contacto_responsable);
        DBMS_OUTPUT.PUT_LINE('Teléfono: ' || r.telefono_responsable);
        DBMS_OUTPUT.PUT_LINE('Email: ' || r.email_responsable);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Grupo de viaje no encontrado.');
    END get_grupo;

    PROCEDURE update_grupo(
        p_id_grupo            IN grupos_viaje.id_grupo%TYPE,
        p_nombre_grupo        IN grupos_viaje.nombre_grupo%TYPE,
        p_tipo_grupo          IN grupos_viaje.tipo_grupo%TYPE,
        p_cantidad_pasajeros  IN grupos_viaje.cantidad_pasajeros%TYPE,
        p_contacto_responsable IN grupos_viaje.contacto_responsable%TYPE,
        p_telefono_responsable IN grupos_viaje.telefono_responsable%TYPE,
        p_email_responsable   IN grupos_viaje.email_responsable%TYPE,
        p_observaciones       IN grupos_viaje.observaciones%TYPE
    ) IS
    BEGIN
        UPDATE grupos_viaje
        SET nombre_grupo        = p_nombre_grupo,
            tipo_grupo          = p_tipo_grupo,
            cantidad_pasajeros  = p_cantidad_pasajeros,
            contacto_responsable = p_contacto_responsable,
            telefono_responsable = p_telefono_responsable,
            email_responsable   = p_email_responsable,
            observaciones       = p_observaciones
        WHERE id_grupo = p_id_grupo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22602, 'No se encontró el grupo de viaje para actualizar.');
        END IF;
    END update_grupo;

    PROCEDURE delete_grupo(
        p_id_grupo IN grupos_viaje.id_grupo%TYPE
    ) IS
    BEGIN
        DELETE FROM grupos_viaje
        WHERE id_grupo = p_id_grupo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22603, 'No se encontró el grupo de viaje para eliminar.');
        END IF;
    END delete_grupo;

END pkg_grupos_viaje;
/