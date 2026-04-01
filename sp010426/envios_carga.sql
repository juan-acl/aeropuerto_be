------------------------------------------------------------
-- Paquete CRUD para la tabla ENVIOS_CARGA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_envios_carga AS
    PROCEDURE insert_envio(
        p_codigo_envio           IN VARCHAR2,
        p_id_vuelo               IN NUMBER,
        p_id_tipo_carga          IN NUMBER,
        p_peso_kg                IN NUMBER,
        p_volumen_m3             IN NUMBER,
        p_cantidad_bultos        IN NUMBER,
        p_contenido              IN VARCHAR2,
        p_valor_declarado        IN NUMBER,
        p_moneda                 IN VARCHAR2,
        p_consignador_nombre     IN VARCHAR2,
        p_consignador_documento  IN VARCHAR2,
        p_consignatario_nombre   IN VARCHAR2,
        p_consignatario_documento IN VARCHAR2,
        p_instrucciones_especiales IN VARCHAR2,
        p_fecha_recepcion        IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_fecha_embarque         IN DATE,
        p_estado                 IN VARCHAR2 DEFAULT 'RECIBIDO',
        p_ubicacion_actual       IN VARCHAR2
    );

    PROCEDURE get_envio(
        p_id_envio IN NUMBER
    );

    PROCEDURE update_envio(
        p_id_envio               IN NUMBER,
        p_codigo_envio           IN VARCHAR2,
        p_id_vuelo               IN NUMBER,
        p_id_tipo_carga          IN NUMBER,
        p_peso_kg                IN NUMBER,
        p_volumen_m3             IN NUMBER,
        p_cantidad_bultos        IN NUMBER,
        p_contenido              IN VARCHAR2,
        p_valor_declarado        IN NUMBER,
        p_moneda                 IN VARCHAR2,
        p_consignador_nombre     IN VARCHAR2,
        p_consignador_documento  IN VARCHAR2,
        p_consignatario_nombre   IN VARCHAR2,
        p_consignatario_documento IN VARCHAR2,
        p_instrucciones_especiales IN VARCHAR2,
        p_fecha_recepcion        IN TIMESTAMP,
        p_fecha_embarque         IN DATE,
        p_estado                 IN VARCHAR2,
        p_ubicacion_actual       IN VARCHAR2
    );

    PROCEDURE delete_envio(
        p_id_envio IN NUMBER
    );
END pkg_envios_carga;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_envios_carga AS

    PROCEDURE insert_envio(
        p_codigo_envio           IN VARCHAR2,
        p_id_vuelo               IN NUMBER,
        p_id_tipo_carga          IN NUMBER,
        p_peso_kg                IN NUMBER,
        p_volumen_m3             IN NUMBER,
        p_cantidad_bultos        IN NUMBER,
        p_contenido              IN VARCHAR2,
        p_valor_declarado        IN NUMBER,
        p_moneda                 IN VARCHAR2,
        p_consignador_nombre     IN VARCHAR2,
        p_consignador_documento  IN VARCHAR2,
        p_consignatario_nombre   IN VARCHAR2,
        p_consignatario_documento IN VARCHAR2,
        p_instrucciones_especiales IN VARCHAR2,
        p_fecha_recepcion        IN TIMESTAMP,
        p_fecha_embarque         IN DATE,
        p_estado                 IN VARCHAR2,
        p_ubicacion_actual       IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO envios_carga (
            codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3,
            cantidad_bultos, contenido, valor_declarado, moneda,
            consignador_nombre, consignador_documento,
            consignatario_nombre, consignatario_documento,
            instrucciones_especiales, fecha_recepcion, fecha_embarque,
            estado, ubicacion_actual
        ) VALUES (
            p_codigo_envio, p_id_vuelo, p_id_tipo_carga, p_peso_kg, p_volumen_m3,
            p_cantidad_bultos, p_contenido, p_valor_declarado, p_moneda,
            p_consignador_nombre, p_consignador_documento,
            p_consignatario_nombre, p_consignatario_documento,
            p_instrucciones_especiales, NVL(p_fecha_recepcion,SYSTIMESTAMP), p_fecha_embarque,
            NVL(p_estado,'RECIBIDO'), p_ubicacion_actual
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28601, 'Error al insertar envío de carga: ' || SQLERRM);
    END insert_envio;

    PROCEDURE get_envio(
        p_id_envio IN NUMBER
    ) IS
        r envios_carga%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM envios_carga
        WHERE id_envio = p_id_envio;

        DBMS_OUTPUT.PUT_LINE('ID Envío: ' || r.id_envio);
        DBMS_OUTPUT.PUT_LINE('Código envío: ' || r.codigo_envio);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Tipo carga: ' || r.id_tipo_carga);
        DBMS_OUTPUT.PUT_LINE('Peso (kg): ' || r.peso_kg);
        DBMS_OUTPUT.PUT_LINE('Volumen (m3): ' || r.volumen_m3);
        DBMS_OUTPUT.PUT_LINE('Cantidad bultos: ' || r.cantidad_bultos);
        DBMS_OUTPUT.PUT_LINE('Contenido: ' || r.contenido);
        DBMS_OUTPUT.PUT_LINE('Valor declarado: ' || r.valor_declarado || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Consignador: ' || r.consignador_nombre || ' (' || r.consignador_documento || ')');
        DBMS_OUTPUT.PUT_LINE('Consignatario: ' || r.consignatario_nombre || ' (' || r.consignatario_documento || ')');
        DBMS_OUTPUT.PUT_LINE('Instrucciones especiales: ' || r.instrucciones_especiales);
        DBMS_OUTPUT.PUT_LINE('Fecha recepción: ' || r.fecha_recepcion);
        DBMS_OUTPUT.PUT_LINE('Fecha embarque: ' || r.fecha_embarque);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Ubicación actual: ' || r.ubicacion_actual);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Envío de carga no encontrado.');
    END get_envio;

    PROCEDURE update_envio(
        p_id_envio               IN NUMBER,
        p_codigo_envio           IN VARCHAR2,
        p_id_vuelo               IN NUMBER,
        p_id_tipo_carga          IN NUMBER,
        p_peso_kg                IN NUMBER,
        p_volumen_m3             IN NUMBER,
        p_cantidad_bultos        IN NUMBER,
        p_contenido              IN VARCHAR2,
        p_valor_declarado        IN NUMBER,
        p_moneda                 IN VARCHAR2,
        p_consignador_nombre     IN VARCHAR2,
        p_consignador_documento  IN VARCHAR2,
        p_consignatario_nombre   IN VARCHAR2,
        p_consignatario_documento IN VARCHAR2,
        p_instrucciones_especiales IN VARCHAR2,
        p_fecha_recepcion        IN TIMESTAMP,
        p_fecha_embarque         IN DATE,
        p_estado                 IN VARCHAR2,
        p_ubicacion_actual       IN VARCHAR2
    ) IS
    BEGIN
        UPDATE envios_carga
        SET codigo_envio           = p_codigo_envio,
            id_vuelo               = p_id_vuelo,
            id_tipo_carga          = p_id_tipo_carga,
            peso_kg                = p_peso_kg,
            volumen_m3             = p_volumen_m3,
            cantidad_bultos        = p_cantidad_bultos,
            contenido              = p_contenido,
            valor_declarado        = p_valor_declarado,
            moneda                 = p_moneda,
            consignador_nombre     = p_consignador_nombre,
            consignador_documento  = p_consignador_documento,
            consignatario_nombre   = p_consignatario_nombre,
            consignatario_documento = p_consignatario_documento,
            instrucciones_especiales = p_instrucciones_especiales,
            fecha_recepcion        = p_fecha_recepcion,
            fecha_embarque         = p_fecha_embarque,
            estado                 = p_estado,
            ubicacion_actual       = p_ubicacion_actual
        WHERE id_envio = p_id_envio;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28602, 'No se encontró el envío de carga para actualizar.');
        END IF;
    END update_envio;

    PROCEDURE delete_envio(
        p_id_envio IN NUMBER
    ) IS
    BEGIN
        DELETE FROM envios_carga
        WHERE id_envio = p_id_envio;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28603, 'No se encontró el envío de carga para eliminar.');
        END IF;
    END delete_envio;

END pkg_envios_carga;
/
