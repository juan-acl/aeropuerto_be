------------------------------------------------------------
-- Paquete CRUD para la tabla PUERTAS_EMBARQUE_ASIGNACION
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_puertas_embarque_asignacion AS
    PROCEDURE insert_asignacion(
        p_id_puerta       IN puertas_embarque_asignacion.id_puerta%TYPE,
        p_id_vuelo        IN puertas_embarque_asignacion.id_vuelo%TYPE,
        p_fecha_asignacion IN puertas_embarque_asignacion.fecha_asignacion%TYPE,
        p_hora_inicio     IN puertas_embarque_asignacion.hora_inicio%TYPE,
        p_hora_fin        IN puertas_embarque_asignacion.hora_fin%TYPE,
        p_asignado_por    IN puertas_embarque_asignacion.asignado_por%TYPE
    );

    PROCEDURE get_asignacion(
        p_id_asignacion_puerta IN puertas_embarque_asignacion.id_asignacion_puerta%TYPE
    );

    PROCEDURE update_asignacion(
        p_id_asignacion_puerta IN puertas_embarque_asignacion.id_asignacion_puerta%TYPE,
        p_id_puerta       IN puertas_embarque_asignacion.id_puerta%TYPE,
        p_id_vuelo        IN puertas_embarque_asignacion.id_vuelo%TYPE,
        p_fecha_asignacion IN puertas_embarque_asignacion.fecha_asignacion%TYPE,
        p_hora_inicio     IN puertas_embarque_asignacion.hora_inicio%TYPE,
        p_hora_fin        IN puertas_embarque_asignacion.hora_fin%TYPE,
        p_asignado_por    IN puertas_embarque_asignacion.asignado_por%TYPE
    );

    PROCEDURE delete_asignacion(
        p_id_asignacion_puerta IN puertas_embarque_asignacion.id_asignacion_puerta%TYPE
    );
END pkg_puertas_embarque_asignacion;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_puertas_embarque_asignacion AS

    PROCEDURE insert_asignacion(
        p_id_puerta       IN puertas_embarque_asignacion.id_puerta%TYPE,
        p_id_vuelo        IN puertas_embarque_asignacion.id_vuelo%TYPE,
        p_fecha_asignacion IN puertas_embarque_asignacion.fecha_asignacion%TYPE,
        p_hora_inicio     IN puertas_embarque_asignacion.hora_inicio%TYPE,
        p_hora_fin        IN puertas_embarque_asignacion.hora_fin%TYPE,
        p_asignado_por    IN puertas_embarque_asignacion.asignado_por%TYPE
    ) IS
    BEGIN
        INSERT INTO puertas_embarque_asignacion (
            id_puerta, id_vuelo, fecha_asignacion,
            hora_inicio, hora_fin, asignado_por
        ) VALUES (
            p_id_puerta, p_id_vuelo, p_fecha_asignacion,
            p_hora_inicio, p_hora_fin, p_asignado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23101, 'Error al insertar asignación de puerta: ' || SQLERRM);
    END insert_asignacion;

    PROCEDURE get_asignacion(
        p_id_asignacion_puerta IN puertas_embarque_asignacion.id_asignacion_puerta%TYPE
    ) IS
        r puertas_embarque_asignacion%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM puertas_embarque_asignacion
        WHERE id_asignacion_puerta = p_id_asignacion_puerta;

        DBMS_OUTPUT.PUT_LINE('ID Asignación: ' || r.id_asignacion_puerta);
        DBMS_OUTPUT.PUT_LINE('Puerta: ' || r.id_puerta);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Hora inicio: ' || r.hora_inicio);
        DBMS_OUTPUT.PUT_LINE('Hora fin: ' || r.hora_fin);
        DBMS_OUTPUT.PUT_LINE('Asignado por: ' || r.asignado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Asignación de puerta no encontrada.');
    END get_asignacion;

    PROCEDURE update_asignacion(
        p_id_asignacion_puerta IN puertas_embarque_asignacion.id_asignacion_puerta%TYPE,
        p_id_puerta       IN puertas_embarque_asignacion.id_puerta%TYPE,
        p_id_vuelo        IN puertas_embarque_asignacion.id_vuelo%TYPE,
        p_fecha_asignacion IN puertas_embarque_asignacion.fecha_asignacion%TYPE,
        p_hora_inicio     IN puertas_embarque_asignacion.hora_inicio%TYPE,
        p_hora_fin        IN puertas_embarque_asignacion.hora_fin%TYPE,
        p_asignado_por    IN puertas_embarque_asignacion.asignado_por%TYPE
    ) IS
    BEGIN
        UPDATE puertas_embarque_asignacion
        SET id_puerta       = p_id_puerta,
            id_vuelo        = p_id_vuelo,
            fecha_asignacion = p_fecha_asignacion,
            hora_inicio     = p_hora_inicio,
            hora_fin        = p_hora_fin,
            asignado_por    = p_asignado_por
        WHERE id_asignacion_puerta = p_id_asignacion_puerta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23102, 'No se encontró la asignación de puerta para actualizar.');
        END IF;
    END update_asignacion;

    PROCEDURE delete_asignacion(
        p_id_asignacion_puerta IN puertas_embarque_asignacion.id_asignacion_puerta%TYPE
    ) IS
    BEGIN
        DELETE FROM puertas_embarque_asignacion
        WHERE id_asignacion_puerta = p_id_asignacion_puerta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23103, 'No se encontró la asignación de puerta para eliminar.');
        END IF;
    END delete_asignacion;

END pkg_puertas_embarque_asignacion;
/