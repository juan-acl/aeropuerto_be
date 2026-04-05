------------------------------------------------------------
-- Paquete CRUD para la tabla ASIGNACION_VEHICULOS_RUTAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_asignacion_vehiculos_rutas AS
    PROCEDURE insert_asignacion(
        p_id_vehiculo_transporte   IN NUMBER,
        p_id_ruta_transporte       IN NUMBER,
        p_fecha_asignacion         IN DATE DEFAULT SYSDATE,
        p_fecha_inicio_vigencia    IN DATE,
        p_fecha_fin_vigencia       IN DATE,
        p_horario_servicio         IN VARCHAR2,
        p_activa                   IN NUMBER DEFAULT 1
    );

    PROCEDURE get_asignacion(
        p_id_asignacion_vehiculo_ruta IN NUMBER
    );

    PROCEDURE update_asignacion(
        p_id_asignacion_vehiculo_ruta IN NUMBER,
        p_id_vehiculo_transporte   IN NUMBER,
        p_id_ruta_transporte       IN NUMBER,
        p_fecha_asignacion         IN DATE,
        p_fecha_inicio_vigencia    IN DATE,
        p_fecha_fin_vigencia       IN DATE,
        p_horario_servicio         IN VARCHAR2,
        p_activa                   IN NUMBER
    );

    PROCEDURE delete_asignacion(
        p_id_asignacion_vehiculo_ruta IN NUMBER
    );
END pkg_asignacion_vehiculos_rutas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_asignacion_vehiculos_rutas AS

    PROCEDURE insert_asignacion(
        p_id_vehiculo_transporte   IN NUMBER,
        p_id_ruta_transporte       IN NUMBER,
        p_fecha_asignacion         IN DATE,
        p_fecha_inicio_vigencia    IN DATE,
        p_fecha_fin_vigencia       IN DATE,
        p_horario_servicio         IN VARCHAR2,
        p_activa                   IN NUMBER
    ) IS
    BEGIN
        INSERT INTO asignacion_vehiculos_rutas (
            id_vehiculo_transporte, id_ruta_transporte,
            fecha_asignacion, fecha_inicio_vigencia, fecha_fin_vigencia,
            horario_servicio, activa
        ) VALUES (
            p_id_vehiculo_transporte, p_id_ruta_transporte,
            NVL(p_fecha_asignacion, SYSDATE), p_fecha_inicio_vigencia, p_fecha_fin_vigencia,
            p_horario_servicio, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34801, 'Error al insertar asignación de vehículo a ruta: ' || SQLERRM);
    END insert_asignacion;

    PROCEDURE get_asignacion(
        p_id_asignacion_vehiculo_ruta IN NUMBER
    ) IS
        r asignacion_vehiculos_rutas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM asignacion_vehiculos_rutas
        WHERE id_asignacion_vehiculo_ruta = p_id_asignacion_vehiculo_ruta;

        DBMS_OUTPUT.PUT_LINE('ID Asignación: ' || r.id_asignacion_vehiculo_ruta);
        DBMS_OUTPUT.PUT_LINE('Vehículo: ' || r.id_vehiculo_transporte);
        DBMS_OUTPUT.PUT_LINE('Ruta: ' || r.id_ruta_transporte);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Inicio vigencia: ' || r.fecha_inicio_vigencia);
        DBMS_OUTPUT.PUT_LINE('Fin vigencia: ' || r.fecha_fin_vigencia);
        DBMS_OUTPUT.PUT_LINE('Horario servicio: ' || r.horario_servicio);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Asignación de vehículo a ruta no encontrada.');
    END get_asignacion;

    PROCEDURE update_asignacion(
        p_id_asignacion_vehiculo_ruta IN NUMBER,
        p_id_vehiculo_transporte   IN NUMBER,
        p_id_ruta_transporte       IN NUMBER,
        p_fecha_asignacion         IN DATE,
        p_fecha_inicio_vigencia    IN DATE,
        p_fecha_fin_vigencia       IN DATE,
        p_horario_servicio         IN VARCHAR2,
        p_activa                   IN NUMBER
    ) IS
    BEGIN
        UPDATE asignacion_vehiculos_rutas
        SET id_vehiculo_transporte   = p_id_vehiculo_transporte,
            id_ruta_transporte       = p_id_ruta_transporte,
            fecha_asignacion         = p_fecha_asignacion,
            fecha_inicio_vigencia    = p_fecha_inicio_vigencia,
            fecha_fin_vigencia       = p_fecha_fin_vigencia,
            horario_servicio         = p_horario_servicio,
            activa                   = p_activa
        WHERE id_asignacion_vehiculo_ruta = p_id_asignacion_vehiculo_ruta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34802, 'No se encontró la asignación de vehículo a ruta para actualizar.');
        END IF;
    END update_asignacion;

    PROCEDURE delete_asignacion(
        p_id_asignacion_vehiculo_ruta IN NUMBER
    ) IS
    BEGIN
        DELETE FROM asignacion_vehiculos_rutas
        WHERE id_asignacion_vehiculo_ruta = p_id_asignacion_vehiculo_ruta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34803, 'No se encontró la asignación de vehículo a ruta para eliminar.');
        END IF;
    END delete_asignacion;

END pkg_asignacion_vehiculos_rutas;
/
