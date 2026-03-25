------------------------------------------------------------
-- Paquete CRUD para la tabla TRIPULACION_DISPONIBILIDAD
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tripulacion_disponibilidad AS
    PROCEDURE insert_disponibilidad(
        p_id_tripulante       IN tripulacion_disponibilidad.id_tripulante%TYPE,
        p_fecha_inicio        IN tripulacion_disponibilidad.fecha_inicio%TYPE,
        p_fecha_fin           IN tripulacion_disponibilidad.fecha_fin%TYPE,
        p_horas_maximas_diarias IN tripulacion_disponibilidad.horas_maximas_diarias%TYPE,
        p_disponible          IN tripulacion_disponibilidad.disponible%TYPE DEFAULT 1,
        p_observaciones       IN tripulacion_disponibilidad.observaciones%TYPE
    );

    PROCEDURE get_disponibilidad(
        p_id_disponibilidad IN tripulacion_disponibilidad.id_disponibilidad%TYPE
    );

    PROCEDURE update_disponibilidad(
        p_id_disponibilidad   IN tripulacion_disponibilidad.id_disponibilidad%TYPE,
        p_id_tripulante       IN tripulacion_disponibilidad.id_tripulante%TYPE,
        p_fecha_inicio        IN tripulacion_disponibilidad.fecha_inicio%TYPE,
        p_fecha_fin           IN tripulacion_disponibilidad.fecha_fin%TYPE,
        p_horas_maximas_diarias IN tripulacion_disponibilidad.horas_maximas_diarias%TYPE,
        p_disponible          IN tripulacion_disponibilidad.disponible%TYPE,
        p_observaciones       IN tripulacion_disponibilidad.observaciones%TYPE
    );

    PROCEDURE delete_disponibilidad(
        p_id_disponibilidad IN tripulacion_disponibilidad.id_disponibilidad%TYPE
    );
END pkg_tripulacion_disponibilidad;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tripulacion_disponibilidad AS

    PROCEDURE insert_disponibilidad(
        p_id_tripulante       IN tripulacion_disponibilidad.id_tripulante%TYPE,
        p_fecha_inicio        IN tripulacion_disponibilidad.fecha_inicio%TYPE,
        p_fecha_fin           IN tripulacion_disponibilidad.fecha_fin%TYPE,
        p_horas_maximas_diarias IN tripulacion_disponibilidad.horas_maximas_diarias%TYPE,
        p_disponible          IN tripulacion_disponibilidad.disponible%TYPE,
        p_observaciones       IN tripulacion_disponibilidad.observaciones%TYPE
    ) IS
    BEGIN
        INSERT INTO tripulacion_disponibilidad (
            id_tripulante, fecha_inicio, fecha_fin,
            horas_maximas_diarias, disponible, observaciones
        ) VALUES (
            p_id_tripulante, p_fecha_inicio, p_fecha_fin,
            p_horas_maximas_diarias, NVL(p_disponible,1), p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21601, 'Error al insertar disponibilidad: ' || SQLERRM);
    END insert_disponibilidad;

    PROCEDURE get_disponibilidad(
        p_id_disponibilidad IN tripulacion_disponibilidad.id_disponibilidad%TYPE
    ) IS
        r tripulacion_disponibilidad%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tripulacion_disponibilidad
        WHERE id_disponibilidad = p_id_disponibilidad;

        DBMS_OUTPUT.PUT_LINE('ID Disponibilidad: ' || r.id_disponibilidad);
        DBMS_OUTPUT.PUT_LINE('Tripulante: ' || r.id_tripulante);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Horas máximas diarias: ' || r.horas_maximas_diarias);
        DBMS_OUTPUT.PUT_LINE('Disponible: ' || r.disponible);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Disponibilidad no encontrada.');
    END get_disponibilidad;

    PROCEDURE update_disponibilidad(
        p_id_disponibilidad   IN tripulacion_disponibilidad.id_disponibilidad%TYPE,
        p_id_tripulante       IN tripulacion_disponibilidad.id_tripulante%TYPE,
        p_fecha_inicio        IN tripulacion_disponibilidad.fecha_inicio%TYPE,
        p_fecha_fin           IN tripulacion_disponibilidad.fecha_fin%TYPE,
        p_horas_maximas_diarias IN tripulacion_disponibilidad.horas_maximas_diarias%TYPE,
        p_disponible          IN tripulacion_disponibilidad.disponible%TYPE,
        p_observaciones       IN tripulacion_disponibilidad.observaciones%TYPE
    ) IS
    BEGIN
        UPDATE tripulacion_disponibilidad
        SET id_tripulante       = p_id_tripulante,
            fecha_inicio        = p_fecha_inicio,
            fecha_fin           = p_fecha_fin,
            horas_maximas_diarias = p_horas_maximas_diarias,
            disponible          = p_disponible,
            observaciones       = p_observaciones
        WHERE id_disponibilidad = p_id_disponibilidad;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21602, 'No se encontró la disponibilidad para actualizar.');
        END IF;
    END update_disponibilidad;

    PROCEDURE delete_disponibilidad(
        p_id_disponibilidad IN tripulacion_disponibilidad.id_disponibilidad%TYPE
    ) IS
    BEGIN
        DELETE FROM tripulacion_disponibilidad
        WHERE id_disponibilidad = p_id_disponibilidad;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21603, 'No se encontró la disponibilidad para eliminar.');
        END IF;
    END delete_disponibilidad;

END pkg_tripulacion_disponibilidad;
/