------------------------------------------------------------
-- Paquete CRUD para la tabla LICENCIAS_OPERATIVAS_AEROPUERTO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_licencias_operativas AS
    PROCEDURE insert_licencia(
        p_codigo_licencia       IN VARCHAR2,
        p_nombre_licencia       IN VARCHAR2,
        p_tipo_licencia         IN VARCHAR2,
        p_entidad_otorgante     IN VARCHAR2,
        p_fecha_emision         IN DATE,
        p_fecha_vencimiento     IN DATE,
        p_fecha_renovacion      IN DATE,
        p_alcance               IN VARCHAR2,
        p_restricciones         IN VARCHAR2,
        p_documento_licencia    IN BLOB,
        p_responsable_seguimiento IN NUMBER,
        p_renovacion_automatica IN NUMBER DEFAULT 0,
        p_activa                IN NUMBER DEFAULT 1,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE get_licencia(
        p_id_licencia_operativa IN NUMBER
    );

    PROCEDURE update_licencia(
        p_id_licencia_operativa IN NUMBER,
        p_codigo_licencia       IN VARCHAR2,
        p_nombre_licencia       IN VARCHAR2,
        p_tipo_licencia         IN VARCHAR2,
        p_entidad_otorgante     IN VARCHAR2,
        p_fecha_emision         IN DATE,
        p_fecha_vencimiento     IN DATE,
        p_fecha_renovacion      IN DATE,
        p_alcance               IN VARCHAR2,
        p_restricciones         IN VARCHAR2,
        p_documento_licencia    IN BLOB,
        p_responsable_seguimiento IN NUMBER,
        p_renovacion_automatica IN NUMBER,
        p_activa                IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE delete_licencia(
        p_id_licencia_operativa IN NUMBER
    );
END pkg_licencias_operativas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_licencias_operativas AS

    PROCEDURE insert_licencia(
        p_codigo_licencia       IN VARCHAR2,
        p_nombre_licencia       IN VARCHAR2,
        p_tipo_licencia         IN VARCHAR2,
        p_entidad_otorgante     IN VARCHAR2,
        p_fecha_emision         IN DATE,
        p_fecha_vencimiento     IN DATE,
        p_fecha_renovacion      IN DATE,
        p_alcance               IN VARCHAR2,
        p_restricciones         IN VARCHAR2,
        p_documento_licencia    IN BLOB,
        p_responsable_seguimiento IN NUMBER,
        p_renovacion_automatica IN NUMBER,
        p_activa                IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO licencias_operativas_aeropuerto (
            codigo_licencia, nombre_licencia, tipo_licencia,
            entidad_otorgante, fecha_emision, fecha_vencimiento,
            fecha_renovacion, alcance, restricciones,
            documento_licencia, responsable_seguimiento,
            renovacion_automatica, activa, observaciones
        ) VALUES (
            p_codigo_licencia, p_nombre_licencia, p_tipo_licencia,
            p_entidad_otorgante, p_fecha_emision, p_fecha_vencimiento,
            p_fecha_renovacion, p_alcance, p_restricciones,
            p_documento_licencia, p_responsable_seguimiento,
            NVL(p_renovacion_automatica,0), NVL(p_activa,1), p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33701, 'Error al insertar licencia operativa: ' || SQLERRM);
    END insert_licencia;

    PROCEDURE get_licencia(
        p_id_licencia_operativa IN NUMBER
    ) IS
        r licencias_operativas_aeropuerto%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM licencias_operativas_aeropuerto
        WHERE id_licencia_operativa = p_id_licencia_operativa;

        DBMS_OUTPUT.PUT_LINE('ID Licencia: ' || r.id_licencia_operativa);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_licencia);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_licencia);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_licencia);
        DBMS_OUTPUT.PUT_LINE('Entidad otorgante: ' || r.entidad_otorgante);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento);
        DBMS_OUTPUT.PUT_LINE('Fecha renovación: ' || r.fecha_renovacion);
        DBMS_OUTPUT.PUT_LINE('Alcance: ' || r.alcance);
        DBMS_OUTPUT.PUT_LINE('Restricciones: ' || r.restricciones);
        IF r.documento_licencia IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento licencia: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento licencia: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Responsable seguimiento: ' || r.responsable_seguimiento);
        DBMS_OUTPUT.PUT_LINE('Renovación automática: ' || r.renovacion_automatica);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Licencia operativa no encontrada.');
    END get_licencia;

    PROCEDURE update_licencia(
        p_id_licencia_operativa IN NUMBER,
        p_codigo_licencia       IN VARCHAR2,
        p_nombre_licencia       IN VARCHAR2,
        p_tipo_licencia         IN VARCHAR2,
        p_entidad_otorgante     IN VARCHAR2,
        p_fecha_emision         IN DATE,
        p_fecha_vencimiento     IN DATE,
        p_fecha_renovacion      IN DATE,
        p_alcance               IN VARCHAR2,
        p_restricciones         IN VARCHAR2,
        p_documento_licencia    IN BLOB,
        p_responsable_seguimiento IN NUMBER,
        p_renovacion_automatica IN NUMBER,
        p_activa                IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        UPDATE licencias_operativas_aeropuerto
        SET codigo_licencia       = p_codigo_licencia,
            nombre_licencia       = p_nombre_licencia,
            tipo_licencia         = p_tipo_licencia,
            entidad_otorgante     = p_entidad_otorgante,
            fecha_emision         = p_fecha_emision,
            fecha_vencimiento     = p_fecha_vencimiento,
            fecha_renovacion      = p_fecha_renovacion,
            alcance               = p_alcance,
            restricciones         = p_restricciones,
            documento_licencia    = p_documento_licencia,
            responsable_seguimiento = p_responsable_seguimiento,
            renovacion_automatica = p_renovacion_automatica,
            activa                = p_activa,
            observaciones         = p_observaciones
        WHERE id_licencia_operativa = p_id_licencia_operativa;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33702, 'No se encontró la licencia operativa para actualizar.');
        END IF;
    END update_licencia;

    PROCEDURE delete_licencia(
        p_id_licencia_operativa IN NUMBER
    ) IS
    BEGIN
        DELETE FROM licencias_operativas_aeropuerto
        WHERE id_licencia_operativa = p_id_licencia_operativa;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33703, 'No se encontró la licencia operativa para eliminar.');
        END IF;
    END delete_licencia;

END pkg_licencias_operativas;
/
