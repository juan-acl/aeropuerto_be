------------------------------------------------------------
-- Paquete CRUD para la tabla CARGAS_COMBUSTIBLE
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_cargas_combustible AS
    PROCEDURE insert_carga(
        p_id_pedido_combustible IN NUMBER,
        p_id_surtidor           IN NUMBER,
        p_cantidad_real_litros  IN NUMBER,
        p_temperatura_combustible IN NUMBER,
        p_densidad_combustible  IN NUMBER,
        p_fecha_inicio_carga    IN TIMESTAMP,
        p_fecha_fin_carga       IN TIMESTAMP,
        p_duracion_minutos      IN NUMBER,
        p_operador_carga        IN NUMBER,
        p_verificador           IN NUMBER,
        p_lectura_inicial_contador IN NUMBER,
        p_lectura_final_contador IN NUMBER,
        p_incidencia_tecnica    IN NUMBER DEFAULT 0,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE get_carga(
        p_id_carga_combustible IN NUMBER
    );

    PROCEDURE update_carga(
        p_id_carga_combustible IN NUMBER,
        p_id_pedido_combustible IN NUMBER,
        p_id_surtidor           IN NUMBER,
        p_cantidad_real_litros  IN NUMBER,
        p_temperatura_combustible IN NUMBER,
        p_densidad_combustible  IN NUMBER,
        p_fecha_inicio_carga    IN TIMESTAMP,
        p_fecha_fin_carga       IN TIMESTAMP,
        p_duracion_minutos      IN NUMBER,
        p_operador_carga        IN NUMBER,
        p_verificador           IN NUMBER,
        p_lectura_inicial_contador IN NUMBER,
        p_lectura_final_contador IN NUMBER,
        p_incidencia_tecnica    IN NUMBER,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE delete_carga(
        p_id_carga_combustible IN NUMBER
    );
END pkg_cargas_combustible;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_cargas_combustible AS

    PROCEDURE insert_carga(
        p_id_pedido_combustible IN NUMBER,
        p_id_surtidor           IN NUMBER,
        p_cantidad_real_litros  IN NUMBER,
        p_temperatura_combustible IN NUMBER,
        p_densidad_combustible  IN NUMBER,
        p_fecha_inicio_carga    IN TIMESTAMP,
        p_fecha_fin_carga       IN TIMESTAMP,
        p_duracion_minutos      IN NUMBER,
        p_operador_carga        IN NUMBER,
        p_verificador           IN NUMBER,
        p_lectura_inicial_contador IN NUMBER,
        p_lectura_final_contador IN NUMBER,
        p_incidencia_tecnica    IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO cargas_combustible (
            id_pedido_combustible, id_surtidor, cantidad_real_litros,
            temperatura_combustible, densidad_combustible,
            fecha_inicio_carga, fecha_fin_carga, duracion_minutos,
            operador_carga, verificador,
            lectura_inicial_contador, lectura_final_contador,
            incidencia_tecnica, observaciones
        ) VALUES (
            p_id_pedido_combustible, p_id_surtidor, p_cantidad_real_litros,
            p_temperatura_combustible, p_densidad_combustible,
            p_fecha_inicio_carga, p_fecha_fin_carga, p_duracion_minutos,
            p_operador_carga, p_verificador,
            p_lectura_inicial_contador, p_lectura_final_contador,
            NVL(p_incidencia_tecnica,0), p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-30701, 'Error al insertar carga de combustible: ' || SQLERRM);
    END insert_carga;

    PROCEDURE get_carga(
        p_id_carga_combustible IN NUMBER
    ) IS
        r cargas_combustible%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM cargas_combustible
        WHERE id_carga_combustible = p_id_carga_combustible;

        DBMS_OUTPUT.PUT_LINE('ID Carga: ' || r.id_carga_combustible);
        DBMS_OUTPUT.PUT_LINE('Pedido: ' || r.id_pedido_combustible);
        DBMS_OUTPUT.PUT_LINE('Surtidor: ' || r.id_surtidor);
        DBMS_OUTPUT.PUT_LINE('Cantidad real (litros): ' || r.cantidad_real_litros);
        DBMS_OUTPUT.PUT_LINE('Temperatura: ' || r.temperatura_combustible);
        DBMS_OUTPUT.PUT_LINE('Densidad: ' || r.densidad_combustible);
        DBMS_OUTPUT.PUT_LINE('Fecha inicio carga: ' || r.fecha_inicio_carga);
        DBMS_OUTPUT.PUT_LINE('Fecha fin carga: ' || r.fecha_fin_carga);
        DBMS_OUTPUT.PUT_LINE('Duración (min): ' || r.duracion_minutos);
        DBMS_OUTPUT.PUT_LINE('Operador carga: ' || r.operador_carga);
        DBMS_OUTPUT.PUT_LINE('Verificador: ' || r.verificador);
        DBMS_OUTPUT.PUT_LINE('Lectura inicial contador: ' || r.lectura_inicial_contador);
        DBMS_OUTPUT.PUT_LINE('Lectura final contador: ' || r.lectura_final_contador);
        DBMS_OUTPUT.PUT_LINE('Incidencia técnica: ' || r.incidencia_tecnica);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Carga de combustible no encontrada.');
    END get_carga;

    PROCEDURE update_carga(
        p_id_carga_combustible IN NUMBER,
        p_id_pedido_combustible IN NUMBER,
        p_id_surtidor           IN NUMBER,
        p_cantidad_real_litros  IN NUMBER,
        p_temperatura_combustible IN NUMBER,
        p_densidad_combustible  IN NUMBER,
        p_fecha_inicio_carga    IN TIMESTAMP,
        p_fecha_fin_carga       IN TIMESTAMP,
        p_duracion_minutos      IN NUMBER,
        p_operador_carga        IN NUMBER,
        p_verificador           IN NUMBER,
        p_lectura_inicial_contador IN NUMBER,
        p_lectura_final_contador IN NUMBER,
        p_incidencia_tecnica    IN NUMBER,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        UPDATE cargas_combustible
        SET id_pedido_combustible = p_id_pedido_combustible,
            id_surtidor           = p_id_surtidor,
            cantidad_real_litros  = p_cantidad_real_litros,
            temperatura_combustible = p_temperatura_combustible,
            densidad_combustible  = p_densidad_combustible,
            fecha_inicio_carga    = p_fecha_inicio_carga,
            fecha_fin_carga       = p_fecha_fin_carga,
            duracion_minutos      = p_duracion_minutos,
            operador_carga        = p_operador_carga,
            verificador           = p_verificador,
            lectura_inicial_contador = p_lectura_inicial_contador,
            lectura_final_contador = p_lectura_final_contador,
            incidencia_tecnica    = p_incidencia_tecnica,
            observaciones         = p_observaciones
        WHERE id_carga_combustible = p_id_carga_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30702, 'No se encontró la carga de combustible para actualizar.');
        END IF;
    END update_carga;

    PROCEDURE delete_carga(
        p_id_carga_combustible IN NUMBER
    ) IS
    BEGIN
        DELETE FROM cargas_combustible
        WHERE id_carga_combustible = p_id_carga_combustible;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-30703, 'No se encontró la carga de combustible para eliminar.');
        END IF;
    END delete_carga;

END pkg_cargas_combustible;
/
