------------------------------------------------------------
-- Paquete CRUD para la tabla EMERGENCIAS_MEDICAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_emergencias_medicas AS
    PROCEDURE insert_emergencia(
        p_id_pasajero            IN NUMBER,
        p_id_vuelo               IN NUMBER,
        p_codigo_aeropuerto      IN VARCHAR2,
        p_fecha_emergencia       IN TIMESTAMP,
        p_tipo_emergencia        IN VARCHAR2,
        p_sintomas               IN VARCHAR2,
        p_diagnostico_inicial    IN VARCHAR2,
        p_personal_atendio       IN VARCHAR2,
        p_tratamiento            IN VARCHAR2,
        p_requiere_hospitalizacion IN NUMBER DEFAULT 0,
        p_hospital_destino       IN VARCHAR2,
        p_fecha_alta             IN DATE
    );

    PROCEDURE get_emergencia(
        p_id_emergencia IN NUMBER
    );

    PROCEDURE update_emergencia(
        p_id_emergencia          IN NUMBER,
        p_id_pasajero            IN NUMBER,
        p_id_vuelo               IN NUMBER,
        p_codigo_aeropuerto      IN VARCHAR2,
        p_fecha_emergencia       IN TIMESTAMP,
        p_tipo_emergencia        IN VARCHAR2,
        p_sintomas               IN VARCHAR2,
        p_diagnostico_inicial    IN VARCHAR2,
        p_personal_atendio       IN VARCHAR2,
        p_tratamiento            IN VARCHAR2,
        p_requiere_hospitalizacion IN NUMBER,
        p_hospital_destino       IN VARCHAR2,
        p_fecha_alta             IN DATE
    );

    PROCEDURE delete_emergencia(
        p_id_emergencia IN NUMBER
    );
END pkg_emergencias_medicas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_emergencias_medicas AS

    PROCEDURE insert_emergencia(
        p_id_pasajero            IN NUMBER,
        p_id_vuelo               IN NUMBER,
        p_codigo_aeropuerto      IN VARCHAR2,
        p_fecha_emergencia       IN TIMESTAMP,
        p_tipo_emergencia        IN VARCHAR2,
        p_sintomas               IN VARCHAR2,
        p_diagnostico_inicial    IN VARCHAR2,
        p_personal_atendio       IN VARCHAR2,
        p_tratamiento            IN VARCHAR2,
        p_requiere_hospitalizacion IN NUMBER,
        p_hospital_destino       IN VARCHAR2,
        p_fecha_alta             IN DATE
    ) IS
    BEGIN
        INSERT INTO emergencias_medicas (
            id_pasajero, id_vuelo, codigo_aeropuerto,
            fecha_emergencia, tipo_emergencia, sintomas,
            diagnostico_inicial, personal_atendio, tratamiento,
            requiere_hospitalizacion, hospital_destino, fecha_alta
        ) VALUES (
            p_id_pasajero, p_id_vuelo, p_codigo_aeropuerto,
            p_fecha_emergencia, p_tipo_emergencia, p_sintomas,
            p_diagnostico_inicial, p_personal_atendio, p_tratamiento,
            NVL(p_requiere_hospitalizacion,0), p_hospital_destino, p_fecha_alta
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23901, 'Error al insertar emergencia médica: ' || SQLERRM);
    END insert_emergencia;

    PROCEDURE get_emergencia(
        p_id_emergencia IN NUMBER
    ) IS
        r emergencias_medicas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM emergencias_medicas
        WHERE id_emergencia = p_id_emergencia;

        DBMS_OUTPUT.PUT_LINE('ID Emergencia: ' || r.id_emergencia);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Fecha emergencia: ' || r.fecha_emergencia);
        DBMS_OUTPUT.PUT_LINE('Tipo emergencia: ' || r.tipo_emergencia);
        DBMS_OUTPUT.PUT_LINE('Síntomas: ' || r.sintomas);
        DBMS_OUTPUT.PUT_LINE('Diagnóstico inicial: ' || r.diagnostico_inicial);
        DBMS_OUTPUT.PUT_LINE('Personal atendió: ' || r.personal_atendio);
        DBMS_OUTPUT.PUT_LINE('Tratamiento: ' || r.tratamiento);
        DBMS_OUTPUT.PUT_LINE('Requiere hospitalización: ' || r.requiere_hospitalizacion);
        DBMS_OUTPUT.PUT_LINE('Hospital destino: ' || r.hospital_destino);
        DBMS_OUTPUT.PUT_LINE('Fecha alta: ' || r.fecha_alta);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Emergencia médica no encontrada.');
    END get_emergencia;

    PROCEDURE update_emergencia(
        p_id_emergencia          IN NUMBER,
        p_id_pasajero            IN NUMBER,
        p_id_vuelo               IN NUMBER,
        p_codigo_aeropuerto      IN VARCHAR2,
        p_fecha_emergencia       IN TIMESTAMP,
        p_tipo_emergencia        IN VARCHAR2,
        p_sintomas               IN VARCHAR2,
        p_diagnostico_inicial    IN VARCHAR2,
        p_personal_atendio       IN VARCHAR2,
        p_tratamiento            IN VARCHAR2,
        p_requiere_hospitalizacion IN NUMBER,
        p_hospital_destino       IN VARCHAR2,
        p_fecha_alta             IN DATE
    ) IS
    BEGIN
        UPDATE emergencias_medicas
        SET id_pasajero            = p_id_pasajero,
            id_vuelo               = p_id_vuelo,
            codigo_aeropuerto      = p_codigo_aeropuerto,
            fecha_emergencia       = p_fecha_emergencia,
            tipo_emergencia        = p_tipo_emergencia,
            sintomas               = p_sintomas,
            diagnostico_inicial    = p_diagnostico_inicial,
            personal_atendio       = p_personal_atendio,
            tratamiento            = p_tratamiento,
            requiere_hospitalizacion = p_requiere_hospitalizacion,
            hospital_destino       = p_hospital_destino,
            fecha_alta             = p_fecha_alta
        WHERE id_emergencia = p_id_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23902, 'No se encontró la emergencia médica para actualizar.');
        END IF;
    END update_emergencia;

    PROCEDURE delete_emergencia(
        p_id_emergencia IN NUMBER
    ) IS
    BEGIN
        DELETE FROM emergencias_medicas
        WHERE id_emergencia = p_id_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23903, 'No se encontró la emergencia médica para eliminar.');
        END IF;
    END delete_emergencia;

END pkg_emergencias_medicas;
/