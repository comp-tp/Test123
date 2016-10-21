if not exists(select * from [dbo].[Resources] where Id ='5A449069-FB43-4912-90F2-400550D6876F' or ( HttpVerb='GET' and API='/v4/users'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('5A449069-FB43-4912-90F2-400550D6876F', '/v4/users', 'GET', '/v4/users?groupId={groupId}&groupName={groupName}&module={module}&status={status}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_users', 'get_users', NULL, 5, 0, 'david.jiang', 'May  7 2015  6:58AM', NULL, NULL, '/apis/v4/users?groupId={groupId}&groupName={groupName}&module={module}&status={status}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'Agency', NULL, '7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end

delete from [dbo].[Resources] where Id ='11D38658-C41E-48A5-91C3-E0D7355202B9'
if not exists(select * from [dbo].[Resources] where Id ='5CD60DBF-9A8D-4ACB-8740-F1731C4C7375' or ( HttpVerb='PUT' and API='/V4/payments/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('5CD60DBF-9A8D-4ACB-8740-F1731C4C7375', '/V4/payments/{id}', 'PUT', '/V4/payments/{id}?fields={fields}&lang={lang}', 'confirm_payment', 'confirm_payment', NULL, 5, 0, 'moss.li@beyondsoft.com', 'May  8 2015  8:57AM', 'moss.li@beyondsoft.com', 'May  8 2015  8:57AM', '/apis/V4/payments/{id}?fields={fields}&lang={lang}', 'Citizen', NULL, '7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='F6FE9E4A-550A-4C37-A818-F1FE529C9C43' or ( HttpVerb='GET' and API='/v4/citizenaccess/citizens/delegatePrivileges'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('F6FE9E4A-550A-4C37-A818-F1FE529C9C43', '/v4/citizenaccess/citizens/delegatePrivileges', 'GET', '/v4/citizenaccess/citizens/delegatePrivileges?offset={offset}&limit={limit}&lang={lang}', 'get_citizens_delegateprivileges', 'get_citizens_delegateprivileges', NULL, 5, 0, 'david.jiang', 'May  8 2015  2:55AM', 'david.jiang', 'May  8 2015  2:59AM', '/apis/v4/citizens/delegatePrivileges?offset={offset}&limit={limit}&lang={lang}', 'Citizen', NULL, '7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='A1941138-A4A2-4B1F-8BE0-5184DA04F214' or ( ScopeName='get_users' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('A1941138-A4A2-4B1F-8BE0-5184DA04F214', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_users', 'david.jiang', 'May  7 2015  6:58AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='0AC581D8-CBA5-4668-92A3-64FAEF7111A4' or ( ScopeName='confirm_payment' and GroupId='3649EBCE-C5C9-4C79-BD92-E37A0C9C3057'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('0AC581D8-CBA5-4668-92A3-64FAEF7111A4', '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057', 'confirm_payment', 'moss.li@beyondsoft.com', 'May  8 2015  8:57AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='1BDF6179-7E23-4353-A9AF-296758414658' or ( ScopeName='get_citizens_delegateprivileges' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('1BDF6179-7E23-4353-A9AF-296758414658', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizens_delegateprivileges', 'david.jiang', 'May  8 2015  2:55AM', NULL, NULL)
end 

update [dbo].[Resources]
set
	 LastUpdatedDate='May  7 2015 12:59AM'
	,LastUpdatedBy='moss.li@beyondsoft.com'
	,ProxyAPI='/apis/V4/payments?lang={lang}'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700215'

update [dbo].[Resources]
set
	 LastUpdatedDate='Apr 30 2015  7:12AM'
	,LastUpdatedBy='kay.li@beyondsoft.com'
	,Applicability='All'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700041'

