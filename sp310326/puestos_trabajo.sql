------------------------------------------------------------
-- Paquete CRUD para la tabla PUESTOS_TRABAJO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_puestos_trabajo AS
    PROCEDURE insert_puesto(
        p_nombre_puesto        IN VARCHAR2,
        p_id_departamento      IN NUMBER,
        p_nivel_jerarquico     IN NUMBER,
        p_salario_minimo       IN NUMBER,
        p_salario_maximo       IN NUMBER,
        p_descripcion_funciones IN VARCHAR2,
        p_requisitos           IN VARCHAR2,
        p_activo               IN NUMBER DEFAULT 1
    );

    PROCEDURE get_puesto(
        p_id_puesto IN NUMBER
    );

    PROCEDURE update_puesto(
        p_id_puesto            IN NUMBER,
        p_nombre_puesto        IN VARCHAR2,
        p_id_departamento      IN NUMBER,
        p_nivel_jerarquico     IN NUMBER,
        p_salario_minimo       IN NUMBER,
        p_salario_maximo       IN NUMBER,
        p_descripcion_funciones IN VARCHAR2,
        p_requisitos           IN VARCHAR2,
        p_activo               IN NUMBER
    );

    PROCEDURE delete_puesto(
        p_id_puesto IN NUMBER
    );
END pkg_puestos_trabajo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_puestos_trabajo AS

    PROCEDURE insert_puesto(
        p_nombre_puesto        IN VARCHAR2,
        p_id_departamento      IN NUMBER,
        p_nivel_jerarquico     IN NUMBER,
        p_salario_minimo       IN NUMBER,
        p_salario_maximo       IN NUMBER,
        p_descripcion_funciones IN VARCHAR2,
        p_requisitos           IN VARCHAR2,
        p_activo               IN NUMBER
    ) IS
    BEGIN
        INSERT INTO puestos_trabajo (
            nombre_puesto, id_departamento, nivel_jerarquico,
            salario_minimo, salario_maximo, descripcion_funciones,
            requisitos, activo
        ) VALUES (
            p_nombre_puesto, p_id_departamento, p_nivel_jerarquico,
            p_salario_minimo, p_salario_maximo, p_descripcion_funciones,
            p_requisitos, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26501, 'Error al insertar puesto de trabajo: ' || SQLERRM);
    END insert_puesto;

    PROCEDURE get_puesto(
        p_id_puesto IN NUMBER
    ) IS
        r puestos_trabajo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM puestos_trabajo
        WHERE id_puesto = p_id_puesto;

        DBMS_OUTPUT.PUT_LINE('ID Puesto: ' || r.id_puesto);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_puesto);
        DBMS_OUTPUT.PUT_LINE('Departamento: ' || r.id_departamento);
        DBMS_OUTPUT.PUT_LINE('Nivel jerárquico: ' || r.nivel_jerarquico);
        DBMS_OUTPUT.PUT_LINE('Salario mínimo: ' || r.salario_minimo);
        DBMS_OUTPUT.PUT_LINE('Salario máximo: ' || r.salario_maximo);
        DBMS_OUTPUT.PUT_LINE('Funciones: ' || r.descripcion_funciones);
        DBMS_OUTPUT.PUT_LINE('Requisitos: ' || r.requisitos);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Puesto de trabajo no encontrado.');
    END get_puesto;

    PROCEDURE update_puesto(
        p_id_puesto            IN NUMBER,
        p_nombre_puesto        IN VARCHAR2,
        p_id_departamento      IN NUMBER,
        p_nivel_jerarquico     IN NUMBER,
        p_salario_minimo       IN NUMBER,
        p_salario_maximo       IN NUMBER,
        p_descripcion_funciones IN VARCHAR2,
        p_requisitos           IN VARCHAR2,
        p_activo               IN NUMBER
    ) IS
    BEGIN
        UPDATE puestos_trabajo
        SET nombre_puesto        = p_nombre_puesto,
            id_departamento      = p_id_departamento,
            nivel_jerarquico     = p_nivel_jerarquico,
            salario_minimo       = p_salario_minimo,
            salario_maximo       = p_salario_maximo,
            descripcion_funciones = p_descripcion_funciones,
            requisitos           = p_requisitos,
            activo               = p_activo
        WHERE id_puesto = p_id_puesto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26502, 'No se encontró el puesto de trabajo para actualizar.');
        END IF;
    END update_puesto;

    PROCEDURE delete_puesto(
        p_id_puesto IN NUMBER
    ) IS
    BEGIN
        DELETE FROM puestos_trabajo
        WHERE id_puesto = p_id_puesto;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26503, 'No se encontró el puesto de trabajo para eliminar.');
        END IF;
    END delete_puesto;

END pkg_puestos_trabajo;
/