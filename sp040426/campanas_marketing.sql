------------------------------------------------------------
-- Paquete CRUD para la tabla CAMPANAS_MARKETING
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_campanas_marketing AS
    PROCEDURE insert_campana(
        p_nombre_campana     IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_tipo_campana       IN VARCHAR2,
        p_objetivo           IN VARCHAR2,
        p_fecha_inicio       IN DATE,
        p_fecha_fin          IN DATE,
        p_presupuesto        IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_costo_real         IN NUMBER,
        p_publico_objetivo   IN VARCHAR2,
        p_segmento_objetivo  IN VARCHAR2,
        p_activa             IN NUMBER DEFAULT 1,
        p_responsable        IN NUMBER,
        p_resultados         IN CLOB
    );

    PROCEDURE get_campana(
        p_id_campana_marketing IN NUMBER
    );

    PROCEDURE update_campana(
        p_id_campana_marketing IN NUMBER,
        p_nombre_campana     IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_tipo_campana       IN VARCHAR2,
        p_objetivo           IN VARCHAR2,
        p_fecha_inicio       IN DATE,
        p_fecha_fin          IN DATE,
        p_presupuesto        IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_costo_real         IN NUMBER,
        p_publico_objetivo   IN VARCHAR2,
        p_segmento_objetivo  IN VARCHAR2,
        p_activa             IN NUMBER,
        p_responsable        IN NUMBER,
        p_resultados         IN CLOB
    );

    PROCEDURE delete_campana(
        p_id_campana_marketing IN NUMBER
    );
END pkg_campanas_marketing;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_campanas_marketing AS

    PROCEDURE insert_campana(
        p_nombre_campana     IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_tipo_campana       IN VARCHAR2,
        p_objetivo           IN VARCHAR2,
        p_fecha_inicio       IN DATE,
        p_fecha_fin          IN DATE,
        p_presupuesto        IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_costo_real         IN NUMBER,
        p_publico_objetivo   IN VARCHAR2,
        p_segmento_objetivo  IN VARCHAR2,
        p_activa             IN NUMBER,
        p_responsable        IN NUMBER,
        p_resultados         IN CLOB
    ) IS
    BEGIN
        INSERT INTO campanas_marketing (
            nombre_campana, descripcion, tipo_campana, objetivo,
            fecha_inicio, fecha_fin, presupuesto, moneda,
            costo_real, publico_objetivo, segmento_objetivo,
            activa, responsable, resultados
        ) VALUES (
            p_nombre_campana, p_descripcion, p_tipo_campana, p_objetivo,
            p_fecha_inicio, p_fecha_fin, p_presupuesto, p_moneda,
            p_costo_real, p_publico_objetivo, p_segmento_objetivo,
            NVL(p_activa,1), p_responsable, p_resultados
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32701, 'Error al insertar campaña de marketing: ' || SQLERRM);
    END insert_campana;

    PROCEDURE get_campana(
        p_id_campana_marketing IN NUMBER
    ) IS
        r campanas_marketing%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM campanas_marketing
        WHERE id_campana_marketing = p_id_campana_marketing;

        DBMS_OUTPUT.PUT_LINE('ID Campaña: ' || r.id_campana_marketing);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_campana);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Tipo campaña: ' || r.tipo_campana);
        DBMS_OUTPUT.PUT_LINE('Objetivo: ' || r.objetivo);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Presupuesto: ' || r.presupuesto || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Costo real: ' || r.costo_real || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Público objetivo: ' || r.publico_objetivo);
        DBMS_OUTPUT.PUT_LINE('Segmento objetivo: ' || r.segmento_objetivo);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
        DBMS_OUTPUT.PUT_LINE('Responsable: ' || r.responsable);
        DBMS_OUTPUT.PUT_LINE('Resultados: ' || DBMS_LOB.SUBSTR(r.resultados, 200, 1));
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Campaña de marketing no encontrada.');
    END get_campana;

    PROCEDURE update_campana(
        p_id_campana_marketing IN NUMBER,
        p_nombre_campana     IN VARCHAR2,
        p_descripcion        IN VARCHAR2,
        p_tipo_campana       IN VARCHAR2,
        p_objetivo           IN VARCHAR2,
        p_fecha_inicio       IN DATE,
        p_fecha_fin          IN DATE,
        p_presupuesto        IN NUMBER,
        p_moneda             IN VARCHAR2,
        p_costo_real         IN NUMBER,
        p_publico_objetivo   IN VARCHAR2,
        p_segmento_objetivo  IN VARCHAR2,
        p_activa             IN NUMBER,
        p_responsable        IN NUMBER,
        p_resultados         IN CLOB
    ) IS
    BEGIN
        UPDATE campanas_marketing
        SET nombre_campana     = p_nombre_campana,
            descripcion        = p_descripcion,
            tipo_campana       = p_tipo_campana,
            objetivo           = p_objetivo,
            fecha_inicio       = p_fecha_inicio,
            fecha_fin          = p_fecha_fin,
            presupuesto        = p_presupuesto,
            moneda             = p_moneda,
            costo_real         = p_costo_real,
            publico_objetivo   = p_publico_objetivo,
            segmento_objetivo  = p_segmento_objetivo,
            activa             = p_activa,
            responsable        = p_responsable,
            resultados         = p_resultados
        WHERE id_campana_marketing = p_id_campana_marketing;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32702, 'No se encontró la campaña de marketing para actualizar.');
        END IF;
    END update_campana;

    PROCEDURE delete_campana(
        p_id_campana_marketing IN NUMBER
    ) IS
    BEGIN
        DELETE FROM campanas_marketing
        WHERE id_campana_marketing = p_id_campana_marketing;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32703, 'No se encontró la campaña de marketing para eliminar.');
        END IF;
    END delete_campana;

END pkg_campanas_marketing;
/
