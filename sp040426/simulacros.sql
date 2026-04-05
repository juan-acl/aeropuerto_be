------------------------------------------------------------
-- Paquete CRUD para la tabla SIMULACROS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_simulacros AS
    PROCEDURE insert_simulacro(
        p_fecha_simulacro        IN DATE,
        p_tipo_simulacro         IN VARCHAR2,
        p_id_plan_emergencia     IN NUMBER,
        p_alcance                IN VARCHAR2,
        p_participantes          IN NUMBER,
        p_duracion_horas         IN NUMBER,
        p_objetivos              IN CLOB,
        p_resultados             IN CLOB,
        p_observaciones          IN CLOB,
        p_evaluacion             IN VARCHAR2,
        p_coordinador            IN VARCHAR2,
        p_fecha_proximo_simulacro IN DATE
    );

    PROCEDURE get_simulacro(
        p_id_simulacro IN NUMBER
    );

    PROCEDURE update_simulacro(
        p_id_simulacro           IN NUMBER,
        p_fecha_simulacro        IN DATE,
        p_tipo_simulacro         IN VARCHAR2,
        p_id_plan_emergencia     IN NUMBER,
        p_alcance                IN VARCHAR2,
        p_participantes          IN NUMBER,
        p_duracion_horas         IN NUMBER,
        p_objetivos              IN CLOB,
        p_resultados             IN CLOB,
        p_observaciones          IN CLOB,
        p_evaluacion             IN VARCHAR2,
        p_coordinador            IN VARCHAR2,
        p_fecha_proximo_simulacro IN DATE
    );

    PROCEDURE delete_simulacro(
        p_id_simulacro IN NUMBER
    );
END pkg_simulacros;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_simulacros AS

    PROCEDURE insert_simulacro(
        p_fecha_simulacro        IN DATE,
        p_tipo_simulacro         IN VARCHAR2,
        p_id_plan_emergencia     IN NUMBER,
        p_alcance                IN VARCHAR2,
        p_participantes          IN NUMBER,
        p_duracion_horas         IN NUMBER,
        p_objetivos              IN CLOB,
        p_resultados             IN CLOB,
        p_observaciones          IN CLOB,
        p_evaluacion             IN VARCHAR2,
        p_coordinador            IN VARCHAR2,
        p_fecha_proximo_simulacro IN DATE
    ) IS
    BEGIN
        INSERT INTO simulacros (
            fecha_simulacro, tipo_simulacro, id_plan_emergencia,
            alcance, participantes, duracion_horas,
            objetivos, resultados, observaciones,
            evaluacion, coordinador, fecha_proximo_simulacro
        ) VALUES (
            p_fecha_simulacro, p_tipo_simulacro, p_id_plan_emergencia,
            p_alcance, p_participantes, p_duracion_horas,
            p_objetivos, p_resultados, p_observaciones,
            p_evaluacion, p_coordinador, p_fecha_proximo_simulacro
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35801, 'Error al insertar simulacro: ' || SQLERRM);
    END insert_simulacro;

    PROCEDURE get_simulacro(
        p_id_simulacro IN NUMBER
    ) IS
        r simulacros%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM simulacros
        WHERE id_simulacro = p_id_simulacro;

        DBMS_OUTPUT.PUT_LINE('ID Simulacro: ' || r.id_simulacro);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha_simulacro);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_simulacro);
        DBMS_OUTPUT.PUT_LINE('Plan emergencia: ' || r.id_plan_emergencia);
        DBMS_OUTPUT.PUT_LINE('Alcance: ' || r.alcance);
        DBMS_OUTPUT.PUT_LINE('Participantes: ' || r.participantes);
        DBMS_OUTPUT.PUT_LINE('Duración (horas): ' || r.duracion_horas);
        DBMS_OUTPUT.PUT_LINE('Objetivos: ' || DBMS_LOB.SUBSTR(r.objetivos,200,1));
        DBMS_OUTPUT.PUT_LINE('Resultados: ' || DBMS_LOB.SUBSTR(r.resultados,200,1));
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || DBMS_LOB.SUBSTR(r.observaciones,200,1));
        DBMS_OUTPUT.PUT_LINE('Evaluación: ' || r.evaluacion);
        DBMS_OUTPUT.PUT_LINE('Coordinador: ' || r.coordinador);
        DBMS_OUTPUT.PUT_LINE('Próximo simulacro: ' || r.fecha_proximo_simulacro);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Simulacro no encontrado.');
    END get_simulacro;

    PROCEDURE update_simulacro(
        p_id_simulacro           IN NUMBER,
        p_fecha_simulacro        IN DATE,
        p_tipo_simulacro         IN VARCHAR2,
        p_id_plan_emergencia     IN NUMBER,
        p_alcance                IN VARCHAR2,
        p_participantes          IN NUMBER,
        p_duracion_horas         IN NUMBER,
        p_objetivos              IN CLOB,
        p_resultados             IN CLOB,
        p_observaciones          IN CLOB,
        p_evaluacion             IN VARCHAR2,
        p_coordinador            IN VARCHAR2,
        p_fecha_proximo_simulacro IN DATE
    ) IS
    BEGIN
        UPDATE simulacros
        SET fecha_simulacro        = p_fecha_simulacro,
            tipo_simulacro         = p_tipo_simulacro,
            id_plan_emergencia     = p_id_plan_emergencia,
            alcance                = p_alcance,
            participantes          = p_participantes,
            duracion_horas         = p_duracion_horas,
            objetivos              = p_objetivos,
            resultados             = p_resultados,
            observaciones          = p_observaciones,
            evaluacion             = p_evaluacion,
            coordinador            = p_coordinador,
            fecha_proximo_simulacro = p_fecha_proximo_simulacro
        WHERE id_simulacro = p_id_simulacro;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35802, 'No se encontró el simulacro para actualizar.');
        END IF;
    END update_simulacro;

    PROCEDURE delete_simulacro(
        p_id_simulacro IN NUMBER
    ) IS
    BEGIN
        DELETE FROM simulacros
        WHERE id_simulacro = p_id_simulacro;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35803, 'No se encontró el simulacro para eliminar.');
        END IF;
    END delete_simulacro;

END pkg_simulacros;
/
