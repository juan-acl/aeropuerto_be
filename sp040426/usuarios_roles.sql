------------------------------------------------------------
-- Paquete CRUD para la tabla USUARIOS_ROLES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_usuarios_roles AS
    PROCEDURE insert_usuario_rol(
        p_id_usuario_sistema IN NUMBER,
        p_id_rol_sistema     IN NUMBER,
        p_fecha_asignacion   IN DATE DEFAULT SYSDATE,
        p_asignado_por       IN NUMBER,
        p_activo             IN NUMBER DEFAULT 1
    );

    PROCEDURE get_usuario_rol(
        p_id_usuario_sistema IN NUMBER,
        p_id_rol_sistema     IN NUMBER
    );

    PROCEDURE update_usuario_rol(
        p_id_usuario_sistema IN NUMBER,
        p_id_rol_sistema     IN NUMBER,
        p_fecha_asignacion   IN DATE,
        p_asignado_por       IN NUMBER,
        p_activo             IN NUMBER
    );

    PROCEDURE delete_usuario_rol(
        p_id_usuario_sistema IN NUMBER,
        p_id_rol_sistema     IN NUMBER
    );
END pkg_usuarios_roles;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_usuarios_roles AS

    PROCEDURE insert_usuario_rol(
        p_id_usuario_sistema IN NUMBER,
        p_id_rol_sistema     IN NUMBER,
        p_fecha_asignacion   IN DATE,
        p_asignado_por       IN NUMBER,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        INSERT INTO usuarios_roles (
            id_usuario_sistema, id_rol_sistema, fecha_asignacion,
            asignado_por, activo
        ) VALUES (
            p_id_usuario_sistema, p_id_rol_sistema, NVL(p_fecha_asignacion, SYSDATE),
            p_asignado_por, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32101, 'Error al insertar asignación de rol: ' || SQLERRM);
    END insert_usuario_rol;

    PROCEDURE get_usuario_rol(
        p_id_usuario_sistema IN NUMBER,
        p_id_rol_sistema     IN NUMBER
    ) IS
        r usuarios_roles%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM usuarios_roles
        WHERE id_usuario_sistema = p_id_usuario_sistema
          AND id_rol_sistema     = p_id_rol_sistema;

        DBMS_OUTPUT.PUT_LINE('Usuario: ' || r.id_usuario_sistema);
        DBMS_OUTPUT.PUT_LINE('Rol: ' || r.id_rol_sistema);
        DBMS_OUTPUT.PUT_LINE('Fecha asignación: ' || r.fecha_asignacion);
        DBMS_OUTPUT.PUT_LINE('Asignado por: ' || r.asignado_por);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Asignación de rol no encontrada.');
    END get_usuario_rol;

    PROCEDURE update_usuario_rol(
        p_id_usuario_sistema IN NUMBER,
        p_id_rol_sistema     IN NUMBER,
        p_fecha_asignacion   IN DATE,
        p_asignado_por       IN NUMBER,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        UPDATE usuarios_roles
        SET fecha_asignacion = p_fecha_asignacion,
            asignado_por     = p_asignado_por,
            activo           = p_activo
        WHERE id_usuario_sistema = p_id_usuario_sistema
          AND id_rol_sistema     = p_id_rol_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32102, 'No se encontró la asignación de rol para actualizar.');
        END IF;
    END update_usuario_rol;

    PROCEDURE delete_usuario_rol(
        p_id_usuario_sistema IN NUMBER,
        p_id_rol_sistema     IN NUMBER
    ) IS
    BEGIN
        DELETE FROM usuarios_roles
        WHERE id_usuario_sistema = p_id_usuario_sistema
          AND id_rol_sistema     = p_id_rol_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32103, 'No se encontró la asignación de rol para eliminar.');
        END IF;
    END delete_usuario_rol;

END pkg_usuarios_roles;
/
