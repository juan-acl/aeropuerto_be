------------------------------------------------------------
-- Paquete CRUD para la tabla RESTAURANTES_MENUS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_restaurantes_menus AS
    PROCEDURE insert_menu(
        p_id_concesion              IN NUMBER,
        p_nombre_plato              IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_categoria_menu            IN VARCHAR2,
        p_precio                    IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_disponible                IN NUMBER DEFAULT 1,
        p_tiempo_preparacion_minutos IN NUMBER,
        p_calorias                  IN NUMBER,
        p_restricciones_alimenticias IN VARCHAR2
    );

    PROCEDURE get_menu(
        p_id_menu IN NUMBER
    );

    PROCEDURE update_menu(
        p_id_menu                   IN NUMBER,
        p_id_concesion              IN NUMBER,
        p_nombre_plato              IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_categoria_menu            IN VARCHAR2,
        p_precio                    IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_disponible                IN NUMBER,
        p_tiempo_preparacion_minutos IN NUMBER,
        p_calorias                  IN NUMBER,
        p_restricciones_alimenticias IN VARCHAR2
    );

    PROCEDURE delete_menu(
        p_id_menu IN NUMBER
    );
END pkg_restaurantes_menus;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_restaurantes_menus AS

    PROCEDURE insert_menu(
        p_id_concesion              IN NUMBER,
        p_nombre_plato              IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_categoria_menu            IN VARCHAR2,
        p_precio                    IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_disponible                IN NUMBER,
        p_tiempo_preparacion_minutos IN NUMBER,
        p_calorias                  IN NUMBER,
        p_restricciones_alimenticias IN VARCHAR2
    ) IS
    BEGIN
        INSERT INTO restaurantes_menus (
            id_concesion, nombre_plato, descripcion, categoria_menu,
            precio, moneda, disponible, tiempo_preparacion_minutos,
            calorias, restricciones_alimenticias
        ) VALUES (
            p_id_concesion, p_nombre_plato, p_descripcion, p_categoria_menu,
            p_precio, p_moneda, NVL(p_disponible,1), p_tiempo_preparacion_minutos,
            p_calorias, p_restricciones_alimenticias
        );
    EXCEPTION
        WHEN OTHERS THEN
            RAISE_APPLICATION_ERROR(-25101, 'Error al insertar menú: ' || SQLERRM);
    END insert_menu;

    PROCEDURE get_menu(
        p_id_menu IN NUMBER
    ) IS
        r restaurantes_menus%ROWTYPE;
    BEGIN
        SELECT * INTO r
        FROM restaurantes_menus
        WHERE id_menu = p_id_menu;

        DBMS_OUTPUT.PUT_LINE('ID Menú: ' || r.id_menu);
        DBMS_OUTPUT.PUT_LINE('Concesión: ' || r.id_concesion);
        DBMS_OUTPUT.PUT_LINE('Plato: ' || r.nombre_plato);
        DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
        DBMS_OUTPUT.PUT_LINE('Categoría: ' || r.categoria_menu);
        DBMS_OUTPUT.PUT_LINE('Precio: ' || r.precio || ' ' || r.moneda);
        DBMS_OUTPUT.PUT_LINE('Disponible: ' || r.disponible);
        DBMS_OUTPUT.PUT_LINE('Tiempo preparación (min): ' || r.tiempo_preparacion_minutos);
        DBMS_OUTPUT.PUT_LINE('Calorías: ' || r.calorias);
        DBMS_OUTPUT.PUT_LINE('Restricciones: ' || r.restricciones_alimenticias);
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Menú no encontrado.');
    END get_menu;

    PROCEDURE update_menu(
        p_id_menu                   IN NUMBER,
        p_id_concesion              IN NUMBER,
        p_nombre_plato              IN VARCHAR2,
        p_descripcion               IN VARCHAR2,
        p_categoria_menu            IN VARCHAR2,
        p_precio                    IN NUMBER,
        p_moneda                    IN VARCHAR2,
        p_disponible                IN NUMBER,
        p_tiempo_preparacion_minutos IN NUMBER,
        p_calorias                  IN NUMBER,
        p_restricciones_alimenticias IN VARCHAR2
    ) IS
    BEGIN
        UPDATE restaurantes_menus
        SET id_concesion              = p_id_concesion,
            nombre_plato              = p_nombre_plato,
            descripcion               = p_descripcion,
            categoria_menu            = p_categoria_menu,
            precio                    = p_precio,
            moneda                    = p_moneda,
            disponible                = p_disponible,
            tiempo_preparacion_minutos = p_tiempo_preparacion_minutos,
            calorias                  = p_calorias,
            restricciones_alimenticias = p_restricciones_alimenticias
        WHERE id_menu = p_id_menu;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25102, 'No se encontró el menú para actualizar.');
        END IF;
    END update_menu;

    PROCEDURE delete_menu(
        p_id_menu IN NUMBER
    ) IS
    BEGIN
        DELETE FROM restaurantes_menus
        WHERE id_menu = p_id_menu;

        IF SQL%ROWCOUNT = 0 THEN
            RAISE_APPLICATION_ERROR(-25103, 'No se encontró el menú para eliminar.');
        END IF;
    END delete_menu;

END pkg_restaurantes_menus;
/