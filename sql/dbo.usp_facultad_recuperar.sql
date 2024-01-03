USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_recuperar] Fecha del script: 2024-01-03 1:30:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_facultad_recuperar]
	@codigo_facultad varchar(50) = ''
AS
	UPDATE FACULTAD
	SET estado = 0
	WHERE codigo_facultad = @codigo_facultad

RETURN 0
