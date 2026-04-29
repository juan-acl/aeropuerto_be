CREATE OR REPLACE PROCEDURE sp_actualizar_estado_vuelo(
    p_id_vuelo   IN NUMBER,
    p_nuevo_estado IN VARCHAR2
) IS
    v_estado_actual VARCHAR2(20);
BEGIN
    -----------------------------------------------------------------
    -- 1. Obtener estado actual del vuelo
    -----------------------------------------------------------------
    SELECT estado_vuelo
    INTO v_estado_actual
    FROM vuelos
    WHERE id_vuelo = p_id_vuelo;

    -----------------------------------------------------------------
    -- 2. Validar transición permitida
    -----------------------------------------------------------------
    CASE v_estado_actual
        WHEN 'PROGRAMADO' THEN
            IF p_nuevo_estado NOT IN ('ABORDANDO','RETRASADO','CANCELADO') THEN
                RAISE_APPLICATION_ERROR(-40401, 'Transición inválida desde PROGRAMADO.');
            END IF;
        WHEN 'RETRASADO' THEN
            IF p_nuevo_estado NOT IN ('ABORDANDO','CANCELADO') THEN
                RAISE_APPLICATION_ERROR(-40402, 'Transición inválida desde RETRASADO.');
            END IF;
        WHEN 'ABORDANDO' THEN
            IF p_nuevo_estado NOT IN ('EN_VUELO') THEN
                RAISE_APPLICATION_ERROR(-40403, 'Transición inválida desde ABORDANDO.');
            END IF;
        WHEN 'EN_VUELO' THEN
            IF p_nuevo_estado NOT IN ('ATERRIZADO') THEN
                RAISE_APPLICATION_ERROR(-40404, 'Transición inválida desde EN_VUELO.');
            END IF;
        WHEN 'CANCELADO' THEN
            RAISE_APPLICATION_ERROR(-40405, 'El vuelo está cancelado. No se permiten más transiciones.');
        WHEN 'ATERRIZADO' THEN
            RAISE_APPLICATION_ERROR(-40406, 'El vuelo ya aterrizó. No se permiten más transiciones.');
        ELSE
            RAISE_APPLICATION_ERROR(-40407, 'Estado actual desconocido.');
    END CASE;

    -----------------------------------------------------------------
    -- 3. Actualizar estado
    -----------------------------------------------------------------
    UPDATE vuelos
    SET estado_vuelo = p_nuevo_estado
    WHERE id_vuelo = p_id_vuelo;

    DBMS_OUTPUT.PUT_LINE('Vuelo ' || p_id_vuelo || ' actualizado de ' || v_estado_actual || ' a ' || p_nuevo_estado);
EXCEPTION
    WHEN NO_DATA_FOUND THEN
        RAISE_APPLICATION_ERROR(-40408, 'El vuelo especificado no existe.');
    WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-40499, 'Error al actualizar estado de vuelo: ' || SQLERRM);
END sp_actualizar_estado_vuelo;
/
