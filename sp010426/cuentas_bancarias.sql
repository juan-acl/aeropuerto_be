------------------------------------------------------------
-- Paquete CRUD para la tabla CUENTAS_BANCARIAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_cuentas_bancarias AS
    PROCEDURE insert_cuenta(
        p_banco          IN VARCHAR2,
        p_tipo_cuenta    IN VARCHAR2,
        p_numero_cuenta  IN VARCHAR2,
        p_moneda         IN VARCHAR2,
        p_saldo_actual   IN NUMBER,
        p_fecha_apertura IN DATE,
        p_estado         IN VARCHAR2 DEFAULT 'ACTIVA',
        p_responsable    IN VARCHAR2
    );

    PROCEDURE get_cuenta(
        p_id_cuenta IN NUMBER
    );

    PROCEDURE update_cuenta(
        p_id_cuenta      IN NUMBER,
        p_banco          IN VARCHAR2,
        p_tipo_cuenta    IN VARCHAR2,
        p_numero_cuenta  IN VARCHAR2,
        p_moneda         IN VARCHAR2,
        p_saldo_actual   IN NUMBER,
        p_fecha_apertura IN DATE,
        p_estado         IN VARCHAR2,
        p_responsable    IN VARCHAR2
    );

    PROCEDURE delete_cuenta(
        p_id_cuenta IN NUMBER
    );
END pkg_cuentas_bancarias;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_cuentas_bancarias AS

    PROCEDURE insert_cuenta(
        p_banco          IN VARCHAR2,
        p_tipo_cuenta    IN VARCHAR2,
        p_numero_cuenta  IN VARCHAR2,
        p_moneda         IN VARCHAR2,
        p_saldo_actual   IN NUMBER,
        p_fecha_apertura IN DATE,
        p_estado         IN VARCHAR2,
        p_responsable    IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO cuentas_bancarias (
            banco, tipo_cuenta, numero_cuenta, moneda,
            saldo_actual, fecha_apertura, estado, responsable
        ) VALUES (
            p_banco, p_tipo_cuenta, p_numero_cuenta, p_moneda,
            p_saldo_actual, p_fecha_apertura, NVL(p_estado,'ACTIVA'), p_responsable
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28001, 'Error al insertar cuenta bancaria: ' || SQLERRM);
    END insert_cuenta;

    PROCEDURE get_cuenta(
        p_id_cuenta IN NUMBER
    ) IS
        r cuentas_bancarias%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM cuentas_bancarias
        WHERE id_cuenta = p_id_cuenta;

        DBMS_OUTPUT.PUT_LINE('ID Cuenta: ' || r.id_cuenta);
        DBMS_OUTPUT.PUT_LINE('Banco: ' || r.banco);
        DBMS_OUTPUT.PUT_LINE('Tipo cuenta: ' || r.tipo_cuenta);
        DBMS_OUTPUT.PUT_LINE('Número cuenta: ' || r.numero_cuenta);
        DBMS_OUTPUT.PUT_LINE('Moneda: ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Saldo actual: ' || r.saldo_actual);
        DBMS_OUTPUT.PUT_LINE('Fecha apertura: ' || r.fecha_apertura);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Responsable: ' || r.responsable);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Cuenta bancaria no encontrada.');
    END get_cuenta;

    PROCEDURE update_cuenta(
        p_id_cuenta      IN NUMBER,
        p_banco          IN VARCHAR2,
        p_tipo_cuenta    IN VARCHAR2,
        p_numero_cuenta  IN VARCHAR2,
        p_moneda         IN VARCHAR2,
        p_saldo_actual   IN NUMBER,
        p_fecha_apertura IN DATE,
        p_estado         IN VARCHAR2,
        p_responsable    IN VARCHAR2
    ) IS
    BEGIN
        UPDATE cuentas_bancarias
        SET banco          = p_banco,
            tipo_cuenta    = p_tipo_cuenta,
            numero_cuenta  = p_numero_cuenta,
            moneda         = p_moneda,
            saldo_actual   = p_saldo_actual,
            fecha_apertura = p_fecha_apertura,
            estado         = p_estado,
            responsable    = p_responsable
        WHERE id_cuenta = p_id_cuenta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28002, 'No se encontró la cuenta bancaria para actualizar.');
        END IF;
    END update_cuenta;

    PROCEDURE delete_cuenta(
        p_id_cuenta IN NUMBER
    ) IS
    BEGIN
        DELETE FROM cuentas_bancarias
        WHERE id_cuenta = p_id_cuenta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28003, 'No se encontró la cuenta bancaria para eliminar.');
        END IF;
    END delete_cuenta;

END pkg_cuentas_bancarias;
/
