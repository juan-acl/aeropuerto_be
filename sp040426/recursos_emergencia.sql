------------------------------------------------------------
-- Paquete CRUD para la tabla RECURSOS_EMERGENCIA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_recursos_emergencia AS
    PROCEDURE insert_recurso(
        p_tipo_recurso              IN VARCHAR2,
        p_nombre_recurso            IN VARCHAR2,
        p_cantidad_disponible       IN NUMBER DEFAULT 0,
        p_ubicacion_almacen         IN VARCHAR2,
        p_fecha_vencimiento         IN DATE,
        p_proveedor                 IN VARCHAR2,
        p_responsable_mantenimiento IN VARCHAR2,
        p_fecha_ultima_revision     IN DATE,
        p_fecha_proxima_revision    IN DATE,
        p_activo                    IN NUMBER DEFAULT 1
    );

    PROCEDURE get_recurso(
        p_id_recurso_emergencia IN NUMBER
    );

    PROCEDURE update_recurso(
        p_id_recurso_emergencia     IN NUMBER,
        p_tipo_recurso              IN VARCHAR2,
        p_nombre_recurso            IN VARCHAR2,
        p_cantidad_disponible       IN NUMBER,
        p_ubicacion_almacen         IN VARCHAR2,
        p_fecha_vencimiento         IN DATE,
        p_proveedor                 IN VARCHAR2,
        p_responsable_mantenimiento IN VARCHAR2,
        p_fecha_ultima_revision     IN DATE,
        p_fecha_proxima_revision    IN DATE,
        p_activo                    IN NUMBER
    );

    PROCEDURE delete_recurso(
        p_id_recurso_emergencia IN NUMBER
    );
END pkg_recursos_emergencia;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_recursos_emergencia AS

    PROCEDURE insert_recurso(
        p_tipo_recurso              IN VARCHAR2,
        p_nombre_recurso            IN VARCHAR2,
        p_cantidad_disponible       IN NUMBER,
        p_ubicacion_almacen         IN VARCHAR2,
        p_fecha_vencimiento         IN DATE,
        p_proveedor                 IN VARCHAR2,
        p_responsable_mantenimiento IN VARCHAR2,
        p_fecha_ultima_revision     IN DATE,
        p_fecha_proxima_revision    IN DATE,
        p_activo                    IN NUMBER
    ) IS
    BEGIN
        INSERT INTO recursos_emergencia (
            tipo_recurso, nombre_recurso, cantidad_disponible,
            ubicacion_almacen, fecha_vencimiento, proveedor,
            responsable_mantenimiento, fecha_ultima_revision,
            fecha_proxima_revision, activo
        ) VALUES (
            p_tipo_recurso, p_nombre_recurso, NVL(p_cantidad_disponible,0),
            p_ubicacion_almacen, p_fecha_vencimiento, p_proveedor,
            p_responsable_mantenimiento, p_fecha_ultima_revision,
            p_fecha_proxima_revision, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36101, 'Error al insertar recurso de emergencia: ' || SQLERRM);
    END insert_recurso;

    PROCEDURE get_recurso(
        p_id_recurso_emergencia IN NUMBER
    ) IS
        r recursos_emergencia%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM recursos_emergencia
        WHERE id_recurso_emergencia = p_id_recurso_emergencia;

        DBMS_OUTPUT.PUT_LINE('ID Recurso: ' || r.id_recurso_emergencia);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_recurso);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_recurso);
        DBMS_OUTPUT.PUT_LINE('Cantidad disponible: ' || r.cantidad_disponible);
        DBMS_OUTPUT.PUT_LINE('Ubicación almacén: ' || r.ubicacion_almacen);
        DBMS_OUTPUT.PUT_LINE('Fecha vencimiento: ' || r.fecha_vencimiento);
        DBMS_OUTPUT.PUT_LINE('Proveedor: ' || r.proveedor);
        DBMS_OUTPUT.PUT_LINE('Responsable mantenimiento: ' || r.responsable_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Última revisión: ' || r.fecha_ultima_revision);
        DBMS_OUTPUT.PUT_LINE('Próxima revisión: ' || r.fecha_proxima_revision);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Recurso de emergencia no encontrado.');
    END get_recurso;

    PROCEDURE update_recurso(
        p_id_recurso_emergencia     IN NUMBER,
        p_tipo_recurso              IN VARCHAR2,
        p_nombre_recurso            IN VARCHAR2,
        p_cantidad_disponible       IN NUMBER,
        p_ubicacion_almacen         IN VARCHAR2,
        p_fecha_vencimiento         IN DATE,
        p_proveedor                 IN VARCHAR2,
        p_responsable_mantenimiento IN VARCHAR2,
        p_fecha_ultima_revision     IN DATE,
        p_fecha_proxima_revision    IN DATE,
        p_activo                    IN NUMBER
    ) IS
    BEGIN
        UPDATE recursos_emergencia
        SET tipo_recurso              = p_tipo_recurso,
            nombre_recurso            = p_nombre_recurso,
            cantidad_disponible       = p_cantidad_disponible,
            ubicacion_almacen         = p_ubicacion_almacen,
            fecha_vencimiento         = p_fecha_vencimiento,
            proveedor                 = p_proveedor,
            responsable_mantenimiento = p_responsable_mantenimiento,
            fecha_ultima_revision     = p_fecha_ultima_revision,
            fecha_proxima_revision    = p_fecha_proxima_revision,
            activo                    = p_activo
        WHERE id_recurso_emergencia = p_id_recurso_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36102, 'No se encontró el recurso de emergencia para actualizar.');
        END IF;
    END update_recurso;

    PROCEDURE delete_recurso(
        p_id_recurso_emergencia IN NUMBER
    ) IS
    BEGIN
        DELETE FROM recursos_emergencia
        WHERE id_recurso_emergencia = p_id_recurso_emergencia;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36103, 'No se encontró el recurso de emergencia para eliminar.');
        END IF;
    END delete_recurso;

END pkg_recursos_emergencia;
/
