```sql
-- ==========================================================================================
-- 🗄️ 1. CREACIÓN DE LA BASE DE DATOS
-- ==========================================================================================

-- 📌 Explicación: Crea la base de datos llamada 'agenda' y la selecciona por defecto con 'USE' 
-- para que todas las tablas y datos que ejecutemos a continuación se guarden dentro de ella.
CREATE DATABASE agenda;
USE agenda;

-- ==========================================================================================
-- 📋 2. CREACIÓN DE LA TABLA PRINCIPAL (Padre)
-- ==========================================================================================

-- 📌 Explicación: Construye la tabla 'datos_personales' para almacenar la información 
-- básica de los estudiantes. Define 'id' como clave primaria (PRIMARY KEY) que se 
-- autoincrementa sola (AUTO_INCREMENT) con cada nuevo registro que agregues.
CREATE TABLE datos_personales (
    id INT AUTO_INCREMENT PRIMARY KEY,
    apellido_paterno VARCHAR(50),
    apellido_materno VARCHAR(50),
    nombres VARCHAR(50),
    curp VARCHAR(18),
    fecha_nacimiento DATE,
    semestre INT,
    sexo CHAR(1),
    telefono VARCHAR(10)
);

-- ==========================================================================================
-- 📍 3. CREACIÓN DE LA TABLA SECUNDARIA (Hija)
-- ==========================================================================================

-- 📌 Explicación: Crea la tabla 'direccion' para los datos de contacto y la foto de perfil. 
-- Utiliza 'id_datos' como llave foránea (FOREIGN KEY) para vincularse estrictamente con el 'id' 
-- de la tabla principal. La instrucción 'ON DELETE CASCADE' es crucial: si borras un 
-- alumno de la tabla principal, su dirección se borrará automáticamente para no dejar basura.
CREATE TABLE direccion (
    id_direccion INT AUTO_INCREMENT PRIMARY KEY,
    id_datos INT,
    direccion VARCHAR(255),
    correo VARCHAR(100),
    contacto_emergencia VARCHAR(10),
    tipo_sangre VARCHAR(5),
    foto LONGBLOB,
    FOREIGN KEY (id_datos) REFERENCES datos_personales(id) ON DELETE CASCADE
);

-- ==========================================================================================
-- 🧑‍🎓 4. INSERCIÓN DE DATOS PERSONALES (20 Registros Iniciales)
-- ==========================================================================================

-- 📌 Explicación: Inserta 20 registros de prueba en la tabla principal. Como el 'id' es 
-- autoincrementable, omitimos esa columna y MySQL les asignará automáticamente los números del 1 al 20.
INSERT INTO datos_personales (apellido_paterno, apellido_materno, nombres, curp, fecha_nacimiento, semestre, sexo, telefono) VALUES
('Piña', 'Ríos', 'Fernando Emmanuel', 'PIRF041107HSRX00', '2004-11-07', 4, 'M', '6691002000'),
('Sánchez', 'García', 'César', 'SAGC030510HSRX00', '2003-05-10', 4, 'M', '6691002001'),
('Carmona', 'López', 'Israel', 'CALI030815HSRX00', '2003-08-15', 4, 'M', '6691002002'),
('Lugo', 'Martínez', 'Omar', 'LUMO031220HSRX00', '2003-12-20', 4, 'M', '6691002003'),
('Gómez', 'Pérez', 'María', 'GOPM040101MSRX00', '2004-01-01', 4, 'F', '6691002004'),
('Ruiz', 'Díaz', 'Ana', 'RUDA040202MSRX00', '2004-02-02', 4, 'F', '6691002005'),
('Hernández', 'Cruz', 'Luis', 'HECL040303HSRX00', '2004-03-03', 2, 'M', '6691002006'),
('Flores', 'Reyes', 'Diana', 'FLRD040404MSRX00', '2004-04-04', 2, 'F', '6691002007'),
('Torres', 'Mora', 'Jorge', 'TOMJ040505HSRX00', '2004-05-05', 3, 'M', '6691002008'),
('Ramírez', 'Luna', 'Sofía', 'RALS040606MSRX00', '2004-06-06', 3, 'F', '6691002009'),
('Jiménez', 'Salas', 'Raúl', 'JISR040707HSRX00', '2004-07-07', 5, 'M', '6691002010'),
('Moreno', 'Ríos', 'Carmen', 'MORC040808MSRX00', '2004-08-08', 5, 'F', '6691002011'),
('Vargas', 'Silva', 'Diego', 'VASD040909HSRX00', '2004-09-09', 1, 'M', '6691002012'),
('Castro', 'Ortiz', 'Elena', 'CAOE041010MSRX00', '2004-10-10', 1, 'F', '6691002013'),
('Ortiz', 'Guzmán', 'Pablo', 'ORGP041111HSRX00', '2004-11-11', 2, 'M', '6691002014'),
('Rojas', 'Méndez', 'Laura', 'ROML041212MSRX00', '2004-12-12', 2, 'F', '6691002015'),
('Mendoza', 'Vega', 'Hugo', 'MEVH050113HSRX00', '2005-01-13', 6, 'M', '6691002016'),
('Delgado', 'Peña', 'Rosa', 'DEPR050214MSRX00', '2005-02-14', 6, 'F', '6691002017'),
('Núñez', 'Suárez', 'Daniel', 'NUSD050315HSRX00', '2005-03-15', 7, 'M', '6691002018'),
('Navarro', 'Soto', 'Valeria', 'NASV050416MSRX00', '2005-04-16', 7, 'F', '6691002019');

-- ==========================================================================================
-- 🏠 5. INSERCIÓN DE DIRECCIONES Y CONTACTO (20 Registros Vinculados)
-- ==========================================================================================

-- 📌 Explicación: Inserta los datos de contacto correspondientes a los 20 alumnos anteriores. 
-- Aquí sí tenemos que indicar manualmente el 'id_datos' (del 1 al 20) para asegurar que 
-- cada dirección quede amarrada exactamente al estudiante correcto de la tabla padre.
INSERT INTO direccion (id_datos, direccion, correo, contacto_emergencia, tipo_sangre, foto) VALUES
(1, 'Av. Ejército Mexicano #123', 'fernando.pina@email.com', '6695001000', 'O+', ''),
(2, 'Col. Centro #456', 'cesar.sanchez@email.com', '6695001001', 'A+', ''),
(3, 'Prados del Sol #789', 'israel.carmona@email.com', '6695001002', 'B+', ''),
(4, 'Villa Galaxia #321', 'omar.lugo@email.com', '6695001003', 'O-', ''),
(5, 'Real del Valle #654', 'maria.gomez@email.com', '6695001004', 'AB+', ''),
(6, 'Hacienda Victoria #987', 'ana.ruiz@email.com', '6695001005', 'A-', ''),
(7, 'Fracc. Gaviotas #111', 'luis.hernandez@email.com', '6695001006', 'O+', ''),
(8, 'Col. Benito Juárez #222', 'diana.flores@email.com', '6695001007', 'B-', ''),
(9, 'Lomas de Mazatlán #333', 'jorge.torres@email.com', '6695001008', 'O+', ''),
(10, 'Sábalo Country #444', 'sofia.ramirez@email.com', '6695001009', 'A+', ''),
(11, 'El Dorado #555', 'raul.jimenez@email.com', '6695001010', 'O-', ''),
(12, 'Playas del Sur #666', 'carmen.moreno@email.com', '6695001011', 'AB-', ''),
(13, 'Col. Francisco Villa #777', 'diego.vargas@email.com', '6695001012', 'O+', ''),
(14, 'Villas del Estero #888', 'elena.castro@email.com', '6695001013', 'A+', ''),
(15, 'Paseo Alameda #999', 'pablo.ortiz@email.com', '6695001014', 'B+', ''),
(16, 'Col. Montuosa #101', 'laura.rojas@email.com', '6695001015', 'O+', ''),
(17, 'Fracc. El Toreo #202', 'hugo.mendoza@email.com', '6695001016', 'A-', ''),
(18, 'Los Mangos #303', 'rosa.delgado@email.com', '6695001017', 'O+', ''),
(19, 'Col. Reforma #404', 'daniel.nunez@email.com', '6695001018', 'B-', ''),
(20, 'Palos Prietos #505', 'valeria.navarro@email.com', '6695001019', 'AB+', '');
```

