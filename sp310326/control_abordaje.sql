------------------------------------------------------------
-- Paquete CRUD para la tabla CONTROL_ABORDAJE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_control_abordaje AS
    PROCEDURE insert_control(
        p_id_vuelo       IN NUMBER,
        p_id_reserva     IN NUMBER,
        p_hora_abordaje  IN TIMESTAMP,
        p_verificado_por IN NUMBER,
        p_estado         IN VARCHAR2,
        p_observaciones  IN VARCHAR2
    );

    PROCEDURE get_control(
        p_id_control_abordaje IN NUMBER
    );

    PROCEDURE update_control(
        p_id_control_abordaje IN NUMBER,
        p_id_vuelo       IN NUMBER,
        p_id_reserva     IN NUMBER,
        p_hora_abordaje  IN TIMESTAMP,
        p_verificado_por IN NUMBER,
        p_estado         IN VARCHAR2,
        p_observaciones  IN VARCHAR2
    );

    PROCEDURE delete_control(
        p_id_control_abordaje IN NUMBER
    );
END pkg_control_abordaje;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_control_abordaje AS

    PROCEDURE insert_control(
        p_id_vuelo       IN NUMBER,
        p_id_reserva     IN NUMBER,
        p_hora_abordaje  IN TIMESTAMP,
        p_verificado_por IN NUMBER,
        p_estado         IN VARCHAR2,
        p_observaciones  IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO control_abordaje (
            id_vuelo, id_reserva, hora_abordaje,
            verificado_por, estado, observaciones
        ) VALUES (
            p_id_vuelo, p_id_reserva, p_hora_abordaje,
            p_verificado_por, p_estado, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23301, 'Error al insertar control de abordaje: ' || SQLERRM);
    END insert_control;

    PROCEDURE get_control(
        p_id_control_abordaje IN NUMBER
    ) IS
        r control_abordaje%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM control_abordaje
        WHERE id_control_abordaje = p_id_control_abordaje;

        DBMS_OUTPUT.PUT_LINE('ID Control: ' || r.id_control_abordaje);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Hora abordaje: ' || r.hora_abordaje);
        DBMS_OUTPUT.PUT_LINE('Verificado por: ' || r.verificado_por);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Control de abordaje no encontrado.');
    END get_control;

    PROCEDURE update_control(
        p_id_control_abordaje IN NUMBER,
        p_id_vuelo       IN NUMBER,
        p_id_reserva     IN NUMBER,
        p_hora_abordaje  IN TIMESTAMP,
        p_verificado_por IN NUMBER,
        p_estado         IN VARCHAR2,
        p_observaciones  IN VARCHAR2
    ) IS
    BEGIN
        UPDATE control_abordaje
        SET id_vuelo       = p_id_vuelo,
            id_reserva     = p_id_reserva,
            hora_abordaje  = p_hora_abordaje,
            verificado_por = p_verificado_por,
            estado         = p_estado,
            observaciones  = p_observaciones
        WHERE id_control_abordaje = p_id_control_abordaje;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23302, 'No se encontró el control de abordaje para actualizar.');
        END IF;
    END update_control;

    PROCEDURE delete_control(
        p_id_control_abordaje IN NUMBER
    ) IS
    BEGIN
        DELETE FROM control_abordaje
        WHERE id_control_abordaje = p_id_control_abordaje;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23303, 'No se encontró el control de abordaje para eliminar.');
        END IF;
    END delete_control;

END pkg_control_abordaje;
/