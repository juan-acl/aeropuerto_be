------------------------------------------------------------
-- Paquete CRUD para la tabla BOTIQUINES_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_botiquines_vuelo AS
    PROCEDURE insert_botiquin(
        p_id_vuelo             IN NUMBER,
        p_fecha_verificacion   IN DATE,
        p_contenido_completo   IN NUMBER DEFAULT 1,
        p_medicamentos_caducados IN NUMBER DEFAULT 0,
        p_observaciones        IN VARCHAR2,
        p_verificado_por       IN VARCHAR2
    );

    PROCEDURE get_botiquin(
        p_id_botiquin IN NUMBER
    );

    PROCEDURE update_botiquin(
        p_id_botiquin          IN NUMBER,
        p_id_vuelo             IN NUMBER,
        p_fecha_verificacion   IN DATE,
        p_contenido_completo   IN NUMBER,
        p_medicamentos_caducados IN NUMBER,
        p_observaciones        IN VARCHAR2,
        p_verificado_por       IN VARCHAR2
    );

    PROCEDURE delete_botiquin(
        p_id_botiquin IN NUMBER
    );
END pkg_botiquines_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_botiquines_vuelo AS

    PROCEDURE insert_botiquin(
        p_id_vuelo             IN NUMBER,
        p_fecha_verificacion   IN DATE,
        p_contenido_completo   IN NUMBER,
        p_medicamentos_caducados IN NUMBER,
        p_observaciones        IN VARCHAR2,
        p_verificado_por       IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO botiquines_vuelo (
            id_vuelo, fecha_verificacion, contenido_completo,
            medicamentos_caducados, observaciones, verificado_por
        ) VALUES (
            p_id_vuelo, p_fecha_verificacion, NVL(p_contenido_completo,1),
            NVL(p_medicamentos_caducados,0), p_observaciones, p_verificado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24001, 'Error al insertar botiquín de vuelo: ' || SQLERRM);
    END insert_botiquin;

    PROCEDURE get_botiquin(
        p_id_botiquin IN NUMBER
    ) IS
        r botiquines_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM botiquines_vuelo
        WHERE id_botiquin = p_id_botiquin;

        DBMS_OUTPUT.PUT_LINE('ID Botiquín: ' || r.id_botiquin);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Fecha verificación: ' || r.fecha_verificacion);
        DBMS_OUTPUT.PUT_LINE('Contenido completo: ' || r.contenido_completo);
        DBMS_OUTPUT.PUT_LINE('Medicamentos caducados: ' || r.medicamentos_caducados);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
        DBMS_OUTPUT.PUT_LINE('Verificado por: ' || r.verificado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Botiquín de vuelo no encontrado.');
    END get_botiquin;

    PROCEDURE update_botiquin(
        p_id_botiquin          IN NUMBER,
        p_id_vuelo             IN NUMBER,
        p_fecha_verificacion   IN DATE,
        p_contenido_completo   IN NUMBER,
        p_medicamentos_caducados IN NUMBER,
        p_observaciones        IN VARCHAR2,
        p_verificado_por       IN VARCHAR2
    ) IS
    BEGIN
        UPDATE botiquines_vuelo
        SET id_vuelo             = p_id_vuelo,
            fecha_verificacion   = p_fecha_verificacion,
            contenido_completo   = p_contenido_completo,
            medicamentos_caducados = p_medicamentos_caducados,
            observaciones        = p_observaciones,
            verificado_por       = p_verificado_por
        WHERE id_botiquin = p_id_botiquin;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24002, 'No se encontró el botiquín de vuelo para actualizar.');
        END IF;
    END update_botiquin;

    PROCEDURE delete_botiquin(
        p_id_botiquin IN NUMBER
    ) IS
    BEGIN
        DELETE FROM botiquines_vuelo
        WHERE id_botiquin = p_id_botiquin;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24003, 'No se encontró el botiquín de vuelo para eliminar.');
        END IF;
    END delete_botiquin;

END pkg_botiquines_vuelo;
/