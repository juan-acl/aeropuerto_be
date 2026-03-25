------------------------------------------------------------
-- Paquete CRUD para la tabla MANTENIMIENTO_AVIONES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_mantenimiento_aviones AS
    PROCEDURE insert_mantenimiento(
        p_matricula_avion       IN mantenimiento_aviones.matricula_avion%TYPE,
        p_id_modelo             IN mantenimiento_aviones.id_modelo%TYPE,
        p_fecha_mantenimiento   IN mantenimiento_aviones.fecha_mantenimiento%TYPE,
        p_tipo_mantenimiento    IN mantenimiento_aviones.tipo_mantenimiento%TYPE,
        p_descripcion           IN mantenimiento_aviones.descripcion%TYPE,
        p_horas_vuelo_actuales  IN mantenimiento_aviones.horas_vuelo_actuales%TYPE,
        p_proximo_mantenimiento IN mantenimiento_aviones.proximo_mantenimiento%TYPE,
        p_costo                 IN mantenimiento_aviones.costo%TYPE,
        p_taller                IN mantenimiento_aviones.taller%TYPE,
        p_tecnico_responsable   IN mantenimiento_aviones.tecnico_responsable%TYPE
    );

    PROCEDURE get_mantenimiento(
        p_id_mantenimiento IN mantenimiento_aviones.id_mantenimiento%TYPE
    );

    PROCEDURE update_mantenimiento(
        p_id_mantenimiento      IN mantenimiento_aviones.id_mantenimiento%TYPE,
        p_matricula_avion       IN mantenimiento_aviones.matricula_avion%TYPE,
        p_id_modelo             IN mantenimiento_aviones.id_modelo%TYPE,
        p_fecha_mantenimiento   IN mantenimiento_aviones.fecha_mantenimiento%TYPE,
        p_tipo_mantenimiento    IN mantenimiento_aviones.tipo_mantenimiento%TYPE,
        p_descripcion           IN mantenimiento_aviones.descripcion%TYPE,
        p_horas_vuelo_actuales  IN mantenimiento_aviones.horas_vuelo_actuales%TYPE,
        p_proximo_mantenimiento IN mantenimiento_aviones.proximo_mantenimiento%TYPE,
        p_costo                 IN mantenimiento_aviones.costo%TYPE,
        p_taller                IN mantenimiento_aviones.taller%TYPE,
        p_tecnico_responsable   IN mantenimiento_aviones.tecnico_responsable%TYPE
    );

    PROCEDURE delete_mantenimiento(
        p_id_mantenimiento IN mantenimiento_aviones.id_mantenimiento%TYPE
    );
END pkg_mantenimiento_aviones;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_mantenimiento_aviones AS

    PROCEDURE insert_mantenimiento(
        p_matricula_avion       IN mantenimiento_aviones.matricula_avion%TYPE,
        p_id_modelo             IN mantenimiento_aviones.id_modelo%TYPE,
        p_fecha_mantenimiento   IN mantenimiento_aviones.fecha_mantenimiento%TYPE,
        p_tipo_mantenimiento    IN mantenimiento_aviones.tipo_mantenimiento%TYPE,
        p_descripcion           IN mantenimiento_aviones.descripcion%TYPE,
        p_horas_vuelo_actuales  IN mantenimiento_aviones.horas_vuelo_actuales%TYPE,
        p_proximo_mantenimiento IN mantenimiento_aviones.proximo_mantenimiento%TYPE,
        p_costo                 IN mantenimiento_aviones.costo%TYPE,
        p_taller                IN mantenimiento_aviones.taller%TYPE,
        p_tecnico_responsable   IN mantenimiento_aviones.tecnico_responsable%TYPE
    ) IS
    BEGIN
        INSERT INTO mantenimiento_aviones (
            matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento,
            descripcion, horas_vuelo_actuales, proximo_mantenimiento,
            costo, taller, tecnico_responsable
        ) VALUES (
            p_matricula_avion, p_id_modelo, p_fecha_mantenimiento, p_tipo_mantenimiento,
            p_descripcion, p_horas_vuelo_actuales, p_proximo_mantenimiento,
            p_costo, p_taller, p_tecnico_responsable
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20101, 'Error al insertar mantenimiento: ' || SQLERRM);
    END insert_mantenimiento;

    PROCEDURE get_mantenimiento(
        p_id_mantenimiento IN mantenimiento_aviones.id_mantenimiento%TYPE
    ) IS
        r mantenimiento_aviones%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM mantenimiento_aviones
        WHERE id_mantenimiento = p_id_mantenimiento;

        DBMS_OUTPUT.PUT_LINE('ID Mantenimiento: ' || r.id_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Matrícula avión: ' || r.matricula_avion);
        DBMS_OUTPUT.PUT_LINE('Modelo: ' || r.id_modelo);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Horas vuelo actuales: ' || r.horas_vuelo_actuales);
        DBMS_OUTPUT.PUT_LINE('Próximo mantenimiento: ' || r.proximo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Costo: ' || r.costo);
        DBMS_OUTPUT.PUT_LINE('Taller: ' || r.taller);
        DBMS_OUTPUT.PUT_LINE('Técnico responsable: ' || r.tecnico_responsable);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Mantenimiento no encontrado.');
    END get_mantenimiento;

    PROCEDURE update_mantenimiento(
        p_id_mantenimiento      IN mantenimiento_aviones.id_mantenimiento%TYPE,
        p_matricula_avion       IN mantenimiento_aviones.matricula_avion%TYPE,
        p_id_modelo             IN mantenimiento_aviones.id_modelo%TYPE,
        p_fecha_mantenimiento   IN mantenimiento_aviones.fecha_mantenimiento%TYPE,
        p_tipo_mantenimiento    IN mantenimiento_aviones.tipo_mantenimiento%TYPE,
        p_descripcion           IN mantenimiento_aviones.descripcion%TYPE,
        p_horas_vuelo_actuales  IN mantenimiento_aviones.horas_vuelo_actuales%TYPE,
        p_proximo_mantenimiento IN mantenimiento_aviones.proximo_mantenimiento%TYPE,
        p_costo                 IN mantenimiento_aviones.costo%TYPE,
        p_taller                IN mantenimiento_aviones.taller%TYPE,
        p_tecnico_responsable   IN mantenimiento_aviones.tecnico_responsable%TYPE
    ) IS
    BEGIN
        UPDATE mantenimiento_aviones
        SET matricula_avion       = p_matricula_avion,
            id_modelo             = p_id_modelo,
            fecha_mantenimiento   = p_fecha_mantenimiento,
            tipo_mantenimiento    = p_tipo_mantenimiento,
            descripcion           = p_descripcion,
            horas_vuelo_actuales  = p_horas_vuelo_actuales,
            proximo_mantenimiento = p_proximo_mantenimiento,
            costo                 = p_costo,
            taller                = p_taller,
            tecnico_responsable   = p_tecnico_responsable
        WHERE id_mantenimiento = p_id_mantenimiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20102, 'No se encontró el mantenimiento para actualizar.');
        END IF;
    END update_mantenimiento;

    PROCEDURE delete_mantenimiento(
        p_id_mantenimiento IN mantenimiento_aviones.id_mantenimiento%TYPE
    ) IS
    BEGIN
        DELETE FROM mantenimiento_aviones
        WHERE id_mantenimiento = p_id_mantenimiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20103, 'No se encontró el mantenimiento para eliminar.');
        END IF;
    END delete_mantenimiento;

END pkg_mantenimiento_aviones;
/