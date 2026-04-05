------------------------------------------------------------
-- Paquete CRUD para la tabla REPORTES_OACI
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_reportes_oaci AS
    PROCEDURE insert_reporte(
        p_tipo_reporte          IN VARCHAR2,
        p_periodo               IN VARCHAR2,
        p_fecha_inicio_periodo  IN DATE,
        p_fecha_fin_periodo     IN DATE,
        p_fecha_envio           IN DATE,
        p_contenido_reporte     IN CLOB,
        p_archivo_reporte       IN BLOB,
        p_estado                IN VARCHAR2 DEFAULT 'GENERADO',
        p_enviado_por           IN NUMBER,
        p_confirmacion_recibido IN NUMBER DEFAULT 0,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE get_reporte(
        p_id_reporte_oaci IN NUMBER
    );

    PROCEDURE update_reporte(
        p_id_reporte_oaci       IN NUMBER,
        p_tipo_reporte          IN VARCHAR2,
        p_periodo               IN VARCHAR2,
        p_fecha_inicio_periodo  IN DATE,
        p_fecha_fin_periodo     IN DATE,
        p_fecha_envio           IN DATE,
        p_contenido_reporte     IN CLOB,
        p_archivo_reporte       IN BLOB,
        p_estado                IN VARCHAR2,
        p_enviado_por           IN NUMBER,
        p_confirmacion_recibido IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE delete_reporte(
        p_id_reporte_oaci IN NUMBER
    );
END pkg_reportes_oaci;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_reportes_oaci AS

    PROCEDURE insert_reporte(
        p_tipo_reporte          IN VARCHAR2,
        p_periodo               IN VARCHAR2,
        p_fecha_inicio_periodo  IN DATE,
        p_fecha_fin_periodo     IN DATE,
        p_fecha_envio           IN DATE,
        p_contenido_reporte     IN CLOB,
        p_archivo_reporte       IN BLOB,
        p_estado                IN VARCHAR2,
        p_enviado_por           IN NUMBER,
        p_confirmacion_recibido IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO reportes_oaci (
            tipo_reporte, periodo, fecha_inicio_periodo, fecha_fin_periodo,
            fecha_envio, contenido_reporte, archivo_reporte,
            estado, enviado_por, confirmacion_recibido, observaciones
        ) VALUES (
            p_tipo_reporte, p_periodo, p_fecha_inicio_periodo, p_fecha_fin_periodo,
            p_fecha_envio, p_contenido_reporte, p_archivo_reporte,
            NVL(p_estado,'GENERADO'), p_enviado_por, NVL(p_confirmacion_recibido,0), p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-36501, 'Error al insertar reporte OACI: ' || SQLERRM);
    END insert_reporte;

    PROCEDURE get_reporte(
        p_id_reporte_oaci IN NUMBER
    ) IS
        r reportes_oaci%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM reportes_oaci
        WHERE id_reporte_oaci = p_id_reporte_oaci;

        DBMS_OUTPUT.PUT_LINE('ID Reporte: ' || r.id_reporte_oaci);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_reporte);
        DBMS_OUTPUT.PUT_LINE('Periodo: ' || r.periodo);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio_periodo);
        DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin_periodo);
        DBMS_OUTPUT.PUT_LINE('Fecha envío: ' || r.fecha_envio);
        DBMS_OUTPUT.PUT_LINE('Contenido: ' || DBMS_LOB.SUBSTR(r.contenido_reporte,200,1));
        IF r.archivo_reporte IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Archivo reporte: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Archivo reporte: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Enviado por: ' || r.enviado_por);
        DBMS_OUTPUT.PUT_LINE('Confirmación recibido: ' || r.confirmacion_recibido);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Reporte OACI no encontrado.');
    END get_reporte;

    PROCEDURE update_reporte(
        p_id_reporte_oaci       IN NUMBER,
        p_tipo_reporte          IN VARCHAR2,
        p_periodo               IN VARCHAR2,
        p_fecha_inicio_periodo  IN DATE,
        p_fecha_fin_periodo     IN DATE,
        p_fecha_envio           IN DATE,
        p_contenido_reporte     IN CLOB,
        p_archivo_reporte       IN BLOB,
        p_estado                IN VARCHAR2,
        p_enviado_por           IN NUMBER,
        p_confirmacion_recibido IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        UPDATE reportes_oaci
        SET tipo_reporte          = p_tipo_reporte,
            periodo               = p_periodo,
            fecha_inicio_periodo  = p_fecha_inicio_periodo,
            fecha_fin_periodo     = p_fecha_fin_periodo,
            fecha_envio           = p_fecha_envio,
            contenido_reporte     = p_contenido_reporte,
            archivo_reporte       = p_archivo_reporte,
            estado                = p_estado,
            enviado_por           = p_enviado_por,
            confirmacion_recibido = p_confirmacion_recibido,
            observaciones         = p_observaciones
        WHERE id_reporte_oaci = p_id_reporte_oaci;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36502, 'No se encontró el reporte OACI para actualizar.');
        END IF;
    END update_reporte;

    PROCEDURE delete_reporte(
        p_id_reporte_oaci IN NUMBER
    ) IS
    BEGIN
        DELETE FROM reportes_oaci
        WHERE id_reporte_oaci = p_id_reporte_oaci;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-36503, 'No se encontró el reporte OACI para eliminar.');
        END IF;
    END delete_reporte;

END pkg_reportes_oaci;
/
