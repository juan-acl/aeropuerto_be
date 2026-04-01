------------------------------------------------------------
-- Paquete CRUD para la tabla MOVIMIENTOS_BANCARIOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_movimientos_bancarios AS
    PROCEDURE insert_movimiento(
        p_id_cuenta       IN NUMBER,
        p_fecha           IN DATE,
        p_tipo_movimiento IN VARCHAR2,
        p_concepto        IN VARCHAR2,
        p_monto           IN NUMBER,
        p_saldo_resultante IN NUMBER,
        p_referencia      IN VARCHAR2,
        p_conciliado      IN NUMBER DEFAULT 0
    );

    PROCEDURE get_movimiento(
        p_id_movimiento IN NUMBER
    );

    PROCEDURE update_movimiento(
        p_id_movimiento  IN NUMBER,
        p_id_cuenta      IN NUMBER,
        p_fecha          IN DATE,
        p_tipo_movimiento IN VARCHAR2,
        p_concepto       IN VARCHAR2,
        p_monto          IN NUMBER,
        p_saldo_resultante IN NUMBER,
        p_referencia     IN VARCHAR2,
        p_conciliado     IN NUMBER
    );

    PROCEDURE delete_movimiento(
        p_id_movimiento IN NUMBER
    );
END pkg_movimientos_bancarios;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_movimientos_bancarios AS

    PROCEDURE insert_movimiento(
        p_id_cuenta       IN NUMBER,
        p_fecha           IN DATE,
        p_tipo_movimiento IN VARCHAR2,
        p_concepto        IN VARCHAR2,
        p_monto           IN NUMBER,
        p_saldo_resultante IN NUMBER,
        p_referencia      IN VARCHAR2,
        p_conciliado      IN NUMBER
    ) IS
    BEGIN
        INSERT INTO movimientos_bancarios (
            id_cuenta, fecha, tipo_movimiento, concepto,
            monto, saldo_resultante, referencia, conciliado
        ) VALUES (
            p_id_cuenta, p_fecha, p_tipo_movimiento, p_concepto,
            p_monto, p_saldo_resultante, p_referencia, NVL(p_conciliado,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28101, 'Error al insertar movimiento bancario: ' || SQLERRM);
    END insert_movimiento;

    PROCEDURE get_movimiento(
        p_id_movimiento IN NUMBER
    ) IS
        r movimientos_bancarios%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM movimientos_bancarios
        WHERE id_movimiento = p_id_movimiento;

        DBMS_OUTPUT.PUT_LINE('ID Movimiento: ' || r.id_movimiento);
        DBMS_OUTPUT.PUT_LINE('Cuenta: ' || r.id_cuenta);
        DBMS_OUTPUT.PUT_LINE('Fecha: ' || r.fecha);
        DBMS_OUTPUT.PUT_LINE('Tipo movimiento: ' || r.tipo_movimiento);
        DBMS_OUTPUT.PUT_LINE('Concepto: ' || r.concepto);
        DBMS_OUTPUT.PUT_LINE('Monto: ' || r.monto);
        DBMS_OUTPUT.PUT_LINE('Saldo resultante: ' || r.saldo_resultante);
        DBMS_OUTPUT.PUT_LINE('Referencia: ' || r.referencia);
        DBMS_OUTPUT.PUT_LINE('Conciliado: ' || r.conciliado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Movimiento bancario no encontrado.');
    END get_movimiento;

    PROCEDURE update_movimiento(
        p_id_movimiento  IN NUMBER,
        p_id_cuenta      IN NUMBER,
        p_fecha          IN DATE,
        p_tipo_movimiento IN VARCHAR2,
        p_concepto       IN VARCHAR2,
        p_monto          IN NUMBER,
        p_saldo_resultante IN NUMBER,
        p_referencia     IN VARCHAR2,
        p_conciliado     IN NUMBER
    ) IS
    BEGIN
        UPDATE movimientos_bancarios
        SET id_cuenta       = p_id_cuenta,
            fecha           = p_fecha,
            tipo_movimiento = p_tipo_movimiento,
            concepto        = p_concepto,
            monto           = p_monto,
            saldo_resultante = p_saldo_resultante,
            referencia      = p_referencia,
            conciliado      = p_conciliado
        WHERE id_movimiento = p_id_movimiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28102, 'No se encontró el movimiento bancario para actualizar.');
        END IF;
    END update_movimiento;

    PROCEDURE delete_movimiento(
        p_id_movimiento IN NUMBER
    ) IS
    BEGIN
        DELETE FROM movimientos_bancarios
        WHERE id_movimiento = p_id_movimiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28103, 'No se encontró el movimiento bancario para eliminar.');
        END IF;
    END delete_movimiento;

END pkg_movimientos_bancarios;
/
