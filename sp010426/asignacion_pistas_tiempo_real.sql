------------------------------------------------------------
-- Paquete CRUD para la tabla ASIGNACION_PISTAS_TIEMPO_REAL
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_asignacion_pistas AS
    PROCEDURE insert_asignacion(
        p_id_pista              IN NUMBER,
        p_id_vuelo              IN NUMBER,
        p_tipo_operacion        IN VARCHAR2,
        p_fecha_hora_asignacion IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_hora_inicio_estimada  IN TIMESTAMP,
        p_hora_fin_estimada     IN TIMESTAMP,
        p_hora_inicio_real      IN TIMESTAMP,
        p_hora_fin_real         IN TIMESTAMP,
        p_estado_asignacion     IN VARCHAR2 DEFAULT 'PROGRAMADA',
        p_asignado_por          IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE get_asignacion(
        p_id_asignacion_pista IN NUMBER
    );

    PROCEDURE update_asignacion(
        p_id_asignacion_pista  IN NUMBER,
        p_id_pista             IN NUMBER,
        p_id_vuelo             IN NUMBER,
        p_tipo_operacion       IN VARCHAR2,
        p_fecha_hora_asignacion IN TIMESTAMP,
        p_hora_inicio_estimada IN TIMESTAMP,
        p_hora_fin_estimada    IN TIMESTAMP,
        p_hora_inicio_real     IN TIMESTAMP,
        p_hora_fin_real        IN TIMESTAMP,
        p_estado_asignacion    IN VARCHAR2,
        p_asignado_por         IN NUMBER,
        p_observaciones        IN VARCHAR2
    );

    PROCEDURE delete_asignacion(
        p_id_asignacion_pista IN NUMBER
    );
END pkg_asignacion_pistas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_asignacion_pistas AS

    PROCEDURE insert_asignacion(
        p_id_pista              IN NUMBER,
        p_id_vuelo              IN NUMBER,
        p_tipo_operacion        IN VARCHAR2,
        p_fecha_hora_asignacion IN TIMESTAMP,
        p_hora_inicio_estimada  IN TIMESTAMP,
        p_hora_fin_estimada     IN TIMESTAMP,
        p_hora_inicio_real      IN TIMESTAMP,
        p_hora_fin_real         IN TIMESTAMP,
        p_estado_asignacion     IN VARCHAR2,
        p_asignado_por          IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO asignacion_pistas_tiempo_real (
            id_pista, id_vuelo, tipo_operacion, fecha_hora_asignacion,
            hora_inicio_estimada, hora_fin_estimada,
            hora_inicio_real, hora_fin_real,
            estado_asignacion, asignado_por, observaciones
        ) VALUES (
            p_id_pista, p_id_vuelo, p_tipo_operacion, NVL(p_fecha_hora_asignacion, SYSTIMESTAMP),
            p_hora_inicio_estimada, p_hora_fin_estimada,
            p_hora_inicio_real, p_hora_fin_real,
            NVL(p_estado_asignacion,'PROGRAMADA'), p_asignado_por, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30001, 'Error al insertar asignación de pista: ' || SQLERRM);
    END insert_asignacion;

    PROCEDURE get_asignacion(
        p_id_asignacion_pista IN NUMBER
    ) IS
        r asignacion_pistas_tiempo_real%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM asignacion_pistas_tiempo_real
        WHERE id_asignacion_pista = p_id_asignacion_pista;

        DBMS_OUTPUT.PUT_LINE('ID Asignación: ' || r.id_asignacion_pista);
        DBMS_OUTPUT.PUT_LINE('Pista: ' || r.id_pista);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Tipo operación: ' || r.tipo_operacion);
        DBMS_OUTPUT.PUT_LINE('Fecha/hora asignación: ' || r.fecha_hora_asignacion);
        DBMS_OUTPUT.PUT_LINE('Hora inicio estimada: ' || r.hora_inicio_estimada);
        DBMS_OUTPUT.PUT_LINE('Hora fin estimada: ' || r.hora_fin_estimada);
        DBMS_OUTPUT.PUT_LINE('Hora inicio real: ' || r.hora_inicio_real);
        DBMS_OUTPUT.PUT_LINE('Hora fin real: ' || r.hora_fin_real);
        DBMS_OUTPUT.PUT_LINE('Estado asignación: ' || r.estado_asignacion);
        DBMS_OUTPUT.PUT_LINE('Asignado por: ' || r.asignado_por);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Asignación de pista no encontrada.');
    END get_asignacion;

    PROCEDURE update_asignacion(
        p_id_asignacion_pista  IN NUMBER,
        p_id_pista             IN NUMBER,
        p_id_vuelo             IN NUMBER,
        p_tipo_operacion       IN VARCHAR2,
        p_fecha_hora_asignacion IN TIMESTAMP,
        p_hora_inicio_estimada IN TIMESTAMP,
        p_hora_fin_estimada    IN TIMESTAMP,
        p_hora_inicio_real     IN TIMESTAMP,
        p_hora_fin_real        IN TIMESTAMP,
        p_estado_asignacion    IN VARCHAR2,
        p_asignado_por         IN NUMBER,
        p_observaciones        IN VARCHAR2
    ) IS
    BEGIN
        UPDATE asignacion_pistas_tiempo_real
        SET id_pista              = p_id_pista,
            id_vuelo              = p_id_vuelo,
            tipo_operacion        = p_tipo_operacion,
            fecha_hora_asignacion = p_fecha_hora_asignacion,
            hora_inicio_estimada  = p_hora_inicio_estimada,
            hora_fin_estimada     = p_hora_fin_estimada,
            hora_inicio_real      = p_hora_inicio_real,
            hora_fin_real         = p_hora_fin_real,
            estado_asignacion     = p_estado_asignacion,
            asignado_por          = p_asignado_por,
            observaciones         = p_observaciones
        WHERE id_asignacion_pista = p_id_asignacion_pista;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30002, 'No se encontró la asignación de pista para actualizar.');
        END IF;
    END update_asignacion;

    PROCEDURE delete_asignacion(
        p_id_asignacion_pista IN NUMBER
    ) IS
    BEGIN
        DELETE FROM asignacion_pistas_tiempo_real
        WHERE id_asignacion_pista = p_id_asignacion_pista;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30003, 'No se encontró la asignación de pista para eliminar.');
        END IF;
    END delete_asignacion;

END pkg_asignacion_pistas;
/
