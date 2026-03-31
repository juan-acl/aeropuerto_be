------------------------------------------------------------
-- Paquete CRUD para la tabla UNIFORMES_EQUIPAMIENTO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_uniformes_equipamiento AS
    PROCEDURE insert_asignacion(
        p_id_empleado      IN NUMBER,
        p_tipo_equipo      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_talla            IN VARCHAR2,
        p_fecha_asignacion IN DATE,
        p_fecha_devolucion IN DATE,
        p_estado           IN VARCHAR2,
        p_observaciones    IN VARCHAR2
    );

    PROCEDURE get_asignacion(
        p_id_asignacion IN NUMBER
    );

    PROCEDURE update_asignacion(
        p_id_asignacion    IN NUMBER,
        p_id_empleado      IN NUMBER,
        p_tipo_equipo      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_talla            IN VARCHAR2,
        p_fecha_asignacion IN DATE,
        p_fecha_devolucion IN DATE,
        p_estado           IN VARCHAR2,
        p_observaciones    IN VARCHAR2
    );

    PROCEDURE delete_asignacion(
        p_id_asignacion IN NUMBER
    );
END pkg_uniformes_equipamiento;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_uniformes_equipamiento AS

    PROCEDURE insert_asignacion(
        p_id_empleado      IN NUMBER,
        p_tipo_equipo      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_talla            IN VARCHAR2,
        p_fecha_asignacion IN DATE,
        p_fecha_devolucion IN DATE,
        p_estado           IN VARCHAR2,
        p_observaciones    IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO uniformes_equipamiento (
            id_empleado, tipo_equipo, descripcion, talla,
            fecha_asignacion, fecha_devolucion, estado, observaciones
        ) VALUES (
            p_id_empleado, p_tipo_equipo, p_descripcion, p_talla,
            p_fecha_asignacion, p_fecha_devolucion, p_estado, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27101, 'Error al insertar asignación de uniforme/equipamiento: ' || SQLERRM);
    END insert_asignacion;

    PROCEDURE get_asignacion(
        p_id_asignacion IN NUMBER
    ) IS
        r uniformes_equipamiento%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM uniformes_equipamiento
        WHERE id_asignacion = p_id_asignacion;

        DBMS_OUTPUT.PUT_LINE('ID Asignación: ' || r.id_asignacion);
        DBMS_OUTPUT.PUT_LINE('Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Tipo equipo: ' || r.tipo_equipo);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Talla: ' || r.talla);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Fecha devolución: ' || r.fecha_devolucion);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Asignación de uniforme/equipamiento no encontrada.');
    END get_asignacion;

    PROCEDURE update_asignacion(
        p_id_asignacion    IN NUMBER,
        p_id_empleado      IN NUMBER,
        p_tipo_equipo      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_talla            IN VARCHAR2,
        p_fecha_asignacion IN DATE,
        p_fecha_devolucion IN DATE,
        p_estado           IN VARCHAR2,
        p_observaciones    IN VARCHAR2
    ) IS
    BEGIN
        UPDATE uniformes_equipamiento
        SET id_empleado      = p_id_empleado,
            tipo_equipo      = p_tipo_equipo,
            descripcion      = p_descripcion,
            talla            = p_talla,
            fecha_asignacion = p_fecha_asignacion,
            fecha_devolucion = p_fecha_devolucion,
            estado           = p_estado,
            observaciones    = p_observaciones
        WHERE id_asignacion = p_id_asignacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27102, 'No se encontró la asignación para actualizar.');
        END IF;
    END update_asignacion;

    PROCEDURE delete_asignacion(
        p_id_asignacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM uniformes_equipamiento
        WHERE id_asignacion = p_id_asignacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27103, 'No se encontró la asignación para eliminar.');
        END IF;
    END delete_asignacion;

END pkg_uniformes_equipamiento;
/