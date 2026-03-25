------------------------------------------------------------
-- Paquete CRUD para la tabla VUELOS_TRIPULACION
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_vuelos_tripulacion AS
    PROCEDURE insert_tripulacion(
        p_id_vuelo       IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante  IN vuelos_tripulacion.id_tripulante%TYPE,
        p_rol_asignado   IN vuelos_tripulacion.rol_asignado%TYPE,
        p_horas_trabajadas IN vuelos_tripulacion.horas_trabajadas%TYPE,
        p_observaciones  IN vuelos_tripulacion.observaciones%TYPE
    );

    PROCEDURE get_tripulacion(
        p_id_vuelo      IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante IN vuelos_tripulacion.id_tripulante%TYPE
    );

    PROCEDURE update_tripulacion(
        p_id_vuelo       IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante  IN vuelos_tripulacion.id_tripulante%TYPE,
        p_rol_asignado   IN vuelos_tripulacion.rol_asignado%TYPE,
        p_horas_trabajadas IN vuelos_tripulacion.horas_trabajadas%TYPE,
        p_observaciones  IN vuelos_tripulacion.observaciones%TYPE
    );

    PROCEDURE delete_tripulacion(
        p_id_vuelo      IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante IN vuelos_tripulacion.id_tripulante%TYPE
    );
END pkg_vuelos_tripulacion;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_vuelos_tripulacion AS

    PROCEDURE insert_tripulacion(
        p_id_vuelo       IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante  IN vuelos_tripulacion.id_tripulante%TYPE,
        p_rol_asignado   IN vuelos_tripulacion.rol_asignado%TYPE,
        p_horas_trabajadas IN vuelos_tripulacion.horas_trabajadas%TYPE,
        p_observaciones  IN vuelos_tripulacion.observaciones%TYPE
    ) IS
    BEGIN
        INSERT INTO vuelos_tripulacion (
            id_vuelo, id_tripulante, rol_asignado,
            horas_trabajadas, observaciones
        ) VALUES (
            p_id_vuelo, p_id_tripulante, p_rol_asignado,
            p_horas_trabajadas, p_observaciones
        );
    EXCEPTION
        WHEN DUP_VAL_ON_INDEX THEN
            RAISE_APPLICATION_ERROR(-21401, 'Ya existe un registro para ese vuelo y tripulante.');
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21402, 'Error al insertar tripulación: ' || SQLERRM);
    END insert_tripulacion;

    PROCEDURE get_tripulacion(
        p_id_vuelo      IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante IN vuelos_tripulacion.id_tripulante%TYPE
    ) IS
        r vuelos_tripulacion%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM vuelos_tripulacion
        WHERE id_vuelo = p_id_vuelo
          AND id_tripulante = p_id_tripulante;

        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Tripulante: ' || r.id_tripulante);
        DBMS_OUTPUT.PUT_LINE('Rol asignado: ' || r.rol_asignado);
        DBMS_OUTPUT.PUT_LINE('Horas trabajadas: ' || r.horas_trabajadas);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Registro de tripulación no encontrado.');
    END get_tripulacion;

    PROCEDURE update_tripulacion(
        p_id_vuelo       IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante  IN vuelos_tripulacion.id_tripulante%TYPE,
        p_rol_asignado   IN vuelos_tripulacion.rol_asignado%TYPE,
        p_horas_trabajadas IN vuelos_tripulacion.horas_trabajadas%TYPE,
        p_observaciones  IN vuelos_tripulacion.observaciones%TYPE
    ) IS
    BEGIN
        UPDATE vuelos_tripulacion
        SET rol_asignado   = p_rol_asignado,
            horas_trabajadas = p_horas_trabajadas,
            observaciones  = p_observaciones
        WHERE id_vuelo = p_id_vuelo
          AND id_tripulante = p_id_tripulante;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21403, 'No se encontró el registro de tripulación para actualizar.');
        END IF;
    END update_tripulacion;

    PROCEDURE delete_tripulacion(
        p_id_vuelo      IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante IN vuelos_tripulacion.id_tripulante%TYPE
    ) IS
    BEGIN
        DELETE FROM vuelos_tripulacion
        WHERE id_vuelo = p_id_vuelo
          AND id_tripulante = p_id_tripulante;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21404, 'No se encontró el registro de tripulación para eliminar.');
        END IF;
    END delete_tripulacion;

END pkg_vuelos_tripulacion;
/