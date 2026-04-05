------------------------------------------------------------
-- Paquete CRUD para la tabla AUDITORIAS_INTERNAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_auditorias_internas AS
    PROCEDURE insert_auditoria(
        p_codigo_auditoria       IN VARCHAR2,
        p_titulo                 IN VARCHAR2,
        p_tipo_auditoria         IN VARCHAR2,
        p_alcance                IN CLOB,
        p_fecha_inicio_planeacion IN DATE,
        p_fecha_fin_planeacion   IN DATE,
        p_fecha_inicio_ejecucion IN DATE,
        p_fecha_fin_ejecucion    IN DATE,
        p_fecha_informe          IN DATE,
        p_auditor_lider          IN NUMBER,
        p_equipo_auditor         IN VARCHAR2,
        p_areas_auditadas        IN VARCHAR2,
        p_hallazgos              IN CLOB,
        p_no_conformidades       IN CLOB,
        p_oportunidades_mejora   IN CLOB,
        p_conclusiones           IN CLOB,
        p_informe_final          IN BLOB,
        p_estado                 IN VARCHAR2 DEFAULT 'PLANEADA'
    );

    PROCEDURE get_auditoria(
        p_id_auditoria_interna IN NUMBER
    );

    PROCEDURE update_auditoria(
        p_id_auditoria_interna IN NUMBER,
        p_codigo_auditoria       IN VARCHAR2,
        p_titulo                 IN VARCHAR2,
        p_tipo_auditoria         IN VARCHAR2,
        p_alcance                IN CLOB,
        p_fecha_inicio_planeacion IN DATE,
        p_fecha_fin_planeacion   IN DATE,
        p_fecha_inicio_ejecucion IN DATE,
        p_fecha_fin_ejecucion    IN DATE,
        p_fecha_informe          IN DATE,
        p_auditor_lider          IN NUMBER,
        p_equipo_auditor         IN VARCHAR2,
        p_areas_auditadas        IN VARCHAR2,
        p_hallazgos              IN CLOB,
        p_no_conformidades       IN CLOB,
        p_oportunidades_mejora   IN CLOB,
        p_conclusiones           IN CLOB,
        p_informe_final          IN BLOB,
        p_estado                 IN VARCHAR2
    );

    PROCEDURE delete_auditoria(
        p_id_auditoria_interna IN NUMBER
    );
END pkg_auditorias_internas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_auditorias_internas AS

    PROCEDURE insert_auditoria(
        p_codigo_auditoria       IN VARCHAR2,
        p_titulo                 IN VARCHAR2,
        p_tipo_auditoria         IN VARCHAR2,
        p_alcance                IN CLOB,
        p_fecha_inicio_planeacion IN DATE,
        p_fecha_fin_planeacion   IN DATE,
        p_fecha_inicio_ejecucion IN DATE,
        p_fecha_fin_ejecucion    IN DATE,
        p_fecha_informe          IN DATE,
        p_auditor_lider          IN NUMBER,
        p_equipo_auditor         IN VARCHAR2,
        p_areas_auditadas        IN VARCHAR2,
        p_hallazgos              IN CLOB,
        p_no_conformidades       IN CLOB,
        p_oportunidades_mejora   IN CLOB,
        p_conclusiones           IN CLOB,
        p_informe_final          IN BLOB,
        p_estado                 IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO auditorias_internas (
            codigo_auditoria, titulo, tipo_auditoria, alcance,
            fecha_inicio_planeacion, fecha_fin_planeacion,
            fecha_inicio_ejecucion, fecha_fin_ejecucion,
            fecha_informe, auditor_lider, equipo_auditor,
            areas_auditadas, hallazgos, no_conformidades,
            oportunidades_mejora, conclusiones, informe_final,
            estado
        ) VALUES (
            p_codigo_auditoria, p_titulo, p_tipo_auditoria, p_alcance,
            p_fecha_inicio_planeacion, p_fecha_fin_planeacion,
            p_fecha_inicio_ejecucion, p_fecha_fin_ejecucion,
            p_fecha_informe, p_auditor_lider, p_equipo_auditor,
            p_areas_auditadas, p_hallazgos, p_no_conformidades,
            p_oportunidades_mejora, p_conclusiones, p_informe_final,
            NVL(p_estado,'PLANEADA')
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34301, 'Error al insertar auditoría interna: ' || SQLERRM);
    END insert_auditoria;

    PROCEDURE get_auditoria(
        p_id_auditoria_interna IN NUMBER
    ) IS
        r auditorias_internas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM auditorias_internas
        WHERE id_auditoria_interna = p_id_auditoria_interna;

        DBMS_OUTPUT.PUT_LINE('ID Auditoría: ' || r.id_auditoria_interna);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_auditoria);
        DBMS_OUTPUT.PUT_LINE('Título: ' || r.titulo);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_auditoria);
        DBMS_OUTPUT.PUT_LINE('Alcance: ' || DBMS_LOB.SUBSTR(r.alcance, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Fechas planeación: ' || r.fecha_inicio_planeacion || ' - ' || r.fecha_fin_planeacion);
        DBMS_OUTPUT.PUT_LINE('Fechas ejecución: ' || r.fecha_inicio_ejecucion || ' - ' || r.fecha_fin_ejecucion);
        DBMS_OUTPUT.PUT_LINE('Fecha informe: ' || r.fecha_informe);
        DBMS_OUTPUT.PUT_LINE('Auditor líder: ' || r.auditor_lider);
        DBMS_OUTPUT.PUT_LINE('Equipo auditor: ' || r.equipo_auditor);
        DBMS_OUTPUT.PUT_LINE('Áreas auditadas: ' || r.areas_auditadas);
        DBMS_OUTPUT.PUT_LINE('Hallazgos: ' || DBMS_LOB.SUBSTR(r.hallazgos, 200, 1));
        DBMS_OUTPUT.PUT_LINE('No conformidades: ' || DBMS_LOB.SUBSTR(r.no_conformidades, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Oportunidades mejora: ' || DBMS_LOB.SUBSTR(r.oportunidades_mejora, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Conclusiones: ' || DBMS_LOB.SUBSTR(r.conclusiones, 200, 1));
        IF r.informe_final IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Informe final: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Informe final: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Auditoría interna no encontrada.');
    END get_auditoria;

    PROCEDURE update_auditoria(
        p_id_auditoria_interna IN NUMBER,
        p_codigo_auditoria       IN VARCHAR2,
        p_titulo                 IN VARCHAR2,
        p_tipo_auditoria         IN VARCHAR2,
        p_alcance                IN CLOB,
        p_fecha_inicio_planeacion IN DATE,
        p_fecha_fin_planeacion   IN DATE,
        p_fecha_inicio_ejecucion IN DATE,
        p_fecha_fin_ejecucion    IN DATE,
        p_fecha_informe          IN DATE,
        p_auditor_lider          IN NUMBER,
        p_equipo_auditor         IN VARCHAR2,
        p_areas_auditadas        IN VARCHAR2,
        p_hallazgos              IN CLOB,
        p_no_conformidades       IN CLOB,
        p_oportunidades_mejora   IN CLOB,
        p_conclusiones           IN CLOB,
        p_informe_final          IN BLOB,
        p_estado                 IN VARCHAR2
    ) IS
    BEGIN
        UPDATE auditorias_internas
        SET codigo_auditoria       = p_codigo_auditoria,
            titulo                 = p_titulo,
            tipo_auditoria         = p_tipo_auditoria,
            alcance                = p_alcance,
            fecha_inicio_planeacion = p_fecha_inicio_planeacion,
            fecha_fin_planeacion   = p_fecha_fin_planeacion,
            fecha_inicio_ejecucion = p_fecha_inicio_ejecucion,
            fecha_fin_ejecucion    = p_fecha_fin_ejecucion,
            fecha_informe          = p_fecha_informe,
            auditor_lider          = p_auditor_lider,
            equipo_auditor         = p_equipo_auditor,
            areas_auditadas        = p_areas_auditadas,
            hallazgos              = p_hallazgos,
            no_conformidades       = p_no_conformidades,
            oportunidades_mejora   = p_oportunidades_mejora,
            conclusiones           = p_conclusiones,
            informe_final          = p_informe_final,
            estado                 = p_estado
        WHERE id_auditoria_interna = p_id_auditoria_interna;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34302, 'No se encontró la auditoría interna para actualizar.');
                END IF;
    END update_auditoria;

    PROCEDURE delete_auditoria(
        p_id_auditoria_interna IN NUMBER
    ) IS
    BEGIN
        DELETE FROM auditorias_internas
        WHERE id_auditoria_interna = p_id_auditoria_interna;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34303, 'No se encontró la auditoría interna para eliminar.');
        END IF;
    END delete_auditoria;

END pkg_auditorias_internas;
/
