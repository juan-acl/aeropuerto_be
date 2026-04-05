------------------------------------------------------------
-- Paquete CRUD para la tabla VEHICULOS_TRANSPORTE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_vehiculos_transporte AS
    PROCEDURE insert_vehiculo(
        p_placa                    IN VARCHAR2,
        p_tipo_vehiculo            IN VARCHAR2,
        p_marca                    IN VARCHAR2,
        p_modelo                   IN VARCHAR2,
        p_anio                     IN NUMBER,
        p_capacidad_pasajeros      IN NUMBER,
        p_capacidad_maletas        IN NUMBER,
        p_tiene_aire_acondicionado IN NUMBER DEFAULT 1,
        p_tiene_wifi               IN NUMBER DEFAULT 0,
        p_tiene_accesibilidad      IN NUMBER DEFAULT 0,
        p_propietario              IN VARCHAR2,
        p_empresa_operadora        IN VARCHAR2,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_disponible               IN NUMBER DEFAULT 1,
        p_activo                   IN NUMBER DEFAULT 1
    );

    PROCEDURE get_vehiculo(
        p_id_vehiculo_transporte IN NUMBER
    );

    PROCEDURE update_vehiculo(
        p_id_vehiculo_transporte IN NUMBER,
        p_placa                    IN VARCHAR2,
        p_tipo_vehiculo            IN VARCHAR2,
        p_marca                    IN VARCHAR2,
        p_modelo                   IN VARCHAR2,
        p_anio                     IN NUMBER,
        p_capacidad_pasajeros      IN NUMBER,
        p_capacidad_maletas        IN NUMBER,
        p_tiene_aire_acondicionado IN NUMBER,
        p_tiene_wifi               IN NUMBER,
        p_tiene_accesibilidad      IN NUMBER,
        p_propietario              IN VARCHAR2,
        p_empresa_operadora        IN VARCHAR2,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_disponible               IN NUMBER,
        p_activo                   IN NUMBER
    );

    PROCEDURE delete_vehiculo(
        p_id_vehiculo_transporte IN NUMBER
    );
END pkg_vehiculos_transporte;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_vehiculos_transporte AS

    PROCEDURE insert_vehiculo(
        p_placa                    IN VARCHAR2,
        p_tipo_vehiculo            IN VARCHAR2,
        p_marca                    IN VARCHAR2,
        p_modelo                   IN VARCHAR2,
        p_anio                     IN NUMBER,
        p_capacidad_pasajeros      IN NUMBER,
        p_capacidad_maletas        IN NUMBER,
        p_tiene_aire_acondicionado IN NUMBER,
        p_tiene_wifi               IN NUMBER,
        p_tiene_accesibilidad      IN NUMBER,
        p_propietario              IN VARCHAR2,
        p_empresa_operadora        IN VARCHAR2,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_disponible               IN NUMBER,
        p_activo                   IN NUMBER
    ) IS
    BEGIN
        INSERT INTO vehiculos_transporte (
            placa, tipo_vehiculo, marca, modelo, anio,
            capacidad_pasajeros, capacidad_maletas,
            tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad,
            propietario, empresa_operadora,
            fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento,
            disponible, activo
        ) VALUES (
            p_placa, p_tipo_vehiculo, p_marca, p_modelo, p_anio,
            p_capacidad_pasajeros, p_capacidad_maletas,
            NVL(p_tiene_aire_acondicionado,1), NVL(p_tiene_wifi,0), NVL(p_tiene_accesibilidad,0),
            p_propietario, p_empresa_operadora,
            p_fecha_ultimo_mantenimiento, p_fecha_proximo_mantenimiento,
            NVL(p_disponible,1), NVL(p_activo,1)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-34601, 'Error al insertar vehículo de transporte: ' || SQLERRM);
    END insert_vehiculo;

    PROCEDURE get_vehiculo(
        p_id_vehiculo_transporte IN NUMBER
    ) IS
        r vehiculos_transporte%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM vehiculos_transporte
        WHERE id_vehiculo_transporte = p_id_vehiculo_transporte;

        DBMS_OUTPUT.PUT_LINE('ID Vehículo: ' || r.id_vehiculo_transporte);
        DBMS_OUTPUT.PUT_LINE('Placa: ' || r.placa);
        DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_vehiculo);
        DBMS_OUTPUT.PUT_LINE('Marca: ' || r.marca);
        DBMS_OUTPUT.PUT_LINE('Modelo: ' || r.modelo);
        DBMS_OUTPUT.PUT_LINE('Año: ' || r.anio);
        DBMS_OUTPUT.PUT_LINE('Capacidad pasajeros: ' || r.capacidad_pasajeros);
        DBMS_OUTPUT.PUT_LINE('Capacidad maletas: ' || r.capacidad_maletas);
        DBMS_OUTPUT.PUT_LINE('Aire acondicionado: ' || r.tiene_aire_acondicionado);
        DBMS_OUTPUT.PUT_LINE('WiFi: ' || r.tiene_wifi);
        DBMS_OUTPUT.PUT_LINE('Accesibilidad: ' || r.tiene_accesibilidad);
        DBMS_OUTPUT.PUT_LINE('Propietario: ' || r.propietario);
        DBMS_OUTPUT.PUT_LINE('Empresa operadora: ' || r.empresa_operadora);
        DBMS_OUTPUT.PUT_LINE('Último mantenimiento: ' || r.fecha_ultimo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Próximo mantenimiento: ' || r.fecha_proximo_mantenimiento);
        DBMS_OUTPUT.PUT_LINE('Disponible: ' || r.disponible);
        DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Vehículo de transporte no encontrado.');
    END get_vehiculo;

    PROCEDURE update_vehiculo(
        p_id_vehiculo_transporte IN NUMBER,
        p_placa                    IN VARCHAR2,
        p_tipo_vehiculo            IN VARCHAR2,
        p_marca                    IN VARCHAR2,
        p_modelo                   IN VARCHAR2,
        p_anio                     IN NUMBER,
        p_capacidad_pasajeros      IN NUMBER,
        p_capacidad_maletas        IN NUMBER,
        p_tiene_aire_acondicionado IN NUMBER,
        p_tiene_wifi               IN NUMBER,
        p_tiene_accesibilidad      IN NUMBER,
        p_propietario              IN VARCHAR2,
        p_empresa_operadora        IN VARCHAR2,
        p_fecha_ultimo_mantenimiento IN DATE,
        p_fecha_proximo_mantenimiento IN DATE,
        p_disponible               IN NUMBER,
        p_activo                   IN NUMBER
    ) IS
    BEGIN
        UPDATE vehiculos_transporte
        SET placa                    = p_placa,
            tipo_vehiculo            = p_tipo_vehiculo,
            marca                    = p_marca,
            modelo                   = p_modelo,
            anio                     = p_anio,
            capacidad_pasajeros      = p_capacidad_pasajeros,
            capacidad_maletas        = p_capacidad_maletas,
            tiene_aire_acondicionado = p_tiene_aire_acondicionado,
            tiene_wifi               = p_tiene_wifi,
            tiene_accesibilidad      = p_tiene_accesibilidad,
            propietario              = p_propietario,
            empresa_operadora        = p_empresa_operadora,
            fecha_ultimo_mantenimiento = p_fecha_ultimo_mantenimiento,
            fecha_proximo_mantenimiento = p_fecha_proximo_mantenimiento,
            disponible               = p_disponible,
            activo                   = p_activo
        WHERE id_vehiculo_transporte = p_id_vehiculo_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34602, 'No se encontró el vehículo de transporte para actualizar.');
        END IF;
    END update_vehiculo;

    PROCEDURE delete_vehiculo(
        p_id_vehiculo_transporte IN NUMBER
    ) IS
    BEGIN
        DELETE FROM vehiculos_transporte
        WHERE id_vehiculo_transporte = p_id_vehiculo_transporte;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-34603, 'No se encontró el vehículo de transporte para eliminar.');
        END IF;
    END delete_vehiculo;

END pkg_vehiculos_transporte;
/
