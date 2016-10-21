
-- The API should be configured to AuthenticationType=0
update Resources
set AuthenticationType=0
where API='/v4/async/result' and httpVerb='GET' and AuthenticationType=5

-- The API should be configured to AuthenticationType=0
update Resources
set AuthenticationType=0
where API='/v3/async/result' and httpVerb='GET' and AuthenticationType=5

if not exists(select * from [dbo].[Resources] where Id ='3B0CB71A-EF15-4935-9973-62BCD94921EC' or ( HttpVerb='GET' and API='/v4/contacts/{id}/records'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('3B0CB71A-EF15-4935-9973-62BCD94921EC', '/v4/contacts/{id}/records', 'GET', '/v4/contacts/{id}/records?types={types}&statuses={statuses}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_contact_records', 'get_contact_records', NULL, 5, 0, 'bryant.tu', 'Dec  8 2014  8:10AM', NULL, NULL, '/apis/v4/contacts/{id}/records?types={types}&statuses={statuses}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='460C74C4-65EE-48A7-9BA9-43986AE72708' or ( HttpVerb='GET' and API='/v4/settings/userGroups'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('460C74C4-65EE-48A7-9BA9-43986AE72708', '/v4/settings/userGroups', 'GET', '/v4/settings/userGroups?module={module}&fields={fields}&lang={lang}', 'get_settings_usergroups', 'get_settings_usergroups', NULL, 5, 0, 'Waikei.Tam', 'Dec 10 2014  7:11AM', 'Waikei.Tam', 'Dec 10 2014  7:11AM', '/apis/v4/settings/userGroups?module={module}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

update [dbo].[Resources]
set
	 LastUpdatedDate='Dec 10 2014  3:39AM'
	,RelativeUriTemplateFull='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems?fields={fields}&lang={lang}'
	,LastUpdatedBy='kevin.tang'
	,ProxyAPI='/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems?fields={fields}&lang={lang}'
	,Applicability='All'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700148'
