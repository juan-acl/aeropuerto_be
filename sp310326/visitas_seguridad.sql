------------------------------------------------------------
-- Paquete CRUD para la tabla VISITAS_SEGURIDAD
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_visitas_seguridad AS
    PROCEDURE insert_visita(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_fecha_visita        IN DATE,
        p_hora_entrada        IN TIMESTAMP,
        p_hora_salida         IN TIMESTAMP,
        p_nombre_visitante    IN VARCHAR2,
        p_tipo_documento      IN VARCHAR2,
        p_numero_documento    IN VARCHAR2,
        p_empresa             IN VARCHAR2,
        p_motivo_visita       IN VARCHAR2,
        p_persona_autoriza    IN VARCHAR2,
        p_area_visitada       IN VARCHAR2,
        p_escort_requerido    IN NUMBER DEFAULT 0,
        p_escort_asignado     IN VARCHAR2
    );

    PROCEDURE get_visita(
        p_id_visita IN NUMBER
    );

    PROCEDURE update_visita(
        p_id_visita           IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_fecha_visita        IN DATE,
        p_hora_entrada        IN TIMESTAMP,
        p_hora_salida         IN TIMESTAMP,
        p_nombre_visitante    IN VARCHAR2,
        p_tipo_documento      IN VARCHAR2,
        p_numero_documento    IN VARCHAR2,
        p_empresa             IN VARCHAR2,
        p_motivo_visita       IN VARCHAR2,
        p_persona_autoriza    IN VARCHAR2,
        p_area_visitada       IN VARCHAR2,
        p_escort_requerido    IN NUMBER,
        p_escort_asignado     IN VARCHAR2
    );

    PROCEDURE delete_visita(
        p_id_visita IN NUMBER
    );
END pkg_visitas_seguridad;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_visitas_seguridad AS

    PROCEDURE insert_visita(
        p_codigo_aeropuerto   IN VARCHAR2,
        p_fecha_visita        IN DATE,
        p_hora_entrada        IN TIMESTAMP,
        p_hora_salida         IN TIMESTAMP,
        p_nombre_visitante    IN VARCHAR2,
        p_tipo_documento      IN VARCHAR2,
        p_numero_documento    IN VARCHAR2,
        p_empresa             IN VARCHAR2,
        p_motivo_visita       IN VARCHAR2,
        p_persona_autoriza    IN VARCHAR2,
        p_area_visitada       IN VARCHAR2,
        p_escort_requerido    IN NUMBER,
        p_escort_asignado     IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO visitas_seguridad (
            codigo_aeropuerto, fecha_visita, hora_entrada, hora_salida,
            nombre_visitante, tipo_documento, numero_documento,
            empresa, motivo_visita, persona_autoriza, area_visitada,
            escort_requerido, escort_asignado
        ) VALUES (
            p_codigo_aeropuerto, p_fecha_visita, p_hora_entrada, p_hora_salida,
            p_nombre_visitante, p_tipo_documento, p_numero_documento,
            p_empresa, p_motivo_visita, p_persona_autoriza, p_area_visitada,
            NVL(p_escort_requerido,0), p_escort_asignado
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-24301, 'Error al insertar visita de seguridad: ' || SQLERRM);
    END insert_visita;

    PROCEDURE get_visita(
        p_id_visita IN NUMBER
    ) IS
        r visitas_seguridad%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM visitas_seguridad
        WHERE id_visita = p_id_visita;

        DBMS_OUTPUT.PUT_LINE('ID Visita: ' || r.id_visita);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Fecha visita: ' || r.fecha_visita);
        DBMS_OUTPUT.PUT_LINE('Hora entrada: ' || r.hora_entrada);
        DBMS_OUTPUT.PUT_LINE('Hora salida: ' || r.hora_salida);
        DBMS_OUTPUT.PUT_LINE('Nombre visitante: ' || r.nombre_visitante);
        DBMS_OUTPUT.PUT_LINE('Tipo documento: ' || r.tipo_documento);
        DBMS_OUTPUT.PUT_LINE('Número documento: ' || r.numero_documento);
        DBMS_OUTPUT.PUT_LINE('Empresa: ' || r.empresa);
        DBMS_OUTPUT.PUT_LINE('Motivo visita: ' || r.motivo_visita);
        DBMS_OUTPUT.PUT_LINE('Persona autoriza: ' || r.persona_autoriza);
        DBMS_OUTPUT.PUT_LINE('Área visitada: ' || r.area_visitada);
        DBMS_OUTPUT.PUT_LINE('Escort requerido: ' || r.escort_requerido);
        DBMS_OUTPUT.PUT_LINE('Escort asignado: ' || r.escort_asignado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Visita de seguridad no encontrada.');
    END get_visita;

    PROCEDURE update_visita(
        p_id_visita           IN NUMBER,
        p_codigo_aeropuerto   IN VARCHAR2,
        p_fecha_visita        IN DATE,
        p_hora_entrada        IN TIMESTAMP,
        p_hora_salida         IN TIMESTAMP,
        p_nombre_visitante    IN VARCHAR2,
        p_tipo_documento      IN VARCHAR2,
        p_numero_documento    IN VARCHAR2,
        p_empresa             IN VARCHAR2,
        p_motivo_visita       IN VARCHAR2,
        p_persona_autoriza    IN VARCHAR2,
        p_area_visitada       IN VARCHAR2,
        p_escort_requerido    IN NUMBER,
        p_escort_asignado     IN VARCHAR2
    ) IS
    BEGIN
        UPDATE visitas_seguridad
        SET codigo_aeropuerto   = p_codigo_aeropuerto,
            fecha_visita        = p_fecha_visita,
            hora_entrada        = p_hora_entrada,
            hora_salida         = p_hora_salida,
            nombre_visitante    = p_nombre_visitante,
            tipo_documento      = p_tipo_documento,
            numero_documento    = p_numero_documento,
            empresa             = p_empresa,
            motivo_visita       = p_motivo_visita,
            persona_autoriza    = p_persona_autoriza,
            area_visitada       = p_area_visitada,
            escort_requerido    = p_escort_requerido,
            escort_asignado     = p_escort_asignado
        WHERE id_visita = p_id_visita;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24302, 'No se encontró la visita de seguridad para actualizar.');
        END IF;
    END update_visita;

    PROCEDURE delete_visita(
        p_id_visita IN NUMBER
    ) IS
    BEGIN
        DELETE FROM visitas_seguridad
        WHERE id_visita = p_id_visita;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-24303, 'No se encontró la visita de seguridad para eliminar.');
        END IF;
    END delete_visita;

END pkg_visitas_seguridad;
/