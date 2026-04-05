------------------------------------------------------------
-- Paquete CRUD para la tabla AUDITORIAS_INTERNACIONALES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_auditorias_internacionales AS
    PROCEDURE insert_auditoria(
        p_entidad_auditora       IN VARCHAR2,
        p_fecha_auditoria        IN DATE,
        p_tipo_auditoria         IN VARCHAR2,
        p_alcance                IN CLOB,
        p_auditores              IN VARCHAR2,
        p_areas_auditadas        IN CLOB,
        p_hallazgos              IN CLOB,
        p_no_conformidades       IN CLOB,
        p_recomendaciones        IN CLOB,
        p_fecha_informe          IN DATE,
        p_informe_auditoria      IN BLOB,
        p_plazo_correccion_dias  IN NUMBER,
        p_fecha_cierre           IN DATE,
        p_observaciones          IN VARCHAR2
    );

    PROCEDURE get_auditoria(
        p_id_auditoria_internacional IN NUMBER
    );

    PROCEDURE update_auditoria(
        p_id_auditoria_internacional IN NUMBER,
        p_entidad_auditora           IN VARCHAR2,
        p_fecha_auditoria            IN DATE,
        p_tipo_auditoria             IN VARCHAR2,
        p_alcance                    IN CLOB,
        p_auditores                  IN VARCHAR2,
        p_areas_auditadas            IN CLOB,
        p_hallazgos                  IN CLOB,
        p_no_conformidades           IN CLOB,
        p_recomendaciones            IN CLOB,
        p_fecha_informe              IN DATE,
        p_informe_auditoria          IN BLOB,
        p_plazo_correccion_dias      IN NUMBER,
        p_fecha_cierre               IN DATE,
        p_observaciones              IN VARCHAR2
    );

    PROCEDURE delete_auditoria(
        p_id_auditoria_internacional IN NUMBER
    );
END pkg_auditorias_internacionales;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_auditorias_internacionales AS

    PROCEDURE insert_auditoria(
        p_entidad_auditora       IN VARCHAR2,
        p_fecha_auditoria        IN DATE,
        p_tipo_auditoria         IN VARCHAR2,
        p_alcance                IN CLOB,
        p_auditores              IN VARCHAR2,
        p_areas_auditadas        IN CLOB,
        p_hallazgos              IN CLOB,
        p_no_conformidades       IN CLOB,
        p_recomendaciones        IN CLOB,
        p_fecha_informe          IN DATE,
        p_informe_auditoria      IN BLOB,
        p_plazo_correccion_dias  IN NUMBER,
        p_fecha_cierre           IN DATE,
        p_observaciones          IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO auditorias_internacionales (
            entidad_auditora, fecha_auditoria, tipo_auditoria,
            alcance, auditores, areas_auditadas,
            hallazgos, no_conformidades, recomendaciones,
            fecha_informe, informe_auditoria, plazo_correccion_dias,
            fecha_cierre, observaciones
        ) VALUES (
            p_entidad_auditora, p_fecha_auditoria, p_tipo_auditoria,
            p_alcance, p_auditores, p_areas_auditadas,
            p_hallazgos, p_no_conformidades, p_recomendaciones,
            p_fecha_informe, p_informe_auditoria, p_plazo_correccion_dias,
            p_fecha_cierre, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36601, 'Error al insertar auditoría internacional: ' || SQLERRM);
    END insert_auditoria;

    PROCEDURE get_auditoria(
        p_id_auditoria_internacional IN NUMBER
    ) IS
        r auditorias_internacionales%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM auditorias_internacionales
        WHERE id_auditoria_internacional = p_id_auditoria_internacional;

        DBMS_OUTPUT.PUT_LINE('ID Auditoría: ' || r.id_auditoria_internacional);
        DBMS_OUTPUT.PUT_LINE('Entidad auditora: ' || r.entidad_auditora);
        DBMS_OUTPUT.PUT_LINE('Fecha auditoría: ' || r.fecha_auditoria);
        DBMS_OUTPUT.PUT_LINE('Tipo auditoría: ' || r.tipo_auditoria);
        DBMS_OUTPUT.PUT_LINE('Alcance: ' || DBMS_LOB.SUBSTR(r.alcance,200,1));
        DBMS_OUTPUT.PUT_LINE('Auditores: ' || r.auditores);
        DBMS_OUTPUT.PUT_LINE('Áreas auditadas: ' || DBMS_LOB.SUBSTR(r.areas_auditadas,200,1));
        DBMS_OUTPUT.PUT_LINE('Hallazgos: ' || DBMS_LOB.SUBSTR(r.hallazgos,200,1));
        DBMS_OUTPUT.PUT_LINE('No conformidades: ' || DBMS_LOB.SUBSTR(r.no_conformidades,200,1));
        DBMS_OUTPUT.PUT_LINE('Recomendaciones: ' || DBMS_LOB.SUBSTR(r.recomendaciones,200,1));
        DBMS_OUTPUT.PUT_LINE('Fecha informe: ' || r.fecha_informe);
        IF r.informe_auditoria IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Informe auditoría: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Informe auditoría: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Plazo corrección (días): ' || r.plazo_correccion_dias);
        DBMS_OUTPUT.PUT_LINE('Fecha cierre: ' || r.fecha_cierre);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Auditoría internacional no encontrada.');
    END get_auditoria;

    PROCEDURE update_auditoria(
        p_id_auditoria_internacional IN NUMBER,
        p_entidad_auditora           IN VARCHAR2,
        p_fecha_auditoria            IN DATE,
        p_tipo_auditoria             IN VARCHAR2,
        p_alcance                    IN CLOB,
        p_auditores                  IN VARCHAR2,
        p_areas_auditadas            IN CLOB,
        p_hallazgos                  IN CLOB,
        p_no_conformidades           IN CLOB,
        p_recomendaciones            IN CLOB,
        p_fecha_informe              IN DATE,
        p_informe_auditoria          IN BLOB,
        p_plazo_correccion_dias      IN NUMBER,
        p_fecha_cierre               IN DATE,
        p_observaciones              IN VARCHAR2
    ) IS
    BEGIN
        UPDATE auditorias_internacionales
        SET entidad_auditora       = p_entidad_auditora,
            fecha_auditoria        = p_fecha_auditoria,
            tipo_auditoria         = p_tipo_auditoria,
            alcance                = p_alcance,
            auditores              = p_auditores,
            areas_auditadas        = p_areas_auditadas,
            hallazgos              = p_hallazgos,
            no_conformidades       = p_no_conformidades,
            recomendaciones        = p_recomendaciones,
            fecha_informe          = p_fecha_informe,
            informe_auditoria      = p_informe_auditoria,
            plazo_correccion_dias  = p_plazo_correccion_dias,
            fecha_cierre           = p_fecha_cierre,
            observaciones          = p_observaciones
        WHERE id_auditoria_internacional = p_id_auditoria_internacional;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36602, 'No se encontró la auditoría internacional para actualizar.');
        END IF;
    END update_auditoria;

    PROCEDURE delete_auditoria(
        p_id_auditoria_internacional IN NUMBER
    ) IS
    BEGIN
        DELETE FROM auditorias_internacionales
        WHERE id_auditoria_internacional = p_id_auditoria_internacional;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36603, 'No se encontró la auditoría internacional para eliminar.');
        END IF;
    END delete_auditoria;

END pkg_auditorias_internacionales;
/
