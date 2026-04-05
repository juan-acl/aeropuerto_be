------------------------------------------------------------
-- Paquete CRUD para la tabla CUMPLIMIENTO_NORMATIVO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_cumplimiento_normativo AS
    PROCEDURE insert_cumplimiento(
        p_id_normativa             IN NUMBER,
        p_fecha_verificacion       IN DATE DEFAULT SYSDATE,
        p_periodo_verificado       IN VARCHAR2,
        p_responsable_verificacion IN NUMBER,
        p_cumplimiento_porcentaje  IN NUMBER,
        p_hallazgos                IN CLOB,
        p_acciones_correctivas     IN CLOB,
        p_fecha_cierre_acciones    IN DATE,
        p_evidencia_cumplimiento   IN BLOB,
        p_calificacion             IN VARCHAR2,
        p_proxima_verificacion     IN DATE,
        p_verificacion_completada  IN NUMBER DEFAULT 0
    );

    PROCEDURE get_cumplimiento(
        p_id_cumplimiento_normativo IN NUMBER
    );

    PROCEDURE update_cumplimiento(
        p_id_cumplimiento_normativo IN NUMBER,
        p_id_normativa             IN NUMBER,
        p_fecha_verificacion       IN DATE,
        p_periodo_verificado       IN VARCHAR2,
        p_responsable_verificacion IN NUMBER,
        p_cumplimiento_porcentaje  IN NUMBER,
        p_hallazgos                IN CLOB,
        p_acciones_correctivas     IN CLOB,
        p_fecha_cierre_acciones    IN DATE,
        p_evidencia_cumplimiento   IN BLOB,
        p_calificacion             IN VARCHAR2,
        p_proxima_verificacion     IN DATE,
        p_verificacion_completada  IN NUMBER
    );

    PROCEDURE delete_cumplimiento(
        p_id_cumplimiento_normativo IN NUMBER
    );
END pkg_cumplimiento_normativo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_cumplimiento_normativo AS

    PROCEDURE insert_cumplimiento(
        p_id_normativa             IN NUMBER,
        p_fecha_verificacion       IN DATE,
        p_periodo_verificado       IN VARCHAR2,
        p_responsable_verificacion IN NUMBER,
        p_cumplimiento_porcentaje  IN NUMBER,
        p_hallazgos                IN CLOB,
        p_acciones_correctivas     IN CLOB,
        p_fecha_cierre_acciones    IN DATE,
        p_evidencia_cumplimiento   IN BLOB,
        p_calificacion             IN VARCHAR2,
        p_proxima_verificacion     IN DATE,
        p_verificacion_completada  IN NUMBER
    ) IS
    BEGIN
        INSERT INTO cumplimiento_normativo (
            id_normativa, fecha_verificacion, periodo_verificado,
            responsable_verificacion, cumplimiento_porcentaje,
            hallazgos, acciones_correctivas, fecha_cierre_acciones,
            evidencia_cumplimiento, calificacion, proxima_verificacion,
            verificacion_completada
        ) VALUES (
            p_id_normativa, NVL(p_fecha_verificacion, SYSDATE), p_periodo_verificado,
            p_responsable_verificacion, p_cumplimiento_porcentaje,
            p_hallazgos, p_acciones_correctivas, p_fecha_cierre_acciones,
            p_evidencia_cumplimiento, p_calificacion, p_proxima_verificacion,
            NVL(p_verificacion_completada,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33801, 'Error al insertar cumplimiento normativo: ' || SQLERRM);
    END insert_cumplimiento;

    PROCEDURE get_cumplimiento(
        p_id_cumplimiento_normativo IN NUMBER
    ) IS
        r cumplimiento_normativo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM cumplimiento_normativo
        WHERE id_cumplimiento_normativo = p_id_cumplimiento_normativo;

        DBMS_OUTPUT.PUT_LINE('ID Cumplimiento: ' || r.id_cumplimiento_normativo);
        DBMS_OUTPUT.PUT_LINE('Normativa: ' || r.id_normativa);
        DBMS_OUTPUT.PUT_LINE('Fecha verificación: ' || r.fecha_verificacion);
        DBMS_OUTPUT.PUT_LINE('Periodo verificado: ' || r.periodo_verificado);
        DBMS_OUTPUT.PUT_LINE('Responsable verificación: ' || r.responsable_verificacion);
        DBMS_OUTPUT.PUT_LINE('Cumplimiento %: ' || r.cumplimiento_porcentaje);
        DBMS_OUTPUT.PUT_LINE('Hallazgos: ' || DBMS_LOB.SUBSTR(r.hallazgos, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Acciones correctivas: ' || DBMS_LOB.SUBSTR(r.acciones_correctivas, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Fecha cierre acciones: ' || r.fecha_cierre_acciones);
        IF r.evidencia_cumplimiento IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Evidencia cumplimiento: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Evidencia cumplimiento: No adjunta');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Calificación: ' || r.calificacion);
        DBMS_OUTPUT.PUT_LINE('Próxima verificación: ' || r.proxima_verificacion);
        DBMS_OUTPUT.PUT_LINE('Verificación completada: ' || r.verificacion_completada);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Cumplimiento normativo no encontrado.');
    END get_cumplimiento;

    PROCEDURE update_cumplimiento(
        p_id_cumplimiento_normativo IN NUMBER,
        p_id_normativa             IN NUMBER,
        p_fecha_verificacion       IN DATE,
        p_periodo_verificado       IN VARCHAR2,
        p_responsable_verificacion IN NUMBER,
        p_cumplimiento_porcentaje  IN NUMBER,
        p_hallazgos                IN CLOB,
        p_acciones_correctivas     IN CLOB,
        p_fecha_cierre_acciones    IN DATE,
        p_evidencia_cumplimiento   IN BLOB,
        p_calificacion             IN VARCHAR2,
        p_proxima_verificacion     IN DATE,
        p_verificacion_completada  IN NUMBER
    ) IS
    BEGIN
        UPDATE cumplimiento_normativo
        SET id_normativa             = p_id_normativa,
            fecha_verificacion       = p_fecha_verificacion,
            periodo_verificado       = p_periodo_verificado,
            responsable_verificacion = p_responsable_verificacion,
            cumplimiento_porcentaje  = p_cumplimiento_porcentaje,
            hallazgos                = p_hallazgos,
            acciones_correctivas     = p_acciones_correctivas,
            fecha_cierre_acciones    = p_fecha_cierre_acciones,
            evidencia_cumplimiento   = p_evidencia_cumplimiento,
            calificacion             = p_calificacion,
            proxima_verificacion     = p_proxima_verificacion,
            verificacion_completada  = p_verificacion_completada
        WHERE id_cumplimiento_normativo = p_id_cumplimiento_normativo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33802, 'No se encontró el cumplimiento normativo para actualizar.');
        END IF;
    END update_cumplimiento;

    PROCEDURE delete_cumplimiento(
        p_id_cumplimiento_normativo IN NUMBER
    ) IS
    BEGIN
        DELETE FROM cumplimiento_normativo
        WHERE id_cumplimiento_normativo = p_id_cumplimiento_normativo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33803, 'No se encontró el cumplimiento normativo para eliminar.');
        END IF;
    END delete_cumplimiento;

END pkg_cumplimiento_normativo;
/
