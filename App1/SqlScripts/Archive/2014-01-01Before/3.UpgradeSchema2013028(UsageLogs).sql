IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'UsageLogs' AND COLUMN_NAME = 'ClientOS')
BEGIN	
	ALTER TABLE dbo.UsageLogs ADD [ClientOS] [varchar](50) NULL;	
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'UsageLogs' AND COLUMN_NAME = 'ClientOSVersion')
BEGIN	
	ALTER TABLE dbo.UsageLogs ADD [ClientOSVersion] [varchar](50) NULL;	
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'UsageLogs' AND COLUMN_NAME = 'ClientDevice')
BEGIN	
	ALTER TABLE dbo.UsageLogs ADD [ClientDevice] [varchar](50) NULL;	
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'UsageLogs' AND COLUMN_NAME = 'AppVersion')
BEGIN	
	ALTER TABLE dbo.UsageLogs ADD [AppVersion] [varchar](50) NULL;	
END
GO