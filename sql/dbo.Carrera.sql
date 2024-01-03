USE UNIVERSIDAD
GO

CREATE TABLE [dbo].[CARRERA] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    facultad            INT NOT NULL DEFAULT 0,
    [nombre_carrera]   VARCHAR (100) NOT NULL,
    [codigo_carrera]   VARCHAR (50)  NOT NULL,
    [creado_tmstp]      DATETIME      NOT NULL DEFAULT GETDATE(),
    [actualizado_tmstp] DATETIME      NOT NULL DEFAULT GETDATE(),
    [estado]            INT           NOT NULL DEFAULT 0,
    CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [UK_Carrera] UNIQUE NONCLUSTERED ([codigo_carrera])
);