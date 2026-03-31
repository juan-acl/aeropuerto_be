------------------------------------------------------------
-- Paquete CRUD para la tabla ESTACIONAMIENTO_REGISTRO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_estacionamiento_registro AS
    PROCEDURE insert_registro(
        p_id_espacio       IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_id_vuelo         IN NUMBER,
        p_placa_vehiculo   IN VARCHAR2,
        p_fecha_entrada    IN TIMESTAMP,
        p_fecha_salida     IN TIMESTAMP,
        p_tiempo_total_horas IN NUMBER,
        p_tarifa_aplicada  IN NUMBER,
        p_total_pagar      IN NUMBER,
        p_estado_pago      IN NUMBER DEFAULT 0,
        p_metodo_pago      IN VARCHAR2
    );

    PROCEDURE get_registro(
        p_id_registro IN NUMBER
    );

    PROCEDURE update_registro(
        p_id_registro      IN NUMBER,
        p_id_espacio       IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_id_vuelo         IN NUMBER,
        p_placa_vehiculo   IN VARCHAR2,
        p_fecha_entrada    IN TIMESTAMP,
        p_fecha_salida     IN TIMESTAMP,
        p_tiempo_total_horas IN NUMBER,
        p_tarifa_aplicada  IN NUMBER,
        p_total_pagar      IN NUMBER,
        p_estado_pago      IN NUMBER,
        p_metodo_pago      IN VARCHAR2
    );

    PROCEDURE delete_registro(
        p_id_registro IN NUMBER
    );
END pkg_estacionamiento_registro;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_estacionamiento_registro AS

    PROCEDURE insert_registro(
        p_id_espacio       IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_id_vuelo         IN NUMBER,
        p_placa_vehiculo   IN VARCHAR2,
        p_fecha_entrada    IN TIMESTAMP,
        p_fecha_salida     IN TIMESTAMP,
        p_tiempo_total_horas IN NUMBER,
        p_tarifa_aplicada  IN NUMBER,
        p_total_pagar      IN NUMBER,
        p_estado_pago      IN NUMBER,
        p_metodo_pago      IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO estacionamiento_registro (
            id_espacio, id_pasajero, id_vuelo, placa_vehiculo,
            fecha_entrada, fecha_salida, tiempo_total_horas,
            tarifa_aplicada, total_pagar, estado_pago, metodo_pago
        ) VALUES (
            p_id_espacio, p_id_pasajero, p_id_vuelo, p_placa_vehiculo,
            p_fecha_entrada, p_fecha_salida, p_tiempo_total_horas,
            p_tarifa_aplicada, p_total_pagar, NVL(p_estado_pago,0), p_metodo_pago
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25501, 'Error al insertar registro de estacionamiento: ' || SQLERRM);
    END insert_registro;

    PROCEDURE get_registro(
        p_id_registro IN NUMBER
    ) IS
        r estacionamiento_registro%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM estacionamiento_registro
        WHERE id_registro = p_id_registro;

        DBMS_OUTPUT.PUT_LINE('ID Registro: ' || r.id_registro);
        DBMS_OUTPUT.PUT_LINE('Espacio: ' || r.id_espacio);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Placa vehículo: ' || r.placa_vehiculo);
        DBMS_OUTPUT.PUT_LINE('Fecha entrada: ' || r.fecha_entrada);
        DBMS_OUTPUT.PUT_LINE('Fecha salida: ' || r.fecha_salida);
        DBMS_OUTPUT.PUT_LINE('Tiempo total (horas): ' || r.tiempo_total_horas);
        DBMS_OUTPUT.PUT_LINE('Tarifa aplicada: ' || r.tarifa_aplicada);
        DBMS_OUTPUT.PUT_LINE('Total a pagar: ' || r.total_pagar);
        DBMS_OUTPUT.PUT_LINE('Estado pago: ' || r.estado_pago);
        DBMS_OUTPUT.PUT_LINE('Método pago: ' || r.metodo_pago);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Registro de estacionamiento no encontrado.');
    END get_registro;

    PROCEDURE update_registro(
        p_id_registro      IN NUMBER,
        p_id_espacio       IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_id_vuelo         IN NUMBER,
        p_placa_vehiculo   IN VARCHAR2,
        p_fecha_entrada    IN TIMESTAMP,
        p_fecha_salida     IN TIMESTAMP,
        p_tiempo_total_horas IN NUMBER,
        p_tarifa_aplicada  IN NUMBER,
        p_total_pagar      IN NUMBER,
        p_estado_pago      IN NUMBER,
        p_metodo_pago      IN VARCHAR2
    ) IS
    BEGIN
        UPDATE estacionamiento_registro
        SET id_espacio       = p_id_espacio,
            id_pasajero      = p_id_pasajero,
            id_vuelo         = p_id_vuelo,
            placa_vehiculo   = p_placa_vehiculo,
            fecha_entrada    = p_fecha_entrada,
            fecha_salida     = p_fecha_salida,
            tiempo_total_horas = p_tiempo_total_horas,
            tarifa_aplicada  = p_tarifa_aplicada,
            total_pagar      = p_total_pagar,
            estado_pago      = p_estado_pago,
            metodo_pago      = p_metodo_pago
        WHERE id_registro = p_id_registro;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25502, 'No se encontró el registro de estacionamiento para actualizar.');
        END IF;
    END update_registro;

    PROCEDURE delete_registro(
        p_id_registro IN NUMBER
    ) IS
    BEGIN
        DELETE FROM estacionamiento_registro
        WHERE id_registro = p_id_registro;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25503, 'No se encontró el registro de estacionamiento para eliminar.');
        END IF;
    END delete_registro;

END pkg_estacionamiento_registro;
/