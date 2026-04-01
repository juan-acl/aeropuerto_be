------------------------------------------------------------
-- Paquete CRUD para la tabla HUELLA_CARBONO_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_huella_carbono_vuelo AS
    PROCEDURE insert_huella(
        p_id_vuelo                  IN NUMBER,
        p_combustible_consumido_litros IN NUMBER,
        p_factor_emision_co2        IN NUMBER,
        p_co2_emitido_kg            IN NUMBER,
        p_co2_por_pasajero_kg       IN NUMBER,
        p_co2_por_km                IN NUMBER,
        p_distancia_vuelo_km        IN NUMBER,
        p_categoria_vuelo           IN VARCHAR2,
        p_eficiencia_combustible_kg_km IN NUMBER,
        p_fecha_calculo             IN DATE DEFAULT SYSDATE,
        p_metodo_calculo            IN VARCHAR2,
        p_certificado_compensacion  IN NUMBER DEFAULT 0
    );

    PROCEDURE get_huella(
        p_id_huella_carbono IN NUMBER
    );

    PROCEDURE update_huella(
        p_id_huella_carbono         IN NUMBER,
        p_id_vuelo                  IN NUMBER,
        p_combustible_consumido_litros IN NUMBER,
        p_factor_emision_co2        IN NUMBER,
        p_co2_emitido_kg            IN NUMBER,
        p_co2_por_pasajero_kg       IN NUMBER,
        p_co2_por_km                IN NUMBER,
        p_distancia_vuelo_km        IN NUMBER,
        p_categoria_vuelo           IN VARCHAR2,
        p_eficiencia_combustible_kg_km IN NUMBER,
        p_fecha_calculo             IN DATE,
        p_metodo_calculo            IN VARCHAR2,
        p_certificado_compensacion  IN NUMBER
    );

    PROCEDURE delete_huella(
        p_id_huella_carbono IN NUMBER
    );
END pkg_huella_carbono_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_huella_carbono_vuelo AS

    PROCEDURE insert_huella(
        p_id_vuelo                  IN NUMBER,
        p_combustible_consumido_litros IN NUMBER,
        p_factor_emision_co2        IN NUMBER,
        p_co2_emitido_kg            IN NUMBER,
        p_co2_por_pasajero_kg       IN NUMBER,
        p_co2_por_km                IN NUMBER,
        p_distancia_vuelo_km        IN NUMBER,
        p_categoria_vuelo           IN VARCHAR2,
        p_eficiencia_combustible_kg_km IN NUMBER,
        p_fecha_calculo             IN DATE,
        p_metodo_calculo            IN VARCHAR2,
        p_certificado_compensacion  IN NUMBER
    ) IS
    BEGIN
        INSERT INTO huella_carbono_vuelo (
            id_vuelo, combustible_consumido_litros, factor_emision_co2,
            co2_emitido_kg, co2_por_pasajero_kg, co2_por_km,
            distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km,
            fecha_calculo, metodo_calculo, certificado_compensacion
        ) VALUES (
            p_id_vuelo, p_combustible_consumido_litros, p_factor_emision_co2,
            p_co2_emitido_kg, p_co2_por_pasajero_kg, p_co2_por_km,
            p_distancia_vuelo_km, p_categoria_vuelo, p_eficiencia_combustible_kg_km,
            NVL(p_fecha_calculo, SYSDATE), p_metodo_calculo, NVL(p_certificado_compensacion,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-31301, 'Error al insertar huella de carbono: ' || SQLERRM);
    END insert_huella;

    PROCEDURE get_huella(
        p_id_huella_carbono IN NUMBER
    ) IS
        r huella_carbono_vuelo%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM huella_carbono_vuelo
        WHERE id_huella_carbono = p_id_huella_carbono;

        DBMS_OUTPUT.PUT_LINE('ID Huella: ' || r.id_huella_carbono);
        DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
        DBMS_OUTPUT.PUT_LINE('Combustible consumido (litros): ' || r.combustible_consumido_litros);
        DBMS_OUTPUT.PUT_LINE('Factor emisión CO2: ' || r.factor_emision_co2);
        DBMS_OUTPUT.PUT_LINE('CO2 emitido (kg): ' || r.co2_emitido_kg);
        DBMS_OUTPUT.PUT_LINE('CO2 por pasajero (kg): ' || r.co2_por_pasajero_kg);
        DBMS_OUTPUT.PUT_LINE('CO2 por km: ' || r.co2_por_km);
        DBMS_OUTPUT.PUT_LINE('Distancia vuelo (km): ' || r.distancia_vuelo_km);
        DBMS_OUTPUT.PUT_LINE('Categoría vuelo: ' || r.categoria_vuelo);
        DBMS_OUTPUT.PUT_LINE('Eficiencia combustible (kg/km): ' || r.eficiencia_combustible_kg_km);
        DBMS_OUTPUT.PUT_LINE('Fecha cálculo: ' || r.fecha_calculo);
        DBMS_OUTPUT.PUT_LINE('Método cálculo: ' || r.metodo_calculo);
        DBMS_OUTPUT.PUT_LINE('Certificado compensación: ' || r.certificado_compensacion);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Huella de carbono no encontrada.');
    END get_huella;

    PROCEDURE update_huella(
        p_id_huella_carbono         IN NUMBER,
        p_id_vuelo                  IN NUMBER,
        p_combustible_consumido_litros IN NUMBER,
        p_factor_emision_co2        IN NUMBER,
        p_co2_emitido_kg            IN NUMBER,
        p_co2_por_pasajero_kg       IN NUMBER,
        p_co2_por_km                IN NUMBER,
        p_distancia_vuelo_km        IN NUMBER,
        p_categoria_vuelo           IN VARCHAR2,
        p_eficiencia_combustible_kg_km IN NUMBER,
        p_fecha_calculo             IN DATE,
        p_metodo_calculo            IN VARCHAR2,
        p_certificado_compensacion  IN NUMBER
    ) IS
    BEGIN
        UPDATE huella_carbono_vuelo
        SET id_vuelo                  = p_id_vuelo,
            combustible_consumido_litros = p_combustible_consumido_litros,
            factor_emision_co2        = p_factor_emision_co2,
            co2_emitido_kg            = p_co2_emitido_kg,
            co2_por_pasajero_kg       = p_co2_por_pasajero_kg,
            co2_por_km                = p_co2_por_km,
            distancia_vuelo_km        = p_distancia_vuelo_km,
            categoria_vuelo           = p_categoria_vuelo,
            eficiencia_combustible_kg_km = p_eficiencia_combustible_kg_km,
            fecha_calculo             = p_fecha_calculo,
            metodo_calculo            = p_metodo_calculo,
            certificado_compensacion  = p_certificado_compensacion
        WHERE id_huella_carbono = p_id_huella_carbono;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31302, 'No se encontró la huella de carbono para actualizar.');
        END IF;
    END update_huella;

    PROCEDURE delete_huella(
        p_id_huella_carbono IN NUMBER
    ) IS
    BEGIN
        DELETE FROM huella_carbono_vuelo
        WHERE id_huella_carbono = p_id_huella_carbono;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-31303, 'No se encontró la huella de carbono para eliminar.');
        END IF;
    END delete_huella;

END pkg_huella_carbono_vuelo;
/
