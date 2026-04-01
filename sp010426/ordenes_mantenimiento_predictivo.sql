------------------------------------------------------------
-- Paquete CRUD para la tabla ORDENES_MANTENIMIENTO_PREDICTIVO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_ordenes_mp AS
    PROCEDURE insert_orden(
        p_id_alerta_tecnica     IN NUMBER,
        p_id_pieza              IN NUMBER,
        p_id_avion_matricula    IN VARCHAR2,
        p_fecha_creacion        IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_prioridad             IN VARCHAR2,
        p_descripcion_trabajo   IN VARCHAR2,
        p_tecnico_asignado      IN NUMBER,
        p_fecha_inicio_estimada IN DATE,
        p_fecha_fin_estimada    IN DATE,
        p_fecha_inicio_real     IN DATE,
        p_fecha_fin_real        IN DATE,
        p_estado                IN VARCHAR2 DEFAULT 'PENDIENTE',
        p_horas_trabajadas      IN NUMBER,
        p_costo_estimado        IN NUMBER,
        p_costo_real            IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE get_orden(
        p_id_orden_mp IN NUMBER
    );

    PROCEDURE update_orden(
        p_id_orden_mp           IN NUMBER,
        p_id_alerta_tecnica     IN NUMBER,
        p_id_pieza              IN NUMBER,
        p_id_avion_matricula    IN VARCHAR2,
        p_fecha_creacion        IN TIMESTAMP,
        p_prioridad             IN VARCHAR2,
        p_descripcion_trabajo   IN VARCHAR2,
        p_tecnico_asignado      IN NUMBER,
        p_fecha_inicio_estimada IN DATE,
        p_fecha_fin_estimada    IN DATE,
        p_fecha_inicio_real     IN DATE,
        p_fecha_fin_real        IN DATE,
        p_estado                IN VARCHAR2,
        p_horas_trabajadas      IN NUMBER,
        p_costo_estimado        IN NUMBER,
        p_costo_real            IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE delete_orden(
        p_id_orden_mp IN NUMBER
    );
END pkg_ordenes_mp;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_ordenes_mp AS

    PROCEDURE insert_orden(
        p_id_alerta_tecnica     IN NUMBER,
        p_id_pieza              IN NUMBER,
        p_id_avion_matricula    IN VARCHAR2,
        p_fecha_creacion        IN TIMESTAMP,
        p_prioridad             IN VARCHAR2,
        p_descripcion_trabajo   IN VARCHAR2,
        p_tecnico_asignado      IN NUMBER,
        p_fecha_inicio_estimada IN DATE,
        p_fecha_fin_estimada    IN DATE,
        p_fecha_inicio_real     IN DATE,
        p_fecha_fin_real        IN DATE,
        p_estado                IN VARCHAR2,
        p_horas_trabajadas      IN NUMBER,
        p_costo_estimado        IN NUMBER,
        p_costo_real            IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO ordenes_mantenimiento_predictivo (
            id_alerta_tecnica, id_pieza, id_avion_matricula, fecha_creacion,
            prioridad, descripcion_trabajo, tecnico_asignado,
            fecha_inicio_estimada, fecha_fin_estimada,
            fecha_inicio_real, fecha_fin_real,
            estado, horas_trabajadas, costo_estimado, costo_real, observaciones
        ) VALUES (
            p_id_alerta_tecnica, p_id_pieza, p_id_avion_matricula, NVL(p_fecha_creacion, SYSTIMESTAMP),
            p_prioridad, p_descripcion_trabajo, p_tecnico_asignado,
            p_fecha_inicio_estimada, p_fecha_fin_estimada,
            p_fecha_inicio_real, p_fecha_fin_real,
            NVL(p_estado,'PENDIENTE'), p_horas_trabajadas, p_costo_estimado, p_costo_real, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-29501, 'Error al insertar orden de mantenimiento predictivo: ' || SQLERRM);
    END insert_orden;

    PROCEDURE get_orden(
        p_id_orden_mp IN NUMBER
    ) IS
        r ordenes_mantenimiento_predictivo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM ordenes_mantenimiento_predictivo
        WHERE id_orden_mp = p_id_orden_mp;

        DBMS_OUTPUT.PUT_LINE('ID Orden MP: ' || r.id_orden_mp);
        DBMS_OUTPUT.PUT_LINE('Alerta técnica: ' || r.id_alerta_tecnica);
        DBMS_OUTPUT.PUT_LINE('Pieza: ' || r.id_pieza);
        DBMS_OUTPUT.PUT_LINE('Avión matrícula: ' || r.id_avion_matricula);
        DBMS_OUTPUT.PUT_LINE('Fecha creación: ' || r.fecha_creacion);
        DBMS_OUTPUT.PUT_LINE('Prioridad: ' || r.prioridad);
        DBMS_OUTPUT.PUT_LINE('Descripción trabajo: ' || r.descripcion_trabajo);
        DBMS_OUTPUT.PUT_LINE('Técnico asignado: ' || r.tecnico_asignado);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio estimada: ' || r.fecha_inicio_estimada);
        DBMS_OUTPUT.PUT_LINE('Fecha fin estimada: ' || r.fecha_fin_estimada);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio real: ' || r.fecha_inicio_real);
        DBMS_OUTPUT.PUT_LINE('Fecha fin real: ' || r.fecha_fin_real);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Horas trabajadas: ' || r.horas_trabajadas);
        DBMS_OUTPUT.PUT_LINE('Costo estimado: ' || r.costo_estimado);
        DBMS_OUTPUT.PUT_LINE('Costo real: ' || r.costo_real);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Orden de mantenimiento predictivo no encontrada.');
    END get_orden;

    PROCEDURE update_orden(
        p_id_orden_mp           IN NUMBER,
        p_id_alerta_tecnica     IN NUMBER,
        p_id_pieza              IN NUMBER,
        p_id_avion_matricula    IN VARCHAR2,
        p_fecha_creacion        IN TIMESTAMP,
        p_prioridad             IN VARCHAR2,
        p_descripcion_trabajo   IN VARCHAR2,
        p_tecnico_asignado      IN NUMBER,
        p_fecha_inicio_estimada IN DATE,
        p_fecha_fin_estimada    IN DATE,
        p_fecha_inicio_real     IN DATE,
        p_fecha_fin_real        IN DATE,
        p_estado                IN VARCHAR2,
        p_horas_trabajadas      IN NUMBER,
        p_costo_estimado        IN NUMBER,
        p_costo_real            IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        UPDATE ordenes_mantenimiento_predictivo
        SET id_alerta_tecnica     = p_id_alerta_tecnica,
            id_pieza              = p_id_pieza,
            id_avion_matricula    = p_id_avion_matricula,
            fecha_creacion        = p_fecha_creacion,
            prioridad             = p_prioridad,
            descripcion_trabajo   = p_descripcion_trabajo,
            tecnico_asignado      = p_tecnico_asignado,
            fecha_inicio_estimada = p_fecha_inicio_estimada,
            fecha_fin_estimada    = p_fecha_fin_estimada,
            fecha_inicio_real     = p_fecha_inicio_real,
            fecha_fin_real        = p_fecha_fin_real,
            estado                = p_estado,
            horas_trabajadas      = p_horas_trabajadas,
            costo_estimado        = p_costo_estimado,
            costo_real            = p_costo_real,
            observaciones         = p_observaciones
        WHERE id_orden_mp = p_id_orden_mp;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29502, 'No se encontró la orden de mantenimiento predictivo para actualizar.');
        END IF;
    END update_orden;

    PROCEDURE delete_orden(
        p_id_orden_mp IN NUMBER
    ) IS
    BEGIN
        DELETE FROM ordenes_mantenimiento_predictivo
        WHERE id_orden_mp = p_id_orden_mp;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-29503, 'No se encontró la orden de mantenimiento predictivo para eliminar.');
        END IF;
    END delete_orden;

END pkg_ordenes_mp;
/
