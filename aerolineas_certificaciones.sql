------------------------------------------------------------
-- Paquete CRUD para la tabla AEROLINEAS_CERTIFICACIONES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_aerolineas_certificaciones AS
    PROCEDURE insert_certificacion(
        p_id_aerolinea        IN aerolineas_certificaciones.id_aerolinea%TYPE,
        p_tipo_certificacion  IN aerolineas_certificaciones.tipo_certificacion%TYPE,
        p_entidad_emisora     IN aerolineas_certificaciones.entidad_emisora%TYPE,
        p_fecha_emision       IN aerolineas_certificaciones.fecha_emision%TYPE,
        p_fecha_expiracion    IN aerolineas_certificaciones.fecha_expiracion%TYPE,
        p_numero_certificado  IN aerolineas_certificaciones.numero_certificado%TYPE,
        p_activo              IN aerolineas_certificaciones.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_certificacion(
        p_id_certificacion IN aerolineas_certificaciones.id_certificacion%TYPE
    );

    PROCEDURE update_certificacion(
        p_id_certificacion    IN aerolineas_certificaciones.id_certificacion%TYPE,
        p_id_aerolinea        IN aerolineas_certificaciones.id_aerolinea%TYPE,
        p_tipo_certificacion  IN aerolineas_certificaciones.tipo_certificacion%TYPE,
        p_entidad_emisora     IN aerolineas_certificaciones.entidad_emisora%TYPE,
        p_fecha_emision       IN aerolineas_certificaciones.fecha_emision%TYPE,
        p_fecha_expiracion    IN aerolineas_certificaciones.fecha_expiracion%TYPE,
        p_numero_certificado  IN aerolineas_certificaciones.numero_certificado%TYPE,
        p_activo              IN aerolineas_certificaciones.activo%TYPE
    );

    PROCEDURE delete_certificacion(
        p_id_certificacion IN aerolineas_certificaciones.id_certificacion%TYPE
    );
END pkg_aerolineas_certificaciones;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_aerolineas_certificaciones AS

    PROCEDURE insert_certificacion(
        p_id_aerolinea        IN aerolineas_certificaciones.id_aerolinea%TYPE,
        p_tipo_certificacion  IN aerolineas_certificaciones.tipo_certificacion%TYPE,
        p_entidad_emisora     IN aerolineas_certificaciones.entidad_emisora%TYPE,
        p_fecha_emision       IN aerolineas_certificaciones.fecha_emision%TYPE,
        p_fecha_expiracion    IN aerolineas_certificaciones.fecha_expiracion%TYPE,
        p_numero_certificado  IN aerolineas_certificaciones.numero_certificado%TYPE,
        p_activo              IN aerolineas_certificaciones.activo%TYPE
    ) IS
    BEGIN
        INSERT INTO aerolineas_certificaciones (
            id_aerolinea, tipo_certificacion, entidad_emisora,
            fecha_emision, fecha_expiracion, numero_certificado, activo
        ) VALUES (
            p_id_aerolinea, p_tipo_certificacion, p_entidad_emisora,
            p_fecha_emision, p_fecha_expiracion, p_numero_certificado, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20201, 'Error al insertar certificación: ' || SQLERRM);
    END insert_certificacion;

    PROCEDURE get_certificacion(
        p_id_certificacion IN aerolineas_certificaciones.id_certificacion%TYPE
    ) IS
        r aerolineas_certificaciones%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM aerolineas_certificaciones
        WHERE id_certificacion = p_id_certificacion;

        DBMS_OUTPUT.PUT_LINE('ID Certificación: ' || r.id_certificacion);
        DBMS_OUTPUT.PUT_LINE('Aerolínea: ' || r.id_aerolinea);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_certificacion);
        DBMS_OUTPUT.PUT_LINE('Entidad emisora: ' || r.entidad_emisora);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Fecha expiración: ' || r.fecha_expiracion);
        DBMS_OUTPUT.PUT_LINE('Número certificado: ' || r.numero_certificado);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Certificación no encontrada.');
    END get_certificacion;

    PROCEDURE update_certificacion(
        p_id_certificacion    IN aerolineas_certificaciones.id_certificacion%TYPE,
        p_id_aerolinea        IN aerolineas_certificaciones.id_aerolinea%TYPE,
        p_tipo_certificacion  IN aerolineas_certificaciones.tipo_certificacion%TYPE,
        p_entidad_emisora     IN aerolineas_certificaciones.entidad_emisora%TYPE,
        p_fecha_emision       IN aerolineas_certificaciones.fecha_emision%TYPE,
        p_fecha_expiracion    IN aerolineas_certificaciones.fecha_expiracion%TYPE,
        p_numero_certificado  IN aerolineas_certificaciones.numero_certificado%TYPE,
        p_activo              IN aerolineas_certificaciones.activo%TYPE
    ) IS
    BEGIN
        UPDATE aerolineas_certificaciones
        SET id_aerolinea       = p_id_aerolinea,
            tipo_certificacion = p_tipo_certificacion,
            entidad_emisora    = p_entidad_emisora,
            fecha_emision      = p_fecha_emision,
            fecha_expiracion   = p_fecha_expiracion,
            numero_certificado = p_numero_certificado,
            activo             = p_activo
        WHERE id_certificacion = p_id_certificacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20202, 'No se encontró la certificación para actualizar.');
        END IF;
    END update_certificacion;

    PROCEDURE delete_certificacion(
        p_id_certificacion IN aerolineas_certificaciones.id_certificacion%TYPE
    ) IS
    BEGIN
        DELETE FROM aerolineas_certificaciones
        WHERE id_certificacion = p_id_certificacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20203, 'No se encontró la certificación para eliminar.');
        END IF;
    END delete_certificacion;

END pkg_aerolineas_certificaciones;
/