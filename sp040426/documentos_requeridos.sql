------------------------------------------------------------
-- Paquete CRUD para la tabla DOCUMENTOS_REQUERIDOS_OPERACION
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_documentos_requeridos AS
    PROCEDURE insert_documento(
        p_tipo_operacion            IN VARCHAR2,
        p_nombre_documento          IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_obligatorio               IN NUMBER DEFAULT 1,
        p_formato_aceptado          IN VARCHAR2,
        p_entidad_emisora_requerida IN VARCHAR2,
        p_periodo_validez_dias      IN NUMBER,
        p_requiere_original         IN NUMBER DEFAULT 1,
        p_activo                    IN NUMBER DEFAULT 1
    );

    PROCEDURE get_documento(
        p_id_documento_requerido IN NUMBER
    );

    PROCEDURE update_documento(
        p_id_documento_requerido   IN NUMBER,
        p_tipo_operacion            IN VARCHAR2,
        p_nombre_documento          IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_obligatorio               IN NUMBER,
        p_formato_aceptado          IN VARCHAR2,
        p_entidad_emisora_requerida IN VARCHAR2,
        p_periodo_validez_dias      IN NUMBER,
        p_requiere_original         IN NUMBER,
        p_activo                    IN NUMBER
    );

    PROCEDURE delete_documento(
        p_id_documento_requerido IN NUMBER
    );
END pkg_documentos_requeridos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_documentos_requeridos AS

    PROCEDURE insert_documento(
        p_tipo_operacion            IN VARCHAR2,
        p_nombre_documento          IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_obligatorio               IN NUMBER,
        p_formato_aceptado          IN VARCHAR2,
        p_entidad_emisora_requerida IN VARCHAR2,
        p_periodo_validez_dias      IN NUMBER,
        p_requiere_original         IN NUMBER,
        p_activo                    IN NUMBER
    ) IS
    BEGIN
        INSERT INTO documentos_requeridos_operacion (
            tipo_operacion, nombre_documento, descripcion,
            obligatorio, formato_aceptado, entidad_emisora_requerida,
            periodo_validez_dias, requiere_original, activo
        ) VALUES (
            p_tipo_operacion, p_nombre_documento, p_descripcion,
            NVL(p_obligatorio,1), p_formato_aceptado, p_entidad_emisora_requerida,
            p_periodo_validez_dias, NVL(p_requiere_original,1), NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33601, 'Error al insertar documento requerido: ' || SQLERRM);
    END insert_documento;

    PROCEDURE get_documento(
        p_id_documento_requerido IN NUMBER
    ) IS
        r documentos_requeridos_operacion%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM documentos_requeridos_operacion
        WHERE id_documento_requerido = p_id_documento_requerido;

        DBMS_OUTPUT.PUT_LINE('ID Documento: ' || r.id_documento_requerido);
        DBMS_OUTPUT.PUT_LINE('Tipo operación: ' || r.tipo_operacion);
        DBMS_OUTPUT.PUT_LINE('Nombre documento: ' || r.nombre_documento);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Obligatorio: ' || r.obligatorio);
        DBMS_OUTPUT.PUT_LINE('Formato aceptado: ' || r.formato_aceptado);
        DBMS_OUTPUT.PUT_LINE('Entidad emisora requerida: ' || r.entidad_emisora_requerida);
        DBMS_OUTPUT.PUT_LINE('Periodo validez (días): ' || r.periodo_validez_dias);
        DBMS_OUTPUT.PUT_LINE('Requiere original: ' || r.requiere_original);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Documento requerido no encontrado.');
    END get_documento;

    PROCEDURE update_documento(
        p_id_documento_requerido   IN NUMBER,
        p_tipo_operacion            IN VARCHAR2,
        p_nombre_documento          IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_obligatorio               IN NUMBER,
        p_formato_aceptado          IN VARCHAR2,
        p_entidad_emisora_requerida IN VARCHAR2,
        p_periodo_validez_dias      IN NUMBER,
        p_requiere_original         IN NUMBER,
        p_activo                    IN NUMBER
    ) IS
    BEGIN
        UPDATE documentos_requeridos_operacion
        SET tipo_operacion            = p_tipo_operacion,
            nombre_documento          = p_nombre_documento,
            descripcion               = p_descripcion,
            obligatorio               = p_obligatorio,
            formato_aceptado          = p_formato_aceptado,
            entidad_emisora_requerida = p_entidad_emisora_requerida,
            periodo_validez_dias      = p_periodo_validez_dias,
            requiere_original         = p_requiere_original,
            activo                    = p_activo
        WHERE id_documento_requerido = p_id_documento_requerido;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33602, 'No se encontró el documento requerido para actualizar.');
        END IF;
    END update_documento;

    PROCEDURE delete_documento(
        p_id_documento_requerido IN NUMBER
    ) IS
    BEGIN
        DELETE FROM documentos_requeridos_operacion
        WHERE id_documento_requerido = p_id_documento_requerido;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33603, 'No se encontró el documento requerido para eliminar.');
        END IF;
    END delete_documento;

END pkg_documentos_requeridos;
/
