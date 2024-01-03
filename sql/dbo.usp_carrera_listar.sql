USE [UNIVERSIDAD]
GO

/****** Objeto: SqlProcedure [dbo].[usp_facultad_listar] Fecha del script: 2024-01-03 10:13:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_carrera_listar]
	@texto varchar(100) = ''
AS
	SELECT	c.id, c.nombre_carrera, c.codigo_carrera, f.nombre_facultad, 
			c.creado_tmstp, c.actualizado_tmstp
	FROM CARRERA c
	INNER JOIN FACULTAD f ON c.facultad = f.id
	WHERE c.estado = 0
	
RETURN 0
