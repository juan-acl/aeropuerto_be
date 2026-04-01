------------------------------------------------------------
-- Paquete CRUD para la tabla SLOTS_AEROPUERTO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_slots_aeropuerto AS
    PROCEDURE insert_slot(
        p_id_aerolinea       IN NUMBER,
        p_fecha_slot         IN DATE,
        p_hora_slot          IN TIMESTAMP,
        p_tipo_operacion     IN VARCHAR2,
        p_id_vuelo_asignado  IN NUMBER,
        p_estado_slot        IN VARCHAR2 DEFAULT 'DISPONIBLE',
        p_fecha_asignacion   IN TIMESTAMP,
        p_asignado_por       IN NUMBER,
        p_fecha_liberacion   IN TIMESTAMP,
        p_motivo_cancelacion IN VARCHAR2
    );

    PROCEDURE get_slot(
        p_id_slot IN NUMBER
    );

    PROCEDURE update_slot(
        p_id_slot            IN NUMBER,
        p_id_aerolinea       IN NUMBER,
        p_fecha_slot         IN DATE,
        p_hora_slot          IN TIMESTAMP,
        p_tipo_operacion     IN VARCHAR2,
        p_id_vuelo_asignado  IN NUMBER,
        p_estado_slot        IN VARCHAR2,
        p_fecha_asignacion   IN TIMESTAMP,
        p_asignado_por       IN NUMBER,
        p_fecha_liberacion   IN TIMESTAMP,
        p_motivo_cancelacion IN VARCHAR2
    );

    PROCEDURE delete_slot(
        p_id_slot IN NUMBER
    );
END pkg_slots_aeropuerto;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_slots_aeropuerto AS

    PROCEDURE insert_slot(
        p_id_aerolinea       IN NUMBER,
        p_fecha_slot         IN DATE,
        p_hora_slot          IN TIMESTAMP,
        p_tipo_operacion     IN VARCHAR2,
        p_id_vuelo_asignado  IN NUMBER,
        p_estado_slot        IN VARCHAR2,
        p_fecha_asignacion   IN TIMESTAMP,
        p_asignado_por       IN NUMBER,
        p_fecha_liberacion   IN TIMESTAMP,
        p_motivo_cancelacion IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO slots_aeropuerto (
            id_aerolinea, fecha_slot, hora_slot, tipo_operacion,
            id_vuelo_asignado, estado_slot, fecha_asignacion,
            asignado_por, fecha_liberacion, motivo_cancelacion
        ) VALUES (
            p_id_aerolinea, p_fecha_slot, p_hora_slot, p_tipo_operacion,
            p_id_vuelo_asignado, NVL(p_estado_slot,'DISPONIBLE'), p_fecha_asignacion,
            p_asignado_por, p_fecha_liberacion, p_motivo_cancelacion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30101, 'Error al insertar slot de aeropuerto: ' || SQLERRM);
    END insert_slot;

    PROCEDURE get_slot(
        p_id_slot IN NUMBER
    ) IS
        r slots_aeropuerto%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM slots_aeropuerto
        WHERE id_slot = p_id_slot;

        DBMS_OUTPUT.PUT_LINE('ID Slot: ' || r.id_slot);
        DBMS_OUTPUT.PUT_LINE('Aerolínea: ' || r.id_aerolinea);
        DBMS_OUTPUT.PUT_LINE('Fecha slot: ' || r.fecha_slot);
        DBMS_OUTPUT.PUT_LINE('Hora slot: ' || r.hora_slot);
        DBMS_OUTPUT.PUT_LINE('Tipo operación: ' || r.tipo_operacion);
        DBMS_OUTPUT.PUT_LINE('Vuelo asignado: ' || r.id_vuelo_asignado);
        DBMS_OUTPUT.PUT_LINE('Estado slot: ' || r.estado_slot);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Asignado por: ' || r.asignado_por);
        DBMS_OUTPUT.PUT_LINE('Fecha liberación: ' || r.fecha_liberacion);
        DBMS_OUTPUT.PUT_LINE('Motivo cancelación: ' || r.motivo_cancelacion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Slot de aeropuerto no encontrado.');
    END get_slot;

    PROCEDURE update_slot(
        p_id_slot            IN NUMBER,
        p_id_aerolinea       IN NUMBER,
        p_fecha_slot         IN DATE,
        p_hora_slot          IN TIMESTAMP,
        p_tipo_operacion     IN VARCHAR2,
        p_id_vuelo_asignado  IN NUMBER,
        p_estado_slot        IN VARCHAR2,
        p_fecha_asignacion   IN TIMESTAMP,
        p_asignado_por       IN NUMBER,
        p_fecha_liberacion   IN TIMESTAMP,
        p_motivo_cancelacion IN VARCHAR2
    ) IS
    BEGIN
        UPDATE slots_aeropuerto
        SET id_aerolinea       = p_id_aerolinea,
            fecha_slot         = p_fecha_slot,
            hora_slot          = p_hora_slot,
            tipo_operacion     = p_tipo_operacion,
            id_vuelo_asignado  = p_id_vuelo_asignado,
            estado_slot        = p_estado_slot,
            fecha_asignacion   = p_fecha_asignacion,
            asignado_por       = p_asignado_por,
            fecha_liberacion   = p_fecha_liberacion,
            motivo_cancelacion = p_motivo_cancelacion
        WHERE id_slot = p_id_slot;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30102, 'No se encontró el slot de aeropuerto para actualizar.');
        END IF;
    END update_slot;

    PROCEDURE delete_slot(
        p_id_slot IN NUMBER
    ) IS
    BEGIN
        DELETE FROM slots_aeropuerto
        WHERE id_slot = p_id_slot;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30103, 'No se encontró el slot de aeropuerto para eliminar.');
        END IF;
    END delete_slot;

END pkg_slots_aeropuerto;
/
