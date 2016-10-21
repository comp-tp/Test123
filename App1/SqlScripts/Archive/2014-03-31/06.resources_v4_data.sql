IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700230')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700230', N'/v4/records/{recordId}/payments', N'POST', N'/v4/records/{recordId}/payments?lang={lang}', N'get_record_payments', N'Get Record Payments', N'Get Record Payments', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/payments?lang={lang}', N'getRecordPayments', N'All', N'7.3.1', NULL, N'records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700231')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700231', N'/v4/records/{recordId}/payments/{paymentId}', N'POST', N'/v4/records/{recordId}/payments/{paymentId}?lang={lang}', N'get_record_payment', N'Get Record Payment', N'Get Record Payment', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/payments/{paymentId}?lang={lang}', N'getRecordPayment', N'All', N'7.3.1', NULL, N'records', NULL)
END


UPDATE [dbo].[Resources] set [RelativeUriTemplateFull] ='/v4/appdata/{container}/{blobname}/?lang={lang}&appid={appid}' where ID='C4012345-AAAA-BBBB-CCCC-123456700196'
UPDATE [dbo].[Resources] set [API] ='/v4/payments' where ID='C4012345-AAAA-BBBB-CCCC-123456700215'
UPDATE [dbo].[Resources] set [RelativeUriTemplateFull] ='/v4/records/{recordId}/votes/summary/?Lang={LANG}' where ID='C4012345-AAAA-BBBB-CCCC-123456700210'
