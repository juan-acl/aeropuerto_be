------------------------------------------------------------
-- Paquete CRUD para la tabla TEMPORADAS_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_temporadas_vuelo AS
    PROCEDURE insert_temporada(
        p_nombre_temporada IN temporadas_vuelo.nombre_temporada%TYPE,
        p_fecha_inicio     IN temporadas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin        IN temporadas_vuelo.fecha_fin%TYPE,
        p_factor_demanda   IN temporadas_vuelo.factor_demanda%TYPE,
        p_activa           IN temporadas_vuelo.activa%TYPE DEFAULT 1
    );

    PROCEDURE get_temporada(
        p_id_temporada IN temporadas_vuelo.id_temporada%TYPE
    );

    PROCEDURE update_temporada(
        p_id_temporada   IN temporadas_vuelo.id_temporada%TYPE,
        p_nombre_temporada IN temporadas_vuelo.nombre_temporada%TYPE,
        p_fecha_inicio     IN temporadas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin        IN temporadas_vuelo.fecha_fin%TYPE,
        p_factor_demanda   IN temporadas_vuelo.factor_demanda%TYPE,
        p_activa           IN temporadas_vuelo.activa%TYPE
    );

    PROCEDURE delete_temporada(
        p_id_temporada IN temporadas_vuelo.id_temporada%TYPE
    );
END pkg_temporadas_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_temporadas_vuelo AS

    PROCEDURE insert_temporada(
        p_nombre_temporada IN temporadas_vuelo.nombre_temporada%TYPE,
        p_fecha_inicio     IN temporadas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin        IN temporadas_vuelo.fecha_fin%TYPE,
        p_factor_demanda   IN temporadas_vuelo.factor_demanda%TYPE,
        p_activa           IN temporadas_vuelo.activa%TYPE
    ) IS
    BEGIN
        INSERT INTO temporadas_vuelo (
            nombre_temporada, fecha_inicio, fecha_fin,
            factor_demanda, activa
        ) VALUES (
            p_nombre_temporada, p_fecha_inicio, p_fecha_fin,
            p_factor_demanda, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20301, 'Error al insertar temporada: ' || SQLERRM);
    END insert_temporada;

    PROCEDURE get_temporada(
        p_id_temporada IN temporadas_vuelo.id_temporada%TYPE
    ) IS
        r temporadas_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM temporadas_vuelo
        WHERE id_temporada = p_id_temporada;

        DBMS_OUTPUT.PUT_LINE('ID Temporada: ' || r.id_temporada);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_temporada);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Factor demanda: ' || r.factor_demanda);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Temporada no encontrada.');
    END get_temporada;

    PROCEDURE update_temporada(
        p_id_temporada   IN temporadas_vuelo.id_temporada%TYPE,
        p_nombre_temporada IN temporadas_vuelo.nombre_temporada%TYPE,
        p_fecha_inicio     IN temporadas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin        IN temporadas_vuelo.fecha_fin%TYPE,
        p_factor_demanda   IN temporadas_vuelo.factor_demanda%TYPE,
        p_activa           IN temporadas_vuelo.activa%TYPE
    ) IS
    BEGIN
        UPDATE temporadas_vuelo
        SET nombre_temporada = p_nombre_temporada,
            fecha_inicio     = p_fecha_inicio,
            fecha_fin        = p_fecha_fin,
            factor_demanda   = p_factor_demanda,
            activa           = p_activa
        WHERE id_temporada = p_id_temporada;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20302, 'No se encontró la temporada para actualizar.');
        END IF;
    END update_temporada;

    PROCEDURE delete_temporada(
        p_id_temporada IN temporadas_vuelo.id_temporada%TYPE
    ) IS
    BEGIN
        DELETE FROM temporadas_vuelo
        WHERE id_temporada = p_id_temporada;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20303, 'No se encontró la temporada para eliminar.');
        END IF;
    END delete_temporada;

END pkg_temporadas_vuelo;
/