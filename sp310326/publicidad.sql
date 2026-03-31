------------------------------------------------------------
-- Paquete CRUD para la tabla PUBLICIDAD
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_publicidad AS
    PROCEDURE insert_publicidad(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_tipo_publicidad     IN VARCHAR2,
        p_empresa_anunciante  IN VARCHAR2,
        p_fecha_inicio        IN DATE,
        p_fecha_fin           IN DATE,
        p_costo               IN NUMBER,
        p_contrato            IN BLOB,
        p_activo              IN NUMBER DEFAULT 1
    );

    PROCEDURE get_publicidad(
        p_id_publicidad IN NUMBER
    );

    PROCEDURE update_publicidad(
        p_id_publicidad       IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_tipo_publicidad     IN VARCHAR2,
        p_empresa_anunciante  IN VARCHAR2,
        p_fecha_inicio        IN DATE,
        p_fecha_fin           IN DATE,
        p_costo               IN NUMBER,
        p_contrato            IN BLOB,
        p_activo              IN NUMBER
    );

    PROCEDURE delete_publicidad(
        p_id_publicidad IN NUMBER
    );
END pkg_publicidad;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_publicidad AS

    PROCEDURE insert_publicidad(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_tipo_publicidad     IN VARCHAR2,
        p_empresa_anunciante  IN VARCHAR2,
        p_fecha_inicio        IN DATE,
        p_fecha_fin           IN DATE,
        p_costo               IN NUMBER,
        p_contrato            IN BLOB,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        INSERT INTO publicidad (
            codigo_aeropuerto, ubicacion, tipo_publicidad,
            empresa_anunciante, fecha_inicio, fecha_fin,
            costo, contrato, activo
        ) VALUES (
            p_codigo_aeropuerto, p_ubicacion, p_tipo_publicidad,
            p_empresa_anunciante, p_fecha_inicio, p_fecha_fin,
            p_costo, p_contrato, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25601, 'Error al insertar publicidad: ' || SQLERRM);
    END insert_publicidad;

    PROCEDURE get_publicidad(
        p_id_publicidad IN NUMBER
    ) IS
        r publicidad%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM publicidad
        WHERE id_publicidad = p_id_publicidad;

        DBMS_OUTPUT.PUT_LINE('ID Publicidad: ' || r.id_publicidad);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Ubicación: ' || r.ubicacion);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_publicidad);
        DBMS_OUTPUT.PUT_LINE('Empresa anunciante: ' || r.empresa_anunciante);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        DBMS_OUTPUT.PUT_LINE('Costo: ' || r.costo);
        DBMS_OUTPUT.PUT_LINE('Contrato: ' || CASE WHEN r.contrato IS NOT NULL THEN 'Sí' ELSE 'No' END);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Publicidad no encontrada.');
    END get_publicidad;

    PROCEDURE update_publicidad(
        p_id_publicidad       IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_ubicacion           IN VARCHAR2,
        p_tipo_publicidad     IN VARCHAR2,
        p_empresa_anunciante  IN VARCHAR2,
        p_fecha_inicio        IN DATE,
        p_fecha_fin           IN DATE,
        p_costo               IN NUMBER,
        p_contrato            IN BLOB,
        p_activo              IN NUMBER
    ) IS
    BEGIN
        UPDATE publicidad
        SET codigo_aeropuerto  = p_codigo_aeropuerto,
            ubicacion          = p_ubicacion,
            tipo_publicidad    = p_tipo_publicidad,
            empresa_anunciante = p_empresa_anunciante,
            fecha_inicio       = p_fecha_inicio,
            fecha_fin          = p_fecha_fin,
            costo              = p_costo,
            contrato           = p_contrato,
            activo             = p_activo
        WHERE id_publicidad = p_id_publicidad;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25602, 'No se encontró la publicidad para actualizar.');
        END IF;
    END update_publicidad;

    PROCEDURE delete_publicidad(
        p_id_publicidad IN NUMBER
    ) IS
    BEGIN
        DELETE FROM publicidad
        WHERE id_publicidad = p_id_publicidad;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25603, 'No se encontró la publicidad para eliminar.');
        END IF;
    END delete_publicidad;

END pkg_publicidad;
/