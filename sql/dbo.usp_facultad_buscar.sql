USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_buscar] Fecha del script: 2024-01-03 10:38:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_facultad_buscar]
	@texto varchar(100) = ''
AS
	SELECT id, nombre_facultad, codigo_facultad, creado_tmstp, actualizado_tmstp
	FROM FACULTAD
	WHERE estado = 0
	AND (	UPPER(nombre_facultad) LIKE '%' + UPPER(@texto) + '%' OR
			UPPER(codigo_facultad) LIKE '%' + UPPER(@texto) + '%' )
RETURN 0
