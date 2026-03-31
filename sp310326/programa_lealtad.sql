------------------------------------------------------------
-- Paquete CRUD para la tabla PROGRAMA_LEALTAD
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_programa_lealtad AS
    PROCEDURE insert_lealtad(
        p_id_pasajero         IN NUMBER,
        p_nivel_membresia     IN VARCHAR2,
        p_puntos_acumulados   IN NUMBER DEFAULT 0,
        p_puntos_canjeables   IN NUMBER DEFAULT 0,
        p_fecha_ingreso       IN DATE,
        p_fecha_ultima_actividad IN DATE,
        p_millas_acumuladas   IN NUMBER DEFAULT 0,
        p_beneficios_activos  IN VARCHAR2,
        p_tarjeta_numero      IN VARCHAR2,
        p_activo              IN NUMBER DEFAULT 1
    );

    PROCEDURE get_lealtad(
        p_id_lealtad IN NUMBER
    );

    PROCEDURE update_lealtad(
        p_id_lealtad          IN NUMBER,
        p_id_pasajero         IN NUMBER,
        p_nivel_membresia     IN VARCHAR2,
        p_puntos_acumulados   IN NUMBER,
        p_puntos_canjeables   IN NUMBER,
        p_fecha_ingreso       IN DATE,
        p_fecha_ultima_actividad IN DATE,
        p_millas_acumuladas   IN NUMBER,
        p_beneficios_activos  IN VARCHAR2,
        p_tarjeta_numero      IN VARCHAR2,
        p_activo              IN NUMBER
    );

    PROCEDURE delete_lealtad(
        p_id_lealtad IN NUMBER
    );
END pkg_programa_lealtad;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_programa_lealtad AS

    PROCEDURE insert_lealtad(
        p_id_pasajero         IN NUMBER,
        p_nivel_membresia     IN VARCHAR2,
        p_puntos_acumulados   IN NUMBER,
        p_puntos_canjeables   IN NUMBER,
        p_fecha_ingreso       IN DATE,
        p_fecha_ultima_actividad IN DATE,
        p_millas_acumuladas   IN NUMBER,
        p_beneficios_activos  IN VARCHAR2,
        p_tarjeta_numero      IN VARCHAR2,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO programa_lealtad (
            id_pasajero, nivel_membresia, puntos_acumulados,
            puntos_canjeables, fecha_ingreso, fecha_ultima_actividad,
            millas_acumuladas, beneficios_activos, tarjeta_numero, activo
        ) VALUES (
            p_id_pasajero, p_nivel_membresia, NVL(p_puntos_acumulados,0),
            NVL(p_puntos_canjeables,0), p_fecha_ingreso, p_fecha_ultima_actividad,
            NVL(p_millas_acumuladas,0), p_beneficios_activos, p_tarjeta_numero, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26101, 'Error al insertar registro de lealtad: ' || SQLERRM);
    END insert_lealtad;

    PROCEDURE get_lealtad(
        p_id_lealtad IN NUMBER
    ) IS
        r programa_lealtad%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM programa_lealtad
        WHERE id_lealtad = p_id_lealtad;

        DBMS_OUTPUT.PUT_LINE('ID Lealtad: ' || r.id_lealtad);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Nivel membresía: ' || r.nivel_membresia);
        DBMS_OUTPUT.PUT_LINE('Puntos acumulados: ' || r.puntos_acumulados);
        DBMS_OUTPUT.PUT_LINE('Puntos canjeables: ' || r.puntos_canjeables);
        DBMS_OUTPUT.PUT_LINE('Fecha ingreso: ' || r.fecha_ingreso);
        DBMS_OUTPUT.PUT_LINE('Última actividad: ' || r.fecha_ultima_actividad);
        DBMS_OUTPUT.PUT_LINE('Millas acumuladas: ' || r.millas_acumuladas);
        DBMS_OUTPUT.PUT_LINE('Beneficios activos: ' || r.beneficios_activos);
        DBMS_OUTPUT.PUT_LINE('Tarjeta número: ' || r.tarjeta_numero);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Registro de lealtad no encontrado.');
    END get_lealtad;

    PROCEDURE update_lealtad(
        p_id_lealtad          IN NUMBER,
        p_id_pasajero         IN NUMBER,
        p_nivel_membresia     IN VARCHAR2,
        p_puntos_acumulados   IN NUMBER,
        p_puntos_canjeables   IN NUMBER,
        p_fecha_ingreso       IN DATE,
        p_fecha_ultima_actividad IN DATE,
        p_millas_acumuladas   IN NUMBER,
        p_beneficios_activos  IN VARCHAR2,
        p_tarjeta_numero      IN VARCHAR2,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        UPDATE programa_lealtad
        SET id_pasajero         = p_id_pasajero,
            nivel_membresia     = p_nivel_membresia,
            puntos_acumulados   = p_puntos_acumulados,
            puntos_canjeables   = p_puntos_canjeables,
            fecha_ingreso       = p_fecha_ingreso,
            fecha_ultima_actividad = p_fecha_ultima_actividad,
            millas_acumuladas   = p_millas_acumuladas,
            beneficios_activos  = p_beneficios_activos,
            tarjeta_numero      = p_tarjeta_numero,
            activo              = p_activo
        WHERE id_lealtad = p_id_lealtad;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26102, 'No se encontró el registro de lealtad para actualizar.');
        END IF;
    END update_lealtad;

    PROCEDURE delete_lealtad(
        p_id_lealtad IN NUMBER
    ) IS
    BEGIN
        DELETE FROM programa_lealtad
        WHERE id_lealtad = p_id_lealtad;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26103, 'No se encontró el registro de lealtad para eliminar.');
        END IF;
    END delete_lealtad;

END pkg_programa_lealtad;
/