------------------------------------------------------------
-- Paquete CRUD para la tabla ASISTENCIAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_asistencias AS
    PROCEDURE insert_asistencia(
        p_id_empleado     IN NUMBER,
        p_fecha           IN DATE,
        p_hora_entrada    IN TIMESTAMP,
        p_hora_salida     IN TIMESTAMP,
        p_horas_trabajadas IN NUMBER,
        p_tipo_jornada    IN VARCHAR2,
        p_observaciones   IN VARCHAR2,
        p_registrado_por  IN NUMBER
    );

    PROCEDURE get_asistencia(
        p_id_asistencia IN NUMBER
    );

    PROCEDURE update_asistencia(
        p_id_asistencia   IN NUMBER,
        p_id_empleado     IN NUMBER,
        p_fecha           IN DATE,
        p_hora_entrada    IN TIMESTAMP,
        p_hora_salida     IN TIMESTAMP,
        p_horas_trabajadas IN NUMBER,
        p_tipo_jornada    IN VARCHAR2,
        p_observaciones   IN VARCHAR2,
        p_registrado_por  IN NUMBER
    );

    PROCEDURE delete_asistencia(
        p_id_asistencia IN NUMBER
    );
END pkg_asistencias;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_asistencias AS

    PROCEDURE insert_asistencia(
        p_id_empleado     IN NUMBER,
        p_fecha           IN DATE,
        p_hora_entrada    IN TIMESTAMP,
        p_hora_salida     IN TIMESTAMP,
        p_horas_trabajadas IN NUMBER,
        p_tipo_jornada    IN VARCHAR2,
        p_observaciones   IN VARCHAR2,
        p_registrado_por  IN NUMBER
    ) IS
    BEGIN
        INSERT INTO asistencias (
            id_empleado, fecha, hora_entrada, hora_salida,
            horas_trabajadas, tipo_jornada, observaciones, registrado_por
        ) VALUES (
            p_id_empleado, p_fecha, p_hora_entrada, p_hora_salida,
            p_horas_trabajadas, p_tipo_jornada, p_observaciones, p_registrado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26601, 'Error al insertar asistencia: ' || SQLERRM);
    END insert_asistencia;

    PROCEDURE get_asistencia(
        p_id_asistencia IN NUMBER
    ) IS
        r asistencias%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM asistencias
        WHERE id_asistencia = p_id_asistencia;

        DBMS_OUTPUT.PUT_LINE('ID Asistencia: ' || r.id_asistencia);
        DBMS_OUTPUT.PUT_LINE('Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha);
        DBMS_OUTPUT.PUT_LINE('Hora entrada: ' || r.hora_entrada);
        DBMS_OUTPUT.PUT_LINE('Hora salida: ' || r.hora_salida);
        DBMS_OUTPUT.PUT_LINE('Horas trabajadas: ' || r.horas_trabajadas);
        DBMS_OUTPUT.PUT_LINE('Tipo jornada: ' || r.tipo_jornada);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
        DBMS_OUTPUT.PUT_LINE('Registrado por: ' || r.registrado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Asistencia no encontrada.');
    END get_asistencia;

    PROCEDURE update_asistencia(
        p_id_asistencia   IN NUMBER,
        p_id_empleado     IN NUMBER,
        p_fecha           IN DATE,
        p_hora_entrada    IN TIMESTAMP,
        p_hora_salida     IN TIMESTAMP,
        p_horas_trabajadas IN NUMBER,
        p_tipo_jornada    IN VARCHAR2,
        p_observaciones   IN VARCHAR2,
        p_registrado_por  IN NUMBER
    ) IS
    BEGIN
        UPDATE asistencias
        SET id_empleado     = p_id_empleado,
            fecha           = p_fecha,
            hora_entrada    = p_hora_entrada,
            hora_salida     = p_hora_salida,
            horas_trabajadas = p_horas_trabajadas,
            tipo_jornada    = p_tipo_jornada,
            observaciones   = p_observaciones,
            registrado_por  = p_registrado_por
        WHERE id_asistencia = p_id_asistencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26602, 'No se encontró la asistencia para actualizar.');
        END IF;
    END update_asistencia;

    PROCEDURE delete_asistencia(
        p_id_asistencia IN NUMBER
    ) IS
    BEGIN
        DELETE FROM asistencias
        WHERE id_asistencia = p_id_asistencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26603, 'No se encontró la asistencia para eliminar.');
        END IF;
    END delete_asistencia;

END pkg_asistencias;
/