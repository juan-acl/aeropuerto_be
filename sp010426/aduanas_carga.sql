------------------------------------------------------------
-- Paquete CRUD para la tabla ADUANAS_CARGA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_aduanas_carga AS
    PROCEDURE insert_registro(
        p_id_envio             IN NUMBER,
        p_tipo_operacion       IN VARCHAR2,
        p_fecha_revision       IN DATE DEFAULT SYSDATE,
        p_estado_aduanal       IN VARCHAR2,
        p_inspector_asignado   IN NUMBER,
        p_documentos_verificados IN NUMBER DEFAULT 0,
        p_impuesto_aplicado    IN NUMBER,
        p_moneda_impuesto      IN VARCHAR2,
        p_fecha_liberacion     IN DATE,
        p_observaciones        IN VARCHAR2
    );

    PROCEDURE get_registro(
        p_id_registro_aduanal IN NUMBER
    );

    PROCEDURE update_registro(
        p_id_registro_aduanal IN NUMBER,
        p_id_envio            IN NUMBER,
        p_tipo_operacion      IN VARCHAR2,
        p_fecha_revision      IN DATE,
        p_estado_aduanal      IN VARCHAR2,
        p_inspector_asignado  IN NUMBER,
        p_documentos_verificados IN NUMBER,
        p_impuesto_aplicado   IN NUMBER,
        p_moneda_impuesto     IN VARCHAR2,
        p_fecha_liberacion    IN DATE,
        p_observaciones       IN VARCHAR2
    );

    PROCEDURE delete_registro(
        p_id_registro_aduanal IN NUMBER
    );
END pkg_aduanas_carga;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_aduanas_carga AS

    PROCEDURE insert_registro(
        p_id_envio             IN NUMBER,
        p_tipo_operacion       IN VARCHAR2,
        p_fecha_revision       IN DATE,
        p_estado_aduanal       IN VARCHAR2,
        p_inspector_asignado   IN NUMBER,
        p_documentos_verificados IN NUMBER,
        p_impuesto_aplicado    IN NUMBER,
        p_moneda_impuesto      IN VARCHAR2,
        p_fecha_liberacion     IN DATE,
        p_observaciones        IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO aduanas_carga (
            id_envio, tipo_operacion, fecha_revision, estado_aduanal,
            inspector_asignado, documentos_verificados, impuesto_aplicado,
            moneda_impuesto, fecha_liberacion, observaciones
        ) VALUES (
            p_id_envio, p_tipo_operacion, NVL(p_fecha_revision, SYSDATE), p_estado_aduanal,
            p_inspector_asignado, NVL(p_documentos_verificados,0), p_impuesto_aplicado,
            p_moneda_impuesto, p_fecha_liberacion, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29001, 'Error al insertar registro aduanal: ' || SQLERRM);
    END insert_registro;

    PROCEDURE get_registro(
        p_id_registro_aduanal IN NUMBER
    ) IS
        r aduanas_carga%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM aduanas_carga
        WHERE id_registro_aduanal = p_id_registro_aduanal;

        DBMS_OUTPUT.PUT_LINE('ID Registro Aduanal: ' || r.id_registro_aduanal);
        DBMS_OUTPUT.PUT_LINE('Envío: ' || r.id_envio);
        DBMS_OUTPUT.PUT_LINE('Tipo operación: ' || r.tipo_operacion);
        DBMS_OUTPUT.PUT_LINE('Fecha revisión: ' || r.fecha_revision);
        DBMS_OUTPUT.PUT_LINE('Estado aduanal: ' || r.estado_aduanal);
        DBMS_OUTPUT.PUT_LINE('Inspector asignado: ' || r.inspector_asignado);
        DBMS_OUTPUT.PUT_LINE('Documentos verificados: ' || r.documentos_verificados);
        DBMS_OUTPUT.PUT_LINE('Impuesto aplicado: ' || r.impuesto_aplicado || ' ' || r.moneda_impuesto);
        DBMS_OUTPUT.PUT_LINE('Fecha liberación: ' || r.fecha_liberacion);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Registro aduanal no encontrado.');
    END get_registro;

    PROCEDURE update_registro(
        p_id_registro_aduanal IN NUMBER,
        p_id_envio            IN NUMBER,
        p_tipo_operacion      IN VARCHAR2,
        p_fecha_revision      IN DATE,
        p_estado_aduanal      IN VARCHAR2,
        p_inspector_asignado  IN NUMBER,
        p_documentos_verificados IN NUMBER,
        p_impuesto_aplicado   IN NUMBER,
        p_moneda_impuesto     IN VARCHAR2,
        p_fecha_liberacion    IN DATE,
        p_observaciones       IN VARCHAR2
    ) IS
    BEGIN
        UPDATE aduanas_carga
        SET id_envio             = p_id_envio,
            tipo_operacion       = p_tipo_operacion,
            fecha_revision       = p_fecha_revision,
            estado_aduanal       = p_estado_aduanal,
            inspector_asignado   = p_inspector_asignado,
            documentos_verificados = p_documentos_verificados,
            impuesto_aplicado    = p_impuesto_aplicado,
            moneda_impuesto      = p_moneda_impuesto,
            fecha_liberacion     = p_fecha_liberacion,
            observaciones        = p_observaciones
        WHERE id_registro_aduanal = p_id_registro_aduanal;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29002, 'No se encontró el registro aduanal para actualizar.');
        END IF;
    END update_registro;

    PROCEDURE delete_registro(
        p_id_registro_aduanal IN NUMBER
    ) IS
    BEGIN
        DELETE FROM aduanas_carga
        WHERE id_registro_aduanal = p_id_registro_aduanal;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29003, 'No se encontró el registro aduanal para eliminar.');
        END IF;
    END delete_registro;

END pkg_aduanas_carga;
/
