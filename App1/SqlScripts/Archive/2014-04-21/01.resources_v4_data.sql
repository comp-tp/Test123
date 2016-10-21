UPDATE RESOURCES
SET SupportedAAVersions='7.3.2'
WHERE api LIKE '/v4/%'

UPDATE RESOURCES
SET ResourceGroupName='Payments'
WHERE api LIKE '/v4/%' and ResourceGroupName='Cashier'

UPDATE RESOURCES
SET DisplayName='Get Contact', Description='Get Contact'
WHERE id='C4012345-AAAA-BBBB-CCCC-123456700104'

IF EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [api] = N'/v4/settings/modules')
BEGIN
	DELETE from resources where api='/v4/settings/modules'
END
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700212', N'/v4/settings/modules', N'GET', N'/v4/settings/modules?lang={lang}', N'get_settings_modules', N'Get Modules', N'Get Modules', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/modules?lang={lang}', N'getModules', N'All', N'7.3.2', NULL, N'Settings', NULL)

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [api] = N'/v4/contacts' and HttpVerb=N'GET' )
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700232', N'/v4/contacts', N'GET', N'/v4/contacts?lang={lang}&state={state}&country={country}&firstName={firstName}&middleName={middleName}&lastName={lastName}&email={email}&addressLine1={addressLine1}&addressLine2={addressLine2}&addressLine3={addressLine3}&businessName={businessName}&city={city}&title={title}&offset={offset}&limit={limit}&fields={fields}', N'get_contacts', N'Get Contacts', N'Get Contacts', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/contacts?lang={lang}&state={state}&country={country}&firstName={firstName}&middleName={middleName}&lastName={lastName}&email={email}&addressLine1={addressLine1}&addressLine2={addressLine2}&addressLine3={addressLine3}&businessName={businessName}&city={city}&title={title}&offset={offset}&limit={limit}&fields={fields}', N'getContacts', N'All', N'7.3.2', NULL, N'Contacts', NULL)
END
ELSE
BEGIN
        UPDATE [dbo].[Resources] SET [RelativeUriTemplateFull] = N'/v4/contacts?lang={lang}&state={state}&country={country}&firstName={firstName}&middleName={middleName}&lastName={lastName}&email={email}&addressLine1={addressLine1}&addressLine2={addressLine2}&addressLine3={addressLine3}&businessName={businessName}&city={city}&title={title}&offset={offset}&limit={limit}&fields={fields}' , ProxyAPI = N'/apis/v4/contacts?lang={lang}&state={state}&country={country}&firstName={firstName}&middleName={middleName}&lastName={lastName}&email={email}&addressLine1={addressLine1}&addressLine2={addressLine2}&addressLine3={addressLine3}&businessName={businessName}&city={city}&title={title}&offset={offset}&limit={limit}&fields={fields}' WHERE [api] = N'/v4/contacts' and HttpVerb=N'GET'
END


IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [api] = N'/v4/settings/records/expirationStatuses' and HttpVerb=N'GET' )
BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700233', N'/v4/settings/records/expirationStatuses', N'GET', N'/v4/settings/records/expirationStatuses?lang={lang}', N'get_settings_record_expierationStatuses', N'Get Record Expiration Statuses', N'Get Record Expiration Statuses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/records/renewal/expirationStatuses?lang={lang}', N'getRecordExpirationStatuses', N'All', N'7.3.2', NULL, N'Records', NULL)
END

UPDATE [dbo].[resources] set RelativeUriTemplateFull = N'/v4/records/{ids}?lang={lang}&expand={expand}&fields={fields}', ProxyAPI = N'/apis/v4/records/{ids}?lang={lang}&expand={expand}&fields={fields}' where name ='get_record' and api = '/v4/records/{ids}'

-- Change auth type of API GET /v4/agencies/{name} from access token to no auth.
UPDATE [dbo].[resources]
SET AuthenticationType = 0
WHERE id = 'C4012345-AAAA-BBBB-CCCC-123456700201'

-- Change auth type of API GET /v4/agencies/{name}/logo from access token to no auth.
UPDATE [dbo].[resources]
SET AuthenticationType = 0
WHERE id = 'C4012345-AAAA-BBBB-CCCC-123456700202'

-- Change auth type of API GET /v4/agencies from access token to no auth.
UPDATE [dbo].[resources]
SET AuthenticationType = 0
WHERE id = 'C4012345-AAAA-BBBB-CCCC-123456700225'

UPDATE [dbo].[resources] set Applicability = N'Agency' where httpverb ='POST' and api = '/v4/records/{recordId}/fees'
