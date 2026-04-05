------------------------------------------------------------
-- Paquete CRUD para la tabla SERIES_VUELO_ASIGNADAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_series_vuelo AS
    PROCEDURE insert_serie(
        p_id_pais_oaci          IN NUMBER,
        p_id_aerolinea          IN NUMBER,
        p_rango_numeros_inicio  IN VARCHAR2,
        p_rango_numeros_fin     IN VARCHAR2,
        p_fecha_asignacion      IN DATE DEFAULT SYSDATE,
        p_fecha_vencimiento     IN DATE,
        p_activa                IN NUMBER DEFAULT 1,
        p_documento_asignacion  IN BLOB
    );

    PROCEDURE get_serie(
        p_id_serie_vuelo IN NUMBER
    );

    PROCEDURE update_serie(
        p_id_serie_vuelo        IN NUMBER,
        p_id_pais_oaci          IN NUMBER,
        p_id_aerolinea          IN NUMBER,
        p_rango_numeros_inicio  IN VARCHAR2,
        p_rango_numeros_fin     IN VARCHAR2,
        p_fecha_asignacion      IN DATE,
        p_fecha_vencimiento     IN DATE,
        p_activa                IN NUMBER,
        p_documento_asignacion  IN BLOB
    );

    PROCEDURE delete_serie(
        p_id_serie_vuelo IN NUMBER
    );
END pkg_series_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_series_vuelo AS

    PROCEDURE insert_serie(
        p_id_pais_oaci          IN NUMBER,
        p_id_aerolinea          IN NUMBER,
        p_rango_numeros_inicio  IN VARCHAR2,
        p_rango_numeros_fin     IN VARCHAR2,
        p_fecha_asignacion      IN DATE,
        p_fecha_vencimiento     IN DATE,
        p_activa                IN NUMBER,
        p_documento_asignacion  IN BLOB
    ) IS
    BEGIN
        INSERT INTO series_vuelo_asignadas (
            id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin,
            fecha_asignacion, fecha_vencimiento, activa, documento_asignacion
        ) VALUES (
            p_id_pais_oaci, p_id_aerolinea, p_rango_numeros_inicio, p_rango_numeros_fin,
            NVL(p_fecha_asignacion, SYSDATE), p_fecha_vencimiento, NVL(p_activa,1), p_documento_asignacion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36401, 'Error al insertar serie de vuelo asignada: ' || SQLERRM);
    END insert_serie;

    PROCEDURE get_serie(
        p_id_serie_vuelo IN NUMBER
    ) IS
        r series_vuelo_asignadas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM series_vuelo_asignadas
        WHERE id_serie_vuelo = p_id_serie_vuelo;

        DBMS_OUTPUT.PUT_LINE('ID Serie: ' || r.id_serie_vuelo);
        DBMS_OUTPUT.PUT_LINE('País OACI: ' || r.id_pais_oaci);
        DBMS_OUTPUT.PUT_LINE('Aerolínea: ' || r.id_aerolinea);
        DBMS_OUTPUT.PUT_LINE('Rango inicio: ' || r.rango_numeros_inicio);
        DBMS_OUTPUT.PUT_LINE('Rango fin: ' || r.rango_numeros_fin);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
        IF r.documento_asignacion IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento asignación: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento asignación: No adjunto');
        END IF;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Serie de vuelo asignada no encontrada.');
    END get_serie;

    PROCEDURE update_serie(
        p_id_serie_vuelo        IN NUMBER,
        p_id_pais_oaci          IN NUMBER,
        p_id_aerolinea          IN NUMBER,
        p_rango_numeros_inicio  IN VARCHAR2,
        p_rango_numeros_fin     IN VARCHAR2,
        p_fecha_asignacion      IN DATE,
        p_fecha_vencimiento     IN DATE,
        p_activa                IN NUMBER,
        p_documento_asignacion  IN BLOB
    ) IS
    BEGIN
        UPDATE series_vuelo_asignadas
        SET id_pais_oaci         = p_id_pais_oaci,
            id_aerolinea         = p_id_aerolinea,
            rango_numeros_inicio = p_rango_numeros_inicio,
            rango_numeros_fin    = p_rango_numeros_fin,
            fecha_asignacion     = p_fecha_asignacion,
            fecha_vencimiento    = p_fecha_vencimiento,
            activa               = p_activa,
            documento_asignacion = p_documento_asignacion
        WHERE id_serie_vuelo = p_id_serie_vuelo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36402, 'No se encontró la serie de vuelo asignada para actualizar.');
        END IF;
    END update_serie;

    PROCEDURE delete_serie(
        p_id_serie_vuelo IN NUMBER
    ) IS
    BEGIN
        DELETE FROM series_vuelo_asignadas
        WHERE id_serie_vuelo = p_id_serie_vuelo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36403, 'No se encontró la serie de vuelo asignada para eliminar.');
        END IF;
    END delete_serie;

END pkg_series_vuelo;
/
