------------------------------------------------------------
-- Paquete CRUD para la tabla PUNTOS_ENCUENTRO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_puntos_encuentro AS
    PROCEDURE insert_punto(
        p_codigo_punto          IN VARCHAR2,
        p_nombre                IN VARCHAR2,
        p_ubicacion             IN VARCHAR2,
        p_coordenada_latitud    IN NUMBER,
        p_coordenada_longitud   IN NUMBER,
        p_capacidad_personas    IN NUMBER,
        p_senalizacion_visible  IN NUMBER DEFAULT 1,
        p_iluminacion           IN NUMBER DEFAULT 1,
        p_recursos_disponibles  IN VARCHAR2,
        p_responsable_asignado  IN VARCHAR2,
        p_activo                IN NUMBER DEFAULT 1
    );

    PROCEDURE get_punto(
        p_id_punto_encuentro IN NUMBER
    );

    PROCEDURE update_punto(
        p_id_punto_encuentro   IN NUMBER,
        p_codigo_punto         IN VARCHAR2,
        p_nombre               IN VARCHAR2,
        p_ubicacion            IN VARCHAR2,
        p_coordenada_latitud   IN NUMBER,
        p_coordenada_longitud  IN NUMBER,
        p_capacidad_personas   IN NUMBER,
        p_senalizacion_visible IN NUMBER,
        p_iluminacion          IN NUMBER,
        p_recursos_disponibles IN VARCHAR2,
        p_responsable_asignado IN VARCHAR2,
        p_activo               IN NUMBER
    );

    PROCEDURE delete_punto(
        p_id_punto_encuentro IN NUMBER
    );
END pkg_puntos_encuentro;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_puntos_encuentro AS

    PROCEDURE insert_punto(
        p_codigo_punto          IN VARCHAR2,
        p_nombre                IN VARCHAR2,
        p_ubicacion             IN VARCHAR2,
        p_coordenada_latitud    IN NUMBER,
        p_coordenada_longitud   IN NUMBER,
        p_capacidad_personas    IN NUMBER,
        p_senalizacion_visible  IN NUMBER,
        p_iluminacion           IN NUMBER,
        p_recursos_disponibles  IN VARCHAR2,
        p_responsable_asignado  IN VARCHAR2,
        p_activo                IN NUMBER
    ) IS
    BEGIN
        INSERT INTO puntos_encuentro (
            codigo_punto, nombre, ubicacion,
            coordenada_latitud, coordenada_longitud,
            capacidad_personas, senalizacion_visible,
            iluminacion, recursos_disponibles,
            responsable_asignado, activo
        ) VALUES (
            p_codigo_punto, p_nombre, p_ubicacion,
            p_coordenada_latitud, p_coordenada_longitud,
            p_capacidad_personas, NVL(p_senalizacion_visible,1),
            NVL(p_iluminacion,1), p_recursos_disponibles,
            p_responsable_asignado, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36001, 'Error al insertar punto de encuentro: ' || SQLERRM);
    END insert_punto;

    PROCEDURE get_punto(
        p_id_punto_encuentro IN NUMBER
    ) IS
        r puntos_encuentro%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM puntos_encuentro
        WHERE id_punto_encuentro = p_id_punto_encuentro;

        DBMS_OUTPUT.PUT_LINE('ID Punto: ' || r.id_punto_encuentro);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_punto);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre);
        DBMS_OUTPUT.PUT_LINE('Ubicación: ' || r.ubicacion);
        DBMS_OUTPUT.PUT_LINE('Latitud: ' || r.coordenada_latitud);
        DBMS_OUTPUT.PUT_LINE('Longitud: ' || r.coordenada_longitud);
        DBMS_OUTPUT.PUT_LINE('Capacidad personas: ' || r.capacidad_personas);
        DBMS_OUTPUT.PUT_LINE('Señalización visible: ' || r.senalizacion_visible);
        DBMS_OUTPUT.PUT_LINE('Iluminación: ' || r.iluminacion);
        DBMS_OUTPUT.PUT_LINE('Recursos disponibles: ' || r.recursos_disponibles);
        DBMS_OUTPUT.PUT_LINE('Responsable asignado: ' || r.responsable_asignado);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Punto de encuentro no encontrado.');
    END get_punto;

    PROCEDURE update_punto(
        p_id_punto_encuentro   IN NUMBER,
        p_codigo_punto         IN VARCHAR2,
        p_nombre               IN VARCHAR2,
        p_ubicacion            IN VARCHAR2,
        p_coordenada_latitud   IN NUMBER,
        p_coordenada_longitud  IN NUMBER,
        p_capacidad_personas   IN NUMBER,
        p_senalizacion_visible IN NUMBER,
        p_iluminacion          IN NUMBER,
        p_recursos_disponibles IN VARCHAR2,
        p_responsable_asignado IN VARCHAR2,
        p_activo               IN NUMBER
    ) IS
    BEGIN
        UPDATE puntos_encuentro
        SET codigo_punto         = p_codigo_punto,
            nombre               = p_nombre,
            ubicacion            = p_ubicacion,
            coordenada_latitud   = p_coordenada_latitud,
            coordenada_longitud  = p_coordenada_longitud,
            capacidad_personas   = p_capacidad_personas,
            senalizacion_visible = p_senalizacion_visible,
            iluminacion          = p_iluminacion,
            recursos_disponibles = p_recursos_disponibles,
            responsable_asignado = p_responsable_asignado,
            activo               = p_activo
        WHERE id_punto_encuentro = p_id_punto_encuentro;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36002, 'No se encontró el punto de encuentro para actualizar.');
        END IF;
    END update_punto;

    PROCEDURE delete_punto(
        p_id_punto_encuentro IN NUMBER
    ) IS
    BEGIN
        DELETE FROM puntos_encuentro
        WHERE id_punto_encuentro = p_id_punto_encuentro;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36003, 'No se encontró el punto de encuentro para eliminar.');
        END IF;
    END delete_punto;

END pkg_puntos_encuentro;
/
