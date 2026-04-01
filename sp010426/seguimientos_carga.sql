------------------------------------------------------------
-- Paquete CRUD para la tabla SEGUIMIENTO_CARGA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_seguimiento_carga AS
    PROCEDURE insert_seguimiento(
        p_id_envio             IN NUMBER,
        p_fecha_hora           IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_ubicacion            IN VARCHAR2,
        p_estado               IN VARCHAR2,
        p_responsable          IN VARCHAR2,
        p_observaciones        IN VARCHAR2,
        p_temperatura_registrada IN NUMBER,
        p_incidente            IN NUMBER DEFAULT 0
    );

    PROCEDURE get_seguimiento(
        p_id_seguimiento IN NUMBER
    );

    PROCEDURE update_seguimiento(
        p_id_seguimiento       IN NUMBER,
        p_id_envio             IN NUMBER,
        p_fecha_hora           IN TIMESTAMP,
        p_ubicacion            IN VARCHAR2,
        p_estado               IN VARCHAR2,
        p_responsable          IN VARCHAR2,
        p_observaciones        IN VARCHAR2,
        p_temperatura_registrada IN NUMBER,
        p_incidente            IN NUMBER
    );

    PROCEDURE delete_seguimiento(
        p_id_seguimiento IN NUMBER
    );
END pkg_seguimiento_carga;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_seguimiento_carga AS

    PROCEDURE insert_seguimiento(
        p_id_envio             IN NUMBER,
        p_fecha_hora           IN TIMESTAMP,
        p_ubicacion            IN VARCHAR2,
        p_estado               IN VARCHAR2,
        p_responsable          IN VARCHAR2,
        p_observaciones        IN VARCHAR2,
        p_temperatura_registrada IN NUMBER,
        p_incidente            IN NUMBER
    ) IS
    BEGIN
        INSERT INTO seguimiento_carga (
            id_envio, fecha_hora, ubicacion, estado,
            responsable, observaciones, temperatura_registrada, incidente
        ) VALUES (
            p_id_envio, NVL(p_fecha_hora, SYSTIMESTAMP), p_ubicacion, p_estado,
            p_responsable, p_observaciones, p_temperatura_registrada, NVL(p_incidente,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28901, 'Error al insertar seguimiento de carga: ' || SQLERRM);
    END insert_seguimiento;

    PROCEDURE get_seguimiento(
        p_id_seguimiento IN NUMBER
    ) IS
        r seguimiento_carga%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM seguimiento_carga
        WHERE id_seguimiento = p_id_seguimiento;

        DBMS_OUTPUT.PUT_LINE('ID Seguimiento: ' || r.id_seguimiento);
        DBMS_OUTPUT.PUT_LINE('Envío: ' || r.id_envio);
        DBMS_OUTPUT.PUT_LINE('Fecha/hora: ' || r.fecha_hora);
        DBMS_OUTPUT.PUT_LINE('Ubicación: ' || r.ubicacion);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Responsable: ' || r.responsable);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
        DBMS_OUTPUT.PUT_LINE('Temperatura registrada: ' || r.temperatura_registrada);
        DBMS_OUTPUT.PUT_LINE('Incidente: ' || r.incidente);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Seguimiento de carga no encontrado.');
    END get_seguimiento;

    PROCEDURE update_seguimiento(
        p_id_seguimiento       IN NUMBER,
        p_id_envio             IN NUMBER,
        p_fecha_hora           IN TIMESTAMP,
        p_ubicacion            IN VARCHAR2,
        p_estado               IN VARCHAR2,
        p_responsable          IN VARCHAR2,
        p_observaciones        IN VARCHAR2,
        p_temperatura_registrada IN NUMBER,
        p_incidente            IN NUMBER
    ) IS
    BEGIN
        UPDATE seguimiento_carga
        SET id_envio             = p_id_envio,
            fecha_hora           = p_fecha_hora,
            ubicacion            = p_ubicacion,
            estado               = p_estado,
            responsable          = p_responsable,
            observaciones        = p_observaciones,
            temperatura_registrada = p_temperatura_registrada,
            incidente            = p_incidente
        WHERE id_seguimiento = p_id_seguimiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28902, 'No se encontró el seguimiento de carga para actualizar.');
        END IF;
    END update_seguimiento;

    PROCEDURE delete_seguimiento(
        p_id_seguimiento IN NUMBER
    ) IS
    BEGIN
        DELETE FROM seguimiento_carga
        WHERE id_seguimiento = p_id_seguimiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28903, 'No se encontró el seguimiento de carga para eliminar.');
        END IF;
    END delete_seguimiento;

END pkg_seguimiento_carga;
/
