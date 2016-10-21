IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GlobalEntities' AND COLUMN_NAME = 'OpenedDate')
BEGIN	
	ALTER TABLE dbo.GlobalEntities ADD [OpenedDate] DATETIME NULL	
END
GO
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GlobalEntities' AND COLUMN_NAME = 'AssignTo')
BEGIN	
	ALTER TABLE dbo.GlobalEntities ADD [AssignTo] [nvarchar](1000) NULL	
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GlobalEntities' AND COLUMN_NAME = 'IsPrivate')
BEGIN	
	ALTER TABLE dbo.GlobalEntities ADD [IsPrivate] INT NOT NULL DEFAULT(0)		
END
GO

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'GlobalEntities' AND COLUMN_NAME = 'IsPrivate')
BEGIN	
	UPDATE dbo.GlobalEntities SET [IsPrivate] = 0
END
GO

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GeoCoordinates_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[GeoCoordinates]'))
ALTER TABLE [dbo].[GeoCoordinates]  WITH CHECK ADD  CONSTRAINT [FK_GeoCoordinates_GlobalEntities] FOREIGN KEY([GlobalEntityID])
REFERENCES [dbo].[GlobalEntities] ([ID])
GO