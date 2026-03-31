------------------------------------------------------------
-- Paquete CRUD para la tabla CAPACITACIONES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_capacitaciones AS
    PROCEDURE insert_capacitacion(
        p_nombre_curso      IN VARCHAR2,
        p_descripcion       IN VARCHAR2,
        p_tipo_capacitacion IN VARCHAR2,
        p_duracion_horas    IN NUMBER,
        p_costo             IN NUMBER,
        p_proveedor         IN VARCHAR2,
        p_fecha_inicio      IN DATE,
        p_fecha_fin         IN DATE,
        p_activo            IN NUMBER DEFAULT 1
    );

    PROCEDURE get_capacitacion(
        p_id_capacitacion IN NUMBER
    );

    PROCEDURE update_capacitacion(
        p_id_capacitacion   IN NUMBER,
        p_nombre_curso      IN VARCHAR2,
        p_descripcion       IN VARCHAR2,
        p_tipo_capacitacion IN VARCHAR2,
        p_duracion_horas    IN NUMBER,
        p_costo             IN NUMBER,
        p_proveedor         IN VARCHAR2,
        p_fecha_inicio      IN DATE,
        p_fecha_fin         IN DATE,
        p_activo            IN NUMBER
    );

    PROCEDURE delete_capacitacion(
        p_id_capacitacion IN NUMBER
    );
END pkg_capacitaciones;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_capacitaciones AS

    PROCEDURE insert_capacitacion(
        p_nombre_curso      IN VARCHAR2,
        p_descripcion       IN VARCHAR2,
        p_tipo_capacitacion IN VARCHAR2,
        p_duracion_horas    IN NUMBER,
        p_costo             IN NUMBER,
        p_proveedor         IN VARCHAR2,
        p_fecha_inicio      IN DATE,
        p_fecha_fin         IN DATE,
        p_activo            IN NUMBER
    ) IS
    BEGIN
        INSERT INTO capacitaciones (
            nombre_curso, descripcion, tipo_capacitacion,
            duracion_horas, costo, proveedor,
            fecha_inicio, fecha_fin, activo
        ) VALUES (
            p_nombre_curso, p_descripcion, p_tipo_capacitacion,
            p_duracion_horas, p_costo, p_proveedor,
            p_fecha_inicio, p_fecha_fin, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-26901, 'Error al insertar capacitación: ' || SQLERRM);
    END insert_capacitacion;

    PROCEDURE get_capacitacion(
        p_id_capacitacion IN NUMBER
    ) IS
        r capacitaciones%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM capacitaciones
        WHERE id_capacitacion = p_id_capacitacion;

        DBMS_OUTPUT.PUT_LINE('ID Capacitación: ' || r.id_capacitacion);
        DBMS_OUTPUT.PUT_LINE('Curso: ' || r.nombre_curso);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_capacitacion);
        DBMS_OUTPUT.PUT_LINE('Duración (horas): ' || r.duracion_horas);
        DBMS_OUTPUT.PUT_LINE('Costo: ' || r.costo);
        DBMS_OUTPUT.PUT_LINE('Proveedor: ' || r.proveedor);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Capacitación no encontrada.');
    END get_capacitacion;

    PROCEDURE update_capacitacion(
        p_id_capacitacion   IN NUMBER,
        p_nombre_curso      IN VARCHAR2,
        p_descripcion       IN VARCHAR2,
        p_tipo_capacitacion IN VARCHAR2,
        p_duracion_horas    IN NUMBER,
        p_costo             IN NUMBER,
        p_proveedor         IN VARCHAR2,
        p_fecha_inicio      IN DATE,
        p_fecha_fin         IN DATE,
        p_activo            IN NUMBER
    ) IS
    BEGIN
        UPDATE capacitaciones
        SET nombre_curso      = p_nombre_curso,
            descripcion       = p_descripcion,
            tipo_capacitacion = p_tipo_capacitacion,
            duracion_horas    = p_duracion_horas,
            costo             = p_costo,
            proveedor         = p_proveedor,
            fecha_inicio      = p_fecha_inicio,
            fecha_fin         = p_fecha_fin,
            activo            = p_activo
        WHERE id_capacitacion = p_id_capacitacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26902, 'No se encontró la capacitación para actualizar.');
        END IF;
    END update_capacitacion;

    PROCEDURE delete_capacitacion(
        p_id_capacitacion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM capacitaciones
        WHERE id_capacitacion = p_id_capacitacion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-26903, 'No se encontró la capacitación para eliminar.');
        END IF;
    END delete_capacitacion;

END pkg_capacitaciones;
/