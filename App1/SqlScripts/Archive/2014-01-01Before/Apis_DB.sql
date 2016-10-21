/****** Object:  ForeignKey [FK_Votes_GlobalEntities]    Script Date: 01/30/2013 20:39:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Votes_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[Votes]'))
ALTER TABLE [dbo].[Votes] DROP CONSTRAINT [FK_Votes_GlobalEntities]
GO
/****** Object:  Table [dbo].[Votes]    Script Date: 01/30/2013 20:39:02 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Votes_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[Votes]'))
ALTER TABLE [dbo].[Votes] DROP CONSTRAINT [FK_Votes_GlobalEntities]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DF_Votes_UpOrDown]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Votes] DROP CONSTRAINT [DF_Votes_UpOrDown]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DF_Votes_Favorite]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Votes] DROP CONSTRAINT [DF_Votes_Favorite]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Votes]') AND type in (N'U'))
DROP TABLE [dbo].[Votes]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 01/30/2013 20:39:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comments]') AND type in (N'U'))
DROP TABLE [dbo].[Comments]
GO
/****** Object:  Table [dbo].[GeoCoordinates]    Script Date: 01/30/2013 20:39:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GeoCoordinates]') AND type in (N'U'))
DROP TABLE [dbo].[GeoCoordinates]
GO
/****** Object:  Table [dbo].[GlobalEntities]    Script Date: 01/30/2013 20:39:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DF__GlobalEnt__IsPri__2A4B4B5E]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[GlobalEntities] DROP CONSTRAINT [DF__GlobalEnt__IsPri__2A4B4B5E]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GlobalEntities]') AND type in (N'U'))
DROP TABLE [dbo].[GlobalEntities]
GO
/****** Object:  Table [dbo].[PersistedData]    Script Date: 01/30/2013 20:39:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersistedData]') AND type in (N'U'))
DROP TABLE [dbo].[PersistedData]
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 01/30/2013 20:39:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DF_ApiUris_AuthenticationType]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Resources] DROP CONSTRAINT [DF_ApiUris_AuthenticationType]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DF_ApiUris_APIAttribute]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Resources] DROP CONSTRAINT [DF_ApiUris_APIAttribute]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND type in (N'U'))
DROP TABLE [dbo].[Resources]
GO
/****** Object:  Table [dbo].[UsageLogs]    Script Date: 01/30/2013 20:39:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsageLogs]') AND type in (N'U'))
DROP TABLE [dbo].[UsageLogs]
GO
/****** Object:  Table [dbo].[UsageLogs]    Script Date: 01/30/2013 20:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UsageLogs]') AND type in (N'U'))
BEGIN
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
 CONSTRAINT [PK_API_Usages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Resources]    Script Date: 01/30/2013 20:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Resources](
	[Id] [uniqueidentifier] NOT NULL,
	[API] [varchar](500) NOT NULL,
	[HttpVerb] [varchar](10) NOT NULL,
	[RelativeUriTemplateFull] [nvarchar](1000) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[AuthenticationType] [int] NOT NULL CONSTRAINT [DF_ApiUris_AuthenticationType]  DEFAULT ((1)),
	[APIAttribute] [int] NOT NULL CONSTRAINT [DF_ApiUris_APIAttribute]  DEFAULT ((0)),
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Resource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF),
 CONSTRAINT [IUX_API_HttpVerb] UNIQUE NONCLUSTERED 
(
	[API] ASC,
	[HttpVerb] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Resources]') AND name = N'IX_ResourceName')
CREATE NONCLUSTERED INDEX [IX_ResourceName] ON [dbo].[Resources] 
(
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF)
GO
/****** Object:  Table [dbo].[PersistedData]    Script Date: 01/30/2013 20:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PersistedData]') AND type in (N'U'))
BEGIN
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
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[GlobalEntities]    Script Date: 01/30/2013 20:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GlobalEntities]') AND type in (N'U'))
BEGIN
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
 CONSTRAINT [PK_GlobalEntities] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[GeoCoordinates]    Script Date: 01/30/2013 20:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GeoCoordinates]') AND type in (N'U'))
BEGIN
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
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 01/30/2013 20:39:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comments]') AND type in (N'U'))
BEGIN
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
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  Table [dbo].[Votes]    Script Date: 01/30/2013 20:39:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Votes]') AND type in (N'U'))
BEGIN
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
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
END
GO
/****** Object:  ForeignKey [FK_Votes_GlobalEntities]    Script Date: 01/30/2013 20:39:02 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Votes_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[Votes]'))
ALTER TABLE [dbo].[Votes]  WITH CHECK ADD  CONSTRAINT [FK_Votes_GlobalEntities] FOREIGN KEY([GlobalEntityID])
REFERENCES [dbo].[GlobalEntities] ([ID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Votes_GlobalEntities]') AND parent_object_id = OBJECT_ID(N'[dbo].[Votes]'))
ALTER TABLE [dbo].[Votes] CHECK CONSTRAINT [FK_Votes_GlobalEntities]
GO



INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10000', '/v3/addresses', 'GET', '/v3/addresses/?lang={lang}&offset={offset}&limit={limit}&houseNumber={houseNumber}&houseNumberFraction={houseNumberFraction}&streetDirection={streetDirection}&streetName={streetName}&streetSuffixDirection={streetSuffixDirection}&streetSuffix={streetSuffix}&unitStart={unitStart}&unitEnd={unitEnd}&unitType={unitType}&city={city}&state={state}&zipCode={zipCode}', 'get_addresses', 'Get Addresses', '', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10001', '/v3/addresses/{id}', 'GET', '/v3/addresses/{id}/?lang={lang}', 'get_address', 'Get Address', 'Returns relevant addresses that match specified queries.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10003', '/v3/appdata/{container}/{blobname}', 'GET', '/v3/appdata/{container}/{blobname}/?lang={lang}&appid={appid}', 'get_app_data', 'Get App Specific Data', 'Retrieves app data matching the container and blob name. The two parameters are defined by the invoker (an app) and must be unique.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10004', '/v3/appdata/{container}/{blobname}', 'PUT', '/v3/appdata/{container}/{blobname}/?lang={lang}&appid={appid}', 'update_app_data', 'Update App Specific Data', 'Stores app data in the Cloud based on the container and blob name. If the two parameters exist in the Cloud already, the API will override them; otherwise, the API will create them in the Cloud. The two parameters are defined by the invoker (an app) and must be unique.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10005', '/v3/appdata/{container}/{blobname}', 'DELETE', '/v3/appdata{container}/{blobname}/?lang={lang}&appid={appid}', 'delete_app_data', 'Delete App Specific Data', 'Deletes app data based on the container and blob name. No error will be returned if neither of the parameters exists in the Cloud.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10006', '/v3/appdata/search/records', 'POST', '/v3/appdata/search/records/?lang={lang}&offset={offset}&limit={limit}', 'geocode_search_records', 'Search Records Via Geocode', 'Searches record via geocode.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c20007', '/v3/appsettings', 'GET', '/v3/appsettings', 'get_app_settings', 'Get App Settings', 'Gets a list of settings of the given App', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10009', '/v3/assets', 'GET', '/v3/assets/?lang={lang}&offset={offset}&limit={limit}&ids={ids}&display={display}&types={types}&status={status}&description={description}&comments={comments}&currentValueRange={currentValueRange}&statusDateRange={statusDateRange}&serviceDateRange={serviceDateRange}', 'get_assets', 'Get Assets', 'Returns relevant assets that match a specified query.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10010', '/v3/assets/{ids}', 'GET', '/v3/assets/{ids}/?lang={lang}', 'get_asset', 'Get Asset', 'Returns relevant assets that match the specified array of IDs.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10011', '/v3/assets', 'POST', '/v3/assets/?lang={lang}', 'create_asset', 'Create Asset', 'Creates an asset. In this API, asset status and asset type comes from system data. Please refer to the system data section.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10012', '/v3/assets/{id}/conditionassessments', 'GET', '/v3/assets/{id}/conditionassessments/?lang={lang}&offset={offset}&limit={limit}', 'get_condition_assessments', 'Get Condition Assessments', 'Get condition assessments for specific asset.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10029', '/v3/contacts', 'GET', '/v3/contacts/?lang={lang}&offset={offset}&limit={limit}&type={type}&fullname={fullname}', 'get_contacts', 'Get Contacts', 'Gets a list of contacts.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10028', '/v3/search/contacts', 'POST', '/v3/search/contacts/?lang={lang}&offset={offset}&limit={limit}', 'search_contacts', 'Search Contacts', 'Search contacts with given critiria.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10030', '/v3/document/{id}', 'GET', '/v3/document/{id}', 'get_document', 'Get Document', 'Get contacts by type or full name.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10031', '/v3/document/{id}/thumbnail', 'GET', '/v3/document/{id}/thumbnail/?pixelWidth={pixelWidth}&pixelHeight={pixelHeight}', 'get_thumbnail', 'Get Thumbnail', 'Downloads the attachment with the specified attachment id.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10078', '/v3/geo/ReverseGeocode', 'GET', '/v3/geo/ReverseGeocode?longitude={longitude}&latitude={latitude}&lang={lang}', 'reverse_geocode', 'Get {Longitude}', 'Returns matched address according to longitude and latitude.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10079', '/v3/geo/search/agencies', 'POST', '/v3/geo/search/agencies/?lang={lang}', 'search_agencies', 'Create Agencies', 'Returns matched agency&nbsp; that match specified latitude and longitude parameters.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10032', '/v3/gissettings', 'GET', '/v3/gissettings/?agency={agency}', 'get_gis_settings', 'Get GIS Settings', 'Return GIS Setting that match specified agency.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10034', '/v3/inspections', 'GET', '/v3/inspections/?lang={lang}&offset={offset}&limit={limit}&scheduleDateRange={scheduleDateRange}&inspectorIds={inspectorIds}&districtIds={districtIds}&types={types}&module={module}', 'get_inspections', 'Get Inspections', 'Returns Inspections that match specified parameter. Note: The data range must be from-to, and the format must be yyyyMMdd. Example: scheduleDateRange=20120708-20120813. The Ids should be "id,id". Each id will use "," to divide.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10035', '/v3/inspections/{id}', 'GET', '/v3/inspections/{id}/?lang={lang}', 'get_inspection', 'Get Inspection', 'Returns a single Inspection.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10036', '/v3/inspections/Inspection', 'POST', '/v3/inspections/Inspection/?lang={lang}', 'create_inspection_1', 'Create Inspection', 'Schedule inspection. These object''s entityState property will be set correspond value (Added, Updated, Deleted) if These sub objects (comment, checklist, checklistItem) have been created, updated and deleted.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10037', '/v3/inspections/{id}/reschedule', 'PUT', '/v3/inspections/{id}/reschedule/?lang={lang}', 'reschedule_inspection', 'Reschedule Inspection', 'Reschedule the specified inspection. Note that in the JSON payload, if auto assign is set, schedule date/time will be ignored; otherwise, it is required.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10038', '/v3/inspections/{id}/reassign', 'PUT', '/v3/inspections/{id}/reassign/?lang={lang}', 'reassign_inspection', 'Reassign Inspection', 'Reassign the specified inspection. Note that in the JSON payload, if auto assign is set, schedule date/time will be ignored; otherwise, it is required.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10039', '/v3/inspections', 'POST', '/v3/inspections/?lang={lang}', 'create_inspection', 'Create Inspection', 'Create a new inspection from the parameters passed. Note that in the JSON payload, record id and inspection type id are required. If auto assign is set, schedule date/time will be ignored; otherwise, schedule date is required.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10033', '/v3/search/inspections', 'POST', '/v3/search/inspections/?expand={expand}&lang={lang}&offset={offset}&limit={limit}', 'search_inspections', 'Search Inspections', 'Returns Inspections that match specified queries. For Ids, The Ids should be &quot;id,id&quot;. Each id will use &quot;,&quot; as separator', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10074', '/v3/inspector', 'GET', '/v3/inspector', 'get_inspector', 'Get Inspector', 'Returns my inspector information, include department id and name.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10080', '/v3/owners', 'GET', '/v3/owners/?lang={lang}&offset={offset}&limit={limit}&fullName={fullName}&firstName={firstName}&middleNames={middleNames}&lastName={lastName}', 'get_owners', 'Get Owners', 'Returns relevant owners that match specified queries.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10082', '/v3/parcels', 'GET', '/v3/parcels/?lang={lang}&offset={offset}&limit={limit}&parcelIds={ids}', 'get_parcels', 'Get Parcels', 'Return parcels by specific queries. The Ids should be "id,id". Each id will use "," as separator.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10083', '/v3/parcels/{ids}', 'GET', '/v3/parcels/{ids}/?lang={lang}', 'get_parcel', 'Get Parcel', 'Return parcels by specific queries. The Ids should be "id,id". Each id will use "," as separator.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10084', '/v3/parcels/{id}/owners', 'GET', '/v3/parcels/{id}/owners/?lang={lang}', 'get_parcel_owners', 'Get Parcel Owners', 'Return owners for specific parcel. Note: Example /parcels/4512/ owners/?', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10085', '/v3/parcels/{id}/addresses', 'GET', '/v3/parcels/{id}/addresses/?lang={lang}', 'get_parcel_addresses', 'Get Parcel Addresses', 'Return addresses for specific parcel. Note: Example /parcels/4512/addresses/?', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10081', '/v3/search/parcels', 'POST', '/v3/search/parcels/?expand={expand}&lang={lang}&offset={offset}&limit={limit}', 'search_parcels', 'Search Parcels', 'Return relevant parcels by specific queries. In this API. For Ids, The Ids should be "id,id". Each id will use "," as separator.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10087', '/v3/records', 'GET', '/v3/records/?expand={expand}&lang={lang}&offset={offset}&limit={limit}&types={recordTypeIds}&statuses={recordStatusIds}&scheduledDateRange={scheduledDateRange}&openedDateRange={openedDateRange}&aliases={aliases}&staffs={staffIds}&module={module}', 'get_records', 'Get Records', 'Returns relevant Records that match specified queries.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10088', '/v3/records/{ids}', 'GET', '/v3/records/{ids}/?expand={expand}&lang={lang}', 'get_record', 'Get Record', 'Get  records by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10089', '/v3/records/{id}/owners', 'GET', '/v3/records/{id}/owners/?lang={lang}', 'get_record_owners', 'Get Record Owners', 'Get the record''s owners by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10090', '/v3/records/{id}/contacts', 'GET', '/v3/records/{id}/contacts/?lang={lang}', 'get_record_contacts', 'Get Record Contacts', 'Get the record''s contracts by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10091', '/v3/records/{id}', 'PUT', '/v3/records/{id}/?lang={lang}', 'update_record', 'Update Record', 'Update record and sub objects, in sub objects, there are three operations in it, create, update, delete.  For example you may add one more parcel on the records, you should mark sub objectâ€™s entityState to Added, if you want update exist parcel, please mark sub objectâ€™s entityState to Updated, and if you want delete one or more parcel, please mark sub object'' entityState to Deleted.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10092', '/v3/records', 'POST', '/v3/records/?lang={lang}', 'create_record', 'Create Record', 'Create record. You can create record with addresses, additional information, additional information table, comments, contact, GIS objects, and parcels. The additional information and additional information table coming from /system/record/type/{id}/asi and /system/record/type/{id}/asit that based on record type. Please note, for sub object, you should mark sub objectâ€™s entityState to Added in this operation.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10093', '/v3/records/{id}/addresses', 'GET', '/v3/records/{id}/addresses/?lang={lang}', 'get_record_addresses', 'Get Record Addresses', 'Return addresses for specific Record. Note: Example  /records/10CAP-00000-00012/addresses/?', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10094', '/v3/records/{id}/documents', 'GET', '/v3/records/{id}/documents/?lang={lang}&offset={offset}&limit={limit}', 'get_record_documents', 'Get Record Documents', 'Return document''s content. Note: Example /document/4254/?', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10095', '/v3/records/{id}/document', 'POST', '/v3/records/{id}/document/?lang={lang}', 'create_record_document', 'Create Record Document', 'Create record''s document. The API use "multipart/form-data" to upload file, the "fileInfo" include file name, description etc. the schema as {"attachment":{"fileName":"file name","fileType":"image","fileSize":200,"description":"desc"}}', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10096', '/v3/records/{id}/asis', 'GET', '/v3/records/{id}/asis/?lang={lang}', 'get_record_asis', 'Get Record Asis', 'Return additional information for specific Record. Note: Example  /records/10CAP-00000-00012/asis/?', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10097', '/v3/records/{id}/asits', 'GET', '/v3/records/{id}/asits/?lang={lang}', 'get_record_asits', 'Get Record Asits', 'Return additional tables for specific Record. Note: Example  /records/10CAP-00000-00012/asits/?', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10098', '/v3/records/{id}/parcels', 'GET', '/v3/records/{id}/parcels/?lang={lang}', 'get_record_parcels', 'Get Record Parcels', 'Get the record''s parcels by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10099', '/v3/records/{id}/costs', 'GET', '/v3/records/{id}/costs/?lang={lang}', 'get_record_costs', 'Get Record Costs', 'Get the record''s costs by record id.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10100', '/v3/records/{id}/parts', 'GET', '/v3/records/{id}/parts/?lang={lang}', 'get_record_parts', 'Get Record Parts', 'Get the record''s parts by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10101', '/v3/records/{id}/related', 'GET', '/v3/records/{id}/related/?lang={lang}', 'get_related_records', 'Get Related Records', 'Get the  related records by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10102', '/v3/records/{id}/conditions', 'GET', '/v3/records/{id}/conditions/?lang={lang}&priority={priority}', 'get_record_conditions', 'Get Record Conditions', 'Get the record''s conditions by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10103', '/v3/records/{id}/inspections', 'GET', '/v3/records/{id}/inspections/?openInspectionsOnly={openInspectionsOnly}&scheduledDateRange={scheduledDateRange}&lang={lang}&offset={offset}&limit={limit}', 'get_record_inspections', 'Get Record Inspections', 'Get the record''s inspections by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10104', '/v3/records/{id}/assets', 'GET', '/v3/records/{id}/assets/?lang={lang}', 'get_record_assets', 'Get Record Assets', 'Return assets for specific Record. Note: Example  /records/10CAP-00000-00012/assets/?', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10105', '/v3/records/{id}/comments', 'GET', '/v3/records/{id}/comments/?lang={lang}', 'get_record_comments', 'Get Record Comments', 'Return comments for specific Record. Note: Example  /records/10CAP-00000-00012/ comments/?', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10106', '/v3/records/{id}/workflowtasks', 'GET', '/v3/records/{id}/workflowtasks/?lang={lang}', 'get_record_workflow_tasks', 'Get Record Workflow Tasks', 'Get the record''s workflow task by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10107', '/v3/records/{id}/workflowtask', 'PUT', '/v3/records/{id}/workflowtask/?lang={lang}', 'update_record_workflow_task', 'Update Record Workflow Task', 'Update the workflow task from the parameters passed. The current JSON representation of the workflow task should include these parameters: processCode, status, and statusDate. Otherwise, the update will fail.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10108', '/v3/records/{id}/location', 'GET', '/v3/records/{id}/location/?lang={lang}', 'get_record_location', 'Get Record Location', 'Get the record''s location by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10109', '/v3/records/{id}/workordertasks', 'GET', '/v3/records/{id}/workordertasks/?lang={lang}', 'get_record_workorder_tasks', 'Get Record Workorder Tasks', 'Get the record''s work order tasks by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10110', '/v3/records/{id}/conditionsummary/?lang={lang}', 'GET', '/v3/records/{id}/conditionsummary/?lang={lang}', 'get_record_condition_summary', 'Get Record Condition Summary', 'Get the record''s condition summary by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10111', '/v3/records/{id}/inspectionsummary/?lang={lang}', 'GET', '/v3/records/{id}/inspectionsummary/?lang={lang}', 'get_record_inspection_summary', 'Get Record Inspection Summary', 'Get the record''s inspection summary by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10112', '/v3/records/{id}/workflowsummary/?lang={lang}', 'GET', '/v3/records/{id}/workflowsummary/?lang={lang}', 'get_record_workflow_summary', 'Get Record Workflow Summary', 'Get the record''s wrokflow summary by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10113', '/v3/records/{id}/feesummary/?lang={lang}', 'GET', '/v3/records/{id}/feesummary/?lang={lang}', 'get_record_fee_summary', 'Get Record Fee Summary', 'Get the record''s fee summary by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10114', '/v3/records/{id}/contactsummary/?lang={lang}', 'GET', '/v3/records/{id}/contactsummary/?lang={lang}', 'get_record_contact_summary', 'Get Record Contact Summary', 'Get the record''s fee summary by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10115', '/v3/records/{id}/projectinformations/?lang={lang}', 'GET', '/v3/records/{id}/projectinformations/?lang={lang}', 'get_record_project_informations', 'Get Record Project Informations', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10116', '/v3/records/{id}/usercomments', 'POST', '/v3/records/{id}/usercomments/?lang={lang}', 'create_record_user_comment', 'Create Record User Comment', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10117', '/v3/records/{id}/usercomments', 'GET', '/v3/records/{id}/usercomments/?lang={lang}&offset={offset}&limit={limit}', 'get_record_user_comments', 'Get Record User Comments', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10118', '/v3/records/{id}/votes', 'POST', '/v3/records/{id}/votes/?Lang={LANG}', 'create_record_vote', 'Create Record Vote', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10119', '/v3/records/{id}/votes', 'GET', '/v3/records/{id}/votes/?Lang={LANG}', 'get_record_votes', 'Get Record Votes', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10120', '/v3/records/{id}/useractivitiessummary', 'GET', '/v3/records/{id}/useractivitiessummary/?Lang={LANG}', 'get_record_user_activities_summary', 'Get User Activities Summary', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10121', '/v3/records/{id}/asis/drilldowns/{drillDownId}', 'GET', '/v3/records/{id}/asis/drilldowns/{drillDownId}/?Lang={LANG}', 'get_record_asi_drilldown', 'Get Record ASI Drilldown', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10122', '/v3/records/{id}/asis/drilldowns/{drillDownId}/{parentValueId}', 'GET', '/v3/records/{id}/asis/drilldowns/{drillDownId}/{parentValueId}/?Lang={LANG}', 'get_record_asi_drilldown_for_parent_item', 'Get Record ASI Drilldown With Parent Item', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10123', '/v3/records/{id}/asits/drilldowns/{drillDownId}', 'GET', '/v3/records/{id}/asits/drilldowns/{drillDownId}/?Lang={LANG}', 'get_record_asit_drilldown', 'Get Drilldowns', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null),
('b6385f30-4da0-11e2-a346-005056c10124', '/v3/records/{id}/asits/drilldowns/{drillDownId}/{parentValueId}', 'GET', '/v3/records/{id}/asits/drilldowns/{drillDownId}/{parentValueId}/?Lang={LANG}', 'get_record_asit_drilldown_for_parent_item', 'Get Record ASIT Drilldown For Parent Item', 'Get the record''s project informations by record id and some specified parameters.', 1, 0, 'System', '2012-12-24', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10086', '/v3/search/records', 'POST', '/v3/search/records/?expand={expand}&lang={lang}&offset={offset}&limit={limit}', 'search_records', 'Search Records', 'Return relevant records by specific queries. In this API, you can set expand=¡±Addresses¡± to get addresses object under return records. For agency app, the API didn¡¯t support bBox and geoCircle two conditions. For Ids, The Ids should be "id,id". Each id will use "," as separator', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10125', '/v3/system/address/streetPrefixes', 'GET', '/v3/system/address/streetPrefixes/?lang={lang}', 'get_ref_street_prefixes', 'Get Reference Data Street Prefixes', 'Get reference address street prefixes.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10126', '/v3/system/asset/statuses', 'GET', '/v3/system/asset/statuses/?lang={lang}', 'get_ref_asset_statuses', 'Get Reference Data Asset''s Statuses', 'Get reference asset''s statuses.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10127', '/v3/system/asset/types', 'GET', '/v3/system/asset/types/?lang={lang}', 'get_ref_asset_types', 'Get Reference Data Asset''s Types', 'Get Reference asset''s Types.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10128', '/v3/system/asset/unitTypes', 'GET', '/v3/system/asset/unitTypes/?lang={lang}', 'get_ref_asset_unit_types', 'Get Reference Data Asset''s Unit Types', 'Get reference unit types.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10129', '/v3/system/asset/asis', 'GET', '/v3/system/asset/asis/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_asset_asis', 'Get Reference Data Asset''s ASIs', 'Get reference additional information that defined for asset object.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10130', '/v3/system/asset/asits', 'GET', '/v3/system/asset/asits/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_asset_asits', 'Get Reference Data Asset''s ASITs', 'Get reference additional tables that defined for asset object.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10131', '/v3/system/inspection/checklists/{id}/items', 'GET', '/v3/system/inspection/checklists/{id}/items/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_checklist_items', 'Get Reference Data Checklist''s Items', 'Get checklist items by specific checklist ID.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10132', '/v3/system/inspection/checklists', 'GET', '/v3/system/inspection/checklists/?groupid={groupid}&lang={lang}&offset={offset}&limit={limit}', 'get_ref_checklists', 'Get Reference Data Checklists', 'Get all checklists or by specific checklist''s group ID.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10133', '/v3/system/common/standardComments', 'GET', '/v3/system/common/standardComments/?groups={groups}&lang={lang}&offset={offset}&limit={limit}', 'get_ref_standard_comments', 'Get Reference Data Standard Comments', 'Get all checklists or by specific checklist''s group ID.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10134', '/v3/system/common/standardCommentGroups', 'GET', '/v3/system/common/standardCommentGroups/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_standard_comment_groups', 'Get Reference Data Standard Comment Groups', 'Get all checklists or by specific checklist''s group ID.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10135', '/v3/system/common/modules', 'GET', '/v3/system/common/modules/?lang={lang}', 'get_ref_modules', 'Get Reference Data Modules', 'Get all checklists or by specific checklist''s group ID.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10136', '/v3/system/common/departments', 'GET', '/v3/system/common/departments/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_departments', 'Get Reference Data Departments', 'Get all checklists or by specific checklist''s group ID.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10137', '/v3/system/common/departments/{id}/staffs', 'GET', '/v3/system/common/departments/{id}/staffs/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_staffs', 'Get Reference Data Staffs', 'Get all checklists or by specific checklist''s group ID.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10138', '/v3/system/common/workordertemplates', 'GET', '/v3/system/common/workordertemplates/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_work_order_templates', 'Get Reference Data Work Order Templates', 'Get all checklists or by specific checklist''s group ID.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10139', '/v3/system/contact/types', 'GET', '/v3/system/contact/types/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_contact_types', 'Get Reference Data Contact''s Types', 'Get all checklists or by specific checklist''s group ID.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10142', '/v3/system/document/types', 'GET', '/v3/system/document/types/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_document_types', 'Get Reference Data Document Types', 'Get a part of the attachment document types limited by ''offset'' and ''limit''.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10143', '/v3/system/inspection/groups', 'GET', '/v3/system/inspection/groups/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_inspection_groups', 'Get Reference Data Inspection Groups', 'Return inspection groups.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10144', '/v3/system/inspection/groups/{id}/types', 'GET', '/v3/system/inspection/groups/{id}/types/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_inspection_types', 'Get Reference Data Inspection Types', 'Get the system inspection types  of a inspection group. need affording the inspection group id. ', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10145', '/v3/system/inspection/inspectors', 'GET', '/v3/system/inspection/inspectors/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_inspectors', 'Get Reference Data Inspectors', 'Get the Inspectors match specified queries.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10146', '/v3/system/inspection/checklist/groups', 'GET', '/v3/system/inspection/checklist/groups/?lang={lang}&offset={offset}&limit={limit}', 'get_ref_inspection_checklist_groups', 'Get Reference Data Inspection Checklist Groups', 'Get all checklist''s groups.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056c10148', '/v3/system/record/types', 'GET', '/v3/system/record/types/?lang={lang}&offset={offset}&limit={limit}&module={module}', 'get_ref_record_types', 'Get Reference Data Record Types', 'Gets Record types by module. Note: Example /system/record/types/?module=Building', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10149', '/v3/system/record/type/{id}/asis', 'GET', '/v3/system/record/type/{id}/asis/?lang={lang}', 'get_ref_record_type_asis', 'Get Reference Data Record Type ASIs', 'Get Record type''s additional information for specific record type.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10150', '/v3/system/record/type/{id}/asits', 'GET', '/v3/system/record/type/{id}/asits/?lang={lang}', 'get_ref_record_type_asits', 'Get Reference Data Record Type ASITs', 'Get Record type''s additional tables for specific record type.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10151', '/v3/system/record/type/{typeId}/statuses', 'GET', '/v3/system/record/type/{typeId}/statuses/?lang={lang}', 'get_ref_record_type_statuses', 'Get Reference Data Record Type Statuses', 'Get Record type¡¯s statuses for specific record type.', 1, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056c10152', '/v3/system/record/priorities', 'GET', '/v3/system/record/priorities/?lang={lang}', 'get_ref_record_priorities', 'Get Reference Data Record Priorities', 'Get reference record priorities.', 1, 0, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056110001', '/apis/v3/resources', 'GET', '/apis/v3/resources/?lang={lang}', 'get_resources', 'Get Resources', 'Returns all available APIs.', 3, 2, 'System', '2012-12-31', null, null)
INSERT INTO Resources(Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, Description, AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate) 
VALUES
('b6385f30-4da0-11e2-a346-005056112080', '/sso/ticket', 'POST', '/sso/ticket', 'get_sso_ticket', 'Get SSO Ticket', 'Returns a SSO Ticket.', 0, 0, 'System', '2012-12-31', null, null),
('b6385f30-4da0-11e2-a346-005056112081', '/oauth2/token', 'POST', '/oauth2/token', 'get_oauth2_token', 'Get oAuth2 Token', 'Returns an access token.', 0, 0, 'System', '2012-12-31', null, null)

