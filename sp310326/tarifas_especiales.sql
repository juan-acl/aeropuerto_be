------------------------------------------------------------
-- Paquete CRUD para la tabla TARIFAS_ESPECIALES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tarifas_especiales AS
    PROCEDURE insert_tarifa(
        p_id_aerolinea       IN tarifas_especiales.id_aerolinea%TYPE,
        p_nombre_tarifa      IN tarifas_especiales.nombre_tarifa%TYPE,
        p_descripcion        IN tarifas_especiales.descripcion%TYPE,
        p_condiciones        IN tarifas_especiales.condiciones%TYPE,
        p_descuento_porcentaje IN tarifas_especiales.descuento_porcentaje%TYPE,
        p_fecha_inicio       IN tarifas_especiales.fecha_inicio%TYPE,
        p_fecha_fin          IN tarifas_especiales.fecha_fin%TYPE,
        p_activa             IN tarifas_especiales.activa%TYPE DEFAULT 1
    );

    PROCEDURE get_tarifa(
        p_id_tarifa IN tarifas_especiales.id_tarifa%TYPE
    );

    PROCEDURE update_tarifa(
        p_id_tarifa          IN tarifas_especiales.id_tarifa%TYPE,
        p_id_aerolinea       IN tarifas_especiales.id_aerolinea%TYPE,
        p_nombre_tarifa      IN tarifas_especiales.nombre_tarifa%TYPE,
        p_descripcion        IN tarifas_especiales.descripcion%TYPE,
        p_condiciones        IN tarifas_especiales.condiciones%TYPE,
        p_descuento_porcentaje IN tarifas_especiales.descuento_porcentaje%TYPE,
        p_fecha_inicio       IN tarifas_especiales.fecha_inicio%TYPE,
        p_fecha_fin          IN tarifas_especiales.fecha_fin%TYPE,
        p_activa             IN tarifas_especiales.activa%TYPE
    );

    PROCEDURE delete_tarifa(
        p_id_tarifa IN tarifas_especiales.id_tarifa%TYPE
    );
END pkg_tarifas_especiales;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tarifas_especiales AS

    PROCEDURE insert_tarifa(
        p_id_aerolinea       IN tarifas_especiales.id_aerolinea%TYPE,
        p_nombre_tarifa      IN tarifas_especiales.nombre_tarifa%TYPE,
        p_descripcion        IN tarifas_especiales.descripcion%TYPE,
        p_condiciones        IN tarifas_especiales.condiciones%TYPE,
        p_descuento_porcentaje IN tarifas_especiales.descuento_porcentaje%TYPE,
        p_fecha_inicio       IN tarifas_especiales.fecha_inicio%TYPE,
        p_fecha_fin          IN tarifas_especiales.fecha_fin%TYPE,
        p_activa             IN tarifas_especiales.activa%TYPE
    ) IS
    BEGIN
        INSERT INTO tarifas_especiales (
            id_aerolinea, nombre_tarifa, descripcion,
            condiciones, descuento_porcentaje, fecha_inicio,
            fecha_fin, activa
        ) VALUES (
            p_id_aerolinea, p_nombre_tarifa, p_descripcion,
            p_condiciones, p_descuento_porcentaje, p_fecha_inicio,
            p_fecha_fin, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22401, 'Error al insertar tarifa especial: ' || SQLERRM);
    END insert_tarifa;

    PROCEDURE get_tarifa(
        p_id_tarifa IN tarifas_especiales.id_tarifa%TYPE
    ) IS
        r tarifas_especiales%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tarifas_especiales
        WHERE id_tarifa = p_id_tarifa;

        DBMS_OUTPUT.PUT_LINE('ID Tarifa: ' || r.id_tarifa);
        DBMS_OUTPUT.PUT_LINE('Aerolínea: ' || r.id_aerolinea);
        DBMS_OUTPUT.PUT_LINE('Nombre tarifa: ' || r.nombre_tarifa);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Condiciones: ' || r.condiciones);
        DBMS_OUTPUT.PUT_LINE('Descuento %: ' || r.descuento_porcentaje);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Tarifa especial no encontrada.');
    END get_tarifa;

    PROCEDURE update_tarifa(
        p_id_tarifa          IN tarifas_especiales.id_tarifa%TYPE,
        p_id_aerolinea       IN tarifas_especiales.id_aerolinea%TYPE,
        p_nombre_tarifa      IN tarifas_especiales.nombre_tarifa%TYPE,
        p_descripcion        IN tarifas_especiales.descripcion%TYPE,
        p_condiciones        IN tarifas_especiales.condiciones%TYPE,
        p_descuento_porcentaje IN tarifas_especiales.descuento_porcentaje%TYPE,
        p_fecha_inicio       IN tarifas_especiales.fecha_inicio%TYPE,
        p_fecha_fin          IN tarifas_especiales.fecha_fin%TYPE,
        p_activa             IN tarifas_especiales.activa%TYPE
    ) IS
    BEGIN
        UPDATE tarifas_especiales
        SET id_aerolinea       = p_id_aerolinea,
            nombre_tarifa      = p_nombre_tarifa,
            descripcion        = p_descripcion,
            condiciones        = p_condiciones,
            descuento_porcentaje = p_descuento_porcentaje,
            fecha_inicio       = p_fecha_inicio,
            fecha_fin          = p_fecha_fin,
            activa             = p_activa
        WHERE id_tarifa = p_id_tarifa;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22402, 'No se encontró la tarifa especial para actualizar.');
        END IF;
    END update_tarifa;

    PROCEDURE delete_tarifa(
        p_id_tarifa IN tarifas_especiales.id_tarifa%TYPE
    ) IS
    BEGIN
        DELETE FROM tarifas_especiales
        WHERE id_tarifa = p_id_tarifa;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22403, 'No se encontró la tarifa especial para eliminar.');
        END IF;
    END delete_tarifa;

END pkg_tarifas_especiales;
/