------------------------------------------------------------
-- Paquete CRUD para la tabla PERSONAL_EMERGENCIA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_personal_emergencia AS
    PROCEDURE insert_personal(
        p_id_empleado                    IN NUMBER,
        p_especialidad                   IN VARCHAR2,
        p_nivel_certificacion            IN VARCHAR2,
        p_fecha_certificacion            IN DATE,
        p_fecha_vencimiento_certificacion IN DATE,
        p_disponible_24h                 IN NUMBER DEFAULT 0,
        p_grupo_respuesta                IN VARCHAR2,
        p_activo                         IN NUMBER DEFAULT 1
    );

    PROCEDURE get_personal(
        p_id_personal_emergencia IN NUMBER
    );

    PROCEDURE update_personal(
        p_id_personal_emergencia         IN NUMBER,
        p_id_empleado                    IN NUMBER,
        p_especialidad                   IN VARCHAR2,
        p_nivel_certificacion            IN VARCHAR2,
        p_fecha_certificacion            IN DATE,
        p_fecha_vencimiento_certificacion IN DATE,
        p_disponible_24h                 IN NUMBER,
        p_grupo_respuesta                IN VARCHAR2,
        p_activo                         IN NUMBER
    );

    PROCEDURE delete_personal(
        p_id_personal_emergencia IN NUMBER
    );
END pkg_personal_emergencia;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_personal_emergencia AS

    PROCEDURE insert_personal(
        p_id_empleado                    IN NUMBER,
        p_especialidad                   IN VARCHAR2,
        p_nivel_certificacion            IN VARCHAR2,
        p_fecha_certificacion            IN DATE,
        p_fecha_vencimiento_certificacion IN DATE,
        p_disponible_24h                 IN NUMBER,
        p_grupo_respuesta                IN VARCHAR2,
        p_activo                         IN NUMBER
    ) IS
    BEGIN
        INSERT INTO personal_emergencia (
            id_empleado, especialidad, nivel_certificacion,
            fecha_certificacion, fecha_vencimiento_certificacion,
            disponible_24h, grupo_respuesta, activo
        ) VALUES (
            p_id_empleado, p_especialidad, p_nivel_certificacion,
            p_fecha_certificacion, p_fecha_vencimiento_certificacion,
            NVL(p_disponible_24h,0), p_grupo_respuesta, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35701, 'Error al insertar personal de emergencia: ' || SQLERRM);
    END insert_personal;

    PROCEDURE get_personal(
        p_id_personal_emergencia IN NUMBER
    ) IS
        r personal_emergencia%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM personal_emergencia
        WHERE id_personal_emergencia = p_id_personal_emergencia;

        DBMS_OUTPUT.PUT_LINE('ID Personal: ' || r.id_personal_emergencia);
        DBMS_OUTPUT.PUT_LINE('Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Especialidad: ' || r.especialidad);
        DBMS_OUTPUT.PUT_LINE('Nivel certificación: ' || r.nivel_certificacion);
        DBMS_OUTPUT.PUT_LINE('Fecha certificación: ' || r.fecha_certificacion);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento certificación: ' || r.fecha_vencimiento_certificacion);
        DBMS_OUTPUT.PUT_LINE('Disponible 24h: ' || r.disponible_24h);
        DBMS_OUTPUT.PUT_LINE('Grupo respuesta: ' || r.grupo_respuesta);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Personal de emergencia no encontrado.');
    END get_personal;

    PROCEDURE update_personal(
        p_id_personal_emergencia         IN NUMBER,
        p_id_empleado                    IN NUMBER,
        p_especialidad                   IN VARCHAR2,
        p_nivel_certificacion            IN VARCHAR2,
        p_fecha_certificacion            IN DATE,
        p_fecha_vencimiento_certificacion IN DATE,
        p_disponible_24h                 IN NUMBER,
        p_grupo_respuesta                IN VARCHAR2,
        p_activo                         IN NUMBER
    ) IS
    BEGIN
        UPDATE personal_emergencia
        SET id_empleado                    = p_id_empleado,
            especialidad                   = p_especialidad,
            nivel_certificacion            = p_nivel_certificacion,
            fecha_certificacion            = p_fecha_certificacion,
            fecha_vencimiento_certificacion = p_fecha_vencimiento_certificacion,
            disponible_24h                 = p_disponible_24h,
            grupo_respuesta                = p_grupo_respuesta,
            activo                         = p_activo
        WHERE id_personal_emergencia = p_id_personal_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35702, 'No se encontró el personal de emergencia para actualizar.');
        END IF;
    END update_personal;

    PROCEDURE delete_personal(
        p_id_personal_emergencia IN NUMBER
    ) IS
    BEGIN
        DELETE FROM personal_emergencia
        WHERE id_personal_emergencia = p_id_personal_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35703, 'No se encontró el personal de emergencia para eliminar.');
        END IF;
    END delete_personal;

END pkg_personal_emergencia;
/
