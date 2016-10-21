IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'maintenance_daily_api' AND XTYPE = 'P')
  DROP PROCEDURE maintenance_daily_api
GO

CREATE PROCEDURE maintenance_daily_api
AS
DECLARE
   @Rows INT,
   @END_DATE Date
BEGIN

   SET @END_DATE=getdate()
   
   SET @Rows = 1
   WHILE (@Rows > 0)
   BEGIN
       DELETE TOP (10000)
       FROM PERSISTEDDATA
       WHERE EXPIRATIONDATE<@END_DATE
       SET @Rows = @@ROWCOUNT
   END

   SET @Rows = 1
   WHILE (@Rows > 0)
   BEGIN
       DELETE TOP (10000)
       FROM ASYNCREQUESTSTATUSES
       WHERE EXPIRATIONDATE<@END_DATE
       SET @Rows = @@ROWCOUNT
   END

END
