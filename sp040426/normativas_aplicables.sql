------------------------------------------------------------
-- Paquete CRUD para la tabla NORMATIVAS_APLICABLES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_normativas_aplicables AS
    PROCEDURE insert_normativa(
        p_codigo_normativa       IN VARCHAR2,
        p_titulo_normativa       IN VARCHAR2,
        p_descripcion            IN CLOB,
        p_entidad_emisora        IN VARCHAR2,
        p_pais_origen            IN VARCHAR2,
        p_ambito_aplicacion      IN VARCHAR2,
        p_fecha_publicacion      IN DATE,
        p_fecha_vigencia         IN DATE,
        p_fecha_ultima_actualizacion IN DATE,
        p_version                IN VARCHAR2,
        p_documento_oficial      IN BLOB,
        p_url_referencia         IN VARCHAR2,
        p_obligatoria            IN NUMBER DEFAULT 1,
        p_activa                 IN NUMBER DEFAULT 1
    );

    PROCEDURE get_normativa(
        p_id_normativa IN NUMBER
    );

    PROCEDURE update_normativa(
        p_id_normativa           IN NUMBER,
        p_codigo_normativa       IN VARCHAR2,
        p_titulo_normativa       IN VARCHAR2,
        p_descripcion            IN CLOB,
        p_entidad_emisora        IN VARCHAR2,
        p_pais_origen            IN VARCHAR2,
        p_ambito_aplicacion      IN VARCHAR2,
        p_fecha_publicacion      IN DATE,
        p_fecha_vigencia         IN DATE,
        p_fecha_ultima_actualizacion IN DATE,
        p_version                IN VARCHAR2,
        p_documento_oficial      IN BLOB,
        p_url_referencia         IN VARCHAR2,
        p_obligatoria            IN NUMBER,
        p_activa                 IN NUMBER
    );

    PROCEDURE delete_normativa(
        p_id_normativa IN NUMBER
    );
END pkg_normativas_aplicables;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_normativas_aplicables AS

    PROCEDURE insert_normativa(
        p_codigo_normativa       IN VARCHAR2,
        p_titulo_normativa       IN VARCHAR2,
        p_descripcion            IN CLOB,
        p_entidad_emisora        IN VARCHAR2,
        p_pais_origen            IN VARCHAR2,
        p_ambito_aplicacion      IN VARCHAR2,
        p_fecha_publicacion      IN DATE,
        p_fecha_vigencia         IN DATE,
        p_fecha_ultima_actualizacion IN DATE,
        p_version                IN VARCHAR2,
        p_documento_oficial      IN BLOB,
        p_url_referencia         IN VARCHAR2,
        p_obligatoria            IN NUMBER,
        p_activa                 IN NUMBER
    ) IS
    BEGIN
        INSERT INTO normativas_aplicables (
            codigo_normativa, titulo_normativa, descripcion,
            entidad_emisora, pais_origen, ambito_aplicacion,
            fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion,
            version, documento_oficial, url_referencia,
            obligatoria, activa
        ) VALUES (
            p_codigo_normativa, p_titulo_normativa, p_descripcion,
            p_entidad_emisora, p_pais_origen, p_ambito_aplicacion,
            p_fecha_publicacion, p_fecha_vigencia, p_fecha_ultima_actualizacion,
            p_version, p_documento_oficial, p_url_referencia,
            NVL(p_obligatoria,1), NVL(p_activa,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-33501, 'Error al insertar normativa: ' || SQLERRM);
    END insert_normativa;

    PROCEDURE get_normativa(
        p_id_normativa IN NUMBER
    ) IS
        r normativas_aplicables%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM normativas_aplicables
        WHERE id_normativa = p_id_normativa;

        DBMS_OUTPUT.PUT_LINE('ID Normativa: ' || r.id_normativa);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_normativa);
        DBMS_OUTPUT.PUT_LINE('Título: ' || r.titulo_normativa);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || DBMS_LOB.SUBSTR(r.descripcion, 200, 1));
        DBMS_OUTPUT.PUT_LINE('Entidad emisora: ' || r.entidad_emisora);
        DBMS_OUTPUT.PUT_LINE('País origen: ' || r.pais_origen);
        DBMS_OUTPUT.PUT_LINE('Ámbito aplicación: ' || r.ambito_aplicacion);
        DBMS_OUTPUT.PUT_LINE('Fecha publicación: ' || r.fecha_publicacion);
        DBMS_OUTPUT.PUT_LINE('Fecha vigencia: ' || r.fecha_vigencia);
        DBMS_OUTPUT.PUT_LINE('Fecha última actualización: ' || r.fecha_ultima_actualizacion);
        DBMS_OUTPUT.PUT_LINE('Versión: ' || r.version);
        IF r.documento_oficial IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Documento oficial: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento oficial: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('URL referencia: ' || r.url_referencia);
        DBMS_OUTPUT.PUT_LINE('Obligatoria: ' || r.obligatoria);
        DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Normativa no encontrada.');
    END get_normativa;

    PROCEDURE update_normativa(
        p_id_normativa           IN NUMBER,
        p_codigo_normativa       IN VARCHAR2,
        p_titulo_normativa       IN VARCHAR2,
        p_descripcion            IN CLOB,
        p_entidad_emisora        IN VARCHAR2,
        p_pais_origen            IN VARCHAR2,
        p_ambito_aplicacion      IN VARCHAR2,
        p_fecha_publicacion      IN DATE,
        p_fecha_vigencia         IN DATE,
        p_fecha_ultima_actualizacion IN DATE,
        p_version                IN VARCHAR2,
        p_documento_oficial      IN BLOB,
        p_url_referencia         IN VARCHAR2,
        p_obligatoria            IN NUMBER,
        p_activa                 IN NUMBER
    ) IS
    BEGIN
        UPDATE normativas_aplicables
        SET codigo_normativa       = p_codigo_normativa,
            titulo_normativa       = p_titulo_normativa,
            descripcion            = p_descripcion,
            entidad_emisora        = p_entidad_emisora,
            pais_origen            = p_pais_origen,
            ambito_aplicacion      = p_ambito_aplicacion,
            fecha_publicacion      = p_fecha_publicacion,
            fecha_vigencia         = p_fecha_vigencia,
            fecha_ultima_actualizacion = p_fecha_ultima_actualizacion,
            version                = p_version,
            documento_oficial      = p_documento_oficial,
            url_referencia         = p_url_referencia,
            obligatoria            = p_obligatoria,
            activa                 = p_activa
        WHERE id_normativa = p_id_normativa;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33502, 'No se encontró la normativa para actualizar.');
        END IF;
    END update_normativa;

    PROCEDURE delete_normativa(
        p_id_normativa IN NUMBER
    ) IS
    BEGIN
        DELETE FROM normativas_aplicables
        WHERE id_normativa = p_id_normativa;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-33503, 'No se encontró la normativa para eliminar.');
        END IF;
    END delete_normativa;

END pkg_normativas_aplicables;
/
