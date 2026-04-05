------------------------------------------------------------
-- Paquete CRUD para la tabla OFERTAS_PERSONALIZADAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_ofertas_personalizadas AS
    PROCEDURE insert_oferta(
        p_id_segmento_cliente IN NUMBER,
        p_id_promocion        IN NUMBER,
        p_titulo_oferta       IN VARCHAR2,
        p_descripcion         IN VARCHAR2,
        p_condiciones         IN VARCHAR2,
        p_descuento_porcentaje IN NUMBER,
        p_descuento_fijo      IN NUMBER,
        p_fecha_inicio        IN DATE,
        p_fecha_fin           IN DATE,
        p_prioridad           IN NUMBER,
        p_visualizaciones     IN NUMBER DEFAULT 0,
        p_conversiones        IN NUMBER DEFAULT 0,
        p_activa              IN NUMBER DEFAULT 1,
        p_creada_por          IN NUMBER,
        p_resultados          IN CLOB
    );

    PROCEDURE get_oferta(
        p_id_oferta_personalizada IN NUMBER
    );

    PROCEDURE update_oferta(
        p_id_oferta_personalizada IN NUMBER,
        p_id_segmento_cliente IN NUMBER,
        p_id_promocion        IN NUMBER,
        p_titulo_oferta       IN VARCHAR2,
        p_descripcion         IN VARCHAR2,
        p_condiciones         IN VARCHAR2,
        p_descuento_porcentaje IN NUMBER,
        p_descuento_fijo      IN NUMBER,
        p_fecha_inicio        IN DATE,
        p_fecha_fin           IN DATE,
        p_prioridad           IN NUMBER,
        p_visualizaciones     IN NUMBER,
        p_conversiones        IN NUMBER,
        p_activa              IN NUMBER,
        p_creada_por          IN NUMBER,
        p_resultados          IN CLOB
    );

    PROCEDURE delete_oferta(
        p_id_oferta_personalizada IN NUMBER
    );
END pkg_ofertas_personalizadas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_ofertas_personalizadas AS

    PROCEDURE insert_oferta(
        p_id_segmento_cliente IN NUMBER,
        p_id_promocion        IN NUMBER,
        p_titulo_oferta       IN VARCHAR2,
        p_descripcion         IN VARCHAR2,
        p_condiciones         IN VARCHAR2,
        p_descuento_porcentaje IN NUMBER,
        p_descuento_fijo      IN NUMBER,
        p_fecha_inicio        IN DATE,
        p_fecha_fin           IN DATE,
        p_prioridad           IN NUMBER,
        p_visualizaciones     IN NUMBER,
        p_conversiones        IN NUMBER,
        p_activa              IN NUMBER,
        p_creada_por          IN NUMBER,
        p_resultados          IN CLOB
    ) IS
    BEGIN
        INSERT INTO ofertas_personalizadas (
            id_segmento_cliente, id_promocion, titulo_oferta, descripcion,
            condiciones, descuento_porcentaje, descuento_fijo,
            fecha_inicio, fecha_fin, prioridad,
            visualizaciones, conversiones, activa,
            creada_por, resultados
        ) VALUES (
            p_id_segmento_cliente, p_id_promocion, p_titulo_oferta, p_descripcion,
            p_condiciones, p_descuento_porcentaje, p_descuento_fijo,
            p_fecha_inicio, p_fecha_fin, p_prioridad,
            NVL(p_visualizaciones,0), NVL(p_conversiones,0), NVL(p_activa,1),
            p_creada_por, p_resultados
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33001, 'Error al insertar oferta personalizada: ' || SQLERRM);
    END insert_oferta;

    PROCEDURE get_oferta(
        p_id_oferta_personalizada IN NUMBER
    ) IS
        r ofertas_personalizadas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM ofertas_personalizadas
        WHERE id_oferta_personalizada = p_id_oferta_personalizada;

        DBMS_OUTPUT.PUT_LINE('ID Oferta: ' || r.id_oferta_personalizada);
        DBMS_OUTPUT.PUT_LINE('Segmento cliente: ' || r.id_segmento_cliente);
        DBMS_OUTPUT.PUT_LINE('Promoción: ' || r.id_promocion);
        DBMS_OUTPUT.PUT_LINE('Título: ' || r.titulo_oferta);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Condiciones: ' || r.condiciones);
        DBMS_OUTPUT.PUT_LINE('Descuento %: ' || r.descuento_porcentaje);
        DBMS_OUTPUT.PUT_LINE('Descuento fijo: ' || r.descuento_fijo);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Prioridad: ' || r.prioridad);
        DBMS_OUTPUT.PUT_LINE('Visualizaciones: ' || r.visualizaciones);
        DBMS_OUTPUT.PUT_LINE('Conversiones: ' || r.conversiones);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
        DBMS_OUTPUT.PUT_LINE('Creada por: ' || r.creada_por);
        DBMS_OUTPUT.PUT_LINE('Resultados: ' || DBMS_LOB.SUBSTR(r.resultados, 200, 1));
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Oferta personalizada no encontrada.');
    END get_oferta;

    PROCEDURE update_oferta(
        p_id_oferta_personalizada IN NUMBER,
        p_id_segmento_cliente IN NUMBER,
        p_id_promocion        IN NUMBER,
        p_titulo_oferta       IN VARCHAR2,
        p_descripcion         IN VARCHAR2,
        p_condiciones         IN VARCHAR2,
        p_descuento_porcentaje IN NUMBER,
        p_descuento_fijo      IN NUMBER,
        p_fecha_inicio        IN DATE,
        p_fecha_fin           IN DATE,
        p_prioridad           IN NUMBER,
        p_visualizaciones     IN NUMBER,
        p_conversiones        IN NUMBER,
        p_activa              IN NUMBER,
        p_creada_por          IN NUMBER,
        p_resultados          IN CLOB
    ) IS
    BEGIN
        UPDATE ofertas_personalizadas
        SET id_segmento_cliente = p_id_segmento_cliente,
            id_promocion        = p_id_promocion,
            titulo_oferta       = p_titulo_oferta,
            descripcion         = p_descripcion,
            condiciones         = p_condiciones,
            descuento_porcentaje = p_descuento_porcentaje,
            descuento_fijo      = p_descuento_fijo,
            fecha_inicio        = p_fecha_inicio,
            fecha_fin           = p_fecha_fin,
            prioridad           = p_prioridad,
            visualizaciones     = p_visualizaciones,
            conversiones        = p_conversiones,
            activa              = p_activa,
            creada_por          = p_creada_por,
            resultados          = p_resultados
        WHERE id_oferta_personalizada = p_id_oferta_personalizada;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33002, 'No se encontró la oferta personalizada para actualizar.');
        END IF;
    END update_oferta;

    PROCEDURE delete_oferta(
        p_id_oferta_personalizada IN NUMBER
    ) IS
    BEGIN
        DELETE FROM ofertas_personalizadas
        WHERE id_oferta_personalizada = p_id_oferta_personalizada;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33003, 'No se encontró la oferta personalizada para eliminar.');
        END IF;
    END delete_oferta;

END pkg_ofertas_personalizadas;
/
