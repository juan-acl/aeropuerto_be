------------------------------------------------------------
-- Paquete CRUD para la tabla CERTIFICACIONES_INTERNACIONALES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_certificaciones_internacionales AS
    PROCEDURE insert_certificacion(
        p_id_estandar              IN NUMBER,
        p_nombre_certificacion     IN VARCHAR2,
        p_organismo_certificador   IN VARCHAR2,
        p_fecha_emision            IN DATE,
        p_fecha_vencimiento        IN DATE,
        p_alcance_certificacion    IN CLOB,
        p_numero_certificado       IN VARCHAR2,
        p_documento_certificado    IN BLOB,
        p_activa                   IN NUMBER DEFAULT 1,
        p_responsable_seguimiento  IN NUMBER
    );

    PROCEDURE get_certificacion(
        p_id_certificacion_internacional IN NUMBER
    );

    PROCEDURE update_certificacion(
        p_id_certificacion_internacional IN NUMBER,
        p_id_estandar              IN NUMBER,
        p_nombre_certificacion     IN VARCHAR2,
        p_organismo_certificador   IN VARCHAR2,
        p_fecha_emision            IN DATE,
        p_fecha_vencimiento        IN DATE,
        p_alcance_certificacion    IN CLOB,
        p_numero_certificado       IN VARCHAR2,
        p_documento_certificado    IN BLOB,
        p_activa                   IN NUMBER,
        p_responsable_seguimiento  IN NUMBER
    );

    PROCEDURE delete_certificacion(
        p_id_certificacion_internacional IN NUMBER
    );
END pkg_certificaciones_internacionales;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_certificaciones_internacionales AS

    PROCEDURE insert_certificacion(
        p_id_estandar              IN NUMBER,
        p_nombre_certificacion     IN VARCHAR2,
        p_organismo_certificador   IN VARCHAR2,
        p_fecha_emision            IN DATE,
        p_fecha_vencimiento        IN DATE,
        p_alcance_certificacion    IN CLOB,
        p_numero_certificado       IN VARCHAR2,
        p_documento_certificado    IN BLOB,
        p_activa                   IN NUMBER,
        p_responsable_seguimiento  IN NUMBER
    ) IS
    BEGIN
        INSERT INTO certificaciones_internacionales (
            id_estandar, nombre_certificacion, organismo_certificador,
            fecha_emision, fecha_vencimiento, alcance_certificacion,
            numero_certificado, documento_certificado, activa, responsable_seguimiento
        ) VALUES (
            p_id_estandar, p_nombre_certificacion, p_organismo_certificador,
            p_fecha_emision, p_fecha_vencimiento, p_alcance_certificacion,
            p_numero_certificado, p_documento_certificado, NVL(p_activa,1), p_responsable_seguimiento
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36701, 'Error al insertar certificación internacional: ' || SQLERRM);
    END insert_certificacion;

    PROCEDURE get_certificacion(
        p_id_certificacion_internacional IN NUMBER
    ) IS
        r certificaciones_internacionales%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM certificaciones_internacionales
        WHERE id_certificacion_internacional = p_id_certificacion_internacional;

        DBMS_OUTPUT.PUT_LINE('ID Certificación: ' || r.id_certificacion_internacional);
        DBMS_OUTPUT.PUT_LINE('Estandar: ' || r.id_estandar);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_certificacion);
        DBMS_OUTPUT.PUT_LINE('Organismo certificador: ' || r.organismo_certificador);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento);
        DBMS_OUTPUT.PUT_LINE('Alcance: ' || DBMS_LOB.SUBSTR(r.alcance_certificacion,200,1));
        DBMS_OUTPUT.PUT_LINE('Número certificado: ' || r.numero_certificado);
        IF r.documento_certificado IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento certificado: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento certificado: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
        DBMS_OUTPUT.PUT_LINE('Responsable seguimiento: ' || r.responsable_seguimiento);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Certificación internacional no encontrada.');
    END get_certificacion;

    PROCEDURE update_certificacion(
        p_id_certificacion_internacional IN NUMBER,
        p_id_estandar              IN NUMBER,
        p_nombre_certificacion     IN VARCHAR2,
        p_organismo_certificador   IN VARCHAR2,
        p_fecha_emision            IN DATE,
        p_fecha_vencimiento        IN DATE,
        p_alcance_certificacion    IN CLOB,
        p_numero_certificado       IN VARCHAR2,
        p_documento_certificado    IN BLOB,
        p_activa                   IN NUMBER,
        p_responsable_seguimiento  IN NUMBER
    ) IS
    BEGIN
        UPDATE certificaciones_internacionales
        SET id_estandar              = p_id_estandar,
            nombre_certificacion     = p_nombre_certificacion,
            organismo_certificador   = p_organismo_certificador,
            fecha_emision            = p_fecha_emision,
            fecha_vencimiento        = p_fecha_vencimiento,
            alcance_certificacion    = p_alcance_certificacion,
            numero_certificado       = p_numero_certificado,
            documento_certificado    = p_documento_certificado,
            activa                   = p_activa,
            responsable_seguimiento  = p_responsable_seguimiento
        WHERE id_certificacion_internacional = p_id_certificacion_internacional;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36702, 'No se encontró la certificación internacional para actualizar.');
        END IF;
    END update_certificacion;

    PROCEDURE delete_certificacion(
        p_id_certificacion_internacional IN NUMBER
    ) IS
    BEGIN
        DELETE FROM certificaciones_internacionales
        WHERE id_certificacion_internacional = p_id_certificacion_internacional;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36703, 'No se encontró la certificación internacional para eliminar.');
        END IF;
    END delete_certificacion;

END pkg_certificaciones_internacionales;
/
