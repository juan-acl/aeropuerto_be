------------------------------------------------------------
-- Paquete CRUD para la tabla RECEPCIONES_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_recepciones_combustible AS
    PROCEDURE insert_recepcion(
        p_id_proveedor_combustible IN NUMBER,
        p_id_tanque                IN NUMBER,
        p_numero_guia              IN VARCHAR2,
        p_fecha_recepcion          IN TIMESTAMP DEFAULT SYSTIMESTAMP,
        p_cantidad_recibida_litros IN NUMBER,
        p_cantidad_facturada_litros IN NUMBER,
        p_temperatura_recepcion    IN NUMBER,
        p_densidad_recepcion       IN NUMBER,
        p_placa_camion             IN VARCHAR2,
        p_transportista            IN VARCHAR2,
        p_conductor                IN VARCHAR2,
        p_licencia_conductor       IN VARCHAR2,
        p_inspector_recibe         IN NUMBER,
        p_certificado_calidad      IN BLOB,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE get_recepcion(
        p_id_recepcion IN NUMBER
    );

    PROCEDURE update_recepcion(
        p_id_recepcion             IN NUMBER,
        p_id_proveedor_combustible IN NUMBER,
        p_id_tanque                IN NUMBER,
        p_numero_guia              IN VARCHAR2,
        p_fecha_recepcion          IN TIMESTAMP,
        p_cantidad_recibida_litros IN NUMBER,
        p_cantidad_facturada_litros IN NUMBER,
        p_temperatura_recepcion    IN NUMBER,
        p_densidad_recepcion       IN NUMBER,
        p_placa_camion             IN VARCHAR2,
        p_transportista            IN VARCHAR2,
        p_conductor                IN VARCHAR2,
        p_licencia_conductor       IN VARCHAR2,
        p_inspector_recibe         IN NUMBER,
        p_certificado_calidad      IN BLOB,
        p_observaciones            IN VARCHAR2
    );

    PROCEDURE delete_recepcion(
        p_id_recepcion IN NUMBER
    );
END pkg_recepciones_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_recepciones_combustible AS

    PROCEDURE insert_recepcion(
        p_id_proveedor_combustible IN NUMBER,
        p_id_tanque                IN NUMBER,
        p_numero_guia              IN VARCHAR2,
        p_fecha_recepcion          IN TIMESTAMP,
        p_cantidad_recibida_litros IN NUMBER,
        p_cantidad_facturada_litros IN NUMBER,
        p_temperatura_recepcion    IN NUMBER,
        p_densidad_recepcion       IN NUMBER,
        p_placa_camion             IN VARCHAR2,
        p_transportista            IN VARCHAR2,
        p_conductor                IN VARCHAR2,
        p_licencia_conductor       IN VARCHAR2,
        p_inspector_recibe         IN NUMBER,
        p_certificado_calidad      IN BLOB,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO recepciones_combustible (
            id_proveedor_combustible, id_tanque, numero_guia,
            fecha_recepcion, cantidad_recibida_litros, cantidad_facturada_litros,
            temperatura_recepcion, densidad_recepcion,
            placa_camion, transportista, conductor, licencia_conductor,
            inspector_recibe, certificado_calidad, observaciones
        ) VALUES (
            p_id_proveedor_combustible, p_id_tanque, p_numero_guia,
            NVL(p_fecha_recepcion, SYSTIMESTAMP), p_cantidad_recibida_litros, p_cantidad_facturada_litros,
            p_temperatura_recepcion, p_densidad_recepcion,
            p_placa_camion, p_transportista, p_conductor, p_licencia_conductor,
            p_inspector_recibe, p_certificado_calidad, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31201, 'Error al insertar recepción de combustible: ' || SQLERRM);
    END insert_recepcion;

    PROCEDURE get_recepcion(
        p_id_recepcion IN NUMBER
    ) IS
        r recepciones_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM recepciones_combustible
        WHERE id_recepcion = p_id_recepcion;

        DBMS_OUTPUT.PUT_LINE('ID Recepción: ' || r.id_recepcion);
        DBMS_OUTPUT.PUT_LINE('Proveedor combustible: ' || r.id_proveedor_combustible);
        DBMS_OUTPUT.PUT_LINE('Tanque: ' || r.id_tanque);
        DBMS_OUTPUT.PUT_LINE('Número guía: ' || r.numero_guia);
        DBMS_OUTPUT.PUT_LINE('Fecha recepción: ' || r.fecha_recepcion);
        DBMS_OUTPUT.PUT_LINE('Cantidad recibida (litros): ' || r.cantidad_recibida_litros);
        DBMS_OUTPUT.PUT_LINE('Cantidad facturada (litros): ' || r.cantidad_facturada_litros);
        DBMS_OUTPUT.PUT_LINE('Temperatura recepción: ' || r.temperatura_recepcion);
        DBMS_OUTPUT.PUT_LINE('Densidad recepción: ' || r.densidad_recepcion);
        DBMS_OUTPUT.PUT_LINE('Placa camión: ' || r.placa_camion);
        DBMS_OUTPUT.PUT_LINE('Transportista: ' || r.transportista);
        DBMS_OUTPUT.PUT_LINE('Conductor: ' || r.conductor);
        DBMS_OUTPUT.PUT_LINE('Licencia conductor: ' || r.licencia_conductor);
        DBMS_OUTPUT.PUT_LINE('Inspector recibe: ' || r.inspector_recibe);
        IF r.certificado_calidad IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Certificado calidad: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Certificado calidad: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Recepción de combustible no encontrada.');
    END get_recepcion;

    PROCEDURE update_recepcion(
        p_id_recepcion             IN NUMBER,
        p_id_proveedor_combustible IN NUMBER,
        p_id_tanque                IN NUMBER,
        p_numero_guia              IN VARCHAR2,
        p_fecha_recepcion          IN TIMESTAMP,
        p_cantidad_recibida_litros IN NUMBER,
        p_cantidad_facturada_litros IN NUMBER,
        p_temperatura_recepcion    IN NUMBER,
        p_densidad_recepcion       IN NUMBER,
        p_placa_camion             IN VARCHAR2,
        p_transportista            IN VARCHAR2,
        p_conductor                IN VARCHAR2,
        p_licencia_conductor       IN VARCHAR2,
        p_inspector_recibe         IN NUMBER,
        p_certificado_calidad      IN BLOB,
        p_observaciones            IN VARCHAR2
    ) IS
    BEGIN
        UPDATE recepciones_combustible
        SET id_proveedor_combustible = p_id_proveedor_combustible,
            id_tanque                = p_id_tanque,
            numero_guia              = p_numero_guia,
            fecha_recepcion          = p_fecha_recepcion,
            cantidad_recibida_litros = p_cantidad_recibida_litros,
            cantidad_facturada_litros = p_cantidad_facturada_litros,
            temperatura_recepcion    = p_temperatura_recepcion,
            densidad_recepcion       = p_densidad_recepcion,
            placa_camion             = p_placa_camion,
            transportista            = p_transportista,
            conductor                = p_conductor,
            licencia_conductor       = p_licencia_conductor,
            inspector_recibe         = p_inspector_recibe,
            certificado_calidad      = p_certificado_calidad,
            observaciones            = p_observaciones
        WHERE id_recepcion = p_id_recepcion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31202, 'No se encontró la recepción de combustible para actualizar.');
        END IF;
    END update_recepcion;

    PROCEDURE delete_recepcion(
        p_id_recepcion IN NUMBER
    ) IS
    BEGIN
        DELETE FROM recepciones_combustible
        WHERE id_recepcion = p_id_recepcion;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31203, 'No se encontró la recepción de combustible para eliminar.');
        END IF;
    END delete_recepcion;

END pkg_recepciones_combustible;
/
