------------------------------------------------------------
-- Paquete CRUD para la tabla FACTURACION_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_facturacion_combustible AS
    PROCEDURE insert_factura(
        p_id_carga_combustible IN NUMBER,
        p_numero_factura       IN VARCHAR2,
        p_id_aerolinea         IN NUMBER,
        p_fecha_emision        IN DATE DEFAULT SYSDATE,
        p_cantidad_litros      IN NUMBER,
        p_precio_unitario      IN NUMBER,
        p_subtotal             IN NUMBER,
        p_impuestos            IN NUMBER,
        p_total                IN NUMBER,
        p_moneda               IN VARCHAR2,
        p_fecha_vencimiento    IN DATE,
        p_pagada               IN NUMBER DEFAULT 0,
        p_fecha_pago           IN DATE,
        p_forma_pago           IN VARCHAR2
    );

    PROCEDURE get_factura(
        p_id_factura_combustible IN NUMBER
    );

    PROCEDURE update_factura(
        p_id_factura_combustible IN NUMBER,
        p_id_carga_combustible   IN NUMBER,
        p_numero_factura         IN VARCHAR2,
        p_id_aerolinea           IN NUMBER,
        p_fecha_emision          IN DATE,
        p_cantidad_litros        IN NUMBER,
        p_precio_unitario        IN NUMBER,
        p_subtotal               IN NUMBER,
        p_impuestos              IN NUMBER,
        p_total                  IN NUMBER,
        p_moneda                 IN VARCHAR2,
        p_fecha_vencimiento      IN DATE,
        p_pagada                 IN NUMBER,
        p_fecha_pago             IN DATE,
        p_forma_pago             IN VARCHAR2
    );

    PROCEDURE delete_factura(
        p_id_factura_combustible IN NUMBER
    );
END pkg_facturacion_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_facturacion_combustible AS

    PROCEDURE insert_factura(
        p_id_carga_combustible IN NUMBER,
        p_numero_factura       IN VARCHAR2,
        p_id_aerolinea         IN NUMBER,
        p_fecha_emision        IN DATE,
        p_cantidad_litros      IN NUMBER,
        p_precio_unitario      IN NUMBER,
        p_subtotal             IN NUMBER,
        p_impuestos            IN NUMBER,
        p_total                IN NUMBER,
        p_moneda               IN VARCHAR2,
        p_fecha_vencimiento    IN DATE,
        p_pagada               IN NUMBER,
        p_fecha_pago           IN DATE,
        p_forma_pago           IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO facturacion_combustible (
            id_carga_combustible, numero_factura, id_aerolinea,
            fecha_emision, cantidad_litros, precio_unitario,
            subtotal, impuestos, total, moneda,
            fecha_vencimiento, pagada, fecha_pago, forma_pago
        ) VALUES (
            p_id_carga_combustible, p_numero_factura, p_id_aerolinea,
            NVL(p_fecha_emision, SYSDATE), p_cantidad_litros, p_precio_unitario,
            p_subtotal, p_impuestos, p_total, p_moneda,
            p_fecha_vencimiento, NVL(p_pagada,0), p_fecha_pago, p_forma_pago
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31001, 'Error al insertar factura de combustible: ' || SQLERRM);
    END insert_factura;

    PROCEDURE get_factura(
        p_id_factura_combustible IN NUMBER
    ) IS
        r facturacion_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM facturacion_combustible
        WHERE id_factura_combustible = p_id_factura_combustible;

        DBMS_OUTPUT.PUT_LINE('ID Factura: ' || r.id_factura_combustible);
        DBMS_OUTPUT.PUT_LINE('Carga combustible: ' || r.id_carga_combustible);
        DBMS_OUTPUT.PUT_LINE('Número factura: ' || r.numero_factura);
        DBMS_OUTPUT.PUT_LINE('Aerolínea: ' || r.id_aerolinea);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Cantidad litros: ' || r.cantidad_litros);
        DBMS_OUTPUT.PUT_LINE('Precio unitario: ' || r.precio_unitario);
        DBMS_OUTPUT.PUT_LINE('Subtotal: ' || r.subtotal);
        DBMS_OUTPUT.PUT_LINE('Impuestos: ' || r.impuestos);
        DBMS_OUTPUT.PUT_LINE('Total: ' || r.total);
        DBMS_OUTPUT.PUT_LINE('Moneda: ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento);
        DBMS_OUTPUT.PUT_LINE('Pagada: ' || r.pagada);
        DBMS_OUTPUT.PUT_LINE('Fecha pago: ' || r.fecha_pago);
        DBMS_OUTPUT.PUT_LINE('Forma pago: ' || r.forma_pago);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Factura de combustible no encontrada.');
    END get_factura;

    PROCEDURE update_factura(
        p_id_factura_combustible IN NUMBER,
        p_id_carga_combustible   IN NUMBER,
        p_numero_factura         IN VARCHAR2,
        p_id_aerolinea           IN NUMBER,
        p_fecha_emision          IN DATE,
        p_cantidad_litros        IN NUMBER,
        p_precio_unitario        IN NUMBER,
        p_subtotal               IN NUMBER,
        p_impuestos              IN NUMBER,
        p_total                  IN NUMBER,
        p_moneda                 IN VARCHAR2,
        p_fecha_vencimiento      IN DATE,
        p_pagada                 IN NUMBER,
        p_fecha_pago             IN DATE,
        p_forma_pago             IN VARCHAR2
    ) IS
    BEGIN
        UPDATE facturacion_combustible
        SET id_carga_combustible = p_id_carga_combustible,
            numero_factura       = p_numero_factura,
            id_aerolinea         = p_id_aerolinea,
            fecha_emision        = p_fecha_emision,
            cantidad_litros      = p_cantidad_litros,
            precio_unitario      = p_precio_unitario,
            subtotal             = p_subtotal,
            impuestos            = p_impuestos,
            total                = p_total,
            moneda               = p_moneda,
            fecha_vencimiento    = p_fecha_vencimiento,
            pagada               = p_pagada,
            fecha_pago           = p_fecha_pago,
            forma_pago           = p_forma_pago
        WHERE id_factura_combustible = p_id_factura_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31002, 'No se encontró la factura de combustible para actualizar.');
        END IF;
    END update_factura;

    PROCEDURE delete_factura(
        p_id_factura_combustible IN NUMBER
    ) IS
    BEGIN
        DELETE FROM facturacion_combustible
        WHERE id_factura_combustible = p_id_factura_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31003, 'No se encontró la factura de combustible para eliminar.');
        END IF;
    END delete_factura;

END pkg_facturacion_combustible;
/
