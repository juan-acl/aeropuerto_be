------------------------------------------------------------
-- Paquete CRUD para la tabla PASAJEROS_SEGMENTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pasajeros_segmentos AS
    PROCEDURE insert_pasajero_segmento(
        p_id_pasajero         IN NUMBER,
        p_id_segmento_cliente IN NUMBER,
        p_fecha_asignacion    IN DATE DEFAULT SYSDATE,
        p_automatico          IN NUMBER DEFAULT 0,
        p_activo              IN NUMBER DEFAULT 1
    );

    PROCEDURE get_pasajero_segmento(
        p_id_pasajero         IN NUMBER,
        p_id_segmento_cliente IN NUMBER
    );

    PROCEDURE update_pasajero_segmento(
        p_id_pasajero         IN NUMBER,
        p_id_segmento_cliente IN NUMBER,
        p_fecha_asignacion    IN DATE,
        p_automatico          IN NUMBER,
        p_activo              IN NUMBER
    );

    PROCEDURE delete_pasajero_segmento(
        p_id_pasajero         IN NUMBER,
        p_id_segmento_cliente IN NUMBER
    );
END pkg_pasajeros_segmentos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pasajeros_segmentos AS

    PROCEDURE insert_pasajero_segmento(
        p_id_pasajero         IN NUMBER,
        p_id_segmento_cliente IN NUMBER,
        p_fecha_asignacion    IN DATE,
        p_automatico          IN NUMBER,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO pasajeros_segmentos (
            id_pasajero, id_segmento_cliente, fecha_asignacion,
            automatico, activo
        ) VALUES (
            p_id_pasajero, p_id_segmento_cliente, NVL(p_fecha_asignacion, SYSDATE),
            NVL(p_automatico,0), NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32901, 'Error al insertar asignación de segmento: ' || SQLERRM);
    END insert_pasajero_segmento;

    PROCEDURE get_pasajero_segmento(
        p_id_pasajero         IN NUMBER,
        p_id_segmento_cliente IN NUMBER
    ) IS
        r pasajeros_segmentos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM pasajeros_segmentos
        WHERE id_pasajero = p_id_pasajero
          AND id_segmento_cliente = p_id_segmento_cliente;

        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Segmento: ' || r.id_segmento_cliente);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Automático: ' || r.automatico);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Asignación de segmento no encontrada.');
    END get_pasajero_segmento;

    PROCEDURE update_pasajero_segmento(
        p_id_pasajero         IN NUMBER,
        p_id_segmento_cliente IN NUMBER,
        p_fecha_asignacion    IN DATE,
        p_automatico          IN NUMBER,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        UPDATE pasajeros_segmentos
        SET fecha_asignacion = p_fecha_asignacion,
            automatico       = p_automatico,
            activo           = p_activo
        WHERE id_pasajero = p_id_pasajero
          AND id_segmento_cliente = p_id_segmento_cliente;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32902, 'No se encontró la asignación de segmento para actualizar.');
        END IF;
    END update_pasajero_segmento;

    PROCEDURE delete_pasajero_segmento(
        p_id_pasajero         IN NUMBER,
        p_id_segmento_cliente IN NUMBER
    ) IS
    BEGIN
        DELETE FROM pasajeros_segmentos
        WHERE id_pasajero = p_id_pasajero
          AND id_segmento_cliente = p_id_segmento_cliente;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32903, 'No se encontró la asignación de segmento para eliminar.');
        END IF;
    END delete_pasajero_segmento;

END pkg_pasajeros_segmentos;
/
