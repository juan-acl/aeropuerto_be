------------------------------------------------------------
-- Paquete CRUD para la tabla RESERVAS_TRANSPORTE_TERRESTRE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_reservas_transporte AS
    PROCEDURE insert_reserva(
        p_codigo_reserva_transporte IN VARCHAR2,
        p_id_pasajero               IN NUMBER,
        p_id_ruta_transporte        IN NUMBER,
        p_tipo_servicio             IN VARCHAR2,
        p_fecha_reserva             IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_fecha_servicio            IN DATE,
        p_hora_recogida             IN TIMESTAMP,
        p_lugar_recogida            IN VARCHAR2,
        p_lugar_destino             IN VARCHAR2,
        p_numero_pasajeros          IN NUMBER DEFAULT 1,
        p_cantidad_maletas          IN NUMBER,
        p_id_vuelo_asociado         IN NUMBER,
        p_instrucciones_especiales  IN VARCHAR2,
        p_estado_reserva            IN VARCHAR2 DEFAULT 'CONFIRMADA',
        p_precio_total              IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_pagado                    IN NUMBER DEFAULT 0
    );

    PROCEDURE get_reserva(
        p_id_reserva_transporte IN NUMBER
    );

    PROCEDURE update_reserva(
        p_id_reserva_transporte     IN NUMBER,
        p_codigo_reserva_transporte IN VARCHAR2,
        p_id_pasajero               IN NUMBER,
        p_id_ruta_transporte        IN NUMBER,
        p_tipo_servicio             IN VARCHAR2,
        p_fecha_reserva             IN TIMESTAMP,
        p_fecha_servicio            IN DATE,
        p_hora_recogida             IN TIMESTAMP,
        p_lugar_recogida            IN VARCHAR2,
        p_lugar_destino             IN VARCHAR2,
        p_numero_pasajeros          IN NUMBER,
        p_cantidad_maletas          IN NUMBER,
        p_id_vuelo_asociado         IN NUMBER,
        p_instrucciones_especiales  IN VARCHAR2,
        p_estado_reserva            IN VARCHAR2,
        p_precio_total              IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_pagado                    IN NUMBER
    );

    PROCEDURE delete_reserva(
        p_id_reserva_transporte IN NUMBER
    );
END pkg_reservas_transporte;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_reservas_transporte AS

    PROCEDURE insert_reserva(
        p_codigo_reserva_transporte IN VARCHAR2,
        p_id_pasajero               IN NUMBER,
        p_id_ruta_transporte        IN NUMBER,
        p_tipo_servicio             IN VARCHAR2,
        p_fecha_reserva             IN TIMESTAMP,
        p_fecha_servicio            IN DATE,
        p_hora_recogida             IN TIMESTAMP,
        p_lugar_recogida            IN VARCHAR2,
        p_lugar_destino             IN VARCHAR2,
        p_numero_pasajeros          IN NUMBER,
        p_cantidad_maletas          IN NUMBER,
        p_id_vuelo_asociado         IN NUMBER,
        p_instrucciones_especiales  IN VARCHAR2,
        p_estado_reserva            IN VARCHAR2,
        p_precio_total              IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_pagado                    IN NUMBER
    ) IS
    BEGIN
        INSERT INTO reservas_transporte_terrestre (
            codigo_reserva_transporte, id_pasajero, id_ruta_transporte,
            tipo_servicio, fecha_reserva, fecha_servicio, hora_recogida,
            lugar_recogida, lugar_destino, numero_pasajeros, cantidad_maletas,
            id_vuelo_asociado, instrucciones_especiales, estado_reserva,
            precio_total, moneda, pagado
        ) VALUES (
            p_codigo_reserva_transporte, p_id_pasajero, p_id_ruta_transporte,
            p_tipo_servicio, NVL(p_fecha_reserva, SYSTIMESTAMP), p_fecha_servicio, p_hora_recogida,
            p_lugar_recogida, p_lugar_destino, NVL(p_numero_pasajeros,1), p_cantidad_maletas,
            p_id_vuelo_asociado, p_instrucciones_especiales, NVL(p_estado_reserva,'CONFIRMADA'),
            p_precio_total, p_moneda, NVL(p_pagado,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34901, 'Error al insertar reserva de transporte terrestre: ' || SQLERRM);
    END insert_reserva;

    PROCEDURE get_reserva(
        p_id_reserva_transporte IN NUMBER
    ) IS
        r reservas_transporte_terrestre%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM reservas_transporte_terrestre
        WHERE id_reserva_transporte = p_id_reserva_transporte;

        DBMS_OUTPUT.PUT_LINE('ID Reserva: ' || r.id_reserva_transporte);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_reserva_transporte);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Ruta transporte: ' || r.id_ruta_transporte);
        DBMS_OUTPUT.PUT_LINE('Tipo servicio: ' || r.tipo_servicio);
        DBMS_OUTPUT.PUT_LINE('Fecha reserva: ' || r.fecha_reserva);
        DBMS_OUTPUT.PUT_LINE('Fecha servicio: ' || r.fecha_servicio);
        DBMS_OUTPUT.PUT_LINE('Hora recogida: ' || r.hora_recogida);
        DBMS_OUTPUT.PUT_LINE('Lugar recogida: ' || r.lugar_recogida);
        DBMS_OUTPUT.PUT_LINE('Lugar destino: ' || r.lugar_destino);
        DBMS_OUTPUT.PUT_LINE('Número pasajeros: ' || r.numero_pasajeros);
        DBMS_OUTPUT.PUT_LINE('Cantidad maletas: ' || r.cantidad_maletas);
        DBMS_OUTPUT.PUT_LINE('Vuelo asociado: ' || r.id_vuelo_asociado);
        DBMS_OUTPUT.PUT_LINE('Instrucciones especiales: ' || r.instrucciones_especiales);
        DBMS_OUTPUT.PUT_LINE('Estado reserva: ' || r.estado_reserva);
        DBMS_OUTPUT.PUT_LINE('Precio total: ' || r.precio_total || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Pagado: ' || r.pagado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Reserva de transporte terrestre no encontrada.');
    END get_reserva;

    PROCEDURE update_reserva(
        p_id_reserva_transporte     IN NUMBER,
        p_codigo_reserva_transporte IN VARCHAR2,
        p_id_pasajero               IN NUMBER,
        p_id_ruta_transporte        IN NUMBER,
        p_tipo_servicio             IN VARCHAR2,
        p_fecha_reserva             IN TIMESTAMP,
        p_fecha_servicio            IN DATE,
        p_hora_recogida             IN TIMESTAMP,
        p_lugar_recogida            IN VARCHAR2,
        p_lugar_destino             IN VARCHAR2,
        p_numero_pasajeros          IN NUMBER,
        p_cantidad_maletas          IN NUMBER,
        p_id_vuelo_asociado         IN NUMBER,
        p_instrucciones_especiales  IN VARCHAR2,
        p_estado_reserva            IN VARCHAR2,
        p_precio_total              IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_pagado                    IN NUMBER
    ) IS
    BEGIN
        UPDATE reservas_transporte_terrestre
        SET codigo_reserva_transporte = p_codigo_reserva_transporte,
            id_pasajero               = p_id_pasajero,
            id_ruta_transporte        = p_id_ruta_transporte,
            tipo_servicio             = p_tipo_servicio,
            fecha_reserva             = p_fecha_reserva,
            fecha_servicio            = p_fecha_servicio,
            hora_recogida             = p_hora_recogida,
            lugar_recogida            = p_lugar_recogida,
            lugar_destino             = p_lugar_destino,
            numero_pasajeros          = p_numero_pasajeros,
            cantidad_maletas          = p_cantidad_maletas,
            id_vuelo_asociado         = p_id_vuelo_asociado,
            instrucciones_especiales  = p_instrucciones_especiales,
            estado_reserva            = p_estado_reserva,
            precio_total              = p_precio_total,
            moneda                    = p_moneda,
            pagado                    = p_pagado
        WHERE id_reserva_transporte = p_id_reserva_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34902, 'No se encontró la reserva de transporte terrestre para actualizar.');
        END IF;
    END update_reserva;

    PROCEDURE delete_reserva(
        p_id_reserva_transporte IN NUMBER
    ) IS
    BEGIN
        DELETE FROM reservas_transporte_terrestre
        WHERE id_reserva_transporte = p_id_reserva_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34903, 'No se encontró la reserva de transporte terrestre para eliminar.');
        END IF;
    END delete_reserva;

END pkg_reservas_transporte;
/
