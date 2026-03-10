create or replace NONEDITIONABLE PACKAGE pkg_aerolineas AS
    PROCEDURE insert_aerolinea(
        p_id_aerolinea      IN aerolineas.id_aerolinea%TYPE,
        p_nombre_aerolinea  IN aerolineas.nombre_aerolinea%TYPE,
        p_codigo_iata       IN aerolineas.codigo_iata%TYPE,
        p_codigo_oaci       IN aerolineas.codigo_oaci%TYPE,
        p_pais_origen       IN aerolineas.pais_origen%TYPE,
        p_anio_fundacion    IN aerolineas.anio_fundacion%TYPE,
        p_flota_total       IN aerolineas.flota_total%TYPE,
        p_destinos_totales  IN aerolineas.destinos_totales%TYPE,
        p_alianza           IN aerolineas.alianza%TYPE,
        p_website           IN aerolineas.website%TYPE,
        p_telefono_contacto IN aerolineas.telefono_contacto%TYPE,
        p_email_contacto    IN aerolineas.email_contacto%TYPE,
        p_activo            IN aerolineas.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_aerolinea(
        p_id_aerolinea IN aerolineas.id_aerolinea%TYPE
    );

    PROCEDURE update_aerolinea(
        p_id_aerolinea      IN aerolineas.id_aerolinea%TYPE,
        p_nombre_aerolinea  IN aerolineas.nombre_aerolinea%TYPE,
        p_codigo_iata       IN aerolineas.codigo_iata%TYPE,
        p_codigo_oaci       IN aerolineas.codigo_oaci%TYPE,
        p_pais_origen       IN aerolineas.pais_origen%TYPE,
        p_anio_fundacion    IN aerolineas.anio_fundacion%TYPE,
        p_flota_total       IN aerolineas.flota_total%TYPE,
        p_destinos_totales  IN aerolineas.destinos_totales%TYPE,
        p_alianza           IN aerolineas.alianza%TYPE,
        p_website           IN aerolineas.website%TYPE,
        p_telefono_contacto IN aerolineas.telefono_contacto%TYPE,
        p_email_contacto    IN aerolineas.email_contacto%TYPE,
        p_activo            IN aerolineas.activo%TYPE
    );

    PROCEDURE delete_aerolinea(
        p_id_aerolinea IN aerolineas.id_aerolinea%TYPE
    );
END pkg_aerolineas;

create or replace NONEDITIONABLE PACKAGE pkg_aeropuertos AS
    PROCEDURE insert_aeropuerto(
        p_codigo_aeropuerto   IN aeropuertos.codigo_aeropuerto%TYPE,
        p_nombre              IN aeropuertos.nombre%TYPE,
        p_ciudad              IN aeropuertos.ciudad%TYPE,
        p_pais                IN aeropuertos.pais%TYPE,
        p_region              IN aeropuertos.region%TYPE,
        p_continente          IN aeropuertos.continente%TYPE,
        p_huso_horario        IN aeropuertos.huso_horario%TYPE,
        p_latitud             IN aeropuertos.latitud%TYPE,
        p_longitud            IN aeropuertos.longitud%TYPE,
        p_elevacion_metros    IN aeropuertos.elevacion_metros%TYPE,
        p_terminales          IN aeropuertos.terminales%TYPE,
        p_puertas_abordaje    IN aeropuertos.puertas_abordaje%TYPE,
        p_usuario_registro    IN aeropuertos.usuario_registro%TYPE
    );

    PROCEDURE get_aeropuerto(
        p_codigo_aeropuerto   IN aeropuertos.codigo_aeropuerto%TYPE
    );

    PROCEDURE update_aeropuerto(
        p_codigo_aeropuerto   IN aeropuertos.codigo_aeropuerto%TYPE,
        p_terminales          IN aeropuertos.terminales%TYPE,
        p_puertas_abordaje    IN aeropuertos.puertas_abordaje%TYPE,
        p_activo              IN aeropuertos.activo%TYPE
    );

    PROCEDURE delete_aeropuerto(
        p_codigo_aeropuerto   IN aeropuertos.codigo_aeropuerto%TYPE
    );
END pkg_aeropuertos;

create or replace NONEDITIONABLE PACKAGE pkg_alianzas AS
    PROCEDURE insert_alianza(
        p_id_alianza      IN alianzas_aerolineas.id_alianza%TYPE,
        p_nombre_alianza  IN alianzas_aerolineas.nombre_alianza%TYPE,
        p_fecha_fundacion IN alianzas_aerolineas.fecha_fundacion%TYPE,
        p_sede            IN alianzas_aerolineas.sede%TYPE,
        p_numero_miembros IN alianzas_aerolineas.numero_miembros%TYPE,
        p_descripcion     IN alianzas_aerolineas.descripcion%TYPE
    );

    PROCEDURE get_alianza(
        p_id_alianza IN alianzas_aerolineas.id_alianza%TYPE
    );

    PROCEDURE update_alianza(
        p_id_alianza      IN alianzas_aerolineas.id_alianza%TYPE,
        p_nombre_alianza  IN alianzas_aerolineas.nombre_alianza%TYPE,
        p_fecha_fundacion IN alianzas_aerolineas.fecha_fundacion%TYPE,
        p_sede            IN alianzas_aerolineas.sede%TYPE,
        p_numero_miembros IN alianzas_aerolineas.numero_miembros%TYPE,
        p_descripcion     IN alianzas_aerolineas.descripcion%TYPE
    );

    PROCEDURE delete_alianza(
        p_id_alianza IN alianzas_aerolineas.id_alianza%TYPE
    );
END pkg_alianzas;

create or replace NONEDITIONABLE PACKAGE pkg_dias_operacion AS
    PROCEDURE insert_dia(
        p_id_dia     IN dias_operacion.id_dia%TYPE,
        p_nombre_dia IN dias_operacion.nombre_dia%TYPE,
        p_numero_dia IN dias_operacion.numero_dia%TYPE,
        p_activo     IN dias_operacion.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_dia(
        p_id_dia IN dias_operacion.id_dia%TYPE
    );

    PROCEDURE update_dia(
        p_id_dia     IN dias_operacion.id_dia%TYPE,
        p_nombre_dia IN dias_operacion.nombre_dia%TYPE,
        p_numero_dia IN dias_operacion.numero_dia%TYPE,
        p_activo     IN dias_operacion.activo%TYPE
    );

    PROCEDURE delete_dia(
        p_id_dia IN dias_operacion.id_dia%TYPE
    );
END pkg_dias_operacion;

create or replace NONEDITIONABLE PACKAGE pkg_estadisticas_vuelo AS
    PROCEDURE insert_estadistica(
        p_id_estadistica        IN estadisticas_vuelo.id_estadistica%TYPE,
        p_id_vuelo              IN estadisticas_vuelo.id_vuelo%TYPE,
        p_pasajeros_transportados IN estadisticas_vuelo.pasajeros_transportados%TYPE,
        p_carga_transportada_kg IN estadisticas_vuelo.carga_transportada_kg%TYPE,
        p_correo_transportado_kg IN estadisticas_vuelo.correo_transportado_kg%TYPE,
        p_factor_ocupacion      IN estadisticas_vuelo.factor_ocupacion%TYPE,
        p_ingresos_totales      IN estadisticas_vuelo.ingresos_totales%TYPE,
        p_gastos_totales        IN estadisticas_vuelo.gastos_totales%TYPE,
        p_beneficio_neto        IN estadisticas_vuelo.beneficio_neto%TYPE,
        p_puntualidad_llegada   IN estadisticas_vuelo.puntualidad_llegada%TYPE DEFAULT 1
    );

    PROCEDURE get_estadistica(
        p_id_estadistica IN estadisticas_vuelo.id_estadistica%TYPE
    );

    PROCEDURE update_estadistica(
        p_id_estadistica        IN estadisticas_vuelo.id_estadistica%TYPE,
        p_pasajeros_transportados IN estadisticas_vuelo.pasajeros_transportados%TYPE,
        p_carga_transportada_kg IN estadisticas_vuelo.carga_transportada_kg%TYPE,
        p_correo_transportado_kg IN estadisticas_vuelo.correo_transportado_kg%TYPE,
        p_factor_ocupacion      IN estadisticas_vuelo.factor_ocupacion%TYPE,
        p_ingresos_totales      IN estadisticas_vuelo.ingresos_totales%TYPE,
        p_gastos_totales        IN estadisticas_vuelo.gastos_totales%TYPE,
        p_beneficio_neto        IN estadisticas_vuelo.beneficio_neto%TYPE,
        p_puntualidad_llegada   IN estadisticas_vuelo.puntualidad_llegada%TYPE
    );

    PROCEDURE delete_estadistica(
        p_id_estadistica IN estadisticas_vuelo.id_estadistica%TYPE
    );
END pkg_estadisticas_vuelo;

create or replace NONEDITIONABLE PACKAGE pkg_fabricantes AS
    PROCEDURE insert_fabricante(
        p_id_fabricante      IN fabricantes_aviones.id_fabricante%TYPE,
        p_nombre_fabricante  IN fabricantes_aviones.nombre_fabricante%TYPE,
        p_pais_origen        IN fabricantes_aviones.pais_origen%TYPE,
        p_anio_fundacion     IN fabricantes_aviones.anio_fundacion%TYPE,
        p_sede_principal     IN fabricantes_aviones.sede_principal%TYPE,
        p_website            IN fabricantes_aviones.website%TYPE,
        p_activo             IN fabricantes_aviones.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_fabricante(
        p_id_fabricante IN fabricantes_aviones.id_fabricante%TYPE
    );

    PROCEDURE update_fabricante(
        p_id_fabricante      IN fabricantes_aviones.id_fabricante%TYPE,
        p_nombre_fabricante  IN fabricantes_aviones.nombre_fabricante%TYPE,
        p_pais_origen        IN fabricantes_aviones.pais_origen%TYPE,
        p_anio_fundacion     IN fabricantes_aviones.anio_fundacion%TYPE,
        p_sede_principal     IN fabricantes_aviones.sede_principal%TYPE,
        p_website            IN fabricantes_aviones.website%TYPE,
        p_activo             IN fabricantes_aviones.activo%TYPE
    );

    PROCEDURE delete_fabricante(
        p_id_fabricante IN fabricantes_aviones.id_fabricante%TYPE
    );
END pkg_fabricantes;

create or replace NONEDITIONABLE PACKAGE pkg_franquicias AS
    PROCEDURE insert_franquicia(
        p_id_franquicia          IN franquicias_equipaje.id_franquicia%TYPE,
        p_id_aerolinea           IN franquicias_equipaje.id_aerolinea%TYPE,
        p_clase_servicio         IN franquicias_equipaje.clase_servicio%TYPE,
        p_peso_maximo_kg         IN franquicias_equipaje.peso_maximo_kg%TYPE,
        p_piezas_permitidas      IN franquicias_equipaje.piezas_permitidas%TYPE,
        p_dimensiones_maximas_cm IN franquicias_equipaje.dimensiones_maximas_cm%TYPE,
        p_exceso_equipaje_costo  IN franquicias_equipaje.exceso_equipaje_costo%TYPE,
        p_moneda                 IN franquicias_equipaje.moneda%TYPE
    );

    PROCEDURE get_franquicia(
        p_id_franquicia IN franquicias_equipaje.id_franquicia%TYPE
    );

    PROCEDURE update_franquicia(
        p_id_franquicia          IN franquicias_equipaje.id_franquicia%TYPE,
        p_clase_servicio         IN franquicias_equipaje.clase_servicio%TYPE,
        p_peso_maximo_kg         IN franquicias_equipaje.peso_maximo_kg%TYPE,
        p_piezas_permitidas      IN franquicias_equipaje.piezas_permitidas%TYPE,
        p_dimensiones_maximas_cm IN franquicias_equipaje.dimensiones_maximas_cm%TYPE,
        p_exceso_equipaje_costo  IN franquicias_equipaje.exceso_equipaje_costo%TYPE,
        p_moneda                 IN franquicias_equipaje.moneda%TYPE
    );

    PROCEDURE delete_franquicia(
        p_id_franquicia IN franquicias_equipaje.id_franquicia%TYPE
    );
END pkg_franquicias;

create or replace NONEDITIONABLE PACKAGE pkg_modelos_aviones AS
    PROCEDURE insert_modelo(
        p_id_modelo              IN modelos_aviones.id_modelo%TYPE,
        p_nombre_modelo          IN modelos_aviones.nombre_modelo%TYPE,
        p_fabricante             IN modelos_aviones.fabricante%TYPE,
        p_capacidad_pasajeros    IN modelos_aviones.capacidad_pasajeros%TYPE,
        p_capacidad_carga_kg     IN modelos_aviones.capacidad_carga_kg%TYPE,
        p_autonomia_km           IN modelos_aviones.autonomia_km%TYPE,
        p_velocidad_crucero_kmh  IN modelos_aviones.velocidad_crucero_kmh%TYPE,
        p_longitud_metros        IN modelos_aviones.longitud_metros%TYPE,
        p_envergadura_metros     IN modelos_aviones.envergadura_metros%TYPE,
        p_altura_metros          IN modelos_aviones.altura_metros%TYPE,
        p_tripulacion_minima     IN modelos_aviones.tripulacion_minima%TYPE,
        p_anio_fabricacion       IN modelos_aviones.anio_fabricacion%TYPE,
        p_activo                 IN modelos_aviones.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_modelo(
        p_id_modelo IN modelos_aviones.id_modelo%TYPE
    );

    PROCEDURE update_modelo(
        p_id_modelo              IN modelos_aviones.id_modelo%TYPE,
        p_nombre_modelo          IN modelos_aviones.nombre_modelo%TYPE,
        p_fabricante             IN modelos_aviones.fabricante%TYPE,
        p_capacidad_pasajeros    IN modelos_aviones.capacidad_pasajeros%TYPE,
        p_capacidad_carga_kg     IN modelos_aviones.capacidad_carga_kg%TYPE,
        p_autonomia_km           IN modelos_aviones.autonomia_km%TYPE,
        p_velocidad_crucero_kmh  IN modelos_aviones.velocidad_crucero_kmh%TYPE,
        p_longitud_metros        IN modelos_aviones.longitud_metros%TYPE,
        p_envergadura_metros     IN modelos_aviones.envergadura_metros%TYPE,
        p_altura_metros          IN modelos_aviones.altura_metros%TYPE,
        p_tripulacion_minima     IN modelos_aviones.tripulacion_minima%TYPE,
        p_anio_fabricacion       IN modelos_aviones.anio_fabricacion%TYPE,
        p_activo                 IN modelos_aviones.activo%TYPE
    );

    PROCEDURE delete_modelo(
        p_id_modelo IN modelos_aviones.id_modelo%TYPE
    );
END pkg_modelos_aviones;

create or replace NONEDITIONABLE PACKAGE pkg_pistas AS
    PROCEDURE insert_pista(
        p_id_pista            IN pistas_aterrizaje.id_pista%TYPE,
        p_codigo_aeropuerto   IN pistas_aterrizaje.codigo_aeropuerto%TYPE,
        p_numero_pista        IN pistas_aterrizaje.numero_pista%TYPE,
        p_longitud_metros     IN pistas_aterrizaje.longitud_metros%TYPE,
        p_anchura_metros      IN pistas_aterrizaje.anchura_metros%TYPE,
        p_superficie          IN pistas_aterrizaje.superficie%TYPE,
        p_iluminacion_nocturna IN pistas_aterrizaje.iluminacion_nocturna%TYPE DEFAULT 1,
        p_sistema_ils         IN pistas_aterrizaje.sistema_ils%TYPE DEFAULT 0,
        p_activo              IN pistas_aterrizaje.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_pista(
        p_id_pista IN pistas_aterrizaje.id_pista%TYPE
    );

    PROCEDURE update_pista(
        p_id_pista            IN pistas_aterrizaje.id_pista%TYPE,
        p_longitud_metros     IN pistas_aterrizaje.longitud_metros%TYPE,
        p_anchura_metros      IN pistas_aterrizaje.anchura_metros%TYPE,
        p_superficie          IN pistas_aterrizaje.superficie%TYPE,
        p_iluminacion_nocturna IN pistas_aterrizaje.iluminacion_nocturna%TYPE,
        p_sistema_ils         IN pistas_aterrizaje.sistema_ils%TYPE,
        p_activo              IN pistas_aterrizaje.activo%TYPE
    );

    PROCEDURE delete_pista(
        p_id_pista IN pistas_aterrizaje.id_pista%TYPE
    );
END pkg_pistas;

create or replace NONEDITIONABLE PACKAGE pkg_programa_dias AS
    PROCEDURE insert_programa_dia(
        p_id_programa              IN programa_dias.id_programa%TYPE,
        p_id_dia                   IN programa_dias.id_dia%TYPE,
        p_hora_salida_programada   IN programa_dias.hora_salida_programada%TYPE,
        p_hora_llegada_programada  IN programa_dias.hora_llegada_programada%TYPE
    );

    PROCEDURE get_programa_dia(
        p_id_programa IN programa_dias.id_programa%TYPE,
        p_id_dia      IN programa_dias.id_dia%TYPE
    );

    PROCEDURE update_programa_dia(
        p_id_programa              IN programa_dias.id_programa%TYPE,
        p_id_dia                   IN programa_dias.id_dia%TYPE,
        p_hora_salida_programada   IN programa_dias.hora_salida_programada%TYPE,
        p_hora_llegada_programada  IN programa_dias.hora_llegada_programada%TYPE
    );

    PROCEDURE delete_programa_dia(
        p_id_programa IN programa_dias.id_programa%TYPE,
        p_id_dia      IN programa_dias.id_dia%TYPE
    );
END pkg_programa_dias;

create or replace NONEDITIONABLE PACKAGE pkg_programas_vuelo AS
    PROCEDURE insert_programa(
        p_id_programa              IN programas_vuelo.id_programa%TYPE,
        p_numero_vuelo             IN programas_vuelo.numero_vuelo%TYPE,
        p_id_aerolinea             IN programas_vuelo.id_aerolinea%TYPE,
        p_aeropuerto_origen        IN programas_vuelo.aeropuerto_origen%TYPE,
        p_aeropuerto_destino       IN programas_vuelo.aeropuerto_destino%TYPE,
        p_tipo_vuelo               IN programas_vuelo.tipo_vuelo%TYPE,
        p_dias_semana              IN programas_vuelo.dias_semana%TYPE,
        p_frecuencia_semanal       IN programas_vuelo.frecuencia_semanal%TYPE,
        p_duracion_estimada_minutos IN programas_vuelo.duracion_estimada_minutos%TYPE,
        p_distancia_km             IN programas_vuelo.distancia_km%TYPE,
        p_clase_servicio           IN programas_vuelo.clase_servicio%TYPE,
        p_activo                   IN programas_vuelo.activo%TYPE DEFAULT 1,
        p_fecha_inicio             IN programas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin                IN programas_vuelo.fecha_fin%TYPE
    );

    PROCEDURE get_programa(
        p_id_programa IN programas_vuelo.id_programa%TYPE
    );

    PROCEDURE update_programa(
        p_id_programa              IN programas_vuelo.id_programa%TYPE,
        p_numero_vuelo             IN programas_vuelo.numero_vuelo%TYPE,
        p_id_aerolinea             IN programas_vuelo.id_aerolinea%TYPE,
        p_aeropuerto_origen        IN programas_vuelo.aeropuerto_origen%TYPE,
        p_aeropuerto_destino       IN programas_vuelo.aeropuerto_destino%TYPE,
        p_tipo_vuelo               IN programas_vuelo.tipo_vuelo%TYPE,
        p_dias_semana              IN programas_vuelo.dias_semana%TYPE,
        p_frecuencia_semanal       IN programas_vuelo.frecuencia_semanal%TYPE,
        p_duracion_estimada_minutos IN programas_vuelo.duracion_estimada_minutos%TYPE,
        p_distancia_km             IN programas_vuelo.distancia_km%TYPE,
        p_clase_servicio           IN programas_vuelo.clase_servicio%TYPE,
        p_activo                   IN programas_vuelo.activo%TYPE,
        p_fecha_inicio             IN programas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin                IN programas_vuelo.fecha_fin%TYPE
    );

    PROCEDURE delete_programa(
        p_id_programa IN programas_vuelo.id_programa%TYPE
    );
END pkg_programas_vuelo;

create or replace NONEDITIONABLE PACKAGE pkg_puertas AS
    PROCEDURE insert_puerta(
        p_id_puerta          IN puertas_embarque.id_puerta%TYPE,
        p_codigo_aeropuerto  IN puertas_embarque.codigo_aeropuerto%TYPE,
        p_numero_puerta      IN puertas_embarque.numero_puerta%TYPE,
        p_terminal           IN puertas_embarque.terminal%TYPE,
        p_tipo_puerta        IN puertas_embarque.tipo_puerta%TYPE,
        p_capacidad_maxima   IN puertas_embarque.capacidad_maxima%TYPE,
        p_tiene_pasarela     IN puertas_embarque.tiene_pasarela%TYPE DEFAULT 1,
        p_activo             IN puertas_embarque.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_puerta(
        p_id_puerta IN puertas_embarque.id_puerta%TYPE
    );

    PROCEDURE update_puerta(
        p_id_puerta          IN puertas_embarque.id_puerta%TYPE,
        p_numero_puerta      IN puertas_embarque.numero_puerta%TYPE,
        p_terminal           IN puertas_embarque.terminal%TYPE,
        p_tipo_puerta        IN puertas_embarque.tipo_puerta%TYPE,
        p_capacidad_maxima   IN puertas_embarque.capacidad_maxima%TYPE,
        p_tiene_pasarela     IN puertas_embarque.tiene_pasarela%TYPE,
        p_activo             IN puertas_embarque.activo%TYPE
    );

    PROCEDURE delete_puerta(
        p_id_puerta IN puertas_embarque.id_puerta%TYPE
    );
END pkg_puertas;

create or replace NONEDITIONABLE PACKAGE pkg_tipos_aerolinea AS
    PROCEDURE insert_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE,
        p_descripcion       IN tipos_aerolinea.descripcion%TYPE,
        p_activo            IN tipos_aerolinea.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE
    );

    PROCEDURE update_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE,
        p_descripcion       IN tipos_aerolinea.descripcion%TYPE,
        p_activo            IN tipos_aerolinea.activo%TYPE
    );

    PROCEDURE delete_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE
    );
END pkg_tipos_aerolinea;

create or replace NONEDITIONABLE PACKAGE pkg_tipos_aeropuerto AS
    PROCEDURE insert_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE,
        p_descripcion        IN tipos_aeropuerto.descripcion%TYPE,
        p_codigo             IN tipos_aeropuerto.codigo%TYPE,
        p_activo             IN tipos_aeropuerto.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE
    );

    PROCEDURE update_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE,
        p_descripcion        IN tipos_aeropuerto.descripcion%TYPE,
        p_codigo             IN tipos_aeropuerto.codigo%TYPE,
        p_activo             IN tipos_aeropuerto.activo%TYPE
    );

    PROCEDURE delete_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE
    );
END pkg_tipos_aeropuerto;

create or replace NONEDITIONABLE PACKAGE pkg_vuelos AS
    PROCEDURE insert_vuelo(
        p_id_vuelo                IN vuelos.id_vuelo%TYPE,
        p_id_programa             IN vuelos.id_programa%TYPE,
        p_fecha_vuelo             IN vuelos.fecha_vuelo%TYPE,
        p_hora_salida_programada  IN vuelos.hora_salida_programada%TYPE,
        p_hora_llegada_programada IN vuelos.hora_llegada_programada%TYPE,
        p_hora_salida_real        IN vuelos.hora_salida_real%TYPE,
        p_hora_llegada_real       IN vuelos.hora_llegada_real%TYPE,
        p_id_modelo_avion         IN vuelos.id_modelo_avion%TYPE,
        p_matricula_avion         IN vuelos.matricula_avion%TYPE,
        p_plazas_vacias           IN vuelos.plazas_vacias%TYPE,
        p_plazas_ocupadas         IN vuelos.plazas_ocupadas%TYPE,
        p_carga_kg                IN vuelos.carga_kg%TYPE,
        p_combustible_litros      IN vuelos.combustible_litros%TYPE,
        p_estado_vuelo            IN vuelos.estado_vuelo%TYPE DEFAULT 'PROGRAMADO',
        p_motivo_cancelacion      IN vuelos.motivo_cancelacion%TYPE,
        p_fecha_reprogramado      IN vuelos.fecha_reprogramado%TYPE,
        p_id_puerta_salida        IN vuelos.id_puerta_salida%TYPE,
        p_id_puerta_llegada       IN vuelos.id_puerta_llegada%TYPE,
        p_observaciones_operativas IN vuelos.observaciones_operativas%TYPE
    );

    PROCEDURE get_vuelo(
        p_id_vuelo IN vuelos.id_vuelo%TYPE
    );

    PROCEDURE update_vuelo(
        p_id_vuelo                IN vuelos.id_vuelo%TYPE,
        p_estado_vuelo            IN vuelos.estado_vuelo%TYPE,
        p_hora_salida_real        IN vuelos.hora_salida_real%TYPE,
        p_hora_llegada_real       IN vuelos.hora_llegada_real%TYPE,
        p_plazas_vacias           IN vuelos.plazas_vacias%TYPE,
        p_plazas_ocupadas         IN vuelos.plazas_ocupadas%TYPE,
        p_carga_kg                IN vuelos.carga_kg%TYPE,
        p_combustible_litros      IN vuelos.combustible_litros%TYPE,
        p_motivo_cancelacion      IN vuelos.motivo_cancelacion%TYPE,
        p_fecha_reprogramado      IN vuelos.fecha_reprogramado%TYPE,
        p_observaciones_operativas IN vuelos.observaciones_operativas%TYPE
    );

    PROCEDURE delete_vuelo(
        p_id_vuelo IN vuelos.id_vuelo%TYPE
    );
END pkg_vuelos;

CREATE OR REPLACE PACKAGE pkg_tripulacion AS
    PROCEDURE insert_tripulante(
        p_id_tripulante     IN tripulacion.id_tripulante%TYPE,
        p_nombres           IN tripulacion.nombres%TYPE,
        p_apellidos         IN tripulacion.apellidos%TYPE,
        p_tipo_documento    IN tripulacion.tipo_documento%TYPE,
        p_numero_documento  IN tripulacion.numero_documento%TYPE,
        p_fecha_nacimiento  IN tripulacion.fecha_nacimiento%TYPE,
        p_nacionalidad      IN tripulacion.nacionalidad%TYPE,
        p_tipo_tripulante   IN tripulacion.tipo_tripulante%TYPE,
        p_licencia          IN tripulacion.licencia%TYPE,
        p_fecha_licencia    IN tripulacion.fecha_licencia%TYPE,
        p_fecha_vencimiento IN tripulacion.fecha_vencimiento_licencia%TYPE,
        p_horas_vuelo       IN tripulacion.horas_vuelo_acumuladas%TYPE,
        p_activo            IN tripulacion.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_tripulante(
        p_id_tripulante IN tripulacion.id_tripulante%TYPE
    );

    PROCEDURE update_tripulante(
        p_id_tripulante     IN tripulacion.id_tripulante%TYPE,
        p_nombres           IN tripulacion.nombres%TYPE,
        p_apellidos         IN tripulacion.apellidos%TYPE,
        p_tipo_documento    IN tripulacion.tipo_documento%TYPE,
        p_numero_documento  IN tripulacion.numero_documento%TYPE,
        p_fecha_nacimiento  IN tripulacion.fecha_nacimiento%TYPE,
        p_nacionalidad      IN tripulacion.nacionalidad%TYPE,
        p_tipo_tripulante   IN tripulacion.tipo_tripulante%TYPE,
        p_licencia          IN tripulacion.licencia%TYPE,
        p_fecha_licencia    IN tripulacion.fecha_licencia%TYPE,
        p_fecha_vencimiento IN tripulacion.fecha_vencimiento_licencia%TYPE,
        p_horas_vuelo       IN tripulacion.horas_vuelo_acumuladas%TYPE,
        p_activo            IN tripulacion.activo%TYPE
    );

    PROCEDURE delete_tripulante(
        p_id_tripulante IN tripulacion.id_tripulante%TYPE
    );
END pkg_tripulacion;
/



------------------------------------------------------------
-- Paquete CRUD para la tabla PROGRAMAS_VUELO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_programas_vuelo AS
    PROCEDURE insert_programa(
        p_id_programa              IN programas_vuelo.id_programa%TYPE,
        p_numero_vuelo             IN programas_vuelo.numero_vuelo%TYPE,
        p_id_aerolinea             IN programas_vuelo.id_aerolinea%TYPE,
        p_aeropuerto_origen        IN programas_vuelo.aeropuerto_origen%TYPE,
        p_aeropuerto_destino       IN programas_vuelo.aeropuerto_destino%TYPE,
        p_tipo_vuelo               IN programas_vuelo.tipo_vuelo%TYPE,
        p_dias_semana              IN programas_vuelo.dias_semana%TYPE,
        p_frecuencia_semanal       IN programas_vuelo.frecuencia_semanal%TYPE,
        p_duracion_estimada_minutos IN programas_vuelo.duracion_estimada_minutos%TYPE,
        p_distancia_km             IN programas_vuelo.distancia_km%TYPE,
        p_clase_servicio           IN programas_vuelo.clase_servicio%TYPE,
        p_activo                   IN programas_vuelo.activo%TYPE DEFAULT 1,
        p_fecha_inicio             IN programas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin                IN programas_vuelo.fecha_fin%TYPE
    );

    PROCEDURE get_programa(
        p_id_programa IN programas_vuelo.id_programa%TYPE
    );

    PROCEDURE update_programa(
        p_id_programa              IN programas_vuelo.id_programa%TYPE,
        p_numero_vuelo             IN programas_vuelo.numero_vuelo%TYPE,
        p_id_aerolinea             IN programas_vuelo.id_aerolinea%TYPE,
        p_aeropuerto_origen        IN programas_vuelo.aeropuerto_origen%TYPE,
        p_aeropuerto_destino       IN programas_vuelo.aeropuerto_destino%TYPE,
        p_tipo_vuelo               IN programas_vuelo.tipo_vuelo%TYPE,
        p_dias_semana              IN programas_vuelo.dias_semana%TYPE,
        p_frecuencia_semanal       IN programas_vuelo.frecuencia_semanal%TYPE,
        p_duracion_estimada_minutos IN programas_vuelo.duracion_estimada_minutos%TYPE,
        p_distancia_km             IN programas_vuelo.distancia_km%TYPE,
        p_clase_servicio           IN programas_vuelo.clase_servicio%TYPE,
        p_activo                   IN programas_vuelo.activo%TYPE,
        p_fecha_inicio             IN programas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin                IN programas_vuelo.fecha_fin%TYPE
    );

    PROCEDURE delete_programa(
        p_id_programa IN programas_vuelo.id_programa%TYPE
    );
END pkg_programas_vuelo;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_programas_vuelo AS

    PROCEDURE insert_programa(
        p_id_programa              IN programas_vuelo.id_programa%TYPE,
        p_numero_vuelo             IN programas_vuelo.numero_vuelo%TYPE,
        p_id_aerolinea             IN programas_vuelo.id_aerolinea%TYPE,
        p_aeropuerto_origen        IN programas_vuelo.aeropuerto_origen%TYPE,
        p_aeropuerto_destino       IN programas_vuelo.aeropuerto_destino%TYPE,
        p_tipo_vuelo               IN programas_vuelo.tipo_vuelo%TYPE,
        p_dias_semana              IN programas_vuelo.dias_semana%TYPE,
        p_frecuencia_semanal       IN programas_vuelo.frecuencia_semanal%TYPE,
        p_duracion_estimada_minutos IN programas_vuelo.duracion_estimada_minutos%TYPE,
        p_distancia_km             IN programas_vuelo.distancia_km%TYPE,
        p_clase_servicio           IN programas_vuelo.clase_servicio%TYPE,
        p_activo                   IN programas_vuelo.activo%TYPE,
        p_fecha_inicio             IN programas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin                IN programas_vuelo.fecha_fin%TYPE
    ) IS
    BEGIN
        INSERT INTO programas_vuelo (
            id_programa, numero_vuelo, id_aerolinea,
            aeropuerto_origen, aeropuerto_destino, tipo_vuelo,
            dias_semana, frecuencia_semanal, duracion_estimada_minutos,
            distancia_km, clase_servicio, activo,
            fecha_inicio, fecha_fin
        ) VALUES (
            p_id_programa, p_numero_vuelo, p_id_aerolinea,
            p_aeropuerto_origen, p_aeropuerto_destino, p_tipo_vuelo,
            p_dias_semana, p_frecuencia_semanal, p_duracion_estimada_minutos,
            p_distancia_km, p_clase_servicio, NVL(p_activo,1),
            p_fecha_inicio, p_fecha_fin
        );
        COMMIT;
    END insert_programa;

    PROCEDURE get_programa(
        p_id_programa IN programas_vuelo.id_programa%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM programas_vuelo WHERE id_programa = p_id_programa;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Programa: ' || r.id_programa);
            DBMS_OUTPUT.PUT_LINE('Número vuelo: ' || r.numero_vuelo);
            DBMS_OUTPUT.PUT_LINE('Aerolínea: ' || r.id_aerolinea);
            DBMS_OUTPUT.PUT_LINE('Origen: ' || r.aeropuerto_origen);
            DBMS_OUTPUT.PUT_LINE('Destino: ' || r.aeropuerto_destino);
            DBMS_OUTPUT.PUT_LINE('Tipo vuelo: ' || r.tipo_vuelo);
            DBMS_OUTPUT.PUT_LINE('Días semana: ' || r.dias_semana);
            DBMS_OUTPUT.PUT_LINE('Frecuencia semanal: ' || r.frecuencia_semanal);
            DBMS_OUTPUT.PUT_LINE('Duración estimada: ' || r.duracion_estimada_minutos || ' min');
            DBMS_OUTPUT.PUT_LINE('Distancia: ' || r.distancia_km || ' km');
            DBMS_OUTPUT.PUT_LINE('Clase servicio: ' || r.clase_servicio);
            DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
            DBMS_OUTPUT.PUT_LINE('Fecha inicio: ' || r.fecha_inicio);
            DBMS_OUTPUT.PUT_LINE('Fecha fin: ' || r.fecha_fin);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Programa de vuelo no encontrado.');
        END IF;
        CLOSE c;
    END get_programa;

    PROCEDURE update_programa(
        p_id_programa              IN programas_vuelo.id_programa%TYPE,
        p_numero_vuelo             IN programas_vuelo.numero_vuelo%TYPE,
        p_id_aerolinea             IN programas_vuelo.id_aerolinea%TYPE,
        p_aeropuerto_origen        IN programas_vuelo.aeropuerto_origen%TYPE,
        p_aeropuerto_destino       IN programas_vuelo.aeropuerto_destino%TYPE,
        p_tipo_vuelo               IN programas_vuelo.tipo_vuelo%TYPE,
        p_dias_semana              IN programas_vuelo.dias_semana%TYPE,
        p_frecuencia_semanal       IN programas_vuelo.frecuencia_semanal%TYPE,
        p_duracion_estimada_minutos IN programas_vuelo.duracion_estimada_minutos%TYPE,
        p_distancia_km             IN programas_vuelo.distancia_km%TYPE,
        p_clase_servicio           IN programas_vuelo.clase_servicio%TYPE,
        p_activo                   IN programas_vuelo.activo%TYPE,
        p_fecha_inicio             IN programas_vuelo.fecha_inicio%TYPE,
        p_fecha_fin                IN programas_vuelo.fecha_fin%TYPE
    ) IS
    BEGIN
        UPDATE programas_vuelo
        SET numero_vuelo = p_numero_vuelo,
            id_aerolinea = p_id_aerolinea,
            aeropuerto_origen = p_aeropuerto_origen,
            aeropuerto_destino = p_aeropuerto_destino,
            tipo_vuelo = p_tipo_vuelo,
            dias_semana = p_dias_semana,
            frecuencia_semanal = p_frecuencia_semanal,
            duracion_estimada_minutos = p_duracion_estimada_minutos,
            distancia_km = p_distancia_km,
            clase_servicio = p_clase_servicio,
            activo = p_activo,
            fecha_inicio = p_fecha_inicio,
            fecha_fin = p_fecha_fin
        WHERE id_programa = p_id_programa;
        COMMIT;
    END update_programa;

    PROCEDURE delete_programa(
        p_id_programa IN programas_vuelo.id_programa%TYPE
    ) IS
    BEGIN
        DELETE FROM programas_vuelo
        WHERE id_programa = p_id_programa;
        COMMIT;
    END delete_programa;

END pkg_programas_vuelo;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla TIPOS_AEROPUERTO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tipos_aeropuerto AS
    PROCEDURE insert_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE,
        p_descripcion        IN tipos_aeropuerto.descripcion%TYPE,
        p_codigo             IN tipos_aeropuerto.codigo%TYPE,
        p_activo             IN tipos_aeropuerto.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE
    );

    PROCEDURE update_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE,
        p_descripcion        IN tipos_aeropuerto.descripcion%TYPE,
        p_codigo             IN tipos_aeropuerto.codigo%TYPE,
        p_activo             IN tipos_aeropuerto.activo%TYPE
    );

    PROCEDURE delete_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE
    );
END pkg_tipos_aeropuerto;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tipos_aeropuerto AS

    PROCEDURE insert_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE,
        p_descripcion        IN tipos_aeropuerto.descripcion%TYPE,
        p_codigo             IN tipos_aeropuerto.codigo%TYPE,
        p_activo             IN tipos_aeropuerto.activo%TYPE
    ) IS
    BEGIN
        INSERT INTO tipos_aeropuerto (
            id_tipo_aeropuerto, descripcion, codigo, activo
        ) VALUES (
            p_id_tipo_aeropuerto, p_descripcion, p_codigo, NVL(p_activo,1)
        );
        COMMIT;
    END insert_tipo;

    PROCEDURE get_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM tipos_aeropuerto WHERE id_tipo_aeropuerto = p_id_tipo_aeropuerto;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Tipo Aeropuerto: ' || r.id_tipo_aeropuerto);
            DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
            DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo);
            DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Tipo de aeropuerto no encontrado.');
        END IF;
        CLOSE c;
    END get_tipo;

    PROCEDURE update_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE,
        p_descripcion        IN tipos_aeropuerto.descripcion%TYPE,
        p_codigo             IN tipos_aeropuerto.codigo%TYPE,
        p_activo             IN tipos_aeropuerto.activo%TYPE
    ) IS
    BEGIN
        UPDATE tipos_aeropuerto
        SET descripcion = p_descripcion,
            codigo = p_codigo,
            activo = p_activo
        WHERE id_tipo_aeropuerto = p_id_tipo_aeropuerto;
        COMMIT;
    END update_tipo;

    PROCEDURE delete_tipo(
        p_id_tipo_aeropuerto IN tipos_aeropuerto.id_tipo_aeropuerto%TYPE
    ) IS
    BEGIN
        DELETE FROM tipos_aeropuerto
        WHERE id_tipo_aeropuerto = p_id_tipo_aeropuerto;
        COMMIT;
    END delete_tipo;

END pkg_tipos_aeropuerto;
/



------------------------------------------------------------
-- Paquete CRUD para la tabla TIPOS_AEROLINEA
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tipos_aerolinea AS
    PROCEDURE insert_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE,
        p_descripcion       IN tipos_aerolinea.descripcion%TYPE,
        p_activo            IN tipos_aerolinea.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE
    );

    PROCEDURE update_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE,
        p_descripcion       IN tipos_aerolinea.descripcion%TYPE,
        p_activo            IN tipos_aerolinea.activo%TYPE
    );

    PROCEDURE delete_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE
    );
END pkg_tipos_aerolinea;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tipos_aerolinea AS

    PROCEDURE insert_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE,
        p_descripcion       IN tipos_aerolinea.descripcion%TYPE,
        p_activo            IN tipos_aerolinea.activo%TYPE
    ) IS
    BEGIN
        INSERT INTO tipos_aerolinea (
            id_tipo_aerolinea, descripcion, activo
        ) VALUES (
            p_id_tipo_aerolinea, p_descripcion, NVL(p_activo,1)
        );
        COMMIT;
    END insert_tipo;

    PROCEDURE get_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM tipos_aerolinea WHERE id_tipo_aerolinea = p_id_tipo_aerolinea;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Tipo Aerolínea: ' || r.id_tipo_aerolinea);
            DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
            DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Tipo de aerolínea no encontrado.');
        END IF;
        CLOSE c;
    END get_tipo;

    PROCEDURE update_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE,
        p_descripcion       IN tipos_aerolinea.descripcion%TYPE,
        p_activo            IN tipos_aerolinea.activo%TYPE
    ) IS
    BEGIN
        UPDATE tipos_aerolinea
        SET descripcion = p_descripcion,
            activo = p_activo
        WHERE id_tipo_aerolinea = p_id_tipo_aerolinea;
        COMMIT;
    END update_tipo;

    PROCEDURE delete_tipo(
        p_id_tipo_aerolinea IN tipos_aerolinea.id_tipo_aerolinea%TYPE
    ) IS
    BEGIN
        DELETE FROM tipos_aerolinea
        WHERE id_tipo_aerolinea = p_id_tipo_aerolinea;
        COMMIT;
    END delete_tipo;

END pkg_tipos_aerolinea;
/
------------------------------------------------------------
-- Paquete CRUD para la tabla VUELOS_TRIPULACION
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_vuelos_tripulacion AS
    PROCEDURE insert_vt(
        p_id_vuelo       IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante  IN vuelos_tripulacion.id_tripulante%TYPE,
        p_rol_asignado   IN vuelos_tripulacion.rol_asignado%TYPE,
        p_horas_trabajadas IN vuelos_tripulacion.horas_trabajadas%TYPE,
        p_observaciones  IN vuelos_tripulacion.observaciones%TYPE
    );

    PROCEDURE get_vt(
        p_id_vuelo      IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante IN vuelos_tripulacion.id_tripulante%TYPE
    );

    PROCEDURE update_vt(
        p_id_vuelo       IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante  IN vuelos_tripulacion.id_tripulante%TYPE,
        p_rol_asignado   IN vuelos_tripulacion.rol_asignado%TYPE,
        p_horas_trabajadas IN vuelos_tripulacion.horas_trabajadas%TYPE,
        p_observaciones  IN vuelos_tripulacion.observaciones%TYPE
    );

    PROCEDURE delete_vt(
        p_id_vuelo      IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante IN vuelos_tripulacion.id_tripulante%TYPE
    );
END pkg_vuelos_tripulacion;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_vuelos_tripulacion AS

    PROCEDURE insert_vt(
        p_id_vuelo       IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante  IN vuelos_tripulacion.id_tripulante%TYPE,
        p_rol_asignado   IN vuelos_tripulacion.rol_asignado%TYPE,
        p_horas_trabajadas IN vuelos_tripulacion.horas_trabajadas%TYPE,
        p_observaciones  IN vuelos_tripulacion.observaciones%TYPE
    ) IS
    BEGIN
        INSERT INTO vuelos_tripulacion (
            id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones
        ) VALUES (
            p_id_vuelo, p_id_tripulante, p_rol_asignado, p_horas_trabajadas, p_observaciones
        );
        COMMIT;
    END insert_vt;

    PROCEDURE get_vt(
        p_id_vuelo      IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante IN vuelos_tripulacion.id_tripulante%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM vuelos_tripulacion 
            WHERE id_vuelo = p_id_vuelo AND id_tripulante = p_id_tripulante;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
            DBMS_OUTPUT.PUT_LINE('Tripulante: ' || r.id_tripulante);
            DBMS_OUTPUT.PUT_LINE('Rol asignado: ' || r.rol_asignado);
            DBMS_OUTPUT.PUT_LINE('Horas trabajadas: ' || r.horas_trabajadas);
            DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Asignación no encontrada.');
        END IF;
        CLOSE c;
    END get_vt;

    PROCEDURE update_vt(
        p_id_vuelo       IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante  IN vuelos_tripulacion.id_tripulante%TYPE,
        p_rol_asignado   IN vuelos_tripulacion.rol_asignado%TYPE,
        p_horas_trabajadas IN vuelos_tripulacion.horas_trabajadas%TYPE,
        p_observaciones  IN vuelos_tripulacion.observaciones%TYPE
    ) IS
    BEGIN
        UPDATE vuelos_tripulacion
        SET rol_asignado = p_rol_asignado,
            horas_trabajadas = p_horas_trabajadas,
            observaciones = p_observaciones
        WHERE id_vuelo = p_id_vuelo AND id_tripulante = p_id_tripulante;
        COMMIT;
    END update_vt;

    PROCEDURE delete_vt(
        p_id_vuelo      IN vuelos_tripulacion.id_vuelo%TYPE,
        p_id_tripulante IN vuelos_tripulacion.id_tripulante%TYPE
    ) IS
    BEGIN
        DELETE FROM vuelos_tripulacion
        WHERE id_vuelo = p_id_vuelo AND id_tripulante = p_id_tripulante;
        COMMIT;
    END delete_vt;

END pkg_vuelos_tripulacion;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla PASAJEROS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pasajeros AS
    PROCEDURE insert_pasajero(
        p_id_pasajero       IN pasajeros.id_pasajero%TYPE,
        p_nombres           IN pasajeros.nombres%TYPE,
        p_apellidos         IN pasajeros.apellidos%TYPE,
        p_tipo_documento    IN pasajeros.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros.numero_documento%TYPE,
        p_nacionalidad      IN pasajeros.nacionalidad%TYPE,
        p_fecha_nacimiento  IN pasajeros.fecha_nacimiento%TYPE,
        p_genero            IN pasajeros.genero%TYPE,
        p_telefono          IN pasajeros.telefono%TYPE,
        p_email             IN pasajeros.email%TYPE,
        p_direccion         IN pasajeros.direccion%TYPE,
        p_ciudad_residencia IN pasajeros.ciudad_residencia%TYPE,
        p_pais_residencia   IN pasajeros.pais_residencia%TYPE,
        p_codigo_postal     IN pasajeros.codigo_postal%TYPE,
        p_ocupacion         IN pasajeros.ocupacion%TYPE,
        p_estado_civil      IN pasajeros.estado_civil%TYPE,
        p_usuario_registro  IN pasajeros.usuario_registro%TYPE
    );

    PROCEDURE get_pasajero(
        p_id_pasajero IN pasajeros.id_pasajero%TYPE
    );

    PROCEDURE update_pasajero(
        p_id_pasajero       IN pasajeros.id_pasajero%TYPE,
        p_nombres           IN pasajeros.nombres%TYPE,
        p_apellidos         IN pasajeros.apellidos%TYPE,
        p_tipo_documento    IN pasajeros.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros.numero_documento%TYPE,
        p_nacionalidad      IN pasajeros.nacionalidad%TYPE,
        p_fecha_nacimiento  IN pasajeros.fecha_nacimiento%TYPE,
        p_genero            IN pasajeros.genero%TYPE,
        p_telefono          IN pasajeros.telefono%TYPE,
        p_email             IN pasajeros.email%TYPE,
        p_direccion         IN pasajeros.direccion%TYPE,
        p_ciudad_residencia IN pasajeros.ciudad_residencia%TYPE,
        p_pais_residencia   IN pasajeros.pais_residencia%TYPE,
        p_codigo_postal     IN pasajeros.codigo_postal%TYPE,
        p_ocupacion         IN pasajeros.ocupacion%TYPE,
        p_estado_civil      IN pasajeros.estado_civil%TYPE,
        p_usuario_registro  IN pasajeros.usuario_registro%TYPE
    );

    PROCEDURE delete_pasajero(
        p_id_pasajero IN pasajeros.id_pasajero%TYPE
    );
END pkg_pasajeros;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pasajeros AS

    PROCEDURE insert_pasajero(
        p_id_pasajero       IN pasajeros.id_pasajero%TYPE,
        p_nombres           IN pasajeros.nombres%TYPE,
        p_apellidos         IN pasajeros.apellidos%TYPE,
        p_tipo_documento    IN pasajeros.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros.numero_documento%TYPE,
        p_nacionalidad      IN pasajeros.nacionalidad%TYPE,
        p_fecha_nacimiento  IN pasajeros.fecha_nacimiento%TYPE,
        p_genero            IN pasajeros.genero%TYPE,
        p_telefono          IN pasajeros.telefono%TYPE,
        p_email             IN pasajeros.email%TYPE,
        p_direccion         IN pasajeros.direccion%TYPE,
        p_ciudad_residencia IN pasajeros.ciudad_residencia%TYPE,
        p_pais_residencia   IN pasajeros.pais_residencia%TYPE,
        p_codigo_postal     IN pasajeros.codigo_postal%TYPE,
        p_ocupacion         IN pasajeros.ocupacion%TYPE,
        p_estado_civil      IN pasajeros.estado_civil%TYPE,
        p_usuario_registro  IN pasajeros.usuario_registro%TYPE
    ) IS
    BEGIN
        INSERT INTO pasajeros (
            id_pasajero, nombres, apellidos, tipo_documento, numero_documento,
            nacionalidad, fecha_nacimiento, genero, telefono, email,
            direccion, ciudad_residencia, pais_residencia, codigo_postal,
            ocupacion, estado_civil, fecha_registro, usuario_registro
        ) VALUES (
            p_id_pasajero, p_nombres, p_apellidos, p_tipo_documento, p_numero_documento,
            p_nacionalidad, p_fecha_nacimiento, p_genero, p_telefono, p_email,
            p_direccion, p_ciudad_residencia, p_pais_residencia, p_codigo_postal,
            p_ocupacion, p_estado_civil, SYSDATE, p_usuario_registro
        );
        COMMIT;
    END insert_pasajero;

    PROCEDURE get_pasajero(
        p_id_pasajero IN pasajeros.id_pasajero%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM pasajeros WHERE id_pasajero = p_id_pasajero;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID: ' || r.id_pasajero);
            DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombres || ' ' || r.apellidos);
            DBMS_OUTPUT.PUT_LINE('Documento: ' || r.tipo_documento || ' ' || r.numero_documento);
            DBMS_OUTPUT.PUT_LINE('Nacionalidad: ' || r.nacionalidad);
            DBMS_OUTPUT.PUT_LINE('Fecha nacimiento: ' || r.fecha_nacimiento);
            DBMS_OUTPUT.PUT_LINE('Género: ' || r.genero);
            DBMS_OUTPUT.PUT_LINE('Teléfono: ' || r.telefono);
            DBMS_OUTPUT.PUT_LINE('Email: ' || r.email);
            DBMS_OUTPUT.PUT_LINE('Dirección: ' || r.direccion);
            DBMS_OUTPUT.PUT_LINE('Ciudad residencia: ' || r.ciudad_residencia);
            DBMS_OUTPUT.PUT_LINE('País residencia: ' || r.pais_residencia);
            DBMS_OUTPUT.PUT_LINE('Código postal: ' || r.codigo_postal);
            DBMS_OUTPUT.PUT_LINE('Ocupación: ' || r.ocupacion);
            DBMS_OUTPUT.PUT_LINE('Estado civil: ' || r.estado_civil);
            DBMS_OUTPUT.PUT_LINE('Fecha registro: ' || r.fecha_registro);
            DBMS_OUTPUT.PUT_LINE('Usuario registro: ' || r.usuario_registro);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Pasajero no encontrado.');
        END IF;
        CLOSE c;
    END get_pasajero;

    PROCEDURE update_pasajero(
        p_id_pasajero       IN pasajeros.id_pasajero%TYPE,
        p_nombres           IN pasajeros.nombres%TYPE,
        p_apellidos         IN pasajeros.apellidos%TYPE,
        p_tipo_documento    IN pasajeros.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros.numero_documento%TYPE,
        p_nacionalidad      IN pasajeros.nacionalidad%TYPE,
        p_fecha_nacimiento  IN pasajeros.fecha_nacimiento%TYPE,
        p_genero            IN pasajeros.genero%TYPE,
        p_telefono          IN pasajeros.telefono%TYPE,
        p_email             IN pasajeros.email%TYPE,
        p_direccion         IN pasajeros.direccion%TYPE,
        p_ciudad_residencia IN pasajeros.ciudad_residencia%TYPE,
        p_pais_residencia   IN pasajeros.pais_residencia%TYPE,
        p_codigo_postal     IN pasajeros.codigo_postal%TYPE,
        p_ocupacion         IN pasajeros.ocupacion%TYPE,
        p_estado_civil      IN pasajeros.estado_civil%TYPE,
        p_usuario_registro  IN pasajeros.usuario_registro%TYPE
    ) IS
    BEGIN
        UPDATE pasajeros
        SET nombres = p_nombres,
            apellidos = p_apellidos,
            tipo_documento = p_tipo_documento,
            numero_documento = p_numero_documento,
            nacionalidad = p_nacionalidad,
            fecha_nacimiento = p_fecha_nacimiento,
            genero = p_genero,
            telefono = p_telefono,
            email = p_email,
            direccion = p_direccion,
            ciudad_residencia = p_ciudad_residencia,
            pais_residencia = p_pais_residencia,
            codigo_postal = p_codigo_postal,
            ocupacion = p_ocupacion,
            estado_civil = p_estado_civil,
            usuario_registro = p_usuario_registro
        WHERE id_pasajero = p_id_pasajero;
        COMMIT;
    END update_pasajero;

    PROCEDURE delete_pasajero(
        p_id_pasajero IN pasajeros.id_pasajero%TYPE
    ) IS
    BEGIN
        DELETE FROM pasajeros
        WHERE id_pasajero = p_id_pasajero;
        COMMIT;
    END delete_pasajero;

END pkg_pasajeros;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla PASAJEROS_DOCUMENTOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_pasajeros_documentos AS
    PROCEDURE insert_documento(
        p_id_documento      IN pasajeros_documentos.id_documento%TYPE,
        p_id_pasajero       IN pasajeros_documentos.id_pasajero%TYPE,
        p_tipo_documento    IN pasajeros_documentos.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros_documentos.numero_documento%TYPE,
        p_pais_emision      IN pasajeros_documentos.pais_emision%TYPE,
        p_fecha_emision     IN pasajeros_documentos.fecha_emision%TYPE,
        p_fecha_expiracion  IN pasajeros_documentos.fecha_expiracion%TYPE,
        p_imagen_documento  IN pasajeros_documentos.imagen_documento%TYPE,
        p_verificado        IN pasajeros_documentos.verificado%TYPE DEFAULT 0
    );

    PROCEDURE get_documento(
        p_id_documento IN pasajeros_documentos.id_documento%TYPE
    );

    PROCEDURE update_documento(
        p_id_documento      IN pasajeros_documentos.id_documento%TYPE,
        p_tipo_documento    IN pasajeros_documentos.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros_documentos.numero_documento%TYPE,
        p_pais_emision      IN pasajeros_documentos.pais_emision%TYPE,
        p_fecha_emision     IN pasajeros_documentos.fecha_emision%TYPE,
        p_fecha_expiracion  IN pasajeros_documentos.fecha_expiracion%TYPE,
        p_imagen_documento  IN pasajeros_documentos.imagen_documento%TYPE,
        p_verificado        IN pasajeros_documentos.verificado%TYPE
    );

    PROCEDURE delete_documento(
        p_id_documento IN pasajeros_documentos.id_documento%TYPE
    );
END pkg_pasajeros_documentos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_pasajeros_documentos AS

    PROCEDURE insert_documento(
        p_id_documento      IN pasajeros_documentos.id_documento%TYPE,
        p_id_pasajero       IN pasajeros_documentos.id_pasajero%TYPE,
        p_tipo_documento    IN pasajeros_documentos.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros_documentos.numero_documento%TYPE,
        p_pais_emision      IN pasajeros_documentos.pais_emision%TYPE,
        p_fecha_emision     IN pasajeros_documentos.fecha_emision%TYPE,
        p_fecha_expiracion  IN pasajeros_documentos.fecha_expiracion%TYPE,
        p_imagen_documento  IN pasajeros_documentos.imagen_documento%TYPE,
        p_verificado        IN pasajeros_documentos.verificado%TYPE
    ) IS
    BEGIN
        INSERT INTO pasajeros_documentos (
            id_documento, id_pasajero, tipo_documento, numero_documento,
            pais_emision, fecha_emision, fecha_expiracion,
            imagen_documento, verificado
        ) VALUES (
            p_id_documento, p_id_pasajero, p_tipo_documento, p_numero_documento,
            p_pais_emision, p_fecha_emision, p_fecha_expiracion,
            p_imagen_documento, NVL(p_verificado,0)
        );
        COMMIT;
    END insert_documento;

    PROCEDURE get_documento(
        p_id_documento IN pasajeros_documentos.id_documento%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM pasajeros_documentos WHERE id_documento = p_id_documento;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Documento: ' || r.id_documento);
            DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
            DBMS_OUTPUT.PUT_LINE('Tipo documento: ' || r.tipo_documento);
            DBMS_OUTPUT.PUT_LINE('Número documento: ' || r.numero_documento);
            DBMS_OUTPUT.PUT_LINE('País emisión: ' || r.pais_emision);
            DBMS_OUTPUT.PUT_LINE('Fecha emisión: ' || r.fecha_emision);
            DBMS_OUTPUT.PUT_LINE('Fecha expiración: ' || r.fecha_expiracion);
            DBMS_OUTPUT.PUT_LINE('Verificado: ' || r.verificado);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Documento no encontrado.');
        END IF;
        CLOSE c;
    END get_documento;

    PROCEDURE update_documento(
        p_id_documento      IN pasajeros_documentos.id_documento%TYPE,
        p_tipo_documento    IN pasajeros_documentos.tipo_documento%TYPE,
        p_numero_documento  IN pasajeros_documentos.numero_documento%TYPE,
        p_pais_emision      IN pasajeros_documentos.pais_emision%TYPE,
        p_fecha_emision     IN pasajeros_documentos.fecha_emision%TYPE,
        p_fecha_expiracion  IN pasajeros_documentos.fecha_expiracion%TYPE,
        p_imagen_documento  IN pasajeros_documentos.imagen_documento%TYPE,
        p_verificado        IN pasajeros_documentos.verificado%TYPE
    ) IS
    BEGIN
        UPDATE pasajeros_documentos
        SET tipo_documento = p_tipo_documento,
            numero_documento = p_numero_documento,
            pais_emision = p_pais_emision,
            fecha_emision = p_fecha_emision,
            fecha_expiracion = p_fecha_expiracion,
            imagen_documento = p_imagen_documento,
            verificado = p_verificado
        WHERE id_documento = p_id_documento;
        COMMIT;
    END update_documento;

    PROCEDURE delete_documento(
        p_id_documento IN pasajeros_documentos.id_documento%TYPE
    ) IS
    BEGIN
        DELETE FROM pasajeros_documentos
        WHERE id_documento = p_id_documento;
        COMMIT;
    END delete_documento;

END pkg_pasajeros_documentos;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla RESERVAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_reservas AS
    PROCEDURE insert_reserva(
        p_id_reserva              IN reservas.id_reserva%TYPE,
        p_id_vuelo                IN reservas.id_vuelo%TYPE,
        p_id_pasajero             IN reservas.id_pasajero%TYPE,
        p_codigo_reserva          IN reservas.codigo_reserva%TYPE,
        p_fecha_modificacion      IN reservas.fecha_modificacion%TYPE,
        p_estado_reserva          IN reservas.estado_reserva%TYPE DEFAULT 'CONFIRMADA',
        p_tipo_tarifa             IN reservas.tipo_tarifa%TYPE,
        p_precio_pagado           IN reservas.precio_pagado%TYPE,
        p_moneda                  IN reservas.moneda%TYPE,
        p_numero_asiento          IN reservas.numero_asiento%TYPE,
        p_clase_servicio          IN reservas.clase_servicio%TYPE,
        p_equipaje_facturado_kg   IN reservas.equipaje_facturado_kg%TYPE,
        p_equipaje_mano_kg        IN reservas.equipaje_mano_kg%TYPE,
        p_checkin_realizado       IN reservas.checkin_realizado%TYPE DEFAULT 0,
        p_fecha_checkin           IN reservas.fecha_checkin%TYPE,
        p_puerta_embarque_asignada IN reservas.puerta_embarque_asignada%TYPE,
        p_grupo_embarque          IN reservas.grupo_embarque%TYPE,
        p_observaciones           IN reservas.observaciones%TYPE
    );

    PROCEDURE get_reserva(
        p_id_reserva IN reservas.id_reserva%TYPE
    );

    PROCEDURE update_reserva(
        p_id_reserva              IN reservas.id_reserva%TYPE,
        p_estado_reserva          IN reservas.estado_reserva%TYPE,
        p_fecha_modificacion      IN reservas.fecha_modificacion%TYPE,
        p_tipo_tarifa             IN reservas.tipo_tarifa%TYPE,
        p_precio_pagado           IN reservas.precio_pagado%TYPE,
        p_moneda                  IN reservas.moneda%TYPE,
        p_numero_asiento          IN reservas.numero_asiento%TYPE,
        p_clase_servicio          IN reservas.clase_servicio%TYPE,
        p_equipaje_facturado_kg   IN reservas.equipaje_facturado_kg%TYPE,
        p_equipaje_mano_kg        IN reservas.equipaje_mano_kg%TYPE,
        p_checkin_realizado       IN reservas.checkin_realizado%TYPE,
        p_fecha_checkin           IN reservas.fecha_checkin%TYPE,
        p_puerta_embarque_asignada IN reservas.puerta_embarque_asignada%TYPE,
        p_grupo_embarque          IN reservas.grupo_embarque%TYPE,
        p_observaciones           IN reservas.observaciones%TYPE
    );

    PROCEDURE delete_reserva(
        p_id_reserva IN reservas.id_reserva%TYPE
    );
END pkg_reservas;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_reservas AS

    -- INSERT
    PROCEDURE insert_reserva(
        p_id_reserva              IN reservas.id_reserva%TYPE,
        p_id_vuelo                IN reservas.id_vuelo%TYPE,
        p_id_pasajero             IN reservas.id_pasajero%TYPE,
        p_codigo_reserva          IN reservas.codigo_reserva%TYPE,
        p_fecha_modificacion      IN reservas.fecha_modificacion%TYPE,
        p_estado_reserva          IN reservas.estado_reserva%TYPE,
        p_tipo_tarifa             IN reservas.tipo_tarifa%TYPE,
        p_precio_pagado           IN reservas.precio_pagado%TYPE,
        p_moneda                  IN reservas.moneda%TYPE,
        p_numero_asiento          IN reservas.numero_asiento%TYPE,
        p_clase_servicio          IN reservas.clase_servicio%TYPE,
        p_equipaje_facturado_kg   IN reservas.equipaje_facturado_kg%TYPE,
        p_equipaje_mano_kg        IN reservas.equipaje_mano_kg%TYPE,
        p_checkin_realizado       IN reservas.checkin_realizado%TYPE,
        p_fecha_checkin           IN reservas.fecha_checkin%TYPE,
        p_puerta_embarque_asignada IN reservas.puerta_embarque_asignada%TYPE,
        p_grupo_embarque          IN reservas.grupo_embarque%TYPE,
        p_observaciones           IN reservas.observaciones%TYPE
    ) IS
    BEGIN
        INSERT INTO reservas (
            id_reserva, id_vuelo, id_pasajero, codigo_reserva,
            fecha_reserva, fecha_modificacion, estado_reserva,
            tipo_tarifa, precio_pagado, moneda, numero_asiento,
            clase_servicio, equipaje_facturado_kg, equipaje_mano_kg,
            checkin_realizado, fecha_checkin, puerta_embarque_asignada,
            grupo_embarque, observaciones
        ) VALUES (
            p_id_reserva, p_id_vuelo, p_id_pasajero, p_codigo_reserva,
            SYSDATE, p_fecha_modificacion, NVL(p_estado_reserva,'CONFIRMADA'),
            p_tipo_tarifa, p_precio_pagado, p_moneda, p_numero_asiento,
            p_clase_servicio, p_equipaje_facturado_kg, p_equipaje_mano_kg,
            NVL(p_checkin_realizado,0), p_fecha_checkin, p_puerta_embarque_asignada,
            p_grupo_embarque, p_observaciones
        );
        COMMIT;
    END insert_reserva;

    -- GET
    PROCEDURE get_reserva(
        p_id_reserva IN reservas.id_reserva%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM reservas WHERE id_reserva = p_id_reserva;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Reserva: ' || r.id_reserva);
            DBMS_OUTPUT.PUT_LINE('Vuelo: ' || r.id_vuelo);
            DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
            DBMS_OUTPUT.PUT_LINE('Código: ' || r.codigo_reserva);
            DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado_reserva);
            DBMS_OUTPUT.PUT_LINE('Fecha reserva: ' || r.fecha_reserva);
            DBMS_OUTPUT.PUT_LINE('Fecha modificación: ' || r.fecha_modificacion);
            DBMS_OUTPUT.PUT_LINE('Tarifa: ' || r.tipo_tarifa);
            DBMS_OUTPUT.PUT_LINE('Precio: ' || r.precio_pagado || ' ' || r.moneda);
            DBMS_OUTPUT.PUT_LINE('Asiento: ' || r.numero_asiento);
            DBMS_OUTPUT.PUT_LINE('Clase: ' || r.clase_servicio);
            DBMS_OUTPUT.PUT_LINE('Equipaje facturado: ' || r.equipaje_facturado_kg || ' kg');
            DBMS_OUTPUT.PUT_LINE('Equipaje mano: ' || r.equipaje_mano_kg || ' kg');
            DBMS_OUTPUT.PUT_LINE('Check-in realizado: ' || r.checkin_realizado);
            DBMS_OUTPUT.PUT_LINE('Fecha check-in: ' || r.fecha_checkin);
            DBMS_OUTPUT.PUT_LINE('Puerta embarque: ' || r.puerta_embarque_asignada);
            DBMS_OUTPUT.PUT_LINE('Grupo embarque: ' || r.grupo_embarque);
            DBMS_OUTPUT.PUT_LINE('Observaciones: ' || r.observaciones);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Reserva no encontrada.');
        END IF;
        CLOSE c;
    END get_reserva;

    -- UPDATE
    PROCEDURE update_reserva(
        p_id_reserva              IN reservas.id_reserva%TYPE,
        p_estado_reserva          IN reservas.estado_reserva%TYPE,
        p_fecha_modificacion      IN reservas.fecha_modificacion%TYPE,
        p_tipo_tarifa             IN reservas.tipo_tarifa%TYPE,
        p_precio_pagado           IN reservas.precio_pagado%TYPE,
        p_moneda                  IN reservas.moneda%TYPE,
        p_numero_asiento          IN reservas.numero_asiento%TYPE,
        p_clase_servicio          IN reservas.clase_servicio%TYPE,
        p_equipaje_facturado_kg   IN reservas.equipaje_facturado_kg%TYPE,
        p_equipaje_mano_kg        IN reservas.equipaje_mano_kg%TYPE,
        p_checkin_realizado       IN reservas.checkin_realizado%TYPE,
        p_fecha_checkin           IN reservas.fecha_checkin%TYPE,
        p_puerta_embarque_asignada IN reservas.puerta_embarque_asignada%TYPE,
        p_grupo_embarque          IN reservas.grupo_embarque%TYPE,
        p_observaciones           IN reservas.observaciones%TYPE
    ) IS
    BEGIN
                UPDATE reservas
        SET estado_reserva = p_estado_reserva,
            fecha_modificacion = NVL(p_fecha_modificacion, SYSDATE),
            tipo_tarifa = p_tipo_tarifa,
            precio_pagado = p_precio_pagado,
            moneda = p_moneda,
            numero_asiento = p_numero_asiento,
            clase_servicio = p_clase_servicio,
            equipaje_facturado_kg = p_equipaje_facturado_kg,
            equipaje_mano_kg = p_equipaje_mano_kg,
            checkin_realizado = p_checkin_realizado,
            fecha_checkin = p_fecha_checkin,
            puerta_embarque_asignada = p_puerta_embarque_asignada,
            grupo_embarque = p_grupo_embarque,
            observaciones = p_observaciones
        WHERE id_reserva = p_id_reserva;
        COMMIT;
    END update_reserva;

    -- DELETE
    PROCEDURE delete_reserva(
        p_id_reserva IN reservas.id_reserva%TYPE
    ) IS
    BEGIN
        DELETE FROM reservas
        WHERE id_reserva = p_id_reserva;
        COMMIT;
    END delete_reserva;

END pkg_reservas;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla METODOS_PAGO
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_metodos_pago AS
    PROCEDURE insert_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE,
        p_descripcion    IN metodos_pago.descripcion%TYPE,
        p_tipo_pago      IN metodos_pago.tipo_pago%TYPE,
        p_procesador     IN metodos_pago.procesador%TYPE,
        p_activo         IN metodos_pago.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE
    );

    PROCEDURE update_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE,
        p_descripcion    IN metodos_pago.descripcion%TYPE,
        p_tipo_pago      IN metodos_pago.tipo_pago%TYPE,
        p_procesador     IN metodos_pago.procesador%TYPE,
        p_activo         IN metodos_pago.activo%TYPE
    );

    PROCEDURE delete_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE
    );
END pkg_metodos_pago;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_metodos_pago AS

    PROCEDURE insert_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE,
        p_descripcion    IN metodos_pago.descripcion%TYPE,
        p_tipo_pago      IN metodos_pago.tipo_pago%TYPE,
        p_procesador     IN metodos_pago.procesador%TYPE,
        p_activo         IN metodos_pago.activo%TYPE
    ) IS
    BEGIN
        INSERT INTO metodos_pago (
            id_metodo_pago, descripcion, tipo_pago, procesador, activo
        ) VALUES (
            p_id_metodo_pago, p_descripcion, p_tipo_pago, p_procesador, NVL(p_activo,1)
        );
        COMMIT;
    END insert_metodo;

    PROCEDURE get_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM metodos_pago WHERE id_metodo_pago = p_id_metodo_pago;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Método: ' || r.id_metodo_pago);
            DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
            DBMS_OUTPUT.PUT_LINE('Tipo pago: ' || r.tipo_pago);
            DBMS_OUTPUT.PUT_LINE('Procesador: ' || r.procesador);
            DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Método de pago no encontrado.');
        END IF;
        CLOSE c;
    END get_metodo;

    PROCEDURE update_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE,
        p_descripcion    IN metodos_pago.descripcion%TYPE,
        p_tipo_pago      IN metodos_pago.tipo_pago%TYPE,
        p_procesador     IN metodos_pago.procesador%TYPE,
        p_activo         IN metodos_pago.activo%TYPE
    ) IS
    BEGIN
        UPDATE metodos_pago
        SET descripcion = p_descripcion,
            tipo_pago = p_tipo_pago,
            procesador = p_procesador,
            activo = p_activo
        WHERE id_metodo_pago = p_id_metodo_pago;
        COMMIT;
    END update_metodo;

    PROCEDURE delete_metodo(
        p_id_metodo_pago IN metodos_pago.id_metodo_pago%TYPE
    ) IS
    BEGIN
        DELETE FROM metodos_pago
        WHERE id_metodo_pago = p_id_metodo_pago;
        COMMIT;
    END delete_metodo;

END pkg_metodos_pago;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla RESERVAS_PAGOS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_reservas_pagos AS
    PROCEDURE insert_pago(
        p_id_pago             IN reservas_pagos.id_pago%TYPE,
        p_id_reserva          IN reservas_pagos.id_reserva%TYPE,
        p_id_metodo_pago      IN reservas_pagos.id_metodo_pago%TYPE,
        p_monto               IN reservas_pagos.monto%TYPE,
        p_moneda              IN reservas_pagos.moneda%TYPE,
        p_fecha_pago          IN reservas_pagos.fecha_pago%TYPE,
        p_codigo_transaccion  IN reservas_pagos.codigo_transaccion%TYPE,
        p_estado_pago         IN reservas_pagos.estado_pago%TYPE DEFAULT 'COMPLETADO',
        p_comprobante_pago    IN reservas_pagos.comprobante_pago%TYPE
    );

    PROCEDURE get_pago(
        p_id_pago IN reservas_pagos.id_pago%TYPE
    );

    PROCEDURE update_pago(
        p_id_pago             IN reservas_pagos.id_pago%TYPE,
        p_monto               IN reservas_pagos.monto%TYPE,
        p_moneda              IN reservas_pagos.moneda%TYPE,
        p_fecha_pago          IN reservas_pagos.fecha_pago%TYPE,
        p_codigo_transaccion  IN reservas_pagos.codigo_transaccion%TYPE,
        p_estado_pago         IN reservas_pagos.estado_pago%TYPE,
        p_comprobante_pago    IN reservas_pagos.comprobante_pago%TYPE
    );

    PROCEDURE delete_pago(
        p_id_pago IN reservas_pagos.id_pago%TYPE
    );
END pkg_reservas_pagos;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_reservas_pagos AS

    -- INSERT
    PROCEDURE insert_pago(
        p_id_pago             IN reservas_pagos.id_pago%TYPE,
        p_id_reserva          IN reservas_pagos.id_reserva%TYPE,
        p_id_metodo_pago      IN reservas_pagos.id_metodo_pago%TYPE,
        p_monto               IN reservas_pagos.monto%TYPE,
        p_moneda              IN reservas_pagos.moneda%TYPE,
        p_fecha_pago          IN reservas_pagos.fecha_pago%TYPE,
        p_codigo_transaccion  IN reservas_pagos.codigo_transaccion%TYPE,
        p_estado_pago         IN reservas_pagos.estado_pago%TYPE,
        p_comprobante_pago    IN reservas_pagos.comprobante_pago%TYPE
    ) IS
    BEGIN
        INSERT INTO reservas_pagos (
            id_pago, id_reserva, id_metodo_pago, monto, moneda,
            fecha_pago, codigo_transaccion, estado_pago, comprobante_pago
        ) VALUES (
            p_id_pago, p_id_reserva, p_id_metodo_pago, p_monto, p_moneda,
            p_fecha_pago, p_codigo_transaccion, NVL(p_estado_pago,'COMPLETADO'), p_comprobante_pago
        );
        COMMIT;
    END insert_pago;

    -- GET
    PROCEDURE get_pago(
        p_id_pago IN reservas_pagos.id_pago%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM reservas_pagos WHERE id_pago = p_id_pago;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Pago: ' || r.id_pago);
            DBMS_OUTPUT.PUT_LINE('Reserva: ' || r.id_reserva);
            DBMS_OUTPUT.PUT_LINE('Método pago: ' || r.id_metodo_pago);
            DBMS_OUTPUT.PUT_LINE('Monto: ' || r.monto || ' ' || r.moneda);
            DBMS_OUTPUT.PUT_LINE('Fecha pago: ' || r.fecha_pago);
            DBMS_OUTPUT.PUT_LINE('Código transacción: ' || r.codigo_transaccion);
            DBMS_OUTPUT.PUT_LINE('Estado: ' || r.estado_pago);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Pago no encontrado.');
        END IF;
        CLOSE c;
    END get_pago;

    -- UPDATE
    PROCEDURE update_pago(
        p_id_pago             IN reservas_pagos.id_pago%TYPE,
        p_monto               IN reservas_pagos.monto%TYPE,
        p_moneda              IN reservas_pagos.moneda%TYPE,
        p_fecha_pago          IN reservas_pagos.fecha_pago%TYPE,
        p_codigo_transaccion  IN reservas_pagos.codigo_transaccion%TYPE,
        p_estado_pago         IN reservas_pagos.estado_pago%TYPE,
        p_comprobante_pago    IN reservas_pagos.comprobante_pago%TYPE
    ) IS
    BEGIN
        UPDATE reservas_pagos
        SET monto = p_monto,
            moneda = p_moneda,
            fecha_pago = p_fecha_pago,
            codigo_transaccion = p_codigo_transaccion,
            estado_pago = p_estado_pago,
            comprobante_pago = p_comprobante_pago
        WHERE id_pago = p_id_pago;
        COMMIT;
    END update_pago;

    -- DELETE
    PROCEDURE delete_pago(
        p_id_pago IN reservas_pagos.id_pago%TYPE
    ) IS
    BEGIN
        DELETE FROM reservas_pagos
        WHERE id_pago = p_id_pago;
        COMMIT;
    END delete_pago;

END pkg_reservas_pagos;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla TIPOS_INCIDENTES
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tipos_incidentes AS
    PROCEDURE insert_incidente(
        p_id_tipo_incidente IN tipos_incidentes.id_tipo_incidente%TYPE,
        p_nombre_tipo       IN tipos_incidentes.nombre_tipo%TYPE,
        p_descripcion       IN tipos_incidentes.descripcion%TYPE,
        p_protocolo_accion  IN tipos_incidentes.protocolo_accion%TYPE,
        p_tiempo_respuesta  IN tipos_incidentes.tiempo_respuesta_estimado%TYPE,
        p_activo            IN tipos_incidentes.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_incidente(
        p_id_tipo_incidente IN tipos_incidentes.id_tipo_incidente%TYPE
    );

    PROCEDURE update_incidente(
        p_id_tipo_incidente IN tipos_incidentes.id_tipo_incidente%TYPE,
        p_nombre_tipo       IN tipos_incidentes.nombre_tipo%TYPE,
        p_descripcion       IN tipos_incidentes.descripcion%TYPE,
        p_protocolo_accion  IN tipos_incidentes.protocolo_accion%TYPE,
        p_tiempo_respuesta  IN tipos_incidentes.tiempo_respuesta_estimado%TYPE,
        p_activo            IN tipos_incidentes.activo%TYPE
    );

    PROCEDURE delete_incidente(
        p_id_tipo_incidente IN tipos_incidentes.id_tipo_incidente%TYPE
    );
END pkg_tipos_incidentes;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tipos_incidentes AS

    -- INSERT
    PROCEDURE insert_incidente(
        p_id_tipo_incidente IN tipos_incidentes.id_tipo_incidente%TYPE,
        p_nombre_tipo       IN tipos_incidentes.nombre_tipo%TYPE,
        p_descripcion       IN tipos_incidentes.descripcion%TYPE,
        p_protocolo_accion  IN tipos_incidentes.protocolo_accion%TYPE,
        p_tiempo_respuesta  IN tipos_incidentes.tiempo_respuesta_estimado%TYPE,
        p_activo            IN tipos_incidentes.activo%TYPE
    ) IS
    BEGIN
        INSERT INTO tipos_incidentes (
            id_tipo_incidente, nombre_tipo, descripcion,
            protocolo_accion, tiempo_respuesta_estimado, activo
        ) VALUES (
            p_id_tipo_incidente, p_nombre_tipo, p_descripcion,
            p_protocolo_accion, p_tiempo_respuesta, NVL(p_activo,1)
        );
        COMMIT;
    END insert_incidente;

    -- GET
    PROCEDURE get_incidente(
        p_id_tipo_incidente IN tipos_incidentes.id_tipo_incidente%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM tipos_incidentes WHERE id_tipo_incidente = p_id_tipo_incidente;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Tipo Incidente: ' || r.id_tipo_incidente);
            DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_tipo);
            DBMS_OUTPUT.PUT_LINE('Descripción: ' || r.descripcion);
            DBMS_OUTPUT.PUT_LINE('Protocolo acción: ' || r.protocolo_accion);
            DBMS_OUTPUT.PUT_LINE('Tiempo respuesta estimado: ' || r.tiempo_respuesta_estimado || ' min');
            DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Tipo de incidente no encontrado.');
        END IF;
        CLOSE c;
    END get_incidente;

    -- UPDATE
    PROCEDURE update_incidente(
        p_id_tipo_incidente IN tipos_incidentes.id_tipo_incidente%TYPE,
        p_nombre_tipo       IN tipos_incidentes.nombre_tipo%TYPE,
        p_descripcion       IN tipos_incidentes.descripcion%TYPE,
        p_protocolo_accion  IN tipos_incidentes.protocolo_accion%TYPE,
        p_tiempo_respuesta  IN tipos_incidentes.tiempo_respuesta_estimado%TYPE,
        p_activo            IN tipos_incidentes.activo%TYPE
    ) IS
    BEGIN
        UPDATE tipos_incidentes
        SET nombre_tipo = p_nombre_tipo,
            descripcion = p_descripcion,
            protocolo_accion = p_protocolo_accion,
            tiempo_respuesta_estimado = p_tiempo_respuesta,
            activo = p_activo
        WHERE id_tipo_incidente = p_id_tipo_incidente;
        COMMIT;
    END update_incidente;

    -- DELETE
    PROCEDURE delete_incidente(
        p_id_tipo_incidente IN tipos_incidentes.id_tipo_incidente%TYPE
    ) IS
    BEGIN
        DELETE FROM tipos_incidentes
        WHERE id_tipo_incidente = p_id_tipo_incidente;
        COMMIT;
    END delete_incidente;

END pkg_tipos_incidentes;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla PROGRAMA_LEALTAD
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_programa_lealtad AS
    PROCEDURE insert_lealtad(
        p_id_lealtad            IN programa_lealtad.id_lealtad%TYPE,
        p_id_pasajero           IN programa_lealtad.id_pasajero%TYPE,
        p_nivel_membresia       IN programa_lealtad.nivel_membresia%TYPE,
        p_puntos_acumulados     IN programa_lealtad.puntos_acumulados%TYPE DEFAULT 0,
        p_puntos_canjeables     IN programa_lealtad.puntos_canjeables%TYPE DEFAULT 0,
        p_fecha_ingreso         IN programa_lealtad.fecha_ingreso%TYPE,
        p_fecha_ultima_actividad IN programa_lealtad.fecha_ultima_actividad%TYPE,
        p_millas_acumuladas     IN programa_lealtad.millas_acumuladas%TYPE DEFAULT 0,
        p_beneficios_activos    IN programa_lealtad.beneficios_activos%TYPE,
        p_tarjeta_numero        IN programa_lealtad.tarjeta_numero%TYPE,
        p_activo                IN programa_lealtad.activo%TYPE DEFAULT 1
    );

    PROCEDURE get_lealtad(
        p_id_lealtad IN programa_lealtad.id_lealtad%TYPE
    );

    PROCEDURE update_lealtad(
        p_id_lealtad            IN programa_lealtad.id_lealtad%TYPE,
        p_nivel_membresia       IN programa_lealtad.nivel_membresia%TYPE,
        p_puntos_acumulados     IN programa_lealtad.puntos_acumulados%TYPE,
        p_puntos_canjeables     IN programa_lealtad.puntos_canjeables%TYPE,
        p_fecha_ultima_actividad IN programa_lealtad.fecha_ultima_actividad%TYPE,
        p_millas_acumuladas     IN programa_lealtad.millas_acumuladas%TYPE,
        p_beneficios_activos    IN programa_lealtad.beneficios_activos%TYPE,
        p_tarjeta_numero        IN programa_lealtad.tarjeta_numero%TYPE,
        p_activo                IN programa_lealtad.activo%TYPE
    );

    PROCEDURE delete_lealtad(
        p_id_lealtad IN programa_lealtad.id_lealtad%TYPE
    );
END pkg_programa_lealtad;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_programa_lealtad AS

    -- INSERT
    PROCEDURE insert_lealtad(
        p_id_lealtad            IN programa_lealtad.id_lealtad%TYPE,
        p_id_pasajero           IN programa_lealtad.id_pasajero%TYPE,
        p_nivel_membresia       IN programa_lealtad.nivel_membresia%TYPE,
        p_puntos_acumulados     IN programa_lealtad.puntos_acumulados%TYPE,
        p_puntos_canjeables     IN programa_lealtad.puntos_canjeables%TYPE,
        p_fecha_ingreso         IN programa_lealtad.fecha_ingreso%TYPE,
        p_fecha_ultima_actividad IN programa_lealtad.fecha_ultima_actividad%TYPE,
        p_millas_acumuladas     IN programa_lealtad.millas_acumuladas%TYPE,
        p_beneficios_activos    IN programa_lealtad.beneficios_activos%TYPE,
        p_tarjeta_numero        IN programa_lealtad.tarjeta_numero%TYPE,
        p_activo                IN programa_lealtad.activo%TYPE
    ) IS
    BEGIN
        INSERT INTO programa_lealtad (
            id_lealtad, id_pasajero, nivel_membresia,
            puntos_acumulados, puntos_canjeables, fecha_ingreso,
            fecha_ultima_actividad, millas_acumuladas,
            beneficios_activos, tarjeta_numero, activo
        ) VALUES (
            p_id_lealtad, p_id_pasajero, p_nivel_membresia,
            NVL(p_puntos_acumulados,0), NVL(p_puntos_canjeables,0), p_fecha_ingreso,
            p_fecha_ultima_actividad, NVL(p_millas_acumuladas,0),
            p_beneficios_activos, p_tarjeta_numero, NVL(p_activo,1)
        );
        COMMIT;
    END insert_lealtad;

    -- GET
    PROCEDURE get_lealtad(
        p_id_lealtad IN programa_lealtad.id_lealtad%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM programa_lealtad WHERE id_lealtad = p_id_lealtad;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Lealtad: ' || r.id_lealtad);
            DBMS_OUTPUT.PUT_LINE('Pasajero: ' || r.id_pasajero);
            DBMS_OUTPUT.PUT_LINE('Nivel membresía: ' || r.nivel_membresia);
            DBMS_OUTPUT.PUT_LINE('Puntos acumulados: ' || r.puntos_acumulados);
            DBMS_OUTPUT.PUT_LINE('Puntos canjeables: ' || r.puntos_canjeables);
            DBMS_OUTPUT.PUT_LINE('Fecha ingreso: ' || r.fecha_ingreso);
            DBMS_OUTPUT.PUT_LINE('Última actividad: ' || r.fecha_ultima_actividad);
            DBMS_OUTPUT.PUT_LINE('Millas acumuladas: ' || r.millas_acumuladas);
            DBMS_OUTPUT.PUT_LINE('Beneficios activos: ' || r.beneficios_activos);
            DBMS_OUTPUT.PUT_LINE('Tarjeta número: ' || r.tarjeta_numero);
            DBMS_OUTPUT.PUT_LINE('Activo: ' || r.activo);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Registro de lealtad no encontrado.');
        END IF;
        CLOSE c;
    END get_lealtad;

    -- UPDATE
    PROCEDURE update_lealtad(
        p_id_lealtad            IN programa_lealtad.id_lealtad%TYPE,
        p_nivel_membresia       IN programa_lealtad.nivel_membresia%TYPE,
        p_puntos_acumulados     IN programa_lealtad.puntos_acumulados%TYPE,
        p_puntos_canjeables     IN programa_lealtad.puntos_canjeables%TYPE,
        p_fecha_ultima_actividad IN programa_lealtad.fecha_ultima_actividad%TYPE,
        p_millas_acumuladas     IN programa_lealtad.millas_acumuladas%TYPE,
        p_beneficios_activos    IN programa_lealtad.beneficios_activos%TYPE,
        p_tarjeta_numero        IN programa_lealtad.tarjeta_numero%TYPE,
        p_activo                IN programa_lealtad.activo%TYPE
    ) IS
    BEGIN
        UPDATE programa_lealtad
        SET nivel_membresia = p_nivel_membresia,
            puntos_acumulados = p_puntos_acumulados,
            puntos_canjeables = p_puntos_canjeables,
            fecha_ultima_actividad = p_fecha_ultima_actividad,
            millas_acumuladas = p_millas_acumuladas,
            beneficios_activos = p_beneficios_activos,
            tarjeta_numero = p_tarjeta_numero,
            activo = p_activo
        WHERE id_lealtad = p_id_lealtad;
        COMMIT;
    END update_lealtad;

    -- DELETE
    PROCEDURE delete_lealtad(
        p_id_lealtad IN programa_lealtad.id_lealtad%TYPE
    ) IS
    BEGIN
        DELETE FROM programa_lealtad
        WHERE id_lealtad = p_id_lealtad;
        COMMIT;
    END delete_lealtad;

END pkg_programa_lealtad;
/

------------------------------------------------------------
-- Paquete CRUD para la tabla TASAS_AEROPORTUARIAS
------------------------------------------------------------
CREATE OR REPLACE PACKAGE pkg_tasas_aeroportuarias AS
    PROCEDURE insert_tasa(
        p_id_tasa            IN tasas_aeroportuarias.id_tasa%TYPE,
        p_nombre_tasa        IN tasas_aeroportuarias.nombre_tasa%TYPE,
        p_tipo_tasa          IN tasas_aeroportuarias.tipo_tasa%TYPE,
        p_monto              IN tasas_aeroportuarias.monto%TYPE,
        p_moneda             IN tasas_aeroportuarias.moneda%TYPE,
        p_calculo_porcentaje IN tasas_aeroportuarias.calculo_porcentaje%TYPE,
        p_aplica_a           IN tasas_aeroportuarias.aplica_a%TYPE,
        p_activa             IN tasas_aeroportuarias.activa%TYPE DEFAULT 1,
        p_fecha_actualizacion IN tasas_aeroportuarias.fecha_actualizacion%TYPE
    );

    PROCEDURE get_tasa(
        p_id_tasa IN tasas_aeroportuarias.id_tasa%TYPE
    );

    PROCEDURE update_tasa(
        p_id_tasa            IN tasas_aeroportuarias.id_tasa%TYPE,
        p_nombre_tasa        IN tasas_aeroportuarias.nombre_tasa%TYPE,
        p_tipo_tasa          IN tasas_aeroportuarias.tipo_tasa%TYPE,
        p_monto              IN tasas_aeroportuarias.monto%TYPE,
        p_moneda             IN tasas_aeroportuarias.moneda%TYPE,
        p_calculo_porcentaje IN tasas_aeroportuarias.calculo_porcentaje%TYPE,
        p_aplica_a           IN tasas_aeroportuarias.aplica_a%TYPE,
        p_activa             IN tasas_aeroportuarias.activa%TYPE,
        p_fecha_actualizacion IN tasas_aeroportuarias.fecha_actualizacion%TYPE
    );

    PROCEDURE delete_tasa(
        p_id_tasa IN tasas_aeroportuarias.id_tasa%TYPE
    );
END pkg_tasas_aeroportuarias;
/
------------------------------------------------------------
-- Implementación del paquete
------------------------------------------------------------
CREATE OR REPLACE PACKAGE BODY pkg_tasas_aeroportuarias AS

    -- INSERT
    PROCEDURE insert_tasa(
        p_id_tasa            IN tasas_aeroportuarias.id_tasa%TYPE,
        p_nombre_tasa        IN tasas_aeroportuarias.nombre_tasa%TYPE,
        p_tipo_tasa          IN tasas_aeroportuarias.tipo_tasa%TYPE,
        p_monto              IN tasas_aeroportuarias.monto%TYPE,
        p_moneda             IN tasas_aeroportuarias.moneda%TYPE,
        p_calculo_porcentaje IN tasas_aeroportuarias.calculo_porcentaje%TYPE,
        p_aplica_a           IN tasas_aeroportuarias.aplica_a%TYPE,
        p_activa             IN tasas_aeroportuarias.activa%TYPE,
        p_fecha_actualizacion IN tasas_aeroportuarias.fecha_actualizacion%TYPE
    ) IS
    BEGIN
        INSERT INTO tasas_aeroportuarias (
            id_tasa, nombre_tasa, tipo_tasa, monto, moneda,
            calculo_porcentaje, aplica_a, activa, fecha_actualizacion
        ) VALUES (
            p_id_tasa, p_nombre_tasa, p_tipo_tasa, p_monto, p_moneda,
            p_calculo_porcentaje, p_aplica_a, NVL(p_activa,1), p_fecha_actualizacion
        );
        COMMIT;
    END insert_tasa;

    -- GET
    PROCEDURE get_tasa(
        p_id_tasa IN tasas_aeroportuarias.id_tasa%TYPE
    ) IS
        CURSOR c IS
            SELECT * FROM tasas_aeroportuarias WHERE id_tasa = p_id_tasa;
        r c%ROWTYPE;
    BEGIN
        OPEN c;
        FETCH c INTO r;
        IF c%FOUND THEN
            DBMS_OUTPUT.PUT_LINE('ID Tasa: ' || r.id_tasa);
            DBMS_OUTPUT.PUT_LINE('Nombre: ' || r.nombre_tasa);
            DBMS_OUTPUT.PUT_LINE('Tipo: ' || r.tipo_tasa);
            DBMS_OUTPUT.PUT_LINE('Monto: ' || r.monto || ' ' || r.moneda);
            DBMS_OUTPUT.PUT_LINE('Cálculo %: ' || r.calculo_porcentaje);
            DBMS_OUTPUT.PUT_LINE('Aplica a: ' || r.aplica_a);
            DBMS_OUTPUT.PUT_LINE('Activa: ' || r.activa);
            DBMS_OUTPUT.PUT_LINE('Fecha actualización: ' || r.fecha_actualizacion);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Tasa aeroportuaria no encontrada.');
        END IF;
        CLOSE c;
    END get_tasa;

    -- UPDATE
    PROCEDURE update_tasa(
        p_id_tasa            IN tasas_aeroportuarias.id_tasa%TYPE,
        p_nombre_tasa        IN tasas_aeroportuarias.nombre_tasa%TYPE,
        p_tipo_tasa          IN tasas_aeroportuarias.tipo_tasa%TYPE,
        p_monto              IN tasas_aeroportuarias.monto%TYPE,
        p_moneda             IN tasas_aeroportuarias.moneda%TYPE,
        p_calculo_porcentaje IN tasas_aeroportuarias.calculo_porcentaje%TYPE,
        p_aplica_a           IN tasas_aeroportuarias.aplica_a%TYPE,
        p_activa             IN tasas_aeroportuarias.activa%TYPE,
        p_fecha_actualizacion IN tasas_aeroportuarias.fecha_actualizacion%TYPE
    ) IS
    BEGIN
        UPDATE tasas_aeroportuarias
        SET nombre_tasa = p_nombre_tasa,
            tipo_tasa = p_tipo_tasa,
            monto = p_monto,
            moneda = p_moneda,
            calculo_porcentaje = p_calculo_porcentaje,
            aplica_a = p_aplica_a,
            activa = p_activa,
            fecha_actualizacion = p_fecha_actualizacion
        WHERE id_tasa = p_id_tasa;
        COMMIT;
    END update_tasa;

    -- DELETE
    PROCEDURE delete_tasa(
        p_id_tasa IN tasas_aeroportuarias.id_tasa%TYPE
    ) IS
    BEGIN
        DELETE FROM tasas_aeroportuarias
        WHERE id_tasa = p_id_tasa;
        COMMIT;
    END delete_tasa;

END pkg_tasas_aeroportuarias;
/