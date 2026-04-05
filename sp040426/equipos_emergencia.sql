------------------------------------------------------------
-- Paquete CRUD para la tabla EQUIPOS_EMERGENCIA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_equipos_emergencia AS
    PROCEDURE insert_equipo(
        p_codigo_equipo             IN VARCHAR2,
        p_nombre_equipo             IN VARCHAR2,
        p_tipo_equipo               IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_ubicacion_habitual        IN VARCHAR2,
        p_disponible_24h            IN NUMBER DEFAULT 1,
        p_personal_asignado         IN NUMBER,
        p_estado                    IN VARCHAR2 DEFAULT 'DISPONIBLE',
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_activo                    IN NUMBER DEFAULT 1
    );

    PROCEDURE get_equipo(
        p_id_equipo_emergencia IN NUMBER
    );

    PROCEDURE update_equipo(
        p_id_equipo_emergencia     IN NUMBER,
        p_codigo_equipo            IN VARCHAR2,
        p_nombre_equipo            IN VARCHAR2,
        p_tipo_equipo              IN VARCHAR2,
        p_descripcion              IN VARCHAR2,
        p_ubicacion_habitual       IN VARCHAR2,
        p_disponible_24h           IN NUMBER,
        p_personal_asignado        IN NUMBER,
        p_estado                   IN VARCHAR2,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_activo                   IN NUMBER
    );

    PROCEDURE delete_equipo(
        p_id_equipo_emergencia IN NUMBER
    );
END pkg_equipos_emergencia;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_equipos_emergencia AS

    PROCEDURE insert_equipo(
        p_codigo_equipo             IN VARCHAR2,
        p_nombre_equipo             IN VARCHAR2,
        p_tipo_equipo               IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_ubicacion_habitual        IN VARCHAR2,
        p_disponible_24h            IN NUMBER,
        p_personal_asignado         IN NUMBER,
        p_estado                    IN VARCHAR2,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_activo                    IN NUMBER
    ) IS
    BEGIN
        INSERT INTO equipos_emergencia (
            codigo_equipo, nombre_equipo, tipo_equipo,
            descripcion, ubicacion_habitual, disponible_24h,
            personal_asignado, estado, fecha_ultimo_mantenimiento,
            fecha_proximo_mantenimiento, activo
        ) VALUES (
            p_codigo_equipo, p_nombre_equipo, p_tipo_equipo,
            p_descripcion, p_ubicacion_habitual, NVL(p_disponible_24h,1),
            p_personal_asignado, NVL(p_estado,'DISPONIBLE'), p_fecha_ultimo_mantenimiento,
            p_fecha_proximo_mantenimiento, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-35601, 'Error al insertar equipo de emergencia: ' || SQLERRM);
    END insert_equipo;

    PROCEDURE get_equipo(
        p_id_equipo_emergencia IN NUMBER
    ) IS
        r equipos_emergencia%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM equipos_emergencia
        WHERE id_equipo_emergencia = p_id_equipo_emergencia;

        DBMS_OUTPUT.PUT_LINE('ID Equipo: ' || r.id_equipo_emergencia);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_equipo);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_equipo);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_equipo);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Ubicación habitual: ' || r.ubicacion_habitual);
        DBMS_OUTPUT.PUT_LINE('Disponible 24h: ' || r.disponible_24h);
        DBMS_OUTPUT.PUT_LINE('Personal asignado: ' || r.personal_asignado);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Último mantenimiento: ' || r.fecha_ultimo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Próximo mantenimiento: ' || r.fecha_proximo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Equipo de emergencia no encontrado.');
    END get_equipo;

    PROCEDURE update_equipo(
        p_id_equipo_emergencia     IN NUMBER,
        p_codigo_equipo            IN VARCHAR2,
        p_nombre_equipo            IN VARCHAR2,
        p_tipo_equipo              IN VARCHAR2,
        p_descripcion              IN VARCHAR2,
        p_ubicacion_habitual       IN VARCHAR2,
        p_disponible_24h           IN NUMBER,
        p_personal_asignado        IN NUMBER,
        p_estado                   IN VARCHAR2,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_activo                   IN NUMBER
    ) IS
    BEGIN
        UPDATE equipos_emergencia
        SET codigo_equipo             = p_codigo_equipo,
            nombre_equipo             = p_nombre_equipo,
            tipo_equipo               = p_tipo_equipo,
            descripcion               = p_descripcion,
            ubicacion_habitual        = p_ubicacion_habitual,
            disponible_24h            = p_disponible_24h,
            personal_asignado         = p_personal_asignado,
            estado                    = p_estado,
            fecha_ultimo_mantenimiento = p_fecha_ultimo_mantenimiento,
            fecha_proximo_mantenimiento = p_fecha_proximo_mantenimiento,
            activo                    = p_activo
        WHERE id_equipo_emergencia = p_id_equipo_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35602, 'No se encontró el equipo de emergencia para actualizar.');
        END IF;
    END update_equipo;

    PROCEDURE delete_equipo(
        p_id_equipo_emergencia IN NUMBER
    ) IS
    BEGIN
        DELETE FROM equipos_emergencia
        WHERE id_equipo_emergencia = p_id_equipo_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-35603, 'No se encontró el equipo de emergencia para eliminar.');
        END IF;
    END delete_equipo;

END pkg_equipos_emergencia;
/
