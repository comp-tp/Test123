 IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [api] = N'/v4/settings/timeAccounting/groups?userIds={userIds}' and HttpVerb=N'GET' )
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) 
	VALUES ( 'C401E345-AAAA-BBBB-CCCC-1234F6700050', N'/v4/settings/timeAccounting/groups', N'GET', N'/v4/settings/timeAccounting/groups?userIds={userIds}&lang={lang}', N'get_settings_time_accounting_groups', N'Get Settings Time Accounting Groups', N'Get Settings Time Accounting Groups', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/timeAccounting/groups?userIds={userIds}&lang={lang}', N'getTimeAccountingGroups', N'All', N'7.3.2', NULL, N'Settings', NULL)
END
ELSE
BEGIN
        UPDATE [dbo].[Resources] SET [RelativeUriTemplateFull] = N'/v4/settings/timeAccounting/groups?userIds={userIds}&lang={lang}' , ProxyAPI = N'/apis/v4/settings/timeAccounting/groups?userIds={userIds}&lang={lang}' WHERE [api] = N'/v4/settings/timeAccounting/groups' and HttpVerb=N'GET'
END

 IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [api] = N'/v4/settings/timeAccounting/types?groupId={groupId}&userIds={userIds}&recordType={recordType}' and HttpVerb=N'GET' )
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) 
	VALUES ( 'C401E345-AAAA-BBBB-CCCC-1234F6700051', N'/v4/settings/timeAccounting/types', N'GET', N'/v4/settings/timeAccounting/types?groupId={groupId}&userIds={userIds}&recordType={recordType}&lang={lang}', N'get_settings_time_accounting_types', N'Get Settings Time Accounting Types', N'Get Settings Time Accounting Types', 0, 11, N'System', getdate(), Null, Null, N'/v4/settings/timeAccounting/types?groupId={groupId}&userIds={userIds}&recordType={recordType}&lang={lang}', N'getTimeAccountingTypes', N'All', N'7.3.2', NULL, N'Settings', NULL)
END
ELSE
BEGIN
        UPDATE [dbo].[Resources] SET [RelativeUriTemplateFull] = N'/v4/settings/timeAccounting/types?groupId={groupId}&userIds={userIds}&recordType={recordType}&lang={lang}' , ProxyAPI = N'/apis/v4/settings/timeAccounting/types?groupId={groupId}&userIds={userIds}&recordType={recordType}&lang={lang}' WHERE [api] = N'/v4/settings/timeAccounting/types' and HttpVerb=N'GET'
END

UPDATE RESOURCES SET [NAME] = 'get_settings_contact_type_customforms'  , [DISPLAYNAME] = 'Get Settings Contact Type Customforms', [DESCRIPTION] = 'Get Settings Contact Type Customforms' ,[METHODNICKNAME] = 'GetContactTypeCustomforms' WHERE API = '/v4/settings/contacts/types/{id}/customForms' AND HTTPVERB = 'GET'

update resources set displayname = 'Get All Settings for App' where name='get_app_settings'
update resources set displayname = 'Get Current User Profile' where name='get_civicid_profile'