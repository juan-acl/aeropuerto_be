------------------------------------------------------------
-- Paquete CRUD para la tabla TANQUES_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tanques_combustible AS
    PROCEDURE insert_tanque(
        p_codigo_tanque          IN VARCHAR2,
        p_nombre_tanque          IN VARCHAR2,
        p_tipo_combustible       IN VARCHAR2,
        p_capacidad_litros       IN NUMBER,
        p_nivel_actual_litros    IN NUMBER,
        p_porcentaje_llenado     IN NUMBER,
        p_ubicacion              IN VARCHAR2,
        p_fecha_ultima_inspeccion IN DATE,
        p_fecha_ultima_calibracion IN DATE,
        p_activo                 IN NUMBER DEFAULT 1
    );

    PROCEDURE get_tanque(
        p_id_tanque IN NUMBER
    );

    PROCEDURE update_tanque(
        p_id_tanque              IN NUMBER,
        p_codigo_tanque          IN VARCHAR2,
        p_nombre_tanque          IN VARCHAR2,
        p_tipo_combustible       IN VARCHAR2,
        p_capacidad_litros       IN NUMBER,
        p_nivel_actual_litros    IN NUMBER,
        p_porcentaje_llenado     IN NUMBER,
        p_ubicacion              IN VARCHAR2,
        p_fecha_ultima_inspeccion IN DATE,
        p_fecha_ultima_calibracion IN DATE,
        p_activo                 IN NUMBER
    );

    PROCEDURE delete_tanque(
        p_id_tanque IN NUMBER
    );
END pkg_tanques_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tanques_combustible AS

    PROCEDURE insert_tanque(
        p_codigo_tanque          IN VARCHAR2,
        p_nombre_tanque          IN VARCHAR2,
        p_tipo_combustible       IN VARCHAR2,
        p_capacidad_litros       IN NUMBER,
        p_nivel_actual_litros    IN NUMBER,
        p_porcentaje_llenado     IN NUMBER,
        p_ubicacion              IN VARCHAR2,
        p_fecha_ultima_inspeccion IN DATE,
        p_fecha_ultima_calibracion IN DATE,
        p_activo                 IN NUMBER
    ) IS
    BEGIN
        INSERT INTO tanques_combustible (
            codigo_tanque, nombre_tanque, tipo_combustible,
            capacidad_litros, nivel_actual_litros, porcentaje_llenado,
            ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo
        ) VALUES (
            p_codigo_tanque, p_nombre_tanque, p_tipo_combustible,
            p_capacidad_litros, p_nivel_actual_litros, p_porcentaje_llenado,
            p_ubicacion, p_fecha_ultima_inspeccion, p_fecha_ultima_calibracion, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30301, 'Error al insertar tanque de combustible: ' || SQLERRM);
    END insert_tanque;

    PROCEDURE get_tanque(
        p_id_tanque IN NUMBER
    ) IS
        r tanques_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tanques_combustible
        WHERE id_tanque = p_id_tanque;

        DBMS_OUTPUT.PUT_LINE('ID Tanque: ' || r.id_tanque);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_tanque);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_tanque);
        DBMS_OUTPUT.PUT_LINE('Tipo combustible: ' || r.tipo_combustible);
        DBMS_OUTPUT.PUT_LINE('Capacidad litros: ' || r.capacidad_litros);
        DBMS_OUTPUT.PUT_LINE('Nivel actual litros: ' || r.nivel_actual_litros);
        DBMS_OUTPUT.PUT_LINE('Porcentaje llenado: ' || r.porcentaje_llenado);
        DBMS_OUTPUT.PUT_LINE('Ubicación: ' || r.ubicacion);
        DBMS_OUTPUT.PUT_LINE('Fecha última inspección: ' || r.fecha_ultima_inspeccion);
        DBMS_OUTPUT.PUT_LINE('Fecha última calibración: ' || r.fecha_ultima_calibracion);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Tanque de combustible no encontrado.');
    END get_tanque;

    PROCEDURE update_tanque(
        p_id_tanque              IN NUMBER,
        p_codigo_tanque          IN VARCHAR2,
        p_nombre_tanque          IN VARCHAR2,
        p_tipo_combustible       IN VARCHAR2,
        p_capacidad_litros       IN NUMBER,
        p_nivel_actual_litros    IN NUMBER,
        p_porcentaje_llenado     IN NUMBER,
        p_ubicacion              IN VARCHAR2,
        p_fecha_ultima_inspeccion IN DATE,
        p_fecha_ultima_calibracion IN DATE,
        p_activo                 IN NUMBER
    ) IS
    BEGIN
        UPDATE tanques_combustible
        SET codigo_tanque          = p_codigo_tanque,
            nombre_tanque          = p_nombre_tanque,
            tipo_combustible       = p_tipo_combustible,
            capacidad_litros       = p_capacidad_litros,
            nivel_actual_litros    = p_nivel_actual_litros,
            porcentaje_llenado     = p_porcentaje_llenado,
            ubicacion              = p_ubicacion,
            fecha_ultima_inspeccion = p_fecha_ultima_inspeccion,
            fecha_ultima_calibracion = p_fecha_ultima_calibracion,
            activo                 = p_activo
        WHERE id_tanque = p_id_tanque;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30302, 'No se encontró el tanque de combustible para actualizar.');
        END IF;
    END update_tanque;

    PROCEDURE delete_tanque(
        p_id_tanque IN NUMBER
    ) IS
    BEGIN
        DELETE FROM tanques_combustible
        WHERE id_tanque = p_id_tanque;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30303, 'No se encontró el tanque de combustible para eliminar.');
        END IF;
    END delete_tanque;

END pkg_tanques_combustible;
/
