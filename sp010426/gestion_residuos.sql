------------------------------------------------------------
-- Paquete CRUD para la tabla GESTION_RESIDUOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_gestion_residuos AS
    PROCEDURE insert_residuo(
        p_fecha_recoleccion   IN DATE,
        p_tipo_residuo        IN VARCHAR2,
        p_cantidad_kg         IN NUMBER,
        p_origen              IN VARCHAR2,
        p_empresa_recolectora IN VARCHAR2,
        p_tratamiento         IN VARCHAR2,
        p_certificado_tratamiento IN VARCHAR2,
        p_costo_tratamiento   IN NUMBER,
        p_observaciones       IN VARCHAR2
    );

    PROCEDURE get_residuo(
        p_id_residuo IN NUMBER
    );

    PROCEDURE update_residuo(
        p_id_residuo           IN NUMBER,
        p_fecha_recoleccion    IN DATE,
        p_tipo_residuo         IN VARCHAR2,
        p_cantidad_kg          IN NUMBER,
        p_origen               IN VARCHAR2,
        p_empresa_recolectora  IN VARCHAR2,
        p_tratamiento          IN VARCHAR2,
        p_certificado_tratamiento IN VARCHAR2,
        p_costo_tratamiento    IN NUMBER,
        p_observaciones        IN VARCHAR2
    );

    PROCEDURE delete_residuo(
        p_id_residuo IN NUMBER
    );
END pkg_gestion_residuos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_gestion_residuos AS

    PROCEDURE insert_residuo(
        p_fecha_recoleccion   IN DATE,
        p_tipo_residuo        IN VARCHAR2,
        p_cantidad_kg         IN NUMBER,
        p_origen              IN VARCHAR2,
        p_empresa_recolectora IN VARCHAR2,
        p_tratamiento         IN VARCHAR2,
        p_certificado_tratamiento IN VARCHAR2,
        p_costo_tratamiento   IN NUMBER,
        p_observaciones       IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO gestion_residuos (
            fecha_recoleccion, tipo_residuo, cantidad_kg,
            origen, empresa_recolectora, tratamiento,
            certificado_tratamiento, costo_tratamiento, observaciones
        ) VALUES (
            p_fecha_recoleccion, p_tipo_residuo, p_cantidad_kg,
            p_origen, p_empresa_recolectora, p_tratamiento,
            p_certificado_tratamiento, p_costo_tratamiento, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31601, 'Error al insertar residuo: ' || SQLERRM);
    END insert_residuo;

    PROCEDURE get_residuo(
        p_id_residuo IN NUMBER
    ) IS
        r gestion_residuos%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM gestion_residuos
        WHERE id_residuo = p_id_residuo;

        DBMS_OUTPUT.PUT_LINE('ID Residuo: ' || r.id_residuo);
        DBMS_OUTPUT.PUT_LINE('Fecha recolección: ' || r.fecha_recoleccion);
        DBMS_OUTPUT.PUT_LINE('Tipo residuo: ' || r.tipo_residuo);
        DBMS_OUTPUT.PUT_LINE('Cantidad (kg): ' || r.cantidad_kg);
        DBMS_OUTPUT.PUT_LINE('Origen: ' || r.origen);
        DBMS_OUTPUT.PUT_LINE('Empresa recolectora: ' || r.empresa_recolectora);
        DBMS_OUTPUT.PUT_LINE('Tratamiento: ' || r.tratamiento);
        DBMS_OUTPUT.PUT_LINE('Certificado tratamiento: ' || r.certificado_tratamiento);
        DBMS_OUTPUT.PUT_LINE('Costo tratamiento: ' || r.costo_tratamiento);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Residuo no encontrado.');
    END get_residuo;

    PROCEDURE update_residuo(
        p_id_residuo           IN NUMBER,
        p_fecha_recoleccion    IN DATE,
        p_tipo_residuo         IN VARCHAR2,
        p_cantidad_kg          IN NUMBER,
        p_origen               IN VARCHAR2,
        p_empresa_recolectora  IN VARCHAR2,
        p_tratamiento          IN VARCHAR2,
        p_certificado_tratamiento IN VARCHAR2,
        p_costo_tratamiento    IN NUMBER,
        p_observaciones        IN VARCHAR2
    ) IS
    BEGIN
        UPDATE gestion_residuos
        SET fecha_recoleccion    = p_fecha_recoleccion,
            tipo_residuo         = p_tipo_residuo,
            cantidad_kg          = p_cantidad_kg,
            origen               = p_origen,
            empresa_recolectora  = p_empresa_recolectora,
            tratamiento          = p_tratamiento,
            certificado_tratamiento = p_certificado_tratamiento,
            costo_tratamiento    = p_costo_tratamiento,
            observaciones        = p_observaciones
        WHERE id_residuo = p_id_residuo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31602, 'No se encontró el residuo para actualizar.');
        END IF;
    END update_residuo;

    PROCEDURE delete_residuo(
        p_id_residuo IN NUMBER
    ) IS
    BEGIN
        DELETE FROM gestion_residuos
        WHERE id_residuo = p_id_residuo;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31603, 'No se encontró el residuo para eliminar.');
        END IF;
    END delete_residuo;

END pkg_gestion_residuos;
/
