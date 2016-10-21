


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Create date: 2015-07-07
-- Description:	check table exists or not
-- =============================================
IF OBJECT_ID('existsTable', 'P') IS NOT NULL
	DROP PROC existsTable
GO

CREATE PROCEDURE existsTable
	@tableName [nvarchar] (255),
	@result bit output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	if exists (
		SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA ='dbo' and TABLE_NAME = @tableName
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
-- Create date: 2015-07-07
-- Description:	create a table if table doesn't exist 
-- =============================================

IF OBJECT_ID('createTableIfNotExist', 'P') IS NOT NULL
	DROP PROC createTableIfNotExist
GO

CREATE PROCEDURE createTableIfNotExist
	@tableName [nvarchar] (255)
AS
DECLARE
@tableExists bit, 
@sql NVARCHAR(MAX)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	exec dbo.existsTable @tableName,@tableExists output

	--If table doesn't exist
	if(@tableExists = 0)
	BEGIN
		-- Create table
		set @sql = 'CREATE TABLE [dbo].[' + @tableName + '](
			[Id] [bigint] identity(1,1),
			[PartitionKey] [nvarchar](100) NOT NULL,
			[RowKey] [nvarchar](250) NOT NULL,
			[Timestamp] [datetimeoffset] Not NULL,
			[Content] [nvarchar](max) Not NULL
			 CONSTRAINT [TableStorages_' + @tableName + '_Id] PRIMARY KEY CLUSTERED
			(
				[Id] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),

			 CONSTRAINT [IUX_TableStorages_' + @tableName + '_partition_rowkey] UNIQUE NONCLUSTERED
			(
				[PartitionKey] ASC,
				[RowKey] ASC
			)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
		)'
		EXEC sp_executesql @sql
	End
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 2015-07-07
-- Description:	delete a table 
-- =============================================

IF OBJECT_ID('deleteTableIfExist', 'P') IS NOT NULL
	DROP PROC deleteTableIfExist
GO

CREATE PROCEDURE deleteTableIfExist
	@tableName [nvarchar] (255)
AS
DECLARE
@tableExists bit,
@sql NVARCHAR(MAX)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	exec dbo.existsTable @tableName,@tableExists output

	--If table exists
	if(@tableExists = 1)
	BEGIN
		-- delete table
		set @sql = 'drop table ' + @tableName
		exec sp_executesql @sql
	End
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Create date: 2015-07-07
-- Description:	check whether an table entity exists or not
-- =============================================

IF OBJECT_ID('existsTableEntity', 'P') IS NOT NULL
	DROP PROC existsTableEntity
GO

CREATE PROCEDURE existsTableEntity
	@tableName nvarchar(255),
	@partitionKey nvarchar(100),
	@rowKey nvarchar(255),
	@result bit output
AS
DECLARE
@sql NVARCHAR(MAX)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	
	exec createTableIfNotExist @tableName 
	
	set @sql = 'select top 1 id from ' + @tableName + ' where PartitionKey = ''' + @partitionKey + ''' and RowKey =''' + @rowKey + '''';
	
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
-- Create date: 2015-07-08
-- Description:	insert one table entity, if has existed, replace it with new entity
-- =============================================

IF OBJECT_ID('createOrReplaceTableEntity', 'P') IS NOT NULL
	DROP PROC createOrReplaceTableEntity
GO

CREATE PROCEDURE createOrReplaceTableEntity
	@tableName nvarchar(255),
	@partitionKey nvarchar(100),
	@rowKey nvarchar(255),
	@timestamp [datetime2],
	@content [nvarchar] (max)
AS
declare @existsRow bit,
@sql nvarchar(MAX)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	
	exec createTableIfNotExist @tableName 

	exec existsTableEntity @tableName, @partitionKey,@rowKey,@existsRow output
 
    if(@existsRow = 0)
	BEGIN
		set @sql='insert into ' + @tableName + '(Partitionkey,Rowkey,Timestamp,Content) values(''' + @partitionKey + ''',''' + @rowKey + ''',''' + CAST(@timestamp AS nvarchar(50)) + ''',''' + @content + ''')'
		EXEC sp_executesql @sql
	END
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Create date: 2015-07-08
-- Description:	delete table entity if it exists
-- =============================================

IF OBJECT_ID('deleteTableEntityIfExists', 'P') IS NOT NULL
	DROP PROC deleteTableEntityIfExists
GO

CREATE PROCEDURE deleteTableEntityIfExists
	@tableName nvarchar(255),
	@partitionKey nvarchar(100),
	@rowKey nvarchar(255),
	@result int output
AS
declare @sql nvarchar(MAX)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	
	exec createTableIfNotExist @tableName 
	
	set @result = 0
	set @sql = 'select top 1 id from ' + @tableName + ' where PartitionKey = ''' + @partitionKey + ''' and RowKey =''' + @rowKey + '''';
	
    exec sp_executesql @sql
	
	if @@ROWCOUNT=1
	begin
		set @sql = 'delete ' + @tableName + ' where PartitionKey = ''' + @partitionKey + ''' and RowKey =''' + @rowKey + '''';
	
		exec sp_executesql @sql
		set @result = @@ROWCOUNT
	end

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 2015-07-08
-- Description:	get table entity
-- =============================================

IF OBJECT_ID('getTableEntity', 'P') IS NOT NULL
	DROP PROC getTableEntity
GO

CREATE PROCEDURE getTableEntity
	@tableName nvarchar(255),
	@partitionKey nvarchar(100),
	@rowKey nvarchar(255)
AS
declare @sql nvarchar(MAX)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;
	
	exec createTableIfNotExist @tablename 
	
	set @sql = 'select Id,Partitionkey,Rowkey,Timestamp,Content from ' + @tableName + ' where PartitionKey = ''' + @partitionKey + ''' and RowKey =''' + @rowKey + '''';
	
	exec sp_executesql @sql
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Create date: 2015-07-08
-- Description: search table entities(only support partitionKey and Rowkey)
-- =============================================
IF OBJECT_ID('searchTableEntities', 'P') IS NOT NULL
	DROP PROC searchTableEntities
GO

CREATE PROCEDURE searchTableEntities
	@tableName nvarchar(255),
	@filter nvarchar (max),
	@lastRowId bigint,
	@maxResults int
AS
declare @sql nvarchar(MAX)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	exec createTableIfNotExist @tableName 
	
	if(@filter is NULL or @filter='')
	BEGIN
		set @sql = 'select top ' + CAST(@maxResults as nvarchar) + ' * from ' + @tableName + ' where id > ' + CAST(@lastRowId as nvarchar) + ' order by id asc';
	END
	ELSE
	BEGIN
		set @sql = 'select top ' + CAST(@maxResults as nvarchar) + ' * from ' + @tableName + ' where id > ' + CAST(@lastRowId as nvarchar) + ' and ('  + @filter + ')' + ' order by id asc';
	END

	exec sp_executesql @sql

END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO