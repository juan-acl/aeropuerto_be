------------------------------------------------------------
-- Paquete CRUD para la tabla RETRASOS_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_retrasos_vuelo AS
    PROCEDURE insert_retraso(
        p_id_vuelo                IN retrasos_vuelo.id_vuelo%TYPE,
        p_minutos_retraso         IN retrasos_vuelo.minutos_retraso%TYPE,
        p_tipo_retraso            IN retrasos_vuelo.tipo_retraso%TYPE,
        p_causa                   IN retrasos_vuelo.causa%TYPE,
        p_responsable             IN retrasos_vuelo.responsable%TYPE,
        p_compensacion_pasajeros  IN retrasos_vuelo.compensacion_pasajeros%TYPE DEFAULT 0
    );

    PROCEDURE get_retraso(
        p_id_retraso IN retrasos_vuelo.id_retraso%TYPE
    );

    PROCEDURE update_retraso(
        p_id_retraso              IN retrasos_vuelo.id_retraso%TYPE,
        p_id_vuelo                IN retrasos_vuelo.id_vuelo%TYPE,
        p_minutos_retraso         IN retrasos_vuelo.minutos_retraso%TYPE,
        p_tipo_retraso            IN retrasos_vuelo.tipo_retraso%TYPE,
        p_causa                   IN retrasos_vuelo.causa%TYPE,
        p_responsable             IN retrasos_vuelo.responsable%TYPE,
        p_compensacion_pasajeros  IN retrasos_vuelo.compensacion_pasajeros%TYPE
    );

    PROCEDURE delete_retraso(
        p_id_retraso IN retrasos_vuelo.id_retraso%TYPE
    );
END pkg_retrasos_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_retrasos_vuelo AS

    PROCEDURE insert_retraso(
        p_id_vuelo                IN retrasos_vuelo.id_vuelo%TYPE,
        p_minutos_retraso         IN retrasos_vuelo.minutos_retraso%TYPE,
        p_tipo_retraso            IN retrasos_vuelo.tipo_retraso%TYPE,
        p_causa                   IN retrasos_vuelo.causa%TYPE,
        p_responsable             IN retrasos_vuelo.responsable%TYPE,
        p_compensacion_pasajeros  IN retrasos_vuelo.compensacion_pasajeros%TYPE
    ) IS
    BEGIN
        INSERT INTO retrasos_vuelo (
            id_vuelo, minutos_retraso, tipo_retraso,
            causa, responsable, compensacion_pasajeros
        ) VALUES (
            p_id_vuelo, p_minutos_retraso, p_tipo_retraso,
            p_causa, p_responsable, NVL(p_compensacion_pasajeros,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20801, 'Error al insertar retraso: ' || SQLERRM);
    END insert_retraso;

    PROCEDURE get_retraso(
        p_id_retraso IN retrasos_vuelo.id_retraso%TYPE
    ) IS
        r retrasos_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM retrasos_vuelo
        WHERE id_retraso = p_id_retraso;

        DBMS_OUTPUT.PUT_LINE('ID Retraso: ' || r.id_retraso);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Minutos retraso: ' || r.minutos_retraso);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_retraso);
        DBMS_OUTPUT.PUT_LINE('Causa: ' || r.causa);
        DBMS_OUTPUT.PUT_LINE('Responsable: ' || r.responsable);
        DBMS_OUTPUT.PUT_LINE('Compensación pasajeros: ' || r.compensacion_pasajeros);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Retraso no encontrado.');
    END get_retraso;

    PROCEDURE update_retraso(
        p_id_retraso              IN retrasos_vuelo.id_retraso%TYPE,
        p_id_vuelo                IN retrasos_vuelo.id_vuelo%TYPE,
        p_minutos_retraso         IN retrasos_vuelo.minutos_retraso%TYPE,
        p_tipo_retraso            IN retrasos_vuelo.tipo_retraso%TYPE,
        p_causa                   IN retrasos_vuelo.causa%TYPE,
        p_responsable             IN retrasos_vuelo.responsable%TYPE,
        p_compensacion_pasajeros  IN retrasos_vuelo.compensacion_pasajeros%TYPE
    ) IS
    BEGIN
        UPDATE retrasos_vuelo
        SET id_vuelo               = p_id_vuelo,
            minutos_retraso        = p_minutos_retraso,
            tipo_retraso           = p_tipo_retraso,
            causa                  = p_causa,
            responsable            = p_responsable,
            compensacion_pasajeros = p_compensacion_pasajeros
        WHERE id_retraso = p_id_retraso;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20802, 'No se encontró el retraso para actualizar.');
        END IF;
    END update_retraso;

    PROCEDURE delete_retraso(
        p_id_retraso IN retrasos_vuelo.id_retraso%TYPE
    ) IS
    BEGIN
        DELETE FROM retrasos_vuelo
        WHERE id_retraso = p_id_retraso;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20803, 'No se encontró el retraso para eliminar.');
        END IF;
    END delete_retraso;

END pkg_retrasos_vuelo;
/