/****** Object:  Table [dbo].[ScopeGroups]    Script Date: 10/31/2013 17:53:29 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScopeGroups]') AND type in (N'U'))
BEGIN
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
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ScopeGroups]') AND name = N'IUX_ScopeGroups')
CREATE UNIQUE NONCLUSTERED INDEX [IUX_ScopeGroups] ON [dbo].[ScopeGroups] 
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[Scope2Groups]    Script Date: 10/31/2013 17:53:28 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Scope2Groups]') AND type in (N'U'))
BEGIN
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
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Scope2Groups]') AND name = N'IUX_Scope2Groups')
CREATE UNIQUE NONCLUSTERED INDEX [IUX_Scope2Groups] ON [dbo].[Scope2Groups] 
(
	[GroupID] ASC,
	[ScopeName] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  ForeignKey [FK_Scope2Groups_ScopeGroups]    Script Date: 10/31/2013 17:53:28 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Scope2Groups_ScopeGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[Scope2Groups]'))
ALTER TABLE [dbo].[Scope2Groups]  WITH CHECK ADD  CONSTRAINT [FK_Scope2Groups_ScopeGroups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[ScopeGroups] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Scope2Groups_ScopeGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[Scope2Groups]'))
ALTER TABLE [dbo].[Scope2Groups] CHECK CONSTRAINT [FK_Scope2Groups_ScopeGroups]
GO
