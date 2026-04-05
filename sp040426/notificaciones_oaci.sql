------------------------------------------------------------
-- Paquete CRUD para la tabla NOTIFICACIONES_OACI
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_notificaciones_oaci AS
    PROCEDURE insert_notificacion(
        p_numero_notificacion      IN VARCHAR2,
        p_fecha_recepcion          IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_tipo_notificacion        IN VARCHAR2,
        p_asunto                   IN VARCHAR2,
        p_descripcion              IN CLOB,
        p_fecha_limite_cumplimiento IN DATE,
        p_documento_notificacion   IN BLOB,
        p_area_responsable         IN NUMBER,
        p_estado_cumplimiento      IN VARCHAR2 DEFAULT 'PENDIENTE',
        p_fecha_cumplimiento       IN DATE,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE get_notificacion(
        p_id_notificacion_oaci IN NUMBER
    );

    PROCEDURE update_notificacion(
        p_id_notificacion_oaci     IN NUMBER,
        p_numero_notificacion      IN VARCHAR2,
        p_fecha_recepcion          IN TIMESTAMP,
        p_tipo_notificacion        IN VARCHAR2,
        p_asunto                   IN VARCHAR2,
        p_descripcion              IN CLOB,
        p_fecha_limite_cumplimiento IN DATE,
        p_documento_notificacion   IN BLOB,
        p_area_responsable         IN NUMBER,
        p_estado_cumplimiento      IN VARCHAR2,
        p_fecha_cumplimiento       IN DATE,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE delete_notificacion(
        p_id_notificacion_oaci IN NUMBER
    );
END pkg_notificaciones_oaci;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_notificaciones_oaci AS

    PROCEDURE insert_notificacion(
        p_numero_notificacion      IN VARCHAR2,
        p_fecha_recepcion          IN TIMESTAMP,
        p_tipo_notificacion        IN VARCHAR2,
        p_asunto                   IN VARCHAR2,
        p_descripcion              IN CLOB,
        p_fecha_limite_cumplimiento IN DATE,
        p_documento_notificacion   IN BLOB,
        p_area_responsable         IN NUMBER,
        p_estado_cumplimiento      IN VARCHAR2,
        p_fecha_cumplimiento       IN DATE,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO notificaciones_oaci (
            numero_notificacion, fecha_recepcion, tipo_notificacion,
            asunto, descripcion, fecha_limite_cumplimiento,
            documento_notificacion, area_responsable, estado_cumplimiento,
            fecha_cumplimiento, observaciones
        ) VALUES (
            p_numero_notificacion, NVL(p_fecha_recepcion, SYSTIMESTAMP), p_tipo_notificacion,
            p_asunto, p_descripcion, p_fecha_limite_cumplimiento,
            p_documento_notificacion, p_area_responsable, NVL(p_estado_cumplimiento,'PENDIENTE'),
            p_fecha_cumplimiento, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36801, 'Error al insertar notificación OACI: ' || SQLERRM);
    END insert_notificacion;

    PROCEDURE get_notificacion(
        p_id_notificacion_oaci IN NUMBER
    ) IS
        r notificaciones_oaci%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM notificaciones_oaci
        WHERE id_notificacion_oaci = p_id_notificacion_oaci;

        DBMS_OUTPUT.PUT_LINE('ID Notificación: ' || r.id_notificacion_oaci);
        DBMS_OUTPUT.PUT_LINE('Número: ' || r.numero_notificacion);
        DBMS_OUTPUT.PUT_LINE('Fecha recepción: ' || r.fecha_recepcion);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_notificacion);
        DBMS_OUTPUT.PUT_LINE('Asunto: ' || r.asunto);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || DBMS_LOB.SUBSTR(r.descripcion,200,1));
        DBMS_OUTPUT.PUT_LINE('Fecha límite cumplimiento: ' || r.fecha_limite_cumplimiento);
        IF r.documento_notificacion IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento notificación: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento notificación: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Área responsable: ' || r.area_responsable);
        DBMS_OUTPUT.PUT_LINE('Estado cumplimiento: ' || r.estado_cumplimiento);
        DBMS_OUTPUT.PUT_LINE('Fecha cumplimiento: ' || r.fecha_cumplimiento);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Notificación OACI no encontrada.');
    END get_notificacion;

    PROCEDURE update_notificacion(
        p_id_notificacion_oaci     IN NUMBER,
        p_numero_notificacion      IN VARCHAR2,
        p_fecha_recepcion          IN TIMESTAMP,
        p_tipo_notificacion        IN VARCHAR2,
        p_asunto                   IN VARCHAR2,
        p_descripcion              IN CLOB,
        p_fecha_limite_cumplimiento IN DATE,
        p_documento_notificacion   IN BLOB,
        p_area_responsable         IN NUMBER,
        p_estado_cumplimiento      IN VARCHAR2,
        p_fecha_cumplimiento       IN DATE,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        UPDATE notificaciones_oaci
        SET numero_notificacion      = p_numero_notificacion,
            fecha_recepcion          = p_fecha_recepcion,
            tipo_notificacion        = p_tipo_notificacion,
            asunto                   = p_asunto,
            descripcion              = p_descripcion,
            fecha_limite_cumplimiento = p_fecha_limite_cumplimiento,
            documento_notificacion   = p_documento_notificacion,
            area_responsable         = p_area_responsable,
            estado_cumplimiento      = p_estado_cumplimiento,
            fecha_cumplimiento       = p_fecha_cumplimiento,
            observaciones            = p_observaciones
        WHERE id_notificacion_oaci = p_id_notificacion_oaci;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36802, 'No se encontró la notificación OACI para actualizar.');
        END IF;
    END update_notificacion;

    PROCEDURE delete_notificacion(
        p_id_notificacion_oaci IN NUMBER
    ) IS
    BEGIN
        DELETE FROM notificaciones_oaci
        WHERE id_notificacion_oaci = p_id_notificacion_oaci;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36803, 'No se encontró la notificación OACI para eliminar.');
        END IF;
    END delete_notificacion;

END pkg_notificaciones_oaci;
/
