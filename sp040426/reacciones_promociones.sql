------------------------------------------------------------
-- Paquete CRUD para la tabla REACCIONES_PROMOCIONES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_reacciones_promociones AS
    PROCEDURE insert_reaccion(
        p_id_oferta_personalizada IN NUMBER,
        p_id_pasajero             IN NUMBER,
        p_fecha_reaccion          IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_tipo_reaccion           IN VARCHAR2,
        p_canal                   IN VARCHAR2,
        p_convertido_en_reserva   IN NUMBER DEFAULT 0,
        p_id_reserva              IN NUMBER,
        p_valor_conversion        IN NUMBER
    );

    PROCEDURE get_reaccion(
        p_id_reaccion IN NUMBER
    );

    PROCEDURE update_reaccion(
        p_id_reaccion             IN NUMBER,
        p_id_oferta_personalizada IN NUMBER,
        p_id_pasajero             IN NUMBER,
        p_fecha_reaccion          IN TIMESTAMP,
        p_tipo_reaccion           IN VARCHAR2,
        p_canal                   IN VARCHAR2,
        p_convertido_en_reserva   IN NUMBER,
        p_id_reserva              IN NUMBER,
        p_valor_conversion        IN NUMBER
    );

    PROCEDURE delete_reaccion(
        p_id_reaccion IN NUMBER
    );
END pkg_reacciones_promociones;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_reacciones_promociones AS

    PROCEDURE insert_reaccion(
        p_id_oferta_personalizada IN NUMBER,
        p_id_pasajero             IN NUMBER,
        p_fecha_reaccion          IN TIMESTAMP,
        p_tipo_reaccion           IN VARCHAR2,
        p_canal                   IN VARCHAR2,
        p_convertido_en_reserva   IN NUMBER,
        p_id_reserva              IN NUMBER,
        p_valor_conversion        IN NUMBER
    ) IS
    BEGIN
        INSERT INTO reacciones_promociones (
            id_oferta_personalizada, id_pasajero, fecha_reaccion,
            tipo_reaccion, canal, convertido_en_reserva,
            id_reserva, valor_conversion
        ) VALUES (
            p_id_oferta_personalizada, p_id_pasajero, NVL(p_fecha_reaccion, SYSTIMESTAMP),
            p_tipo_reaccion, p_canal, NVL(p_convertido_en_reserva,0),
            p_id_reserva, p_valor_conversion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33401, 'Error al insertar reacción de promoción: ' || SQLERRM);
    END insert_reaccion;

    PROCEDURE get_reaccion(
        p_id_reaccion IN NUMBER
    ) IS
        r reacciones_promociones%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM reacciones_promociones
        WHERE id_reaccion = p_id_reaccion;

        DBMS_OUTPUT.PUT_LINE('ID Reacción: ' || r.id_reaccion);
        DBMS_OUTPUT.PUT_LINE('Oferta personalizada: ' || r.id_oferta_personalizada);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Fecha reacción: ' || r.fecha_reaccion);
        DBMS_OUTPUT.PUT_LINE('Tipo reacción: ' || r.tipo_reaccion);
        DBMS_OUTPUT.PUT_LINE('Canal: ' || r.canal);
        DBMS_OUTPUT.PUT_LINE('Convertido en reserva: ' || r.convertido_en_reserva);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Valor conversión: ' || r.valor_conversion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Reacción de promoción no encontrada.');
    END get_reaccion;

    PROCEDURE update_reaccion(
        p_id_reaccion             IN NUMBER,
        p_id_oferta_personalizada IN NUMBER,
        p_id_pasajero             IN NUMBER,
        p_fecha_reaccion          IN TIMESTAMP,
        p_tipo_reaccion           IN VARCHAR2,
        p_canal                   IN VARCHAR2,
        p_convertido_en_reserva   IN NUMBER,
        p_id_reserva              IN NUMBER,
        p_valor_conversion        IN NUMBER
    ) IS
    BEGIN
        UPDATE reacciones_promociones
        SET id_oferta_personalizada = p_id_oferta_personalizada,
            id_pasajero             = p_id_pasajero,
            fecha_reaccion          = p_fecha_reaccion,
            tipo_reaccion           = p_tipo_reaccion,
            canal                   = p_canal,
            convertido_en_reserva   = p_convertido_en_reserva,
            id_reserva              = p_id_reserva,
            valor_conversion        = p_valor_conversion
        WHERE id_reaccion = p_id_reaccion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33402, 'No se encontró la reacción de promoción para actualizar.');
        END IF;
    END update_reaccion;

    PROCEDURE delete_reaccion(
        p_id_reaccion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM reacciones_promociones
        WHERE id_reaccion = p_id_reaccion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33403, 'No se encontró la reacción de promoción para eliminar.');
        END IF;
    END delete_reaccion;

END pkg_reacciones_promociones;
/
