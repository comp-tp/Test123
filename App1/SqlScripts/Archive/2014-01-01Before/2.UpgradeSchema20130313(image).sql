/****** Object:  ForeignKey [FK_Images_GlobalEntities]    Script Date: 02/19/2013 15:35:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Images_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[Images]'))
ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_GlobalEntities]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 02/19/2013 15:35:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Images_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[Images]'))
ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_GlobalEntities]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Images]') AND type in (N'U'))
DROP TABLE [dbo].[Images]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 02/19/2013 15:35:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Images]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Images](
	[Id] [uniqueidentifier] NOT NULL,
	[GlobalEntityID] [uniqueidentifier] NOT NULL,
	[ImageURL] [nvarchar](1000) NOT NULL,
	[BlobContainer] [nvarchar](100) NOT NULL,
	[BlobName] [nvarchar](1000) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  ForeignKey [FK_Images_GlobalEntities]    Script Date: 02/19/2013 15:35:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Images_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[Images]'))
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_GlobalEntities] FOREIGN KEY([GlobalEntityID])
REFERENCES [dbo].[GlobalEntities] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Images_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[Images]'))
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_GlobalEntities]
GO
