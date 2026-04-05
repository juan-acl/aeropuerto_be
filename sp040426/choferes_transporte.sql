------------------------------------------------------------
-- Paquete CRUD para la tabla CHOFERES_TRANSPORTE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_choferes_transporte AS
    PROCEDURE insert_chofer(
        p_nombres                 IN VARCHAR2,
        p_apellidos               IN VARCHAR2,
        p_tipo_documento          IN VARCHAR2,
        p_numero_documento        IN VARCHAR2,
        p_licencia_conducir       IN VARCHAR2,
        p_categoria_licencia      IN VARCHAR2,
        p_fecha_vencimiento_licencia IN DATE,
        p_telefono                IN VARCHAR2,
        p_email                   IN VARCHAR2,
        p_fecha_contratacion      IN DATE,
        p_empresa_contratante     IN VARCHAR2,
        p_certificaciones         IN VARCHAR2,
        p_idiomas                 IN VARCHAR2,
        p_disponible              IN NUMBER DEFAULT 1,
        p_activo                  IN NUMBER DEFAULT 1
    );

    PROCEDURE get_chofer(
        p_id_chofer_transporte IN NUMBER
    );

    PROCEDURE update_chofer(
        p_id_chofer_transporte    IN NUMBER,
        p_nombres                 IN VARCHAR2,
        p_apellidos               IN VARCHAR2,
        p_tipo_documento          IN VARCHAR2,
        p_numero_documento        IN VARCHAR2,
        p_licencia_conducir       IN VARCHAR2,
        p_categoria_licencia      IN VARCHAR2,
        p_fecha_vencimiento_licencia IN DATE,
        p_telefono                IN VARCHAR2,
        p_email                   IN VARCHAR2,
        p_fecha_contratacion      IN DATE,
        p_empresa_contratante     IN VARCHAR2,
        p_certificaciones         IN VARCHAR2,
        p_idiomas                 IN VARCHAR2,
        p_disponible              IN NUMBER,
        p_activo                  IN NUMBER
    );

    PROCEDURE delete_chofer(
        p_id_chofer_transporte IN NUMBER
    );
END pkg_choferes_transporte;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_choferes_transporte AS

    PROCEDURE insert_chofer(
        p_nombres                 IN VARCHAR2,
        p_apellidos               IN VARCHAR2,
        p_tipo_documento          IN VARCHAR2,
        p_numero_documento        IN VARCHAR2,
        p_licencia_conducir       IN VARCHAR2,
        p_categoria_licencia      IN VARCHAR2,
        p_fecha_vencimiento_licencia IN DATE,
        p_telefono                IN VARCHAR2,
        p_email                   IN VARCHAR2,
        p_fecha_contratacion      IN DATE,
        p_empresa_contratante     IN VARCHAR2,
        p_certificaciones         IN VARCHAR2,
        p_idiomas                 IN VARCHAR2,
        p_disponible              IN NUMBER,
        p_activo                  IN NUMBER
    ) IS
    BEGIN
        INSERT INTO choferes_transporte (
            nombres, apellidos, tipo_documento, numero_documento,
            licencia_conducir, categoria_licencia, fecha_vencimiento_licencia,
            telefono, email, fecha_contratacion, empresa_contratante,
            certificaciones, idiomas, disponible, activo
        ) VALUES (
            p_nombres, p_apellidos, p_tipo_documento, p_numero_documento,
            p_licencia_conducir, p_categoria_licencia, p_fecha_vencimiento_licencia,
            p_telefono, p_email, p_fecha_contratacion, p_empresa_contratante,
            p_certificaciones, p_idiomas, NVL(p_disponible,1), NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34701, 'Error al insertar chofer de transporte: ' || SQLERRM);
    END insert_chofer;

    PROCEDURE get_chofer(
        p_id_chofer_transporte IN NUMBER
    ) IS
        r choferes_transporte%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM choferes_transporte
        WHERE id_chofer_transporte = p_id_chofer_transporte;

        DBMS_OUTPUT.PUT_LINE('ID Chofer: ' || r.id_chofer_transporte);
        DBMS_OUTPUT.PUT_LINE('Nombres: ' || r.nombres);
        DBMS_OUTPUT.PUT_LINE('Apellidos: ' || r.apellidos);
        DBMS_OUTPUT.PUT_LINE('Tipo documento: ' || r.tipo_documento);
        DBMS_OUTPUT.PUT_LINE('Número documento: ' || r.numero_documento);
        DBMS_OUTPUT.PUT_LINE('Licencia conducir: ' || r.licencia_conducir);
        DBMS_OUTPUT.PUT_LINE('Categoría licencia: ' || r.categoria_licencia);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento licencia: ' || r.fecha_vencimiento_licencia);
        DBMS_OUTPUT.PUT_LINE('Teléfono: ' || r.telefono);
        DBMS_OUTPUT.PUT_LINE('Email: ' || r.email);
        DBMS_OUTPUT.PUT_LINE('Fecha contratación: ' || r.fecha_contratacion);
        DBMS_OUTPUT.PUT_LINE('Empresa contratante: ' || r.empresa_contratante);
        DBMS_OUTPUT.PUT_LINE('Certificaciones: ' || r.certificaciones);
        DBMS_OUTPUT.PUT_LINE('Idiomas: ' || r.idiomas);
        DBMS_OUTPUT.PUT_LINE('Disponible: ' || r.disponible);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Chofer de transporte no encontrado.');
    END get_chofer;

    PROCEDURE update_chofer(
        p_id_chofer_transporte    IN NUMBER,
        p_nombres                 IN VARCHAR2,
        p_apellidos               IN VARCHAR2,
        p_tipo_documento          IN VARCHAR2,
        p_numero_documento        IN VARCHAR2,
        p_licencia_conducir       IN VARCHAR2,
        p_categoria_licencia      IN VARCHAR2,
        p_fecha_vencimiento_licencia IN DATE,
        p_telefono                IN VARCHAR2,
        p_email                   IN VARCHAR2,
        p_fecha_contratacion      IN DATE,
        p_empresa_contratante     IN VARCHAR2,
        p_certificaciones         IN VARCHAR2,
        p_idiomas                 IN VARCHAR2,
        p_disponible              IN NUMBER,
        p_activo                  IN NUMBER
    ) IS
    BEGIN
        UPDATE choferes_transporte
        SET nombres                 = p_nombres,
            apellidos               = p_apellidos,
            tipo_documento          = p_tipo_documento,
            numero_documento        = p_numero_documento,
            licencia_conducir       = p_licencia_conducir,
            categoria_licencia      = p_categoria_licencia,
            fecha_vencimiento_licencia = p_fecha_vencimiento_licencia,
            telefono                = p_telefono,
            email                   = p_email,
            fecha_contratacion      = p_fecha_contratacion,
            empresa_contratante     = p_empresa_contratante,
            certificaciones         = p_certificaciones,
            idiomas                 = p_idiomas,
            disponible              = p_disponible,
            activo                  = p_activo
        WHERE id_chofer_transporte = p_id_chofer_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34702, 'No se encontró el chofer de transporte para actualizar.');
        END IF;
    END update_chofer;

    PROCEDURE delete_chofer(
        p_id_chofer_transporte IN NUMBER
    ) IS
    BEGIN
        DELETE FROM choferes_transporte
        WHERE id_chofer_transporte = p_id_chofer_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34703, 'No se encontró el chofer de transporte para eliminar.');
        END IF;
    END delete_chofer;

END pkg_choferes_transporte;
/
