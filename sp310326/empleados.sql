------------------------------------------------------------
-- Paquete CRUD para la tabla EMPLEADOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_empleados AS
    PROCEDURE insert_empleado(
        p_codigo_empleado    IN VARCHAR2,
        p_nombres            IN VARCHAR2,
        p_apellidos          IN VARCHAR2,
        p_tipo_documento     IN VARCHAR2,
        p_numero_documento   IN VARCHAR2,
        p_fecha_nacimiento   IN DATE,
        p_nacionalidad       IN VARCHAR2,
        p_genero             IN VARCHAR2,
        p_direccion          IN VARCHAR2,
        p_telefono           IN VARCHAR2,
        p_email              IN VARCHAR2,
        p_fecha_contratacion IN DATE,
        p_departamento       IN VARCHAR2,
        p_cargo              IN VARCHAR2,
        p_salario_base       IN NUMBER,
        p_tipo_contrato      IN VARCHAR2,
        p_activo             IN NUMBER DEFAULT 1,
        p_foto_empleado      IN BLOB
    );

    PROCEDURE get_empleado(
        p_id_empleado IN NUMBER
    );

    PROCEDURE update_empleado(
        p_id_empleado        IN NUMBER,
        p_codigo_empleado    IN VARCHAR2,
        p_nombres            IN VARCHAR2,
        p_apellidos          IN VARCHAR2,
        p_tipo_documento     IN VARCHAR2,
        p_numero_documento   IN VARCHAR2,
        p_fecha_nacimiento   IN DATE,
        p_nacionalidad       IN VARCHAR2,
        p_genero             IN VARCHAR2,
        p_direccion          IN VARCHAR2,
        p_telefono           IN VARCHAR2,
        p_email              IN VARCHAR2,
        p_fecha_contratacion IN DATE,
        p_departamento       IN VARCHAR2,
        p_cargo              IN VARCHAR2,
        p_salario_base       IN NUMBER,
        p_tipo_contrato      IN VARCHAR2,
        p_activo             IN NUMBER,
        p_foto_empleado      IN BLOB
    );

    PROCEDURE delete_empleado(
        p_id_empleado IN NUMBER
    );
END pkg_empleados;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_empleados AS

    PROCEDURE insert_empleado(
        p_codigo_empleado    IN VARCHAR2,
        p_nombres            IN VARCHAR2,
        p_apellidos          IN VARCHAR2,
        p_tipo_documento     IN VARCHAR2,
        p_numero_documento   IN VARCHAR2,
        p_fecha_nacimiento   IN DATE,
        p_nacionalidad       IN VARCHAR2,
        p_genero             IN VARCHAR2,
        p_direccion          IN VARCHAR2,
        p_telefono           IN VARCHAR2,
        p_email              IN VARCHAR2,
        p_fecha_contratacion IN DATE,
        p_departamento       IN VARCHAR2,
        p_cargo              IN VARCHAR2,
        p_salario_base       IN NUMBER,
        p_tipo_contrato      IN VARCHAR2,
        p_activo             IN NUMBER,
        p_foto_empleado      IN BLOB
    ) IS
    BEGIN
        INSERT INTO empleados (
            codigo_empleado, nombres, apellidos, tipo_documento,
            numero_documento, fecha_nacimiento, nacionalidad, genero,
            direccion, telefono, email, fecha_contratacion,
            departamento, cargo, salario_base, tipo_contrato,
            activo, foto_empleado
        ) VALUES (
            p_codigo_empleado, p_nombres, p_apellidos, p_tipo_documento,
            p_numero_documento, p_fecha_nacimiento, p_nacionalidad, p_genero,
            p_direccion, p_telefono, p_email, p_fecha_contratacion,
            p_departamento, p_cargo, p_salario_base, p_tipo_contrato,
            NVL(p_activo,1), p_foto_empleado
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26301, 'Error al insertar empleado: ' || SQLERRM);
    END insert_empleado;

    PROCEDURE get_empleado(
        p_id_empleado IN NUMBER
    ) IS
        r empleados%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM empleados
        WHERE id_empleado = p_id_empleado;

        DBMS_OUTPUT.PUT_LINE('ID Empleado: ' || r.id_empleado);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_empleado);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombres || ' ' || r.apellidos);
        DBMS_OUTPUT.PUT_LINE('Documento: ' || r.tipo_documento || ' ' || r.numero_documento);
        DBMS_OUTPUT.PUT_LINE('Nacimiento: ' || r.fecha_nacimiento);
        DBMS_OUTPUT.PUT_LINE('Nacionalidad: ' || r.nacionalidad);
        DBMS_OUTPUT.PUT_LINE('Género: ' || r.genero);
        DBMS_OUTPUT.PUT_LINE('Dirección: ' || r.direccion);
        DBMS_OUTPUT.PUT_LINE('Teléfono: ' || r.telefono);
        DBMS_OUTPUT.PUT_LINE('Email: ' || r.email);
        DBMS_OUTPUT.PUT_LINE('Fecha contratación: ' || r.fecha_contratacion);
        DBMS_OUTPUT.PUT_LINE('Departamento: ' || r.departamento);
        DBMS_OUTPUT.PUT_LINE('Cargo: ' || r.cargo);
        DBMS_OUTPUT.PUT_LINE('Salario base: ' || r.salario_base);
        DBMS_OUTPUT.PUT_LINE('Tipo contrato: ' || r.tipo_contrato);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        DBMS_OUTPUT.PUT_LINE('Foto: ' || CASE WHEN r.foto_empleado IS NOT NULL THEN 'Sí' ELSE 'No' END);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Empleado no encontrado.');
    END get_empleado;

    PROCEDURE update_empleado(
        p_id_empleado        IN NUMBER,
        p_codigo_empleado    IN VARCHAR2,
        p_nombres            IN VARCHAR2,
        p_apellidos          IN VARCHAR2,
        p_tipo_documento     IN VARCHAR2,
        p_numero_documento   IN VARCHAR2,
        p_fecha_nacimiento   IN DATE,
        p_nacionalidad       IN VARCHAR2,
        p_genero             IN VARCHAR2,
        p_direccion          IN VARCHAR2,
        p_telefono           IN VARCHAR2,
        p_email              IN VARCHAR2,
        p_fecha_contratacion IN DATE,
        p_departamento       IN VARCHAR2,
        p_cargo              IN VARCHAR2,
        p_salario_base       IN NUMBER,
        p_tipo_contrato      IN VARCHAR2,
        p_activo             IN NUMBER,
        p_foto_empleado      IN BLOB
    ) IS
    BEGIN
        UPDATE empleados
        SET codigo_empleado    = p_codigo_empleado,
            nombres            = p_nombres,
            apellidos          = p_apellidos,
            tipo_documento     = p_tipo_documento,
            numero_documento   = p_numero_documento,
            fecha_nacimiento   = p_fecha_nacimiento,
            nacionalidad       = p_nacionalidad,
            genero             = p_genero,
            direccion          = p_direccion,
            telefono           = p_telefono,
            email              = p_email,
            fecha_contratacion = p_fecha_contratacion,
            departamento       = p_departamento,
            cargo              = p_cargo,
            salario_base       = p_salario_base,
            tipo_contrato      = p_tipo_contrato,
            activo             = p_activo,
            foto_empleado      = p_foto_empleado
        WHERE id_empleado = p_id_empleado;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26302, 'No se encontró el empleado para actualizar.');
        END IF;
    END update_empleado;

    PROCEDURE delete_empleado(
        p_id_empleado IN NUMBER
    ) IS
    BEGIN
        DELETE FROM empleados
        WHERE id_empleado = p_id_empleado;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26303, 'No se encontró el empleado para eliminar.');
        END IF;
    END delete_empleado;

END pkg_empleados;
/