CREATE OR REPLACE PROCEDURE sp_actualizar_estado_equipaje(
    p_id_equipaje   IN RAW,
    p_nuevo_estado  IN VARCHAR2
) IS
    v_estado_actual VARCHAR2(30);
BEGIN
    -----------------------------------------------------------------
    -- 1. Obtener estado actual del equipaje
    -----------------------------------------------------------------
    SELECT estado
    INTO v_estado_actual
    FROM equipaje
    WHERE id_equipaje = p_id_equipaje;

    -----------------------------------------------------------------
    -- 2. Validar transición permitida
    -----------------------------------------------------------------
    CASE v_estado_actual
        WHEN 'Registrado' THEN
            IF p_nuevo_estado NOT IN ('En cinta') THEN
                RAISE_APPLICATION_ERROR(-40601, 'Transición inválida desde Registrado.');
            END IF;

        WHEN 'En cinta' THEN
            IF p_nuevo_estado NOT IN ('Cargado') THEN
                RAISE_APPLICATION_ERROR(-40602, 'Transición inválida desde En cinta.');
            END IF;

        WHEN 'Cargado' THEN
            IF p_nuevo_estado NOT IN ('En vuelo','Descargado') THEN
                RAISE_APPLICATION_ERROR(-40603, 'Transición inválida desde Cargado.');
            END IF;

        WHEN 'En vuelo' THEN
            IF p_nuevo_estado NOT IN ('Descargado') THEN
                RAISE_APPLICATION_ERROR(-40604, 'Transición inválida desde En vuelo.');
            END IF;

        WHEN 'Descargado' THEN
            IF p_nuevo_estado NOT IN ('En carrusel') THEN
                RAISE_APPLICATION_ERROR(-40605, 'Transición inválida desde Descargado.');
            END IF;

        WHEN 'En carrusel' THEN
            IF p_nuevo_estado NOT IN ('Reclamado','Perdido') THEN
                RAISE_APPLICATION_ERROR(-40606, 'Transición inválida desde En carrusel.');
            END IF;

        WHEN 'Reclamado' THEN
            RAISE_APPLICATION_ERROR(-40607, 'El equipaje ya fue Reclamado. No se permiten más transiciones.');

        WHEN 'Perdido' THEN
            RAISE_APPLICATION_ERROR(-40608, 'El equipaje está Perdido. No se permiten más transiciones.');

        WHEN 'Dañado' THEN
            RAISE_APPLICATION_ERROR(-40609, 'El equipaje está marcado como Dañado. No se permiten más transiciones.');

        ELSE
            RAISE_APPLICATION_ERROR(-40610, 'Estado actual desconocido.');
    END CASE;

    -----------------------------------------------------------------
    -- 3. Actualizar estado
    -----------------------------------------------------------------
    UPDATE equipaje
    SET estado = p_nuevo_estado,
        fecha_hora_ultimo_scan = SYSTIMESTAMP
    WHERE id_equipaje = p_id_equipaje;

    DBMS_OUTPUT.PUT_LINE('Equipaje ' || p_id_equipaje || ' actualizado de ' || v_estado_actual || ' a ' || p_nuevo_estado);
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-40611, 'El equipaje especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-40699, 'Error al actualizar estado de equipaje: ' || SQLERRM);
END sp_actualizar_estado_equipaje;
/
