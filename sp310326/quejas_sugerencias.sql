------------------------------------------------------------
-- Paquete CRUD para la tabla QUEJAS_SUGERENCIAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_quejas_sugerencias AS
    PROCEDURE insert_queja(
        p_id_pasajero        IN NUMBER,
        p_id_vuelo           IN NUMBER,
        p_tipo_contacto      IN VARCHAR2,
        p_fecha_contacto     IN TIMESTAMP,
        p_medio_recepcion    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_area_relacionada   IN VARCHAR2,
        p_estado             IN VARCHAR2 DEFAULT 'RECIBIDO',
        p_fecha_respuesta    IN TIMESTAMP,
        p_respuesta          IN VARCHAR2,
        p_satisfaccion       IN NUMBER
    );

    PROCEDURE get_queja(
        p_id_queja IN NUMBER
    );

    PROCEDURE update_queja(
        p_id_queja           IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_id_vuelo           IN NUMBER,
        p_tipo_contacto      IN VARCHAR2,
        p_fecha_contacto     IN TIMESTAMP,
        p_medio_recepcion    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_area_relacionada   IN VARCHAR2,
        p_estado             IN VARCHAR2,
        p_fecha_respuesta    IN TIMESTAMP,
        p_respuesta          IN VARCHAR2,
        p_satisfaccion       IN NUMBER
    );

    PROCEDURE delete_queja(
        p_id_queja IN NUMBER
    );
END pkg_quejas_sugerencias;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_quejas_sugerencias AS

    PROCEDURE insert_queja(
        p_id_pasajero        IN NUMBER,
        p_id_vuelo           IN NUMBER,
        p_tipo_contacto      IN VARCHAR2,
        p_fecha_contacto     IN TIMESTAMP,
        p_medio_recepcion    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_area_relacionada   IN VARCHAR2,
        p_estado             IN VARCHAR2,
        p_fecha_respuesta    IN TIMESTAMP,
        p_respuesta          IN VARCHAR2,
        p_satisfaccion       IN NUMBER
    ) IS
    BEGIN
        INSERT INTO quejas_sugerencias (
            id_pasajero, id_vuelo, tipo_contacto, fecha_contacto,
            medio_recepcion, descripcion, area_relacionada,
            estado, fecha_respuesta, respuesta, satisfaccion_respuesta
        ) VALUES (
            p_id_pasajero, p_id_vuelo, p_tipo_contacto, p_fecha_contacto,
            p_medio_recepcion, p_descripcion, p_area_relacionada,
            NVL(p_estado,'RECIBIDO'), p_fecha_respuesta, p_respuesta, p_satisfaccion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25901, 'Error al insertar queja/sugerencia: ' || SQLERRM);
    END insert_queja;

    PROCEDURE get_queja(
        p_id_queja IN NUMBER
    ) IS
        r quejas_sugerencias%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM quejas_sugerencias
        WHERE id_queja = p_id_queja;

        DBMS_OUTPUT.PUT_LINE('ID Queja: ' || r.id_queja);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Tipo contacto: ' || r.tipo_contacto);
        DBMS_OUTPUT.PUT_LINE('Fecha contacto: ' || r.fecha_contacto);
        DBMS_OUTPUT.PUT_LINE('Medio recepción: ' || r.medio_recepcion);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Área relacionada: ' || r.area_relacionada);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Fecha respuesta: ' || r.fecha_respuesta);
        DBMS_OUTPUT.PUT_LINE('Respuesta: ' || r.respuesta);
        DBMS_OUTPUT.PUT_LINE('Satisfacción: ' || r.satisfaccion_respuesta);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Queja/Sugerencia no encontrada.');
    END get_queja;

    PROCEDURE update_queja(
        p_id_queja           IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_id_vuelo           IN NUMBER,
        p_tipo_contacto      IN VARCHAR2,
        p_fecha_contacto     IN TIMESTAMP,
        p_medio_recepcion    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_area_relacionada   IN VARCHAR2,
        p_estado             IN VARCHAR2,
        p_fecha_respuesta    IN TIMESTAMP,
        p_respuesta          IN VARCHAR2,
        p_satisfaccion       IN NUMBER
    ) IS
    BEGIN
        UPDATE quejas_sugerencias
        SET id_pasajero        = p_id_pasajero,
            id_vuelo           = p_id_vuelo,
            tipo_contacto      = p_tipo_contacto,
            fecha_contacto     = p_fecha_contacto,
            medio_recepcion    = p_medio_recepcion,
            descripcion        = p_descripcion,
            area_relacionada   = p_area_relacionada,
            estado             = p_estado,
            fecha_respuesta    = p_fecha_respuesta,
            respuesta          = p_respuesta,
            satisfaccion_respuesta = p_satisfaccion
        WHERE id_queja = p_id_queja;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25902, 'No se encontró la queja/sugerencia para actualizar.');
        END IF;
    END update_queja;

    PROCEDURE delete_queja(
        p_id_queja IN NUMBER
    ) IS
    BEGIN
        DELETE FROM quejas_sugerencias
        WHERE id_queja = p_id_queja;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25903, 'No se encontró la queja/sugerencia para eliminar.');
        END IF;
    END delete_queja;

END pkg_quejas_sugerencias;
/