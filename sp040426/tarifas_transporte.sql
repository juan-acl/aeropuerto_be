------------------------------------------------------------
-- Paquete CRUD para la tabla TARIFAS_TRANSPORTE_TERRESTRE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tarifas_transporte AS
    PROCEDURE insert_tarifa(
        p_id_ruta_transporte       IN NUMBER,
        p_tipo_tarifa              IN VARCHAR2,
        p_precio_por_persona       IN NUMBER,
        p_precio_vehiculo_privado  IN NUMBER,
        p_precio_maleta_extra      IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_hora_inicio_aplicacion   IN VARCHAR2,
        p_hora_fin_aplicacion      IN VARCHAR2,
        p_dias_aplicacion          IN VARCHAR2,
        p_fecha_inicio_vigencia    IN DATE,
        p_fecha_fin_vigencia       IN DATE,
        p_activa                   IN NUMBER DEFAULT 1
    );

    PROCEDURE get_tarifa(
        p_id_tarifa_transporte IN NUMBER
    );

    PROCEDURE update_tarifa(
        p_id_tarifa_transporte     IN NUMBER,
        p_id_ruta_transporte       IN NUMBER,
        p_tipo_tarifa              IN VARCHAR2,
        p_precio_por_persona       IN NUMBER,
        p_precio_vehiculo_privado  IN NUMBER,
        p_precio_maleta_extra      IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_hora_inicio_aplicacion   IN VARCHAR2,
        p_hora_fin_aplicacion      IN VARCHAR2,
        p_dias_aplicacion          IN VARCHAR2,
        p_fecha_inicio_vigencia    IN DATE,
        p_fecha_fin_vigencia       IN DATE,
        p_activa                   IN NUMBER
    );

    PROCEDURE delete_tarifa(
        p_id_tarifa_transporte IN NUMBER
    );
END pkg_tarifas_transporte;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tarifas_transporte AS

    PROCEDURE insert_tarifa(
        p_id_ruta_transporte       IN NUMBER,
        p_tipo_tarifa              IN VARCHAR2,
        p_precio_por_persona       IN NUMBER,
        p_precio_vehiculo_privado  IN NUMBER,
        p_precio_maleta_extra      IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_hora_inicio_aplicacion   IN VARCHAR2,
        p_hora_fin_aplicacion      IN VARCHAR2,
        p_dias_aplicacion          IN VARCHAR2,
        p_fecha_inicio_vigencia    IN DATE,
        p_fecha_fin_vigencia       IN DATE,
        p_activa                   IN NUMBER
    ) IS
    BEGIN
        INSERT INTO tarifas_transporte_terrestre (
            id_ruta_transporte, tipo_tarifa,
            precio_por_persona, precio_vehiculo_privado, precio_maleta_extra,
            moneda, hora_inicio_aplicacion, hora_fin_aplicacion,
            dias_aplicacion, fecha_inicio_vigencia, fecha_fin_vigencia, activa
        ) VALUES (
            p_id_ruta_transporte, p_tipo_tarifa,
            p_precio_por_persona, p_precio_vehiculo_privado, p_precio_maleta_extra,
            p_moneda, p_hora_inicio_aplicacion, p_hora_fin_aplicacion,
            p_dias_aplicacion, p_fecha_inicio_vigencia, p_fecha_fin_vigencia, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35101, 'Error al insertar tarifa de transporte terrestre: ' || SQLERRM);
    END insert_tarifa;

    PROCEDURE get_tarifa(
        p_id_tarifa_transporte IN NUMBER
    ) IS
        r tarifas_transporte_terrestre%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tarifas_transporte_terrestre
        WHERE id_tarifa_transporte = p_id_tarifa_transporte;

        DBMS_OUTPUT.PUT_LINE('ID Tarifa: ' || r.id_tarifa_transporte);
        DBMS_OUTPUT.PUT_LINE('Ruta: ' || r.id_ruta_transporte);
        DBMS_OUTPUT.PUT_LINE('Tipo tarifa: ' || r.tipo_tarifa);
        DBMS_OUTPUT.PUT_LINE('Precio por persona: ' || r.precio_por_persona);
        DBMS_OUTPUT.PUT_LINE('Precio vehículo privado: ' || r.precio_vehiculo_privado);
        DBMS_OUTPUT.PUT_LINE('Precio maleta extra: ' || r.precio_maleta_extra);
        DBMS_OUTPUT.PUT_LINE('Moneda: ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Hora inicio aplicación: ' || r.hora_inicio_aplicacion);
        DBMS_OUTPUT.PUT_LINE('Hora fin aplicación: ' || r.hora_fin_aplicacion);
        DBMS_OUTPUT.PUT_LINE('Días aplicación: ' || r.dias_aplicacion);
        DBMS_OUTPUT.PUT_LINE('Inicio vigencia: ' || r.fecha_inicio_vigencia);
        DBMS_OUTPUT.PUT_LINE('Fin vigencia: ' || r.fecha_fin_vigencia);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Tarifa de transporte terrestre no encontrada.');
    END get_tarifa;

    PROCEDURE update_tarifa(
        p_id_tarifa_transporte     IN NUMBER,
        p_id_ruta_transporte       IN NUMBER,
        p_tipo_tarifa              IN VARCHAR2,
        p_precio_por_persona       IN NUMBER,
        p_precio_vehiculo_privado  IN NUMBER,
        p_precio_maleta_extra      IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_hora_inicio_aplicacion   IN VARCHAR2,
        p_hora_fin_aplicacion      IN VARCHAR2,
        p_dias_aplicacion          IN VARCHAR2,
        p_fecha_inicio_vigencia    IN DATE,
        p_fecha_fin_vigencia       IN DATE,
        p_activa                   IN NUMBER
    ) IS
    BEGIN
        UPDATE tarifas_transporte_terrestre
        SET id_ruta_transporte       = p_id_ruta_transporte,
            tipo_tarifa              = p_tipo_tarifa,
            precio_por_persona       = p_precio_por_persona,
            precio_vehiculo_privado  = p_precio_vehiculo_privado,
            precio_maleta_extra      = p_precio_maleta_extra,
            moneda                   = p_moneda,
            hora_inicio_aplicacion   = p_hora_inicio_aplicacion,
            hora_fin_aplicacion      = p_hora_fin_aplicacion,
            dias_aplicacion          = p_dias_aplicacion,
            fecha_inicio_vigencia    = p_fecha_inicio_vigencia,
            fecha_fin_vigencia       = p_fecha_fin_vigencia,
            activa                   = p_activa
        WHERE id_tarifa_transporte = p_id_tarifa_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35102, 'No se encontró la tarifa de transporte terrestre para actualizar.');
        END IF;
    END update_tarifa;

    PROCEDURE delete_tarifa(
        p_id_tarifa_transporte IN NUMBER
    ) IS
    BEGIN
        DELETE FROM tarifas_transporte_terrestre
        WHERE id_tarifa_transporte = p_id_tarifa_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35103, 'No se encontró la tarifa de transporte terrestre para eliminar.');
        END IF;
    END delete_tarifa;

END pkg_tarifas_transporte;
/
