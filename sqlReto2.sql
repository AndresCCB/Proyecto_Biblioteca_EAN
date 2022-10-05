 --Creacion de la Base de Datos
CREATE DATABASE BibliotecaEan

--Usar la base de datos
USE BibliotecaEan

--Crear la tabla
CREATE TABLE Libros(
	codigo INT IDENTITY(1,1) NOT NULL,
	titulo VARCHAR(40) NOT NULL,
	autor VARCHAR(30) NOT NULL,
	editorial VARCHAR(20),
	precio DECIMAL(5,2) NOT NULL,
	cantidad SMALLINT NOT NULL,
	PRIMARY KEY(codigo)
)

--PROCEDIMIENTOSA ALMACENADOS...............

--para listar los libros
CREATE PROCEDURE listar_libros
as
SELECT *
FROM Libros
ORDER BY codigo;

--para bucar los libros por titulo
CREATE PROCEDURE buscar_libros_titulo --para buscar por titulo
@titulo VARCHAR(40)
as
SELECT * 
FROM Libros
WHERE  (titulo LIKE '%' + @titulo + '%');

--Buscar los libros por autor
CREATE PROCEDURE buscar_libros_autor --para buscar por autor
@autor VARCHAR(30)
as
SELECT * 
FROM Libros
WHERE  (autor LIKE '%' + @autor + '%');

--Buscar los libros por codigo
CREATE PROCEDURE buscar_libros_codigo --para buscar por codigo
@codigo int
as
SELECT * 
FROM Libros
WHERE  (codigo = @codigo);

--Para registrar, actualizar y eliminar registros
CREATE PROCEDURE mantenimiento_libros
@codigo INT,
@titulo VARCHAR(40),
@autor VARCHAR(30),
@editorial VARCHAR(20),
@precio DECIMAL(5,2),
@cantidad SMALLINT,
@accion VARCHAR(50) OUTPUT
as
IF(@accion = '1') --REGISTRAR
BEGIN
	INSERT INTO BibliotecaEan.dbo.Libros
	VALUES(@titulo, @autor, @editorial, @precio, @cantidad)
	SET @accion = 'Se registro el libro: ' + @titulo
END
ELSE IF(@accion = '2') --ACTUALIZAR
BEGIN
	UPDATE BibliotecaEan.dbo.Libros SET titulo = @titulo, 
	autor = @autor, editorial = @editorial,
	precio = @precio, cantidad = @cantidad
	WHERE CONVERT(varchar,codigo) = CONVERT(varchar,@codigo)
	SET @accion = 'Se modifico el codigo: ' + CONVERT(varchar(10), @codigo)
END
ELSE IF(@accion = '3') --ELIMINAR
BEGIN
	DELETE FROM BibliotecaEan.dbo.Libros WHERE (codigo = @codigo) OR (titulo = @titulo)
	SET @accion = 'Se borro el registro con codigo: ' + CONVERT(varchar(10), @codigo)
END;

DROP PROCEDURE buscar_libros_titulo --eliminar un procedimiento
DROP PROCEDURE buscar_libros_autor
DROP PROCEDURE buscar_libros_codigo
DROP PROCEDURE mantenimiento_libros
DROP PROCEDURE listar_libros


--PRUEBAS
INSERT INTO Libros
VALUES('Cronicas de una muerte anunciada', 'Pedro Gabriel', 'Norma', 200, 2)

INSERT INTO Libros
VALUES('Cien año de soledad', 'Gabriel Garcia Marquez', 'Vintage', 800, 18)

SELECT * FROM Libros

UPDATE Libros SET titulo = 'Porfi', 
	autor = 'yo', editorial = 'casa',
	precio = 123, cantidad = 2
	WHERE codigo = 3