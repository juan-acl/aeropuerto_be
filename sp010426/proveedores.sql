------------------------------------------------------------
-- Paquete CRUD para la tabla PROVEEDORES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_proveedores AS
    PROCEDURE insert_proveedor(
        p_nombre_proveedor   IN VARCHAR2,
        p_tipo_proveedor     IN VARCHAR2,
        p_nit                IN VARCHAR2,
        p_direccion          IN VARCHAR2,
        p_telefono           IN VARCHAR2,
        p_email              IN VARCHAR2,
        p_contacto_nombre    IN VARCHAR2,
        p_contacto_telefono  IN VARCHAR2,
        p_condiciones_pago   IN VARCHAR2,
        p_calificacion       IN NUMBER,
        p_activo             IN NUMBER DEFAULT 1
    );

    PROCEDURE get_proveedor(
        p_id_proveedor IN NUMBER
    );

    PROCEDURE update_proveedor(
        p_id_proveedor       IN NUMBER,
        p_nombre_proveedor   IN VARCHAR2,
        p_tipo_proveedor     IN VARCHAR2,
        p_nit                IN VARCHAR2,
        p_direccion          IN VARCHAR2,
        p_telefono           IN VARCHAR2,
        p_email              IN VARCHAR2,
        p_contacto_nombre    IN VARCHAR2,
        p_contacto_telefono  IN VARCHAR2,
        p_condiciones_pago   IN VARCHAR2,
        p_calificacion       IN NUMBER,
        p_activo             IN NUMBER
    );

    PROCEDURE delete_proveedor(
        p_id_proveedor IN NUMBER
    );
END pkg_proveedores;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_proveedores AS

    PROCEDURE insert_proveedor(
        p_nombre_proveedor   IN VARCHAR2,
        p_tipo_proveedor     IN VARCHAR2,
        p_nit                IN VARCHAR2,
        p_direccion          IN VARCHAR2,
        p_telefono           IN VARCHAR2,
        p_email              IN VARCHAR2,
        p_contacto_nombre    IN VARCHAR2,
        p_contacto_telefono  IN VARCHAR2,
        p_condiciones_pago   IN VARCHAR2,
        p_calificacion       IN NUMBER,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        INSERT INTO proveedores (
            nombre_proveedor, tipo_proveedor, nit, direccion,
            telefono, email, contacto_nombre, contacto_telefono,
            condiciones_pago, calificacion, activo
        ) VALUES (
            p_nombre_proveedor, p_tipo_proveedor, p_nit, p_direccion,
            p_telefono, p_email, p_contacto_nombre, p_contacto_telefono,
            p_condiciones_pago, p_calificacion, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-27501, 'Error al insertar proveedor: ' || SQLERRM);
    END insert_proveedor;

    PROCEDURE get_proveedor(
        p_id_proveedor IN NUMBER
    ) IS
        r proveedores%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM proveedores
        WHERE id_proveedor = p_id_proveedor;

        DBMS_OUTPUT.PUT_LINE('ID Proveedor: ' || r.id_proveedor);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_proveedor);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_proveedor);
        DBMS_OUTPUT.PUT_LINE('NIT: ' || r.nit);
        DBMS_OUTPUT.PUT_LINE('Dirección: ' || r.direccion);
        DBMS_OUTPUT.PUT_LINE('Teléfono: ' || r.telefono);
        DBMS_OUTPUT.PUT_LINE('Email: ' || r.email);
        DBMS_OUTPUT.PUT_LINE('Contacto: ' || r.contacto_nombre || ' - ' || r.contacto_telefono);
        DBMS_OUTPUT.PUT_LINE('Condiciones pago: ' || r.condiciones_pago);
        DBMS_OUTPUT.PUT_LINE('Calificación: ' || r.calificacion);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Proveedor no encontrado.');
    END get_proveedor;

    PROCEDURE update_proveedor(
        p_id_proveedor       IN NUMBER,
        p_nombre_proveedor   IN VARCHAR2,
        p_tipo_proveedor     IN VARCHAR2,
        p_nit                IN VARCHAR2,
        p_direccion          IN VARCHAR2,
        p_telefono           IN VARCHAR2,
        p_email              IN VARCHAR2,
        p_contacto_nombre    IN VARCHAR2,
        p_contacto_telefono  IN VARCHAR2,
        p_condiciones_pago   IN VARCHAR2,
        p_calificacion       IN NUMBER,
        p_activo             IN NUMBER
    ) IS
    BEGIN
        UPDATE proveedores
        SET nombre_proveedor   = p_nombre_proveedor,
            tipo_proveedor     = p_tipo_proveedor,
            nit                = p_nit,
            direccion          = p_direccion,
            telefono           = p_telefono,
            email              = p_email,
            contacto_nombre    = p_contacto_nombre,
            contacto_telefono  = p_contacto_telefono,
            condiciones_pago   = p_condiciones_pago,
            calificacion       = p_calificacion,
            activo             = p_activo
        WHERE id_proveedor = p_id_proveedor;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27502, 'No se encontró el proveedor para actualizar.');
        END IF;
    END update_proveedor;

    PROCEDURE delete_proveedor(
        p_id_proveedor IN NUMBER
    ) IS
    BEGIN
        DELETE FROM proveedores
        WHERE id_proveedor = p_id_proveedor;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-27503, 'No se encontró el proveedor para eliminar.');
        END IF;
    END delete_proveedor;

END pkg_proveedores;
/
