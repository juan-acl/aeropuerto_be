------------------------------------------------------------
-- Paquete CRUD para la tabla ROLES_PERMISOS_MODULOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_roles_permisos_modulos AS
    PROCEDURE insert_permiso(
        p_id_rol_sistema    IN NUMBER,
        p_id_modulo_sistema IN NUMBER,
        p_permiso_lectura   IN NUMBER DEFAULT 0,
        p_permiso_escritura IN NUMBER DEFAULT 0,
        p_permiso_eliminacion IN NUMBER DEFAULT 0,
        p_permiso_ejecucion IN NUMBER DEFAULT 0
    );

    PROCEDURE get_permiso(
        p_id_rol_sistema    IN NUMBER,
        p_id_modulo_sistema IN NUMBER
    );

    PROCEDURE update_permiso(
        p_id_rol_sistema    IN NUMBER,
        p_id_modulo_sistema IN NUMBER,
        p_permiso_lectura   IN NUMBER,
        p_permiso_escritura IN NUMBER,
        p_permiso_eliminacion IN NUMBER,
        p_permiso_ejecucion IN NUMBER
    );

    PROCEDURE delete_permiso(
        p_id_rol_sistema    IN NUMBER,
        p_id_modulo_sistema IN NUMBER
    );
END pkg_roles_permisos_modulos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_roles_permisos_modulos AS

    PROCEDURE insert_permiso(
        p_id_rol_sistema    IN NUMBER,
        p_id_modulo_sistema IN NUMBER,
        p_permiso_lectura   IN NUMBER,
        p_permiso_escritura IN NUMBER,
        p_permiso_eliminacion IN NUMBER,
        p_permiso_ejecucion IN NUMBER
    ) IS
    BEGIN
        INSERT INTO roles_permisos_modulos (
            id_rol_sistema, id_modulo_sistema,
            permiso_lectura, permiso_escritura,
            permiso_eliminacion, permiso_ejecucion
        ) VALUES (
            p_id_rol_sistema, p_id_modulo_sistema,
            NVL(p_permiso_lectura,0), NVL(p_permiso_escritura,0),
            NVL(p_permiso_eliminacion,0), NVL(p_permiso_ejecucion,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32301, 'Error al insertar permisos de rol: ' || SQLERRM);
    END insert_permiso;

    PROCEDURE get_permiso(
        p_id_rol_sistema    IN NUMBER,
        p_id_modulo_sistema IN NUMBER
    ) IS
        r roles_permisos_modulos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM roles_permisos_modulos
        WHERE id_rol_sistema = p_id_rol_sistema
          AND id_modulo_sistema = p_id_modulo_sistema;

        DBMS_OUTPUT.PUT_LINE('Rol: ' || r.id_rol_sistema);
        DBMS_OUTPUT.PUT_LINE('Módulo: ' || r.id_modulo_sistema);
        DBMS_OUTPUT.PUT_LINE('Permiso lectura: ' || r.permiso_lectura);
        DBMS_OUTPUT.PUT_LINE('Permiso escritura: ' || r.permiso_escritura);
        DBMS_OUTPUT.PUT_LINE('Permiso eliminación: ' || r.permiso_eliminacion);
        DBMS_OUTPUT.PUT_LINE('Permiso ejecución: ' || r.permiso_ejecucion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Permisos no encontrados para el rol y módulo especificados.');
    END get_permiso;

    PROCEDURE update_permiso(
        p_id_rol_sistema    IN NUMBER,
        p_id_modulo_sistema IN NUMBER,
        p_permiso_lectura   IN NUMBER,
        p_permiso_escritura IN NUMBER,
        p_permiso_eliminacion IN NUMBER,
        p_permiso_ejecucion IN NUMBER
    ) IS
    BEGIN
        UPDATE roles_permisos_modulos
        SET permiso_lectura   = p_permiso_lectura,
            permiso_escritura = p_permiso_escritura,
            permiso_eliminacion = p_permiso_eliminacion,
            permiso_ejecucion = p_permiso_ejecucion
        WHERE id_rol_sistema = p_id_rol_sistema
          AND id_modulo_sistema = p_id_modulo_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32302, 'No se encontró el permiso para actualizar.');
        END IF;
    END update_permiso;

    PROCEDURE delete_permiso(
        p_id_rol_sistema    IN NUMBER,
        p_id_modulo_sistema IN NUMBER
    ) IS
    BEGIN
        DELETE FROM roles_permisos_modulos
        WHERE id_rol_sistema = p_id_rol_sistema
          AND id_modulo_sistema = p_id_modulo_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32303, 'No se encontró el permiso para eliminar.');
        END IF;
    END delete_permiso;

END pkg_roles_permisos_modulos;
/
