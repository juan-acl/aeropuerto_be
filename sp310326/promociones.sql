------------------------------------------------------------
-- Paquete CRUD para la tabla PROMOCIONES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_promociones AS
    PROCEDURE insert_promocion(
        p_codigo_promocion   IN promociones.codigo_promocion%TYPE,
        p_nombre_promocion   IN promociones.nombre_promocion%TYPE,
        p_descripcion        IN promociones.descripcion%TYPE,
        p_tipo_descuento     IN promociones.tipo_descuento%TYPE,
        p_valor_descuento    IN promociones.valor_descuento%TYPE,
        p_fecha_inicio       IN promociones.fecha_inicio%TYPE,
        p_fecha_fin          IN promociones.fecha_fin%TYPE,
        p_uso_maximo         IN promociones.uso_maximo%TYPE,
        p_usos_actuales      IN promociones.usos_actuales%TYPE DEFAULT 0,
        p_activa             IN promociones.activa%TYPE DEFAULT 1
    );

    PROCEDURE get_promocion(
        p_id_promocion IN promociones.id_promocion%TYPE
    );

    PROCEDURE update_promocion(
        p_id_promocion       IN promociones.id_promocion%TYPE,
        p_codigo_promocion   IN promociones.codigo_promocion%TYPE,
        p_nombre_promocion   IN promociones.nombre_promocion%TYPE,
        p_descripcion        IN promociones.descripcion%TYPE,
        p_tipo_descuento     IN promociones.tipo_descuento%TYPE,
        p_valor_descuento    IN promociones.valor_descuento%TYPE,
        p_fecha_inicio       IN promociones.fecha_inicio%TYPE,
        p_fecha_fin          IN promociones.fecha_fin%TYPE,
        p_uso_maximo         IN promociones.uso_maximo%TYPE,
        p_usos_actuales      IN promociones.usos_actuales%TYPE,
        p_activa             IN promociones.activa%TYPE
    );

    PROCEDURE delete_promocion(
        p_id_promocion IN promociones.id_promocion%TYPE
    );
END pkg_promociones;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_promociones AS

    PROCEDURE insert_promocion(
        p_codigo_promocion   IN promociones.codigo_promocion%TYPE,
        p_nombre_promocion   IN promociones.nombre_promocion%TYPE,
        p_descripcion        IN promociones.descripcion%TYPE,
        p_tipo_descuento     IN promociones.tipo_descuento%TYPE,
        p_valor_descuento    IN promociones.valor_descuento%TYPE,
        p_fecha_inicio       IN promociones.fecha_inicio%TYPE,
        p_fecha_fin          IN promociones.fecha_fin%TYPE,
        p_uso_maximo         IN promociones.uso_maximo%TYPE,
        p_usos_actuales      IN promociones.usos_actuales%TYPE,
        p_activa             IN promociones.activa%TYPE
    ) IS
    BEGIN
        INSERT INTO promociones (
            codigo_promocion, nombre_promocion, descripcion,
            tipo_descuento, valor_descuento, fecha_inicio,
            fecha_fin, uso_maximo, usos_actuales, activa
        ) VALUES (
            p_codigo_promocion, p_nombre_promocion, p_descripcion,
            p_tipo_descuento, p_valor_descuento, p_fecha_inicio,
            p_fecha_fin, p_uso_maximo, NVL(p_usos_actuales,0), NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22501, 'Error al insertar promoción: ' || SQLERRM);
    END insert_promocion;

    PROCEDURE get_promocion(
        p_id_promocion IN promociones.id_promocion%TYPE
    ) IS
        r promociones%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM promociones
        WHERE id_promocion = p_id_promocion;

        DBMS_OUTPUT.PUT_LINE('ID Promoción: ' || r.id_promocion);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_promocion);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_promocion);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Tipo descuento: ' || r.tipo_descuento);
        DBMS_OUTPUT.PUT_LINE('Valor descuento: ' || r.valor_descuento);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Uso máximo: ' || r.uso_maximo);
        DBMS_OUTPUT.PUT_LINE('Usos actuales: ' || r.usos_actuales);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Promoción no encontrada.');
    END get_promocion;

    PROCEDURE update_promocion(
        p_id_promocion       IN promociones.id_promocion%TYPE,
        p_codigo_promocion   IN promociones.codigo_promocion%TYPE,
        p_nombre_promocion   IN promociones.nombre_promocion%TYPE,
        p_descripcion        IN promociones.descripcion%TYPE,
        p_tipo_descuento     IN promociones.tipo_descuento%TYPE,
        p_valor_descuento    IN promociones.valor_descuento%TYPE,
        p_fecha_inicio       IN promociones.fecha_inicio%TYPE,
        p_fecha_fin          IN promociones.fecha_fin%TYPE,
        p_uso_maximo         IN promociones.uso_maximo%TYPE,
        p_usos_actuales      IN promociones.usos_actuales%TYPE,
        p_activa             IN promociones.activa%TYPE
    ) IS
    BEGIN
        UPDATE promociones
        SET codigo_promocion   = p_codigo_promocion,
            nombre_promocion   = p_nombre_promocion,
            descripcion        = p_descripcion,
            tipo_descuento     = p_tipo_descuento,
            valor_descuento    = p_valor_descuento,
            fecha_inicio       = p_fecha_inicio,
            fecha_fin          = p_fecha_fin,
            uso_maximo         = p_uso_maximo,
            usos_actuales      = p_usos_actuales,
            activa             = p_activa
        WHERE id_promocion = p_id_promocion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22502, 'No se encontró la promoción para actualizar.');
        END IF;
    END update_promocion;

    PROCEDURE delete_promocion(
        p_id_promocion IN promociones.id_promocion%TYPE
    ) IS
    BEGIN
        DELETE FROM promociones
        WHERE id_promocion = p_id_promocion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22503, 'No se encontró la promoción para eliminar.');
        END IF;
    END delete_promocion;

END pkg_promociones;
/