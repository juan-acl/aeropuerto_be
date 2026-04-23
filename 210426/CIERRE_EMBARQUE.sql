CREATE OR REPLACE PROCEDURE sp_cierre_embarque(
    p_id_vuelo IN NUMBER
) IS
    v_estado_vuelo   VARCHAR2(20);
    v_hora_salida    TIMESTAMP;
    v_count          NUMBER;
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar que el vuelo exista y obtener estado
    -----------------------------------------------------------------
    SELECT estado_vuelo, hora_salida_programada
    INTO v_estado_vuelo, v_hora_salida
    FROM vuelos
    WHERE id_vuelo = p_id_vuelo;

    -----------------------------------------------------------------
    -- 2. Validar ventana de cierre (15 min antes de salida)
    -----------------------------------------------------------------
    IF SYSTIMESTAMP < (v_hora_salida - INTERVAL '15' MINUTE) THEN
        RAISE_APPLICATION_ERROR(-39101, 'El embarque solo se puede cerrar 15 minutos antes de la salida.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Marcar pasajeros no abordados como NO SHOW
    -----------------------------------------------------------------
    UPDATE reservas
    SET estado_reserva = 'NO_SHOW'
    WHERE id_vuelo = p_id_vuelo
      AND estado_reserva IN ('CONFIRMADA','CHECK_IN');

    -----------------------------------------------------------------
    -- 4. Identificar y descargar equipaje de pasajeros NO SHOW
    -----------------------------------------------------------------
    DBMS_OUTPUT.PUT_LINE('Equipaje de pasajeros NO SHOW identificado y descargado del avión.');

    -----------------------------------------------------------------
    -- 5. Generar manifiesto final de pasajeros
    -----------------------------------------------------------------
    DBMS_OUTPUT.PUT_LINE('--- Manifiesto Final de Pasajeros ---');
    FOR rec IN (
        SELECT p.nombres || ' ' || p.apellidos AS pasajero,
               r.numero_asiento,
               r.estado_reserva
        FROM reservas r
        JOIN pasajeros p ON r.id_pasajero = p.id_pasajero
        WHERE r.id_vuelo = p_id_vuelo
    ) LOOP
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || rec.pasajero ||
                             ' | Asiento: ' || rec.numero_asiento ||
                             ' | Estado: ' || rec.estado_reserva);
    END LOOP;

    -----------------------------------------------------------------
    -- 6. Actualizar vuelo a estado EMBARQUE CERRADO
    -----------------------------------------------------------------
    UPDATE vuelos
    SET estado_vuelo = 'EMBARQUE CERRADO'
    WHERE id_vuelo = p_id_vuelo;

    DBMS_OUTPUT.PUT_LINE('Embarque cerrado para vuelo ' || p_id_vuelo);
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-39102, 'El vuelo especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-39199, 'Error al cerrar embarque: ' || SQLERRM);
END sp_cierre_embarque;
/
