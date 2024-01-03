USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_buscar] Fecha del script: 2024-01-03 9:56:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_carrera_buscar]
	@texto varchar(100) = ''
AS
	SELECT 
		c.id, c.nombre_carrera, c.codigo_carrera, 
		f.nombre_facultad, c.creado_tmstp, c.actualizado_tmstp
	FROM CARRERA c
	INNER JOIN FACULTAD f ON c.facultad = f.id
	WHERE c.estado = 0
	AND (	UPPER(nombre_carrera) LIKE '%' + UPPER(@texto) + '%' OR
			UPPER(codigo_carrera) LIKE '%' + UPPER(@texto) + '%' )
RETURN 0
