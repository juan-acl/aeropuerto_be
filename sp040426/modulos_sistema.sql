------------------------------------------------------------
-- Paquete CRUD para la tabla MODULOS_SISTEMA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_modulos_sistema AS
    PROCEDURE insert_modulo(
        p_nombre_modulo IN VARCHAR2,
        p_descripcion   IN VARCHAR2,
        p_ruta_acceso   IN VARCHAR2,
        p_icono         IN VARCHAR2,
        p_orden         IN NUMBER,
        p_activo        IN NUMBER DEFAULT 1
    );

    PROCEDURE get_modulo(
        p_id_modulo_sistema IN NUMBER
    );

    PROCEDURE update_modulo(
        p_id_modulo_sistema IN NUMBER,
        p_nombre_modulo     IN VARCHAR2,
        p_descripcion       IN VARCHAR2,
        p_ruta_acceso       IN VARCHAR2,
        p_icono             IN VARCHAR2,
        p_orden             IN NUMBER,
        p_activo            IN NUMBER
    );

    PROCEDURE delete_modulo(
        p_id_modulo_sistema IN NUMBER
    );
END pkg_modulos_sistema;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_modulos_sistema AS

    PROCEDURE insert_modulo(
        p_nombre_modulo IN VARCHAR2,
        p_descripcion   IN VARCHAR2,
        p_ruta_acceso   IN VARCHAR2,
        p_icono         IN VARCHAR2,
        p_orden         IN NUMBER,
        p_activo        IN NUMBER
    ) IS
    BEGIN
        INSERT INTO modulos_sistema (
            nombre_modulo, descripcion, ruta_acceso,
            icono, orden, activo
        ) VALUES (
            p_nombre_modulo, p_descripcion, p_ruta_acceso,
            p_icono, p_orden, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-32201, 'Error al insertar módulo del sistema: ' || SQLERRM);
    END insert_modulo;

    PROCEDURE get_modulo(
        p_id_modulo_sistema IN NUMBER
    ) IS
        r modulos_sistema%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM modulos_sistema
        WHERE id_modulo_sistema = p_id_modulo_sistema;

        DBMS_OUTPUT.PUT_LINE('ID Módulo: ' || r.id_modulo_sistema);
        DBMS_OUTPUT.PUT_LINE('Nombre módulo: ' || r.nombre_modulo);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Ruta acceso: ' || r.ruta_acceso);
        DBMS_OUTPUT.PUT_LINE('Ícono: ' || r.icono);
        DBMS_OUTPUT.PUT_LINE('Orden: ' || r.orden);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Módulo del sistema no encontrado.');
    END get_modulo;

    PROCEDURE update_modulo(
        p_id_modulo_sistema IN NUMBER,
        p_nombre_modulo     IN VARCHAR2,
        p_descripcion       IN VARCHAR2,
        p_ruta_acceso       IN VARCHAR2,
        p_icono             IN VARCHAR2,
        p_orden             IN NUMBER,
        p_activo            IN NUMBER
    ) IS
    BEGIN
        UPDATE modulos_sistema
        SET nombre_modulo = p_nombre_modulo,
            descripcion   = p_descripcion,
            ruta_acceso   = p_ruta_acceso,
            icono         = p_icono,
            orden         = p_orden,
            activo        = p_activo
        WHERE id_modulo_sistema = p_id_modulo_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32202, 'No se encontró el módulo del sistema para actualizar.');
        END IF;
    END update_modulo;

    PROCEDURE delete_modulo(
        p_id_modulo_sistema IN NUMBER
    ) IS
    BEGIN
        DELETE FROM modulos_sistema
        WHERE id_modulo_sistema = p_id_modulo_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-32203, 'No se encontró el módulo del sistema para eliminar.');
        END IF;
    END delete_modulo;

END pkg_modulos_sistema;
/
