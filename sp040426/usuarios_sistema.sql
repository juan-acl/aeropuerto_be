------------------------------------------------------------
-- Paquete CRUD para la tabla USUARIOS_SISTEMA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_usuarios_sistema AS
    PROCEDURE insert_usuario(
        p_id_empleado              IN NUMBER,
        p_nombre_usuario           IN VARCHAR2,
        p_password_hash            IN VARCHAR2,
        p_email_institucional      IN VARCHAR2,
        p_fecha_creacion           IN DATE DEFAULT SYSDATE,
        p_fecha_ultimo_acceso      IN TIMESTAMP,
        p_fecha_vencimiento_password IN DATE,
        p_intentos_fallidos        IN NUMBER DEFAULT 0,
        p_bloqueado                IN NUMBER DEFAULT 0,
        p_motivo_bloqueo           IN VARCHAR2,
        p_requiere_cambio_password IN NUMBER DEFAULT 0,
        p_activo                   IN NUMBER DEFAULT 1,
        p_creado_por               IN NUMBER
    );

    PROCEDURE get_usuario(
        p_id_usuario_sistema IN NUMBER
    );

    PROCEDURE update_usuario(
        p_id_usuario_sistema       IN NUMBER,
        p_id_empleado              IN NUMBER,
        p_nombre_usuario           IN VARCHAR2,
        p_password_hash            IN VARCHAR2,
        p_email_institucional      IN VARCHAR2,
        p_fecha_creacion           IN DATE,
        p_fecha_ultimo_acceso      IN TIMESTAMP,
        p_fecha_vencimiento_password IN DATE,
        p_intentos_fallidos        IN NUMBER,
        p_bloqueado                IN NUMBER,
        p_motivo_bloqueo           IN VARCHAR2,
        p_requiere_cambio_password IN NUMBER,
        p_activo                   IN NUMBER,
        p_creado_por               IN NUMBER
    );

    PROCEDURE delete_usuario(
        p_id_usuario_sistema IN NUMBER
    );
END pkg_usuarios_sistema;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_usuarios_sistema AS

    PROCEDURE insert_usuario(
        p_id_empleado              IN NUMBER,
        p_nombre_usuario           IN VARCHAR2,
        p_password_hash            IN VARCHAR2,
        p_email_institucional      IN VARCHAR2,
        p_fecha_creacion           IN DATE,
        p_fecha_ultimo_acceso      IN TIMESTAMP,
        p_fecha_vencimiento_password IN DATE,
        p_intentos_fallidos        IN NUMBER,
        p_bloqueado                IN NUMBER,
        p_motivo_bloqueo           IN VARCHAR2,
        p_requiere_cambio_password IN NUMBER,
        p_activo                   IN NUMBER,
        p_creado_por               IN NUMBER
    ) IS
    BEGIN
        INSERT INTO usuarios_sistema (
            id_empleado, nombre_usuario, password_hash,
            email_institucional, fecha_creacion, fecha_ultimo_acceso,
            fecha_vencimiento_password, intentos_fallidos, bloqueado,
            motivo_bloqueo, requiere_cambio_password, activo, creado_por
        ) VALUES (
            p_id_empleado, p_nombre_usuario, p_password_hash,
            p_email_institucional, NVL(p_fecha_creacion, SYSDATE), p_fecha_ultimo_acceso,
            p_fecha_vencimiento_password, NVL(p_intentos_fallidos,0), NVL(p_bloqueado,0),
            p_motivo_bloqueo, NVL(p_requiere_cambio_password,0), NVL(p_activo,1), p_creado_por
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31901, 'Error al insertar usuario del sistema: ' || SQLERRM);
    END insert_usuario;

    PROCEDURE get_usuario(
        p_id_usuario_sistema IN NUMBER
    ) IS
        r usuarios_sistema%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM usuarios_sistema
        WHERE id_usuario_sistema = p_id_usuario_sistema;

        DBMS_OUTPUT.PUT_LINE('ID Usuario: ' || r.id_usuario_sistema);
        DBMS_OUTPUT.PUT_LINE('Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Nombre usuario: ' || r.nombre_usuario);
        DBMS_OUTPUT.PUT_LINE('Email institucional: ' || r.email_institucional);
        DBMS_OUTPUT.PUT_LINE('Fecha creación: ' || r.fecha_creacion);
        DBMS_OUTPUT.PUT_LINE('Último acceso: ' || r.fecha_ultimo_acceso);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento password: ' || r.fecha_vencimiento_password);
        DBMS_OUTPUT.PUT_LINE('Intentos fallidos: ' || r.intentos_fallidos);
        DBMS_OUTPUT.PUT_LINE('Bloqueado: ' || r.bloqueado);
        DBMS_OUTPUT.PUT_LINE('Motivo bloqueo: ' || r.motivo_bloqueo);
        DBMS_OUTPUT.PUT_LINE('Requiere cambio password: ' || r.requiere_cambio_password);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        DBMS_OUTPUT.PUT_LINE('Creado por: ' || r.creado_por);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Usuario del sistema no encontrado.');
    END get_usuario;

    PROCEDURE update_usuario(
        p_id_usuario_sistema       IN NUMBER,
        p_id_empleado              IN NUMBER,
        p_nombre_usuario           IN VARCHAR2,
        p_password_hash            IN VARCHAR2,
        p_email_institucional      IN VARCHAR2,
        p_fecha_creacion           IN DATE,
        p_fecha_ultimo_acceso      IN TIMESTAMP,
        p_fecha_vencimiento_password IN DATE,
        p_intentos_fallidos        IN NUMBER,
        p_bloqueado                IN NUMBER,
        p_motivo_bloqueo           IN VARCHAR2,
        p_requiere_cambio_password IN NUMBER,
        p_activo                   IN NUMBER,
        p_creado_por               IN NUMBER
    ) IS
    BEGIN
        UPDATE usuarios_sistema
        SET id_empleado              = p_id_empleado,
            nombre_usuario           = p_nombre_usuario,
            password_hash            = p_password_hash,
            email_institucional      = p_email_institucional,
            fecha_creacion           = p_fecha_creacion,
            fecha_ultimo_acceso      = p_fecha_ultimo_acceso,
            fecha_vencimiento_password = p_fecha_vencimiento_password,
            intentos_fallidos        = p_intentos_fallidos,
            bloqueado                = p_bloqueado,
            motivo_bloqueo           = p_motivo_bloqueo,
            requiere_cambio_password = p_requiere_cambio_password,
            activo                   = p_activo,
            creado_por               = p_creado_por
        WHERE id_usuario_sistema = p_id_usuario_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31902, 'No se encontró el usuario del sistema para actualizar.');
        END IF;
    END update_usuario;

    PROCEDURE delete_usuario(
        p_id_usuario_sistema IN NUMBER
    ) IS
    BEGIN
        DELETE FROM usuarios_sistema
        WHERE id_usuario_sistema = p_id_usuario_sistema;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31903, 'No se encontró el usuario del sistema para eliminar.');
        END IF;
    END delete_usuario;

END pkg_usuarios_sistema;
/
