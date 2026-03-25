------------------------------------------------------------
-- Paquete CRUD para la tabla COMBUSTIBLE_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_combustible_vuelo AS
    PROCEDURE insert_combustible(
        p_id_vuelo                   IN combustible_vuelo.id_vuelo%TYPE,
        p_combustible_planeado_litros IN combustible_vuelo.combustible_planeado_litros%TYPE,
        p_combustible_real_litros     IN combustible_vuelo.combustible_real_litros%TYPE,
        p_combustible_extra_litros    IN combustible_vuelo.combustible_extra_litros%TYPE,
        p_tipo_combustible            IN combustible_vuelo.tipo_combustible%TYPE,
        p_proveedor                   IN combustible_vuelo.proveedor%TYPE,
        p_costo_total                 IN combustible_vuelo.costo_total%TYPE,
        p_fecha_carga                 IN combustible_vuelo.fecha_carga%TYPE
    );

    PROCEDURE get_combustible(
        p_id_combustible IN combustible_vuelo.id_combustible%TYPE
    );

    PROCEDURE update_combustible(
        p_id_combustible             IN combustible_vuelo.id_combustible%TYPE,
        p_id_vuelo                   IN combustible_vuelo.id_vuelo%TYPE,
        p_combustible_planeado_litros IN combustible_vuelo.combustible_planeado_litros%TYPE,
        p_combustible_real_litros     IN combustible_vuelo.combustible_real_litros%TYPE,
        p_combustible_extra_litros    IN combustible_vuelo.combustible_extra_litros%TYPE,
        p_tipo_combustible            IN combustible_vuelo.tipo_combustible%TYPE,
        p_proveedor                   IN combustible_vuelo.proveedor%TYPE,
        p_costo_total                 IN combustible_vuelo.costo_total%TYPE,
        p_fecha_carga                 IN combustible_vuelo.fecha_carga%TYPE
    );

    PROCEDURE delete_combustible(
        p_id_combustible IN combustible_vuelo.id_combustible%TYPE
    );
END pkg_combustible_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_combustible_vuelo AS

    PROCEDURE insert_combustible(
        p_id_vuelo                   IN combustible_vuelo.id_vuelo%TYPE,
        p_combustible_planeado_litros IN combustible_vuelo.combustible_planeado_litros%TYPE,
        p_combustible_real_litros     IN combustible_vuelo.combustible_real_litros%TYPE,
        p_combustible_extra_litros    IN combustible_vuelo.combustible_extra_litros%TYPE,
        p_tipo_combustible            IN combustible_vuelo.tipo_combustible%TYPE,
        p_proveedor                   IN combustible_vuelo.proveedor%TYPE,
        p_costo_total                 IN combustible_vuelo.costo_total%TYPE,
        p_fecha_carga                 IN combustible_vuelo.fecha_carga%TYPE
    ) IS
    BEGIN
        INSERT INTO combustible_vuelo (
            id_vuelo, combustible_planeado_litros, combustible_real_litros,
            combustible_extra_litros, tipo_combustible, proveedor,
            costo_total, fecha_carga
        ) VALUES (
            p_id_vuelo, p_combustible_planeado_litros, p_combustible_real_litros,
            p_combustible_extra_litros, p_tipo_combustible, p_proveedor,
            p_costo_total, p_fecha_carga
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21101, 'Error al insertar registro de combustible: ' || SQLERRM);
    END insert_combustible;

    PROCEDURE get_combustible(
        p_id_combustible IN combustible_vuelo.id_combustible%TYPE
    ) IS
        r combustible_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM combustible_vuelo
        WHERE id_combustible = p_id_combustible;

        DBMS_OUTPUT.PUT_LINE('ID Combustible: ' || r.id_combustible);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Planeado (L): ' || r.combustible_planeado_litros);
        DBMS_OUTPUT.PUT_LINE('Real (L): ' || r.combustible_real_litros);
        DBMS_OUTPUT.PUT_LINE('Extra (L): ' || r.combustible_extra_litros);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_combustible);
        DBMS_OUTPUT.PUT_LINE('Proveedor: ' || r.proveedor);
        DBMS_OUTPUT.PUT_LINE('Costo total: ' || r.costo_total);
        DBMS_OUTPUT.PUT_LINE('Fecha carga: ' || r.fecha_carga);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Registro de combustible no encontrado.');
    END get_combustible;

    PROCEDURE update_combustible(
        p_id_combustible             IN combustible_vuelo.id_combustible%TYPE,
        p_id_vuelo                   IN combustible_vuelo.id_vuelo%TYPE,
        p_combustible_planeado_litros IN combustible_vuelo.combustible_planeado_litros%TYPE,
        p_combustible_real_litros     IN combustible_vuelo.combustible_real_litros%TYPE,
        p_combustible_extra_litros    IN combustible_vuelo.combustible_extra_litros%TYPE,
        p_tipo_combustible            IN combustible_vuelo.tipo_combustible%TYPE,
        p_proveedor                   IN combustible_vuelo.proveedor%TYPE,
        p_costo_total                 IN combustible_vuelo.costo_total%TYPE,
        p_fecha_carga                 IN combustible_vuelo.fecha_carga%TYPE
    ) IS
    BEGIN
        UPDATE combustible_vuelo
        SET id_vuelo                   = p_id_vuelo,
            combustible_planeado_litros = p_combustible_planeado_litros,
            combustible_real_litros     = p_combustible_real_litros,
            combustible_extra_litros    = p_combustible_extra_litros,
            tipo_combustible            = p_tipo_combustible,
            proveedor                   = p_proveedor,
            costo_total                 = p_costo_total,
            fecha_carga                 = p_fecha_carga
        WHERE id_combustible = p_id_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21102, 'No se encontró el registro de combustible para actualizar.');
        END IF;
    END update_combustible;

    PROCEDURE delete_combustible(
        p_id_combustible IN combustible_vuelo.id_combustible%TYPE
    ) IS
    BEGIN
        DELETE FROM combustible_vuelo
        WHERE id_combustible = p_id_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21103, 'No se encontró el registro de combustible para eliminar.');
        END IF;
    END delete_combustible;

END pkg_combustible_vuelo;
/