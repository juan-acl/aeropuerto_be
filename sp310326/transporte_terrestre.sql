------------------------------------------------------------
-- Paquete CRUD para la tabla TRANSPORTE_TERRESTRE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_transporte_terrestre AS
    PROCEDURE insert_transporte(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_tipo_transporte     IN VARCHAR2,
        p_empresa             IN VARCHAR2,
        p_telefono_contacto   IN VARCHAR2,
        p_tarifa_estimada     IN VARCHAR2,
        p_horario_operacion   IN VARCHAR2,
        p_activo              IN NUMBER DEFAULT 1
    );

    PROCEDURE get_transporte(
        p_id_transporte IN NUMBER
    );

    PROCEDURE update_transporte(
        p_id_transporte       IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_tipo_transporte     IN VARCHAR2,
        p_empresa             IN VARCHAR2,
        p_telefono_contacto   IN VARCHAR2,
        p_tarifa_estimada     IN VARCHAR2,
        p_horario_operacion   IN VARCHAR2,
        p_activo              IN NUMBER
    );

    PROCEDURE delete_transporte(
        p_id_transporte IN NUMBER
    );
END pkg_transporte_terrestre;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_transporte_terrestre AS

    PROCEDURE insert_transporte(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_tipo_transporte     IN VARCHAR2,
        p_empresa             IN VARCHAR2,
        p_telefono_contacto   IN VARCHAR2,
        p_tarifa_estimada     IN VARCHAR2,
        p_horario_operacion   IN VARCHAR2,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO transporte_terrestre (
            codigo_aeropuerto, tipo_transporte, empresa,
            telefono_contacto, tarifa_estimada, horario_operacion, activo
        ) VALUES (
            p_codigo_aeropuerto, p_tipo_transporte, p_empresa,
            p_telefono_contacto, p_tarifa_estimada, p_horario_operacion, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25701, 'Error al insertar transporte terrestre: ' || SQLERRM);
    END insert_transporte;

    PROCEDURE get_transporte(
        p_id_transporte IN NUMBER
    ) IS
        r transporte_terrestre%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM transporte_terrestre
        WHERE id_transporte = p_id_transporte;

        DBMS_OUTPUT.PUT_LINE('ID Transporte: ' || r.id_transporte);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Tipo transporte: ' || r.tipo_transporte);
        DBMS_OUTPUT.PUT_LINE('Empresa: ' || r.empresa);
        DBMS_OUTPUT.PUT_LINE('Teléfono: ' || r.telefono_contacto);
        DBMS_OUTPUT.PUT_LINE('Tarifa estimada: ' || r.tarifa_estimada);
        DBMS_OUTPUT.PUT_LINE('Horario operación: ' || r.horario_operacion);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Transporte terrestre no encontrado.');
    END get_transporte;

    PROCEDURE update_transporte(
        p_id_transporte       IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_tipo_transporte     IN VARCHAR2,
        p_empresa             IN VARCHAR2,
        p_telefono_contacto   IN VARCHAR2,
        p_tarifa_estimada     IN VARCHAR2,
        p_horario_operacion   IN VARCHAR2,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        UPDATE transporte_terrestre
        SET codigo_aeropuerto = p_codigo_aeropuerto,
            tipo_transporte   = p_tipo_transporte,
            empresa           = p_empresa,
            telefono_contacto = p_telefono_contacto,
            tarifa_estimada   = p_tarifa_estimada,
            horario_operacion = p_horario_operacion,
            activo            = p_activo
        WHERE id_transporte = p_id_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25702, 'No se encontró el transporte terrestre para actualizar.');
        END IF;
    END update_transporte;

    PROCEDURE delete_transporte(
        p_id_transporte IN NUMBER
    ) IS
    BEGIN
        DELETE FROM transporte_terrestre
        WHERE id_transporte = p_id_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25703, 'No se encontró el transporte terrestre para eliminar.');
        END IF;
    END delete_transporte;

END pkg_transporte_terrestre;
/