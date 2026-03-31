------------------------------------------------------------
-- Paquete CRUD para la tabla RECLAMACIONES_OBJETOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_reclamaciones_objetos AS
    PROCEDURE insert_reclamacion(
        p_id_pasajero           IN NUMBER,
        p_id_objeto             IN NUMBER,
        p_fecha_reclamacion     IN TIMESTAMP,
        p_descripcion_reclamacion IN VARCHAR2,
        p_estado                IN VARCHAR2 DEFAULT 'PENDIENTE',
        p_fecha_resolucion      IN TIMESTAMP,
        p_resolucion            IN VARCHAR2,
        p_resuelto_por          IN VARCHAR2
    );

    PROCEDURE get_reclamacion(
        p_id_reclamacion IN NUMBER
    );

    PROCEDURE update_reclamacion(
        p_id_reclamacion        IN NUMBER,
        p_id_pasajero           IN NUMBER,
        p_id_objeto             IN NUMBER,
        p_fecha_reclamacion     IN TIMESTAMP,
        p_descripcion_reclamacion IN VARCHAR2,
        p_estado                IN VARCHAR2,
        p_fecha_resolucion      IN TIMESTAMP,
        p_resolucion            IN VARCHAR2,
        p_resuelto_por          IN VARCHAR2
    );

    PROCEDURE delete_reclamacion(
        p_id_reclamacion IN NUMBER
    );
END pkg_reclamaciones_objetos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_reclamaciones_objetos AS

    PROCEDURE insert_reclamacion(
        p_id_pasajero           IN NUMBER,
        p_id_objeto             IN NUMBER,
        p_fecha_reclamacion     IN TIMESTAMP,
        p_descripcion_reclamacion IN VARCHAR2,
        p_estado                IN VARCHAR2,
        p_fecha_resolucion      IN TIMESTAMP,
        p_resolucion            IN VARCHAR2,
        p_resuelto_por          IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO reclamaciones_objetos (
            id_pasajero, id_objeto, fecha_reclamacion,
            descripcion_reclamacion, estado, fecha_resolucion,
            resolucion, resuelto_por
        ) VALUES (
            p_id_pasajero, p_id_objeto, p_fecha_reclamacion,
            p_descripcion_reclamacion, NVL(p_estado,'PENDIENTE'),
            p_fecha_resolucion, p_resolucion, p_resuelto_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24601, 'Error al insertar reclamación de objeto: ' || SQLERRM);
    END insert_reclamacion;

    PROCEDURE get_reclamacion(
        p_id_reclamacion IN NUMBER
    ) IS
        r reclamaciones_objetos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM reclamaciones_objetos
        WHERE id_reclamacion = p_id_reclamacion;

        DBMS_OUTPUT.PUT_LINE('ID Reclamación: ' || r.id_reclamacion);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Objeto: ' || r.id_objeto);
        DBMS_OUTPUT.PUT_LINE('Fecha reclamación: ' || r.fecha_reclamacion);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion_reclamacion);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Fecha resolución: ' || r.fecha_resolucion);
        DBMS_OUTPUT.PUT_LINE('Resolución: ' || r.resolucion);
        DBMS_OUTPUT.PUT_LINE('Resuelto por: ' || r.resuelto_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Reclamación no encontrada.');
    END get_reclamacion;

    PROCEDURE update_reclamacion(
        p_id_reclamacion        IN NUMBER,
        p_id_pasajero           IN NUMBER,
        p_id_objeto             IN NUMBER,
        p_fecha_reclamacion     IN TIMESTAMP,
        p_descripcion_reclamacion IN VARCHAR2,
        p_estado                IN VARCHAR2,
        p_fecha_resolucion      IN TIMESTAMP,
        p_resolucion            IN VARCHAR2,
        p_resuelto_por          IN VARCHAR2
    ) IS
    BEGIN
        UPDATE reclamaciones_objetos
        SET id_pasajero           = p_id_pasajero,
            id_objeto             = p_id_objeto,
            fecha_reclamacion     = p_fecha_reclamacion,
            descripcion_reclamacion = p_descripcion_reclamacion,
            estado                = p_estado,
            fecha_resolucion      = p_fecha_resolucion,
            resolucion            = p_resolucion,
            resuelto_por          = p_resuelto_por
        WHERE id_reclamacion = p_id_reclamacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24602, 'No se encontró la reclamación para actualizar.');
        END IF;
    END update_reclamacion;

    PROCEDURE delete_reclamacion(
        p_id_reclamacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM reclamaciones_objetos
        WHERE id_reclamacion = p_id_reclamacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24603, 'No se encontró la reclamación para eliminar.');
        END IF;
    END delete_reclamacion;

END pkg_reclamaciones_objetos;
/