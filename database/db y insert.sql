-- =====================================================
-- SCRIPT DE INSERCIÓN DE DATOS DE EJEMPLO
-- BASE DE DATOS AEROPORTUARIA
-- 10 REGISTROS POR TABLA (O MÍNIMO REQUERIDO)
-- MODIFICADO PARA GENERACIÓN AUTOMÁTICA DE IDs
-- =====================================================

-- =====================================================
-- MÓDULO 1: INFRAESTRUCTURA AEROPORTUARIA
-- =====================================================

-- Tabla 1.1: aeropuertos (10 principales)
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('MAD', 'Aeropuerto Adolfo Suárez Madrid-Barajas', 'Madrid', 'España', 'Comunidad de Madrid', 'Europa', 'UTC+1', 40.4936, -3.5668, 610, 4, 156, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('BCN', 'Aeropuerto Josep Tarradellas Barcelona-El Prat', 'Barcelona', 'España', 'Cataluña', 'Europa', 'UTC+1', 41.2974, 2.0833, 4, 2, 102, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('BOG', 'Aeropuerto Internacional El Dorado', 'Bogotá', 'Colombia', 'Cundinamarca', 'América', 'UTC-5', 4.7019, -74.1469, 2626, 2, 98, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('JFK', 'John F. Kennedy International Airport', 'Nueva York', 'Estados Unidos', 'Nueva York', 'América', 'UTC-5', 40.6413, -73.7781, 4, 6, 128, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('LAX', 'Los Angeles International Airport', 'Los Ángeles', 'Estados Unidos', 'California', 'América', 'UTC-8', 33.9416, -118.4085, 38, 9, 146, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('LHR', 'London Heathrow Airport', 'Londres', 'Reino Unido', 'Inglaterra', 'Europa', 'UTC+0', 51.4700, -0.4543, 25, 4, 92, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('CDG', 'Paris Charles de Gaulle Airport', 'París', 'Francia', 'Île-de-France', 'Europa', 'UTC+1', 49.0097, 2.5479, 119, 3, 112, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('MEX', 'Aeropuerto Internacional Benito Juárez', 'Ciudad de México', 'México', 'CDMX', 'América', 'UTC-6', 19.4363, -99.0721, 2230, 2, 74, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('GRU', 'Aeroporto Internacional de São Paulo-Guarulhos', 'São Paulo', 'Brasil', 'São Paulo', 'América', 'UTC-3', -23.4356, -46.4731, 750, 2, 68, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES
('SYD', 'Sydney Kingsford Smith International Airport', 'Sídney', 'Australia', 'Nueva Gales del Sur', 'Oceanía', 'UTC+11', -33.9399, 151.1753, 6, 3, 82, 1, 'SISTEMA');

-- Tabla 1.2: tipos_aeropuerto (se omite id_tipo_aeropuerto)
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Internacional', 'INTL', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Nacional', 'NATL', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Carga', 'CARGO', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Regional', 'REG', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Privado', 'PRIV', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Militar', 'MIL', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Hub Principal', 'HUB', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Low Cost', 'LCC', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Estacional', 'SEAS', 1);
INSERT INTO tipos_aeropuerto (descripcion, codigo, activo) VALUES ('Alternativo', 'ALT', 1);

-- Tabla 1.3: aeropuertos_tipos (clave compuesta, no autoincremental)
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('MAD', 1);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('MAD', 7);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('BCN', 1);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('BCN', 8);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('BOG', 1);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('BOG', 7);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('JFK', 1);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('JFK', 7);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('LAX', 1);
INSERT INTO aeropuertos_tipos (codigo_aeropuerto, id_tipo_aeropuerto) VALUES ('LHR', 1);

-- Tabla 1.4: aeropuertos_contactos (se omite id_contacto)
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('MAD', 'ADMINISTRACION', 'Ana García López', 'Directora General', '+34913456789', 'ana.garcia@aena.es', '08:00-18:00');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('MAD', 'OPERACIONES', 'Carlos Rodríguez', 'Jefe de Operaciones', '+34913456790', 'carlos.rodriguez@aena.es', '24h');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('BCN', 'ADMINISTRACION', 'María Pérez', 'Directora', '+34936789012', 'maria.perez@aena.es', '08:00-18:00');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('BOG', 'SEGURIDAD', 'Juan Martínez', 'Coordinador Seguridad', '+5712345678', 'juan.martinez@eldorado.co', '24h');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('JFK', 'OPERACIONES', 'John Smith', 'Operations Manager', '+17185551234', 'john.smith@panynj.gov', '24h');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('LAX', 'ATENCION_CLIENTE', 'Lisa Johnson', 'Customer Service', '+13105551234', 'lisa.johnson@lawa.org', '06:00-23:00');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('LHR', 'SEGURIDAD', 'David Brown', 'Security Chief', '+44208901234', 'david.brown@heathrow.com', '24h');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('CDG', 'ADMINISTRACION', 'Pierre Dubois', 'Directeur', '+33187654321', 'pierre.dubois@adp.fr', '09:00-17:00');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('MEX', 'OPERACIONES', 'Luisa Fernández', 'Gerente', '+525578901234', 'luisa.fernandez@aicm.mx', '24h');
INSERT INTO aeropuertos_contactos (codigo_aeropuerto, tipo_contacto, nombre, cargo, telefono, email, horario_atencion) VALUES
('GRU', 'MANTENIMIENTO', 'João Silva', 'Supervisor', '+551123456789', 'joao.silva@gru.com.br', '07:00-19:00');

-- Tabla 1.5: instalaciones_aeropuerto (se omite id_instalacion)
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('MAD', 'Terminal T4', 'TERMINAL', 35000000, 'OPERATIVA', DATE '2006-02-05', DATE '2020-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('MAD', 'Terminal T1', 'TERMINAL', 12000000, 'OPERATIVA', DATE '1950-01-01', DATE '2018-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('BCN', 'Terminal T1', 'TERMINAL', 25000000, 'OPERATIVA', DATE '2009-06-16', DATE '2019-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('BOG', 'Hangar Avianca', 'HANGAR', 5, 'OPERATIVO', DATE '2010-01-01', DATE '2021-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('JFK', 'Torre de Control', 'TORRE_CONTROL', NULL, 'OPERATIVA', DATE '1994-01-01', DATE '2015-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('LAX', 'Estacionamiento Central', 'ESTACIONAMIENTO', 8000, 'OPERATIVO', DATE '1984-01-01', DATE '2010-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('LHR', 'Terminal T5', 'TERMINAL', 30000000, 'OPERATIVA', DATE '2008-03-27', DATE '2022-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('CDG', 'Terminal 2E', 'TERMINAL', 15000000, 'OPERATIVA', DATE '2003-06-25', DATE '2016-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('MEX', 'Zona Comercial', 'COMERCIAL', 150, 'OPERATIVA', DATE '2000-01-01', DATE '2018-01-01');
INSERT INTO instalaciones_aeropuerto (codigo_aeropuerto, nombre_instalacion, tipo_instalacion, capacidad, estado, fecha_construccion, ultima_renovacion) VALUES
('GRU', 'Pista 09R/27L', 'PISTA', NULL, 'OPERATIVA', DATE '1985-01-01', DATE '2017-01-01');

-- Tabla 1.6: pistas_aterrizaje (se omite id_pista)
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('MAD', '18L/36R', 3500, 60, 'ASFALTO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('MAD', '18R/36L', 4100, 60, 'ASFALTO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('BCN', '07L/25R', 2660, 45, 'ASFALTO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('BCN', '07R/25L', 3352, 60, 'CONCRETO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('BOG', '13L/31R', 3800, 45, 'ASFALTO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('BOG', '13R/31L', 3800, 45, 'ASFALTO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('JFK', '04L/22R', 3460, 45, 'ASFALTO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('JFK', '04R/22L', 2560, 45, 'CONCRETO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('LAX', '06L/24R', 2720, 45, 'CONCRETO', 1, 1, 1);
INSERT INTO pistas_aterrizaje (codigo_aeropuerto, numero_pista, longitud_metros, anchura_metros, superficie, iluminacion_nocturna, sistema_ils, activo) VALUES
('LHR', '09L/27R', 3900, 50, 'ASFALTO', 1, 1, 1);

-- Tabla 1.7: puertas_embarque (se omite id_puerta)
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('MAD', 'A1', 'T4', 'INTERNACIONAL', 350, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('MAD', 'A2', 'T4', 'INTERNACIONAL', 350, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('MAD', 'B1', 'T4', 'NACIONAL', 250, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('BCN', 'C1', 'T1', 'INTERNACIONAL', 300, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('BCN', 'D1', 'T1', 'NACIONAL', 200, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('BOG', '1', 'T1', 'INTERNACIONAL', 400, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('BOG', '2', 'T1', 'INTERNACIONAL', 400, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('JFK', 'B1', 'T1', 'INTERNACIONAL', 450, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('JFK', 'B2', 'T1', 'INTERNACIONAL', 450, 1, 1);
INSERT INTO puertas_embarque (codigo_aeropuerto, numero_puerta, terminal, tipo_puerta, capacidad_maxima, tiene_pasarela, activo) VALUES
('LAX', '1A', 'T1', 'MIXTA', 300, 1, 1);

-- Tabla 1.8: estaciones_monitoreo_ambiental (se omite id_estacion_ambiental)
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('MAD-R01', 'Estación Norte Madrid', 'Cerca de pista 18L', 40.5100, -3.5700, 'RUIDO', DATE '2019-01-01', DATE '2024-01-15', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('MAD-A01', 'Estación Calidad Aire Madrid', 'Terminal T4', 40.4950, -3.5680, 'AIRE', DATE '2020-01-01', DATE '2024-02-10', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('BCN-R01', 'Estación Ruido Barcelona', 'Zona Sur', 41.2900, 2.0800, 'RUIDO', DATE '2018-01-01', DATE '2024-01-20', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('BOG-M01', 'Estación Multipropósito Bogotá', 'Zona Industrial', 4.7100, -74.1500, 'MULTIPROPOSITO', DATE '2021-01-01', DATE '2024-01-05', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('JFK-R01', 'JFK Noise Station 1', 'Jamaica Bay', 40.6400, -73.7800, 'RUIDO', DATE '2017-01-01', DATE '2024-02-01', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('LAX-A01', 'LAX Air Quality', 'In-N-Out', 33.9400, -118.4100, 'AIRE', DATE '2019-01-01', DATE '2024-01-12', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('LHR-R01', 'Heathrow Noise', 'Terminal 5', 51.4750, -0.4500, 'RUIDO', DATE '2016-01-01', DATE '2024-02-05', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('CDG-A01', 'CDG Air', 'Roissy-en-France', 49.0100, 2.5500, 'AIRE', DATE '2020-01-01', DATE '2024-01-18', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('MEX-M01', 'CDMX Multipropósito', 'Peñón de los Baños', 19.4400, -99.0700, 'MULTIPROPOSITO', DATE '2022-01-01', DATE '2024-02-20', 1);
INSERT INTO estaciones_monitoreo_ambiental (codigo_estacion, nombre_estacion, ubicacion, coordenada_latitud, coordenada_longitud, tipo_estacion, fecha_instalacion, fecha_ultima_calibracion, activa) VALUES
('SYD-R01', 'Sydney Noise', 'Botany Bay', -33.9400, 151.1800, 'RUIDO', DATE '2018-01-01', DATE '2024-01-25', 1);

-- =====================================================
-- MÓDULO 2: FLOTA AÉREA
-- =====================================================

-- Tabla 2.1: modelos_aviones (se omite id_modelo)
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Boeing 737-800', 'Boeing', 189, 21000, 5436, 842, 39.5, 35.8, 12.5, 6, 2015, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Airbus A320-200', 'Airbus', 180, 16600, 6100, 828, 37.6, 34.1, 11.8, 6, 2016, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Boeing 787-9', 'Boeing', 290, 55000, 14140, 903, 62.8, 60.1, 17.0, 8, 2018, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Airbus A350-900', 'Airbus', 325, 53000, 15000, 903, 66.8, 64.8, 17.1, 8, 2019, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Boeing 777-300ER', 'Boeing', 386, 65000, 14685, 905, 73.9, 64.8, 18.5, 10, 2017, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Airbus A380-800', 'Airbus', 517, 67000, 15200, 903, 72.7, 79.8, 24.1, 12, 2014, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Embraer E195-E2', 'Embraer', 146, 15000, 4815, 850, 41.5, 35.1, 10.9, 5, 2020, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Bombardier CRJ900', 'Bombardier', 90, 8000, 2800, 830, 36.2, 24.9, 7.5, 4, 2018, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('ATR 72-600', 'ATR', 78, 7500, 1528, 510, 27.2, 27.1, 7.7, 4, 2019, 1);
INSERT INTO modelos_aviones (nombre_modelo, fabricante, capacidad_pasajeros, capacidad_carga_kg, autonomia_km, velocidad_crucero_kmh, longitud_metros, envergadura_metros, altura_metros, tripulacion_minima, anio_fabricacion, activo) VALUES
('Airbus A330-300', 'Airbus', 300, 45000, 11750, 880, 63.7, 60.3, 16.8, 8, 2016, 1);

-- Tabla 2.2: fabricantes_aviones (se omite id_fabricante)
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('Boeing', 'Estados Unidos', 1916, 'Chicago, Illinois', 'www.boeing.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('Airbus', 'Francia', 1970, 'Toulouse, Francia', 'www.airbus.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('Embraer', 'Brasil', 1969, 'São José dos Campos, Brasil', 'www.embraer.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('Bombardier', 'Canadá', 1942, 'Montreal, Québec', 'www.bombardier.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('ATR', 'Francia/Italia', 1981, 'Toulouse, Francia', 'www.atr-aircraft.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('Lockheed Martin', 'Estados Unidos', 1995, 'Bethesda, Maryland', 'www.lockheedmartin.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('Gulfstream Aerospace', 'Estados Unidos', 1958, 'Savannah, Georgia', 'www.gulfstream.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('Cessna', 'Estados Unidos', 1927, 'Wichita, Kansas', 'www.cessna.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('Mitsubishi Heavy Industries', 'Japón', 1884, 'Tokio, Japón', 'www.mhi.com', 1);
INSERT INTO fabricantes_aviones (nombre_fabricante, pais_origen, anio_fundacion, sede_principal, website, activo) VALUES
('COMAC', 'China', 2008, 'Shanghái, China', 'www.comac.cc', 1);

-- Tabla 2.3: motores_aviones (se omite id_motor)
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('CFM56-7B', 'CFM International', 'TURBOFAN', 27300, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('IAE V2500', 'Pratt & Whitney', 'TURBOFAN', 25000, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('Rolls-Royce Trent 1000', 'Rolls-Royce', 'TURBOFAN', 75000, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('GE9X', 'General Electric', 'TURBOFAN', 105000, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('Pratt & Whitney PW1000G', 'Pratt & Whitney', 'TURBOFAN', 33000, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('Rolls-Royce Trent 900', 'Rolls-Royce', 'TURBOFAN', 80000, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('PW127M', 'Pratt & Whitney Canada', 'TURBOPROP', 2750, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('GE CF34-8C5', 'General Electric', 'TURBOFAN', 14500, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('Honeywell TPE331', 'Honeywell', 'TURBOPROP', 1650, 1);
INSERT INTO motores_aviones (nombre_motor, fabricante_motor, tipo_motor, empuje_libras, activo) VALUES
('CFM International LEAP-1A', 'CFM International', 'TURBOFAN', 35000, 1);

-- Tabla 2.4: historial_aviones (con matrículas) (se omite id_historial)
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('EC-MAD', 1, DATE '2024-01-15', 'Entrada en flota', 'Aeronave nueva incorporada a flota', 0, 0);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('EC-BCN', 2, DATE '2023-11-10', 'Inspección mayor', 'Revisión A completada', 3500, 1200);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('N787BA', 3, DATE '2024-02-01', 'Cambio de motor', 'Motor izquierdo reemplazado', 12000, 2500);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('F-AIRB', 4, DATE '2023-12-05', 'Pintura', 'Nuevo esquema de pintura', 8500, 1700);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('N777UA', 5, DATE '2024-01-20', 'Mantenimiento programado', 'Revisión de 24 meses', 45000, 6800);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('A6-EDA', 6, DATE '2023-10-30', 'Incidente técnico', 'Falla menor en sistema hidráulico', 22000, 3100);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('PR-EMB', 7, DATE '2024-02-10', 'Actualización aviónica', 'Software actualizado', 1800, 900);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('C-FRJX', 8, DATE '2023-09-15', 'Cambio de neumáticos', 'Tren de aterrizaje', 9800, 4500);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('F-ORLY', 9, DATE '2024-01-05', 'Reparación', 'Reparación de ala', 5600, 3200);
INSERT INTO historial_aviones (matricula_avion, id_modelo, fecha_registro, evento, descripcion, horas_vuelo, ciclos_vuelo) VALUES
('CS-TMT', 10, DATE '2023-12-18', 'Entrada en flota', 'Aeronave de leasing', 150, 30);

-- Tabla 2.5: mantenimiento_aviones (se omite id_mantenimiento)
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('EC-MAD', 1, DATE '2024-02-15', 'PREVENTIVO', 'Revisión de 100 horas', 100, DATE '2024-03-15', 2500.00, 'Iberia Mantenimiento', 'Carlos Sánchez');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('EC-BCN', 2, DATE '2024-01-20', 'CORRECTIVO', 'Reemplazo de asiento 12A', 3650, DATE '2024-04-20', 850.00, 'Vueling Talleres', 'Laura Gómez');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('N787BA', 3, DATE '2024-02-01', 'PREDICTIVO', 'Análisis de vibración motores', 12100, DATE '2024-05-01', 4500.00, 'Boeing Services', 'Mike Johnson');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('F-AIRB', 4, DATE '2023-12-10', 'PREVENTIVO', 'Revisión A', 8600, DATE '2024-03-10', 3800.00, 'Air France Industries', 'Jean Dupont');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('N777UA', 5, DATE '2024-01-25', 'MAYOR', 'Overhaul motor derecho', 45200, DATE '2025-01-25', 1250000.00, 'United Maintenance', 'Robert Chen');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('A6-EDA', 6, DATE '2023-11-05', 'CORRECTIVO', 'Reparación sistema hidráulico', 22100, DATE '2024-02-05', 23400.00, 'Emirates Engineering', 'Ahmed Hassan');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('PR-EMB', 7, DATE '2024-02-12', 'PREVENTIVO', 'Revisión de 500 horas', 1850, DATE '2024-04-12', 1800.00, 'Azul Tec', 'Pedro Santos');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('C-FRJX', 8, DATE '2023-09-20', 'PREDICTIVO', 'Análisis de aceite', 9900, DATE '2023-12-20', 950.00, 'Air Canada Tech', 'Sarah Wilson');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('F-ORLY', 9, DATE '2024-01-10', 'CORRECTIVO', 'Reparación parabrisas', 5700, DATE '2024-04-10', 3200.00, 'Hop! Maintenance', 'Philippe Martin');
INSERT INTO mantenimiento_aviones (matricula_avion, id_modelo, fecha_mantenimiento, tipo_mantenimiento, descripcion, horas_vuelo_actuales, proximo_mantenimiento, costo, taller, tecnico_responsable) VALUES
('CS-TMT', 10, DATE '2023-12-22', 'PREVENTIVO', 'Revisión inicial', 200, DATE '2024-03-22', 2200.00, 'TAP Manutenção', 'João Ferreira');

-- =====================================================
-- MÓDULO 3: AEROLÍNEAS Y OPERACIONES
-- =====================================================

-- Tabla 3.1: aerolineas (10 principales) (se omite id_aerolinea)
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('Iberia', 'IB', 'IBE', 'España', 1927, 85, 140, 'ONEWORLD', 'www.iberia.com', '+34901211111', 'atencioncliente@iberia.es', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('Avianca', 'AV', 'AVA', 'Colombia', 1919, 70, 110, 'STAR_ALLIANCE', 'www.avianca.com', '+5714013434', 'servicioalcliente@avianca.com', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('American Airlines', 'AA', 'AAL', 'Estados Unidos', 1930, 950, 350, 'ONEWORLD', 'www.aa.com', '+18004337300', 'customer.service@aa.com', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('Delta Air Lines', 'DL', 'DAL', 'Estados Unidos', 1925, 900, 325, 'SKYTEAM', 'www.delta.com', '+18002211212', 'customer.care@delta.com', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('United Airlines', 'UA', 'UAL', 'Estados Unidos', 1926, 850, 340, 'STAR_ALLIANCE', 'www.united.com', '+18008648331', 'customer.relations@united.com', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('Air France', 'AF', 'AFR', 'Francia', 1933, 220, 200, 'SKYTEAM', 'www.airfrance.com', '+33139545000', 'service.client@airfrance.fr', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('British Airways', 'BA', 'BAW', 'Reino Unido', 1974, 250, 180, 'ONEWORLD', 'www.britishairways.com', '+443442938787', 'customer.relations@ba.com', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('LATAM Airlines', 'LA', 'LAN', 'Chile', 2012, 140, 140, 'NINGUNA', 'www.latam.com', '+56225698700', 'servicioalcliente@latam.com', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('Emirates', 'EK', 'UAE', 'Emiratos Árabes', 1985, 260, 160, 'NINGUNA', 'www.emirates.com', '+97146003333', 'customer.support@emirates.com', 1);
INSERT INTO aerolineas (nombre_aerolinea, codigo_iata, codigo_oaci, pais_origen, anio_fundacion, flota_total, destinos_totales, alianza, website, telefono_contacto, email_contacto, activo) VALUES
('Qatar Airways', 'QR', 'QTR', 'Catar', 1993, 200, 170, 'ONEWORLD', 'www.qatarairways.com', '+97440232023', 'customer.support@qatarairways.com.qa', 1);

-- Tabla 3.2: tipos_aerolinea (se omite id_tipo_aerolinea)
INSERT INTO tipos_aerolinea (descripcion, activo) VALUES ('COMERCIAL', 1);
INSERT INTO tipos_aerolinea (descripcion, activo) VALUES ('CARGA', 1);
INSERT INTO tipos_aerolinea (descripcion, activo) VALUES ('CHARTER', 1);
INSERT INTO tipos_aerolinea (descripcion, activo) VALUES ('EJECUTIVA', 1);
INSERT INTO tipos_aerolinea (descripcion, activo) VALUES ('LOW_COST', 1);

-- Tabla 3.3: aerolineas_tipos (relaciones) (clave compuesta, no autoincremental)
INSERT INTO aerolineas_tipos (id_aerolinea, id_tipo_aerolinea) VALUES (1, 1);
INSERT INTO aerolineas_tipos (id_aerolinea, id_tipo_aerolinea) VALUES (2, 1);
INSERT INTO aerolineas_tipos (id_aerolinea, id_tipo_aerolinea) VALUES (3, 1);
INSERT INTO aerolineas_tipos (id_aerolinea, id_tipo_aerolinea) VALUES (4, 1);
INSERT INTO aerolineas_tipos (id_aerolinea, id_tipo_aerolinea) VALUES (5, 1);

-- Tabla 3.4: aerolineas_certificaciones (se omite id_certificacion)
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(1, 'IOSA', 'IATA', DATE '2023-01-15', DATE '2025-01-15', 'IOSA-IB-2023-001', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(2, 'IOSA', 'IATA', DATE '2023-02-10', DATE '2025-02-10', 'IOSA-AV-2023-002', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(3, 'FAA 121', 'FAA', DATE '2023-03-05', DATE '2024-03-05', 'FAA-AA-121-2023', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(4, 'FAA 121', 'FAA', DATE '2023-04-20', DATE '2024-04-20', 'FAA-DL-121-2023', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(5, 'FAA 121', 'FAA', DATE '2023-05-12', DATE '2024-05-12', 'FAA-UA-121-2023', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(6, 'EASA Part 145', 'EASA', DATE '2023-06-18', DATE '2025-06-18', 'EASA-AF-145-2023', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(7, 'EASA Part 145', 'EASA', DATE '2023-07-22', DATE '2025-07-22', 'EASA-BA-145-2023', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(8, 'IOSA', 'IATA', DATE '2023-08-30', DATE '2025-08-30', 'IOSA-LA-2023-008', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(9, 'GCAA', 'GCAA', DATE '2023-09-14', DATE '2024-09-14', 'GCAA-EK-2023-009', 1);
INSERT INTO aerolineas_certificaciones (id_aerolinea, tipo_certificacion, entidad_emisora, fecha_emision, fecha_expiracion, numero_certificado, activo) VALUES
(10, 'QCAA', 'QCAA', DATE '2023-10-01', DATE '2024-10-01', 'QCAA-QR-2023-010', 1);

-- Tabla 3.5: alianzas_aerolineas (se omite id_alianza)
INSERT INTO alianzas_aerolineas (nombre_alianza, fecha_fundacion, sede, numero_miembros, descripcion) VALUES
('STAR_ALLIANCE', DATE '1997-05-14', 'Fráncfort, Alemania', 26, 'La primera y más grande alianza global de aerolíneas');
INSERT INTO alianzas_aerolineas (nombre_alianza, fecha_fundacion, sede, numero_miembros, descripcion) VALUES
('SKYTEAM', DATE '2000-06-22', 'Ámsterdam, Países Bajos', 19, 'Alianza global de aerolíneas con enfoque en conectividad');
INSERT INTO alianzas_aerolineas (nombre_alianza, fecha_fundacion, sede, numero_miembros, descripcion) VALUES
('ONEWORLD', DATE '1999-02-01', 'Nueva York, Estados Unidos', 14, 'Alianza de aerolíneas de calidad y servicio premium');

-- Tabla 3.6: alianzas_miembros (clave compuesta, no autoincremental)
INSERT INTO alianzas_miembros (id_alianza, id_aerolinea, fecha_ingreso, estado_miembro) VALUES (3, 1, DATE '1999-02-01', 'ACTIVO');
INSERT INTO alianzas_miembros (id_alianza, id_aerolinea, fecha_ingreso, estado_miembro) VALUES (1, 2, DATE '2013-06-21', 'ACTIVO');
INSERT INTO alianzas_miembros (id_alianza, id_aerolinea, fecha_ingreso, estado_miembro) VALUES (3, 3, DATE '1999-02-01', 'ACTIVO');
INSERT INTO alianzas_miembros (id_alianza, id_aerolinea, fecha_ingreso, estado_miembro) VALUES (2, 4, DATE '2000-06-22', 'ACTIVO');
INSERT INTO alianzas_miembros (id_alianza, id_aerolinea, fecha_ingreso, estado_miembro) VALUES (1, 5, DATE '1997-05-14', 'ACTIVO');
INSERT INTO alianzas_miembros (id_alianza, id_aerolinea, fecha_ingreso, estado_miembro) VALUES (2, 6, DATE '2000-06-22', 'ACTIVO');
INSERT INTO alianzas_miembros (id_alianza, id_aerolinea, fecha_ingreso, estado_miembro) VALUES (3, 7, DATE '1999-02-01', 'ACTIVO');

-- Tabla 3.7: franquicias_equipaje (se omite id_franquicia)
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(1, 'ECONOMICA', 23, 1, '158cm (suma)', 50, 'EUR');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(1, 'EJECUTIVA', 32, 2, '158cm (suma)', 0, 'EUR');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(2, 'ECONOMICA', 23, 1, '158cm (suma)', 450000, 'COP');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(3, 'ECONOMICA', 23, 1, '158cm (suma)', 100, 'USD');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(3, 'PRIMERA_CLASE', 32, 3, '158cm (suma)', 0, 'USD');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(4, 'ECONOMICA', 23, 1, '158cm (suma)', 100, 'USD');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(6, 'ECONOMICA', 23, 1, '158cm (suma)', 60, 'EUR');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(7, 'ECONOMICA', 23, 1, '158cm (suma)', 55, 'GBP');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(8, 'ECONOMICA', 23, 1, '158cm (suma)', 80, 'USD');
INSERT INTO franquicias_equipaje (id_aerolinea, clase_servicio, peso_maximo_kg, piezas_permitidas, dimensiones_maximas_cm, exceso_equipaje_costo, moneda) VALUES
(9, 'ECONOMICA', 30, 2, '158cm (suma)', 100, 'USD');

-- =====================================================
-- MÓDULO 4: PROGRAMACIÓN DE VUELOS (7 TABLAS)
-- =====================================================

-- Tabla 4.1: programas_vuelo (se omite id_programa)
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('IB1234', 1, 'MAD', 'BOG', 'INTERNACIONAL', 'L,M,X,J,V,S,D', 7, 600, 8400, 'MIXTA', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('AV123', 2, 'BOG', 'MAD', 'INTERNACIONAL', 'L,M,X,J,V,S,D', 7, 590, 8400, 'MIXTA', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('AA456', 3, 'JFK', 'LAX', 'NACIONAL', 'L,M,X,J,V', 5, 360, 4000, 'ECONOMICA', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('DL789', 4, 'JFK', 'LHR', 'INTERNACIONAL', 'L,M,X,J,V,S,D', 7, 420, 5500, 'EJECUTIVA', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('UA101', 5, 'LAX', 'SYD', 'INTERNACIONAL', 'L,J,V', 3, 900, 12000, 'PRIMERA_CLASE', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('AF345', 6, 'CDG', 'JFK', 'INTERNACIONAL', 'L,M,X,J,V,S,D', 7, 480, 5800, 'MIXTA', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('BA678', 7, 'LHR', 'JFK', 'INTERNACIONAL', 'L,M,X,J,V,S,D', 7, 450, 5500, 'MIXTA', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('LA890', 8, 'GRU', 'JFK', 'INTERNACIONAL', 'L,X,V', 3, 600, 7700, 'ECONOMICA', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('EK212', 9, 'MEX', 'BCN', 'INTERNACIONAL', 'M,J,S', 3, 720, 9100, 'EJECUTIVA', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO programas_vuelo (numero_vuelo, id_aerolinea, aeropuerto_origen, aeropuerto_destino, tipo_vuelo, dias_semana, frecuencia_semanal, duracion_estimada_minutos, distancia_km, clase_servicio, activo, fecha_inicio, fecha_fin) VALUES
('QR456', 10, 'MAD', 'BOG', 'INTERNACIONAL', 'L,M,X,J,V,S,D', 7, 595, 8400, 'PRIMERA_CLASE', 1, DATE '2024-01-01', DATE '2024-12-31');

-- Tabla 4.2: dias_operacion (se omite id_dia)
INSERT INTO dias_operacion (nombre_dia, numero_dia, activo) VALUES ('LUNES', 1, 1);
INSERT INTO dias_operacion (nombre_dia, numero_dia, activo) VALUES ('MARTES', 2, 1);
INSERT INTO dias_operacion (nombre_dia, numero_dia, activo) VALUES ('MIERCOLES', 3, 1);
INSERT INTO dias_operacion (nombre_dia, numero_dia, activo) VALUES ('JUEVES', 4, 1);
INSERT INTO dias_operacion (nombre_dia, numero_dia, activo) VALUES ('VIERNES', 5, 1);
INSERT INTO dias_operacion (nombre_dia, numero_dia, activo) VALUES ('SABADO', 6, 1);
INSERT INTO dias_operacion (nombre_dia, numero_dia, activo) VALUES ('DOMINGO', 7, 1);

-- Tabla 4.3: programa_dias (horarios específicos por día) (clave compuesta, no autoincremental)
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(1, 1, TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(2, 2, TO_TIMESTAMP('2024-03-19 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 18:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(3, 3, TO_TIMESTAMP('2024-03-20 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 18:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(4, 4, TO_TIMESTAMP('2024-03-21 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-21 18:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(5, 5, TO_TIMESTAMP('2024-03-22 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-22 18:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(6, 6, TO_TIMESTAMP('2024-03-23 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-23 18:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(7, 7, TO_TIMESTAMP('2024-03-24 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-24 18:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(8, 1, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(9, 2, TO_TIMESTAMP('2024-03-19 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO programa_dias (id_programa, id_dia, hora_salida_programada, hora_llegada_programada) VALUES
(10, 3, TO_TIMESTAMP('2024-03-20 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 11:00:00', 'YYYY-MM-DD HH24:MI:SS'));

-- (Aeropuertos adicionales insertados aquí por completitud, pero se asume que ya se ejecutaron en la creación)
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('MDE', 'Aeropuerto Internacional José María Córdova', 'Medellín', 'Colombia', 'Antioquia', 'América', 'UTC-5', 6.1645, -75.4231, 2140, 1, 25, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('EWR', 'Newark Liberty International Airport', 'Newark', 'Estados Unidos', 'Nueva Jersey', 'América', 'UTC-5', 40.6895, -74.1745, 5, 3, 45, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('BOS', 'Boston Logan International Airport', 'Boston', 'Estados Unidos', 'Massachusetts', 'América', 'UTC-5', 42.3656, -71.0096, 6, 4, 40, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('SFO', 'San Francisco International Airport', 'San Francisco', 'Estados Unidos', 'California', 'América', 'UTC-8', 37.6213, -122.3790, 4, 4, 60, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('ORY', 'Paris Orly Airport', 'París', 'Francia', 'Île-de-France', 'Europa', 'UTC+1', 48.7262, 2.3655, 89, 3, 35, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('LGW', 'London Gatwick Airport', 'Londres', 'Reino Unido', 'Inglaterra', 'Europa', 'UTC+0', 51.1537, -0.1821, 62, 2, 50, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('GIG', 'Aeroporto Internacional do Galeão', 'Río de Janeiro', 'Brasil', 'Río de Janeiro', 'América', 'UTC-3', -22.8090, -43.2481, 9, 2, 32, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('GDL', 'Aeropuerto Internacional de Guadalajara', 'Guadalajara', 'México', 'Jalisco', 'América', 'UTC-6', 20.5218, -103.3100, 1524, 2, 30, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('AGP', 'Aeropuerto de Málaga-Costa del Sol', 'Málaga', 'España', 'Andalucía', 'Europa', 'UTC+1', 36.6749, -4.4991, 16, 1, 25, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('ORD', 'Chicago O''Hare International Airport', 'Chicago', 'Estados Unidos', 'Illinois', 'América', 'UTC-6', 41.9742, -87.9073, 204, 4, 182, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('HNL', 'Daniel K. Inouye International Airport', 'Honolulu', 'Estados Unidos', 'Hawái', 'América', 'UTC-10', 21.3187, -157.9224, 4, 3, 40, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('YYZ', 'Toronto Pearson International Airport', 'Toronto', 'Canadá', 'Ontario', 'América', 'UTC-5', 43.6777, -79.6248, 173, 2, 100, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('PTY', 'Aeropuerto Internacional de Tocumen', 'Ciudad de Panamá', 'Panamá', 'Panamá', 'América', 'UTC-5', 9.0714, -79.3835, 41, 2, 45, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('UIO', 'Aeropuerto Internacional Mariscal Sucre', 'Quito', 'Ecuador', 'Pichincha', 'América', 'UTC-5', -0.1298, -78.3575, 2400, 1, 20, 1, 'SISTEMA');
INSERT INTO aeropuertos (codigo_aeropuerto, nombre, ciudad, pais, region, continente, huso_horario, latitud, longitud, elevacion_metros, terminales, puertas_abordaje, activo, usuario_registro) VALUES ('CCS', 'Aeropuerto Internacional Simón Bolívar', 'Caracas', 'Venezuela', 'Miranda', 'América', 'UTC-4', 10.6012, -66.9911, 71, 1, 25, 1, 'SISTEMA');

-- Tabla 4.4: rutas_alternativas (se omite id_ruta_alternativa)
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(1, 'MAD', 'BCN', 'Desvío por clima en BOG', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(2, 'BOG', 'MDE', 'Desvío por mantenimiento MAD', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(3, 'JFK', 'EWR', 'Alternativa por congestión', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(4, 'JFK', 'BOS', 'Desvío Londres cerrado', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(5, 'LAX', 'SFO', 'Alternativa técnica', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(6, 'CDG', 'ORY', 'Desvío por huelga', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(7, 'LHR', 'LGW', 'Alternativa por clima', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(8, 'GRU', 'GIG', 'Desvío técnico', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(9, 'MEX', 'GDL', 'Alternativa por seguridad', 1, DATE '2024-01-01', DATE '2024-12-31');
INSERT INTO rutas_alternativas (id_programa, aeropuerto_origen_alt, aeropuerto_destino_alt, motivo, activa, fecha_inicio, fecha_fin) VALUES
(10, 'MAD', 'AGP', 'Desvío por niebla', 1, DATE '2024-01-01', DATE '2024-12-31');

-- Tabla 4.5: temporadas_vuelo (se omite id_temporada)
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Temporada Alta Verano', DATE '2024-06-01', DATE '2024-08-31', 1.5, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Temporada Baja Invierno', DATE '2024-01-07', DATE '2024-03-31', 0.8, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Semana Santa', DATE '2024-03-25', DATE '2024-04-01', 1.3, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Puente de Diciembre', DATE '2024-12-05', DATE '2024-12-10', 1.2, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Navidad', DATE '2024-12-20', DATE '2025-01-06', 1.8, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Temporada Media Otoño', DATE '2024-09-01', DATE '2024-11-30', 1.0, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Acción de Gracias (US)', DATE '2024-11-25', DATE '2024-11-30', 1.6, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Carnaval (Latam)', DATE '2024-02-10', DATE '2024-02-14', 1.4, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Verano Europa', DATE '2024-07-01', DATE '2024-08-15', 1.7, 1);
INSERT INTO temporadas_vuelo (nombre_temporada, fecha_inicio, fecha_fin, factor_demanda, activa) VALUES
('Vacaciones Escolares', DATE '2024-12-15', DATE '2025-01-15', 1.5, 1);

-- Tabla 4.6: programas_temporada (clave compuesta, no autoincremental)
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (1, 1, 2, 20.5);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (1, 2, -1, -15.0);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (2, 1, 2, 22.0);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (3, 7, 1, 30.0);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (4, 5, 2, 35.0);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (5, 1, 0, 25.0);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (6, 9, 3, 18.5);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (7, 5, 2, 28.0);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (8, 8, 1, 15.0);
INSERT INTO programas_temporada (id_programa, id_temporada, ajuste_frecuencia, ajuste_precio) VALUES (9, 10, 2, 12.5);

-- Tabla 4.7: restricciones_vuelo (se omite id_restriccion)
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(1, 'CLIMATICA', 'No operar en tormentas eléctricas en el Caribe', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(2, 'TECNICA', 'Requiere pista mayor a 3500m', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(3, 'SEGURIDAD', 'Restricción por eventos en NYC', DATE '2024-09-01', DATE '2024-09-15', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(4, 'POLITICA', 'Requisitos especiales Brexit', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(5, 'TECNICA', 'Requiere tripulación certificada ETOPS', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(6, 'CLIMATICA', 'No operar con niebla en CDG', DATE '2024-11-01', DATE '2024-12-31', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(7, 'SEGURIDAD', 'Restricciones por altura de pasajeros VIP', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(8, 'TECNICA', 'Requiere tanques adicionales', DATE '2024-01-01', DATE '2024-06-30', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(9, 'CLIMATICA', 'Restricción por huracanes', DATE '2024-06-01', DATE '2024-11-30', 1);
INSERT INTO restricciones_vuelo (id_programa, tipo_restriccion, descripcion, fecha_inicio, fecha_fin, activa) VALUES
(10, 'POLITICA', 'Visado obligatorio para nacionales', DATE '2024-01-01', DATE '2024-12-31', 1);

-- =====================================================
-- MÓDULO 5: OPERACIONES DE VUELO (15 TABLAS)
-- NOTA: Insertamos primero la tabla principal (vuelos)
-- y luego las tablas relacionadas
-- =====================================================

-- Tabla 5.1: vuelos (se omite id_vuelo)
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(1, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:15:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:20:00', 'YYYY-MM-DD HH24:MI:SS'), 3, 'N787BA', 15, 275, 12000, 85000, 'ATERRIZADO', NULL, NULL, 1, 6, 'Retraso menor por tráfico aéreo');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(2, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 16:25:00', 'YYYY-MM-DD HH24:MI:SS'), 2, 'EC-BCN', 5, 175, 8000, 60000, 'ATERRIZADO', NULL, NULL, 6, 2, 'Vuelo sin novedad');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(3, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:05:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 'EC-MAD', 0, 180, 5000, 30000, 'ATERRIZADO', NULL, NULL, 8, 10, 'Vuelo completo');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(4, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 22:30:00', 'YYYY-MM-DD HH24:MI:SS'), 4, 'F-AIRB', 20, 305, 15000, 95000, 'ATERRIZADO', NULL, NULL, 9, 7, 'Retraso por catering');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(5, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 11:10:00', 'YYYY-MM-DD HH24:MI:SS'), 5, 'N777UA', 10, 376, 20000, 145000, 'ATERRIZADO', NULL, NULL, 10, NULL, 'Vuelo nocturno sin incidencias');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(6, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:20:00', 'YYYY-MM-DD HH24:MI:SS'), 3, 'N787BA', 25, 265, 11000, 82000, 'ATERRIZADO', NULL, NULL, 5, 8, 'Retraso por asignación de puerta');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(7, DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 20:30:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, NULL, 4, 'F-AIRB', 0, 0, 0, 0, 'CANCELADO', 'Huelga de controladores', DATE '2024-03-20', NULL, NULL, 'Pasajeros reubicados');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(8, DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, NULL, 2, 'EC-BCN', 0, 0, 0, 0, 'DEMORADO', NULL, DATE '2024-03-20', 4, NULL, 'Demora técnica, reprogramado');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(9, DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 11:05:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 20:15:00', 'YYYY-MM-DD HH24:MI:SS'), 5, 'N777UA', 30, 356, 18000, 138000, 'EN_VUELO', NULL, NULL, 2, 5, 'Sin novedad');
INSERT INTO vuelos (id_programa, fecha_vuelo, hora_salida_programada, hora_llegada_programada, hora_salida_real, hora_llegada_real, id_modelo_avion, matricula_avion, plazas_vacias, plazas_ocupadas, carga_kg, combustible_litros, estado_vuelo, motivo_cancelacion, fecha_reprogramado, id_puerta_salida, id_puerta_llegada, observaciones_operativas) VALUES
(10, DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 20:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 20:25:00', 'YYYY-MM-DD HH24:MI:SS'), 3, 'N787BA', 10, 280, 14000, 86000, 'ATERRIZADO', NULL, NULL, 1, 6, 'Vuelo sin novedad');

-- Tabla 5.2: condiciones_meteorologicas (se omite id_condicion)
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('MAD', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 18, 45, 1015, 10, 'NE', 10, 'Despejado', NULL);
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('BOG', TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 14, 80, 1020, 5, 'SE', 8, 'Nublado', 'Lluvia ligera');
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('JFK', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 5, 60, 1025, 15, 'NW', 12, 'Despejado', NULL);
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('LAX', TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 22, 30, 1012, 8, 'SW', 15, 'Despejado', NULL);
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('LHR', TO_TIMESTAMP('2024-03-18 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), 8, 75, 1010, 12, 'W', 5, 'Nublado', 'Niebla');
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('CDG', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 10, 70, 1018, 10, 'N', 8, 'Nublado', NULL);
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('MEX', TO_TIMESTAMP('2024-03-20 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 22, 40, 1022, 5, 'SE', 14, 'Despejado', NULL);
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('GRU', TO_TIMESTAMP('2024-03-19 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), 20, 85, 1011, 7, 'E', 6, 'Lluvioso', 'Tormenta eléctrica');
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('SYD', TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 25, 65, 1013, 15, 'S', 12, 'Parcialmente nublado', NULL);
INSERT INTO condiciones_meteorologicas (codigo_aeropuerto, fecha_hora, temperatura, humedad, presion_atmosferica, viento_velocidad, viento_direccion, visibilidad_km, condicion_general, fenomenos_especiales) VALUES
('BCN', TO_TIMESTAMP('2024-03-20 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 20, 50, 1016, 8, 'S', 15, 'Despejado', NULL);

-- Tabla 5.3: alertas_meteorologicas (se omite id_alerta)
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('GRU', 'TORMENTA', 'ALTO', 'Tormenta eléctrica con relámpagos', TO_TIMESTAMP('2024-03-19 04:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('LHR', 'NIEBLA', 'MEDIO', 'Niebla densa, visibilidad reducida', TO_TIMESTAMP('2024-03-18 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 02:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('JFK', 'VIENTO', 'BAJO', 'Vientos fuertes del noroeste', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 0);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('BOG', 'LLUVIA', 'MEDIO', 'Lluvias moderadas persistentes', TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), 0);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('MEX', 'CALOR', 'BAJO', 'Temperaturas superiores a 30°C', TO_TIMESTAMP('2024-03-20 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 0);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('LAX', 'INCENDIO', 'ALTO', 'Humo de incendios forestales', TO_TIMESTAMP('2024-03-19 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('SYD', 'OLEAJE', 'MEDIO', 'Condiciones de viento adversas', TO_TIMESTAMP('2024-03-19 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), 0);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('CDG', 'NIEVE', 'ALTO', 'Nevadas inesperadas', TO_TIMESTAMP('2024-03-22 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-23 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('MAD', 'VIENTO', 'MEDIO', 'Rachas de viento fuertes', TO_TIMESTAMP('2024-03-21 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-21 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 0);
INSERT INTO alertas_meteorologicas (codigo_aeropuerto, tipo_alerta, nivel_alerta, descripcion, fecha_inicio, fecha_fin, afecta_operaciones) VALUES
('BCN', 'LLUVIA', 'MEDIO', 'Lluvias intensas', TO_TIMESTAMP('2024-03-22 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-22 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 0);

-- Tabla 5.4: escalas_tecnicas (se omite id_escala)
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(1, 'BCN', 1, TO_TIMESTAMP('2024-03-18 13:45:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 14:45:00', 'YYYY-MM-DD HH24:MI:SS'), 60, 'COMBUSTIBLE', 'Repostaje técnico');
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(2, 'MAD', 1, TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 13:15:00', 'YYYY-MM-DD HH24:MI:SS'), 45, 'TECNICA', 'Cambio de tripulación');
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(3, 'ORD', 1, TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:15:00', 'YYYY-MM-DD HH24:MI:SS'), 45, 'COMBUSTIBLE', NULL);
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(4, 'BOS', 1, TO_TIMESTAMP('2024-03-18 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 19:30:00', 'YYYY-MM-DD HH24:MI:SS'), 60, 'CLIMATICA', 'Esperar mejora clima');
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(5, 'HNL', 1, TO_TIMESTAMP('2024-03-19 02:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 03:30:00', 'YYYY-MM-DD HH24:MI:SS'), 90, 'COMBUSTIBLE', 'Repostaje y descanso tripulación');
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(6, 'YYZ', 1, TO_TIMESTAMP('2024-03-18 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:15:00', 'YYYY-MM-DD HH24:MI:SS'), 45, 'TECNICA', 'Revisión menor');
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(9, 'PTY', 1, TO_TIMESTAMP('2024-03-20 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 60, 'COMBUSTIBLE', NULL);
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(9, 'UIO', 2, TO_TIMESTAMP('2024-03-20 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 18:45:00', 'YYYY-MM-DD HH24:MI:SS'), 45, 'TECNICA', 'Cambio tripulación');
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(10, 'CCS', 1, TO_TIMESTAMP('2024-03-20 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 17:15:00', 'YYYY-MM-DD HH24:MI:SS'), 45, 'COMBUSTIBLE', NULL);
INSERT INTO escalas_tecnicas (id_vuelo, aeropuerto_escala, numero_orden, hora_llegada, hora_despegue, tiempo_escala_minutos, motivo_escala, observaciones) VALUES
(10, 'BOG', 2, TO_TIMESTAMP('2024-03-20 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 19:15:00', 'YYYY-MM-DD HH24:MI:SS'), 45, 'TECNICA', NULL);

-- Tabla 5.5: escalas_servicios (se omite id_servicio_escala)
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(1, 'COMBUSTIBLE', 'Repsol', 45000, 'EUR', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(2, 'MANTENIMIENTO', 'Iberia Mantenimiento', 2500, 'EUR', TO_TIMESTAMP('2024-03-18 12:45:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(2, 'CATERING', 'Gate Gourmet', 1800, 'EUR', TO_TIMESTAMP('2024-03-18 12:50:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(3, 'COMBUSTIBLE', 'Shell Aviation', 32000, 'USD', TO_TIMESTAMP('2024-03-18 09:45:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(4, 'LIMPIEZA', 'ABM Aviation', 950, 'USD', TO_TIMESTAMP('2024-03-18 18:45:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(5, 'COMBUSTIBLE', 'Pacific Fuel', 78000, 'USD', TO_TIMESTAMP('2024-03-19 02:30:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(5, 'TRIPULACION', 'United Crew Services', 3500, 'USD', TO_TIMESTAMP('2024-03-19 03:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(6, 'MANTENIMIENTO', 'Air Canada Tech', 1800, 'CAD', TO_TIMESTAMP('2024-03-18 10:45:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(7, 'COMBUSTIBLE', 'Copa Fuel', 52000, 'USD', TO_TIMESTAMP('2024-03-20 16:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO escalas_servicios (id_escala, tipo_servicio, proveedor, costo, moneda, fecha_servicio) VALUES
(9, 'COMBUSTIBLE', 'PDVSA Aviation', 48000, 'USD', TO_TIMESTAMP('2024-03-20 16:45:00', 'YYYY-MM-DD HH24:MI:SS'));

-- Tabla 5.6: incidentes_vuelo (se omite id_incidente_vuelo)
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(1, TO_TIMESTAMP('2024-03-18 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'MEDICO', 'Pasajero con mareos', 'BAJA', 'Asistencia médica a bordo', 'Tripulación');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(3, TO_TIMESTAMP('2024-03-18 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'TECNICO', 'Falla en sistema de entretenimiento', 'BAJA', 'Reinicio del sistema', 'Piloto');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(4, TO_TIMESTAMP('2024-03-18 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'SEGURIDAD', 'Pasajero alterado', 'MEDIA', 'Amonestación verbal', 'Sobrecargo');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(5, TO_TIMESTAMP('2024-03-19 04:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERATIVO', 'Turbulencia severa', 'MEDIA', 'Aseguramiento de cabina', 'Piloto');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(6, TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'CLIMATICO', 'Rayo cercano', 'BAJA', 'Procedimiento estándar', 'Piloto');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(9, TO_TIMESTAMP('2024-03-20 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'TECNICO', 'Indicador de presión de cabina', 'ALTA', 'Descenso a altitud segura', 'Piloto');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(9, TO_TIMESTAMP('2024-03-20 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'MEDICO', 'Pasajero con crisis de ansiedad', 'MEDIA', 'Asistencia psicológica', 'Tripulación');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(10, TO_TIMESTAMP('2024-03-20 17:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'SEGURIDAD', 'Bolso sospechoso', 'ALTA', 'Protocolo de seguridad', 'Tripulación');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(10, TO_TIMESTAMP('2024-03-20 19:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERATIVO', 'Retraso por equipaje', 'BAJA', 'Coordinación con tierra', 'Piloto');
INSERT INTO incidentes_vuelo (id_vuelo, fecha_incidente, tipo_incidente, descripcion, gravedad, acciones_tomadas, reportado_por) VALUES
(2, TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'TECNICO', 'Falla en WC', 'BAJA', 'Reparación en destino', 'Tripulación');

-- Tabla 5.7: retrasos_vuelo (se omite id_retraso)
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(1, 15, 'OPERACIONAL', 'Tráfico aéreo', 'Control aéreo', 0);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(1, 5, 'OPERACIONAL', 'Llegada de pasajeros con conexión', 'Aerolínea', 0);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(4, 30, 'OPERACIONAL', 'Retraso en catering', 'Proveedor', 1);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(5, 10, 'OPERACIONAL', 'Espera de autorización', 'Control aéreo', 0);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(6, 15, 'OPERACIONAL', 'Asignación de puerta', 'Aeropuerto', 0);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(7, 0, 'OPERACIONAL', 'Huelga', 'Controladores', 1);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(8, 180, 'TECNICO', 'Falla mecánica', 'Aerolínea', 1);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(9, 5, 'OPERACIONAL', 'Limpieza adicional', 'Aerolínea', 0);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(9, 10, 'CLIMATICO', 'Tormenta en ruta', 'Clima', 0);
INSERT INTO retrasos_vuelo (id_vuelo, minutos_retraso, tipo_retraso, causa, responsable, compensacion_pasajeros) VALUES
(10, 0, 'OPERACIONAL', 'Puntual', NULL, 0);

-- Tabla 5.8: cancelaciones_vuelo (se omite id_cancelacion)
INSERT INTO cancelaciones_vuelo (id_vuelo, fecha_cancelacion, motivo_principal, motivo_detallado, notificado_a_pasajeros, fecha_notificacion, pasajeros_reubicados, costo_compensacion) VALUES
(7, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Huelga de controladores aéreos', 'Paro nacional indefinido del personal de control', 1, TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 250, 45000.00);
INSERT INTO cancelaciones_vuelo (id_vuelo, fecha_cancelacion, motivo_principal, motivo_detallado, notificado_a_pasajeros, fecha_notificacion, pasajeros_reubicados, costo_compensacion) VALUES
(8, TO_TIMESTAMP('2024-03-19 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Falla técnica', 'Problema en motor derecho detectado en revisión', 1, TO_TIMESTAMP('2024-03-19 19:00:00', 'YYYY-MM-DD HH24:MI:SS'), 180, 32000.00);

-- Tabla 5.9: desvios_vuelo (se omite id_desvio)
INSERT INTO desvios_vuelo (id_vuelo, aeropuerto_desvio, fecha_desvio, motivo, duracion_desvio_minutos, acciones_tomadas) VALUES
(4, 'BOS', TO_TIMESTAMP('2024-03-18 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Tormenta en JFK', 60, 'Esperar mejora condiciones');
INSERT INTO desvios_vuelo (id_vuelo, aeropuerto_desvio, fecha_desvio, motivo, duracion_desvio_minutos, acciones_tomadas) VALUES
(6, 'YYZ', TO_TIMESTAMP('2024-03-18 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Revisión técnica no programada', 45, 'Inspección de mantenimiento');
INSERT INTO desvios_vuelo (id_vuelo, aeropuerto_desvio, fecha_desvio, motivo, duracion_desvio_minutos, acciones_tomadas) VALUES
(9, 'PTY', TO_TIMESTAMP('2024-03-20 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Repostaje por vientos', 60, 'Repostar combustible');

-- Tabla 5.10: combustible_vuelo (se omite id_combustible)
INSERT INTO combustible_vuelo (id_vuelo, combustible_planeado_litros, combustible_real_litros, combustible_extra_litros, tipo_combustible, proveedor, costo_total, fecha_carga) VALUES
(1, 84000, 85000, 1000, 'JET_A1', 'Repsol', 76500, TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO combustible_vuelo (id_vuelo, combustible_planeado_litros, combustible_real_litros, combustible_extra_litros, tipo_combustible, proveedor, costo_total, fecha_carga) VALUES
(2, 59000, 60000, 1000, 'JET_A1', 'Terpel', 54000, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO combustible_vuelo (id_vuelo, combustible_planeado_litros, combustible_real_litros, combustible_extra_litros, tipo_combustible, proveedor, costo_total, fecha_carga) VALUES
(3, 29500, 30000, 500, 'JET_A', 'Shell', 33000, TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO combustible_vuelo (id_vuelo, combustible_planeado_litros, combustible_real_litros, combustible_extra_litros, tipo_combustible, proveedor, costo_total, fecha_carga) VALUES
(4, 94000, 95000, 1000, 'JET_A1', 'BP', 104500, TO_TIMESTAMP('2024-03-18 13:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO combustible_vuelo (id_vuelo, combustible_planeado_litros, combustible_real_litros, combustible_extra_litros, tipo_combustible, proveedor, costo_total, fecha_carga) VALUES
(5, 143000, 145000, 2000, 'JET_A1', 'Chevron', 188500, TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO combustible_vuelo (id_vuelo, combustible_planeado_litros, combustible_real_litros, combustible_extra_litros, tipo_combustible, proveedor, costo_total, fecha_carga) VALUES
(6, 81500, 82000, 500, 'JET_A1', 'Total', 73800, TO_TIMESTAMP('2024-03-18 07:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO combustible_vuelo (id_vuelo, combustible_planeado_litros, combustible_real_litros, combustible_extra_litros, tipo_combustible, proveedor, costo_total, fecha_carga) VALUES
(9, 136000, 138000, 2000, 'JET_A1', 'Pemex', 151800, TO_TIMESTAMP('2024-03-20 09:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO combustible_vuelo (id_vuelo, combustible_planeado_litros, combustible_real_litros, combustible_extra_litros, tipo_combustible, proveedor, costo_total, fecha_carga) VALUES
(10, 85500, 86000, 500, 'JET_A1', 'Repsol', 77400, TO_TIMESTAMP('2024-03-20 12:00:00', 'YYYY-MM-DD HH24:MI:SS'));

-- Tabla 5.11: rutas_vuelo (se omite id_ruta)
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(1, 1, 40.4936, -3.5668, 0, 0, 0);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(1, 2, 41.2974, 2.0833, 35000, 900, 90);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(1, 3, 28.4556, -13.8636, 37000, 910, 210);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(1, 4, 18.1136, -67.0397, 38000, 910, 360);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(1, 5, 4.7019, -74.1469, 0, 0, 540);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(3, 1, 40.6413, -73.7781, 0, 0, 0);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(3, 2, 39.8561, -84.0167, 36000, 850, 120);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(3, 3, 36.0840, -94.1711, 37000, 850, 210);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(3, 4, 34.0522, -118.2437, 0, 0, 330);
INSERT INTO rutas_vuelo (id_vuelo, secuencia_punto, coordenada_lat, coordenada_lon, altitud_pies, velocidad_esperada_kmh, tiempo_estimado_minutos) VALUES
(5, 1, 33.9416, -118.4085, 0, 0, 0);

-- Tabla 5.12: comunicaciones_vuelo (se omite id_comunicacion)
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(1, TO_TIMESTAMP('2024-03-18 11:55:00', 'YYYY-MM-DD HH24:MI:SS'), 'AUTORIZACION', 'IB1234', 'MAD Torre', 'Solicitando autorización de pushback', 'Carlos Ruiz');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(1, TO_TIMESTAMP('2024-03-18 12:05:00', 'YYYY-MM-DD HH24:MI:SS'), 'AUTORIZACION', 'MAD Torre', 'IB1234', 'Autorizado pushback, pista 18L', 'Laura Gómez');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(1, TO_TIMESTAMP('2024-03-18 12:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'DESPEGUE', 'IB1234', 'MAD Torre', 'Autorización despegue recibida', 'Piloto');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(3, TO_TIMESTAMP('2024-03-18 07:50:00', 'YYYY-MM-DD HH24:MI:SS'), 'AUTORIZACION', 'AA456', 'JFK Torre', 'Solicitando rodaje', 'John Smith');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(3, TO_TIMESTAMP('2024-03-18 08:05:00', 'YYYY-MM-DD HH24:MI:SS'), 'DESPEGUE', 'JFK Torre', 'AA456', 'Autorizado despegue pista 04L', 'Mike Johnson');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(4, TO_TIMESTAMP('2024-03-18 14:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'INFORMACION', 'DL789', 'JFK Torre', 'Reportamos retraso por catering', 'Piloto');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(5, TO_TIMESTAMP('2024-03-18 19:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'CONSULTA', 'UA101', 'LAX Torre', 'Consultamos condiciones en ruta', 'Piloto');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(6, TO_TIMESTAMP('2024-03-18 08:50:00', 'YYYY-MM-DD HH24:MI:SS'), 'INFORMACION', 'AF345', 'CDG Torre', 'Solicitamos cambio de puerta', 'Piloto');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(9, TO_TIMESTAMP('2024-03-20 10:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'AUTORIZACION', 'EK212', 'MEX Torre', 'Solicitando autorización', 'Piloto');
INSERT INTO comunicaciones_vuelo (id_vuelo, fecha_hora, tipo_comunicacion, origen, destino, mensaje, operador) VALUES
(10, TO_TIMESTAMP('2024-03-20 13:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'AUTORIZACION', 'QR456', 'MAD Torre', 'Listos para rodaje', 'Piloto');

-- Tabla 5.13: autorizaciones_vuelo (se omite id_autorizacion)
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(1, 'SOBREVUELO', 'Agencia Estatal de Seguridad Aérea', 'AUT-MAD-BOG-001', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(2, 'SOBREVUELO', 'Aeronáutica Civil Colombia', 'AUT-BOG-MAD-001', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(3, 'DOMESTICO', 'FAA', 'FAA-DOM-AA-456', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(4, 'INTERNACIONAL', 'FAA / CAA', 'INT-JFK-LHR-001', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(5, 'INTERNACIONAL', 'FAA / CASA', 'INT-LAX-SYD-001', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(6, 'INTERNACIONAL', 'EASA / FAA', 'INT-CDG-JFK-001', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(7, 'INTERNACIONAL', 'CAA / FAA', 'INT-LHR-JFK-001', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(8, 'INTERNACIONAL', 'ANAC / FAA', 'INT-GRU-JFK-001', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(9, 'INTERNACIONAL', 'AFAC / EASA', 'INT-MEX-BCN-001', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO autorizaciones_vuelo (id_vuelo, tipo_autorizacion, entidad_autorizante, numero_autorizacion, fecha_emision, fecha_expiracion, activa) VALUES
(10, 'INTERNACIONAL', 'AESA / Aerocivil', 'INT-MAD-BOG-002', DATE '2024-01-01', DATE '2024-12-31', 1);

-- Tabla 5.14: seguros_vuelo (se omite id_seguro)
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(1, 1, 'RESPONSABILIDAD_CIVIL', 'RC-IB-2024-001', 'MAPFRE', 500000000, DATE '2024-01-01', DATE '2024-12-31', 125000);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(2, 2, 'RESPONSABILIDAD_CIVIL', 'RC-AV-2024-001', 'Seguros Bolívar', 450000000, DATE '2024-01-01', DATE '2024-12-31', 110000);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(3, 3, 'RESPONSABILIDAD_CIVIL', 'RC-AA-2024-001', 'AIG', 600000000, DATE '2024-01-01', DATE '2024-12-31', 150000);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(4, 4, 'RESPONSABILIDAD_CIVIL', 'RC-DL-2024-001', 'Chubb', 600000000, DATE '2024-01-01', DATE '2024-12-31', 150000);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(5, 5, 'RESPONSABILIDAD_CIVIL', 'RC-UA-2024-001', 'AIG', 650000000, DATE '2024-01-01', DATE '2024-12-31', 162500);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(6, 6, 'RESPONSABILIDAD_CIVIL', 'RC-AF-2024-001', 'AXA', 550000000, DATE '2024-01-01', DATE '2024-12-31', 137500);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(7, 7, 'RESPONSABILIDAD_CIVIL', 'RC-BA-2024-001', 'Lloyds', 600000000, DATE '2024-01-01', DATE '2024-12-31', 150000);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(8, 8, 'RESPONSABILIDAD_CIVIL', 'RC-LA-2024-001', 'Zurich', 500000000, DATE '2024-01-01', DATE '2024-12-31', 125000);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(9, 9, 'RESPONSABILIDAD_CIVIL', 'RC-EK-2024-001', 'QIC', 700000000, DATE '2024-01-01', DATE '2024-12-31', 175000);
INSERT INTO seguros_vuelo (id_vuelo, id_aerolinea, tipo_seguro, poliza, aseguradora, cobertura_maxima, fecha_inicio, fecha_fin, prima) VALUES
(10, 10, 'RESPONSABILIDAD_CIVIL', 'RC-QR-2024-001', 'QIC', 650000000, DATE '2024-01-01', DATE '2024-12-31', 162500);

-- Tabla 5.15: estadisticas_vuelo (se omite id_estadistica)
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(1, 275, 11500, 500, 94.8, 165000, 98000, 67000, 0);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(2, 175, 7800, 200, 97.2, 98000, 72000, 26000, 1);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(3, 180, 5000, 0, 100.0, 72000, 40000, 32000, 0);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(4, 305, 14500, 500, 93.8, 213500, 125000, 88500, 0);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(5, 376, 19500, 500, 97.4, 376000, 210000, 166000, 0);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(6, 265, 10800, 200, 91.4, 145750, 90000, 55750, 0);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(7, 0, 0, 0, 0.0, 0, 45000, -45000, 0);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(8, 0, 0, 0, 0.0, 0, 32000, -32000, 0);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(9, 356, 17500, 500, 92.2, 338200, 185000, 153200, 0);
INSERT INTO estadisticas_vuelo (id_vuelo, pasajeros_transportados, carga_transportada_kg, correo_transportado_kg, factor_ocupacion, ingresos_totales, gastos_totales, beneficio_neto, puntualidad_llegada) VALUES
(10, 280, 13500, 500, 96.6, 196000, 105000, 91000, 1);

-- =====================================================
-- MÓDULO 6: TRIPULACIÓN (4 TABLAS)
-- =====================================================

-- Tabla 6.1: tripulacion (se omite id_tripulante)
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('Carlos Alberto', 'González Pérez', 'DNI', '12345678A', DATE '1980-05-15', 'Española', 'PILOTO', 'ATP-IB-001', DATE '2023-01-01', DATE '2025-01-01', 12500, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('María Fernanda', 'López Rodríguez', 'DNI', '87654321B', DATE '1985-08-22', 'Española', 'COPILOTO', 'CPL-IB-002', DATE '2023-02-01', DATE '2025-02-01', 4500, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('Juan David', 'Martínez Silva', 'CC', '1012345678', DATE '1990-11-03', 'Colombiana', 'PILOTO', 'ATP-AV-001', DATE '2023-03-01', DATE '2025-03-01', 6800, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('Ana Milena', 'Gómez Castro', 'CC', '1023456789', DATE '1988-07-19', 'Colombiana', 'SOBRECARGO', 'PURS-AV-001', DATE '2023-04-01', DATE '2025-04-01', 5200, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('John Robert', 'Smith', 'PASSPORT', 'USA123456', DATE '1975-03-30', 'Estadounidense', 'PILOTO', 'ATP-AA-001', DATE '2023-05-01', DATE '2025-05-01', 18500, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('Jennifer Lynn', 'Davis', 'PASSPORT', 'USA789012', DATE '1992-12-12', 'Estadounidense', 'AUXILIAR', 'FA-AA-001', DATE '2023-06-01', DATE '2025-06-01', 2100, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('Pierre', 'Dubois', 'PASSPORT', 'FRA456789', DATE '1982-09-18', 'Francesa', 'PILOTO', 'ATP-AF-001', DATE '2023-07-01', DATE '2025-07-01', 9800, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('Sophie', 'Martin', 'PASSPORT', 'FRA987654', DATE '1991-04-25', 'Francesa', 'SOBRECARGO', 'PURS-AF-001', DATE '2023-08-01', DATE '2025-08-01', 3800, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('James', 'Wilson', 'PASSPORT', 'GBR567890', DATE '1978-06-07', 'Británica', 'PILOTO', 'ATP-BA-001', DATE '2023-09-01', DATE '2025-09-01', 15200, 1);
INSERT INTO tripulacion (nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, tipo_tripulante, licencia, fecha_licencia, fecha_vencimiento_licencia, horas_vuelo_acumuladas, activo) VALUES
('Sarah', 'Taylor', 'PASSPORT', 'GBR890123', DATE '1989-02-14', 'Británica', 'AUXILIAR', 'FA-BA-001', DATE '2023-10-01', DATE '2025-10-01', 2900, 1);

-- Tabla 6.2: vuelos_tripulacion (se inserta después de tener vuelos) (clave compuesta, no autoincremental)
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (1, 1, 'Capitán', 10, 'Sin incidencias');
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (1, 2, 'Copiloto', 10, NULL);
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (2, 3, 'Capitán', 9.5, NULL);
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (2, 4, 'Sobrecargo', 9.5, 'Buena atención');
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (3, 5, 'Capitán', 6, NULL);
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (3, 6, 'Auxiliar', 6, NULL);
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (4, 7, 'Capitán', 8.5, 'Reportó retraso');
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (4, 8, 'Sobrecargo', 8.5, NULL);
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (5, 9, 'Capitán', 15, 'Vuelo nocturno');
INSERT INTO vuelos_tripulacion (id_vuelo, id_tripulante, rol_asignado, horas_trabajadas, observaciones) VALUES (5, 10, 'Auxiliar', 15, NULL);

-- Tabla 6.3: tripulacion_certificaciones (se omite id_certificacion)
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(1, 'Tipo Boeing 787', DATE '2022-01-01', DATE '2025-01-01', 'Boeing', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(1, 'Instructor de vuelo', DATE '2020-03-01', DATE '2024-03-01', 'AESA', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(2, 'Tipo Airbus A320', DATE '2021-06-01', DATE '2024-06-01', 'Airbus', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(3, 'Tipo Airbus A330', DATE '2020-11-01', DATE '2024-11-01', 'Airbus', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(4, 'Primeros auxilios avanzados', DATE '2023-02-01', DATE '2025-02-01', 'Cruz Roja', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(5, 'Tipo Boeing 777', DATE '2019-08-01', DATE '2024-08-01', 'Boeing', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(6, 'Seguridad en cabina', DATE '2023-05-01', DATE '2025-05-01', 'FAA', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(7, 'Tipo Airbus A350', DATE '2022-04-01', DATE '2025-04-01', 'Airbus', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(8, 'Idiomas (Inglés avanzado)', DATE '2021-09-01', DATE '2026-09-01', 'Cambridge', 1);
INSERT INTO tripulacion_certificaciones (id_tripulante, tipo_certificacion, fecha_obtencion, fecha_vencimiento, entidad_certificadora, activa) VALUES
(9, 'Tipo Boeing 787', DATE '2020-12-01', DATE '2024-12-01', 'Boeing', 1);

-- Tabla 6.4: tripulacion_disponibilidad (se omite id_disponibilidad)
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(1, DATE '2024-03-01', DATE '2024-03-31', 12, 1, 'Disponible todo el mes');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(2, DATE '2024-03-01', DATE '2024-03-31', 10, 1, 'Disponible');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(3, DATE '2024-03-01', DATE '2024-03-15', 12, 1, 'Disponible primera quincena');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(3, DATE '2024-03-16', DATE '2024-03-31', 0, 0, 'Vacaciones');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(4, DATE '2024-03-01', DATE '2024-03-31', 10, 1, 'Disponible');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(5, DATE '2024-03-01', DATE '2024-03-31', 14, 1, 'Disponible vuelos largos');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(6, DATE '2024-03-01', DATE '2024-03-20', 8, 1, 'Disponible parcial');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(7, DATE '2024-03-01', DATE '2024-03-31', 12, 1, 'Disponible');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(8, DATE '2024-03-01', DATE '2024-03-31', 10, 1, 'Disponible');
INSERT INTO tripulacion_disponibilidad (id_tripulante, fecha_inicio, fecha_fin, horas_maximas_diarias, disponible, observaciones) VALUES
(9, DATE '2024-03-01', DATE '2024-03-31', 12, 1, 'Disponible');

-- =====================================================
-- MÓDULO 7: PASAJEROS (10 TABLAS)
-- =====================================================

-- Tabla 7.1: pasajeros (10 pasajeros frecuentes) (se omite id_pasajero)
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Alejandro', 'Fernández Gómez', 'DPI', 'ESP12345678', 'Española', DATE '1985-07-12', 'M', '+34611223344', 'alejandro.fernandez@email.com', 'Calle Mayor 10', 'Madrid', 'España', '28001', 'Ingeniero', 'Soltero', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Laura', 'Martínez Ruiz', 'DPI', 'ESP87654321', 'Española', DATE '1990-03-25', 'F', '+34622334455', 'laura.martinez@email.com', 'Avda. Diagonal 200', 'Barcelona', 'España', '08001', 'Abogada', 'Casada', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Carlos', 'Rodríguez Silva', 'OTRO', 'COL12345678', 'Colombiana', DATE '1978-11-05', 'M', '+573001234567', 'carlos.rodriguez@email.com', 'Carrera 15 #45-67', 'Bogotá', 'Colombia', '110111', 'Médico', 'Casado', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Ana Patricia', 'Gómez Castro', 'OTRO', 'COL87654321', 'Colombiana', DATE '1982-09-18', 'F', '+573002345678', 'ana.gomez@email.com', 'Calle 100 #20-30', 'Bogotá', 'Colombia', '110121', 'Arquitecta', 'Soltera', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Michael', 'Johnson', 'PASAPORTE', 'USA12345678', 'Estadounidense', DATE '1975-06-20', 'M', '+12125551234', 'michael.johnson@email.com', '123 Main St', 'New York', 'Estados Unidos', '10001', 'Empresario', 'Divorciado', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Jennifer', 'Williams', 'PASAPORTE', 'USA87654321', 'Estadounidense', DATE '1988-12-15', 'F', '+13105559876', 'jennifer.williams@email.com', '456 Oak Ave', 'Los Angeles', 'Estados Unidos', '90001', 'Diseñadora', 'Soltera', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Jean', 'Dupont', 'PASAPORTE', 'FRA12345678', 'Francesa', DATE '1969-04-02', 'M', '+33123456789', 'jean.dupont@email.com', '15 Rue de Rivoli', 'París', 'Francia', '75001', 'Chef', 'Casado', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Marie', 'Bernard', 'PASAPORTE', 'FRA87654321', 'Francesa', DATE '1992-08-30', 'F', '+33612345678', 'marie.bernard@email.com', '25 Avenue des Champs-Élysées', 'París', 'Francia', '75008', 'Periodista', 'Soltera', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('David', 'Brown', 'PASAPORTE', 'GBR12345678', 'Británica', DATE '1983-01-10', 'M', '+442079876543', 'david.brown@email.com', '10 Downing Street', 'Londres', 'Reino Unido', 'SW1A 1AA', 'Funcionario', 'Casado', 'SISTEMA');
INSERT INTO pasajeros (nombres, apellidos, tipo_documento, numero_documento, nacionalidad, fecha_nacimiento, genero, telefono, email, direccion, ciudad_residencia, pais_residencia, codigo_postal, ocupacion, estado_civil, usuario_registro) VALUES
('Emma', 'Taylor', 'PASAPORTE', 'GBR87654321', 'Británica', DATE '1995-05-22', 'F', '+442079876544', 'emma.taylor@email.com', '221B Baker Street', 'Londres', 'Reino Unido', 'NW1 6XE', 'Estudiante', 'Soltera', 'SISTEMA');

-- Tabla 7.2: pasajeros_documentos (se omite id_documento)
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(1, 'DNI', '12345678A', 'España', DATE '2019-01-01', DATE '2029-01-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(2, 'DNI', '87654321B', 'España', DATE '2020-03-01', DATE '2030-03-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(3, 'Pasaporte', 'COL123456', 'Colombia', DATE '2022-06-01', DATE '2032-06-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(4, 'Cédula', '1012345678', 'Colombia', DATE '2021-09-01', DATE '2031-09-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(5, 'Pasaporte', 'USA12345678', 'Estados Unidos', DATE '2020-12-01', DATE '2030-12-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(6, 'Pasaporte', 'USA87654321', 'Estados Unidos', DATE '2022-04-01', DATE '2032-04-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(7, 'Pasaporte', 'FRA12345678', 'Francia', DATE '2021-07-01', DATE '2031-07-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(8, 'Pasaporte', 'FRA87654321', 'Francia', DATE '2022-10-01', DATE '2032-10-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(9, 'Pasaporte', 'GBR12345678', 'Reino Unido', DATE '2019-11-01', DATE '2029-11-01', 1);
INSERT INTO pasajeros_documentos (id_pasajero, tipo_documento, numero_documento, pais_emision, fecha_emision, fecha_expiracion, verificado) VALUES
(10, 'Pasaporte', 'GBR87654321', 'Reino Unido', DATE '2023-02-01', DATE '2033-02-01', 1);

-- Tabla 7.3: perfiles_viajero (se omite id_perfil)
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(1, 'FRECUENTE', 'IB-12345', 1, 25000, 'PLATA', DATE '2022-01-01', DATE '2024-03-01');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(2, 'OCASIONAL', 'VY-67890', 2, 5000, 'BRONCE', DATE '2023-06-01', DATE '2024-02-15');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(3, 'VIP', 'AV-111213', 2, 75000, 'ORO', DATE '2021-03-01', DATE '2024-03-10');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(4, 'CORPORATIVO', 'AV-141516', 2, 45000, 'PLATA', DATE '2022-09-01', DATE '2024-02-28');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(5, 'FRECUENTE', 'AA-171819', 3, 120000, 'PLATINO', DATE '2019-05-01', DATE '2024-03-15');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(6, 'OCASIONAL', 'DL-202122', 4, 8000, 'BRONCE', DATE '2023-11-01', DATE '2024-01-20');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(7, 'VIP', 'AF-232425', 6, 90000, 'ORO', DATE '2020-08-01', DATE '2024-03-05');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(8, 'FRECUENTE', 'AF-262728', 6, 35000, 'PLATA', DATE '2022-12-01', DATE '2024-02-10');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(9, 'FRECUENTE', 'BA-293031', 7, 65000, 'PLATA', DATE '2021-10-01', DATE '2024-03-12');
INSERT INTO perfiles_viajero (id_pasajero, tipo_perfil, numero_programa, aerolinea_asociada, puntos_acumulados, categoria, fecha_ingreso, fecha_ultima_actividad) VALUES
(10, 'OCASIONAL', 'BA-323334', 7, 3000, 'BRONCE', DATE '2023-09-01', DATE '2024-01-05');

-- Tabla 7.4: pasajeros_preferencias (se omite id_preferencia)
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(1, 'COMIDA', 'Vegetariana', 1, DATE '2024-01-15');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(2, 'ASIENTO', 'Prefiere pasillo', 1, DATE '2024-02-01');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(3, 'COMIDA', 'Sin gluten', 1, DATE '2024-01-20');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(4, 'ASIENTO', 'Prefiere ventanilla', 1, DATE '2024-02-10');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(5, 'SERVICIOS', 'Acceso a sala VIP', 1, DATE '2024-01-05');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(6, 'ATENCION', 'Asistencia especial movilidad', 1, DATE '2024-02-15');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(7, 'COMIDA', 'Kosher', 1, DATE '2024-01-25');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(8, 'ASIENTO', 'Prefiere fila de salida', 1, DATE '2024-02-20');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(9, 'SERVICIOS', 'Periódico en inglés', 1, DATE '2024-01-30');
INSERT INTO pasajeros_preferencias (id_pasajero, tipo_preferencia, descripcion, activo, fecha_actualizacion) VALUES
(10, 'COMIDA', 'Vegetariana', 1, DATE '2024-02-25');

-- Tabla 7.5: pasajeros_historial_medico (se omite id_historial_medico)
INSERT INTO pasajeros_historial_medico (id_pasajero, condicion_medica, requiere_atencion_especial, medicamentos_autorizados, contacto_emergencia_nombre, contacto_emergencia_telefono, contacto_emergencia_relacion, ultima_actualizacion) VALUES
(3, 'Hipertensión', 0, 'Enalapril 10mg', 'María Rodríguez', '+573001234568', 'Esposa', DATE '2024-01-10');
INSERT INTO pasajeros_historial_medico (id_pasajero, condicion_medica, requiere_atencion_especial, medicamentos_autorizados, contacto_emergencia_nombre, contacto_emergencia_telefono, contacto_emergencia_relacion, ultima_actualizacion) VALUES
(4, 'Alergia a mariscos', 1, 'Epinefrina autoinyectable', 'Carlos Gómez', '+573002345679', 'Hermano', DATE '2024-02-05');
INSERT INTO pasajeros_historial_medico (id_pasajero, condicion_medica, requiere_atencion_especial, medicamentos_autorizados, contacto_emergencia_nombre, contacto_emergencia_telefono, contacto_emergencia_relacion, ultima_actualizacion) VALUES
(5, 'Diabetes tipo 2', 1, 'Insulina, metformina', 'Sarah Johnson', '+12125551235', 'Esposa', DATE '2024-01-15');
INSERT INTO pasajeros_historial_medico (id_pasajero, condicion_medica, requiere_atencion_especial, medicamentos_autorizados, contacto_emergencia_nombre, contacto_emergencia_telefono, contacto_emergencia_relacion, ultima_actualizacion) VALUES
(7, 'Asma', 1, 'Inhalador salbutamol', 'Claire Dupont', '+33123456790', 'Esposa', DATE '2024-02-20');
INSERT INTO pasajeros_historial_medico (id_pasajero, condicion_medica, requiere_atencion_especial, medicamentos_autorizados, contacto_emergencia_nombre, contacto_emergencia_telefono, contacto_emergencia_relacion, ultima_actualizacion) VALUES
(9, 'Alergia a penicilina', 1, 'Ninguno', 'Elizabeth Brown', '+442079876545', 'Esposa', DATE '2024-01-25');

-- Tabla 7.6: pasajeros_historial (se inserta después de vuelos) (se omite id_historial_pasajero)
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(1, 1, DATE '2024-03-18', 'VUELO', 'Vuelo Madrid-Bogotá', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(2, 2, DATE '2024-03-18', 'VUELO', 'Vuelo Bogotá-Madrid', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(3, 1, DATE '2024-03-18', 'VUELO', 'Vuelo Madrid-Bogotá', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(4, 2, DATE '2024-03-18', 'VUELO', 'Vuelo Bogotá-Madrid', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(5, 3, DATE '2024-03-18', 'VUELO', 'Vuelo Nueva York-Los Ángeles', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(6, 3, DATE '2024-03-18', 'VUELO', 'Vuelo Nueva York-Los Ángeles', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(7, 4, DATE '2024-03-18', 'VUELO', 'Vuelo Nueva York-Londres', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(8, 6, DATE '2024-03-18', 'VUELO', 'Vuelo París-Nueva York', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(9, 5, DATE '2024-03-18', 'VUELO', 'Vuelo Los Ángeles-Sídney', TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO pasajeros_historial (id_pasajero, id_vuelo, fecha_vuelo, tipo_historial, descripcion, fecha_registro) VALUES
(10, 10, DATE '2024-03-20', 'VUELO', 'Vuelo Madrid-Bogotá', TO_TIMESTAMP('2024-03-21 10:00:00', 'YYYY-MM-DD HH24:MI:SS'));

-- Tabla 7.7: pasajeros_redes_sociales (se omite id_red_social)
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(1, 'LINKEDIN', 'alejandro-fernandez', 'https://linkedin.com/in/alejandro-fernandez', 1);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(2, 'INSTAGRAM', '@lauramartinez', 'https://instagram.com/lauramartinez', 1);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(3, 'LINKEDIN', 'carlos-rodriguez', 'https://linkedin.com/in/carlos-rodriguez', 1);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(4, 'FACEBOOK', 'ana.gomez', 'https://facebook.com/ana.gomez', 0);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(5, 'LINKEDIN', 'michael-johnson-nyc', 'https://linkedin.com/in/michael-johnson-nyc', 1);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(6, 'TWITTER', '@jennywilliams', 'https://twitter.com/jennywilliams', 1);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(7, 'LINKEDIN', 'jean-dupont', 'https://linkedin.com/in/jean-dupont', 1);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(8, 'INSTAGRAM', '@maribernard', 'https://instagram.com/maribernard', 1);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(9, 'LINKEDIN', 'david-brown-uk', 'https://linkedin.com/in/david-brown-uk', 1);
INSERT INTO pasajeros_redes_sociales (id_pasajero, red_social, usuario, url_perfil, publico) VALUES
(10, 'FACEBOOK', 'emma.taylor', 'https://facebook.com/emma.taylor', 0);

-- Tabla 7.8: historial_comunicaciones (se omite id_comunicacion)
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(1, 'EMAIL', TO_TIMESTAMP('2024-03-01 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Confirmación de reserva', 'Su vuelo IB1234 ha sido confirmado', 'ENVIADO', 0);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(2, 'SMS', TO_TIMESTAMP('2024-03-02 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Recordatorio de vuelo', 'Su vuelo AV123 sale mañana a las 10:00', 'ENTREGADO', 0);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(3, 'EMAIL', TO_TIMESTAMP('2024-03-03 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'Oferta especial', 'Descuento en su próxima reserva', 'LEIDO', 1);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(4, 'WHATSAPP', TO_TIMESTAMP('2024-03-04 16:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'Check-in disponible', 'Ya puede hacer check-in para su vuelo', 'ENTREGADO', 0);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(5, 'EMAIL', TO_TIMESTAMP('2024-03-05 11:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'Encuesta de satisfacción', 'Califique su experiencia de vuelo', 'LEIDO', 1);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(6, 'LLAMADA', TO_TIMESTAMP('2024-03-06 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Cambio de reserva', 'Confirmación de cambio de fecha', 'ENTREGADO', 1);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(7, 'EMAIL', TO_TIMESTAMP('2024-03-07 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Promoción especial', 'Acumule millas extras', 'ENVIADO', 0);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(8, 'SMS', TO_TIMESTAMP('2024-03-08 13:40:00', 'YYYY-MM-DD HH24:MI:SS'), 'Recordatorio', 'No olvide su documentación', 'ENTREGADO', 0);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(9, 'EMAIL', TO_TIMESTAMP('2024-03-09 10:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'Actualización de vuelo', 'Cambio de puerta de embarque', 'LEIDO', 0);
INSERT INTO historial_comunicaciones (id_pasajero, tipo_comunicacion, fecha_envio, asunto, contenido, estado, respuesta_recibida) VALUES
(10, 'WHATSAPP', TO_TIMESTAMP('2024-03-10 17:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Bienvenida', 'Gracias por volar con nosotros', 'ENTREGADO', 1);

-- Tabla 7.9: preferencias_idiomas (se omite id_preferencia_idioma)
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(1, 'Español', 'NATIVO', 1);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(1, 'Inglés', 'AVANZADO', 0);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(2, 'Español', 'NATIVO', 1);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(2, 'Catalán', 'AVANZADO', 0);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(3, 'Español', 'NATIVO', 1);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(3, 'Inglés', 'AVANZADO', 0);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(4, 'Español', 'NATIVO', 1);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(5, 'Inglés', 'NATIVO', 1);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(5, 'Español', 'BASICO', 0);
INSERT INTO preferencias_idiomas (id_pasajero, idioma, nivel, preferido) VALUES
(6, 'Inglés', 'NATIVO', 1);

-- Tabla 7.10: acompanantes_viaje (se omite id_acompanante)
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(1, 2, 5, 'AMIGO', DATE '2024-03-18');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(3, 4, 12, 'FAMILIAR', DATE '2024-03-18');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(5, 6, 3, 'COLEGA', DATE '2024-03-18');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(7, 8, 8, 'FAMILIAR', DATE '2024-03-18');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(9, 10, 2, 'AMIGO', DATE '2024-03-20');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(1, 3, 1, 'COLEGA', DATE '2023-12-15');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(4, 2, 2, 'FAMILIAR', DATE '2024-02-10');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(6, 5, 3, 'COLEGA', DATE '2024-03-18');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(8, 7, 8, 'FAMILIAR', DATE '2024-03-18');
INSERT INTO acompanantes_viaje (id_pasajero_principal, id_pasajero_acompanante, frecuencia, relacion, ultimo_viaje_juntos) VALUES
(10, 9, 2, 'AMIGO', DATE '2024-03-20');

-- =====================================================
-- MÓDULO 8: RESERVAS Y BOLETERÍA (12 TABLAS)
-- =====================================================

-- Tabla 8.1: reservas (se omite id_reserva)
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(1, 1, 'IB-MAD-BOG-001', DATE '2024-02-15', NULL, 'CONFIRMADA', 'FLEXIBLE', 850.00, 'EUR', '12A', 'EJECUTIVA', 23, 8, 1, TO_TIMESTAMP('2024-03-17 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'A1', 1, NULL);
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(1, 3, 'IB-MAD-BOG-002', DATE '2024-02-20', NULL, 'CONFIRMADA', 'ECONOMICA', 450.00, 'EUR', '24B', 'ECONOMICA', 23, 8, 1, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'A1', 3, NULL);
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(2, 2, 'AV-BOG-MAD-001', DATE '2024-02-10', NULL, 'CONFIRMADA', 'FLEXIBLE', 4200000.00, 'COP', '5F', 'EJECUTIVA', 23, 8, 1, TO_TIMESTAMP('2024-03-17 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', 1, NULL);
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(2, 4, 'AV-BOG-MAD-002', DATE '2024-02-12', NULL, 'CONFIRMADA', 'ECONOMICA', 2100000.00, 'COP', '18C', 'ECONOMICA', 23, 8, 1, TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1', 3, NULL);
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(3, 5, 'AA-JFK-LAX-001', DATE '2024-03-01', NULL, 'CONFIRMADA', 'PRIMERA_CLASE', 1200.00, 'USD', '2A', 'PRIMERA_CLASE', 32, 12, 1, TO_TIMESTAMP('2024-03-17 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'B1', 1, NULL);
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(3, 6, 'AA-JFK-LAX-002', DATE '2024-03-02', NULL, 'CONFIRMADA', 'ECONOMICA', 350.00, 'USD', '15D', 'ECONOMICA', 23, 8, 1, TO_TIMESTAMP('2024-03-18 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'B1', 3, NULL);
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(4, 7, 'DL-JFK-LHR-001', DATE '2024-02-28', NULL, 'CANCELADA', 'EJECUTIVA', 1800.00, 'USD', NULL, 'EJECUTIVA', 32, 10, 0, NULL, NULL, NULL, 'Cancelado por huelga');
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(6, 8, 'AF-CDG-JFK-001', DATE '2024-02-25', NULL, 'CONFIRMADA', 'ECONOMICA', 680.00, 'EUR', '22F', 'ECONOMICA', 23, 8, 1, TO_TIMESTAMP('2024-03-17 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'C1', 3, NULL);
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(5, 9, 'UA-LAX-SYD-001', DATE '2024-02-05', NULL, 'CONFIRMADA', 'PRIMERA_CLASE', 5200.00, 'USD', '1A', 'PRIMERA_CLASE', 32, 12, 1, TO_TIMESTAMP('2024-03-17 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), '1A', 1, NULL);
INSERT INTO reservas (id_vuelo, id_pasajero, codigo_reserva, fecha_reserva, fecha_modificacion, estado_reserva, tipo_tarifa, precio_pagado, moneda, numero_asiento, clase_servicio, equipaje_facturado_kg, equipaje_mano_kg, checkin_realizado, fecha_checkin, puerta_embarque_asignada, grupo_embarque, observaciones) VALUES
(10, 10, 'QR-MAD-BOG-001', DATE '2024-03-01', DATE '2024-03-05', 'CONFIRMADA', 'EJECUTIVA', 2100.00, 'EUR', '3K', 'EJECUTIVA', 30, 10, 1, TO_TIMESTAMP('2024-03-19 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'A1', 1, 'Cambio de asiento solicitado');

-- Tabla 8.2: historial_reservas (se omite id_historial_reserva)
INSERT INTO historial_reservas (id_reserva, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, usuario_modificacion, motivo_cambio) VALUES
(1, TO_TIMESTAMP('2024-02-16 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'numero_asiento', '14B', '12A', 'agente1', 'Cambio solicitado por pasajero');
INSERT INTO historial_reservas (id_reserva, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, usuario_modificacion, motivo_cambio) VALUES
(7, TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'estado_reserva', 'CONFIRMADA', 'CANCELADA', 'sistema', 'Cancelación por huelga');
INSERT INTO historial_reservas (id_reserva, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, usuario_modificacion, motivo_cambio) VALUES
(10, TO_TIMESTAMP('2024-03-05 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'numero_asiento', '8C', '3K', 'agente2', 'Preferencia de pasillo');
INSERT INTO historial_reservas (id_reserva, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, usuario_modificacion, motivo_cambio) VALUES
(10, TO_TIMESTAMP('2024-03-05 14:31:00', 'YYYY-MM-DD HH24:MI:SS'), 'equipaje_facturado_kg', '23', '30', 'agente2', 'Añade equipaje extra');
INSERT INTO historial_reservas (id_reserva, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, usuario_modificacion, motivo_cambio) VALUES
(2, TO_TIMESTAMP('2024-03-18 08:05:00', 'YYYY-MM-DD HH24:MI:SS'), 'checkin_realizado', '0', '1', 'sistema', 'Check-in online');

-- Tabla 8.3: metodos_pago (se omite id_metodo_pago)
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('Visa', 'TARJETA_CREDITO', 'Stripe', 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('Mastercard', 'TARJETA_CREDITO', 'Stripe', 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('American Express', 'TARJETA_CREDITO', 'Stripe', 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('Visa Débito', 'TARJETA_DEBITO', 'Stripe', 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('Efectivo', 'EFECTIVO', NULL, 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('Transferencia bancaria', 'TRANSFERENCIA', 'BBVA', 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('PayPal', 'TARJETA_CREDITO', 'PayPal', 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('Puntos Iberia', 'PUNTOS', 'Iberia Plus', 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('Puntos Avianca', 'PUNTOS', 'LifeMiles', 1);
INSERT INTO metodos_pago (descripcion, tipo_pago, procesador, activo) VALUES
('Apple Pay', 'TARJETA_CREDITO', 'Apple', 1);

-- Tabla 8.4: reservas_pagos (se omite id_pago)
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(1, 1, 850.00, 'EUR', TO_TIMESTAMP('2024-02-15 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-IB-001', 'COMPLETADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(2, 2, 450.00, 'EUR', TO_TIMESTAMP('2024-02-20 15:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-IB-002', 'COMPLETADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(3, 9, 4200000.00, 'COP', TO_TIMESTAMP('2024-02-10 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-AV-001', 'COMPLETADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(4, 5, 2100000.00, 'COP', TO_TIMESTAMP('2024-02-12 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-AV-002', 'COMPLETADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(5, 1, 1200.00, 'USD', TO_TIMESTAMP('2024-03-01 08:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-AA-001', 'COMPLETADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(6, 4, 350.00, 'USD', TO_TIMESTAMP('2024-03-02 14:10:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-AA-002', 'COMPLETADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(7, 3, 1800.00, 'USD', TO_TIMESTAMP('2024-02-28 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-DL-001', 'REEMBOLSADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(8, 7, 680.00, 'EUR', TO_TIMESTAMP('2024-02-25 12:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-AF-001', 'COMPLETADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(9, 1, 5200.00, 'USD', TO_TIMESTAMP('2024-02-05 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-UA-001', 'COMPLETADO');
INSERT INTO reservas_pagos (id_reserva, id_metodo_pago, monto, moneda, fecha_pago, codigo_transaccion, estado_pago) VALUES
(10, 8, 2100.00, 'EUR', TO_TIMESTAMP('2024-03-01 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'TXN-QR-001', 'COMPLETADO');

-- Tabla 8.5: facturas (se omite id_factura)
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(1, 'FAC-IB-2024-001', DATE '2024-02-16', 750.00, 100.00, 850.00, 'EUR', 'Alejandro Fernández Gómez, NIF 12345678A');
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(2, 'FAC-IB-2024-002', DATE '2024-02-21', 397.00, 53.00, 450.00, 'EUR', 'Carlos Rodríguez Silva, Pasaporte COL123456');
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(3, 'FAC-AV-2024-001', DATE '2024-02-11', 3700000.00, 500000.00, 4200000.00, 'COP', 'Laura Martínez Ruiz, NIF 87654321B');
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(4, 'FAC-AV-2024-002', DATE '2024-02-13', 1850000.00, 250000.00, 2100000.00, 'COP', 'Ana Patricia Gómez Castro, CC 1012345678');
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(5, 'FAC-AA-2024-001', DATE '2024-03-02', 1060.00, 140.00, 1200.00, 'USD', 'Michael Johnson, Pasaporte USA12345678');
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(6, 'FAC-AA-2024-002', DATE '2024-03-03', 309.00, 41.00, 350.00, 'USD', 'Jennifer Williams, Pasaporte USA87654321');
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(8, 'FAC-AF-2024-001', DATE '2024-02-26', 600.00, 80.00, 680.00, 'EUR', 'Marie Bernard, Pasaporte FRA87654321');
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(9, 'FAC-UA-2024-001', DATE '2024-02-06', 4590.00, 610.00, 5200.00, 'USD', 'David Brown, Pasaporte GBR12345678');
INSERT INTO facturas (id_reserva, numero_factura, fecha_emision, subtotal, impuestos, total, moneda, datos_fiscales) VALUES
(10, 'FAC-QR-2024-001', DATE '2024-03-02', 1850.00, 250.00, 2100.00, 'EUR', 'Emma Taylor, Pasaporte GBR87654321');

-- Tabla 8.6: tarifas_especiales (se omite id_tarifa)
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(1, 'Joven', 'Para pasajeros de 18-25 años', 'Presentar identificación', 15.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(1, 'Senior', 'Para mayores de 65 años', 'Presentar identificación', 20.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(2, 'Grupo familiar', 'Familias de 4 o más', 'Mínimo 4 pasajeros', 12.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(2, 'Médico', 'Personal sanitario', 'Credencial profesional', 10.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(3, 'Militar', 'Personal militar', 'Identificación oficial', 15.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(3, 'Estudiante', 'Estudiantes universitarios', 'Carnet estudiante vigente', 10.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(4, 'Corporativo', 'Empresas conveniadas', 'Código corporativo', 8.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(6, 'Diplomático', 'Personal diplomático', 'Pasaporte diplomático', 25.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(7, 'Residente', 'Residentes del Reino Unido', 'Dirección UK', 5.00, DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO tarifas_especiales (id_aerolinea, nombre_tarifa, descripcion, condiciones, descuento_porcentaje, fecha_inicio, fecha_fin, activa) VALUES
(8, 'Conexión', 'Pasajeros en conexión', 'Vuelo internacional previo', 7.00, DATE '2024-01-01', DATE '2024-12-31', 1);

-- Tabla 8.7: promociones (se omite id_promocion)
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('VERANO2024', 'Descuento de verano', '20% en vuelos seleccionados', 'PORCENTAJE', 20.00, DATE '2024-06-01', DATE '2024-08-31', 1000, 0, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('BLACKFRIDAY', 'Black Friday', 'Descuentos especiales', 'PORCENTAJE', 30.00, DATE '2024-11-25', DATE '2024-11-30', 500, 0, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('2X1MADBOG', '2x1 Madrid-Bogotá', 'Compra un asiento y llévate otro gratis', '2X1', 0.00, DATE '2024-03-01', DATE '2024-04-30', 200, 45, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('WELCOME50', 'Bienvenida', '50€ de descuento para nuevos usuarios', 'MONTO_FIJO', 50.00, DATE '2024-01-01', DATE '2024-12-31', 500, 328, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('EQUIPAJE10', 'Equipaje gratis', '10kg de equipaje adicional sin costo', 'OTRO', 0.00, DATE '2024-04-01', DATE '2024-06-30', 300, 0, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('MILLASDOBLES', 'Millas dobles', 'Acumula el doble de millas', 'OTRO', 0.00, DATE '2024-05-01', DATE '2024-07-31', 1000, 0, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('PUENTEMAYO', 'Puente de mayo', 'Ofertas para el puente', 'PORCENTAJE', 15.00, DATE '2024-04-30', DATE '2024-05-05', 200, 0, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('ULTIMAMINUTO', 'Último minuto', 'Reservas con menos de 7 días', 'PORCENTAJE', 10.00, DATE '2024-01-01', DATE '2024-12-31', 500, 89, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('FAMILIA', 'Tarifa familiar', 'Descuento para grupos familiares', 'PORCENTAJE', 12.00, DATE '2024-01-01', DATE '2024-12-31', 300, 57, 1);
INSERT INTO promociones (codigo_promocion, nombre_promocion, descripcion, tipo_descuento, valor_descuento, fecha_inicio, fecha_fin, uso_maximo, usos_actuales, activa) VALUES
('CUMPLEAÑOS', 'Mes de cumpleaños', 'Descuento en tu mes', 'PORCENTAJE', 15.00, DATE '2024-01-01', DATE '2024-12-31', 1000, 102, 1);

-- Tabla 8.8: reservas_promociones (clave compuesta, no autoincremental)
INSERT INTO reservas_promociones (id_reserva, id_promocion, descuento_aplicado, fecha_aplicacion) VALUES
(1, 4, 50.00, TO_TIMESTAMP('2024-02-15 10:30:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO reservas_promociones (id_reserva, id_promocion, descuento_aplicado, fecha_aplicacion) VALUES
(3, 9, 504000.00, TO_TIMESTAMP('2024-02-10 09:15:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO reservas_promociones (id_reserva, id_promocion, descuento_aplicado, fecha_aplicacion) VALUES
(5, 5, 0.00, TO_TIMESTAMP('2024-03-01 08:20:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO reservas_promociones (id_reserva, id_promocion, descuento_aplicado, fecha_aplicacion) VALUES
(8, 8, 68.00, TO_TIMESTAMP('2024-02-25 12:45:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO reservas_promociones (id_reserva, id_promocion, descuento_aplicado, fecha_aplicacion) VALUES
(10, 10, 315.00, TO_TIMESTAMP('2024-03-01 11:30:00', 'YYYY-MM-DD HH24:MI:SS'));

-- Tabla 8.9: grupos_viaje (se omite id_grupo)
INSERT INTO grupos_viaje (nombre_grupo, tipo_grupo, cantidad_pasajeros, contacto_responsable, telefono_responsable, email_responsable, observaciones) VALUES
('Familia Rodríguez Gómez', 'FAMILIA', 4, 'Carlos Rodríguez', '+573001234567', 'carlos.rodriguez@email.com', 'Viaje familiar a Madrid');
INSERT INTO grupos_viaje (nombre_grupo, tipo_grupo, cantidad_pasajeros, contacto_responsable, telefono_responsable, email_responsable, observaciones) VALUES
('Ejecutivos Tech Corp', 'EMPRESA', 8, 'Michael Johnson', '+12125551234', 'michael.johnson@email.com', 'Convención en Los Ángeles');
INSERT INTO grupos_viaje (nombre_grupo, tipo_grupo, cantidad_pasajeros, contacto_responsable, telefono_responsable, email_responsable, observaciones) VALUES
('Amigos París', 'TURISTICO', 3, 'Jean Dupont', '+33123456789', 'jean.dupont@email.com', 'Tour por Nueva York');
INSERT INTO grupos_viaje (nombre_grupo, tipo_grupo, cantidad_pasajeros, contacto_responsable, telefono_responsable, email_responsable, observaciones) VALUES
('Excursión escolar', 'ESCOLAR', 25, 'Marie Bernard', '+33612345678', 'marie.bernard@email.com', 'Viaje de estudios');
INSERT INTO grupos_viaje (nombre_grupo, tipo_grupo, cantidad_pasajeros, contacto_responsable, telefono_responsable, email_responsable, observaciones) VALUES
('Tour Británico', 'TURISTICO', 6, 'David Brown', '+442079876543', 'david.brown@email.com', 'Vacaciones en España');

-- Tabla 8.10: grupos_pasajeros (clave compuesta, no autoincremental)
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(1, 3, DATE '2024-02-10', 'Padre');
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(1, 4, DATE '2024-02-10', 'Madre');
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(2, 5, DATE '2024-03-01', 'Líder');
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(2, 6, DATE '2024-03-01', 'Miembro');
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(3, 7, DATE '2024-02-28', 'Organizador');
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(3, 8, DATE '2024-02-28', 'Miembro');
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(4, 8, DATE '2024-02-25', 'Profesora');
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(5, 9, DATE '2024-02-05', 'Coordinador');
INSERT INTO grupos_pasajeros (id_grupo, id_pasajero, fecha_asignacion, rol_en_grupo) VALUES
(5, 10, DATE '2024-02-05', 'Miembro');

-- Tabla 8.11: solicitudes_especiales (se omite id_solicitud)
INSERT INTO solicitudes_especiales (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud, fecha_resolucion, resolucion) VALUES
(2, 'COMIDA_ESPECIAL', 'Comida vegetariana', TO_TIMESTAMP('2024-02-20 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'APROBADA', TO_TIMESTAMP('2024-02-21 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Confirmado');
INSERT INTO solicitudes_especiales (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud, fecha_resolucion, resolucion) VALUES
(3, 'ASISTENCIA', 'Asistencia en silla de ruedas', TO_TIMESTAMP('2024-02-10 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'APROBADA', TO_TIMESTAMP('2024-02-11 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Asistencia confirmada');
INSERT INTO solicitudes_especiales (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud, fecha_resolucion, resolucion) VALUES
(5, 'EQUIPAJE_ESPECIAL', 'Equipaje con material deportivo (esquís)', TO_TIMESTAMP('2024-03-01 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'APROBADA', TO_TIMESTAMP('2024-03-02 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Cargo adicional aplicado');
INSERT INTO solicitudes_especiales (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud, fecha_resolucion, resolucion) VALUES
(6, 'MASCOTA', 'Viaje con perro pequeño en cabina', TO_TIMESTAMP('2024-03-02 15:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'PENDIENTE', NULL, NULL);
INSERT INTO solicitudes_especiales (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud, fecha_resolucion, resolucion) VALUES
(7, 'COMIDA_ESPECIAL', 'Comida sin gluten', TO_TIMESTAMP('2024-02-28 17:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'RECHAZADA', TO_TIMESTAMP('2024-02-29 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Vuelo cancelado');
INSERT INTO solicitudes_especiales (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud, fecha_resolucion, resolucion) VALUES
(8, 'ASISTENCIA', 'Asistencia para persona con discapacidad visual', TO_TIMESTAMP('2024-02-25 13:10:00', 'YYYY-MM-DD HH24:MI:SS'), 'APROBADA', TO_TIMESTAMP('2024-02-26 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Asistente asignado');
INSERT INTO solicitudes_especiales (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud, fecha_resolucion, resolucion) VALUES
(9, 'COMIDA_ESPECIAL', 'Comida kosher', TO_TIMESTAMP('2024-02-05 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'APROBADA', TO_TIMESTAMP('2024-02-06 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Confirmado');
INSERT INTO solicitudes_especiales (id_reserva, tipo_solicitud, descripcion, fecha_solicitud, estado_solicitud, fecha_resolucion, resolucion) VALUES
(10, 'EQUIPAJE_ESPECIAL', 'Instrumento musical (violonchelo)', TO_TIMESTAMP('2024-03-01 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'APROBADA', TO_TIMESTAMP('2024-03-02 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Asiento extra comprado');

-- Tabla 8.12: equipaje_especial (se omite id_equipaje_especial)
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(3, 'DEPORTIVO', 25, '200x40x30', 'Equipo de golf', 1, 1, 75.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(5, 'DEPORTIVO', 15, '190x30x25', 'Esquís y bastones', 1, 1, 50.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(6, 'MASCOTA', 5, '45x30x25', 'Perro raza pequeña', 1, 0, 0.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(8, 'INSTRUMENTO_MUSICAL', 10, '140x50x40', 'Guitarra', 1, 1, 40.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(10, 'INSTRUMENTO_MUSICAL', 20, '150x60x50', 'Violonchelo', 1, 1, 200.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(1, 'VALORES', 2, '30x20x10', 'Documentos confidenciales', 1, 1, 150.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(2, 'DIPLOMATICO', 5, '40x30x20', 'Maleta diplomática', 1, 1, 0.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(4, 'DEPORTIVO', 20, '150x40x30', 'Bicicleta', 1, 1, 100.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(7, 'VALORES', 3, '25x15x10', 'Joyas', 1, 0, 0.00);
INSERT INTO equipaje_especial (id_reserva, tipo_equipaje, peso_kg, dimensiones, contenido, requiere_autorizacion, autorizado, costo_adicional) VALUES
(9, 'MASCOTA', 4, '40x30x25', 'Gato', 1, 1, 50.00);

COMMIT;

SELECT 'Datos insertados correctamente' AS estado FROM dual;

-- =====================================================
-- CONTINUACIÓN: MÓDULOS 9 AL 15
-- =====================================================

-- =====================================================
-- MÓDULO 9: CHECK-IN Y ABORDAJE (5 TABLAS)
-- =====================================================

-- Tabla 9.1: checkin_digital (se omite id_checkin)
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(1, TO_TIMESTAMP('2024-03-17 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.1.100', 'iPhone 15', 1, 1, 1);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(2, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.1.101', 'Samsung S24', 1, 1, 0);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(3, TO_TIMESTAMP('2024-03-17 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), '10.0.0.25', 'iPad Pro', 1, 1, 1);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(4, TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), '10.0.0.26', 'PC Windows', 1, 1, 0);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(5, TO_TIMESTAMP('2024-03-17 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), '172.16.0.1', 'MacBook Pro', 1, 1, 1);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(6, TO_TIMESTAMP('2024-03-18 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), '172.16.0.2', 'iPhone 14', 1, 0, 1);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(7, TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.2.50', 'iPad', 0, 0, 0);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(8, TO_TIMESTAMP('2024-03-17 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.2.51', 'PC Windows', 1, 1, 1);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(9, TO_TIMESTAMP('2024-03-17 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), '10.1.1.10', 'Samsung Tablet', 1, 1, 1);
INSERT INTO checkin_digital (id_reserva, fecha_checkin, ip_origen, dispositivo, pase_abordaje_generado, enviado_email, enviado_sms) VALUES
(10, TO_TIMESTAMP('2024-03-19 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), '10.1.1.11', 'iPhone 15', 1, 1, 1);

-- Tabla 9.2: pases_abordaje (se omite id_pase_abordaje)
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(1, 'IB-MAD-BOG-001-12A', TO_TIMESTAMP('2024-03-17 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'A1', '1', '12A', 1);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(2, 'IB-MAD-BOG-002-24B', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:50:00', 'YYYY-MM-DD HH24:MI:SS'), 'A1', '3', '24B', 1);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(3, 'AV-BOG-MAD-001-5F', TO_TIMESTAMP('2024-03-17 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '1', '5F', 1);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(4, 'AV-BOG-MAD-002-18C', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:40:00', 'YYYY-MM-DD HH24:MI:SS'), '1', '3', '18C', 1);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(5, 'AA-JFK-LAX-001-2A', TO_TIMESTAMP('2024-03-17 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'B1', '1', '2A', 1);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(6, 'AA-JFK-LAX-002-15D', TO_TIMESTAMP('2024-03-18 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 07:35:00', 'YYYY-MM-DD HH24:MI:SS'), 'B1', '3', '15D', 1);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(8, 'AF-CDG-JFK-001-22F', TO_TIMESTAMP('2024-03-17 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'C1', '3', '22F', 1);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(9, 'UA-LAX-SYD-001-1A', TO_TIMESTAMP('2024-03-17 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 19:30:00', 'YYYY-MM-DD HH24:MI:SS'), '1A', '1', '1A', 1);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(10, 'QR-MAD-BOG-001-3K', TO_TIMESTAMP('2024-03-19 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'A1', '1', '3K', 0);
INSERT INTO pases_abordaje (id_reserva, codigo_barras, fecha_generacion, fecha_escaneo, puerta_embarque, grupo_embarque, asiento, utilizado) VALUES
(7, 'DL-JFK-LHR-001-XXX', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, NULL, NULL, NULL, 0);

-- =====================================================
-- INSERCIÓN DE EMPLEADOS (10 REGISTROS) (se omite id_empleado)
-- =====================================================
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP001', 'Juan Carlos', 'González Pérez', 'DNI', '12345678A', DATE '1980-05-15', 'Española', 'M', 'Calle Mayor 10, Madrid', '+34611223344', 'juan.gonzalez@aeropuerto.com', DATE '2022-01-15', 'Operaciones', 'Jefe de Operaciones', 55000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP002', 'María Luisa', 'López Rodríguez', 'DNI', '87654321B', DATE '1985-08-22', 'Española', 'F', 'Avda. de la Paz 25, Madrid', '+34622334455', 'maria.lopez@aeropuerto.com', DATE '2022-03-10', 'Mantenimiento', 'Supervisora de Mantenimiento', 48000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP003', 'Carlos Alberto', 'Rodríguez Silva', 'DNI', '11223344C', DATE '1975-11-30', 'Española', 'M', 'Calle de Alcalá 150, Madrid', '+34633445566', 'carlos.rodriguez@aeropuerto.com', DATE '2021-06-01', 'Recursos Humanos', 'Gerente de RRHH', 52000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP004', 'Ana Belén', 'Martínez García', 'DNI', '55667788D', DATE '1990-02-18', 'Española', 'F', 'Paseo de la Castellana 80, Madrid', '+34644556677', 'ana.martinez@aeropuerto.com', DATE '2023-01-15', 'Finanzas', 'Analista Financiera', 42000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP005', 'Javier', 'Fernández López', 'DNI', '99887766E', DATE '1988-07-12', 'Española', 'M', 'Calle de Goya 45, Madrid', '+34655667788', 'javier.fernandez@aeropuerto.com', DATE '2022-09-01', 'Seguridad', 'Jefe de Seguridad', 50000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP006', 'Laura', 'Sánchez Ruiz', 'DNI', '33445566F', DATE '1992-11-05', 'Española', 'F', 'Avda. de América 30, Madrid', '+34666778899', 'laura.sanchez@aeropuerto.com', DATE '2023-03-20', 'Comercial', 'Responsable Comercial', 45000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP007', 'David', 'Gómez Castro', 'DNI', '66778899G', DATE '1983-09-28', 'Española', 'M', 'Calle de Serrano 120, Madrid', '+34677889900', 'david.gomez@aeropuerto.com', DATE '2021-11-10', 'Atención al Cliente', 'Supervisor de Atención', 38000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP008', 'Patricia', 'Díaz Hernández', 'DNI', '11223344H', DATE '1995-04-17', 'Española', 'F', 'Calle de Velázquez 55, Madrid', '+34688990011', 'patricia.diaz@aeropuerto.com', DATE '2024-01-10', 'Tecnología', 'Analista de Sistemas', 43000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP009', 'Miguel Ángel', 'Ruiz Pérez', 'DNI', '22334455I', DATE '1979-12-03', 'Española', 'M', 'Calle de Orense 70, Madrid', '+34699001122', 'miguel.ruiz@aeropuerto.com', DATE '2022-05-15', 'Legal', 'Asesor Legal', 58000.00, 'PERMANENTE', 1);
INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP010', 'Carmen', 'Navarro Gil', 'DNI', '33445566J', DATE '1987-06-22', 'Española', 'F', 'Avda. de Brasil 15, Madrid', '+34700112233', 'carmen.navarro@aeropuerto.com', DATE '2023-08-01', 'Calidad', 'Inspectora de Calidad', 41000.00, 'PERMANENTE', 1);

-- Tabla 9.3: puertas_embarque_asignacion (ahora con empleados existentes) (se omite id_asignacion_puerta)
INSERT INTO puertas_embarque_asignacion (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) VALUES
(1, 1, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1);
INSERT INTO puertas_embarque_asignacion (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) VALUES
(6, 2, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2);
INSERT INTO puertas_embarque_asignacion (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) VALUES
(8, 3, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 07:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 3);
INSERT INTO puertas_embarque_asignacion (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) VALUES
(9, 4, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4);
INSERT INTO puertas_embarque_asignacion (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) VALUES
(10, 5, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 21:00:00', 'YYYY-MM-DD HH24:MI:SS'), 5);
INSERT INTO puertas_embarque_asignacion (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) VALUES
(5, 6, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 6);
INSERT INTO puertas_embarque_asignacion (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) VALUES
(2, 10, TO_TIMESTAMP('2024-03-20 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 7);
INSERT INTO puertas_embarque_asignacion (id_puerta, id_vuelo, fecha_asignacion, hora_inicio, hora_fin, asignado_por) VALUES
(4, 8, TO_TIMESTAMP('2024-03-19 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 01:00:00', 'YYYY-MM-DD HH24:MI:SS'), 8);

-- Tabla 9.4: grupos_embarque (se omite id_grupo_embarque)
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(1, 1, 'Primera clase y pasajeros con movilidad reducida', 1, TO_TIMESTAMP('2024-03-18 11:30:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(1, 2, 'Familias con niños pequeños', 2, TO_TIMESTAMP('2024-03-18 11:40:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(1, 3, 'Clase turista filas 20-30', 3, TO_TIMESTAMP('2024-03-18 11:50:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(1, 4, 'Clase turista resto de filas', 4, TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(2, 1, 'Ejecutivos y priority', 1, TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(2, 2, 'Familias', 2, TO_TIMESTAMP('2024-03-18 09:40:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(2, 3, 'Turista', 3, TO_TIMESTAMP('2024-03-18 09:50:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(3, 1, 'Primera clase', 1, TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(3, 2, 'Turista', 2, TO_TIMESTAMP('2024-03-18 07:45:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO grupos_embarque (id_vuelo, numero_grupo, descripcion, orden, tiempo_estimado) VALUES
(5, 1, 'Primera clase', 1, TO_TIMESTAMP('2024-03-18 19:30:00', 'YYYY-MM-DD HH24:MI:SS'));

-- Tabla 9.5: control_abordaje (se omite id_control_abordaje)
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(1, 1, TO_TIMESTAMP('2024-03-18 11:45:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 'ABORDADO', 'Pasajero abordó a tiempo');
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(1, 2, TO_TIMESTAMP('2024-03-18 11:50:00', 'YYYY-MM-DD HH24:MI:SS'), 2, 'ABORDADO', NULL);
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(2, 3, TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 3, 'ABORDADO', NULL);
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(2, 4, TO_TIMESTAMP('2024-03-18 09:50:00', 'YYYY-MM-DD HH24:MI:SS'), 4, 'ABORDADO', 'Abordó en último grupo');
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(3, 5, TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'), 5, 'ABORDADO', NULL);
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(3, 6, TO_TIMESTAMP('2024-03-18 07:46:00', 'YYYY-MM-DD HH24:MI:SS'), 6, 'ABORDADO', NULL);
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(4, 7, NULL, NULL, 'NO_ABORDADO', 'Vuelo cancelado');
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(6, 8, TO_TIMESTAMP('2024-03-18 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), 7, 'ABORDADO', NULL);
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(5, 9, TO_TIMESTAMP('2024-03-18 19:30:00', 'YYYY-MM-DD HH24:MI:SS'), 8, 'ABORDADO', NULL);
INSERT INTO control_abordaje (id_vuelo, id_reserva, hora_abordaje, verificado_por, estado, observaciones) VALUES
(10, 10, TO_TIMESTAMP('2024-03-20 13:45:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ABORDADO', 'Abordó sin incidencias');

-- =====================================================
-- MÓDULO 10: SEGURIDAD (8 TABLAS)
-- =====================================================

-- Tabla 10.1: incidentes (se omite id_incidente)
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(5, 3, 'JFK', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 06:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'INCIDENTE', 'BAJO', 'Pasajero intentó pasar con líquidos en exceso', 'Control seguridad T1', 'TSA', 'Oficial Martínez', 'Líquidos decomisados', DATE '2024-03-18', 'RESUELTO', 0);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(7, 4, 'JFK', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DISCUSION', 'MEDIO', 'Discusión con personal de tierra por cancelación', 'Puerta B1', 'Policía Portuaria', 'Sargento Williams', 'Pasajero calmado y reubicado', DATE '2024-03-18', 'RESUELTO', 0);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(NULL, NULL, 'MAD', DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'ROBO', 'ALTO', 'Robo de maleta en cinta de equipajes', 'Terminal T4', 'Policía Nacional', 'Inspector Ruiz', 'En investigación', NULL, 'ACTIVO', 1);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(2, 2, 'BOG', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'EMERGENCIA_MEDICA', 'MEDIO', 'Desmayo en sala de espera', 'Sala VIP', 'Defensa Civil', 'Dr. Rodríguez', 'Atendido y estabilizado', DATE '2024-03-18', 'RESUELTO', 0);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(NULL, 5, 'LAX', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 18:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'INFRACCION', 'MEDIO', 'Pasajero intentó fumar en el baño', 'A bordo', 'Crew', 'Capitán Smith', 'Reporte a autoridades en destino', DATE '2024-03-19', 'RESUELTO', 1);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(8, 6, 'CDG', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 07:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'ARRESTO', 'CRITICO', 'Pasajero intentó abordar con documentación falsa', 'Control pasaportes', 'Police Aux Frontières', 'Capitaine Dubois', 'Arresto y detención', DATE '2024-03-18', 'RESUELTO', 1);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(10, 10, 'MAD', DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'SEGURIDAD', 'BAJO', 'Alarma activada por olvido de monedero', 'Arco seguridad', 'Policía Nacional', 'Agente López', 'Falsa alarma', DATE '2024-03-20', 'RESUELTO', 0);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(NULL, NULL, 'BCN', DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 14:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'INCIDENTE', 'MEDIO', 'Paquete sospechoso en terminal', 'Terminal T1', 'Mossos d''Esquadra', 'Sargento Vidal', 'Evacuación parcial, falso aviso', DATE '2024-03-19', 'RESUELTO', 0);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(4, 2, 'BOG', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'EMERGENCIA_MEDICA', 'ALTO', 'Infarto en sala de embarque', 'Puerta 1', 'Defensa Civil', 'Dr. Gómez', 'Reanimado y hospitalizado', DATE '2024-03-25', 'ACTIVO', 1);
INSERT INTO incidentes (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_incidente, hora_incidente, tipo_incidente, nivel_gravedad, descripcion, lugar_incidente, autoridad_involucrada, oficial_a_cargo, resolucion, fecha_resolucion, estado, requiere_seguimiento) VALUES
(1, 1, 'MAD', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'INFRACCION', 'BAJO', 'Olvidó teléfono en bandeja', 'Control seguridad', 'Policía', 'Agente García', 'Recuperado', DATE '2024-03-18', 'RESUELTO', 0);

-- Tabla 10.2: tipos_incidentes (se omite id_tipo_incidente)
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('SEGURIDAD', 'Incidentes relacionados con seguridad física', 'Activar protocolo de seguridad, contactar policía', 5, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('MEDICO', 'Emergencias médicas', 'Llamar a servicio médico, preparar botiquín', 3, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('OPERACIONAL', 'Problemas operativos', 'Notificar a supervisión', 10, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('CLIMATICO', 'Incidentes por condiciones climáticas', 'Activar plan de contingencia climática', 15, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('INCENDIO', 'Fuego o humo', 'Evacuar área, llamar a bomberos', 2, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('ARRESTO', 'Detención de pasajero', 'Asegurar área, contactar autoridades', 5, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('DISCUSION', 'Altercados verbales', 'Intervención de supervisión', 8, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('ROBO', 'Hurto o pérdida', 'Tomar denuncia, revisar CCTV', 15, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('INFRACCION', 'Incumplimiento de normas', 'Amonestación, reporte', 10, 1);
INSERT INTO tipos_incidentes (nombre_tipo, descripcion, protocolo_accion, tiempo_respuesta_estimado, activo) VALUES
('AMENAZA', 'Amenaza de bomba o similar', 'Activar máximo protocolo, evacuar', 1, 1);

-- Tabla 10.3: incidentes_involucrados (se omite id_involucrado)
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(1, 'PASAJERO', 5, NULL, NULL, NULL, NULL, NULL, 'Infractor', 'No sabía que no podía llevar el agua');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(1, 'EMPLEADO', NULL, NULL, 'Ana Torres', 'DNI', '56789012C', 'Española', 'Inspector', 'El pasajero mostró actitud colaboradora');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(2, 'PASAJERO', 7, NULL, NULL, NULL, NULL, NULL, 'Implicado', 'Estaba frustrado por la cancelación');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(2, 'EMPLEADO', NULL, NULL, 'Carlos Mendoza', 'DNI', '67890123D', 'Española', 'Agente', 'El pasajero estaba alterado pero se calmó');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(3, 'VISITANTE', NULL, NULL, 'Luis Fernández', 'DNI', '78901234E', 'Española', 'Denunciante', 'Vi a una persona cogiendo la maleta');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(4, 'PASAJERO', 2, NULL, NULL, NULL, NULL, NULL, 'Afectado', 'Me sentí mareada y perdí el conocimiento');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(4, 'EMPLEADO', NULL, NULL, 'Médico Rodríguez', 'CC', '11223344', 'Colombiana', 'Socorrista', 'La pasajera tenía baja presión, se recuperó');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(5, 'TRIPULANTE', NULL, 6, NULL, NULL, NULL, NULL, 'Testigo', 'Oli a humo y confirmé que venía del baño');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(6, 'AUTORIDAD', NULL, NULL, 'Capitaine Dubois', 'PASSPORT', 'POL-001', 'Francesa', 'Oficial', 'El pasaporte era falso');
INSERT INTO incidentes_involucrados (id_incidente, tipo_persona, id_pasajero, id_tripulante, nombre_completo, tipo_documento, numero_documento, nacionalidad, rol_en_incidente, declaracion) VALUES
(9, 'EMPLEADO', NULL, NULL, 'Dra. Gómez', 'CC', '99887766', 'Colombiana', 'Médico', 'El paciente sufrió un infarto agudo de miocardio');

-- Tabla 10.4: incidentes_evidencia (se omite id_evidencia)
INSERT INTO incidentes_evidencia (id_incidente, tipo_evidencia, descripcion, fecha_registro, registrado_por) VALUES
(1, 'OBJETO', 'Botella de agua 500ml', TO_TIMESTAMP('2024-03-18 06:35:00', 'YYYY-MM-DD HH24:MI:SS'), 'Oficial Martínez');
INSERT INTO incidentes_evidencia (id_incidente, tipo_evidencia, descripcion, fecha_registro, registrado_por) VALUES
(3, 'FOTO', 'Captura de CCTV del momento del robo', TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Inspector Ruiz');
INSERT INTO incidentes_evidencia (id_incidente, tipo_evidencia, descripcion, fecha_registro, registrado_por) VALUES
(5, 'TESTIMONIO', 'Declaración de sobrecargo', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Capitán Smith');
INSERT INTO incidentes_evidencia (id_incidente, tipo_evidencia, descripcion, fecha_registro, registrado_por) VALUES
(6, 'DOCUMENTO', 'Pasaporte falso incautado', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Capitaine Dubois');
INSERT INTO incidentes_evidencia (id_incidente, tipo_evidencia, descripcion, fecha_registro, registrado_por) VALUES
(8, 'VIDEO', 'Grabación de cámara de seguridad', TO_TIMESTAMP('2024-03-19 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Sargento Vidal');
INSERT INTO incidentes_evidencia (id_incidente, tipo_evidencia, descripcion, fecha_registro, registrado_por) VALUES
(9, 'DOCUMENTO', 'Historial médico del paciente', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Dr. Gómez');

-- Tabla 10.5: incidentes_medidas (se omite id_medida)
INSERT INTO incidentes_medidas (id_incidente, tipo_medida, descripcion, fecha_aplicacion, aplicado_por, vigencia_dias, fecha_vencimiento, observaciones) VALUES
(1, 'ADVERTENCIA', 'Amonestación verbal por intento de pasar líquidos', TO_TIMESTAMP('2024-03-18 06:40:00', 'YYYY-MM-DD HH24:MI:SS'), 'Oficial Martínez', NULL, NULL, 'Pasajero colaborador');
INSERT INTO incidentes_medidas (id_incidente, tipo_medida, descripcion, fecha_aplicacion, aplicado_por, vigencia_dias, fecha_vencimiento, observaciones) VALUES
(2, 'ADVERTENCIA', 'Llamada de atención por altercado', TO_TIMESTAMP('2024-03-18 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Sargento Williams', NULL, NULL, 'El pasajero se disculpó');
INSERT INTO incidentes_medidas (id_incidente, tipo_medida, descripcion, fecha_aplicacion, aplicado_por, vigencia_dias, fecha_vencimiento, observaciones) VALUES
(5, 'MULTA', 'Multa por fumar a bordo', TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Autoridad Aduanera', NULL, NULL, 'Multa de 500 USD');
INSERT INTO incidentes_medidas (id_incidente, tipo_medida, descripcion, fecha_aplicacion, aplicado_por, vigencia_dias, fecha_vencimiento, observaciones) VALUES
(6, 'ARRESTO', 'Detención por falsificación documental', TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Capitaine Dubois', NULL, NULL, 'Trasladado a comisaría');
INSERT INTO incidentes_medidas (id_incidente, tipo_medida, descripcion, fecha_aplicacion, aplicado_por, vigencia_dias, fecha_vencimiento, observaciones) VALUES
(6, 'PROHIBICION_VUELO', 'Prohibición de volar en territorio francés', TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Capitaine Dubois', 365, DATE '2025-03-18', 'Mientras dure el proceso');
INSERT INTO incidentes_medidas (id_incidente, tipo_medida, descripcion, fecha_aplicacion, aplicado_por, vigencia_dias, fecha_vencimiento, observaciones) VALUES
(8, 'OTRA', 'Reapertura de terminal tras falso aviso', TO_TIMESTAMP('2024-03-19 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Sargento Vidal', NULL, NULL, NULL);

-- Tabla 10.6: prohibiciones_vuelo (se omite id_prohibicion)
INSERT INTO prohibiciones_vuelo (id_pasajero, fecha_prohibicion, fecha_inicio, fecha_fin, motivo, id_incidente, autoridad_emite, activa) VALUES
(8, DATE '2024-03-18', DATE '2024-03-18', DATE '2025-03-18', 'Uso de pasaporte falso', 6, 'Police Aux Frontières', 1);
INSERT INTO prohibiciones_vuelo (id_pasajero, fecha_prohibicion, fecha_inicio, fecha_fin, motivo, id_incidente, autoridad_emite, activa) VALUES
(5, DATE '2024-03-19', DATE '2024-03-19', DATE '2024-06-19', 'Fumar a bordo', 5, 'FAA', 1);

-- Tabla 10.7: emergencias_medicas (se omite id_emergencia)
INSERT INTO emergencias_medicas (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_emergencia, tipo_emergencia, sintomas, diagnostico_inicial, personal_atendio, tratamiento, requiere_hospitalizacion, hospital_destino, fecha_alta) VALUES
(2, 2, 'BOG', TO_TIMESTAMP('2024-03-18 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'DESMAYO', 'Mareos, pérdida de conocimiento', 'Hipotensión', 'Dr. Rodríguez', 'Reposo e hidratación', 0, NULL, DATE '2024-03-18');
INSERT INTO emergencias_medicas (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_emergencia, tipo_emergencia, sintomas, diagnostico_inicial, personal_atendio, tratamiento, requiere_hospitalizacion, hospital_destino, fecha_alta) VALUES
(4, 2, 'BOG', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PARO_CARDIACO', 'Dolor en pecho, pérdida de conocimiento', 'Infarto agudo de miocardio', 'Dr. Gómez', 'RCP, desfibrilador', 1, 'Clínica Shaio', DATE '2024-03-25');
INSERT INTO emergencias_medicas (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_emergencia, tipo_emergencia, sintomas, diagnostico_inicial, personal_atendio, tratamiento, requiere_hospitalizacion, hospital_destino, fecha_alta) VALUES
(NULL, NULL, 'MAD', TO_TIMESTAMP('2024-03-19 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'ALERGIA', 'Inflamación, dificultad respiratoria', 'Shock anafiláctico', 'SAMUR', 'Adrenalina', 1, 'Hospital La Paz', DATE '2024-03-20');
INSERT INTO emergencias_medicas (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_emergencia, tipo_emergencia, sintomas, diagnostico_inicial, personal_atendio, tratamiento, requiere_hospitalizacion, hospital_destino, fecha_alta) VALUES
(3, 1, 'MAD', TO_TIMESTAMP('2024-03-18 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'MAREO', 'Vértigo', 'Mareo por ansiedad', 'Enfermería', 'Reposo', 0, NULL, DATE '2024-03-18');
INSERT INTO emergencias_medicas (id_pasajero, id_vuelo, codigo_aeropuerto, fecha_emergencia, tipo_emergencia, sintomas, diagnostico_inicial, personal_atendio, tratamiento, requiere_hospitalizacion, hospital_destino, fecha_alta) VALUES
(9, 5, 'LAX', TO_TIMESTAMP('2024-03-18 23:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'HIPOGLUCEMIA', 'Sudoración, temblores', 'Bajo nivel de azúcar', 'Tripulante', 'Jugo de naranja', 0, NULL, DATE '2024-03-19');

-- Tabla 10.8: botiquines_vuelo (se omite id_botiquin)
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(1, DATE '2024-03-17', 1, 0, 'Todo correcto', 'Supervisor Gómez');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(2, DATE '2024-03-17', 1, 0, NULL, 'Supervisor Pérez');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(3, DATE '2024-03-17', 1, 0, 'Reponer esparadrapo', 'Supervisor López');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(4, DATE '2024-03-17', 1, 0, NULL, 'Supervisor Martínez');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(5, DATE '2024-03-17', 1, 0, NULL, 'Supervisor Rodríguez');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(6, DATE '2024-03-17', 1, 0, 'Todo en orden', 'Supervisor Fernández');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(7, DATE '2024-03-17', 0, 0, 'Faltan vendas, vuelo cancelado', 'Supervisor García');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(8, DATE '2024-03-19', 1, 0, 'Revisado antes de reprogramación', 'Supervisor Díaz');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(9, DATE '2024-03-19', 1, 0, NULL, 'Supervisor Castro');
INSERT INTO botiquines_vuelo (id_vuelo, fecha_verificacion, contenido_completo, medicamentos_caducados, observaciones, verificado_por) VALUES
(10, DATE '2024-03-19', 1, 0, NULL, 'Supervisor Vargas');

-- =====================================================
-- MÓDULO 11: SEGURIDAD AEROPORTUARIA (5 TABLAS)
-- =====================================================

-- Tabla 11.1: seguridad_controles (se omite id_control)
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('MAD', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'RAYOS_X', 350, 2, 'Supervisor Gómez', 'Mañana sin incidencias graves');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('MAD', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'RAYOS_X', 420, 3, 'Supervisor Pérez', 'Incidencias menores');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('BOG', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'RAYOS_X', 280, 1, 'Supervisor Rodríguez', 'Un decomiso de líquidos');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('BOG', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'REVISION_MANUAL', 45, 0, 'Supervisor López', 'Revisiones aleatorias');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('JFK', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 04:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'RAYOS_X', 550, 5, 'Supervisor Smith', 'Varios objetos punzantes');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('JFK', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'CANES', 120, 0, 'Supervisor Johnson', 'Dogs sin novedad');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('CDG', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'RAYOS_X', 390, 1, 'Supervisor Dubois', 'Incidente de documentación');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('MEX', DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'RAYOS_X', 310, 0, 'Supervisor Fernández', 'Mañana tranquila');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('GRU', DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DOCUMENTOS', 250, 0, 'Supervisor Silva', 'Todo correcto');
INSERT INTO seguridad_controles (codigo_aeropuerto, fecha_control, hora_control, tipo_control, numero_pasajeros_revisados, numero_incidencias, supervisor, observaciones) VALUES
('LAX', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'RAYOS_X', 480, 1, 'Supervisor Williams', 'Incendio en la playa, humo en terminal');

-- Tabla 11.2: objetos_decomisados (se omite id_decomiso)
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(1, 5, 'Líquidos', 'Botella de agua 500ml', 1, 'Exceso de líquidos', 'Destruido', TO_TIMESTAMP('2024-03-18 06:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente García');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(1, NULL, 'Punzante', 'Tijeras de uñas', 1, 'Objeto punzante', 'Depósito', TO_TIMESTAMP('2024-03-18 07:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente García');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(3, 2, 'Líquidos', 'Perfume 100ml', 1, 'Excede tamaño', 'Depósito', TO_TIMESTAMP('2024-03-18 05:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente Martínez');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(5, NULL, 'Peligroso', 'Encendedor', 1, 'No permitido', 'Destruido', TO_TIMESTAMP('2024-03-18 04:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente Davis');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(5, 6, 'Líquidos', 'Gel de baño 200ml', 2, 'Excede tamaño', 'Depósito', TO_TIMESTAMP('2024-03-18 05:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente Miller');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(7, 8, 'Documento', 'Pasaporte falso', 1, 'Falsificación', 'Incautado por PAF', TO_TIMESTAMP('2024-03-18 07:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'Capitaine Dubois');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(2, 1, 'Electrónico', 'Power bank', 1, 'Debe ir en cabina', 'Devuelto', TO_TIMESTAMP('2024-03-18 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente López');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(10, 9, 'Peligroso', 'Encendedor', 1, 'No permitido', 'Destruido', TO_TIMESTAMP('2024-03-18 18:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente Taylor');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(8, NULL, 'Líquidos', 'Agua bendita 200ml', 1, 'Excede tamaño', 'Depósito', TO_TIMESTAMP('2024-03-20 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente Hernández');
INSERT INTO objetos_decomisados (id_control, id_pasajero, tipo_objeto, descripcion, cantidad, motivo_decomiso, destino_final, fecha_registro, registrado_por) VALUES
(9, NULL, 'Punzante', 'Navaja', 1, 'Objeto prohibido', 'Depósito policial', TO_TIMESTAMP('2024-03-19 19:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Agente Costa');

-- Tabla 11.3: visitas_seguridad (se omite id_visita)
INSERT INTO visitas_seguridad (codigo_aeropuerto, fecha_visita, hora_entrada, hora_salida, nombre_visitante, tipo_documento, numero_documento, empresa, motivo_visita, persona_autoriza, area_visitada, escort_requerido, escort_asignado) VALUES
('MAD', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Roberto Sánchez', 'DNI', '11223344A', 'Inditex', 'Revisión de tiendas', 'Ana García', 'Zona comercial', 0, NULL);
INSERT INTO visitas_seguridad (codigo_aeropuerto, fecha_visita, hora_entrada, hora_salida, nombre_visitante, tipo_documento, numero_documento, empresa, motivo_visita, persona_autoriza, area_visitada, escort_requerido, escort_asignado) VALUES
('MAD', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Elena Gómez', 'DNI', '22334455B', 'AENA', 'Inspección técnica', 'Carlos Rodríguez', 'Pistas', 1, 'Juan Pérez');
INSERT INTO visitas_seguridad (codigo_aeropuerto, fecha_visita, hora_entrada, hora_salida, nombre_visitante, tipo_documento, numero_documento, empresa, motivo_visita, persona_autoriza, area_visitada, escort_requerido, escort_asignado) VALUES
('BOG', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Peter Johnson', 'PASAPORTE', 'USA998877', 'Boeing', 'Mantenimiento', 'Juan Martínez', 'Hangar', 1, 'Luis Castro');
INSERT INTO visitas_seguridad (codigo_aeropuerto, fecha_visita, hora_entrada, hora_salida, nombre_visitante, tipo_documento, numero_documento, empresa, motivo_visita, persona_autoriza, area_visitada, escort_requerido, escort_asignado) VALUES
('JFK', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Michael Chen', 'PASAPORTE', 'CAN445566', 'Air Canada', 'Auditoría', 'John Smith', 'Terminal 1', 0, NULL);
INSERT INTO visitas_seguridad (codigo_aeropuerto, fecha_visita, hora_entrada, hora_salida, nombre_visitante, tipo_documento, numero_documento, empresa, motivo_visita, persona_autoriza, area_visitada, escort_requerido, escort_asignado) VALUES
('CDG', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Marie Lambert', 'PASAPORTE', 'FRA334455', 'Airbus', 'Entrega de repuestos', 'Pierre Dubois', 'Zona de carga', 1, 'Jean Moreau');

-- Tabla 11.4: alertas_seguridad (se omite id_alerta)
INSERT INTO alertas_seguridad (codigo_aeropuerto, nivel_alerta, fecha_inicio, fecha_fin, motivo, medidas_adicionales, activa, emitida_por) VALUES
('MAD', 'VERDE', TO_TIMESTAMP('2024-03-18 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 23:59:00', 'YYYY-MM-DD HH24:MI:SS'), 'Normalidad', 'Ninguna', 0, 'AENA');
INSERT INTO alertas_seguridad (codigo_aeropuerto, nivel_alerta, fecha_inicio, fecha_fin, motivo, medidas_adicionales, activa, emitida_por) VALUES
('JFK', 'AMARILLO', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Manifestación cerca del aeropuerto', 'Refuerzo de seguridad en accesos', 0, 'Port Authority');
INSERT INTO alertas_seguridad (codigo_aeropuerto, nivel_alerta, fecha_inicio, fecha_fin, motivo, medidas_adicionales, activa, emitida_por) VALUES
('CDG', 'NARANJA', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Amenaza de bomba (falsa)', 'Evacuación parcial de terminal', 0, 'PAF');
INSERT INTO alertas_seguridad (codigo_aeropuerto, nivel_alerta, fecha_inicio, fecha_fin, motivo, medidas_adicionales, activa, emitida_por) VALUES
('LAX', 'AMARILLO', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Humo de incendios forestales', 'Monitoreo de visibilidad', 1, 'LAWA');
INSERT INTO alertas_seguridad (codigo_aeropuerto, nivel_alerta, fecha_inicio, fecha_fin, motivo, medidas_adicionales, activa, emitida_por) VALUES
('MEX', 'VERDE', TO_TIMESTAMP('2024-03-20 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 23:59:00', 'YYYY-MM-DD HH24:MI:SS'), 'Normalidad', 'Ninguna', 0, 'AICM');
INSERT INTO alertas_seguridad (codigo_aeropuerto, nivel_alerta, fecha_inicio, fecha_fin, motivo, medidas_adicionales, activa, emitida_por) VALUES
('BOG', 'ROJO', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Emergencia médica en sala', 'Acceso restringido a servicios médicos', 0, 'El Dorado');

-- Tabla 11.5: accesos_areas_restringidas (se omite id_acceso)
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(1, 'Pista principal', TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'ENTRADA', 'TARJETA', 1, NULL);
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(1, 'Pista principal', TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'SALIDA', 'TARJETA', 1, NULL);
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(2, 'Torre de control', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'ENTRADA', 'HUELLA', 1, NULL);
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(2, 'Torre de control', TO_TIMESTAMP('2024-03-18 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'SALIDA', 'HUELLA', 1, NULL);
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(3, 'Zona de carga', TO_TIMESTAMP('2024-03-18 10:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'ENTRADA', 'CODIGO', 1, NULL);
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(3, 'Zona de carga', TO_TIMESTAMP('2024-03-18 11:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'SALIDA', 'CODIGO', 1, NULL);
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(4, 'Hangar mantenimiento', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'ENTRADA', 'TARJETA', 1, NULL);
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(4, 'Hangar mantenimiento', TO_TIMESTAMP('2024-03-18 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'SALIDA', 'TARJETA', 1, NULL);
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(5, 'Pista principal', TO_TIMESTAMP('2024-03-18 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'ENTRADA', 'HUELLA', 1, 'Acceso para vuelo UA101');
INSERT INTO accesos_areas_restringidas (id_empleado, area_acceso, fecha_hora_acceso, tipo_acceso, metodo_autenticacion, autorizado, observaciones) VALUES
(5, 'Pista principal', TO_TIMESTAMP('2024-03-18 21:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'SALIDA', 'HUELLA', 1, NULL);

-- =====================================================
-- MÓDULO 12: OBJETOS PERDIDOS (5 TABLAS)
-- =====================================================

-- Tabla 12.1: objetos_perdidos (se omite id_objeto)
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Mochila negra', 'EQUIPAJE', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'VUELO', 'Compartimento superior fila 12', 1, 'MAD', 'Negro', 'Samsonite', 'Lite-Shock', 120.00, 'Tripulación', 'Oficina objetos perdidos T4', 'ENCONTRADO', NULL, NULL, 'Etiqueta con nombre A. Fernández');
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Teléfono móvil', 'ELECTRONICA', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 12:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'SALA_ESPERA', 'Zona de asientos puerta A1', NULL, 'MAD', 'Negro', 'Apple', 'iPhone 15', 800.00, 'Personal limpieza', 'Oficina objetos perdidos', 'EN_PROCESO', NULL, NULL, 'Contraseña requerida');
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Gafas de sol', 'ACCESORIO', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'RESTAURANTE', 'Starbucks', NULL, 'BOG', 'Negro', 'Ray-Ban', 'Aviator', 150.00, 'Mesero', 'Oficina objetos perdidos', 'ENCONTRADO', NULL, NULL, NULL);
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Pasaporte', 'DOCUMENTO', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 16:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'AEROPUERTO', 'Mostrador facturación Delta', NULL, 'JFK', 'Rojo', NULL, 'US Passport', 0.00, 'Agente', 'Oficina de policía', 'ENCONTRADO', NULL, NULL, 'Pasaporte de Michael Johnson');
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Tablet', 'ELECTRONICA', DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 08:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'VUELO', 'Bolso asiento 22F', 6, 'CDG', 'Gris', 'Apple', 'iPad Pro', 900.00, 'Tripulación', 'Oficina objetos perdidos', 'ENTREGADO', DATE '2024-03-20', 8, 'Entregado a Marie Bernard');
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Chaqueta', 'ROPA', DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'VUELO', 'Compartimento superior fila 3', 10, 'MAD', 'Azul', 'Zara', 'Plumas', 80.00, 'Tripulación', 'Oficina objetos perdidos', 'ENCONTRADO', NULL, NULL, 'Sin etiqueta');
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Cartera', 'ACCESORIO', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 13:10:00', 'YYYY-MM-DD HH24:MI:SS'), 'BAÑOS', 'Baño caballeros T1', NULL, 'BCN', 'Marrón', 'Loewe', 'Puzzle', 450.00, 'Mantenimiento', 'Oficina objetos perdidos', 'ENCONTRADO', NULL, NULL, 'Contiene 200€');
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Libro', 'OTROS', DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 11:50:00', 'YYYY-MM-DD HH24:MI:SS'), 'SALA_ESPERA', 'Puerta 1', NULL, 'BOG', 'Verde', NULL, 'Cien años de soledad', 25.00, 'Pasajero', 'Oficina objetos perdidos', 'ENCONTRADO', NULL, NULL, NULL);
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Auriculares', 'ELECTRONICA', DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 22:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'VUELO', 'Asiento 1A', 5, 'LAX', 'Blanco', 'Apple', 'AirPods Max', 550.00, 'Tripulación', 'Oficina objetos perdidos', 'ENTREGADO', DATE '2024-03-19', 9, 'Entregado a David Brown');
INSERT INTO objetos_perdidos (descripcion, categoria_objeto, fecha_reporte, hora_reporte, lugar_encontrado, ubicacion_detallada, id_vuelo, codigo_aeropuerto, color, marca, modelo, valor_estimado, encontrado_por, ubicacion_actual, estado, fecha_entrega, id_pasajero_entrega, observaciones) VALUES
('Maleta pequeña', 'EQUIPAJE', DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'AEROPUERTO', 'Cinta recogida equipajes', 10, 'MAD', 'Rosa', 'Rimowa', 'Essential', 600.00, 'Personal', 'Oficina objetos perdidos', 'ENCONTRADO', NULL, NULL, 'Sin reclamar');

-- Tabla 12.2: categorias_objetos (se omite id_categoria)
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('EQUIPAJE', 'Maletas, mochilas, bolsos', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('ELECTRONICA', 'Móviles, tablets, portátiles, auriculares', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('DOCUMENTO', 'Pasaportes, DNI, tarjetas', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('ROPA', 'Prendas de vestir', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('ACCESORIO', 'Gafas, joyas, relojes', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('LLAVES', 'Llaveros y llaves', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('JUGUETES', 'Muñecos, juegos', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('BEBE', 'Artículos para bebé', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('DEPORTES', 'Equipo deportivo', 1);
INSERT INTO categorias_objetos (nombre_categoria, descripcion, activo) VALUES ('OTROS', 'Objetos diversos', 1);

-- Tabla 12.3: objetos_seguimiento (se omite id_seguimiento)
INSERT INTO objetos_seguimiento (id_objeto, fecha_movimiento, ubicacion, responsable, accion, observaciones) VALUES
(1, TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Vuelo IB1234', 'Tripulación', 'RECOGIDA', 'Objeto encontrado en vuelo');
INSERT INTO objetos_seguimiento (id_objeto, fecha_movimiento, ubicacion, responsable, accion, observaciones) VALUES
(1, TO_TIMESTAMP('2024-03-18 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Oficina objetos perdidos T4', 'Personal MAD', 'ENTREGA', 'Entregado por tripulación');
INSERT INTO objetos_seguimiento (id_objeto, fecha_movimiento, ubicacion, responsable, accion, observaciones) VALUES
(5, TO_TIMESTAMP('2024-03-19 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Vuelo AF345', 'Tripulación', 'RECOGIDA', 'Encontrado en asiento 22F');
INSERT INTO objetos_seguimiento (id_objeto, fecha_movimiento, ubicacion, responsable, accion, observaciones) VALUES
(5, TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Oficina objetos perdidos CDG', 'Personal CDG', 'ENTREGA', 'Registrado en sistema');
INSERT INTO objetos_seguimiento (id_objeto, fecha_movimiento, ubicacion, responsable, accion, observaciones) VALUES
(5, TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Oficina objetos perdidos CDG', 'Marie Bernard', 'ENTREGADO', 'Recogido por propietario');

-- Tabla 12.4: objetos_entregados (se omite id_entrega)
INSERT INTO objetos_entregados (id_objeto, id_pasajero, fecha_entrega, documento_identificacion, entregado_por, observaciones) VALUES
(5, 8, TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PASAPORTE FRA87654321', 'Agente Dupont', 'Verificado identidad');
INSERT INTO objetos_entregados (id_objeto, id_pasajero, fecha_entrega, documento_identificacion, entregado_por, observaciones) VALUES
(9, 9, TO_TIMESTAMP('2024-03-19 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PASAPORTE GBR12345678', 'Agente Wilson', 'Entregado en LAX');

-- Tabla 12.5: reclamaciones_objetos (se omite id_reclamacion)
INSERT INTO reclamaciones_objetos (id_pasajero, id_objeto, fecha_reclamacion, descripcion_reclamacion, estado, fecha_resolucion, resolucion, resuelto_por) VALUES
(8, 5, TO_TIMESTAMP('2024-03-19 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Olvidé mi iPad en el vuelo AF345', 'APROBADA', TO_TIMESTAMP('2024-03-20 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Objeto coincide con descripción', 'Agente Martín');
INSERT INTO reclamaciones_objetos (id_pasajero, id_objeto, fecha_reclamacion, descripcion_reclamacion, estado, fecha_resolucion, resolucion, resuelto_por) VALUES
(1, 1, TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Mi mochila Samsonite negra', 'PENDIENTE', NULL, NULL, NULL);
INSERT INTO reclamaciones_objetos (id_pasajero, id_objeto, fecha_reclamacion, descripcion_reclamacion, estado, fecha_resolucion, resolucion, resuelto_por) VALUES
(4, 8, TO_TIMESTAMP('2024-03-19 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Mi libro de García Márquez', 'RECHAZADA', TO_TIMESTAMP('2024-03-20 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Descripción no coincide', 'Agente Castro');
INSERT INTO reclamaciones_objetos (id_pasajero, id_objeto, fecha_reclamacion, descripcion_reclamacion, estado, fecha_resolucion, resolucion, resuelto_por) VALUES
(9, 9, TO_TIMESTAMP('2024-03-19 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Mis AirPods Max', 'APROBADA', TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Verificado', 'Agente Taylor');

-- =====================================================
-- MÓDULO 13: ÁREA COMERCIAL (10 TABLAS)
-- =====================================================

-- Tabla 13.1: concesiones_comerciales (se omite id_concesion)
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('MAD', 'Zara', 'TIENDA', 'Inditex', 'A12345678', 'Carlos López', '+34913456701', 'zara.mad@inditex.com', DATE '2023-01-01', DATE '2028-12-31', 15000.00, 'T4', 'L-101', 250, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('MAD', 'Starbucks', 'RESTAURANTE', 'Vips', 'B87654321', 'Ana Gómez', '+34913456702', 'starbucks.mad@vips.com', DATE '2023-06-01', DATE '2026-05-31', 12000.00, 'T4', 'L-102', 120, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('MAD', 'Duty Free', 'DUTY_FREE', 'Dufry', 'C11223344', 'Juan Pérez', '+34913456703', 'dutyfree.mad@dufry.com', DATE '2023-01-01', DATE '2027-12-31', 25000.00, 'T4', 'L-103', 400, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('BOG', 'Juan Valdez', 'RESTAURANTE', 'FNC', '901234567', 'María Rodríguez', '+5712345678', 'juanvaldez.bog@fnc.com', DATE '2023-03-01', DATE '2028-02-29', 8000.00, 'T1', 'L-201', 80, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('BOG', 'Éxito', 'TIENDA', 'Grupo Éxito', '890123456', 'Carlos Castro', '+5713456789', 'exito.bog@exito.com', DATE '2023-05-01', DATE '2028-04-30', 10000.00, 'T1', 'L-202', 200, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('JFK', 'Hudson News', 'TIENDA', 'Hudson Group', 'USA-12345', 'John Smith', '+17185551234', 'hudson.jfk@hudsongroup.com', DATE '2023-01-01', DATE '2025-12-31', 20000.00, 'T1', 'L-301', 150, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('JFK', 'Shake Shack', 'RESTAURANTE', 'SS Group', 'USA-67890', 'Jennifer Davis', '+17185551235', 'shakeshack.jfk@ssgroup.com', DATE '2023-04-01', DATE '2026-03-31', 18000.00, 'T1', 'L-302', 180, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('CDG', 'Hermès', 'TIENDA', 'Hermès', 'FRA-112233', 'Pierre Dubois', '+33187654321', 'hermes.cdg@hermes.com', DATE '2023-02-01', DATE '2028-01-31', 30000.00, 'T2', 'L-401', 120, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('MEX', 'Palacio de Hierro', 'TIENDA', 'Palacio', 'MEX-445566', 'Luisa Fernández', '+525578901234', 'palacio.mex@palacio.com', DATE '2023-03-01', DATE '2027-02-28', 22000.00, 'T1', 'L-501', 300, 1);
INSERT INTO concesiones_comerciales (codigo_aeropuerto, nombre_comercial, tipo_negocio, empresa, ruc, representante, telefono_contacto, email_contacto, fecha_inicio_concesion, fecha_fin_concesion, canon_mensual, ubicacion_terminal, local_numero, area_m2, activo) VALUES
('LAX', 'In-N-Out', 'RESTAURANTE', 'In-N-Out', 'USA-998877', 'Mark Williams', '+13105551234', 'innout.lax@innout.com', DATE '2023-07-01', DATE '2028-06-30', 25000.00, 'T1', 'L-601', 150, 1);

-- Tabla 13.2: tiendas_productos (se omite id_producto)
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(1, 'ZARA-001', 'Camisa básica', 'Camisa de algodón', 'ROPA', 29.95, 'EUR', 50, 10, 21.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(1, 'ZARA-002', 'Vestido negro', 'Vestido casual', 'ROPA', 49.95, 'EUR', 30, 5, 21.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(2, 'SB-001', 'Latte', 'Café con leche', 'BEBIDAS', 4.50, 'EUR', 200, 50, 10.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(2, 'SB-002', 'Sandwich', 'Sandwich vegetal', 'COMIDA', 6.95, 'EUR', 30, 10, 10.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(3, 'DF-001', 'Perfume Chanel', 'Chanel Nº5', 'PERFUMES', 120.00, 'EUR', 20, 5, 21.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(3, 'DF-002', 'Whisky Johnnie Walker', 'Blue Label', 'BEBIDAS', 180.00, 'EUR', 15, 3, 21.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(4, 'JV-001', 'Café molido', 'Café 500g', 'COMIDA', 15.00, 'USD', 80, 20, 19.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(5, 'EX-001', 'Chocolate', 'Chocolate colombiano', 'COMIDA', 8.50, 'USD', 120, 30, 19.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(6, 'HN-001', 'The New York Times', 'Periódico', 'PRENSA', 3.00, 'USD', 50, 10, 0.00, 1);
INSERT INTO tiendas_productos (id_concesion, codigo_producto, nombre_producto, descripcion, categoria, precio, moneda, stock_actual, stock_minimo, iva_aplicable, activo) VALUES
(7, 'SS-001', 'ShackBurger', 'Hamburguesa', 'COMIDA', 8.99, 'USD', 100, 25, 8.00, 1);

-- Tabla 13.3: tiendas_ventas (se omite id_venta)
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(2, TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 5, 'PASAJERO', 11.45, 1.15, 12.60, 'TARJETA_CREDITO', '1234', NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(2, TO_TIMESTAMP('2024-03-18 10:15:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 1, 'PASAJERO', 9.00, 0.90, 9.90, 'TARJETA_DEBITO', '5678', NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(3, TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 1, 'PASAJERO', 300.00, 63.00, 363.00, 'TARJETA_CREDITO', '4321', NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(4, TO_TIMESTAMP('2024-03-18 08:45:00', 'YYYY-MM-DD HH24:MI:SS'), 3, 3, 'PASAJERO', 30.00, 5.70, 35.70, 'EFECTIVO', NULL, NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(5, TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4, 4, 'PASAJERO', 17.00, 3.23, 20.23, 'TARJETA_CREDITO', '8765', NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(7, TO_TIMESTAMP('2024-03-18 07:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, NULL, 'VISITANTE', 17.98, 1.44, 19.42, 'TARJETA_CREDITO', '2468', NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(6, TO_TIMESTAMP('2024-03-18 06:30:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 6, 'PASAJERO', 6.00, 0.00, 6.00, 'EFECTIVO', NULL, NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(10, TO_TIMESTAMP('2024-03-18 19:00:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 9, 'PASAJERO', 17.98, 1.44, 19.42, 'TARJETA_CREDITO', '1357', NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(8, TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 7, 7, 'PASAJERO', 120.00, 25.20, 145.20, 'TARJETA_CREDITO', '5791', NULL);
INSERT INTO tiendas_ventas (id_concesion, fecha_venta, id_reserva, id_pasajero, tipo_cliente, subtotal, impuestos, total, metodo_pago, tarjeta_numero, autorizado_por) VALUES
(9, TO_TIMESTAMP('2024-03-20 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 10, 10, 'PASAJERO', 29.95, 6.29, 36.24, 'TARJETA_CREDITO', '9753', NULL);

-- Tabla 13.4: ventas_detalle (se omite id_detalle)
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(1, 3, 2, 4.50, 0.00, 9.00);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(1, 4, 1, 6.95, 0.00, 6.95);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(2, 3, 2, 4.50, 0.00, 9.00);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(3, 5, 1, 120.00, 0.00, 120.00);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(3, 6, 1, 180.00, 0.00, 180.00);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(4, 7, 2, 15.00, 0.00, 30.00);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(5, 8, 2, 8.50, 0.00, 17.00);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(6, 10, 2, 8.99, 0.00, 17.98);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(7, 9, 2, 3.00, 0.00, 6.00);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(8, 10, 2, 8.99, 0.00, 17.98);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(9, 5, 1, 120.00, 0.00, 120.00);
INSERT INTO ventas_detalle (id_venta, id_producto, cantidad, precio_unitario, descuento_aplicado, subtotal_linea) VALUES
(10, 1, 1, 29.95, 0.00, 29.95);

-- Tabla 13.5: restaurantes_menus (se omite id_menu)
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(2, 'Latte', 'Café espresso con leche', 'BEBIDAS', 4.50, 'EUR', 1, 3, 150, 'Contiene lactosa');
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(2, 'Croissant', 'Croissant de mantequilla', 'DESAYUNO', 3.50, 'EUR', 1, 2, 300, 'Contiene gluten');
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(2, 'Sandwich vegetal', 'Pan integral con vegetales', 'ALMUERZO', 6.95, 'EUR', 1, 8, 450, 'Opción vegetariana');
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(4, 'Café Juan Valdez', 'Café premium colombiano', 'BEBIDAS', 3.50, 'USD', 1, 3, 10, NULL);
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(4, 'Pan de bono', 'Pan de queso colombiano', 'DESAYUNO', 2.50, 'USD', 1, 5, 250, 'Contiene gluten, lactosa');
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(7, 'ShackBurger', 'Hamburguesa clásica', 'COMIDA_RAPIDA', 8.99, 'USD', 1, 10, 550, 'Contiene gluten, lactosa');
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(7, 'Milkshake', 'Batido de vainilla', 'BEBIDAS', 5.99, 'USD', 1, 5, 400, 'Contiene lactosa');
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(10, 'Double-Double', 'Hamburguesa doble', 'COMIDA_RAPIDA', 5.99, 'USD', 1, 8, 600, 'Contiene gluten, lactosa');
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(10, 'Patatas fritas', 'Patatas fritas', 'COMIDA_RAPIDA', 3.99, 'USD', 1, 5, 350, 'Sin gluten');
INSERT INTO restaurantes_menus (id_concesion, nombre_plato, descripcion, categoria_menu, precio, moneda, disponible, tiempo_preparacion_minutos, calorias, restricciones_alimenticias) VALUES
(10, 'Soda', 'Refresco', 'BEBIDAS', 2.50, 'USD', 1, 1, 150, NULL);

-- Tabla 13.6: salones_vip (se omite id_salon)
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('MAD', 'Sala VIP Iberia', 'T4, planta 1', 200, '06:00', '22:00', 'Comida, bebida, duchas, wifi, zona de trabajo', 'Business class o Star Alliance Gold', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('MAD', 'Sala VIP Velázquez', 'T4, planta 2', 150, '05:00', '23:00', 'Comida, bebida, relax, prensa', 'Priority Pass o pago', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('BOG', 'Avianca VIP Lounge', 'T1, segundo piso', 180, '04:00', '22:00', 'Comida, bebida, duchas, sala de juntas', 'Business class o Star Alliance Gold', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('JFK', 'Delta Sky Club', 'T4', 250, '05:00', '23:00', 'Buffet, bar, duchas, sala de conferencias', 'Delta One o SkyTeam Elite', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('JFK', 'American Airlines Admirals Club', 'T8', 220, '05:00', '22:30', 'Comida, bebida, sala de estar', 'Business class o oneworld', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('LHR', 'British Airways Galleries', 'T5', 300, '05:00', '22:30', 'Primera clase, spa, restaurante', 'First class BA', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('CDG', 'Air France Lounge', 'T2E', 200, '06:00', '21:30', 'Comida, bar, zona de descanso', 'Business class AF', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('MEX', 'Salón VIP The Grand', 'T1', 120, '05:00', '22:00', 'Snacks, bebidas, wifi', 'Priority Pass', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('GRU', 'LATAM VIP Lounge', 'T3', 180, '05:00', '23:00', 'Comida, bebida, duchas', 'Business class', 1);
INSERT INTO salones_vip (codigo_aeropuerto, nombre_salon, ubicacion, capacidad, horario_apertura, horario_cierre, servicios, requisitos_acceso, activo) VALUES
('LAX', 'Star Alliance Lounge', 'TBIT', 280, '05:00', '23:30', 'Buffet, bar, terraza, duchas', 'Star Alliance Gold', 1);

-- Tabla 13.7: salones_accesos (se omite id_acceso)
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(1, 5, 3, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 07:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRIMERA_CLASE', 0.00, 'Agente');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(2, 1, 1, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'PAGO', 35.00, 'Recepcionista');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(3, 3, 2, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRIMERA_CLASE', 0.00, 'Agente');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(4, 7, 4, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'CLUB', 0.00, 'Delta');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(7, 8, 6, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 07:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRIMERA_CLASE', 0.00, 'AF');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(10, 9, 5, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 19:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRIMERA_CLASE', 0.00, 'Agente');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(8, 10, 9, DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PAGO', 40.00, 'Recepcionista');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(1, 2, 2, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'INVITACION', 0.00, 'Iberia');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(5, 6, 3, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 06:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRIMERA_CLASE', 0.00, 'AA');
INSERT INTO salones_accesos (id_salon, id_pasajero, id_vuelo, fecha_acceso, hora_entrada, hora_salida, tipo_acceso, costo, autorizado_por) VALUES
(6, 9, 5, DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'CLUB', 0.00, 'BA');

-- Tabla 13.8: estacionamiento (se omite id_estacionamiento)
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('MAD', 'A-001', 'AUTOMOVIL', 'T4', 3.50, 25.00, 1, NULL);
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('MAD', 'A-002', 'AUTOMOVIL', 'T4', 3.50, 25.00, 1, NULL);
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('MAD', 'M-001', 'MOTOCICLETA', 'T4', 1.50, 10.00, 1, NULL);
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('MAD', 'D-001', 'DISCAPACITADO', 'T4', 2.50, 18.00, 1, 'Plaza reservada');
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('BOG', 'P1-01', 'AUTOMOVIL', 'T1', 4000, 25000, 1, 'Pesos colombianos');
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('BOG', 'P1-02', 'AUTOMOVIL', 'T1', 4000, 25000, 0, 'Ocupado');
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('JFK', 'G-101', 'AUTOMOVIL', 'T1', 8.00, 55.00, 1, NULL);
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('JFK', 'G-102', 'ELECTRICO', 'T1', 6.00, 45.00, 1, 'Con cargador');
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('LAX', 'P-201', 'AUTOMOVIL', 'T1', 6.00, 40.00, 1, NULL);
INSERT INTO estacionamiento (codigo_aeropuerto, numero_espacio, tipo_espacio, terminal_cercana, tarifa_por_hora, tarifa_diaria, disponible, observaciones) VALUES
('CDG', 'C-301', 'AUTOMOVIL', 'T2', 5.00, 35.00, 1, NULL);

-- Tabla 13.9: estacionamiento_registro (se omite id_registro)
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(1, 1, 1, '1234ABC', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 6.5, 3.50, 22.75, 1, 'TARJETA');
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(2, 3, 1, '5678DEF', TO_TIMESTAMP('2024-03-18 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), 8.0, 25.00, 25.00, 1, 'EFECTIVO');
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(6, 2, 2, 'ABC123', TO_TIMESTAMP('2024-03-18 04:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, NULL, 25000, NULL, 0, NULL);
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(7, 5, 3, 'XYZ789', TO_TIMESTAMP('2024-03-18 04:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 4.0, 8.00, 32.00, 1, 'TARJETA');
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(8, 7, 4, 'EV001', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), 10.0, 6.00, 60.00, 1, 'APP');
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(9, 9, 5, 'CA9876', TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 00:00:00', 'YYYY-MM-DD HH24:MI:SS'), 8.0, 40.00, 40.00, 1, 'TARJETA');
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(10, 8, 6, 'FR-123-AB', TO_TIMESTAMP('2024-03-18 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4.0, 5.00, 20.00, 1, 'EFECTIVO');
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(4, 4, 2, 'DIS-001', TO_TIMESTAMP('2024-03-18 07:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 3.0, 2.50, 7.50, 1, 'EFECTIVO');
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(3, 10, 9, 'MOT-01', TO_TIMESTAMP('2024-03-20 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), 5.0, 1.50, 7.50, 1, 'EFECTIVO');
INSERT INTO estacionamiento_registro (id_espacio, id_pasajero, id_vuelo, placa_vehiculo, fecha_entrada, fecha_salida, tiempo_total_horas, tarifa_aplicada, total_pagar, estado_pago, metodo_pago) VALUES
(5, NULL, NULL, 'XYZ-456', TO_TIMESTAMP('2024-03-20 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, NULL, 25000, NULL, 0, NULL);

-- Tabla 13.10: publicidad (se omite id_publicidad)
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('MAD', 'T4 - Pasillo central', 'VALLA', 'Iberia', DATE '2024-01-01', DATE '2024-06-30', 50000.00, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('MAD', 'T4 - Puertas A', 'PANTALLA_DIGITAL', 'Coca-Cola', DATE '2024-03-01', DATE '2024-09-01', 30000.00, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('BOG', 'T1 - Zona de check-in', 'VALLA', 'Avianca', DATE '2024-01-01', DATE '2024-12-31', 45000000, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('BOG', 'T1 - Puertas', 'BANNER', 'Bavaria', DATE '2024-02-01', DATE '2024-05-31', 15000000, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('JFK', 'T1 - Pasillo', 'VALLA', 'American Airlines', DATE '2024-01-01', DATE '2024-06-30', 75000.00, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('JFK', 'T1 - Pantallas', 'PANTALLA_DIGITAL', 'Samsung', DATE '2024-03-15', DATE '2024-09-15', 45000.00, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('CDG', 'T2 - Zona comercial', 'VALLA', 'Air France', DATE '2024-01-01', DATE '2024-12-31', 65000.00, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('MEX', 'T1 - Pasillo', 'BANNER', 'Telcel', DATE '2024-04-01', DATE '2024-07-31', 350000.00, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('LAX', 'T1 - Puertas', 'PANTALLA_DIGITAL', 'United', DATE '2024-02-01', DATE '2024-08-31', 55000.00, 1);
INSERT INTO publicidad (codigo_aeropuerto, ubicacion, tipo_publicidad, empresa_anunciante, fecha_inicio, fecha_fin, costo, activo) VALUES
('GRU', 'T3 - Zona de embarque', 'VALLA', 'LATAM', DATE '2024-01-01', DATE '2024-06-30', 200000.00, 1);

-- =====================================================
-- MÓDULO 14: SERVICIOS AL PASAJERO (7 TABLAS)
-- =====================================================

-- Tabla 14.1: transporte_terrestre (se omite id_transporte)
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('MAD', 'TAXI', 'Radio Taxi Madrid', '+34913456789', '30-40€ a centro', '24h', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('MAD', 'BUS', 'EMT Madrid', '+34901234567', '5€', '05:00-23:30', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('MAD', 'METRO', 'Metro Madrid', '+34901234568', '4.50€', '06:00-01:30', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('BOG', 'TAXI', 'Taxi El Dorado', '+5712345678', '40.000-50.000 COP', '24h', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('BOG', 'BUS', 'TransMilenio', '+5712345679', '2.500 COP', '04:30-23:00', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('JFK', 'TAXI', 'NYC Taxi', '+12125551234', '50-70 USD a Manhattan', '24h', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('JFK', 'BUS', 'MTA', '+17185551234', '7 USD', '24h', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('CDG', 'RENTA_AUTO', 'Hertz', '+33123456789', 'desde 50€/día', '07:00-23:00', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('MEX', 'SHUTTLE', 'Shuttle CDMX', '+525512345678', '150 MXN', '24h', 1);
INSERT INTO transporte_terrestre (codigo_aeropuerto, tipo_transporte, empresa, telefono_contacto, tarifa_estimada, horario_operacion, activo) VALUES
('LAX', 'SHUTTLE', 'LAX Shuttle', '+13105551234', '10 USD', '24h', 1);

-- Tabla 14.2: hoteles_cercanos (se omite id_hotel)
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('MAD', 'Hotel Barajas', '3*', 'Avda. de Logroño 305', 1.5, '+34913456790', 'reservas@hotelbarajas.com', 'www.hotelbarajas.com', 85.00, 1, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('MAD', 'NH Barajas', '4*', 'Calle de Alcalá 450', 2.0, '+34913456791', 'nh.barajas@nh-hotels.com', 'www.nh-hotels.com', 120.00, 1, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('BOG', 'Hilton Bogotá', '5*', 'Av. El Dorado 123', 3.0, '+5712345670', 'reservas.bog@hilton.com', 'www.hilton.com', 250.00, 1, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('BOG', 'Hotel Habitel', '3*', 'Calle 26 #95-50', 1.0, '+5712345671', 'info@habitel.com', 'www.habitel.com', 70.00, 1, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('JFK', 'TWA Hotel', '4*', 'JFK Airport', 0.1, '+17185551236', 'info@twahotel.com', 'www.twahotel.com', 350.00, 0, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('JFK', 'Hilton JFK', '4*', '144-02 135th Ave', 1.5, '+17185551237', 'jfk@hilton.com', 'www.hiltonjfk.com', 220.00, 1, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('CDG', 'Hilton CDG', '4*', 'Roissypôle', 0.5, '+33123456790', 'cdg@hilton.com', 'www.hiltoncdg.com', 180.00, 1, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('MEX', 'Camino Real', '5*', 'Av. Puerto México 123', 2.0, '+525512345679', 'camino.real@mex.com', 'www.caminoreal.com', 200.00, 1, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('LAX', 'Sheraton LAX', '4*', '6101 W Century Blvd', 0.3, '+13105551238', 'sheraton.lax@sheraton.com', 'www.sheratonlax.com', 180.00, 1, 1);
INSERT INTO hoteles_cercanos (codigo_aeropuerto, nombre_hotel, categoria, direccion, distancia_km, telefono, email, website, tarifa_noche_desde, tiene_shuttle, activo) VALUES
('GRU', 'Hotel Pullman', '4*', 'Av. das Nações Unidas', 2.0, '+551123456790', 'pullman.gru@pullman.com', 'www.pullman.com', 200.00, 1, 1);

-- Tabla 14.3: servicios_aeropuerto (se omite id_servicio)
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('MAD', 'Banco Santander', 'BANCO', 'T4 - Planta 0', '08:30', '14:30', '+34913456792', 0, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('MAD', 'Farmacia', 'FARMACIA', 'T4 - Planta 1', '07:00', '22:00', '+34913456793', 0, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('MAD', 'Punto de Información', 'INFORMACION', 'T4 - Llegadas', '06:00', '23:00', '+34913456794', 0, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('BOG', 'Primeros Auxilios', 'PRIMEROS_AUXILIOS', 'T1 - Piso 2', '24h', '24h', '+5712345672', 1, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('JFK', 'Migración', 'MIGRACION', 'T1 - Llegadas', '24h', '24h', '+17185551239', 1, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('JFK', 'Aduana', 'ADUANA', 'T1 - Llegadas', '24h', '24h', '+17185551240', 1, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('CDG', 'Wifi Gratis', 'WIFI', 'Todo el aeropuerto', '24h', '24h', NULL, 1, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('MEX', 'Cajero BBVA', 'CAJERO', 'T1 - Pasillo', '24h', '24h', NULL, 1, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('LAX', 'Boletería', 'BOLETERIA', 'T1 - Check-in', '04:00', '23:00', '+13105551241', 0, 1);
INSERT INTO servicios_aeropuerto (codigo_aeropuerto, nombre_servicio, tipo_servicio, ubicacion, horario_apertura, horario_cierre, telefono_contacto, disponible_24h, activo) VALUES
('GRU', 'Información', 'INFORMACION', 'T3 - Llegadas', '24h', '24h', '+551123456791', 1, 1);

-- Tabla 14.4: quejas_sugerencias (se omite id_queja)
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(7, 4, 'QUEJA', TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRESENCIAL', 'Mala atención en cancelación de vuelo', 'ATENCION_CLIENTE', 'RESUELTO', TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Se ofreció compensación', 4);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(1, 1, 'SUGERENCIA', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'EMAIL', 'Mejorar la comida a bordo', 'CATERING', 'RECIBIDO', NULL, NULL, NULL);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(5, 3, 'FELICITACION', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'WEB', 'Excelente atención de la tripulación', 'TRIPULACION', 'RESUELTO', TO_TIMESTAMP('2024-03-19 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Gracias por su comentario', 5);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(8, 6, 'RECLAMO', TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRESENCIAL', 'Perdí mi iPad y quiero reclamarlo', 'OBJETOS_PERDIDOS', 'RESUELTO', TO_TIMESTAMP('2024-03-20 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Objeto localizado y entregado', 5);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(2, 2, 'QUEJA', TO_TIMESTAMP('2024-03-18 17:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'APP', 'El check-in online no funcionaba', 'SISTEMAS', 'EN_PROCESO', NULL, NULL, NULL);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(3, 1, 'SUGERENCIA', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'WEB', 'Poner más pantallas en la sala de espera', 'INFRAESTRUCTURA', 'RECIBIDO', NULL, NULL, NULL);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(9, 5, 'FELICITACION', TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'EMAIL', 'Muy cómodo el asiento de primera clase', 'SERVICIOS', 'RESUELTO', TO_TIMESTAMP('2024-03-20 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Gracias por volar con nosotros', 5);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(10, 10, 'QUEJA', TO_TIMESTAMP('2024-03-20 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRESENCIAL', 'El equipaje especial no llegó', 'EQUIPAJE', 'RECIBIDO', NULL, NULL, NULL);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(4, 2, 'RECLAMO', TO_TIMESTAMP('2024-03-19 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'TELEFONICO', 'Me cobraron dos veces el mismo vuelo', 'FINANZAS', 'EN_PROCESO', NULL, NULL, NULL);
INSERT INTO quejas_sugerencias (id_pasajero, id_vuelo, tipo_contacto, fecha_contacto, medio_recepcion, descripcion, area_relacionada, estado, fecha_respuesta, respuesta, satisfaccion_respuesta) VALUES
(6, 3, 'SUGERENCIA', TO_TIMESTAMP('2024-03-18 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'APP', 'Mejorar el sistema de entretenimiento', 'SERVICIOS', 'RECIBIDO', NULL, NULL, NULL);

-- Tabla 14.5: encuestas_satisfaccion (se omite id_encuesta)
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(1, 1, TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4, 5, 4, 4, 5, 4, 4, 'Bien en general, retraso menor', 1);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(2, 2, TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 5, 5, 5, 4, 5, 5, 5, 'Excelente viaje', 1);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(3, 1, TO_TIMESTAMP('2024-03-19 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 3, 4, 3, 3, 4, 4, 3, 'Asiento incómodo', 1);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(4, 2, TO_TIMESTAMP('2024-03-19 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2, 3, 2, 3, 3, 4, 1, 'Perdieron mi maleta', 0);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(5, 3, TO_TIMESTAMP('2024-03-19 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 5, 5, 5, 5, 5, 5, 5, 'Todo perfecto', 1);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(6, 3, TO_TIMESTAMP('2024-03-19 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4, 4, 4, 4, 4, 4, 4, 'Bien', 1);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(7, 4, TO_TIMESTAMP('2024-03-19 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 2, 1, 1, 2, 1, 1, 'Vuelo cancelado, mala gestión', 0);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(8, 6, TO_TIMESTAMP('2024-03-19 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4, 4, 4, 4, 4, 5, 4, 'Buen servicio', 1);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(9, 5, TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 5, 5, 5, 5, 5, 5, 5, 'Excelente vuelo largo', 1);
INSERT INTO encuestas_satisfaccion (id_pasajero, id_vuelo, fecha_encuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_comodidad, puntuacion_limpieza, puntuacion_atencion, puntuacion_equipaje, comentarios, recomienda) VALUES
(10, 10, TO_TIMESTAMP('2024-03-21 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4, 5, 4, 4, 5, 4, 3, 'Equipaje especial llegó bien', 1);

-- Tabla 14.6: programa_lealtad (se omite id_lealtad)
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(1, 'PLATA', 25000, 15000, DATE '2022-01-01', DATE '2024-03-01', 45000, 'Acceso sala VIP, equipaje extra', 'IB-12345-01', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(2, 'BRONCE', 5000, 2000, DATE '2023-06-01', DATE '2024-02-15', 8500, 'Embarque preferente', 'VY-67890-02', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(3, 'ORO', 75000, 50000, DATE '2021-03-01', DATE '2024-03-10', 125000, 'Sala VIP, upgrades, equipaje extra', 'AV-111213-03', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(4, 'PLATA', 45000, 30000, DATE '2022-09-01', DATE '2024-02-28', 78000, 'Sala VIP', 'AV-141516-04', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(5, 'PLATINO', 120000, 80000, DATE '2019-05-01', DATE '2024-03-15', 250000, 'Todos los beneficios', 'AA-171819-05', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(6, 'BRONCE', 8000, 4000, DATE '2023-11-01', DATE '2024-01-20', 15000, 'Embarque preferente', 'DL-202122-06', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(7, 'ORO', 90000, 60000, DATE '2020-08-01', DATE '2024-03-05', 160000, 'Sala VIP, upgrades', 'AF-232425-07', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(8, 'PLATA', 35000, 20000, DATE '2022-12-01', DATE '2024-02-10', 60000, 'Sala VIP', 'AF-262728-08', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(9, 'PLATA', 65000, 40000, DATE '2021-10-01', DATE '2024-03-12', 110000, 'Sala VIP, equipaje extra', 'BA-293031-09', 1);
INSERT INTO programa_lealtad (id_pasajero, nivel_membresia, puntos_acumulados, puntos_canjeables, fecha_ingreso, fecha_ultima_actividad, millas_acumuladas, beneficios_activos, tarjeta_numero, activo) VALUES
(10, 'BRONCE', 3000, 1000, DATE '2023-09-01', DATE '2024-01-05', 5000, 'Ninguno', 'BA-323334-10', 1);

-- Tabla 14.7: atencion_especial (se omite id_atencion)
INSERT INTO atencion_especial (id_pasajero, id_reserva, tipo_atencion, fecha_solicitud, fecha_atencion, asistente_asignado, observaciones) VALUES
(2, 3, 'SILLA_RUEDAS', TO_TIMESTAMP('2024-02-10 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Pedro Gómez', 'Asistencia en mostrador y embarque');
INSERT INTO atencion_especial (id_pasajero, id_reserva, tipo_atencion, fecha_solicitud, fecha_atencion, asistente_asignado, observaciones) VALUES
(4, 4, 'ASISTENCIA_VISUAL', TO_TIMESTAMP('2024-02-12 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Ana López', 'Acompañamiento hasta la puerta');
INSERT INTO atencion_especial (id_pasajero, id_reserva, tipo_atencion, fecha_solicitud, fecha_atencion, asistente_asignado, observaciones) VALUES
(5, 5, 'SILLA_RUEDAS', TO_TIMESTAMP('2024-03-01 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 06:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Carlos Ruiz', 'Asistencia en conexión');
INSERT INTO atencion_especial (id_pasajero, id_reserva, tipo_atencion, fecha_solicitud, fecha_atencion, asistente_asignado, observaciones) VALUES
(8, 8, 'ASISTENCIA_AUDITIVA', TO_TIMESTAMP('2024-02-25 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 07:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'Sophie Martin', 'Intérprete de lenguaje de señas');
INSERT INTO atencion_especial (id_pasajero, id_reserva, tipo_atencion, fecha_solicitud, fecha_atencion, asistente_asignado, observaciones) VALUES
(9, 9, 'SILLA_RUEDAS', TO_TIMESTAMP('2024-02-05 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'James Wilson', 'Asistencia en vuelo largo');

-- =====================================================
-- MÓDULO 15: RECURSOS HUMANOS (10 TABLAS)
-- NOTA: Ya insertamos empleados, ahora el resto
-- =====================================================

-- Tabla 15.2: departamentos (depende de empleados para gerente_id) (se omite id_departamento)
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Operaciones', 'Gestión de vuelos y operaciones', 'Terminal T4', 5000000.00, 1, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Mantenimiento', 'Mantenimiento de aeronaves', 'Hangar', 3500000.00, 2, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Recursos Humanos', 'Gestión de personal', 'Oficinas', 1200000.00, 3, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Finanzas', 'Gestión económica', 'Oficinas', 2000000.00, 4, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Seguridad', 'Seguridad aeroportuaria', 'Terminal', 2500000.00, 5, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Comercial', 'Gestión de tiendas y concesiones', 'Zona comercial', 1800000.00, 6, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Atención al Cliente', 'Servicio al pasajero', 'Terminal', 900000.00, 7, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Tecnología', 'Sistemas informáticos', 'Oficinas', 1500000.00, 8, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Legal', 'Asesoría jurídica', 'Oficinas', 800000.00, 9, 1);
INSERT INTO departamentos (nombre_departamento, descripcion, ubicacion, presupuesto_anual, gerente_id, activo) VALUES
('Calidad', 'Control de calidad', 'Oficinas', 600000.00, 10, 1);

-- Tabla 15.3: puestos_trabajo (se omite id_puesto)
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Gerente de Operaciones', 1, 5, 60000.00, 90000.00, 'Supervisar operaciones diarias', 'Experiencia 10 años', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Supervisor de Mantenimiento', 2, 4, 45000.00, 65000.00, 'Coordinar mantenimiento', 'Licencia FAA', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Técnico de Mantenimiento', 2, 3, 35000.00, 50000.00, 'Realizar mantenimiento', 'Certificación técnica', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Analista de RRHH', 3, 3, 30000.00, 45000.00, 'Gestión de personal', 'Titulación universitaria', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Agente de Seguridad', 5, 2, 25000.00, 35000.00, 'Control de accesos', 'Formación específica', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Comercial', 6, 3, 28000.00, 40000.00, 'Gestión de tiendas', 'Experiencia en retail', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Agente de Atención', 7, 2, 22000.00, 32000.00, 'Atención al pasajero', 'Idiomas', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Programador', 8, 3, 40000.00, 60000.00, 'Desarrollo de software', 'Titulación informática', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Asesor Legal', 9, 4, 50000.00, 80000.00, 'Asesoramiento jurídico', 'Licenciatura en Derecho', 1);
INSERT INTO puestos_trabajo (nombre_puesto, id_departamento, nivel_jerarquico, salario_minimo, salario_maximo, descripcion_funciones, requisitos, activo) VALUES
('Inspector de Calidad', 10, 3, 35000.00, 50000.00, 'Auditoría de procesos', 'Experiencia en auditoría', 1);

-- Tabla 15.4: empleados_historial (se omite id_historial_empleado)
INSERT INTO empleados_historial (id_empleado, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, motivo, modificado_por) VALUES
(1, DATE '2024-01-15', 'salario_base', '55000.00', '60000.00', 'Aumento anual', 3);
INSERT INTO empleados_historial (id_empleado, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, motivo, modificado_por) VALUES
(2, DATE '2024-02-01', 'cargo', 'Supervisor Técnico', 'Supervisor de Mantenimiento', 'Promoción', 3);
INSERT INTO empleados_historial (id_empleado, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, motivo, modificado_por) VALUES
(3, DATE '2023-12-10', 'departamento', 'Operaciones', 'Recursos Humanos', 'Cambio de área', 3);
INSERT INTO empleados_historial (id_empleado, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, motivo, modificado_por) VALUES
(5, DATE '2024-03-01', 'salario_base', '42000.00', '45000.00', 'Aumento por méritos', 3);
INSERT INTO empleados_historial (id_empleado, fecha_cambio, campo_modificado, valor_anterior, valor_nuevo, motivo, modificado_por) VALUES
(7, DATE '2024-02-15', 'cargo', 'Agente', 'Agente de Atención', 'Reestructuración', 3);

-- Tabla 15.5: asistencias (se omite id_asistencia)
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(1, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ORDINARIA', NULL, 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(2, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ORDINARIA', NULL, 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(3, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ORDINARIA', NULL, 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(4, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 17:30:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ORDINARIA', NULL, 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(5, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 8, 'EXTRA', 'Turno extra', 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(6, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), 8, 'ORDINARIA', NULL, 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(7, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 19:00:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ORDINARIA', NULL, 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(8, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ORDINARIA', NULL, 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(9, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ORDINARIA', NULL, 3);
INSERT INTO asistencias (id_empleado, fecha, hora_entrada, hora_salida, horas_trabajadas, tipo_jornada, observaciones, registrado_por) VALUES
(10, DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 17:15:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 'ORDINARIA', NULL, 3);

-- Tabla 15.6: vacaciones_permisos (se omite id_solicitud)
INSERT INTO vacaciones_permisos (id_empleado, tipo_solicitud, fecha_inicio, fecha_fin, dias_solicitados, motivo, fecha_solicitud, estado, autorizado_por, fecha_autorizacion, observaciones) VALUES
(3, 'VACACIONES', DATE '2024-08-01', DATE '2024-08-15', 15, 'Vacaciones verano', DATE '2024-03-01', 'APROBADO', 3, DATE '2024-03-05', NULL);
INSERT INTO vacaciones_permisos (id_empleado, tipo_solicitud, fecha_inicio, fecha_fin, dias_solicitados, motivo, fecha_solicitud, estado, autorizado_por, fecha_autorizacion, observaciones) VALUES
(5, 'PERMISO', DATE '2024-04-01', DATE '2024-04-01', 1, 'Asunto personal', DATE '2024-03-15', 'APROBADO', 3, DATE '2024-03-16', NULL);
INSERT INTO vacaciones_permisos (id_empleado, tipo_solicitud, fecha_inicio, fecha_fin, dias_solicitados, motivo, fecha_solicitud, estado, autorizado_por, fecha_autorizacion, observaciones) VALUES
(7, 'LICENCIA', DATE '2024-05-20', DATE '2024-06-20', 30, 'Maternidad', DATE '2024-02-01', 'APROBADO', 3, DATE '2024-02-10', NULL);
INSERT INTO vacaciones_permisos (id_empleado, tipo_solicitud, fecha_inicio, fecha_fin, dias_solicitados, motivo, fecha_solicitud, estado, autorizado_por, fecha_autorizacion, observaciones) VALUES
(2, 'VACACIONES', DATE '2024-07-10', DATE '2024-07-24', 15, 'Vacaciones', DATE '2024-03-10', 'PENDIENTE', NULL, NULL, NULL);
INSERT INTO vacaciones_permisos (id_empleado, tipo_solicitud, fecha_inicio, fecha_fin, dias_solicitados, motivo, fecha_solicitud, estado, autorizado_por, fecha_autorizacion, observaciones) VALUES
(9, 'INCAPACIDAD', DATE '2024-03-18', DATE '2024-03-20', 3, 'Gripe', DATE '2024-03-18', 'APROBADO', 3, DATE '2024-03-18', 'Con justificante médico');

-- Tabla 15.7: evaluaciones_desempeno (se omite id_evaluacion)
INSERT INTO evaluaciones_desempeno (id_empleado, fecha_evaluacion, evaluador_id, periodo_evaluado, puntuacion_total, puntuacion_productividad, puntuacion_calidad, puntuacion_asistencia, puntuacion_trabajo_equipo, comentarios, metas_futuras) VALUES
(1, DATE '2024-03-01', 3, '2023-2024', 4.8, 5.0, 4.8, 5.0, 4.5, 'Excelente desempeño', 'Mantener liderazgo');
INSERT INTO evaluaciones_desempeno (id_empleado, fecha_evaluacion, evaluador_id, periodo_evaluado, puntuacion_total, puntuacion_productividad, puntuacion_calidad, puntuacion_asistencia, puntuacion_trabajo_equipo, comentarios, metas_futuras) VALUES
(2, DATE '2024-03-01', 3, '2023-2024', 4.5, 4.8, 4.5, 5.0, 4.0, 'Buen trabajo', 'Mejorar coordinación');
INSERT INTO evaluaciones_desempeno (id_empleado, fecha_evaluacion, evaluador_id, periodo_evaluado, puntuacion_total, puntuacion_productividad, puntuacion_calidad, puntuacion_asistencia, puntuacion_trabajo_equipo, comentarios, metas_futuras) VALUES
(4, DATE '2024-03-01', 3, '2023-2024', 4.0, 4.0, 4.2, 4.5, 3.8, 'Cumple objetivos', 'Formación en liderazgo');
INSERT INTO evaluaciones_desempeno (id_empleado, fecha_evaluacion, evaluador_id, periodo_evaluado, puntuacion_total, puntuacion_productividad, puntuacion_calidad, puntuacion_asistencia, puntuacion_trabajo_equipo, comentarios, metas_futuras) VALUES
(6, DATE '2024-03-01', 3, '2023-2024', 3.5, 3.5, 3.8, 4.0, 3.0, 'Regular, puede mejorar', 'Curso de atención al cliente');
INSERT INTO evaluaciones_desempeno (id_empleado, fecha_evaluacion, evaluador_id, periodo_evaluado, puntuacion_total, puntuacion_productividad, puntuacion_calidad, puntuacion_asistencia, puntuacion_trabajo_equipo, comentarios, metas_futuras) VALUES
(8, DATE '2024-03-01', 3, '2023-2024', 4.7, 5.0, 4.5, 5.0, 4.5, 'Excelente técnico', 'Certificaciones avanzadas');

-- Tabla 15.8: capacitaciones (se omite id_capacitacion)
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Seguridad Operacional', 'Normativas de seguridad', 'SEGURIDAD', 20, 500.00, 'AESA', DATE '2024-04-01', DATE '2024-04-05', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Atención al Cliente Avanzada', 'Mejora de habilidades', 'ATENCION_CLIENTE', 16, 300.00, 'IHK', DATE '2024-05-10', DATE '2024-05-12', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Inglés Técnico', 'Inglés para aviación', 'IDIOMAS', 40, 600.00, 'Cambridge', DATE '2024-06-01', DATE '2024-07-01', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Liderazgo', 'Gestión de equipos', 'LIDERAZGO', 24, 800.00, 'ESE', DATE '2024-05-20', DATE '2024-05-24', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Mantenimiento Avanzado', 'Técnicas de mantenimiento', 'TECNICA', 30, 1200.00, 'Boeing', DATE '2024-09-01', DATE '2024-09-05', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Primeros Auxilios', 'RCP y emergencias', 'SEGURIDAD', 8, 150.00, 'Cruz Roja', DATE '2024-04-15', DATE '2024-04-15', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Excel Avanzado', 'Hoja de cálculo', 'TECNICA', 12, 200.00, 'Microsoft', DATE '2024-06-10', DATE '2024-06-12', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Gestión de Conflictos', 'Resolución de problemas', 'ATENCION_CLIENTE', 8, 250.00, 'IHK', DATE '2024-07-01', DATE '2024-07-01', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Francés Básico', 'Idioma', 'IDIOMAS', 30, 400.00, 'Alliance', DATE '2024-08-01', DATE '2024-09-01', 1);
INSERT INTO capacitaciones (nombre_curso, descripcion, tipo_capacitacion, duracion_horas, costo, proveedor, fecha_inicio, fecha_fin, activo) VALUES
('Trabajo en Equipo', 'Dinámicas de grupo', 'LIDERAZGO', 8, 180.00, 'HR Consulting', DATE '2024-05-05', DATE '2024-05-05', 1);

-- Tabla 15.9: empleados_capacitacion (clave compuesta, no autoincremental)
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(1, 4, DATE '2024-04-01', 'INSCRITO', NULL, NULL, 0);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(2, 5, DATE '2024-04-01', 'INSCRITO', NULL, NULL, 0);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(3, 6, DATE '2024-03-15', 'COMPLETADO', DATE '2024-04-15', 9.5, 1);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(4, 2, DATE '2024-03-01', 'COMPLETADO', DATE '2024-05-12', 8.0, 1);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(5, 1, DATE '2024-02-01', 'COMPLETADO', DATE '2024-04-05', 9.0, 1);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(6, 8, DATE '2024-04-01', 'INSCRITO', NULL, NULL, 0);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(7, 6, DATE '2024-04-01', 'INSCRITO', NULL, NULL, 0);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(8, 7, DATE '2024-05-01', 'INSCRITO', NULL, NULL, 0);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(9, 3, DATE '2024-04-15', 'INSCRITO', NULL, NULL, 0);
INSERT INTO empleados_capacitacion (id_empleado, id_capacitacion, fecha_asignacion, estado, fecha_completado, calificacion, certificado_obtenido) VALUES
(10, 10, DATE '2024-04-10', 'INSCRITO', NULL, NULL, 0);

-- Tabla 15.10: uniformes_equipamiento (se omite id_asignacion)
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(1, 'UNIFORME', 'Uniforme de gerente', 'L', DATE '2024-01-01', NULL, 'NUEVO', NULL);
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(2, 'UNIFORME', 'Uniforme técnico', 'M', DATE '2024-01-01', NULL, 'NUEVO', NULL);
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(3, 'RADIO', 'Radio Motorola', NULL, DATE '2024-01-01', NULL, 'BUENO', NULL);
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(4, 'COMPUTADORA', 'Dell Latitude', NULL, DATE '2024-01-01', NULL, 'NUEVO', NULL);
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(5, 'CHALECO', 'Chaleco reflectante', 'XL', DATE '2024-01-01', NULL, 'BUENO', NULL);
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(5, 'UNIFORME', 'Uniforme seguridad', 'XL', DATE '2024-01-01', NULL, 'BUENO', NULL);
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(6, 'RADIO', 'Radio Motorola', NULL, DATE '2024-01-01', NULL, 'REGULAR', 'Requiere mantenimiento');
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(7, 'UNIFORME', 'Uniforme atención', 'S', DATE '2024-01-01', NULL, 'NUEVO', NULL);
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(8, 'COMPUTADORA', 'MacBook Pro', NULL, DATE '2024-01-01', NULL, 'NUEVO', NULL);
INSERT INTO uniformes_equipamiento (id_empleado, tipo_equipo, descripcion, talla, fecha_asignacion, fecha_devolucion, estado, observaciones) VALUES
(9, 'HERRAMIENTA', 'Kit de herramientas', NULL, DATE '2024-01-01', NULL, 'BUENO', NULL);

COMMIT;

SELECT 'Datos insertados correctamente (Módulos 9-15)' AS estado FROM dual;

-- =====================================================
-- CONTINUACIÓN: MÓDULOS 16 AL 29
-- (Se han omitido por brevedad, pero la estructura sería la misma)
-- =====================================================

-- (Aquí continuarían los INSERTs para los módulos 16 al 29,
--  siguiendo el mismo patrón de omitir las columnas de identidad
--  y escapando los símbolos &)

-- =====================================================
-- MÓDULO 16: FINANZAS Y CONTABILIDAD (10 TABLAS)
-- =====================================================

-- Tabla 16.1: presupuestos (se omite id_presupuesto)
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Presupuesto Operaciones Enero', 1, 400000.00, 385000.00, 'OPERATIVO', 'Dentro de lo esperado', DATE '2024-02-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 2, 'Presupuesto Operaciones Febrero', 1, 400000.00, 392000.00, 'OPERATIVO', NULL, DATE '2024-03-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Mantenimiento Enero', 2, 300000.00, 325000.00, 'MANTENIMIENTO', 'Reparación no programada', DATE '2024-02-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Personal RRHH', 3, 100000.00, 98500.00, 'PERSONAL', NULL, DATE '2024-02-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Gastos Financieros', 4, 150000.00, 148000.00, 'OPERATIVO', NULL, DATE '2024-02-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Seguridad Enero', 5, 200000.00, 195000.00, 'PERSONAL', NULL, DATE '2024-02-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Comercial Enero', 6, 150000.00, 162000.00, 'INVERSION', 'Nueva campaña', DATE '2024-02-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Atención Cliente', 7, 80000.00, 78000.00, 'PERSONAL', NULL, DATE '2024-02-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Tecnología', 8, 120000.00, 115000.00, 'INVERSION', 'Licencias software', DATE '2024-02-01');
INSERT INTO presupuestos (anio_fiscal, mes, concepto, id_departamento, monto_asignado, monto_ejecutado, tipo_gasto, observaciones, fecha_actualizacion) VALUES
(2024, 1, 'Legal', 9, 70000.00, 65000.00, 'OPERATIVO', NULL, DATE '2024-02-01');

-- Tabla 16.2: ingresos (se omite id_ingreso)
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-18', 'Tasa de embarque IB1234', 'TASA_EMBARQUE', NULL, 1, 27500.00, 'EUR', 'TRANSFERENCIA', 'FAC-001', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-18', 'Tasa de embarque AV123', 'TASA_EMBARQUE', NULL, 2, 17500.00, 'EUR', 'TRANSFERENCIA', 'FAC-002', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-18', 'Canon mensual Zara', 'CONCESIONES', 1, NULL, 15000.00, 'EUR', 'TRANSFERENCIA', 'FAC-Z-001', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-18', 'Canon mensual Starbucks', 'CONCESIONES', 2, NULL, 12000.00, 'EUR', 'TRANSFERENCIA', 'FAC-S-001', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-18', 'Estacionamiento - Varios', 'ESTACIONAMIENTO', NULL, NULL, 3250.00, 'EUR', 'TARJETA', 'TIK-001', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-18', 'Publicidad Iberia', 'PUBLICIDAD', NULL, NULL, 5000.00, 'EUR', 'TRANSFERENCIA', 'FAC-P-001', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-19', 'Tasa de embarque UA101', 'TASA_EMBARQUE', NULL, 5, 37600.00, 'USD', 'TRANSFERENCIA', 'FAC-003', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-19', 'Canon mensual Duty Free', 'CONCESIONES', 3, NULL, 25000.00, 'EUR', 'TRANSFERENCIA', 'FAC-D-001', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-20', 'Estacionamiento - Larga estancia', 'ESTACIONAMIENTO', NULL, NULL, 4500.00, 'EUR', 'EFECTIVO', 'TIK-002', 4);
INSERT INTO ingresos (fecha, concepto, tipo_ingreso, id_concesion, id_vuelo, monto, moneda, metodo_pago, comprobante, registrado_por) VALUES
(DATE '2024-03-20', 'Otros ingresos', 'OTROS', NULL, NULL, 1200.00, 'EUR', 'TARJETA', 'FAC-O-001', 4);

-- Tabla 16.3: gastos (se omite id_gasto)
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-18', 'Electricidad terminal', 'SERVICIOS', 1, 'Iberdrola', 15000.00, 'EUR', 'FAC-E-001', 4);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-18', 'Agua', 'SERVICIOS', 1, 'Canal de Isabel II', 3500.00, 'EUR', 'FAC-A-001', 4);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-18', 'Material oficina', 'SUMINISTROS', 3, 'Office Depot', 850.00, 'EUR', 'FAC-M-001', 3);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-18', 'Mantenimiento pistas', 'MANTENIMIENTO', 2, 'Ferrovial', 25000.00, 'EUR', 'FAC-M-002', 2);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-18', 'Nóminas personal', 'PERSONAL', 3, 'Prosegur', 45000.00, 'EUR', 'NOM-001', 3);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-19', 'Seguridad privada', 'SEGURIDAD', 5, 'Prosegur', 12000.00, 'EUR', 'FAC-S-001', 5);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-19', 'Limpieza terminal', 'SERVICIOS', 1, 'FCC', 18000.00, 'EUR', 'FAC-L-001', 1);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-20', 'Reparación equipos', 'MANTENIMIENTO', 2, 'Siemens', 8500.00, 'EUR', 'FAC-R-001', 2);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-20', 'Publicidad institucional', 'OTROS', 6, 'Havas Media', 15000.00, 'EUR', 'FAC-P-001', 6);
INSERT INTO gastos (fecha, concepto, tipo_gasto, id_departamento, proveedor, monto, moneda, factura, autorizado_por) VALUES
(DATE '2024-03-20', 'Asesoría legal', 'SERVICIOS', 9, 'Bufete Gómez', 3500.00, 'EUR', 'FAC-L-002', 9);

-- Tabla 16.4: proveedores (se omite id_proveedor)
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Repsol', 'COMBUSTIBLE', 'A-28123456', 'C/ Méndez Álvaro 44, Madrid', '+34913456789', 'comercial@repsol.com', 'Carlos López', '+34913456790', '30 días', 5, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Gate Gourmet', 'CATERING', 'B-87654321', 'Av. de la Hispanidad 12, Madrid', '+34913456791', 'ventas@gate-gourmet.com', 'Ana Pérez', '+34913456792', '45 días', 4, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Ferrovial', 'MANTENIMIENTO', 'C-11223344', 'C/ Príncipe de Vergara 135, Madrid', '+34913456793', 'servicios@ferrovial.com', 'Juan García', '+34913456794', '60 días', 4, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('FCC', 'LIMPIEZA', 'D-55667788', 'C/ Federico Salmón 13, Madrid', '+34913456795', 'limpieza@fcc.es', 'María Rodríguez', '+34913456796', '30 días', 5, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Prosegur', 'SEGURIDAD', 'E-99001122', 'C/ Pinar 18, Madrid', '+34913456797', 'seguridad@prosegur.com', 'Pedro Sánchez', '+34913456798', '30 días', 4, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Microsoft', 'TECNOLOGIA', 'F-33445566', 'Microsoft Ibérica, Madrid', '+34913456799', 'empresas@microsoft.com', 'Laura Gómez', '+34913456800', '30 días', 5, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Shell', 'COMBUSTIBLE', 'G-77889900', 'C/ Orense 70, Madrid', '+34913456801', 'shell@shell.es', 'David Martínez', '+34913456802', '30 días', 4, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Iberdrola', 'COMBUSTIBLE', 'H-11223344', 'C/ Tomás Redondo 1, Madrid', '+34913456803', 'empresas@iberdrola.es', 'Elena Díaz', '+34913456804', '30 días', 5, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Do & Co', 'CATERING', 'I-55667788', 'Av. del Partenón 5, Madrid', '+34913456805', 'catering@doco.com', 'Miguel Ángel', '+34913456806', '45 días', 4, 1);
INSERT INTO proveedores (nombre_proveedor, tipo_proveedor, nit, direccion, telefono, email, contacto_nombre, contacto_telefono, condiciones_pago, calificacion, activo) VALUES
('Indra', 'TECNOLOGIA', 'J-99001122', 'Av. de Bruselas 35, Madrid', '+34913456807', 'indra@indra.es', 'Patricia Ruiz', '+34913456808', '60 días', 5, 1);

-- Tabla 16.5: ordenes_compra (se omite id_orden)
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(1, DATE '2024-03-01', DATE '2024-03-05', DATE '2024-03-05', 'COMPLETADO', 45000.00, 9450.00, 54450.00, 'Entrega en depósito', 2, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(2, DATE '2024-03-10', DATE '2024-03-12', DATE '2024-03-12', 'COMPLETADO', 8500.00, 1785.00, 10285.00, 'Entrega en catering', 6, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(3, DATE '2024-03-15', DATE '2024-03-20', NULL, 'PENDIENTE', 15000.00, 3150.00, 18150.00, 'Obra en pista', 2, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(5, DATE '2024-03-05', DATE '2024-03-10', DATE '2024-03-10', 'COMPLETADO', 12000.00, 2520.00, 14520.00, 'Equipamiento seguridad', 5, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(6, DATE '2024-03-08', DATE '2024-03-15', DATE '2024-03-14', 'COMPLETADO', 8000.00, 1680.00, 9680.00, 'Licencias software', 8, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(7, DATE '2024-03-12', DATE '2024-03-16', DATE '2024-03-16', 'COMPLETADO', 38000.00, 7980.00, 45980.00, 'Combustible', 2, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(8, DATE '2024-03-01', DATE '2024-03-01', DATE '2024-03-01', 'COMPLETADO', 15000.00, 3150.00, 18150.00, 'Suministro eléctrico', 1, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(9, DATE '2024-03-14', DATE '2024-03-17', DATE '2024-03-17', 'COMPLETADO', 5600.00, 1176.00, 6776.00, 'Comidas especiales', 6, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(10, DATE '2024-03-18', DATE '2024-03-25', NULL, 'PENDIENTE', 22000.00, 4620.00, 26620.00, 'Sistemas radar', 8, 4);
INSERT INTO ordenes_compra (id_proveedor, fecha_orden, fecha_entrega_estimada, fecha_entrega_real, estado, subtotal, impuestos, total, condiciones_entrega, solicitado_por, autorizado_por) VALUES
(4, DATE '2024-03-02', DATE '2024-03-02', DATE '2024-03-02', 'COMPLETADO', 18000.00, 3780.00, 21780.00, 'Servicio limpieza mensual', 1, 4);

-- Tabla 16.6: ordenes_detalle (se omite id_detalle)
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(1, 'Jet A-1', 45000, 1.00, 45000.00, 'Precio por litro');
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(2, 'Menús ejecutivos', 500, 12.00, 6000.00, NULL);
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(2, 'Menús vegetarianos', 200, 10.00, 2000.00, NULL);
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(2, 'Bebidas', 500, 1.00, 500.00, NULL);
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(3, 'Reparación asfalto', 1, 15000.00, 15000.00, 'Pista 18L');
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(4, 'Chalecos reflectantes', 50, 80.00, 4000.00, NULL);
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(4, 'Radios Motorola', 20, 400.00, 8000.00, NULL);
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(5, 'Licencias Office 365', 50, 160.00, 8000.00, 'Anuales');
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(6, 'Jet A-1 Shell', 38000, 1.00, 38000.00, NULL);
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(8, 'Menús kosher', 100, 18.00, 1800.00, NULL);
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(8, 'Menús sin gluten', 200, 12.00, 2400.00, NULL);
INSERT INTO ordenes_detalle (id_orden, descripcion, cantidad, precio_unitario, subtotal_linea, observaciones) VALUES
(9, 'Sistema radar secundario', 1, 22000.00, 22000.00, 'Repuesto');

-- Tabla 16.7: tasas_aeroportuarias (se omite id_tasa)
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de embarque internacional', 'INTERNACIONAL', 25.00, 'EUR', NULL, 'PASAJERO', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de embarque nacional', 'NACIONAL', 15.00, 'EUR', NULL, 'PASAJERO', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de seguridad', 'SEGURIDAD', 8.00, 'EUR', NULL, 'PASAJERO', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de aterrizaje', 'INTERNACIONAL', 500.00, 'EUR', NULL, 'AVION', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de estacionamiento', 'ESTACIONAMIENTO', 100.00, 'EUR', NULL, 'AVION', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de combustible', 'COMBUSTIBLE', NULL, 'EUR', 2.5, 'AEROLINEA', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de carga internacional', 'INTERNACIONAL', 0.50, 'EUR', NULL, 'CARGA', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de carga nacional', 'NACIONAL', 0.25, 'EUR', NULL, 'CARGA', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de handling', 'INTERNACIONAL', 150.00, 'EUR', NULL, 'AVION', 1, DATE '2024-01-01');
INSERT INTO tasas_aeroportuarias (nombre_tasa, tipo_tasa, monto, moneda, calculo_porcentaje, aplica_a, activa, fecha_actualizacion) VALUES
('Tasa de pasarela', 'INTERNACIONAL', 75.00, 'EUR', NULL, 'AVION', 1, DATE '2024-01-01');

-- Tabla 16.8: tasas_aplicadas (se omite id_aplicacion)
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(1, 1, NULL, DATE '2024-03-18', 25.00, 1, DATE '2024-03-18');
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(3, 1, NULL, DATE '2024-03-18', 8.00, 1, DATE '2024-03-18');
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(4, 1, NULL, DATE '2024-03-18', 500.00, 1, DATE '2024-03-18');
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(1, 2, NULL, DATE '2024-03-18', 25.00, 1, DATE '2024-03-18');
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(9, 3, NULL, DATE '2024-03-18', 150.00, 1, DATE '2024-03-18');
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(1, 3, NULL, DATE '2024-03-18', 15.00, 1, DATE '2024-03-18');
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(7, 5, NULL, DATE '2024-03-18', 0.50, 0, NULL);
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(1, NULL, 1, DATE '2024-03-18', 25.00, 1, DATE '2024-03-18');
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(3, NULL, 2, DATE '2024-03-18', 8.00, 1, DATE '2024-03-18');
INSERT INTO tasas_aplicadas (id_tasa, id_vuelo, id_reserva, fecha_aplicacion, monto_aplicado, facturado, fecha_factura) VALUES
(1, 10, NULL, DATE '2024-03-20', 25.00, 1, DATE '2024-03-20');

-- Tabla 16.9: cuentas_bancarias (se omite id_cuenta)
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('Santander', 'MONETARIA', 'ES00-1234-5678-9012-3456', 'EUR', 1250000.00, DATE '2020-01-01', 'ACTIVA', 'Jefe Finanzas');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('BBVA', 'MONETARIA', 'ES00-2345-6789-0123-4567', 'USD', 850000.00, DATE '2020-01-01', 'ACTIVA', 'Jefe Finanzas');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('Bankia', 'AHORRO', 'ES00-3456-7890-1234-5678', 'EUR', 3500000.00, DATE '2021-06-01', 'ACTIVA', 'Tesorería');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('CaixaBank', 'MONETARIA', 'ES00-4567-8901-2345-6789', 'GBP', 250000.00, DATE '2022-01-01', 'ACTIVA', 'Jefe Finanzas');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('Banco Sabadell', 'INVERSION', 'ES00-5678-9012-3456-7890', 'EUR', 1500000.00, DATE '2023-01-01', 'ACTIVA', 'Tesorería');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('Bankinter', 'MONETARIA', 'ES00-6789-0123-4567-8901', 'COP', 450000000.00, DATE '2023-06-01', 'ACTIVA', 'Jefe Finanzas');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('Citibank', 'MONETARIA', 'US00-7890-1234-5678-9012', 'USD', 650000.00, DATE '2020-01-01', 'ACTIVA', 'Jefe Finanzas');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('BNP Paribas', 'MONETARIA', 'FR00-8901-2345-6789-0123', 'EUR', 280000.00, DATE '2021-01-01', 'ACTIVA', 'Jefe Finanzas');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('HSBC', 'AHORRO', 'GB00-9012-3456-7890-1234', 'GBP', 180000.00, DATE '2022-06-01', 'ACTIVA', 'Tesorería');
INSERT INTO cuentas_bancarias (banco, tipo_cuenta, numero_cuenta, moneda, saldo_actual, fecha_apertura, estado, responsable) VALUES
('Deutsche Bank', 'INVERSION', 'DE00-0123-4567-8901-2345', 'EUR', 2200000.00, DATE '2023-01-01', 'ACTIVA', 'Tesorería');

-- Tabla 16.10: movimientos_bancarios (se omite id_movimiento)
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(1, DATE '2024-03-18', 'DEPOSITO', 'Ingreso tasas aeroportuarias', 85000.00, 1335000.00, 'REF-001', 1);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(1, DATE '2024-03-18', 'RETIRO', 'Pago nóminas', -45000.00, 1290000.00, 'REF-002', 1);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(2, DATE '2024-03-18', 'DEPOSITO', 'Transferencia Delta Airlines', 120000.00, 970000.00, 'REF-003', 1);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(3, DATE '2024-03-18', 'RETIRO', 'Pago a proveedores', -250000.00, 3250000.00, 'REF-004', 1);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(1, DATE '2024-03-19', 'DEPOSITO', 'Ingreso publicidad', 5000.00, 1295000.00, 'REF-005', 0);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(6, DATE '2024-03-19', 'DEPOSITO', 'Ingreso Avianca', 42000000.00, 492000000.00, 'REF-006', 1);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(7, DATE '2024-03-19', 'RETIRO', 'Pago combustible', -45000.00, 605000.00, 'REF-007', 1);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(10, DATE '2024-03-20', 'TRANSFERENCIA', 'Transferencia a cuenta EUR', -500000.00, 1700000.00, 'REF-008', 0);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(1, DATE '2024-03-20', 'DEPOSITO', 'Ingreso recepción transferencia', 500000.00, 1795000.00, 'REF-009', 0);
INSERT INTO movimientos_bancarios (id_cuenta, fecha, tipo_movimiento, concepto, monto, saldo_resultante, referencia, conciliado) VALUES
(4, DATE '2024-03-20', 'PAGO', 'Pago British Airways', -35000.00, 215000.00, 'REF-010', 1);


-- =====================================================
-- MÓDULO 18: MENORES Y GRUPOS ESPECIALES (4 TABLAS)
-- =====================================================

-- Tabla 18.1: menores_no_acompanados (se omite id_menor)
INSERT INTO menores_no_acompanados (id_reserva, edad, nombre_entrega_origen, relacion_origen, telefono_origen, nombre_recoge_destino, relacion_destino, telefono_destino, observaciones) VALUES
(5, 12, 'Michael Johnson', 'Padre', '+12125551234', 'Sarah Johnson', 'Madre', '+12125551235', 'Menor viaja solo');
INSERT INTO menores_no_acompanados (id_reserva, edad, nombre_entrega_origen, relacion_origen, telefono_origen, nombre_recoge_destino, relacion_destino, telefono_destino, observaciones) VALUES
(6, 14, 'Jennifer Williams', 'Madre', '+13105559876', 'Robert Williams', 'Tío', '+13105559877', 'Contacto en destino');
INSERT INTO menores_no_acompanados (id_reserva, edad, nombre_entrega_origen, relacion_origen, telefono_origen, nombre_recoge_destino, relacion_destino, telefono_destino, observaciones) VALUES
(9, 10, 'David Brown', 'Padre', '+442079876543', 'Elizabeth Brown', 'Madre', '+442079876544', 'Viaja a ver a su madre');
INSERT INTO menores_no_acompanados (id_reserva, edad, nombre_entrega_origen, relacion_origen, telefono_origen, nombre_recoge_destino, relacion_destino, telefono_destino, observaciones) VALUES
(10, 15, 'Emma Taylor', 'Madre', '+442079876544', 'James Taylor', 'Abuelo', '+442079876545', 'Servicio de menores');

-- Tabla 18.2: pasajeros_menores (se omite id_relacion)
INSERT INTO pasajeros_menores (id_menor, id_acompanante, tipo_relacion, autorizado, documento_autorizacion) VALUES
(1, 5, 'PADRE', 1, NULL);
INSERT INTO pasajeros_menores (id_menor, id_acompanante, tipo_relacion, autorizado, documento_autorizacion) VALUES
(2, 6, 'MADRE', 1, NULL);
INSERT INTO pasajeros_menores (id_menor, id_acompanante, tipo_relacion, autorizado, documento_autorizacion) VALUES
(3, 9, 'PADRE', 1, NULL);
INSERT INTO pasajeros_menores (id_menor, id_acompanante, tipo_relacion, autorizado, documento_autorizacion) VALUES
(4, 10, 'MADRE', 1, NULL);

-- Tabla 18.3: autorizaciones_menores (se omite id_autorizacion_menor)
INSERT INTO autorizaciones_menores (id_menor, numero_autorizacion, fecha_emision, fecha_expiracion, autoridad_emisora, verificado) VALUES
(1, 'AUT-MEN-001', DATE '2024-03-10', DATE '2024-04-10', 'Notaría NYC', 1);
INSERT INTO autorizaciones_menores (id_menor, numero_autorizacion, fecha_emision, fecha_expiracion, autoridad_emisora, verificado) VALUES
(2, 'AUT-MEN-002', DATE '2024-03-11', DATE '2024-04-11', 'Consulado', 1);
INSERT INTO autorizaciones_menores (id_menor, numero_autorizacion, fecha_emision, fecha_expiracion, autoridad_emisora, verificado) VALUES
(3, 'AUT-MEN-003', DATE '2024-03-12', DATE '2024-04-12', 'Notaría Londres', 1);
INSERT INTO autorizaciones_menores (id_menor, numero_autorizacion, fecha_emision, fecha_expiracion, autoridad_emisora, verificado) VALUES
(4, 'AUT-MEN-004', DATE '2024-03-13', DATE '2024-04-13', 'Notaría Londres', 0);

-- Tabla 18.4: pasajeros_mascotas (se omite id_mascota)
INSERT INTO pasajeros_mascotas (id_pasajero, id_reserva, nombre_mascota, tipo_mascota, raza, peso_kg, vacunas, transportadora_dimensiones, autorizado) VALUES
(6, 6, 'Luna', 'PERRO', 'Chihuahua', 3, 'Vacunada al día', '40x30x25', 1);
INSERT INTO pasajeros_mascotas (id_pasajero, id_reserva, nombre_mascota, tipo_mascota, raza, peso_kg, vacunas, transportadora_dimensiones, autorizado) VALUES
(10, 10, 'Simba', 'GATO', 'Siamés', 4, 'Vacunas completas', '40x30x25', 1);
INSERT INTO pasajeros_mascotas (id_pasajero, id_reserva, nombre_mascota, tipo_mascota, raza, peso_kg, vacunas, transportadora_dimensiones, autorizado) VALUES
(5, 5, 'Max', 'PERRO', 'Golden Retriever', 25, 'Vacunas al día', NULL, 0);
INSERT INTO pasajeros_mascotas (id_pasajero, id_reserva, nombre_mascota, tipo_mascota, raza, peso_kg, vacunas, transportadora_dimensiones, autorizado) VALUES
(8, 8, 'Coco', 'AVE', 'Periquito', 0.1, 'Ninguna', '30x20x20', 1);
--================================================
-- MÓDULO 19: GESTIÓN DE CARGA Y MERCANCÍAS (10 TABLAS)
-- =====================================================

-- Tabla 19.1: tipos_carga (se omite id_tipo_carga)
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('GEN-001', 'Carga general', 'GENERAL', 0, NULL, 0, NULL, 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('PER-001', 'Flores frescas', 'PERECEDERA', 1, 4.0, 0, NULL, 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('PER-002', 'Productos farmacéuticos', 'MEDICAMENTOS', 1, 2.0, 0, NULL, 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('PEL-001', 'Material inflamable', 'PELIGROSA', 0, NULL, 1, 'Clase 3', 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('VAL-001', 'Obras de arte', 'VALORES', 0, NULL, 0, NULL, 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('VAL-002', 'Metales preciosos', 'VALORES', 0, NULL, 0, NULL, 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('DIP-001', 'Valija diplomática', 'DIPLOMATICA', 0, NULL, 0, NULL, 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('ANM-001', 'Animales vivos', 'ANIMALES_VIVOS', 0, NULL, 0, NULL, 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('MED-001', 'Vacunas', 'MEDICAMENTOS', 1, -20.0, 0, NULL, 1);
INSERT INTO tipos_carga (codigo_carga, descripcion, categoria, requiere_frio, temperatura_requerida, peligroso, clase_peligrosidad, activo) VALUES
('PEL-002', 'Baterías de litio', 'PELIGROSA', 0, NULL, 1, 'Clase 9', 1);

-- Tabla 19.2: envios_carga (se omite id_envio)
INSERT INTO envios_carga (codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3, cantidad_bultos, contenido, valor_declarado, moneda, consignador_nombre, consignador_documento, consignatario_nombre, consignatario_documento, instrucciones_especiales, fecha_recepcion, fecha_embarque, estado, ubicacion_actual) VALUES
('ENV-001', 1, 2, 1500.00, 5.0, 50, 'Flores de Colombia', 25000.00, 'EUR', 'Flores El Rosal', 'NIT-COL-001', 'Interflora España', 'B-12345678', 'Mantener a 4°C', TO_TIMESTAMP('2024-03-17 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', 'CARGADO', 'En vuelo');
INSERT INTO envios_carga (codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3, cantidad_bultos, contenido, valor_declarado, moneda, consignador_nombre, consignador_documento, consignatario_nombre, consignatario_documento, instrucciones_especiales, fecha_recepcion, fecha_embarque, estado, ubicacion_actual) VALUES
('ENV-002', 1, 3, 500.00, 1.5, 20, 'Medicamentos', 150000.00, 'EUR', 'Laboratorios Roche', 'NIT-COL-002', 'Roche España', 'A-87654321', 'Temperatura controlada', TO_TIMESTAMP('2024-03-17 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', 'CARGADO', 'En vuelo');
INSERT INTO envios_carga (codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3, cantidad_bultos, contenido, valor_declarado, moneda, consignador_nombre, consignador_documento, consignatario_nombre, consignatario_documento, instrucciones_especiales, fecha_recepcion, fecha_embarque, estado, ubicacion_actual) VALUES
('ENV-003', 2, 1, 3000.00, 12.0, 100, 'Repuestos industriales', 45000.00, 'EUR', 'Siemens Colombia', 'NIT-COL-003', 'Siemens España', 'B-11223344', NULL, TO_TIMESTAMP('2024-03-17 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', 'CARGADO', 'En vuelo');
INSERT INTO envios_carga (codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3, cantidad_bultos, contenido, valor_declarado, moneda, consignador_nombre, consignador_documento, consignatario_nombre, consignatario_documento, instrucciones_especiales, fecha_recepcion, fecha_embarque, estado, ubicacion_actual) VALUES
('ENV-004', 3, 5, 200.00, 1.0, 5, 'Obras de arte', 500000.00, 'USD', 'Galería de Arte NY', 'USA-12345', 'Museo del Prado', 'M-001', 'Máxima seguridad', TO_TIMESTAMP('2024-03-17 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', 'EN_BODEGA', 'Bodega MAD');
INSERT INTO envios_carga (codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3, cantidad_bultos, contenido, valor_declarado, moneda, consignador_nombre, consignador_documento, consignatario_nombre, consignatario_documento, instrucciones_especiales, fecha_recepcion, fecha_embarque, estado, ubicacion_actual) VALUES
('ENV-005', 5, 7, 50.00, 0.5, 2, 'Valija diplomática', 0.00, 'USD', 'Embajada UK', 'DIP-001', 'Consulado UK', 'DIP-002', 'Entrega personal', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', 'EN_VUELO', 'En vuelo');
INSERT INTO envios_carga (codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3, cantidad_bultos, contenido, valor_declarado, moneda, consignador_nombre, consignador_documento, consignatario_nombre, consignatario_documento, instrucciones_especiales, fecha_recepcion, fecha_embarque, estado, ubicacion_actual) VALUES
('ENV-006', 6, 8, 800.00, 3.0, 10, 'Caballos de competición', 200000.00, 'EUR', 'Haras Franceses', 'FRA-001', 'Club Hípico Madrid', 'ESP-001', 'Alimentación cada 4h', TO_TIMESTAMP('2024-03-17 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', 'RECIBIDO', 'CDG');
INSERT INTO envios_carga (codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3, cantidad_bultos, contenido, valor_declarado, moneda, consignador_nombre, consignador_documento, consignatario_nombre, consignatario_documento, instrucciones_especiales, fecha_recepcion, fecha_embarque, estado, ubicacion_actual) VALUES
('ENV-007', 10, 9, 100.00, 0.8, 10, 'Vacunas COVID-19', 500000.00, 'EUR', 'Pfizer', 'NIT-USA-001', 'Ministerio Salud Colombia', 'NIT-COL-999', 'Cadena de frío -20°C', TO_TIMESTAMP('2024-03-19 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-20', 'EN_BODEGA', 'Bodega MAD');
INSERT INTO envios_carga (codigo_envio, id_vuelo, id_tipo_carga, peso_kg, volumen_m3, cantidad_bultos, contenido, valor_declarado, moneda, consignador_nombre, consignador_documento, consignatario_nombre, consignatario_documento, instrucciones_especiales, fecha_recepcion, fecha_embarque, estado, ubicacion_actual) VALUES
('ENV-008', 10, 4, 2000.00, 4.0, 40, 'Pintura industrial', 30000.00, 'EUR', 'AkzoNobel', 'NIT-ESP-001', 'Pinturas Colombia', 'NIT-COL-004', 'Material peligroso', TO_TIMESTAMP('2024-03-19 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-20', 'EN_BODEGA', 'Bodega MAD');

-- Tabla 19.3: manifiestos_carga (se omite id_manifiesto)
INSERT INTO manifiestos_carga (numero_manifiesto, id_vuelo, fecha_emision, total_bultos, peso_total_kg, volumen_total_m3, valor_total, agente_carga, estado, emitido_por) VALUES
('MAN-IB-001', 1, DATE '2024-03-18', 70, 2000.00, 6.5, 175000.00, 'Iberia Cargo', 'EMITIDO', 2);
INSERT INTO manifiestos_carga (numero_manifiesto, id_vuelo, fecha_emision, total_bultos, peso_total_kg, volumen_total_m3, valor_total, agente_carga, estado, emitido_por) VALUES
('MAN-AV-001', 2, DATE '2024-03-18', 100, 3000.00, 12.0, 45000.00, 'Avianca Cargo', 'EMITIDO', 3);
INSERT INTO manifiestos_carga (numero_manifiesto, id_vuelo, fecha_emision, total_bultos, peso_total_kg, volumen_total_m3, valor_total, agente_carga, estado, emitido_por) VALUES
('MAN-AA-001', 3, DATE '2024-03-18', 5, 200.00, 1.0, 500000.00, 'American Airlines Cargo', 'VALIDADO', 5);
INSERT INTO manifiestos_carga (numero_manifiesto, id_vuelo, fecha_emision, total_bultos, peso_total_kg, volumen_total_m3, valor_total, agente_carga, estado, emitido_por) VALUES
('MAN-UA-001', 5, DATE '2024-03-18', 2, 50.00, 0.5, 0.00, 'United Cargo', 'EMITIDO', 9);
INSERT INTO manifiestos_carga (numero_manifiesto, id_vuelo, fecha_emision, total_bultos, peso_total_kg, volumen_total_m3, valor_total, agente_carga, estado, emitido_por) VALUES
('MAN-QR-001', 10, DATE '2024-03-20', 50, 2100.00, 4.8, 530000.00, 'Qatar Airways Cargo', 'EMITIDO', 10);

-- Tabla 19.4: manifiestos_detalle (se omite id_detalle)
INSERT INTO manifiestos_detalle (id_manifiesto, id_envio, numero_orden, observaciones) VALUES
(1, 1, 1, NULL);
INSERT INTO manifiestos_detalle (id_manifiesto, id_envio, numero_orden, observaciones) VALUES
(1, 2, 2, NULL);
INSERT INTO manifiestos_detalle (id_manifiesto, id_envio, numero_orden, observaciones) VALUES
(2, 3, 1, NULL);
INSERT INTO manifiestos_detalle (id_manifiesto, id_envio, numero_orden, observaciones) VALUES
(3, 4, 1, 'Requiere custodia especial');
INSERT INTO manifiestos_detalle (id_manifiesto, id_envio, numero_orden, observaciones) VALUES
(4, 5, 1, 'Valija diplomática');
INSERT INTO manifiestos_detalle (id_manifiesto, id_envio, numero_orden, observaciones) VALUES
(5, 7, 1, NULL);
INSERT INTO manifiestos_detalle (id_manifiesto, id_envio, numero_orden, observaciones) VALUES
(5, 8, 2, 'Mercancía peligrosa');

-- Tabla 19.5: seguimiento_carga (se omite id_seguimiento)
INSERT INTO seguimiento_carga (id_envio, fecha_hora, ubicacion, estado, responsable, observaciones, temperatura_registrada, incidente) VALUES
(1, TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Bodega BOG', 'EN_BODEGA', 'Carlos Gómez', 'Carga recibida', NULL, 0);
INSERT INTO seguimiento_carga (id_envio, fecha_hora, ubicacion, estado, responsable, observaciones, temperatura_registrada, incidente) VALUES
(1, TO_TIMESTAMP('2024-03-18 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Avión IB1234', 'CARGADO', 'Juan Pérez', 'Cargado a bordo', 4.2, 0);
INSERT INTO seguimiento_carga (id_envio, fecha_hora, ubicacion, estado, responsable, observaciones, temperatura_registrada, incidente) VALUES
(2, TO_TIMESTAMP('2024-03-18 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Bodega BOG', 'EN_BODEGA', 'Carlos Gómez', NULL, 2.1, 0);
INSERT INTO seguimiento_carga (id_envio, fecha_hora, ubicacion, estado, responsable, observaciones, temperatura_registrada, incidente) VALUES
(4, TO_TIMESTAMP('2024-03-18 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Bodega JFK', 'EN_BODEGA', 'John Smith', 'Carga de alto valor', NULL, 0);
INSERT INTO seguimiento_carga (id_envio, fecha_hora, ubicacion, estado, responsable, observaciones, temperatura_registrada, incidente) VALUES
(5, TO_TIMESTAMP('2024-03-18 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'En ruta', 'EN_VUELO', 'Capitán Smith', NULL, NULL, 0);
INSERT INTO seguimiento_carga (id_envio, fecha_hora, ubicacion, estado, responsable, observaciones, temperatura_registrada, incidente) VALUES
(7, TO_TIMESTAMP('2024-03-19 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Bodega MAD', 'EN_BODEGA', 'Ana López', 'Cadena de frío OK', -19.8, 0);
INSERT INTO seguimiento_carga (id_envio, fecha_hora, ubicacion, estado, responsable, observaciones, temperatura_registrada, incidente) VALUES
(8, TO_TIMESTAMP('2024-03-19 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Bodega MAD', 'EN_BODEGA', 'Ana López', 'Zona de peligrosos', NULL, 0);

-- Tabla 19.6: restricciones_carga (se omite id_restriccion)
INSERT INTO restricciones_carga (id_tipo_carga, id_aerolinea, permitido, requiere_autorizacion_especial, documento_requerido, observaciones) VALUES
(4, 1, 1, 1, 'Declaración de mercancías peligrosas', 'Solo con autorización');
INSERT INTO restricciones_carga (id_tipo_carga, id_aerolinea, permitido, requiere_autorizacion_especial, documento_requerido, observaciones) VALUES
(4, 2, 0, 0, NULL, 'No permitido en Avianca');
INSERT INTO restricciones_carga (id_tipo_carga, id_aerolinea, permitido, requiere_autorizacion_especial, documento_requerido, observaciones) VALUES
(8, 1, 1, 1, 'Certificado veterinario', 'Máximo 2 animales');
INSERT INTO restricciones_carga (id_tipo_carga, id_aerolinea, permitido, requiere_autorizacion_especial, documento_requerido, observaciones) VALUES
(8, 3, 1, 1, 'Certificado IATA', NULL);
INSERT INTO restricciones_carga (id_tipo_carga, id_aerolinea, permitido, requiere_autorizacion_especial, documento_requerido, observaciones) VALUES
(9, 1, 1, 0, NULL, NULL);
INSERT INTO restricciones_carga (id_tipo_carga, id_aerolinea, permitido, requiere_autorizacion_especial, documento_requerido, observaciones) VALUES
(10, 1, 1, 1, 'MSDS', 'Solo en bodega clase C');
INSERT INTO restricciones_carga (id_tipo_carga, id_aerolinea, permitido, requiere_autorizacion_especial, documento_requerido, observaciones) VALUES
(10, 5, 0, 0, NULL, 'No permitido');
-- =====================================================
-- INSERTAR EMPLEADOS 11 AL 15 (INSPECTORES DE ADUANAS)
-- =====================================================

INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP011', 'Roberto', 'Gutiérrez Sánchez', 'DNI', '55667788K', DATE '1982-04-12', 'Española', 'M', 'Calle de Atocha 45, Madrid', '+34611224455', 'roberto.gutierrez@aeropuerto.com', DATE '2021-03-15', 'Aduanas', 'Inspector de Aduanas', 42000.00, 'PERMANENTE', 1);

INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP012', 'María', 'Fuentes López', 'DNI', '66778899L', DATE '1985-09-23', 'Española', 'F', 'Avda. de la Ilustración 78, Madrid', '+34622335566', 'maria.fuentes@aeropuerto.com', DATE '2020-11-10', 'Aduanas', 'Inspectora de Aduanas', 44000.00, 'PERMANENTE', 1);

INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP013', 'Carlos', 'Mendoza Ruiz', 'DNI', '77889900M', DATE '1979-12-05', 'Española', 'M', 'Calle de Alcalá 200, Madrid', '+34633446677', 'carlos.mendoza@aeropuerto.com', DATE '2019-06-20', 'Aduanas', 'Inspector Jefe', 52000.00, 'PERMANENTE', 1);

INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP014', 'Ana', 'Castro Gómez', 'DNI', '88990011N', DATE '1988-03-17', 'Española', 'F', 'Paseo de la Castellana 150, Madrid', '+34644557788', 'ana.castro@aeropuerto.com', DATE '2022-01-15', 'Aduanas', 'Inspectora de Aduanas', 43000.00, 'PERMANENTE', 1);

INSERT INTO empleados (codigo_empleado, nombres, apellidos, tipo_documento, numero_documento, fecha_nacimiento, nacionalidad, genero, direccion, telefono, email, fecha_contratacion, departamento, cargo, salario_base, tipo_contrato, activo) VALUES
('EMP015', 'Javier', 'Torres Pérez', 'DNI', '99001122O', DATE '1983-07-30', 'Española', 'M', 'Calle de Goya 80, Madrid', '+34655668899', 'javier.torres@aeropuerto.com', DATE '2021-09-01', 'Aduanas', 'Inspector de Aduanas', 42500.00, 'PERMANENTE', 1);

COMMIT;
SELECT 'Empleados 11-15 insertados correctamente' AS estado FROM dual;


-- Tabla 19.7: aduanas_carga (se omite id_registro_aduanal)
INSERT INTO aduanas_carga (id_envio, tipo_operacion, fecha_revision, estado_aduanal, inspector_asignado, documentos_verificados, impuesto_aplicado, moneda_impuesto, fecha_liberacion, observaciones) VALUES
(1, 'EXPORTACION', DATE '2024-03-17', 'LIBERADO', 11, 1, 2500.00, 'EUR', DATE '2024-03-17', NULL);
INSERT INTO aduanas_carga (id_envio, tipo_operacion, fecha_revision, estado_aduanal, inspector_asignado, documentos_verificados, impuesto_aplicado, moneda_impuesto, fecha_liberacion, observaciones) VALUES
(2, 'EXPORTACION', DATE '2024-03-17', 'LIBERADO', 11, 1, 0.00, 'EUR', DATE '2024-03-17', 'Medicamentos exentos');
INSERT INTO aduanas_carga (id_envio, tipo_operacion, fecha_revision, estado_aduanal, inspector_asignado, documentos_verificados, impuesto_aplicado, moneda_impuesto, fecha_liberacion, observaciones) VALUES
(3, 'EXPORTACION', DATE '2024-03-17', 'LIBERADO', 12, 1, 4500.00, 'EUR', DATE '2024-03-17', NULL);
INSERT INTO aduanas_carga (id_envio, tipo_operacion, fecha_revision, estado_aduanal, inspector_asignado, documentos_verificados, impuesto_aplicado, moneda_impuesto, fecha_liberacion, observaciones) VALUES
(4, 'IMPORTACION', DATE '2024-03-18', 'EN_TRAMITE', 13, 0, NULL, NULL, NULL, 'Obra de arte, requiere peritaje');
INSERT INTO aduanas_carga (id_envio, tipo_operacion, fecha_revision, estado_aduanal, inspector_asignado, documentos_verificados, impuesto_aplicado, moneda_impuesto, fecha_liberacion, observaciones) VALUES
(5, 'IMPORTACION', DATE '2024-03-19', 'LIBERADO', 14, 1, 0.00, 'USD', DATE '2024-03-19', 'Valija diplomática exenta');
INSERT INTO aduanas_carga (id_envio, tipo_operacion, fecha_revision, estado_aduanal, inspector_asignado, documentos_verificados, impuesto_aplicado, moneda_impuesto, fecha_liberacion, observaciones) VALUES
(7, 'IMPORTACION', DATE '2024-03-20', 'EN_TRAMITE', 15, 1, 50000.00, 'EUR', NULL, 'Vacunas en proceso');

-- Tabla 19.8: inspectores_aduanas (se omite id_inspector)
INSERT INTO inspectores_aduanas (id_empleado, numero_licencia, nivel_autorizacion, fecha_certificacion, fecha_vencimiento_certificacion, especialidad, activo) VALUES
(11, 'LIC-AD-001', 3, DATE '2023-01-01', DATE '2025-01-01', 'Carga general', 1);
INSERT INTO inspectores_aduanas (id_empleado, numero_licencia, nivel_autorizacion, fecha_certificacion, fecha_vencimiento_certificacion, especialidad, activo) VALUES
(12, 'LIC-AD-002', 4, DATE '2023-02-01', DATE '2025-02-01', 'Mercancías peligrosas', 1);
INSERT INTO inspectores_aduanas (id_empleado, numero_licencia, nivel_autorizacion, fecha_certificacion, fecha_vencimiento_certificacion, especialidad, activo) VALUES
(13, 'LIC-AD-003', 5, DATE '2022-03-01', DATE '2025-03-01', 'Obras de arte, valores', 1);
INSERT INTO inspectores_aduanas (id_empleado, numero_licencia, nivel_autorizacion, fecha_certificacion, fecha_vencimiento_certificacion, especialidad, activo) VALUES
(14, 'LIC-AD-004', 4, DATE '2023-04-01', DATE '2025-04-01', 'Valijas diplomáticas', 1);
INSERT INTO inspectores_aduanas (id_empleado, numero_licencia, nivel_autorizacion, fecha_certificacion, fecha_vencimiento_certificacion, especialidad, activo) VALUES
(15, 'LIC-AD-005', 4, DATE '2023-05-01', DATE '2025-05-01', 'Productos farmacéuticos', 1);


-- Tabla 19.9: bodegas_carga (se omite id_bodega)
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-MAD-01', 'Bodega General MAD', 'Zona de carga MAD', 5000.00, 500000.00, 0, 0, 1, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-MAD-02', 'Cámara frigorífica MAD', 'Zona de carga MAD', 500.00, 50000.00, 1, 1, 1, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-MAD-03', 'Bodega de alto valor MAD', 'Zona de carga MAD', 100.00, 10000.00, 0, 0, 1, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-BOG-01', 'Bodega General BOG', 'Zona de carga BOG', 8000.00, 800000.00, 0, 0, 0, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-BOG-02', 'Cámara frigorífica BOG', 'Zona de carga BOG', 800.00, 80000.00, 1, 1, 1, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-JFK-01', 'JFK Cargo Terminal', 'JFK Cargo Area', 15000.00, 1500000.00, 0, 0, 0, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-CDG-01', 'CDG Cargo', 'Roissy Cargo', 12000.00, 1200000.00, 1, 1, 1, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-MEX-01', 'MEX Cargo', 'Zona de carga MEX', 6000.00, 600000.00, 0, 0, 0, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-LAX-01', 'LAX Cargo', 'LAX Cargo Area', 20000.00, 2000000.00, 1, 1, 1, 1);
INSERT INTO bodegas_carga (codigo_bodega, nombre_bodega, ubicacion, capacidad_m3, capacidad_kg, tiene_refrigeracion, temperatura_controlada, tiene_acceso_restringido, activo) VALUES
('BOD-GRU-01', 'GRU Cargo', 'São Paulo Cargo', 10000.00, 1000000.00, 1, 1, 1, 1);

-- Tabla 19.10: carga_ubicacion (se omite id_ubicacion)
INSERT INTO carga_ubicacion (id_envio, id_bodega, fecha_ingreso, fecha_salida, posicion_estante, posicion_fila, posicion_columna, responsable_ingreso, responsable_salida) VALUES
(1, 4, TO_TIMESTAMP('2024-03-17 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'A', 1, 1, 11, NULL);
INSERT INTO carga_ubicacion (id_envio, id_bodega, fecha_ingreso, fecha_salida, posicion_estante, posicion_fila, posicion_columna, responsable_ingreso, responsable_salida) VALUES
(2, 4, TO_TIMESTAMP('2024-03-17 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'B', 1, 2, 11, NULL);
INSERT INTO carga_ubicacion (id_envio, id_bodega, fecha_ingreso, fecha_salida, posicion_estante, posicion_fila, posicion_columna, responsable_ingreso, responsable_salida) VALUES
(3, 4, TO_TIMESTAMP('2024-03-17 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'C', 1, 3, 12, NULL);
INSERT INTO carga_ubicacion (id_envio, id_bodega, fecha_ingreso, fecha_salida, posicion_estante, posicion_fila, posicion_columna, responsable_ingreso, responsable_salida) VALUES
(4, 6, TO_TIMESTAMP('2024-03-17 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'VIP', 1, 1, 13, NULL);
INSERT INTO carga_ubicacion (id_envio, id_bodega, fecha_ingreso, fecha_salida, posicion_estante, posicion_fila, posicion_columna, responsable_ingreso, responsable_salida) VALUES
(5, 6, TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DIP', 1, 1, 14, NULL);
INSERT INTO carga_ubicacion (id_envio, id_bodega, fecha_ingreso, fecha_salida, posicion_estante, posicion_fila, posicion_columna, responsable_ingreso, responsable_salida) VALUES
(6, 7, TO_TIMESTAMP('2024-03-17 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'ANM', 1, 1, 15, NULL);
INSERT INTO carga_ubicacion (id_envio, id_bodega, fecha_ingreso, fecha_salida, posicion_estante, posicion_fila, posicion_columna, responsable_ingreso, responsable_salida) VALUES
(7, 2, TO_TIMESTAMP('2024-03-19 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'FRIO', 1, 1, 15, NULL);
INSERT INTO carga_ubicacion (id_envio, id_bodega, fecha_ingreso, fecha_salida, posicion_estante, posicion_fila, posicion_columna, responsable_ingreso, responsable_salida) VALUES
(8, 1, TO_TIMESTAMP('2024-03-19 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, 'PEL', 1, 1, 12, NULL);

-- =====================================================
-- MÓDULO 20: MANTENIMIENTO PREDICTIVO (10 TABLAS)
-- =====================================================

-- Tabla 20.1: sensores_avion (se omite id_sensor)
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(3, 'B787-ENG-001', 'MOTOR', 'Motor izquierdo', 'Rolls-Royce', 'Trent 1000 Sensor', 'RR-001-2024', DATE '2024-01-01', DATE '2024-01-01', 60, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(3, 'B787-ENG-002', 'MOTOR', 'Motor derecho', 'Rolls-Royce', 'Trent 1000 Sensor', 'RR-002-2024', DATE '2024-01-01', DATE '2024-01-01', 60, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(3, 'B787-TEMP-001', 'TEMPERATURA', 'Cabina', 'Honeywell', 'HT-2000', 'HW-001-2024', DATE '2024-01-01', DATE '2024-01-01', 30, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(3, 'B787-PRES-001', 'PRESION', 'Cabina', 'Honeywell', 'HP-1000', 'HW-002-2024', DATE '2024-01-01', DATE '2024-01-01', 30, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(1, 'B738-VIB-001', 'VIBRACION', 'Motor CFM56', 'General Electric', 'GE-V100', 'GE-001-2023', DATE '2023-06-01', DATE '2023-12-01', 10, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(1, 'B738-FUEL-001', 'COMBUSTIBLE', 'Tanque ala izquierda', 'Parker', 'PF-500', 'PK-001-2023', DATE '2023-06-01', DATE '2023-12-01', 120, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(2, 'A320-ENG-001', 'MOTOR', 'Motor IAE', 'Pratt & Whitney', 'PW1000G', 'PW-001-2023', DATE '2023-05-01', DATE '2023-11-01', 60, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(4, 'A350-HYD-001', 'HIDRAULICO', 'Sistema hidráulico', 'Eaton', 'E-H100', 'ET-001-2024', DATE '2024-02-01', DATE '2024-02-01', 15, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(5, 'B777-ALT-001', 'ALTITUD', 'Sistema navegación', 'Rockwell Collins', 'RC-ALT', 'RC-001-2022', DATE '2022-01-01', DATE '2024-01-01', 5, 1);
INSERT INTO sensores_avion (id_modelo_avion, codigo_sensor, tipo_sensor, ubicacion_fisica, fabricante, modelo_sensor, numero_serie, fecha_instalacion, fecha_ultima_calibracion, frecuencia_lectura_segundos, activo) VALUES
(5, 'B777-VIB-002', 'VIBRACION', 'Motor GE90', 'General Electric', 'GE-V200', 'GE-002-2022', DATE '2022-01-01', DATE '2024-01-01', 10, 1);

-- Tabla 20.2: lecturas_sensores (se omite id_lectura)
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(1, 1, TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 24500, 'RPM', 98, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(2, 1, TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 24480, 'RPM', 99, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(3, 1, TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 22.5, '°C', 100, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(4, 1, TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 14.7, 'psi', 100, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(5, 3, TO_TIMESTAMP('2024-03-18 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), 1.2, 'mm/s', 95, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(6, 3, TO_TIMESTAMP('2024-03-18 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), 4500, 'litros', 98, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(7, 2, TO_TIMESTAMP('2024-03-18 10:15:00', 'YYYY-MM-DD HH24:MI:SS'), 23500, 'RPM', 97, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(8, 4, TO_TIMESTAMP('2024-03-18 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), 3000, 'psi', 99, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(9, 5, TO_TIMESTAMP('2024-03-18 20:30:00', 'YYYY-MM-DD HH24:MI:SS'), 35000, 'pies', 100, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(10, 5, TO_TIMESTAMP('2024-03-18 20:30:00', 'YYYY-MM-DD HH24:MI:SS'), 2.5, 'mm/s', 96, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(5, 3, TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 3.8, 'mm/s', 92, 1);
INSERT INTO lecturas_sensores (id_sensor, id_vuelo, timestamp_lectura, valor_lectura, unidad_medida, calidad_lectura, procesado) VALUES
(5, 3, TO_TIMESTAMP('2024-03-18 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 4.2, 'mm/s', 91, 1);

-- Tabla 20.3: alertas_tecnicas (se omite id_alerta_tecnica)
INSERT INTO alertas_tecnicas (id_lectura, nivel_alerta, tipo_alerta, descripcion, valor_umbral, valor_actual, fecha_alerta, atendida, fecha_atencion, atendido_por, acciones_tomadas) VALUES
(11, 'PREVENTIVO', 'VIBRACIÓN', 'Aumento de vibración en motor', 3.0, 3.8, TO_TIMESTAMP('2024-03-18 09:35:00', 'YYYY-MM-DD HH24:MI:SS'), 1, TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2, 'Programar revisión en destino');
INSERT INTO alertas_tecnicas (id_lectura, nivel_alerta, tipo_alerta, descripcion, valor_umbral, valor_actual, fecha_alerta, atendida, fecha_atencion, atendido_por, acciones_tomadas) VALUES
(12, 'CRITICO', 'VIBRACIÓN', 'Nivel de vibración crítico', 4.0, 4.2, TO_TIMESTAMP('2024-03-18 10:35:00', 'YYYY-MM-DD HH24:MI:SS'), 1, TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2, 'Mantenimiento urgente al aterrizar');
INSERT INTO alertas_tecnicas (id_lectura, nivel_alerta, tipo_alerta, descripcion, valor_umbral, valor_actual, fecha_alerta, atendida, fecha_atencion, atendido_por, acciones_tomadas) VALUES
(8, 'INFORMATIVO', 'HIDRAULICO', 'Presión hidráulica normal', NULL, 3000, TO_TIMESTAMP('2024-03-18 15:35:00', 'YYYY-MM-DD HH24:MI:SS'), 0, NULL, NULL, NULL);

-- Tabla 20.4: piezas_reemplazo (se omite id_pieza)
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('BP-FAN-001', 'Fan Blade', 'Álabes de ventilador', 1, 1, 'B737-FAN-123', 15, 5, 30, 'Almacén MAD A1', 12500.00, 'USD', 30, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('AIR-TUR-002', 'Turbina', 'Turbina de baja presión', 2, 2, 'A320-TUR-456', 8, 3, 15, 'Almacén MAD B2', 45000.00, 'EUR', 45, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('BOE-LAN-003', 'Tren de aterrizaje', 'Tren principal', 3, 1, 'B787-LG-789', 2, 2, 5, 'Almacén MAD C3', 250000.00, 'USD', 90, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('AIR-FREN-004', 'Frenos', 'Pastillas de freno', 4, 2, 'A350-BRK-101', 50, 10, 100, 'Almacén MAD A1', 850.00, 'EUR', 15, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('BOE-COMP-005', 'Compresor', 'Compresor alta presión', 5, 1, 'B777-COMP-202', 5, 3, 10, 'Almacén MAD B2', 75000.00, 'USD', 60, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('EMB-AS-006', 'Asiento', 'Asiento clase económica', 7, 3, 'E195-SEAT-303', 30, 10, 60, 'Almacén MAD C3', 1200.00, 'USD', 20, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('BOM-WIN-007', 'Ventana', 'Ventana cabina', 8, 4, 'CRJ-WIN-404', 8, 3, 15, 'Almacén MAD A1', 3500.00, 'CAD', 25, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('ATR-PROP-008', 'Hélice', 'Hélice completa', 9, 5, 'ATR-PROP-505', 4, 2, 8, 'Almacén MAD B2', 28000.00, 'EUR', 40, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('AIR-COMP-009', 'Computadora', 'Computadora de vuelo', 10, 2, 'A330-FMC-606', 3, 2, 6, 'Almacén MAD C3', 45000.00, 'EUR', 30, 1);
INSERT INTO piezas_reemplazo (codigo_pieza, nombre_pieza, descripcion, id_modelo_avion, id_fabricante, numero_parte_fabricante, stock_actual, stock_minimo, stock_maximo, ubicacion_almacen, precio_unitario, moneda, tiempo_reorden_dias, activo) VALUES
('BOE-BAT-010', 'Batería', 'Batería principal', 1, 1, 'B737-BAT-707', 25, 5, 50, 'Almacén MAD A1', 2500.00, 'USD', 10, 1);

-- Tabla 20.5: ordenes_mantenimiento_predictivo (se omite id_orden_mp)
INSERT INTO ordenes_mantenimiento_predictivo (id_alerta_tecnica, id_pieza, id_avion_matricula, fecha_creacion, prioridad, descripcion_trabajo, tecnico_asignado, fecha_inicio_estimada, fecha_fin_estimada, fecha_inicio_real, fecha_fin_real, estado, horas_trabajadas, costo_estimado, costo_real, observaciones) VALUES
(2, 1, 'EC-MAD', TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'URGENTE', 'Revisión de vibración excesiva en motor', 2, DATE '2024-03-19', DATE '2024-03-19', DATE '2024-03-19', DATE '2024-03-19', 'COMPLETADO', 4, 2500.00, 2700.00, 'Se reemplazó sensor de vibración');
INSERT INTO ordenes_mantenimiento_predictivo (id_alerta_tecnica, id_pieza, id_avion_matricula, fecha_creacion, prioridad, descripcion_trabajo, tecnico_asignado, fecha_inicio_estimada, fecha_fin_estimada, fecha_inicio_real, fecha_fin_real, estado, horas_trabajadas, costo_estimado, costo_real, observaciones) VALUES
(NULL, 4, 'F-AIRB', TO_TIMESTAMP('2024-03-17 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'MEDIA', 'Cambio de pastillas de freno', 3, DATE '2024-03-20', DATE '2024-03-20', NULL, NULL, 'PENDIENTE', NULL, 1500.00, NULL, 'Programado');
INSERT INTO ordenes_mantenimiento_predictivo (id_alerta_tecnica, id_pieza, id_avion_matricula, fecha_creacion, prioridad, descripcion_trabajo, tecnico_asignado, fecha_inicio_estimada, fecha_fin_estimada, fecha_inicio_real, fecha_fin_real, estado, horas_trabajadas, costo_estimado, costo_real, observaciones) VALUES
(NULL, 8, 'F-ORLY', TO_TIMESTAMP('2024-03-15 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'BAJA', 'Revisión anual de hélice', 4, DATE '2024-04-01', DATE '2024-04-02', NULL, NULL, 'PENDIENTE', NULL, 3500.00, NULL, NULL);
INSERT INTO ordenes_mantenimiento_predictivo (id_alerta_tecnica, id_pieza, id_avion_matricula, fecha_creacion, prioridad, descripcion_trabajo, tecnico_asignado, fecha_inicio_estimada, fecha_fin_estimada, fecha_inicio_real, fecha_fin_real, estado, horas_trabajadas, costo_estimado, costo_real, observaciones) VALUES
(NULL, 9, 'CS-TMT', TO_TIMESTAMP('2024-03-10 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'ALTA', 'Actualización de software FMC', 5, DATE '2024-03-22', DATE '2024-03-22', NULL, NULL, 'ASIGNADO', NULL, 5000.00, NULL, NULL);
INSERT INTO ordenes_mantenimiento_predictivo (id_alerta_tecnica, id_pieza, id_avion_matricula, fecha_creacion, prioridad, descripcion_trabajo, tecnico_asignado, fecha_inicio_estimada, fecha_fin_estimada, fecha_inicio_real, fecha_fin_real, estado, horas_trabajadas, costo_estimado, costo_real, observaciones) VALUES
(NULL, 2, 'EC-BCN', TO_TIMESTAMP('2024-03-16 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'MEDIA', 'Inspección de turbina', 2, DATE '2024-03-25', DATE '2024-03-26', NULL, NULL, 'PENDIENTE', NULL, 8000.00, NULL, NULL);

-- Tabla 20.6: checklists_mantenimiento (se omite id_checklist)
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(1, 'B737-A-CHK', 'Check A Boeing 737', 'PREVENTIVO', 500, NULL, 480, 0, 1, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(2, 'A320-A-CHK', 'Check A Airbus A320', 'PREVENTIVO', 600, NULL, 450, 0, 1, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(3, 'B787-ENG-CHK', 'Revisión motores', 'PREDICTIVO', NULL, 30, 120, 1, 1, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(4, 'A350-LG-CHK', 'Revisión tren aterrizaje', 'PREVENTIVO', 1000, NULL, 300, 1, 1, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(5, 'B777-ENG-CHK', 'Revisión motores GE90', 'PREDICTIVO', NULL, 45, 180, 1, 1, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(7, 'E195-AV-CHK', 'Revisión aviónica', 'PREVENTIVO', 400, NULL, 240, 0, 1, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(9, 'ATR-PROP-CHK', 'Revisión hélices', 'MAYOR', 2000, NULL, 360, 1, 1, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(1, 'B737-FUEL-CHK', 'Revisión sistema combustible', 'CORRECTIVO', NULL, NULL, 90, 0, 1, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(3, 'B787-CAB-CHK', 'Revisión cabina', 'PREVENTIVO', 150, NULL, 60, 0, 0, 1);
INSERT INTO checklists_mantenimiento (id_modelo_avion, codigo_checklist, nombre_checklist, tipo_mantenimiento, frecuencia_horas_vuelo, frecuencia_dias, tiempo_estimado_minutos, requiere_herramientas_especiales, requiere_certificacion, activo) VALUES
(2, 'A320-HYD-CHK', 'Revisión sistema hidráulico', 'PREDICTIVO', NULL, 15, 45, 0, 1, 1);

-- Tabla 20.7: checklist_tareas (se omite id_tarea)
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(1, 1, 'Revisar nivel de aceite motores', 30, 1, 'Cantidad litros', '18-22 litros');
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(1, 2, 'Inspeccionar neumáticos', 45, 1, 'Presión psi', '190-210 psi');
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(1, 3, 'Comprobar luces exteriores', 20, 0, NULL, NULL);
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(2, 1, 'Revisar sistema hidráulico', 40, 1, 'Presión psi', '2900-3100 psi');
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(2, 2, 'Inspeccionar flaps', 35, 1, 'Ángulo máximo', '35-40 grados');
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(3, 1, 'Análisis vibración motor izquierdo', 30, 1, 'mm/s', '<3.0');
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(3, 2, 'Análisis vibración motor derecho', 30, 1, 'mm/s', '<3.0');
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(4, 1, 'Inspección visual tren principal', 60, 1, NULL, NULL);
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(5, 1, 'Análisis de aceite motor', 20, 1, 'Contaminación ppm', '<10 ppm');
INSERT INTO checklist_tareas (id_checklist, numero_orden, descripcion_tarea, tiempo_estimado_minutos, requiere_inspeccion, parametros_medicion, valores_aceptables) VALUES
(7, 1, 'Balanceo de hélices', 120, 1, 'Desequilibrio', '<0.2 in/s');

-- Tabla 20.8: checklist_ejecucion (se omite id_ejecucion)
INSERT INTO checklist_ejecucion (id_orden_mp, id_checklist, fecha_inicio, fecha_fin, tecnico_ejecutor, supervisor, resultado, observaciones) VALUES
(1, 3, TO_TIMESTAMP('2024-03-19 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2, 3, 'APROBADO_CON_OBS', 'Vibración dentro de parámetros tras ajuste');
INSERT INTO checklist_ejecucion (id_orden_mp, id_checklist, fecha_inicio, fecha_fin, tecnico_ejecutor, supervisor, resultado, observaciones) VALUES
(2, 4, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO checklist_ejecucion (id_orden_mp, id_checklist, fecha_inicio, fecha_fin, tecnico_ejecutor, supervisor, resultado, observaciones) VALUES
(4, 6, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO checklist_ejecucion (id_orden_mp, id_checklist, fecha_inicio, fecha_fin, tecnico_ejecutor, supervisor, resultado, observaciones) VALUES
(1, 9, TO_TIMESTAMP('2024-03-19 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 6, 3, 'APROBADO', 'Cabina en perfecto estado');

-- Tabla 20.9: tareas_ejecutadas (se omite id_tarea_ejecutada)
INSERT INTO tareas_ejecutadas (id_ejecucion, id_tarea, fecha_ejecucion, tiempo_real_minutos, resultados_medicion, conforme, observaciones_tarea) VALUES
(1, 6, TO_TIMESTAMP('2024-03-19 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 25, '2.8 mm/s', 1, 'Dentro de límites');
INSERT INTO tareas_ejecutadas (id_ejecucion, id_tarea, fecha_ejecucion, tiempo_real_minutos, resultados_medicion, conforme, observaciones_tarea) VALUES
(1, 7, TO_TIMESTAMP('2024-03-19 09:45:00', 'YYYY-MM-DD HH24:MI:SS'), 28, '2.5 mm/s', 1, NULL);
INSERT INTO tareas_ejecutadas (id_ejecucion, id_tarea, fecha_ejecucion, tiempo_real_minutos, resultados_medicion, conforme, observaciones_tarea) VALUES
(4, 3, TO_TIMESTAMP('2024-03-19 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 15, 'Todas OK', 1, NULL);

-- Tabla 20.10: proveedores_repuestos (se omite id_proveedor_repuesto)
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(1, 1, 12000.00, 25, 5, DATE '2024-03-01', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(1, 3, 240000.00, 40, 5, DATE '2024-02-15', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(1, 5, 72000.00, 35, 4, DATE '2024-01-10', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(3, 4, 800.00, 10, 5, DATE '2024-03-10', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(3, 6, 1150.00, 15, 4, DATE '2024-02-20', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(6, 2, 44000.00, 30, 5, DATE '2024-03-05', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(6, 9, 43000.00, 25, 5, DATE '2024-02-28', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(7, 10, 2400.00, 8, 4, DATE '2024-03-12', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(10, 7, 3400.00, 20, 4, DATE '2024-03-08', 1);
INSERT INTO proveedores_repuestos (id_proveedor, id_pieza, precio_contrato, tiempo_entrega_dias, calificacion, ultima_compra, activo) VALUES
(10, 8, 27000.00, 35, 5, DATE '2024-02-05', 1);

-- =====================================================
-- MÓDULO 21: OPERACIONES EN TIEMPO REAL (10 TABLAS)
-- =====================================================

-- Tabla 21.1: posiciones_radar (continuación)
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(1, TO_TIMESTAMP('2024-03-18 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 34.5000, -20.5000, 36000, 485, 238, 100, 'RADAR', 96, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(1, TO_TIMESTAMP('2024-03-18 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 32.0000, -25.5000, 37000, 488, 240, 0, 'RADAR', 97, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(2, TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 28.5000, -55.0000, 35000, 470, 58, -150, 'RADAR', 96, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(2, TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 26.0000, -60.0000, 34000, 465, 55, -200, 'ADS-B', 98, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(3, TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 37.5000, -96.0000, 35000, 515, 265, 500, 'RADAR', 99, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(3, TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 35.2000, -99.5000, 36000, 518, 260, 0, 'MLAT', 98, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(4, TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 48.5000, -40.0000, 33000, 500, 80, -200, 'RADAR', 95, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(4, TO_TIMESTAMP('2024-03-18 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 46.2000, -45.0000, 32000, 495, 75, -300, 'SATELITE', 94, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(6, TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 50.5000, -32.0000, 33000, 485, 290, -100, 'RADAR', 97, 1);
INSERT INTO posiciones_radar (id_vuelo, timestamp_posicion, latitud, longitud, altitud_pies, velocidad_nudos, heading_grados, tasa_ascenso, fuente_datos, precision_posicion, procesado) VALUES
(6, TO_TIMESTAMP('2024-03-18 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 48.8000, -35.5000, 32000, 480, 285, -200, 'ADS-B', 98, 1);

-- Tabla 21.2: torre_control_comunicaciones (continuación)
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(2, TO_TIMESTAMP('2024-03-18 09:45:00', 'YYYY-MM-DD HH24:MI:SS'), '118.3', 'AUTORIZACION', 'AV123', 'BOG Torre', 'AV123 solicita autorización de rodaje', 2, 1);
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(2, TO_TIMESTAMP('2024-03-18 09:48:00', 'YYYY-MM-DD HH24:MI:SS'), '118.3', 'AUTORIZACION', 'BOG Torre', 'AV123', 'AV123 autorizado rodaje pista 13L', 2, 1);
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(4, TO_TIMESTAMP('2024-03-18 14:50:00', 'YYYY-MM-DD HH24:MI:SS'), '119.5', 'INFORMACION', 'DL789', 'JFK Torre', 'DL789 informa retraso por catering', 4, 1);
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(6, TO_TIMESTAMP('2024-03-18 08:55:00', 'YYYY-MM-DD HH24:MI:SS'), '118.9', 'CONSULTA', 'AF345', 'CDG Torre', 'AF345 solicita cambio de puerta', 6, 1);
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(6, TO_TIMESTAMP('2024-03-18 08:58:00', 'YYYY-MM-DD HH24:MI:SS'), '118.9', 'INFORMACION', 'CDG Torre', 'AF345', 'AF345 asignado puerta C1', 6, 1);
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(8, TO_TIMESTAMP('2024-03-19 21:30:00', 'YYYY-MM-DD HH24:MI:SS'), '119.3', 'EMERGENCIA', 'LA890', 'GRU Torre', 'LA890 reporta falla técnica', 7, 1);
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(8, TO_TIMESTAMP('2024-03-19 21:35:00', 'YYYY-MM-DD HH24:MI:SS'), '119.3', 'EMERGENCIA', 'GRU Torre', 'LA890', 'LA890 proceda a puerta de regreso', 7, 1);
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(9, TO_TIMESTAMP('2024-03-20 10:50:00', 'YYYY-MM-DD HH24:MI:SS'), '118.7', 'AUTORIZACION', 'EK212', 'MEX Torre', 'EK212 solicita pushback', 8, 1);
INSERT INTO torre_control_comunicaciones (id_vuelo, timestamp_comunicacion, frecuencia_mhz, tipo_comunicacion, origen, destino, mensaje, operador_torre, transcrito) VALUES
(9, TO_TIMESTAMP('2024-03-20 10:53:00', 'YYYY-MM-DD HH24:MI:SS'), '118.7', 'AUTORIZACION', 'MEX Torre', 'EK212', 'EK212 autorizado pushback', 8, 1);

-- Tabla 21.3: asignacion_pistas_tiempo_real (continuación)
INSERT INTO asignacion_pistas_tiempo_real (id_pista, id_vuelo, tipo_operacion, fecha_hora_asignacion, hora_inicio_estimada, hora_fin_estimada, hora_inicio_real, hora_fin_real, estado_asignacion, asignado_por, observaciones) VALUES
(5, 2, 'DESPEGUE', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:05:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:03:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADA', 2, NULL);
INSERT INTO asignacion_pistas_tiempo_real (id_pista, id_vuelo, tipo_operacion, fecha_hora_asignacion, hora_inicio_estimada, hora_fin_estimada, hora_inicio_real, hora_fin_real, estado_asignacion, asignado_por, observaciones) VALUES
(6, 9, 'ATERRIZAJE', TO_TIMESTAMP('2024-03-20 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 20:10:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 20:15:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 20:18:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADA', 8, 'Retraso por clima');
INSERT INTO asignacion_pistas_tiempo_real (id_pista, id_vuelo, tipo_operacion, fecha_hora_asignacion, hora_inicio_estimada, hora_fin_estimada, hora_inicio_real, hora_fin_real, estado_asignacion, asignado_por, observaciones) VALUES
(10, 7, 'DESPEGUE', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 13:05:00', 'YYYY-MM-DD HH24:MI:SS'), NULL, NULL, 'CANCELADA', 4, 'Vuelo cancelado');

-- Tabla 21.4: condiciones_pista_tiempo_real (continuación)
INSERT INTO condiciones_pista_tiempo_real (id_pista, fecha_hora_registro, estado_pista, condicion_superficie, coeficiente_friccion, visibilidad_metros, techonubes_pies, viento_direccion_grados, viento_velocidad_nudos, observaciones, registrado_por) VALUES
(2, TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERATIVA', 'SECA', 0.86, 10000, NULL, 50, 12, NULL, 1);
INSERT INTO condiciones_pista_tiempo_real (id_pista, fecha_hora_registro, estado_pista, condicion_superficie, coeficiente_friccion, visibilidad_metros, techonubes_pies, viento_direccion_grados, viento_velocidad_nudos, observaciones, registrado_por) VALUES
(5, TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERATIVA', 'SECA', 0.85, 9000, 12000, 130, 8, NULL, 2);
INSERT INTO condiciones_pista_tiempo_real (id_pista, fecha_hora_registro, estado_pista, condicion_superficie, coeficiente_friccion, visibilidad_metros, techonubes_pies, viento_direccion_grados, viento_velocidad_nudos, observaciones, registrado_por) VALUES
(6, TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERATIVA', 'SECA', 0.87, 11000, NULL, 80, 10, NULL, 3);
INSERT INTO condiciones_pista_tiempo_real (id_pista, fecha_hora_registro, estado_pista, condicion_superficie, coeficiente_friccion, visibilidad_metros, techonubes_pies, viento_direccion_grados, viento_velocidad_nudos, observaciones, registrado_por) VALUES
(1, TO_TIMESTAMP('2024-03-19 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERATIVA', 'MOJADA', 0.62, 5000, 8000, 210, 18, 'Lluvia moderada', 2);
INSERT INTO condiciones_pista_tiempo_real (id_pista, fecha_hora_registro, estado_pista, condicion_superficie, coeficiente_friccion, visibilidad_metros, techonubes_pies, viento_direccion_grados, viento_velocidad_nudos, observaciones, registrado_por) VALUES
(3, TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERATIVA', 'SECA', 0.88, 12000, NULL, 30, 5, NULL, 1);

-- Tabla 21.5: slots_aeropuerto (continuación)
INSERT INTO slots_aeropuerto (id_aerolinea, fecha_slot, hora_slot, tipo_operacion, id_vuelo_asignado, estado_slot, fecha_asignacion, asignado_por, fecha_liberacion, motivo_cancelacion) VALUES
(2, DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DESPEGUE', 2, 'UTILIZADO', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2, NULL, NULL);
INSERT INTO slots_aeropuerto (id_aerolinea, fecha_slot, hora_slot, tipo_operacion, id_vuelo_asignado, estado_slot, fecha_asignacion, asignado_por, fecha_liberacion, motivo_cancelacion) VALUES
(6, DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DESPEGUE', 6, 'UTILIZADO', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 3, NULL, NULL);
INSERT INTO slots_aeropuerto (id_aerolinea, fecha_slot, hora_slot, tipo_operacion, id_vuelo_asignado, estado_slot, fecha_asignacion, asignado_por, fecha_liberacion, motivo_cancelacion) VALUES
(7, DATE '2024-03-19', TO_TIMESTAMP('2024-03-19 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DESPEGUE', 7, 'CANCELADO', TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4, TO_TIMESTAMP('2024-03-19 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Huelga');
INSERT INTO slots_aeropuerto (id_aerolinea, fecha_slot, hora_slot, tipo_operacion, id_vuelo_asignado, estado_slot, fecha_asignacion, asignado_por, fecha_liberacion, motivo_cancelacion) VALUES
(3, DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DESPEGUE', 3, 'UTILIZADO', TO_TIMESTAMP('2024-03-19 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 3, NULL, NULL);
INSERT INTO slots_aeropuerto (id_aerolinea, fecha_slot, hora_slot, tipo_operacion, id_vuelo_asignado, estado_slot, fecha_asignacion, asignado_por, fecha_liberacion, motivo_cancelacion) VALUES
(4, DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DESPEGUE', NULL, 'DISPONIBLE', NULL, NULL, NULL, NULL);

-- Tabla 21.6: retrasos_tiempo_real (continuación)
INSERT INTO retrasos_tiempo_real (id_vuelo, fecha_hora_registro, tipo_retraso, causa_especifica, minutos_retraso_actuales, minutos_retraso_estimados, impacto_global, afecta_conexiones, notificado_pasajeros, actualizado_por, observaciones) VALUES
(2, TO_TIMESTAMP('2024-03-18 09:50:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERACIONAL', 'Espera de autorización', 0, 0, 0, 0, 0, 2, 'Sin retraso');
INSERT INTO retrasos_tiempo_real (id_vuelo, fecha_hora_registro, tipo_retraso, causa_especifica, minutos_retraso_actuales, minutos_retraso_estimados, impacto_global, afecta_conexiones, notificado_pasajeros, actualizado_por, observaciones) VALUES
(3, TO_TIMESTAMP('2024-03-18 07:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'TRANSITO', 'Congestión en pista', 5, 5, 0, 0, 1, 3, NULL);
INSERT INTO retrasos_tiempo_real (id_vuelo, fecha_hora_registro, tipo_retraso, causa_especifica, minutos_retraso_actuales, minutos_retraso_estimados, impacto_global, afecta_conexiones, notificado_pasajeros, actualizado_por, observaciones) VALUES
(5, TO_TIMESTAMP('2024-03-18 19:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'TRIPULACION', 'Cambio de tripulación', 0, 0, 0, 0, 0, 5, 'Sin retraso');
INSERT INTO retrasos_tiempo_real (id_vuelo, fecha_hora_registro, tipo_retraso, causa_especifica, minutos_retraso_actuales, minutos_retraso_estimados, impacto_global, afecta_conexiones, notificado_pasajeros, actualizado_por, observaciones) VALUES
(9, TO_TIMESTAMP('2024-03-20 10:55:00', 'YYYY-MM-DD HH24:MI:SS'), 'OPERACIONAL', 'Espera de combustible', 5, 10, 0, 0, 1, 8, NULL);
INSERT INTO retrasos_tiempo_real (id_vuelo, fecha_hora_registro, tipo_retraso, causa_especifica, minutos_retraso_actuales, minutos_retraso_estimados, impacto_global, afecta_conexiones, notificado_pasajeros, actualizado_por, observaciones) VALUES
(10, TO_TIMESTAMP('2024-03-20 13:55:00', 'YYYY-MM-DD HH24:MI:SS'), 'TRANSITO', 'Tráfico aéreo', 0, 0, 0, 0, 0, 1, 'Puntual');

-- Tabla 21.7: capacidad_terminal_tiempo_real (continuación)
INSERT INTO capacidad_terminal_tiempo_real (terminal, fecha_hora_medicion, pasajeros_actuales, pasajeros_estimados_salida, pasajeros_estimados_llegada, pasajeros_en_transito, capacidad_maxima, porcentaje_ocupacion, nivel_congestion, tiempo_espera_seguridad_minutos, medicion_automatica, registrado_por) VALUES
('T1', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2800, 2500, 2300, 400, 5000, 56.00, 'MODERADO', 12, 1, NULL);
INSERT INTO capacidad_terminal_tiempo_real (terminal, fecha_hora_medicion, pasajeros_actuales, pasajeros_estimados_salida, pasajeros_estimados_llegada, pasajeros_en_transito, capacidad_maxima, porcentaje_ocupacion, nivel_congestion, tiempo_espera_seguridad_minutos, medicion_automatica, registrado_por) VALUES
('T2', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 3200, 2800, 3000, 600, 5500, 58.18, 'MODERADO', 14, 1, NULL);
INSERT INTO capacidad_terminal_tiempo_real (terminal, fecha_hora_medicion, pasajeros_actuales, pasajeros_estimados_salida, pasajeros_estimados_llegada, pasajeros_en_transito, capacidad_maxima, porcentaje_ocupacion, nivel_congestion, tiempo_espera_seguridad_minutos, medicion_automatica, registrado_por) VALUES
('T3', TO_TIMESTAMP('2024-03-18 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), 4100, 3500, 3800, 800, 6000, 68.33, 'ALTO', 22, 1, NULL);
INSERT INTO capacidad_terminal_tiempo_real (terminal, fecha_hora_medicion, pasajeros_actuales, pasajeros_estimados_salida, pasajeros_estimados_llegada, pasajeros_en_transito, capacidad_maxima, porcentaje_ocupacion, nivel_congestion, tiempo_espera_seguridad_minutos, medicion_automatica, registrado_por) VALUES
('T4', TO_TIMESTAMP('2024-03-19 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 3500, 3200, 3000, 500, 8000, 43.75, 'BAJO', 8, 1, NULL);
INSERT INTO capacidad_terminal_tiempo_real (terminal, fecha_hora_medicion, pasajeros_actuales, pasajeros_estimados_salida, pasajeros_estimados_llegada, pasajeros_en_transito, capacidad_maxima, porcentaje_ocupacion, nivel_congestion, tiempo_espera_seguridad_minutos, medicion_automatica, registrado_por) VALUES
('T5', TO_TIMESTAMP('2024-03-20 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 5200, 4800, 5000, 1200, 10000, 52.00, 'MODERADO', 16, 1, NULL);

-- Tabla 21.8: alertas_operacionales (continuación)
INSERT INTO alertas_operacionales (tipo_alerta, nivel_alerta, descripcion, fecha_hora_inicio, fecha_hora_fin, area_afectada, vuelos_afectados, pasajeros_afectados, acciones_recomendadas, activa, creada_por, cerrada_por) VALUES
('RETRASO_GENERAL', 'PREVENTIVO', 'Acumulación de retrasos por clima', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Todas las terminales', 12, 2800, 'Informar a pasajeros', 0, 2, 3);
INSERT INTO alertas_operacionales (tipo_alerta, nivel_alerta, descripcion, fecha_hora_inicio, fecha_hora_fin, area_afectada, vuelos_afectados, pasajeros_afectados, acciones_recomendadas, activa, creada_por, cerrada_por) VALUES
('CONGESTION', 'CRITICO', 'Saturación en zona de recogida de equipajes', TO_TIMESTAMP('2024-03-19 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 19:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'T4 Llegadas', 8, 1500, 'Reforzar personal', 0, 4, 5);
INSERT INTO alertas_operacionales (tipo_alerta, nivel_alerta, descripcion, fecha_hora_inicio, fecha_hora_fin, area_afectada, vuelos_afectados, pasajeros_afectados, acciones_recomendadas, activa, creada_por, cerrada_por) VALUES
('FALLA_TECNICA', 'CRITICO', 'Falla en sistema de handling', TO_TIMESTAMP('2024-03-20 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Zona de carga', 5, 0, 'Activar sistema manual', 0, 6, 7);

-- Tabla 21.9: historial_flujo_trafico (continuación)
INSERT INTO historial_flujo_trafico (fecha_hora_inicio, fecha_hora_fin, tipo_medicion, despegues_hora, aterrizajes_hora, total_operaciones_hora, pasajeros_salida_hora, pasajeros_llegada_hora, total_pasajeros_hora, pico_operaciones, observaciones) VALUES
(TO_TIMESTAMP('2024-03-19 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'POR_HORA', 34, 30, 64, 4000, 3600, 7600, 1, 'Hora pico mañana');
INSERT INTO historial_flujo_trafico (fecha_hora_inicio, fecha_hora_fin, tipo_medicion, despegues_hora, aterrizajes_hora, total_operaciones_hora, pasajeros_salida_hora, pasajeros_llegada_hora, total_pasajeros_hora, pico_operaciones, observaciones) VALUES
(TO_TIMESTAMP('2024-03-19 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'POR_HORA', 36, 34, 70, 4600, 4400, 9000, 1, 'Hora pico tarde');
INSERT INTO historial_flujo_trafico (fecha_hora_inicio, fecha_hora_fin, tipo_medicion, despegues_hora, aterrizajes_hora, total_operaciones_hora, pasajeros_salida_hora, pasajeros_llegada_hora, total_pasajeros_hora, pico_operaciones, observaciones) VALUES
(DATE '2024-03-20', DATE '2024-03-21', 'POR_DIA', 830, 810, 1640, 108000, 103000, 211000, 0, 'Tráfico diario');

-- Tabla 21.10: prediccion_demanda (continuación)
INSERT INTO prediccion_demanda (fecha_prediccion, hora_prediccion, tipo_prediccion, valor_predicho, intervalo_confianza_inferior, intervalo_confianza_superior, modelo_utilizado, precision_historica, fecha_generacion, generado_por) VALUES
(DATE '2024-03-21', TO_TIMESTAMP('2024-03-21 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PASAJEROS', 4100.00, 3900.00, 4300.00, 'ARIMA', 92.5, TO_TIMESTAMP('2024-03-20 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'SISTEMA');
INSERT INTO prediccion_demanda (fecha_prediccion, hora_prediccion, tipo_prediccion, valor_predicho, intervalo_confianza_inferior, intervalo_confianza_superior, modelo_utilizado, precision_historica, fecha_generacion, generado_por) VALUES
(DATE '2024-03-21', TO_TIMESTAMP('2024-03-21 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PASAJEROS', 4400.00, 4200.00, 4600.00, 'ARIMA', 92.5, TO_TIMESTAMP('2024-03-20 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'SISTEMA');
INSERT INTO prediccion_demanda (fecha_prediccion, hora_prediccion, tipo_prediccion, valor_predicho, intervalo_confianza_inferior, intervalo_confianza_superior, modelo_utilizado, precision_historica, fecha_generacion, generado_por) VALUES
(DATE '2024-03-22', NULL, 'OPERACIONES', 1620.00, 1550.00, 1690.00, 'Prophet', 89.0, TO_TIMESTAMP('2024-03-21 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'SISTEMA');

COMMIT;
SELECT 'Módulo 21 completado' AS estado FROM dual;


-- =====================================================
-- MÓDULO 22: GESTIÓN DE COMBUSTIBLE (10 TABLAS)
-- =====================================================

-- Tabla 22.1: tanques_combustible (se omite id_tanque)
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-MAD-01', 'Tanque Norte MAD', 'JET_A1', 5000000.00, 3850000.00, 77.0, 'Zona norte MAD', DATE '2024-03-01', DATE '2024-02-15', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-MAD-02', 'Tanque Sur MAD', 'JET_A1', 4500000.00, 4200000.00, 93.3, 'Zona sur MAD', DATE '2024-03-01', DATE '2024-02-15', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-MAD-03', 'Tanque Emergencia', 'JET_A', 1000000.00, 950000.00, 95.0, 'Zona este MAD', DATE '2024-02-28', DATE '2024-02-28', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-BOG-01', 'Tanque Principal BOG', 'JET_A1', 8000000.00, 5200000.00, 65.0, 'Zona industrial BOG', DATE '2024-03-02', DATE '2024-02-20', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-BOG-02', 'Tanque Secundario BOG', 'JET_A1', 4000000.00, 3800000.00, 95.0, 'Zona industrial BOG', DATE '2024-03-02', DATE '2024-02-20', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-JFK-01', 'JFK Tank 1', 'JET_A1', 12000000.00, 8900000.00, 74.2, 'JFK Fuel Farm', DATE '2024-03-03', DATE '2024-03-01', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-CDG-01', 'CDG Tank', 'JET_A1', 10000000.00, 7200000.00, 72.0, 'CDG Cargo Area', DATE '2024-03-04', DATE '2024-03-02', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-MEX-01', 'Tanque MEX', 'JET_A1', 6000000.00, 5100000.00, 85.0, 'Zona de combustibles MEX', DATE '2024-03-05', DATE '2024-03-03', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-LAX-01', 'LAX Tank', 'JET_A1', 15000000.00, 12200000.00, 81.3, 'LAX Fuel Depot', DATE '2024-03-06', DATE '2024-03-04', 1);
INSERT INTO tanques_combustible (codigo_tanque, nombre_tanque, tipo_combustible, capacidad_litros, nivel_actual_litros, porcentaje_llenado, ubicacion, fecha_ultima_inspeccion, fecha_ultima_calibracion, activo) VALUES
('TAN-GRU-01', 'Tanque GRU', 'JET_A1', 9000000.00, 6800000.00, 75.6, 'GRU Fuel Farm', DATE '2024-03-07', DATE '2024-03-05', 1);

-- NO SE PUEDE REPETIR id_proveedor
-- Tabla 22.2: proveedores_combustible (se omite id_proveedor_combustible)
INSERT INTO proveedores_combustible (id_proveedor, tipo_combustible_suministrado, precio_compra_galon, moneda, contrato_vigente, fecha_inicio_contrato, fecha_fin_contrato, volumen_minimo_contrato, condiciones_especiales) VALUES
(1, 'JET_A1', 2.85, 'USD', 1, DATE '2024-01-01', DATE '2024-12-31', 10000000.00, 'Precio fijo anual');
INSERT INTO proveedores_combustible (id_proveedor, tipo_combustible_suministrado, precio_compra_galon, moneda, contrato_vigente, fecha_inicio_contrato, fecha_fin_contrato, volumen_minimo_contrato, condiciones_especiales) VALUES
(7, 'JET_A1', 2.90, 'USD', 1, DATE '2024-01-01', DATE '2024-06-30', 5000000.00, 'Precio variable');
INSERT INTO proveedores_combustible (id_proveedor, tipo_combustible_suministrado, precio_compra_galon, moneda, contrato_vigente, fecha_inicio_contrato, fecha_fin_contrato, volumen_minimo_contrato, condiciones_especiales) VALUES
(2, 'JET_A', 2.95, 'USD', 1, DATE '2024-01-01', DATE '2024-12-31', 2000000.00, NULL);
INSERT INTO proveedores_combustible (id_proveedor, tipo_combustible_suministrado, precio_compra_galon, moneda, contrato_vigente, fecha_inicio_contrato, fecha_fin_contrato, volumen_minimo_contrato, condiciones_especiales) VALUES
(6, 'AVGAS', 4.50, 'USD', 1, DATE '2024-01-01', DATE '2024-12-31', 500000.00, NULL);
INSERT INTO proveedores_combustible (id_proveedor, tipo_combustible_suministrado, precio_compra_galon, moneda, contrato_vigente, fecha_inicio_contrato, fecha_fin_contrato, volumen_minimo_contrato, condiciones_especiales) VALUES
(5, 'JET_A1', 2.80, 'USD', 0, DATE '2023-01-01', DATE '2023-12-31', 8000000.00, 'Contrato vencido');

-- Tabla 22.3: pedidos_combustible (se omite id_pedido_combustible)
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-001', 1, 85000.00, 'JET_A1', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADO', 'NORMAL', 2, 4, NULL);
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-002', 2, 60000.00, 'JET_A1', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADO', 'NORMAL', 3, 4, NULL);
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-003', 3, 30000.00, 'JET_A', TO_TIMESTAMP('2024-03-18 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADO', 'ALTA', 5, 4, NULL);
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-004', 4, 95000.00, 'JET_A1', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'CANCELADO', 'NORMAL', 7, 4, 'Vuelo cancelado');
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-005', 5, 145000.00, 'JET_A1', TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 19:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADO', 'NORMAL', 9, 4, NULL);
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-006', 6, 82000.00, 'JET_A1', TO_TIMESTAMP('2024-03-18 05:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADO', 'NORMAL', 8, 4, NULL);
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-007', 8, 0.00, 'JET_A1', TO_TIMESTAMP('2024-03-19 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 21:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'CANCELADO', 'NORMAL', 4, 4, 'Reprogramado');
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-008', 9, 138000.00, 'JET_A1', TO_TIMESTAMP('2024-03-20 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADO', 'NORMAL', 10, 4, NULL);
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-009', 10, 86000.00, 'JET_A1', TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 13:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETADO', 'NORMAL', 1, 4, NULL);
INSERT INTO pedidos_combustible (numero_pedido, id_vuelo, cantidad_solicitada_litros, tipo_combustible, fecha_pedido, fecha_requerida, estado_pedido, prioridad, solicitado_por, aprobado_por, observaciones) VALUES
('PED-010', 5, 500000.00, 'JET_A1', TO_TIMESTAMP('2024-03-20 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-21 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'APROBADO', 'NORMAL', 2, 4, 'Pedido para reabastecimiento de tanques');

-- Tabla 22.4: surtidores_combustible (se omite id_surtidor)
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-MAD-01', 'Puerta A1 MAD', 'JET_A1', 3000, 1, DATE '2024-03-01', DATE '2024-04-01', 1, NULL);
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-MAD-02', 'Puerta A2 MAD', 'JET_A1', 3000, 1, DATE '2024-03-01', DATE '2024-04-01', 1, NULL);
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-MAD-03', 'Puerta B1 MAD', 'JET_A', 2500, 1, DATE '2024-02-28', DATE '2024-03-28', 1, NULL);
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-BOG-01', 'Puerta 1 BOG', 'JET_A1', 2800, 1, DATE '2024-03-02', DATE '2024-04-02', 1, NULL);
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-BOG-02', 'Puerta 2 BOG', 'JET_A1', 2800, 0, DATE '2024-02-20', DATE '2024-03-20', 0, 'Fuera de servicio por mantenimiento');
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-JFK-01', 'Gate B1 JFK', 'JET_A1', 3500, 1, DATE '2024-03-03', DATE '2024-04-03', 1, NULL);
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-CDG-01', 'Gate C1 CDG', 'JET_A1', 3200, 1, DATE '2024-03-04', DATE '2024-04-04', 1, NULL);
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-MEX-01', 'Puerta 1 MEX', 'JET_A1', 2700, 1, DATE '2024-03-05', DATE '2024-04-05', 1, NULL);
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-LAX-01', 'Gate 1A LAX', 'JET_A1', 3600, 1, DATE '2024-03-06', DATE '2024-04-06', 1, NULL);
INSERT INTO surtidores_combustible (codigo_surtidor, ubicacion, tipo_combustible, velocidad_carga_litros_hora, disponible, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, operativo, observaciones) VALUES
('SUR-GRU-01', 'Portão 1 GRU', 'JET_A1', 2900, 1, DATE '2024-03-07', DATE '2024-04-07', 1, NULL);

-- Tabla 22.5: cargas_combustible (se omite id_carga_combustible)
INSERT INTO cargas_combustible (id_pedido_combustible, id_surtidor, cantidad_real_litros, temperatura_combustible, densidad_combustible, fecha_inicio_carga, fecha_fin_carga, duracion_minutos, operador_carga, verificador, lectura_inicial_contador, lectura_final_contador, incidencia_tecnica, observaciones) VALUES
(1, 1, 85200.00, 18.5, 0.802, TO_TIMESTAMP('2024-03-18 10:45:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:25:00', 'YYYY-MM-DD HH24:MI:SS'), 40, 2, 4, 125000, 210200, 0, NULL);
INSERT INTO cargas_combustible (id_pedido_combustible, id_surtidor, cantidad_real_litros, temperatura_combustible, densidad_combustible, fecha_inicio_carga, fecha_fin_carga, duracion_minutos, operador_carga, verificador, lectura_inicial_contador, lectura_final_contador, incidencia_tecnica, observaciones) VALUES
(2, 4, 59800.00, 20.1, 0.801, TO_TIMESTAMP('2024-03-18 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:05:00', 'YYYY-MM-DD HH24:MI:SS'), 35, 3, 4, 45000, 104800, 0, NULL);
INSERT INTO cargas_combustible (id_pedido_combustible, id_surtidor, cantidad_real_litros, temperatura_combustible, densidad_combustible, fecha_inicio_carga, fecha_fin_carga, duracion_minutos, operador_carga, verificador, lectura_inicial_contador, lectura_final_contador, incidencia_tecnica, observaciones) VALUES
(3, 3, 30200.00, 19.2, 0.798, TO_TIMESTAMP('2024-03-18 07:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'), 30, 5, 4, 89000, 119200, 0, NULL);
INSERT INTO cargas_combustible (id_pedido_combustible, id_surtidor, cantidad_real_litros, temperatura_combustible, densidad_combustible, fecha_inicio_carga, fecha_fin_carga, duracion_minutos, operador_carga, verificador, lectura_inicial_contador, lectura_final_contador, incidencia_tecnica, observaciones) VALUES
(5, 9, 146000.00, 22.5, 0.805, TO_TIMESTAMP('2024-03-18 18:45:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 19:40:00', 'YYYY-MM-DD HH24:MI:SS'), 55, 9, 4, 215000, 361000, 0, NULL);
INSERT INTO cargas_combustible (id_pedido_combustible, id_surtidor, cantidad_real_litros, temperatura_combustible, densidad_combustible, fecha_inicio_carga, fecha_fin_carga, duracion_minutos, operador_carga, verificador, lectura_inicial_contador, lectura_final_contador, incidencia_tecnica, observaciones) VALUES
(6, 7, 82500.00, 16.8, 0.800, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:40:00', 'YYYY-MM-DD HH24:MI:SS'), 40, 8, 4, 330000, 412500, 0, NULL);
INSERT INTO cargas_combustible (id_pedido_combustible, id_surtidor, cantidad_real_litros, temperatura_combustible, densidad_combustible, fecha_inicio_carga, fecha_fin_carga, duracion_minutos, operador_carga, verificador, lectura_inicial_contador, lectura_final_contador, incidencia_tecnica, observaciones) VALUES
(8, 8, 139500.00, 23.0, 0.803, TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 10:50:00', 'YYYY-MM-DD HH24:MI:SS'), 50, 10, 4, 180000, 319500, 0, NULL);
INSERT INTO cargas_combustible (id_pedido_combustible, id_surtidor, cantidad_real_litros, temperatura_combustible, densidad_combustible, fecha_inicio_carga, fecha_fin_carga, duracion_minutos, operador_carga, verificador, lectura_inicial_contador, lectura_final_contador, incidencia_tecnica, observaciones) VALUES
(9, 2, 86500.00, 19.5, 0.801, TO_TIMESTAMP('2024-03-20 12:45:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-20 13:25:00', 'YYYY-MM-DD HH24:MI:SS'), 40, 1, 4, 210200, 296700, 0, NULL);

-- Tabla 22.6: control_calidad_combustible (se omite id_muestra)
INSERT INTO control_calidad_combustible (id_tanque, fecha_muestra, fecha_analisis, numero_muestra, tipo_analisis, analista, densidad_medida, temperatura_prueba, presencia_agua, particulas_suspendidas, conductividad, resultado, aprobado_por, observaciones) VALUES
(1, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'M-001', 'RUTINA', 11, 0.802, 20.0, 0.0, 0.1, 250, 'APROBADO', 4, NULL);
INSERT INTO control_calidad_combustible (id_tanque, fecha_muestra, fecha_analisis, numero_muestra, tipo_analisis, analista, densidad_medida, temperatura_prueba, presencia_agua, particulas_suspendidas, conductividad, resultado, aprobado_por, observaciones) VALUES
(2, TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'M-002', 'RUTINA', 12, 0.801, 21.0, 0.0, 0.0, 245, 'APROBADO', 4, NULL);
INSERT INTO control_calidad_combustible (id_tanque, fecha_muestra, fecha_analisis, numero_muestra, tipo_analisis, analista, densidad_medida, temperatura_prueba, presencia_agua, particulas_suspendidas, conductividad, resultado, aprobado_por, observaciones) VALUES
(3, TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'M-003', 'RUTINA', 13, 0.798, 19.5, 0.0, 0.2, 260, 'APROBADO', 4, NULL);
INSERT INTO control_calidad_combustible (id_tanque, fecha_muestra, fecha_analisis, numero_muestra, tipo_analisis, analista, densidad_medida, temperatura_prueba, presencia_agua, particulas_suspendidas, conductividad, resultado, aprobado_por, observaciones) VALUES
(4, TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'M-004', 'RUTINA', 14, 0.803, 22.0, 0.1, 0.5, 235, 'APROBADO', 4, 'Traza de agua, dentro de límites');
INSERT INTO control_calidad_combustible (id_tanque, fecha_muestra, fecha_analisis, numero_muestra, tipo_analisis, analista, densidad_medida, temperatura_prueba, presencia_agua, particulas_suspendidas, conductividad, resultado, aprobado_por, observaciones) VALUES
(6, TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'M-005', 'RUTINA', 15, 0.804, 23.5, 0.0, 0.1, 255, 'APROBADO', 4, NULL);
INSERT INTO control_calidad_combustible (id_tanque, fecha_muestra, fecha_analisis, numero_muestra, tipo_analisis, analista, densidad_medida, temperatura_prueba, presencia_agua, particulas_suspendidas, conductividad, resultado, aprobado_por, observaciones) VALUES
(9, TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'M-006', 'RUTINA', 11, 0.805, 24.0, 0.0, 0.3, 248, 'APROBADO', 4, NULL);
INSERT INTO control_calidad_combustible (id_tanque, fecha_muestra, fecha_analisis, numero_muestra, tipo_analisis, analista, densidad_medida, temperatura_prueba, presencia_agua, particulas_suspendidas, conductividad, resultado, aprobado_por, observaciones) VALUES
(10, TO_TIMESTAMP('2024-03-18 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 19:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'M-007', 'RUTINA', 12, 0.802, 21.5, 0.2, 0.8, 240, 'RECHAZADO', 4, 'Alta presencia de agua y partículas');

-- Tabla 22.7: historial_precios_combustible (se omite id_precio_combustible)
INSERT INTO historial_precios_combustible (fecha_precio, tipo_combustible, precio_compra_local, precio_venta_aerolineas, moneda, precio_internacional_referencia, variacion_porcentual, factor_ajuste, vigente) VALUES
(DATE '2024-03-18', 'JET_A1', 2.85, 3.25, 'USD', 2.80, 1.79, 1.02, 1);
INSERT INTO historial_precios_combustible (fecha_precio, tipo_combustible, precio_compra_local, precio_venta_aerolineas, moneda, precio_internacional_referencia, variacion_porcentual, factor_ajuste, vigente) VALUES
(DATE '2024-03-17', 'JET_A1', 2.83, 3.23, 'USD', 2.78, 0.71, 1.02, 0);
INSERT INTO historial_precios_combustible (fecha_precio, tipo_combustible, precio_compra_local, precio_venta_aerolineas, moneda, precio_internacional_referencia, variacion_porcentual, factor_ajuste, vigente) VALUES
(DATE '2024-03-16', 'JET_A1', 2.80, 3.20, 'USD', 2.75, -1.06, 1.02, 0);
INSERT INTO historial_precios_combustible (fecha_precio, tipo_combustible, precio_compra_local, precio_venta_aerolineas, moneda, precio_internacional_referencia, variacion_porcentual, factor_ajuste, vigente) VALUES
(DATE '2024-03-18', 'JET_A', 2.95, 3.35, 'USD', 2.90, 1.72, 1.02, 1);
INSERT INTO historial_precios_combustible (fecha_precio, tipo_combustible, precio_compra_local, precio_venta_aerolineas, moneda, precio_internacional_referencia, variacion_porcentual, factor_ajuste, vigente) VALUES
(DATE '2024-03-18', 'AVGAS', 4.50, 5.10, 'USD', 4.45, 1.11, 1.02, 1);

-- Tabla 22.8: facturacion_combustible (se omite id_factura_combustible)
INSERT INTO facturacion_combustible (id_carga_combustible, numero_factura, id_aerolinea, fecha_emision, cantidad_litros, precio_unitario, subtotal, impuestos, total, moneda, fecha_vencimiento, pagada, fecha_pago, forma_pago) VALUES
(1, 'FAC-COM-001', 1, DATE '2024-03-19', 85200.00, 3.25, 276900.00, 58149.00, 335049.00, 'USD', DATE '2024-04-18', 0, NULL, 'TRANSFERENCIA');
INSERT INTO facturacion_combustible (id_carga_combustible, numero_factura, id_aerolinea, fecha_emision, cantidad_litros, precio_unitario, subtotal, impuestos, total, moneda, fecha_vencimiento, pagada, fecha_pago, forma_pago) VALUES
(2, 'FAC-COM-002', 2, DATE '2024-03-19', 59800.00, 3.25, 194350.00, 40813.50, 235163.50, 'USD', DATE '2024-04-18', 0, NULL, 'TRANSFERENCIA');
INSERT INTO facturacion_combustible (id_carga_combustible, numero_factura, id_aerolinea, fecha_emision, cantidad_litros, precio_unitario, subtotal, impuestos, total, moneda, fecha_vencimiento, pagada, fecha_pago, forma_pago) VALUES
(3, 'FAC-COM-003', 3, DATE '2024-03-19', 30200.00, 3.35, 101170.00, 21245.70, 122415.70, 'USD', DATE '2024-04-18', 0, NULL, 'TRANSFERENCIA');
INSERT INTO facturacion_combustible (id_carga_combustible, numero_factura, id_aerolinea, fecha_emision, cantidad_litros, precio_unitario, subtotal, impuestos, total, moneda, fecha_vencimiento, pagada, fecha_pago, forma_pago) VALUES
(4, 'FAC-COM-004', 5, DATE '2024-03-20', 146000.00, 3.25, 474500.00, 99645.00, 574145.00, 'USD', DATE '2024-04-19', 0, NULL, 'TRANSFERENCIA');
INSERT INTO facturacion_combustible (id_carga_combustible, numero_factura, id_aerolinea, fecha_emision, cantidad_litros, precio_unitario, subtotal, impuestos, total, moneda, fecha_vencimiento, pagada, fecha_pago, forma_pago) VALUES
(5, 'FAC-COM-005', 6, DATE '2024-03-19', 82500.00, 3.25, 268125.00, 56306.25, 324431.25, 'USD', DATE '2024-04-18', 0, NULL, 'TRANSFERENCIA');
INSERT INTO facturacion_combustible (id_carga_combustible, numero_factura, id_aerolinea, fecha_emision, cantidad_litros, precio_unitario, subtotal, impuestos, total, moneda, fecha_vencimiento, pagada, fecha_pago, forma_pago) VALUES
(6, 'FAC-COM-006', 9, DATE '2024-03-21', 139500.00, 3.25, 453375.00, 95208.75, 548583.75, 'USD', DATE '2024-04-20', 0, NULL, 'TRANSFERENCIA');
INSERT INTO facturacion_combustible (id_carga_combustible, numero_factura, id_aerolinea, fecha_emision, cantidad_litros, precio_unitario, subtotal, impuestos, total, moneda, fecha_vencimiento, pagada, fecha_pago, forma_pago) VALUES
(7, 'FAC-COM-007', 10, DATE '2024-03-21', 86500.00, 3.25, 281125.00, 59036.25, 340161.25, 'USD', DATE '2024-04-20', 0, NULL, 'TRANSFERENCIA');

-- Tabla 22.9: inventario_combustible (se omite id_inventario)
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(1, DATE '2024-03-18', 3845000.00, 3850000.00, -5000.00, -0.13, 18.5, 'DIARIO', 2, 4, 'Diferencia dentro de tolerancia');
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(2, DATE '2024-03-18', 4205000.00, 4200000.00, 5000.00, 0.12, 19.2, 'DIARIO', 3, 4, NULL);
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(3, DATE '2024-03-18', 948000.00, 950000.00, -2000.00, -0.21, 17.8, 'DIARIO', 5, 4, NULL);
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(4, DATE '2024-03-18', 5198000.00, 5200000.00, -2000.00, -0.04, 20.5, 'DIARIO', 7, 4, NULL);
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(5, DATE '2024-03-18', 3805000.00, 3800000.00, 5000.00, 0.13, 21.0, 'DIARIO', 8, 4, NULL);
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(6, DATE '2024-03-18', 8905000.00, 8900000.00, 5000.00, 0.06, 22.5, 'DIARIO', 9, 4, NULL);
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(7, DATE '2024-03-18', 7195000.00, 7200000.00, -5000.00, -0.07, 16.8, 'DIARIO', 10, 4, NULL);
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(1, DATE '2024-03-20', 3855000.00, 3860000.00, -5000.00, -0.13, 19.0, 'DIARIO', 2, 4, NULL);
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(2, DATE '2024-03-20', 4195000.00, 4190000.00, 5000.00, 0.12, 19.5, 'DIARIO', 3, 4, NULL);
INSERT INTO inventario_combustible (id_tanque, fecha_inventario, nivel_medido_litros, nivel_teorico_litros, diferencia_litros, porcentaje_diferencia, temperatura_promedio, tipo_inventario, realizado_por, verificado_por, observaciones) VALUES
(10, DATE '2024-03-20', 6815000.00, 6820000.00, -5000.00, -0.07, 21.5, 'DIARIO', 1, 4, NULL);

-- Tabla 22.10: recepciones_combustible (se omite id_recepcion)
INSERT INTO recepciones_combustible (id_proveedor_combustible, id_tanque, numero_guia, fecha_recepcion, cantidad_recibida_litros, cantidad_facturada_litros, temperatura_recepcion, densidad_recepcion, placa_camion, transportista, conductor, licencia_conductor, inspector_recibe, observaciones) VALUES
(1, 1, 'GUI-001', TO_TIMESTAMP('2024-03-18 06:00:00', 'YYYY-MM-DD HH24:MI:SS'), 250000.00, 250000.00, 18.0, 0.801, '1234-ABC', 'Logística Repsol', 'Juan Pérez', 'B-123456', 2, NULL);
INSERT INTO recepciones_combustible (id_proveedor_combustible, id_tanque, numero_guia, fecha_recepcion, cantidad_recibida_litros, cantidad_facturada_litros, temperatura_recepcion, densidad_recepcion, placa_camion, transportista, conductor, licencia_conductor, inspector_recibe, observaciones) VALUES
(2, 2, 'GUI-002', TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'), 200000.00, 200000.00, 19.0, 0.802, '5678-DEF', 'Shell Logistics', 'Carlos Gómez', 'B-789012', 3, NULL);
INSERT INTO recepciones_combustible (id_proveedor_combustible, id_tanque, numero_guia, fecha_recepcion, cantidad_recibida_litros, cantidad_facturada_litros, temperatura_recepcion, densidad_recepcion, placa_camion, transportista, conductor, licencia_conductor, inspector_recibe, observaciones) VALUES
(1, 3, 'GUI-003', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 50000.00, 50000.00, 17.5, 0.798, '9101-GHI', 'Repsol', 'Ana López', 'B-345678', 5, NULL);
INSERT INTO recepciones_combustible (id_proveedor_combustible, id_tanque, numero_guia, fecha_recepcion, cantidad_recibida_litros, cantidad_facturada_litros, temperatura_recepcion, densidad_recepcion, placa_camion, transportista, conductor, licencia_conductor, inspector_recibe, observaciones) VALUES
(1, 1, 'GUI-004', TO_TIMESTAMP('2024-03-19 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 200000.00, 200000.00, 18.5, 0.802, '1122-JKL', 'Repsol', 'Luis García', 'B-901234', 2, NULL);
INSERT INTO recepciones_combustible (id_proveedor_combustible, id_tanque, numero_guia, fecha_recepcion, cantidad_recibida_litros, cantidad_facturada_litros, temperatura_recepcion, densidad_recepcion, placa_camion, transportista, conductor, licencia_conductor, inspector_recibe, observaciones) VALUES
(2, 2, 'GUI-005', TO_TIMESTAMP('2024-03-20 07:00:00', 'YYYY-MM-DD HH24:MI:SS'), 180000.00, 180000.00, 19.2, 0.803, '3344-MNO', 'Shell', 'Pedro Sánchez', 'B-567890', 3, NULL);

COMMIT;
SELECT 'Módulo 22 completado' AS estado FROM dual;


-- =====================================================
-- MÓDULO 23: GESTIÓN AMBIENTAL (9 TABLAS)
-- =====================================================

-- Tabla 23.2: monitoreo_ruido (se omite id_medicion_ruido)
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(1, TO_TIMESTAMP('2024-03-18 12:15:00', 'YYYY-MM-DD HH24:MI:SS'), 75.5, 92.3, 60.2, '125', 180, 1, 'DESPEGUE', 0, 0);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(1, TO_TIMESTAMP('2024-03-18 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 72.0, 88.5, 58.5, '125', 180, 2, 'ATERRIZAJE', 0, 0);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(3, TO_TIMESTAMP('2024-03-18 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), 78.0, 95.5, 62.0, '250', 150, 3, 'DESPEGUE', 1, 1);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(4, TO_TIMESTAMP('2024-03-18 06:30:00', 'YYYY-MM-DD HH24:MI:SS'), 70.0, 85.0, 55.0, '63', 120, NULL, 'VEHICULOS', 0, 0);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(5, TO_TIMESTAMP('2024-03-18 07:45:00', 'YYYY-MM-DD HH24:MI:SS'), 82.0, 98.0, 68.0, '500', 200, 4, 'DESPEGUE', 1, 1);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(6, TO_TIMESTAMP('2024-03-18 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), 68.5, 80.0, 52.0, '125', 90, 5, 'ATERRIZAJE', 0, 0);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(7, TO_TIMESTAMP('2024-03-18 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 71.0, 86.5, 59.0, '250', 150, 6, 'DESPEGUE', 0, 0);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(8, TO_TIMESTAMP('2024-03-20 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 74.0, 90.0, 61.0, '125', 180, 10, 'DESPEGUE', 0, 0);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(9, TO_TIMESTAMP('2024-03-20 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 69.0, 82.0, 54.0, '63', 120, 9, 'ATERRIZAJE', 0, 0);
INSERT INTO monitoreo_ruido (id_estacion_ambiental, fecha_hora_medicion, nivel_ruido_continua_db, nivel_ruido_maximo_db, nivel_ruido_minimo_db, frecuencia_Hz, duracion_segundos, id_vuelo_asociado, tipo_fuente, excede_limite, alerta_generada) VALUES
(10, TO_TIMESTAMP('2024-03-18 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 73.0, 89.0, 60.0, '250', 150, NULL, 'CONSTRUCCION', 0, 0);

-- Tabla 23.3: monitoreo_aire (se omite id_medicion_aire)
INSERT INTO monitoreo_aire (id_estacion_ambiental, fecha_hora_medicion, co2_ppm, co_ppm, nox_ppm, so2_ppm, particulas_pm10, particulas_pm25, compuestos_organicos_volatiles, temperatura_ambiente, humedad_relativa, presion_atmosferica, velocidad_viento, direccion_viento, indice_calidad_aire, alerta_generada) VALUES
(2, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 420.0, 0.5, 0.08, 0.02, 25.0, 12.0, 0.3, 15.0, 65, 1015.0, 8, 'NE', 52, 0);
INSERT INTO monitoreo_aire (id_estacion_ambiental, fecha_hora_medicion, co2_ppm, co_ppm, nox_ppm, so2_ppm, particulas_pm10, particulas_pm25, compuestos_organicos_volatiles, temperatura_ambiente, humedad_relativa, presion_atmosferica, velocidad_viento, direccion_viento, indice_calidad_aire, alerta_generada) VALUES
(2, TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 450.0, 0.8, 0.12, 0.03, 35.0, 18.0, 0.5, 18.0, 45, 1013.0, 10, 'NE', 65, 0);
INSERT INTO monitoreo_aire (id_estacion_ambiental, fecha_hora_medicion, co2_ppm, co_ppm, nox_ppm, so2_ppm, particulas_pm10, particulas_pm25, compuestos_organicos_volatiles, temperatura_ambiente, humedad_relativa, presion_atmosferica, velocidad_viento, direccion_viento, indice_calidad_aire, alerta_generada) VALUES
(2, TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 480.0, 1.2, 0.15, 0.04, 45.0, 22.0, 0.8, 20.0, 40, 1010.0, 12, 'SW', 78, 1);
INSERT INTO monitoreo_aire (id_estacion_ambiental, fecha_hora_medicion, co2_ppm, co_ppm, nox_ppm, so2_ppm, particulas_pm10, particulas_pm25, compuestos_organicos_volatiles, temperatura_ambiente, humedad_relativa, presion_atmosferica, velocidad_viento, direccion_viento, indice_calidad_aire, alerta_generada) VALUES
(4, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 390.0, 0.3, 0.06, 0.01, 18.0, 9.0, 0.2, 14.0, 80, 1020.0, 5, 'SE', 42, 0);
INSERT INTO monitoreo_aire (id_estacion_ambiental, fecha_hora_medicion, co2_ppm, co_ppm, nox_ppm, so2_ppm, particulas_pm10, particulas_pm25, compuestos_organicos_volatiles, temperatura_ambiente, humedad_relativa, presion_atmosferica, velocidad_viento, direccion_viento, indice_calidad_aire, alerta_generada) VALUES
(4, TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 410.0, 0.6, 0.10, 0.02, 28.0, 14.0, 0.4, 16.0, 70, 1018.0, 7, 'S', 58, 0);
INSERT INTO monitoreo_aire (id_estacion_ambiental, fecha_hora_medicion, co2_ppm, co_ppm, nox_ppm, so2_ppm, particulas_pm10, particulas_pm25, compuestos_organicos_volatiles, temperatura_ambiente, humedad_relativa, presion_atmosferica, velocidad_viento, direccion_viento, indice_calidad_aire, alerta_generada) VALUES
(6, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 440.0, 0.9, 0.14, 0.03, 38.0, 19.0, 0.6, 22.0, 30, 1012.0, 8, 'SW', 72, 0);
INSERT INTO monitoreo_aire (id_estacion_ambiental, fecha_hora_medicion, co2_ppm, co_ppm, nox_ppm, so2_ppm, particulas_pm10, particulas_pm25, compuestos_organicos_volatiles, temperatura_ambiente, humedad_relativa, presion_atmosferica, velocidad_viento, direccion_viento, indice_calidad_aire, alerta_generada) VALUES
(8, TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 430.0, 0.7, 0.11, 0.02, 32.0, 16.0, 0.5, 20.0, 55, 1014.0, 6, 'E', 62, 0);
INSERT INTO monitoreo_aire (id_estacion_ambiental, fecha_hora_medicion, co2_ppm, co_ppm, nox_ppm, so2_ppm, particulas_pm10, particulas_pm25, compuestos_organicos_volatiles, temperatura_ambiente, humedad_relativa, presion_atmosferica, velocidad_viento, direccion_viento, indice_calidad_aire, alerta_generada) VALUES
(9, TO_TIMESTAMP('2024-03-20 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 445.0, 0.8, 0.12, 0.03, 34.0, 17.0, 0.5, 22.0, 40, 1022.0, 5, 'SE', 66, 0);

-- Tabla 23.4: huella_carbono_vuelo (se omite id_huella_carbono)
INSERT INTO huella_carbono_vuelo (id_vuelo, combustible_consumido_litros, factor_emision_co2, co2_emitido_kg, co2_por_pasajero_kg, co2_por_km, distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km, fecha_calculo, metodo_calculo, certificado_compensacion) VALUES
(1, 85000.00, 2.52, 214200.00, 778.91, 25.50, 8400, 'LARGO', 10.12, DATE '2024-03-19', 'ICAO Carbon Calculator', 0);
INSERT INTO huella_carbono_vuelo (id_vuelo, combustible_consumido_litros, factor_emision_co2, co2_emitido_kg, co2_por_pasajero_kg, co2_por_km, distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km, fecha_calculo, metodo_calculo, certificado_compensacion) VALUES
(2, 60000.00, 2.52, 151200.00, 864.00, 18.00, 8400, 'LARGO', 7.14, DATE '2024-03-19', 'ICAO Carbon Calculator', 0);
INSERT INTO huella_carbono_vuelo (id_vuelo, combustible_consumido_litros, factor_emision_co2, co2_emitido_kg, co2_por_pasajero_kg, co2_por_km, distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km, fecha_calculo, metodo_calculo, certificado_compensacion) VALUES
(3, 30000.00, 2.52, 75600.00, 420.00, 18.90, 4000, 'MEDIO', 7.50, DATE '2024-03-19', 'ICAO Carbon Calculator', 0);
INSERT INTO huella_carbono_vuelo (id_vuelo, combustible_consumido_litros, factor_emision_co2, co2_emitido_kg, co2_por_pasajero_kg, co2_por_km, distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km, fecha_calculo, metodo_calculo, certificado_compensacion) VALUES
(4, 95000.00, 2.52, 239400.00, 785.90, 43.53, 5500, 'MEDIO', 17.27, DATE '2024-03-19', 'ICAO Carbon Calculator', 0);
INSERT INTO huella_carbono_vuelo (id_vuelo, combustible_consumido_litros, factor_emision_co2, co2_emitido_kg, co2_por_pasajero_kg, co2_por_km, distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km, fecha_calculo, metodo_calculo, certificado_compensacion) VALUES
(5, 145000.00, 2.52, 365400.00, 971.81, 30.45, 12000, 'LARGO', 12.08, DATE '2024-03-20', 'ICAO Carbon Calculator', 0);
INSERT INTO huella_carbono_vuelo (id_vuelo, combustible_consumido_litros, factor_emision_co2, co2_emitido_kg, co2_por_pasajero_kg, co2_por_km, distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km, fecha_calculo, metodo_calculo, certificado_compensacion) VALUES
(6, 82000.00, 2.52, 206640.00, 779.77, 35.63, 5800, 'MEDIO', 14.14, DATE '2024-03-19', 'ICAO Carbon Calculator', 0);
INSERT INTO huella_carbono_vuelo (id_vuelo, combustible_consumido_litros, factor_emision_co2, co2_emitido_kg, co2_por_pasajero_kg, co2_por_km, distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km, fecha_calculo, metodo_calculo, certificado_compensacion) VALUES
(9, 138000.00, 2.52, 347760.00, 976.85, 38.21, 9100, 'LARGO', 15.17, DATE '2024-03-21', 'ICAO Carbon Calculator', 0);
INSERT INTO huella_carbono_vuelo (id_vuelo, combustible_consumido_litros, factor_emision_co2, co2_emitido_kg, co2_por_pasajero_kg, co2_por_km, distancia_vuelo_km, categoria_vuelo, eficiencia_combustible_kg_km, fecha_calculo, metodo_calculo, certificado_compensacion) VALUES
(10, 86000.00, 2.52, 216720.00, 774.00, 25.80, 8400, 'LARGO', 10.24, DATE '2024-03-21', 'ICAO Carbon Calculator', 1);

-- Tabla 23.5: programas_compensacion_ambiental (se omite id_programa_compensacion)
INSERT INTO programas_compensacion_ambiental (nombre_programa, descripcion, tipo_programa, fecha_inicio, fecha_fin, inversion_total, moneda, co2_compensado_estimado_kg, entidad_ejecutora, activo, contacto_responsable) VALUES
('Reforestación Amazonía', 'Plantación de árboles en la Amazonía colombiana', 'REFORESTACION', DATE '2023-01-01', DATE '2025-12-31', 500000.00, 'USD', 1000000.00, 'Fundación Natura', 1, 'Carlos Gómez');
INSERT INTO programas_compensacion_ambiental (nombre_programa, descripcion, tipo_programa, fecha_inicio, fecha_fin, inversion_total, moneda, co2_compensado_estimado_kg, entidad_ejecutora, activo, contacto_responsable) VALUES
('Parque Solar Aeropuertos', 'Instalación de paneles solares', 'ENERGIA_LIMPIA', DATE '2024-01-01', DATE '2026-12-31', 2000000.00, 'EUR', 1500000.00, 'Iberdrola', 1, 'Ana Martínez');
INSERT INTO programas_compensacion_ambiental (nombre_programa, descripcion, tipo_programa, fecha_inicio, fecha_fin, inversion_total, moneda, co2_compensado_estimado_kg, entidad_ejecutora, activo, contacto_responsable) VALUES
('Educación Ambiental', 'Talleres en escuelas cercanas', 'EDUCACION', DATE '2024-01-01', DATE '2024-12-31', 50000.00, 'EUR', 0.00, 'AENA', 1, 'Laura Pérez');
INSERT INTO programas_compensacion_ambiental (nombre_programa, descripcion, tipo_programa, fecha_inicio, fecha_fin, inversion_total, moneda, co2_compensado_estimado_kg, entidad_ejecutora, activo, contacto_responsable) VALUES
('Estudio huella de carbono', 'Investigación de impacto ambiental', 'INVESTIGACION', DATE '2024-03-01', DATE '2024-09-30', 75000.00, 'USD', 0.00, 'Universidad Politécnica', 1, 'Juan López');

-- Tabla 23.6: compensaciones_vuelo (se omite id_compensacion_vuelo)
INSERT INTO compensaciones_vuelo (id_huella_carbono, id_programa_compensacion, fecha_compensacion, cantidad_compensada_kg, porcentaje_compensado, monto_aportado, moneda, verificada) VALUES
(1, 1, DATE '2024-03-20', 50000.00, 23.34, 1250.00, 'USD', 1);
INSERT INTO compensaciones_vuelo (id_huella_carbono, id_programa_compensacion, fecha_compensacion, cantidad_compensada_kg, porcentaje_compensado, monto_aportado, moneda, verificada) VALUES
(2, 1, DATE '2024-03-20', 30000.00, 19.84, 750.00, 'USD', 1);
INSERT INTO compensaciones_vuelo (id_huella_carbono, id_programa_compensacion, fecha_compensacion, cantidad_compensada_kg, porcentaje_compensado, monto_aportado, moneda, verificada) VALUES
(3, 2, DATE '2024-03-20', 20000.00, 26.46, 500.00, 'EUR', 1);
INSERT INTO compensaciones_vuelo (id_huella_carbono, id_programa_compensacion, fecha_compensacion, cantidad_compensada_kg, porcentaje_compensado, monto_aportado, moneda, verificada) VALUES
(8, 2, DATE '2024-03-22', 216720.00, 100.00, 5000.00, 'EUR', 1);

-- Tabla 23.7: gestion_residuos (se omite id_residuo)
INSERT INTO gestion_residuos (fecha_recoleccion, tipo_residuo, cantidad_kg, origen, empresa_recolectora, tratamiento, certificado_tratamiento, costo_tratamiento, observaciones) VALUES
(DATE '2024-03-18', 'PLASTICO', 1250.00, 'TERMINAL', 'Recicla Madrid', 'RECICLAJE', 'CERT-001', 250.00, NULL);
INSERT INTO gestion_residuos (fecha_recoleccion, tipo_residuo, cantidad_kg, origen, empresa_recolectora, tratamiento, certificado_tratamiento, costo_tratamiento, observaciones) VALUES
(DATE '2024-03-18', 'ORGANICO', 3500.00, 'RESTAURANTES', 'Valoriza', 'COMPOSTAJE', 'CERT-002', 300.00, NULL);
INSERT INTO gestion_residuos (fecha_recoleccion, tipo_residuo, cantidad_kg, origen, empresa_recolectora, tratamiento, certificado_tratamiento, costo_tratamiento, observaciones) VALUES
(DATE '2024-03-18', 'PAPEL', 800.00, 'OFICINAS', 'Recicla Madrid', 'RECICLAJE', 'CERT-003', 120.00, NULL);
INSERT INTO gestion_residuos (fecha_recoleccion, tipo_residuo, cantidad_kg, origen, empresa_recolectora, tratamiento, certificado_tratamiento, costo_tratamiento, observaciones) VALUES
(DATE '2024-03-18', 'PELIGROSO', 150.00, 'MANTENIMIENTO', 'Gestión Integral', 'INCINERACION', 'CERT-004', 450.00, 'Residuos químicos');
INSERT INTO gestion_residuos (fecha_recoleccion, tipo_residuo, cantidad_kg, origen, empresa_recolectora, tratamiento, certificado_tratamiento, costo_tratamiento, observaciones) VALUES
(DATE '2024-03-19', 'VIDRIO', 600.00, 'RESTAURANTES', 'Recicla Madrid', 'RECICLAJE', 'CERT-005', 90.00, NULL);
INSERT INTO gestion_residuos (fecha_recoleccion, tipo_residuo, cantidad_kg, origen, empresa_recolectora, tratamiento, certificado_tratamiento, costo_tratamiento, observaciones) VALUES
(DATE '2024-03-19', 'BIOSANITARIO', 80.00, 'VUELOS', 'Servicios Médicos', 'INCINERACION', 'CERT-006', 240.00, 'Residuos de botiquines');
INSERT INTO gestion_residuos (fecha_recoleccion, tipo_residuo, cantidad_kg, origen, empresa_recolectora, tratamiento, certificado_tratamiento, costo_tratamiento, observaciones) VALUES
(DATE '2024-03-20', 'ELECTRONICO', 200.00, 'OFICINAS', 'Recyberica', 'RECICLAJE', 'CERT-007', 300.00, 'Equipos obsoletos');
INSERT INTO gestion_residuos (fecha_recoleccion, tipo_residuo, cantidad_kg, origen, empresa_recolectora, tratamiento, certificado_tratamiento, costo_tratamiento, observaciones) VALUES
(DATE '2024-03-20', 'METAL', 450.00, 'MANTENIMIENTO', 'Hierros Madrid', 'RECICLAJE', 'CERT-008', 100.00, 'Chatarra');

-- Tabla 23.8: certificaciones_ambientales_aeropuerto (se omite id_certificacion_ambiental)
INSERT INTO certificaciones_ambientales_aeropuerto (codigo_certificacion, nombre_certificacion, entidad_certificadora, fecha_obtencion, fecha_vencimiento, nivel_certificacion, alcance, activa, responsable_seguimiento, observaciones) VALUES
('ISO-14001-MAD', 'ISO 14001:2015', 'AENOR', DATE '2023-05-15', DATE '2026-05-15', 'Certificado', 'Gestión ambiental aeropuerto MAD', 1, 2, NULL);
INSERT INTO certificaciones_ambientales_aeropuerto (codigo_certificacion, nombre_certificacion, entidad_certificadora, fecha_obtencion, fecha_vencimiento, nivel_certificacion, alcance, activa, responsable_seguimiento, observaciones) VALUES
('ACA-LEVEL3', 'Airport Carbon Accreditation Level 3', 'ACI', DATE '2024-01-20', DATE '2025-01-20', 'Optimización', 'Huella de carbono', 1, 2, NULL);
INSERT INTO certificaciones_ambientales_aeropuerto (codigo_certificacion, nombre_certificacion, entidad_certificadora, fecha_obtencion, fecha_vencimiento, nivel_certificacion, alcance, activa, responsable_seguimiento, observaciones) VALUES
('EMAS-MAD', 'EMAS III', 'Comisión Europea', DATE '2023-10-10', DATE '2026-10-10', 'Registro', 'Eco-gestión', 1, 3, NULL);
INSERT INTO certificaciones_ambientales_aeropuerto (codigo_certificacion, nombre_certificacion, entidad_certificadora, fecha_obtencion, fecha_vencimiento, nivel_certificacion, alcance, activa, responsable_seguimiento, observaciones) VALUES
('ISO-50001', 'ISO 50001:2018', 'AENOR', DATE '2024-02-01', DATE '2027-02-01', 'Certificado', 'Eficiencia energética', 1, 4, NULL);
INSERT INTO certificaciones_ambientales_aeropuerto (codigo_certificacion, nombre_certificacion, entidad_certificadora, fecha_obtencion, fecha_vencimiento, nivel_certificacion, alcance, activa, responsable_seguimiento, observaciones) VALUES
('LEED-GOLD', 'LEED Gold', 'USGBC', DATE '2023-11-15', DATE '2028-11-15', 'Oro', 'Edificio terminal T4', 1, 5, NULL);

-- Tabla 23.9: indicadores_desempeno_ambiental (se omite id_indicador_ambiental)
INSERT INTO indicadores_desempeno_ambiental (anio, mes, indicador, valor_medido, unidad_medida, valor_objetivo, cumplimiento_porcentaje, tendencia, observaciones) VALUES
(2024, 3, 'HUELLA_CARBONO', 1250000.00, 'kg', 1300000.00, 104.00, 'MEJORA', 'Por debajo del objetivo');
INSERT INTO indicadores_desempeno_ambiental (anio, mes, indicador, valor_medido, unidad_medida, valor_objetivo, cumplimiento_porcentaje, tendencia, observaciones) VALUES
(2024, 3, 'CONSUMO_AGUA', 45000.00, 'm3', 50000.00, 111.11, 'MEJORA', NULL);
INSERT INTO indicadores_desempeno_ambiental (anio, mes, indicador, valor_medido, unidad_medida, valor_objetivo, cumplimiento_porcentaje, tendencia, observaciones) VALUES
(2024, 3, 'CONSUMO_ENERGIA', 2500000.00, 'kWh', 2400000.00, 95.83, 'DETERIORO', 'Consumo superior al esperado');
INSERT INTO indicadores_desempeno_ambiental (anio, mes, indicador, valor_medido, unidad_medida, valor_objetivo, cumplimiento_porcentaje, tendencia, observaciones) VALUES
(2024, 3, 'RESIDUOS', 5500.00, 'kg', 6000.00, 109.09, 'MEJORA', 'Menos residuos generados');
INSERT INTO indicadores_desempeno_ambiental (anio, mes, indicador, valor_medido, unidad_medida, valor_objetivo, cumplimiento_porcentaje, tendencia, observaciones) VALUES
(2024, 3, 'RUIDO', 72.5, 'db', 75.0, 103.45, 'ESTABLE', 'Dentro de límites');
INSERT INTO indicadores_desempeno_ambiental (anio, mes, indicador, valor_medido, unidad_medida, valor_objetivo, cumplimiento_porcentaje, tendencia, observaciones) VALUES
(2024, 3, 'CALIDAD_AIRE', 52.0, 'ICA', 60.0, 115.38, 'MEJORA', NULL);
INSERT INTO indicadores_desempeno_ambiental (anio, mes, indicador, valor_medido, unidad_medida, valor_objetivo, cumplimiento_porcentaje, tendencia, observaciones) VALUES
(2024, 2, 'HUELLA_CARBONO', 1320000.00, 'kg', 1300000.00, 98.48, 'DETERIORO', NULL);
INSERT INTO indicadores_desempeno_ambiental (anio, mes, indicador, valor_medido, unidad_medida, valor_objetivo, cumplimiento_porcentaje, tendencia, observaciones) VALUES
(2024, 2, 'CONSUMO_AGUA', 48000.00, 'm3', 50000.00, 104.17, 'MEJORA', NULL);

-- Tabla 23.10: proyectos_eficiencia_energetica (se omite id_proyecto_eficiencia)
INSERT INTO proyectos_eficiencia_energetica (nombre_proyecto, descripcion, tipo_proyecto, inversion_total, ahorro_energetico_anual_kwh, reduccion_co2_anual_kg, fecha_inicio, fecha_finalizacion, periodo_retorno_anios, estado, responsable_proyecto, resultados_obtenidos) VALUES
('LED Terminal T4', 'Sustitución de iluminación por LED', 'ILUMINACION', 500000.00, 800000.00, 120000.00, DATE '2023-06-01', DATE '2023-12-01', 2.5, 'COMPLETADO', 'Ing. García', 'Ahorro energético del 30%');
INSERT INTO proyectos_eficiencia_energetica (nombre_proyecto, descripcion, tipo_proyecto, inversion_total, ahorro_energetico_anual_kwh, reduccion_co2_anual_kg, fecha_inicio, fecha_finalizacion, periodo_retorno_anios, estado, responsable_proyecto, resultados_obtenidos) VALUES
('Paneles Solares T4', 'Instalación de paneles fotovoltaicos', 'ENERGIA_SOLAR', 1200000.00, 1500000.00, 225000.00, DATE '2024-01-15', DATE '2024-06-30', 4.0, 'EN_EJECUCION', 'Ing. Martínez', NULL);
INSERT INTO proyectos_eficiencia_energetica (nombre_proyecto, descripcion, tipo_proyecto, inversion_total, ahorro_energetico_anual_kwh, reduccion_co2_anual_kg, fecha_inicio, fecha_finalizacion, periodo_retorno_anios, estado, responsable_proyecto, resultados_obtenidos) VALUES
('Climatización Eficiente', 'Mejora del sistema HVAC', 'CLIMATIZACION', 800000.00, 600000.00, 90000.00, DATE '2024-03-01', DATE '2024-09-30', 4.5, 'EN_EJECUCION', 'Ing. López', NULL);
INSERT INTO proyectos_eficiencia_energetica (nombre_proyecto, descripcion, tipo_proyecto, inversion_total, ahorro_energetico_anual_kwh, reduccion_co2_anual_kg, fecha_inicio, fecha_finalizacion, periodo_retorno_anios, estado, responsable_proyecto, resultados_obtenidos) VALUES
('Equipos Handling Eléctricos', 'Renovación de flota de handling', 'EQUIPOS_EFICIENTES', 2000000.00, 1200000.00, 180000.00, DATE '2024-05-01', DATE '2024-12-31', 5.0, 'PLANEADO', 'Ing. Fernández', NULL);
INSERT INTO proyectos_eficiencia_energetica (nombre_proyecto, descripcion, tipo_proyecto, inversion_total, ahorro_energetico_anual_kwh, reduccion_co2_anual_kg, fecha_inicio, fecha_finalizacion, periodo_retorno_anios, estado, responsable_proyecto, resultados_obtenidos) VALUES
('Sistema de Gestión Energética', 'Software de monitorización', 'OTROS', 150000.00, 200000.00, 30000.00, DATE '2023-10-01', DATE '2024-01-31', 1.5, 'EVALUADO', 'Ing. Ruiz', 'Optimización del 15%');

COMMIT;
SELECT 'Módulo 23 completado' AS estado FROM dual;

-- =====================================================
-- MÓDULO 24: SEGURIDAD INFORMÁTICA Y ACCESOS (12 TABLAS)
-- =====================================================

-- Tabla 24.1: usuarios_sistema (depende de empleados) (se omite id_usuario_sistema)
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(1, 'jgonzalez', 'hash_12345', 'jgonzalez@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(2, 'mlopez', 'hash_23456', 'mlopez@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(3, 'arodriguez', 'hash_34567', 'arodriguez@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 1, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(4, 'mgarcia', 'hash_45678', 'mgarcia@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(5, 'cperez', 'hash_56789', 'cperez@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(6, 'psanchez', 'hash_67890', 'psanchez@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 2, 1, 'Intentos fallidos', 1, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(7, 'lgomez', 'hash_78901', 'lgomez@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(8, 'jrodriguez', 'hash_89012', 'jrodriguez@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(9, 'smartin', 'hash_90123', 'smartin@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(10, 'aruiz', 'hash_01234', 'aruiz@aeropuerto.com', DATE '2024-01-01', TO_TIMESTAMP('2024-03-18 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-01', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(11, 'rgutierrez', 'hash_11223', 'rgutierrez@aeropuerto.com', DATE '2024-01-15', TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-15', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(12, 'mfuentes', 'hash_22334', 'mfuentes@aeropuerto.com', DATE '2024-01-15', TO_TIMESTAMP('2024-03-18 19:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-15', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(13, 'cmendoza', 'hash_33445', 'cmendoza@aeropuerto.com', DATE '2024-01-15', TO_TIMESTAMP('2024-03-18 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-15', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(14, 'acastro', 'hash_44556', 'acastro@aeropuerto.com', DATE '2024-01-15', TO_TIMESTAMP('2024-03-18 21:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-15', 0, 0, NULL, 0, 1, 1);
INSERT INTO usuarios_sistema (id_empleado, nombre_usuario, password_hash, email_institucional, fecha_creacion, fecha_ultimo_acceso, fecha_vencimiento_password, intentos_fallidos, bloqueado, motivo_bloqueo, requiere_cambio_password, activo, creado_por) VALUES
(15, 'jtorres', 'hash_55667', 'jtorres@aeropuerto.com', DATE '2024-01-15', TO_TIMESTAMP('2024-03-18 22:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-15', 0, 0, NULL, 0, 1, 1);

-- Tabla 24.2: roles_sistema (se omite id_rol_sistema)
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('ADMIN', 'Administrador del sistema', 5, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('GERENTE', 'Gerente de área', 4, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('SUPERVISOR', 'Supervisor operativo', 3, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('OPERADOR', 'Operador de sistemas', 2, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('CONSULTA', 'Solo consulta', 1, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('RRHH', 'Recursos Humanos', 3, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('FINANZAS', 'Departamento financiero', 3, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('MANTENIMIENTO', 'Técnicos de mantenimiento', 2, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('COMERCIAL', 'Área comercial', 2, 1);
INSERT INTO roles_sistema (nombre_rol, descripcion, nivel_jerarquico, activo) VALUES
('SEGURIDAD', 'Personal de seguridad', 2, 1);

-- Tabla 24.3: usuarios_roles (clave compuesta, no autoincremental)
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(1, 1, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(1, 2, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(2, 3, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(3, 6, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(4, 7, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(5, 8, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(6, 4, DATE '2024-01-01', 1, 0);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(7, 9, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(8, 8, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(9, 5, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(10, 10, DATE '2024-01-01', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(11, 4, DATE '2024-01-15', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(12, 4, DATE '2024-01-15', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(13, 4, DATE '2024-01-15', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(14, 4, DATE '2024-01-15', 1, 1);
INSERT INTO usuarios_roles (id_usuario_sistema, id_rol_sistema, fecha_asignacion, asignado_por, activo) VALUES
(15, 4, DATE '2024-01-15', 1, 1);

-- Tabla 24.4: modulos_sistema (se omite id_modulo_sistema)
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Dashboard', 'Panel principal', '/dashboard', 'home', 1, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Vuelos', 'Gestión de vuelos', '/vuelos', 'flight', 2, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Reservas', 'Gestión de reservas', '/reservas', 'booking', 3, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Pasajeros', 'Datos de pasajeros', '/pasajeros', 'people', 4, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Aeropuertos', 'Infraestructura', '/aeropuertos', 'airport', 5, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Finanzas', 'Gestión financiera', '/finanzas', 'finance', 6, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('RRHH', 'Recursos Humanos', '/rrhh', 'hr', 7, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Mantenimiento', 'Gestión técnica', '/mantenimiento', 'maintenance', 8, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Reportes', 'Generación de reportes', '/reportes', 'reports', 9, 1);
INSERT INTO modulos_sistema (nombre_modulo, descripcion, ruta_acceso, icono, orden, activo) VALUES
('Configuración', 'Configuración del sistema', '/config', 'settings', 10, 1);

-- Tabla 24.5: roles_permisos_modulos (clave compuesta, no autoincremental)
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(1, 1, 1, 1, 1, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(1, 2, 1, 1, 1, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(2, 2, 1, 1, 1, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(2, 3, 1, 1, 0, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(3, 2, 1, 1, 0, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(4, 2, 1, 0, 0, 0);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(5, 1, 1, 0, 0, 0);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(5, 2, 1, 0, 0, 0);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(6, 7, 1, 1, 1, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(7, 6, 1, 1, 1, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(8, 8, 1, 1, 0, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(9, 3, 1, 1, 0, 1);
INSERT INTO roles_permisos_modulos (id_rol_sistema, id_modulo_sistema, permiso_lectura, permiso_escritura, permiso_eliminacion, permiso_ejecucion) VALUES
(10, 5, 1, 0, 0, 1);

-- Tabla 24.6: logs_acceso_sistema (se omite id_log_acceso)
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(1, TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.1.100', 'PC', 'Chrome', 'Windows 11', 'LOGIN', 'EXITOSO', 'SES-001');
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(1, TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.1.100', 'PC', 'Chrome', 'Windows 11', 'LOGOUT', 'EXITOSO', 'SES-001');
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(2, TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.1.101', 'iPhone', 'Safari', 'iOS', 'LOGIN', 'EXITOSO', 'SES-002');
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(3, TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), '10.0.0.25', 'iPad', 'Safari', 'iPadOS', 'LOGIN', 'EXITOSO', 'SES-003');
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(6, TO_TIMESTAMP('2024-03-18 13:00:00', 'YYYY-MM-DD HH24:MI:SS'), '172.16.0.1', 'PC', 'Firefox', 'Windows 10', 'LOGIN', 'FALLIDO', NULL);
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(6, TO_TIMESTAMP('2024-03-18 13:05:00', 'YYYY-MM-DD HH24:MI:SS'), '172.16.0.1', 'PC', 'Firefox', 'Windows 10', 'LOGIN', 'FALLIDO', NULL);
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(6, TO_TIMESTAMP('2024-03-18 13:10:00', 'YYYY-MM-DD HH24:MI:SS'), '172.16.0.1', 'PC', 'Firefox', 'Windows 10', 'LOGIN', 'BLOQUEADO', NULL);
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(7, TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.2.50', 'iPhone', 'Chrome', 'iOS', 'LOGIN', 'EXITOSO', 'SES-004');
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(8, TO_TIMESTAMP('2024-03-18 15:00:00', 'YYYY-MM-DD HH24:MI:SS'), '10.1.1.10', 'PC', 'Edge', 'Windows 11', 'LOGIN', 'EXITOSO', 'SES-005');
INSERT INTO logs_acceso_sistema (id_usuario_sistema, timestamp_acceso, ip_origen, dispositivo, navegador, sistema_operativo, tipo_acceso, resultado, sesion_id) VALUES
(9, TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), '10.1.1.11', 'Samsung', 'Chrome', 'Android', 'LOGIN', 'EXITOSO', 'SES-006');

-- Tabla 24.7: tokens_autenticacion (se omite id_token)
INSERT INTO tokens_autenticacion (id_usuario_sistema, token, tipo_token, fecha_emision, fecha_expiracion, ultimo_uso, ip_creacion, dispositivo_creacion, revocado, fecha_revocacion, motivo_revocacion) VALUES
(1, 'token_1234567890', 'SESION', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.1.100', 'PC', 0, NULL, NULL);
INSERT INTO tokens_autenticacion (id_usuario_sistema, token, tipo_token, fecha_emision, fecha_expiracion, ultimo_uso, ip_creacion, dispositivo_creacion, revocado, fecha_revocacion, motivo_revocacion) VALUES
(2, 'token_2345678901', 'SESION', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 21:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), '192.168.1.101', 'iPhone', 0, NULL, NULL);
INSERT INTO tokens_autenticacion (id_usuario_sistema, token, tipo_token, fecha_emision, fecha_expiracion, ultimo_uso, ip_creacion, dispositivo_creacion, revocado, fecha_revocacion, motivo_revocacion) VALUES
(3, 'token_3456789012', 'API', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-04-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), '10.0.0.25', 'iPad', 0, NULL, NULL);
INSERT INTO tokens_autenticacion (id_usuario_sistema, token, tipo_token, fecha_emision, fecha_expiracion, ultimo_uso, ip_creacion, dispositivo_creacion, revocado, fecha_revocacion, motivo_revocacion) VALUES
(5, 'token_4567890123', 'RECUPERACION', TO_TIMESTAMP('2024-03-17 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-17 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), '172.16.0.2', 'PC', 1, TO_TIMESTAMP('2024-03-18 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Expirado');

-- Tabla 24.8: bitacora_cambios_db (se omite id_bitacora_cambio)
INSERT INTO bitacora_cambios_db (id_usuario_sistema, timestamp_cambio, tabla_afectada, registro_id, tipo_operacion, valores_anteriores, valores_nuevos, ip_origen, sesion_id) VALUES
(1, TO_TIMESTAMP('2024-03-18 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'VUELOS', 7, 'UPDATE', 'estado=PROGRAMADO', 'estado=CANCELADO', '192.168.1.100', 'SES-001');
INSERT INTO bitacora_cambios_db (id_usuario_sistema, timestamp_cambio, tabla_afectada, registro_id, tipo_operacion, valores_anteriores, valores_nuevos, ip_origen, sesion_id) VALUES
(2, TO_TIMESTAMP('2024-03-18 11:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'RESERVAS', 1, 'UPDATE', 'asiento=14B', 'asiento=12A', '192.168.1.101', 'SES-002');
INSERT INTO bitacora_cambios_db (id_usuario_sistema, timestamp_cambio, tabla_afectada, registro_id, tipo_operacion, valores_anteriores, valores_nuevos, ip_origen, sesion_id) VALUES
(3, TO_TIMESTAMP('2024-03-18 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'EMPLEADOS', 5, 'UPDATE', 'salario_base=42000', 'salario_base=45000', '10.0.0.25', 'SES-003');
INSERT INTO bitacora_cambios_db (id_usuario_sistema, timestamp_cambio, tabla_afectada, registro_id, tipo_operacion, valores_anteriores, valores_nuevos, ip_origen, sesion_id) VALUES
(4, TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRESUPUESTOS', 3, 'UPDATE', 'monto_ejecutado=300000', 'monto_ejecutado=325000', '192.168.1.102', 'SES-007');

-- Tabla 24.9: respaldos_sistema (se omite id_respaldo)
INSERT INTO respaldos_sistema (fecha_respaldo, tipo_respaldo, tamano_mb, ubicacion_respaldo, nombre_archivo, verificado, fecha_verificacion, realizado_por, observaciones) VALUES
(TO_TIMESTAMP('2024-03-18 02:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPLETO', 5120.50, '/backups/bd/', 'backup_20240318_full.bkp', 1, TO_TIMESTAMP('2024-03-18 03:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 'Respaldo semanal');
INSERT INTO respaldos_sistema (fecha_respaldo, tipo_respaldo, tamano_mb, ubicacion_respaldo, nombre_archivo, verificado, fecha_verificacion, realizado_por, observaciones) VALUES
(TO_TIMESTAMP('2024-03-19 02:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'INCREMENTAL', 850.25, '/backups/bd/', 'backup_20240319_inc.bkp', 1, TO_TIMESTAMP('2024-03-19 03:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);
INSERT INTO respaldos_sistema (fecha_respaldo, tipo_respaldo, tamano_mb, ubicacion_respaldo, nombre_archivo, verificado, fecha_verificacion, realizado_por, observaciones) VALUES
(TO_TIMESTAMP('2024-03-20 02:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'INCREMENTAL', 795.75, '/backups/bd/', 'backup_20240320_inc.bkp', 0, NULL, 1, NULL);
INSERT INTO respaldos_sistema (fecha_respaldo, tipo_respaldo, tamano_mb, ubicacion_respaldo, nombre_archivo, verificado, fecha_verificacion, realizado_por, observaciones) VALUES
(TO_TIMESTAMP('2024-03-17 02:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'DIFERENCIAL', 2100.30, '/backups/bd/', 'backup_20240317_diff.bkp', 1, TO_TIMESTAMP('2024-03-17 03:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL);

-- Tabla 24.10: incidentes_seguridad_informatica (se omite id_incidente_seguridad_info)
INSERT INTO incidentes_seguridad_informatica (fecha_deteccion, tipo_incidente, nivel_gravedad, descripcion, ip_origen, usuario_afectado, acciones_tomadas, fecha_resolucion, responsable_resolucion, requiere_notificacion_legal, notificado_legal, estado) VALUES
(TO_TIMESTAMP('2024-03-18 13:10:00', 'YYYY-MM-DD HH24:MI:SS'), 'FUERZA_BRUTA', 'MEDIO', 'Múltiples intentos de acceso fallidos', '172.16.0.1', 6, 'Bloqueo de usuario y notificación', TO_TIMESTAMP('2024-03-18 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 0, 0, 'RESUELTO');
INSERT INTO incidentes_seguridad_informatica (fecha_deteccion, tipo_incidente, nivel_gravedad, descripcion, ip_origen, usuario_afectado, acciones_tomadas, fecha_resolucion, responsable_resolucion, requiere_notificacion_legal, notificado_legal, estado) VALUES
(TO_TIMESTAMP('2024-03-17 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'PHISHING', 'ALTO', 'Email sospechoso reportado por empleado', '45.33.22.11', 3, 'Investigación y bloqueo remitente', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 1, 1, 'RESUELTO');
INSERT INTO incidentes_seguridad_informatica (fecha_deteccion, tipo_incidente, nivel_gravedad, descripcion, ip_origen, usuario_afectado, acciones_tomadas, fecha_resolucion, responsable_resolucion, requiere_notificacion_legal, notificado_legal, estado) VALUES
(TO_TIMESTAMP('2024-03-16 15:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'MALWARE', 'CRITICO', 'Detección de software malicioso en estación de trabajo', '10.0.0.50', 5, 'Aislamiento del equipo y análisis forense', NULL, 1, 1, 1, 'EN_INVESTIGACION');
INSERT INTO incidentes_seguridad_informatica (fecha_deteccion, tipo_incidente, nivel_gravedad, descripcion, ip_origen, usuario_afectado, acciones_tomadas, fecha_resolucion, responsable_resolucion, requiere_notificacion_legal, notificado_legal, estado) VALUES
(TO_TIMESTAMP('2024-03-15 11:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'ACCESO_NO_AUTORIZADO', 'BAJO', 'Intento de acceso a módulo restringido', '192.168.2.150', NULL, 'Revisión de permisos', TO_TIMESTAMP('2024-03-15 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 0, 0, 'RESUELTO');
INSERT INTO incidentes_seguridad_informatica (fecha_deteccion, tipo_incidente, nivel_gravedad, descripcion, ip_origen, usuario_afectado, acciones_tomadas, fecha_resolucion, responsable_resolucion, requiere_notificacion_legal, notificado_legal, estado) VALUES
(TO_TIMESTAMP('2024-03-14 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'FILTRACION', 'ALTO', 'Filtración de datos de prueba', NULL, NULL, 'Revisión de logs', TO_TIMESTAMP('2024-03-16 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 1, 1, 'FALSO_POSITIVO');

-- Tabla 24.11: politicas_seguridad (se omite id_politica)
INSERT INTO politicas_seguridad (nombre_politica, version, fecha_aprobacion, fecha_vigencia, fecha_revision, contenido, aprobado_por, responsable_ejecucion, activa) VALUES
('Política de Contraseñas', '2.0', DATE '2024-01-15', DATE '2024-01-15', DATE '2025-01-15', 'Longitud mínima 8 caracteres, mayúsculas, minúsculas, números y caracteres especiales', 1, 2, 1);
INSERT INTO politicas_seguridad (nombre_politica, version, fecha_aprobacion, fecha_vigencia, fecha_revision, contenido, aprobado_por, responsable_ejecucion, activa) VALUES
('Política de Acceso Remoto', '1.5', DATE '2024-02-01', DATE '2024-02-01', DATE '2024-08-01', 'Acceso solo mediante VPN y autenticación 2FA', 1, 2, 1);
INSERT INTO politicas_seguridad (nombre_politica, version, fecha_aprobacion, fecha_vigencia, fecha_revision, contenido, aprobado_por, responsable_ejecucion, activa) VALUES
('Política de Backup', '3.0', DATE '2023-12-10', DATE '2024-01-01', DATE '2024-06-01', 'Backups diarios incrementales y semanales completos', 1, 3, 1);
INSERT INTO politicas_seguridad (nombre_politica, version, fecha_aprobacion, fecha_vigencia, fecha_revision, contenido, aprobado_por, responsable_ejecucion, activa) VALUES
('Política de Incidentes', '2.1', DATE '2024-01-20', DATE '2024-01-20', DATE '2024-07-20', 'Protocolo de respuesta ante incidentes de seguridad', 1, 3, 1);
INSERT INTO politicas_seguridad (nombre_politica, version, fecha_aprobacion, fecha_vigencia, fecha_revision, contenido, aprobado_por, responsable_ejecucion, activa) VALUES
('Política de Software', '1.2', DATE '2024-02-15', DATE '2024-03-01', DATE '2024-09-01', 'Software únicamente autorizado por TI', 1, 2, 1);

-- Tabla 24.12: auditorias_seguridad (se omite id_auditoria_seguridad)
INSERT INTO auditorias_seguridad (fecha_auditoria, tipo_auditoria, entidad_auditora, alcance, hallazgos, recomendaciones, fecha_cierre, responsable_cierre, estado) VALUES
(DATE '2024-02-15', 'INTERNA', 'Equipo TI', 'Revisión de accesos privilegiados', 'Usuarios con permisos excesivos detectados', 'Revisar y ajustar perfiles', DATE '2024-02-28', 1, 'COMPLETADA');
INSERT INTO auditorias_seguridad (fecha_auditoria, tipo_auditoria, entidad_auditora, alcance, hallazgos, recomendaciones, fecha_cierre, responsable_cierre, estado) VALUES
(DATE '2024-03-01', 'EXTERNA', 'Seguritech', 'Penetration testing', 'Vulnerabilidades en aplicación web', 'Corregir inyecciones SQL', NULL, NULL, 'EN_PROCESO');
INSERT INTO auditorias_seguridad (fecha_auditoria, tipo_auditoria, entidad_auditora, alcance, hallazgos, recomendaciones, fecha_cierre, responsable_cierre, estado) VALUES
(DATE '2024-01-10', 'REGULATORIA', 'AEPD', 'Cumplimiento RGPD', 'Consentimientos informados OK', 'Mantener registros', DATE '2024-02-10', 1, 'COMPLETADA');
INSERT INTO auditorias_seguridad (fecha_auditoria, tipo_auditoria, entidad_auditora, alcance, hallazgos, recomendaciones, fecha_cierre, responsable_cierre, estado) VALUES
(DATE '2024-03-10', 'INTERNA', 'Auditoría Interna', 'Revisión de logs', 'No se detectaron anomalías', 'Continuar monitoreo', NULL, NULL, 'EN_PROCESO');

COMMIT;
SELECT 'Módulo 24 completado' AS estado FROM dual;


-- =====================================================
-- MÓDULO 25: MARKETING Y FIDELIZACIÓN (10 TABLAS)
-- =====================================================

-- Tabla 25.1: campanas_marketing (se omite id_campana_marketing)
INSERT INTO campanas_marketing (nombre_campana, descripcion, tipo_campana, objetivo, fecha_inicio, fecha_fin, presupuesto, moneda, costo_real, publico_objetivo, segmento_objetivo, activa, responsable, resultados) VALUES
('Verano 2024', 'Promoción de vuelos a Caribe', 'EMAIL', 'VENTAS', DATE '2024-05-01', DATE '2024-08-31', 50000.00, 'EUR', NULL, 'Turistas 25-45 años', 'Vacaciones', 1, 7, NULL);
INSERT INTO campanas_marketing (nombre_campana, descripcion, tipo_campana, objetivo, fecha_inicio, fecha_fin, presupuesto, moneda, costo_real, publico_objetivo, segmento_objetivo, activa, responsable, resultados) VALUES
('Programa de Lealtad', 'Promoción de inscripción', 'SMS', 'FIDELIZACION', DATE '2024-03-01', DATE '2024-04-30', 15000.00, 'EUR', 12500.00, 'Viajeros frecuentes', 'Premium', 1, 7, '500 nuevas altas');
INSERT INTO campanas_marketing (nombre_campana, descripcion, tipo_campana, objetivo, fecha_inicio, fecha_fin, presupuesto, moneda, costo_real, publico_objetivo, segmento_objetivo, activa, responsable, resultados) VALUES
('Black Friday', 'Descuentos especiales', 'WEB', 'VENTAS', DATE '2024-11-20', DATE '2024-11-30', 75000.00, 'EUR', NULL, 'Todos los públicos', 'General', 1, 7, NULL);
INSERT INTO campanas_marketing (nombre_campana, descripcion, tipo_campana, objetivo, fecha_inicio, fecha_fin, presupuesto, moneda, costo_real, publico_objetivo, segmento_objetivo, activa, responsable, resultados) VALUES
('Lanzamiento Nueva York', 'Vuelo directo a JFK', 'PRENSA', 'LANZAMIENTO', DATE '2024-04-01', DATE '2024-05-15', 30000.00, 'EUR', NULL, 'Empresarios y turistas', 'Negocios', 1, 7, NULL);
INSERT INTO campanas_marketing (nombre_campana, descripcion, tipo_campana, objetivo, fecha_inicio, fecha_fin, presupuesto, moneda, costo_real, publico_objetivo, segmento_objetivo, activa, responsable, resultados) VALUES
('Redes Sociales', 'Campaña de engagement', 'REDES_SOCIALES', 'NOTORIEDAD', DATE '2024-02-01', DATE '2024-03-31', 20000.00, 'EUR', 18500.00, 'Millennials', 'Digital', 0, 7, 'Alcance 1M personas');

-- Tabla 25.2: segmentos_clientes (se omite id_segmento_cliente)
INSERT INTO segmentos_clientes (nombre_segmento, descripcion, criterios_json, frecuencia_viajes, clase_preferida, destinos_frecuentes, edad_promedio, nivel_ingresos, activo) VALUES
('Viajero Frecuente Premium', 'Clientes que viajan más de 10 veces al año', '{"vuelos_anio": ">10"}', 'ALTA', 'EJECUTIVA', '["MAD", "BCN", "JFK", "LHR"]', 45, 'ALTO', 1);
INSERT INTO segmentos_clientes (nombre_segmento, descripcion, criterios_json, frecuencia_viajes, clase_preferida, destinos_frecuentes, edad_promedio, nivel_ingresos, activo) VALUES
('Turista Vacacional', 'Viajes de placer 2-3 veces al año', '{"vuelos_anio": "2-5"}', 'MEDIA', 'ECONOMICA', '["MAD", "BCN", "PMI", "AGP"]', 35, 'MEDIO', 1);
INSERT INTO segmentos_clientes (nombre_segmento, descripcion, criterios_json, frecuencia_viajes, clase_preferida, destinos_frecuentes, edad_promedio, nivel_ingresos, activo) VALUES
('Viajero Ocasional', 'Viaja menos de 2 veces al año', '{"vuelos_anio": "<2"}', 'BAJA', 'ECONOMICA', '["MAD", "BCN"]', 30, 'BAJO', 1);
INSERT INTO segmentos_clientes (nombre_segmento, descripcion, criterios_json, frecuencia_viajes, clase_preferida, destinos_frecuentes, edad_promedio, nivel_ingresos, activo) VALUES
('Corporativo', 'Viajes de negocios', '{"motivo": "trabajo"}', 'ALTA', 'EJECUTIVA', '["MAD", "BCN", "JFK", "CDG"]', 42, 'ALTO', 1);
INSERT INTO segmentos_clientes (nombre_segmento, descripcion, criterios_json, frecuencia_viajes, clase_preferida, destinos_frecuentes, edad_promedio, nivel_ingresos, activo) VALUES
('Estudiante', 'Jóvenes entre 18-25 años', '{"edad": "18-25"}', 'BAJA', 'ECONOMICA', '["MAD", "BCN", "LON"]', 22, 'BAJO', 1);
INSERT INTO segmentos_clientes (nombre_segmento, descripcion, criterios_json, frecuencia_viajes, clase_preferida, destinos_frecuentes, edad_promedio, nivel_ingresos, activo) VALUES
('Familia', 'Viajes en grupo familiar', '{"tipo": "familia"}', 'MEDIA', 'ECONOMICA', '["PMI", "ALC", "AGP"]', 40, 'MEDIO', 1);
INSERT INTO segmentos_clientes (nombre_segmento, descripcion, criterios_json, frecuencia_viajes, clase_preferida, destinos_frecuentes, edad_promedio, nivel_ingresos, activo) VALUES
('Senior', 'Mayores de 65 años', '{"edad": ">65"}', 'BAJA', 'ECONOMICA', '["MAD", "BCN", "TFS"]', 70, 'MEDIO', 1);

-- Tabla 25.3: pasajeros_segmentos (clave compuesta, no autoincremental)
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(1, 2, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(2, 2, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(3, 1, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(4, 4, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(5, 1, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(5, 4, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(6, 2, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(7, 1, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(8, 2, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(9, 1, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(9, 4, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(10, 2, DATE '2024-01-01', 1, 1);
INSERT INTO pasajeros_segmentos (id_pasajero, id_segmento_cliente, fecha_asignacion, automatico, activo) VALUES
(10, 5, DATE '2024-01-01', 1, 1);

-- Tabla 25.4: ofertas_personalizadas (se omite id_oferta_personalizada)
INSERT INTO ofertas_personalizadas (id_segmento_cliente, id_promocion, titulo_oferta, descripcion, condiciones, descuento_porcentaje, descuento_fijo, fecha_inicio, fecha_fin, prioridad, visualizaciones, conversiones, activa, creada_por) VALUES
(1, 8, 'Upgrade gratis', 'Upgrade a clase ejecutiva', 'Sujeto a disponibilidad', NULL, NULL, DATE '2024-03-01', DATE '2024-04-30', 1, 150, 12, 1, 7);
INSERT INTO ofertas_personalizadas (id_segmento_cliente, id_promocion, titulo_oferta, descripcion, condiciones, descuento_porcentaje, descuento_fijo, fecha_inicio, fecha_fin, prioridad, visualizaciones, conversiones, activa, creada_por) VALUES
(2, 10, '15% de descuento', 'Descuento en tu próximo vuelo', 'Reserva con 30 días de antelación', 15.00, NULL, DATE '2024-03-01', DATE '2024-05-31', 2, 320, 45, 1, 7);
INSERT INTO ofertas_personalizadas (id_segmento_cliente, id_promocion, titulo_oferta, descripcion, condiciones, descuento_porcentaje, descuento_fijo, fecha_inicio, fecha_fin, prioridad, visualizaciones, conversiones, activa, creada_por) VALUES
(4, 7, 'Sala VIP', 'Acceso gratuito a sala VIP', 'En vuelos internacionales', NULL, NULL, DATE '2024-02-01', DATE '2024-06-30', 1, 85, 30, 1, 7);
INSERT INTO ofertas_personalizadas (id_segmento_cliente, id_promocion, titulo_oferta, descripcion, condiciones, descuento_porcentaje, descuento_fijo, fecha_inicio, fecha_fin, prioridad, visualizaciones, conversiones, activa, creada_por) VALUES
(5, 1, '50€ de descuento', 'Para estudiantes', 'Con carnet estudiante válido', NULL, 50.00, DATE '2024-03-15', DATE '2024-07-15', 3, 210, 28, 1, 7);
INSERT INTO ofertas_personalizadas (id_segmento_cliente, id_promocion, titulo_oferta, descripcion, condiciones, descuento_porcentaje, descuento_fijo, fecha_inicio, fecha_fin, prioridad, visualizaciones, conversiones, activa, creada_por) VALUES
(6, 9, '10% descuento familiar', 'Para grupos de 4 o más', 'Mínimo 4 pasajeros', 10.00, NULL, DATE '2024-04-01', DATE '2024-08-31', 2, 95, 18, 1, 7);

-- Tabla 25.5: canjes_puntos (se omite id_canje_puntos)
INSERT INTO canjes_puntos (id_pasajero, id_lealtad, fecha_canje, puntos_utilizados, tipo_canje, descripcion_canje, id_vuelo, id_producto, valor_monetario, moneda, estado_canje, procesado_por, observaciones) VALUES
(5, 5, TO_TIMESTAMP('2024-03-15 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 15000, 'UPGRADE', 'Upgrade a primera clase', 5, NULL, 500.00, 'USD', 'PROCESADO', 7, NULL);
INSERT INTO canjes_puntos (id_pasajero, id_lealtad, fecha_canje, puntos_utilizados, tipo_canje, descripcion_canje, id_vuelo, id_producto, valor_monetario, moneda, estado_canje, procesado_por, observaciones) VALUES
(3, 3, TO_TIMESTAMP('2024-03-10 14:20:00', 'YYYY-MM-DD HH24:MI:SS'), 8000, 'EQUIPAJE_EXTRA', 'Maleta adicional', 2, NULL, 80.00, 'USD', 'PROCESADO', 7, NULL);
INSERT INTO canjes_puntos (id_pasajero, id_lealtad, fecha_canje, puntos_utilizados, tipo_canje, descripcion_canje, id_vuelo, id_producto, valor_monetario, moneda, estado_canje, procesado_por, observaciones) VALUES
(9, 9, TO_TIMESTAMP('2024-03-12 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 25000, 'VUELO', 'Vuelo Madrid-Londres', 10, NULL, 350.00, 'GBP', 'PROCESADO', 7, NULL);
INSERT INTO canjes_puntos (id_pasajero, id_lealtad, fecha_canje, puntos_utilizados, tipo_canje, descripcion_canje, id_vuelo, id_producto, valor_monetario, moneda, estado_canje, procesado_por, observaciones) VALUES
(1, 1, TO_TIMESTAMP('2024-03-05 16:40:00', 'YYYY-MM-DD HH24:MI:SS'), 5000, 'PRODUCTO', 'Perfume en tienda', NULL, 5, 85.00, 'EUR', 'ENTREGADO', 7, NULL);
INSERT INTO canjes_puntos (id_pasajero, id_lealtad, fecha_canje, puntos_utilizados, tipo_canje, descripcion_canje, id_vuelo, id_producto, valor_monetario, moneda, estado_canje, procesado_por, observaciones) VALUES
(7, 7, TO_TIMESTAMP('2024-03-08 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 12000, 'SERVICIO', 'Acceso a sala VIP', NULL, NULL, 40.00, 'EUR', 'PROCESADO', 7, NULL);
INSERT INTO canjes_puntos (id_pasajero, id_lealtad, fecha_canje, puntos_utilizados, tipo_canje, descripcion_canje, id_vuelo, id_producto, valor_monetario, moneda, estado_canje, procesado_por, observaciones) VALUES
(2, 2, TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2000, 'PRODUCTO', 'Café en Starbucks', NULL, 3, 4.50, 'EUR', 'PROCESADO', 7, NULL);

-- Tabla 25.6: newsletter_suscripciones (se omite id_suscripcion_newsletter)
INSERT INTO newsletter_suscripciones (id_pasajero, email, nombre, fecha_suscripcion, fecha_baja, frecuencia, temas_interes, confirmado, token_confirmacion, activo) VALUES
(1, 'alejandro.fernandez@email.com', 'Alejandro Fernández', DATE '2024-01-15', NULL, 'MENSUAL', 'ofertas, destinos', 1, 'TOKEN123', 1);
INSERT INTO newsletter_suscripciones (id_pasajero, email, nombre, fecha_suscripcion, fecha_baja, frecuencia, temas_interes, confirmado, token_confirmacion, activo) VALUES
(2, 'laura.martinez@email.com', 'Laura Martínez', DATE '2024-02-01', NULL, 'SEMANAL', 'ofertas, novedades', 1, 'TOKEN234', 1);
INSERT INTO newsletter_suscripciones (id_pasajero, email, nombre, fecha_suscripcion, fecha_baja, frecuencia, temas_interes, confirmado, token_confirmacion, activo) VALUES
(3, 'carlos.rodriguez@email.com', 'Carlos Rodríguez', DATE '2024-01-20', NULL, 'MENSUAL', 'programa lealtad', 1, 'TOKEN345', 1);
INSERT INTO newsletter_suscripciones (id_pasajero, email, nombre, fecha_suscripcion, fecha_baja, frecuencia, temas_interes, confirmado, token_confirmacion, activo) VALUES
(5, 'michael.johnson@email.com', 'Michael Johnson', DATE '2024-02-15', NULL, 'TRIMESTRAL', 'destinos internacionales', 1, 'TOKEN456', 1);
INSERT INTO newsletter_suscripciones (id_pasajero, email, nombre, fecha_suscripcion, fecha_baja, frecuencia, temas_interes, confirmado, token_confirmacion, activo) VALUES
(7, 'jean.dupont@email.com', 'Jean Dupont', DATE '2024-03-01', NULL, 'MENSUAL', 'ofertas', 1, 'TOKEN567', 1);
INSERT INTO newsletter_suscripciones (id_pasajero, email, nombre, fecha_suscripcion, fecha_baja, frecuencia, temas_interes, confirmado, token_confirmacion, activo) VALUES
(9, 'david.brown@email.com', 'David Brown', DATE '2024-02-20', DATE '2024-03-15', 'MENSUAL', 'ofertas', 1, 'TOKEN678', 0);
INSERT INTO newsletter_suscripciones (id_pasajero, email, nombre, fecha_suscripcion, fecha_baja, frecuencia, temas_interes, confirmado, token_confirmacion, activo) VALUES
(NULL, 'cliente.nuevo@email.com', 'Cliente Nuevo', DATE '2024-03-10', NULL, 'MENSUAL', 'ofertas, novedades', 0, 'TOKEN789', 1);

-- Tabla 25.7: newsletter_envios (se omite id_envio_newsletter)
INSERT INTO newsletter_envios (id_suscripcion_newsletter, id_campana_marketing, fecha_envio, asunto, contenido, formato, abierto, fecha_apertura, clicks, convertido) VALUES
(1, 2, TO_TIMESTAMP('2024-03-01 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Ofertas exclusivas para ti', '<h1>50% en tu próximo vuelo</h1>', 'HTML', 1, TO_TIMESTAMP('2024-03-01 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 2, 1);
INSERT INTO newsletter_envios (id_suscripcion_newsletter, id_campana_marketing, fecha_envio, asunto, contenido, formato, abierto, fecha_apertura, clicks, convertido) VALUES
(2, 2, TO_TIMESTAMP('2024-03-01 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Ofertas exclusivas para ti', '<h1>50% en tu próximo vuelo</h1>', 'HTML', 1, TO_TIMESTAMP('2024-03-01 11:15:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 0);
INSERT INTO newsletter_envios (id_suscripcion_newsletter, id_campana_marketing, fecha_envio, asunto, contenido, formato, abierto, fecha_apertura, clicks, convertido) VALUES
(3, 2, TO_TIMESTAMP('2024-03-01 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Ofertas exclusivas para ti', '<h1>50% en tu próximo vuelo</h1>', 'HTML', 0, NULL, 0, 0);
INSERT INTO newsletter_envios (id_suscripcion_newsletter, id_campana_marketing, fecha_envio, asunto, contenido, formato, abierto, fecha_apertura, clicks, convertido) VALUES
(4, 5, TO_TIMESTAMP('2024-02-15 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Síguenos en redes', 'Estamos en Instagram y Facebook', 'TEXTO', 1, TO_TIMESTAMP('2024-02-15 09:45:00', 'YYYY-MM-DD HH24:MI:SS'), 3, 0);
INSERT INTO newsletter_envios (id_suscripcion_newsletter, id_campana_marketing, fecha_envio, asunto, contenido, formato, abierto, fecha_apertura, clicks, convertido) VALUES
(5, 2, TO_TIMESTAMP('2024-03-01 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Ofertas exclusivas para ti', '<h1>50% en tu próximo vuelo</h1>', 'HTML', 1, TO_TIMESTAMP('2024-03-01 12:20:00', 'YYYY-MM-DD HH24:MI:SS'), 0, 0);
INSERT INTO newsletter_envios (id_suscripcion_newsletter, id_campana_marketing, fecha_envio, asunto, contenido, formato, abierto, fecha_apertura, clicks, convertido) VALUES
(7, 2, TO_TIMESTAMP('2024-03-10 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Confirma tu suscripción', 'Por favor confirma tu email', 'HTML', 1, TO_TIMESTAMP('2024-03-10 11:20:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 0);

-- Tabla 25.8: encuestas_post_vuelo (se omite id_encuesta_post_vuelo)
INSERT INTO encuestas_post_vuelo (id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_tripulacion, puntuacion_comida, puntuacion_confort, puntuacion_puntualidad, comentarios, recomendaria, nps_generado, procesada) VALUES
(1, 1, TO_TIMESTAMP('2024-03-19 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'EMAIL', 4, 5, 4, 4, 3, 4, 3, 'Comida mejorable', 1, 0, 1);
INSERT INTO encuestas_post_vuelo (id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_tripulacion, puntuacion_comida, puntuacion_confort, puntuacion_puntualidad, comentarios, recomendaria, nps_generado, procesada) VALUES
(2, 3, TO_TIMESTAMP('2024-03-19 11:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'SMS', 5, 5, 5, 5, 4, 5, 5, 'Excelente viaje', 1, 100, 1);
INSERT INTO encuestas_post_vuelo (id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_tripulacion, puntuacion_comida, puntuacion_confort, puntuacion_puntualidad, comentarios, recomendaria, nps_generado, procesada) VALUES
(3, 5, TO_TIMESTAMP('2024-03-19 14:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'WEB', 5, 5, 5, 5, 5, 5, 5, 'Perfecto', 1, 100, 1);
INSERT INTO encuestas_post_vuelo (id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_tripulacion, puntuacion_comida, puntuacion_confort, puntuacion_puntualidad, comentarios, recomendaria, nps_generado, procesada) VALUES
(2, 4, TO_TIMESTAMP('2024-03-19 15:10:00', 'YYYY-MM-DD HH24:MI:SS'), 'APP', 2, 3, 2, 3, 2, 2, 1, 'Perdieron mi maleta', 0, -100, 1);
INSERT INTO encuestas_post_vuelo (id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_tripulacion, puntuacion_comida, puntuacion_confort, puntuacion_puntualidad, comentarios, recomendaria, nps_generado, procesada) VALUES
(5, 9, TO_TIMESTAMP('2024-03-20 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'EMAIL', 5, 5, 5, 5, 5, 5, 5, 'Vuelo largo pero muy cómodo', 1, 100, 1);
INSERT INTO encuestas_post_vuelo (id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_tripulacion, puntuacion_comida, puntuacion_confort, puntuacion_puntualidad, comentarios, recomendaria, nps_generado, procesada) VALUES
(10, 10, TO_TIMESTAMP('2024-03-21 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'APP', 4, 5, 4, 4, 4, 4, 5, 'Mascota viajó bien', 1, 0, 0);
INSERT INTO encuestas_post_vuelo (id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_tripulacion, puntuacion_comida, puntuacion_confort, puntuacion_puntualidad, comentarios, recomendaria, nps_generado, procesada) VALUES
(6, 8, TO_TIMESTAMP('2024-03-19 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'WEB', 4, 4, 4, 5, 3, 4, 4, 'Bien en general', 1, 0, 1);
INSERT INTO encuestas_post_vuelo (id_vuelo, id_pasajero, fecha_encuesta, canal_respuesta, puntuacion_general, puntuacion_checkin, puntuacion_abordaje, puntuacion_tripulacion, puntuacion_comida, puntuacion_confort, puntuacion_puntualidad, comentarios, recomendaria, nps_generado, procesada) VALUES
(1, 2, TO_TIMESTAMP('2024-03-19 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'PRESENCIAL', 3, 4, 3, 4, 3, 3, 3, NULL, 1, -33, 1);

-- Tabla 25.9: analisis_comportamiento (se omite id_analisis_comportamiento)
INSERT INTO analisis_comportamiento (id_pasajero, fecha_analisis, vuelos_anio, vuelos_mes, vuelos_semana, destinos_frecuentes, aerolineas_preferidas, clase_preferida, dia_preferido_viaje, mes_preferido_viaje, anticipacion_promedio_reserva, gasto_promedio_anual, gasto_promedio_vuelo, ingresos_totales_generados, score_fidelidad, ultima_actualizacion) VALUES
(1, DATE '2024-03-01', 6, 1, 0, 'MAD, BOG', 'IB, AV', 'ECONOMICA', 'VIERNES', 7, 30, 3500.00, 580.00, 3500.00, 75.5, TO_TIMESTAMP('2024-03-01 12:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO analisis_comportamiento (id_pasajero, fecha_analisis, vuelos_anio, vuelos_mes, vuelos_semana, destinos_frecuentes, aerolineas_preferidas, clase_preferida, dia_preferido_viaje, mes_preferido_viaje, anticipacion_promedio_reserva, gasto_promedio_anual, gasto_promedio_vuelo, ingresos_totales_generados, score_fidelidad, ultima_actualizacion) VALUES
(3, DATE '2024-03-01', 12, 2, 0, 'MAD, BOG, MEX', 'AV, IB', 'EJECUTIVA', 'LUNES', 3, 45, 12000.00, 1000.00, 12000.00, 95.0, TO_TIMESTAMP('2024-03-01 12:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO analisis_comportamiento (id_pasajero, fecha_analisis, vuelos_anio, vuelos_mes, vuelos_semana, destinos_frecuentes, aerolineas_preferidas, clase_preferida, dia_preferido_viaje, mes_preferido_viaje, anticipacion_promedio_reserva, gasto_promedio_anual, gasto_promedio_vuelo, ingresos_totales_generados, score_fidelidad, ultima_actualizacion) VALUES
(5, DATE '2024-03-01', 18, 3, 1, 'JFK, LAX, LHR', 'AA, UA', 'PRIMERA_CLASE', 'JUEVES', 5, 60, 35000.00, 1944.00, 35000.00, 98.0, TO_TIMESTAMP('2024-03-01 12:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO analisis_comportamiento (id_pasajero, fecha_analisis, vuelos_anio, vuelos_mes, vuelos_semana, destinos_frecuentes, aerolineas_preferidas, clase_preferida, dia_preferido_viaje, mes_preferido_viaje, anticipacion_promedio_reserva, gasto_promedio_anual, gasto_promedio_vuelo, ingresos_totales_generados, score_fidelidad, ultima_actualizacion) VALUES
(7, DATE '2024-03-01', 9, 1, 0, 'CDG, JFK', 'AF, DL', 'EJECUTIVA', 'MARTES', 6, 30, 8500.00, 944.00, 8500.00, 82.0, TO_TIMESTAMP('2024-03-01 12:00:00', 'YYYY-MM-DD HH24:MI:SS'));
INSERT INTO analisis_comportamiento (id_pasajero, fecha_analisis, vuelos_anio, vuelos_mes, vuelos_semana, destinos_frecuentes, aerolineas_preferidas, clase_preferida, dia_preferido_viaje, mes_preferido_viaje, anticipacion_promedio_reserva, gasto_promedio_anual, gasto_promedio_vuelo, ingresos_totales_generados, score_fidelidad, ultima_actualizacion) VALUES
(9, DATE '2024-03-01', 7, 1, 0, 'LHR, SYD, LAX', 'BA, UA', 'PRIMERA_CLASE', 'VIERNES', 8, 50, 15000.00, 2143.00, 15000.00, 88.0, TO_TIMESTAMP('2024-03-01 12:00:00', 'YYYY-MM-DD HH24:MI:SS'));

-- Tabla 25.10: reacciones_promociones (se omite id_reaccion)
INSERT INTO reacciones_promociones (id_oferta_personalizada, id_pasajero, fecha_reaccion, tipo_reaccion, canal, convertido_en_reserva, id_reserva, valor_conversion) VALUES
(2, 1, TO_TIMESTAMP('2024-03-02 10:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'CLICK', 'EMAIL', 1, 1, 450.00);
INSERT INTO reacciones_promociones (id_oferta_personalizada, id_pasajero, fecha_reaccion, tipo_reaccion, canal, convertido_en_reserva, id_reserva, valor_conversion) VALUES
(2, 2, TO_TIMESTAMP('2024-03-03 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'CLICK', 'SMS', 1, 3, 4200000.00);
INSERT INTO reacciones_promociones (id_oferta_personalizada, id_pasajero, fecha_reaccion, tipo_reaccion, canal, convertido_en_reserva, id_reserva, valor_conversion) VALUES
(1, 3, TO_TIMESTAMP('2024-03-05 09:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'APLICADA', 'APP', 0, NULL, NULL);
INSERT INTO reacciones_promociones (id_oferta_personalizada, id_pasajero, fecha_reaccion, tipo_reaccion, canal, convertido_en_reserva, id_reserva, valor_conversion) VALUES
(3, 5, TO_TIMESTAMP('2024-03-04 14:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'VISTA', 'EMAIL', 0, NULL, NULL);
INSERT INTO reacciones_promociones (id_oferta_personalizada, id_pasajero, fecha_reaccion, tipo_reaccion, canal, convertido_en_reserva, id_reserva, valor_conversion) VALUES
(4, 10, TO_TIMESTAMP('2024-03-18 16:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'CLICK', 'WEB', 1, 10, 2100.00);
INSERT INTO reacciones_promociones (id_oferta_personalizada, id_pasajero, fecha_reaccion, tipo_reaccion, canal, convertido_en_reserva, id_reserva, valor_conversion) VALUES
(5, 4, TO_TIMESTAMP('2024-03-15 12:10:00', 'YYYY-MM-DD HH24:MI:SS'), 'APLICADA', 'EMAIL', 1, 4, 2100000.00);
INSERT INTO reacciones_promociones (id_oferta_personalizada, id_pasajero, fecha_reaccion, tipo_reaccion, canal, convertido_en_reserva, id_reserva, valor_conversion) VALUES
(2, 6, TO_TIMESTAMP('2024-03-07 08:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'COMPARTIDA', 'APP', 0, NULL, NULL);
INSERT INTO reacciones_promociones (id_oferta_personalizada, id_pasajero, fecha_reaccion, tipo_reaccion, canal, convertido_en_reserva, id_reserva, valor_conversion) VALUES
(1, 9, TO_TIMESTAMP('2024-03-10 17:50:00', 'YYYY-MM-DD HH24:MI:SS'), 'CLICK', 'SMS', 0, NULL, NULL);

COMMIT;
SELECT 'Módulo 25 completado' AS estado FROM dual;

-- =====================================================
-- MÓDULO 26: GESTIÓN DOCUMENTAL Y REGULATORIA (10 TABLAS)
-- =====================================================

-- Tabla 26.1: normativas_aplicables (se omite id_normativa)
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('OACI-ANNEX-1', 'Anexo 1 - Licencias al personal', 'Requisitos para licencias de tripulación', 'OACI', 'Internacional', 'INTERNACIONAL', DATE '2022-01-01', DATE '2023-01-01', DATE '2023-06-01', '12', 'https://www.icao.int/annex1', 1, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('EASA-PART-145', 'EASA Part 145', 'Organizaciones de mantenimiento aprobadas', 'EASA', 'UE', 'REGIONAL', DATE '2022-03-15', DATE '2023-03-15', DATE '2023-09-15', '5', 'https://www.easa.europa.eu/part145', 1, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('AESA-SEG-001', 'Programa Estatal de Seguridad Operacional', 'Marco de seguridad para aviación civil', 'AESA', 'España', 'NACIONAL', DATE '2023-01-10', DATE '2023-04-10', DATE '2023-10-10', '2', 'https://www.seguridadaerea.es/peso', 1, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('LEY-18-2014', 'Ley de Navegación Aérea', 'Ley nacional de navegación aérea', 'BOE', 'España', 'NACIONAL', DATE '2014-07-15', DATE '2014-10-15', DATE '2022-12-20', '5', 'https://www.boe.es/ley18-2014', 1, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('RGPD-679-2016', 'Reglamento General de Protección de Datos', 'Protección de datos personales', 'Parlamento Europeo', 'UE', 'REGIONAL', DATE '2016-04-27', DATE '2018-05-25', DATE '2023-05-25', '2', 'https://www.europa.eu/rgpd', 1, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('IATA-DGR-64', 'Dangerous Goods Regulations', 'Regulación de mercancías peligrosas', 'IATA', 'Internacional', 'INTERNACIONAL', DATE '2023-01-01', DATE '2023-01-01', DATE '2024-01-01', '64', 'https://www.iata.org/dgr', 1, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('ORDEN-FOM-1234', 'Orden Ministerial de Tasas Aeroportuarias', 'Regulación de tasas', 'Ministerio Transportes', 'España', 'NACIONAL', DATE '2022-11-20', DATE '2023-01-01', DATE '2023-11-20', '3', NULL, 1, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('ISO-9001-2015', 'ISO 9001:2015', 'Sistemas de gestión de calidad', 'ISO', 'Internacional', 'INTERNACIONAL', DATE '2015-09-15', DATE '2015-09-15', DATE '2023-09-15', '2015', 'https://www.iso.org/9001', 0, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('REAL-DECRETO-123', 'Real Decreto de Seguridad Aeroportuaria', 'Medidas de seguridad en aeropuertos', 'BOE', 'España', 'NACIONAL', DATE '2023-02-28', DATE '2023-06-01', DATE '2023-12-01', '1', NULL, 1, 1);
INSERT INTO normativas_aplicables (codigo_normativa, titulo_normativa, descripcion, entidad_emisora, pais_origen, ambito_aplicacion, fecha_publicacion, fecha_vigencia, fecha_ultima_actualizacion, version, url_referencia, obligatoria, activa) VALUES
('ACUERDO-CIELOS-2023', 'Acuerdo de Cielos Abiertos UE-USA', 'Acuerdo bilateral de transporte aéreo', 'Comisión Europea', 'Internacional', 'INTERNACIONAL', DATE '2023-06-20', DATE '2023-10-01', DATE '2023-10-01', '2', NULL, 1, 1);

-- Tabla 26.2: documentos_requeridos_operacion (se omite id_documento_requerido)
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('VUELO_INTERNACIONAL', 'Pasaporte', 'Documento de viaje válido', 1, 'Electrónico/Físico', 'País origen', 1825, 1, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('VUELO_INTERNACIONAL', 'Visado', 'Visado de entrada según destino', 0, 'Físico', 'Consulado', 90, 1, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('VUELO_NACIONAL', 'DNI', 'Documento Nacional de Identidad', 1, 'Físico/Digital', 'Policía', 3650, 1, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('CARGA', 'Manifiesto de Carga', 'Lista detallada de mercancías', 1, 'Electrónico', 'Agente de carga', NULL, 0, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('CARGA', 'Declaración de Mercancías Peligrosas', 'Para envíos con materiales peligrosos', 0, 'Físico', 'Expedidor', NULL, 1, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('TRANSITO', 'Tarjeta de Embarque', 'Para pasajeros en conexión', 1, 'Digital/Físico', 'Aerolínea', 1, 0, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('PRIVADO', 'Licencia de Piloto', 'Licencia válida', 1, 'Físico', 'Aviación Civil', 365, 1, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('PRIVADO', 'Seguro de la aeronave', 'Póliza de seguro vigente', 1, 'Electrónico', 'Aseguradora', 365, 0, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('VUELO_INTERNACIONAL', 'Certificado de Vacunación', 'Vacunas requeridas', 0, 'Físico/Digital', 'Sanidad', NULL, 0, 1);
INSERT INTO documentos_requeridos_operacion (tipo_operacion, nombre_documento, descripcion, obligatorio, formato_aceptado, entidad_emisora_requerida, periodo_validez_dias, requiere_original, activo) VALUES
('CARGA', 'Certificado Fitosanitario', 'Para productos vegetales', 0, 'Físico', 'Sanidad Vegetal', 90, 1, 1);

-- Tabla 26.3: licencias_operativas_aeropuerto (se omite id_licencia_operativa)
INSERT INTO licencias_operativas_aeropuerto (codigo_licencia, nombre_licencia, tipo_licencia, entidad_otorgante, fecha_emision, fecha_vencimiento, fecha_renovacion, alcance, restricciones, responsable_seguimiento, renovacion_automatica, activa, observaciones) VALUES
('LIC-AENA-001', 'Licencia de Operación Aeroportuaria', 'OPERATIVA', 'AESA', DATE '2023-01-01', DATE '2025-12-31', DATE '2025-12-01', 'Operación comercial de pasajeros y carga', 'Horario limitado 00:00-06:00', 2, 0, 1, NULL);
INSERT INTO licencias_operativas_aeropuerto (codigo_licencia, nombre_licencia, tipo_licencia, entidad_otorgante, fecha_emision, fecha_vencimiento, fecha_renovacion, alcance, restricciones, responsable_seguimiento, renovacion_automatica, activa, observaciones) VALUES
('LIC-AMB-002', 'Licencia Ambiental', 'AMBIENTAL', 'Comunidad de Madrid', DATE '2023-03-15', DATE '2026-03-14', DATE '2026-02-15', 'Emisiones y ruido', 'Límite de operaciones nocturnas', 2, 1, 1, NULL);
INSERT INTO licencias_operativas_aeropuerto (codigo_licencia, nombre_licencia, tipo_licencia, entidad_otorgante, fecha_emision, fecha_vencimiento, fecha_renovacion, alcance, restricciones, responsable_seguimiento, renovacion_automatica, activa, observaciones) VALUES
('LIC-SEG-003', 'Certificado de Seguridad Aeroportuaria', 'SEGURIDAD', 'Ministerio Interior', DATE '2023-05-20', DATE '2024-05-19', DATE '2024-04-20', 'Seguridad operacional', 'Auditoría anual', 5, 0, 1, NULL);
INSERT INTO licencias_operativas_aeropuerto (codigo_licencia, nombre_licencia, tipo_licencia, entidad_otorgante, fecha_emision, fecha_vencimiento, fecha_renovacion, alcance, restricciones, responsable_seguimiento, renovacion_automatica, activa, observaciones) VALUES
('LIC-SAN-004', 'Licencia Sanitaria', 'SANITARIA', 'Sanidad Exterior', DATE '2023-02-10', DATE '2025-02-09', DATE '2025-01-10', 'Control sanitario de pasajeros y mercancías', 'Inspecciones periódicas', 7, 1, 1, NULL);
INSERT INTO licencias_operativas_aeropuerto (codigo_licencia, nombre_licencia, tipo_licencia, entidad_otorgante, fecha_emision, fecha_vencimiento, fecha_renovacion, alcance, restricciones, responsable_seguimiento, renovacion_automatica, activa, observaciones) VALUES
('LIC-CON-005', 'Licencia de Construcción', 'CONSTRUCCION', 'Ayuntamiento', DATE '2022-08-01', DATE '2025-07-31', DATE '2025-06-01', 'Obras en terminal T4', 'Sujeto a supervisión', 1, 0, 1, NULL);
INSERT INTO licencias_operativas_aeropuerto (codigo_licencia, nombre_licencia, tipo_licencia, entidad_otorgante, fecha_emision, fecha_vencimiento, fecha_renovacion, alcance, restricciones, responsable_seguimiento, renovacion_automatica, activa, observaciones) VALUES
('LIC-EXT-006', 'Licencia de Extranjería', 'OPERATIVA', 'Oficina de Extranjería', DATE '2023-06-01', DATE '2024-05-31', DATE '2024-05-01', 'Contratación de personal extranjero', 'Cuota anual', 3, 0, 1, NULL);

-- Tabla 26.4: cumplimiento_normativo (se omite id_cumplimiento_normativo)
INSERT INTO cumplimiento_normativo (id_normativa, fecha_verificacion, periodo_verificado, responsable_verificacion, cumplimiento_porcentaje, hallazgos, acciones_correctivas, fecha_cierre_acciones, calificacion, proxima_verificacion, verificacion_completada) VALUES
(1, DATE '2024-03-01', 'ANUAL', 3, 98.5, 'Alguna documentación desactualizada', 'Actualizar licencias', DATE '2024-03-15', 'EXCELENTE', DATE '2025-03-01', 1);
INSERT INTO cumplimiento_normativo (id_normativa, fecha_verificacion, periodo_verificado, responsable_verificacion, cumplimiento_porcentaje, hallazgos, acciones_correctivas, fecha_cierre_acciones, calificacion, proxima_verificacion, verificacion_completada) VALUES
(2, DATE '2024-02-15', 'SEMESTRAL', 2, 95.0, 'Registros de mantenimiento incompletos', 'Digitalizar registros', DATE '2024-03-10', 'ACEPTABLE', DATE '2024-08-15', 1);
INSERT INTO cumplimiento_normativo (id_normativa, fecha_verificacion, periodo_verificado, responsable_verificacion, cumplimiento_porcentaje, hallazgos, acciones_correctivas, fecha_cierre_acciones, calificacion, proxima_verificacion, verificacion_completada) VALUES
(3, DATE '2024-01-20', 'TRIMESTRAL', 1, 100.0, NULL, NULL, NULL, 'EXCELENTE', DATE '2024-04-20', 1);
INSERT INTO cumplimiento_normativo (id_normativa, fecha_verificacion, periodo_verificado, responsable_verificacion, cumplimiento_porcentaje, hallazgos, acciones_correctivas, fecha_cierre_acciones, calificacion, proxima_verificacion, verificacion_completada) VALUES
(5, DATE '2024-03-10', 'ANUAL', 8, 88.5, 'Faltan consentimientos informados', 'Actualizar formularios', DATE '2024-04-10', 'OBSERVADO', DATE '2025-03-10', 0);
INSERT INTO cumplimiento_normativo (id_normativa, fecha_verificacion, periodo_verificado, responsable_verificacion, cumplimiento_porcentaje, hallazgos, acciones_correctivas, fecha_cierre_acciones, calificacion, proxima_verificacion, verificacion_completada) VALUES
(6, DATE '2024-02-28', 'SEMESTRAL', 12, 96.0, 'Etiquetado incorrecto en un envío', 'Reentrenar personal', DATE '2024-03-20', 'ACEPTABLE', DATE '2024-08-28', 1);

-- Tabla 26.5: contratos (se omite id_contrato)
INSERT INTO contratos (numero_contrato, nombre_contrato, tipo_contrato, contraparte_nombre, contraparte_documento, fecha_firma, fecha_inicio, fecha_fin, monto_total, moneda, forma_pago, objeto_contractual, renovacion_automatica, notificar_vencimiento_dias, estado, administrador_contrato, observaciones) VALUES
('CON-001-2024', 'Concesión Zara', 'CONCESION', 'Inditex', 'A12345678', DATE '2023-12-15', DATE '2024-01-01', DATE '2028-12-31', 900000.00, 'EUR', 'Mensual', 'Explotación local comercial T4', 1, 60, 'VIGENTE', 6, NULL);
INSERT INTO contratos (numero_contrato, nombre_contrato, tipo_contrato, contraparte_nombre, contraparte_documento, fecha_firma, fecha_inicio, fecha_fin, monto_total, moneda, forma_pago, objeto_contractual, renovacion_automatica, notificar_vencimiento_dias, estado, administrador_contrato, observaciones) VALUES
('CON-002-2024', 'Suministro combustible Repsol', 'SUMINISTRO', 'Repsol', 'A28123456', DATE '2023-11-20', DATE '2024-01-01', DATE '2024-12-31', 15000000.00, 'EUR', 'Mensual', 'Suministro de combustible JET A1', 0, 30, 'VIGENTE', 2, NULL);
INSERT INTO contratos (numero_contrato, nombre_contrato, tipo_contrato, contraparte_nombre, contraparte_documento, fecha_firma, fecha_inicio, fecha_fin, monto_total, moneda, forma_pago, objeto_contractual, renovacion_automatica, notificar_vencimiento_dias, estado, administrador_contrato, observaciones) VALUES
('CON-003-2023', 'Limpieza terminales', 'SERVICIOS', 'FCC', 'D55667788', DATE '2023-09-10', DATE '2023-10-01', DATE '2024-09-30', 216000.00, 'EUR', 'Mensual', 'Servicios de limpieza', 1, 45, 'VIGENTE', 1, NULL);
INSERT INTO contratos (numero_contrato, nombre_contrato, tipo_contrato, contraparte_nombre, contraparte_documento, fecha_firma, fecha_inicio, fecha_fin, monto_total, moneda, forma_pago, objeto_contractual, renovacion_automatica, notificar_vencimiento_dias, estado, administrador_contrato, observaciones) VALUES
('CON-004-2024', 'Arrendamiento oficinas', 'ARRENDAMIENTO', 'Inversiones Aeropuerto', 'B99887766', DATE '2023-12-01', DATE '2024-01-01', DATE '2026-12-31', 360000.00, 'EUR', 'Mensual', 'Alquiler oficinas administrativas', 1, 90, 'VIGENTE', 4, NULL);
INSERT INTO contratos (numero_contrato, nombre_contrato, tipo_contrato, contraparte_nombre, contraparte_documento, fecha_firma, fecha_inicio, fecha_fin, monto_total, moneda, forma_pago, objeto_contractual, renovacion_automatica, notificar_vencimiento_dias, estado, administrador_contrato, observaciones) VALUES
('CON-005-2023', 'Contrato Seguridad', 'SERVICIOS', 'Prosegur', 'E99001122', DATE '2023-08-15', DATE '2023-09-01', DATE '2024-08-31', 600000.00, 'EUR', 'Mensual', 'Servicios de seguridad', 1, 60, 'VIGENTE', 5, NULL);
INSERT INTO contratos (numero_contrato, nombre_contrato, tipo_contrato, contraparte_nombre, contraparte_documento, fecha_firma, fecha_inicio, fecha_fin, monto_total, moneda, forma_pago, objeto_contractual, renovacion_automatica, notificar_vencimiento_dias, estado, administrador_contrato, observaciones) VALUES
('CON-006-2022', 'Mantenimiento pistas', 'SERVICIOS', 'Ferrovial', 'C11223344', DATE '2022-12-20', DATE '2023-01-01', DATE '2024-12-31', 1200000.00, 'EUR', 'Trimestral', 'Mantenimiento de infraestructura', 0, 60, 'VIGENTE', 2, NULL);
INSERT INTO contratos (numero_contrato, nombre_contrato, tipo_contrato, contraparte_nombre, contraparte_documento, fecha_firma, fecha_inicio, fecha_fin, monto_total, moneda, forma_pago, objeto_contractual, renovacion_automatica, notificar_vencimiento_dias, estado, administrador_contrato, observaciones) VALUES
('LAB-001-2023', 'Contrato Gerente', 'LABORAL', 'Juan González', '12345678A', DATE '2023-05-01', DATE '2023-06-01', DATE '2024-05-31', 60000.00, 'EUR', 'Mensual', 'Contrato de trabajo', 0, 30, 'VIGENTE', 3, NULL);
INSERT INTO contratos (numero_contrato, nombre_contrato, tipo_contrato, contraparte_nombre, contraparte_documento, fecha_firma, fecha_inicio, fecha_fin, monto_total, moneda, forma_pago, objeto_contractual, renovacion_automatica, notificar_vencimiento_dias, estado, administrador_contrato, observaciones) VALUES
('CON-007-2024', 'Publicidad', 'SERVICIOS', 'Havas Media', 'F33445566', DATE '2024-01-15', DATE '2024-02-01', DATE '2024-07-31', 180000.00, 'EUR', 'Mensual', 'Gestión de publicidad', 0, 30, 'VIGENTE', 6, NULL);

-- Tabla 26.6: clausulas_contrato (se omite id_clausula_contrato)
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(1, 1, 'Objeto', 'El concesionario explotará el local comercial L-101 en T4', 'OBLIGACION', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(1, 2, 'Canon', 'El canon mensual será de 15.000€, actualizable anualmente según IPC', 'OBLIGACION', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(1, 3, 'Horario', 'El local deberá permanecer abierto de 08:00 a 22:00 todos los días', 'OBLIGACION', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(1, 4, 'Penalizaciones', 'El incumplimiento de horario conllevará penalización de 500€/día', 'PENALIZACION', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(2, 1, 'Precio', 'El precio del combustible será de 2,85€/litro más impuestos', 'OBLIGACION', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(2, 2, 'Volumen mínimo', 'El aeropuerto se compromete a un consumo mínimo anual de 10 millones de litros', 'OBLIGACION', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(2, 3, 'Confidencialidad', 'Las partes se obligan a mantener la confidencialidad de los términos', 'CONFIDENCIALIDAD', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(7, 1, 'Jornada', 'La jornada laboral será de 40 horas semanales', 'OBLIGACION', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(7, 2, 'Vacaciones', 'El trabajador tendrá derecho a 22 días hábiles de vacaciones anuales', 'DERECHO', 1);
INSERT INTO clausulas_contrato (id_contrato, numero_clausula, titulo_clausula, texto_clausula, tipo_clausula, vigente) VALUES
(3, 1, 'Garantía', 'Se establece una garantía de 50.000€ para el cumplimiento del contrato', 'GARANTIA', 1);

-- Tabla 26.7: notificaciones_legales (se omite id_notificacion_legal)
INSERT INTO notificaciones_legales (numero_notificacion, remitente_nombre, remitente_tipo, destinatario_interno, asunto, descripcion, fecha_recepcion, fecha_respuesta_requerida, prioridad, area_responsable, usuario_asignado, estado, fecha_respuesta, respuesta) VALUES
('NOT-LEG-001', 'Agencia Tributaria', 'ENTIDAD_GUBERNAMENTAL', 4, 'Requerimiento de información fiscal', 'Solicitud de documentación sobre tasas aeroportuarias', TO_TIMESTAMP('2024-03-15 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-15', 'MEDIA', 4, 4, 'EN_PROCESO', NULL, NULL);
INSERT INTO notificaciones_legales (numero_notificacion, remitente_nombre, remitente_tipo, destinatario_interno, asunto, descripcion, fecha_recepcion, fecha_respuesta_requerida, prioridad, area_responsable, usuario_asignado, estado, fecha_respuesta, respuesta) VALUES
('NOT-LEG-002', 'Inspección de Trabajo', 'ENTIDAD_GUBERNAMENTAL', 3, 'Inspección laboral', 'Revisión de contratos y condiciones laborales', TO_TIMESTAMP('2024-03-10 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-10', 'ALTA', 3, 3, 'EN_PROCESO', NULL, NULL);
INSERT INTO notificaciones_legales (numero_notificacion, remitente_nombre, remitente_tipo, destinatario_interno, asunto, descripcion, fecha_recepcion, fecha_respuesta_requerida, prioridad, area_responsable, usuario_asignado, estado, fecha_respuesta, respuesta) VALUES
('NOT-LEG-003', 'Iberia', 'AEROLINEA', 2, 'Reclamación por retraso', 'Reclamación de daños por cancelación vuelo DL789', TO_TIMESTAMP('2024-03-20 14:15:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-20', 'BAJA', 9, 9, 'RECIBIDO', NULL, NULL);
INSERT INTO notificaciones_legales (numero_notificacion, remitente_nombre, remitente_tipo, destinatario_interno, asunto, descripcion, fecha_recepcion, fecha_respuesta_requerida, prioridad, area_responsable, usuario_asignado, estado, fecha_respuesta, respuesta) VALUES
('NOT-LEG-004', 'Juan Pérez', 'PASAJERO', 7, 'Reclamación equipaje', 'Maleta perdida en vuelo IB1234', TO_TIMESTAMP('2024-03-18 16:45:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-18', 'MEDIA', 7, 7, 'RESPONDIDO', TO_TIMESTAMP('2024-03-25 10:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Se ha iniciado la búsqueda de la maleta');
INSERT INTO notificaciones_legales (numero_notificacion, remitente_nombre, remitente_tipo, destinatario_interno, asunto, descripcion, fecha_recepcion, fecha_respuesta_requerida, prioridad, area_responsable, usuario_asignado, estado, fecha_respuesta, respuesta) VALUES
('NOT-LEG-005', 'Proveedores SA', 'PROVEEDOR', 2, 'Reclamación de pago', 'Factura pendiente desde enero', TO_TIMESTAMP('2024-03-05 09:20:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-04-05', 'URGENTE', 4, 4, 'RESPONDIDO', TO_TIMESTAMP('2024-03-07 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'El pago se ha procesado');

-- Tabla 26.8: documentos_importantes (se omite id_documento_importante)
INSERT INTO documentos_importantes (codigo_documento, titulo, tipo_documento, fecha_creacion, fecha_revision, version, autor, area_responsable, palabras_clave, resumen, ubicacion_fisica, confidencial, niveles_acceso, activo) VALUES
('DOC-PLN-001', 'Plan Estratégico 2024-2026', 'PLANO', DATE '2023-12-10', DATE '2024-01-15', '1.2', 'Dirección', 1, 'estrategia, objetivos, crecimiento', 'Plan a 3 años para el desarrollo del aeropuerto', 'Archivo Dirección', 1, 'Dirección', 1);
INSERT INTO documentos_importantes (codigo_documento, titulo, tipo_documento, fecha_creacion, fecha_revision, version, autor, area_responsable, palabras_clave, resumen, ubicacion_fisica, confidencial, niveles_acceso, activo) VALUES
('DOC-MAN-001', 'Manual de Operaciones', 'MANUAL', DATE '2023-06-01', DATE '2024-02-20', '3.0', 'Operaciones', 1, 'procedimientos, seguridad, operaciones', 'Manual detallado de procedimientos operativos', 'Intranet', 0, 'Todo el personal', 1);
INSERT INTO documentos_importantes (codigo_documento, titulo, tipo_documento, fecha_creacion, fecha_revision, version, autor, area_responsable, palabras_clave, resumen, ubicacion_fisica, confidencial, niveles_acceso, activo) VALUES
('DOC-POL-001', 'Política de Calidad', 'POLITICA', DATE '2023-09-15', DATE '2024-03-01', '2.1', 'Calidad', 10, 'calidad, iso, mejora', 'Política de calidad del aeropuerto', 'Intranet', 0, 'Todo el personal', 1);
INSERT INTO documentos_importantes (codigo_documento, titulo, tipo_documento, fecha_creacion, fecha_revision, version, autor, area_responsable, palabras_clave, resumen, ubicacion_fisica, confidencial, niveles_acceso, activo) VALUES
('DOC-INF-001', 'Informe Anual 2023', 'INFORME', DATE '2024-01-20', NULL, '1.0', 'Finanzas', 4, 'memoria, cuentas, resultados', 'Informe de gestión y cuentas anuales', 'Web corporativa', 0, 'Público', 1);
INSERT INTO documentos_importantes (codigo_documento, titulo, tipo_documento, fecha_creacion, fecha_revision, version, autor, area_responsable, palabras_clave, resumen, ubicacion_fisica, confidencial, niveles_acceso, activo) VALUES
('DOC-EST-001', 'Estudio de Impacto Ambiental', 'ESTUDIO', DATE '2022-11-30', DATE '2023-11-30', '2.0', 'Medio Ambiente', 2, 'impacto, ambiental, sostenibilidad', 'Evaluación de impacto ambiental', 'Archivo Técnico', 0, 'Técnicos', 1);
INSERT INTO documentos_importantes (codigo_documento, titulo, tipo_documento, fecha_creacion, fecha_revision, version, autor, area_responsable, palabras_clave, resumen, ubicacion_fisica, confidencial, niveles_acceso, activo) VALUES
('DOC-PLA-001', 'Planos Terminal T4', 'PLANO', DATE '2023-04-05', DATE '2024-02-10', '1.5', 'Ingeniería', 2, 'arquitectura, planos, terminal', 'Planos actualizados de la terminal', 'Archivo Ingeniería', 1, 'Ingeniería, Operaciones', 1);
INSERT INTO documentos_importantes (codigo_documento, titulo, tipo_documento, fecha_creacion, fecha_revision, version, autor, area_responsable, palabras_clave, resumen, ubicacion_fisica, confidencial, niveles_acceso, activo) VALUES
('DOC-PRO-001', 'Procedimiento de Emergencia', 'PROCEDIMIENTO', DATE '2023-12-01', DATE '2024-02-28', '3.2', 'Seguridad', 5, 'emergencia, evacuación, protocolo', 'Procedimientos ante emergencias', 'Todos los departamentos', 0, 'Todo el personal', 1);
INSERT INTO documentos_importantes (codigo_documento, titulo, tipo_documento, fecha_creacion, fecha_revision, version, autor, area_responsable, palabras_clave, resumen, ubicacion_fisica, confidencial, niveles_acceso, activo) VALUES
('DOC-ACT-001', 'Acta Reunión Comité', 'ACTA', DATE '2024-03-01', NULL, '1.0', 'Secretaría', 1, 'reunión, acuerdos', 'Acta de la reunión del comité de dirección', 'Archivo', 1, 'Dirección', 1);

-- Tabla 26.9: revisiones_documentos (se omite id_revision_documento)
INSERT INTO revisiones_documentos (id_documento_importante, numero_revision, fecha_revision, revisor, cambios_realizados, version_resultante, aprobado, aprobado_por, fecha_aprobacion, observaciones) VALUES
(1, 1, DATE '2024-01-10', 1, 'Actualización de objetivos 2024', '1.1', 1, 1, DATE '2024-01-12', NULL);
INSERT INTO revisiones_documentos (id_documento_importante, numero_revision, fecha_revision, revisor, cambios_realizados, version_resultante, aprobado, aprobado_por, fecha_aprobacion, observaciones) VALUES
(1, 2, DATE '2024-01-15', 1, 'Inclusión de anexos financieros', '1.2', 1, 1, DATE '2024-01-16', NULL);
INSERT INTO revisiones_documentos (id_documento_importante, numero_revision, fecha_revision, revisor, cambios_realizados, version_resultante, aprobado, aprobado_por, fecha_aprobacion, observaciones) VALUES
(2, 1, DATE '2023-12-10', 2, 'Actualización procedimientos seguridad', '2.8', 1, 1, DATE '2023-12-12', NULL);
INSERT INTO revisiones_documentos (id_documento_importante, numero_revision, fecha_revision, revisor, cambios_realizados, version_resultante, aprobado, aprobado_por, fecha_aprobacion, observaciones) VALUES
(2, 2, DATE '2024-02-20', 2, 'Nuevos protocolos COVID', '3.0', 1, 1, DATE '2024-02-22', NULL);
INSERT INTO revisiones_documentos (id_documento_importante, numero_revision, fecha_revision, revisor, cambios_realizados, version_resultante, aprobado, aprobado_por, fecha_aprobacion, observaciones) VALUES
(3, 1, DATE '2024-02-25', 10, 'Actualización ISO', '2.1', 1, 1, DATE '2024-02-28', NULL);
INSERT INTO revisiones_documentos (id_documento_importante, numero_revision, fecha_revision, revisor, cambios_realizados, version_resultante, aprobado, aprobado_por, fecha_aprobacion, observaciones) VALUES
(5, 1, DATE '2023-11-20', 2, 'Nuevos datos de monitoreo', '2.0', 1, 1, DATE '2023-11-25', NULL);

-- Tabla 26.10: auditorias_internas (se omite id_auditoria_interna)
INSERT INTO auditorias_internas (codigo_auditoria, titulo, tipo_auditoria, alcance, fecha_inicio_planeacion, fecha_fin_planeacion, fecha_inicio_ejecucion, fecha_fin_ejecucion, fecha_informe, auditor_lider, equipo_auditor, areas_auditadas, hallazgos, no_conformidades, oportunidades_mejora, conclusiones, estado) VALUES
('AUD-INT-001', 'Auditoría Procesos Operativos', 'PROCESOS', 'Revisión de procesos de embarque y atención al pasajero', DATE '2024-02-01', DATE '2024-02-15', DATE '2024-02-20', DATE '2024-02-28', DATE '2024-03-05', 2, 'Ana Gómez, Carlos Ruiz', 'Operaciones, Atención Cliente', 'Tiempos de embarque superiores a estándar', 'No conformidad en procedimiento de check-in', 'Implementar sistema de autoembarque', 'Se requiere mejorar eficiencia', 'COMPLETADA');
INSERT INTO auditorias_internas (codigo_auditoria, titulo, tipo_auditoria, alcance, fecha_inicio_planeacion, fecha_fin_planeacion, fecha_inicio_ejecucion, fecha_fin_ejecucion, fecha_informe, auditor_lider, equipo_auditor, areas_auditadas, hallazgos, no_conformidades, oportunidades_mejora, conclusiones, estado) VALUES
('AUD-INT-002', 'Auditoría Financiera', 'FINANCIERA', 'Revisión de gastos e ingresos Q1', DATE '2024-03-01', DATE '2024-03-10', DATE '2024-03-15', DATE '2024-03-25', NULL, 4, 'Laura Pérez', 'Finanzas', 'Discrepancias en conciliaciones', NULL, 'Automatizar conciliaciones', NULL, 'EN_EJECUCION');
INSERT INTO auditorias_internas (codigo_auditoria, titulo, tipo_auditoria, alcance, fecha_inicio_planeacion, fecha_fin_planeacion, fecha_inicio_ejecucion, fecha_fin_ejecucion, fecha_informe, auditor_lider, equipo_auditor, areas_auditadas, hallazgos, no_conformidades, oportunidades_mejora, conclusiones, estado) VALUES
('AUD-INT-003', 'Auditoría Seguridad', 'SEGURIDAD', 'Revisión de controles de acceso', DATE '2024-01-10', DATE '2024-01-20', DATE '2024-01-25', DATE '2024-02-05', DATE '2024-02-10', 5, 'Juan López', 'Seguridad', 'Accesos no autorizados detectados', '3 no conformidades', 'Mejorar sistema de autenticación', 'Implementar medidas correctivas', 'COMPLETADA');
INSERT INTO auditorias_internas (codigo_auditoria, titulo, tipo_auditoria, alcance, fecha_inicio_planeacion, fecha_fin_planeacion, fecha_inicio_ejecucion, fecha_fin_ejecucion, fecha_informe, auditor_lider, equipo_auditor, areas_auditadas, hallazgos, no_conformidades, oportunidades_mejora, conclusiones, estado) VALUES
('AUD-INT-004', 'Auditoría Calidad', 'CALIDAD', 'Revisión sistema de gestión de calidad', DATE '2024-03-05', DATE '2024-03-15', DATE '2024-03-20', NULL, NULL, 10, 'Marta Sánchez', 'Calidad', NULL, NULL, NULL, NULL, 'PLANEADA');

COMMIT;
SELECT 'Módulo 26 completado' AS estado FROM dual;

-- =====================================================
-- MÓDULO 27: TRANSPORTE TERRESTRE AMPLIADO (10 TABLAS)
-- =====================================================

-- Tabla 27.1: rutas_transporte_terrestre (se omite id_ruta_transporte)
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-MAD-001', 'Aeropuerto - Centro', 'MAD', 'Puerta del Sol', 15.5, 30, 'AEROPUERTO_CENTRO', 'Cada 15 min', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-MAD-002', 'Aeropuerto - Atocha', 'MAD', 'Estación Atocha', 14.0, 25, 'AEROPUERTO_CENTRO', 'Cada 20 min', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-MAD-003', 'Aeropuerto - Ifema', 'MAD', 'Ifema', 5.0, 10, 'URBANA', 'Cada 30 min', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-BOG-001', 'Aeropuerto - Centro', 'BOG', 'Calle 26', 13.0, 35, 'AEROPUERTO_CENTRO', 'Cada 20 min', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-BOG-002', 'Aeropuerto - Zona Rosa', 'BOG', 'Zona Rosa', 18.0, 45, 'AEROPUERTO_CENTRO', 'Cada 30 min', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-JFK-001', 'JFK - Manhattan', 'JFK', 'Times Square', 25.0, 60, 'AEROPUERTO_CENTRO', 'Cada 15 min', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-JFK-002', 'JFK - Brooklyn', 'JFK', 'Brooklyn Bridge', 20.0, 50, 'URBANA', 'Cada 25 min', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-MAD-004', 'Aeropuerto - Hoteles', 'MAD', 'Hotel Barajas', 2.5, 5, 'AEROPUERTO_HOTEL', 'Bajo demanda', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-BOG-003', 'Aeropuerto - Hoteles', 'BOG', 'Hotel Habitel', 1.0, 3, 'AEROPUERTO_HOTEL', 'Bajo demanda', 1);
INSERT INTO rutas_transporte_terrestre (codigo_ruta, nombre_ruta, origen, destino, distancia_km, duracion_estimada_minutos, tipo_ruta, frecuencia_servicio, activa) VALUES
('R-MAD-005', 'Madrid - Barcelona', 'MAD', 'BCN', 620.0, 420, 'INTERURBANA', 'Diario', 1);

-- Tabla 27.2: vehiculos_transporte (se omite id_vehiculo_transporte)
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('MAD-1234', 'BUS', 'Mercedes', 'Citaro', 2022, 60, 30, 1, 1, 1, 'EMT Madrid', 'EMT', DATE '2024-03-01', DATE '2024-04-01', 1, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('MAD-5678', 'BUS', 'Volvo', '7900', 2023, 55, 28, 1, 1, 1, 'EMT Madrid', 'EMT', DATE '2024-03-05', DATE '2024-04-05', 1, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('MAD-9012', 'TAXI', 'Toyota', 'Prius', 2023, 4, 3, 1, 0, 0, 'Radio Taxi', 'Radio Taxi', DATE '2024-03-10', DATE '2024-04-10', 1, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('MAD-3456', 'VAN', 'Ford', 'Transit', 2022, 8, 8, 1, 1, 1, 'Shuttle Madrid', 'Shuttle Madrid', DATE '2024-02-20', DATE '2024-03-20', 1, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('BOG-123', 'BUS', 'Scania', 'K310', 2023, 50, 25, 1, 0, 1, 'TransMilenio', 'TransMilenio', DATE '2024-03-02', DATE '2024-04-02', 1, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('BOG-456', 'TAXI', 'Chevrolet', 'Spark', 2022, 4, 2, 1, 0, 0, 'Taxi Bogotá', 'Taxi Bogotá', DATE '2024-03-08', DATE '2024-04-08', 1, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('NYC-100', 'TAXI', 'Ford', 'Crown Victoria', 2020, 4, 3, 1, 0, 0, 'NYC Taxi', 'NYC Taxi', DATE '2024-03-03', DATE '2024-04-03', 1, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('NYC-200', 'BUS', 'MCI', 'D4500', 2021, 55, 30, 1, 1, 1, 'MTA', 'MTA', DATE '2024-03-12', DATE '2024-04-12', 0, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('MAD-7890', 'MOTOCICLETA', 'Honda', 'PCX', 2023, 1, 1, 0, 0, 0, 'Mensajero', 'Express', DATE '2024-03-15', DATE '2024-04-15', 1, 1);
INSERT INTO vehiculos_transporte (placa, tipo_vehiculo, marca, modelo, anio, capacidad_pasajeros, capacidad_maletas, tiene_aire_acondicionado, tiene_wifi, tiene_accesibilidad, propietario, empresa_operadora, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, disponible, activo) VALUES
('MAD-1122', 'AUTO', 'Tesla', 'Model 3', 2024, 4, 2, 1, 1, 0, 'Renta Auto', 'Tesla Rent', DATE '2024-03-01', DATE '2024-04-01', 1, 1);

-- Tabla 27.3: choferes_transporte (se omite id_chofer_transporte)
INSERT INTO choferes_transporte (nombres, apellidos, tipo_documento, numero_documento, licencia_conducir, categoria_licencia, fecha_vencimiento_licencia, telefono, email, fecha_contratacion, empresa_contratante, certificaciones, idiomas, disponible, activo) VALUES
('Carlos', 'García López', 'DNI', '12345678A', 'LIC-001', 'D', DATE '2025-06-01', '+34611223344', 'carlos.garcia@emt.es', DATE '2022-01-15', 'EMT Madrid', 'Curso de conducción eficiente', 'Español', 1, 1);
INSERT INTO choferes_transporte (nombres, apellidos, tipo_documento, numero_documento, licencia_conducir, categoria_licencia, fecha_vencimiento_licencia, telefono, email, fecha_contratacion, empresa_contratante, certificaciones, idiomas, disponible, activo) VALUES
('María', 'Rodríguez Pérez', 'DNI', '87654321B', 'LIC-002', 'D', DATE '2025-09-15', '+34622334455', 'maria.rodriguez@emt.es', DATE '2021-11-20', 'EMT Madrid', 'Transporte de pasajeros', 'Español, Inglés básico', 1, 1);
INSERT INTO choferes_transporte (nombres, apellidos, tipo_documento, numero_documento, licencia_conducir, categoria_licencia, fecha_vencimiento_licencia, telefono, email, fecha_contratacion, empresa_contratante, certificaciones, idiomas, disponible, activo) VALUES
('Juan', 'Martínez Silva', 'CC', '1012345678', 'LIC-003', 'C1', DATE '2024-12-10', '+573001234567', 'juan.martinez@taxi.co', DATE '2023-02-01', 'Taxi Bogotá', NULL, 'Español', 1, 1);
INSERT INTO choferes_transporte (nombres, apellidos, tipo_documento, numero_documento, licencia_conducir, categoria_licencia, fecha_vencimiento_licencia, telefono, email, fecha_contratacion, empresa_contratante, certificaciones, idiomas, disponible, activo) VALUES
('John', 'Smith', 'PASSPORT', 'USA123456', 'LIC-004', 'E', DATE '2025-03-20', '+12125551234', 'john.smith@nyctaxi.com', DATE '2020-05-10', 'NYC Taxi', 'Defensive driving', 'Inglés', 1, 1);
INSERT INTO choferes_transporte (nombres, apellidos, tipo_documento, numero_documento, licencia_conducir, categoria_licencia, fecha_vencimiento_licencia, telefono, email, fecha_contratacion, empresa_contratante, certificaciones, idiomas, disponible, activo) VALUES
('Ana', 'Gómez Castro', 'CC', '1023456789', 'LIC-005', 'C1', DATE '2025-07-05', '+573002345678', 'ana.gomez@transmilenio.co', DATE '2022-08-15', 'TransMilenio', 'Primeros auxilios', 'Español', 0, 1);
INSERT INTO choferes_transporte (nombres, apellidos, tipo_documento, numero_documento, licencia_conducir, categoria_licencia, fecha_vencimiento_licencia, telefono, email, fecha_contratacion, empresa_contratante, certificaciones, idiomas, disponible, activo) VALUES
('Pierre', 'Dubois', 'PASSPORT', 'FRA456789', 'LIC-006', 'D', DATE '2025-11-30', '+33123456789', 'pierre.dubois@shuttle.fr', DATE '2023-01-10', 'Shuttle Paris', 'Transporte ejecutivo', 'Francés, Inglés', 1, 1);

-- Tabla 27.4: asignacion_vehiculos_rutas (se omite id_asignacion_vehiculo_ruta)
INSERT INTO asignacion_vehiculos_rutas (id_vehiculo_transporte, id_ruta_transporte, fecha_asignacion, fecha_inicio_vigencia, fecha_fin_vigencia, horario_servicio, activa) VALUES
(1, 1, DATE '2024-03-01', DATE '2024-03-01', DATE '2024-03-31', '06:00-22:00', 1);
INSERT INTO asignacion_vehiculos_rutas (id_vehiculo_transporte, id_ruta_transporte, fecha_asignacion, fecha_inicio_vigencia, fecha_fin_vigencia, horario_servicio, activa) VALUES
(2, 2, DATE '2024-03-01', DATE '2024-03-01', DATE '2024-03-31', '07:00-23:00', 1);
INSERT INTO asignacion_vehiculos_rutas (id_vehiculo_transporte, id_ruta_transporte, fecha_asignacion, fecha_inicio_vigencia, fecha_fin_vigencia, horario_servicio, activa) VALUES
(3, 8, DATE '2024-03-01', DATE '2024-03-01', NULL, '24h', 1);
INSERT INTO asignacion_vehiculos_rutas (id_vehiculo_transporte, id_ruta_transporte, fecha_asignacion, fecha_inicio_vigencia, fecha_fin_vigencia, horario_servicio, activa) VALUES
(5, 4, DATE '2024-03-01', DATE '2024-03-01', DATE '2024-03-31', '05:00-22:00', 1);
INSERT INTO asignacion_vehiculos_rutas (id_vehiculo_transporte, id_ruta_transporte, fecha_asignacion, fecha_inicio_vigencia, fecha_fin_vigencia, horario_servicio, activa) VALUES
(6, 9, DATE '2024-03-01', DATE '2024-03-01', NULL, '24h', 1);
INSERT INTO asignacion_vehiculos_rutas (id_vehiculo_transporte, id_ruta_transporte, fecha_asignacion, fecha_inicio_vigencia, fecha_fin_vigencia, horario_servicio, activa) VALUES
(7, 6, DATE '2024-03-01', DATE '2024-03-01', NULL, '24h', 1);
INSERT INTO asignacion_vehiculos_rutas (id_vehiculo_transporte, id_ruta_transporte, fecha_asignacion, fecha_inicio_vigencia, fecha_fin_vigencia, horario_servicio, activa) VALUES
(10, 8, DATE '2024-03-01', DATE '2024-03-01', NULL, '08:00-20:00', 1);

-- Tabla 27.5: reservas_transporte_terrestre (se omite id_reserva_transporte)
INSERT INTO reservas_transporte_terrestre (codigo_reserva_transporte, id_pasajero, id_ruta_transporte, tipo_servicio, fecha_reserva, fecha_servicio, hora_recogida, lugar_recogida, lugar_destino, numero_pasajeros, cantidad_maletas, id_vuelo_asociado, instrucciones_especiales, estado_reserva, precio_total, moneda, pagado) VALUES
('TRANS-001', 1, 8, 'PRIVADO', TO_TIMESTAMP('2024-03-17 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Hotel Barajas', 'Terminal T4', 1, 2, 1, 'Esperar en llegadas', 'COMPLETADA', 25.00, 'EUR', 1);
INSERT INTO reservas_transporte_terrestre (codigo_reserva_transporte, id_pasajero, id_ruta_transporte, tipo_servicio, fecha_reserva, fecha_servicio, hora_recogida, lugar_recogida, lugar_destino, numero_pasajeros, cantidad_maletas, id_vuelo_asociado, instrucciones_especiales, estado_reserva, precio_total, moneda, pagado) VALUES
('TRANS-002', 3, 8, 'PRIVADO', TO_TIMESTAMP('2024-03-17 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'NH Barajas', 'Terminal T4', 2, 3, 1, NULL, 'COMPLETADA', 35.00, 'EUR', 1);
INSERT INTO reservas_transporte_terrestre (codigo_reserva_transporte, id_pasajero, id_ruta_transporte, tipo_servicio, fecha_reserva, fecha_servicio, hora_recogida, lugar_recogida, lugar_destino, numero_pasajeros, cantidad_maletas, id_vuelo_asociado, instrucciones_especiales, estado_reserva, precio_total, moneda, pagado) VALUES
('TRANS-003', 5, 6, 'COMPARTIDO', TO_TIMESTAMP('2024-03-16 15:20:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 05:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Hilton JFK', 'JFK Terminal 1', 1, 1, 3, NULL, 'COMPLETADA', 45.00, 'USD', 1);
INSERT INTO reservas_transporte_terrestre (codigo_reserva_transporte, id_pasajero, id_ruta_transporte, tipo_servicio, fecha_reserva, fecha_servicio, hora_recogida, lugar_recogida, lugar_destino, numero_pasajeros, cantidad_maletas, id_vuelo_asociado, instrucciones_especiales, estado_reserva, precio_total, moneda, pagado) VALUES
('TRANS-004', 9, 9, 'PRIVADO', TO_TIMESTAMP('2024-03-17 18:45:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 18:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Hotel Habitel', 'BOG Terminal 1', 1, 2, 5, 'Silla de ruedas', 'ASIGNADA', 20.00, 'USD', 1);
INSERT INTO reservas_transporte_terrestre (codigo_reserva_transporte, id_pasajero, id_ruta_transporte, tipo_servicio, fecha_reserva, fecha_servicio, hora_recogida, lugar_recogida, lugar_destino, numero_pasajeros, cantidad_maletas, id_vuelo_asociado, instrucciones_especiales, estado_reserva, precio_total, moneda, pagado) VALUES
('TRANS-005', 10, 8, 'PRIVADO', TO_TIMESTAMP('2024-03-19 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-20', TO_TIMESTAMP('2024-03-20 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Hotel Barajas', 'Terminal T4', 2, 3, 10, 'Viajan con mascota', 'CONFIRMADA', 30.00, 'EUR', 0);
INSERT INTO reservas_transporte_terrestre (codigo_reserva_transporte, id_pasajero, id_ruta_transporte, tipo_servicio, fecha_reserva, fecha_servicio, hora_recogida, lugar_recogida, lugar_destino, numero_pasajeros, cantidad_maletas, id_vuelo_asociado, instrucciones_especiales, estado_reserva, precio_total, moneda, pagado) VALUES
('TRANS-006', 2, 8, 'PRIVADO', TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), DATE '2024-03-18', TO_TIMESTAMP('2024-03-18 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Terminal T4', 'Hotel Barajas', 1, 2, 2, NULL, 'COMPLETADA', 25.00, 'EUR', 1);

-- Tabla 27.6: asignacion_servicios_transporte (se omite id_asignacion_servicio)
INSERT INTO asignacion_servicios_transporte (id_reserva_transporte, id_vehiculo_transporte, id_chofer_transporte, fecha_asignacion, asignado_por, hora_llegada_vehiculo, hora_inicio_servicio, hora_fin_servicio, kilometraje_inicio, kilometraje_fin, incidencias, calificacion_pasajero, comentarios_pasajero) VALUES
(1, 3, 3, TO_TIMESTAMP('2024-03-18 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), 1, TO_TIMESTAMP('2024-03-18 09:55:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 10:20:00', 'YYYY-MM-DD HH24:MI:SS'), 12500, 12520, NULL, 5, 'Muy puntual');
INSERT INTO asignacion_servicios_transporte (id_reserva_transporte, id_vehiculo_transporte, id_chofer_transporte, fecha_asignacion, asignado_por, hora_llegada_vehiculo, hora_inicio_servicio, hora_fin_servicio, kilometraje_inicio, kilometraje_fin, incidencias, calificacion_pasajero, comentarios_pasajero) VALUES
(2, 3, 3, TO_TIMESTAMP('2024-03-18 07:30:00', 'YYYY-MM-DD HH24:MI:SS'), 1, TO_TIMESTAMP('2024-03-18 07:55:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 08:25:00', 'YYYY-MM-DD HH24:MI:SS'), 12520, 12545, NULL, 4, 'Bien');
INSERT INTO asignacion_servicios_transporte (id_reserva_transporte, id_vehiculo_transporte, id_chofer_transporte, fecha_asignacion, asignado_por, hora_llegada_vehiculo, hora_inicio_servicio, hora_fin_servicio, kilometraje_inicio, kilometraje_fin, incidencias, calificacion_pasajero, comentarios_pasajero) VALUES
(3, 7, 4, TO_TIMESTAMP('2024-03-18 05:00:00', 'YYYY-MM-DD HH24:MI:SS'), 2, TO_TIMESTAMP('2024-03-18 05:25:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 05:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 06:15:00', 'YYYY-MM-DD HH24:MI:SS'), 45000, 45045, NULL, 5, 'Excelente conductor');
INSERT INTO asignacion_servicios_transporte (id_reserva_transporte, id_vehiculo_transporte, id_chofer_transporte, fecha_asignacion, asignado_por, hora_llegada_vehiculo, hora_inicio_servicio, hora_fin_servicio, kilometraje_inicio, kilometraje_fin, incidencias, calificacion_pasajero, comentarios_pasajero) VALUES
(4, 6, 3, TO_TIMESTAMP('2024-03-18 17:30:00', 'YYYY-MM-DD HH24:MI:SS'), 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO asignacion_servicios_transporte (id_reserva_transporte, id_vehiculo_transporte, id_chofer_transporte, fecha_asignacion, asignado_por, hora_llegada_vehiculo, hora_inicio_servicio, hora_fin_servicio, kilometraje_inicio, kilometraje_fin, incidencias, calificacion_pasajero, comentarios_pasajero) VALUES
(5, 3, 3, TO_TIMESTAMP('2024-03-20 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- Tabla 27.7: tarifas_transporte_terrestre (se omite id_tarifa_transporte)
INSERT INTO tarifas_transporte_terrestre (id_ruta_transporte, tipo_tarifa, precio_por_persona, precio_vehiculo_privado, precio_maleta_extra, moneda, hora_inicio_aplicacion, hora_fin_aplicacion, dias_aplicacion, fecha_inicio_vigencia, fecha_fin_vigencia, activa) VALUES
(1, 'NORMAL', 5.00, NULL, 0.00, 'EUR', '06:00', '22:00', 'Lunes a Viernes', DATE '2024-01-01', NULL, 1);
INSERT INTO tarifas_transporte_terrestre (id_ruta_transporte, tipo_tarifa, precio_por_persona, precio_vehiculo_privado, precio_maleta_extra, moneda, hora_inicio_aplicacion, hora_fin_aplicacion, dias_aplicacion, fecha_inicio_vigencia, fecha_fin_vigencia, activa) VALUES
(1, 'NOCTURNA', 6.00, NULL, 0.00, 'EUR', '22:00', '06:00', 'Todos', DATE '2024-01-01', NULL, 1);
INSERT INTO tarifas_transporte_terrestre (id_ruta_transporte, tipo_tarifa, precio_por_persona, precio_vehiculo_privado, precio_maleta_extra, moneda, hora_inicio_aplicacion, hora_fin_aplicacion, dias_aplicacion, fecha_inicio_vigencia, fecha_fin_vigencia, activa) VALUES
(2, 'NORMAL', 5.50, NULL, 0.00, 'EUR', '06:00', '22:00', 'Todos', DATE '2024-01-01', NULL, 1);
INSERT INTO tarifas_transporte_terrestre (id_ruta_transporte, tipo_tarifa, precio_por_persona, precio_vehiculo_privado, precio_maleta_extra, moneda, hora_inicio_aplicacion, hora_fin_aplicacion, dias_aplicacion, fecha_inicio_vigencia, fecha_fin_vigencia, activa) VALUES
(6, 'NORMAL', 15.00, 55.00, 2.00, 'USD', '00:00', '23:59', 'Todos', DATE '2024-01-01', NULL, 1);
INSERT INTO tarifas_transporte_terrestre (id_ruta_transporte, tipo_tarifa, precio_por_persona, precio_vehiculo_privado, precio_maleta_extra, moneda, hora_inicio_aplicacion, hora_fin_aplicacion, dias_aplicacion, fecha_inicio_vigencia, fecha_fin_vigencia, activa) VALUES
(8, 'NORMAL', NULL, 25.00, 5.00, 'EUR', '00:00', '23:59', 'Todos', DATE '2024-01-01', NULL, 1);
INSERT INTO tarifas_transporte_terrestre (id_ruta_transporte, tipo_tarifa, precio_por_persona, precio_vehiculo_privado, precio_maleta_extra, moneda, hora_inicio_aplicacion, hora_fin_aplicacion, dias_aplicacion, fecha_inicio_vigencia, fecha_fin_vigencia, activa) VALUES
(9, 'NORMAL', NULL, 20.00, 3.00, 'USD', '00:00', '23:59', 'Todos', DATE '2024-01-01', NULL, 1);
INSERT INTO tarifas_transporte_terrestre (id_ruta_transporte, tipo_tarifa, precio_por_persona, precio_vehiculo_privado, precio_maleta_extra, moneda, hora_inicio_aplicacion, hora_fin_aplicacion, dias_aplicacion, fecha_inicio_vigencia, fecha_fin_vigencia, activa) VALUES
(4, 'FESTIVO', 4000.00, NULL, 0.00, 'COP', '00:00', '23:59', 'Festivos', DATE '2024-01-01', NULL, 1);

-- Tabla 27.8: empresas_transporte (se omite id_empresa_transporte)
INSERT INTO empresas_transporte (nombre_empresa, nit, tipo_empresa, telefono_contacto, email_contacto, website, persona_contacto, telefono_emergencia, horario_atencion, calificacion_promedio, autorizada_aeropuerto, fecha_autorizacion, fecha_vencimiento_autorizacion, activa) VALUES
('EMT Madrid', 'A-28123456', 'BUS', '+34901234567', 'atencion@emt.es', 'www.emtmadrid.es', 'Carlos López', '+34611223344', '24h', 4.5, 1, DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO empresas_transporte (nombre_empresa, nit, tipo_empresa, telefono_contacto, email_contacto, website, persona_contacto, telefono_emergencia, horario_atencion, calificacion_promedio, autorizada_aeropuerto, fecha_autorizacion, fecha_vencimiento_autorizacion, activa) VALUES
('Radio Taxi Madrid', 'B-87654321', 'TAXI', '+34913456789', 'central@radiotaxi.es', 'www.radiotaxi.es', 'Ana García', '+34622334455', '24h', 4.2, 1, DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO empresas_transporte (nombre_empresa, nit, tipo_empresa, telefono_contacto, email_contacto, website, persona_contacto, telefono_emergencia, horario_atencion, calificacion_promedio, autorizada_aeropuerto, fecha_autorizacion, fecha_vencimiento_autorizacion, activa) VALUES
('TransMilenio', '901234567-1', 'BUS', '+5712345678', 'atencion@transmilenio.gov.co', 'www.transmilenio.gov.co', 'Pedro Gómez', '+57300112233', '04:30-23:00', 4.0, 1, DATE '2023-02-15', DATE '2025-02-14', 1);
INSERT INTO empresas_transporte (nombre_empresa, nit, tipo_empresa, telefono_contacto, email_contacto, website, persona_contacto, telefono_emergencia, horario_atencion, calificacion_promedio, autorizada_aeropuerto, fecha_autorizacion, fecha_vencimiento_autorizacion, activa) VALUES
('NYC Taxi', 'NYC-12345', 'TAXI', '+12125551234', 'info@nyctaxi.nyc', 'www.nyctaxi.nyc', 'John Davis', '+19175551234', '24h', 4.3, 1, DATE '2023-03-10', DATE '2025-03-09', 1);
INSERT INTO empresas_transporte (nombre_empresa, nit, tipo_empresa, telefono_contacto, email_contacto, website, persona_contacto, telefono_emergencia, horario_atencion, calificacion_promedio, autorizada_aeropuerto, fecha_autorizacion, fecha_vencimiento_autorizacion, activa) VALUES
('Shuttle Madrid', 'C-11223344', 'SHUTTLE', '+34913456790', 'reservas@shuttlemadrid.com', 'www.shuttlemadrid.com', 'Laura Pérez', '+34633445566', '06:00-22:00', 4.8, 1, DATE '2023-04-20', DATE '2025-04-19', 1);
INSERT INTO empresas_transporte (nombre_empresa, nit, tipo_empresa, telefono_contacto, email_contacto, website, persona_contacto, telefono_emergencia, horario_atencion, calificacion_promedio, autorizada_aeropuerto, fecha_autorizacion, fecha_vencimiento_autorizacion, activa) VALUES
('Hertz', 'D-44556677', 'RENTA_CAR', '+34901239876', 'madrid@hertz.com', 'www.hertz.es', 'Carlos Ruiz', '+34644556677', '07:00-23:00', 4.6, 1, DATE '2023-05-05', DATE '2025-05-04', 1);

-- Tabla 27.9: convenios_hoteles_transporte (se omite id_convenio_hotel)
INSERT INTO convenios_hoteles_transporte (id_hotel_cercano, id_empresa_transporte, tipo_convenio, tarifa_especial, condiciones, fecha_inicio, fecha_fin, activo) VALUES
(1, 5, 'SHUTTLE_GRATUITO', 0.00, 'Para huéspedes del hotel', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO convenios_hoteles_transporte (id_hotel_cercano, id_empresa_transporte, tipo_convenio, tarifa_especial, condiciones, fecha_inicio, fecha_fin, activo) VALUES
(2, 5, 'TARIFA_PREFERENCIAL', 20.00, '20% descuento para huéspedes', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO convenios_hoteles_transporte (id_hotel_cercano, id_empresa_transporte, tipo_convenio, tarifa_especial, condiciones, fecha_inicio, fecha_fin, activo) VALUES
(3, 3, 'SHUTTLE_GRATUITO', 0.00, 'Servicio exclusivo', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO convenios_hoteles_transporte (id_hotel_cercano, id_empresa_transporte, tipo_convenio, tarifa_especial, condiciones, fecha_inicio, fecha_fin, activo) VALUES
(4, 3, 'TARIFA_PREFERENCIAL', 15000.00, 'Tarifa especial 15000 COP', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO convenios_hoteles_transporte (id_hotel_cercano, id_empresa_transporte, tipo_convenio, tarifa_especial, condiciones, fecha_inicio, fecha_fin, activo) VALUES
(5, 4, 'EXCLUSIVO', 45.00, 'Servicio exclusivo para TWA', DATE '2024-01-01', DATE '2024-12-31', 1);
INSERT INTO convenios_hoteles_transporte (id_hotel_cercano, id_empresa_transporte, tipo_convenio, tarifa_especial, condiciones, fecha_inicio, fecha_fin, activo) VALUES
(6, 4, 'TARIFA_PREFERENCIAL', 50.00, NULL, DATE '2024-01-01', DATE '2024-12-31', 1);

-- Tabla 27.10: quejas_transporte_terrestre (se omite id_queja_transporte)
INSERT INTO quejas_transporte_terrestre (id_reserva_transporte, id_pasajero, fecha_queja, tipo_queja, descripcion_queja, estado, fecha_resolucion, resolucion, compensacion_ofrecida, resuelto_por, satisfaccion_pasajero) VALUES
(3, 5, TO_TIMESTAMP('2024-03-19 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'TARIFA', 'Me cobraron más de lo indicado', 'RESUELTA', TO_TIMESTAMP('2024-03-20 11:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'Se devolvió la diferencia', '10 USD', 1, 5);
INSERT INTO quejas_transporte_terrestre (id_reserva_transporte, id_pasajero, fecha_queja, tipo_queja, descripcion_queja, estado, fecha_resolucion, resolucion, compensacion_ofrecida, resuelto_por, satisfaccion_pasajero) VALUES
(4, 9, TO_TIMESTAMP('2024-03-19 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'CONDUCTOR', 'El conductor llegó tarde', 'EN_INVESTIGACION', NULL, NULL, NULL, NULL, NULL);

COMMIT;
SELECT 'Módulo 27 completado' AS estado FROM dual;

-- =====================================================
-- MÓDULO 28: GESTIÓN DE EMERGENCIAS (10 TABLAS)
-- =====================================================

-- Tabla 28.1: planes_emergencia (se omite id_plan_emergencia)
INSERT INTO planes_emergencia (codigo_plan, nombre_plan, tipo_emergencia, nivel_activacion, descripcion, procedimiento, responsable_activacion, tiempo_respuesta_estimado_minutos, recursos_requeridos, version, fecha_creacion, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('PLAN-INC-001', 'Plan contra incendios', 'INCENDIO', 'EMERGENCIA', 'Procedimientos para incendios en terminal', 'Evacuar zona, activar alarma, llamar a bomberos', 'Jefe de Seguridad', 5, 'Bomberos, equipo de extinción', '2.1', DATE '2023-01-15', DATE '2024-01-15', DATE '2025-01-15', 1);
INSERT INTO planes_emergencia (codigo_plan, nombre_plan, tipo_emergencia, nivel_activacion, descripcion, procedimiento, responsable_activacion, tiempo_respuesta_estimado_minutos, recursos_requeridos, version, fecha_creacion, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('PLAN-SIS-001', 'Plan antisísmico', 'TERREMOTO', 'CRISIS', 'Actuación ante terremoto', 'Evacuación, puntos de encuentro', 'Jefe de Operaciones', 10, 'Protección Civil', '1.5', DATE '2023-03-20', DATE '2024-03-20', DATE '2025-03-20', 1);
INSERT INTO planes_emergencia (codigo_plan, nombre_plan, tipo_emergencia, nivel_activacion, descripcion, procedimiento, responsable_activacion, tiempo_respuesta_estimado_minutos, recursos_requeridos, version, fecha_creacion, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('PLAN-ACC-001', 'Plan accidente aéreo', 'ACCIDENTE_AEREO', 'CRISIS', 'Protocolo para accidente de aeronave', 'Activar servicios de emergencia, acordonar zona', 'Director Aeropuerto', 3, 'Bomberos, ambulancias, policía', '3.0', DATE '2023-02-10', DATE '2024-02-10', DATE '2025-02-10', 1);
INSERT INTO planes_emergencia (codigo_plan, nombre_plan, tipo_emergencia, nivel_activacion, descripcion, procedimiento, responsable_activacion, tiempo_respuesta_estimado_minutos, recursos_requeridos, version, fecha_creacion, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('PLAN-ATE-001', 'Plan antiterrorista', 'ATENTADO', 'CRISIS', 'Actuación ante atentado', 'Protocolo de seguridad nacional', 'Policía Nacional', 2, 'Fuerzas de seguridad', '2.2', DATE '2023-04-05', DATE '2024-04-05', DATE '2025-04-05', 1);
INSERT INTO planes_emergencia (codigo_plan, nombre_plan, tipo_emergencia, nivel_activacion, descripcion, procedimiento, responsable_activacion, tiempo_respuesta_estimado_minutos, recursos_requeridos, version, fecha_creacion, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('PLAN-QUI-001', 'Plan derrame químico', 'DERRAME_QUIMICO', 'EMERGENCIA', 'Protocolo para derrames de combustible', 'Contener derrame, desalojar zona', 'Jefe de Mantenimiento', 8, 'Equipo de contención', '1.8', DATE '2023-05-12', DATE '2024-05-12', DATE '2025-05-12', 1);
INSERT INTO planes_emergencia (codigo_plan, nombre_plan, tipo_emergencia, nivel_activacion, descripcion, procedimiento, responsable_activacion, tiempo_respuesta_estimado_minutos, recursos_requeridos, version, fecha_creacion, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('PLAN-MED-001', 'Plan emergencia médica masiva', 'EMERGENCIA_MEDICA_MASIVA', 'ALERTA', 'Protocolo para múltiples víctimas', 'Activar puesto médico avanzado', 'Jefe de Sanidad', 5, 'Personal médico, ambulancias', '2.0', DATE '2023-06-18', DATE '2024-06-18', DATE '2025-06-18', 1);

-- Tabla 28.2: equipos_emergencia (se omite id_equipo_emergencia)
INSERT INTO equipos_emergencia (codigo_equipo, nombre_equipo, tipo_equipo, descripcion, ubicacion_habitual, disponible_24h, personal_asignado, estado, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, activo) VALUES
('BOM-001', 'Bomba urbana pesada', 'CAMION_BOMBA', 'Camión de bomberos con escalera', 'Parque de bomberos', 1, 6, 'DISPONIBLE', DATE '2024-03-01', DATE '2024-04-01', 1);
INSERT INTO equipos_emergencia (codigo_equipo, nombre_equipo, tipo_equipo, descripcion, ubicacion_habitual, disponible_24h, personal_asignado, estado, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, activo) VALUES
('AMB-001', 'Ambulancia UVI móvil', 'AMBULANCIA', 'Ambulancia medicalizada', 'Base SAMUR', 1, 3, 'DISPONIBLE', DATE '2024-03-05', DATE '2024-04-05', 1);
INSERT INTO equipos_emergencia (codigo_equipo, nombre_equipo, tipo_equipo, descripcion, ubicacion_habitual, disponible_24h, personal_asignado, estado, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, activo) VALUES
('AMB-002', 'Ambulancia soporte vital', 'AMBULANCIA', 'Ambulancia básica', 'Base SAMUR', 1, 2, 'DISPONIBLE', DATE '2024-03-06', DATE '2024-04-06', 1);
INSERT INTO equipos_emergencia (codigo_equipo, nombre_equipo, tipo_equipo, descripcion, ubicacion_habitual, disponible_24h, personal_asignado, estado, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, activo) VALUES
('RES-001', 'Vehículo de rescate', 'UNIDAD_RESCATE', 'Vehículo para rescate en pista', 'Hangar emergencias', 1, 4, 'DISPONIBLE', DATE '2024-03-02', DATE '2024-04-02', 1);
INSERT INTO equipos_emergencia (codigo_equipo, nombre_equipo, tipo_equipo, descripcion, ubicacion_habitual, disponible_24h, personal_asignado, estado, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, activo) VALUES
('MED-001', 'Módulo médico avanzado', 'EQUIPO_MEDICO', 'Puesto médico desplegable', 'Almacén', 0, 5, 'DISPONIBLE', DATE '2024-02-28', DATE '2024-03-28', 1);
INSERT INTO equipos_emergencia (codigo_equipo, nombre_equipo, tipo_equipo, descripcion, ubicacion_habitual, disponible_24h, personal_asignado, estado, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, activo) VALUES
('GEN-001', 'Generador eléctrico', 'GENERADOR', 'Generador de emergencia 100kW', 'Sótano T4', 1, 1, 'EN_MANTENIMIENTO', DATE '2024-03-10', DATE '2024-04-10', 1);
INSERT INTO equipos_emergencia (codigo_equipo, nombre_equipo, tipo_equipo, descripcion, ubicacion_habitual, disponible_24h, personal_asignado, estado, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, activo) VALUES
('ILU-001', 'Torre de iluminación', 'ILUMINACION', 'Torre móvil con reflectores', 'Almacén', 0, 1, 'DISPONIBLE', DATE '2024-03-08', DATE '2024-04-08', 1);
INSERT INTO equipos_emergencia (codigo_equipo, nombre_equipo, tipo_equipo, descripcion, ubicacion_habitual, disponible_24h, personal_asignado, estado, fecha_ultimo_mantenimiento, fecha_proximo_mantenimiento, activo) VALUES
('COM-001', 'Puesto de mando avanzado', 'COMUNICACIONES', 'Unidad de comunicaciones móvil', 'Base seguridad', 1, 3, 'DISPONIBLE', DATE '2024-03-12', DATE '2024-04-12', 1);

-- Tabla 28.3: personal_emergencia (se omite id_personal_emergencia)
INSERT INTO personal_emergencia (id_empleado, especialidad, nivel_certificacion, fecha_certificacion, fecha_vencimiento_certificacion, disponible_24h, grupo_respuesta, activo) VALUES
(2, 'BOMBERO', 'AVANZADO', DATE '2023-01-15', DATE '2025-01-15', 1, 'Alpha', 1);
INSERT INTO personal_emergencia (id_empleado, especialidad, nivel_certificacion, fecha_certificacion, fecha_vencimiento_certificacion, disponible_24h, grupo_respuesta, activo) VALUES
(3, 'PARAMEDICO', 'INTERMEDIO', DATE '2023-03-20', DATE '2025-03-20', 1, 'Bravo', 1);
INSERT INTO personal_emergencia (id_empleado, especialidad, nivel_certificacion, fecha_certificacion, fecha_vencimiento_certificacion, disponible_24h, grupo_respuesta, activo) VALUES
(5, 'MEDICO', 'AVANZADO', DATE '2023-02-10', DATE '2026-02-10', 0, 'Charlie', 1);
INSERT INTO personal_emergencia (id_empleado, especialidad, nivel_certificacion, fecha_certificacion, fecha_vencimiento_certificacion, disponible_24h, grupo_respuesta, activo) VALUES
(7, 'ENFERMERO', 'BASICO', DATE '2023-05-05', DATE '2024-05-05', 1, 'Bravo', 1);
INSERT INTO personal_emergencia (id_empleado, especialidad, nivel_certificacion, fecha_certificacion, fecha_vencimiento_certificacion, disponible_24h, grupo_respuesta, activo) VALUES
(8, 'RESCATISTA', 'INTERMEDIO', DATE '2023-04-12', DATE '2025-04-12', 1, 'Alpha', 1);
INSERT INTO personal_emergencia (id_empleado, especialidad, nivel_certificacion, fecha_certificacion, fecha_vencimiento_certificacion, disponible_24h, grupo_respuesta, activo) VALUES
(9, 'COORDINADOR', 'AVANZADO', DATE '2023-06-18', DATE '2026-06-18', 1, 'Comando', 1);
INSERT INTO personal_emergencia (id_empleado, especialidad, nivel_certificacion, fecha_certificacion, fecha_vencimiento_certificacion, disponible_24h, grupo_respuesta, activo) VALUES
(10, 'COMUNICADOR', 'BASICO', DATE '2023-07-22', DATE '2024-07-22', 1, 'Delta', 1);

-- Tabla 28.4: simulacros (se omite id_simulacro)
INSERT INTO simulacros (fecha_simulacro, tipo_simulacro, id_plan_emergencia, alcance, participantes, duracion_horas, objetivos, resultados, evaluacion, coordinador, fecha_proximo_simulacro) VALUES
(DATE '2024-02-15', 'INCENDIO', 1, 'Simulacro de incendio en terminal T4', 150, 2, 'Evaluar tiempos de evacuación', 'Evacuación completada en 5 minutos', 'SATISFACTORIO', 'Jefe Seguridad', DATE '2024-08-15');
INSERT INTO simulacros (fecha_simulacro, tipo_simulacro, id_plan_emergencia, alcance, participantes, duracion_horas, objetivos, resultados, evaluacion, coordinador, fecha_proximo_simulacro) VALUES
(DATE '2024-01-20', 'EVACUACION', 2, 'Simulacro de evacuación general', 500, 3, 'Probar puntos de encuentro', 'Congestión en puntos de encuentro', 'MEJORABLE', 'Jefe Operaciones', DATE '2024-07-20');
INSERT INTO simulacros (fecha_simulacro, tipo_simulacro, id_plan_emergencia, alcance, participantes, duracion_horas, objetivos, resultados, evaluacion, coordinador, fecha_proximo_simulacro) VALUES
(DATE '2024-03-10', 'ACCIDENTE_AEREO', 3, 'Simulacro de accidente en pista', 200, 4, 'Coordinar servicios de emergencia', 'Buena coordinación entre equipos', 'SATISFACTORIO', 'Director', DATE '2024-09-10');
INSERT INTO simulacros (fecha_simulacro, tipo_simulacro, id_plan_emergencia, alcance, participantes, duracion_horas, objetivos, resultados, evaluacion, coordinador, fecha_proximo_simulacro) VALUES
(DATE '2024-02-28', 'DERRAME_QUIMICO', 5, 'Derrame controlado en zona de combustible', 50, 2, 'Probar protocolos de contención', 'Contención exitosa', 'SATISFACTORIO', 'Jefe Mantenimiento', DATE '2024-08-28');

-- Tabla 28.5: activaciones_emergencia (se omite id_activacion)
INSERT INTO activaciones_emergencia (fecha_hora_activacion, tipo_emergencia, id_plan_emergencia, nivel_activacion, descripcion_incidente, lugar_incidente, personas_afectadas, personas_atendidas, recursos_movilizados, hora_control, hora_fin, estado, responsable_coordinacion) VALUES
(TO_TIMESTAMP('2024-03-19 14:20:00', 'YYYY-MM-DD HH24:MI:SS'), 'ATENTADO', 4, 'ALERTA', 'Paquete sospechoso en T1', 'Terminal 1 llegadas', 0, 0, 'Policía Nacional, bomberos', TO_TIMESTAMP('2024-03-19 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-19 16:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'FINALIZADA', 'Jefe Seguridad');
INSERT INTO activaciones_emergencia (fecha_hora_activacion, tipo_emergencia, id_plan_emergencia, nivel_activacion, descripcion_incidente, lugar_incidente, personas_afectadas, personas_atendidas, recursos_movilizados, hora_control, hora_fin, estado, responsable_coordinacion) VALUES
(TO_TIMESTAMP('2024-03-18 09:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'EMERGENCIA_MEDICA_MASIVA', 6, 'PREALERTA', 'Múltiples pasajeros con mareos en sala VIP', 'Sala VIP BOG', 8, 8, 'Ambulancias, personal médico', TO_TIMESTAMP('2024-03-18 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_TIMESTAMP('2024-03-18 12:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'FINALIZADA', 'Jefe Sanidad');

-- Tabla 28.6: puntos_encuentro (se omite id_punto_encuentro)
INSERT INTO puntos_encuentro (codigo_punto, nombre, ubicacion, coordenada_latitud, coordenada_longitud, capacidad_personas, senalizacion_visible, iluminacion, recursos_disponibles, responsable_asignado, activo) VALUES
('PE-01', 'Punto Norte', 'Zona norte T4 exterior', 40.5010, -3.5650, 500, 1, 1, 'Agua, mantas, megáfono', 'Seguridad Norte', 1);
INSERT INTO puntos_encuentro (codigo_punto, nombre, ubicacion, coordenada_latitud, coordenada_longitud, capacidad_personas, senalizacion_visible, iluminacion, recursos_disponibles, responsable_asignado, activo) VALUES
('PE-02', 'Punto Sur', 'Zona sur T4 exterior', 40.4850, -3.5680, 600, 1, 1, 'Agua, mantas, megáfono', 'Seguridad Sur', 1);
INSERT INTO puntos_encuentro (codigo_punto, nombre, ubicacion, coordenada_latitud, coordenada_longitud, capacidad_personas, senalizacion_visible, iluminacion, recursos_disponibles, responsable_asignado, activo) VALUES
('PE-03', 'Punto Este', 'Parking T4', 40.4950, -3.5600, 400, 1, 1, 'Botiquín, agua', 'Parking', 1);
INSERT INTO puntos_encuentro (codigo_punto, nombre, ubicacion, coordenada_latitud, coordenada_longitud, capacidad_personas, senalizacion_visible, iluminacion, recursos_disponibles, responsable_asignado, activo) VALUES
('PE-04', 'Punto Oeste', 'Zona de carga', 40.4920, -3.5750, 300, 0, 0, NULL, NULL, 1);
INSERT INTO puntos_encuentro (codigo_punto, nombre, ubicacion, coordenada_latitud, coordenada_longitud, capacidad_personas, senalizacion_visible, iluminacion, recursos_disponibles, responsable_asignado, activo) VALUES
('PE-05', 'Punto Central BOG', 'Plaza central T1', 4.7050, -74.1450, 800, 1, 1, 'Agua, botiquín', 'Coordinador', 1);

-- Tabla 28.7: comunicaciones_emergencia (se omite id_comunicacion_emergencia)
INSERT INTO comunicaciones_emergencia (id_activacion, fecha_hora_envio, tipo_mensaje, medio_envio, destinatarios, contenido, emisor, confirmacion_recibido, observaciones) VALUES
(1, TO_TIMESTAMP('2024-03-19 14:25:00', 'YYYY-MM-DD HH24:MI:SS'), 'ALERTA', 'ALTAVOZ', 'Pasajeros T1', 'Procedan a evacuar la terminal', 'Jefe Seguridad', 1, NULL);
INSERT INTO comunicaciones_emergencia (id_activacion, fecha_hora_envio, tipo_mensaje, medio_envio, destinatarios, contenido, emisor, confirmacion_recibido, observaciones) VALUES
(1, TO_TIMESTAMP('2024-03-19 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'INSTRUCCION', 'RADIO', 'Equipos de seguridad', 'Acordonar zona de llegadas', 'Central', 1, NULL);
INSERT INTO comunicaciones_emergencia (id_activacion, fecha_hora_envio, tipo_mensaje, medio_envio, destinatarios, contenido, emisor, confirmacion_recibido, observaciones) VALUES
(1, TO_TIMESTAMP('2024-03-19 15:35:00', 'YYYY-MM-DD HH24:MI:SS'), 'CONFIRMACION', 'RADIO', 'Todos los equipos', 'Falso aviso, reabrir terminal', 'Policía', 1, NULL);
INSERT INTO comunicaciones_emergencia (id_activacion, fecha_hora_envio, tipo_mensaje, medio_envio, destinatarios, contenido, emisor, confirmacion_recibido, observaciones) VALUES
(2, TO_TIMESTAMP('2024-03-18 09:10:00', 'YYYY-MM-DD HH24:MI:SS'), 'ALERTA', 'SMS', 'Personal sanitario', 'Múltiples pasajeros afectados en sala VIP', 'Coordinador', 1, NULL);
INSERT INTO comunicaciones_emergencia (id_activacion, fecha_hora_envio, tipo_mensaje, medio_envio, destinatarios, contenido, emisor, confirmacion_recibido, observaciones) VALUES
(2, TO_TIMESTAMP('2024-03-18 11:05:00', 'YYYY-MM-DD HH24:MI:SS'), 'INFORME', 'EMAIL', 'Dirección', 'Incidente médico resuelto', 'Jefe Sanidad', 0, NULL);

-- Tabla 28.8: recursos_emergencia (se omite id_recurso_emergencia)
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('MEDICO', 'Botiquines de primeros auxilios', 50, 'Almacén T4', DATE '2025-12-31', 'Sanitaria SA', 'Enfermería', DATE '2024-03-01', DATE '2024-06-01', 1);
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('MEDICO', 'Desfibriladores', 15, 'Terminales', DATE '2026-01-15', 'CardioCare', 'Enfermería', DATE '2024-02-15', DATE '2024-05-15', 1);
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('EXTINCION', 'Extintores CO2', 200, 'Todo el aeropuerto', DATE '2024-12-01', 'Extintores SA', 'Mantenimiento', DATE '2024-03-10', DATE '2024-06-10', 1);
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('RESCATE', 'Cuerdas de rescate', 30, 'Hangar emergencias', DATE '2028-01-01', 'Rescate SL', 'Bomberos', DATE '2024-02-20', DATE '2024-05-20', 1);
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('COMUNICACION', 'Radios portátiles', 40, 'Base seguridad', DATE '2026-03-01', 'Comunicaciones SL', 'Seguridad', DATE '2024-03-05', DATE '2024-06-05', 1);
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('ENERGIA', 'Generadores portátiles', 5, 'Almacén', DATE '2030-01-01', 'Generadores SA', 'Mantenimiento', DATE '2024-02-28', DATE '2024-05-28', 1);
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('AGUA', 'Agua embotellada', 2000, 'Almacén T4', DATE '2025-06-01', 'Aqua SA', 'Logística', DATE '2024-03-12', DATE '2024-06-12', 1);
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('ALIMENTOS', 'Barras energéticas', 1000, 'Almacén T4', DATE '2024-12-01', 'Alimentos SA', 'Logística', DATE '2024-03-15', DATE '2024-06-15', 1);
INSERT INTO recursos_emergencia (tipo_recurso, nombre_recurso, cantidad_disponible, ubicacion_almacen, fecha_vencimiento, proveedor, responsable_mantenimiento, fecha_ultima_revision, fecha_proxima_revision, activo) VALUES
('TRANSPORTE', 'Camillas plegables', 20, 'Almacén', DATE '2030-01-01', 'Medical Supplies', 'Enfermería', DATE '2024-03-08', DATE '2024-06-08', 1);

-- Tabla 28.9: evaluaciones_post_emergencia (se omite id_evaluacion_post)
INSERT INTO evaluaciones_post_emergencia (id_activacion, fecha_evaluacion, evaluador, tiempo_respuesta_minutos, eficacia_respuesta, coordinacion, recursos_utilizados, puntos_fuertes, areas_mejora, acciones_recomendadas, responsable_seguimiento, fecha_seguimiento) VALUES
(1, TO_TIMESTAMP('2024-03-20 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Comité Seguridad', 10, 4, 4, 'Policía, bomberos, megafonía', 'Rápida activación', 'Comunicación inicial', 'Mejorar protocolo de comunicación', 'Jefe Seguridad', DATE '2024-04-20');
INSERT INTO evaluaciones_post_emergencia (id_activacion, fecha_evaluacion, evaluador, tiempo_respuesta_minutos, eficacia_respuesta, coordinacion, recursos_utilizados, puntos_fuertes, areas_mejora, acciones_recomendadas, responsable_seguimiento, fecha_seguimiento) VALUES
(2, TO_TIMESTAMP('2024-03-19 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'Jefe Sanidad', 10, 5, 5, '2 ambulancias, 4 sanitarios', 'Atención rápida', 'Ninguna', 'Mantener protocolo', 'Jefe Sanidad', DATE '2024-04-19');

-- Tabla 28.10: entrenamientos_emergencia (se omite id_entrenamiento)
INSERT INTO entrenamientos_emergencia (nombre_entrenamiento, tipo_entrenamiento, fecha_realizacion, duracion_horas, instructor, participantes, contenido, evaluacion, certificaciones_entregadas, fecha_proximo_entrenamiento) VALUES
('Primeros Auxilios Básicos', 'PRIMEROS_AUXILIOS', DATE '2024-02-10', 8, 'Cruz Roja', 30, 'RCP, vendajes, actuación ante emergencias', 'Aprobado por 28 participantes', 1, DATE '2025-02-10');
INSERT INTO entrenamientos_emergencia (nombre_entrenamiento, tipo_entrenamiento, fecha_realizacion, duracion_horas, instructor, participantes, contenido, evaluacion, certificaciones_entregadas, fecha_proximo_entrenamiento) VALUES
('Uso de Extintores', 'COMBATE_INCENDIOS', DATE '2024-03-05', 4, 'Bomberos', 45, 'Tipos de fuego, manejo de extintores', 'Prácticas superadas', 1, DATE '2024-09-05');
INSERT INTO entrenamientos_emergencia (nombre_entrenamiento, tipo_entrenamiento, fecha_realizacion, duracion_horas, instructor, participantes, contenido, evaluacion, certificaciones_entregadas, fecha_proximo_entrenamiento) VALUES
('Evacuación de Terminales', 'EVACUACION', DATE '2024-01-20', 6, 'Protección Civil', 60, 'Protocolos de evacuación, puntos de encuentro', 'Simulacro posterior', 0, DATE '2024-07-20');
INSERT INTO entrenamientos_emergencia (nombre_entrenamiento, tipo_entrenamiento, fecha_realizacion, duracion_horas, instructor, participantes, contenido, evaluacion, certificaciones_entregadas, fecha_proximo_entrenamiento) VALUES
('Mercancías Peligrosas', 'MAT_PELIGROSOS', DATE '2024-03-12', 8, 'IATA', 25, 'Identificación y manejo de materiales peligrosos', 'Certificación IATA', 1, DATE '2025-03-12');
INSERT INTO entrenamientos_emergencia (nombre_entrenamiento, tipo_entrenamiento, fecha_realizacion, duracion_horas, instructor, participantes, contenido, evaluacion, certificaciones_entregadas, fecha_proximo_entrenamiento) VALUES
('Coordinación de Emergencias', 'COORDINACION', DATE '2024-02-28', 12, 'Dirección', 15, 'Gestión de crisis, toma de decisiones', 'Muy satisfactorio', 0, DATE '2024-08-28');

COMMIT;
SELECT 'Módulo 28 completado' AS estado FROM dual;

-- =====================================================
-- MÓDULO 29: INTEROPERABILIDAD CON OACI (7 TABLAS)
-- =====================================================

-- Tabla 29.1: codigos_oaci_paises (se omite id_pais_oaci)
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('España (Canarias)', 'GC', 'GC', 'GC', DATE '1950-01-01', 'Islas Canarias');
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('Estados Unidos', 'K', 'K', 'K', DATE '1947-01-01', 'Continental');
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('Reino Unido', 'EG', 'EG', 'EG', DATE '1950-01-01', NULL);
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('Francia', 'LF', 'LF', 'LF', DATE '1950-01-01', NULL);
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('Colombia', 'SK', 'SK', 'SK', DATE '1955-01-01', NULL);
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('México', 'MM', 'MM', 'MM', DATE '1955-01-01', NULL);
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('Brasil', 'SB', 'SB', 'SB', DATE '1950-01-01', NULL);
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('Australia', 'Y', 'Y', 'Y', DATE '1947-01-01', NULL);
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('Argentina', 'SA', 'SA', 'SA', DATE '1950-01-01', NULL);
INSERT INTO codigos_oaci_paises (nombre_pais, codigo_oaci_pais, rango_inicio, rango_fin, fecha_asignacion, observaciones) VALUES
('Chile', 'SC', 'SC', 'SC', DATE '1950-01-01', NULL);

-- Tabla 29.2: series_vuelo_asignadas (se omite id_serie_vuelo)
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(1, 1, '1000', '1999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(5, 6, '2000', '2999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(4, 7, '3000', '3999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(2, 3, '4000', '4999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(2, 4, '5000', '5999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(2, 5, '6000', '6999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(3, 2, '7000', '7999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(6, 9, '8000', '8999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(7, 10, '9000', '9999', DATE '2023-01-01', DATE '2025-12-31', 1);
INSERT INTO series_vuelo_asignadas (id_pais_oaci, id_aerolinea, rango_numeros_inicio, rango_numeros_fin, fecha_asignacion, fecha_vencimiento, activa) VALUES
(8, 8, '10000', '10999', DATE '2023-01-01', DATE '2025-12-31', 1);

-- Tabla 29.3: reportes_oaci (se omite id_reporte_oaci)
INSERT INTO reportes_oaci (tipo_reporte, periodo, fecha_inicio_periodo, fecha_fin_periodo, fecha_envio, estado, enviado_por, confirmacion_recibido, observaciones) VALUES
('ESTADISTICO', 'ANUAL', DATE '2023-01-01', DATE '2023-12-31', DATE '2024-02-15', 'ENVIADO', 4, 1, 'Informe anual remitido');
INSERT INTO reportes_oaci (tipo_reporte, periodo, fecha_inicio_periodo, fecha_fin_periodo, fecha_envio, estado, enviado_por, confirmacion_recibido, observaciones) VALUES
('SEGURIDAD', 'MENSUAL', DATE '2024-02-01', DATE '2024-02-29', DATE '2024-03-05', 'ENVIADO', 2, 1, 'Sin incidencias destacables');
INSERT INTO reportes_oaci (tipo_reporte, periodo, fecha_inicio_periodo, fecha_fin_periodo, fecha_envio, estado, enviado_por, confirmacion_recibido, observaciones) VALUES
('OPERACIONES', 'TRIMESTRAL', DATE '2024-01-01', DATE '2024-03-31', NULL, 'GENERADO', 1, 0, NULL);
INSERT INTO reportes_oaci (tipo_reporte, periodo, fecha_inicio_periodo, fecha_fin_periodo, fecha_envio, estado, enviado_por, confirmacion_recibido, observaciones) VALUES
('INCIDENTES', 'MENSUAL', DATE '2024-03-01', DATE '2024-03-31', NULL, 'GENERADO', 5, 0, NULL);
INSERT INTO reportes_oaci (tipo_reporte, periodo, fecha_inicio_periodo, fecha_fin_periodo, fecha_envio, estado, enviado_por, confirmacion_recibido, observaciones) VALUES
('FINANCIERO', 'SEMESTRAL', DATE '2023-07-01', DATE '2023-12-31', DATE '2024-01-20', 'ENVIADO', 4, 1, 'Datos económicos remitidos');

-- Tabla 29.4: estandares_internacionales (se omite id_estandar)
INSERT INTO estandares_internacionales (codigo_estandar, nombre_estandar, descripcion, organismo_emisor, fecha_publicacion, version, fecha_vigencia, obligatorio, activo) VALUES
('ISO 9001:2015', 'Sistemas de Gestión de Calidad', 'Requisitos para sistemas de gestión de calidad', 'ISO', DATE '2015-09-15', '2015', DATE '2015-09-15', 0, 1);
INSERT INTO estandares_internacionales (codigo_estandar, nombre_estandar, descripcion, organismo_emisor, fecha_publicacion, version, fecha_vigencia, obligatorio, activo) VALUES
('ISO 14001:2015', 'Gestión Ambiental', 'Requisitos para sistemas de gestión ambiental', 'ISO', DATE '2015-09-15', '2015', DATE '2015-09-15', 0, 1);
INSERT INTO estandares_internacionales (codigo_estandar, nombre_estandar, descripcion, organismo_emisor, fecha_publicacion, version, fecha_vigencia, obligatorio, activo) VALUES
('ISO 45001:2018', 'Seguridad y Salud en el Trabajo', 'Requisitos para sistemas de gestión de SST', 'ISO', DATE '2018-03-12', '2018', DATE '2018-03-12', 0, 1);
INSERT INTO estandares_internacionales (codigo_estandar, nombre_estandar, descripcion, organismo_emisor, fecha_publicacion, version, fecha_vigencia, obligatorio, activo) VALUES
('IATA-ISAGO', 'IATA Safety Audit for Ground Operations', 'Estándar de seguridad en operaciones en tierra', 'IATA', DATE '2023-01-01', '5', DATE '2023-01-01', 1, 1);
INSERT INTO estandares_internacionales (codigo_estandar, nombre_estandar, descripcion, organismo_emisor, fecha_publicacion, version, fecha_vigencia, obligatorio, activo) VALUES
('OACI-ANNEX6', 'Anexo 6 - Operación de Aeronaves', 'Estándares para operación de aeronaves', 'OACI', DATE '2022-07-01', '12', DATE '2022-07-01', 1, 1);
INSERT INTO estandares_internacionales (codigo_estandar, nombre_estandar, descripcion, organismo_emisor, fecha_publicacion, version, fecha_vigencia, obligatorio, activo) VALUES
('OACI-ANNEX14', 'Anexo 14 - Aeródromos', 'Diseño y operación de aeródromos', 'OACI', DATE '2023-03-01', '9', DATE '2023-03-01', 1, 1);

-- Tabla 29.5: auditorias_internacionales (se omite id_auditoria_internacional)
INSERT INTO auditorias_internacionales (entidad_auditora, fecha_auditoria, tipo_auditoria, alcance, auditores, areas_auditadas, hallazgos, no_conformidades, recomendaciones, fecha_informe, plazo_correccion_dias, fecha_cierre, observaciones) VALUES
('IATA', DATE '2024-02-20', 'SEGURIDAD', 'Auditoría ISAGO', 'John Smith, María García', 'Operaciones en tierra, handling', 'Procedimientos correctos', '2 menores', 'Actualizar manuales', DATE '2024-03-05', 60, NULL, NULL);
INSERT INTO auditorias_internacionales (entidad_auditora, fecha_auditoria, tipo_auditoria, alcance, auditores, areas_auditadas, hallazgos, no_conformidades, recomendaciones, fecha_informe, plazo_correccion_dias, fecha_cierre, observaciones) VALUES
('EASA', DATE '2024-01-15', 'OPERACIONES', 'Auditoría de seguridad operacional', 'Pierre Dubois, Ana López', 'Mantenimiento, operaciones de vuelo', 'Registros incompletos', '1 mayor', 'Implementar sistema digital', DATE '2024-02-01', 90, NULL, NULL);
INSERT INTO auditorias_internacionales (entidad_auditora, fecha_auditoria, tipo_auditoria, alcance, auditores, areas_auditadas, hallazgos, no_conformidades, recomendaciones, fecha_informe, plazo_correccion_dias, fecha_cierre, observaciones) VALUES
('ISO', DATE '2023-11-10', 'CALIDAD', 'Auditoría de certificación ISO 9001', 'Carlos Gómez, Elena Ruiz', 'Todos los departamentos', 'Sistema consolidado', '0', 'Continuar mejora continua', DATE '2023-12-01', NULL, DATE '2023-12-01', 'Certificación renovada');

-- Tabla 29.6: certificaciones_internacionales (se omite id_certificacion_internacional)
INSERT INTO certificaciones_internacionales (id_estandar, nombre_certificacion, organismo_certificador, fecha_emision, fecha_vencimiento, alcance_certificacion, numero_certificado, activa, responsable_seguimiento) VALUES
(1, 'ISO 9001:2015', 'AENOR', DATE '2023-12-15', DATE '2026-12-14', 'Gestión de calidad aeroportuaria', 'CERT-001-2023', 1, 10);
INSERT INTO certificaciones_internacionales (id_estandar, nombre_certificacion, organismo_certificador, fecha_emision, fecha_vencimiento, alcance_certificacion, numero_certificado, activa, responsable_seguimiento) VALUES
(2, 'ISO 14001:2015', 'AENOR', DATE '2023-11-20', DATE '2026-11-19', 'Gestión ambiental', 'CERT-002-2023', 1, 2);
INSERT INTO certificaciones_internacionales (id_estandar, nombre_certificacion, organismo_certificador, fecha_emision, fecha_vencimiento, alcance_certificacion, numero_certificado, activa, responsable_seguimiento) VALUES
(4, 'ISAGO Registration', 'IATA', DATE '2024-01-10', DATE '2026-01-09', 'Safety audit ground operations', 'ISAGO-001-2024', 1, 1);
INSERT INTO certificaciones_internacionales (id_estandar, nombre_certificacion, organismo_certificador, fecha_emision, fecha_vencimiento, alcance_certificacion, numero_certificado, activa, responsable_seguimiento) VALUES
(3, 'ISO 45001:2018', 'AENOR', DATE '2024-02-28', DATE '2027-02-27', 'Seguridad y salud laboral', 'CERT-003-2024', 1, 3);
INSERT INTO certificaciones_internacionales (id_estandar, nombre_certificacion, organismo_certificador, fecha_emision, fecha_vencimiento, alcance_certificacion, numero_certificado, activa, responsable_seguimiento) VALUES
(NULL, 'Airport Carbon Accreditation Level 2', 'ACI', DATE '2023-10-05', DATE '2024-10-04', 'Reducción de huella de carbono', 'ACA-002-2023', 1, 2);

-- Tabla 29.7: notificaciones_oaci (se omite id_notificacion_oaci)
INSERT INTO notificaciones_oaci (numero_notificacion, fecha_recepcion, tipo_notificacion, asunto, descripcion, fecha_limite_cumplimiento, area_responsable, estado_cumplimiento, fecha_cumplimiento, observaciones) VALUES
('OACI-CIRC-2024-01', TO_TIMESTAMP('2024-02-01 10:00:00', 'YYYY-MM-DD HH24:MI:SS'), 'CIRCULAR', 'Nuevos códigos de aeropuertos', 'Actualización de códigos OACI para nuevos aeropuertos', DATE '2024-05-01', 1, 'PENDIENTE', NULL, NULL);
INSERT INTO notificaciones_oaci (numero_notificacion, fecha_recepcion, tipo_notificacion, asunto, descripcion, fecha_limite_cumplimiento, area_responsable, estado_cumplimiento, fecha_cumplimiento, observaciones) VALUES
('OACI-DIR-2024-05', TO_TIMESTAMP('2024-01-15 14:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'DIRECTIVA', 'Requisitos de seguridad para vuelos nocturnos', 'Nuevas normas para operaciones nocturnas', DATE '2024-04-15', 1, 'EN_PROCESO', NULL, NULL);
INSERT INTO notificaciones_oaci (numero_notificacion, fecha_recepcion, tipo_notificacion, asunto, descripcion, fecha_limite_cumplimiento, area_responsable, estado_cumplimiento, fecha_cumplimiento, observaciones) VALUES
('OACI-REQ-2024-12', TO_TIMESTAMP('2024-03-10 09:15:00', 'YYYY-MM-DD HH24:MI:SS'), 'REQUERIMIENTO', 'Informe de seguridad anual', 'Solicitud de datos de seguridad 2023', DATE '2024-04-30', 2, 'PENDIENTE', NULL, NULL);
INSERT INTO notificaciones_oaci (numero_notificacion, fecha_recepcion, tipo_notificacion, asunto, descripcion, fecha_limite_cumplimiento, area_responsable, estado_cumplimiento, fecha_cumplimiento, observaciones) VALUES
('OACI-INF-2024-08', TO_TIMESTAMP('2024-02-20 11:45:00', 'YYYY-MM-DD HH24:MI:SS'), 'INFORMACION', 'Conferencia de aviación civil', 'Información sobre conferencia anual', NULL, 3, 'CUMPLIDO', DATE '2024-02-25', 'Información distribuida');
INSERT INTO notificaciones_oaci (numero_notificacion, fecha_recepcion, tipo_notificacion, asunto, descripcion, fecha_limite_cumplimiento, area_responsable, estado_cumplimiento, fecha_cumplimiento, observaciones) VALUES
('OACI-ALERT-2024-03', TO_TIMESTAMP('2024-03-05 08:30:00', 'YYYY-MM-DD HH24:MI:SS'), 'ALERTA', 'Alerta de seguridad cibernética', 'Posibles amenazas a sistemas de navegación', DATE '2024-03-20', 8, 'EN_PROCESO', NULL, NULL);

COMMIT;
SELECT 'Módulo 29 completado' AS estado FROM dual;
















-- ----------------------VISTAAAS

CREATE OR REPLACE VIEW vista_publicidad_efectiva AS
SELECT 
    p.id_pasajero,
    p.nombres || ' ' || p.apellidos AS nombre_completo,
    p.email,
    p.telefono,
    pub.empresa_anunciante,
    pub.tipo_publicidad,
    pub.ubicacion,
    pub.fecha_inicio AS inicio_campania,
    pub.fecha_fin AS fin_campania,
    r.fecha_reserva,
    r.codigo_reserva,
    r.precio_pagado,
    r.moneda,
    pv.numero_vuelo,
    a.nombre_aerolinea,
    v.fecha_vuelo,
    v.estado_vuelo,
    rp.tipo_reaccion,
    rp.fecha_reaccion,
    -- CORREGIDO: Convertir TIMESTAMP a DATE para resta
    ROUND(CAST(r.fecha_reserva AS DATE) - CAST(rp.fecha_reaccion AS DATE)) AS dias_entre_reaccion_y_reserva
FROM pasajeros p
JOIN reacciones_promociones rp ON p.id_pasajero = rp.id_pasajero
JOIN ofertas_personalizadas op ON rp.id_oferta_personalizada = op.id_oferta_personalizada
JOIN promociones prom ON op.id_promocion = prom.id_promocion
JOIN publicidad pub ON pub.empresa_anunciante LIKE '%' || prom.codigo_promocion || '%'
JOIN reservas r ON p.id_pasajero = r.id_pasajero
JOIN vuelos v ON r.id_vuelo = v.id_vuelo
JOIN programas_vuelo pv ON v.id_programa = pv.id_programa
JOIN aerolineas a ON pv.id_aerolinea = a.id_aerolinea
WHERE rp.tipo_reaccion IN ('CLICK', 'APLICADA')
AND r.fecha_reserva > pub.fecha_inicio
AND r.fecha_reserva < pub.fecha_fin;


CREATE OR REPLACE VIEW vista_vacaciones_temporada_alta AS
SELECT 
    e.id_empleado,
    e.codigo_empleado,
    e.nombres || ' ' || e.apellidos AS nombre_completo,
    e.cargo,
    e.departamento,
    vp.fecha_inicio AS inicio_vacaciones,
    vp.fecha_fin AS fin_vacaciones,
    vp.dias_solicitados,
    tv.nombre_temporada,
    tv.factor_demanda,
    -- CORREGIDO: Cálculo de porcentaje sin errores
    ROUND(vp.dias_solicitados * 100.0 / 30, 2) AS porcentaje_mes,
    -- CORREGIDO: Duración de vacaciones en días
    (vp.fecha_fin - vp.fecha_inicio) AS duracion_real_dias
FROM empleados e
JOIN vacaciones_permisos vp ON e.id_empleado = vp.id_empleado
JOIN temporadas_vuelo tv ON vp.fecha_inicio BETWEEN tv.fecha_inicio AND tv.fecha_fin
WHERE vp.tipo_solicitud = 'VACACIONES'
AND tv.factor_demanda > 1.3
ORDER BY tv.factor_demanda DESC;



CREATE OR REPLACE VIEW vista_viajes_cumpleaneros AS
SELECT 
    p.id_pasajero,
    p.nombres || ' ' || p.apellidos AS nombre_completo,
    p.fecha_nacimiento,
    EXTRACT(MONTH FROM p.fecha_nacimiento) AS mes_cumple,
    EXTRACT(DAY FROM p.fecha_nacimiento) AS dia_cumple,
    r.codigo_reserva,
    pv.numero_vuelo,  -- CORREGIDO
    v.fecha_vuelo,
    r.precio_pagado - NVL(rp.descuento_aplicado, 0) AS precio_sin_descuento,  -- CORREGIDO: NVL en lugar de COALESCE
    NVL(rp.descuento_aplicado, 0) AS descuento_aplicado,
    prom.nombre_promocion,
    prom.codigo_promocion,
    -- CORREGIDO: Días desde cumpleaños
    ABS(CAST(v.fecha_vuelo AS DATE) - CAST(p.fecha_nacimiento AS DATE)) AS dias_desde_cumple
FROM pasajeros p
JOIN reservas r ON p.id_pasajero = r.id_pasajero
JOIN vuelos v ON r.id_vuelo = v.id_vuelo
JOIN programas_vuelo pv ON v.id_programa = pv.id_programa
LEFT JOIN reservas_promociones rp ON r.id_reserva = rp.id_reserva
LEFT JOIN promociones prom ON rp.id_promocion = prom.id_promocion
WHERE EXTRACT(MONTH FROM p.fecha_nacimiento) = EXTRACT(MONTH FROM v.fecha_vuelo)
AND ABS(EXTRACT(DAY FROM p.fecha_nacimiento) - EXTRACT(DAY FROM v.fecha_vuelo)) <= 3;

CREATE OR REPLACE VIEW vista_tripulacion_horas_extra AS
SELECT 
    t.id_tripulante,
    t.nombres || ' ' || t.apellidos AS nombre_tripulante,
    t.tipo_tripulante,
    COUNT(DISTINCT vt.id_vuelo) AS total_vuelos_mes,
    NVL(SUM(vt.horas_trabajadas), 0) AS total_horas_mes,
    ROUND(NVL(AVG(vt.horas_trabajadas), 0), 2) AS promedio_horas_por_vuelo,
    -- CORREGIDO: Horas extra
    SUM(GREATEST(NVL(vt.horas_trabajadas, 0) - 8, 0)) AS horas_extra,
    -- CORREGIDO: Valor de horas extra
    SUM(GREATEST(NVL(vt.horas_trabajadas, 0) - 8, 0) * 1.5) AS horas_extra_valoradas,
    -- CORREGIDO: Lista de vuelos (sin LISTAGG si hay problemas)
    MAX(pv.numero_vuelo) AS ejemplo_vuelo  -- Simplificado para evitar LISTAGG
FROM tripulacion t
LEFT JOIN vuelos_tripulacion vt ON t.id_tripulante = vt.id_tripulante
LEFT JOIN vuelos v ON vt.id_vuelo = v.id_vuelo
LEFT JOIN programas_vuelo pv ON v.id_programa = pv.id_programa
WHERE EXTRACT(MONTH FROM v.fecha_vuelo) = EXTRACT(MONTH FROM SYSDATE)
   OR v.fecha_vuelo IS NULL
GROUP BY t.id_tripulante, t.nombres, t.apellidos, t.tipo_tripulante
HAVING NVL(SUM(vt.horas_trabajadas), 0) > 160
ORDER BY total_horas_mes DESC;

CREATE OR REPLACE VIEW vista_reincidentes_objetos_perdidos AS
SELECT 
    p.id_pasajero,
    p.nombres || ' ' || p.apellidos AS nombre_completo,
    p.email,
    p.telefono,
    COUNT(DISTINCT op.id_objeto) AS objetos_perdidos,
    -- CORREGIDO: Sin LISTAGG (simplificado)
    MAX(op.descripcion) AS ejemplo_objeto,
    MIN(op.fecha_reporte) AS primer_objeto_perdido,
    MAX(op.fecha_reporte) AS ultimo_objeto_perdido,
    COUNT(DISTINCT r.id_reserva) AS viajes_posteriores,
    MIN(r.fecha_reserva) AS primer_viaje_despues,
    -- CORREGIDO: Días entre último objeto y próximo viaje
    ROUND(MIN(CAST(r.fecha_reserva AS DATE) - CAST(op.fecha_reporte AS DATE))) AS dias_hasta_proximo_viaje
FROM pasajeros p
JOIN objetos_perdidos op ON p.id_pasajero = op.id_pasajero_entrega
LEFT JOIN reservas r ON p.id_pasajero = r.id_pasajero 
    AND r.fecha_reserva > op.fecha_reporte
GROUP BY p.id_pasajero, p.nombres, p.apellidos, p.email, p.telefono
HAVING COUNT(DISTINCT op.id_objeto) >= 2
AND COUNT(DISTINCT r.id_reserva) > 0
ORDER BY objetos_perdidos DESC;

CREATE OR REPLACE VIEW vista_comida_especial_medica AS
SELECT 
    v.id_vuelo,
    pv.numero_vuelo,  -- CORREGIDO
    v.fecha_vuelo,
    a.nombre_aerolinea,
    COUNT(DISTINCT r.id_reserva) AS total_reservas,
    COUNT(DISTINCT se.id_solicitud) AS comidas_especiales,
    COUNT(DISTINCT phm.id_historial_medico) AS pasajeros_con_condicion,
    -- CORREGIDO: Sin LISTAGG (simplificado)
    MAX(phm.condicion_medica) AS ejemplo_condicion,
    MAX(se.descripcion) AS ejemplo_comida
FROM vuelos v
JOIN programas_vuelo pv ON v.id_programa = pv.id_programa
JOIN aerolineas a ON pv.id_aerolinea = a.id_aerolinea
JOIN reservas r ON v.id_vuelo = r.id_vuelo
LEFT JOIN solicitudes_especiales se ON r.id_reserva = se.id_reserva 
    AND se.tipo_solicitud = 'COMIDA_ESPECIAL'
LEFT JOIN pasajeros_historial_medico phm ON r.id_pasajero = phm.id_pasajero
GROUP BY v.id_vuelo, pv.numero_vuelo, v.fecha_vuelo, a.nombre_aerolinea
HAVING COUNT(DISTINCT se.id_solicitud) > 0
ORDER BY comidas_especiales DESC;

CREATE OR REPLACE VIEW vista_evaluadores_evaluados AS
SELECT 
    e.id_empleado,
    e.nombres || ' ' || e.apellidos AS nombre_empleado,
    e.cargo,
    e.departamento,
    COUNT(DISTINCT ed.id_evaluacion) AS veces_evaluado,
    ROUND(NVL(AVG(ed.puntuacion_total), 0), 2) AS promedio_calificacion_recibida,
    COUNT(DISTINCT ed2.id_evaluacion) AS veces_como_evaluador,
    ROUND(NVL(AVG(ed2.puntuacion_total), 0), 2) AS promedio_calificaciones_otorgadas,
    -- CORREGIDO: Diferencia sin errores
    ROUND(NVL(AVG(ed.puntuacion_total), 0) - NVL(AVG(ed2.puntuacion_total), 0), 2) AS diferencia_calificacion
FROM empleados e
LEFT JOIN evaluaciones_desempeno ed ON e.id_empleado = ed.id_empleado
LEFT JOIN evaluaciones_desempeno ed2 ON e.id_empleado = ed2.evaluador_id
GROUP BY e.id_empleado, e.nombres, e.apellidos, e.cargo, e.departamento
HAVING COUNT(DISTINCT ed.id_evaluacion) > 0 
AND COUNT(DISTINCT ed2.id_evaluacion) > 0
ORDER BY diferencia_calificacion DESC;

CREATE OR REPLACE VIEW vista_viajeros_con_mascotas AS
SELECT 
    p.id_pasajero,
    p.nombres || ' ' || p.apellidos AS nombre_dueno,
    p.email,
    p.telefono,
    COUNT(DISTINCT pm.id_mascota) AS total_mascotas,
    -- CORREGIDO: Sin LISTAGG
    MAX(pm.nombre_mascota || ' (' || pm.tipo_mascota || ')') AS ejemplo_mascota,
    COUNT(DISTINCT r.id_reserva) AS viajes_con_mascota,
    MIN(r.fecha_reserva) AS primer_viaje_mascota,
    MAX(r.fecha_reserva) AS ultimo_viaje_mascota,
    -- CORREGIDO: Lista de vuelos simplificada
    MAX(pv.numero_vuelo) AS ejemplo_vuelo
FROM pasajeros p
JOIN pasajeros_mascotas pm ON p.id_pasajero = pm.id_pasajero
JOIN reservas r ON p.id_pasajero = r.id_pasajero AND pm.id_reserva = r.id_reserva
JOIN vuelos v ON r.id_vuelo = v.id_vuelo
JOIN programas_vuelo pv ON v.id_programa = pv.id_programa
WHERE pm.autorizado = 1
GROUP BY p.id_pasajero, p.nombres, p.apellidos, p.email, p.telefono
ORDER BY viajes_con_mascota DESC;



CREATE OR REPLACE VIEW vista_quejas_equipaje_por_aerolinea AS
SELECT 
    a.id_aerolinea,
    a.nombre_aerolinea,
    a.codigo_iata,
    COUNT(DISTINCT q.id_queja) AS total_quejas,
    SUM(CASE WHEN q.tipo_contacto = 'QUEJA' AND q.area_relacionada = 'EQUIPAJE' THEN 1 ELSE 0 END) AS quejas_equipaje,
    -- CORREGIDO: Porcentaje sin división por cero
    ROUND(
        SUM(CASE WHEN q.tipo_contacto = 'QUEJA' AND q.area_relacionada = 'EQUIPAJE' THEN 1 ELSE 0 END) * 100.0 / 
        NULLIF(COUNT(DISTINCT q.id_queja), 0), 2) AS porcentaje_quejas_equipaje,
    COUNT(DISTINCT v.id_vuelo) AS total_vuelos_periodo,
    -- CORREGIDO: Tasa por 1000 vuelos
    ROUND(
        SUM(CASE WHEN q.tipo_contacto = 'QUEJA' AND q.area_relacionada = 'EQUIPAJE' THEN 1 ELSE 0 END) * 1000.0 / 
        NULLIF(COUNT(DISTINCT v.id_vuelo), 0), 2) AS quejas_equipaje_por_1000_vuelos
FROM aerolineas a
LEFT JOIN programas_vuelo pv ON a.id_aerolinea = pv.id_aerolinea
LEFT JOIN vuelos v ON pv.id_programa = v.id_programa 
    AND v.fecha_vuelo BETWEEN ADD_MONTHS(SYSDATE, -6) AND SYSDATE
LEFT JOIN quejas_sugerencias q ON v.id_vuelo = q.id_vuelo
GROUP BY a.id_aerolinea, a.nombre_aerolinea, a.codigo_iata
HAVING SUM(CASE WHEN q.tipo_contacto = 'QUEJA' AND q.area_relacionada = 'EQUIPAJE' THEN 1 ELSE 0 END) > 0
ORDER BY quejas_equipaje_por_1000_vuelos DESC;




CREATE OR REPLACE VIEW vista_pasajeros_multipago AS
SELECT 
    p.id_pasajero,
    p.nombres || ' ' || p.apellidos AS nombre_completo,
    p.email,
    COUNT(DISTINCT r.id_reserva) AS total_reservas,
    COUNT(DISTINCT rp.id_metodo_pago) AS metodos_pago_distintos,
    -- CORREGIDO: Sin LISTAGG (simplificado)
    MAX(mp.descripcion) AS ejemplo_metodo_pago,
    SUM(rp.monto) AS gasto_total,
    ROUND(AVG(rp.monto), 2) AS gasto_promedio_por_pago,
    MIN(rp.fecha_pago) AS primer_pago,
    MAX(rp.fecha_pago) AS ultimo_pago,
    -- CORREGIDO: Categoría basada en métodos
    CASE 
        WHEN COUNT(DISTINCT rp.id_metodo_pago) >= 3 THEN 'Frecuente multipago'
        WHEN COUNT(DISTINCT rp.id_metodo_pago) = 2 THEN 'Ocasional multipago'
        ELSE 'Monometodo'
    END AS categoria_pago
FROM pasajeros p
JOIN reservas r ON p.id_pasajero = r.id_pasajero
JOIN reservas_pagos rp ON r.id_reserva = rp.id_reserva
JOIN metodos_pago mp ON rp.id_metodo_pago = mp.id_metodo_pago
GROUP BY p.id_pasajero, p.nombres, p.apellidos, p.email
HAVING COUNT(DISTINCT rp.id_metodo_pago) >= 2
ORDER BY metodos_pago_distintos DESC, gasto_total DESC;




