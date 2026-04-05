------------------------------------------------------------
-- Paquete CRUD para la tabla CONTRATOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_contratos AS
    PROCEDURE insert_contrato(
        p_numero_contrato          IN VARCHAR2,
        p_nombre_contrato          IN VARCHAR2,
        p_tipo_contrato            IN VARCHAR2,
        p_contraparte_nombre       IN VARCHAR2,
        p_contraparte_documento    IN VARCHAR2,
        p_fecha_firma              IN DATE,
        p_fecha_inicio             IN DATE,
        p_fecha_fin                IN DATE,
        p_fecha_terminacion_anticipada IN DATE,
        p_monto_total              IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_forma_pago               IN VARCHAR2,
        p_objeto_contractual       IN CLOB,
        p_clausulas_principales    IN CLOB,
        p_documento_contrato       IN BLOB,
        p_renovacion_automatica    IN NUMBER DEFAULT 0,
        p_notificar_vencimiento_dias IN NUMBER DEFAULT 30,
        p_estado                   IN VARCHAR2 DEFAULT 'VIGENTE',
        p_administrador_contrato   IN NUMBER,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE get_contrato(
        p_id_contrato IN NUMBER
    );

    PROCEDURE update_contrato(
        p_id_contrato              IN NUMBER,
        p_numero_contrato          IN VARCHAR2,
        p_nombre_contrato          IN VARCHAR2,
        p_tipo_contrato            IN VARCHAR2,
        p_contraparte_nombre       IN VARCHAR2,
        p_contraparte_documento    IN VARCHAR2,
        p_fecha_firma              IN DATE,
        p_fecha_inicio             IN DATE,
        p_fecha_fin                IN DATE,
        p_fecha_terminacion_anticipada IN DATE,
        p_monto_total              IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_forma_pago               IN VARCHAR2,
        p_objeto_contractual       IN CLOB,
        p_clausulas_principales    IN CLOB,
        p_documento_contrato       IN BLOB,
        p_renovacion_automatica    IN NUMBER,
        p_notificar_vencimiento_dias IN NUMBER,
        p_estado                   IN VARCHAR2,
        p_administrador_contrato   IN NUMBER,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE delete_contrato(
        p_id_contrato IN NUMBER
    );
END pkg_contratos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_contratos AS

    PROCEDURE insert_contrato(
        p_numero_contrato          IN VARCHAR2,
        p_nombre_contrato          IN VARCHAR2,
        p_tipo_contrato            IN VARCHAR2,
        p_contraparte_nombre       IN VARCHAR2,
        p_contraparte_documento    IN VARCHAR2,
        p_fecha_firma              IN DATE,
        p_fecha_inicio             IN DATE,
        p_fecha_fin                IN DATE,
        p_fecha_terminacion_anticipada IN DATE,
        p_monto_total              IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_forma_pago               IN VARCHAR2,
        p_objeto_contractual       IN CLOB,
        p_clausulas_principales    IN CLOB,
        p_documento_contrato       IN BLOB,
        p_renovacion_automatica    IN NUMBER,
        p_notificar_vencimiento_dias IN NUMBER,
        p_estado                   IN VARCHAR2,
        p_administrador_contrato   IN NUMBER,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO contratos (
            numero_contrato, nombre_contrato, tipo_contrato,
            contraparte_nombre, contraparte_documento,
            fecha_firma, fecha_inicio, fecha_fin, fecha_terminacion_anticipada,
            monto_total, moneda, forma_pago,
            objeto_contractual, clausulas_principales, documento_contrato,
            renovacion_automatica, notificar_vencimiento_dias, estado,
            administrador_contrato, observaciones
        ) VALUES (
            p_numero_contrato, p_nombre_contrato, p_tipo_contrato,
            p_contraparte_nombre, p_contraparte_documento,
            p_fecha_firma, p_fecha_inicio, p_fecha_fin, p_fecha_terminacion_anticipada,
            p_monto_total, p_moneda, p_forma_pago,
            p_objeto_contractual, p_clausulas_principales, p_documento_contrato,
            NVL(p_renovacion_automatica,0), NVL(p_notificar_vencimiento_dias,30), NVL(p_estado,'VIGENTE'),
            p_administrador_contrato, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33901, 'Error al insertar contrato: ' || SQLERRM);
    END insert_contrato;

    PROCEDURE get_contrato(
        p_id_contrato IN NUMBER
    ) IS
        r contratos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM contratos
        WHERE id_contrato = p_id_contrato;

        DBMS_OUTPUT.PUT_LINE('ID Contrato: ' || r.id_contrato);
        DBMS_OUTPUT.PUT_LINE('Número: ' || r.numero_contrato);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_contrato);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_contrato);
        DBMS_OUTPUT.PUT_LINE('Contraparte: ' || r.contraparte_nombre);
        DBMS_OUTPUT.PUT_LINE('Documento contraparte: ' || r.contraparte_documento);
        DBMS_OUTPUT.PUT_LINE('Fecha firma: ' || r.fecha_firma);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Fecha terminación anticipada: ' || r.fecha_terminacion_anticipada);
        DBMS_OUTPUT.PUT_LINE('Monto total: ' || r.monto_total || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Forma pago: ' || r.forma_pago);
        DBMS_OUTPUT.PUT_LINE('Objeto contractual: ' || DBMS_LOB.SUBSTR(r.objeto_contractual, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Cláusulas principales: ' || DBMS_LOB.SUBSTR(r.clausulas_principales, 200, 1));
        IF r.documento_contrato IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento contrato: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento contrato: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Renovación automática: ' || r.renovacion_automatica);
        DBMS_OUTPUT.PUT_LINE('Notificar vencimiento (días): ' || r.notificar_vencimiento_dias);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Administrador contrato: ' || r.administrador_contrato);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Contrato no encontrado.');
    END get_contrato;

        PROCEDURE update_contrato(
        p_id_contrato              IN NUMBER,
        p_numero_contrato          IN VARCHAR2,
        p_nombre_contrato          IN VARCHAR2,
        p_tipo_contrato            IN VARCHAR2,
        p_contraparte_nombre       IN VARCHAR2,
        p_contraparte_documento    IN VARCHAR2,
        p_fecha_firma              IN DATE,
        p_fecha_inicio             IN DATE,
        p_fecha_fin                IN DATE,
        p_fecha_terminacion_anticipada IN DATE,
        p_monto_total              IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_forma_pago               IN VARCHAR2,
        p_objeto_contractual       IN CLOB,
        p_clausulas_principales    IN CLOB,
        p_documento_contrato       IN BLOB,
        p_renovacion_automatica    IN NUMBER,
        p_notificar_vencimiento_dias IN NUMBER,
        p_estado                   IN VARCHAR2,
        p_administrador_contrato   IN NUMBER,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        UPDATE contratos
        SET numero_contrato          = p_numero_contrato,
            nombre_contrato          = p_nombre_contrato,
            tipo_contrato            = p_tipo_contrato,
            contraparte_nombre       = p_contraparte_nombre,
            contraparte_documento    = p_contraparte_documento,
            fecha_firma              = p_fecha_firma,
            fecha_inicio             = p_fecha_inicio,
            fecha_fin                = p_fecha_fin,
            fecha_terminacion_anticipada = p_fecha_terminacion_anticipada,
            monto_total              = p_monto_total,
            moneda                   = p_moneda,
            forma_pago               = p_forma_pago,
            objeto_contractual       = p_objeto_contractual,
            clausulas_principales    = p_clausulas_principales,
            documento_contrato       = p_documento_contrato,
            renovacion_automatica    = p_renovacion_automatica,
            notificar_vencimiento_dias = p_notificar_vencimiento_dias,
            estado                   = p_estado,
            administrador_contrato   = p_administrador_contrato,
            observaciones            = p_observaciones
        WHERE id_contrato = p_id_contrato;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33902, 'No se encontró el contrato para actualizar.');
        END IF;
    END update_contrato;

    PROCEDURE delete_contrato(
        p_id_contrato IN NUMBER
    ) IS
    BEGIN
        DELETE FROM contratos
        WHERE id_contrato = p_id_contrato;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33903, 'No se encontró el contrato para eliminar.');
        END IF;
    END delete_contrato;

END pkg_contratos;
/
