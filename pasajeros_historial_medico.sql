------------------------------------------------------------
-- Paquete CRUD para la tabla PASAJEROS_HISTORIAL_MEDICO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pasajeros_historial_medico AS
    PROCEDURE insert_historial(
        p_id_pasajero                  IN pasajeros_historial_medico.id_pasajero%TYPE,
        p_condicion_medica             IN pasajeros_historial_medico.condicion_medica%TYPE,
        p_requiere_atencion_especial   IN pasajeros_historial_medico.requiere_atencion_especial%TYPE DEFAULT 0,
        p_medicamentos_autorizados     IN pasajeros_historial_medico.medicamentos_autorizados%TYPE,
        p_contacto_emergencia_nombre   IN pasajeros_historial_medico.contacto_emergencia_nombre%TYPE,
        p_contacto_emergencia_telefono IN pasajeros_historial_medico.contacto_emergencia_telefono%TYPE,
        p_contacto_emergencia_relacion IN pasajeros_historial_medico.contacto_emergencia_relacion%TYPE,
        p_ultima_actualizacion         IN pasajeros_historial_medico.ultima_actualizacion%TYPE
    );

    PROCEDURE get_historial(
        p_id_historial_medico IN pasajeros_historial_medico.id_historial_medico%TYPE
    );

    PROCEDURE update_historial(
        p_id_historial_medico          IN pasajeros_historial_medico.id_historial_medico%TYPE,
        p_id_pasajero                  IN pasajeros_historial_medico.id_pasajero%TYPE,
        p_condicion_medica             IN pasajeros_historial_medico.condicion_medica%TYPE,
        p_requiere_atencion_especial   IN pasajeros_historial_medico.requiere_atencion_especial%TYPE,
        p_medicamentos_autorizados     IN pasajeros_historial_medico.medicamentos_autorizados%TYPE,
        p_contacto_emergencia_nombre   IN pasajeros_historial_medico.contacto_emergencia_nombre%TYPE,
        p_contacto_emergencia_telefono IN pasajeros_historial_medico.contacto_emergencia_telefono%TYPE,
        p_contacto_emergencia_relacion IN pasajeros_historial_medico.contacto_emergencia_relacion%TYPE,
        p_ultima_actualizacion         IN pasajeros_historial_medico.ultima_actualizacion%TYPE
    );

    PROCEDURE delete_historial(
        p_id_historial_medico IN pasajeros_historial_medico.id_historial_medico%TYPE
    );
END pkg_pasajeros_historial_medico;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pasajeros_historial_medico AS

    PROCEDURE insert_historial(
        p_id_pasajero                  IN pasajeros_historial_medico.id_pasajero%TYPE,
        p_condicion_medica             IN pasajeros_historial_medico.condicion_medica%TYPE,
        p_requiere_atencion_especial   IN pasajeros_historial_medico.requiere_atencion_especial%TYPE,
        p_medicamentos_autorizados     IN pasajeros_historial_medico.medicamentos_autorizados%TYPE,
        p_contacto_emergencia_nombre   IN pasajeros_historial_medico.contacto_emergencia_nombre%TYPE,
        p_contacto_emergencia_telefono IN pasajeros_historial_medico.contacto_emergencia_telefono%TYPE,
        p_contacto_emergencia_relacion IN pasajeros_historial_medico.contacto_emergencia_relacion%TYPE,
        p_ultima_actualizacion         IN pasajeros_historial_medico.ultima_actualizacion%TYPE
    ) IS
    BEGIN
        INSERT INTO pasajeros_historial_medico (
            id_pasajero, condicion_medica, requiere_atencion_especial,
            medicamentos_autorizados, contacto_emergencia_nombre,
            contacto_emergencia_telefono, contacto_emergencia_relacion,
            ultima_actualizacion
        ) VALUES (
            p_id_pasajero, p_condicion_medica, NVL(p_requiere_atencion_especial,0),
            p_medicamentos_autorizados, p_contacto_emergencia_nombre,
            p_contacto_emergencia_telefono, p_contacto_emergencia_relacion,
            p_ultima_actualizacion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22001, 'Error al insertar historial médico: ' || SQLERRM);
    END insert_historial;

    PROCEDURE get_historial(
        p_id_historial_medico IN pasajeros_historial_medico.id_historial_medico%TYPE
    ) IS
        r pasajeros_historial_medico%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM pasajeros_historial_medico
        WHERE id_historial_medico = p_id_historial_medico;

        DBMS_OUTPUT.PUT_LINE('ID Historial: ' || r.id_historial_medico);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Condición médica: ' || r.condicion_medica);
        DBMS_OUTPUT.PUT_LINE('Requiere atención especial: ' || r.requiere_atencion_especial);
        DBMS_OUTPUT.PUT_LINE('Medicamentos autorizados: ' || r.medicamentos_autorizados);
        DBMS_OUTPUT.PUT_LINE('Contacto emergencia: ' || r.contacto_emergencia_nombre);
        DBMS_OUTPUT.PUT_LINE('Teléfono contacto: ' || r.contacto_emergencia_telefono);
        DBMS_OUTPUT.PUT_LINE('Relación: ' || r.contacto_emergencia_relacion);
        DBMS_OUTPUT.PUT_LINE('Última actualización: ' || r.ultima_actualizacion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Historial médico no encontrado.');
    END get_historial;

    PROCEDURE update_historial(
        p_id_historial_medico          IN pasajeros_historial_medico.id_historial_medico%TYPE,
        p_id_pasajero                  IN pasajeros_historial_medico.id_pasajero%TYPE,
        p_condicion_medica             IN pasajeros_historial_medico.condicion_medica%TYPE,
        p_requiere_atencion_especial   IN pasajeros_historial_medico.requiere_atencion_especial%TYPE,
        p_medicamentos_autorizados     IN pasajeros_historial_medico.medicamentos_autorizados%TYPE,
        p_contacto_emergencia_nombre   IN pasajeros_historial_medico.contacto_emergencia_nombre%TYPE,
        p_contacto_emergencia_telefono IN pasajeros_historial_medico.contacto_emergencia_telefono%TYPE,
        p_contacto_emergencia_relacion IN pasajeros_historial_medico.contacto_emergencia_relacion%TYPE,
        p_ultima_actualizacion         IN pasajeros_historial_medico.ultima_actualizacion%TYPE
    ) IS
    BEGIN
        UPDATE pasajeros_historial_medico
        SET id_pasajero                  = p_id_pasajero,
            condicion_medica             = p_condicion_medica,
            requiere_atencion_especial   = p_requiere_atencion_especial,
            medicamentos_autorizados     = p_medicamentos_autorizados,
            contacto_emergencia_nombre   = p_contacto_emergencia_nombre,
            contacto_emergencia_telefono = p_contacto_emergencia_telefono,
            contacto_emergencia_relacion = p_contacto_emergencia_relacion,
            ultima_actualizacion         = p_ultima_actualizacion
        WHERE id_historial_medico = p_id_historial_medico;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22002, 'No se encontró el historial médico para actualizar.');
        END IF;
    END update_historial;

    PROCEDURE delete_historial(
        p_id_historial_medico IN pasajeros_historial_medico.id_historial_medico%TYPE
    ) IS
    BEGIN
        DELETE FROM pasajeros_historial_medico
        WHERE id_historial_medico = p_id_historial_medico;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22003, 'No se encontró el historial médico para eliminar.');
        END IF;
    END delete_historial;

END pkg_pasajeros_historial_medico;
/