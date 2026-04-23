CREATE OR REPLACE PROCEDURE sp_checkin_en_linea(
    p_codigo_reserva   IN VARCHAR2,
    p_numero_documento IN VARCHAR2,
    p_numero_asiento   IN VARCHAR2
) IS
    v_id_reserva       NUMBER;
    v_id_vuelo         NUMBER;
    v_estado_reserva   VARCHAR2(20);
    v_estado_vuelo     VARCHAR2(20);
    v_hora_salida      TIMESTAMP;
    v_clase_servicio   VARCHAR2(20);
    v_count            NUMBER;
    v_puerta           VARCHAR2(10);
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que la reservación exista por código o documento
    -----------------------------------------------------------------
    SELECT r.id_reserva, r.id_vuelo, r.estado_reserva, r.clase_servicio,
           v.estado_vuelo, v.hora_salida_programada
    INTO v_id_reserva, v_id_vuelo, v_estado_reserva, v_clase_servicio,
         v_estado_vuelo, v_hora_salida
    FROM reservas r
    JOIN pasajeros p ON r.id_pasajero = p.id_pasajero
    JOIN vuelos v ON r.id_vuelo = v.id_vuelo
    WHERE r.codigo_reserva = p_codigo_reserva
       OR p.numero_documento = p_numero_documento;

    -----------------------------------------------------------------
    -- 2. Validar estado de la reserva y vuelo
    -----------------------------------------------------------------
    IF v_estado_reserva <> 'CONFIRMADA' THEN
        RAISE_APPLICATION_ERROR(-38301, 'La reserva debe estar CONFIRMADA para hacer check-in.');
    END IF;

    IF v_estado_vuelo = 'CANCELADO' THEN
        RAISE_APPLICATION_ERROR(-38302, 'El vuelo está cancelado, no se puede hacer check-in.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Validar ventana de check-in (24h antes, hasta 2h antes)
    -----------------------------------------------------------------
    IF SYSTIMESTAMP < (v_hora_salida - INTERVAL '24' HOUR)
       OR SYSTIMESTAMP > (v_hora_salida - INTERVAL '2' HOUR) THEN
        RAISE_APPLICATION_ERROR(-38303, 'El check-in solo está habilitado entre 24h y 2h antes de la salida.');
    END IF;

    -----------------------------------------------------------------
    -- 4. Validar que el asiento esté disponible en la clase pagada
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM reservas
    WHERE id_vuelo = v_id_vuelo
      AND numero_asiento = p_numero_asiento
      AND estado_reserva IN ('CONFIRMADA','CHECK_IN');

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-38304, 'El asiento seleccionado ya está ocupado.');
    END IF;

    -----------------------------------------------------------------
    -- 5. Validar que el pasajero no haya hecho check-in antes
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM reservas
    WHERE id_reserva = v_id_reserva
      AND estado_reserva = 'CHECK_IN';

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-38305, 'El pasajero ya realizó check-in para este vuelo.');
    END IF;

    -----------------------------------------------------------------
    -- 6. Actualizar reserva a estado CHECK_IN
    -----------------------------------------------------------------
    UPDATE reservas
    SET estado_reserva = 'CHECK_IN',
        numero_asiento = p_numero_asiento,
        checkin_realizado = 1,
        fecha_checkin = SYSTIMESTAMP,
        fecha_modificacion = SYSDATE
    WHERE id_reserva = v_id_reserva;

    -----------------------------------------------------------------
    -- 7. Generar pase de abordar (simulado con código QR)
    -----------------------------------------------------------------
    SELECT puerta_embarque_asignada
    INTO v_puerta
    FROM reservas
    WHERE id_reserva = v_id_reserva;

    DBMS_OUTPUT.PUT_LINE('Pase de abordar generado:');
    DBMS_OUTPUT.PUT_LINE('Reserva: ' || p_codigo_reserva);
    DBMS_OUTPUT.PUT_LINE('Vuelo: ' || v_id_vuelo);
    DBMS_OUTPUT.PUT_LINE('Fecha/Hora salida: ' || TO_CHAR(v_hora_salida,'DD/MM/YYYY HH24:MI'));
    DBMS_OUTPUT.PUT_LINE('Puerta: ' || NVL(v_puerta,'Pendiente'));
    DBMS_OUTPUT.PUT_LINE('Asiento: ' || p_numero_asiento);
    DBMS_OUTPUT.PUT_LINE('Código QR: QR-' || p_codigo_reserva || '-' || v_id_vuelo);

EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-38306, 'No se encontró la reserva o pasajero.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-38399, 'Error al realizar check-in: ' || SQLERRM);
END sp_checkin_en_linea;
/

