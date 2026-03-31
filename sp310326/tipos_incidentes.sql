------------------------------------------------------------
-- Paquete CRUD para la tabla TIPOS_INCIDENTES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tipos_incidentes AS
    PROCEDURE insert_tipo(
        p_nombre_tipo        IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_protocolo_accion   IN VARCHAR2,
        p_tiempo_respuesta   IN NUMBER,
        p_activo             IN NUMBER DEFAULT 1
    );

    PROCEDURE get_tipo(
        p_id_tipo_incidente IN NUMBER
    );

    PROCEDURE update_tipo(
        p_id_tipo_incidente IN NUMBER,
        p_nombre_tipo        IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_protocolo_accion   IN VARCHAR2,
        p_tiempo_respuesta   IN NUMBER,
        p_activo             IN NUMBER
    );

    PROCEDURE delete_tipo(
        p_id_tipo_incidente IN NUMBER
    );
END pkg_tipos_incidentes;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tipos_incidentes AS

    PROCEDURE insert_tipo(
        p_nombre_tipo        IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_protocolo_accion   IN VARCHAR2,
        p_tiempo_respuesta   IN NUMBER,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        INSERT INTO tipos_incidentes (
            nombre_tipo, descripcion, protocolo_accion,
            tiempo_respuesta_estimado, activo
        ) VALUES (
            p_nombre_tipo, p_descripcion, p_protocolo_accion,
            p_tiempo_respuesta, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23501, 'Error al insertar tipo de incidente: ' || SQLERRM);
    END insert_tipo;

    PROCEDURE get_tipo(
        p_id_tipo_incidente IN NUMBER
    ) IS
        r tipos_incidentes%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tipos_incidentes
        WHERE id_tipo_incidente = p_id_tipo_incidente;

        DBMS_OUTPUT.PUT_LINE('ID Tipo incidente: ' || r.id_tipo_incidente);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_tipo);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Protocolo acción: ' || r.protocolo_accion);
        DBMS_OUTPUT.PUT_LINE('Tiempo respuesta estimado: ' || r.tiempo_respuesta_estimado);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Tipo de incidente no encontrado.');
    END get_tipo;

    PROCEDURE update_tipo(
        p_id_tipo_incidente IN NUMBER,
        p_nombre_tipo        IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_protocolo_accion   IN VARCHAR2,
        p_tiempo_respuesta   IN NUMBER,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        UPDATE tipos_incidentes
        SET nombre_tipo        = p_nombre_tipo,
            descripcion        = p_descripcion,
            protocolo_accion   = p_protocolo_accion,
            tiempo_respuesta_estimado = p_tiempo_respuesta,
            activo             = p_activo
        WHERE id_tipo_incidente = p_id_tipo_incidente;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23502, 'No se encontró el tipo de incidente para actualizar.');
        END IF;
    END update_tipo;

    PROCEDURE delete_tipo(
        p_id_tipo_incidente IN NUMBER
    ) IS
    BEGIN
        DELETE FROM tipos_incidentes
        WHERE id_tipo_incidente = p_id_tipo_incidente;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23503, 'No se encontró el tipo de incidente para eliminar.');
        END IF;
    END delete_tipo;

END pkg_tipos_incidentes;
/