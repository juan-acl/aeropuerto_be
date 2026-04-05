------------------------------------------------------------
-- Paquete CRUD para la tabla CANJES_PUNTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_canjes_puntos AS
    PROCEDURE insert_canje(
        p_id_pasajero        IN NUMBER,
        p_id_lealtad         IN NUMBER,
        p_fecha_canje        IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_puntos_utilizados  IN NUMBER,
        p_tipo_canje         IN VARCHAR2,
        p_descripcion_canje  IN VARCHAR2,
        p_id_vuelo           IN NUMBER,
        p_id_producto        IN NUMBER,
        p_valor_monetario    IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_estado_canje       IN VARCHAR2 DEFAULT 'PROCESADO',
        p_procesado_por      IN NUMBER,
        p_observaciones      IN VARCHAR2
    );

    PROCEDURE get_canje(
        p_id_canje_puntos IN NUMBER
    );

    PROCEDURE update_canje(
        p_id_canje_puntos  IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_id_lealtad       IN NUMBER,
        p_fecha_canje      IN TIMESTAMP,
        p_puntos_utilizados IN NUMBER,
        p_tipo_canje       IN VARCHAR2,
        p_descripcion_canje IN VARCHAR2,
        p_id_vuelo         IN NUMBER,
        p_id_producto      IN NUMBER,
        p_valor_monetario  IN NUMBER,
        p_moneda           IN VARCHAR2,
        p_estado_canje     IN VARCHAR2,
        p_procesado_por    IN NUMBER,
        p_observaciones    IN VARCHAR2
    );

    PROCEDURE delete_canje(
        p_id_canje_puntos IN NUMBER
    );
END pkg_canjes_puntos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_canjes_puntos AS

    PROCEDURE insert_canje(
        p_id_pasajero        IN NUMBER,
        p_id_lealtad         IN NUMBER,
        p_fecha_canje        IN TIMESTAMP,
        p_puntos_utilizados  IN NUMBER,
        p_tipo_canje         IN VARCHAR2,
        p_descripcion_canje  IN VARCHAR2,
        p_id_vuelo           IN NUMBER,
        p_id_producto        IN NUMBER,
        p_valor_monetario    IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_estado_canje       IN VARCHAR2,
        p_procesado_por      IN NUMBER,
        p_observaciones      IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO canjes_puntos (
            id_pasajero, id_lealtad, fecha_canje,
            puntos_utilizados, tipo_canje, descripcion_canje,
            id_vuelo, id_producto, valor_monetario,
            moneda, estado_canje, procesado_por, observaciones
        ) VALUES (
            p_id_pasajero, p_id_lealtad, NVL(p_fecha_canje, SYSTIMESTAMP),
            p_puntos_utilizados, p_tipo_canje, p_descripcion_canje,
            p_id_vuelo, p_id_producto, p_valor_monetario,
            p_moneda, NVL(p_estado_canje,'PROCESADO'), p_procesado_por, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33101, 'Error al insertar canje de puntos: ' || SQLERRM);
    END insert_canje;

    PROCEDURE get_canje(
        p_id_canje_puntos IN NUMBER
    ) IS
        r canjes_puntos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM canjes_puntos
        WHERE id_canje_puntos = p_id_canje_puntos;

        DBMS_OUTPUT.PUT_LINE('ID Canje: ' || r.id_canje_puntos);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Lealtad: ' || r.id_lealtad);
        DBMS_OUTPUT.PUT_LINE('Fecha canje: ' || r.fecha_canje);
        DBMS_OUTPUT.PUT_LINE('Puntos utilizados: ' || r.puntos_utilizados);
        DBMS_OUTPUT.PUT_LINE('Tipo canje: ' || r.tipo_canje);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion_canje);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Producto: ' || r.id_producto);
        DBMS_OUTPUT.PUT_LINE('Valor monetario: ' || r.valor_monetario || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado_canje);
        DBMS_OUTPUT.PUT_LINE('Procesado por: ' || r.procesado_por);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Canje de puntos no encontrado.');
    END get_canje;

    PROCEDURE update_canje(
        p_id_canje_puntos  IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_id_lealtad       IN NUMBER,
        p_fecha_canje      IN TIMESTAMP,
        p_puntos_utilizados IN NUMBER,
        p_tipo_canje       IN VARCHAR2,
        p_descripcion_canje IN VARCHAR2,
        p_id_vuelo         IN NUMBER,
        p_id_producto      IN NUMBER,
        p_valor_monetario  IN NUMBER,
        p_moneda           IN VARCHAR2,
        p_estado_canje     IN VARCHAR2,
        p_procesado_por    IN NUMBER,
        p_observaciones    IN VARCHAR2
    ) IS
    BEGIN
        UPDATE canjes_puntos
        SET id_pasajero        = p_id_pasajero,
            id_lealtad         = p_id_lealtad,
            fecha_canje        = p_fecha_canje,
            puntos_utilizados  = p_puntos_utilizados,
            tipo_canje         = p_tipo_canje,
            descripcion_canje  = p_descripcion_canje,
            id_vuelo           = p_id_vuelo,
            id_producto        = p_id_producto,
            valor_monetario    = p_valor_monetario,
            moneda             = p_moneda,
            estado_canje       = p_estado_canje,
            procesado_por      = p_procesado_por,
            observaciones      = p_observaciones
        WHERE id_canje_puntos = p_id_canje_puntos;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33102, 'No se encontró el canje de puntos para actualizar.');
        END IF;
    END update_canje;

    PROCEDURE delete_canje(
        p_id_canje_puntos IN NUMBER
    ) IS
    BEGIN
        DELETE FROM canjes_puntos
        WHERE id_canje_puntos = p_id_canje_puntos;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33103, 'No se encontró el canje de puntos para eliminar.');
        END IF;
    END delete_canje;

END pkg_canjes_puntos;
/
