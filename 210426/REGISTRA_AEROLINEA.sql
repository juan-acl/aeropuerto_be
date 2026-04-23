CREATE OR REPLACE PROCEDURE sp_registrar_aerolinea(
    p_nombre        IN VARCHAR2,
    p_codigo_iata   IN VARCHAR2,
    p_codigo_oaci   IN VARCHAR2,
    p_pais_origen   IN VARCHAR2,
    p_contacto      IN VARCHAR2
) IS
    v_count   NUMBER;
    v_new_id  NUMBER;
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar campos obligatorios
    -----------------------------------------------------------------
    IF p_nombre IS NULL OR p_codigo_iata IS NULL OR p_codigo_oaci IS NULL 
       OR p_pais_origen IS NULL OR p_contacto IS NULL THEN
        RAISE_APPLICATION_ERROR(-39501, 'Todos los campos obligatorios deben ser proporcionados.');
    END IF;

    -----------------------------------------------------------------
    -- 2. Validar formato de códigos
    -----------------------------------------------------------------
    IF LENGTH(p_codigo_iata) <> 2 THEN
        RAISE_APPLICATION_ERROR(-39502, 'El código IATA debe tener exactamente 2 letras.');
    END IF;

    IF LENGTH(p_codigo_oaci) <> 3 THEN
        RAISE_APPLICATION_ERROR(-39503, 'El código OACI debe tener exactamente 3 letras.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Validar unicidad de códigos
    -----------------------------------------------------------------
    SELECT COUNT(*) INTO v_count FROM aerolineas WHERE codigo_iata = p_codigo_iata;
    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-39504, 'El código IATA ya está registrado.');
    END IF;

    SELECT COUNT(*) INTO v_count FROM aerolineas WHERE codigo_oaci = p_codigo_oaci;
    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-39505, 'El código OACI ya está registrado.');
    END IF;

    -----------------------------------------------------------------
    -- 4. Generar nuevo ID sin secuencia (MAX+1)
    -----------------------------------------------------------------
    SELECT NVL(MAX(id_aerolinea),0)+1 INTO v_new_id FROM aerolineas;

    -----------------------------------------------------------------
    -- 5. Insertar nueva aerolínea
    -----------------------------------------------------------------
    INSERT INTO aerolineas (
        id_aerolinea, nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, telefono_contacto
    ) VALUES (
        v_new_id, p_nombre, p_codigo_iata, p_codigo_oaci, p_pais_origen, p_contacto
    );

    DBMS_OUTPUT.PUT_LINE('Aerolínea ' || p_nombre || ' registrada correctamente.');
END sp_registrar_aerolinea;
/


