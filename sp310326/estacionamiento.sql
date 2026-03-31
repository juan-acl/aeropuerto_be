------------------------------------------------------------
-- Paquete CRUD para la tabla ESTACIONAMIENTO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_estacionamiento AS
    PROCEDURE insert_estacionamiento(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_numero_espacio      IN VARCHAR2,
        p_tipo_espacio        IN VARCHAR2,
        p_terminal_cercana    IN VARCHAR2,
        p_tarifa_por_hora     IN NUMBER,
        p_tarifa_diaria       IN NUMBER,
        p_disponible          IN NUMBER DEFAULT 1,
        p_observaciones       IN VARCHAR2
    );

    PROCEDURE get_estacionamiento(
        p_id_estacionamiento IN NUMBER
    );

    PROCEDURE update_estacionamiento(
        p_id_estacionamiento IN NUMBER,
        p_codigo_aeropuerto  IN VARCHAR2,
        p_numero_espacio     IN VARCHAR2,
        p_tipo_espacio       IN VARCHAR2,
        p_terminal_cercana   IN VARCHAR2,
        p_tarifa_por_hora    IN NUMBER,
        p_tarifa_diaria      IN NUMBER,
        p_disponible         IN NUMBER,
        p_observaciones      IN VARCHAR2
    );

    PROCEDURE delete_estacionamiento(
        p_id_estacionamiento IN NUMBER
    );
END pkg_estacionamiento;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_estacionamiento AS

    PROCEDURE insert_estacionamiento(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_numero_espacio      IN VARCHAR2,
        p_tipo_espacio        IN VARCHAR2,
        p_terminal_cercana    IN VARCHAR2,
        p_tarifa_por_hora     IN NUMBER,
        p_tarifa_diaria       IN NUMBER,
        p_disponible          IN NUMBER,
        p_observaciones       IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO estacionamiento (
            codigo_aeropuerto, numero_espacio, tipo_espacio,
            terminal_cercana, tarifa_por_hora, tarifa_diaria,
            disponible, observaciones
        ) VALUES (
            p_codigo_aeropuerto, p_numero_espacio, p_tipo_espacio,
            p_terminal_cercana, p_tarifa_por_hora, p_tarifa_diaria,
            NVL(p_disponible,1), p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25401, 'Error al insertar espacio de estacionamiento: ' || SQLERRM);
    END insert_estacionamiento;

    PROCEDURE get_estacionamiento(
        p_id_estacionamiento IN NUMBER
    ) IS
        r estacionamiento%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM estacionamiento
        WHERE id_estacionamiento = p_id_estacionamiento;

        DBMS_OUTPUT.PUT_LINE('ID Estacionamiento: ' || r.id_estacionamiento);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Número espacio: ' || r.numero_espacio);
        DBMS_OUTPUT.PUT_LINE('Tipo espacio: ' || r.tipo_espacio);
        DBMS_OUTPUT.PUT_LINE('Terminal cercana: ' || r.terminal_cercana);
        DBMS_OUTPUT.PUT_LINE('Tarifa por hora: ' || r.tarifa_por_hora);
        DBMS_OUTPUT.PUT_LINE('Tarifa diaria: ' || r.tarifa_diaria);
        DBMS_OUTPUT.PUT_LINE('Disponible: ' || r.disponible);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Espacio de estacionamiento no encontrado.');
    END get_estacionamiento;

    PROCEDURE update_estacionamiento(
        p_id_estacionamiento IN NUMBER,
        p_codigo_aeropuerto  IN VARCHAR2,
        p_numero_espacio     IN VARCHAR2,
        p_tipo_espacio       IN VARCHAR2,
        p_terminal_cercana   IN VARCHAR2,
        p_tarifa_por_hora    IN NUMBER,
        p_tarifa_diaria      IN NUMBER,
        p_disponible         IN NUMBER,
        p_observaciones      IN VARCHAR2
    ) IS
    BEGIN
        UPDATE estacionamiento
        SET codigo_aeropuerto = p_codigo_aeropuerto,
            numero_espacio    = p_numero_espacio,
            tipo_espacio      = p_tipo_espacio,
            terminal_cercana  = p_terminal_cercana,
            tarifa_por_hora   = p_tarifa_por_hora,
            tarifa_diaria     = p_tarifa_diaria,
            disponible        = p_disponible,
            observaciones     = p_observaciones
        WHERE id_estacionamiento = p_id_estacionamiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25402, 'No se encontró el espacio de estacionamiento para actualizar.');
        END IF;
    END update_estacionamiento;

    PROCEDURE delete_estacionamiento(
        p_id_estacionamiento IN NUMBER
    ) IS
    BEGIN
        DELETE FROM estacionamiento
        WHERE id_estacionamiento = p_id_estacionamiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25403, 'No se encontró el espacio de estacionamiento para eliminar.');
        END IF;
    END delete_estacionamiento;

END pkg_estacionamiento;
/