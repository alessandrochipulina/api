USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_listar] Fecha del script: 2024-01-03 10:41:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_facultad_listar]
AS
	SELECT id, nombre_facultad, codigo_facultad, creado_tmstp, actualizado_tmstp
	FROM FACULTAD
	WHERE estado = 0
RETURN 0
