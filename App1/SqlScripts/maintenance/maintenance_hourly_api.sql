IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'maintenance_hourly_api' AND XTYPE = 'P')
  DROP PROCEDURE maintenance_hourly_api
GO

CREATE PROCEDURE maintenance_hourly_api
AS
DECLARE
   @Rows INT,
   @END_DATE Date
BEGIN

   select GETDATE()

END
