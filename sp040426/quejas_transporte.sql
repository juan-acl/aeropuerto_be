------------------------------------------------------------
-- Paquete CRUD para la tabla QUEJAS_TRANSPORTE_TERRESTRE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_quejas_transporte AS
    PROCEDURE insert_queja(
        p_id_reserva_transporte   IN NUMBER,
        p_id_pasajero             IN NUMBER,
        p_fecha_queja             IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_tipo_queja              IN VARCHAR2,
        p_descripcion_queja       IN VARCHAR2,
        p_evidencia               IN BLOB,
        p_estado                  IN VARCHAR2 DEFAULT 'RECIBIDA',
        p_fecha_resolucion        IN TIMESTAMP,
        p_resolucion              IN VARCHAR2,
        p_compensacion_ofrecida   IN VARCHAR2,
        p_resuelto_por            IN NUMBER,
        p_satisfaccion_pasajero   IN NUMBER
    );

    PROCEDURE get_queja(
        p_id_queja_transporte IN NUMBER
    );

    PROCEDURE update_queja(
        p_id_queja_transporte     IN NUMBER,
        p_id_reserva_transporte   IN NUMBER,
        p_id_pasajero             IN NUMBER,
        p_fecha_queja             IN TIMESTAMP,
        p_tipo_queja              IN VARCHAR2,
        p_descripcion_queja       IN VARCHAR2,
        p_evidencia               IN BLOB,
        p_estado                  IN VARCHAR2,
        p_fecha_resolucion        IN TIMESTAMP,
        p_resolucion              IN VARCHAR2,
        p_compensacion_ofrecida   IN VARCHAR2,
        p_resuelto_por            IN NUMBER,
        p_satisfaccion_pasajero   IN NUMBER
    );

    PROCEDURE delete_queja(
        p_id_queja_transporte IN NUMBER
    );
END pkg_quejas_transporte;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_quejas_transporte AS

    PROCEDURE insert_queja(
        p_id_reserva_transporte   IN NUMBER,
        p_id_pasajero             IN NUMBER,
        p_fecha_queja             IN TIMESTAMP,
        p_tipo_queja              IN VARCHAR2,
        p_descripcion_queja       IN VARCHAR2,
        p_evidencia               IN BLOB,
        p_estado                  IN VARCHAR2,
        p_fecha_resolucion        IN TIMESTAMP,
        p_resolucion              IN VARCHAR2,
        p_compensacion_ofrecida   IN VARCHAR2,
        p_resuelto_por            IN NUMBER,
        p_satisfaccion_pasajero   IN NUMBER
    ) IS
    BEGIN
        INSERT INTO quejas_transporte_terrestre (
            id_reserva_transporte, id_pasajero, fecha_queja,
            tipo_queja, descripcion_queja, evidencia,
            estado, fecha_resolucion, resolucion,
            compensacion_ofrecida, resuelto_por, satisfaccion_pasajero
        ) VALUES (
            p_id_reserva_transporte, p_id_pasajero, NVL(p_fecha_queja, SYSTIMESTAMP),
            p_tipo_queja, p_descripcion_queja, p_evidencia,
            NVL(p_estado,'RECIBIDA'), p_fecha_resolucion, p_resolucion,
            p_compensacion_ofrecida, p_resuelto_por, p_satisfaccion_pasajero
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35401, 'Error al insertar queja de transporte terrestre: ' || SQLERRM);
    END insert_queja;

    PROCEDURE get_queja(
        p_id_queja_transporte IN NUMBER
    ) IS
        r quejas_transporte_terrestre%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM quejas_transporte_terrestre
        WHERE id_queja_transporte = p_id_queja_transporte;

        DBMS_OUTPUT.PUT_LINE('ID Queja: ' || r.id_queja_transporte);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva_transporte);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Fecha queja: ' || r.fecha_queja);
        DBMS_OUTPUT.PUT_LINE('Tipo queja: ' || r.tipo_queja);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion_queja);
        IF r.evidencia IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Evidencia: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Evidencia: No adjunta');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Fecha resolución: ' || r.fecha_resolucion);
        DBMS_OUTPUT.PUT_LINE('Resolución: ' || r.resolucion);
        DBMS_OUTPUT.PUT_LINE('Compensación ofrecida: ' || r.compensacion_ofrecida);
        DBMS_OUTPUT.PUT_LINE('Resuelto por: ' || r.resuelto_por);
        DBMS_OUTPUT.PUT_LINE('Satisfacción pasajero: ' || r.satisfaccion_pasajero);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Queja de transporte terrestre no encontrada.');
    END get_queja;

    PROCEDURE update_queja(
        p_id_queja_transporte     IN NUMBER,
        p_id_reserva_transporte   IN NUMBER,
        p_id_pasajero             IN NUMBER,
        p_fecha_queja             IN TIMESTAMP,
        p_tipo_queja              IN VARCHAR2,
        p_descripcion_queja       IN VARCHAR2,
        p_evidencia               IN BLOB,
        p_estado                  IN VARCHAR2,
        p_fecha_resolucion        IN TIMESTAMP,
        p_resolucion              IN VARCHAR2,
        p_compensacion_ofrecida   IN VARCHAR2,
        p_resuelto_por            IN NUMBER,
        p_satisfaccion_pasajero   IN NUMBER
    ) IS
    BEGIN
        UPDATE quejas_transporte_terrestre
        SET id_reserva_transporte   = p_id_reserva_transporte,
            id_pasajero             = p_id_pasajero,
            fecha_queja             = p_fecha_queja,
            tipo_queja              = p_tipo_queja,
            descripcion_queja       = p_descripcion_queja,
            evidencia               = p_evidencia,
            estado                  = p_estado,
            fecha_resolucion        = p_fecha_resolucion,
            resolucion              = p_resolucion,
            compensacion_ofrecida   = p_compensacion_ofrecida,
            resuelto_por            = p_resuelto_por,
            satisfaccion_pasajero   = p_satisfaccion_pasajero
        WHERE id_queja_transporte = p_id_queja_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35402, 'No se encontró la queja de transporte terrestre para actualizar.');
        END IF;
    END update_queja;

    PROCEDURE delete_queja(
        p_id_queja_transporte IN NUMBER
    ) IS
    BEGIN
        DELETE FROM quejas_transporte_terrestre
        WHERE id_queja_transporte = p_id_queja_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35403, 'No se encontró la queja de transporte terrestre para eliminar.');
        END IF;
    END delete_queja;

END pkg_quejas_transporte;
/
