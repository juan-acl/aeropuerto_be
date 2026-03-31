------------------------------------------------------------
-- Paquete CRUD para la tabla EQUIPAJE_ESPECIAL
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_equipaje_especial AS
    PROCEDURE insert_equipaje(
        p_id_reserva          IN equipaje_especial.id_reserva%TYPE,
        p_tipo_equipaje       IN equipaje_especial.tipo_equipaje%TYPE,
        p_peso_kg             IN equipaje_especial.peso_kg%TYPE,
        p_dimensiones         IN equipaje_especial.dimensiones%TYPE,
        p_contenido           IN equipaje_especial.contenido%TYPE,
        p_requiere_autorizacion IN equipaje_especial.requiere_autorizacion%TYPE DEFAULT 1,
        p_autorizado          IN equipaje_especial.autorizado%TYPE DEFAULT 0,
        p_costo_adicional     IN equipaje_especial.costo_adicional%TYPE
    );

    PROCEDURE get_equipaje(
        p_id_equipaje_especial IN equipaje_especial.id_equipaje_especial%TYPE
    );

    PROCEDURE update_equipaje(
        p_id_equipaje_especial IN equipaje_especial.id_equipaje_especial%TYPE,
        p_id_reserva           IN equipaje_especial.id_reserva%TYPE,
        p_tipo_equipaje        IN equipaje_especial.tipo_equipaje%TYPE,
        p_peso_kg              IN equipaje_especial.peso_kg%TYPE,
        p_dimensiones          IN equipaje_especial.dimensiones%TYPE,
        p_contenido            IN equipaje_especial.contenido%TYPE,
        p_requiere_autorizacion IN equipaje_especial.requiere_autorizacion%TYPE,
        p_autorizado           IN equipaje_especial.autorizado%TYPE,
        p_costo_adicional      IN equipaje_especial.costo_adicional%TYPE
    );

    PROCEDURE delete_equipaje(
        p_id_equipaje_especial IN equipaje_especial.id_equipaje_especial%TYPE
    );
END pkg_equipaje_especial;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_equipaje_especial AS

    PROCEDURE insert_equipaje(
        p_id_reserva          IN equipaje_especial.id_reserva%TYPE,
        p_tipo_equipaje       IN equipaje_especial.tipo_equipaje%TYPE,
        p_peso_kg             IN equipaje_especial.peso_kg%TYPE,
        p_dimensiones         IN equipaje_especial.dimensiones%TYPE,
        p_contenido           IN equipaje_especial.contenido%TYPE,
        p_requiere_autorizacion IN equipaje_especial.requiere_autorizacion%TYPE,
        p_autorizado          IN equipaje_especial.autorizado%TYPE,
        p_costo_adicional     IN equipaje_especial.costo_adicional%TYPE
    ) IS
    BEGIN
        INSERT INTO equipaje_especial (
            id_reserva, tipo_equipaje, peso_kg, dimensiones,
            contenido, requiere_autorizacion, autorizado, costo_adicional
        ) VALUES (
            p_id_reserva, p_tipo_equipaje, p_peso_kg, p_dimensiones,
            p_contenido, NVL(p_requiere_autorizacion,1), NVL(p_autorizado,0), p_costo_adicional
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-22801, 'Error al insertar equipaje especial: ' || SQLERRM);
    END insert_equipaje;

    PROCEDURE get_equipaje(
        p_id_equipaje_especial IN equipaje_especial.id_equipaje_especial%TYPE
    ) IS
        r equipaje_especial%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM equipaje_especial
        WHERE id_equipaje_especial = p_id_equipaje_especial;

        DBMS_OUTPUT.PUT_LINE('ID Equipaje: ' || r.id_equipaje_especial);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Tipo equipaje: ' || r.tipo_equipaje);
        DBMS_OUTPUT.PUT_LINE('Peso (kg): ' || r.peso_kg);
        DBMS_OUTPUT.PUT_LINE('Dimensiones: ' || r.dimensiones);
        DBMS_OUTPUT.PUT_LINE('Contenido: ' || r.contenido);
        DBMS_OUTPUT.PUT_LINE('Requiere autorización: ' || r.requiere_autorizacion);
        DBMS_OUTPUT.PUT_LINE('Autorizado: ' || r.autorizado);
        DBMS_OUTPUT.PUT_LINE('Costo adicional: ' || r.costo_adicional);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Equipaje especial no encontrado.');
    END get_equipaje;

    PROCEDURE update_equipaje(
        p_id_equipaje_especial IN equipaje_especial.id_equipaje_especial%TYPE,
        p_id_reserva           IN equipaje_especial.id_reserva%TYPE,
        p_tipo_equipaje        IN equipaje_especial.tipo_equipaje%TYPE,
        p_peso_kg              IN equipaje_especial.peso_kg%TYPE,
        p_dimensiones          IN equipaje_especial.dimensiones%TYPE,
        p_contenido            IN equipaje_especial.contenido%TYPE,
        p_requiere_autorizacion IN equipaje_especial.requiere_autorizacion%TYPE,
        p_autorizado           IN equipaje_especial.autorizado%TYPE,
        p_costo_adicional      IN equipaje_especial.costo_adicional%TYPE
    ) IS
    BEGIN
        UPDATE equipaje_especial
        SET id_reserva           = p_id_reserva,
            tipo_equipaje        = p_tipo_equipaje,
            peso_kg              = p_peso_kg,
            dimensiones          = p_dimensiones,
            contenido            = p_contenido,
            requiere_autorizacion = p_requiere_autorizacion,
            autorizado           = p_autorizado,
            costo_adicional      = p_costo_adicional
        WHERE id_equipaje_especial = p_id_equipaje_especial;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22802, 'No se encontró el equipaje especial para actualizar.');
        END IF;
    END update_equipaje;

    PROCEDURE delete_equipaje(
        p_id_equipaje_especial IN equipaje_especial.id_equipaje_especial%TYPE
    ) IS
    BEGIN
        DELETE FROM equipaje_especial
        WHERE id_equipaje_especial = p_id_equipaje_especial;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-22803, 'No se encontró el equipaje especial para eliminar.');
        END IF;
    END delete_equipaje;

END pkg_equipaje_especial;
/