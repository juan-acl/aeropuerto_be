------------------------------------------------------------
-- Paquete CRUD para la tabla CANCELACIONES_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_cancelaciones_vuelo AS
    PROCEDURE insert_cancelacion(
        p_id_vuelo              IN cancelaciones_vuelo.id_vuelo%TYPE,
        p_fecha_cancelacion     IN cancelaciones_vuelo.fecha_cancelacion%TYPE,
        p_motivo_principal      IN cancelaciones_vuelo.motivo_principal%TYPE,
        p_motivo_detallado      IN cancelaciones_vuelo.motivo_detallado%TYPE,
        p_notificado_a_pasajeros IN cancelaciones_vuelo.notificado_a_pasajeros%TYPE DEFAULT 0,
        p_fecha_notificacion    IN cancelaciones_vuelo.fecha_notificacion%TYPE,
        p_pasajeros_reubicados  IN cancelaciones_vuelo.pasajeros_reubicados%TYPE,
        p_costo_compensacion    IN cancelaciones_vuelo.costo_compensacion%TYPE
    );

    PROCEDURE get_cancelacion(
        p_id_cancelacion IN cancelaciones_vuelo.id_cancelacion%TYPE
    );

    PROCEDURE update_cancelacion(
        p_id_cancelacion        IN cancelaciones_vuelo.id_cancelacion%TYPE,
        p_id_vuelo              IN cancelaciones_vuelo.id_vuelo%TYPE,
        p_fecha_cancelacion     IN cancelaciones_vuelo.fecha_cancelacion%TYPE,
        p_motivo_principal      IN cancelaciones_vuelo.motivo_principal%TYPE,
        p_motivo_detallado      IN cancelaciones_vuelo.motivo_detallado%TYPE,
        p_notificado_a_pasajeros IN cancelaciones_vuelo.notificado_a_pasajeros%TYPE,
        p_fecha_notificacion    IN cancelaciones_vuelo.fecha_notificacion%TYPE,
        p_pasajeros_reubicados  IN cancelaciones_vuelo.pasajeros_reubicados%TYPE,
        p_costo_compensacion    IN cancelaciones_vuelo.costo_compensacion%TYPE
    );

    PROCEDURE delete_cancelacion(
        p_id_cancelacion IN cancelaciones_vuelo.id_cancelacion%TYPE
    );
END pkg_cancelaciones_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_cancelaciones_vuelo AS

    PROCEDURE insert_cancelacion(
        p_id_vuelo              IN cancelaciones_vuelo.id_vuelo%TYPE,
        p_fecha_cancelacion     IN cancelaciones_vuelo.fecha_cancelacion%TYPE,
        p_motivo_principal      IN cancelaciones_vuelo.motivo_principal%TYPE,
        p_motivo_detallado      IN cancelaciones_vuelo.motivo_detallado%TYPE,
        p_notificado_a_pasajeros IN cancelaciones_vuelo.notificado_a_pasajeros%TYPE,
        p_fecha_notificacion    IN cancelaciones_vuelo.fecha_notificacion%TYPE,
        p_pasajeros_reubicados  IN cancelaciones_vuelo.pasajeros_reubicados%TYPE,
        p_costo_compensacion    IN cancelaciones_vuelo.costo_compensacion%TYPE
    ) IS
    BEGIN
        INSERT INTO cancelaciones_vuelo (
            id_vuelo, fecha_cancelacion, motivo_principal,
            motivo_detallado, notificado_a_pasajeros, fecha_notificacion,
            pasajeros_reubicados, costo_compensacion
        ) VALUES (
            p_id_vuelo, p_fecha_cancelacion, p_motivo_principal,
            p_motivo_detallado, NVL(p_notificado_a_pasajeros,0), p_fecha_notificacion,
            p_pasajeros_reubicados, p_costo_compensacion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20901, 'Error al insertar cancelación: ' || SQLERRM);
    END insert_cancelacion;

    PROCEDURE get_cancelacion(
        p_id_cancelacion IN cancelaciones_vuelo.id_cancelacion%TYPE
    ) IS
        r cancelaciones_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM cancelaciones_vuelo
        WHERE id_cancelacion = p_id_cancelacion;

        DBMS_OUTPUT.PUT_LINE('ID Cancelación: ' || r.id_cancelacion);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Fecha cancelación: ' || r.fecha_cancelacion);
        DBMS_OUTPUT.PUT_LINE('Motivo principal: ' || r.motivo_principal);
        DBMS_OUTPUT.PUT_LINE('Motivo detallado: ' || r.motivo_detallado);
        DBMS_OUTPUT.PUT_LINE('Notificado a pasajeros: ' || r.notificado_a_pasajeros);
        DBMS_OUTPUT.PUT_LINE('Fecha notificación: ' || r.fecha_notificacion);
        DBMS_OUTPUT.PUT_LINE('Pasajeros reubicados: ' || r.pasajeros_reubicados);
        DBMS_OUTPUT.PUT_LINE('Costo compensación: ' || r.costo_compensacion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Cancelación no encontrada.');
    END get_cancelacion;

    PROCEDURE update_cancelacion(
        p_id_cancelacion        IN cancelaciones_vuelo.id_cancelacion%TYPE,
        p_id_vuelo              IN cancelaciones_vuelo.id_vuelo%TYPE,
        p_fecha_cancelacion     IN cancelaciones_vuelo.fecha_cancelacion%TYPE,
        p_motivo_principal      IN cancelaciones_vuelo.motivo_principal%TYPE,
        p_motivo_detallado      IN cancelaciones_vuelo.motivo_detallado%TYPE,
        p_notificado_a_pasajeros IN cancelaciones_vuelo.notificado_a_pasajeros%TYPE,
        p_fecha_notificacion    IN cancelaciones_vuelo.fecha_notificacion%TYPE,
        p_pasajeros_reubicados  IN cancelaciones_vuelo.pasajeros_reubicados%TYPE,
        p_costo_compensacion    IN cancelaciones_vuelo.costo_compensacion%TYPE
    ) IS
    BEGIN
        UPDATE cancelaciones_vuelo
        SET id_vuelo              = p_id_vuelo,
            fecha_cancelacion     = p_fecha_cancelacion,
            motivo_principal      = p_motivo_principal,
            motivo_detallado      = p_motivo_detallado,
            notificado_a_pasajeros = p_notificado_a_pasajeros,
            fecha_notificacion    = p_fecha_notificacion,
            pasajeros_reubicados  = p_pasajeros_reubicados,
            costo_compensacion    = p_costo_compensacion
        WHERE id_cancelacion = p_id_cancelacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20902, 'No se encontró la cancelación para actualizar.');
        END IF;
    END update_cancelacion;

    PROCEDURE delete_cancelacion(
        p_id_cancelacion IN cancelaciones_vuelo.id_cancelacion%TYPE
    ) IS
    BEGIN
        DELETE FROM cancelaciones_vuelo
        WHERE id_cancelacion = p_id_cancelacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20903, 'No se encontró la cancelación para eliminar.');
        END IF;
    END delete_cancelacion;

END pkg_cancelaciones_vuelo;
/