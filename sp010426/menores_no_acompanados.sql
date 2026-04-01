------------------------------------------------------------
-- Paquete CRUD para la tabla MENORES_NO_ACOMPANADOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_menores_no_acompanados AS
    PROCEDURE insert_menor(
        p_id_reserva             IN NUMBER,
        p_edad                   IN NUMBER,
        p_nombre_entrega_origen  IN VARCHAR2,
        p_relacion_origen        IN VARCHAR2,
        p_telefono_origen        IN VARCHAR2,
        p_nombre_recoge_destino  IN VARCHAR2,
        p_relacion_destino       IN VARCHAR2,
        p_telefono_destino       IN VARCHAR2,
        p_observaciones          IN VARCHAR2
    );

    PROCEDURE get_menor(
        p_id_menor IN NUMBER
    );

    PROCEDURE update_menor(
        p_id_menor              IN NUMBER,
        p_id_reserva            IN NUMBER,
        p_edad                  IN NUMBER,
        p_nombre_entrega_origen IN VARCHAR2,
        p_relacion_origen       IN VARCHAR2,
        p_telefono_origen       IN VARCHAR2,
        p_nombre_recoge_destino IN VARCHAR2,
        p_relacion_destino      IN VARCHAR2,
        p_telefono_destino      IN VARCHAR2,
        p_observaciones         IN VARCHAR2
    );

    PROCEDURE delete_menor(
        p_id_menor IN NUMBER
    );
END pkg_menores_no_acompanados;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_menores_no_acompanados AS

    PROCEDURE insert_menor(
        p_id_reserva             IN NUMBER,
        p_edad                   IN NUMBER,
        p_nombre_entrega_origen  IN VARCHAR2,
        p_relacion_origen        IN VARCHAR2,
        p_telefono_origen        IN VARCHAR2,
        p_nombre_recoge_destino  IN VARCHAR2,
        p_relacion_destino       IN VARCHAR2,
        p_telefono_destino       IN VARCHAR2,
        p_observaciones          IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO menores_no_acompanados (
            id_reserva, edad, nombre_entrega_origen, relacion_origen,
            telefono_origen, nombre_recoge_destino, relacion_destino,
            telefono_destino, observaciones
        ) VALUES (
            p_id_reserva, p_edad, p_nombre_entrega_origen, p_relacion_origen,
            p_telefono_origen, p_nombre_recoge_destino, p_relacion_destino,
            p_telefono_destino, p_observaciones
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-28201, 'Error al insertar menor no acompañado: ' || SQLERRM);
    END insert_menor;

    PROCEDURE get_menor(
        p_id_menor IN NUMBER
    ) IS
        r menores_no_acompanados%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM menores_no_acompanados
        WHERE id_menor = p_id_menor;

        DBMS_OUTPUT.PUT_LINE('ID Menor: ' || r.id_menor);
        DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
        DBMS_OUTPUT.PUT_LINE('Edad: ' || r.edad);
        DBMS_OUTPUT.PUT_LINE('Entrega origen: ' || r.nombre_entrega_origen || ' (' || r.relacion_origen || ') - ' || r.telefono_origen);
        DBMS_OUTPUT.PUT_LINE('Recoge destino: ' || r.nombre_recoge_destino || ' (' || r.relacion_destino || ') - ' || r.telefono_destino);
        DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Menor no acompañado no encontrado.');
    END get_menor;

    PROCEDURE update_menor(
        p_id_menor              IN NUMBER,
        p_id_reserva            IN NUMBER,
        p_edad                  IN NUMBER,
        p_nombre_entrega_origen IN VARCHAR2,
        p_relacion_origen       IN VARCHAR2,
        p_telefono_origen       IN VARCHAR2,
        p_nombre_recoge_destino IN VARCHAR2,
        p_relacion_destino      IN VARCHAR2,
        p_telefono_destino      IN VARCHAR2,
        p_observaciones         IN VARCHAR2
    ) IS
    BEGIN
        UPDATE menores_no_acompanados
        SET id_reserva            = p_id_reserva,
            edad                  = p_edad,
            nombre_entrega_origen = p_nombre_entrega_origen,
            relacion_origen       = p_relacion_origen,
            telefono_origen       = p_telefono_origen,
            nombre_recoge_destino = p_nombre_recoge_destino,
            relacion_destino      = p_relacion_destino,
            telefono_destino      = p_telefono_destino,
            observaciones         = p_observaciones
        WHERE id_menor = p_id_menor;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28202, 'No se encontró el menor para actualizar.');
        END IF;
    END update_menor;

    PROCEDURE delete_menor(
        p_id_menor IN NUMBER
    ) IS
    BEGIN
        DELETE FROM menores_no_acompanados
        WHERE id_menor = p_id_menor;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-28203, 'No se encontró el menor para eliminar.');
        END IF;
    END delete_menor;

END pkg_menores_no_acompanados;
/
