CREATE OR REPLACE PROCEDURE sp_checkin_mostrador(
    p_codigo_reserva     IN VARCHAR2,
    p_numero_documento   IN VARCHAR2,
    p_numero_asiento     IN VARCHAR2,
    p_equipaje_facturado IN NUMBER,
    p_equipaje_mano      IN NUMBER,
    p_tipo_vuelo         IN VARCHAR2, -- 'Nacional' o 'Internacional'
    p_visa_valida        IN NUMBER    -- 1 = sí, 0 = no
) IS
    v_id_reserva       NUMBER;
    v_id_vuelo         NUMBER;
    v_estado_reserva   VARCHAR2(20);
    v_estado_vuelo     VARCHAR2(20);
    v_hora_salida      TIMESTAMP;
    v_count            NUMBER;
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que la reservación exista por código o documento
    -----------------------------------------------------------------
    SELECT r.id_reserva, r.id_vuelo, r.estado_reserva,
           v.estado_vuelo, v.hora_salida_programada
    INTO v_id_reserva, v_id_vuelo, v_estado_reserva,
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
        RAISE_APPLICATION_ERROR(-38601, 'La reserva debe estar CONFIRMADA para check-in en mostrador.');
    END IF;

    IF v_estado_vuelo = 'CANCELADO' THEN
        RAISE_APPLICATION_ERROR(-38602, 'El vuelo está cancelado, no se puede hacer check-in.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Validar ventana de check-in (3h antes, hasta 45 min antes)
    -----------------------------------------------------------------
    IF SYSTIMESTAMP < (v_hora_salida - INTERVAL '3' HOUR)
       OR SYSTIMESTAMP > (v_hora_salida - INTERVAL '45' MINUTE) THEN
        RAISE_APPLICATION_ERROR(-38603, 'El check-in en mostrador solo está habilitado entre 3h y 45min antes de la salida.');
    END IF;

    -----------------------------------------------------------------
    -- 4. Verificar identidad según tipo de vuelo
    -----------------------------------------------------------------
    IF p_tipo_vuelo = 'Nacional' THEN
        -- Se valida con DPI/pasaporte (ya cubierto por numero_documento)
        NULL;
    ELSE
        -- Vuelos internacionales: verificar visa válida
        IF p_visa_valida = 0 THEN
            RAISE_APPLICATION_ERROR(-38604, 'El pasajero no tiene visa válida para este destino.');
        END IF;
    END IF;

    -----------------------------------------------------------------
    -- 5. Validar asiento disponible
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM reservas
    WHERE id_vuelo = v_id_vuelo
      AND numero_asiento = p_numero_asiento
      AND estado_reserva IN ('CONFIRMADA','CHECK_IN');

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-38605, 'El asiento seleccionado ya está ocupado.');
    END IF;

    -----------------------------------------------------------------
    -- 6. Validar que el pasajero no haya hecho check-in antes
    -----------------------------------------------------------------
    SELECT COUNT(*)
    INTO v_count
    FROM reservas
    WHERE id_reserva = v_id_reserva
      AND estado_reserva = 'CHECK_IN';

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-38606, 'El pasajero ya realizó check-in para este vuelo.');
    END IF;

    -----------------------------------------------------------------
    -- 7. Actualizar reserva a estado CHECK_IN y registrar equipaje
    -----------------------------------------------------------------
    UPDATE reservas
    SET estado_reserva = 'CHECK_IN',
        numero_asiento = p_numero_asiento,
        checkin_realizado = 1,
        fecha_checkin = SYSTIMESTAMP,
        fecha_modificacion = SYSDATE,
        equipaje_facturado_kg = p_equipaje_facturado,
        equipaje_mano_kg = p_equipaje_mano
    WHERE id_reserva = v_id_reserva;

    DBMS_OUTPUT.PUT_LINE('Check-in en mostrador realizado para la reserva ' || p_codigo_reserva);
    DBMS_OUTPUT.PUT_LINE('Equipaje documentado: ' || p_equipaje_facturado || ' kg');
    DBMS_OUTPUT.PUT_LINE('Equipaje de mano: ' || p_equipaje_mano || ' kg');
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-38607, 'No se encontró la reserva o pasajero.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-38699, 'Error al realizar check-in en mostrador: ' || SQLERRM);
END sp_checkin_mostrador;
/

