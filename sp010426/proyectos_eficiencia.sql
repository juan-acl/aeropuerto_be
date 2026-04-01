------------------------------------------------------------
-- Paquete CRUD para la tabla PROYECTOS_EFICIENCIA_ENERGETICA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_proyectos_eficiencia AS
    PROCEDURE insert_proyecto(
        p_nombre_proyecto        IN VARCHAR2,
        p_descripcion            IN VARCHAR2,
        p_tipo_proyecto          IN VARCHAR2,
        p_inversion_total        IN NUMBER,
        p_ahorro_energetico_anual_kwh IN NUMBER,
        p_reduccion_co2_anual_kg IN NUMBER,
        p_fecha_inicio           IN DATE,
        p_fecha_finalizacion     IN DATE,
        p_periodo_retorno_anios  IN NUMBER,
        p_estado                 IN VARCHAR2,
        p_responsable_proyecto   IN VARCHAR2,
        p_resultados_obtenidos   IN VARCHAR2
    );

    PROCEDURE get_proyecto(
        p_id_proyecto_eficiencia IN NUMBER
    );

    PROCEDURE update_proyecto(
        p_id_proyecto_eficiencia IN NUMBER,
        p_nombre_proyecto        IN VARCHAR2,
        p_descripcion            IN VARCHAR2,
        p_tipo_proyecto          IN VARCHAR2,
        p_inversion_total        IN NUMBER,
        p_ahorro_energetico_anual_kwh IN NUMBER,
        p_reduccion_co2_anual_kg IN NUMBER,
        p_fecha_inicio           IN DATE,
        p_fecha_finalizacion     IN DATE,
        p_periodo_retorno_anios  IN NUMBER,
        p_estado                 IN VARCHAR2,
        p_responsable_proyecto   IN VARCHAR2,
        p_resultados_obtenidos   IN VARCHAR2
    );

    PROCEDURE delete_proyecto(
        p_id_proyecto_eficiencia IN NUMBER
    );
END pkg_proyectos_eficiencia;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_proyectos_eficiencia AS

    PROCEDURE insert_proyecto(
        p_nombre_proyecto        IN VARCHAR2,
        p_descripcion            IN VARCHAR2,
        p_tipo_proyecto          IN VARCHAR2,
        p_inversion_total        IN NUMBER,
        p_ahorro_energetico_anual_kwh IN NUMBER,
        p_reduccion_co2_anual_kg IN NUMBER,
        p_fecha_inicio           IN DATE,
        p_fecha_finalizacion     IN DATE,
        p_periodo_retorno_anios  IN NUMBER,
        p_estado                 IN VARCHAR2,
        p_responsable_proyecto   IN VARCHAR2,
        p_resultados_obtenidos   IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO proyectos_eficiencia_energetica (
            nombre_proyecto, descripcion, tipo_proyecto,
            inversion_total, ahorro_energetico_anual_kwh, reduccion_co2_anual_kg,
            fecha_inicio, fecha_finalizacion, periodo_retorno_anios,
            estado, responsable_proyecto, resultados_obtenidos
        ) VALUES (
            p_nombre_proyecto, p_descripcion, p_tipo_proyecto,
            p_inversion_total, p_ahorro_energetico_anual_kwh, p_reduccion_co2_anual_kg,
            p_fecha_inicio, p_fecha_finalizacion, p_periodo_retorno_anios,
            p_estado, p_responsable_proyecto, p_resultados_obtenidos
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31801, 'Error al insertar proyecto de eficiencia energética: ' || SQLERRM);
    END insert_proyecto;

    PROCEDURE get_proyecto(
        p_id_proyecto_eficiencia IN NUMBER
    ) IS
        r proyectos_eficiencia_energetica%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM proyectos_eficiencia_energetica
        WHERE id_proyecto_eficiencia = p_id_proyecto_eficiencia;

        DBMS_OUTPUT.PUT_LINE('ID Proyecto: ' || r.id_proyecto_eficiencia);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_proyecto);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Tipo proyecto: ' || r.tipo_proyecto);
        DBMS_OUTPUT.PUT_LINE('Inversión total: ' || r.inversion_total);
        DBMS_OUTPUT.PUT_LINE('Ahorro energético anual (kWh): ' || r.ahorro_energetico_anual_kwh);
        DBMS_OUTPUT.PUT_LINE('Reducción CO2 anual (kg): ' || r.reduccion_co2_anual_kg);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha finalización: ' || r.fecha_finalizacion);
        DBMS_OUTPUT.PUT_LINE('Periodo retorno (años): ' || r.periodo_retorno_anios);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Responsable: ' || r.responsable_proyecto);
        DBMS_OUTPUT.PUT_LINE('Resultados obtenidos: ' || r.resultados_obtenidos);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Proyecto de eficiencia energética no encontrado.');
    END get_proyecto;

    PROCEDURE update_proyecto(
        p_id_proyecto_eficiencia IN NUMBER,
        p_nombre_proyecto        IN VARCHAR2,
        p_descripcion            IN VARCHAR2,
        p_tipo_proyecto          IN VARCHAR2,
        p_inversion_total        IN NUMBER,
        p_ahorro_energetico_anual_kwh IN NUMBER,
        p_reduccion_co2_anual_kg IN NUMBER,
        p_fecha_inicio           IN DATE,
        p_fecha_finalizacion     IN DATE,
        p_periodo_retorno_anios  IN NUMBER,
        p_estado                 IN VARCHAR2,
        p_responsable_proyecto   IN VARCHAR2,
        p_resultados_obtenidos   IN VARCHAR2
    ) IS
    BEGIN
        UPDATE proyectos_eficiencia_energetica
        SET nombre_proyecto        = p_nombre_proyecto,
            descripcion            = p_descripcion,
            tipo_proyecto          = p_tipo_proyecto,
            inversion_total        = p_inversion_total,
            ahorro_energetico_anual_kwh = p_ahorro_energetico_anual_kwh,
            reduccion_co2_anual_kg = p_reduccion_co2_anual_kg,
            fecha_inicio           = p_fecha_inicio,
            fecha_finalizacion     = p_fecha_finalizacion,
            periodo_retorno_anios  = p_periodo_retorno_anios,
            estado                 = p_estado,
            responsable_proyecto   = p_responsable_proyecto,
            resultados_obtenidos   = p_resultados_obtenidos
        WHERE id_proyecto_eficiencia = p_id_proyecto_eficiencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31802, 'No se encontró el proyecto de eficiencia energética para actualizar.');
        END IF;
    END update_proyecto;

    PROCEDURE delete_proyecto(
        p_id_proyecto_eficiencia IN NUMBER
    ) IS
    BEGIN
        DELETE FROM proyectos_eficiencia_energetica
        WHERE id_proyecto_eficiencia = p_id_proyecto_eficiencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31803, 'No se encontró el proyecto de eficiencia energética para eliminar.');
        END IF;
    END delete_proyecto;

END pkg_proyectos_eficiencia;
/
