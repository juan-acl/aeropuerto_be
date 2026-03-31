------------------------------------------------------------
-- Paquete CRUD para la tabla TIENDAS_VENTAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tiendas_ventas AS
    PROCEDURE insert_venta(
        p_id_concesion       IN NUMBER,
        p_fecha_venta        IN TIMESTAMP,
        p_id_reserva         IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_tipo_cliente       IN VARCHAR2,
        p_subtotal           IN NUMBER,
        p_impuestos          IN NUMBER,
        p_total              IN NUMBER,
        p_metodo_pago        IN VARCHAR2,
        p_tarjeta_numero     IN VARCHAR2,
        p_autorizado_por     IN VARCHAR2
    );

    PROCEDURE get_venta(
        p_id_venta IN NUMBER
    );

    PROCEDURE update_venta(
        p_id_venta           IN NUMBER,
        p_id_concesion       IN NUMBER,
        p_fecha_venta        IN TIMESTAMP,
        p_id_reserva         IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_tipo_cliente       IN VARCHAR2,
        p_subtotal           IN NUMBER,
        p_impuestos          IN NUMBER,
        p_total              IN NUMBER,
        p_metodo_pago        IN VARCHAR2,
        p_tarjeta_numero     IN VARCHAR2,
        p_autorizado_por     IN VARCHAR2
    );

    PROCEDURE delete_venta(
        p_id_venta IN NUMBER
    );
END pkg_tiendas_ventas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tiendas_ventas AS

    PROCEDURE insert_venta(
        p_id_concesion       IN NUMBER,
        p_fecha_venta        IN TIMESTAMP,
        p_id_reserva         IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_tipo_cliente       IN VARCHAR2,
        p_subtotal           IN NUMBER,
        p_impuestos          IN NUMBER,
        p_total              IN NUMBER,
        p_metodo_pago        IN VARCHAR2,
        p_tarjeta_numero     IN VARCHAR2,
        p_autorizado_por     IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO tiendas_ventas (
            id_concesion, fecha_venta, id_reserva, id_pasajero,
            tipo_cliente, subtotal, impuestos, total,
            metodo_pago, tarjeta_numero, autorizado_por
        ) VALUES (
            p_id_concesion, p_fecha_venta, p_id_reserva, p_id_pasajero,
            p_tipo_cliente, p_subtotal, p_impuestos, p_total,
            p_metodo_pago, p_tarjeta_numero, p_autorizado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24901, 'Error al insertar venta en tienda: ' || SQLERRM);
    END insert_venta;

    PROCEDURE get_venta(
        p_id_venta IN NUMBER
    ) IS
        r tiendas_ventas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tiendas_ventas
        WHERE id_venta = p_id_venta;

        DBMS_OUTPUT.PUT_LINE('ID Venta: ' || r.id_venta);
        DBMS_OUTPUT.PUT_LINE('Concesión: ' || r.id_concesion);
        DBMS_OUTPUT.PUT_LINE('Fecha venta: ' || r.fecha_venta);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Tipo cliente: ' || r.tipo_cliente);
        DBMS_OUTPUT.PUT_LINE('Subtotal: ' || r.subtotal);
        DBMS_OUTPUT.PUT_LINE('Impuestos: ' || r.impuestos);
        DBMS_OUTPUT.PUT_LINE('Total: ' || r.total);
        DBMS_OUTPUT.PUT_LINE('Método pago: ' || r.metodo_pago);
        DBMS_OUTPUT.PUT_LINE('Tarjeta número: ' || r.tarjeta_numero);
        DBMS_OUTPUT.PUT_LINE('Autorizado por: ' || r.autorizado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Venta no encontrada.');
    END get_venta;

    PROCEDURE update_venta(
        p_id_venta           IN NUMBER,
        p_id_concesion       IN NUMBER,
        p_fecha_venta        IN TIMESTAMP,
        p_id_reserva         IN NUMBER,
        p_id_pasajero        IN NUMBER,
        p_tipo_cliente       IN VARCHAR2,
        p_subtotal           IN NUMBER,
        p_impuestos          IN NUMBER,
        p_total              IN NUMBER,
        p_metodo_pago        IN VARCHAR2,
        p_tarjeta_numero     IN VARCHAR2,
        p_autorizado_por     IN VARCHAR2
    ) IS
    BEGIN
        UPDATE tiendas_ventas
        SET id_concesion   = p_id_concesion,
            fecha_venta    = p_fecha_venta,
            id_reserva     = p_id_reserva,
            id_pasajero    = p_id_pasajero,
            tipo_cliente   = p_tipo_cliente,
            subtotal       = p_subtotal,
            impuestos      = p_impuestos,
            total          = p_total,
            metodo_pago    = p_metodo_pago,
            tarjeta_numero = p_tarjeta_numero,
            autorizado_por = p_autorizado_por
        WHERE id_venta = p_id_venta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24902, 'No se encontró la venta para actualizar.');
        END IF;
    END update_venta;

    PROCEDURE delete_venta(
        p_id_venta IN NUMBER
    ) IS
    BEGIN
        DELETE FROM tiendas_ventas
        WHERE id_venta = p_id_venta;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24903, 'No se encontró la venta para eliminar.');
        END IF;
    END delete_venta;

END pkg_tiendas_ventas;
/