USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_eliminar] Fecha del script: 2024-01-03 10:07:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_carrera_eliminar]
	@codigo_carrera varchar(100) = ''
AS
	DECLARE @id INT
	SET @id = 0

	SELECT @id = id FROM CARRERA WHERE @codigo_carrera = codigo_carrera
	IF @@ROWCOUNT <= 0 BEGIN
		SELECT 300
		RETURN 0
	END 

	DELETE FROM CARRERA
	WHERE id = @id

	SELECT 0
RETURN 0
