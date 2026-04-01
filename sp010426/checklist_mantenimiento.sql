------------------------------------------------------------
-- Paquete CRUD para la tabla CHECKLISTS_MANTENIMIENTO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_checklists_mantenimiento AS
    PROCEDURE insert_checklist(
        p_id_modelo_avion              IN NUMBER,
        p_codigo_checklist             IN VARCHAR2,
        p_nombre_checklist             IN VARCHAR2,
        p_tipo_mantenimiento           IN VARCHAR2,
        p_frecuencia_horas_vuelo       IN NUMBER,
        p_frecuencia_dias              IN NUMBER,
        p_tiempo_estimado_minutos      IN NUMBER,
        p_requiere_herramientas_especiales IN NUMBER DEFAULT 0,
        p_requiere_certificacion       IN NUMBER DEFAULT 0,
        p_activo                       IN NUMBER DEFAULT 1
    );

    PROCEDURE get_checklist(
        p_id_checklist IN NUMBER
    );

    PROCEDURE update_checklist(
        p_id_checklist                 IN NUMBER,
        p_id_modelo_avion              IN NUMBER,
        p_codigo_checklist             IN VARCHAR2,
        p_nombre_checklist             IN VARCHAR2,
        p_tipo_mantenimiento           IN VARCHAR2,
        p_frecuencia_horas_vuelo       IN NUMBER,
        p_frecuencia_dias              IN NUMBER,
        p_tiempo_estimado_minutos      IN NUMBER,
        p_requiere_herramientas_especiales IN NUMBER,
        p_requiere_certificacion       IN NUMBER,
        p_activo                       IN NUMBER
    );

    PROCEDURE delete_checklist(
        p_id_checklist IN NUMBER
    );
END pkg_checklists_mantenimiento;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_checklists_mantenimiento AS

    PROCEDURE insert_checklist(
        p_id_modelo_avion              IN NUMBER,
        p_codigo_checklist             IN VARCHAR2,
        p_nombre_checklist             IN VARCHAR2,
        p_tipo_mantenimiento           IN VARCHAR2,
        p_frecuencia_horas_vuelo       IN NUMBER,
        p_frecuencia_dias              IN NUMBER,
        p_tiempo_estimado_minutos      IN NUMBER,
        p_requiere_herramientas_especiales IN NUMBER,
        p_requiere_certificacion       IN NUMBER,
        p_activo                       IN NUMBER
    ) IS
    BEGIN
        INSERT INTO checklists_mantenimiento (
            id_modelo_avion, codigo_checklist, nombre_checklist,
            tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias,
            tiempo_estimado_minutos, requiere_herramientas_especiales,
            requiere_certificacion, activo
        ) VALUES (
            p_id_modelo_avion, p_codigo_checklist, p_nombre_checklist,
            p_tipo_mantenimiento, p_frecuencia_horas_vuelo, p_frecuencia_dias,
            p_tiempo_estimado_minutos, NVL(p_requiere_herramientas_especiales,0),
            NVL(p_requiere_certificacion,0), NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29601, 'Error al insertar checklist de mantenimiento: ' || SQLERRM);
    END insert_checklist;

    PROCEDURE get_checklist(
        p_id_checklist IN NUMBER
    ) IS
        r checklists_mantenimiento%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM checklists_mantenimiento
        WHERE id_checklist = p_id_checklist;

        DBMS_OUTPUT.PUT_LINE('ID Checklist: ' || r.id_checklist);
        DBMS_OUTPUT.PUT_LINE('Modelo avión: ' || r.id_modelo_avion);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_checklist);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_checklist);
        DBMS_OUTPUT.PUT_LINE('Tipo mantenimiento: ' || r.tipo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Frecuencia horas vuelo: ' || r.frecuencia_horas_vuelo);
        DBMS_OUTPUT.PUT_LINE('Frecuencia días: ' || r.frecuencia_dias);
        DBMS_OUTPUT.PUT_LINE('Tiempo estimado (min): ' || r.tiempo_estimado_minutos);
        DBMS_OUTPUT.PUT_LINE('Requiere herramientas especiales: ' || r.requiere_herramientas_especiales);
        DBMS_OUTPUT.PUT_LINE('Requiere certificación: ' || r.requiere_certificacion);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Checklist de mantenimiento no encontrado.');
    END get_checklist;

    PROCEDURE update_checklist(
        p_id_checklist                 IN NUMBER,
        p_id_modelo_avion              IN NUMBER,
        p_codigo_checklist             IN VARCHAR2,
        p_nombre_checklist             IN VARCHAR2,
        p_tipo_mantenimiento           IN VARCHAR2,
        p_frecuencia_horas_vuelo       IN NUMBER,
        p_frecuencia_dias              IN NUMBER,
        p_tiempo_estimado_minutos      IN NUMBER,
        p_requiere_herramientas_especiales IN NUMBER,
        p_requiere_certificacion       IN NUMBER,
        p_activo                       IN NUMBER
    ) IS
    BEGIN
        UPDATE checklists_mantenimiento
        SET id_modelo_avion              = p_id_modelo_avion,
            codigo_checklist             = p_codigo_checklist,
            nombre_checklist             = p_nombre_checklist,
            tipo_mantenimiento           = p_tipo_mantenimiento,
            frecuencia_horas_vuelo       = p_frecuencia_horas_vuelo,
            frecuencia_dias              = p_frecuencia_dias,
            tiempo_estimado_minutos      = p_tiempo_estimado_minutos,
            requiere_herramientas_especiales = p_requiere_herramientas_especiales,
            requiere_certificacion       = p_requiere_certificacion,
            activo                       = p_activo
        WHERE id_checklist = p_id_checklist;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29602, 'No se encontró el checklist de mantenimiento para actualizar.');
        END IF;
    END update_checklist;

    PROCEDURE delete_checklist(
        p_id_checklist IN NUMBER
    ) IS
    BEGIN
        DELETE FROM checklists_mantenimiento
        WHERE id_checklist = p_id_checklist;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29603, 'No se encontró el checklist de mantenimiento para eliminar.');
        END IF;
    END delete_checklist;

END pkg_checklists_mantenimiento;
/
