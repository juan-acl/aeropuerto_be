CREATE OR REPLACE PROCEDURE sp_registrar_pasajero(
    p_nombre           IN VARCHAR2,
    p_apellidos        IN VARCHAR2,
    p_numero_documento IN VARCHAR2,
    p_nacionalidad     IN VARCHAR2,
    p_fecha_nacimiento IN DATE,
    p_email            IN VARCHAR2 DEFAULT NULL
) IS
    v_count NUMBER;
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar campos obligatorios
    -----------------------------------------------------------------
    IF p_nombre IS NULL OR p_apellidos IS NULL OR p_numero_documento IS NULL 
       OR p_nacionalidad IS NULL OR p_fecha_nacimiento IS NULL THEN
        RAISE_APPLICATION_ERROR(-40301, 'Todos los campos obligatorios deben ser proporcionados.');
    END IF;

    -----------------------------------------------------------------
    -- 2. Validar unicidad de documento/pasaporte
    -----------------------------------------------------------------
    SELECT COUNT(*) INTO v_count
    FROM pasajeros
    WHERE numero_documento = p_numero_documento;

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-40302, 'El número de documento/pasaporte ya está registrado.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Validar formato de email (si se proporciona)
    -----------------------------------------------------------------
    IF p_email IS NOT NULL THEN
        IF NOT REGEXP_LIKE(p_email, '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$') THEN
            RAISE_APPLICATION_ERROR(-40303, 'El email no tiene un formato válido.');
        END IF;
    END IF;

    -----------------------------------------------------------------
    -- 4. Validar fecha de nacimiento
    -----------------------------------------------------------------
    IF p_fecha_nacimiento > SYSDATE THEN
        RAISE_APPLICATION_ERROR(-40304, 'La fecha de nacimiento no puede ser futura.');
    END IF;

    -----------------------------------------------------------------
    -- 5. Insertar pasajero (id_pasajero se genera automáticamente con SYS_GUID)
    -----------------------------------------------------------------
    INSERT INTO pasajeros (
        nombres, apellidos, numero_documento, nacionalidad, fecha_nacimiento, email
    ) VALUES (
        p_nombre, p_apellidos, p_numero_documento, p_nacionalidad, p_fecha_nacimiento, p_email
    );

    DBMS_OUTPUT.PUT_LINE('Pasajero ' || p_nombre || ' ' || p_apellidos || ' registrado correctamente.');
END sp_registrar_pasajero;
/


