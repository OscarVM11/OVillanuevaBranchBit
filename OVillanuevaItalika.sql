CREATE DATABASE OVillanuevaItalika

GO

USE OVillanuevaItalika

GO

CREATE TABLE Tipo(
	IdTipo int IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(15)
)

	INSERT INTO Tipo VALUES('Scooter')
	INSERT INTO Tipo VALUES('Trabajo')
	INSERT INTO Tipo VALUES('Deportiva')
	INSERT INTO Tipo VALUES('Cafe Racer')
	INSERT INTO Tipo VALUES('Doble Proposito')
	INSERT INTO Tipo VALUES('Cuatrimoto')
	INSERT INTO Tipo VALUES('Linea Z')
	INSERT INTO Tipo VALUES('Chopper')
	INSERT INTO Tipo VALUES('Adventure')

	GO

	CREATE PROCEDURE TipoGet
	AS
	SELECT 
		IdTipo, Nombre
	FROM Tipo

	GO

	CREATE PROCEDURE GetByTipo
	@IdTipo int
	as
	SELECT 
		IdTipo, 
		Nombre		
	FROM Tipo
	WHERE IdTipo = @IdTipo

	

GO

CREATE TABLE Producto(
	SKU varchar(20) PRIMARY KEY,
	Fert varchar(20),
	Modelo varchar(20),
	Tipo int FOREIGN KEY REFERENCES Tipo(IdTipo),
	NumeroDeSerie varchar(20),
	Fecha date
)

GO

	ALTER TABLE Producto ALTER COLUMN Fecha datetime

	GO

	INSERT INTO Producto VALUES('1G25T77D23', 'V8E62S59E8', 'TC 200', 8,'7869126843201425', GETDATE())
	INSERT INTO Producto VALUES('2DF896GH85', 'P85OI2TT25', 'WS 175 Sport', 1,'7852369874125632', '5/25/2020')
	INSERT INTO Producto VALUES('9ER2E2S85E', 'I41R11D44F', 'Vort X', 3,'8569742358015269', '12/14/2020')
	INSERT INTO Producto VALUES('8D5E52DE7Y', 'V2S2S5S6R5', 'DM 250', 5,'2569874036589452', '01/15/2021')
	INSERT INTO Producto VALUES('78ER7R4S44', 'N8G7DW41DE', 'DT 150', 2,'8752369802458635', GETDATE())
	INSERT INTO Producto VALUES('FD4E5E120D', 'UY41Y00W58', 'SPT Fire', 4,'5898756985012574', '02/02/21')
	INSERT INTO Producto VALUES('MH1F4F7W4E', 'R8RF2S2E0E', 'RT 250', 3,'0236987458201452', GETDATE())

	GO

	CREATE PROCEDURE ProductoGet
	AS
	SELECT 
		Producto.SKU, 
		Producto.Fert,
		Producto.Modelo,
		Tipo.Nombre,
		Producto.NumeroDeSerie,
		Producto.Fecha
	FROM Producto
	INNER JOIN Tipo ON Producto.Tipo = Tipo.IdTipo

	GO

	CREATE PROCEDURE ProductoAdd
	@SKU varchar(20),
	@Fert varchar(20),
	@Modelo varchar(20),
	@Tipo int,
	@NumeroDeSerie varchar(20),
	@Fecha date
	as
	INSERT INTO [Producto]([SKU],[Fert],[Modelo],[Tipo],[NumeroDeSerie],[Fecha]) 
	VALUES (@SKU, @Fert, @Modelo,@Tipo,@NumeroDeSerie,@Fecha)


	GO

	CREATE PROCEDURE ProductoGetBySKU
	@SKU varchar(20)
	as
	SELECT 
		Producto.SKU, 
		Producto.Fert,
		Producto.Modelo,
		Tipo.Nombre,
		Producto.NumeroDeSerie,
		Producto.Fecha
	FROM Producto
	INNER JOIN Tipo ON Producto.Tipo = Tipo.IdTipo
	WHERE Producto.SKU = @SKU

	GO

	CREATE PROCEDURE ProductoGetByModelo
	@Modelo varchar(20)
	as
	SELECT 
		Producto.SKU, 
		Producto.Fert,
		Producto.Modelo,
		Tipo.Nombre,
		Producto.NumeroDeSerie,
		Producto.Fecha
	FROM Producto
	INNER JOIN Tipo ON Producto.Tipo = Tipo.IdTipo
	WHERE Producto.Modelo = @Modelo

	GO

	CREATE PROCEDURE ProductoUpdate
	@SKU varchar(20),
	@Fert varchar(20),
	@Modelo varchar(20),
	@Tipo int,
	@NumeroDeSerie varchar(20),
	@Fecha date
	as
	UPDATE 
		Producto 
		SET 
			SKU = @SKU, 
			Fert = @Fert, 
			Modelo = @Modelo, 
			Tipo = @Tipo, 
			NumeroDeSerie = @NumeroDeSerie,
			Fecha = @Fecha 
		WHERE SKU = @SKU

	GO
	
	CREATE PROCEDURE ProductoDelete
	@SKU varchar(20)
	as
	DELETE FROM Producto WHERE SKU = @SKU