-- Crear la base de datos PracticeBlazor
CREATE DATABASE PracticeBlazor
GO

USE PracticeBlazor
GO

-- Crear la tabla de Cliente
CREATE TABLE Cliente
(
	Id INT IDENTITY (1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	Apellido VARCHAR(50) NOT NULL,
	Direccion VARCHAR(255)
);
GO