------------------------------------------------------------
-- Paquete CRUD para la tabla ENCUESTAS_POST_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_encuestas_post_vuelo AS
    PROCEDURE insert_encuesta(
        p_id_vuelo              IN NUMBER,
        p_id_pasajero           IN NUMBER,
        p_fecha_encuesta        IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_canal_respuesta       IN VARCHAR2,
        p_puntuacion_general    IN NUMBER,
        p_puntuacion_checkin    IN NUMBER,
        p_puntuacion_abordaje   IN NUMBER,
        p_puntuacion_tripulacion IN NUMBER,
        p_puntuacion_comida     IN NUMBER,
        p_puntuacion_confort    IN NUMBER,
        p_puntuacion_puntualidad IN NUMBER,
        p_comentarios           IN VARCHAR2,
        p_recomendaria          IN NUMBER,
        p_nps_generado          IN NUMBER,
        p_procesada             IN NUMBER DEFAULT 0
    );

    PROCEDURE get_encuesta(
        p_id_encuesta_post_vuelo IN NUMBER
    );

    PROCEDURE update_encuesta(
        p_id_encuesta_post_vuelo IN NUMBER,
        p_id_vuelo              IN NUMBER,
        p_id_pasajero           IN NUMBER,
        p_fecha_encuesta        IN TIMESTAMP,
        p_canal_respuesta       IN VARCHAR2,
        p_puntuacion_general    IN NUMBER,
        p_puntuacion_checkin    IN NUMBER,
        p_puntuacion_abordaje   IN NUMBER,
        p_puntuacion_tripulacion IN NUMBER,
        p_puntuacion_comida     IN NUMBER,
        p_puntuacion_confort    IN NUMBER,
        p_puntuacion_puntualidad IN NUMBER,
        p_comentarios           IN VARCHAR2,
        p_recomendaria          IN NUMBER,
        p_nps_generado          IN NUMBER,
        p_procesada             IN NUMBER
    );

    PROCEDURE delete_encuesta(
        p_id_encuesta_post_vuelo IN NUMBER
    );
END pkg_encuestas_post_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_encuestas_post_vuelo AS

    PROCEDURE insert_encuesta(
        p_id_vuelo              IN NUMBER,
        p_id_pasajero           IN NUMBER,
        p_fecha_encuesta        IN TIMESTAMP,
        p_canal_respuesta       IN VARCHAR2,
        p_puntuacion_general    IN NUMBER,
        p_puntuacion_checkin    IN NUMBER,
        p_puntuacion_abordaje   IN NUMBER,
        p_puntuacion_tripulacion IN NUMBER,
        p_puntuacion_comida     IN NUMBER,
        p_puntuacion_confort    IN NUMBER,
        p_puntuacion_puntualidad IN NUMBER,
        p_comentarios           IN VARCHAR2,
        p_recomendaria          IN NUMBER,
        p_nps_generado          IN NUMBER,
        p_procesada             IN NUMBER
    ) IS
    BEGIN
        INSERT INTO encuestas_post_vuelo (
            id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta,
            puntuacion_general, puntuacion_checkin, puntuacion_abordaje,
            puntuacion_tripulacion, puntuacion_comida, puntuacion_confort,
            puntuacion_puntualidad, comentarios, recomendaria,
            nps_generado, procesada
        ) VALUES (
            p_id_vuelo, p_id_pasajero, NVL(p_fecha_encuesta, SYSTIMESTAMP), p_canal_respuesta,
            p_puntuacion_general, p_puntuacion_checkin, p_puntuacion_abordaje,
            p_puntuacion_tripulacion, p_puntuacion_comida, p_puntuacion_confort,
            p_puntuacion_puntualidad, p_comentarios, p_recomendaria,
            p_nps_generado, NVL(p_procesada,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33301, 'Error al insertar encuesta post-vuelo: ' || SQLERRM);
    END insert_encuesta;

    PROCEDURE get_encuesta(
        p_id_encuesta_post_vuelo IN NUMBER
    ) IS
        r encuestas_post_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM encuestas_post_vuelo
        WHERE id_encuesta_post_vuelo = p_id_encuesta_post_vuelo;

        DBMS_OUTPUT.PUT_LINE('ID Encuesta: ' || r.id_encuesta_post_vuelo);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Fecha encuesta: ' || r.fecha_encuesta);
        DBMS_OUTPUT.PUT_LINE('Canal respuesta: ' || r.canal_respuesta);
        DBMS_OUTPUT.PUT_LINE('Puntuación general: ' || r.puntuacion_general);
        DBMS_OUTPUT.PUT_LINE('Check-in: ' || r.puntuacion_checkin);
        DBMS_OUTPUT.PUT_LINE('Abordaje: ' || r.puntuacion_abordaje);
        DBMS_OUTPUT.PUT_LINE('Tripulación: ' || r.puntuacion_tripulacion);
        DBMS_OUTPUT.PUT_LINE('Comida: ' || r.puntuacion_comida);
        DBMS_OUTPUT.PUT_LINE('Confort: ' || r.puntuacion_confort);
        DBMS_OUTPUT.PUT_LINE('Puntualidad: ' || r.puntuacion_puntualidad);
        DBMS_OUTPUT.PUT_LINE('Comentarios: ' || r.comentarios);
        DBMS_OUTPUT.PUT_LINE('Recomendaría: ' || r.recomendaria);
        DBMS_OUTPUT.PUT_LINE('NPS generado: ' || r.nps_generado);
        DBMS_OUTPUT.PUT_LINE('Procesada: ' || r.procesada);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Encuesta post-vuelo no encontrada.');
    END get_encuesta;

    PROCEDURE update_encuesta(
        p_id_encuesta_post_vuelo IN NUMBER,
        p_id_vuelo              IN NUMBER,
        p_id_pasajero           IN NUMBER,
        p_fecha_encuesta        IN TIMESTAMP,
        p_canal_respuesta       IN VARCHAR2,
        p_puntuacion_general    IN NUMBER,
        p_puntuacion_checkin    IN NUMBER,
        p_puntuacion_abordaje   IN NUMBER,
        p_puntuacion_tripulacion IN NUMBER,
        p_puntuacion_comida     IN NUMBER,
        p_puntuacion_confort    IN NUMBER,
        p_puntuacion_puntualidad IN NUMBER,
        p_comentarios           IN VARCHAR2,
        p_recomendaria          IN NUMBER,
        p_nps_generado          IN NUMBER,
        p_procesada             IN NUMBER
    ) IS
    BEGIN
        UPDATE encuestas_post_vuelo
        SET id_vuelo              = p_id_vuelo,
            id_pasajero           = p_id_pasajero,
            fecha_encuesta        = p_fecha_encuesta,
            canal_respuesta       = p_canal_respuesta,
            puntuacion_general    = p_puntuacion_general,
            puntuacion_checkin    = p_puntuacion_checkin,
            puntuacion_abordaje   = p_puntuacion_abordaje,
            puntuacion_tripulacion = p_puntuacion_tripulacion,
            puntuacion_comida     = p_puntuacion_comida,
            puntuacion_confort    = p_puntuacion_confort,
            puntuacion_puntualidad = p_puntuacion_puntualidad,
            comentarios           = p_comentarios,
            recomendaria          = p_recomendaria,
            nps_generado          = p_nps_generado,
            procesada             = p_procesada
        WHERE id_encuesta_post_vuelo = p_id_encuesta_post_vuelo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33302, 'No se encontró la encuesta post-vuelo para actualizar.');
        END IF;
    END update_encuesta;

    PROCEDURE delete_encuesta(
        p_id_encuesta_post_vuelo IN NUMBER
    ) IS
    BEGIN
        DELETE FROM encuestas_post_vuelo
        WHERE id_encuesta_post_vuelo = p_id_encuesta_post_vuelo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33303, 'No se encontró la encuesta post-vuelo para eliminar.');
        END IF;
    END delete_encuesta;

END pkg_encuestas_post_vuelo;
/
