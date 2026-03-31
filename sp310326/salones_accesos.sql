------------------------------------------------------------
-- Paquete CRUD para la tabla SALONES_ACCESOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_salones_accesos AS
    PROCEDURE insert_acceso(
        p_id_salon        IN NUMBER,
        p_id_pasajero     IN NUMBER,
        p_id_vuelo        IN NUMBER,
        p_fecha_acceso    IN DATE,
        p_hora_entrada    IN TIMESTAMP,
        p_hora_salida     IN TIMESTAMP,
        p_tipo_acceso     IN VARCHAR2,
        p_costo           IN NUMBER,
        p_autorizado_por  IN VARCHAR2
    );

    PROCEDURE get_acceso(
        p_id_acceso IN NUMBER
    );

    PROCEDURE update_acceso(
        p_id_acceso       IN NUMBER,
        p_id_salon        IN NUMBER,
        p_id_pasajero     IN NUMBER,
        p_id_vuelo        IN NUMBER,
        p_fecha_acceso    IN DATE,
        p_hora_entrada    IN TIMESTAMP,
        p_hora_salida     IN TIMESTAMP,
        p_tipo_acceso     IN VARCHAR2,
        p_costo           IN NUMBER,
        p_autorizado_por  IN VARCHAR2
    );

    PROCEDURE delete_acceso(
        p_id_acceso IN NUMBER
    );
END pkg_salones_accesos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_salones_accesos AS

    PROCEDURE insert_acceso(
        p_id_salon        IN NUMBER,
        p_id_pasajero     IN NUMBER,
        p_id_vuelo        IN NUMBER,
        p_fecha_acceso    IN DATE,
        p_hora_entrada    IN TIMESTAMP,
        p_hora_salida     IN TIMESTAMP,
        p_tipo_acceso     IN VARCHAR2,
        p_costo           IN NUMBER,
        p_autorizado_por  IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO salones_accesos (
            id_salon, id_pasajero, id_vuelo, fecha_acceso,
            hora_entrada, hora_salida, tipo_acceso,
            costo, autorizado_por
        ) VALUES (
            p_id_salon, p_id_pasajero, p_id_vuelo, p_fecha_acceso,
            p_hora_entrada, p_hora_salida, p_tipo_acceso,
            p_costo, p_autorizado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25301, 'Error al insertar acceso a salón VIP: ' || SQLERRM);
    END insert_acceso;

    PROCEDURE get_acceso(
        p_id_acceso IN NUMBER
    ) IS
        r salones_accesos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM salones_accesos
        WHERE id_acceso = p_id_acceso;

        DBMS_OUTPUT.PUT_LINE('ID Acceso: ' || r.id_acceso);
        DBMS_OUTPUT.PUT_LINE('Salón: ' || r.id_salon);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Fecha acceso: ' || r.fecha_acceso);
        DBMS_OUTPUT.PUT_LINE('Hora entrada: ' || r.hora_entrada);
        DBMS_OUTPUT.PUT_LINE('Hora salida: ' || r.hora_salida);
        DBMS_OUTPUT.PUT_LINE('Tipo acceso: ' || r.tipo_acceso);
        DBMS_OUTPUT.PUT_LINE('Costo: ' || r.costo);
        DBMS_OUTPUT.PUT_LINE('Autorizado por: ' || r.autorizado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Acceso a salón VIP no encontrado.');
    END get_acceso;

    PROCEDURE update_acceso(
        p_id_acceso       IN NUMBER,
        p_id_salon        IN NUMBER,
        p_id_pasajero     IN NUMBER,
        p_id_vuelo        IN NUMBER,
        p_fecha_acceso    IN DATE,
        p_hora_entrada    IN TIMESTAMP,
        p_hora_salida     IN TIMESTAMP,
        p_tipo_acceso     IN VARCHAR2,
        p_costo           IN NUMBER,
        p_autorizado_por  IN VARCHAR2
    ) IS
    BEGIN
        UPDATE salones_accesos
        SET id_salon       = p_id_salon,
            id_pasajero    = p_id_pasajero,
            id_vuelo       = p_id_vuelo,
            fecha_acceso   = p_fecha_acceso,
            hora_entrada   = p_hora_entrada,
            hora_salida    = p_hora_salida,
            tipo_acceso    = p_tipo_acceso,
            costo          = p_costo,
            autorizado_por = p_autorizado_por
        WHERE id_acceso = p_id_acceso;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25302, 'No se encontró el acceso a salón VIP para actualizar.');
        END IF;
    END update_acceso;

    PROCEDURE delete_acceso(
        p_id_acceso IN NUMBER
    ) IS
    BEGIN
        DELETE FROM salones_accesos
        WHERE id_acceso = p_id_acceso;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25303, 'No se encontró el acceso a salón VIP para eliminar.');
        END IF;
    END delete_acceso;

END pkg_salones_accesos;
/