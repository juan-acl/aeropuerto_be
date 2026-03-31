------------------------------------------------------------
-- Paquete CRUD para la tabla DEPARTAMENTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_departamentos AS
    PROCEDURE insert_departamento(
        p_nombre_departamento IN VARCHAR2,
        p_descripcion         IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_presupuesto_anual   IN NUMBER,
        p_gerente_id          IN NUMBER,
        p_activo              IN NUMBER DEFAULT 1
    );

    PROCEDURE get_departamento(
        p_id_departamento IN NUMBER
    );

    PROCEDURE update_departamento(
        p_id_departamento     IN NUMBER,
        p_nombre_departamento IN VARCHAR2,
        p_descripcion         IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_presupuesto_anual   IN NUMBER,
        p_gerente_id          IN NUMBER,
        p_activo              IN NUMBER
    );

    PROCEDURE delete_departamento(
        p_id_departamento IN NUMBER
    );
END pkg_departamentos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_departamentos AS

    PROCEDURE insert_departamento(
        p_nombre_departamento IN VARCHAR2,
        p_descripcion         IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_presupuesto_anual   IN NUMBER,
        p_gerente_id          IN NUMBER,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO departamentos (
            nombre_departamento, descripcion, ubicacion,
            presupuesto_anual, gerente_id, activo
        ) VALUES (
            p_nombre_departamento, p_descripcion, p_ubicacion,
            p_presupuesto_anual, p_gerente_id, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26401, 'Error al insertar departamento: ' || SQLERRM);
    END insert_departamento;

    PROCEDURE get_departamento(
        p_id_departamento IN NUMBER
    ) IS
        r departamentos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM departamentos
        WHERE id_departamento = p_id_departamento;

        DBMS_OUTPUT.PUT_LINE('ID Departamento: ' || r.id_departamento);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_departamento);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Ubicación: ' || r.ubicacion);
        DBMS_OUTPUT.PUT_LINE('Presupuesto anual: ' || r.presupuesto_anual);
        DBMS_OUTPUT.PUT_LINE('Gerente ID: ' || r.gerente_id);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Departamento no encontrado.');
    END get_departamento;

    PROCEDURE update_departamento(
        p_id_departamento     IN NUMBER,
        p_nombre_departamento IN VARCHAR2,
        p_descripcion         IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_presupuesto_anual   IN NUMBER,
        p_gerente_id          IN NUMBER,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        UPDATE departamentos
        SET nombre_departamento = p_nombre_departamento,
            descripcion         = p_descripcion,
            ubicacion           = p_ubicacion,
            presupuesto_anual   = p_presupuesto_anual,
            gerente_id          = p_gerente_id,
            activo              = p_activo
        WHERE id_departamento = p_id_departamento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26402, 'No se encontró el departamento para actualizar.');
        END IF;
    END update_departamento;

    PROCEDURE delete_departamento(
        p_id_departamento IN NUMBER
    ) IS
    BEGIN
        DELETE FROM departamentos
        WHERE id_departamento = p_id_departamento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26403, 'No se encontró el departamento para eliminar.');
        END IF;
    END delete_departamento;

END pkg_departamentos;
/