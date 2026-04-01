------------------------------------------------------------
-- Paquete CRUD para la tabla SURTIDORES_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_surtidores_combustible AS
    PROCEDURE insert_surtidor(
        p_codigo_surtidor          IN VARCHAR2,
        p_ubicacion                IN VARCHAR2,
        p_tipo_combustible         IN VARCHAR2,
        p_velocidad_carga_litros_hora IN NUMBER,
        p_disponible               IN NUMBER DEFAULT 1,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_operativo                IN NUMBER DEFAULT 1,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE get_surtidor(
        p_id_surtidor IN NUMBER
    );

    PROCEDURE update_surtidor(
        p_id_surtidor              IN NUMBER,
        p_codigo_surtidor          IN VARCHAR2,
        p_ubicacion                IN VARCHAR2,
        p_tipo_combustible         IN VARCHAR2,
        p_velocidad_carga_litros_hora IN NUMBER,
        p_disponible               IN NUMBER,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_operativo                IN NUMBER,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE delete_surtidor(
        p_id_surtidor IN NUMBER
    );
END pkg_surtidores_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_surtidores_combustible AS

    PROCEDURE insert_surtidor(
        p_codigo_surtidor          IN VARCHAR2,
        p_ubicacion                IN VARCHAR2,
        p_tipo_combustible         IN VARCHAR2,
        p_velocidad_carga_litros_hora IN NUMBER,
        p_disponible               IN NUMBER,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_operativo                IN NUMBER,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO surtidores_combustible (
            codigo_surtidor, ubicacion, tipo_combustible,
            velocidad_carga_litros_hora, disponible,
            fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento,
            operativo, observaciones
        ) VALUES (
            p_codigo_surtidor, p_ubicacion, p_tipo_combustible,
            p_velocidad_carga_litros_hora, NVL(p_disponible,1),
            p_fecha_ultimo_mantenimiento, p_fecha_proximo_mantenimiento,
            NVL(p_operativo,1), p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30601, 'Error al insertar surtidor de combustible: ' || SQLERRM);
    END insert_surtidor;

    PROCEDURE get_surtidor(
        p_id_surtidor IN NUMBER
    ) IS
        r surtidores_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM surtidores_combustible
        WHERE id_surtidor = p_id_surtidor;

        DBMS_OUTPUT.PUT_LINE('ID Surtidor: ' || r.id_surtidor);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_surtidor);
        DBMS_OUTPUT.PUT_LINE('Ubicación: ' || r.ubicacion);
        DBMS_OUTPUT.PUT_LINE('Tipo combustible: ' || r.tipo_combustible);
        DBMS_OUTPUT.PUT_LINE('Velocidad carga (L/h): ' || r.velocidad_carga_litros_hora);
        DBMS_OUTPUT.PUT_LINE('Disponible: ' || r.disponible);
        DBMS_OUTPUT.PUT_LINE('Fecha último mantenimiento: ' || r.fecha_ultimo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Fecha próximo mantenimiento: ' || r.fecha_proximo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Operativo: ' || r.operativo);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Surtidor de combustible no encontrado.');
    END get_surtidor;

    PROCEDURE update_surtidor(
        p_id_surtidor              IN NUMBER,
        p_codigo_surtidor          IN VARCHAR2,
        p_ubicacion                IN VARCHAR2,
        p_tipo_combustible         IN VARCHAR2,
        p_velocidad_carga_litros_hora IN NUMBER,
        p_disponible               IN NUMBER,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_operativo                IN NUMBER,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        UPDATE surtidores_combustible
        SET codigo_surtidor          = p_codigo_surtidor,
            ubicacion                = p_ubicacion,
            tipo_combustible         = p_tipo_combustible,
            velocidad_carga_litros_hora = p_velocidad_carga_litros_hora,
            disponible               = p_disponible,
            fecha_ultimo_mantenimiento = p_fecha_ultimo_mantenimiento,
            fecha_proximo_mantenimiento = p_fecha_proximo_mantenimiento,
            operativo                = p_operativo,
            observaciones            = p_observaciones
        WHERE id_surtidor = p_id_surtidor;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30602, 'No se encontró el surtidor de combustible para actualizar.');
        END IF;
    END update_surtidor;

    PROCEDURE delete_surtidor(
        p_id_surtidor IN NUMBER
    ) IS
    BEGIN
        DELETE FROM surtidores_combustible
        WHERE id_surtidor = p_id_surtidor;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30603, 'No se encontró el surtidor de combustible para eliminar.');
        END IF;
    END delete_surtidor;

END pkg_surtidores_combustible;
/
