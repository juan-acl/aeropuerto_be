------------------------------------------------------------
-- Paquete CRUD para la tabla HOTELES_CERCANOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_hoteles_cercanos AS
    PROCEDURE insert_hotel(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_nombre_hotel        IN VARCHAR2,
        p_categoria           IN VARCHAR2,
        p_direccion           IN VARCHAR2,
        p_distancia_km        IN NUMBER,
        p_telefono            IN VARCHAR2,
        p_email               IN VARCHAR2,
        p_website             IN VARCHAR2,
        p_tarifa_noche_desde  IN NUMBER,
        p_tiene_shuttle       IN NUMBER DEFAULT 0,
        p_activo              IN NUMBER DEFAULT 1
    );

    PROCEDURE get_hotel(
        p_id_hotel IN NUMBER
    );

    PROCEDURE update_hotel(
        p_id_hotel            IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_nombre_hotel        IN VARCHAR2,
        p_categoria           IN VARCHAR2,
        p_direccion           IN VARCHAR2,
        p_distancia_km        IN NUMBER,
        p_telefono            IN VARCHAR2,
        p_email               IN VARCHAR2,
        p_website             IN VARCHAR2,
        p_tarifa_noche_desde  IN NUMBER,
        p_tiene_shuttle       IN NUMBER,
        p_activo              IN NUMBER
    );

    PROCEDURE delete_hotel(
        p_id_hotel IN NUMBER
    );
END pkg_hoteles_cercanos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_hoteles_cercanos AS

    PROCEDURE insert_hotel(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_nombre_hotel        IN VARCHAR2,
        p_categoria           IN VARCHAR2,
        p_direccion           IN VARCHAR2,
        p_distancia_km        IN NUMBER,
        p_telefono            IN VARCHAR2,
        p_email               IN VARCHAR2,
        p_website             IN VARCHAR2,
        p_tarifa_noche_desde  IN NUMBER,
        p_tiene_shuttle       IN NUMBER,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO hoteles_cercanos (
            codigo_aeropuerto, nombre_hotel, categoria, direccion,
            distancia_km, telefono, email, website,
            tarifa_noche_desde, tiene_shuttle, activo
        ) VALUES (
            p_codigo_aeropuerto, p_nombre_hotel, p_categoria, p_direccion,
            p_distancia_km, p_telefono, p_email, p_website,
            p_tarifa_noche_desde, NVL(p_tiene_shuttle,0), NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25801, 'Error al insertar hotel cercano: ' || SQLERRM);
    END insert_hotel;

    PROCEDURE get_hotel(
        p_id_hotel IN NUMBER
    ) IS
        r hoteles_cercanos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM hoteles_cercanos
        WHERE id_hotel = p_id_hotel;

        DBMS_OUTPUT.PUT_LINE('ID Hotel: ' || r.id_hotel);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_hotel);
        DBMS_OUTPUT.PUT_LINE('Categoría: ' || r.categoria);
        DBMS_OUTPUT.PUT_LINE('Dirección: ' || r.direccion);
        DBMS_OUTPUT.PUT_LINE('Distancia (km): ' || r.distancia_km);
        DBMS_OUTPUT.PUT_LINE('Teléfono: ' || r.telefono);
        DBMS_OUTPUT.PUT_LINE('Email: ' || r.email);
        DBMS_OUTPUT.PUT_LINE('Website: ' || r.website);
        DBMS_OUTPUT.PUT_LINE('Tarifa desde: ' || r.tarifa_noche_desde);
        DBMS_OUTPUT.PUT_LINE('Shuttle: ' || r.tiene_shuttle);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Hotel cercano no encontrado.');
    END get_hotel;

    PROCEDURE update_hotel(
        p_id_hotel            IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_nombre_hotel        IN VARCHAR2,
        p_categoria           IN VARCHAR2,
        p_direccion           IN VARCHAR2,
        p_distancia_km        IN NUMBER,
        p_telefono            IN VARCHAR2,
        p_email               IN VARCHAR2,
        p_website             IN VARCHAR2,
        p_tarifa_noche_desde  IN NUMBER,
        p_tiene_shuttle       IN NUMBER,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        UPDATE hoteles_cercanos
        SET codigo_aeropuerto  = p_codigo_aeropuerto,
            nombre_hotel       = p_nombre_hotel,
            categoria          = p_categoria,
            direccion          = p_direccion,
            distancia_km       = p_distancia_km,
            telefono           = p_telefono,
            email              = p_email,
            website            = p_website,
            tarifa_noche_desde = p_tarifa_noche_desde,
            tiene_shuttle      = p_tiene_shuttle,
            activo             = p_activo
        WHERE id_hotel = p_id_hotel;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25802, 'No se encontró el hotel cercano para actualizar.');
        END IF;
    END update_hotel;

    PROCEDURE delete_hotel(
        p_id_hotel IN NUMBER
    ) IS
    BEGIN
        DELETE FROM hoteles_cercanos
        WHERE id_hotel = p_id_hotel;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25803, 'No se encontró el hotel cercano para eliminar.');
        END IF;
    END delete_hotel;

END pkg_hoteles_cercanos;
/