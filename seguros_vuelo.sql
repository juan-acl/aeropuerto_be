------------------------------------------------------------
-- Paquete CRUD para la tabla SEGUROS_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_seguros_vuelo AS
    PROCEDURE insert_seguro(
        p_id_vuelo       IN seguros_vuelo.id_vuelo%TYPE,
        p_id_aerolinea   IN seguros_vuelo.id_aerolinea%TYPE,
        p_tipo_seguro    IN seguros_vuelo.tipo_seguro%TYPE,
        p_poliza         IN seguros_vuelo.poliza%TYPE,
        p_aseguradora    IN seguros_vuelo.aseguradora%TYPE,
        p_cobertura_max  IN seguros_vuelo.cobertura_maxima%TYPE,
        p_fecha_inicio   IN seguros_vuelo.fecha_inicio%TYPE,
        p_fecha_fin      IN seguros_vuelo.fecha_fin%TYPE,
        p_prima          IN seguros_vuelo.prima%TYPE
    );

    PROCEDURE get_seguro(
        p_id_seguro IN seguros_vuelo.id_seguro%TYPE
    );

    PROCEDURE update_seguro(
        p_id_seguro     IN seguros_vuelo.id_seguro%TYPE,
        p_id_vuelo      IN seguros_vuelo.id_vuelo%TYPE,
        p_id_aerolinea  IN seguros_vuelo.id_aerolinea%TYPE,
        p_tipo_seguro   IN seguros_vuelo.tipo_seguro%TYPE,
        p_poliza        IN seguros_vuelo.poliza%TYPE,
        p_aseguradora   IN seguros_vuelo.aseguradora%TYPE,
        p_cobertura_max IN seguros_vuelo.cobertura_maxima%TYPE,
        p_fecha_inicio  IN seguros_vuelo.fecha_inicio%TYPE,
        p_fecha_fin     IN seguros_vuelo.fecha_fin%TYPE,
        p_prima         IN seguros_vuelo.prima%TYPE
    );

    PROCEDURE delete_seguro(
        p_id_seguro IN seguros_vuelo.id_seguro%TYPE
    );
END pkg_seguros_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_seguros_vuelo AS

    PROCEDURE insert_seguro(
        p_id_vuelo       IN seguros_vuelo.id_vuelo%TYPE,
        p_id_aerolinea   IN seguros_vuelo.id_aerolinea%TYPE,
        p_tipo_seguro    IN seguros_vuelo.tipo_seguro%TYPE,
        p_poliza         IN seguros_vuelo.poliza%TYPE,
        p_aseguradora    IN seguros_vuelo.aseguradora%TYPE,
        p_cobertura_max  IN seguros_vuelo.cobertura_maxima%TYPE,
        p_fecha_inicio   IN seguros_vuelo.fecha_inicio%TYPE,
        p_fecha_fin      IN seguros_vuelo.fecha_fin%TYPE,
        p_prima          IN seguros_vuelo.prima%TYPE
    ) IS
    BEGIN
        INSERT INTO seguros_vuelo (
            id_vuelo, id_aerolinea, tipo_seguro, poliza,
            aseguradora, cobertura_maxima, fecha_inicio,
            fecha_fin, prima
        ) VALUES (
            p_id_vuelo, p_id_aerolinea, p_tipo_seguro, p_poliza,
            p_aseguradora, p_cobertura_max, p_fecha_inicio,
            p_fecha_fin, p_prima
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21301, 'Error al insertar seguro: ' || SQLERRM);
    END insert_seguro;

    PROCEDURE get_seguro(
        p_id_seguro IN seguros_vuelo.id_seguro%TYPE
    ) IS
        r seguros_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM seguros_vuelo
        WHERE id_seguro = p_id_seguro;

        DBMS_OUTPUT.PUT_LINE('ID Seguro: ' || r.id_seguro);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Aerolínea: ' || r.id_aerolinea);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_seguro);
        DBMS_OUTPUT.PUT_LINE('Póliza: ' || r.poliza);
        DBMS_OUTPUT.PUT_LINE('Aseguradora: ' || r.aseguradora);
        DBMS_OUTPUT.PUT_LINE('Cobertura máxima: ' || r.cobertura_maxima);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Prima: ' || r.prima);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Seguro no encontrado.');
    END get_seguro;

    PROCEDURE update_seguro(
        p_id_seguro     IN seguros_vuelo.id_seguro%TYPE,
        p_id_vuelo      IN seguros_vuelo.id_vuelo%TYPE,
        p_id_aerolinea  IN seguros_vuelo.id_aerolinea%TYPE,
        p_tipo_seguro   IN seguros_vuelo.tipo_seguro%TYPE,
        p_poliza        IN seguros_vuelo.poliza%TYPE,
        p_aseguradora   IN seguros_vuelo.aseguradora%TYPE,
        p_cobertura_max IN seguros_vuelo.cobertura_maxima%TYPE,
        p_fecha_inicio  IN seguros_vuelo.fecha_inicio%TYPE,
        p_fecha_fin     IN seguros_vuelo.fecha_fin%TYPE,
        p_prima         IN seguros_vuelo.prima%TYPE
    ) IS
    BEGIN
        UPDATE seguros_vuelo
        SET id_vuelo       = p_id_vuelo,
            id_aerolinea   = p_id_aerolinea,
            tipo_seguro    = p_tipo_seguro,
            poliza         = p_poliza,
            aseguradora    = p_aseguradora,
            cobertura_maxima = p_cobertura_max,
            fecha_inicio   = p_fecha_inicio,
            fecha_fin      = p_fecha_fin,
            prima          = p_prima
        WHERE id_seguro = p_id_seguro;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21302, 'No se encontró el seguro para actualizar.');
        END IF;
    END update_seguro;

    PROCEDURE delete_seguro(
        p_id_seguro IN seguros_vuelo.id_seguro%TYPE
    ) IS
    BEGIN
        DELETE FROM seguros_vuelo
        WHERE id_seguro = p_id_seguro;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21303, 'No se encontró el seguro para eliminar.');
        END IF;
    END delete_seguro;

END pkg_seguros_vuelo;
/