------------------------------------------------------------
-- Paquete CRUD para la tabla ENTRENAMIENTOS_EMERGENCIA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_entrenamientos_emergencia AS
    PROCEDURE insert_entrenamiento(
        p_nombre_entrenamiento       IN VARCHAR2,
        p_tipo_entrenamiento         IN VARCHAR2,
        p_fecha_realizacion          IN DATE,
        p_duracion_horas             IN NUMBER,
        p_instructor                 IN VARCHAR2,
        p_participantes              IN NUMBER,
        p_contenido                  IN CLOB,
        p_evaluacion                 IN CLOB,
        p_certificaciones_entregadas IN NUMBER DEFAULT 0,
        p_fecha_proximo_entrenamiento IN DATE
    );

    PROCEDURE get_entrenamiento(
        p_id_entrenamiento IN NUMBER
    );

    PROCEDURE update_entrenamiento(
        p_id_entrenamiento           IN NUMBER,
        p_nombre_entrenamiento       IN VARCHAR2,
        p_tipo_entrenamiento         IN VARCHAR2,
        p_fecha_realizacion          IN DATE,
        p_duracion_horas             IN NUMBER,
        p_instructor                 IN VARCHAR2,
        p_participantes              IN NUMBER,
        p_contenido                  IN CLOB,
        p_evaluacion                 IN CLOB,
        p_certificaciones_entregadas IN NUMBER,
        p_fecha_proximo_entrenamiento IN DATE
    );

    PROCEDURE delete_entrenamiento(
        p_id_entrenamiento IN NUMBER
    );
END pkg_entrenamientos_emergencia;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_entrenamientos_emergencia AS

    PROCEDURE insert_entrenamiento(
        p_nombre_entrenamiento       IN VARCHAR2,
        p_tipo_entrenamiento         IN VARCHAR2,
        p_fecha_realizacion          IN DATE,
        p_duracion_horas             IN NUMBER,
        p_instructor                 IN VARCHAR2,
        p_participantes              IN NUMBER,
        p_contenido                  IN CLOB,
        p_evaluacion                 IN CLOB,
        p_certificaciones_entregadas IN NUMBER,
        p_fecha_proximo_entrenamiento IN DATE
    ) IS
    BEGIN
        INSERT INTO entrenamientos_emergencia (
            nombre_entrenamiento, tipo_entrenamiento, fecha_realizacion,
            duracion_horas, instructor, participantes,
            contenido, evaluacion, certificaciones_entregadas,
            fecha_proximo_entrenamiento
        ) VALUES (
            p_nombre_entrenamiento, p_tipo_entrenamiento, p_fecha_realizacion,
            p_duracion_horas, p_instructor, p_participantes,
            p_contenido, p_evaluacion, NVL(p_certificaciones_entregadas,0),
            p_fecha_proximo_entrenamiento
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36301, 'Error al insertar entrenamiento de emergencia: ' || SQLERRM);
    END insert_entrenamiento;

    PROCEDURE get_entrenamiento(
        p_id_entrenamiento IN NUMBER
    ) IS
        r entrenamientos_emergencia%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM entrenamientos_emergencia
        WHERE id_entrenamiento = p_id_entrenamiento;

        DBMS_OUTPUT.PUT_LINE('ID Entrenamiento: ' || r.id_entrenamiento);
        DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_entrenamiento);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_entrenamiento);
        DBMS_OUTPUT.PUT_LINE('Fecha realización: ' || r.fecha_realizacion);
        DBMS_OUTPUT.PUT_LINE('Duración (horas): ' || r.duracion_horas);
        DBMS_OUTPUT.PUT_LINE('Instructor: ' || r.instructor);
        DBMS_OUTPUT.PUT_LINE('Participantes: ' || r.participantes);
        DBMS_OUTPUT.PUT_LINE('Contenido: ' || DBMS_LOB.SUBSTR(r.contenido,200,1));
        DBMS_OUTPUT.PUT_LINE('Evaluación: ' || DBMS_LOB.SUBSTR(r.evaluacion,200,1));
        DBMS_OUTPUT.PUT_LINE('Certificaciones entregadas: ' || r.certificaciones_entregadas);
        DBMS_OUTPUT.PUT_LINE('Próximo entrenamiento: ' || r.fecha_proximo_entrenamiento);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Entrenamiento de emergencia no encontrado.');
    END get_entrenamiento;

    PROCEDURE update_entrenamiento(
        p_id_entrenamiento           IN NUMBER,
        p_nombre_entrenamiento       IN VARCHAR2,
        p_tipo_entrenamiento         IN VARCHAR2,
        p_fecha_realizacion          IN DATE,
        p_duracion_horas             IN NUMBER,
        p_instructor                 IN VARCHAR2,
        p_participantes              IN NUMBER,
        p_contenido                  IN CLOB,
        p_evaluacion                 IN CLOB,
        p_certificaciones_entregadas IN NUMBER,
        p_fecha_proximo_entrenamiento IN DATE
    ) IS
    BEGIN
        UPDATE entrenamientos_emergencia
        SET nombre_entrenamiento       = p_nombre_entrenamiento,
            tipo_entrenamiento         = p_tipo_entrenamiento,
            fecha_realizacion          = p_fecha_realizacion,
            duracion_horas             = p_duracion_horas,
            instructor                 = p_instructor,
            participantes              = p_participantes,
            contenido                  = p_contenido,
            evaluacion                 = p_evaluacion,
            certificaciones_entregadas = p_certificaciones_entregadas,
            fecha_proximo_entrenamiento = p_fecha_proximo_entrenamiento
        WHERE id_entrenamiento = p_id_entrenamiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36302, 'No se encontró el entrenamiento de emergencia para actualizar.');
        END IF;
    END update_entrenamiento;

    PROCEDURE delete_entrenamiento(
        p_id_entrenamiento IN NUMBER
    ) IS
    BEGIN
        DELETE FROM entrenamientos_emergencia
        WHERE id_entrenamiento = p_id_entrenamiento;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36303, 'No se encontró el entrenamiento de emergencia para eliminar.');
        END IF;
    END delete_entrenamiento;

END pkg_entrenamientos_emergencia;
/
