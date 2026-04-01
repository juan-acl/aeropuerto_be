------------------------------------------------------------
-- Paquete CRUD para la tabla TAREAS_EJECUTADAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tareas_ejecutadas AS
    PROCEDURE insert_tarea(
        p_id_ejecucion       IN NUMBER,
        p_id_tarea           IN NUMBER,
        p_fecha_ejecucion    IN TIMESTAMP,
        p_tiempo_real_minutos IN NUMBER,
        p_resultados_medicion IN VARCHAR2,
        p_conforme           IN NUMBER DEFAULT 1,
        p_observaciones_tarea IN VARCHAR2
    );

    PROCEDURE get_tarea(
        p_id_tarea_ejecutada IN NUMBER
    );

    PROCEDURE update_tarea(
        p_id_tarea_ejecutada IN NUMBER,
        p_id_ejecucion       IN NUMBER,
        p_id_tarea           IN NUMBER,
        p_fecha_ejecucion    IN TIMESTAMP,
        p_tiempo_real_minutos IN NUMBER,
        p_resultados_medicion IN VARCHAR2,
        p_conforme           IN NUMBER,
        p_observaciones_tarea IN VARCHAR2
    );

    PROCEDURE delete_tarea(
        p_id_tarea_ejecutada IN NUMBER
    );
END pkg_tareas_ejecutadas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tareas_ejecutadas AS

    PROCEDURE insert_tarea(
        p_id_ejecucion       IN NUMBER,
        p_id_tarea           IN NUMBER,
        p_fecha_ejecucion    IN TIMESTAMP,
        p_tiempo_real_minutos IN NUMBER,
        p_resultados_medicion IN VARCHAR2,
        p_conforme           IN NUMBER,
        p_observaciones_tarea IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO tareas_ejecutadas (
            id_ejecucion, id_tarea, fecha_ejecucion,
            tiempo_real_minutos, resultados_medicion,
            conforme, observaciones_tarea
        ) VALUES (
            p_id_ejecucion, p_id_tarea, p_fecha_ejecucion,
            p_tiempo_real_minutos, p_resultados_medicion,
            NVL(p_conforme,1), p_observaciones_tarea
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29801, 'Error al insertar tarea ejecutada: ' || SQLERRM);
    END insert_tarea;

    PROCEDURE get_tarea(
        p_id_tarea_ejecutada IN NUMBER
    ) IS
        r tareas_ejecutadas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tareas_ejecutadas
        WHERE id_tarea_ejecutada = p_id_tarea_ejecutada;

        DBMS_OUTPUT.PUT_LINE('ID Tarea ejecutada: ' || r.id_tarea_ejecutada);
        DBMS_OUTPUT.PUT_LINE('Ejecución: ' || r.id_ejecucion);
        DBMS_OUTPUT.PUT_LINE('Tarea: ' || r.id_tarea);
        DBMS_OUTPUT.PUT_LINE('Fecha ejecución: ' || r.fecha_ejecucion);
        DBMS_OUTPUT.PUT_LINE('Tiempo real (min): ' || r.tiempo_real_minutos);
        DBMS_OUTPUT.PUT_LINE('Resultados medición: ' || r.resultados_medicion);
        DBMS_OUTPUT.PUT_LINE('Conforme: ' || r.conforme);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones_tarea);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Tarea ejecutada no encontrada.');
    END get_tarea;

    PROCEDURE update_tarea(
        p_id_tarea_ejecutada IN NUMBER,
        p_id_ejecucion       IN NUMBER,
        p_id_tarea           IN NUMBER,
        p_fecha_ejecucion    IN TIMESTAMP,
        p_tiempo_real_minutos IN NUMBER,
        p_resultados_medicion IN VARCHAR2,
        p_conforme           IN NUMBER,
        p_observaciones_tarea IN VARCHAR2
    ) IS
    BEGIN
        UPDATE tareas_ejecutadas
        SET id_ejecucion       = p_id_ejecucion,
            id_tarea           = p_id_tarea,
            fecha_ejecucion    = p_fecha_ejecucion,
            tiempo_real_minutos = p_tiempo_real_minutos,
            resultados_medicion = p_resultados_medicion,
            conforme           = p_conforme,
            observaciones_tarea = p_observaciones_tarea
        WHERE id_tarea_ejecutada = p_id_tarea_ejecutada;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29802, 'No se encontró la tarea ejecutada para actualizar.');
        END IF;
    END update_tarea;

    PROCEDURE delete_tarea(
        p_id_tarea_ejecutada IN NUMBER
    ) IS
    BEGIN
        DELETE FROM tareas_ejecutadas
        WHERE id_tarea_ejecutada = p_id_tarea_ejecutada;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29803, 'No se encontró la tarea ejecutada para eliminar.');
        END IF;
    END delete_tarea;

END pkg_tareas_ejecutadas;
/
