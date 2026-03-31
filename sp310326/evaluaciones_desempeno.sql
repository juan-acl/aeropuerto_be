------------------------------------------------------------
-- Paquete CRUD para la tabla EVALUACIONES_DESEMPENO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_evaluaciones_desempeno AS
    PROCEDURE insert_evaluacion(
        p_id_empleado              IN NUMBER,
        p_fecha_evaluacion         IN DATE,
        p_evaluador_id             IN NUMBER,
        p_periodo_evaluado         IN VARCHAR2,
        p_puntuacion_total         IN NUMBER,
        p_puntuacion_productividad IN NUMBER,
        p_puntuacion_calidad       IN NUMBER,
        p_puntuacion_asistencia    IN NUMBER,
        p_puntuacion_trabajo_equipo IN NUMBER,
        p_comentarios              IN VARCHAR2,
        p_metas_futuras            IN VARCHAR2
    );

    PROCEDURE get_evaluacion(
        p_id_evaluacion IN NUMBER
    );

    PROCEDURE update_evaluacion(
        p_id_evaluacion            IN NUMBER,
        p_id_empleado              IN NUMBER,
        p_fecha_evaluacion         IN DATE,
        p_evaluador_id             IN NUMBER,
        p_periodo_evaluado         IN VARCHAR2,
        p_puntuacion_total         IN NUMBER,
        p_puntuacion_productividad IN NUMBER,
        p_puntuacion_calidad       IN NUMBER,
        p_puntuacion_asistencia    IN NUMBER,
        p_puntuacion_trabajo_equipo IN NUMBER,
        p_comentarios              IN VARCHAR2,
        p_metas_futuras            IN VARCHAR2
    );

    PROCEDURE delete_evaluacion(
        p_id_evaluacion IN NUMBER
    );
END pkg_evaluaciones_desempeno;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_evaluaciones_desempeno AS

    PROCEDURE insert_evaluacion(
        p_id_empleado              IN NUMBER,
        p_fecha_evaluacion         IN DATE,
        p_evaluador_id             IN NUMBER,
        p_periodo_evaluado         IN VARCHAR2,
        p_puntuacion_total         IN NUMBER,
        p_puntuacion_productividad IN NUMBER,
        p_puntuacion_calidad       IN NUMBER,
        p_puntuacion_asistencia    IN NUMBER,
        p_puntuacion_trabajo_equipo IN NUMBER,
        p_comentarios              IN VARCHAR2,
        p_metas_futuras            IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO evaluaciones_desempeno (
            id_empleado, fecha_evaluacion, evaluador_id, periodo_evaluado,
            puntuacion_total, puntuacion_productividad, puntuacion_calidad,
            puntuacion_asistencia, puntuacion_trabajo_equipo,
            comentarios, metas_futuras
        ) VALUES (
            p_id_empleado, p_fecha_evaluacion, p_evaluador_id, p_periodo_evaluado,
            p_puntuacion_total, p_puntuacion_productividad, p_puntuacion_calidad,
            p_puntuacion_asistencia, p_puntuacion_trabajo_equipo,
            p_comentarios, p_metas_futuras
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26801, 'Error al insertar evaluación de desempeño: ' || SQLERRM);
    END insert_evaluacion;

    PROCEDURE get_evaluacion(
        p_id_evaluacion IN NUMBER
    ) IS
        r evaluaciones_desempeno%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM evaluaciones_desempeno
        WHERE id_evaluacion = p_id_evaluacion;

        DBMS_OUTPUT.PUT_LINE('ID Evaluación: ' || r.id_evaluacion);
        DBMS_OUTPUT.PUT_LINE('Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha_evaluacion);
        DBMS_OUTPUT.PUT_LINE('Evaluador: ' || r.evaluador_id);
        DBMS_OUTPUT.PUT_LINE('Periodo evaluado: ' || r.periodo_evaluado);
        DBMS_OUTPUT.PUT_LINE('Puntuación total: ' || r.puntuacion_total);
        DBMS_OUTPUT.PUT_LINE('Productividad: ' || r.puntuacion_productividad);
        DBMS_OUTPUT.PUT_LINE('Calidad: ' || r.puntuacion_calidad);
        DBMS_OUTPUT.PUT_LINE('Asistencia: ' || r.puntuacion_asistencia);
        DBMS_OUTPUT.PUT_LINE('Trabajo en equipo: ' || r.puntuacion_trabajo_equipo);
        DBMS_OUTPUT.PUT_LINE('Comentarios: ' || r.comentarios);
        DBMS_OUTPUT.PUT_LINE('Metas futuras: ' || r.metas_futuras);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Evaluación de desempeño no encontrada.');
    END get_evaluacion;

    PROCEDURE update_evaluacion(
        p_id_evaluacion            IN NUMBER,
        p_id_empleado              IN NUMBER,
        p_fecha_evaluacion         IN DATE,
        p_evaluador_id             IN NUMBER,
        p_periodo_evaluado         IN VARCHAR2,
        p_puntuacion_total         IN NUMBER,
        p_puntuacion_productividad IN NUMBER,
        p_puntuacion_calidad       IN NUMBER,
        p_puntuacion_asistencia    IN NUMBER,
        p_puntuacion_trabajo_equipo IN NUMBER,
        p_comentarios              IN VARCHAR2,
        p_metas_futuras            IN VARCHAR2
    ) IS
    BEGIN
        UPDATE evaluaciones_desempeno
        SET id_empleado              = p_id_empleado,
            fecha_evaluacion         = p_fecha_evaluacion,
            evaluador_id             = p_evaluador_id,
            periodo_evaluado         = p_periodo_evaluado,
            puntuacion_total         = p_puntuacion_total,
            puntuacion_productividad = p_puntuacion_productividad,
            puntuacion_calidad       = p_puntuacion_calidad,
            puntuacion_asistencia    = p_puntuacion_asistencia,
            puntuacion_trabajo_equipo = p_puntuacion_trabajo_equipo,
            comentarios              = p_comentarios,
            metas_futuras            = p_metas_futuras
        WHERE id_evaluacion = p_id_evaluacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26802, 'No se encontró la evaluación de desempeño para actualizar.');
        END IF;
    END update_evaluacion;

    PROCEDURE delete_evaluacion(
        p_id_evaluacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM evaluaciones_desempeno
        WHERE id_evaluacion = p_id_evaluacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26803, 'No se encontró la evaluación de desempeño para eliminar.');
        END IF;
    END delete_evaluacion;

END pkg_evaluaciones_desempeno;
/