------------------------------------------------------------
-- Paquete CRUD para la tabla RESTRICCIONES_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_restricciones_vuelo AS
    PROCEDURE insert_restriccion(
        p_id_programa      IN restricciones_vuelo.id_programa%TYPE,
        p_tipo_restriccion IN restricciones_vuelo.tipo_restriccion%TYPE,
        p_descripcion      IN restricciones_vuelo.descripcion%TYPE,
        p_fecha_inicio     IN restricciones_vuelo.fecha_inicio%TYPE,
        p_fecha_fin        IN restricciones_vuelo.fecha_fin%TYPE,
        p_activa           IN restricciones_vuelo.activa%TYPE DEFAULT 1
    );

    PROCEDURE get_restriccion(
        p_id_restriccion IN restricciones_vuelo.id_restriccion%TYPE
    );

    PROCEDURE update_restriccion(
        p_id_restriccion   IN restricciones_vuelo.id_restriccion%TYPE,
        p_id_programa      IN restricciones_vuelo.id_programa%TYPE,
        p_tipo_restriccion IN restricciones_vuelo.tipo_restriccion%TYPE,
        p_descripcion      IN restricciones_vuelo.descripcion%TYPE,
        p_fecha_inicio     IN restricciones_vuelo.fecha_inicio%TYPE,
        p_fecha_fin        IN restricciones_vuelo.fecha_fin%TYPE,
        p_activa           IN restricciones_vuelo.activa%TYPE
    );

    PROCEDURE delete_restriccion(
        p_id_restriccion IN restricciones_vuelo.id_restriccion%TYPE
    );
END pkg_restricciones_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_restricciones_vuelo AS

    PROCEDURE insert_restriccion(
        p_id_programa      IN restricciones_vuelo.id_programa%TYPE,
        p_tipo_restriccion IN restricciones_vuelo.tipo_restriccion%TYPE,
        p_descripcion      IN restricciones_vuelo.descripcion%TYPE,
        p_fecha_inicio     IN restricciones_vuelo.fecha_inicio%TYPE,
        p_fecha_fin        IN restricciones_vuelo.fecha_fin%TYPE,
        p_activa           IN restricciones_vuelo.activa%TYPE
    ) IS
    BEGIN
        INSERT INTO restricciones_vuelo (
            id_programa, tipo_restriccion, descripcion,
            fecha_inicio, fecha_fin, activa
        ) VALUES (
            p_id_programa, p_tipo_restriccion, p_descripcion,
            p_fecha_inicio, p_fecha_fin, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20401, 'Error al insertar restricción: ' || SQLERRM);
    END insert_restriccion;

    PROCEDURE get_restriccion(
        p_id_restriccion IN restricciones_vuelo.id_restriccion%TYPE
    ) IS
        r restricciones_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM restricciones_vuelo
        WHERE id_restriccion = p_id_restriccion;

        DBMS_OUTPUT.PUT_LINE('ID Restricción: ' || r.id_restriccion);
        DBMS_OUTPUT.PUT_LINE('Programa: ' || r.id_programa);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_restriccion);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Restricción no encontrada.');
    END get_restriccion;

    PROCEDURE update_restriccion(
        p_id_restriccion   IN restricciones_vuelo.id_restriccion%TYPE,
        p_id_programa      IN restricciones_vuelo.id_programa%TYPE,
        p_tipo_restriccion IN restricciones_vuelo.tipo_restriccion%TYPE,
        p_descripcion      IN restricciones_vuelo.descripcion%TYPE,
        p_fecha_inicio     IN restricciones_vuelo.fecha_inicio%TYPE,
        p_fecha_fin        IN restricciones_vuelo.fecha_fin%TYPE,
        p_activa           IN restricciones_vuelo.activa%TYPE
    ) IS
    BEGIN
        UPDATE restricciones_vuelo
        SET id_programa      = p_id_programa,
            tipo_restriccion = p_tipo_restriccion,
            descripcion      = p_descripcion,
            fecha_inicio     = p_fecha_inicio,
            fecha_fin        = p_fecha_fin,
            activa           = p_activa
        WHERE id_restriccion = p_id_restriccion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20402, 'No se encontró la restricción para actualizar.');
        END IF;
    END update_restriccion;

    PROCEDURE delete_restriccion(
        p_id_restriccion IN restricciones_vuelo.id_restriccion%TYPE
    ) IS
    BEGIN
        DELETE FROM restricciones_vuelo
        WHERE id_restriccion = p_id_restriccion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20403, 'No se encontró la restricción para eliminar.');
        END IF;
    END delete_restriccion;

END pkg_restricciones_vuelo;
/