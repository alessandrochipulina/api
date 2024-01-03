CREATE TABLE [dbo].[FACULTAD] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [nombre_facultad]   VARCHAR (100) NOT NULL,
    [codigo_facultad]   VARCHAR (50)  NOT NULL,
    [creado_tmstp]      DATETIME      NOT NULL DEFAULT GETDATE(),
    [actualizado_tmstp] DATETIME      NOT NULL DEFAULT GETDATE(),
    [estado]            INT           NOT NULL DEFAULT 0,
    CONSTRAINT [PK_Facultad] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [UK_Facultad] UNIQUE NONCLUSTERED ([codigo_facultad])
);

