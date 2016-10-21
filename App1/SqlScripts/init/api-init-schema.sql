/****** Object:  Table [dbo].[AsyncRequestStatuses]    Script Date: 5/18/2015 1:58:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AsyncRequestStatuses](
	[RequestID] [varchar](50) NOT NULL,
	[Status] [varchar](10) NOT NULL,
	[HttpMethod] [varchar](10) NOT NULL,
	[RequestUrl] [varchar](255) NOT NULL,
	[RequestDataBlobUrl] [varchar](255) NULL,
	[ResponseDataBlobUrl] [varchar](255) NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[Description] [varchar](100) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_AsyncRequestStatuses] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [uniqueidentifier] NOT NULL,
	[GlobalEntityID] [uniqueidentifier] NOT NULL,
	[Comments] [nvarchar](max) NULL,
	[AppID] [nvarchar](100) NOT NULL,
	[CloudUserId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GeoCoordinates]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeoCoordinates](
	[ID] [uniqueidentifier] NOT NULL,
	[GlobalEntityID] [uniqueidentifier] NOT NULL,
	[CoordinateX] [decimal](18, 12) NULL,
	[CoordinateY] [decimal](18, 12) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_GeoCoodinates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[GlobalEntities]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GlobalEntities](
	[ID] [uniqueidentifier] NOT NULL,
	[EntityID] [nvarchar](200) NOT NULL,
	[EntityType] [nvarchar](50) NOT NULL,
	[AgencyName] [nvarchar](100) NOT NULL,
	[Environment] [nvarchar](20) NOT NULL,
	[Status] [nvarchar](10) NOT NULL,
	[CloudUserID] [uniqueidentifier] NULL,
	[UDF1] [nvarchar](1000) NULL,
	[UDF2] [nvarchar](1000) NULL,
	[UDF3] [nvarchar](1000) NULL,
	[UDF4] [nvarchar](1000) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[IsPrivate] [int] NOT NULL DEFAULT ((0)),
	[OpenedDate] [datetime] NULL,
	[AssignTo] [nvarchar](1000) NULL,
 CONSTRAINT [PK_GlobalEntities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Images]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[PersistedData]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersistedData](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[Namespace] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[DataKey] [nvarchar](512) NOT NULL,
	[BlobName] [nvarchar](1024) NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[BlobSize] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[Agency] [nvarchar](50) NOT NULL,
	[EntityType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PersistedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Resources]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [uniqueidentifier] NOT NULL,
	[API] [varchar](500) NOT NULL,
	[HttpVerb] [varchar](10) NOT NULL,
	[RelativeUriTemplateFull] [varchar](4000) NULL,
	[Name] [varchar](200) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[AuthenticationType] [int] NOT NULL CONSTRAINT [DF_ApiUris_AuthenticationType]  DEFAULT ((1)),
	[APIAttribute] [int] NOT NULL CONSTRAINT [DF_ApiUris_APIAttribute]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[ProxyAPI] [varchar](4000) NULL,
	[Applicability] [varchar](10) NULL,
	[MethodNickName] [varchar](50) NULL,
	[SupportedAAVersions] [varchar](500) NULL,
	[SupportedAPIVersions] [varchar](200) NULL,
	[ResourceGroupName] [varchar](200) NULL,
	[FIDDescription] [varchar](100) NULL,
	[IsProxy] [int] NOT NULL DEFAULT ((0)),
	[IsAAGovxmlAPI] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
 CONSTRAINT [IUX_API_HttpVerb] UNIQUE NONCLUSTERED 
(
	[API] ASC,
	[HttpVerb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Scope2Groups]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Scope2Groups](
	[ID] [uniqueidentifier] NOT NULL,
	[GroupID] [uniqueidentifier] NOT NULL,
	[ScopeName] [varchar](200) NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Scope2Groups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ScopeGroups]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScopeGroups](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ScopeGroups] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [dbo].[Votes]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[ID] [uniqueidentifier] NOT NULL,
	[GlobalEntityID] [uniqueidentifier] NOT NULL,
	[UpOrDown] [int] NOT NULL CONSTRAINT [DF_Votes_UpOrDown]  DEFAULT ((0)),
	[Favorite] [int] NOT NULL CONSTRAINT [DF_Votes_Favorite]  DEFAULT ((0)),
	[AppID] [nvarchar](100) NOT NULL,
	[CloudUserID] [uniqueidentifier] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Index [IX_PERSISTEDDATA_EXPIRATIONDATE]    Script Date: 5/18/2015 1:58:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_PERSISTEDDATA_EXPIRATIONDATE] ON [dbo].[PersistedData]
(
	[ExpirationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ASYNCREQUESTSTATUSES_EXPIRATIONDATE]    Script Date: 5/18/2015 1:58:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_ASYNCREQUESTSTATUSES_EXPIRATIONDATE] ON [dbo].[AsyncRequestStatuses]
(
	[ExpirationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ResourceName]    Script Date: 5/18/2015 1:58:26 PM ******/
CREATE NONCLUSTERED INDEX [IX_ResourceName] ON [dbo].[Resources]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IUX_Scope2Groups]    Script Date: 5/18/2015 1:58:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IUX_Scope2Groups] ON [dbo].[Scope2Groups]
(
	[GroupID] ASC,
	[ScopeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IUX_ScopeGroups]    Script Date: 5/18/2015 1:58:26 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IUX_ScopeGroups] ON [dbo].[ScopeGroups]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
ALTER TABLE [dbo].[GeoCoordinates]  WITH CHECK ADD  CONSTRAINT [FK_GeoCoordinates_GlobalEntities] FOREIGN KEY([GlobalEntityID])
REFERENCES [dbo].[GlobalEntities] ([ID])
GO
ALTER TABLE [dbo].[GeoCoordinates] CHECK CONSTRAINT [FK_GeoCoordinates_GlobalEntities]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_GlobalEntities] FOREIGN KEY([GlobalEntityID])
REFERENCES [dbo].[GlobalEntities] ([ID])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_GlobalEntities]
GO
ALTER TABLE [dbo].[Scope2Groups]  WITH CHECK ADD  CONSTRAINT [FK_Scope2Groups_ScopeGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[ScopeGroups] ([ID])
GO
ALTER TABLE [dbo].[Scope2Groups] CHECK CONSTRAINT [FK_Scope2Groups_ScopeGroups]
GO
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_Votes_GlobalEntities] FOREIGN KEY([GlobalEntityID])
REFERENCES [dbo].[GlobalEntities] ([ID])
GO
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_Votes_GlobalEntities]
GO
/****** Object:  StoredProcedure [dbo].[maintenance_daily_api]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[maintenance_daily_api]
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

GO
/****** Object:  StoredProcedure [dbo].[maintenance_hourly_api]    Script Date: 5/18/2015 2:12:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[maintenance_hourly_api]
AS
DECLARE
   @Rows INT,
   @END_DATE Date
BEGIN

   select GETDATE()

END

GO
/****** Object:  StoredProcedure [dbo].[maintenance_weekly_api]    Script Date: 5/18/2015 1:58:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[maintenance_weekly_api]
AS
BEGIN
   
-- rebuild index
ALTER INDEX [PK_Resource] ON [Resources]
REBUILD WITH (ONLINE = ON)

ALTER INDEX [PK_GlobalEntities] ON [GlobalEntities]
REBUILD WITH (ONLINE = ON)

ALTER INDEX [PK_PERSISTEDDATA] ON PERSISTEDDATA
REBUILD WITH (ONLINE = ON)

ALTER INDEX [PK_AsyncRequestStatuses] ON ASYNCREQUESTSTATUSES
REBUILD WITH (ONLINE = ON)

END

GO