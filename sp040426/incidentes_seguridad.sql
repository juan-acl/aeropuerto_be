------------------------------------------------------------
-- Paquete CRUD para la tabla INCIDENTES_SEGURIDAD_INFORMATICA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_incidentes_seguridad AS
    PROCEDURE insert_incidente(
        p_fecha_deteccion         IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_tipo_incidente          IN VARCHAR2,
        p_nivel_gravedad          IN VARCHAR2,
        p_descripcion             IN VARCHAR2,
        p_ip_origen               IN VARCHAR2,
        p_usuario_afectado        IN NUMBER,
        p_acciones_tomadas        IN VARCHAR2,
        p_fecha_resolucion        IN TIMESTAMP,
        p_responsable_resolucion  IN NUMBER,
        p_requiere_notificacion_legal IN NUMBER DEFAULT 0,
        p_notificado_legal        IN NUMBER DEFAULT 0,
        p_estado                  IN VARCHAR2 DEFAULT 'ACTIVO'
    );

    PROCEDURE get_incidente(
        p_id_incidente_seguridad_info IN NUMBER
    );

    PROCEDURE update_incidente(
        p_id_incidente_seguridad_info IN NUMBER,
        p_fecha_deteccion         IN TIMESTAMP,
        p_tipo_incidente          IN VARCHAR2,
        p_nivel_gravedad          IN VARCHAR2,
        p_descripcion             IN VARCHAR2,
        p_ip_origen               IN VARCHAR2,
        p_usuario_afectado        IN NUMBER,
        p_acciones_tomadas        IN VARCHAR2,
        p_fecha_resolucion        IN TIMESTAMP,
        p_responsable_resolucion  IN NUMBER,
        p_requiere_notificacion_legal IN NUMBER,
        p_notificado_legal        IN NUMBER,
        p_estado                  IN VARCHAR2
    );

    PROCEDURE delete_incidente(
        p_id_incidente_seguridad_info IN NUMBER
    );
END pkg_incidentes_seguridad;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_incidentes_seguridad AS

    PROCEDURE insert_incidente(
        p_fecha_deteccion         IN TIMESTAMP,
        p_tipo_incidente          IN VARCHAR2,
        p_nivel_gravedad          IN VARCHAR2,
        p_descripcion             IN VARCHAR2,
        p_ip_origen               IN VARCHAR2,
        p_usuario_afectado        IN NUMBER,
        p_acciones_tomadas        IN VARCHAR2,
        p_fecha_resolucion        IN TIMESTAMP,
        p_responsable_resolucion  IN NUMBER,
        p_requiere_notificacion_legal IN NUMBER,
        p_notificado_legal        IN NUMBER,
        p_estado                  IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO incidentes_seguridad_informatica (
            fecha_deteccion, tipo_incidente, nivel_gravedad,
            descripcion, ip_origen, usuario_afectado,
            acciones_tomadas, fecha_resolucion, responsable_resolucion,
            requiere_notificacion_legal, notificado_legal, estado
        ) VALUES (
            NVL(p_fecha_deteccion, SYSTIMESTAMP), p_tipo_incidente, p_nivel_gravedad,
            p_descripcion, p_ip_origen, p_usuario_afectado,
            p_acciones_tomadas, p_fecha_resolucion, p_responsable_resolucion,
            NVL(p_requiere_notificacion_legal,0), NVL(p_notificado_legal,0), NVL(p_estado,'ACTIVO')
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32401, 'Error al insertar incidente de seguridad: ' || SQLERRM);
    END insert_incidente;

    PROCEDURE get_incidente(
        p_id_incidente_seguridad_info IN NUMBER
    ) IS
        r incidentes_seguridad_informatica%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM incidentes_seguridad_informatica
        WHERE id_incidente_seguridad_info = p_id_incidente_seguridad_info;

        DBMS_OUTPUT.PUT_LINE('ID Incidente: ' || r.id_incidente_seguridad_info);
        DBMS_OUTPUT.PUT_LINE('Fecha detección: ' || r.fecha_deteccion);
        DBMS_OUTPUT.PUT_LINE('Tipo incidente: ' || r.tipo_incidente);
        DBMS_OUTPUT.PUT_LINE('Nivel gravedad: ' || r.nivel_gravedad);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('IP origen: ' || r.ip_origen);
        DBMS_OUTPUT.PUT_LINE('Usuario afectado: ' || r.usuario_afectado);
        DBMS_OUTPUT.PUT_LINE('Acciones tomadas: ' || r.acciones_tomadas);
        DBMS_OUTPUT.PUT_LINE('Fecha resolución: ' || r.fecha_resolucion);
        DBMS_OUTPUT.PUT_LINE('Responsable resolución: ' || r.responsable_resolucion);
        DBMS_OUTPUT.PUT_LINE('Requiere notificación legal: ' || r.requiere_notificacion_legal);
        DBMS_OUTPUT.PUT_LINE('Notificado legal: ' || r.notificado_legal);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Incidente de seguridad no encontrado.');
    END get_incidente;

    PROCEDURE update_incidente(
        p_id_incidente_seguridad_info IN NUMBER,
        p_fecha_deteccion         IN TIMESTAMP,
        p_tipo_incidente          IN VARCHAR2,
        p_nivel_gravedad          IN VARCHAR2,
        p_descripcion             IN VARCHAR2,
        p_ip_origen               IN VARCHAR2,
        p_usuario_afectado        IN NUMBER,
        p_acciones_tomadas        IN VARCHAR2,
        p_fecha_resolucion        IN TIMESTAMP,
        p_responsable_resolucion  IN NUMBER,
        p_requiere_notificacion_legal IN NUMBER,
        p_notificado_legal        IN NUMBER,
        p_estado                  IN VARCHAR2
    ) IS
    BEGIN
        UPDATE incidentes_seguridad_informatica
        SET fecha_deteccion         = p_fecha_deteccion,
            tipo_incidente          = p_tipo_incidente,
            nivel_gravedad          = p_nivel_gravedad,
            descripcion             = p_descripcion,
            ip_origen               = p_ip_origen,
            usuario_afectado        = p_usuario_afectado,
            acciones_tomadas        = p_acciones_tomadas,
            fecha_resolucion        = p_fecha_resolucion,
            responsable_resolucion  = p_responsable_resolucion,
            requiere_notificacion_legal = p_requiere_notificacion_legal,
            notificado_legal        = p_notificado_legal,
            estado                  = p_estado
        WHERE id_incidente_seguridad_info = p_id_incidente_seguridad_info;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32402, 'No se encontró el incidente de seguridad para actualizar.');
        END IF;
    END update_incidente;

    PROCEDURE delete_incidente(
        p_id_incidente_seguridad_info IN NUMBER
    ) IS
    BEGIN
        DELETE FROM incidentes_seguridad_informatica
        WHERE id_incidente_seguridad_info = p_id_incidente_seguridad_info;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32403, 'No se encontró el incidente de seguridad para eliminar.');
        END IF;
    END delete_incidente;

END pkg_incidentes_seguridad;
/
