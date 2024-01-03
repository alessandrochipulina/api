CREATE TRIGGER [T_UP_Carrera]
	ON [dbo].[CARRERA]
	FOR UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		UPDATE dbo.CARRERA SET actualizado_tmstp = GETDATE()
		FROM dbo.CARRERA c
		INNER JOIN inserted i 
		ON c.id = i.id
	END