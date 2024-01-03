USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_actualizar_nombre] Fecha del script: 2024-01-03 2:07:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_carrera_actualizar_nombre]
	@nombre_carrera varchar(100) = '',
	@codigo_carrera varchar(50) = ''
AS
	UPDATE CARRERA
	SET nombre_carrera = @nombre_carrera
	WHERE codigo_carrera = @codigo_carrera
	
RETURN 0
