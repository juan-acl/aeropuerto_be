------------------------------------------------------------
-- Paquete CRUD para la tabla CONVENIOS_HOTELES_TRANSPORTE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_convenios_hoteles AS
    PROCEDURE insert_convenio(
        p_id_hotel_cercano       IN NUMBER,
        p_id_empresa_transporte  IN NUMBER,
        p_tipo_convenio          IN VARCHAR2,
        p_tarifa_especial        IN NUMBER,
        p_condiciones            IN VARCHAR2,
        p_fecha_inicio           IN DATE,
        p_fecha_fin              IN DATE,
        p_activo                 IN NUMBER DEFAULT 1
    );

    PROCEDURE get_convenio(
        p_id_convenio_hotel IN NUMBER
    );

    PROCEDURE update_convenio(
        p_id_convenio_hotel      IN NUMBER,
        p_id_hotel_cercano       IN NUMBER,
        p_id_empresa_transporte  IN NUMBER,
        p_tipo_convenio          IN VARCHAR2,
        p_tarifa_especial        IN NUMBER,
        p_condiciones            IN VARCHAR2,
        p_fecha_inicio           IN DATE,
        p_fecha_fin              IN DATE,
        p_activo                 IN NUMBER
    );

    PROCEDURE delete_convenio(
        p_id_convenio_hotel IN NUMBER
    );
END pkg_convenios_hoteles;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_convenios_hoteles AS

    PROCEDURE insert_convenio(
        p_id_hotel_cercano       IN NUMBER,
        p_id_empresa_transporte  IN NUMBER,
        p_tipo_convenio          IN VARCHAR2,
        p_tarifa_especial        IN NUMBER,
        p_condiciones            IN VARCHAR2,
        p_fecha_inicio           IN DATE,
        p_fecha_fin              IN DATE,
        p_activo                 IN NUMBER
    ) IS
    BEGIN
        INSERT INTO convenios_hoteles_transporte (
            id_hotel_cercano, id_empresa_transporte, tipo_convenio,
            tarifa_especial, condiciones, fecha_inicio, fecha_fin, activo
        ) VALUES (
            p_id_hotel_cercano, p_id_empresa_transporte, p_tipo_convenio,
            p_tarifa_especial, p_condiciones, p_fecha_inicio, p_fecha_fin, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35301, 'Error al insertar convenio hotel-transporte: ' || SQLERRM);
    END insert_convenio;

    PROCEDURE get_convenio(
        p_id_convenio_hotel IN NUMBER
    ) IS
        r convenios_hoteles_transporte%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM convenios_hoteles_transporte
        WHERE id_convenio_hotel = p_id_convenio_hotel;

        DBMS_OUTPUT.PUT_LINE('ID Convenio: ' || r.id_convenio_hotel);
        DBMS_OUTPUT.PUT_LINE('Hotel cercano: ' || r.id_hotel_cercano);
        DBMS_OUTPUT.PUT_LINE('Empresa transporte: ' || r.id_empresa_transporte);
        DBMS_OUTPUT.PUT_LINE('Tipo convenio: ' || r.tipo_convenio);
        DBMS_OUTPUT.PUT_LINE('Tarifa especial: ' || r.tarifa_especial);
        DBMS_OUTPUT.PUT_LINE('Condiciones: ' || r.condiciones);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Convenio hotel-transporte no encontrado.');
    END get_convenio;

    PROCEDURE update_convenio(
        p_id_convenio_hotel      IN NUMBER,
        p_id_hotel_cercano       IN NUMBER,
        p_id_empresa_transporte  IN NUMBER,
        p_tipo_convenio          IN VARCHAR2,
        p_tarifa_especial        IN NUMBER,
        p_condiciones            IN VARCHAR2,
        p_fecha_inicio           IN DATE,
        p_fecha_fin              IN DATE,
        p_activo                 IN NUMBER
    ) IS
    BEGIN
        UPDATE convenios_hoteles_transporte
        SET id_hotel_cercano       = p_id_hotel_cercano,
            id_empresa_transporte  = p_id_empresa_transporte,
            tipo_convenio          = p_tipo_convenio,
            tarifa_especial        = p_tarifa_especial,
            condiciones            = p_condiciones,
            fecha_inicio           = p_fecha_inicio,
            fecha_fin              = p_fecha_fin,
            activo                 = p_activo
        WHERE id_convenio_hotel = p_id_convenio_hotel;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35302, 'No se encontró el convenio hotel-transporte para actualizar.');
        END IF;
    END update_convenio;

    PROCEDURE delete_convenio(
        p_id_convenio_hotel IN NUMBER
    ) IS
    BEGIN
        DELETE FROM convenios_hoteles_transporte
        WHERE id_convenio_hotel = p_id_convenio_hotel;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35303, 'No se encontró el convenio hotel-transporte para eliminar.');
        END IF;
    END delete_convenio;

END pkg_convenios_hoteles;
/
