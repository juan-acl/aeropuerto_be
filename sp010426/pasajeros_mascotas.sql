------------------------------------------------------------
-- Paquete CRUD para la tabla PASAJEROS_MASCOTAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pasajeros_mascotas AS
    PROCEDURE insert_mascota(
        p_id_pasajero               IN NUMBER,
        p_id_reserva                IN NUMBER,
        p_nombre_mascota            IN VARCHAR2,
        p_tipo_mascota              IN VARCHAR2,
        p_raza                      IN VARCHAR2,
        p_peso_kg                   IN NUMBER,
        p_certificado_salud         IN BLOB,
        p_vacunas                   IN VARCHAR2,
        p_transportadora_dimensiones IN VARCHAR2,
        p_autorizado                IN NUMBER DEFAULT 0
    );

    PROCEDURE get_mascota(
        p_id_mascota IN NUMBER
    );

    PROCEDURE update_mascota(
        p_id_mascota                IN NUMBER,
        p_id_pasajero               IN NUMBER,
        p_id_reserva                IN NUMBER,
        p_nombre_mascota            IN VARCHAR2,
        p_tipo_mascota              IN VARCHAR2,
        p_raza                      IN VARCHAR2,
        p_peso_kg                   IN NUMBER,
        p_certificado_salud         IN BLOB,
        p_vacunas                   IN VARCHAR2,
        p_transportadora_dimensiones IN VARCHAR2,
        p_autorizado                IN NUMBER
    );

    PROCEDURE delete_mascota(
        p_id_mascota IN NUMBER
    );
END pkg_pasajeros_mascotas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pasajeros_mascotas AS

    PROCEDURE insert_mascota(
        p_id_pasajero               IN NUMBER,
        p_id_reserva                IN NUMBER,
        p_nombre_mascota            IN VARCHAR2,
        p_tipo_mascota              IN VARCHAR2,
        p_raza                      IN VARCHAR2,
        p_peso_kg                   IN NUMBER,
        p_certificado_salud         IN BLOB,
        p_vacunas                   IN VARCHAR2,
        p_transportadora_dimensiones IN VARCHAR2,
        p_autorizado                IN NUMBER
    ) IS
    BEGIN
        INSERT INTO pasajeros_mascotas (
            id_pasajero, id_reserva, nombre_mascota, tipo_mascota,
            raza, peso_kg, certificado_salud, vacunas,
            transportadora_dimensiones, autorizado
        ) VALUES (
            p_id_pasajero, p_id_reserva, p_nombre_mascota, p_tipo_mascota,
            p_raza, p_peso_kg, p_certificado_salud, p_vacunas,
            p_transportadora_dimensiones, NVL(p_autorizado,0)
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28501, 'Error al insertar mascota de pasajero: ' || SQLERRM);
    END insert_mascota;

    PROCEDURE get_mascota(
        p_id_mascota IN NUMBER
    ) IS
        r pasajeros_mascotas%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM pasajeros_mascotas
        WHERE id_mascota = p_id_mascota;

        DBMS_OUTPUT.PUT_LINE('ID Mascota: ' || r.id_mascota);
        DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Nombre mascota: ' || r.nombre_mascota);
        DBMS_OUTPUT.PUT_LINE('Tipo mascota: ' || r.tipo_mascota);
        DBMS_OUTPUT.PUT_LINE('Raza: ' || r.raza);
        DBMS_OUTPUT.PUT_LINE('Peso (kg): ' || r.peso_kg);
        IF r.certificado_salud IS NOT NULL THEN
            DBMS_OUTPUT.PUT_LINE('Certificado salud: [BLOB almacenado]');
        ELSE
            DBMS_OUTPUT.PUT_LINE('Certificado salud: No adjunto');
        END IF;
        DBMS_OUTPUT.PUT_LINE('Vacunas: ' || r.vacunas);
        DBMS_OUTPUT.PUT_LINE('Transportadora: ' || r.transportadora_dimensiones);
        DBMS_OUTPUT.PUT_LINE('Autorizado: ' || r.autorizado);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Mascota de pasajero no encontrada.');
    END get_mascota;

    PROCEDURE update_mascota(
        p_id_mascota                IN NUMBER,
        p_id_pasajero               IN NUMBER,
        p_id_reserva                IN NUMBER,
        p_nombre_mascota            IN VARCHAR2,
        p_tipo_mascota              IN VARCHAR2,
        p_raza                      IN VARCHAR2,
        p_peso_kg                   IN NUMBER,
        p_certificado_salud         IN BLOB,
        p_vacunas                   IN VARCHAR2,
        p_transportadora_dimensiones IN VARCHAR2,
        p_autorizado                IN NUMBER
    ) IS
    BEGIN
        UPDATE pasajeros_mascotas
        SET id_pasajero               = p_id_pasajero,
            id_reserva                = p_id_reserva,
            nombre_mascota            = p_nombre_mascota,
            tipo_mascota              = p_tipo_mascota,
            raza                      = p_raza,
            peso_kg                   = p_peso_kg,
            certificado_salud         = p_certificado_salud,
            vacunas                   = p_vacunas,
            transportadora_dimensiones = p_transportadora_dimensiones,
            autorizado                = p_autorizado
        WHERE id_mascota = p_id_mascota;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28502, 'No se encontró la mascota para actualizar.');
        END IF;
    END update_mascota;

    PROCEDURE delete_mascota(
        p_id_mascota IN NUMBER
    ) IS
    BEGIN
        DELETE FROM pasajeros_mascotas
        WHERE id_mascota = p_id_mascota;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28503, 'No se encontró la mascota para eliminar.');
        END IF;
    END delete_mascota;

END pkg_pasajeros_mascotas;
/
