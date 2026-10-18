-- phpMyAdmin SQL Dump
-- version 5.2.3deb1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost:3306
-- Tiempo de generación: 18-10-2026 a las 20:16:41
-- Versión del servidor: 8.4.11-0ubuntu0.26.04.1
-- Versión de PHP: 8.5.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `agenda`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `datos_personales`
--

CREATE TABLE `datos_personales` (
  `id` int NOT NULL,
  `apellido_paterno` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `apellido_materno` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `nombres` varchar(40) COLLATE utf8mb4_general_ci NOT NULL,
  `curp` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `fecha_nacimiento` date NOT NULL,
  `semestre` int NOT NULL,
  `sexo` char(1) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `telefono` varchar(15) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `datos_personales`
--

INSERT INTO `datos_personales` (`id`, `apellido_paterno`, `apellido_materno`, `nombres`, `curp`, `fecha_nacimiento`, `semestre`, `sexo`, `telefono`) VALUES
(1, 'Piña', 'Ríos', 'Fernando Emmanuel', 'PIRF041107HSRX00PP', '2004-11-07', 5, 'M', '6691002000'),
(2, 'Sánchez', 'García', 'César Adrian', 'SAGC030510HSRX00', '2003-05-10', 4, 'M', '6691002001'),
(3, 'Carmona', 'López', 'Israel', 'CALI030815HSRX00', '2003-08-15', 4, 'M', '6691002002'),
(4, 'Lugo', 'Martínez', 'Omar', 'LUMO031220HSRX00', '2003-12-20', 4, 'M', '6691002003'),
(5, 'Gómez', 'Pérez', 'María', 'GOPM040101MSRX00', '2004-01-01', 4, 'F', '6691002004'),
(6, 'Ruiz', 'Díaz', 'Ana Laura', 'RUDA040202MSRX00', '2004-02-02', 4, 'F', '6691002005'),
(7, 'Hernández', 'Cruz', 'Luis', 'HECL040303HSRX00', '2004-03-03', 2, 'M', '6691002006'),
(8, 'Flores', 'Reyes', 'Diana', 'FLRD040404MSRX00', '2004-04-04', 2, 'F', '6691002007'),
(9, 'Torres', 'Mora', 'Jorge', 'TOMJ040505HSRX00', '2004-05-05', 3, 'M', '6691002008'),
(10, 'Ramírez', 'Luna', 'Sofía', 'RALS040606MSRX00', '2004-06-06', 3, 'F', '6691002009'),
(11, 'Jiménez', 'Salas', 'Raúl', 'JISR040707HSRX00', '2004-07-07', 5, 'M', '6691002010'),
(12, 'Moreno', 'Ríos', 'Carmen', 'MORC040808MSRX00', '2004-08-08', 5, 'F', '6691002011'),
(13, 'Vargas', 'Silva', 'Diego', 'VASD040909HSRX00', '2004-09-09', 1, 'M', '6691002012'),
(14, 'Castro', 'Ortiz', 'Elena', 'CAOE041010MSRX00', '2004-10-10', 1, 'F', '6691002013'),
(15, 'Picaso', 'Guzman', 'Pablo', 'GPP125376HSLNRSA8A', '2004-11-11', 2, 'M', '6691002014'),
(16, 'Rojas', 'Méndez', 'Laura', 'ROML041212MSRX00', '2004-12-12', 2, 'F', '6691002015'),
(17, 'Mendoza', 'Vega', 'Hugo', 'MEVH050113HSRX00', '2005-01-13', 6, 'M', '6691002016'),
(18, 'Delgado', 'Peña', 'Rosa', 'DEPR050214MSRX00', '2005-02-14', 6, 'F', '6691002017'),
(19, 'Núñez', 'Suárez', 'Daniel', 'NUSD050315HSRX00', '2005-03-15', 7, 'M', '6691002018'),
(20, 'Navarro', 'Soto', 'Valeria', 'NASV050416MSRX00', '2005-04-16', 7, 'F', '6691002019'),
(22, 'Jose', 'De Dominguez', 'Josefa', 'DJJ130594HSLANREAS', '2000-09-01', 9, 'F', '6692457387');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `datos_personales`
--
ALTER TABLE `datos_personales`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `datos_personales`
--
ALTER TABLE `datos_personales`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
