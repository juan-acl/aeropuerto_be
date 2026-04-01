------------------------------------------------------------
-- Paquete CRUD para la tabla CARGA_UBICACION
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_carga_ubicacion AS
    PROCEDURE insert_ubicacion(
        p_id_envio            IN NUMBER,
        p_id_bodega           IN NUMBER,
        p_fecha_ingreso       IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_fecha_salida        IN TIMESTAMP,
        p_posicion_estante    IN VARCHAR2,
        p_posicion_fila       IN NUMBER,
        p_posicion_columna    IN NUMBER,
        p_responsable_ingreso IN NUMBER,
        p_responsable_salida  IN NUMBER
    );

    PROCEDURE get_ubicacion(
        p_id_ubicacion IN NUMBER
    );

    PROCEDURE update_ubicacion(
        p_id_ubicacion       IN NUMBER,
        p_id_envio           IN NUMBER,
        p_id_bodega          IN NUMBER,
        p_fecha_ingreso      IN TIMESTAMP,
        p_fecha_salida       IN TIMESTAMP,
        p_posicion_estante   IN VARCHAR2,
        p_posicion_fila      IN NUMBER,
        p_posicion_columna   IN NUMBER,
        p_responsable_ingreso IN NUMBER,
        p_responsable_salida  IN NUMBER
    );

    PROCEDURE delete_ubicacion(
        p_id_ubicacion IN NUMBER
    );
END pkg_carga_ubicacion;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_carga_ubicacion AS

    PROCEDURE insert_ubicacion(
        p_id_envio            IN NUMBER,
        p_id_bodega           IN NUMBER,
        p_fecha_ingreso       IN TIMESTAMP,
        p_fecha_salida        IN TIMESTAMP,
        p_posicion_estante    IN VARCHAR2,
        p_posicion_fila       IN NUMBER,
        p_posicion_columna    IN NUMBER,
        p_responsable_ingreso IN NUMBER,
        p_responsable_salida  IN NUMBER
    ) IS
    BEGIN
        INSERT INTO carga_ubicacion (
            id_envio, id_bodega, fecha_ingreso, fecha_salida,
            posicion_estante, posicion_fila, posicion_columna,
            responsable_ingreso, responsable_salida
        ) VALUES (
            p_id_envio, p_id_bodega, NVL(p_fecha_ingreso, SYSTIMESTAMP), p_fecha_salida,
            p_posicion_estante, p_posicion_fila, p_posicion_columna,
            p_responsable_ingreso, p_responsable_salida
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29301, 'Error al insertar ubicación de carga: ' || SQLERRM);
    END insert_ubicacion;

    PROCEDURE get_ubicacion(
        p_id_ubicacion IN NUMBER
    ) IS
        r carga_ubicacion%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM carga_ubicacion
        WHERE id_ubicacion = p_id_ubicacion;

        DBMS_OUTPUT.PUT_LINE('ID Ubicación: ' || r.id_ubicacion);
        DBMS_OUTPUT.PUT_LINE('Envío: ' || r.id_envio);
        DBMS_OUTPUT.PUT_LINE('Bodega: ' || r.id_bodega);
        DBMS_OUTPUT.PUT_LINE('Fecha ingreso: ' || r.fecha_ingreso);
        DBMS_OUTPUT.PUT_LINE('Fecha salida: ' || r.fecha_salida);
        DBMS_OUTPUT.PUT_LINE('Posición estante: ' || r.posicion_estante);
        DBMS_OUTPUT.PUT_LINE('Fila: ' || r.posicion_fila);
        DBMS_OUTPUT.PUT_LINE('Columna: ' || r.posicion_columna);
        DBMS_OUTPUT.PUT_LINE('Responsable ingreso: ' || r.responsable_ingreso);
        DBMS_OUTPUT.PUT_LINE('Responsable salida: ' || r.responsable_salida);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Ubicación de carga no encontrada.');
    END get_ubicacion;

    PROCEDURE update_ubicacion(
        p_id_ubicacion       IN NUMBER,
        p_id_envio           IN NUMBER,
        p_id_bodega          IN NUMBER,
        p_fecha_ingreso      IN TIMESTAMP,
        p_fecha_salida       IN TIMESTAMP,
        p_posicion_estante   IN VARCHAR2,
        p_posicion_fila      IN NUMBER,
        p_posicion_columna   IN NUMBER,
        p_responsable_ingreso IN NUMBER,
        p_responsable_salida  IN NUMBER
    ) IS
    BEGIN
        UPDATE carga_ubicacion
        SET id_envio            = p_id_envio,
            id_bodega           = p_id_bodega,
            fecha_ingreso       = p_fecha_ingreso,
            fecha_salida        = p_fecha_salida,
            posicion_estante    = p_posicion_estante,
            posicion_fila       = p_posicion_fila,
            posicion_columna    = p_posicion_columna,
            responsable_ingreso = p_responsable_ingreso,
            responsable_salida  = p_responsable_salida
        WHERE id_ubicacion = p_id_ubicacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29302, 'No se encontró la ubicación de carga para actualizar.');
        END IF;
    END update_ubicacion;

    PROCEDURE delete_ubicacion(
        p_id_ubicacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM carga_ubicacion
        WHERE id_ubicacion = p_id_ubicacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29303, 'No se encontró la ubicación de carga para eliminar.');
        END IF;
    END delete_ubicacion;

END pkg_carga_ubicacion;
/
