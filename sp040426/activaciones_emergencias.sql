------------------------------------------------------------
-- Paquete CRUD para la tabla ACTIVACIONES_EMERGENCIA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_activaciones_emergencia AS
    PROCEDURE insert_activacion(
        p_fecha_hora_activacion   IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_tipo_emergencia         IN VARCHAR2,
        p_id_plan_emergencia      IN NUMBER,
        p_nivel_activacion        IN VARCHAR2,
        p_descripcion_incidente   IN CLOB,
        p_lugar_incidente         IN VARCHAR2,
        p_personas_afectadas      IN NUMBER,
        p_personas_atendidas      IN NUMBER,
        p_recursos_movilizados    IN CLOB,
        p_hora_control            IN TIMESTAMP,
        p_hora_fin                IN TIMESTAMP,
        p_estado                  IN VARCHAR2 DEFAULT 'ACTIVA',
        p_responsable_coordinacion IN VARCHAR2,
        p_informe_incidente       IN CLOB,
        p_lecciones_aprendidas    IN CLOB
    );

    PROCEDURE get_activacion(
        p_id_activacion IN NUMBER
    );

    PROCEDURE update_activacion(
        p_id_activacion           IN NUMBER,
        p_fecha_hora_activacion   IN TIMESTAMP,
        p_tipo_emergencia         IN VARCHAR2,
        p_id_plan_emergencia      IN NUMBER,
        p_nivel_activacion        IN VARCHAR2,
        p_descripcion_incidente   IN CLOB,
        p_lugar_incidente         IN VARCHAR2,
        p_personas_afectadas      IN NUMBER,
        p_personas_atendidas      IN NUMBER,
        p_recursos_movilizados    IN CLOB,
        p_hora_control            IN TIMESTAMP,
        p_hora_fin                IN TIMESTAMP,
        p_estado                  IN VARCHAR2,
        p_responsable_coordinacion IN VARCHAR2,
        p_informe_incidente       IN CLOB,
        p_lecciones_aprendidas    IN CLOB
    );

    PROCEDURE delete_activacion(
        p_id_activacion IN NUMBER
    );
END pkg_activaciones_emergencia;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_activaciones_emergencia AS

    PROCEDURE insert_activacion(
        p_fecha_hora_activacion   IN TIMESTAMP,
        p_tipo_emergencia         IN VARCHAR2,
        p_id_plan_emergencia      IN NUMBER,
        p_nivel_activacion        IN VARCHAR2,
        p_descripcion_incidente   IN CLOB,
        p_lugar_incidente         IN VARCHAR2,
        p_personas_afectadas      IN NUMBER,
        p_personas_atendidas      IN NUMBER,
        p_recursos_movilizados    IN CLOB,
        p_hora_control            IN TIMESTAMP,
        p_hora_fin                IN TIMESTAMP,
        p_estado                  IN VARCHAR2,
        p_responsable_coordinacion IN VARCHAR2,
        p_informe_incidente       IN CLOB,
        p_lecciones_aprendidas    IN CLOB
    ) IS
    BEGIN
        INSERT INTO activaciones_emergencia (
            fecha_hora_activacion, tipo_emergencia, id_plan_emergencia,
            nivel_activacion, descripcion_incidente, lugar_incidente,
            personas_afectadas, personas_atendidas, recursos_movilizados,
            hora_control, hora_fin, estado,
            responsable_coordinacion, informe_incidente, lecciones_aprendidas
        ) VALUES (
            NVL(p_fecha_hora_activacion, SYSTIMESTAMP), p_tipo_emergencia, p_id_plan_emergencia,
            p_nivel_activacion, p_descripcion_incidente, p_lugar_incidente,
            p_personas_afectadas, p_personas_atendidas, p_recursos_movilizados,
            p_hora_control, p_hora_fin, NVL(p_estado,'ACTIVA'),
            p_responsable_coordinacion, p_informe_incidente, p_lecciones_aprendidas
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35901, 'Error al insertar activación de emergencia: ' || SQLERRM);
    END insert_activacion;

    PROCEDURE get_activacion(
        p_id_activacion IN NUMBER
    ) IS
        r activaciones_emergencia%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM activaciones_emergencia
        WHERE id_activacion = p_id_activacion;

        DBMS_OUTPUT.PUT_LINE('ID Activación: ' || r.id_activacion);
        DBMS_OUTPUT.PUT_LINE('Fecha/Hora activación: ' || r.fecha_hora_activacion);
        DBMS_OUTPUT.PUT_LINE('Tipo emergencia: ' || r.tipo_emergencia);
        DBMS_OUTPUT.PUT_LINE('Plan emergencia: ' || r.id_plan_emergencia);
        DBMS_OUTPUT.PUT_LINE('Nivel activación: ' || r.nivel_activacion);
        DBMS_OUTPUT.PUT_LINE('Descripción incidente: ' || DBMS_LOB.SUBSTR(r.descripcion_incidente,200,1));
        DBMS_OUTPUT.PUT_LINE('Lugar incidente: ' || r.lugar_incidente);
        DBMS_OUTPUT.PUT_LINE('Personas afectadas: ' || r.personas_afectadas);
        DBMS_OUTPUT.PUT_LINE('Personas atendidas: ' || r.personas_atendidas);
        DBMS_OUTPUT.PUT_LINE('Recursos movilizados: ' || DBMS_LOB.SUBSTR(r.recursos_movilizados,200,1));
        DBMS_OUTPUT.PUT_LINE('Hora control: ' || r.hora_control);
        DBMS_OUTPUT.PUT_LINE('Hora fin: ' || r.hora_fin);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Responsable coordinación: ' || r.responsable_coordinacion);
        DBMS_OUTPUT.PUT_LINE('Informe incidente: ' || DBMS_LOB.SUBSTR(r.informe_incidente,200,1));
        DBMS_OUTPUT.PUT_LINE('Lecciones aprendidas: ' || DBMS_LOB.SUBSTR(r.lecciones_aprendidas,200,1));
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Activación de emergencia no encontrada.');
    END get_activacion;

    PROCEDURE update_activacion(
        p_id_activacion           IN NUMBER,
        p_fecha_hora_activacion   IN TIMESTAMP,
        p_tipo_emergencia         IN VARCHAR2,
        p_id_plan_emergencia      IN NUMBER,
        p_nivel_activacion        IN VARCHAR2,
        p_descripcion_incidente   IN CLOB,
        p_lugar_incidente         IN VARCHAR2,
        p_personas_afectadas      IN NUMBER,
        p_personas_atendidas      IN NUMBER,
        p_recursos_movilizados    IN CLOB,
        p_hora_control            IN TIMESTAMP,
        p_hora_fin                IN TIMESTAMP,
        p_estado                  IN VARCHAR2,
        p_responsable_coordinacion IN VARCHAR2,
        p_informe_incidente       IN CLOB,
        p_lecciones_aprendidas    IN CLOB
    ) IS
    BEGIN
        UPDATE activaciones_emergencia
        SET fecha_hora_activacion   = p_fecha_hora_activacion,
            tipo_emergencia         = p_tipo_emergencia,
            id_plan_emergencia      = p_id_plan_emergencia,
            nivel_activacion        = p_nivel_activacion,
            descripcion_incidente   = p_descripcion_incidente,
            lugar_incidente         = p_lugar_incidente,
            personas_afectadas      = p_personas_afectadas,
            personas_atendidas      = p_personas_atendidas,
            recursos_movilizados    = p_recursos_movilizados,
            hora_control            = p_hora_control,
            hora_fin                = p_hora_fin,
            estado                  = p_estado,
            responsable_coordinacion = p_responsable_coordinacion,
            informe_incidente       = p_informe_incidente,
            lecciones_aprendidas    = p_lecciones_aprendidas
        WHERE id_activacion = p_id_activacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35902, 'No se encontró la activación de emergencia para actualizar.');
        END IF;
    END update_activacion;

    PROCEDURE delete_activacion(
        p_id_activacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM activaciones_emergencia
        WHERE id_activacion = p_id_activacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35903, 'No se encontró la activación de emergencia para eliminar.');
        END IF;
    END delete_activacion;

END pkg_activaciones_emergencia;
/
