-- Crear base de datos
DROP DATABASE IF EXISTS universidad_don_bosco;
CREATE DATABASE IF NOT EXISTS universidad_don_bosco;
USE universidad_don_bosco;

-- Tabla de alumnos
CREATE TABLE alumnos (
    id_alumno INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    carnet VARCHAR(20) NOT NULL UNIQUE,
    carrera VARCHAR(100) NOT NULL,
    correo VARCHAR(100) NOT NULL UNIQUE,
    foto LONGBLOB -- Para almacenar la imagen en formato binario
);

-- Tabla de materias
CREATE TABLE materias (
    id_materia INT AUTO_INCREMENT PRIMARY KEY,
    nombre_materia VARCHAR(100) NOT NULL,
    carrera VARCHAR(100) NOT NULL, -- Carrera a la que pertenece la materia
    laboratorio BOOLEAN DEFAULT FALSE -- Indica si la materia tiene laboratorio
);

-- Tabla de inscripciones
CREATE TABLE inscripciones (
    id_inscripcion INT AUTO_INCREMENT PRIMARY KEY,
    id_alumno INT,
    id_materia INT,
    fecha_inscripcion DATE NOT NULL,
    total_pagar DECIMAL(10,2) NOT NULL, -- Total a pagar por la inscripción
    FOREIGN KEY (id_alumno) REFERENCES alumnos(id_alumno),
    FOREIGN KEY (id_materia) REFERENCES materias(id_materia)
);

-- Tabla de usuarios (para el login)
CREATE TABLE usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL -- Se debe almacenar de forma encriptada
);

-- Insertar el usuario "Tony_Kros"
INSERT INTO usuarios (usuario, password) 
VALUES ('Tony_Kros', 'RM1524'); -- Guardamos la contraseña encriptada
SELECT * from usuarios;