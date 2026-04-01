------------------------------------------------------------
-- Paquete CRUD para la tabla PROGRAMAS_COMPENSACION_AMBIENTAL
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_programas_compensacion AS
    PROCEDURE insert_programa(
        p_nombre_programa       IN VARCHAR2,
        p_descripcion           IN VARCHAR2,
        p_tipo_programa         IN VARCHAR2,
        p_fecha_inicio          IN DATE,
        p_fecha_fin             IN DATE,
        p_inversion_total       IN NUMBER,
        p_moneda                IN VARCHAR2,
        p_co2_compensado_estimado_kg IN NUMBER,
        p_entidad_ejecutora     IN VARCHAR2,
        p_activo                IN NUMBER DEFAULT 1,
        p_contacto_responsable  IN VARCHAR2
    );

    PROCEDURE get_programa(
        p_id_programa_compensacion IN NUMBER
    );

    PROCEDURE update_programa(
        p_id_programa_compensacion IN NUMBER,
        p_nombre_programa          IN VARCHAR2,
        p_descripcion              IN VARCHAR2,
        p_tipo_programa            IN VARCHAR2,
        p_fecha_inicio             IN DATE,
        p_fecha_fin                IN DATE,
        p_inversion_total          IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_co2_compensado_estimado_kg IN NUMBER,
        p_entidad_ejecutora        IN VARCHAR2,
        p_activo                   IN NUMBER,
        p_contacto_responsable     IN VARCHAR2
    );

    PROCEDURE delete_programa(
        p_id_programa_compensacion IN NUMBER
    );
END pkg_programas_compensacion;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_programas_compensacion AS

    PROCEDURE insert_programa(
        p_nombre_programa       IN VARCHAR2,
        p_descripcion           IN VARCHAR2,
        p_tipo_programa         IN VARCHAR2,
        p_fecha_inicio          IN DATE,
        p_fecha_fin             IN DATE,
        p_inversion_total       IN NUMBER,
        p_moneda                IN VARCHAR2,
        p_co2_compensado_estimado_kg IN NUMBER,
        p_entidad_ejecutora     IN VARCHAR2,
        p_activo                IN NUMBER,
        p_contacto_responsable  IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO programas_compensacion_ambiental (
            nombre_programa, descripcion, tipo_programa,
            fecha_inicio, fecha_fin, inversion_total, moneda,
            co2_compensado_estimado_kg, entidad_ejecutora,
            activo, contacto_responsable
        ) VALUES (
            p_nombre_programa, p_descripcion, p_tipo_programa,
            p_fecha_inicio, p_fecha_fin, p_inversion_total, p_moneda,
            p_co2_compensado_estimado_kg, p_entidad_ejecutora,
            NVL(p_activo,1), p_contacto_responsable
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31401, 'Error al insertar programa de compensación: ' || SQLERRM);
    END insert_programa;

    PROCEDURE get_programa(
        p_id_programa_compensacion IN NUMBER
    ) IS
        r programas_compensacion_ambiental%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM programas_compensacion_ambiental
        WHERE id_programa_compensacion = p_id_programa_compensacion;

        DBMS_OUTPUT.PUT_LINE('ID Programa: ' || r.id_programa_compensacion);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_programa);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Tipo programa: ' || r.tipo_programa);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Inversión total: ' || r.inversion_total || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('CO2 compensado estimado (kg): ' || r.co2_compensado_estimado_kg);
        DBMS_OUTPUT.PUT_LINE('Entidad ejecutora: ' || r.entidad_ejecutora);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        DBMS_OUTPUT.PUT_LINE('Contacto responsable: ' || r.contacto_responsable);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Programa de compensación no encontrado.');
    END get_programa;

    PROCEDURE update_programa(
        p_id_programa_compensacion IN NUMBER,
        p_nombre_programa          IN VARCHAR2,
        p_descripcion              IN VARCHAR2,
        p_tipo_programa            IN VARCHAR2,
        p_fecha_inicio             IN DATE,
        p_fecha_fin                IN DATE,
        p_inversion_total          IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_co2_compensado_estimado_kg IN NUMBER,
        p_entidad_ejecutora        IN VARCHAR2,
        p_activo                   IN NUMBER,
        p_contacto_responsable     IN VARCHAR2
    ) IS
    BEGIN
        UPDATE programas_compensacion_ambiental
        SET nombre_programa       = p_nombre_programa,
            descripcion           = p_descripcion,
            tipo_programa         = p_tipo_programa,
            fecha_inicio          = p_fecha_inicio,
            fecha_fin             = p_fecha_fin,
            inversion_total       = p_inversion_total,
            moneda                = p_moneda,
            co2_compensado_estimado_kg = p_co2_compensado_estimado_kg,
            entidad_ejecutora     = p_entidad_ejecutora,
            activo                = p_activo,
            contacto_responsable  = p_contacto_responsable
        WHERE id_programa_compensacion = p_id_programa_compensacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31402, 'No se encontró el programa de compensación para actualizar.');
        END IF;
    END update_programa;

    PROCEDURE delete_programa(
        p_id_programa_compensacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM programas_compensacion_ambiental
        WHERE id_programa_compensacion = p_id_programa_compensacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31403, 'No se encontró el programa de compensación para eliminar.');
        END IF;
    END delete_programa;

END pkg_programas_compensacion;
/
