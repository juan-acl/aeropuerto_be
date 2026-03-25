------------------------------------------------------------
-- Paquete CRUD para la tabla ESCALAS_TECNICAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_escalas_tecnicas AS
    PROCEDURE insert_escala(
        p_id_vuelo               IN escalas_tecnicas.id_vuelo%TYPE,
        p_aeropuerto_escala      IN escalas_tecnicas.aeropuerto_escala%TYPE,
        p_numero_orden           IN escalas_tecnicas.numero_orden%TYPE,
        p_hora_llegada           IN escalas_tecnicas.hora_llegada%TYPE,
        p_hora_despegue          IN escalas_tecnicas.hora_despegue%TYPE,
        p_tiempo_escala_minutos  IN escalas_tecnicas.tiempo_escala_minutos%TYPE,
        p_motivo_escala          IN escalas_tecnicas.motivo_escala%TYPE,
        p_observaciones          IN escalas_tecnicas.observaciones%TYPE
    );

    PROCEDURE get_escala(
        p_id_escala IN escalas_tecnicas.id_escala%TYPE
    );

    PROCEDURE update_escala(
        p_id_escala              IN escalas_tecnicas.id_escala%TYPE,
        p_id_vuelo               IN escalas_tecnicas.id_vuelo%TYPE,
        p_aeropuerto_escala      IN escalas_tecnicas.aeropuerto_escala%TYPE,
        p_numero_orden           IN escalas_tecnicas.numero_orden%TYPE,
        p_hora_llegada           IN escalas_tecnicas.hora_llegada%TYPE,
        p_hora_despegue          IN escalas_tecnicas.hora_despegue%TYPE,
        p_tiempo_escala_minutos  IN escalas_tecnicas.tiempo_escala_minutos%TYPE,
        p_motivo_escala          IN escalas_tecnicas.motivo_escala%TYPE,
        p_observaciones          IN escalas_tecnicas.observaciones%TYPE
    );

    PROCEDURE delete_escala(
        p_id_escala IN escalas_tecnicas.id_escala%TYPE
    );
END pkg_escalas_tecnicas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_escalas_tecnicas AS

    PROCEDURE insert_escala(
        p_id_vuelo               IN escalas_tecnicas.id_vuelo%TYPE,
        p_aeropuerto_escala      IN escalas_tecnicas.aeropuerto_escala%TYPE,
        p_numero_orden           IN escalas_tecnicas.numero_orden%TYPE,
        p_hora_llegada           IN escalas_tecnicas.hora_llegada%TYPE,
        p_hora_despegue          IN escalas_tecnicas.hora_despegue%TYPE,
        p_tiempo_escala_minutos  IN escalas_tecnicas.tiempo_escala_minutos%TYPE,
        p_motivo_escala          IN escalas_tecnicas.motivo_escala%TYPE,
        p_observaciones          IN escalas_tecnicas.observaciones%TYPE
    ) IS
    BEGIN
        INSERT INTO escalas_tecnicas (
            id_vuelo, aeropuerto_escala, numero_orden,
            hora_llegada, hora_despegue, tiempo_escala_minutos,
            motivo_escala, observaciones
        ) VALUES (
            p_id_vuelo, p_aeropuerto_escala, p_numero_orden,
            p_hora_llegada, p_hora_despegue, p_tiempo_escala_minutos,
            p_motivo_escala, p_observaciones
        );
    EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
            RAISE_APPLICATION_ERROR(-20501, 'Ya existe una escala con ese número de orden para el vuelo.');
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20502, 'Error al insertar escala técnica: ' || SQLERRM);
    END insert_escala;

    PROCEDURE get_escala(
        p_id_escala IN escalas_tecnicas.id_escala%TYPE
    ) IS
        r escalas_tecnicas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM escalas_tecnicas
        WHERE id_escala = p_id_escala;

        DBMS_OUTPUT.PUT_LINE('ID Escala: ' || r.id_escala);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto escala: ' || r.aeropuerto_escala);
        DBMS_OUTPUT.PUT_LINE('Número orden: ' || r.numero_orden);
        DBMS_OUTPUT.PUT_LINE('Hora llegada: ' || r.hora_llegada);
        DBMS_OUTPUT.PUT_LINE('Hora despegue: ' || r.hora_despegue);
        DBMS_OUTPUT.PUT_LINE('Tiempo escala (min): ' || r.tiempo_escala_minutos);
        DBMS_OUTPUT.PUT_LINE('Motivo: ' || r.motivo_escala);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Escala técnica no encontrada.');
    END get_escala;

    PROCEDURE update_escala(
        p_id_escala              IN escalas_tecnicas.id_escala%TYPE,
        p_id_vuelo               IN escalas_tecnicas.id_vuelo%TYPE,
        p_aeropuerto_escala      IN escalas_tecnicas.aeropuerto_escala%TYPE,
        p_numero_orden           IN escalas_tecnicas.numero_orden%TYPE,
        p_hora_llegada           IN escalas_tecnicas.hora_llegada%TYPE,
        p_hora_despegue          IN escalas_tecnicas.hora_despegue%TYPE,
        p_tiempo_escala_minutos  IN escalas_tecnicas.tiempo_escala_minutos%TYPE,
        p_motivo_escala          IN escalas_tecnicas.motivo_escala%TYPE,
        p_observaciones          IN escalas_tecnicas.observaciones%TYPE
    ) IS
    BEGIN
        UPDATE escalas_tecnicas
        SET id_vuelo              = p_id_vuelo,
            aeropuerto_escala     = p_aeropuerto_escala,
            numero_orden          = p_numero_orden,
            hora_llegada          = p_hora_llegada,
            hora_despegue         = p_hora_despegue,
            tiempo_escala_minutos = p_tiempo_escala_minutos,
            motivo_escala         = p_motivo_escala,
            observaciones         = p_observaciones
        WHERE id_escala = p_id_escala;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20503, 'No se encontró la escala técnica para actualizar.');
        END IF;
    END update_escala;

    PROCEDURE delete_escala(
        p_id_escala IN escalas_tecnicas.id_escala%TYPE
    ) IS
    BEGIN
        DELETE FROM escalas_tecnicas
        WHERE id_escala = p_id_escala;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20504, 'No se encontró la escala técnica para eliminar.');
        END IF;
    END delete_escala;

END pkg_escalas_tecnicas;
/