------------------------------------------------------------
-- Paquete CRUD para la tabla MANIFIESTOS_CARGA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_manifiestos_carga AS
    PROCEDURE insert_manifiesto(
        p_numero_manifiesto   IN VARCHAR2,
        p_id_vuelo            IN NUMBER,
        p_fecha_emision       IN DATE DEFAULT SYSDATE,
        p_total_bultos        IN NUMBER,
        p_peso_total_kg       IN NUMBER,
        p_volumen_total_m3    IN NUMBER,
        p_valor_total         IN NUMBER,
        p_agente_carga        IN VARCHAR2,
        p_documento_adjunto   IN BLOB,
        p_estado              IN VARCHAR2 DEFAULT 'EMITIDO',
        p_emitido_por         IN NUMBER
    );

    PROCEDURE get_manifiesto(
        p_id_manifiesto IN NUMBER
    );

    PROCEDURE update_manifiesto(
        p_id_manifiesto      IN NUMBER,
        p_numero_manifiesto  IN VARCHAR2,
        p_id_vuelo           IN NUMBER,
        p_fecha_emision      IN DATE,
        p_total_bultos       IN NUMBER,
        p_peso_total_kg      IN NUMBER,
        p_volumen_total_m3   IN NUMBER,
        p_valor_total        IN NUMBER,
        p_agente_carga       IN VARCHAR2,
        p_documento_adjunto  IN BLOB,
        p_estado             IN VARCHAR2,
        p_emitido_por        IN NUMBER
    );

    PROCEDURE delete_manifiesto(
        p_id_manifiesto IN NUMBER
    );
END pkg_manifiestos_carga;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_manifiestos_carga AS

    PROCEDURE insert_manifiesto(
        p_numero_manifiesto   IN VARCHAR2,
        p_id_vuelo            IN NUMBER,
        p_fecha_emision       IN DATE,
        p_total_bultos        IN NUMBER,
        p_peso_total_kg       IN NUMBER,
        p_volumen_total_m3    IN NUMBER,
        p_valor_total         IN NUMBER,
        p_agente_carga        IN VARCHAR2,
        p_documento_adjunto   IN BLOB,
        p_estado              IN VARCHAR2,
        p_emitido_por         IN NUMBER
    ) IS
    BEGIN
        INSERT INTO manifiestos_carga (
            numero_manifiesto, id_vuelo, fecha_emision, total_bultos,
            peso_total_kg, volumen_total_m3, valor_total, agente_carga,
            documento_adjunto, estado, emitido_por
        ) VALUES (
            p_numero_manifiesto, p_id_vuelo, NVL(p_fecha_emision, SYSDATE), p_total_bultos,
            p_peso_total_kg, p_volumen_total_m3, p_valor_total, p_agente_carga,
            p_documento_adjunto, NVL(p_estado,'EMITIDO'), p_emitido_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28701, 'Error al insertar manifiesto de carga: ' || SQLERRM);
    END insert_manifiesto;

    PROCEDURE get_manifiesto(
        p_id_manifiesto IN NUMBER
    ) IS
        r manifiestos_carga%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM manifiestos_carga
        WHERE id_manifiesto = p_id_manifiesto;

        DBMS_OUTPUT.PUT_LINE('ID Manifiesto: ' || r.id_manifiesto);
        DBMS_OUTPUT.PUT_LINE('Número manifiesto: ' || r.numero_manifiesto);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
        DBMS_OUTPUT.PUT_LINE('Total bultos: ' || r.total_bultos);
        DBMS_OUTPUT.PUT_LINE('Peso total (kg): ' || r.peso_total_kg);
        DBMS_OUTPUT.PUT_LINE('Volumen total (m3): ' || r.volumen_total_m3);
        DBMS_OUTPUT.PUT_LINE('Valor total: ' || r.valor_total);
        DBMS_OUTPUT.PUT_LINE('Agente carga: ' || r.agente_carga);
        IF r.documento_adjunto IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento adjunto: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento adjunto: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Emitido por: ' || r.emitido_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Manifiesto de carga no encontrado.');
    END get_manifiesto;

    PROCEDURE update_manifiesto(
        p_id_manifiesto      IN NUMBER,
        p_numero_manifiesto  IN VARCHAR2,
        p_id_vuelo           IN NUMBER,
        p_fecha_emision      IN DATE,
        p_total_bultos       IN NUMBER,
        p_peso_total_kg      IN NUMBER,
        p_volumen_total_m3   IN NUMBER,
        p_valor_total        IN NUMBER,
        p_agente_carga       IN VARCHAR2,
        p_documento_adjunto  IN BLOB,
        p_estado             IN VARCHAR2,
        p_emitido_por        IN NUMBER
    ) IS
    BEGIN
        UPDATE manifiestos_carga
        SET numero_manifiesto  = p_numero_manifiesto,
            id_vuelo           = p_id_vuelo,
            fecha_emision      = p_fecha_emision,
            total_bultos       = p_total_bultos,
            peso_total_kg      = p_peso_total_kg,
            volumen_total_m3   = p_volumen_total_m3,
            valor_total        = p_valor_total,
            agente_carga       = p_agente_carga,
            documento_adjunto  = p_documento_adjunto,
            estado             = p_estado,
            emitido_por        = p_emitido_por
        WHERE id_manifiesto = p_id_manifiesto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28702, 'No se encontró el manifiesto de carga para actualizar.');
        END IF;
    END update_manifiesto;

    PROCEDURE delete_manifiesto(
        p_id_manifiesto IN NUMBER
    ) IS
    BEGIN
        DELETE FROM manifiestos_carga
        WHERE id_manifiesto = p_id_manifiesto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28703, 'No se encontró el manifiesto de carga para eliminar.');
        END IF;
    END delete_manifiesto;

END pkg_manifiestos_carga;
/
