------------------------------------------------------------
-- Paquete CRUD para la tabla PEDIDOS_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pedidos_combustible AS
    PROCEDURE insert_pedido(
        p_numero_pedido            IN VARCHAR2,
        p_id_vuelo                 IN NUMBER,
        p_cantidad_solicitada_litros IN NUMBER,
        p_tipo_combustible         IN VARCHAR2,
        p_fecha_pedido             IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_fecha_requerida          IN TIMESTAMP,
        p_estado_pedido            IN VARCHAR2 DEFAULT 'SOLICITADO',
        p_prioridad                IN VARCHAR2,
        p_solicitado_por           IN NUMBER,
        p_aprobado_por             IN NUMBER,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE get_pedido(
        p_id_pedido_combustible IN NUMBER
    );

    PROCEDURE update_pedido(
        p_id_pedido_combustible   IN NUMBER,
        p_numero_pedido           IN VARCHAR2,
        p_id_vuelo                IN NUMBER,
        p_cantidad_solicitada_litros IN NUMBER,
        p_tipo_combustible        IN VARCHAR2,
        p_fecha_pedido            IN TIMESTAMP,
        p_fecha_requerida         IN TIMESTAMP,
        p_estado_pedido           IN VARCHAR2,
        p_prioridad               IN VARCHAR2,
        p_solicitado_por          IN NUMBER,
        p_aprobado_por            IN NUMBER,
        p_observaciones           IN VARCHAR2
    );

    PROCEDURE delete_pedido(
        p_id_pedido_combustible IN NUMBER
    );
END pkg_pedidos_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pedidos_combustible AS

    PROCEDURE insert_pedido(
        p_numero_pedido            IN VARCHAR2,
        p_id_vuelo                 IN NUMBER,
        p_cantidad_solicitada_litros IN NUMBER,
        p_tipo_combustible         IN VARCHAR2,
        p_fecha_pedido             IN TIMESTAMP,
        p_fecha_requerida          IN TIMESTAMP,
        p_estado_pedido            IN VARCHAR2,
        p_prioridad                IN VARCHAR2,
        p_solicitado_por           IN NUMBER,
        p_aprobado_por             IN NUMBER,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO pedidos_combustible (
            numero_pedido, id_vuelo, cantidad_solicitada_litros,
            tipo_combustible, fecha_pedido, fecha_requerida,
            estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones
        ) VALUES (
            p_numero_pedido, p_id_vuelo, p_cantidad_solicitada_litros,
            p_tipo_combustible, NVL(p_fecha_pedido, SYSTIMESTAMP), p_fecha_requerida,
            NVL(p_estado_pedido,'SOLICITADO'), p_prioridad, p_solicitado_por, p_aprobado_por, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30501, 'Error al insertar pedido de combustible: ' || SQLERRM);
    END insert_pedido;

    PROCEDURE get_pedido(
        p_id_pedido_combustible IN NUMBER
    ) IS
        r pedidos_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM pedidos_combustible
        WHERE id_pedido_combustible = p_id_pedido_combustible;

        DBMS_OUTPUT.PUT_LINE('ID Pedido: ' || r.id_pedido_combustible);
        DBMS_OUTPUT.PUT_LINE('Número pedido: ' || r.numero_pedido);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Cantidad solicitada (litros): ' || r.cantidad_solicitada_litros);
        DBMS_OUTPUT.PUT_LINE('Tipo combustible: ' || r.tipo_combustible);
        DBMS_OUTPUT.PUT_LINE('Fecha pedido: ' || r.fecha_pedido);
        DBMS_OUTPUT.PUT_LINE('Fecha requerida: ' || r.fecha_requerida);
        DBMS_OUTPUT.PUT_LINE('Estado pedido: ' || r.estado_pedido);
        DBMS_OUTPUT.PUT_LINE('Prioridad: ' || r.prioridad);
        DBMS_OUTPUT.PUT_LINE('Solicitado por: ' || r.solicitado_por);
        DBMS_OUTPUT.PUT_LINE('Aprobado por: ' || r.aprobado_por);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Pedido de combustible no encontrado.');
    END get_pedido;

    PROCEDURE update_pedido(
        p_id_pedido_combustible   IN NUMBER,
        p_numero_pedido           IN VARCHAR2,
        p_id_vuelo                IN NUMBER,
        p_cantidad_solicitada_litros IN NUMBER,
        p_tipo_combustible        IN VARCHAR2,
        p_fecha_pedido            IN TIMESTAMP,
        p_fecha_requerida         IN TIMESTAMP,
        p_estado_pedido           IN VARCHAR2,
        p_prioridad               IN VARCHAR2,
        p_solicitado_por          IN NUMBER,
        p_aprobado_por            IN NUMBER,
        p_observaciones           IN VARCHAR2
    ) IS
    BEGIN
        UPDATE pedidos_combustible
        SET numero_pedido            = p_numero_pedido,
            id_vuelo                 = p_id_vuelo,
            cantidad_solicitada_litros = p_cantidad_solicitada_litros,
            tipo_combustible         = p_tipo_combustible,
            fecha_pedido             = p_fecha_pedido,
            fecha_requerida          = p_fecha_requerida,
            estado_pedido            = p_estado_pedido,
            prioridad                = p_prioridad,
            solicitado_por           = p_solicitado_por,
            aprobado_por             = p_aprobado_por,
            observaciones            = p_observaciones
        WHERE id_pedido_combustible = p_id_pedido_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30502, 'No se encontró el pedido de combustible para actualizar.');
        END IF;
    END update_pedido;

    PROCEDURE delete_pedido(
        p_id_pedido_combustible IN NUMBER
    ) IS
    BEGIN
        DELETE FROM pedidos_combustible
        WHERE id_pedido_combustible = p_id_pedido_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30503, 'No se encontró el pedido de combustible para eliminar.');
        END IF;
    END delete_pedido;

END pkg_pedidos_combustible;
/
