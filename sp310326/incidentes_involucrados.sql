------------------------------------------------------------
-- Paquete CRUD para la tabla INCIDENTES_INVOLUCRADOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_incidentes_involucrados AS
    PROCEDURE insert_involucrado(
        p_id_incidente      IN NUMBER,
        p_tipo_persona      IN VARCHAR2,
        p_id_pasajero       IN NUMBER,
        p_id_tripulante     IN NUMBER,
        p_nombre_completo   IN VARCHAR2,
        p_tipo_documento    IN VARCHAR2,
        p_numero_documento  IN VARCHAR2,
        p_nacionalidad      IN VARCHAR2,
        p_rol_en_incidente  IN VARCHAR2,
        p_declaracion       IN VARCHAR2
    );

    PROCEDURE get_involucrado(
        p_id_involucrado IN NUMBER
    );

    PROCEDURE update_involucrado(
        p_id_involucrado   IN NUMBER,
        p_id_incidente     IN NUMBER,
        p_tipo_persona     IN VARCHAR2,
        p_id_pasajero      IN NUMBER,
        p_id_tripulante    IN NUMBER,
        p_nombre_completo  IN VARCHAR2,
        p_tipo_documento   IN VARCHAR2,
        p_numero_documento IN VARCHAR2,
        p_nacionalidad     IN VARCHAR2,
        p_rol_en_incidente IN VARCHAR2,
        p_declaracion      IN VARCHAR2
    );

    PROCEDURE delete_involucrado(
        p_id_involucrado IN NUMBER
    );
END pkg_incidentes_involucrados;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_incidentes_involucrados AS

    PROCEDURE insert_involucrado(
        p_id_incidente      IN NUMBER,
        p_tipo_persona      IN VARCHAR2,
        p_id_pasajero       IN NUMBER,
        p_id_tripulante     IN NUMBER,
        p_nombre_completo   IN VARCHAR2,
        p_tipo_documento    IN VARCHAR2,
        p_numero_documento  IN VARCHAR2,
        p_nacionalidad      IN VARCHAR2,
        p_rol_en_incidente  IN VARCHAR2,
        p_declaracion       IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO incidentes_involucrados (
            id_incidente, tipo_persona, id_pasajero, id_tripulante,
            nombre_completo, tipo_documento, numero_documento,
            nacionalidad, rol_en_incidente, declaracion
        ) VALUES (
            p_id_incidente, p_tipo_persona, p_id_pasajero, p_id_tripulante,
            p_nombre_completo, p_tipo_documento, p_numero_documento,
            p_nacionalidad, p_rol_en_incidente, p_declaracion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23601, 'Error al insertar involucrado en incidente: ' || SQLERRM);
    END insert_involucrado;

    PROCEDURE get_involucrado(
        p_id_involucrado IN NUMBER
    ) IS
        r incidentes_involucrados%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM incidentes_involucrados
        WHERE id_involucrado = p_id_involucrado;

        DBMS_OUTPUT.PUT_LINE('ID Involucrado: ' || r.id_involucrado);
        DBMS_OUTPUT.PUT_LINE('Incidente: ' || r.id_incidente);
        DBMS_OUTPUT.PUT_LINE('Tipo persona: ' || r.tipo_persona);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Tripulante: ' || r.id_tripulante);
        DBMS_OUTPUT.PUT_LINE('Nombre completo: ' || r.nombre_completo);
        DBMS_OUTPUT.PUT_LINE('Tipo documento: ' || r.tipo_documento);
        DBMS_OUTPUT.PUT_LINE('Número documento: ' || r.numero_documento);
        DBMS_OUTPUT.PUT_LINE('Nacionalidad: ' || r.nacionalidad);
        DBMS_OUTPUT.PUT_LINE('Rol en incidente: ' || r.rol_en_incidente);
        DBMS_OUTPUT.PUT_LINE('Declaración: ' || r.declaracion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Involucrado no encontrado.');
    END get_involucrado;

    PROCEDURE update_involucrado(
        p_id_involucrado   IN NUMBER,
        p_id_incidente     IN NUMBER,
        p_tipo_persona     IN VARCHAR2,
        p_id_pasajero      IN NUMBER,
        p_id_tripulante    IN NUMBER,
        p_nombre_completo  IN VARCHAR2,
        p_tipo_documento   IN VARCHAR2,
        p_numero_documento IN VARCHAR2,
        p_nacionalidad     IN VARCHAR2,
        p_rol_en_incidente IN VARCHAR2,
        p_declaracion      IN VARCHAR2
    ) IS
    BEGIN
        UPDATE incidentes_involucrados
        SET id_incidente     = p_id_incidente,
            tipo_persona     = p_tipo_persona,
            id_pasajero      = p_id_pasajero,
            id_tripulante    = p_id_tripulante,
            nombre_completo  = p_nombre_completo,
            tipo_documento   = p_tipo_documento,
            numero_documento = p_numero_documento,
            nacionalidad     = p_nacionalidad,
            rol_en_incidente = p_rol_en_incidente,
            declaracion      = p_declaracion
        WHERE id_involucrado = p_id_involucrado;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23602, 'No se encontró el involucrado para actualizar.');
        END IF;
    END update_involucrado;

    PROCEDURE delete_involucrado(
        p_id_involucrado IN NUMBER
    ) IS
    BEGIN
        DELETE FROM incidentes_involucrados
        WHERE id_involucrado = p_id_involucrado;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23603, 'No se encontró el involucrado para eliminar.');
        END IF;
    END delete_involucrado;

END pkg_incidentes_involucrados;
/