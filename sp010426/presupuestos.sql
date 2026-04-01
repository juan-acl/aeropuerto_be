------------------------------------------------------------
-- Paquete CRUD para la tabla PRESUPUESTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_presupuestos AS
    PROCEDURE insert_presupuesto(
        p_anio_fiscal       IN NUMBER,
        p_mes               IN NUMBER,
        p_concepto          IN VARCHAR2,
        p_id_departamento   IN NUMBER,
        p_monto_asignado    IN NUMBER,
        p_monto_ejecutado   IN NUMBER,
        p_tipo_gasto        IN VARCHAR2,
        p_observaciones     IN VARCHAR2,
        p_fecha_actualizacion IN DATE
    );

    PROCEDURE get_presupuesto(
        p_id_presupuesto IN NUMBER
    );

    PROCEDURE update_presupuesto(
        p_id_presupuesto    IN NUMBER,
        p_anio_fiscal       IN NUMBER,
        p_mes               IN NUMBER,
        p_concepto          IN VARCHAR2,
        p_id_departamento   IN NUMBER,
        p_monto_asignado    IN NUMBER,
        p_monto_ejecutado   IN NUMBER,
        p_tipo_gasto        IN VARCHAR2,
        p_observaciones     IN VARCHAR2,
        p_fecha_actualizacion IN DATE
    );

    PROCEDURE delete_presupuesto(
        p_id_presupuesto IN NUMBER
    );
END pkg_presupuestos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_presupuestos AS

    PROCEDURE insert_presupuesto(
        p_anio_fiscal       IN NUMBER,
        p_mes               IN NUMBER,
        p_concepto          IN VARCHAR2,
        p_id_departamento   IN NUMBER,
        p_monto_asignado    IN NUMBER,
        p_monto_ejecutado   IN NUMBER,
        p_tipo_gasto        IN VARCHAR2,
        p_observaciones     IN VARCHAR2,
        p_fecha_actualizacion IN DATE
    ) IS
    BEGIN
        INSERT INTO presupuestos (
            anio_fiscal, mes, concepto, id_departamento,
            monto_asignado, monto_ejecutado, tipo_gasto,
            observaciones, fecha_actualizacion
        ) VALUES (
            p_anio_fiscal, p_mes, p_concepto, p_id_departamento,
            p_monto_asignado, p_monto_ejecutado, p_tipo_gasto,
            p_observaciones, p_fecha_actualizacion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27201, 'Error al insertar presupuesto: ' || SQLERRM);
    END insert_presupuesto;

    PROCEDURE get_presupuesto(
        p_id_presupuesto IN NUMBER
    ) IS
        r presupuestos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM presupuestos
        WHERE id_presupuesto = p_id_presupuesto;

        DBMS_OUTPUT.PUT_LINE('ID Presupuesto: ' || r.id_presupuesto);
        DBMS_OUTPUT.PUT_LINE('Año fiscal: ' || r.anio_fiscal);
        DBMS_OUTPUT.PUT_LINE('Mes: ' || r.mes);
        DBMS_OUTPUT.PUT_LINE('Concepto: ' || r.concepto);
        DBMS_OUTPUT.PUT_LINE('Departamento: ' || r.id_departamento);
        DBMS_OUTPUT.PUT_LINE('Monto asignado: ' || r.monto_asignado);
        DBMS_OUTPUT.PUT_LINE('Monto ejecutado: ' || r.monto_ejecutado);
        DBMS_OUTPUT.PUT_LINE('Tipo gasto: ' || r.tipo_gasto);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
        DBMS_OUTPUT.PUT_LINE('Fecha actualización: ' || r.fecha_actualizacion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Presupuesto no encontrado.');
    END get_presupuesto;

    PROCEDURE update_presupuesto(
        p_id_presupuesto    IN NUMBER,
        p_anio_fiscal       IN NUMBER,
        p_mes               IN NUMBER,
        p_concepto          IN VARCHAR2,
        p_id_departamento   IN NUMBER,
        p_monto_asignado    IN NUMBER,
        p_monto_ejecutado   IN NUMBER,
        p_tipo_gasto        IN VARCHAR2,
        p_observaciones     IN VARCHAR2,
        p_fecha_actualizacion IN DATE
    ) IS
    BEGIN
        UPDATE presupuestos
        SET anio_fiscal       = p_anio_fiscal,
            mes               = p_mes,
            concepto          = p_concepto,
            id_departamento   = p_id_departamento,
            monto_asignado    = p_monto_asignado,
            monto_ejecutado   = p_monto_ejecutado,
            tipo_gasto        = p_tipo_gasto,
            observaciones     = p_observaciones,
            fecha_actualizacion = p_fecha_actualizacion
        WHERE id_presupuesto = p_id_presupuesto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27202, 'No se encontró el presupuesto para actualizar.');
        END IF;
    END update_presupuesto;

    PROCEDURE delete_presupuesto(
        p_id_presupuesto IN NUMBER
    ) IS
    BEGIN
        DELETE FROM presupuestos
        WHERE id_presupuesto = p_id_presupuesto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27203, 'No se encontró el presupuesto para eliminar.');
        END IF;
    END delete_presupuesto;

END pkg_presupuestos;
/
