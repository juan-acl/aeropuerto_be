------------------------------------------------------------
-- Paquete CRUD para la tabla PIEZAS_REEMPLAZO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_piezas_reemplazo AS
    PROCEDURE insert_pieza(
        p_codigo_pieza             IN VARCHAR2,
        p_nombre_pieza             IN VARCHAR2,
        p_descripcion              IN VARCHAR2,
        p_id_modelo_avion          IN NUMBER,
        p_id_fabricante            IN NUMBER,
        p_numero_parte_fabricante  IN VARCHAR2,
        p_stock_actual             IN NUMBER DEFAULT 0,
        p_stock_minimo             IN NUMBER DEFAULT 5,
        p_stock_maximo             IN NUMBER DEFAULT 50,
        p_ubicacion_almacen        IN VARCHAR2,
        p_precio_unitario          IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_tiempo_reorden_dias      IN NUMBER,
        p_activo                   IN NUMBER DEFAULT 1
    );

    PROCEDURE get_pieza(
        p_id_pieza IN NUMBER
    );

    PROCEDURE update_pieza(
        p_id_pieza                 IN NUMBER,
        p_codigo_pieza             IN VARCHAR2,
        p_nombre_pieza             IN VARCHAR2,
        p_descripcion              IN VARCHAR2,
        p_id_modelo_avion          IN NUMBER,
        p_id_fabricante            IN NUMBER,
        p_numero_parte_fabricante  IN VARCHAR2,
        p_stock_actual             IN NUMBER,
        p_stock_minimo             IN NUMBER,
        p_stock_maximo             IN NUMBER,
        p_ubicacion_almacen        IN VARCHAR2,
        p_precio_unitario          IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_tiempo_reorden_dias      IN NUMBER,
        p_activo                   IN NUMBER
    );

    PROCEDURE delete_pieza(
        p_id_pieza IN NUMBER
    );
END pkg_piezas_reemplazo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_piezas_reemplazo AS

    PROCEDURE insert_pieza(
        p_codigo_pieza             IN VARCHAR2,
        p_nombre_pieza             IN VARCHAR2,
        p_descripcion              IN VARCHAR2,
        p_id_modelo_avion          IN NUMBER,
        p_id_fabricante            IN NUMBER,
        p_numero_parte_fabricante  IN VARCHAR2,
        p_stock_actual             IN NUMBER,
        p_stock_minimo             IN NUMBER,
        p_stock_maximo             IN NUMBER,
        p_ubicacion_almacen        IN VARCHAR2,
        p_precio_unitario          IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_tiempo_reorden_dias      IN NUMBER,
        p_activo                   IN NUMBER
    ) IS
    BEGIN
        INSERT INTO piezas_reemplazo (
            codigo_pieza, nombre_pieza, descripcion,
            id_modelo_avion, id_fabricante, numero_parte_fabricante,
            stock_actual, stock_minimo, stock_maximo,
            ubicacion_almacen, precio_unitario, moneda,
            tiempo_reorden_dias, activo
        ) VALUES (
            p_codigo_pieza, p_nombre_pieza, p_descripcion,
            p_id_modelo_avion, p_id_fabricante, p_numero_parte_fabricante,
            NVL(p_stock_actual,0), NVL(p_stock_minimo,5), NVL(p_stock_maximo,50),
            p_ubicacion_almacen, p_precio_unitario, p_moneda,
            p_tiempo_reorden_dias, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29401, 'Error al insertar pieza de reemplazo: ' || SQLERRM);
    END insert_pieza;

    PROCEDURE get_pieza(
        p_id_pieza IN NUMBER
    ) IS
        r piezas_reemplazo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM piezas_reemplazo
        WHERE id_pieza = p_id_pieza;

        DBMS_OUTPUT.PUT_LINE('ID Pieza: ' || r.id_pieza);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_pieza);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_pieza);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Modelo avión: ' || r.id_modelo_avion);
        DBMS_OUTPUT.PUT_LINE('Fabricante: ' || r.id_fabricante);
        DBMS_OUTPUT.PUT_LINE('Número parte fabricante: ' || r.numero_parte_fabricante);
        DBMS_OUTPUT.PUT_LINE('Stock actual: ' || r.stock_actual);
        DBMS_OUTPUT.PUT_LINE('Stock mínimo: ' || r.stock_minimo);
        DBMS_OUTPUT.PUT_LINE('Stock máximo: ' || r.stock_maximo);
        DBMS_OUTPUT.PUT_LINE('Ubicación almacén: ' || r.ubicacion_almacen);
        DBMS_OUTPUT.PUT_LINE('Precio unitario: ' || r.precio_unitario || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Tiempo reorden (días): ' || r.tiempo_reorden_dias);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Pieza de reemplazo no encontrada.');
    END get_pieza;

    PROCEDURE update_pieza(
        p_id_pieza                 IN NUMBER,
        p_codigo_pieza             IN VARCHAR2,
        p_nombre_pieza             IN VARCHAR2,
        p_descripcion              IN VARCHAR2,
        p_id_modelo_avion          IN NUMBER,
        p_id_fabricante            IN NUMBER,
        p_numero_parte_fabricante  IN VARCHAR2,
        p_stock_actual             IN NUMBER,
        p_stock_minimo             IN NUMBER,
        p_stock_maximo             IN NUMBER,
        p_ubicacion_almacen        IN VARCHAR2,
        p_precio_unitario          IN NUMBER,
        p_moneda                   IN VARCHAR2,
        p_tiempo_reorden_dias      IN NUMBER,
        p_activo                   IN NUMBER
    ) IS
    BEGIN
        UPDATE piezas_reemplazo
        SET codigo_pieza            = p_codigo_pieza,
            nombre_pieza            = p_nombre_pieza,
            descripcion             = p_descripcion,
            id_modelo_avion         = p_id_modelo_avion,
            id_fabricante           = p_id_fabricante,
            numero_parte_fabricante = p_numero_parte_fabricante,
            stock_actual            = p_stock_actual,
            stock_minimo            = p_stock_minimo,
            stock_maximo            = p_stock_maximo,
            ubicacion_almacen       = p_ubicacion_almacen,
            precio_unitario         = p_precio_unitario,
            moneda                  = p_moneda,
            tiempo_reorden_dias     = p_tiempo_reorden_dias,
            activo                  = p_activo
        WHERE id_pieza = p_id_pieza;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29402, 'No se encontró la pieza de reemplazo para actualizar.');
        END IF;
    END update_pieza;

    PROCEDURE delete_pieza(
        p_id_pieza IN NUMBER
    ) IS
    BEGIN
        DELETE FROM piezas_reemplazo
        WHERE id_pieza = p_id_pieza;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29403, 'No se encontró la pieza de reemplazo para eliminar.');
        END IF;
    END delete_pieza;

END pkg_piezas_reemplazo;
/
