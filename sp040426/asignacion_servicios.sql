------------------------------------------------------------
-- Paquete CRUD para la tabla ASIGNACION_SERVICIOS_TRANSPORTE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_asignacion_servicios AS
    PROCEDURE insert_asignacion(
        p_id_reserva_transporte   IN NUMBER,
        p_id_vehiculo_transporte  IN NUMBER,
        p_id_chofer_transporte    IN NUMBER,
        p_fecha_asignacion        IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_asignado_por            IN NUMBER,
        p_hora_llegada_vehiculo   IN TIMESTAMP,
        p_hora_inicio_servicio    IN TIMESTAMP,
        p_hora_fin_servicio       IN TIMESTAMP,
        p_kilometraje_inicio      IN NUMBER,
        p_kilometraje_fin         IN NUMBER,
        p_incidencias             IN VARCHAR2,
        p_calificacion_pasajero   IN NUMBER,
        p_comentarios_pasajero    IN VARCHAR2
    );

    PROCEDURE get_asignacion(
        p_id_asignacion_servicio IN NUMBER
    );

    PROCEDURE update_asignacion(
        p_id_asignacion_servicio IN NUMBER,
        p_id_reserva_transporte   IN NUMBER,
        p_id_vehiculo_transporte  IN NUMBER,
        p_id_chofer_transporte    IN NUMBER,
        p_fecha_asignacion        IN TIMESTAMP,
        p_asignado_por            IN NUMBER,
        p_hora_llegada_vehiculo   IN TIMESTAMP,
        p_hora_inicio_servicio    IN TIMESTAMP,
        p_hora_fin_servicio       IN TIMESTAMP,
        p_kilometraje_inicio      IN NUMBER,
        p_kilometraje_fin         IN NUMBER,
        p_incidencias             IN VARCHAR2,
        p_calificacion_pasajero   IN NUMBER,
        p_comentarios_pasajero    IN VARCHAR2
    );

    PROCEDURE delete_asignacion(
        p_id_asignacion_servicio IN NUMBER
    );
END pkg_asignacion_servicios;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_asignacion_servicios AS

    PROCEDURE insert_asignacion(
        p_id_reserva_transporte   IN NUMBER,
        p_id_vehiculo_transporte  IN NUMBER,
        p_id_chofer_transporte    IN NUMBER,
        p_fecha_asignacion        IN TIMESTAMP,
        p_asignado_por            IN NUMBER,
        p_hora_llegada_vehiculo   IN TIMESTAMP,
        p_hora_inicio_servicio    IN TIMESTAMP,
        p_hora_fin_servicio       IN TIMESTAMP,
        p_kilometraje_inicio      IN NUMBER,
        p_kilometraje_fin         IN NUMBER,
        p_incidencias             IN VARCHAR2,
        p_calificacion_pasajero   IN NUMBER,
        p_comentarios_pasajero    IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO asignacion_servicios_transporte (
            id_reserva_transporte, id_vehiculo_transporte, id_chofer_transporte,
            fecha_asignacion, asignado_por, hora_llegada_vehiculo,
            hora_inicio_servicio, hora_fin_servicio,
            kilometraje_inicio, kilometraje_fin,
            incidencias, calificacion_pasajero, comentarios_pasajero
        ) VALUES (
            p_id_reserva_transporte, p_id_vehiculo_transporte, p_id_chofer_transporte,
            NVL(p_fecha_asignacion, SYSTIMESTAMP), p_asignado_por, p_hora_llegada_vehiculo,
            p_hora_inicio_servicio, p_hora_fin_servicio,
            p_kilometraje_inicio, p_kilometraje_fin,
            p_incidencias, p_calificacion_pasajero, p_comentarios_pasajero
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35001, 'Error al insertar asignación de servicio de transporte: ' || SQLERRM);
    END insert_asignacion;

    PROCEDURE get_asignacion(
        p_id_asignacion_servicio IN NUMBER
    ) IS
        r asignacion_servicios_transporte%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM asignacion_servicios_transporte
        WHERE id_asignacion_servicio = p_id_asignacion_servicio;

        DBMS_OUTPUT.PUT_LINE('ID Asignación: ' || r.id_asignacion_servicio);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva_transporte);
        DBMS_OUTPUT.PUT_LINE('Vehículo: ' || r.id_vehiculo_transporte);
        DBMS_OUTPUT.PUT_LINE('Chofer: ' || r.id_chofer_transporte);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Asignado por: ' || r.asignado_por);
        DBMS_OUTPUT.PUT_LINE('Hora llegada vehículo: ' || r.hora_llegada_vehiculo);
        DBMS_OUTPUT.PUT_LINE('Hora inicio servicio: ' || r.hora_inicio_servicio);
        DBMS_OUTPUT.PUT_LINE('Hora fin servicio: ' || r.hora_fin_servicio);
        DBMS_OUTPUT.PUT_LINE('Kilometraje inicio: ' || r.kilometraje_inicio);
        DBMS_OUTPUT.PUT_LINE('Kilometraje fin: ' || r.kilometraje_fin);
        DBMS_OUTPUT.PUT_LINE('Incidencias: ' || r.incidencias);
        DBMS_OUTPUT.PUT_LINE('Calificación pasajero: ' || r.calificacion_pasajero);
        DBMS_OUTPUT.PUT_LINE('Comentarios pasajero: ' || r.comentarios_pasajero);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Asignación de servicio de transporte no encontrada.');
    END get_asignacion;

    PROCEDURE update_asignacion(
        p_id_asignacion_servicio IN NUMBER,
        p_id_reserva_transporte   IN NUMBER,
        p_id_vehiculo_transporte  IN NUMBER,
        p_id_chofer_transporte    IN NUMBER,
        p_fecha_asignacion        IN TIMESTAMP,
        p_asignado_por            IN NUMBER,
        p_hora_llegada_vehiculo   IN TIMESTAMP,
        p_hora_inicio_servicio    IN TIMESTAMP,
        p_hora_fin_servicio       IN TIMESTAMP,
        p_kilometraje_inicio      IN NUMBER,
        p_kilometraje_fin         IN NUMBER,
        p_incidencias             IN VARCHAR2,
        p_calificacion_pasajero   IN NUMBER,
        p_comentarios_pasajero    IN VARCHAR2
    ) IS
    BEGIN
        UPDATE asignacion_servicios_transporte
        SET id_reserva_transporte   = p_id_reserva_transporte,
            id_vehiculo_transporte  = p_id_vehiculo_transporte,
            id_chofer_transporte    = p_id_chofer_transporte,
            fecha_asignacion        = p_fecha_asignacion,
            asignado_por            = p_asignado_por,
            hora_llegada_vehiculo   = p_hora_llegada_vehiculo,
            hora_inicio_servicio    = p_hora_inicio_servicio,
            hora_fin_servicio       = p_hora_fin_servicio,
            kilometraje_inicio      = p_kilometraje_inicio,
            kilometraje_fin         = p_kilometraje_fin,
            incidencias             = p_incidencias,
            calificacion_pasajero   = p_calificacion_pasajero,
            comentarios_pasajero    = p_comentarios_pasajero
        WHERE id_asignacion_servicio = p_id_asignacion_servicio;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35002, 'No se encontró la asignación de servicio de transporte para actualizar.');
        END IF;
    END update_asignacion;

    PROCEDURE delete_asignacion(
        p_id_asignacion_servicio IN NUMBER
    ) IS
    BEGIN
        DELETE FROM asignacion_servicios_transporte
        WHERE id_asignacion_servicio = p_id_asignacion_servicio;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35003, 'No se encontró la asignación de servicio de transporte para eliminar.');
        END IF;
    END delete_asignacion;

END pkg_asignacion_servicios;
/
