------------------------------------------------------------
-- Paquete CRUD para la tabla PASES_ABORDAJE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pases_abordaje AS
    PROCEDURE insert_pase(
        p_id_reserva       IN pases_abordaje.id_reserva%TYPE,
        p_codigo_barras    IN pases_abordaje.codigo_barras%TYPE,
        p_qr_code          IN pases_abordaje.qr_code%TYPE,
        p_fecha_generacion IN pases_abordaje.fecha_generacion%TYPE,
        p_fecha_escaneo    IN pases_abordaje.fecha_escaneo%TYPE,
        p_puerta_embarque  IN pases_abordaje.puerta_embarque%TYPE,
        p_grupo_embarque   IN pases_abordaje.grupo_embarque%TYPE,
        p_asiento          IN pases_abordaje.asiento%TYPE,
        p_utilizado        IN pases_abordaje.utilizado%TYPE DEFAULT 0
    );

    PROCEDURE get_pase(
        p_id_pase_abordaje IN pases_abordaje.id_pase_abordaje%TYPE
    );

    PROCEDURE update_pase(
        p_id_pase_abordaje IN pases_abordaje.id_pase_abordaje%TYPE,
        p_id_reserva       IN pases_abordaje.id_reserva%TYPE,
        p_codigo_barras    IN pases_abordaje.codigo_barras%TYPE,
        p_qr_code          IN pases_abordaje.qr_code%TYPE,
        p_fecha_generacion IN pases_abordaje.fecha_generacion%TYPE,
        p_fecha_escaneo    IN pases_abordaje.fecha_escaneo%TYPE,
        p_puerta_embarque  IN pases_abordaje.puerta_embarque%TYPE,
        p_grupo_embarque   IN pases_abordaje.grupo_embarque%TYPE,
        p_asiento          IN pases_abordaje.asiento%TYPE,
        p_utilizado        IN pases_abordaje.utilizado%TYPE
    );

    PROCEDURE delete_pase(
        p_id_pase_abordaje IN pases_abordaje.id_pase_abordaje%TYPE
    );
END pkg_pases_abordaje;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pases_abordaje AS

    PROCEDURE insert_pase(
        p_id_reserva       IN pases_abordaje.id_reserva%TYPE,
        p_codigo_barras    IN pases_abordaje.codigo_barras%TYPE,
        p_qr_code          IN pases_abordaje.qr_code%TYPE,
        p_fecha_generacion IN pases_abordaje.fecha_generacion%TYPE,
        p_fecha_escaneo    IN pases_abordaje.fecha_escaneo%TYPE,
        p_puerta_embarque  IN pases_abordaje.puerta_embarque%TYPE,
        p_grupo_embarque   IN pases_abordaje.grupo_embarque%TYPE,
        p_asiento          IN pases_abordaje.asiento%TYPE,
        p_utilizado        IN pases_abordaje.utilizado%TYPE
    ) IS
    BEGIN
        INSERT INTO pases_abordaje (
            id_reserva, codigo_barras, qr_code,
            fecha_generacion, fecha_escaneo,
            puerta_embarque, grupo_embarque,
            asiento, utilizado
        ) VALUES (
            p_id_reserva, p_codigo_barras, p_qr_code,
            p_fecha_generacion, p_fecha_escaneo,
            p_puerta_embarque, p_grupo_embarque,
            p_asiento, NVL(p_utilizado,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23001, 'Error al insertar pase de abordaje: ' || SQLERRM);
    END insert_pase;

    PROCEDURE get_pase(
        p_id_pase_abordaje IN pases_abordaje.id_pase_abordaje%TYPE
    ) IS
        r pases_abordaje%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM pases_abordaje
        WHERE id_pase_abordaje = p_id_pase_abordaje;

        DBMS_OUTPUT.PUT_LINE('ID Pase: ' || r.id_pase_abordaje);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Código barras: ' || r.codigo_barras);
        DBMS_OUTPUT.PUT_LINE('Fecha generación: ' || r.fecha_generacion);
        DBMS_OUTPUT.PUT_LINE('Fecha escaneo: ' || r.fecha_escaneo);
        DBMS_OUTPUT.PUT_LINE('Puerta embarque: ' || r.puerta_embarque);
        DBMS_OUTPUT.PUT_LINE('Grupo embarque: ' || r.grupo_embarque);
        DBMS_OUTPUT.PUT_LINE('Asiento: ' || r.asiento);
        DBMS_OUTPUT.PUT_LINE('Utilizado: ' || r.utilizado);
        DBMS_OUTPUT.PUT_LINE('QR Code: (BLOB)');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Pase de abordaje no encontrado.');
    END get_pase;

    PROCEDURE update_pase(
        p_id_pase_abordaje IN pases_abordaje.id_pase_abordaje%TYPE,
        p_id_reserva       IN pases_abordaje.id_reserva%TYPE,
        p_codigo_barras    IN pases_abordaje.codigo_barras%TYPE,
        p_qr_code          IN pases_abordaje.qr_code%TYPE,
        p_fecha_generacion IN pases_abordaje.fecha_generacion%TYPE,
        p_fecha_escaneo    IN pases_abordaje.fecha_escaneo%TYPE,
        p_puerta_embarque  IN pases_abordaje.puerta_embarque%TYPE,
        p_grupo_embarque   IN pases_abordaje.grupo_embarque%TYPE,
        p_asiento          IN pases_abordaje.asiento%TYPE,
        p_utilizado        IN pases_abordaje.utilizado%TYPE
    ) IS
    BEGIN
        UPDATE pases_abordaje
        SET id_reserva       = p_id_reserva,
            codigo_barras    = p_codigo_barras,
            qr_code          = p_qr_code,
            fecha_generacion = p_fecha_generacion,
            fecha_escaneo    = p_fecha_escaneo,
            puerta_embarque  = p_puerta_embarque,
            grupo_embarque   = p_grupo_embarque,
            asiento          = p_asiento,
            utilizado        = p_utilizado
        WHERE id_pase_abordaje = p_id_pase_abordaje;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23002, 'No se encontró el pase de abordaje para actualizar.');
        END IF;
    END update_pase;

    PROCEDURE delete_pase(
        p_id_pase_abordaje IN pases_abordaje.id_pase_abordaje%TYPE
    ) IS
    BEGIN
        DELETE FROM pases_abordaje
        WHERE id_pase_abordaje = p_id_pase_abordaje;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23003, 'No se encontró el pase de abordaje para eliminar.');
        END IF;
    END delete_pase;

END pkg_pases_abordaje;
/