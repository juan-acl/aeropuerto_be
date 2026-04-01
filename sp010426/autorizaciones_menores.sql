------------------------------------------------------------
-- Paquete CRUD para la tabla AUTORIZACIONES_MENORES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_autorizaciones_menores AS
    PROCEDURE insert_autorizacion(
        p_id_menor               IN NUMBER,
        p_numero_autorizacion    IN VARCHAR2,
        p_fecha_emision          IN DATE,
        p_fecha_expiracion       IN DATE,
        p_autoridad_emisora      IN VARCHAR2,
        p_documento_autorizacion IN BLOB,
        p_verificado             IN NUMBER DEFAULT 0
    );

    PROCEDURE get_autorizacion(
        p_id_autorizacion_menor IN NUMBER
    );

    PROCEDURE update_autorizacion(
        p_id_autorizacion_menor IN NUMBER,
        p_id_menor              IN NUMBER,
        p_numero_autorizacion   IN VARCHAR2,
        p_fecha_emision         IN DATE,
        p_fecha_expiracion      IN DATE,
        p_autoridad_emisora     IN VARCHAR2,
        p_documento_autorizacion IN BLOB,
        p_verificado            IN NUMBER
    );

    PROCEDURE delete_autorizacion(
        p_id_autorizacion_menor IN NUMBER
    );
END pkg_autorizaciones_menores;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_autorizaciones_menores AS

    PROCEDURE insert_autorizacion(
        p_id_menor               IN NUMBER,
        p_numero_autorizacion    IN VARCHAR2,
        p_fecha_emision          IN DATE,
        p_fecha_expiracion       IN DATE,
        p_autoridad_emisora      IN VARCHAR2,
        p_documento_autorizacion IN BLOB,
        p_verificado             IN NUMBER
    ) IS
    BEGIN
        INSERT INTO autorizaciones_menores (
            id_menor, numero_autorizacion, fecha_emision, fecha_expiracion,
            autoridad_emisora, documento_autorizacion, verificado
        ) VALUES (
            p_id_menor, p_numero_autorizacion, p_fecha_emision, p_fecha_expiracion,
            p_autoridad_emisora, p_documento_autorizacion, NVL(p_verificado,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28401, 'Error al insertar autorización de menor: ' || SQLERRM);
    END insert_autorizacion;

    PROCEDURE get_autorizacion(
        p_id_autorizacion_menor IN NUMBER
    ) IS
        r autorizaciones_menores%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM autorizaciones_menores
        WHERE id_autorizacion_menor = p_id_autorizacion_menor;

        DBMS_OUTPUT.PUT_LINE('ID Autorización menor: ' || r.id_autorizacion_menor);
        DBMS_OUTPUT.PUT_LINE('Menor: ' || r.id_menor);
        DBMS_OUTPUT.PUT_LINE('Número autorización: ' || r.numero_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Fecha expiración: ' || r.fecha_expiracion);
        DBMS_OUTPUT.PUT_LINE('Autoridad emisora: ' || r.autoridad_emisora);
        IF r.documento_autorizacion IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento autorización: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento autorización: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Verificado: ' || r.verificado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Autorización de menor no encontrada.');
    END get_autorizacion;

    PROCEDURE update_autorizacion(
        p_id_autorizacion_menor IN NUMBER,
        p_id_menor              IN NUMBER,
        p_numero_autorizacion   IN VARCHAR2,
        p_fecha_emision         IN DATE,
        p_fecha_expiracion      IN DATE,
        p_autoridad_emisora     IN VARCHAR2,
        p_documento_autorizacion IN BLOB,
        p_verificado            IN NUMBER
    ) IS
    BEGIN
        UPDATE autorizaciones_menores
        SET id_menor               = p_id_menor,
            numero_autorizacion    = p_numero_autorizacion,
            fecha_emision          = p_fecha_emision,
            fecha_expiracion       = p_fecha_expiracion,
            autoridad_emisora      = p_autoridad_emisora,
            documento_autorizacion = p_documento_autorizacion,
            verificado             = p_verificado
        WHERE id_autorizacion_menor = p_id_autorizacion_menor;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28402, 'No se encontró la autorización de menor para actualizar.');
        END IF;
    END update_autorizacion;

    PROCEDURE delete_autorizacion(
        p_id_autorizacion_menor IN NUMBER
    ) IS
    BEGIN
        DELETE FROM autorizaciones_menores
        WHERE id_autorizacion_menor = p_id_autorizacion_menor;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28403, 'No se encontró la autorización de menor para eliminar.');
        END IF;
    END delete_autorizacion;

END pkg_autorizaciones_menores;
/
