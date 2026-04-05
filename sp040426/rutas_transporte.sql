------------------------------------------------------------
-- Paquete CRUD para la tabla RUTAS_TRANSPORTE_TERRESTRE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_rutas_transporte AS
    PROCEDURE insert_ruta(
        p_codigo_ruta          IN VARCHAR2,
        p_nombre_ruta          IN VARCHAR2,
        p_origen               IN VARCHAR2,
        p_destino              IN VARCHAR2,
        p_distancia_km         IN NUMBER,
        p_duracion_estimada    IN NUMBER,
        p_tipo_ruta            IN VARCHAR2,
        p_frecuencia_servicio  IN VARCHAR2,
        p_activa               IN NUMBER DEFAULT 1
    );

    PROCEDURE get_ruta(
        p_id_ruta_transporte IN NUMBER
    );

    PROCEDURE update_ruta(
        p_id_ruta_transporte  IN NUMBER,
        p_codigo_ruta         IN VARCHAR2,
        p_nombre_ruta         IN VARCHAR2,
        p_origen              IN VARCHAR2,
        p_destino             IN VARCHAR2,
        p_distancia_km        IN NUMBER,
        p_duracion_estimada   IN NUMBER,
        p_tipo_ruta           IN VARCHAR2,
        p_frecuencia_servicio IN VARCHAR2,
        p_activa              IN NUMBER
    );

    PROCEDURE delete_ruta(
        p_id_ruta_transporte IN NUMBER
    );
END pkg_rutas_transporte;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_rutas_transporte AS

    PROCEDURE insert_ruta(
        p_codigo_ruta          IN VARCHAR2,
        p_nombre_ruta          IN VARCHAR2,
        p_origen               IN VARCHAR2,
        p_destino              IN VARCHAR2,
        p_distancia_km         IN NUMBER,
        p_duracion_estimada    IN NUMBER,
        p_tipo_ruta            IN VARCHAR2,
        p_frecuencia_servicio  IN VARCHAR2,
        p_activa               IN NUMBER
    ) IS
    BEGIN
        INSERT INTO rutas_transporte_terrestre (
            codigo_ruta, nombre_ruta, origen, destino,
            distancia_km, duracion_estimada_minutos,
            tipo_ruta, frecuencia_servicio, activa
        ) VALUES (
            p_codigo_ruta, p_nombre_ruta, p_origen, p_destino,
            p_distancia_km, p_duracion_estimada,
            p_tipo_ruta, p_frecuencia_servicio, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34501, 'Error al insertar ruta de transporte terrestre: ' || SQLERRM);
    END insert_ruta;

    PROCEDURE get_ruta(
        p_id_ruta_transporte IN NUMBER
    ) IS
        r rutas_transporte_terrestre%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM rutas_transporte_terrestre
        WHERE id_ruta_transporte = p_id_ruta_transporte;

        DBMS_OUTPUT.PUT_LINE('ID Ruta: ' || r.id_ruta_transporte);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_ruta);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_ruta);
        DBMS_OUTPUT.PUT_LINE('Origen: ' || r.origen);
        DBMS_OUTPUT.PUT_LINE('Destino: ' || r.destino);
        DBMS_OUTPUT.PUT_LINE('Distancia (km): ' || r.distancia_km);
        DBMS_OUTPUT.PUT_LINE('Duración estimada (min): ' || r.duracion_estimada_minutos);
        DBMS_OUTPUT.PUT_LINE('Tipo ruta: ' || r.tipo_ruta);
        DBMS_OUTPUT.PUT_LINE('Frecuencia servicio: ' || r.frecuencia_servicio);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Ruta de transporte terrestre no encontrada.');
    END get_ruta;

    PROCEDURE update_ruta(
        p_id_ruta_transporte  IN NUMBER,
        p_codigo_ruta         IN VARCHAR2,
        p_nombre_ruta         IN VARCHAR2,
        p_origen              IN VARCHAR2,
        p_destino             IN VARCHAR2,
        p_distancia_km        IN NUMBER,
        p_duracion_estimada   IN NUMBER,
        p_tipo_ruta           IN VARCHAR2,
        p_frecuencia_servicio IN VARCHAR2,
        p_activa              IN NUMBER
    ) IS
    BEGIN
        UPDATE rutas_transporte_terrestre
        SET codigo_ruta         = p_codigo_ruta,
            nombre_ruta         = p_nombre_ruta,
            origen              = p_origen,
            destino             = p_destino,
            distancia_km        = p_distancia_km,
            duracion_estimada_minutos = p_duracion_estimada,
            tipo_ruta           = p_tipo_ruta,
            frecuencia_servicio = p_frecuencia_servicio,
            activa              = p_activa
        WHERE id_ruta_transporte = p_id_ruta_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34502, 'No se encontró la ruta de transporte terrestre para actualizar.');
        END IF;
    END update_ruta;

    PROCEDURE delete_ruta(
        p_id_ruta_transporte IN NUMBER
    ) IS
    BEGIN
        DELETE FROM rutas_transporte_terrestre
        WHERE id_ruta_transporte = p_id_ruta_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34503, 'No se encontró la ruta de transporte terrestre para eliminar.');
        END IF;
    END delete_ruta;

END pkg_rutas_transporte;
/
