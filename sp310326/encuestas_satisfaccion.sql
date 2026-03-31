------------------------------------------------------------
-- Paquete CRUD para la tabla ENCUESTAS_SATISFACCION
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_encuestas_satisfaccion AS
    PROCEDURE insert_encuesta(
        p_id_pasajero        IN NUMBER,
        p_id_vuelo           IN NUMBER,
        p_fecha_encuesta     IN TIMESTAMP,
        p_puntuacion_general IN NUMBER,
        p_puntuacion_checkin IN NUMBER,
        p_puntuacion_abordaje IN NUMBER,
        p_puntuacion_comodidad IN NUMBER,
        p_puntuacion_limpieza IN NUMBER,
        p_puntuacion_atencion IN NUMBER,
        p_puntuacion_equipaje IN NUMBER,
        p_comentarios        IN VARCHAR2,
        p_recomienda         IN NUMBER DEFAULT 1
    );

    PROCEDURE get_encuesta(
        p_id_encuesta IN NUMBER
    );

    PROCEDURE update_encuesta(
        p_id_encuesta        IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_id_vuelo           IN NUMBER,
        p_fecha_encuesta     IN TIMESTAMP,
        p_puntuacion_general IN NUMBER,
        p_puntuacion_checkin IN NUMBER,
        p_puntuacion_abordaje IN NUMBER,
        p_puntuacion_comodidad IN NUMBER,
        p_puntuacion_limpieza IN NUMBER,
        p_puntuacion_atencion IN NUMBER,
        p_puntuacion_equipaje IN NUMBER,
        p_comentarios        IN VARCHAR2,
        p_recomienda         IN NUMBER
    );

    PROCEDURE delete_encuesta(
        p_id_encuesta IN NUMBER
    );
END pkg_encuestas_satisfaccion;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_encuestas_satisfaccion AS

    PROCEDURE insert_encuesta(
        p_id_pasajero        IN NUMBER,
        p_id_vuelo           IN NUMBER,
        p_fecha_encuesta     IN TIMESTAMP,
        p_puntuacion_general IN NUMBER,
        p_puntuacion_checkin IN NUMBER,
        p_puntuacion_abordaje IN NUMBER,
        p_puntuacion_comodidad IN NUMBER,
        p_puntuacion_limpieza IN NUMBER,
        p_puntuacion_atencion IN NUMBER,
        p_puntuacion_equipaje IN NUMBER,
        p_comentarios        IN VARCHAR2,
        p_recomienda         IN NUMBER
    ) IS
    BEGIN
        INSERT INTO encuestas_satisfaccion (
            id_pasajero, id_vuelo, fecha_encuesta,
            puntuacion_general, puntuacion_checkin, puntuacion_abordaje,
            puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion,
            puntuacion_equipaje, comentarios, recomienda
        ) VALUES (
            p_id_pasajero, p_id_vuelo, p_fecha_encuesta,
            p_puntuacion_general, p_puntuacion_checkin, p_puntuacion_abordaje,
            p_puntuacion_comodidad, p_puntuacion_limpieza, p_puntuacion_atencion,
            p_puntuacion_equipaje, p_comentarios, NVL(p_recomienda,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26001, 'Error al insertar encuesta de satisfacción: ' || SQLERRM);
    END insert_encuesta;

    PROCEDURE get_encuesta(
        p_id_encuesta IN NUMBER
    ) IS
        r encuestas_satisfaccion%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM encuestas_satisfaccion
        WHERE id_encuesta = p_id_encuesta;

        DBMS_OUTPUT.PUT_LINE('ID Encuesta: ' || r.id_encuesta);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha_encuesta);
        DBMS_OUTPUT.PUT_LINE('Puntuación general: ' || r.puntuacion_general);
        DBMS_OUTPUT.PUT_LINE('Check-in: ' || r.puntuacion_checkin);
        DBMS_OUTPUT.PUT_LINE('Abordaje: ' || r.puntuacion_abordaje);
        DBMS_OUTPUT.PUT_LINE('Comodidad: ' || r.puntuacion_comodidad);
        DBMS_OUTPUT.PUT_LINE('Limpieza: ' || r.puntuacion_limpieza);
        DBMS_OUTPUT.PUT_LINE('Atención: ' || r.puntuacion_atencion);
        DBMS_OUTPUT.PUT_LINE('Equipaje: ' || r.puntuacion_equipaje);
        DBMS_OUTPUT.PUT_LINE('Comentarios: ' || r.comentarios);
        DBMS_OUTPUT.PUT_LINE('Recomienda: ' || r.recomienda);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Encuesta de satisfacción no encontrada.');
    END get_encuesta;

    PROCEDURE update_encuesta(
        p_id_encuesta        IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_id_vuelo           IN NUMBER,
        p_fecha_encuesta     IN TIMESTAMP,
        p_puntuacion_general IN NUMBER,
        p_puntuacion_checkin IN NUMBER,
        p_puntuacion_abordaje IN NUMBER,
        p_puntuacion_comodidad IN NUMBER,
        p_puntuacion_limpieza IN NUMBER,
        p_puntuacion_atencion IN NUMBER,
        p_puntuacion_equipaje IN NUMBER,
        p_comentarios        IN VARCHAR2,
        p_recomienda         IN NUMBER
    ) IS
    BEGIN
        UPDATE encuestas_satisfaccion
        SET id_pasajero        = p_id_pasajero,
            id_vuelo           = p_id_vuelo,
            fecha_encuesta     = p_fecha_encuesta,
            puntuacion_general = p_puntuacion_general,
            puntuacion_checkin = p_puntuacion_checkin,
            puntuacion_abordaje = p_puntuacion_abordaje,
            puntuacion_comodidad = p_puntuacion_comodidad,
            puntuacion_limpieza = p_puntuacion_limpieza,
            puntuacion_atencion = p_puntuacion_atencion,
            puntuacion_equipaje = p_puntuacion_equipaje,
            comentarios        = p_comentarios,
            recomienda         = p_recomienda
        WHERE id_encuesta = p_id_encuesta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26002, 'No se encontró la encuesta de satisfacción para actualizar.');
        END IF;
    END update_encuesta;

    PROCEDURE delete_encuesta(
        p_id_encuesta IN NUMBER
    ) IS
    BEGIN
        DELETE FROM encuestas_satisfaccion
        WHERE id_encuesta = p_id_encuesta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26003, 'No se encontró la encuesta de satisfacción para eliminar.');
        END IF;
    END delete_encuesta;

END pkg_encuestas_satisfaccion;
/