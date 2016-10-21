

IF OBJECT_ID('[dbo].[BlobContainers]', 'U') IS NOT NULL
  DROP TABLE [dbo].[BlobContainers]
GO

CREATE TABLE [dbo].[BlobContainers]
(
	[Id] uniqueidentifier NOT NULL,
	[Name] [nvarchar] (255) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime2] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime2] NULL,

    CONSTRAINT [BlobContainers_Id] PRIMARY KEY CLUSTERED(
		[Id] ASC
	),
	CONSTRAINT [IUX_BlobContainers_Name] UNIQUE NONCLUSTERED 
	(
		[Name] ASC
	)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
GO


IF OBJECT_ID('[dbo].[BlobItems]', 'U') IS NOT NULL
  DROP TABLE [dbo].[BlobItems]
GO

CREATE TABLE [dbo].[BlobItems]
(
	[Id] uniqueidentifier NOT NULL,
	[RowNumber] [BIGINT] IDENTITY(1,1) NOT NULL,
	[ContainerId] uniqueidentifier NOT NULL,
	[Name] [nvarchar] (255) NOT NULL,
	[Content] [varbinary] (max) NOT NULL,
	[ContentEncoding] [nvarchar] (100) NULL,
	[ContentType] [nvarchar] (100) NOT NULL,
	[ContentLength] [bigint] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime2] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime2] NULL,

    CONSTRAINT [BlobItems_Id] PRIMARY KEY NONCLUSTERED(
		[Id] ASC
	),
	CONSTRAINT [IUX_BlobItems_RowNumber] UNIQUE CLUSTERED 
	( 
		[RowNumber] ASC
	),
	CONSTRAINT [IUX_BlobItems_ContainerId_Name] UNIQUE NONCLUSTERED 
	(
		[ContainerId] ASC,
		[Name] ASC
	)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
GO

ALTER TABLE [dbo].[BlobItems]  WITH CHECK ADD  CONSTRAINT [FK_BlobItems_BlobContainers] FOREIGN KEY([ContainerId])
REFERENCES [dbo].[BlobContainers] ([Id])
GO
ALTER TABLE [dbo].[BlobItems] CHECK CONSTRAINT [FK_BlobItems_BlobContainers]
GO





SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	check blob existing
-- =============================================
CREATE PROCEDURE existsBlob
	@containerName [nvarchar] (255),
	@blobName [nvarchar] (255),
	@result bit output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	if exists (
		select b.Id
		from BlobContainers c
			,BlobItems b
		where c.Id = b.ContainerId
		and @containerName=c.Name
		and @blobName = b.Name
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


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	get blob attributes
-- =============================================
CREATE PROCEDURE getBlobAttributes
	@containerName [nvarchar] (255),
	@blobName [nvarchar] (255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	select b.id, b.RowNumber, b.containerId, b.Name, null as Content, b.ContentEncoding, b.ContentType, b.ContentLength, b.CreatedBy, b.CreatedDate , b.LastUpdatedBy, b.LastUpdatedDate
	from BlobContainers c
		,BlobItems b
	where c.Id = b.ContainerId
	and @containerName=c.Name
	and @blobName = b.Name

END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	get blob content
-- =============================================
CREATE PROCEDURE getBlobContent
	@containerName [nvarchar] (255),
	@blobName [nvarchar] (255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	select b.content
	from BlobContainers c
		,BlobItems b
	where c.Id = b.ContainerId
	and @containerName=c.Name
	and @blobName = b.Name

END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	delete blob if it exists
-- =============================================
CREATE PROCEDURE deleteBlobIfExists
	@containerName [nvarchar] (255),
	@blobName [nvarchar] (255),
	@result bit output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	exec existsBlob @containerName, @blobName, @result output

	if @result=1
	begin
		delete 
		from BlobItems
		where id in
		(select b.id
			from BlobContainers c
				,BlobItems b
			where c.Id = b.ContainerId
			and @containerName=c.Name
			and @blobName = b.Name
		)
	end

END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	search blobs
-- =============================================
CREATE PROCEDURE searchBlobs
	@containerName [nvarchar] (255),
	@namePrefix [nvarchar] (255),
	@lastCount bigint,
	@maxResults int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	select top (@maxResults) b.*, c.Name as containerName
	from BlobContainers c
		,BlobItems b
	where c.Id = b.ContainerId
	and @containerName=c.Name
	and 1= (case when @namePrefix is not null and b.Name like (@namePrefix + '%') then 1 else 0 end)
	and b.RowNumber > @lastCount
	order by b.RowNumber asc
	
END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	get blob container
-- =============================================
CREATE PROCEDURE getBlobContainer
	@containerName [nvarchar] (255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	select *
	from BlobContainers c
	where @containerName=c.Name

END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	create blob container
-- =============================================
CREATE PROCEDURE createBlobContainer
	@Id uniqueidentifier ,
	@Name [nvarchar] (255) ,
	@CreatedBy [nvarchar](50) ,
	@CreatedDate [datetime2] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	insert BlobContainers ([Id], [Name], [CreatedBy], [CreatedDate])
	values (@Id, @Name, @CreatedBy, @CreatedDate)

END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	create blob item
-- =============================================
CREATE PROCEDURE createBlobItem
	@Id uniqueidentifier ,
	@ContainerId uniqueidentifier ,
	@Name [nvarchar] (255) ,
	@Content [varbinary] (max) ,
	@ContentEncoding [nvarchar] (100) ,
	@ContentType [nvarchar] (100) ,
	@ContentLength [bigint] ,
	@CreatedBy [nvarchar](50) ,
	@CreatedDate [datetime2] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	insert BlobItems ([Id], [ContainerId], [Name], [Content], [ContentEncoding], [ContentType], [ContentLength], [CreatedBy], [CreatedDate])
	values (@Id, @ContainerId, @Name, @Content, @ContentEncoding, @ContentType, @ContentLength, @CreatedBy, @CreatedDate)

END
GO



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Xinter Peng
-- Create date: 2015-05-20
-- Description:	update blob item
-- =============================================
CREATE PROCEDURE updateBlobItem
	@Id uniqueidentifier ,
	@ContainerId uniqueidentifier ,
	@Name [nvarchar] (255) ,
	@Content [varbinary] (max) ,
	@ContentEncoding [nvarchar] (100) ,
	@ContentType [nvarchar] (100) ,
	@ContentLength [bigint] ,
	@LastUpdatedBy [nvarchar](50) ,
	@LastUpdatedDate [datetime2] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	update BlobItems 
	set 
		[ContainerId]=@ContainerId, [Name]=@Name, [Content]=@Content, [ContentEncoding]=@ContentEncoding
		, [ContentType]=@ContentType, [ContentLength]=@ContentLength, [LastUpdatedBy]=@LastUpdatedBy, [LastUpdatedDate]=@LastUpdatedDate
	where [Id]=@Id
END
GO
