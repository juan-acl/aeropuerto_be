------------------------------------------------------------
-- Paquete CRUD para la tabla EVALUACIONES_POST_EMERGENCIA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_evaluaciones_post AS
    PROCEDURE insert_evaluacion(
        p_id_activacion            IN NUMBER,
        p_fecha_evaluacion         IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_evaluador                IN VARCHAR2,
        p_tiempo_respuesta_minutos IN NUMBER,
        p_eficacia_respuesta       IN NUMBER,
        p_coordinacion             IN NUMBER,
        p_recursos_utilizados      IN CLOB,
        p_puntos_fuertes           IN CLOB,
        p_areas_mejora             IN CLOB,
        p_acciones_recomendadas    IN CLOB,
        p_responsable_seguimiento  IN VARCHAR2,
        p_fecha_seguimiento        IN DATE
    );

    PROCEDURE get_evaluacion(
        p_id_evaluacion_post IN NUMBER
    );

    PROCEDURE update_evaluacion(
        p_id_evaluacion_post       IN NUMBER,
        p_id_activacion            IN NUMBER,
        p_fecha_evaluacion         IN TIMESTAMP,
        p_evaluador                IN VARCHAR2,
        p_tiempo_respuesta_minutos IN NUMBER,
        p_eficacia_respuesta       IN NUMBER,
        p_coordinacion             IN NUMBER,
        p_recursos_utilizados      IN CLOB,
        p_puntos_fuertes           IN CLOB,
        p_areas_mejora             IN CLOB,
        p_acciones_recomendadas    IN CLOB,
        p_responsable_seguimiento  IN VARCHAR2,
        p_fecha_seguimiento        IN DATE
    );

    PROCEDURE delete_evaluacion(
        p_id_evaluacion_post IN NUMBER
    );
END pkg_evaluaciones_post;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_evaluaciones_post AS

    PROCEDURE insert_evaluacion(
        p_id_activacion            IN NUMBER,
        p_fecha_evaluacion         IN TIMESTAMP,
        p_evaluador                IN VARCHAR2,
        p_tiempo_respuesta_minutos IN NUMBER,
        p_eficacia_respuesta       IN NUMBER,
        p_coordinacion             IN NUMBER,
        p_recursos_utilizados      IN CLOB,
        p_puntos_fuertes           IN CLOB,
        p_areas_mejora             IN CLOB,
        p_acciones_recomendadas    IN CLOB,
        p_responsable_seguimiento  IN VARCHAR2,
        p_fecha_seguimiento        IN DATE
    ) IS
    BEGIN
        INSERT INTO evaluaciones_post_emergencia (
            id_activacion, fecha_evaluacion, evaluador,
            tiempo_respuesta_minutos, eficacia_respuesta, coordinacion,
            recursos_utilizados, puntos_fuertes, areas_mejora,
            acciones_recomendadas, responsable_seguimiento, fecha_seguimiento
        ) VALUES (
            p_id_activacion, NVL(p_fecha_evaluacion, SYSTIMESTAMP), p_evaluador,
            p_tiempo_respuesta_minutos, p_eficacia_respuesta, p_coordinacion,
            p_recursos_utilizados, p_puntos_fuertes, p_areas_mejora,
            p_acciones_recomendadas, p_responsable_seguimiento, p_fecha_seguimiento
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36201, 'Error al insertar evaluación post-emergencia: ' || SQLERRM);
    END insert_evaluacion;

    PROCEDURE get_evaluacion(
        p_id_evaluacion_post IN NUMBER
    ) IS
        r evaluaciones_post_emergencia%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM evaluaciones_post_emergencia
        WHERE id_evaluacion_post = p_id_evaluacion_post;

        DBMS_OUTPUT.PUT_LINE('ID Evaluación: ' || r.id_evaluacion_post);
        DBMS_OUTPUT.PUT_LINE('Activación: ' || r.id_activacion);
        DBMS_OUTPUT.PUT_LINE('Fecha evaluación: ' || r.fecha_evaluacion);
        DBMS_OUTPUT.PUT_LINE('Evaluador: ' || r.evaluador);
        DBMS_OUTPUT.PUT_LINE('Tiempo respuesta (min): ' || r.tiempo_respuesta_minutos);
        DBMS_OUTPUT.PUT_LINE('Eficacia respuesta: ' || r.eficacia_respuesta);
        DBMS_OUTPUT.PUT_LINE('Coordinación: ' || r.coordinacion);
        DBMS_OUTPUT.PUT_LINE('Recursos utilizados: ' || DBMS_LOB.SUBSTR(r.recursos_utilizados,200,1));
        DBMS_OUTPUT.PUT_LINE('Puntos fuertes: ' || DBMS_LOB.SUBSTR(r.puntos_fuertes,200,1));
        DBMS_OUTPUT.PUT_LINE('Áreas de mejora: ' || DBMS_LOB.SUBSTR(r.areas_mejora,200,1));
        DBMS_OUTPUT.PUT_LINE('Acciones recomendadas: ' || DBMS_LOB.SUBSTR(r.acciones_recomendadas,200,1));
        DBMS_OUTPUT.PUT_LINE('Responsable seguimiento: ' || r.responsable_seguimiento);
        DBMS_OUTPUT.PUT_LINE('Fecha seguimiento: ' || r.fecha_seguimiento);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Evaluación post-emergencia no encontrada.');
    END get_evaluacion;

    PROCEDURE update_evaluacion(
        p_id_evaluacion_post       IN NUMBER,
        p_id_activacion            IN NUMBER,
        p_fecha_evaluacion         IN TIMESTAMP,
        p_evaluador                IN VARCHAR2,
        p_tiempo_respuesta_minutos IN NUMBER,
        p_eficacia_respuesta       IN NUMBER,
        p_coordinacion             IN NUMBER,
        p_recursos_utilizados      IN CLOB,
        p_puntos_fuertes           IN CLOB,
        p_areas_mejora             IN CLOB,
        p_acciones_recomendadas    IN CLOB,
        p_responsable_seguimiento  IN VARCHAR2,
        p_fecha_seguimiento        IN DATE
    ) IS
    BEGIN
        UPDATE evaluaciones_post_emergencia
        SET id_activacion            = p_id_activacion,
            fecha_evaluacion         = p_fecha_evaluacion,
            evaluador                = p_evaluador,
            tiempo_respuesta_minutos = p_tiempo_respuesta_minutos,
            eficacia_respuesta       = p_eficacia_respuesta,
            coordinacion             = p_coordinacion,
            recursos_utilizados      = p_recursos_utilizados,
            puntos_fuertes           = p_puntos_fuertes,
            areas_mejora             = p_areas_mejora,
            acciones_recomendadas    = p_acciones_recomendadas,
            responsable_seguimiento  = p_responsable_seguimiento,
            fecha_seguimiento        = p_fecha_seguimiento
        WHERE id_evaluacion_post = p_id_evaluacion_post;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36202, 'No se encontró la evaluación post-emergencia para actualizar.');
        END IF;
    END update_evaluacion;

    PROCEDURE delete_evaluacion(
        p_id_evaluacion_post IN NUMBER
    ) IS
    BEGIN
        DELETE FROM evaluaciones_post_emergencia
        WHERE id_evaluacion_post = p_id_evaluacion_post;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36203, 'No se encontró la evaluación post-emergencia para eliminar.');
        END IF;
    END delete_evaluacion;

END pkg_evaluaciones_post;
/
