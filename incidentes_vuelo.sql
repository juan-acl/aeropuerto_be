------------------------------------------------------------
-- Paquete CRUD para la tabla INCIDENTES_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_incidentes_vuelo AS
    PROCEDURE insert_incidente(
        p_id_vuelo         IN incidentes_vuelo.id_vuelo%TYPE,
        p_fecha_incidente  IN incidentes_vuelo.fecha_incidente%TYPE,
        p_tipo_incidente   IN incidentes_vuelo.tipo_incidente%TYPE,
        p_descripcion      IN incidentes_vuelo.descripcion%TYPE,
        p_gravedad         IN incidentes_vuelo.gravedad%TYPE,
        p_acciones_tomadas IN incidentes_vuelo.acciones_tomadas%TYPE,
        p_reportado_por    IN incidentes_vuelo.reportado_por%TYPE
    );

    PROCEDURE get_incidente(
        p_id_incidente_vuelo IN incidentes_vuelo.id_incidente_vuelo%TYPE
    );

    PROCEDURE update_incidente(
        p_id_incidente_vuelo IN incidentes_vuelo.id_incidente_vuelo%TYPE,
        p_id_vuelo           IN incidentes_vuelo.id_vuelo%TYPE,
        p_fecha_incidente    IN incidentes_vuelo.fecha_incidente%TYPE,
        p_tipo_incidente     IN incidentes_vuelo.tipo_incidente%TYPE,
        p_descripcion        IN incidentes_vuelo.descripcion%TYPE,
        p_gravedad           IN incidentes_vuelo.gravedad%TYPE,
        p_acciones_tomadas   IN incidentes_vuelo.acciones_tomadas%TYPE,
        p_reportado_por      IN incidentes_vuelo.reportado_por%TYPE
    );

    PROCEDURE delete_incidente(
        p_id_incidente_vuelo IN incidentes_vuelo.id_incidente_vuelo%TYPE
    );
END pkg_incidentes_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_incidentes_vuelo AS

    PROCEDURE insert_incidente(
        p_id_vuelo         IN incidentes_vuelo.id_vuelo%TYPE,
        p_fecha_incidente  IN incidentes_vuelo.fecha_incidente%TYPE,
        p_tipo_incidente   IN incidentes_vuelo.tipo_incidente%TYPE,
        p_descripcion      IN incidentes_vuelo.descripcion%TYPE,
        p_gravedad         IN incidentes_vuelo.gravedad%TYPE,
        p_acciones_tomadas IN incidentes_vuelo.acciones_tomadas%TYPE,
        p_reportado_por    IN incidentes_vuelo.reportado_por%TYPE
    ) IS
    BEGIN
        INSERT INTO incidentes_vuelo (
            id_vuelo, fecha_incidente, tipo_incidente,
            descripcion, gravedad, acciones_tomadas, reportado_por
        ) VALUES (
            p_id_vuelo, p_fecha_incidente, p_tipo_incidente,
            p_descripcion, p_gravedad, p_acciones_tomadas, p_reportado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20701, 'Error al insertar incidente: ' || SQLERRM);
    END insert_incidente;

    PROCEDURE get_incidente(
        p_id_incidente_vuelo IN incidentes_vuelo.id_incidente_vuelo%TYPE
    ) IS
        r incidentes_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM incidentes_vuelo
        WHERE id_incidente_vuelo = p_id_incidente_vuelo;

        DBMS_OUTPUT.PUT_LINE('ID Incidente: ' || r.id_incidente_vuelo);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha_incidente);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_incidente);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Gravedad: ' || r.gravedad);
        DBMS_OUTPUT.PUT_LINE('Acciones tomadas: ' || r.acciones_tomadas);
        DBMS_OUTPUT.PUT_LINE('Reportado por: ' || r.reportado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Incidente no encontrado.');
    END get_incidente;

    PROCEDURE update_incidente(
        p_id_incidente_vuelo IN incidentes_vuelo.id_incidente_vuelo%TYPE,
        p_id_vuelo           IN incidentes_vuelo.id_vuelo%TYPE,
        p_fecha_incidente    IN incidentes_vuelo.fecha_incidente%TYPE,
        p_tipo_incidente     IN incidentes_vuelo.tipo_incidente%TYPE,
        p_descripcion        IN incidentes_vuelo.descripcion%TYPE,
        p_gravedad           IN incidentes_vuelo.gravedad%TYPE,
        p_acciones_tomadas   IN incidentes_vuelo.acciones_tomadas%TYPE,
        p_reportado_por      IN incidentes_vuelo.reportado_por%TYPE
    ) IS
    BEGIN
        UPDATE incidentes_vuelo
        SET id_vuelo         = p_id_vuelo,
            fecha_incidente  = p_fecha_incidente,
            tipo_incidente   = p_tipo_incidente,
            descripcion      = p_descripcion,
            gravedad         = p_gravedad,
            acciones_tomadas = p_acciones_tomadas,
            reportado_por    = p_reportado_por
        WHERE id_incidente_vuelo = p_id_incidente_vuelo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20702, 'No se encontró el incidente para actualizar.');
        END IF;
    END update_incidente;

    PROCEDURE delete_incidente(
        p_id_incidente_vuelo IN incidentes_vuelo.id_incidente_vuelo%TYPE
    ) IS
    BEGIN
        DELETE FROM incidentes_vuelo
        WHERE id_incidente_vuelo = p_id_incidente_vuelo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20703, 'No se encontró el incidente para eliminar.');
        END IF;
    END delete_incidente;

END pkg_incidentes_vuelo;
/