------------------------------------------------------------
-- Paquete CRUD para la tabla SOLICITUDES_ESPECIALES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_solicitudes_especiales AS
    PROCEDURE insert_solicitud(
        p_id_reserva       IN solicitudes_especiales.id_reserva%TYPE,
        p_tipo_solicitud   IN solicitudes_especiales.tipo_solicitud%TYPE,
        p_descripcion      IN solicitudes_especiales.descripcion%TYPE,
        p_fecha_solicitud  IN solicitudes_especiales.fecha_solicitud%TYPE,
        p_estado_solicitud IN solicitudes_especiales.estado_solicitud%TYPE DEFAULT 'PENDIENTE',
        p_fecha_resolucion IN solicitudes_especiales.fecha_resolucion%TYPE,
        p_resolucion       IN solicitudes_especiales.resolucion%TYPE
    );

    PROCEDURE get_solicitud(
        p_id_solicitud IN solicitudes_especiales.id_solicitud%TYPE
    );

    PROCEDURE update_solicitud(
        p_id_solicitud    IN solicitudes_especiales.id_solicitud%TYPE,
        p_id_reserva      IN solicitudes_especiales.id_reserva%TYPE,
        p_tipo_solicitud  IN solicitudes_especiales.tipo_solicitud%TYPE,
        p_descripcion     IN solicitudes_especiales.descripcion%TYPE,
        p_fecha_solicitud IN solicitudes_especiales.fecha_solicitud%TYPE,
        p_estado_solicitud IN solicitudes_especiales.estado_solicitud%TYPE,
        p_fecha_resolucion IN solicitudes_especiales.fecha_resolucion%TYPE,
        p_resolucion      IN solicitudes_especiales.resolucion%TYPE
    );

    PROCEDURE delete_solicitud(
        p_id_solicitud IN solicitudes_especiales.id_solicitud%TYPE
    );
END pkg_solicitudes_especiales;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_solicitudes_especiales AS

    PROCEDURE insert_solicitud(
        p_id_reserva       IN solicitudes_especiales.id_reserva%TYPE,
        p_tipo_solicitud   IN solicitudes_especiales.tipo_solicitud%TYPE,
        p_descripcion      IN solicitudes_especiales.descripcion%TYPE,
        p_fecha_solicitud  IN solicitudes_especiales.fecha_solicitud%TYPE,
        p_estado_solicitud IN solicitudes_especiales.estado_solicitud%TYPE,
        p_fecha_resolucion IN solicitudes_especiales.fecha_resolucion%TYPE,
        p_resolucion       IN solicitudes_especiales.resolucion%TYPE
    ) IS
    BEGIN
        INSERT INTO solicitudes_especiales (
            id_reserva, tipo_solicitud, descripcion,
            fecha_solicitud, estado_solicitud,
            fecha_resolucion, resolucion
        ) VALUES (
            p_id_reserva, p_tipo_solicitud, p_descripcion,
            p_fecha_solicitud, NVL(p_estado_solicitud,'PENDIENTE'),
            p_fecha_resolucion, p_resolucion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22701, 'Error al insertar solicitud especial: ' || SQLERRM);
    END insert_solicitud;

    PROCEDURE get_solicitud(
        p_id_solicitud IN solicitudes_especiales.id_solicitud%TYPE
    ) IS
        r solicitudes_especiales%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM solicitudes_especiales
        WHERE id_solicitud = p_id_solicitud;

        DBMS_OUTPUT.PUT_LINE('ID Solicitud: ' || r.id_solicitud);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Tipo solicitud: ' || r.tipo_solicitud);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Fecha solicitud: ' || r.fecha_solicitud);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado_solicitud);
        DBMS_OUTPUT.PUT_LINE('Fecha resolución: ' || r.fecha_resolucion);
        DBMS_OUTPUT.PUT_LINE('Resolución: ' || r.resolucion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Solicitud especial no encontrada.');
    END get_solicitud;

    PROCEDURE update_solicitud(
        p_id_solicitud    IN solicitudes_especiales.id_solicitud%TYPE,
        p_id_reserva      IN solicitudes_especiales.id_reserva%TYPE,
        p_tipo_solicitud  IN solicitudes_especiales.tipo_solicitud%TYPE,
        p_descripcion     IN solicitudes_especiales.descripcion%TYPE,
        p_fecha_solicitud IN solicitudes_especiales.fecha_solicitud%TYPE,
        p_estado_solicitud IN solicitudes_especiales.estado_solicitud%TYPE,
        p_fecha_resolucion IN solicitudes_especiales.fecha_resolucion%TYPE,
        p_resolucion      IN solicitudes_especiales.resolucion%TYPE
    ) IS
    BEGIN
        UPDATE solicitudes_especiales
        SET id_reserva      = p_id_reserva,
            tipo_solicitud  = p_tipo_solicitud,
            descripcion     = p_descripcion,
            fecha_solicitud = p_fecha_solicitud,
            estado_solicitud = p_estado_solicitud,
            fecha_resolucion = p_fecha_resolucion,
            resolucion      = p_resolucion
        WHERE id_solicitud = p_id_solicitud;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22702, 'No se encontró la solicitud especial para actualizar.');
        END IF;
    END update_solicitud;

    PROCEDURE delete_solicitud(
        p_id_solicitud IN solicitudes_especiales.id_solicitud%TYPE
    ) IS
    BEGIN
        DELETE FROM solicitudes_especiales
        WHERE id_solicitud = p_id_solicitud;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22703, 'No se encontró la solicitud especial para eliminar.');
        END IF;
    END delete_solicitud;

END pkg_solicitudes_especiales;
/