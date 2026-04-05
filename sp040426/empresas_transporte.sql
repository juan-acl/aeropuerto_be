------------------------------------------------------------
-- Paquete CRUD para la tabla EMPRESAS_TRANSPORTE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_empresas_transporte AS
    PROCEDURE insert_empresa(
        p_nombre_empresa             IN VARCHAR2,
        p_nit                        IN VARCHAR2,
        p_tipo_empresa               IN VARCHAR2,
        p_telefono_contacto          IN VARCHAR2,
        p_email_contacto             IN VARCHAR2,
        p_website                    IN VARCHAR2,
        p_persona_contacto           IN VARCHAR2,
        p_telefono_emergencia        IN VARCHAR2,
        p_horario_atencion           IN VARCHAR2,
        p_calificacion_promedio      IN NUMBER,
        p_autorizada_aeropuerto      IN NUMBER DEFAULT 1,
        p_fecha_autorizacion         IN DATE,
        p_fecha_vencimiento_autorizacion IN DATE,
        p_activa                     IN NUMBER DEFAULT 1
    );

    PROCEDURE get_empresa(
        p_id_empresa_transporte IN NUMBER
    );

    PROCEDURE update_empresa(
        p_id_empresa_transporte      IN NUMBER,
        p_nombre_empresa             IN VARCHAR2,
        p_nit                        IN VARCHAR2,
        p_tipo_empresa               IN VARCHAR2,
        p_telefono_contacto          IN VARCHAR2,
        p_email_contacto             IN VARCHAR2,
        p_website                    IN VARCHAR2,
        p_persona_contacto           IN VARCHAR2,
        p_telefono_emergencia        IN VARCHAR2,
        p_horario_atencion           IN VARCHAR2,
        p_calificacion_promedio      IN NUMBER,
        p_autorizada_aeropuerto      IN NUMBER,
        p_fecha_autorizacion         IN DATE,
        p_fecha_vencimiento_autorizacion IN DATE,
        p_activa                     IN NUMBER
    );

    PROCEDURE delete_empresa(
        p_id_empresa_transporte IN NUMBER
    );
END pkg_empresas_transporte;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_empresas_transporte AS

    PROCEDURE insert_empresa(
        p_nombre_empresa             IN VARCHAR2,
        p_nit                        IN VARCHAR2,
        p_tipo_empresa               IN VARCHAR2,
        p_telefono_contacto          IN VARCHAR2,
        p_email_contacto             IN VARCHAR2,
        p_website                    IN VARCHAR2,
        p_persona_contacto           IN VARCHAR2,
        p_telefono_emergencia        IN VARCHAR2,
        p_horario_atencion           IN VARCHAR2,
        p_calificacion_promedio      IN NUMBER,
        p_autorizada_aeropuerto      IN NUMBER,
        p_fecha_autorizacion         IN DATE,
        p_fecha_vencimiento_autorizacion IN DATE,
        p_activa                     IN NUMBER
    ) IS
    BEGIN
        INSERT INTO empresas_transporte (
            nombre_empresa, nit, tipo_empresa,
            telefono_contacto, email_contacto, website,
            persona_contacto, telefono_emergencia, horario_atencion,
            calificacion_promedio, autorizada_aeropuerto,
            fecha_autorizacion, fecha_vencimiento_autorizacion, activa
        ) VALUES (
            p_nombre_empresa, p_nit, p_tipo_empresa,
            p_telefono_contacto, p_email_contacto, p_website,
            p_persona_contacto, p_telefono_emergencia, p_horario_atencion,
            p_calificacion_promedio, NVL(p_autorizada_aeropuerto,1),
            p_fecha_autorizacion, p_fecha_vencimiento_autorizacion, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35201, 'Error al insertar empresa de transporte: ' || SQLERRM);
    END insert_empresa;

    PROCEDURE get_empresa(
        p_id_empresa_transporte IN NUMBER
    ) IS
        r empresas_transporte%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM empresas_transporte
        WHERE id_empresa_transporte = p_id_empresa_transporte;

        DBMS_OUTPUT.PUT_LINE('ID Empresa: ' || r.id_empresa_transporte);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_empresa);
        DBMS_OUTPUT.PUT_LINE('NIT: ' || r.nit);
        DBMS_OUTPUT.PUT_LINE('Tipo empresa: ' || r.tipo_empresa);
        DBMS_OUTPUT.PUT_LINE('Teléfono contacto: ' || r.telefono_contacto);
        DBMS_OUTPUT.PUT_LINE('Email contacto: ' || r.email_contacto);
        DBMS_OUTPUT.PUT_LINE('Website: ' || r.website);
        DBMS_OUTPUT.PUT_LINE('Persona contacto: ' || r.persona_contacto);
        DBMS_OUTPUT.PUT_LINE('Teléfono emergencia: ' || r.telefono_emergencia);
        DBMS_OUTPUT.PUT_LINE('Horario atención: ' || r.horario_atencion);
        DBMS_OUTPUT.PUT_LINE('Calificación promedio: ' || r.calificacion_promedio);
        DBMS_OUTPUT.PUT_LINE('Autorizada aeropuerto: ' || r.autorizada_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Fecha autorización: ' || r.fecha_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento autorización: ' || r.fecha_vencimiento_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Empresa de transporte no encontrada.');
    END get_empresa;

    PROCEDURE update_empresa(
        p_id_empresa_transporte      IN NUMBER,
        p_nombre_empresa             IN VARCHAR2,
        p_nit                        IN VARCHAR2,
        p_tipo_empresa               IN VARCHAR2,
        p_telefono_contacto          IN VARCHAR2,
        p_email_contacto             IN VARCHAR2,
        p_website                    IN VARCHAR2,
        p_persona_contacto           IN VARCHAR2,
        p_telefono_emergencia        IN VARCHAR2,
        p_horario_atencion           IN VARCHAR2,
        p_calificacion_promedio      IN NUMBER,
        p_autorizada_aeropuerto      IN NUMBER,
        p_fecha_autorizacion         IN DATE,
        p_fecha_vencimiento_autorizacion IN DATE,
        p_activa                     IN NUMBER
    ) IS
    BEGIN
        UPDATE empresas_transporte
        SET nombre_empresa             = p_nombre_empresa,
            nit                        = p_nit,
            tipo_empresa               = p_tipo_empresa,
            telefono_contacto          = p_telefono_contacto,
            email_contacto             = p_email_contacto,
            website                    = p_website,
            persona_contacto           = p_persona_contacto,
            telefono_emergencia        = p_telefono_emergencia,
            horario_atencion           = p_horario_atencion,
            calificacion_promedio      = p_calificacion_promedio,
            autorizada_aeropuerto      = p_autorizada_aeropuerto,
            fecha_autorizacion         = p_fecha_autorizacion,
            fecha_vencimiento_autorizacion = p_fecha_vencimiento_autorizacion,
            activa                     = p_activa
        WHERE id_empresa_transporte = p_id_empresa_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35202, 'No se encontró la empresa de transporte para actualizar.');
        END IF;
    END update_empresa;

    PROCEDURE delete_empresa(
        p_id_empresa_transporte IN NUMBER
    ) IS
    BEGIN
        DELETE FROM empresas_transporte
        WHERE id_empresa_transporte = p_id_empresa_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35203, 'No se encontró la empresa de transporte para eliminar.');
        END IF;
    END delete_empresa;

END pkg_empresas_transporte;
/
