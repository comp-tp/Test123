/****** Object:  Table [dbo].[Comments]    Script Date: 2/27/2014 3:09:08 PM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[GeoCoordinates]    Script Date: 2/27/2014 3:09:09 PM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[GlobalEntities]    Script Date: 2/27/2014 3:09:09 PM ******/
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
	[IsPrivate] [int] NOT NULL,
	[OpenedDate] [datetime] NULL,
	[AssignTo] [nvarchar](1000) NULL,
 CONSTRAINT [PK_GlobalEntities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Images]    Script Date: 2/27/2014 3:09:10 PM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[PersistedData]    Script Date: 2/27/2014 3:09:11 PM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Resources]    Script Date: 2/27/2014 3:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resources](
	[Id] [uniqueidentifier] NOT NULL,
	[API] [varchar](500) NOT NULL,
	[HttpVerb] [varchar](10) NOT NULL,
	[RelativeUriTemplateFull] [nvarchar](1000) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[AuthenticationType] [int] NOT NULL,
	[APIAttribute] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
	[ProxyAPI] [varchar](500) NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF),
 CONSTRAINT [IUX_API_HttpVerb] UNIQUE NONCLUSTERED 
(
	[API] ASC,
	[HttpVerb] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Scope2Groups]    Script Date: 2/27/2014 3:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[ScopeGroups]    Script Date: 2/27/2014 3:09:13 PM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[UsageLogs]    Script Date: 2/27/2014 3:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsageLogs](
	[Id] [uniqueidentifier] NOT NULL,
	[ResourceName] [nvarchar](1000) NOT NULL,
	[HttpVerb] [varchar](10) NULL,
	[Agency] [nvarchar](100) NULL,
	[UserId] [nvarchar](200) NULL,
	[AppId] [nvarchar](100) NULL,
	[Environment] [varchar](10) NULL,
	[ClientIP] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ClientOS] [varchar](50) NULL,
	[ClientOSVersion] [varchar](50) NULL,
	[ClientDevice] [varchar](50) NULL,
	[AppVersion] [varchar](50) NULL,
 CONSTRAINT [PK_API_Usages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
/****** Object:  Table [dbo].[Votes]    Script Date: 2/27/2014 3:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Votes](
	[ID] [uniqueidentifier] NOT NULL,
	[GlobalEntityID] [uniqueidentifier] NOT NULL,
	[UpOrDown] [int] NOT NULL,
	[Favorite] [int] NOT NULL,
	[AppID] [nvarchar](100) NOT NULL,
	[CloudUserID] [uniqueidentifier] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ResourceName]    Script Date: 2/27/2014 3:09:15 PM ******/
CREATE NONCLUSTERED INDEX [IX_ResourceName] ON [dbo].[Resources]
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IUX_Scope2Groups]    Script Date: 2/27/2014 3:09:15 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IUX_Scope2Groups] ON [dbo].[Scope2Groups]
(
	[GroupID] ASC,
	[ScopeName] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IUX_ScopeGroups]    Script Date: 2/27/2014 3:09:15 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IUX_ScopeGroups] ON [dbo].[ScopeGroups]
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Index [UsageLogs_Date]    Script Date: 2/27/2014 3:09:15 PM ******/
CREATE NONCLUSTERED INDEX [UsageLogs_Date] ON [dbo].[UsageLogs]
(
	[CreatedDate] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
ALTER TABLE [dbo].[GlobalEntities] ADD  DEFAULT ((0)) FOR [IsPrivate]
GO
ALTER TABLE [dbo].[Resources] ADD  CONSTRAINT [DF_ApiUris_AuthenticationType]  DEFAULT ((1)) FOR [AuthenticationType]
GO
ALTER TABLE [dbo].[Resources] ADD  CONSTRAINT [DF_ApiUris_APIAttribute]  DEFAULT ((0)) FOR [APIAttribute]
GO
ALTER TABLE [dbo].[Votes] ADD  CONSTRAINT [DF_Votes_UpOrDown]  DEFAULT ((0)) FOR [UpOrDown]
GO
ALTER TABLE [dbo].[Votes] ADD  CONSTRAINT [DF_Votes_Favorite]  DEFAULT ((0)) FOR [Favorite]
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
