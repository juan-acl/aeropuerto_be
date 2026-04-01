------------------------------------------------------------
-- Paquete CRUD para la tabla CONTROL_CALIDAD_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_control_calidad_combustible AS
    PROCEDURE insert_muestra(
        p_id_tanque             IN NUMBER,
        p_fecha_muestra         IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_fecha_analisis        IN TIMESTAMP,
        p_numero_muestra        IN VARCHAR2,
        p_tipo_analisis         IN VARCHAR2,
        p_analista              IN NUMBER,
        p_densidad_medida       IN NUMBER,
        p_temperatura_prueba    IN NUMBER,
        p_presencia_agua        IN NUMBER,
        p_particulas_suspendidas IN NUMBER,
        p_conductividad         IN NUMBER,
        p_resultado             IN VARCHAR2,
        p_aprobado_por          IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE get_muestra(
        p_id_muestra IN NUMBER
    );

    PROCEDURE update_muestra(
        p_id_muestra            IN NUMBER,
        p_id_tanque             IN NUMBER,
        p_fecha_muestra         IN TIMESTAMP,
        p_fecha_analisis        IN TIMESTAMP,
        p_numero_muestra        IN VARCHAR2,
        p_tipo_analisis         IN VARCHAR2,
        p_analista              IN NUMBER,
        p_densidad_medida       IN NUMBER,
        p_temperatura_prueba    IN NUMBER,
        p_presencia_agua        IN NUMBER,
        p_particulas_suspendidas IN NUMBER,
        p_conductividad         IN NUMBER,
        p_resultado             IN VARCHAR2,
        p_aprobado_por          IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE delete_muestra(
        p_id_muestra IN NUMBER
    );
END pkg_control_calidad_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_control_calidad_combustible AS

    PROCEDURE insert_muestra(
        p_id_tanque             IN NUMBER,
        p_fecha_muestra         IN TIMESTAMP,
        p_fecha_analisis        IN TIMESTAMP,
        p_numero_muestra        IN VARCHAR2,
        p_tipo_analisis         IN VARCHAR2,
        p_analista              IN NUMBER,
        p_densidad_medida       IN NUMBER,
        p_temperatura_prueba    IN NUMBER,
        p_presencia_agua        IN NUMBER,
        p_particulas_suspendidas IN NUMBER,
        p_conductividad         IN NUMBER,
        p_resultado             IN VARCHAR2,
        p_aprobado_por          IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO control_calidad_combustible (
            id_tanque, fecha_muestra, fecha_analisis, numero_muestra,
            tipo_analisis, analista, densidad_medida, temperatura_prueba,
            presencia_agua, particulas_suspendidas, conductividad,
            resultado, aprobado_por, observaciones
        ) VALUES (
            p_id_tanque, NVL(p_fecha_muestra, SYSTIMESTAMP), p_fecha_analisis, p_numero_muestra,
            p_tipo_analisis, p_analista, p_densidad_medida, p_temperatura_prueba,
            p_presencia_agua, p_particulas_suspendidas, p_conductividad,
            p_resultado, p_aprobado_por, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30801, 'Error al insertar muestra de control de calidad: ' || SQLERRM);
    END insert_muestra;

    PROCEDURE get_muestra(
        p_id_muestra IN NUMBER
    ) IS
        r control_calidad_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM control_calidad_combustible
        WHERE id_muestra = p_id_muestra;

        DBMS_OUTPUT.PUT_LINE('ID Muestra: ' || r.id_muestra);
        DBMS_OUTPUT.PUT_LINE('Tanque: ' || r.id_tanque);
        DBMS_OUTPUT.PUT_LINE('Fecha muestra: ' || r.fecha_muestra);
        DBMS_OUTPUT.PUT_LINE('Fecha análisis: ' || r.fecha_analisis);
        DBMS_OUTPUT.PUT_LINE('Número muestra: ' || r.numero_muestra);
        DBMS_OUTPUT.PUT_LINE('Tipo análisis: ' || r.tipo_analisis);
        DBMS_OUTPUT.PUT_LINE('Analista: ' || r.analista);
        DBMS_OUTPUT.PUT_LINE('Densidad medida: ' || r.densidad_medida);
        DBMS_OUTPUT.PUT_LINE('Temperatura prueba: ' || r.temperatura_prueba);
        DBMS_OUTPUT.PUT_LINE('Presencia agua: ' || r.presencia_agua);
        DBMS_OUTPUT.PUT_LINE('Partículas suspendidas: ' || r.particulas_suspendidas);
        DBMS_OUTPUT.PUT_LINE('Conductividad: ' || r.conductividad);
        DBMS_OUTPUT.PUT_LINE('Resultado: ' || r.resultado);
        DBMS_OUTPUT.PUT_LINE('Aprobado por: ' || r.aprobado_por);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Muestra de control de calidad no encontrada.');
    END get_muestra;

    PROCEDURE update_muestra(
        p_id_muestra            IN NUMBER,
        p_id_tanque             IN NUMBER,
        p_fecha_muestra         IN TIMESTAMP,
        p_fecha_analisis        IN TIMESTAMP,
        p_numero_muestra        IN VARCHAR2,
        p_tipo_analisis         IN VARCHAR2,
        p_analista              IN NUMBER,
        p_densidad_medida       IN NUMBER,
        p_temperatura_prueba    IN NUMBER,
        p_presencia_agua        IN NUMBER,
        p_particulas_suspendidas IN NUMBER,
        p_conductividad         IN NUMBER,
        p_resultado             IN VARCHAR2,
        p_aprobado_por          IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        UPDATE control_calidad_combustible
        SET id_tanque             = p_id_tanque,
            fecha_muestra         = p_fecha_muestra,
            fecha_analisis        = p_fecha_analisis,
            numero_muestra        = p_numero_muestra,
            tipo_analisis         = p_tipo_analisis,
            analista              = p_analista,
            densidad_medida       = p_densidad_medida,
            temperatura_prueba    = p_temperatura_prueba,
            presencia_agua        = p_presencia_agua,
            particulas_suspendidas = p_particulas_suspendidas,
            conductividad         = p_conductividad,
            resultado             = p_resultado,
            aprobado_por          = p_aprobado_por,
            observaciones         = p_observaciones
        WHERE id_muestra = p_id_muestra;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30802, 'No se encontró la muestra de control de calidad para actualizar.');
        END IF;
    END update_muestra;

    PROCEDURE delete_muestra(
        p_id_muestra IN NUMBER
    ) IS
    BEGIN
        DELETE FROM control_calidad_combustible
        WHERE id_muestra = p_id_muestra;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30803, 'No se encontró la muestra de control de calidad para eliminar.');
        END IF;
    END delete_muestra;

END pkg_control_calidad_combustible;
/
