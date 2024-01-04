USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_eliminar] Fecha del script: 2024-01-04 3:48:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_facultad_eliminar]
	@codigo_facultad varchar(100) = '',
	@codigo_facultad_new varchar(100) = ''
AS
	DECLARE @id INT
	DECLARE @id_new INT
	DECLARE @cantidad INT
	SET @id = 0
	SET @id_new = 0
	SET @cantidad = 0

	SELECT @id = id FROM FACULTAD WHERE @codigo_facultad = codigo_facultad
	IF @@ROWCOUNT <= 0 BEGIN
		SELECT 300 as result
		RETURN 0
	END 

	SELECT * FROM CARRERA WHERE facultad = @id
	IF @@ROWCOUNT > 0 BEGIN 
		SELECT @id_new = id FROM FACULTAD WHERE @codigo_facultad_new = codigo_facultad
		IF @@ROWCOUNT <= 0 BEGIN 
			SELECT 400 as result
			RETURN 0
		END
		
		UPDATE CARRERA
		SET facultad = @id_new
		WHERE facultad = @id
	END

	DELETE FROM FACULTAD
	WHERE codigo_facultad = @codigo_facultad

	SELECT 0 as result
		
RETURN 0
