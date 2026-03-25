------------------------------------------------------------
-- Paquete CRUD para la tabla TRIPULACION_CERTIFICACIONES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tripulacion_certificaciones AS
    PROCEDURE insert_certificacion(
        p_id_tripulante        IN tripulacion_certificaciones.id_tripulante%TYPE,
        p_tipo_certificacion   IN tripulacion_certificaciones.tipo_certificacion%TYPE,
        p_fecha_obtencion      IN tripulacion_certificaciones.fecha_obtencion%TYPE,
        p_fecha_vencimiento    IN tripulacion_certificaciones.fecha_vencimiento%TYPE,
        p_entidad_certificadora IN tripulacion_certificaciones.entidad_certificadora%TYPE,
        p_activa               IN tripulacion_certificaciones.activa%TYPE DEFAULT 1
    );

    PROCEDURE get_certificacion(
        p_id_certificacion IN tripulacion_certificaciones.id_certificacion%TYPE
    );

    PROCEDURE update_certificacion(
        p_id_certificacion     IN tripulacion_certificaciones.id_certificacion%TYPE,
        p_id_tripulante        IN tripulacion_certificaciones.id_tripulante%TYPE,
        p_tipo_certificacion   IN tripulacion_certificaciones.tipo_certificacion%TYPE,
        p_fecha_obtencion      IN tripulacion_certificaciones.fecha_obtencion%TYPE,
        p_fecha_vencimiento    IN tripulacion_certificaciones.fecha_vencimiento%TYPE,
        p_entidad_certificadora IN tripulacion_certificaciones.entidad_certificadora%TYPE,
        p_activa               IN tripulacion_certificaciones.activa%TYPE
    );

    PROCEDURE delete_certificacion(
        p_id_certificacion IN tripulacion_certificaciones.id_certificacion%TYPE
    );
END pkg_tripulacion_certificaciones;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tripulacion_certificaciones AS

    PROCEDURE insert_certificacion(
        p_id_tripulante        IN tripulacion_certificaciones.id_tripulante%TYPE,
        p_tipo_certificacion   IN tripulacion_certificaciones.tipo_certificacion%TYPE,
        p_fecha_obtencion      IN tripulacion_certificaciones.fecha_obtencion%TYPE,
        p_fecha_vencimiento    IN tripulacion_certificaciones.fecha_vencimiento%TYPE,
        p_entidad_certificadora IN tripulacion_certificaciones.entidad_certificadora%TYPE,
        p_activa               IN tripulacion_certificaciones.activa%TYPE
    ) IS
    BEGIN
        INSERT INTO tripulacion_certificaciones (
            id_tripulante, tipo_certificacion, fecha_obtencion,
            fecha_vencimiento, entidad_certificadora, activa
        ) VALUES (
            p_id_tripulante, p_tipo_certificacion, p_fecha_obtencion,
            p_fecha_vencimiento, p_entidad_certificadora, NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-21501, 'Error al insertar certificación: ' || SQLERRM);
    END insert_certificacion;

    PROCEDURE get_certificacion(
        p_id_certificacion IN tripulacion_certificaciones.id_certificacion%TYPE
    ) IS
        r tripulacion_certificaciones%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM tripulacion_certificaciones
        WHERE id_certificacion = p_id_certificacion;

        DBMS_OUTPUT.PUT_LINE('ID Certificación: ' || r.id_certificacion);
        DBMS_OUTPUT.PUT_LINE('Tripulante: ' || r.id_tripulante);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_certificacion);
        DBMS_OUTPUT.PUT_LINE('Fecha obtención: ' || r.fecha_obtencion);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento);
        DBMS_OUTPUT.PUT_LINE('Entidad certificadora: ' || r.entidad_certificadora);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Certificación no encontrada.');
    END get_certificacion;

    PROCEDURE update_certificacion(
        p_id_certificacion     IN tripulacion_certificaciones.id_certificacion%TYPE,
        p_id_tripulante        IN tripulacion_certificaciones.id_tripulante%TYPE,
        p_tipo_certificacion   IN tripulacion_certificaciones.tipo_certificacion%TYPE,
        p_fecha_obtencion      IN tripulacion_certificaciones.fecha_obtencion%TYPE,
        p_fecha_vencimiento    IN tripulacion_certificaciones.fecha_vencimiento%TYPE,
        p_entidad_certificadora IN tripulacion_certificaciones.entidad_certificadora%TYPE,
        p_activa               IN tripulacion_certificaciones.activa%TYPE
    ) IS
    BEGIN
        UPDATE tripulacion_certificaciones
        SET id_tripulante        = p_id_tripulante,
            tipo_certificacion   = p_tipo_certificacion,
            fecha_obtencion      = p_fecha_obtencion,
            fecha_vencimiento    = p_fecha_vencimiento,
            entidad_certificadora = p_entidad_certificadora,
            activa               = p_activa
        WHERE id_certificacion = p_id_certificacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21502, 'No se encontró la certificación para actualizar.');
        END IF;
    END update_certificacion;

    PROCEDURE delete_certificacion(
        p_id_certificacion IN tripulacion_certificaciones.id_certificacion%TYPE
    ) IS
    BEGIN
        DELETE FROM tripulacion_certificaciones
        WHERE id_certificacion = p_id_certificacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-21503, 'No se encontró la certificación para eliminar.');
        END IF;
    END delete_certificacion;

END pkg_tripulacion_certificaciones;
/