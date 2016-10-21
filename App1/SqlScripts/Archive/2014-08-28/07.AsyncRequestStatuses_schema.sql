SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)

GO