------------------------------------------------------------
-- Paquete CRUD para la tabla NEWSLETTER_SUSCRIPCIONES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_newsletter_suscripciones AS
    PROCEDURE insert_suscripcion(
        p_id_pasajero          IN NUMBER,
        p_email                IN VARCHAR2,
        p_nombre               IN VARCHAR2,
        p_fecha_suscripcion    IN DATE DEFAULT SYSDATE,
        p_fecha_baja           IN DATE,
        p_frecuencia           IN VARCHAR2 DEFAULT 'MENSUAL',
        p_temas_interes        IN VARCHAR2,
        p_confirmado           IN NUMBER DEFAULT 0,
        p_token_confirmacion   IN VARCHAR2,
        p_activo               IN NUMBER DEFAULT 1
    );

    PROCEDURE get_suscripcion(
        p_id_suscripcion_newsletter IN NUMBER
    );

    PROCEDURE update_suscripcion(
        p_id_suscripcion_newsletter IN NUMBER,
        p_id_pasajero          IN NUMBER,
        p_email                IN VARCHAR2,
        p_nombre               IN VARCHAR2,
        p_fecha_suscripcion    IN DATE,
        p_fecha_baja           IN DATE,
        p_frecuencia           IN VARCHAR2,
        p_temas_interes        IN VARCHAR2,
        p_confirmado           IN NUMBER,
        p_token_confirmacion   IN VARCHAR2,
        p_activo               IN NUMBER
    );

    PROCEDURE delete_suscripcion(
        p_id_suscripcion_newsletter IN NUMBER
    );
END pkg_newsletter_suscripciones;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_newsletter_suscripciones AS

    PROCEDURE insert_suscripcion(
        p_id_pasajero          IN NUMBER,
        p_email                IN VARCHAR2,
        p_nombre               IN VARCHAR2,
        p_fecha_suscripcion    IN DATE,
        p_fecha_baja           IN DATE,
        p_frecuencia           IN VARCHAR2,
        p_temas_interes        IN VARCHAR2,
        p_confirmado           IN NUMBER,
        p_token_confirmacion   IN VARCHAR2,
        p_activo               IN NUMBER
    ) IS
    BEGIN
        INSERT INTO newsletter_suscripciones (
            id_pasajero, email, nombre, fecha_suscripcion,
            fecha_baja, frecuencia, temas_interes,
            confirmado, token_confirmacion, activo
        ) VALUES (
            p_id_pasajero, p_email, p_nombre, NVL(p_fecha_suscripcion, SYSDATE),
            p_fecha_baja, NVL(p_frecuencia,'MENSUAL'), p_temas_interes,
            NVL(p_confirmado,0), p_token_confirmacion, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33201, 'Error al insertar suscripción de newsletter: ' || SQLERRM);
    END insert_suscripcion;

    PROCEDURE get_suscripcion(
        p_id_suscripcion_newsletter IN NUMBER
    ) IS
        r newsletter_suscripciones%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM newsletter_suscripciones
        WHERE id_suscripcion_newsletter = p_id_suscripcion_newsletter;

        DBMS_OUTPUT.PUT_LINE('ID Suscripción: ' || r.id_suscripcion_newsletter);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Email: ' || r.email);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre);
        DBMS_OUTPUT.PUT_LINE('Fecha suscripción: ' || r.fecha_suscripcion);
        DBMS_OUTPUT.PUT_LINE('Fecha baja: ' || r.fecha_baja);
        DBMS_OUTPUT.PUT_LINE('Frecuencia: ' || r.frecuencia);
        DBMS_OUTPUT.PUT_LINE('Temas interés: ' || r.temas_interes);
        DBMS_OUTPUT.PUT_LINE('Confirmado: ' || r.confirmado);
        DBMS_OUTPUT.PUT_LINE('Token confirmación: ' || r.token_confirmacion);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Suscripción de newsletter no encontrada.');
    END get_suscripcion;

    PROCEDURE update_suscripcion(
        p_id_suscripcion_newsletter IN NUMBER,
        p_id_pasajero          IN NUMBER,
        p_email                IN VARCHAR2,
        p_nombre               IN VARCHAR2,
        p_fecha_suscripcion    IN DATE,
        p_fecha_baja           IN DATE,
        p_frecuencia           IN VARCHAR2,
        p_temas_interes        IN VARCHAR2,
        p_confirmado           IN NUMBER,
        p_token_confirmacion   IN VARCHAR2,
        p_activo               IN NUMBER
    ) IS
    BEGIN
        UPDATE newsletter_suscripciones
        SET id_pasajero        = p_id_pasajero,
            email              = p_email,
            nombre             = p_nombre,
            fecha_suscripcion  = p_fecha_suscripcion,
            fecha_baja         = p_fecha_baja,
            frecuencia         = p_frecuencia,
            temas_interes      = p_temas_interes,
            confirmado         = p_confirmado,
            token_confirmacion = p_token_confirmacion,
            activo             = p_activo
        WHERE id_suscripcion_newsletter = p_id_suscripcion_newsletter;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33202, 'No se encontró la suscripción de newsletter para actualizar.');
        END IF;
    END update_suscripcion;

    PROCEDURE delete_suscripcion(
        p_id_suscripcion_newsletter IN NUMBER
    ) IS
    BEGIN
        DELETE FROM newsletter_suscripciones
        WHERE id_suscripcion_newsletter = p_id_suscripcion_newsletter;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33203, 'No se encontró la suscripción de newsletter para eliminar.');
        END IF;
    END delete_suscripcion;

END pkg_newsletter_suscripciones;
/
