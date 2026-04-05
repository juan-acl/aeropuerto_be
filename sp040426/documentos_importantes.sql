------------------------------------------------------------
-- Paquete CRUD para la tabla DOCUMENTOS_IMPORTANTES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_documentos_importantes AS
    PROCEDURE insert_documento(
        p_codigo_documento     IN VARCHAR2,
        p_titulo               IN VARCHAR2,
        p_tipo_documento       IN VARCHAR2,
        p_fecha_creacion       IN DATE DEFAULT SYSDATE,
        p_fecha_revision       IN DATE,
        p_version              IN VARCHAR2,
        p_autor                IN VARCHAR2,
        p_area_responsable     IN NUMBER,
        p_palabras_clave       IN VARCHAR2,
        p_resumen              IN CLOB,
        p_archivo_digital      IN BLOB,
        p_ubicacion_fisica     IN VARCHAR2,
        p_confidencial         IN NUMBER DEFAULT 0,
        p_niveles_acceso       IN VARCHAR2,
        p_activo               IN NUMBER DEFAULT 1
    );

    PROCEDURE get_documento(
        p_id_documento_importante IN NUMBER
    );

    PROCEDURE update_documento(
        p_id_documento_importante IN NUMBER,
        p_codigo_documento     IN VARCHAR2,
        p_titulo               IN VARCHAR2,
        p_tipo_documento       IN VARCHAR2,
        p_fecha_creacion       IN DATE,
        p_fecha_revision       IN DATE,
        p_version              IN VARCHAR2,
        p_autor                IN VARCHAR2,
        p_area_responsable     IN NUMBER,
        p_palabras_clave       IN VARCHAR2,
        p_resumen              IN CLOB,
        p_archivo_digital      IN BLOB,
        p_ubicacion_fisica     IN VARCHAR2,
        p_confidencial         IN NUMBER,
        p_niveles_acceso       IN VARCHAR2,
        p_activo               IN NUMBER
    );

    PROCEDURE delete_documento(
        p_id_documento_importante IN NUMBER
    );
END pkg_documentos_importantes;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_documentos_importantes AS

    PROCEDURE insert_documento(
        p_codigo_documento     IN VARCHAR2,
        p_titulo               IN VARCHAR2,
        p_tipo_documento       IN VARCHAR2,
        p_fecha_creacion       IN DATE,
        p_fecha_revision       IN DATE,
        p_version              IN VARCHAR2,
        p_autor                IN VARCHAR2,
        p_area_responsable     IN NUMBER,
        p_palabras_clave       IN VARCHAR2,
        p_resumen              IN CLOB,
        p_archivo_digital      IN BLOB,
        p_ubicacion_fisica     IN VARCHAR2,
        p_confidencial         IN NUMBER,
        p_niveles_acceso       IN VARCHAR2,
        p_activo               IN NUMBER
    ) IS
    BEGIN
        INSERT INTO documentos_importantes (
            codigo_documento, titulo, tipo_documento,
            fecha_creacion, fecha_revision, version,
            autor, area_responsable, palabras_clave,
            resumen, archivo_digital, ubicacion_fisica,
            confidencial, niveles_acceso, activo
        ) VALUES (
            p_codigo_documento, p_titulo, p_tipo_documento,
            NVL(p_fecha_creacion, SYSDATE), p_fecha_revision, p_version,
            p_autor, p_area_responsable, p_palabras_clave,
            p_resumen, p_archivo_digital, p_ubicacion_fisica,
            NVL(p_confidencial,0), p_niveles_acceso, NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34201, 'Error al insertar documento importante: ' || SQLERRM);
    END insert_documento;

    PROCEDURE get_documento(
        p_id_documento_importante IN NUMBER
    ) IS
        r documentos_importantes%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM documentos_importantes
        WHERE id_documento_importante = p_id_documento_importante;

        DBMS_OUTPUT.PUT_LINE('ID Documento: ' || r.id_documento_importante);
        DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_documento);
        DBMS_OUTPUT.PUT_LINE('Título: ' || r.titulo);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_documento);
        DBMS_OUTPUT.PUT_LINE('Fecha creación: ' || r.fecha_creacion);
        DBMS_OUTPUT.PUT_LINE('Fecha revisión: ' || r.fecha_revision);
        DBMS_OUTPUT.PUT_LINE('Versión: ' || r.version);
        DBMS_OUTPUT.PUT_LINE('Autor: ' || r.autor);
        DBMS_OUTPUT.PUT_LINE('Área responsable: ' || r.area_responsable);
        DBMS_OUTPUT.PUT_LINE('Palabras clave: ' || r.palabras_clave);
        DBMS_OUTPUT.PUT_LINE('Resumen: ' || DBMS_LOB.SUBSTR(r.resumen, 200, 1));
        IF r.archivo_digital IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Archivo digital: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Archivo digital: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Ubicación física: ' || r.ubicacion_fisica);
        DBMS_OUTPUT.PUT_LINE('Confidencial: ' || r.confidencial);
        DBMS_OUTPUT.PUT_LINE('Niveles acceso: ' || r.niveles_acceso);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Documento importante no encontrado.');
    END get_documento;

    PROCEDURE update_documento(
        p_id_documento_importante IN NUMBER,
        p_codigo_documento     IN VARCHAR2,
        p_titulo               IN VARCHAR2,
        p_tipo_documento       IN VARCHAR2,
        p_fecha_creacion       IN DATE,
        p_fecha_revision       IN DATE,
        p_version              IN VARCHAR2,
        p_autor                IN VARCHAR2,
        p_area_responsable     IN NUMBER,
        p_palabras_clave       IN VARCHAR2,
        p_resumen              IN CLOB,
        p_archivo_digital      IN BLOB,
        p_ubicacion_fisica     IN VARCHAR2,
        p_confidencial         IN NUMBER,
        p_niveles_acceso       IN VARCHAR2,
        p_activo               IN NUMBER
    ) IS
    BEGIN
        UPDATE documentos_importantes
        SET codigo_documento     = p_codigo_documento,
            titulo               = p_titulo,
            tipo_documento       = p_tipo_documento,
            fecha_creacion       = p_fecha_creacion,
            fecha_revision       = p_fecha_revision,
            version              = p_version,
            autor                = p_autor,
            area_responsable     = p_area_responsable,
            palabras_clave       = p_palabras_clave,
            resumen              = p_resumen,
            archivo_digital      = p_archivo_digital,
            ubicacion_fisica     = p_ubicacion_fisica,
            confidencial         = p_confidencial,
            niveles_acceso       = p_niveles_acceso,
            activo               = p_activo
        WHERE id_documento_importante = p_id_documento_importante;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34202, 'No se encontró el documento importante para actualizar.');
        END IF;
    END update_documento;

    PROCEDURE delete_documento(
        p_id_documento_importante IN NUMBER
    ) IS
    BEGIN
        DELETE FROM documentos_importantes
        WHERE id_documento_importante = p_id_documento_importante;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34203, 'No se encontró el documento importante para eliminar.');
        END IF;
    END delete_documento;

END pkg_documentos_importantes;
/
