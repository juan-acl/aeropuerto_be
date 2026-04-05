------------------------------------------------------------
-- Paquete CRUD para la tabla CLAUSULAS_CONTRATO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_clausulas_contrato AS
    PROCEDURE insert_clausula(
        p_id_contrato      IN NUMBER,
        p_numero_clausula  IN NUMBER,
        p_titulo_clausula  IN VARCHAR2,
        p_texto_clausula   IN CLOB,
        p_tipo_clausula    IN VARCHAR2,
        p_vigente          IN NUMBER DEFAULT 1
    );

    PROCEDURE get_clausula(
        p_id_clausula_contrato IN NUMBER
    );

    PROCEDURE update_clausula(
        p_id_clausula_contrato IN NUMBER,
        p_id_contrato      IN NUMBER,
        p_numero_clausula  IN NUMBER,
        p_titulo_clausula  IN VARCHAR2,
        p_texto_clausula   IN CLOB,
        p_tipo_clausula    IN VARCHAR2,
        p_vigente          IN NUMBER
    );

    PROCEDURE delete_clausula(
        p_id_clausula_contrato IN NUMBER
    );
END pkg_clausulas_contrato;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_clausulas_contrato AS

    PROCEDURE insert_clausula(
        p_id_contrato      IN NUMBER,
        p_numero_clausula  IN NUMBER,
        p_titulo_clausula  IN VARCHAR2,
        p_texto_clausula   IN CLOB,
        p_tipo_clausula    IN VARCHAR2,
        p_vigente          IN NUMBER
    ) IS
    BEGIN
        INSERT INTO clausulas_contrato (
            id_contrato, numero_clausula, titulo_clausula,
            texto_clausula, tipo_clausula, vigente
        ) VALUES (
            p_id_contrato, p_numero_clausula, p_titulo_clausula,
            p_texto_clausula, p_tipo_clausula, NVL(p_vigente,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34001, 'Error al insertar cláusula de contrato: ' || SQLERRM);
    END insert_clausula;

    PROCEDURE get_clausula(
        p_id_clausula_contrato IN NUMBER
    ) IS
        r clausulas_contrato%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM clausulas_contrato
        WHERE id_clausula_contrato = p_id_clausula_contrato;

        DBMS_OUTPUT.PUT_LINE('ID Cláusula: ' || r.id_clausula_contrato);
        DBMS_OUTPUT.PUT_LINE('Contrato: ' || r.id_contrato);
        DBMS_OUTPUT.PUT_LINE('Número cláusula: ' || r.numero_clausula);
        DBMS_OUTPUT.PUT_LINE('Título: ' || r.titulo_clausula);
        DBMS_OUTPUT.PUT_LINE('Texto: ' || DBMS_LOB.SUBSTR(r.texto_clausula, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_clausula);
        DBMS_OUTPUT.PUT_LINE('Vigente: ' || r.vigente);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Cláusula de contrato no encontrada.');
    END get_clausula;

    PROCEDURE update_clausula(
        p_id_clausula_contrato IN NUMBER,
        p_id_contrato      IN NUMBER,
        p_numero_clausula  IN NUMBER,
        p_titulo_clausula  IN VARCHAR2,
        p_texto_clausula   IN CLOB,
        p_tipo_clausula    IN VARCHAR2,
        p_vigente          IN NUMBER
    ) IS
    BEGIN
        UPDATE clausulas_contrato
        SET id_contrato      = p_id_contrato,
            numero_clausula  = p_numero_clausula,
            titulo_clausula  = p_titulo_clausula,
            texto_clausula   = p_texto_clausula,
            tipo_clausula    = p_tipo_clausula,
            vigente          = p_vigente
        WHERE id_clausula_contrato = p_id_clausula_contrato;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34002, 'No se encontró la cláusula de contrato para actualizar.');
        END IF;
    END update_clausula;

    PROCEDURE delete_clausula(
        p_id_clausula_contrato IN NUMBER
    ) IS
    BEGIN
        DELETE FROM clausulas_contrato
        WHERE id_clausula_contrato = p_id_clausula_contrato;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34003, 'No se encontró la cláusula de contrato para eliminar.');
        END IF;
    END delete_clausula;

END pkg_clausulas_contrato;
/
