CREATE OR REPLACE PROCEDURE sp_registrar_aeronave(
    p_matricula        IN VARCHAR2,
    p_codigo_icao_tipo IN CHAR,
    p_id_aerolinea     IN NUMBER,
    p_nombre_aeronave  IN VARCHAR2,
    p_configuracion    IN CLOB,
    p_numero_motores   IN NUMBER,
    p_anio_fabricacion IN NUMBER
) IS
    v_count        NUMBER;
    v_capacidad    NUMBER;
    v_json_total   NUMBER;
BEGIN
    -----------------------------------------------------------------
    -- 1. Validar campos obligatorios
    -----------------------------------------------------------------
    IF p_matricula IS NULL OR p_codigo_icao_tipo IS NULL 
       OR p_id_aerolinea IS NULL OR p_configuracion IS NULL 
       OR p_numero_motores IS NULL THEN
        RAISE_APPLICATION_ERROR(-40001, 'Todos los campos obligatorios deben ser proporcionados.');
    END IF;

    -----------------------------------------------------------------
    -- 2. Validar unicidad de matrícula
    -----------------------------------------------------------------
    SELECT COUNT(*) INTO v_count
    FROM aeronave
    WHERE matricula = p_matricula;

    IF v_count > 0 THEN
        RAISE_APPLICATION_ERROR(-40002, 'La matrícula ya está registrada.');
    END IF;

    -----------------------------------------------------------------
    -- 3. Obtener capacidad máxima del modelo desde tipo_aeronave
    -----------------------------------------------------------------
    SELECT capacidad_pax_max INTO v_capacidad
    FROM tipo_aeronave
    WHERE codigo_icao = p_codigo_icao_tipo;

    -----------------------------------------------------------------
    -- 4. Validar suma de asientos en JSON = capacidad máxima
    -----------------------------------------------------------------
    v_json_total := NVL(JSON_VALUE(p_configuracion, '$.primera' RETURNING NUMBER),0)
                  + NVL(JSON_VALUE(p_configuracion, '$.business' RETURNING NUMBER),0)
                  + NVL(JSON_VALUE(p_configuracion, '$.economy' RETURNING NUMBER),0);

    IF v_json_total <> v_capacidad THEN
        RAISE_APPLICATION_ERROR(-40003, 'La suma de asientos en cabina ('||v_json_total||') no coincide con la capacidad máxima ('||v_capacidad||').');
    END IF;

    -----------------------------------------------------------------
    -- 5. Insertar nueva aeronave (id_aeronave se genera con SYS_GUID automáticamente)
    -----------------------------------------------------------------
    INSERT INTO aeronave (
        matricula, codigo_icao_tipo, id_aerolinea, nombre_aeronave,
        configuracion_cabina, numero_motores, anio_fabricacion
    ) VALUES (
        p_matricula, p_codigo_icao_tipo, p_id_aerolinea, p_nombre_aeronave,
        p_configuracion, p_numero_motores, p_anio_fabricacion
    );

    DBMS_OUTPUT.PUT_LINE('Aeronave ' || NVL(p_nombre_aeronave,p_matricula) || ' registrada correctamente.');
END sp_registrar_aeronave;
/



