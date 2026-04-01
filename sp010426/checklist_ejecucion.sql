------------------------------------------------------------
-- Paquete CRUD para la tabla CHECKLIST_EJECUCION
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_checklist_ejecucion AS
    PROCEDURE insert_ejecucion(
        p_id_orden_mp     IN NUMBER,
        p_id_checklist    IN NUMBER,
        p_fecha_inicio    IN TIMESTAMP,
        p_fecha_fin       IN TIMESTAMP,
        p_tecnico_ejecutor IN NUMBER,
        p_supervisor      IN NUMBER,
        p_resultado       IN VARCHAR2,
        p_observaciones   IN VARCHAR2,
        p_firma_tecnico   IN BLOB,
        p_firma_supervisor IN BLOB
    );

    PROCEDURE get_ejecucion(
        p_id_ejecucion IN NUMBER
    );

    PROCEDURE update_ejecucion(
        p_id_ejecucion   IN NUMBER,
        p_id_orden_mp    IN NUMBER,
        p_id_checklist   IN NUMBER,
        p_fecha_inicio   IN TIMESTAMP,
        p_fecha_fin      IN TIMESTAMP,
        p_tecnico_ejecutor IN NUMBER,
        p_supervisor     IN NUMBER,
        p_resultado      IN VARCHAR2,
        p_observaciones  IN VARCHAR2,
        p_firma_tecnico  IN BLOB,
        p_firma_supervisor IN BLOB
    );

    PROCEDURE delete_ejecucion(
        p_id_ejecucion IN NUMBER
    );
END pkg_checklist_ejecucion;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_checklist_ejecucion AS

    PROCEDURE insert_ejecucion(
        p_id_orden_mp     IN NUMBER,
        p_id_checklist    IN NUMBER,
        p_fecha_inicio    IN TIMESTAMP,
        p_fecha_fin       IN TIMESTAMP,
        p_tecnico_ejecutor IN NUMBER,
        p_supervisor      IN NUMBER,
        p_resultado       IN VARCHAR2,
        p_observaciones   IN VARCHAR2,
        p_firma_tecnico   IN BLOB,
        p_firma_supervisor IN BLOB
    ) IS
    BEGIN
        INSERT INTO checklist_ejecucion (
            id_orden_mp, id_checklist, fecha_inicio, fecha_fin,
            tecnico_ejecutor, supervisor, resultado,
            observaciones, firma_tecnico, firma_supervisor
        ) VALUES (
            p_id_orden_mp, p_id_checklist, p_fecha_inicio, p_fecha_fin,
            p_tecnico_ejecutor, p_supervisor, p_resultado,
            p_observaciones, p_firma_tecnico, p_firma_supervisor
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29701, 'Error al insertar ejecución de checklist: ' || SQLERRM);
    END insert_ejecucion;

    PROCEDURE get_ejecucion(
        p_id_ejecucion IN NUMBER
    ) IS
        r checklist_ejecucion%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM checklist_ejecucion
        WHERE id_ejecucion = p_id_ejecucion;

        DBMS_OUTPUT.PUT_LINE('ID Ejecución: ' || r.id_ejecucion);
        DBMS_OUTPUT.PUT_LINE('Orden MP: ' || r.id_orden_mp);
        DBMS_OUTPUT.PUT_LINE('Checklist: ' || r.id_checklist);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Técnico ejecutor: ' || r.tecnico_ejecutor);
        DBMS_OUTPUT.PUT_LINE('Supervisor: ' || r.supervisor);
        DBMS_OUTPUT.PUT_LINE('Resultado: ' || r.resultado);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
        IF r.firma_tecnico IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Firma técnico: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Firma técnico: No adjunta');
        END IF;
        IF r.firma_supervisor IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Firma supervisor: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Firma supervisor: No adjunta');
        END IF;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Ejecución de checklist no encontrada.');
    END get_ejecucion;

    PROCEDURE update_ejecucion(
        p_id_ejecucion   IN NUMBER,
        p_id_orden_mp    IN NUMBER,
        p_id_checklist   IN NUMBER,
        p_fecha_inicio   IN TIMESTAMP,
        p_fecha_fin      IN TIMESTAMP,
        p_tecnico_ejecutor IN NUMBER,
        p_supervisor     IN NUMBER,
        p_resultado      IN VARCHAR2,
        p_observaciones  IN VARCHAR2,
        p_firma_tecnico  IN BLOB,
        p_firma_supervisor IN BLOB
    ) IS
    BEGIN
        UPDATE checklist_ejecucion
        SET id_orden_mp     = p_id_orden_mp,
            id_checklist    = p_id_checklist,
            fecha_inicio    = p_fecha_inicio,
            fecha_fin       = p_fecha_fin,
            tecnico_ejecutor = p_tecnico_ejecutor,
            supervisor      = p_supervisor,
            resultado       = p_resultado,
            observaciones   = p_observaciones,
            firma_tecnico   = p_firma_tecnico,
            firma_supervisor = p_firma_supervisor
        WHERE id_ejecucion = p_id_ejecucion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29702, 'No se encontró la ejecución de checklist para actualizar.');
        END IF;
    END update_ejecucion;

    PROCEDURE delete_ejecucion(
        p_id_ejecucion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM checklist_ejecucion
        WHERE id_ejecucion = p_id_ejecucion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29703, 'No se encontró la ejecución de checklist para eliminar.');
        END IF;
    END delete_ejecucion;

END pkg_checklist_ejecucion;
/
