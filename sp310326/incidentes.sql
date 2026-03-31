------------------------------------------------------------
-- Paquete CRUD para la tabla INCIDENTES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_incidentes AS
    PROCEDURE insert_incidente(
        p_id_pasajero          IN NUMBER,
        p_id_vuelo             IN NUMBER,
        p_codigo_aeropuerto    IN VARCHAR2,
        p_fecha_incidente      IN DATE DEFAULT SYSDATE,
        p_hora_incidente       IN TIMESTAMP,
        p_tipo_incidente       IN VARCHAR2,
        p_nivel_gravedad       IN VARCHAR2,
        p_descripcion          IN VARCHAR2,
        p_lugar_incidente      IN VARCHAR2,
        p_autoridad_involucrada IN VARCHAR2,
        p_oficial_a_cargo      IN VARCHAR2,
        p_resolucion           IN VARCHAR2,
        p_fecha_resolucion     IN DATE,
        p_estado               IN VARCHAR2 DEFAULT 'ACTIVO',
        p_requiere_seguimiento IN NUMBER DEFAULT 0
    );

    PROCEDURE get_incidente(
        p_id_incidente IN NUMBER
    );

    PROCEDURE update_incidente(
        p_id_incidente         IN NUMBER,
        p_id_pasajero          IN NUMBER,
        p_id_vuelo             IN NUMBER,
        p_codigo_aeropuerto    IN VARCHAR2,
        p_fecha_incidente      IN DATE,
        p_hora_incidente       IN TIMESTAMP,
        p_tipo_incidente       IN VARCHAR2,
        p_nivel_gravedad       IN VARCHAR2,
        p_descripcion          IN VARCHAR2,
        p_lugar_incidente      IN VARCHAR2,
        p_autoridad_involucrada IN VARCHAR2,
        p_oficial_a_cargo      IN VARCHAR2,
        p_resolucion           IN VARCHAR2,
        p_fecha_resolucion     IN DATE,
        p_estado               IN VARCHAR2,
        p_requiere_seguimiento IN NUMBER
    );

    PROCEDURE delete_incidente(
        p_id_incidente IN NUMBER
    );
END pkg_incidentes;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_incidentes AS

    PROCEDURE insert_incidente(
        p_id_pasajero          IN NUMBER,
        p_id_vuelo             IN NUMBER,
        p_codigo_aeropuerto    IN VARCHAR2,
        p_fecha_incidente      IN DATE,
        p_hora_incidente       IN TIMESTAMP,
        p_tipo_incidente       IN VARCHAR2,
        p_nivel_gravedad       IN VARCHAR2,
        p_descripcion          IN VARCHAR2,
        p_lugar_incidente      IN VARCHAR2,
        p_autoridad_involucrada IN VARCHAR2,
        p_oficial_a_cargo      IN VARCHAR2,
        p_resolucion           IN VARCHAR2,
        p_fecha_resolucion     IN DATE,
        p_estado               IN VARCHAR2,
        p_requiere_seguimiento IN NUMBER
    ) IS
    BEGIN
        INSERT INTO incidentes (
            id_pasajero, id_vuelo, codigo_aeropuerto,
            fecha_incidente, hora_incidente, tipo_incidente,
            nivel_gravedad, descripcion, lugar_incidente,
            autoridad_involucrada, oficial_a_cargo,
            resolucion, fecha_resolucion, estado,
            requiere_seguimiento
        ) VALUES (
            p_id_pasajero, p_id_vuelo, p_codigo_aeropuerto,
            NVL(p_fecha_incidente, SYSDATE), p_hora_incidente, p_tipo_incidente,
            p_nivel_gravedad, p_descripcion, p_lugar_incidente,
            p_autoridad_involucrada, p_oficial_a_cargo,
            p_resolucion, p_fecha_resolucion, NVL(p_estado,'ACTIVO'),
            NVL(p_requiere_seguimiento,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-23401, 'Error al insertar incidente: ' || SQLERRM);
    END insert_incidente;

    PROCEDURE get_incidente(
        p_id_incidente IN NUMBER
    ) IS
        r incidentes%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM incidentes
        WHERE id_incidente = p_id_incidente;

        DBMS_OUTPUT.PUT_LINE('ID Incidente: ' || r.id_incidente);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Aeropuerto: ' || r.codigo_aeropuerto);
        DBMS_OUTPUT.PUT_LINE('Fecha incidente: ' || r.fecha_incidente);
        DBMS_OUTPUT.PUT_LINE('Hora incidente: ' || r.hora_incidente);
        DBMS_OUTPUT.PUT_LINE('Tipo incidente: ' || r.tipo_incidente);
        DBMS_OUTPUT.PUT_LINE('Nivel gravedad: ' || r.nivel_gravedad);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Lugar: ' || r.lugar_incidente);
        DBMS_OUTPUT.PUT_LINE('Autoridad involucrada: ' || r.autoridad_involucrada);
        DBMS_OUTPUT.PUT_LINE('Oficial a cargo: ' || r.oficial_a_cargo);
        DBMS_OUTPUT.PUT_LINE('Resolución: ' || r.resolucion);
        DBMS_OUTPUT.PUT_LINE('Fecha resolución: ' || r.fecha_resolucion);
        DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado);
        DBMS_OUTPUT.PUT_LINE('Requiere seguimiento: ' || r.requiere_seguimiento);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Incidente no encontrado.');
    END get_incidente;

    PROCEDURE update_incidente(
        p_id_incidente         IN NUMBER,
        p_id_pasajero          IN NUMBER,
        p_id_vuelo             IN NUMBER,
        p_codigo_aeropuerto    IN VARCHAR2,
        p_fecha_incidente      IN DATE,
        p_hora_incidente       IN TIMESTAMP,
        p_tipo_incidente       IN VARCHAR2,
        p_nivel_gravedad       IN VARCHAR2,
        p_descripcion          IN VARCHAR2,
        p_lugar_incidente      IN VARCHAR2,
        p_autoridad_involucrada IN VARCHAR2,
        p_oficial_a_cargo      IN VARCHAR2,
        p_resolucion           IN VARCHAR2,
        p_fecha_resolucion     IN DATE,
        p_estado               IN VARCHAR2,
        p_requiere_seguimiento IN NUMBER
    ) IS
    BEGIN
        UPDATE incidentes
        SET id_pasajero          = p_id_pasajero,
            id_vuelo             = p_id_vuelo,
            codigo_aeropuerto    = p_codigo_aeropuerto,
            fecha_incidente      = p_fecha_incidente,
            hora_incidente       = p_hora_incidente,
            tipo_incidente       = p_tipo_incidente,
            nivel_gravedad       = p_nivel_gravedad,
            descripcion          = p_descripcion,
            lugar_incidente      = p_lugar_incidente,
            autoridad_involucrada = p_autoridad_involucrada,
            oficial_a_cargo      = p_oficial_a_cargo,
            resolucion           = p_resolucion,
            fecha_resolucion     = p_fecha_resolucion,
            estado               = p_estado,
            requiere_seguimiento = p_requiere_seguimiento
        WHERE id_incidente = p_id_incidente;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23402, 'No se encontró el incidente para actualizar.');
        END IF;
    END update_incidente;

    PROCEDURE delete_incidente(
        p_id_incidente IN NUMBER
    ) IS
    BEGIN
        DELETE FROM incidentes
        WHERE id_incidente = p_id_incidente;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-23403, 'No se encontró el incidente para eliminar.');
        END IF;
    END delete_incidente;

END pkg_incidentes;
/