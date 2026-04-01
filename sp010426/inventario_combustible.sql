------------------------------------------------------------
-- Paquete CRUD para la tabla INVENTARIO_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_inventario_combustible AS
    PROCEDURE insert_inventario(
        p_id_tanque             IN NUMBER,
        p_fecha_inventario      IN DATE,
        p_nivel_medido_litros   IN NUMBER,
        p_nivel_teorico_litros  IN NUMBER,
        p_diferencia_litros     IN NUMBER,
        p_porcentaje_diferencia IN NUMBER,
        p_temperatura_promedio  IN NUMBER,
        p_tipo_inventario       IN VARCHAR2,
        p_realizado_por         IN NUMBER,
        p_verificado_por        IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE get_inventario(
        p_id_inventario IN NUMBER
    );

    PROCEDURE update_inventario(
        p_id_inventario         IN NUMBER,
        p_id_tanque             IN NUMBER,
        p_fecha_inventario      IN DATE,
        p_nivel_medido_litros   IN NUMBER,
        p_nivel_teorico_litros  IN NUMBER,
        p_diferencia_litros     IN NUMBER,
        p_porcentaje_diferencia IN NUMBER,
        p_temperatura_promedio  IN NUMBER,
        p_tipo_inventario       IN VARCHAR2,
        p_realizado_por         IN NUMBER,
        p_verificado_por        IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE delete_inventario(
        p_id_inventario IN NUMBER
    );
END pkg_inventario_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_inventario_combustible AS

    PROCEDURE insert_inventario(
        p_id_tanque             IN NUMBER,
        p_fecha_inventario      IN DATE,
        p_nivel_medido_litros   IN NUMBER,
        p_nivel_teorico_litros  IN NUMBER,
        p_diferencia_litros     IN NUMBER,
        p_porcentaje_diferencia IN NUMBER,
        p_temperatura_promedio  IN NUMBER,
        p_tipo_inventario       IN VARCHAR2,
        p_realizado_por         IN NUMBER,
        p_verificado_por        IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO inventario_combustible (
            id_tanque, fecha_inventario, nivel_medido_litros,
            nivel_teorico_litros, diferencia_litros, porcentaje_diferencia,
            temperatura_promedio, tipo_inventario,
            realizado_por, verificado_por, observaciones
        ) VALUES (
            p_id_tanque, p_fecha_inventario, p_nivel_medido_litros,
            p_nivel_teorico_litros, p_diferencia_litros, p_porcentaje_diferencia,
            p_temperatura_promedio, p_tipo_inventario,
            p_realizado_por, p_verificado_por, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31101, 'Error al insertar inventario de combustible: ' || SQLERRM);
    END insert_inventario;

    PROCEDURE get_inventario(
        p_id_inventario IN NUMBER
    ) IS
        r inventario_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM inventario_combustible
        WHERE id_inventario = p_id_inventario;

        DBMS_OUTPUT.PUT_LINE('ID Inventario: ' || r.id_inventario);
        DBMS_OUTPUT.PUT_LINE('Tanque: ' || r.id_tanque);
        DBMS_OUTPUT.PUT_LINE('Fecha inventario: ' || r.fecha_inventario);
        DBMS_OUTPUT.PUT_LINE('Nivel medido (litros): ' || r.nivel_medido_litros);
        DBMS_OUTPUT.PUT_LINE('Nivel teórico (litros): ' || r.nivel_teorico_litros);
        DBMS_OUTPUT.PUT_LINE('Diferencia (litros): ' || r.diferencia_litros);
        DBMS_OUTPUT.PUT_LINE('Porcentaje diferencia: ' || r.porcentaje_diferencia);
        DBMS_OUTPUT.PUT_LINE('Temperatura promedio: ' || r.temperatura_promedio);
        DBMS_OUTPUT.PUT_LINE('Tipo inventario: ' || r.tipo_inventario);
        DBMS_OUTPUT.PUT_LINE('Realizado por: ' || r.realizado_por);
        DBMS_OUTPUT.PUT_LINE('Verificado por: ' || r.verificado_por);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Inventario de combustible no encontrado.');
    END get_inventario;

    PROCEDURE update_inventario(
        p_id_inventario         IN NUMBER,
        p_id_tanque             IN NUMBER,
        p_fecha_inventario      IN DATE,
        p_nivel_medido_litros   IN NUMBER,
        p_nivel_teorico_litros  IN NUMBER,
        p_diferencia_litros     IN NUMBER,
        p_porcentaje_diferencia IN NUMBER,
        p_temperatura_promedio  IN NUMBER,
        p_tipo_inventario       IN VARCHAR2,
        p_realizado_por         IN NUMBER,
        p_verificado_por        IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        UPDATE inventario_combustible
        SET id_tanque             = p_id_tanque,
            fecha_inventario      = p_fecha_inventario,
            nivel_medido_litros   = p_nivel_medido_litros,
            nivel_teorico_litros  = p_nivel_teorico_litros,
            diferencia_litros     = p_diferencia_litros,
            porcentaje_diferencia = p_porcentaje_diferencia,
            temperatura_promedio  = p_temperatura_promedio,
            tipo_inventario       = p_tipo_inventario,
            realizado_por         = p_realizado_por,
            verificado_por        = p_verificado_por,
            observaciones         = p_observaciones
        WHERE id_inventario = p_id_inventario;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31102, 'No se encontró el inventario de combustible para actualizar.');
        END IF;
    END update_inventario;

    PROCEDURE delete_inventario(
        p_id_inventario IN NUMBER
    ) IS
    BEGIN
        DELETE FROM inventario_combustible
        WHERE id_inventario = p_id_inventario;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31103, 'No se encontró el inventario de combustible para eliminar.');
        END IF;
    END delete_inventario;

END pkg_inventario_combustible;
/
