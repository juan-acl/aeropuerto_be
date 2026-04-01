------------------------------------------------------------
-- Paquete CRUD para la tabla CERTIFICACIONES_AMBIENTALES_AEROPUERTO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_certificaciones_ambientales AS
    PROCEDURE insert_certificacion(
        p_codigo_certificacion   IN VARCHAR2,
        p_nombre_certificacion   IN VARCHAR2,
        p_entidad_certificadora  IN VARCHAR2,
        p_fecha_obtencion        IN DATE,
        p_fecha_vencimiento      IN DATE,
        p_nivel_certificacion    IN VARCHAR2,
        p_alcance                IN VARCHAR2,
        p_documento_certificado  IN BLOB,
        p_activa                 IN NUMBER DEFAULT 1,
        p_responsable_seguimiento IN NUMBER,
        p_observaciones          IN VARCHAR2
    );

    PROCEDURE get_certificacion(
        p_id_certificacion_ambiental IN NUMBER
    );

    PROCEDURE update_certificacion(
        p_id_certificacion_ambiental IN NUMBER,
        p_codigo_certificacion   IN VARCHAR2,
        p_nombre_certificacion   IN VARCHAR2,
        p_entidad_certificadora  IN VARCHAR2,
        p_fecha_obtencion        IN DATE,
        p_fecha_vencimiento      IN DATE,
        p_nivel_certificacion    IN VARCHAR2,
        p_alcance                IN VARCHAR2,
        p_documento_certificado  IN BLOB,
        p_activa                 IN NUMBER,
        p_responsable_seguimiento IN NUMBER,
        p_observaciones          IN VARCHAR2
    );

    PROCEDURE delete_certificacion(
        p_id_certificacion_ambiental IN NUMBER
    );
END pkg_certificaciones_ambientales;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_certificaciones_ambientales AS

    PROCEDURE insert_certificacion(
        p_codigo_certificacion   IN VARCHAR2,
        p_nombre_certificacion   IN VARCHAR2,
        p_entidad_certificadora  IN VARCHAR2,
        p_fecha_obtencion        IN DATE,
        p_fecha_vencimiento      IN DATE,
        p_nivel_certificacion    IN VARCHAR2,
        p_alcance                IN VARCHAR2,
        p_documento_certificado  IN BLOB,
        p_activa                 IN NUMBER,
        p_responsable_seguimiento IN NUMBER,
        p_observaciones          IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO certificaciones_ambientales_aeropuerto (
            codigo_certificacion, nombre_certificacion, entidad_certificadora,
            fecha_obtencion, fecha_vencimiento, nivel_certificacion,
            alcance, documento_certificado, activa,
            responsable_seguimiento, observaciones
        ) VALUES (
            p_codigo_certificacion, p_nombre_certificacion, p_entidad_certificadora,
            p_fecha_obtencion, p_fecha_vencimiento, p_nivel_certificacion,
            p_alcance, p_documento_certificado, NVL(p_activa,1),
            p_responsable_seguimiento, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31701, 'Error al insertar certificación ambiental: ' || SQLERRM);
    END insert_certificacion;

    PROCEDURE get_certificacion(
        p_id_certificacion_ambiental IN NUMBER
    ) IS
        r certificaciones_ambientales_aeropuerto%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM certificaciones_ambientales_aeropuerto
        WHERE id_certificacion_ambiental = p_id_certificacion_ambiental;

        DBMS_OUTPUT.PUT_LINE('ID Certificación: ' || r.id_certificacion_ambiental);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_certificacion);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_certificacion);
        DBMS_OUTPUT.PUT_LINE('Entidad certificadora: ' || r.entidad_certificadora);
        DBMS_OUTPUT.PUT_LINE('Fecha obtención: ' || r.fecha_obtencion);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento);
        DBMS_OUTPUT.PUT_LINE('Nivel certificación: ' || r.nivel_certificacion);
        DBMS_OUTPUT.PUT_LINE('Alcance: ' || r.alcance);
        IF r.documento_certificado IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento certificado: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento certificado: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
        DBMS_OUTPUT.PUT_LINE('Responsable seguimiento: ' || r.responsable_seguimiento);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Certificación ambiental no encontrada.');
    END get_certificacion;

    PROCEDURE update_certificacion(
        p_id_certificacion_ambiental IN NUMBER,
        p_codigo_certificacion   IN VARCHAR2,
        p_nombre_certificacion   IN VARCHAR2,
        p_entidad_certificadora  IN VARCHAR2,
        p_fecha_obtencion        IN DATE,
        p_fecha_vencimiento      IN DATE,
        p_nivel_certificacion    IN VARCHAR2,
        p_alcance                IN VARCHAR2,
        p_documento_certificado  IN BLOB,
        p_activa                 IN NUMBER,
        p_responsable_seguimiento IN NUMBER,
        p_observaciones          IN VARCHAR2
    ) IS
    BEGIN
        UPDATE certificaciones_ambientales_aeropuerto
        SET codigo_certificacion   = p_codigo_certificacion,
            nombre_certificacion   = p_nombre_certificacion,
            entidad_certificadora  = p_entidad_certificadora,
            fecha_obtencion        = p_fecha_obtencion,
            fecha_vencimiento      = p_fecha_vencimiento,
            nivel_certificacion    = p_nivel_certificacion,
            alcance                = p_alcance,
            documento_certificado  = p_documento_certificado,
            activa                 = p_activa,
            responsable_seguimiento = p_responsable_seguimiento,
            observaciones          = p_observaciones
        WHERE id_certificacion_ambiental = p_id_certificacion_ambiental;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31702, 'No se encontró la certificación ambiental para actualizar.');
        END IF;
    END update_certificacion;

    PROCEDURE delete_certificacion(
        p_id_certificacion_ambiental IN NUMBER
    ) IS
    BEGIN
        DELETE FROM certificaciones_ambientales_aeropuerto
        WHERE id_certificacion_ambiental = p_id_certificacion_ambiental;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31703, 'No se encontró la certificación ambiental para eliminar.');
        END IF;
    END delete_certificacion;

END pkg_certificaciones_ambientales;
/
