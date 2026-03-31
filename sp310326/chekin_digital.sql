------------------------------------------------------------
-- Paquete CRUD para la tabla CHECKIN_DIGITAL
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_checkin_digital AS
    PROCEDURE insert_checkin(
        p_id_reserva            IN checkin_digital.id_reserva%TYPE,
        p_fecha_checkin         IN checkin_digital.fecha_checkin%TYPE,
        p_ip_origen             IN checkin_digital.ip_origen%TYPE,
        p_dispositivo           IN checkin_digital.dispositivo%TYPE,
        p_pase_abordaje_generado IN checkin_digital.pase_abordaje_generado%TYPE DEFAULT 1,
        p_codigo_qr             IN checkin_digital.codigo_qr%TYPE,
        p_enviado_email         IN checkin_digital.enviado_email%TYPE DEFAULT 0,
        p_enviado_sms           IN checkin_digital.enviado_sms%TYPE DEFAULT 0
    );

    PROCEDURE get_checkin(
        p_id_checkin IN checkin_digital.id_checkin%TYPE
    );

    PROCEDURE update_checkin(
        p_id_checkin            IN checkin_digital.id_checkin%TYPE,
        p_id_reserva            IN checkin_digital.id_reserva%TYPE,
        p_fecha_checkin         IN checkin_digital.fecha_checkin%TYPE,
        p_ip_origen             IN checkin_digital.ip_origen%TYPE,
        p_dispositivo           IN checkin_digital.dispositivo%TYPE,
        p_pase_abordaje_generado IN checkin_digital.pase_abordaje_generado%TYPE,
        p_codigo_qr             IN checkin_digital.codigo_qr%TYPE,
        p_enviado_email         IN checkin_digital.enviado_email%TYPE,
        p_enviado_sms           IN checkin_digital.enviado_sms%TYPE
    );

    PROCEDURE delete_checkin(
        p_id_checkin IN checkin_digital.id_checkin%TYPE
    );
END pkg_checkin_digital;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_checkin_digital AS

    PROCEDURE insert_checkin(
        p_id_reserva            IN checkin_digital.id_reserva%TYPE,
        p_fecha_checkin         IN checkin_digital.fecha_checkin%TYPE,
        p_ip_origen             IN checkin_digital.ip_origen%TYPE,
        p_dispositivo           IN checkin_digital.dispositivo%TYPE,
        p_pase_abordaje_generado IN checkin_digital.pase_abordaje_generado%TYPE,
        p_codigo_qr             IN checkin_digital.codigo_qr%TYPE,
        p_enviado_email         IN checkin_digital.enviado_email%TYPE,
        p_enviado_sms           IN checkin_digital.enviado_sms%TYPE
    ) IS
    BEGIN
        INSERT INTO checkin_digital (
            id_reserva, fecha_checkin, ip_origen, dispositivo,
            pase_abordaje_generado, codigo_qr,
            enviado_email, enviado_sms
        ) VALUES (
            p_id_reserva, p_fecha_checkin, p_ip_origen, p_dispositivo,
            NVL(p_pase_abordaje_generado,1), p_codigo_qr,
            NVL(p_enviado_email,0), NVL(p_enviado_sms,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22901, 'Error al insertar check-in digital: ' || SQLERRM);
    END insert_checkin;

    PROCEDURE get_checkin(
        p_id_checkin IN checkin_digital.id_checkin%TYPE
    ) IS
        r checkin_digital%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM checkin_digital
        WHERE id_checkin = p_id_checkin;

        DBMS_OUTPUT.PUT_LINE('ID Check-in: ' || r.id_checkin);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Fecha check-in: ' || r.fecha_checkin);
        DBMS_OUTPUT.PUT_LINE('IP origen: ' || r.ip_origen);
        DBMS_OUTPUT.PUT_LINE('Dispositivo: ' || r.dispositivo);
        DBMS_OUTPUT.PUT_LINE('Pase abordaje generado: ' || r.pase_abordaje_generado);
        DBMS_OUTPUT.PUT_LINE('Enviado email: ' || r.enviado_email);
        DBMS_OUTPUT.PUT_LINE('Enviado SMS: ' || r.enviado_sms);
        DBMS_OUTPUT.PUT_LINE('Código QR: (BLOB)');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Check-in digital no encontrado.');
    END get_checkin;

    PROCEDURE update_checkin(
        p_id_checkin            IN checkin_digital.id_checkin%TYPE,
        p_id_reserva            IN checkin_digital.id_reserva%TYPE,
        p_fecha_checkin         IN checkin_digital.fecha_checkin%TYPE,
        p_ip_origen             IN checkin_digital.ip_origen%TYPE,
        p_dispositivo           IN checkin_digital.dispositivo%TYPE,
        p_pase_abordaje_generado IN checkin_digital.pase_abordaje_generado%TYPE,
        p_codigo_qr             IN checkin_digital.codigo_qr%TYPE,
        p_enviado_email         IN checkin_digital.enviado_email%TYPE,
        p_enviado_sms           IN checkin_digital.enviado_sms%TYPE
    ) IS
    BEGIN
        UPDATE checkin_digital
        SET id_reserva            = p_id_reserva,
            fecha_checkin         = p_fecha_checkin,
            ip_origen             = p_ip_origen,
            dispositivo           = p_dispositivo,
            pase_abordaje_generado = p_pase_abordaje_generado,
            codigo_qr             = p_codigo_qr,
            enviado_email         = p_enviado_email,
            enviado_sms           = p_enviado_sms
        WHERE id_checkin = p_id_checkin;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22902, 'No se encontró el check-in digital para actualizar.');
        END IF;
    END update_checkin;

    PROCEDURE delete_checkin(
        p_id_checkin IN checkin_digital.id_checkin%TYPE
    ) IS
    BEGIN
        DELETE FROM checkin_digital
        WHERE id_checkin = p_id_checkin;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22903, 'No se encontró el check-in digital para eliminar.');
        END IF;
    END delete_checkin;

END pkg_checkin_digital;
/