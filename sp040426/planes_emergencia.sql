------------------------------------------------------------
-- Paquete CRUD para la tabla PLANES_EMERGENCIA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_planes_emergencia AS
    PROCEDURE insert_plan(
        p_codigo_plan                IN VARCHAR2,
        p_nombre_plan                IN VARCHAR2,
        p_tipo_emergencia            IN VARCHAR2,
        p_nivel_activacion           IN VARCHAR2,
        p_descripcion                IN CLOB,
        p_procedimiento              IN CLOB,
        p_responsable_activacion     IN VARCHAR2,
        p_tiempo_respuesta_estimado  IN NUMBER,
        p_recursos_requeridos        IN CLOB,
        p_version                    IN VARCHAR2,
        p_fecha_creacion             IN DATE DEFAULT SYSDATE,
        p_fecha_ultima_revision      IN DATE,
        p_fecha_proxima_revision     IN DATE,
        p_documento_plan             IN BLOB,
        p_activo                     IN NUMBER DEFAULT 1
    );

    PROCEDURE get_plan(
        p_id_plan_emergencia IN NUMBER
    );

    PROCEDURE update_plan(
        p_id_plan_emergencia         IN NUMBER,
        p_codigo_plan                IN VARCHAR2,
        p_nombre_plan                IN VARCHAR2,
        p_tipo_emergencia            IN VARCHAR2,
        p_nivel_activacion           IN VARCHAR2,
        p_descripcion                IN CLOB,
        p_procedimiento              IN CLOB,
        p_responsable_activacion     IN VARCHAR2,
        p_tiempo_respuesta_estimado  IN NUMBER,
        p_recursos_requeridos        IN CLOB,
        p_version                    IN VARCHAR2,
        p_fecha_creacion             IN DATE,
        p_fecha_ultima_revision      IN DATE,
        p_fecha_proxima_revision     IN DATE,
        p_documento_plan             IN BLOB,
        p_activo                     IN NUMBER
    );

    PROCEDURE delete_plan(
        p_id_plan_emergencia IN NUMBER
    );
END pkg_planes_emergencia;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_planes_emergencia AS

    PROCEDURE insert_plan(
        p_codigo_plan                IN VARCHAR2,
        p_nombre_plan                IN VARCHAR2,
        p_tipo_emergencia            IN VARCHAR2,
        p_nivel_activacion           IN VARCHAR2,
        p_descripcion                IN CLOB,
        p_procedimiento              IN CLOB,
        p_responsable_activacion     IN VARCHAR2,
        p_tiempo_respuesta_estimado  IN NUMBER,
        p_recursos_requeridos        IN CLOB,
        p_version                    IN VARCHAR2,
        p_fecha_creacion             IN DATE,
        p_fecha_ultima_revision      IN DATE,
        p_fecha_proxima_revision     IN DATE,
        p_documento_plan             IN BLOB,
        p_activo                     IN NUMBER
    ) IS
    BEGIN
        INSERT INTO planes_emergencia (
            codigo_plan, nombre_plan, tipo_emergencia, nivel_activacion,
            descripcion, procedimiento, responsable_activacion,
            tiempo_respuesta_estimado_minutos, recursos_requeridos,
            version, fecha_creacion, fecha_ultima_revision,
            fecha_proxima_revision, documento_plan, activo
        ) VALUES (
            p_codigo_plan, p_nombre_plan, p_tipo_emergencia, p_nivel_activacion,
            p_descripcion, p_procedimiento, p_responsable_activacion,
            p_tiempo_respuesta_estimado, p_recursos_requeridos,
            p_version, NVL(p_fecha_creacion, SYSDATE), p_fecha_ultima_revision,
            p_fecha_proxima_revision, p_documento_plan, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35501, 'Error al insertar plan de emergencia: ' || SQLERRM);
    END insert_plan;

    PROCEDURE get_plan(
        p_id_plan_emergencia IN NUMBER
    ) IS
        r planes_emergencia%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM planes_emergencia
        WHERE id_plan_emergencia = p_id_plan_emergencia;

        DBMS_OUTPUT.PUT_LINE('ID Plan: ' || r.id_plan_emergencia);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_plan);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_plan);
        DBMS_OUTPUT.PUT_LINE('Tipo emergencia: ' || r.tipo_emergencia);
        DBMS_OUTPUT.PUT_LINE('Nivel activación: ' || r.nivel_activacion);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || DBMS_LOB.SUBSTR(r.descripcion,200,1));
        DBMS_OUTPUT.PUT_LINE('Procedimiento: ' || DBMS_LOB.SUBSTR(r.procedimiento,200,1));
        DBMS_OUTPUT.PUT_LINE('Responsable activación: ' || r.responsable_activacion);
        DBMS_OUTPUT.PUT_LINE('Tiempo respuesta estimado: ' || r.tiempo_respuesta_estimado_minutos);
        DBMS_OUTPUT.PUT_LINE('Recursos requeridos: ' || DBMS_LOB.SUBSTR(r.recursos_requeridos,200,1));
        DBMS_OUTPUT.PUT_LINE('Versión: ' || r.version);
        DBMS_OUTPUT.PUT_LINE('Fecha creación: ' || r.fecha_creacion);
        DBMS_OUTPUT.PUT_LINE('Última revisión: ' || r.fecha_ultima_revision);
        DBMS_OUTPUT.PUT_LINE('Próxima revisión: ' || r.fecha_proxima_revision);
        IF r.documento_plan IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento plan: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento plan: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Plan de emergencia no encontrado.');
    END get_plan;

    PROCEDURE update_plan(
        p_id_plan_emergencia         IN NUMBER,
        p_codigo_plan                IN VARCHAR2,
        p_nombre_plan                IN VARCHAR2,
        p_tipo_emergencia            IN VARCHAR2,
        p_nivel_activacion           IN VARCHAR2,
        p_descripcion                IN CLOB,
        p_procedimiento              IN CLOB,
        p_responsable_activacion     IN VARCHAR2,
        p_tiempo_respuesta_estimado  IN NUMBER,
        p_recursos_requeridos        IN CLOB,
        p_version                    IN VARCHAR2,
        p_fecha_creacion             IN DATE,
        p_fecha_ultima_revision      IN DATE,
        p_fecha_proxima_revision     IN DATE,
        p_documento_plan             IN BLOB,
        p_activo                     IN NUMBER
    ) IS
    BEGIN
        UPDATE planes_emergencia
        SET codigo_plan                = p_codigo_plan,
            nombre_plan                = p_nombre_plan,
            tipo_emergencia            = p_tipo_emergencia,
            nivel_activacion           = p_nivel_activacion,
            descripcion                = p_descripcion,
            procedimiento              = p_procedimiento,
            responsable_activacion     = p_responsable_activacion,
            tiempo_respuesta_estimado_minutos = p_tiempo_respuesta_estimado,
            recursos_requeridos        = p_recursos_requeridos,
            version                    = p_version,
            fecha_creacion             = p_fecha_creacion,
            fecha_ultima_revision      = p_fecha_ultima_revision,
            fecha_proxima_revision     = p_fecha_proxima_revision,
            documento_plan             = p_documento_plan,
            activo                     = p_activo
        WHERE id_plan_emergencia = p_id_plan_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35502, 'No se encontró el plan de emergencia para actualizar.');
        END IF;
    END update_plan;

    PROCEDURE delete_plan(
        p_id_plan_emergencia IN NUMBER
    ) IS
    BEGIN
        DELETE FROM planes_emergencia
        WHERE id_plan_emergencia = p_id_plan_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35503, 'No se encontró el plan de emergencia para eliminar.');
        END IF;
    END delete_plan;

END pkg_planes_emergencia;
/
