USE Negocios2022
GO

IF (OBJECT_ID('uspListarEmpleados') IS NOT NULL) 
BEGIN
	DROP PROCEDURE uspListarEmpleados;
END
GO

CREATE PROCEDURE uspListarEmpleados AS
BEGIN
	SELECT IdEmpleado, ApeEmpleado, NomEmpleado, FecNac, DirEmpleado, idDistrito, fonoEmpleado, idCargo, FecContrata 
	FROM RRHH.empleados;
END
GO

IF (OBJECT_ID('uspListarDistritos') IS NOT NULL) 
BEGIN
	DROP PROCEDURE uspListarDistritos;
END
GO

CREATE PROCEDURE uspListarDistritos AS
BEGIN
	SELECT idDistrito, nomDistrito 
	FROM RRHH.Distritos;
END
GO

IF (OBJECT_ID('uspListarCargos') IS NOT NULL) 
BEGIN
	DROP PROCEDURE uspListarCargos;
END
GO

CREATE PROCEDURE uspListarCargos AS
BEGIN
	SELECT idcargo, desCargo
	FROM RRHH.Cargos;
END
GO

IF (OBJECT_ID('uspObtenerEmpleado') IS NOT NULL) 
BEGIN
	DROP PROCEDURE uspObtenerEmpleado;
END
GO

CREATE PROCEDURE uspObtenerEmpleado 
@idEmpleado INT
AS
BEGIN
	SELECT IdEmpleado, ApeEmpleado, NomEmpleado, FecNac, DirEmpleado, idDistrito, fonoEmpleado, idCargo, FecContrata 
	FROM RRHH.empleados
	WHERE IdEmpleado = @idEmpleado
END
GO

IF (OBJECT_ID('uspRegistrarEmpleado') IS NOT NULL) 
BEGIN
	DROP PROCEDURE uspRegistrarEmpleado;
END
GO

CREATE PROCEDURE uspRegistrarEmpleado
@IdEmpleado INT,
@ApeEmpleado VARCHAR(50),
@NomEmpleado VARCHAR(50),
@FecNac DATETIME,
@DirEmpleado VARCHAR(60),
@idDistrito INT,
@fonoEmpleado VARCHAR(15),
@idCargo INT,
@FecContrata DATETIME
AS
BEGIN
	INSERT INTO RRHH.empleados(IdEmpleado, ApeEmpleado, NomEmpleado, FecNac, DirEmpleado, idDistrito, fonoEmpleado, idCargo, FecContrata)
	VALUES (@IdEmpleado, @ApeEmpleado, @NomEmpleado, @FecNac, @DirEmpleado, @idDistrito, @fonoEmpleado, @idCargo, @FecContrata)
END
GO

IF (OBJECT_ID('uspActualizarEmpleado') IS NOT NULL) 
BEGIN
	DROP PROCEDURE uspActualizarEmpleado;
END
GO

CREATE PROCEDURE uspActualizarEmpleado
@idEmpleado INT,
@ApeEmpleado VARCHAR(50),
@NomEmpleado VARCHAR(50),
@FecNac DATETIME,
@DirEmpleado VARCHAR(60),
@idDistrito INT,
@fonoEmpleado VARCHAR(15),
@idCargo INT,
@FecContrata DATETIME
AS
BEGIN
	UPDATE RRHH.empleados 
	SET ApeEmpleado = @ApeEmpleado, NomEmpleado = @NomEmpleado, FecNac = @FecNac, DirEmpleado = @DirEmpleado, idDistrito = @idDistrito, fonoEmpleado = @fonoEmpleado, idCargo = @idCargo, FecContrata = @FecContrata
	WHERE idEmpleado = @idEmpleado
END
GO


IF (OBJECT_ID('uspEliminarEmpleado') IS NOT NULL) 
BEGIN
	DROP PROCEDURE uspEliminarEmpleado;
END
GO

CREATE PROCEDURE uspEliminarEmpleado
@idEmpleado INT
AS
BEGIN
	DELETE FROM RRHH.empleados
	WHERE IdEmpleado = @idEmpleado;
END
GO