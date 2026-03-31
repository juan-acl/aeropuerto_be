------------------------------------------------------------
-- Paquete CRUD para la tabla ATENCION_ESPECIAL
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_atencion_especial AS
    PROCEDURE insert_atencion(
        p_id_pasajero        IN NUMBER,
        p_id_reserva         IN NUMBER,
        p_tipo_atencion      IN VARCHAR2,
        p_fecha_solicitud    IN TIMESTAMP,
        p_fecha_atencion     IN TIMESTAMP,
        p_asistente_asignado IN VARCHAR2,
        p_observaciones      IN VARCHAR2
    );

    PROCEDURE get_atencion(
        p_id_atencion IN NUMBER
    );

    PROCEDURE update_atencion(
        p_id_atencion        IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_id_reserva         IN NUMBER,
        p_tipo_atencion      IN VARCHAR2,
        p_fecha_solicitud    IN TIMESTAMP,
        p_fecha_atencion     IN TIMESTAMP,
        p_asistente_asignado IN VARCHAR2,
        p_observaciones      IN VARCHAR2
    );

    PROCEDURE delete_atencion(
        p_id_atencion IN NUMBER
    );
END pkg_atencion_especial;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_atencion_especial AS

    PROCEDURE insert_atencion(
        p_id_pasajero        IN NUMBER,
        p_id_reserva         IN NUMBER,
        p_tipo_atencion      IN VARCHAR2,
        p_fecha_solicitud    IN TIMESTAMP,
        p_fecha_atencion     IN TIMESTAMP,
        p_asistente_asignado IN VARCHAR2,
        p_observaciones      IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO atencion_especial (
            id_pasajero, id_reserva, tipo_atencion,
            fecha_solicitud, fecha_atencion, asistente_asignado, observaciones
        ) VALUES (
            p_id_pasajero, p_id_reserva, p_tipo_atencion,
            p_fecha_solicitud, p_fecha_atencion, p_asistente_asignado, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26201, 'Error al insertar atención especial: ' || SQLERRM);
    END insert_atencion;

    PROCEDURE get_atencion(
        p_id_atencion IN NUMBER
    ) IS
        r atencion_especial%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM atencion_especial
        WHERE id_atencion = p_id_atencion;

        DBMS_OUTPUT.PUT_LINE('ID Atención: ' || r.id_atencion);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Tipo atención: ' || r.tipo_atencion);
        DBMS_OUTPUT.PUT_LINE('Fecha solicitud: ' || r.fecha_solicitud);
        DBMS_OUTPUT.PUT_LINE('Fecha atención: ' || r.fecha_atencion);
        DBMS_OUTPUT.PUT_LINE('Asistente asignado: ' || r.asistente_asignado);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Atención especial no encontrada.');
    END get_atencion;

    PROCEDURE update_atencion(
        p_id_atencion        IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_id_reserva         IN NUMBER,
        p_tipo_atencion      IN VARCHAR2,
        p_fecha_solicitud    IN TIMESTAMP,
        p_fecha_atencion     IN TIMESTAMP,
        p_asistente_asignado IN VARCHAR2,
        p_observaciones      IN VARCHAR2
    ) IS
    BEGIN
        UPDATE atencion_especial
        SET id_pasajero        = p_id_pasajero,
            id_reserva         = p_id_reserva,
            tipo_atencion      = p_tipo_atencion,
            fecha_solicitud    = p_fecha_solicitud,
            fecha_atencion     = p_fecha_atencion,
            asistente_asignado = p_asistente_asignado,
            observaciones      = p_observaciones
        WHERE id_atencion = p_id_atencion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26202, 'No se encontró la atención especial para actualizar.');
        END IF;
    END update_atencion;

    PROCEDURE delete_atencion(
        p_id_atencion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM atencion_especial
        WHERE id_atencion = p_id_atencion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26203, 'No se encontró la atención especial para eliminar.');
        END IF;
    END delete_atencion;

END pkg_atencion_especial;
/