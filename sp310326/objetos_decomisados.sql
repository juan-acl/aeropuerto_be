------------------------------------------------------------
-- Paquete CRUD para la tabla OBJETOS_DECOMISADOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_objetos_decomisados AS
    PROCEDURE insert_decomiso(
        p_id_control       IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_tipo_objeto      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_cantidad         IN NUMBER,
        p_motivo_decomiso  IN VARCHAR2,
        p_destino_final    IN VARCHAR2,
        p_fecha_registro   IN TIMESTAMP,
        p_registrado_por   IN VARCHAR2
    );

    PROCEDURE get_decomiso(
        p_id_decomiso IN NUMBER
    );

    PROCEDURE update_decomiso(
        p_id_decomiso      IN NUMBER,
        p_id_control       IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_tipo_objeto      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_cantidad         IN NUMBER,
        p_motivo_decomiso  IN VARCHAR2,
        p_destino_final    IN VARCHAR2,
        p_fecha_registro   IN TIMESTAMP,
        p_registrado_por   IN VARCHAR2
    );

    PROCEDURE delete_decomiso(
        p_id_decomiso IN NUMBER
    );
END pkg_objetos_decomisados;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_objetos_decomisados AS

    PROCEDURE insert_decomiso(
        p_id_control       IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_tipo_objeto      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_cantidad         IN NUMBER,
        p_motivo_decomiso  IN VARCHAR2,
        p_destino_final    IN VARCHAR2,
        p_fecha_registro   IN TIMESTAMP,
        p_registrado_por   IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO objetos_decomisados (
            id_control, id_pasajero, tipo_objeto, descripcion,
            cantidad, motivo_decomiso, destino_final,
            fecha_registro, registrado_por
        ) VALUES (
            p_id_control, p_id_pasajero, p_tipo_objeto, p_descripcion,
            p_cantidad, p_motivo_decomiso, p_destino_final,
            p_fecha_registro, p_registrado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24201, 'Error al insertar objeto decomisado: ' || SQLERRM);
    END insert_decomiso;

    PROCEDURE get_decomiso(
        p_id_decomiso IN NUMBER
    ) IS
        r objetos_decomisados%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM objetos_decomisados
        WHERE id_decomiso = p_id_decomiso;

        DBMS_OUTPUT.PUT_LINE('ID Decomiso: ' || r.id_decomiso);
        DBMS_OUTPUT.PUT_LINE('Control: ' || r.id_control);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Tipo objeto: ' || r.tipo_objeto);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Cantidad: ' || r.cantidad);
        DBMS_OUTPUT.PUT_LINE('Motivo decomiso: ' || r.motivo_decomiso);
        DBMS_OUTPUT.PUT_LINE('Destino final: ' || r.destino_final);
        DBMS_OUTPUT.PUT_LINE('Fecha registro: ' || r.fecha_registro);
        DBMS_OUTPUT.PUT_LINE('Registrado por: ' || r.registrado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Objeto decomisado no encontrado.');
    END get_decomiso;

    PROCEDURE update_decomiso(
        p_id_decomiso      IN NUMBER,
        p_id_control       IN NUMBER,
        p_id_pasajero      IN NUMBER,
        p_tipo_objeto      IN VARCHAR2,
        p_descripcion      IN VARCHAR2,
        p_cantidad         IN NUMBER,
        p_motivo_decomiso  IN VARCHAR2,
        p_destino_final    IN VARCHAR2,
        p_fecha_registro   IN TIMESTAMP,
        p_registrado_por   IN VARCHAR2
    ) IS
    BEGIN
        UPDATE objetos_decomisados
        SET id_control       = p_id_control,
            id_pasajero      = p_id_pasajero,
            tipo_objeto      = p_tipo_objeto,
            descripcion      = p_descripcion,
            cantidad         = p_cantidad,
            motivo_decomiso  = p_motivo_decomiso,
            destino_final    = p_destino_final,
            fecha_registro   = p_fecha_registro,
            registrado_por   = p_registrado_por
        WHERE id_decomiso = p_id_decomiso;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24202, 'No se encontró el objeto decomisado para actualizar.');
        END IF;
    END update_decomiso;

    PROCEDURE delete_decomiso(
        p_id_decomiso IN NUMBER
    ) IS
    BEGIN
        DELETE FROM objetos_decomisados
        WHERE id_decomiso = p_id_decomiso;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24203, 'No se encontró el objeto decomisado para eliminar.');
        END IF;
    END delete_decomiso;

END pkg_objetos_decomisados;
/