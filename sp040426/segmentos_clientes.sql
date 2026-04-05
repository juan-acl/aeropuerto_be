------------------------------------------------------------
-- Paquete CRUD para la tabla SEGMENTOS_CLIENTES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_segmentos_clientes AS
    PROCEDURE insert_segmento(
        p_nombre_segmento    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_criterios_json     IN CLOB,
        p_frecuencia_viajes  IN VARCHAR2,
        p_clase_preferida    IN VARCHAR2,
        p_destinos_frecuentes IN CLOB,
        p_edad_promedio      IN NUMBER,
        p_nivel_ingresos     IN VARCHAR2,
        p_activo             IN NUMBER DEFAULT 1
    );

    PROCEDURE get_segmento(
        p_id_segmento_cliente IN NUMBER
    );

    PROCEDURE update_segmento(
        p_id_segmento_cliente IN NUMBER,
        p_nombre_segmento    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_criterios_json     IN CLOB,
        p_frecuencia_viajes  IN VARCHAR2,
        p_clase_preferida    IN VARCHAR2,
        p_destinos_frecuentes IN CLOB,
        p_edad_promedio      IN NUMBER,
        p_nivel_ingresos     IN VARCHAR2,
        p_activo             IN NUMBER
    );

    PROCEDURE delete_segmento(
        p_id_segmento_cliente IN NUMBER
    );
END pkg_segmentos_clientes;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_segmentos_clientes AS

    PROCEDURE insert_segmento(
        p_nombre_segmento    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_criterios_json     IN CLOB,
        p_frecuencia_viajes  IN VARCHAR2,
        p_clase_preferida    IN VARCHAR2,
        p_destinos_frecuentes IN CLOB,
        p_edad_promedio      IN NUMBER,
        p_nivel_ingresos     IN VARCHAR2,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        INSERT INTO segmentos_clientes (
            nombre_segmento, descripcion, criterios_json,
            frecuencia_viajes, clase_preferida, destinos_frecuentes,
            edad_promedio, nivel_ingresos, activo
        ) VALUES (
            p_nombre_segmento, p_descripcion, p_criterios_json,
            p_frecuencia_viajes, p_clase_preferida, p_destinos_frecuentes,
            p_edad_promedio, p_nivel_ingresos, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32801, 'Error al insertar segmento de cliente: ' || SQLERRM);
    END insert_segmento;

    PROCEDURE get_segmento(
        p_id_segmento_cliente IN NUMBER
    ) IS
        r segmentos_clientes%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM segmentos_clientes
        WHERE id_segmento_cliente = p_id_segmento_cliente;

        DBMS_OUTPUT.PUT_LINE('ID Segmento: ' || r.id_segmento_cliente);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_segmento);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Criterios JSON: ' || DBMS_LOB.SUBSTR(r.criterios_json, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Frecuencia viajes: ' || r.frecuencia_viajes);
        DBMS_OUTPUT.PUT_LINE('Clase preferida: ' || r.clase_preferida);
        DBMS_OUTPUT.PUT_LINE('Destinos frecuentes: ' || DBMS_LOB.SUBSTR(r.destinos_frecuentes, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Edad promedio: ' || r.edad_promedio);
        DBMS_OUTPUT.PUT_LINE('Nivel ingresos: ' || r.nivel_ingresos);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Segmento de cliente no encontrado.');
    END get_segmento;

    PROCEDURE update_segmento(
        p_id_segmento_cliente IN NUMBER,
        p_nombre_segmento    IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_criterios_json     IN CLOB,
        p_frecuencia_viajes  IN VARCHAR2,
        p_clase_preferida    IN VARCHAR2,
        p_destinos_frecuentes IN CLOB,
        p_edad_promedio      IN NUMBER,
        p_nivel_ingresos     IN VARCHAR2,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        UPDATE segmentos_clientes
        SET nombre_segmento    = p_nombre_segmento,
            descripcion        = p_descripcion,
            criterios_json     = p_criterios_json,
            frecuencia_viajes  = p_frecuencia_viajes,
            clase_preferida    = p_clase_preferida,
            destinos_frecuentes = p_destinos_frecuentes,
            edad_promedio      = p_edad_promedio,
            nivel_ingresos     = p_nivel_ingresos,
            activo             = p_activo
        WHERE id_segmento_cliente = p_id_segmento_cliente;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32802, 'No se encontró el segmento de cliente para actualizar.');
        END IF;
    END update_segmento;

    PROCEDURE delete_segmento(
        p_id_segmento_cliente IN NUMBER
    ) IS
    BEGIN
        DELETE FROM segmentos_clientes
        WHERE id_segmento_cliente = p_id_segmento_cliente;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32803, 'No se encontró el segmento de cliente para eliminar.');
        END IF;
    END delete_segmento;

END pkg_segmentos_clientes;
/
