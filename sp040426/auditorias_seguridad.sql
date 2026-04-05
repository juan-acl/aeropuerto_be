------------------------------------------------------------
-- Paquete CRUD para la tabla AUDITORIAS_SEGURIDAD
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_auditorias_seguridad AS
    PROCEDURE insert_auditoria(
        p_fecha_auditoria   IN DATE DEFAULT SYSDATE,
        p_tipo_auditoria    IN VARCHAR2,
        p_entidad_auditora  IN VARCHAR2,
        p_alcance           IN VARCHAR2,
        p_hallazgos         IN CLOB,
        p_recomendaciones   IN CLOB,
        p_fecha_cierre      IN DATE,
        p_responsable_cierre IN NUMBER,
        p_documento_auditoria IN BLOB,
        p_estado            IN VARCHAR2 DEFAULT 'EN_PROCESO'
    );

    PROCEDURE get_auditoria(
        p_id_auditoria_seguridad IN NUMBER
    );

    PROCEDURE update_auditoria(
        p_id_auditoria_seguridad IN NUMBER,
        p_fecha_auditoria   IN DATE,
        p_tipo_auditoria    IN VARCHAR2,
        p_entidad_auditora  IN VARCHAR2,
        p_alcance           IN VARCHAR2,
        p_hallazgos         IN CLOB,
        p_recomendaciones   IN CLOB,
        p_fecha_cierre      IN DATE,
        p_responsable_cierre IN NUMBER,
        p_documento_auditoria IN BLOB,
        p_estado            IN VARCHAR2
    );

    PROCEDURE delete_auditoria(
        p_id_auditoria_seguridad IN NUMBER
    );
END pkg_auditorias_seguridad;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_auditorias_seguridad AS

    PROCEDURE insert_auditoria(
        p_fecha_auditoria   IN DATE,
        p_tipo_auditoria    IN VARCHAR2,
        p_entidad_auditora  IN VARCHAR2,
        p_alcance           IN VARCHAR2,
        p_hallazgos         IN CLOB,
        p_recomendaciones   IN CLOB,
        p_fecha_cierre      IN DATE,
        p_responsable_cierre IN NUMBER,
        p_documento_auditoria IN BLOB,
        p_estado            IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO auditorias_seguridad (
            fecha_auditoria, tipo_auditoria, entidad_auditora,
            alcance, hallazgos, recomendaciones,
            fecha_cierre, responsable_cierre, documento_auditoria, estado
        ) VALUES (
            NVL(p_fecha_auditoria, SYSDATE), p_tipo_auditoria, p_entidad_auditora,
            p_alcance, p_hallazgos, p_recomendaciones,
            p_fecha_cierre, p_responsable_cierre, p_documento_auditoria, NVL(p_estado,'EN_PROCESO')
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32601, 'Error al insertar auditoría de seguridad: ' || SQLERRM);
    END insert_auditoria;

    PROCEDURE get_auditoria(
        p_id_auditoria_seguridad IN NUMBER
    ) IS
        r auditorias_seguridad%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM auditorias_seguridad
        WHERE id_auditoria_seguridad = p_id_auditoria_seguridad;

        DBMS_OUTPUT.PUT_LINE('ID Auditoría: ' || r.id_auditoria_seguridad);
        DBMS_OUTPUT.PUT_LINE('Fecha auditoría: ' || r.fecha_auditoria);
        DBMS_OUTPUT.PUT_LINE('Tipo auditoría: ' || r.tipo_auditoria);
        DBMS_OUTPUT.PUT_LINE('Entidad auditora: ' || r.entidad_auditora);
        DBMS_OUTPUT.PUT_LINE('Alcance: ' || r.alcance);
        DBMS_OUTPUT.PUT_LINE('Hallazgos: ' || DBMS_LOB.SUBSTR(r.hallazgos, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Recomendaciones: ' || DBMS_LOB.SUBSTR(r.recomendaciones, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Fecha cierre: ' || r.fecha_cierre);
        DBMS_OUTPUT.PUT_LINE('Responsable cierre: ' || r.responsable_cierre);
        IF r.documento_auditoria IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento auditoría: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento auditoría: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Auditoría de seguridad no encontrada.');
    END get_auditoria;

    PROCEDURE update_auditoria(
        p_id_auditoria_seguridad IN NUMBER,
        p_fecha_auditoria   IN DATE,
        p_tipo_auditoria    IN VARCHAR2,
        p_entidad_auditora  IN VARCHAR2,
        p_alcance           IN VARCHAR2,
        p_hallazgos         IN CLOB,
        p_recomendaciones   IN CLOB,
        p_fecha_cierre      IN DATE,
        p_responsable_cierre IN NUMBER,
        p_documento_auditoria IN BLOB,
        p_estado            IN VARCHAR2
    ) IS
    BEGIN
        UPDATE auditorias_seguridad
        SET fecha_auditoria   = p_fecha_auditoria,
            tipo_auditoria    = p_tipo_auditoria,
            entidad_auditora  = p_entidad_auditora,
            alcance           = p_alcance,
            hallazgos         = p_hallazgos,
            recomendaciones   = p_recomendaciones,
            fecha_cierre      = p_fecha_cierre,
            responsable_cierre = p_responsable_cierre,
            documento_auditoria = p_documento_auditoria,
            estado            = p_estado
        WHERE id_auditoria_seguridad = p_id_auditoria_seguridad;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32602, 'No se encontró la auditoría de seguridad para actualizar.');
        END IF;
    END update_auditoria;

    PROCEDURE delete_auditoria(
        p_id_auditoria_seguridad IN NUMBER
    ) IS
    BEGIN
        DELETE FROM auditorias_seguridad
        WHERE id_auditoria_seguridad = p_id_auditoria_seguridad;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32603, 'No se encontró la auditoría de seguridad para eliminar.');
        END IF;
    END delete_auditoria;

END pkg_auditorias_seguridad;
/
