------------------------------------------------------------
-- Paquete CRUD para la tabla PASAJEROS_DOCUMENTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pasajeros_documentos AS
    PROCEDURE insert_documento(
        p_id_pasajero       IN pasajeros_documentos.id_pasajero%TYPE,
        p_tipo_documento    IN pasajeros_documentos.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros_documentos.numero_documento%TYPE,
        p_pais_emision      IN pasajeros_documentos.pais_emision%TYPE,
        p_fecha_emision     IN pasajeros_documentos.fecha_emision%TYPE,
        p_fecha_expiracion  IN pasajeros_documentos.fecha_expiracion%TYPE,
        p_imagen_documento  IN pasajeros_documentos.imagen_documento%TYPE,
        p_verificado        IN pasajeros_documentos.verificado%TYPE DEFAULT 0
    );

    PROCEDURE get_documento(
        p_id_documento IN pasajeros_documentos.id_documento%TYPE
    );

    PROCEDURE update_documento(
        p_id_documento     IN pasajeros_documentos.id_documento%TYPE,
        p_id_pasajero      IN pasajeros_documentos.id_pasajero%TYPE,
        p_tipo_documento   IN pasajeros_documentos.tipo_documento%TYPE,
        p_numero_documento IN pasajeros_documentos.numero_documento%TYPE,
        p_pais_emision     IN pasajeros_documentos.pais_emision%TYPE,
        p_fecha_emision    IN pasajeros_documentos.fecha_emision%TYPE,
        p_fecha_expiracion IN pasajeros_documentos.fecha_expiracion%TYPE,
        p_imagen_documento IN pasajeros_documentos.imagen_documento%TYPE,
        p_verificado       IN pasajeros_documentos.verificado%TYPE
    );

    PROCEDURE delete_documento(
        p_id_documento IN pasajeros_documentos.id_documento%TYPE
    );
END pkg_pasajeros_documentos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pasajeros_documentos AS

    PROCEDURE insert_documento(
        p_id_pasajero       IN pasajeros_documentos.id_pasajero%TYPE,
        p_tipo_documento    IN pasajeros_documentos.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros_documentos.numero_documento%TYPE,
        p_pais_emision      IN pasajeros_documentos.pais_emision%TYPE,
        p_fecha_emision     IN pasajeros_documentos.fecha_emision%TYPE,
        p_fecha_expiracion  IN pasajeros_documentos.fecha_expiracion%TYPE,
        p_imagen_documento  IN pasajeros_documentos.imagen_documento%TYPE,
        p_verificado        IN pasajeros_documentos.verificado%TYPE
    ) IS
    BEGIN
        INSERT INTO pasajeros_documentos (
            id_pasajero, tipo_documento, numero_documento,
            pais_emision, fecha_emision, fecha_expiracion,
            imagen_documento, verificado
        ) VALUES (
            p_id_pasajero, p_tipo_documento, p_numero_documento,
            p_pais_emision, p_fecha_emision, p_fecha_expiracion,
            p_imagen_documento, NVL(p_verificado,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21701, 'Error al insertar documento: ' || SQLERRM);
    END insert_documento;

    PROCEDURE get_documento(
        p_id_documento IN pasajeros_documentos.id_documento%TYPE
    ) IS
        r pasajeros_documentos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM pasajeros_documentos
        WHERE id_documento = p_id_documento;

        DBMS_OUTPUT.PUT_LINE('ID Documento: ' || r.id_documento);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_documento);
        DBMS_OUTPUT.PUT_LINE('Número: ' || r.numero_documento);
        DBMS_OUTPUT.PUT_LINE('País emisión: ' || r.pais_emision);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Fecha expiración: ' || r.fecha_expiracion);
        DBMS_OUTPUT.PUT_LINE('Verificado: ' || r.verificado);
        DBMS_OUTPUT.PUT_LINE('Imagen documento: (BLOB)');
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Documento no encontrado.');
    END get_documento;

    PROCEDURE update_documento(
        p_id_documento     IN pasajeros_documentos.id_documento%TYPE,
        p_id_pasajero      IN pasajeros_documentos.id_pasajero%TYPE,
        p_tipo_documento   IN pasajeros_documentos.tipo_documento%TYPE,
        p_numero_documento IN pasajeros_documentos.numero_documento%TYPE,
        p_pais_emision     IN pasajeros_documentos.pais_emision%TYPE,
        p_fecha_emision    IN pasajeros_documentos.fecha_emision%TYPE,
        p_fecha_expiracion IN pasajeros_documentos.fecha_expiracion%TYPE,
        p_imagen_documento IN pasajeros_documentos.imagen_documento%TYPE,
        p_verificado       IN pasajeros_documentos.verificado%TYPE
    ) IS
    BEGIN
        UPDATE pasajeros_documentos
        SET id_pasajero      = p_id_pasajero,
            tipo_documento   = p_tipo_documento,
            numero_documento = p_numero_documento,
            pais_emision     = p_pais_emision,
            fecha_emision    = p_fecha_emision,
            fecha_expiracion = p_fecha_expiracion,
            imagen_documento = p_imagen_documento,
            verificado       = p_verificado
        WHERE id_documento = p_id_documento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21702, 'No se encontró el documento para actualizar.');
        END IF;
    END update_documento;

    PROCEDURE delete_documento(
        p_id_documento IN pasajeros_documentos.id_documento%TYPE
    ) IS
    BEGIN
        DELETE FROM pasajeros_documentos
        WHERE id_documento = p_id_documento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21703, 'No se encontró el documento para eliminar.');
        END IF;
    END delete_documento;

END pkg_pasajeros_documentos;
/