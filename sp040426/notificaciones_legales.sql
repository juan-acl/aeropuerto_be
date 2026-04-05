------------------------------------------------------------
-- Paquete CRUD para la tabla NOTIFICACIONES_LEGALES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_notificaciones_legales AS
    PROCEDURE insert_notificacion(
        p_numero_notificacion     IN VARCHAR2,
        p_remitente_nombre        IN VARCHAR2,
        p_remitente_tipo          IN VARCHAR2,
        p_destinatario_interno    IN NUMBER,
        p_asunto                  IN VARCHAR2,
        p_descripcion             IN CLOB,
        p_fecha_recepcion         IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_fecha_respuesta_requerida IN DATE,
        p_prioridad               IN VARCHAR2,
        p_documento_recibido      IN BLOB,
        p_area_responsable        IN NUMBER,
        p_usuario_asignado        IN NUMBER,
        p_estado                  IN VARCHAR2 DEFAULT 'RECIBIDO',
        p_fecha_respuesta         IN TIMESTAMP,
        p_respuesta               IN CLOB,
        p_documento_respuesta     IN BLOB
    );

    PROCEDURE get_notificacion(
        p_id_notificacion_legal IN NUMBER
    );

    PROCEDURE update_notificacion(
        p_id_notificacion_legal IN NUMBER,
        p_numero_notificacion     IN VARCHAR2,
        p_remitente_nombre        IN VARCHAR2,
        p_remitente_tipo          IN VARCHAR2,
        p_destinatario_interno    IN NUMBER,
        p_asunto                  IN VARCHAR2,
        p_descripcion             IN CLOB,
        p_fecha_recepcion         IN TIMESTAMP,
        p_fecha_respuesta_requerida IN DATE,
        p_prioridad               IN VARCHAR2,
        p_documento_recibido      IN BLOB,
        p_area_responsable        IN NUMBER,
        p_usuario_asignado        IN NUMBER,
        p_estado                  IN VARCHAR2,
        p_fecha_respuesta         IN TIMESTAMP,
        p_respuesta               IN CLOB,
        p_documento_respuesta     IN BLOB
    );

    PROCEDURE delete_notificacion(
        p_id_notificacion_legal IN NUMBER
    );
END pkg_notificaciones_legales;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_notificaciones_legales AS

    PROCEDURE insert_notificacion(
        p_numero_notificacion     IN VARCHAR2,
        p_remitente_nombre        IN VARCHAR2,
        p_remitente_tipo          IN VARCHAR2,
        p_destinatario_interno    IN NUMBER,
        p_asunto                  IN VARCHAR2,
        p_descripcion             IN CLOB,
        p_fecha_recepcion         IN TIMESTAMP,
        p_fecha_respuesta_requerida IN DATE,
        p_prioridad               IN VARCHAR2,
        p_documento_recibido      IN BLOB,
        p_area_responsable        IN NUMBER,
        p_usuario_asignado        IN NUMBER,
        p_estado                  IN VARCHAR2,
        p_fecha_respuesta         IN TIMESTAMP,
        p_respuesta               IN CLOB,
        p_documento_respuesta     IN BLOB
    ) IS
    BEGIN
        INSERT INTO notificaciones_legales (
            numero_notificacion, remitente_nombre, remitente_tipo,
            destinatario_interno, asunto, descripcion,
            fecha_recepcion, fecha_respuesta_requerida, prioridad,
            documento_recibido, area_responsable, usuario_asignado,
            estado, fecha_respuesta, respuesta, documento_respuesta
        ) VALUES (
            p_numero_notificacion, p_remitente_nombre, p_remitente_tipo,
            p_destinatario_interno, p_asunto, p_descripcion,
            NVL(p_fecha_recepcion, SYSTIMESTAMP), p_fecha_respuesta_requerida, p_prioridad,
            p_documento_recibido, p_area_responsable, p_usuario_asignado,
            NVL(p_estado,'RECIBIDO'), p_fecha_respuesta, p_respuesta, p_documento_respuesta
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34101, 'Error al insertar notificación legal: ' || SQLERRM);
    END insert_notificacion;

    PROCEDURE get_notificacion(
        p_id_notificacion_legal IN NUMBER
    ) IS
        r notificaciones_legales%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM notificaciones_legales
        WHERE id_notificacion_legal = p_id_notificacion_legal;

        DBMS_OUTPUT.PUT_LINE('ID Notificación: ' || r.id_notificacion_legal);
        DBMS_OUTPUT.PUT_LINE('Número: ' || r.numero_notificacion);
        DBMS_OUTPUT.PUT_LINE('Remitente: ' || r.remitente_nombre || ' (' || r.remitente_tipo || ')');
        DBMS_OUTPUT.PUT_LINE('Destinatario interno: ' || r.destinatario_interno);
        DBMS_OUTPUT.PUT_LINE('Asunto: ' || r.asunto);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || DBMS_LOB.SUBSTR(r.descripcion, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Fecha recepción: ' || r.fecha_recepcion);
        DBMS_OUTPUT.PUT_LINE('Fecha respuesta requerida: ' || r.fecha_respuesta_requerida);
        DBMS_OUTPUT.PUT_LINE('Prioridad: ' || r.prioridad);
        IF r.documento_recibido IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento recibido: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento recibido: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Área responsable: ' || r.area_responsable);
        DBMS_OUTPUT.PUT_LINE('Usuario asignado: ' || r.usuario_asignado);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Fecha respuesta: ' || r.fecha_respuesta);
        DBMS_OUTPUT.PUT_LINE('Respuesta: ' || DBMS_LOB.SUBSTR(r.respuesta, 200, 1));
        IF r.documento_respuesta IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento respuesta: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento respuesta: No adjunto');
        END IF;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Notificación legal no encontrada.');
    END get_notificacion;

    PROCEDURE update_notificacion(
        p_id_notificacion_legal IN NUMBER,
        p_numero_notificacion     IN VARCHAR2,
        p_remitente_nombre        IN VARCHAR2,
        p_remitente_tipo          IN VARCHAR2,
        p_destinatario_interno    IN NUMBER,
        p_asunto                  IN VARCHAR2,
        p_descripcion             IN CLOB,
        p_fecha_recepcion         IN TIMESTAMP,
        p_fecha_respuesta_requerida IN DATE,
        p_prioridad               IN VARCHAR2,
        p_documento_recibido      IN BLOB,
        p_area_responsable        IN NUMBER,
        p_usuario_asignado        IN NUMBER,
        p_estado                  IN VARCHAR2,
        p_fecha_respuesta         IN TIMESTAMP,
        p_respuesta               IN CLOB,
        p_documento_respuesta     IN BLOB
    ) IS
    BEGIN
        UPDATE notificaciones_legales
        SET numero_notificacion     = p_numero_notificacion,
            remitente_nombre        = p_remitente_nombre,
            remitente_tipo          = p_remitente_tipo,
            destinatario_interno    = p_destinatario_interno,
            asunto                  = p_asunto,
            descripcion             = p_descripcion,
            fecha_recepcion         = p_fecha_recepcion,
            fecha_respuesta_requerida = p_fecha_respuesta_requerida,
            prioridad               = p_prioridad,
            documento_recibido      = p_documento_recibido,
            area_responsable        = p_area_responsable,
            usuario_asignado        = p_usuario_asignado,
            estado                  = p_estado,
            fecha_respuesta         = p_fecha_respuesta,
            respuesta               = p_respuesta,
            documento_respuesta     = p_documento_respuesta
        WHERE id_notificacion_legal = p_id_notificacion_legal;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34102, 'No se encontró la notificación legal para actualizar.');
        END IF;
    END update_notificacion;

    PROCEDURE delete_notificacion(
        p_id_notificacion_legal IN NUMBER
    ) IS
    BEGIN
        DELETE FROM notificaciones_legales
        WHERE id_notificacion_legal = p_id_notificacion_legal;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34103, 'No se encontró la notificación legal para eliminar.');
        END IF;
    END delete_notificacion;

END pkg_notificaciones_legales;
/
