------------------------------------------------------------
-- Paquete CRUD para la tabla ROLES_SISTEMA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_roles_sistema AS
    PROCEDURE insert_rol(
        p_nombre_rol      IN VARCHAR2,
        p_descripcion     IN VARCHAR2,
        p_nivel_jerarquico IN NUMBER,
        p_activo          IN NUMBER DEFAULT 1
    );

    PROCEDURE get_rol(
        p_id_rol_sistema IN NUMBER
    );

    PROCEDURE update_rol(
        p_id_rol_sistema  IN NUMBER,
        p_nombre_rol      IN VARCHAR2,
        p_descripcion     IN VARCHAR2,
        p_nivel_jerarquico IN NUMBER,
        p_activo          IN NUMBER
    );

    PROCEDURE delete_rol(
        p_id_rol_sistema IN NUMBER
    );
END pkg_roles_sistema;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_roles_sistema AS

    PROCEDURE insert_rol(
        p_nombre_rol      IN VARCHAR2,
        p_descripcion     IN VARCHAR2,
        p_nivel_jerarquico IN NUMBER,
        p_activo          IN NUMBER
    ) IS
    BEGIN
        INSERT INTO roles_sistema (
            nombre_rol, descripcion, nivel_jerarquico, activo
        ) VALUES (
            p_nombre_rol, p_descripcion, p_nivel_jerarquico, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32001, 'Error al insertar rol del sistema: ' || SQLERRM);
    END insert_rol;

    PROCEDURE get_rol(
        p_id_rol_sistema IN NUMBER
    ) IS
        r roles_sistema%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM roles_sistema
        WHERE id_rol_sistema = p_id_rol_sistema;

        DBMS_OUTPUT.PUT_LINE('ID Rol: ' || r.id_rol_sistema);
        DBMS_OUTPUT.PUT_LINE('Nombre rol: ' || r.nombre_rol);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Nivel jerárquico: ' || r.nivel_jerarquico);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Rol del sistema no encontrado.');
    END get_rol;

    PROCEDURE update_rol(
        p_id_rol_sistema  IN NUMBER,
        p_nombre_rol      IN VARCHAR2,
        p_descripcion     IN VARCHAR2,
        p_nivel_jerarquico IN NUMBER,
        p_activo          IN NUMBER
    ) IS
    BEGIN
        UPDATE roles_sistema
        SET nombre_rol      = p_nombre_rol,
            descripcion     = p_descripcion,
            nivel_jerarquico = p_nivel_jerarquico,
            activo          = p_activo
        WHERE id_rol_sistema = p_id_rol_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32002, 'No se encontró el rol del sistema para actualizar.');
        END IF;
    END update_rol;

    PROCEDURE delete_rol(
        p_id_rol_sistema IN NUMBER
    ) IS
    BEGIN
        DELETE FROM roles_sistema
        WHERE id_rol_sistema = p_id_rol_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32003, 'No se encontró el rol del sistema para eliminar.');
        END IF;
    END delete_rol;

END pkg_roles_sistema;
/
