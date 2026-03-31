------------------------------------------------------------
-- Paquete CRUD para la tabla OBJETOS_PERDIDOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_objetos_perdidos AS
    PROCEDURE insert_objeto(
        p_descripcion        IN VARCHAR2,
        p_categoria_objeto   IN VARCHAR2,
        p_fecha_reporte      IN DATE DEFAULT SYSDATE,
        p_hora_reporte       IN TIMESTAMP,
        p_lugar_encontrado   IN VARCHAR2,
        p_ubicacion_detallada IN VARCHAR2,
        p_id_vuelo           IN NUMBER,
        p_codigo_aeropuerto  IN VARCHAR2,
        p_color              IN VARCHAR2,
        p_marca              IN VARCHAR2,
        p_modelo             IN VARCHAR2,
        p_numero_serie       IN VARCHAR2,
        p_valor_estimado     IN NUMBER,
        p_encontrado_por     IN VARCHAR2,
        p_ubicacion_actual   IN VARCHAR2,
        p_estado             IN VARCHAR2 DEFAULT 'ENCONTRADO',
        p_fecha_entrega      IN DATE,
        p_id_pasajero_entrega IN NUMBER,
        p_observaciones      IN VARCHAR2,
        p_foto_objeto        IN BLOB
    );

    PROCEDURE get_objeto(
        p_id_objeto IN NUMBER
    );

    PROCEDURE update_objeto(
        p_id_objeto          IN NUMBER,
        p_descripcion        IN VARCHAR2,
        p_categoria_objeto   IN VARCHAR2,
        p_fecha_reporte      IN DATE,
        p_hora_reporte       IN TIMESTAMP,
        p_lugar_encontrado   IN VARCHAR2,
        p_ubicacion_detallada IN VARCHAR2,
        p_id_vuelo           IN NUMBER,
        p_codigo_aeropuerto  IN VARCHAR2,
        p_color              IN VARCHAR2,
        p_marca              IN VARCHAR2,
        p_modelo             IN VARCHAR2,
        p_numero_serie       IN VARCHAR2,
        p_valor_estimado     IN NUMBER,
        p_encontrado_por     IN VARCHAR2,
        p_ubicacion_actual   IN VARCHAR2,
        p_estado             IN VARCHAR2,
        p_fecha_entrega      IN DATE,
        p_id_pasajero_entrega IN NUMBER,
        p_observaciones      IN VARCHAR2,
        p_foto_objeto        IN BLOB
    );

    PROCEDURE delete_objeto(
        p_id_objeto IN NUMBER
    );
END pkg_objetos_perdidos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_objetos_perdidos AS

    PROCEDURE insert_objeto(
        p_descripcion        IN VARCHAR2,
        p_categoria_objeto   IN VARCHAR2,
        p_fecha_reporte      IN DATE,
        p_hora_reporte       IN TIMESTAMP,
        p_lugar_encontrado   IN VARCHAR2,
        p_ubicacion_detallada IN VARCHAR2,
        p_id_vuelo           IN NUMBER,
        p_codigo_aeropuerto  IN VARCHAR2,
        p_color              IN VARCHAR2,
        p_marca              IN VARCHAR2,
        p_modelo             IN VARCHAR2,
        p_numero_serie       IN VARCHAR2,
        p_valor_estimado     IN NUMBER,
        p_encontrado_por     IN VARCHAR2,
        p_ubicacion_actual   IN VARCHAR2,
        p_estado             IN VARCHAR2,
        p_fecha_entrega      IN DATE,
        p_id_pasajero_entrega IN NUMBER,
        p_observaciones      IN VARCHAR2,
        p_foto_objeto        IN BLOB
    ) IS
    BEGIN
        INSERT INTO objetos_perdidos (
            descripcion, categoria_objeto, fecha_reporte, hora_reporte,
            lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto,
            color, marca, modelo, numero_serie, valor_estimado,
            encontrado_por, ubicacion_actual, estado, fecha_entrega,
            id_pasajero_entrega, observaciones, foto_objeto
        ) VALUES (
            p_descripcion, p_categoria_objeto, NVL(p_fecha_reporte, SYSDATE), p_hora_reporte,
            p_lugar_encontrado, p_ubicacion_detallada, p_id_vuelo, p_codigo_aeropuerto,
            p_color, p_marca, p_modelo, p_numero_serie, p_valor_estimado,
            p_encontrado_por, p_ubicacion_actual, NVL(p_estado,'ENCONTRADO'), p_fecha_entrega,
            p_id_pasajero_entrega, p_observaciones, p_foto_objeto
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24401, 'Error al insertar objeto perdido: ' || SQLERRM);
    END insert_objeto;

    PROCEDURE get_objeto(
        p_id_objeto IN NUMBER
    ) IS
        r objetos_perdidos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM objetos_perdidos
        WHERE id_objeto = p_id_objeto;

        DBMS_OUTPUT.PUT_LINE('ID Objeto: ' || r.id_objeto);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Categoría: ' || r.categoria_objeto);
        DBMS_OUTPUT.PUT_LINE('Fecha reporte: ' || r.fecha_reporte);
        DBMS_OUTPUT.PUT_LINE('Hora reporte: ' || r.hora_reporte);
        DBMS_OUTPUT.PUT_LINE('Lugar encontrado: ' || r.lugar_encontrado);
        DBMS_OUTPUT.PUT_LINE('Ubicación detallada: ' || r.ubicacion_detallada);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Color: ' || r.color);
        DBMS_OUTPUT.PUT_LINE('Marca: ' || r.marca);
        DBMS_OUTPUT.PUT_LINE('Modelo: ' || r.modelo);
        DBMS_OUTPUT.PUT_LINE('Número serie: ' || r.numero_serie);
        DBMS_OUTPUT.PUT_LINE('Valor estimado: ' || r.valor_estimado);
        DBMS_OUTPUT.PUT_LINE('Encontrado por: ' || r.encontrado_por);
        DBMS_OUTPUT.PUT_LINE('Ubicación actual: ' || r.ubicacion_actual);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Fecha entrega: ' || r.fecha_entrega);
        DBMS_OUTPUT.PUT_LINE('Pasajero entrega: ' || r.id_pasajero_entrega);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
        DBMS_OUTPUT.PUT_LINE('Foto objeto: ' || CASE WHEN r.foto_objeto IS NOT NULL THEN 'Sí' ELSE 'No' END);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Objeto perdido no encontrado.');
    END get_objeto;

    PROCEDURE update_objeto(
        p_id_objeto          IN NUMBER,
        p_descripcion        IN VARCHAR2,
        p_categoria_objeto   IN VARCHAR2,
        p_fecha_reporte      IN DATE,
        p_hora_reporte       IN TIMESTAMP,
        p_lugar_encontrado   IN VARCHAR2,
        p_ubicacion_detallada IN VARCHAR2,
        p_id_vuelo           IN NUMBER,
        p_codigo_aeropuerto  IN VARCHAR2,
        p_color              IN VARCHAR2,
        p_marca              IN VARCHAR2,
        p_modelo             IN VARCHAR2,
        p_numero_serie       IN VARCHAR2,
        p_valor_estimado     IN NUMBER,
        p_encontrado_por     IN VARCHAR2,
        p_ubicacion_actual   IN VARCHAR2,
        p_estado             IN VARCHAR2,
        p_fecha_entrega      IN DATE,
        p_id_pasajero_entrega IN NUMBER,
        p_observaciones      IN VARCHAR2,
        p_foto_objeto        IN BLOB
    ) IS
    BEGIN
        UPDATE objetos_perdidos
        SET descripcion        = p_descripcion,
            categoria_objeto   = p_categoria_objeto,
            fecha_reporte      = p_fecha_reporte,
            hora_reporte       = p_hora_reporte,
            lugar_encontrado   = p_lugar_encontrado,
            ubicacion_detallada = p_ubicacion_detallada,
            id_vuelo           = p_id_vuelo,
            codigo_aeropuerto  = p_codigo_aeropuerto,
            color              = p_color,
            marca              = p_marca,
            modelo             = p_modelo,
            numero_serie       = p_numero_serie,
            valor_estimado     = p_valor_estimado,
            encontrado_por     = p_encontrado_por,
            ubicacion_actual   = p_ubicacion_actual,
            estado             = p_estado,
            fecha_entrega      = p_fecha_entrega,
            id_pasajero_entrega = p_id_pasajero_entrega,
            observaciones      = p_observaciones,
            foto_objeto        = p_foto_objeto
        WHERE id_objeto = p_id_objeto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24402, 'No se encontró el objeto perdido para actualizar.');
        END IF;
    END update_objeto;

        PROCEDURE delete_objeto(
        p_id_objeto IN NUMBER
    ) IS
    BEGIN
        DELETE FROM objetos_perdidos
        WHERE id_objeto = p_id_objeto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24403, 'No se encontró el objeto perdido para eliminar.');
        END IF;
    END delete_objeto;
END pkg_objetos_perdidos;
/
