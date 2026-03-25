------------------------------------------------------------
-- Paquete CRUD para la tabla AUTORIZACIONES_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_autorizaciones_vuelo AS
    PROCEDURE insert_autorizacion(
        p_id_vuelo            IN autorizaciones_vuelo.id_vuelo%TYPE,
        p_tipo_autorizacion   IN autorizaciones_vuelo.tipo_autorizacion%TYPE,
        p_entidad_autorizante IN autorizaciones_vuelo.entidad_autorizante%TYPE,
        p_numero_autorizacion IN autorizaciones_vuelo.numero_autorizacion%TYPE,
        p_fecha_emision       IN autorizaciones_vuelo.fecha_emision%TYPE,
        p_fecha_expiracion    IN autorizaciones_vuelo.fecha_expiracion%TYPE,
        p_documento_asociado  IN autorizaciones_vuelo.documento_asociado%TYPE,
        p_activa              IN autorizaciones_vuelo.activa%TYPE DEFAULT 1
    );

    PROCEDURE get_autorizacion(
        p_id_autorizacion IN autorizaciones_vuelo.id_autorizacion%TYPE
    );

    PROCEDURE update_autorizacion(
        p_id_autorizacion    IN autorizaciones_vuelo.id_autorizacion%TYPE,
        p_id_vuelo           IN autorizaciones_vuelo.id_vuelo%TYPE,
        p_tipo_autorizacion  IN autorizaciones_vuelo.tipo_autorizacion%TYPE,
        p_entidad_autorizante IN autorizaciones_vuelo.entidad_autorizante%TYPE,
        p_numero_autorizacion IN autorizaciones_vuelo.numero_autorizacion%TYPE,
        p_fecha_emision      IN autorizaciones_vuelo.fecha_emision%TYPE,
        p_fecha_expiracion   IN autorizaciones_vuelo.fecha_expiracion%TYPE,
        p_documento_asociado IN autorizaciones_vuelo.documento_asociado%TYPE,
        p_activa             IN autorizaciones_vuelo.activa%TYPE
    );

    PROCEDURE delete_autorizacion(
        p_id_autorizacion IN autorizaciones_vuelo.id_autorizacion%TYPE
    );
END pkg_autorizaciones_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_autorizaciones_vuelo AS

    PROCEDURE insert_autorizacion(
        p_id_vuelo            IN autorizaciones_vuelo.id_vuelo%TYPE,
        p_tipo_autorizacion   IN autorizaciones_vuelo.tipo_autorizacion%TYPE,
        p_entidad_autorizante IN autorizaciones_vuelo.entidad_autorizante%TYPE,
        p_numero_autorizacion IN autorizaciones_vuelo.numero_autorizacion%TYPE,
        p_fecha_emision       IN autorizaciones_vuelo.fecha_emision%TYPE,
        p_fecha_expiracion    IN autorizaciones_vuelo.fecha_expiracion%TYPE,
        p_documento_asociado  IN autorizaciones_vuelo.documento_asociado%TYPE,
        p_activa              IN autorizaciones_vuelo.activa%TYPE
    ) IS
    BEGIN
        INSERT INTO autorizaciones_vuelo (
            id_vuelo, tipo_autorizacion, entidad_autorizante,
            numero_autorizacion, fecha_emision, fecha_expiracion,
            documento_asociado, activa
        ) VALUES (
            p_id_vuelo, p_tipo_autorizacion, p_entidad_autorizante,
            p_numero_autorizacion, p_fecha_emision, p_fecha_expiracion,
            p_documento_asociado, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21201, 'Error al insertar autorización: ' || SQLERRM);
    END insert_autorizacion;

    PROCEDURE get_autorizacion(
        p_id_autorizacion IN autorizaciones_vuelo.id_autorizacion%TYPE
    ) IS
        r autorizaciones_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM autorizaciones_vuelo
        WHERE id_autorizacion = p_id_autorizacion;

        DBMS_OUTPUT.PUT_LINE('ID Autorización: ' || r.id_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Entidad autorizante: ' || r.entidad_autorizante);
        DBMS_OUTPUT.PUT_LINE('Número autorización: ' || r.numero_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Fecha expiración: ' || r.fecha_expiracion);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
        DBMS_OUTPUT.PUT_LINE('Documento asociado: (BLOB)');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Autorización no encontrada.');
    END get_autorizacion;

    PROCEDURE update_autorizacion(
        p_id_autorizacion    IN autorizaciones_vuelo.id_autorizacion%TYPE,
        p_id_vuelo           IN autorizaciones_vuelo.id_vuelo%TYPE,
        p_tipo_autorizacion  IN autorizaciones_vuelo.tipo_autorizacion%TYPE,
        p_entidad_autorizante IN autorizaciones_vuelo.entidad_autorizante%TYPE,
        p_numero_autorizacion IN autorizaciones_vuelo.numero_autorizacion%TYPE,
        p_fecha_emision      IN autorizaciones_vuelo.fecha_emision%TYPE,
        p_fecha_expiracion   IN autorizaciones_vuelo.fecha_expiracion%TYPE,
        p_documento_asociado IN autorizaciones_vuelo.documento_asociado%TYPE,
        p_activa             IN autorizaciones_vuelo.activa%TYPE
    ) IS
    BEGIN
        UPDATE autorizaciones_vuelo
        SET id_vuelo           = p_id_vuelo,
            tipo_autorizacion  = p_tipo_autorizacion,
            entidad_autorizante = p_entidad_autorizante,
            numero_autorizacion = p_numero_autorizacion,
            fecha_emision      = p_fecha_emision,
            fecha_expiracion   = p_fecha_expiracion,
            documento_asociado = p_documento_asociado,
            activa             = p_activa
        WHERE id_autorizacion = p_id_autorizacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21202, 'No se encontró la autorización para actualizar.');
        END IF;
    END update_autorizacion;

    PROCEDURE delete_autorizacion(
        p_id_autorizacion IN autorizaciones_vuelo.id_autorizacion%TYPE
    ) IS
    BEGIN
        DELETE FROM autorizaciones_vuelo
        WHERE id_autorizacion = p_id_autorizacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21203, 'No se encontró la autorización para eliminar.');
        END IF;
    END delete_autorizacion;

END pkg_autorizaciones_vuelo;
/