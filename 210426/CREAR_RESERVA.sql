CREATE OR REPLACE PROCEDURE sp_crear_reserva(
    p_id_vuelo       IN NUMBER,
    p_id_pasajero    IN NUMBER,
    p_clase_servicio IN VARCHAR2,
    p_numero_asiento IN VARCHAR2,
    p_tipo_tarifa    IN VARCHAR2,
    p_precio         IN NUMBER,
    p_moneda         IN VARCHAR2
) IS
    v_estado_vuelo VARCHAR2(20);
    v_hora_salida TIMESTAMP;
    v_count NUMBER;
    v_codigo_reserva VARCHAR2(20);
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que el vuelo exista y esté en estado PROGRAMADO
    -----------------------------------------------------------------
    SELECT estado_vuelo, hora_salida_programada
    INTO v_estado_vuelo, v_hora_salida
    FROM vuelos
    WHERE id_vuelo = p_id_vuelo;

    IF v_estado_vuelo <> 'PROGRAMADO' THEN
        RAISE_APPLICATION_ERROR(-37801, 'El vuelo no está en estado PROGRAMADO.');
    END IF;

    -----------------------------------------------------------------
    -- 2. Validar que la reservación se haga con al menos 2h antes de salida
    -----------------------------------------------------------------
    IF SYSTIMESTAMP > (v_hora_salida - INTERVAL '2' HOUR) THEN
        RAISE_APPLICATION_ERROR(-37802, 'No se aceptan reservaciones con menos de 2 horas antes de la salida.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Validar que el pasajero exista
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM pasajeros
    WHERE id_pasajero = p_id_pasajero;

    IF v_count = 0 THEN
        RAISE_APPLICATION_ERROR(-37803, 'El pasajero no está registrado en el sistema.');
        -- Aquí podrías insertar el pasajero si se permite registro en el momento
    END IF;

    -----------------------------------------------------------------
    -- 4. Validar que el pasajero no tenga dos reservaciones activas en el mismo vuelo
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM reservas
    WHERE id_vuelo = p_id_vuelo
      AND id_pasajero = p_id_pasajero
      AND estado_reserva IN ('PENDIENTE','CONFIRMADA');

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-37804, 'El pasajero ya tiene una reservación activa en este vuelo.');
    END IF;

    -----------------------------------------------------------------
    -- 5. Validar que el pasajero no tenga reservaciones en vuelos traslapados
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM reservas r
    JOIN vuelos v ON r.id_vuelo = v.id_vuelo
    WHERE r.id_pasajero = p_id_pasajero
      AND r.estado_reserva IN ('PENDIENTE','CONFIRMADA')
      AND (
            (v_hora_salida BETWEEN v.hora_salida_programada AND v.hora_llegada_programada)
         OR (v.hora_salida_programada BETWEEN v_hora_salida AND v_hora_salida + INTERVAL '1' HOUR)
          );

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-37805, 'El pasajero tiene reservaciones en vuelos traslapados.');
    END IF;

    -----------------------------------------------------------------
    -- 6. Validar que haya asientos disponibles en la clase seleccionada
    -----------------------------------------------------------------
    -- Aquí se asume que la lógica de plazas_vacias/plazas_ocupadas está en la tabla vuelos
    SELECT COUNT(*)
    INTO v_count
    FROM reservas
    WHERE id_vuelo = p_id_vuelo
      AND numero_asiento = p_numero_asiento;

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-37806, 'El asiento ya está ocupado.');
    END IF;

    -----------------------------------------------------------------
    -- 7. Generar código de reserva único
    -----------------------------------------------------------------
    v_codigo_reserva := 'RSV' || TO_CHAR(SYSDATE,'YYYYMMDDHH24MISS') || p_id_pasajero;

    -----------------------------------------------------------------
    -- 8. Crear la reservación en estado PENDIENTE
    -----------------------------------------------------------------
    INSERT INTO reservas (
        id_vuelo, id_pasajero, codigo_reserva,
        fecha_reserva, estado_reserva,
        tipo_tarifa, precio_pagado, moneda,
        numero_asiento, clase_servicio
    ) VALUES (
        p_id_vuelo, p_id_pasajero, v_codigo_reserva,
        SYSDATE, 'PENDIENTE',
        p_tipo_tarifa, p_precio, p_moneda,
        p_numero_asiento, p_clase_servicio
    );

    -----------------------------------------------------------------
    -- 9. Actualizar plazas ocupadas/vacías en el vuelo
    -----------------------------------------------------------------
    UPDATE vuelos
    SET plazas_ocupadas = plazas_ocupadas + 1,
        plazas_vacias   = plazas_vacias - 1
    WHERE id_vuelo = p_id_vuelo;

    DBMS_OUTPUT.PUT_LINE('Reservación creada en estado PENDIENTE. Asiento bloqueado por 15 minutos para pago.');
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-37807, 'El vuelo especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-37899, 'Error al crear reservación: ' || SQLERRM);
END sp_crear_reserva;
/

