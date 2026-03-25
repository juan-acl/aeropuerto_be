------------------------------------------------------------
-- Paquete CRUD para la tabla PERFILES_VIAJERO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_perfiles_viajero AS
    PROCEDURE insert_perfil(
        p_id_pasajero        IN perfiles_viajero.id_pasajero%TYPE,
        p_tipo_perfil        IN perfiles_viajero.tipo_perfil%TYPE,
        p_numero_programa    IN perfiles_viajero.numero_programa%TYPE,
        p_aerolinea_asociada IN perfiles_viajero.aerolinea_asociada%TYPE,
        p_puntos_acumulados  IN perfiles_viajero.puntos_acumulados%TYPE DEFAULT 0,
        p_categoria          IN perfiles_viajero.categoria%TYPE,
        p_fecha_ingreso      IN perfiles_viajero.fecha_ingreso%TYPE,
        p_fecha_ultima_actividad IN perfiles_viajero.fecha_ultima_actividad%TYPE
    );

    PROCEDURE get_perfil(
        p_id_perfil IN perfiles_viajero.id_perfil%TYPE
    );

    PROCEDURE update_perfil(
        p_id_perfil          IN perfiles_viajero.id_perfil%TYPE,
        p_id_pasajero        IN perfiles_viajero.id_pasajero%TYPE,
        p_tipo_perfil        IN perfiles_viajero.tipo_perfil%TYPE,
        p_numero_programa    IN perfiles_viajero.numero_programa%TYPE,
        p_aerolinea_asociada IN perfiles_viajero.aerolinea_asociada%TYPE,
        p_puntos_acumulados  IN perfiles_viajero.puntos_acumulados%TYPE,
        p_categoria          IN perfiles_viajero.categoria%TYPE,
        p_fecha_ingreso      IN perfiles_viajero.fecha_ingreso%TYPE,
        p_fecha_ultima_actividad IN perfiles_viajero.fecha_ultima_actividad%TYPE
    );

    PROCEDURE delete_perfil(
        p_id_perfil IN perfiles_viajero.id_perfil%TYPE
    );
END pkg_perfiles_viajero;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_perfiles_viajero AS

    PROCEDURE insert_perfil(
        p_id_pasajero        IN perfiles_viajero.id_pasajero%TYPE,
        p_tipo_perfil        IN perfiles_viajero.tipo_perfil%TYPE,
        p_numero_programa    IN perfiles_viajero.numero_programa%TYPE,
        p_aerolinea_asociada IN perfiles_viajero.aerolinea_asociada%TYPE,
        p_puntos_acumulados  IN perfiles_viajero.puntos_acumulados%TYPE,
        p_categoria          IN perfiles_viajero.categoria%TYPE,
        p_fecha_ingreso      IN perfiles_viajero.fecha_ingreso%TYPE,
        p_fecha_ultima_actividad IN perfiles_viajero.fecha_ultima_actividad%TYPE
    ) IS
    BEGIN
        INSERT INTO perfiles_viajero (
            id_pasajero, tipo_perfil, numero_programa,
            aerolinea_asociada, puntos_acumulados, categoria,
            fecha_ingreso, fecha_ultima_actividad
        ) VALUES (
            p_id_pasajero, p_tipo_perfil, p_numero_programa,
            p_aerolinea_asociada, NVL(p_puntos_acumulados,0), p_categoria,
            p_fecha_ingreso, p_fecha_ultima_actividad
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21801, 'Error al insertar perfil: ' || SQLERRM);
    END insert_perfil;

    PROCEDURE get_perfil(
        p_id_perfil IN perfiles_viajero.id_perfil%TYPE
    ) IS
        r perfiles_viajero%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM perfiles_viajero
        WHERE id_perfil = p_id_perfil;

        DBMS_OUTPUT.PUT_LINE('ID Perfil: ' || r.id_perfil);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Tipo perfil: ' || r.tipo_perfil);
        DBMS_OUTPUT.PUT_LINE('Número programa: ' || r.numero_programa);
        DBMS_OUTPUT.PUT_LINE('Aerolínea asociada: ' || r.aerolinea_asociada);
        DBMS_OUTPUT.PUT_LINE('Puntos acumulados: ' || r.puntos_acumulados);
        DBMS_OUTPUT.PUT_LINE('Categoría: ' || r.categoria);
        DBMS_OUTPUT.PUT_LINE('Fecha ingreso: ' || r.fecha_ingreso);
        DBMS_OUTPUT.PUT_LINE('Última actividad: ' || r.fecha_ultima_actividad);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Perfil no encontrado.');
    END get_perfil;

    PROCEDURE update_perfil(
        p_id_perfil          IN perfiles_viajero.id_perfil%TYPE,
        p_id_pasajero        IN perfiles_viajero.id_pasajero%TYPE,
        p_tipo_perfil        IN perfiles_viajero.tipo_perfil%TYPE,
        p_numero_programa    IN perfiles_viajero.numero_programa%TYPE,
        p_aerolinea_asociada IN perfiles_viajero.aerolinea_asociada%TYPE,
        p_puntos_acumulados  IN perfiles_viajero.puntos_acumulados%TYPE,
        p_categoria          IN perfiles_viajero.categoria%TYPE,
        p_fecha_ingreso      IN perfiles_viajero.fecha_ingreso%TYPE,
        p_fecha_ultima_actividad IN perfiles_viajero.fecha_ultima_actividad%TYPE
    ) IS
    BEGIN
        UPDATE perfiles_viajero
        SET id_pasajero        = p_id_pasajero,
            tipo_perfil        = p_tipo_perfil,
            numero_programa    = p_numero_programa,
            aerolinea_asociada = p_aerolinea_asociada,
            puntos_acumulados  = p_puntos_acumulados,
            categoria          = p_categoria,
            fecha_ingreso      = p_fecha_ingreso,
            fecha_ultima_actividad = p_fecha_ultima_actividad
        WHERE id_perfil = p_id_perfil;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21802, 'No se encontró el perfil para actualizar.');
        END IF;
    END update_perfil;

    PROCEDURE delete_perfil(
        p_id_perfil IN perfiles_viajero.id_perfil%TYPE
    ) IS
    BEGIN
        DELETE FROM perfiles_viajero
        WHERE id_perfil = p_id_perfil;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21803, 'No se encontró el perfil para eliminar.');
        END IF;
    END delete_perfil;

END pkg_perfiles_viajero;
/