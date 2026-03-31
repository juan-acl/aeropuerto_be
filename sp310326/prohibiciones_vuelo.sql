------------------------------------------------------------
-- Paquete CRUD para la tabla PROHIBICIONES_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_prohibiciones_vuelo AS
    PROCEDURE insert_prohibicion(
        p_id_pasajero       IN NUMBER,
        p_fecha_prohibicion IN DATE,
        p_fecha_inicio      IN DATE,
        p_fecha_fin         IN DATE,
        p_motivo            IN VARCHAR2,
        p_id_incidente      IN NUMBER,
        p_autoridad_emite   IN VARCHAR2,
        p_activa            IN NUMBER DEFAULT 1
    );

    PROCEDURE get_prohibicion(
        p_id_prohibicion IN NUMBER
    );

    PROCEDURE update_prohibicion(
        p_id_prohibicion    IN NUMBER,
        p_id_pasajero       IN NUMBER,
        p_fecha_prohibicion IN DATE,
        p_fecha_inicio      IN DATE,
        p_fecha_fin         IN DATE,
        p_motivo            IN VARCHAR2,
        p_id_incidente      IN NUMBER,
        p_autoridad_emite   IN VARCHAR2,
        p_activa            IN NUMBER
    );

    PROCEDURE delete_prohibicion(
        p_id_prohibicion IN NUMBER
    );
END pkg_prohibiciones_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_prohibiciones_vuelo AS

    PROCEDURE insert_prohibicion(
        p_id_pasajero       IN NUMBER,
        p_fecha_prohibicion IN DATE,
        p_fecha_inicio      IN DATE,
        p_fecha_fin         IN DATE,
        p_motivo            IN VARCHAR2,
        p_id_incidente      IN NUMBER,
        p_autoridad_emite   IN VARCHAR2,
        p_activa            IN NUMBER
    ) IS
    BEGIN
        INSERT INTO prohibiciones_vuelo (
            id_pasajero, fecha_prohibicion, fecha_inicio, fecha_fin,
            motivo, id_incidente, autoridad_emite, activa
        ) VALUES (
            p_id_pasajero, p_fecha_prohibicion, p_fecha_inicio, p_fecha_fin,
            p_motivo, p_id_incidente, p_autoridad_emite, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23801, 'Error al insertar prohibición de vuelo: ' || SQLERRM);
    END insert_prohibicion;

    PROCEDURE get_prohibicion(
        p_id_prohibicion IN NUMBER
    ) IS
        r prohibiciones_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM prohibiciones_vuelo
        WHERE id_prohibicion = p_id_prohibicion;

        DBMS_OUTPUT.PUT_LINE('ID Prohibición: ' || r.id_prohibicion);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Fecha prohibición: ' || r.fecha_prohibicion);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Motivo: ' || r.motivo);
        DBMS_OUTPUT.PUT_LINE('Incidente: ' || r.id_incidente);
        DBMS_OUTPUT.PUT_LINE('Autoridad emite: ' || r.autoridad_emite);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Prohibición de vuelo no encontrada.');
    END get_prohibicion;

    PROCEDURE update_prohibicion(
        p_id_prohibicion    IN NUMBER,
        p_id_pasajero       IN NUMBER,
        p_fecha_prohibicion IN DATE,
        p_fecha_inicio      IN DATE,
        p_fecha_fin         IN DATE,
        p_motivo            IN VARCHAR2,
        p_id_incidente      IN NUMBER,
        p_autoridad_emite   IN VARCHAR2,
        p_activa            IN NUMBER
    ) IS
    BEGIN
        UPDATE prohibiciones_vuelo
        SET id_pasajero       = p_id_pasajero,
            fecha_prohibicion = p_fecha_prohibicion,
            fecha_inicio      = p_fecha_inicio,
            fecha_fin         = p_fecha_fin,
            motivo            = p_motivo,
            id_incidente      = p_id_incidente,
            autoridad_emite   = p_autoridad_emite,
            activa            = p_activa
        WHERE id_prohibicion = p_id_prohibicion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23802, 'No se encontró la prohibición de vuelo para actualizar.');
        END IF;
    END update_prohibicion;

    PROCEDURE delete_prohibicion(
        p_id_prohibicion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM prohibiciones_vuelo
        WHERE id_prohibicion = p_id_prohibicion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23803, 'No se encontró la prohibición de vuelo para eliminar.');
        END IF;
    END delete_prohibicion;

END pkg_prohibiciones_vuelo;
/