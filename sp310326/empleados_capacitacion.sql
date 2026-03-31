------------------------------------------------------------
-- Paquete CRUD para la tabla EMPLEADOS_CAPACITACION
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_empleados_capacitacion AS
    PROCEDURE insert_empleado_capacitacion(
        p_id_empleado        IN NUMBER,
        p_id_capacitacion    IN NUMBER,
        p_fecha_asignacion   IN DATE,
        p_estado             IN VARCHAR2 DEFAULT 'INSCRITO',
        p_fecha_completado   IN DATE,
        p_calificacion       IN NUMBER,
        p_certificado_obtenido IN NUMBER DEFAULT 0
    );

    PROCEDURE get_empleado_capacitacion(
        p_id_empleado     IN NUMBER,
        p_id_capacitacion IN NUMBER
    );

    PROCEDURE update_empleado_capacitacion(
        p_id_empleado        IN NUMBER,
        p_id_capacitacion    IN NUMBER,
        p_fecha_asignacion   IN DATE,
        p_estado             IN VARCHAR2,
        p_fecha_completado   IN DATE,
        p_calificacion       IN NUMBER,
        p_certificado_obtenido IN NUMBER
    );

    PROCEDURE delete_empleado_capacitacion(
        p_id_empleado     IN NUMBER,
        p_id_capacitacion IN NUMBER
    );
END pkg_empleados_capacitacion;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_empleados_capacitacion AS

    PROCEDURE insert_empleado_capacitacion(
        p_id_empleado        IN NUMBER,
        p_id_capacitacion    IN NUMBER,
        p_fecha_asignacion   IN DATE,
        p_estado             IN VARCHAR2,
        p_fecha_completado   IN DATE,
        p_calificacion       IN NUMBER,
        p_certificado_obtenido IN NUMBER
    ) IS
    BEGIN
        INSERT INTO empleados_capacitacion (
            id_empleado, id_capacitacion, fecha_asignacion,
            estado, fecha_completado, calificacion, certificado_obtenido
        ) VALUES (
            p_id_empleado, p_id_capacitacion, p_fecha_asignacion,
            NVL(p_estado,'INSCRITO'), p_fecha_completado, p_calificacion, NVL(p_certificado_obtenido,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27001, 'Error al insertar relación empleado-capacitación: ' || SQLERRM);
    END insert_empleado_capacitacion;

    PROCEDURE get_empleado_capacitacion(
        p_id_empleado     IN NUMBER,
        p_id_capacitacion IN NUMBER
    ) IS
        r empleados_capacitacion%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM empleados_capacitacion
        WHERE id_empleado = p_id_empleado
          AND id_capacitacion = p_id_capacitacion;

        DBMS_OUTPUT.PUT_LINE('Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Capacitación: ' || r.id_capacitacion);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Fecha completado: ' || r.fecha_completado);
        DBMS_OUTPUT.PUT_LINE('Calificación: ' || r.calificacion);
        DBMS_OUTPUT.PUT_LINE('Certificado obtenido: ' || r.certificado_obtenido);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Relación empleado-capacitación no encontrada.');
    END get_empleado_capacitacion;

    PROCEDURE update_empleado_capacitacion(
        p_id_empleado        IN NUMBER,
        p_id_capacitacion    IN NUMBER,
        p_fecha_asignacion   IN DATE,
        p_estado             IN VARCHAR2,
        p_fecha_completado   IN DATE,
        p_calificacion       IN NUMBER,
        p_certificado_obtenido IN NUMBER
    ) IS
    BEGIN
        UPDATE empleados_capacitacion
        SET fecha_asignacion   = p_fecha_asignacion,
            estado             = p_estado,
            fecha_completado   = p_fecha_completado,
            calificacion       = p_calificacion,
            certificado_obtenido = p_certificado_obtenido
        WHERE id_empleado = p_id_empleado
          AND id_capacitacion = p_id_capacitacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27002, 'No se encontró la relación empleado-capacitación para actualizar.');
        END IF;
    END update_empleado_capacitacion;

    PROCEDURE delete_empleado_capacitacion(
        p_id_empleado     IN NUMBER,
        p_id_capacitacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM empleados_capacitacion
        WHERE id_empleado = p_id_empleado
          AND id_capacitacion = p_id_capacitacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27003, 'No se encontró la relación empleado-capacitación para eliminar.');
        END IF;
    END delete_empleado_capacitacion;

END pkg_empleados_capacitacion;
/