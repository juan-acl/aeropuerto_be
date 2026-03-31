------------------------------------------------------------
-- Paquete CRUD para la tabla INCIDENTES_MEDIDAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_incidentes_medidas AS
    PROCEDURE insert_medida(
        p_id_incidente     IN NUMBER,
        p_tipo_medida      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_fecha_aplicacion IN TIMESTAMP,
        p_aplicado_por     IN VARCHAR2,
        p_vigencia_dias    IN NUMBER,
        p_fecha_vencimiento IN DATE,
        p_observaciones    IN VARCHAR2
    );

    PROCEDURE get_medida(
        p_id_medida IN NUMBER
    );

    PROCEDURE update_medida(
        p_id_medida        IN NUMBER,
        p_id_incidente     IN NUMBER,
        p_tipo_medida      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_fecha_aplicacion IN TIMESTAMP,
        p_aplicado_por     IN VARCHAR2,
        p_vigencia_dias    IN NUMBER,
        p_fecha_vencimiento IN DATE,
        p_observaciones    IN VARCHAR2
    );

    PROCEDURE delete_medida(
        p_id_medida IN NUMBER
    );
END pkg_incidentes_medidas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_incidentes_medidas AS

    PROCEDURE insert_medida(
        p_id_incidente     IN NUMBER,
        p_tipo_medida      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_fecha_aplicacion IN TIMESTAMP,
        p_aplicado_por     IN VARCHAR2,
        p_vigencia_dias    IN NUMBER,
        p_fecha_vencimiento IN DATE,
        p_observaciones    IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO incidentes_medidas (
            id_incidente, tipo_medida, descripcion,
            fecha_aplicacion, aplicado_por, vigencia_dias,
            fecha_vencimiento, observaciones
        ) VALUES (
            p_id_incidente, p_tipo_medida, p_descripcion,
            p_fecha_aplicacion, p_aplicado_por, p_vigencia_dias,
            p_fecha_vencimiento, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23701, 'Error al insertar medida de incidente: ' || SQLERRM);
    END insert_medida;

    PROCEDURE get_medida(
        p_id_medida IN NUMBER
    ) IS
        r incidentes_medidas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM incidentes_medidas
        WHERE id_medida = p_id_medida;

        DBMS_OUTPUT.PUT_LINE('ID Medida: ' || r.id_medida);
        DBMS_OUTPUT.PUT_LINE('Incidente: ' || r.id_incidente);
        DBMS_OUTPUT.PUT_LINE('Tipo medida: ' || r.tipo_medida);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Fecha aplicación: ' || r.fecha_aplicacion);
        DBMS_OUTPUT.PUT_LINE('Aplicado por: ' || r.aplicado_por);
        DBMS_OUTPUT.PUT_LINE('Vigencia días: ' || r.vigencia_dias);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Medida de incidente no encontrada.');
    END get_medida;

    PROCEDURE update_medida(
        p_id_medida        IN NUMBER,
        p_id_incidente     IN NUMBER,
        p_tipo_medida      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_fecha_aplicacion IN TIMESTAMP,
        p_aplicado_por     IN VARCHAR2,
        p_vigencia_dias    IN NUMBER,
        p_fecha_vencimiento IN DATE,
        p_observaciones    IN VARCHAR2
    ) IS
    BEGIN
        UPDATE incidentes_medidas
        SET id_incidente     = p_id_incidente,
            tipo_medida      = p_tipo_medida,
            descripcion      = p_descripcion,
            fecha_aplicacion = p_fecha_aplicacion,
            aplicado_por     = p_aplicado_por,
            vigencia_dias    = p_vigencia_dias,
            fecha_vencimiento = p_fecha_vencimiento,
            observaciones    = p_observaciones
        WHERE id_medida = p_id_medida;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23702, 'No se encontró la medida de incidente para actualizar.');
        END IF;
    END update_medida;

    PROCEDURE delete_medida(
        p_id_medida IN NUMBER
    ) IS
    BEGIN
        DELETE FROM incidentes_medidas
        WHERE id_medida = p_id_medida;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23703, 'No se encontró la medida de incidente para eliminar.');
        END IF;
    END delete_medida;

END pkg_incidentes_medidas;
/