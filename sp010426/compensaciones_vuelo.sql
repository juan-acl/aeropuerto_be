------------------------------------------------------------
-- Paquete CRUD para la tabla COMPENSACIONES_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_compensaciones_vuelo AS
    PROCEDURE insert_compensacion(
        p_id_huella_carbono       IN NUMBER,
        p_id_programa_compensacion IN NUMBER,
        p_fecha_compensacion      IN DATE DEFAULT SYSDATE,
        p_cantidad_compensada_kg  IN NUMBER,
        p_porcentaje_compensado   IN NUMBER,
        p_monto_aportado          IN NUMBER,
        p_moneda                  IN VARCHAR2,
        p_comprobante_compensacion IN BLOB,
        p_verificada              IN NUMBER DEFAULT 0
    );

    PROCEDURE get_compensacion(
        p_id_compensacion_vuelo IN NUMBER
    );

    PROCEDURE update_compensacion(
        p_id_compensacion_vuelo  IN NUMBER,
        p_id_huella_carbono      IN NUMBER,
        p_id_programa_compensacion IN NUMBER,
        p_fecha_compensacion     IN DATE,
        p_cantidad_compensada_kg IN NUMBER,
        p_porcentaje_compensado  IN NUMBER,
        p_monto_aportado         IN NUMBER,
        p_moneda                 IN VARCHAR2,
        p_comprobante_compensacion IN BLOB,
        p_verificada             IN NUMBER
    );

    PROCEDURE delete_compensacion(
        p_id_compensacion_vuelo IN NUMBER
    );
END pkg_compensaciones_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_compensaciones_vuelo AS

    PROCEDURE insert_compensacion(
        p_id_huella_carbono       IN NUMBER,
        p_id_programa_compensacion IN NUMBER,
        p_fecha_compensacion      IN DATE,
        p_cantidad_compensada_kg  IN NUMBER,
        p_porcentaje_compensado   IN NUMBER,
        p_monto_aportado          IN NUMBER,
        p_moneda                  IN VARCHAR2,
        p_comprobante_compensacion IN BLOB,
        p_verificada              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO compensaciones_vuelo (
            id_huella_carbono, id_programa_compensacion, fecha_compensacion,
            cantidad_compensada_kg, porcentaje_compensado, monto_aportado,
            moneda, comprobante_compensacion, verificada
        ) VALUES (
            p_id_huella_carbono, p_id_programa_compensacion, NVL(p_fecha_compensacion, SYSDATE),
            p_cantidad_compensada_kg, p_porcentaje_compensado, p_monto_aportado,
            p_moneda, p_comprobante_compensacion, NVL(p_verificada,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31501, 'Error al insertar compensación de vuelo: ' || SQLERRM);
    END insert_compensacion;

    PROCEDURE get_compensacion(
        p_id_compensacion_vuelo IN NUMBER
    ) IS
        r compensaciones_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM compensaciones_vuelo
        WHERE id_compensacion_vuelo = p_id_compensacion_vuelo;

        DBMS_OUTPUT.PUT_LINE('ID Compensación: ' || r.id_compensacion_vuelo);
        DBMS_OUTPUT.PUT_LINE('Huella carbono: ' || r.id_huella_carbono);
        DBMS_OUTPUT.PUT_LINE('Programa compensación: ' || r.id_programa_compensacion);
        DBMS_OUTPUT.PUT_LINE('Fecha compensación: ' || r.fecha_compensacion);
        DBMS_OUTPUT.PUT_LINE('Cantidad compensada (kg): ' || r.cantidad_compensada_kg);
        DBMS_OUTPUT.PUT_LINE('Porcentaje compensado: ' || r.porcentaje_compensado);
        DBMS_OUTPUT.PUT_LINE('Monto aportado: ' || r.monto_aportado || ' ' || r.moneda);
        IF r.comprobante_compensacion IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Comprobante: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Comprobante: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Verificada: ' || r.verificada);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Compensación de vuelo no encontrada.');
    END get_compensacion;

    PROCEDURE update_compensacion(
        p_id_compensacion_vuelo  IN NUMBER,
        p_id_huella_carbono      IN NUMBER,
        p_id_programa_compensacion IN NUMBER,
        p_fecha_compensacion     IN DATE,
        p_cantidad_compensada_kg IN NUMBER,
        p_porcentaje_compensado  IN NUMBER,
        p_monto_aportado         IN NUMBER,
        p_moneda                 IN VARCHAR2,
        p_comprobante_compensacion IN BLOB,
        p_verificada             IN NUMBER
    ) IS
    BEGIN
        UPDATE compensaciones_vuelo
        SET id_huella_carbono       = p_id_huella_carbono,
            id_programa_compensacion = p_id_programa_compensacion,
            fecha_compensacion      = p_fecha_compensacion,
            cantidad_compensada_kg  = p_cantidad_compensada_kg,
            porcentaje_compensado   = p_porcentaje_compensado,
            monto_aportado          = p_monto_aportado,
            moneda                  = p_moneda,
            comprobante_compensacion = p_comprobante_compensacion,
            verificada              = p_verificada
        WHERE id_compensacion_vuelo = p_id_compensacion_vuelo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31502, 'No se encontró la compensación de vuelo para actualizar.');
        END IF;
    END update_compensacion;

    PROCEDURE delete_compensacion(
        p_id_compensacion_vuelo IN NUMBER
    ) IS
    BEGIN
        DELETE FROM compensaciones_vuelo
        WHERE id_compensacion_vuelo = p_id_compensacion_vuelo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31503, 'No se encontró la compensación de vuelo para eliminar.');
        END IF;
    END delete_compensacion;

END pkg_compensaciones_vuelo;
/
