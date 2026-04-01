------------------------------------------------------------
-- Paquete CRUD para la tabla TASAS_AEROPORTUARIAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tasas_aeroportuarias AS
    PROCEDURE insert_tasa(
        p_nombre_tasa        IN VARCHAR2,
        p_tipo_tasa          IN VARCHAR2,
        p_monto              IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_calculo_porcentaje IN NUMBER,
        p_aplica_a           IN VARCHAR2,
        p_activa             IN NUMBER DEFAULT 1,
        p_fecha_actualizacion IN DATE
    );

    PROCEDURE get_tasa(
        p_id_tasa IN NUMBER
    );

    PROCEDURE update_tasa(
        p_id_tasa            IN NUMBER,
        p_nombre_tasa        IN VARCHAR2,
        p_tipo_tasa          IN VARCHAR2,
        p_monto              IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_calculo_porcentaje IN NUMBER,
        p_aplica_a           IN VARCHAR2,
        p_activa             IN NUMBER,
        p_fecha_actualizacion IN DATE
    );

    PROCEDURE delete_tasa(
        p_id_tasa IN NUMBER
    );
END pkg_tasas_aeroportuarias;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tasas_aeroportuarias AS

    PROCEDURE insert_tasa(
        p_nombre_tasa        IN VARCHAR2,
        p_tipo_tasa          IN VARCHAR2,
        p_monto              IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_calculo_porcentaje IN NUMBER,
        p_aplica_a           IN VARCHAR2,
        p_activa             IN NUMBER,
        p_fecha_actualizacion IN DATE
    ) IS
    BEGIN
        INSERT INTO tasas_aeroportuarias (
            nombre_tasa, tipo_tasa, monto, moneda,
            calculo_porcentaje, aplica_a, activa, fecha_actualizacion
        ) VALUES (
            p_nombre_tasa, p_tipo_tasa, p_monto, p_moneda,
            p_calculo_porcentaje, p_aplica_a, NVL(p_activa,1), p_fecha_actualizacion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27801, 'Error al insertar tasa aeroportuaria: ' || SQLERRM);
    END insert_tasa;

    PROCEDURE get_tasa(
        p_id_tasa IN NUMBER
    ) IS
        r tasas_aeroportuarias%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tasas_aeroportuarias
        WHERE id_tasa = p_id_tasa;

        DBMS_OUTPUT.PUT_LINE('ID Tasa: ' || r.id_tasa);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_tasa);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_tasa);
        DBMS_OUTPUT.PUT_LINE('Monto: ' || r.monto || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Porcentaje cálculo: ' || r.calculo_porcentaje);
        DBMS_OUTPUT.PUT_LINE('Aplica a: ' || r.aplica_a);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
        DBMS_OUTPUT.PUT_LINE('Fecha actualización: ' || r.fecha_actualizacion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Tasa aeroportuaria no encontrada.');
    END get_tasa;

    PROCEDURE update_tasa(
        p_id_tasa            IN NUMBER,
        p_nombre_tasa        IN VARCHAR2,
        p_tipo_tasa          IN VARCHAR2,
        p_monto              IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_calculo_porcentaje IN NUMBER,
        p_aplica_a           IN VARCHAR2,
        p_activa             IN NUMBER,
        p_fecha_actualizacion IN DATE
    ) IS
    BEGIN
        UPDATE tasas_aeroportuarias
        SET nombre_tasa        = p_nombre_tasa,
            tipo_tasa          = p_tipo_tasa,
            monto              = p_monto,
            moneda             = p_moneda,
            calculo_porcentaje = p_calculo_porcentaje,
            aplica_a           = p_aplica_a,
            activa             = p_activa,
            fecha_actualizacion = p_fecha_actualizacion
        WHERE id_tasa = p_id_tasa;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27802, 'No se encontró la tasa aeroportuaria para actualizar.');
        END IF;
    END update_tasa;

    PROCEDURE delete_tasa(
        p_id_tasa IN NUMBER
    ) IS
    BEGIN
        DELETE FROM tasas_aeroportuarias
        WHERE id_tasa = p_id_tasa;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27803, 'No se encontró la tasa aeroportuaria para eliminar.');
        END IF;
    END delete_tasa;

END pkg_tasas_aeroportuarias;
/
