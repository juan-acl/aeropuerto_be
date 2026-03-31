------------------------------------------------------------
-- Paquete CRUD para la tabla OBJETOS_ENTREGADOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_objetos_entregados AS
    PROCEDURE insert_entrega(
        p_id_objeto              IN NUMBER,
        p_id_pasajero            IN NUMBER,
        p_fecha_entrega          IN TIMESTAMP,
        p_documento_identificacion IN VARCHAR2,
        p_firma_digital          IN BLOB,
        p_entregado_por          IN VARCHAR2,
        p_observaciones          IN VARCHAR2
    );

    PROCEDURE get_entrega(
        p_id_entrega IN NUMBER
    );

    PROCEDURE update_entrega(
        p_id_entrega             IN NUMBER,
        p_id_objeto              IN NUMBER,
        p_id_pasajero            IN NUMBER,
        p_fecha_entrega          IN TIMESTAMP,
        p_documento_identificacion IN VARCHAR2,
        p_firma_digital          IN BLOB,
        p_entregado_por          IN VARCHAR2,
        p_observaciones          IN VARCHAR2
    );

    PROCEDURE delete_entrega(
        p_id_entrega IN NUMBER
    );
END pkg_objetos_entregados;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_objetos_entregados AS

    PROCEDURE insert_entrega(
        p_id_objeto              IN NUMBER,
        p_id_pasajero            IN NUMBER,
        p_fecha_entrega          IN TIMESTAMP,
        p_documento_identificacion IN VARCHAR2,
        p_firma_digital          IN BLOB,
        p_entregado_por          IN VARCHAR2,
        p_observaciones          IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO objetos_entregados (
            id_objeto, id_pasajero, fecha_entrega,
            documento_identificacion, firma_digital,
            entregado_por, observaciones
        ) VALUES (
            p_id_objeto, p_id_pasajero, p_fecha_entrega,
            p_documento_identificacion, p_firma_digital,
            p_entregado_por, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24501, 'Error al insertar entrega de objeto: ' || SQLERRM);
    END insert_entrega;

    PROCEDURE get_entrega(
        p_id_entrega IN NUMBER
    ) IS
        r objetos_entregados%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM objetos_entregados
        WHERE id_entrega = p_id_entrega;

        DBMS_OUTPUT.PUT_LINE('ID Entrega: ' || r.id_entrega);
        DBMS_OUTPUT.PUT_LINE('Objeto: ' || r.id_objeto);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Fecha entrega: ' || r.fecha_entrega);
        DBMS_OUTPUT.PUT_LINE('Documento identificación: ' || r.documento_identificacion);
        DBMS_OUTPUT.PUT_LINE('Firma digital: ' || CASE WHEN r.firma_digital IS NOT NULL THEN 'Sí' ELSE 'No' END);
        DBMS_OUTPUT.PUT_LINE('Entregado por: ' || r.entregado_por);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Entrega de objeto no encontrada.');
    END get_entrega;

    PROCEDURE update_entrega(
        p_id_entrega             IN NUMBER,
        p_id_objeto              IN NUMBER,
        p_id_pasajero            IN NUMBER,
        p_fecha_entrega          IN TIMESTAMP,
        p_documento_identificacion IN VARCHAR2,
        p_firma_digital          IN BLOB,
        p_entregado_por          IN VARCHAR2,
        p_observaciones          IN VARCHAR2
    ) IS
    BEGIN
        UPDATE objetos_entregados
        SET id_objeto              = p_id_objeto,
            id_pasajero            = p_id_pasajero,
            fecha_entrega          = p_fecha_entrega,
            documento_identificacion = p_documento_identificacion,
            firma_digital          = p_firma_digital,
            entregado_por          = p_entregado_por,
            observaciones          = p_observaciones
        WHERE id_entrega = p_id_entrega;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24502, 'No se encontró la entrega de objeto para actualizar.');
        END IF;
    END update_entrega;

    PROCEDURE delete_entrega(
        p_id_entrega IN NUMBER
    ) IS
    BEGIN
        DELETE FROM objetos_entregados
        WHERE id_entrega = p_id_entrega;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24503, 'No se encontró la entrega de objeto para eliminar.');
        END IF;
    END delete_entrega;

END pkg_objetos_entregados;
/