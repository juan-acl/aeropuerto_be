------------------------------------------------------------
-- Paquete CRUD para la tabla RETRASOS_TIEMPO_REAL
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_retrasos_tiempo_real AS
    PROCEDURE insert_retraso(
        p_id_vuelo                 IN NUMBER,
        p_fecha_hora_registro      IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_tipo_retraso             IN VARCHAR2,
        p_causa_especifica         IN VARCHAR2,
        p_minutos_retraso_actuales IN NUMBER,
        p_minutos_retraso_estimados IN NUMBER,
        p_impacto_global           IN NUMBER DEFAULT 0,
        p_afecta_conexiones        IN NUMBER DEFAULT 0,
        p_notificado_pasajeros     IN NUMBER DEFAULT 0,
        p_actualizado_por          IN NUMBER,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE get_retraso(
        p_id_retraso_tiempo_real IN NUMBER
    );

    PROCEDURE update_retraso(
        p_id_retraso_tiempo_real  IN NUMBER,
        p_id_vuelo                IN NUMBER,
        p_fecha_hora_registro     IN TIMESTAMP,
        p_tipo_retraso            IN VARCHAR2,
        p_causa_especifica        IN VARCHAR2,
        p_minutos_retraso_actuales IN NUMBER,
        p_minutos_retraso_estimados IN NUMBER,
        p_impacto_global          IN NUMBER,
        p_afecta_conexiones       IN NUMBER,
        p_notificado_pasajeros    IN NUMBER,
        p_actualizado_por         IN NUMBER,
        p_observaciones           IN VARCHAR2
    );

    PROCEDURE delete_retraso(
        p_id_retraso_tiempo_real IN NUMBER
    );
END pkg_retrasos_tiempo_real;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_retrasos_tiempo_real AS

    PROCEDURE insert_retraso(
        p_id_vuelo                 IN NUMBER,
        p_fecha_hora_registro      IN TIMESTAMP,
        p_tipo_retraso             IN VARCHAR2,
        p_causa_especifica         IN VARCHAR2,
        p_minutos_retraso_actuales IN NUMBER,
        p_minutos_retraso_estimados IN NUMBER,
        p_impacto_global           IN NUMBER,
        p_afecta_conexiones        IN NUMBER,
        p_notificado_pasajeros     IN NUMBER,
        p_actualizado_por          IN NUMBER,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO retrasos_tiempo_real (
            id_vuelo, fecha_hora_registro, tipo_retraso, causa_especifica,
            minutos_retraso_actuales, minutos_retraso_estimados,
            impacto_global, afecta_conexiones, notificado_pasajeros,
            actualizado_por, observaciones
        ) VALUES (
            p_id_vuelo, NVL(p_fecha_hora_registro, SYSTIMESTAMP), p_tipo_retraso, p_causa_especifica,
            p_minutos_retraso_actuales, p_minutos_retraso_estimados,
            NVL(p_impacto_global,0), NVL(p_afecta_conexiones,0), NVL(p_notificado_pasajeros,0),
            p_actualizado_por, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30201, 'Error al insertar retraso en tiempo real: ' || SQLERRM);
    END insert_retraso;

    PROCEDURE get_retraso(
        p_id_retraso_tiempo_real IN NUMBER
    ) IS
        r retrasos_tiempo_real%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM retrasos_tiempo_real
        WHERE id_retraso_tiempo_real = p_id_retraso_tiempo_real;

        DBMS_OUTPUT.PUT_LINE('ID Retraso: ' || r.id_retraso_tiempo_real);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Fecha/hora registro: ' || r.fecha_hora_registro);
        DBMS_OUTPUT.PUT_LINE('Tipo retraso: ' || r.tipo_retraso);
        DBMS_OUTPUT.PUT_LINE('Causa específica: ' || r.causa_especifica);
        DBMS_OUTPUT.PUT_LINE('Minutos retraso actuales: ' || r.minutos_retraso_actuales);
        DBMS_OUTPUT.PUT_LINE('Minutos retraso estimados: ' || r.minutos_retraso_estimados);
        DBMS_OUTPUT.PUT_LINE('Impacto global: ' || r.impacto_global);
        DBMS_OUTPUT.PUT_LINE('Afecta conexiones: ' || r.afecta_conexiones);
        DBMS_OUTPUT.PUT_LINE('Notificado pasajeros: ' || r.notificado_pasajeros);
        DBMS_OUTPUT.PUT_LINE('Actualizado por: ' || r.actualizado_por);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Retraso en tiempo real no encontrado.');
    END get_retraso;

    PROCEDURE update_retraso(
        p_id_retraso_tiempo_real  IN NUMBER,
        p_id_vuelo                IN NUMBER,
        p_fecha_hora_registro     IN TIMESTAMP,
        p_tipo_retraso            IN VARCHAR2,
        p_causa_especifica        IN VARCHAR2,
        p_minutos_retraso_actuales IN NUMBER,
        p_minutos_retraso_estimados IN NUMBER,
        p_impacto_global          IN NUMBER,
        p_afecta_conexiones       IN NUMBER,
        p_notificado_pasajeros    IN NUMBER,
        p_actualizado_por         IN NUMBER,
        p_observaciones           IN VARCHAR2
    ) IS
    BEGIN
        UPDATE retrasos_tiempo_real
        SET id_vuelo                = p_id_vuelo,
            fecha_hora_registro     = p_fecha_hora_registro,
            tipo_retraso            = p_tipo_retraso,
            causa_especifica        = p_causa_especifica,
            minutos_retraso_actuales = p_minutos_retraso_actuales,
            minutos_retraso_estimados = p_minutos_retraso_estimados,
            impacto_global          = p_impacto_global,
            afecta_conexiones       = p_afecta_conexiones,
            notificado_pasajeros    = p_notificado_pasajeros,
            actualizado_por         = p_actualizado_por,
            observaciones           = p_observaciones
        WHERE id_retraso_tiempo_real = p_id_retraso_tiempo_real;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30202, 'No se encontró el retraso en tiempo real para actualizar.');
        END IF;
    END update_retraso;

    PROCEDURE delete_retraso(
        p_id_retraso_tiempo_real IN NUMBER
    ) IS
    BEGIN
        DELETE FROM retrasos_tiempo_real
        WHERE id_retraso_tiempo_real = p_id_retraso_tiempo_real;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30203, 'No se encontró el retraso en tiempo real para eliminar.');
        END IF;
    END delete_retraso;

END pkg_retrasos_tiempo_real;
/
