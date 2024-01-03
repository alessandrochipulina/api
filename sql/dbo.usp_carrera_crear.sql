USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_carrera_crear] Fecha del script: 2024-01-03 3:37:48 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_carrera_crear]
	@nombre_carrera varchar(100) = '',
	@codigo_carrera varchar(50) = '',
	@codigo_facultad varchar(50) = ''
AS
	DECLARE @id INT
	SET @id = 0

	SELECT @id = id FROM FACULTAD WHERE @codigo_facultad = codigo_facultad
	IF @@ROWCOUNT <= 0 BEGIN
		SELECT 100 as Result
		RETURN 0
	END

	INSERT INTO CARRERA( nombre_carrera, codigo_carrera, facultad )
	VALUES( @nombre_carrera, @codigo_carrera, @id )
	SELECT 0 as Result
RETURN 0
