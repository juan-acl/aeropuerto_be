CREATE OR REPLACE PROCEDURE sp_apertura_embarque(
    p_codigo_reserva   IN VARCHAR2,
    p_numero_documento IN VARCHAR2,
    p_puerta_embarque  IN VARCHAR2
) IS
    v_id_reserva       NUMBER;
    v_id_vuelo         NUMBER;
    v_estado_reserva   VARCHAR2(20);
    v_estado_vuelo     VARCHAR2(20);
    v_hora_salida      TIMESTAMP;
    v_puerta_reserva   VARCHAR2(10);
    v_nombres          VARCHAR2(100);
    v_apellidos        VARCHAR2(100);
    v_numero_documento VARCHAR2(30);
    v_count            NUMBER;
    v_abordados        NUMBER;
    v_total_reservas   NUMBER;
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que el pase corresponda al vuelo correcto
    -----------------------------------------------------------------
    SELECT r.id_reserva, r.id_vuelo, r.estado_reserva,
           v.estado_vuelo, v.hora_salida_programada,
           r.puerta_embarque_asignada,
           p.nombres, p.apellidos, p.numero_documento
    INTO v_id_reserva, v_id_vuelo, v_estado_reserva,
         v_estado_vuelo, v_hora_salida,
         v_puerta_reserva,
         v_nombres, v_apellidos, v_numero_documento
    FROM reservas r
    JOIN pasajeros p ON r.id_pasajero = p.id_pasajero
    JOIN vuelos v ON r.id_vuelo = v.id_vuelo
    WHERE r.codigo_reserva = p_codigo_reserva;

    IF v_estado_reserva <> 'CHECK_IN' THEN
        RAISE_APPLICATION_ERROR(-38901, 'El pase no corresponde a una reserva con check-in realizado.');
    END IF;

    -----------------------------------------------------------------
    -- 2. Validar puerta de embarque
    -----------------------------------------------------------------
    IF v_puerta_reserva IS NULL OR v_puerta_reserva <> p_puerta_embarque THEN
        RAISE_APPLICATION_ERROR(-38902, 'La puerta de embarque no coincide con la asignada.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Validar duplicados
    -----------------------------------------------------------------
    IF v_estado_reserva = 'ABORDADO' THEN
        RAISE_APPLICATION_ERROR(-38903, 'El pasajero ya fue registrado como ABORDADO.');
    END IF;

    -----------------------------------------------------------------
    -- 4. Validar documento
    -----------------------------------------------------------------
    IF v_numero_documento <> p_numero_documento THEN
        RAISE_APPLICATION_ERROR(-38904, 'El documento del pasajero no coincide con el pase.');
    END IF;

    -----------------------------------------------------------------
    -- 5. Registrar como ABORDADO
    -----------------------------------------------------------------
    UPDATE reservas
    SET estado_reserva = 'ABORDADO',
        fecha_modificacion = SYSDATE
    WHERE id_reserva = v_id_reserva;

    -----------------------------------------------------------------
    -- 6. Calcular conteo en tiempo real
    -----------------------------------------------------------------
    SELECT COUNT(*) INTO v_abordados
    FROM reservas
    WHERE id_vuelo = v_id_vuelo
      AND estado_reserva = 'ABORDADO';

    SELECT COUNT(*) INTO v_total_reservas
    FROM reservas
    WHERE id_vuelo = v_id_vuelo
      AND estado_reserva IN ('CONFIRMADA','CHECK_IN','ABORDADO');

    DBMS_OUTPUT.PUT_LINE('Pasajero ' || v_nombres || ' ' || v_apellidos || ' abordado correctamente.');
    DBMS_OUTPUT.PUT_LINE('Conteo actualizado: ' || v_abordados || ' de ' || v_total_reservas || ' pasajeros esperados.');
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-38905, 'No se encontró la reserva especificada.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-38999, 'Error al registrar embarque: ' || SQLERRM);
END sp_apertura_embarque;
/

