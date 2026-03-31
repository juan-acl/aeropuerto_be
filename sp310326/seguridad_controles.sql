------------------------------------------------------------
-- Paquete CRUD para la tabla SEGURIDAD_CONTROLES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_seguridad_controles AS
    PROCEDURE insert_control(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_fecha_control       IN DATE,
        p_hora_control        IN TIMESTAMP,
        p_tipo_control        IN VARCHAR2,
        p_numero_pasajeros    IN NUMBER,
        p_numero_incidencias  IN NUMBER,
        p_supervisor          IN VARCHAR2,
        p_observaciones       IN VARCHAR2
    );

    PROCEDURE get_control(
        p_id_control IN NUMBER
    );

    PROCEDURE update_control(
        p_id_control          IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_fecha_control       IN DATE,
        p_hora_control        IN TIMESTAMP,
        p_tipo_control        IN VARCHAR2,
        p_numero_pasajeros    IN NUMBER,
        p_numero_incidencias  IN NUMBER,
        p_supervisor          IN VARCHAR2,
        p_observaciones       IN VARCHAR2
    );

    PROCEDURE delete_control(
        p_id_control IN NUMBER
    );
END pkg_seguridad_controles;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_seguridad_controles AS

    PROCEDURE insert_control(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_fecha_control       IN DATE,
        p_hora_control        IN TIMESTAMP,
        p_tipo_control        IN VARCHAR2,
        p_numero_pasajeros    IN NUMBER,
        p_numero_incidencias  IN NUMBER,
        p_supervisor          IN VARCHAR2,
        p_observaciones       IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO seguridad_controles (
            codigo_aeropuerto, fecha_control, hora_control,
            tipo_control, numero_pasajeros_revisados, numero_incidencias,
            supervisor, observaciones
        ) VALUES (
            p_codigo_aeropuerto, p_fecha_control, p_hora_control,
            p_tipo_control, p_numero_pasajeros, p_numero_incidencias,
            p_supervisor, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24101, 'Error al insertar control de seguridad: ' || SQLERRM);
    END insert_control;

    PROCEDURE get_control(
        p_id_control IN NUMBER
    ) IS
        r seguridad_controles%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM seguridad_controles
        WHERE id_control = p_id_control;

        DBMS_OUTPUT.PUT_LINE('ID Control: ' || r.id_control);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Fecha control: ' || r.fecha_control);
        DBMS_OUTPUT.PUT_LINE('Hora control: ' || r.hora_control);
        DBMS_OUTPUT.PUT_LINE('Tipo control: ' || r.tipo_control);
        DBMS_OUTPUT.PUT_LINE('Pasajeros revisados: ' || r.numero_pasajeros_revisados);
        DBMS_OUTPUT.PUT_LINE('Incidencias: ' || r.numero_incidencias);
        DBMS_OUTPUT.PUT_LINE('Supervisor: ' || r.supervisor);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Control de seguridad no encontrado.');
    END get_control;

    PROCEDURE update_control(
        p_id_control          IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_fecha_control       IN DATE,
        p_hora_control        IN TIMESTAMP,
        p_tipo_control        IN VARCHAR2,
        p_numero_pasajeros    IN NUMBER,
        p_numero_incidencias  IN NUMBER,
        p_supervisor          IN VARCHAR2,
        p_observaciones       IN VARCHAR2
    ) IS
    BEGIN
        UPDATE seguridad_controles
        SET codigo_aeropuerto   = p_codigo_aeropuerto,
            fecha_control       = p_fecha_control,
            hora_control        = p_hora_control,
            tipo_control        = p_tipo_control,
            numero_pasajeros_revisados = p_numero_pasajeros,
            numero_incidencias  = p_numero_incidencias,
            supervisor          = p_supervisor,
            observaciones       = p_observaciones
        WHERE id_control = p_id_control;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24102, 'No se encontró el control de seguridad para actualizar.');
        END IF;
    END update_control;

    PROCEDURE delete_control(
        p_id_control IN NUMBER
    ) IS
    BEGIN
        DELETE FROM seguridad_controles
        WHERE id_control = p_id_control;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24103, 'No se encontró el control de seguridad para eliminar.');
        END IF;
    END delete_control;

END pkg_seguridad_controles;
/