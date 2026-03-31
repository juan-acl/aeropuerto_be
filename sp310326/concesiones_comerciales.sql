------------------------------------------------------------
-- Paquete CRUD para la tabla CONCESIONES_COMERCIALES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_concesiones_comerciales AS
    PROCEDURE insert_concesion(
        p_codigo_aeropuerto     IN VARCHAR2,
        p_nombre_comercial      IN VARCHAR2,
        p_tipo_negocio          IN VARCHAR2,
        p_empresa               IN VARCHAR2,
        p_ruc                   IN VARCHAR2,
        p_representante         IN VARCHAR2,
        p_telefono_contacto     IN VARCHAR2,
        p_email_contacto        IN VARCHAR2,
        p_fecha_inicio_concesion IN DATE,
        p_fecha_fin_concesion   IN DATE,
        p_canon_mensual         IN NUMBER,
        p_ubicacion_terminal    IN VARCHAR2,
        p_local_numero          IN VARCHAR2,
        p_area_m2               IN NUMBER,
        p_activo                IN NUMBER DEFAULT 1
    );

    PROCEDURE get_concesion(
        p_id_concesion IN NUMBER
    );

    PROCEDURE update_concesion(
        p_id_concesion          IN NUMBER,
        p_codigo_aeropuerto     IN VARCHAR2,
        p_nombre_comercial      IN VARCHAR2,
        p_tipo_negocio          IN VARCHAR2,
        p_empresa               IN VARCHAR2,
        p_ruc                   IN VARCHAR2,
        p_representante         IN VARCHAR2,
        p_telefono_contacto     IN VARCHAR2,
        p_email_contacto        IN VARCHAR2,
        p_fecha_inicio_concesion IN DATE,
        p_fecha_fin_concesion   IN DATE,
        p_canon_mensual         IN NUMBER,
        p_ubicacion_terminal    IN VARCHAR2,
        p_local_numero          IN VARCHAR2,
        p_area_m2               IN NUMBER,
        p_activo                IN NUMBER
    );

    PROCEDURE delete_concesion(
        p_id_concesion IN NUMBER
    );
END pkg_concesiones_comerciales;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_concesiones_comerciales AS

    PROCEDURE insert_concesion(
        p_codigo_aeropuerto     IN VARCHAR2,
        p_nombre_comercial      IN VARCHAR2,
        p_tipo_negocio          IN VARCHAR2,
        p_empresa               IN VARCHAR2,
        p_ruc                   IN VARCHAR2,
        p_representante         IN VARCHAR2,
        p_telefono_contacto     IN VARCHAR2,
        p_email_contacto        IN VARCHAR2,
        p_fecha_inicio_concesion IN DATE,
        p_fecha_fin_concesion   IN DATE,
        p_canon_mensual         IN NUMBER,
        p_ubicacion_terminal    IN VARCHAR2,
        p_local_numero          IN VARCHAR2,
        p_area_m2               IN NUMBER,
        p_activo                IN NUMBER
    ) IS
    BEGIN
        INSERT INTO concesiones_comerciales (
            codigo_aeropuerto, nombre_comercial, tipo_negocio,
            empresa, ruc, representante, telefono_contacto,
            email_contacto, fecha_inicio_concesion, fecha_fin_concesion,
            canon_mensual, ubicacion_terminal, local_numero,
            area_m2, activo
        ) VALUES (
            p_codigo_aeropuerto, p_nombre_comercial, p_tipo_negocio,
            p_empresa, p_ruc, p_representante, p_telefono_contacto,
            p_email_contacto, p_fecha_inicio_concesion, p_fecha_fin_concesion,
            p_canon_mensual, p_ubicacion_terminal, p_local_numero,
            p_area_m2, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24701, 'Error al insertar concesión comercial: ' || SQLERRM);
    END insert_concesion;

    PROCEDURE get_concesion(
        p_id_concesion IN NUMBER
    ) IS
        r concesiones_comerciales%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM concesiones_comerciales
        WHERE id_concesion = p_id_concesion;

        DBMS_OUTPUT.PUT_LINE('ID Concesión: ' || r.id_concesion);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Nombre comercial: ' || r.nombre_comercial);
        DBMS_OUTPUT.PUT_LINE('Tipo negocio: ' || r.tipo_negocio);
        DBMS_OUTPUT.PUT_LINE('Empresa: ' || r.empresa);
        DBMS_OUTPUT.PUT_LINE('RUC: ' || r.ruc);
        DBMS_OUTPUT.PUT_LINE('Representante: ' || r.representante);
        DBMS_OUTPUT.PUT_LINE('Teléfono: ' || r.telefono_contacto);
        DBMS_OUTPUT.PUT_LINE('Email: ' || r.email_contacto);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio_concesion);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin_concesion);
        DBMS_OUTPUT.PUT_LINE('Canon mensual: ' || r.canon_mensual);
        DBMS_OUTPUT.PUT_LINE('Ubicación terminal: ' || r.ubicacion_terminal);
        DBMS_OUTPUT.PUT_LINE('Local número: ' || r.local_numero);
        DBMS_OUTPUT.PUT_LINE('Área m2: ' || r.area_m2);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Concesión comercial no encontrada.');
    END get_concesion;

    PROCEDURE update_concesion(
        p_id_concesion          IN NUMBER,
        p_codigo_aeropuerto     IN VARCHAR2,
        p_nombre_comercial      IN VARCHAR2,
        p_tipo_negocio          IN VARCHAR2,
        p_empresa               IN VARCHAR2,
        p_ruc                   IN VARCHAR2,
        p_representante         IN VARCHAR2,
        p_telefono_contacto     IN VARCHAR2,
        p_email_contacto        IN VARCHAR2,
        p_fecha_inicio_concesion IN DATE,
        p_fecha_fin_concesion   IN DATE,
        p_canon_mensual         IN NUMBER,
        p_ubicacion_terminal    IN VARCHAR2,
        p_local_numero          IN VARCHAR2,
        p_area_m2               IN NUMBER,
        p_activo                IN NUMBER
    ) IS
    BEGIN
        UPDATE concesiones_comerciales
        SET codigo_aeropuerto     = p_codigo_aeropuerto,
            nombre_comercial      = p_nombre_comercial,
            tipo_negocio          = p_tipo_negocio,
            empresa               = p_empresa,
            ruc                   = p_ruc,
            representante         = p_representante,
            telefono_contacto     = p_telefono_contacto,
            email_contacto        = p_email_contacto,
            fecha_inicio_concesion = p_fecha_inicio_concesion,
            fecha_fin_concesion   = p_fecha_fin_concesion,
            canon_mensual         = p_canon_mensual,
            ubicacion_terminal    = p_ubicacion_terminal,
            local_numero          = p_local_numero,
            area_m2               = p_area_m2,
            activo                = p_activo
        WHERE id_concesion = p_id_concesion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24702, 'No se encontró la concesión comercial para actualizar.');
        END IF;
    END update_concesion;

    PROCEDURE delete_concesion(
        p_id_concesion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM concesiones_comerciales
        WHERE id_concesion = p_id_concesion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24703, 'No se encontró la concesión comercial para eliminar.');
        END IF;
    END delete_concesion;

END pkg_concesiones_comerciales;
/