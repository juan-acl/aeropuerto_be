------------------------------------------------------------
-- Paquete CRUD para la tabla ESCALAS_SERVICIOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_escalas_servicios AS
    PROCEDURE insert_servicio(
        p_id_escala        IN escalas_servicios.id_escala%TYPE,
        p_tipo_servicio    IN escalas_servicios.tipo_servicio%TYPE,
        p_proveedor        IN escalas_servicios.proveedor%TYPE,
        p_costo            IN escalas_servicios.costo%TYPE,
        p_moneda           IN escalas_servicios.moneda%TYPE,
        p_fecha_servicio   IN escalas_servicios.fecha_servicio%TYPE
    );

    PROCEDURE get_servicio(
        p_id_servicio_escala IN escalas_servicios.id_servicio_escala%TYPE
    );

    PROCEDURE update_servicio(
        p_id_servicio_escala IN escalas_servicios.id_servicio_escala%TYPE,
        p_id_escala          IN escalas_servicios.id_escala%TYPE,
        p_tipo_servicio      IN escalas_servicios.tipo_servicio%TYPE,
        p_proveedor          IN escalas_servicios.proveedor%TYPE,
        p_costo              IN escalas_servicios.costo%TYPE,
        p_moneda             IN escalas_servicios.moneda%TYPE,
        p_fecha_servicio     IN escalas_servicios.fecha_servicio%TYPE
    );

    PROCEDURE delete_servicio(
        p_id_servicio_escala IN escalas_servicios.id_servicio_escala%TYPE
    );
END pkg_escalas_servicios;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_escalas_servicios AS

    PROCEDURE insert_servicio(
        p_id_escala        IN escalas_servicios.id_escala%TYPE,
        p_tipo_servicio    IN escalas_servicios.tipo_servicio%TYPE,
        p_proveedor        IN escalas_servicios.proveedor%TYPE,
        p_costo            IN escalas_servicios.costo%TYPE,
        p_moneda           IN escalas_servicios.moneda%TYPE,
        p_fecha_servicio   IN escalas_servicios.fecha_servicio%TYPE
    ) IS
    BEGIN
        INSERT INTO escalas_servicios (
            id_escala, tipo_servicio, proveedor,
            costo, moneda, fecha_servicio
        ) VALUES (
            p_id_escala, p_tipo_servicio, p_proveedor,
            p_costo, p_moneda, p_fecha_servicio
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-20601, 'Error al insertar servicio de escala: ' || SQLERRM);
    END insert_servicio;

    PROCEDURE get_servicio(
        p_id_servicio_escala IN escalas_servicios.id_servicio_escala%TYPE
    ) IS
        r escalas_servicios%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM escalas_servicios
        WHERE id_servicio_escala = p_id_servicio_escala;

        DBMS_OUTPUT.PUT_LINE('ID Servicio Escala: ' || r.id_servicio_escala);
        DBMS_OUTPUT.PUT_LINE('Escala: ' || r.id_escala);
        DBMS_OUTPUT.PUT_LINE('Tipo servicio: ' || r.tipo_servicio);
        DBMS_OUTPUT.PUT_LINE('Proveedor: ' || r.proveedor);
        DBMS_OUTPUT.PUT_LINE('Costo: ' || r.costo || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Fecha servicio: ' || r.fecha_servicio);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Servicio de escala no encontrado.');
    END get_servicio;

    PROCEDURE update_servicio(
        p_id_servicio_escala IN escalas_servicios.id_servicio_escala%TYPE,
        p_id_escala          IN escalas_servicios.id_escala%TYPE,
        p_tipo_servicio      IN escalas_servicios.tipo_servicio%TYPE,
        p_proveedor          IN escalas_servicios.proveedor%TYPE,
        p_costo              IN escalas_servicios.costo%TYPE,
        p_moneda             IN escalas_servicios.moneda%TYPE,
        p_fecha_servicio     IN escalas_servicios.fecha_servicio%TYPE
    ) IS
    BEGIN
        UPDATE escalas_servicios
        SET id_escala      = p_id_escala,
            tipo_servicio  = p_tipo_servicio,
            proveedor      = p_proveedor,
            costo          = p_costo,
            moneda         = p_moneda,
            fecha_servicio = p_fecha_servicio
        WHERE id_servicio_escala = p_id_servicio_escala;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20602, 'No se encontró el servicio de escala para actualizar.');
        END IF;
    END update_servicio;

    PROCEDURE delete_servicio(
        p_id_servicio_escala IN escalas_servicios.id_servicio_escala%TYPE
    ) IS
    BEGIN
        DELETE FROM escalas_servicios
        WHERE id_servicio_escala = p_id_servicio_escala;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-20603, 'No se encontró el servicio de escala para eliminar.');
        END IF;
    END delete_servicio;

END pkg_escalas_servicios;
/