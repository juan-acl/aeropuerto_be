------------------------------------------------------------
-- Paquete CRUD para la tabla PASAJEROS_MENORES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pasajeros_menores AS
    PROCEDURE insert_relacion(
        p_id_menor               IN NUMBER,
        p_id_acompanante         IN NUMBER,
        p_tipo_relacion          IN VARCHAR2,
        p_autorizado             IN NUMBER DEFAULT 0,
        p_documento_autorizacion IN BLOB
    );

    PROCEDURE get_relacion(
        p_id_relacion IN NUMBER
    );

    PROCEDURE update_relacion(
        p_id_relacion            IN NUMBER,
        p_id_menor               IN NUMBER,
        p_id_acompanante         IN NUMBER,
        p_tipo_relacion          IN VARCHAR2,
        p_autorizado             IN NUMBER,
        p_documento_autorizacion IN BLOB
    );

    PROCEDURE delete_relacion(
        p_id_relacion IN NUMBER
    );
END pkg_pasajeros_menores;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pasajeros_menores AS

    PROCEDURE insert_relacion(
        p_id_menor               IN NUMBER,
        p_id_acompanante         IN NUMBER,
        p_tipo_relacion          IN VARCHAR2,
        p_autorizado             IN NUMBER,
        p_documento_autorizacion IN BLOB
    ) IS
    BEGIN
        INSERT INTO pasajeros_menores (
            id_menor, id_acompanante, tipo_relacion,
            autorizado, documento_autorizacion
        ) VALUES (
            p_id_menor, p_id_acompanante, p_tipo_relacion,
            NVL(p_autorizado,0), p_documento_autorizacion
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28301, 'Error al insertar relación de pasajero menor: ' || SQLERRM);
    END insert_relacion;

    PROCEDURE get_relacion(
        p_id_relacion IN NUMBER
    ) IS
        r pasajeros_menores%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM pasajeros_menores
        WHERE id_relacion = p_id_relacion;

        DBMS_OUTPUT.PUT_LINE('ID Relación: ' || r.id_relacion);
        DBMS_OUTPUT.PUT_LINE('Menor: ' || r.id_menor);
        DBMS_OUTPUT.PUT_LINE('Acompañante: ' || r.id_acompanante);
        DBMS_OUTPUT.PUT_LINE('Tipo relación: ' || r.tipo_relacion);
        DBMS_OUTPUT.PUT_LINE('Autorizado: ' || r.autorizado);
        IF r.documento_autorizacion IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento autorización: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento autorización: No adjunto');
        END IF;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Relación de pasajero menor no encontrada.');
    END get_relacion;

    PROCEDURE update_relacion(
        p_id_relacion            IN NUMBER,
        p_id_menor               IN NUMBER,
        p_id_acompanante         IN NUMBER,
        p_tipo_relacion          IN VARCHAR2,
        p_autorizado             IN NUMBER,
        p_documento_autorizacion IN BLOB
    ) IS
    BEGIN
        UPDATE pasajeros_menores
        SET id_menor               = p_id_menor,
            id_acompanante         = p_id_acompanante,
            tipo_relacion          = p_tipo_relacion,
            autorizado             = p_autorizado,
            documento_autorizacion = p_documento_autorizacion
        WHERE id_relacion = p_id_relacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28302, 'No se encontró la relación de pasajero menor para actualizar.');
        END IF;
    END update_relacion;

    PROCEDURE delete_relacion(
        p_id_relacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM pasajeros_menores
        WHERE id_relacion = p_id_relacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28303, 'No se encontró la relación de pasajero menor para eliminar.');
        END IF;
    END delete_relacion;

END pkg_pasajeros_menores;
/
