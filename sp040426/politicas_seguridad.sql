------------------------------------------------------------
-- Paquete CRUD para la tabla POLITICAS_SEGURIDAD
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_politicas_seguridad AS
    PROCEDURE insert_politica(
        p_nombre_politica       IN VARCHAR2,
        p_version               IN VARCHAR2,
        p_fecha_aprobacion      IN DATE,
        p_fecha_vigencia        IN DATE,
        p_fecha_revision        IN DATE,
        p_contenido             IN CLOB,
        p_aprobado_por          IN NUMBER,
        p_responsable_ejecucion IN NUMBER,
        p_activa                IN NUMBER DEFAULT 1
    );

    PROCEDURE get_politica(
        p_id_politica IN NUMBER
    );

    PROCEDURE update_politica(
        p_id_politica           IN NUMBER,
        p_nombre_politica       IN VARCHAR2,
        p_version               IN VARCHAR2,
        p_fecha_aprobacion      IN DATE,
        p_fecha_vigencia        IN DATE,
        p_fecha_revision        IN DATE,
        p_contenido             IN CLOB,
        p_aprobado_por          IN NUMBER,
        p_responsable_ejecucion IN NUMBER,
        p_activa                IN NUMBER
    );

    PROCEDURE delete_politica(
        p_id_politica IN NUMBER
    );
END pkg_politicas_seguridad;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_politicas_seguridad AS

    PROCEDURE insert_politica(
        p_nombre_politica       IN VARCHAR2,
        p_version               IN VARCHAR2,
        p_fecha_aprobacion      IN DATE,
        p_fecha_vigencia        IN DATE,
        p_fecha_revision        IN DATE,
        p_contenido             IN CLOB,
        p_aprobado_por          IN NUMBER,
        p_responsable_ejecucion IN NUMBER,
        p_activa                IN NUMBER
    ) IS
    BEGIN
        INSERT INTO politicas_seguridad (
            nombre_politica, version, fecha_aprobacion,
            fecha_vigencia, fecha_revision, contenido,
            aprobado_por, responsable_ejecucion, activa
        ) VALUES (
            p_nombre_politica, p_version, p_fecha_aprobacion,
            p_fecha_vigencia, p_fecha_revision, p_contenido,
            p_aprobado_por, p_responsable_ejecucion, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32501, 'Error al insertar política de seguridad: ' || SQLERRM);
    END insert_politica;

    PROCEDURE get_politica(
        p_id_politica IN NUMBER
    ) IS
        r politicas_seguridad%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM politicas_seguridad
        WHERE id_politica = p_id_politica;

        DBMS_OUTPUT.PUT_LINE('ID Política: ' || r.id_politica);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_politica);
        DBMS_OUTPUT.PUT_LINE('Versión: ' || r.version);
        DBMS_OUTPUT.PUT_LINE('Fecha aprobación: ' || r.fecha_aprobacion);
        DBMS_OUTPUT.PUT_LINE('Fecha vigencia: ' || r.fecha_vigencia);
        DBMS_OUTPUT.PUT_LINE('Fecha revisión: ' || r.fecha_revision);
        DBMS_OUTPUT.PUT_LINE('Contenido: ' || DBMS_LOB.SUBSTR(r.contenido, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Aprobado por: ' || r.aprobado_por);
        DBMS_OUTPUT.PUT_LINE('Responsable ejecución: ' || r.responsable_ejecucion);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Política de seguridad no encontrada.');
    END get_politica;

    PROCEDURE update_politica(
        p_id_politica           IN NUMBER,
        p_nombre_politica       IN VARCHAR2,
        p_version               IN VARCHAR2,
        p_fecha_aprobacion      IN DATE,
        p_fecha_vigencia        IN DATE,
        p_fecha_revision        IN DATE,
        p_contenido             IN CLOB,
        p_aprobado_por          IN NUMBER,
        p_responsable_ejecucion IN NUMBER,
        p_activa                IN NUMBER
    ) IS
    BEGIN
        UPDATE politicas_seguridad
        SET nombre_politica       = p_nombre_politica,
            version               = p_version,
            fecha_aprobacion      = p_fecha_aprobacion,
            fecha_vigencia        = p_fecha_vigencia,
            fecha_revision        = p_fecha_revision,
            contenido             = p_contenido,
            aprobado_por          = p_aprobado_por,
            responsable_ejecucion = p_responsable_ejecucion,
            activa                = p_activa
        WHERE id_politica = p_id_politica;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32502, 'No se encontró la política de seguridad para actualizar.');
        END IF;
    END update_politica;

    PROCEDURE delete_politica(
        p_id_politica IN NUMBER
    ) IS
    BEGIN
        DELETE FROM politicas_seguridad
        WHERE id_politica = p_id_politica;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32503, 'No se encontró la política de seguridad para eliminar.');
        END IF;
    END delete_politica;

END pkg_politicas_seguridad;
/
