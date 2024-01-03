USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_recuperar] Fecha del script: 2024-01-03 10:44:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_carrera_recuperar]
	@codigo_carrera varchar(50) = ''
AS
	UPDATE CARRERA
	SET estado = 0
	WHERE codigo_carrera = @codigo_carrera

RETURN 0
