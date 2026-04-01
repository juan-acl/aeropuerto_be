------------------------------------------------------------
-- Paquete CRUD para la tabla BODEGAS_CARGA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_bodegas_carga AS
    PROCEDURE insert_bodega(
        p_codigo_bodega            IN VARCHAR2,
        p_nombre_bodega            IN VARCHAR2,
        p_ubicacion                IN VARCHAR2,
        p_capacidad_m3             IN NUMBER,
        p_capacidad_kg             IN NUMBER,
        p_tiene_refrigeracion      IN NUMBER DEFAULT 0,
        p_temperatura_controlada   IN NUMBER DEFAULT 0,
        p_tiene_acceso_restringido IN NUMBER DEFAULT 1,
        p_activo                   IN NUMBER DEFAULT 1
    );

    PROCEDURE get_bodega(
        p_id_bodega IN NUMBER
    );

    PROCEDURE update_bodega(
        p_id_bodega                IN NUMBER,
        p_codigo_bodega            IN VARCHAR2,
        p_nombre_bodega            IN VARCHAR2,
        p_ubicacion                IN VARCHAR2,
        p_capacidad_m3             IN NUMBER,
        p_capacidad_kg             IN NUMBER,
        p_tiene_refrigeracion      IN NUMBER,
        p_temperatura_controlada   IN NUMBER,
        p_tiene_acceso_restringido IN NUMBER,
        p_activo                   IN NUMBER
    );

    PROCEDURE delete_bodega(
        p_id_bodega IN NUMBER
    );
END pkg_bodegas_carga;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_bodegas_carga AS

    PROCEDURE insert_bodega(
        p_codigo_bodega            IN VARCHAR2,
        p_nombre_bodega            IN VARCHAR2,
        p_ubicacion                IN VARCHAR2,
        p_capacidad_m3             IN NUMBER,
        p_capacidad_kg             IN NUMBER,
        p_tiene_refrigeracion      IN NUMBER,
        p_temperatura_controlada   IN NUMBER,
        p_tiene_acceso_restringido IN NUMBER,
        p_activo                   IN NUMBER
    ) IS
    BEGIN
        INSERT INTO bodegas_carga (
            codigo_bodega, nombre_bodega, ubicacion,
            capacidad_m3, capacidad_kg,
            tiene_refrigeracion, temperatura_controlada,
            tiene_acceso_restringido, activo
        ) VALUES (
            p_codigo_bodega, p_nombre_bodega, p_ubicacion,
            p_capacidad_m3, p_capacidad_kg,
            NVL(p_tiene_refrigeracion,0), NVL(p_temperatura_controlada,0),
            NVL(p_tiene_acceso_restringido,1), NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29201, 'Error al insertar bodega de carga: ' || SQLERRM);
    END insert_bodega;

    PROCEDURE get_bodega(
        p_id_bodega IN NUMBER
    ) IS
        r bodegas_carga%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM bodegas_carga
        WHERE id_bodega = p_id_bodega;

        DBMS_OUTPUT.PUT_LINE('ID Bodega: ' || r.id_bodega);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_bodega);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_bodega);
        DBMS_OUTPUT.PUT_LINE('Ubicación: ' || r.ubicacion);
        DBMS_OUTPUT.PUT_LINE('Capacidad m3: ' || r.capacidad_m3);
        DBMS_OUTPUT.PUT_LINE('Capacidad kg: ' || r.capacidad_kg);
        DBMS_OUTPUT.PUT_LINE('Refrigeración: ' || r.tiene_refrigeracion);
        DBMS_OUTPUT.PUT_LINE('Temperatura controlada: ' || r.temperatura_controlada);
        DBMS_OUTPUT.PUT_LINE('Acceso restringido: ' || r.tiene_acceso_restringido);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Bodega de carga no encontrada.');
    END get_bodega;

    PROCEDURE update_bodega(
        p_id_bodega                IN NUMBER,
        p_codigo_bodega            IN VARCHAR2,
        p_nombre_bodega            IN VARCHAR2,
        p_ubicacion                IN VARCHAR2,
        p_capacidad_m3             IN NUMBER,
        p_capacidad_kg             IN NUMBER,
        p_tiene_refrigeracion      IN NUMBER,
        p_temperatura_controlada   IN NUMBER,
        p_tiene_acceso_restringido IN NUMBER,
        p_activo                   IN NUMBER
    ) IS
    BEGIN
        UPDATE bodegas_carga
        SET codigo_bodega            = p_codigo_bodega,
            nombre_bodega            = p_nombre_bodega,
            ubicacion                = p_ubicacion,
            capacidad_m3             = p_capacidad_m3,
            capacidad_kg             = p_capacidad_kg,
            tiene_refrigeracion      = p_tiene_refrigeracion,
            temperatura_controlada   = p_temperatura_controlada,
            tiene_acceso_restringido = p_tiene_acceso_restringido,
            activo                   = p_activo
        WHERE id_bodega = p_id_bodega;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29202, 'No se encontró la bodega de carga para actualizar.');
        END IF;
    END update_bodega;

    PROCEDURE delete_bodega(
        p_id_bodega IN NUMBER
    ) IS
    BEGIN
        DELETE FROM bodegas_carga
        WHERE id_bodega = p_id_bodega;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29203, 'No se encontró la bodega de carga para eliminar.');
        END IF;
    END delete_bodega;

END pkg_bodegas_carga;
/
