------------------------------------------------------------
-- Paquete CRUD para la tabla DESVIOS_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_desvios_vuelo AS
    PROCEDURE insert_desvio(
        p_id_vuelo              IN desvios_vuelo.id_vuelo%TYPE,
        p_aeropuerto_desvio     IN desvios_vuelo.aeropuerto_desvio%TYPE,
        p_fecha_desvio          IN desvios_vuelo.fecha_desvio%TYPE,
        p_motivo                IN desvios_vuelo.motivo%TYPE,
        p_duracion_desvio_min   IN desvios_vuelo.duracion_desvio_minutos%TYPE,
        p_acciones_tomadas      IN desvios_vuelo.acciones_tomadas%TYPE
    );

    PROCEDURE get_desvio(
        p_id_desvio IN desvios_vuelo.id_desvio%TYPE
    );

    PROCEDURE update_desvio(
        p_id_desvio             IN desvios_vuelo.id_desvio%TYPE,
        p_id_vuelo              IN desvios_vuelo.id_vuelo%TYPE,
        p_aeropuerto_desvio     IN desvios_vuelo.aeropuerto_desvio%TYPE,
        p_fecha_desvio          IN desvios_vuelo.fecha_desvio%TYPE,
        p_motivo                IN desvios_vuelo.motivo%TYPE,
        p_duracion_desvio_min   IN desvios_vuelo.duracion_desvio_minutos%TYPE,
        p_acciones_tomadas      IN desvios_vuelo.acciones_tomadas%TYPE
    );

    PROCEDURE delete_desvio(
        p_id_desvio IN desvios_vuelo.id_desvio%TYPE
    );
END pkg_desvios_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_desvios_vuelo AS

    PROCEDURE insert_desvio(
        p_id_vuelo              IN desvios_vuelo.id_vuelo%TYPE,
        p_aeropuerto_desvio     IN desvios_vuelo.aeropuerto_desvio%TYPE,
        p_fecha_desvio          IN desvios_vuelo.fecha_desvio%TYPE,
        p_motivo                IN desvios_vuelo.motivo%TYPE,
        p_duracion_desvio_min   IN desvios_vuelo.duracion_desvio_minutos%TYPE,
        p_acciones_tomadas      IN desvios_vuelo.acciones_tomadas%TYPE
    ) IS
    BEGIN
        INSERT INTO desvios_vuelo (
            id_vuelo, aeropuerto_desvio, fecha_desvio,
            motivo, duracion_desvio_minutos, acciones_tomadas
        ) VALUES (
            p_id_vuelo, p_aeropuerto_desvio, p_fecha_desvio,
            p_motivo, p_duracion_desvio_min, p_acciones_tomadas
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21001, 'Error al insertar desvío: ' || SQLERRM);
    END insert_desvio;

    PROCEDURE get_desvio(
        p_id_desvio IN desvios_vuelo.id_desvio%TYPE
    ) IS
        r desvios_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM desvios_vuelo
        WHERE id_desvio = p_id_desvio;

        DBMS_OUTPUT.PUT_LINE('ID Desvío: ' || r.id_desvio);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto desvío: ' || r.aeropuerto_desvio);
        DBMS_OUTPUT.PUT_LINE('Fecha desvío: ' || r.fecha_desvio);
        DBMS_OUTPUT.PUT_LINE('Motivo: ' || r.motivo);
        DBMS_OUTPUT.PUT_LINE('Duración (min): ' || r.duracion_desvio_minutos);
        DBMS_OUTPUT.PUT_LINE('Acciones tomadas: ' || r.acciones_tomadas);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Desvío no encontrado.');
    END get_desvio;

    PROCEDURE update_desvio(
        p_id_desvio             IN desvios_vuelo.id_desvio%TYPE,
        p_id_vuelo              IN desvios_vuelo.id_vuelo%TYPE,
        p_aeropuerto_desvio     IN desvios_vuelo.aeropuerto_desvio%TYPE,
        p_fecha_desvio          IN desvios_vuelo.fecha_desvio%TYPE,
        p_motivo                IN desvios_vuelo.motivo%TYPE,
        p_duracion_desvio_min   IN desvios_vuelo.duracion_desvio_minutos%TYPE,
        p_acciones_tomadas      IN desvios_vuelo.acciones_tomadas%TYPE
    ) IS
    BEGIN
        UPDATE desvios_vuelo
        SET id_vuelo              = p_id_vuelo,
            aeropuerto_desvio     = p_aeropuerto_desvio,
            fecha_desvio          = p_fecha_desvio,
            motivo                = p_motivo,
            duracion_desvio_minutos = p_duracion_desvio_min,
            acciones_tomadas      = p_acciones_tomadas
        WHERE id_desvio = p_id_desvio;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21002, 'No se encontró el desvío para actualizar.');
        END IF;
    END update_desvio;

    PROCEDURE delete_desvio(
        p_id_desvio IN desvios_vuelo.id_desvio%TYPE
    ) IS
    BEGIN
        DELETE FROM desvios_vuelo
        WHERE id_desvio = p_id_desvio;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21003, 'No se encontró el desvío para eliminar.');
        END IF;
    END delete_desvio;

END pkg_desvios_vuelo;
/