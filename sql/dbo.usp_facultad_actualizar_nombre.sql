USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_buscar] Fecha del script: 2024-01-03 1:35:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_facultad_actualizar_nombre]
	@nombre_facultad varchar(100) = '',
	@codigo_facultad varchar(50) = ''
AS
	UPDATE FACULTAD
	SET nombre_facultad = @nombre_facultad
	WHERE codigo_facultad = @codigo_facultad
	
RETURN 0
