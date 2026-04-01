------------------------------------------------------------
-- Paquete CRUD para la tabla INSPECTORES_ADUANAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_inspectores_aduanas AS
    PROCEDURE insert_inspector(
        p_id_empleado                   IN NUMBER,
        p_numero_licencia               IN VARCHAR2,
        p_nivel_autorizacion            IN NUMBER,
        p_fecha_certificacion           IN DATE,
        p_fecha_vencimiento_certificacion IN DATE,
        p_especialidad                  IN VARCHAR2,
        p_activo                        IN NUMBER DEFAULT 1
    );

    PROCEDURE get_inspector(
        p_id_inspector IN NUMBER
    );

    PROCEDURE update_inspector(
        p_id_inspector                  IN NUMBER,
        p_id_empleado                   IN NUMBER,
        p_numero_licencia               IN VARCHAR2,
        p_nivel_autorizacion            IN NUMBER,
        p_fecha_certificacion           IN DATE,
        p_fecha_vencimiento_certificacion IN DATE,
        p_especialidad                  IN VARCHAR2,
        p_activo                        IN NUMBER
    );

    PROCEDURE delete_inspector(
        p_id_inspector IN NUMBER
    );
END pkg_inspectores_aduanas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_inspectores_aduanas AS

    PROCEDURE insert_inspector(
        p_id_empleado                   IN NUMBER,
        p_numero_licencia               IN VARCHAR2,
        p_nivel_autorizacion            IN NUMBER,
        p_fecha_certificacion           IN DATE,
        p_fecha_vencimiento_certificacion IN DATE,
        p_especialidad                  IN VARCHAR2,
        p_activo                        IN NUMBER
    ) IS
    BEGIN
        INSERT INTO inspectores_aduanas (
            id_empleado, numero_licencia, nivel_autorizacion,
            fecha_certificacion, fecha_vencimiento_certificacion,
            especialidad, activo
        ) VALUES (
            p_id_empleado, p_numero_licencia, p_nivel_autorizacion,
            p_fecha_certificacion, p_fecha_vencimiento_certificacion,
            p_especialidad, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29101, 'Error al insertar inspector de aduanas: ' || SQLERRM);
    END insert_inspector;

    PROCEDURE get_inspector(
        p_id_inspector IN NUMBER
    ) IS
        r inspectores_aduanas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM inspectores_aduanas
        WHERE id_inspector = p_id_inspector;

        DBMS_OUTPUT.PUT_LINE('ID Inspector: ' || r.id_inspector);
        DBMS_OUTPUT.PUT_LINE('Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Número licencia: ' || r.numero_licencia);
        DBMS_OUTPUT.PUT_LINE('Nivel autorización: ' || r.nivel_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Fecha certificación: ' || r.fecha_certificacion);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento_certificacion);
        DBMS_OUTPUT.PUT_LINE('Especialidad: ' || r.especialidad);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Inspector de aduanas no encontrado.');
    END get_inspector;

    PROCEDURE update_inspector(
        p_id_inspector                  IN NUMBER,
        p_id_empleado                   IN NUMBER,
        p_numero_licencia               IN VARCHAR2,
        p_nivel_autorizacion            IN NUMBER,
        p_fecha_certificacion           IN DATE,
        p_fecha_vencimiento_certificacion IN DATE,
        p_especialidad                  IN VARCHAR2,
        p_activo                        IN NUMBER
    ) IS
    BEGIN
        UPDATE inspectores_aduanas
        SET id_empleado                   = p_id_empleado,
            numero_licencia               = p_numero_licencia,
            nivel_autorizacion            = p_nivel_autorizacion,
            fecha_certificacion           = p_fecha_certificacion,
            fecha_vencimiento_certificacion = p_fecha_vencimiento_certificacion,
            especialidad                  = p_especialidad,
            activo                        = p_activo
        WHERE id_inspector = p_id_inspector;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29102, 'No se encontró el inspector de aduanas para actualizar.');
        END IF;
    END update_inspector;

    PROCEDURE delete_inspector(
        p_id_inspector IN NUMBER
    ) IS
    BEGIN
        DELETE FROM inspectores_aduanas
        WHERE id_inspector = p_id_inspector;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29103, 'No se encontró el inspector de aduanas para eliminar.');
        END IF;
    END delete_inspector;

END pkg_inspectores_aduanas;
/
