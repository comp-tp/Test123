IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [Id] = N'C4012345-AAAA-BBBB-CCCC-123456709000')
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription])
	VALUES ( 'C4012345-AAAA-BBBB-CCCC-123456709000', N'/v4/async/result', N'GET', N'/v4/async/result?requestId={requestId}', N'get_async_result', N'Get Async Result', N'Get Async Result', 0, 0, N'System', getdate(), NULL, NULL, NULL, N'getAsyncResult', N'All', '', NULL, NULL, NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [Id] = N'C4012345-AAAA-BBBB-CCCC-123456709001')
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription])
	VALUES ( 'C4012345-AAAA-BBBB-CCCC-123456709001', N'/v3/async/result', N'GET', N'/v3/async/result?requestId={requestId}', N'get_async_result', N'Get Async Result', N'Get Async Result', 0, 0, N'System', getdate(), NULL, NULL, NULL, N'getAsyncResult', N'All', '', NULL, NULL, NULL)
END	