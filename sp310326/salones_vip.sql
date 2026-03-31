------------------------------------------------------------
-- Paquete CRUD para la tabla SALONES_VIP
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_salones_vip AS
    PROCEDURE insert_salon(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_nombre_salon        IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_capacidad           IN NUMBER,
        p_horario_apertura    IN VARCHAR2,
        p_horario_cierre      IN VARCHAR2,
        p_servicios           IN VARCHAR2,
        p_requisitos_acceso   IN VARCHAR2,
        p_activo              IN NUMBER DEFAULT 1
    );

    PROCEDURE get_salon(
        p_id_salon IN NUMBER
    );

    PROCEDURE update_salon(
        p_id_salon            IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_nombre_salon        IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_capacidad           IN NUMBER,
        p_horario_apertura    IN VARCHAR2,
        p_horario_cierre      IN VARCHAR2,
        p_servicios           IN VARCHAR2,
        p_requisitos_acceso   IN VARCHAR2,
        p_activo              IN NUMBER
    );

    PROCEDURE delete_salon(
        p_id_salon IN NUMBER
    );
END pkg_salones_vip;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_salones_vip AS

    PROCEDURE insert_salon(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_nombre_salon        IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_capacidad           IN NUMBER,
        p_horario_apertura    IN VARCHAR2,
        p_horario_cierre      IN VARCHAR2,
        p_servicios           IN VARCHAR2,
        p_requisitos_acceso   IN VARCHAR2,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO salones_vip (
            codigo_aeropuerto, nombre_salon, ubicacion, capacidad,
            horario_apertura, horario_cierre, servicios,
            requisitos_acceso, activo
        ) VALUES (
            p_codigo_aeropuerto, p_nombre_salon, p_ubicacion, p_capacidad,
            p_horario_apertura, p_horario_cierre, p_servicios,
            p_requisitos_acceso, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25201, 'Error al insertar salón VIP: ' || SQLERRM);
    END insert_salon;

    PROCEDURE get_salon(
        p_id_salon IN NUMBER
    ) IS
        r salones_vip%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM salones_vip
        WHERE id_salon = p_id_salon;

        DBMS_OUTPUT.PUT_LINE('ID Salón: ' || r.id_salon);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Nombre salón: ' || r.nombre_salon);
        DBMS_OUTPUT.PUT_LINE('Ubicación: ' || r.ubicacion);
        DBMS_OUTPUT.PUT_LINE('Capacidad: ' || r.capacidad);
        DBMS_OUTPUT.PUT_LINE('Horario apertura: ' || r.horario_apertura);
        DBMS_OUTPUT.PUT_LINE('Horario cierre: ' || r.horario_cierre);
        DBMS_OUTPUT.PUT_LINE('Servicios: ' || r.servicios);
        DBMS_OUTPUT.PUT_LINE('Requisitos acceso: ' || r.requisitos_acceso);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Salón VIP no encontrado.');
    END get_salon;

    PROCEDURE update_salon(
        p_id_salon            IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_nombre_salon        IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_capacidad           IN NUMBER,
        p_horario_apertura    IN VARCHAR2,
        p_horario_cierre      IN VARCHAR2,
        p_servicios           IN VARCHAR2,
        p_requisitos_acceso   IN VARCHAR2,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        UPDATE salones_vip
        SET codigo_aeropuerto   = p_codigo_aeropuerto,
            nombre_salon        = p_nombre_salon,
            ubicacion           = p_ubicacion,
            capacidad           = p_capacidad,
            horario_apertura    = p_horario_apertura,
            horario_cierre      = p_horario_cierre,
            servicios           = p_servicios,
            requisitos_acceso   = p_requisitos_acceso,
            activo              = p_activo
        WHERE id_salon = p_id_salon;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25202, 'No se encontró el salón VIP para actualizar.');
        END IF;
    END update_salon;

    PROCEDURE delete_salon(
        p_id_salon IN NUMBER
    ) IS
    BEGIN
        DELETE FROM salones_vip
        WHERE id_salon = p_id_salon;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25203, 'No se encontró el salón VIP para eliminar.');
        END IF;
    END delete_salon;

END pkg_salones_vip;
/