SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Create date: 2015-09-24
-- Description:	check queue exists or not
-- =============================================
IF OBJECT_ID('existsQueue', 'P') IS NOT NULL
	DROP PROC existsQueue
GO

CREATE PROCEDURE existsQueue
	@queueName [nvarchar] (255),
	@result bit output
AS
BEGIN
	SET NOCOUNT ON;

	if exists (
		SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA ='dbo' and TABLE_NAME = @queueName
	)
	begin
		set @result=1
	end
	else
	begin
		set @result=0
	end

END
GO

-- =============================================
-- Create date: 2015-09-24
-- Description:	create a queue if queue doesn't exist 
-- =============================================

IF OBJECT_ID('createQueueIfNotExist', 'P') IS NOT NULL
	DROP PROC createQueueIfNotExist
GO

CREATE PROCEDURE createQueueIfNotExist
	@queueName [nvarchar] (255),
	@existsQueue bit output
AS
DECLARE
@sql NVARCHAR(MAX)
BEGIN
	SET NOCOUNT ON;

	exec dbo.existsQueue @queueName,@existsQueue output

	--If Queue doesn't exist
	if(@existsQueue = 0)
	BEGIN
		-- Create Queue
		set @sql = 'CREATE TABLE [dbo].[' + @queueName + '](
			[Id] [bigint] IDENTITY(1,1) NOT NULL,
			[InsertionTime] [datetimeoffset] NOT NULL,
			[ExpirationTime] [datetimeoffset] NOT NULL,
			[Content] [nvarchar](max) NOT NULL
			CONSTRAINT [QueueStorages_' + @queueName + '_Id] PRIMARY KEY CLUSTERED
			(
				[Id] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
		) ON [PRIMARY]'
		EXEC sp_executesql @sql
	End
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 2015-09-24
-- Description:	delete a Queue 
-- =============================================

IF OBJECT_ID('deleteQueueIfExist', 'P') IS NOT NULL
	DROP PROC deleteQueueIfExist
GO

CREATE PROCEDURE deleteQueueIfExist
	@queueName [nvarchar] (255),
	@existsQueue bit output
AS
DECLARE
@sql NVARCHAR(MAX)
BEGIN
	SET NOCOUNT ON;

	exec dbo.existsQueue @queueName,@existsQueue output

	--If queue exists
	if(@existsQueue = 1)
	BEGIN
		-- delete queue
		set @sql = 'drop table [dbo].[' + @queueName + ']'
		exec sp_executesql @sql
	End
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Create date: 2015-09-24
-- Description:	check whether queue message exists or not
-- =============================================

IF OBJECT_ID('existsQueueMessage', 'P') IS NOT NULL
	DROP PROC existsQueueMessage
GO

CREATE PROCEDURE existsQueueMessage
	@queueName nvarchar(255),
	@messageID bigint,
	@result bit output
AS
DECLARE
@sql NVARCHAR(MAX),
@existsQueue bit
BEGIN
	SET NOCOUNT ON;
	
	exec dbo.createQueueIfNotExist @queueName 
	
	set @sql = 'select top 1 id from  [dbo].[' + @queueName + '] where ID = ' + CAST(@messageID as varchar(32)) ;
	
	exec sp_executesql @sql
	if(@@ROWCOUNT > 0)
	BEGIN
		select @result = 1
	END
	ELSE
	BEGIN
		select @result = 0
	END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Create date: 2015-09-24
-- Description:	insert one queue message
-- =============================================

IF OBJECT_ID('createQueueMessage', 'P') IS NOT NULL
	DROP PROC createQueueMessage
GO

CREATE PROCEDURE createQueueMessage
	@queueName nvarchar(255),
	@insertionTime [datetime2],
	@expirationTime [datetime2],
	@content [nvarchar] (max)
AS
declare @existsRow bit,
@sql nvarchar(MAX),
@existQueue bit
BEGIN
	SET NOCOUNT ON;
	
	exec dbo.createQueueIfNotExist @queueName, @existQueue output 

	set @sql='insert into  [dbo].[' + @queueName + '](insertionTime,ExpirationTime,Content) values(''' + CAST(@insertionTime AS nvarchar(50)) + ''',''' + CAST(@expirationTime AS nvarchar(50)) + ''',''' + @content + ''')'
	EXEC sp_executesql @sql
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Create date: 2015-09-24
-- Description:	delete queue message if it exists
-- =============================================

IF OBJECT_ID('deleteQueueMessageIfExists', 'P') IS NOT NULL
	DROP PROC deleteQueueMessageIfExists
GO

CREATE PROCEDURE deleteQueueMessageIfExists
	@queueName nvarchar(255),
	@messageID bigint
AS
declare @sql nvarchar(MAX),
@existQueue bit
BEGIN
	SET NOCOUNT ON;
	
	exec dbo.createQueueIfNotExist @queueName, @existQueue output
	
	begin
		set @sql = 'delete  [dbo].[' + @queueName + '] where ID = ' + CAST(@messageID as varchar(32));
	
		exec sp_executesql @sql
	end

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 2015-09-24
-- Description:	get queue message by id
-- =============================================

IF OBJECT_ID('getQueueMessageById', 'P') IS NOT NULL
	DROP PROC getQueueMessageById
GO

CREATE PROCEDURE getQueueMessageById
	@queueName nvarchar(255),
	@messageID bigint,
	@withDeleteQueueMessage bit
AS
declare @sql nvarchar(MAX),
@existQueue bit
BEGIN
	SET NOCOUNT ON;
	
	exec dbo.createQueueIfNotExist @queueName, @existQueue output
	
	IF(@withDeleteQueueMessage = 1)
	BEGIN
		set @sql='WITH T AS' + 
		' (SELECT TOP 1 * FROM [dbo].[' + @queueName + '] where ID =' + CAST(@messageID as varchar(32)) + ')' +
		' DELETE FROM T' +
		' OUTPUT deleted.*'
		exec sp_executesql @sql
	END
	ELSE
	BEGIN
		set @sql = 'select TOP 1 * from [dbo].[' + @queueName + '] where ID = ' + CAST(@messageID as varchar(32));
		
		exec sp_executesql @sql
	END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Create date: 2015-09-24
-- Description:	get queue messages (FIFO) 
-- =============================================

IF OBJECT_ID('getQueueMessages', 'P') IS NOT NULL
	DROP PROC getQueueMessages
GO

CREATE PROCEDURE getQueueMessages
	@queueName nvarchar(255),
	@messageCount int,
	@withDeleteQueueMessage bit
AS
declare @sql nvarchar(MAX),
@existQueue bit
BEGIN
	SET NOCOUNT ON;
	
	exec dbo.createQueueIfNotExist @queueName, @existQueue output
	
	IF(@withDeleteQueueMessage = 1)
	BEGIN
		set @sql='WITH T AS' + 
		' (SELECT TOP ' + CAST(@messageCount as varchar(10)) + ' * FROM [dbo].[' + @queueName + '] order by id asc) ' +
		' DELETE FROM T' +
		' OUTPUT deleted.*'
		exec sp_executesql @sql
	END
	ELSE
	BEGIN
		set @sql = 'SELECT TOP ' + CAST(@messageCount as varchar(10)) + ' * from [dbo].[' + @queueName + '] order by id asc';
		
		exec sp_executesql @sql
	END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Create date: 2015-09-24
-- Description:	delete expired queue messages  
-- =============================================

IF OBJECT_ID('deleteExpiredQueueMessages', 'P') IS NOT NULL
	DROP PROC deleteExpiredQueueMessages
GO

CREATE PROCEDURE deleteExpiredQueueMessages
AS
DECLARE @tableName nvarchar(250),
@sql nvarchar(MAX)
BEGIN
	SET NOCOUNT ON;

	DECLARE cur CURSOR FOR SELECT substring(name,len('QueueStorages_') + 1, len(name)-len('QueueStorages_') -3) as tableName
	FROM sys.indexes where type=1 and name like 'QueueStorages_%_Id'

	OPEN cur

	FETCH NEXT FROM cur INTO @tableName

	WHILE @@FETCH_STATUS = 0 
	BEGIN
		set @sql='delete from [dbo].[' + @tableName + '] where expirationTime < getutcdate()'
		exec sp_executesql @sql
		FETCH NEXT FROM cur INTO @tableName
	END

	CLOSE cur    
	DEALLOCATE cur

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Create date: 2015-10-02
-- Description:	delete all queue messages by queue name 
-- =============================================

IF OBJECT_ID('clearQueueMessages', 'P') IS NOT NULL
	DROP PROC clearQueueMessages
GO

CREATE PROCEDURE clearQueueMessages
@queueName nvarchar(255)
AS
declare @sql nvarchar(MAX),
@existQueue bit
BEGIN
	SET NOCOUNT ON;
	
	exec dbo.createQueueIfNotExist @queueName, @existQueue output
	
	if(@existQueue = 1)
	BEGIN
		set @sql = 'delete from [dbo].[' + @queueName + ']';
		exec sp_executesql @sql
	END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO