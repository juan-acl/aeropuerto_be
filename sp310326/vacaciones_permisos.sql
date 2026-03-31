------------------------------------------------------------
-- Paquete CRUD para la tabla VACACIONES_PERMISOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_vacaciones_permisos AS
    PROCEDURE insert_solicitud(
        p_id_empleado      IN NUMBER,
        p_tipo_solicitud   IN VARCHAR2,
        p_fecha_inicio     IN DATE,
        p_fecha_fin        IN DATE,
        p_dias_solicitados IN NUMBER,
        p_motivo           IN VARCHAR2,
        p_fecha_solicitud  IN DATE,
        p_estado           IN VARCHAR2 DEFAULT 'PENDIENTE',
        p_autorizado_por   IN NUMBER,
        p_fecha_autorizacion IN DATE,
        p_observaciones    IN VARCHAR2
    );

    PROCEDURE get_solicitud(
        p_id_solicitud IN NUMBER
    );

    PROCEDURE update_solicitud(
        p_id_solicitud     IN NUMBER,
        p_id_empleado      IN NUMBER,
        p_tipo_solicitud   IN VARCHAR2,
        p_fecha_inicio     IN DATE,
        p_fecha_fin        IN DATE,
        p_dias_solicitados IN NUMBER,
        p_motivo           IN VARCHAR2,
        p_fecha_solicitud  IN DATE,
        p_estado           IN VARCHAR2,
        p_autorizado_por   IN NUMBER,
        p_fecha_autorizacion IN DATE,
        p_observaciones    IN VARCHAR2
    );

    PROCEDURE delete_solicitud(
        p_id_solicitud IN NUMBER
    );
END pkg_vacaciones_permisos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_vacaciones_permisos AS

    PROCEDURE insert_solicitud(
        p_id_empleado      IN NUMBER,
        p_tipo_solicitud   IN VARCHAR2,
        p_fecha_inicio     IN DATE,
        p_fecha_fin        IN DATE,
        p_dias_solicitados IN NUMBER,
        p_motivo           IN VARCHAR2,
        p_fecha_solicitud  IN DATE,
        p_estado           IN VARCHAR2,
        p_autorizado_por   IN NUMBER,
        p_fecha_autorizacion IN DATE,
        p_observaciones    IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO vacaciones_permisos (
            id_empleado, tipo_solicitud, fecha_inicio, fecha_fin,
            dias_solicitados, motivo, fecha_solicitud, estado,
            autorizado_por, fecha_autorizacion, observaciones
        ) VALUES (
            p_id_empleado, p_tipo_solicitud, p_fecha_inicio, p_fecha_fin,
            p_dias_solicitados, p_motivo, p_fecha_solicitud, NVL(p_estado,'PENDIENTE'),
            p_autorizado_por, p_fecha_autorizacion, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26701, 'Error al insertar solicitud de vacaciones/permiso: ' || SQLERRM);
    END insert_solicitud;

    PROCEDURE get_solicitud(
        p_id_solicitud IN NUMBER
    ) IS
        r vacaciones_permisos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM vacaciones_permisos
        WHERE id_solicitud = p_id_solicitud;

        DBMS_OUTPUT.PUT_LINE('ID Solicitud: ' || r.id_solicitud);
        DBMS_OUTPUT.PUT_LINE('Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Tipo solicitud: ' || r.tipo_solicitud);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Días solicitados: ' || r.dias_solicitados);
        DBMS_OUTPUT.PUT_LINE('Motivo: ' || r.motivo);
        DBMS_OUTPUT.PUT_LINE('Fecha solicitud: ' || r.fecha_solicitud);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Autorizado por: ' || r.autorizado_por);
        DBMS_OUTPUT.PUT_LINE('Fecha autorización: ' || r.fecha_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Solicitud de vacaciones/permiso no encontrada.');
    END get_solicitud;

    PROCEDURE update_solicitud(
        p_id_solicitud     IN NUMBER,
        p_id_empleado      IN NUMBER,
        p_tipo_solicitud   IN VARCHAR2,
        p_fecha_inicio     IN DATE,
        p_fecha_fin        IN DATE,
        p_dias_solicitados IN NUMBER,
        p_motivo           IN VARCHAR2,
        p_fecha_solicitud  IN DATE,
        p_estado           IN VARCHAR2,
        p_autorizado_por   IN NUMBER,
        p_fecha_autorizacion IN DATE,
        p_observaciones    IN VARCHAR2
    ) IS
    BEGIN
        UPDATE vacaciones_permisos
        SET id_empleado       = p_id_empleado,
            tipo_solicitud    = p_tipo_solicitud,
            fecha_inicio      = p_fecha_inicio,
            fecha_fin         = p_fecha_fin,
            dias_solicitados  = p_dias_solicitados,
            motivo            = p_motivo,
            fecha_solicitud   = p_fecha_solicitud,
            estado            = p_estado,
            autorizado_por    = p_autorizado_por,
            fecha_autorizacion = p_fecha_autorizacion,
            observaciones     = p_observaciones
        WHERE id_solicitud = p_id_solicitud;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26702, 'No se encontró la solicitud para actualizar.');
        END IF;
    END update_solicitud;

    PROCEDURE delete_solicitud(
        p_id_solicitud IN NUMBER
    ) IS
    BEGIN
        DELETE FROM vacaciones_permisos
        WHERE id_solicitud = p_id_solicitud;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26703, 'No se encontró la solicitud para eliminar.');
        END IF;
    END delete_solicitud;

END pkg_vacaciones_permisos;
/