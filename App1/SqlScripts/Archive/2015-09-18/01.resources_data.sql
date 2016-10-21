
if not exists(select * from [dbo].[Resources] where Id ='272E7FDA-6AE8-47E4-B759-D58DB8915B42' or ( HttpVerb='GET' and API='/v4/citizenaccess/citizens/{id}/trustAccounts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('272E7FDA-6AE8-47E4-B759-D58DB8915B42', '/v4/citizenaccess/citizens/{id}/trustAccounts', 'GET', '/v4/citizenaccess/citizens/{id}/trustAccounts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_citizenaccess_trustaccounts', 'get_citizenaccess_trustaccounts', NULL, 5, 0, 'Bryant-Tu', 'Apr 23 2015  6:39AM', 'devin.yao@beyondsoft.com', 'Apr 24 2015  6:32AM', '/apis/v4/citizens/{id}/trustAccounts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='F5C9F6A5-B045-4F76-B4E7-483BEA74B018' or ( HttpVerb='GET' and API='/v4/citizenaccess/citizens/delegates'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('F5C9F6A5-B045-4F76-B4E7-483BEA74B018', '/v4/citizenaccess/citizens/delegates', 'GET', '/v4/citizenaccess/citizens/delegates?userName={userName}&name={name}&delegateStatus={delegateStatus}&offset={offset}&limit={limit}&lang={lang}', 'get_citizenaccess_citizens_delegates', 'get_citizenaccess_citizens_delegates', NULL, 5, 0, 'Enhui', 'Apr  1 2015 11:39PM', 'Enhui', 'Apr  1 2015 11:39PM', '/apis/v4/citizens/delegates?userName={userName}&name={name}&delegateStatus={delegateStatus}&offset={offset}&limit={limit}&lang={lang}', 'Citizen', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='03183E54-BB07-41B7-A624-9DCB5ED5668F' or ( HttpVerb='GET' and API='/v4/citizenaccess/citizens/invitations'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('03183E54-BB07-41B7-A624-9DCB5ED5668F', '/v4/citizenaccess/citizens/invitations', 'GET', '/v4/citizenaccess/citizens/invitations?userName={userName}&name={name}&delegateStatus={delegateStatus}&offset={offset}&limit={limit}&lang={lang}', 'get_citizenaccess_citizens_invitations', 'get_citizenaccess_citizens_invitations', NULL, 5, 0, 'Enhui', 'Apr  1 2015 11:40PM', 'Enhui', 'Apr  1 2015 11:41PM', '/apis/v4/citizens/invitations?userName={userName}&name={name}&delegateStatus={delegateStatus}&offset={offset}&limit={limit}&lang={lang}', 'Citizen', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='FA0A94C4-6BEC-4C51-AFE2-7D682743E2C7' or ( HttpVerb='GET' and API='/v4/citizens/{id}/accounts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('FA0A94C4-6BEC-4C51-AFE2-7D682743E2C7', '/v4/citizens/{id}/accounts', 'GET', '/v4/citizens/{id}/accounts?lang={lang}', 'get_citizens_accounts', 'get_citizens_accounts', NULL, 5, 0, 'Bryant-Tu', 'Apr 21 2015  1:53AM', 'Bryant-Tu', 'Apr 21 2015  1:55AM', '/apis/v4/citizens/{id}/accounts?lang={lang}', 'All', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='AED6FD04-5F16-439E-802C-7DFF5124DC19' or ( HttpVerb='POST' and API='/v4/civicid/accounts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('AED6FD04-5F16-439E-802C-7DFF5124DC19', '/v4/civicid/accounts', 'POST', '/v4/civicid/accounts?lang={lang}', 'create_civicid_accounts', 'create_civicid_accounts', NULL, 1, 0, 'vsamaresan', 'Apr  7 2015 11:07PM', 'cwoo@accela.com', 'Apr 28 2015 10:45PM', '/apis/v4/civicid/accounts?lang={lang}', 'All', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 0, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='5B3AC5BC-B057-47AD-81D2-90455FDCE430' or ( HttpVerb='POST' and API='/v4/documentReview/documents/{documentId}/comments'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('5B3AC5BC-B057-47AD-81D2-90455FDCE430', '/v4/documentReview/documents/{documentId}/comments', 'POST', '/v4/documentReview/documents/{documentId}/comments?fields={fields}&lang={lang}', 'create_documentreview_documents_comments', 'create_documentreview_documents_comments', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb  2 2015  8:39AM', 'kay.li@beyondsoft.com', 'Mar  6 2015  7:24AM', '/apis/v4/documentReview/documents/{documentId}/comments?fields={fields}&lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='4A22D3DA-AA1F-4106-BAB0-E6F21C39BC50' or ( HttpVerb='PUT' and API='/v4/documentReview/documents/{documentId}/comments/{commentId}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('4A22D3DA-AA1F-4106-BAB0-E6F21C39BC50', '/v4/documentReview/documents/{documentId}/comments/{commentId}', 'PUT', '/v4/documentReview/documents/{documentId}/comments/{commentId}?fields={fields}&lang={lang}', 'update_documentreview_documents_comments', 'update_documentreview_documents_comments', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb  2 2015  8:59AM', 'kay.li@beyondsoft.com', 'Mar 17 2015  2:56AM', '/apis/v4/documentReview/documents/{documentId}/comments/{commentId}?fields={fields}&lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='F9D63226-B7F5-4028-B628-2EF3A1CDAC7E' or ( HttpVerb='DELETE' and API='/v4/documentReview/documents/{documentId}/comments/{commentIds}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('F9D63226-B7F5-4028-B628-2EF3A1CDAC7E', '/v4/documentReview/documents/{documentId}/comments/{commentIds}', 'DELETE', '/v4/documentReview/documents/{documentId}/comments/{commentIds}?fields={fields}&lang={lang}', 'delete_documentreview_documents_comments', 'delete_documentreview_documents_comments', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb  2 2015  8:18AM', 'kay.li', 'Feb  6 2015  9:22AM', '/apis/v4/documentReview/documents/{documentId}/comments/{commentIds}?fields={fields}&lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='1067D3D7-7CDD-497B-91A8-457657992AAC' or ( HttpVerb='GET' and API='/v4/documentReview/documents/{documentId}/comments/{commentIds}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('1067D3D7-7CDD-497B-91A8-457657992AAC', '/v4/documentReview/documents/{documentId}/comments/{commentIds}', 'GET', '/v4/documentReview/documents/{documentId}/comments/{commentIds}?isActive={isActive}&fields={fields}&lang={lang}', 'get_documentreview_documents_comments', 'get_documentreview_documents_comments', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb  2 2015  8:21AM', 'kay.li', 'Feb  6 2015  9:23AM', '/apis/v4/documentReview/documents/{documentId}/comments/{commentIds}?isActive={isActive}&fields={fields}&lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='E45E52AF-8C37-45DB-863C-9518536D3474' or ( HttpVerb='PUT' and API='/v4/documentReview/documents/{documentId}/tasks/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('E45E52AF-8C37-45DB-863C-9518536D3474', '/v4/documentReview/documents/{documentId}/tasks/{id}', 'PUT', '/v4/documentReview/documents/{documentId}/tasks/{id}?fields={fields}&lang={lang}', 'update_documentreview_documents_tasks', 'update_documentreview_documents_tasks', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb  2 2015  8:59AM', 'kay.li', 'Feb  6 2015  9:23AM', '/apis/v4/documentReview/documents/{documentId}/tasks/{id}?fields={fields}&lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

delete from [dbo].[Resources] where Id ='C4012345-AAAA-BBBB-CCCC-123456700057'

delete from [dbo].[Resources] where Id ='C4012345-AAAA-BBBB-CCCC-123456700139'

delete from [dbo].[Resources] where Id ='C4012345-AAAA-BBBB-CCCC-123456700140'

delete from [dbo].[Resources] where Id ='3754E633-E396-4B8F-A3C8-51C3C70F3707'

delete from [dbo].[Resources] where Id ='F5A90B82-4440-4E91-81E8-665AD1828044'

delete from [dbo].[Resources] where Id ='8EABF719-4568-4AE7-875B-85811FB63553'

if not exists(select * from [dbo].[Resources] where Id ='443AECFF-E7F4-468A-AAAD-69E6B9F64675' or ( HttpVerb='POST' and API='/v4/documentReview/records/{recordId}/documents'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('443AECFF-E7F4-468A-AAAD-69E6B9F64675', '/v4/documentReview/records/{recordId}/documents', 'POST', '/v4/documentReview/records/{recordId}/documents?lang={lang}', 'create_documentreview_records_documents', 'create_documentreview_records_documents', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb  2 2015  8:58AM', 'kay.li', 'Feb  6 2015  9:23AM', '/apis/v4/documentReview/records/{recordId}/documents?lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='4CA7BF8D-3E9F-4CF5-A13C-84BF40BC9808' or ( HttpVerb='POST' and API='/v4/documentReview/records/{recordId}/documents/{documentId}/checkin'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('4CA7BF8D-3E9F-4CF5-A13C-84BF40BC9808', '/v4/documentReview/records/{recordId}/documents/{documentId}/checkin', 'POST', '/v4/documentReview/records/{recordId}/documents/{documentId}/checkin?lang={lang}', 'create_documentreview_records_documents_checkin', 'create_documentreview_records_documents_checkin', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Mar 17 2015  2:35AM', 'kay.li@beyondsoft.com', 'Mar 17 2015  5:47AM', '/apis/v4/documentReview/records/{recordId}/documents/{documentId}/checkin?lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='33A57B93-6B82-4713-A60A-831AAB9B60D0' or ( HttpVerb='POST' and API='/V4/payments/initialize'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('33A57B93-6B82-4713-A60A-831AAB9B60D0', '/V4/payments/initialize', 'POST', '/V4/payments/initialize?fields={fields}&lang={lang}', 'payments_initialize', 'payments_initialize', NULL, 5, 0, 'moss.li@beyondsoft.com', 'Apr 16 2015  9:44AM', 'cwoo@accela.com', 'Apr 17 2015  4:09PM', '/apis/V4/payments/initialize?fields={fields}&lang={lang}', 'Citizen', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='BCECE5E9-757A-491D-A9A2-034977231CA7' or ( HttpVerb='POST' and API='/v4/search/contacts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('BCECE5E9-757A-491D-A9A2-034977231CA7', '/v4/search/contacts', 'POST', '/v4/search/contacts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'search_contacts', 'search_contacts', NULL, 5, 0, 'moss.li@beyondsoft.com', 'Apr 22 2015  8:44AM', 'moss.li@beyondsoft.com', 'Apr 22 2015  8:45AM', '/apis/v4/search/contacts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='CC323589-08FB-462B-8791-608330039C32' or ( HttpVerb='GET' and API='/v4/settings/inspections/types'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('CC323589-08FB-462B-8791-608330039C32', '/v4/settings/inspections/types', 'GET', '/v4/settings/inspections/types?lang={lang}&expand={expand}&offset={offset}&limit={limit}&fields={fields}&group={group}', 'get_settings_inspection_types', 'get_settings_inspections_types', NULL, 5, 0, 'ashley.zou@beyondsoft.com', 'Apr  3 2015  1:53AM', 'kay.li@beyondsoft.com', 'Apr 10 2015  2:15AM', '/apis/v4/settings/inspections/types?group={group}&limit={limit}&expand={expand}&offset={offset}&fields={fields}&lang={lang}', 'All', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='E3834883-3ED6-4B30-A009-1F6FE8F4E008' or ( HttpVerb='GET' and API='/v4/settings/inspections/types/{ids}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('E3834883-3ED6-4B30-A009-1F6FE8F4E008', '/v4/settings/inspections/types/{ids}', 'GET', '/v4/settings/inspections/types/{ids}?expand={expand}&fields={fields}&lang={lang}', 'get_settings_inspection_type', 'get_settings_inspection_type', NULL, 5, 0, 'ashley.zou@beyondsoft.com', 'Apr  3 2015  2:42AM', 'kay.li@beyondsoft.com', 'Apr 10 2015  2:16AM', '/apis/v4/settings/inspections/types/{ids}?expand={expand}&fields={fields}&lang={lang}', 'All', NULL, 'AA7.3.3.5.0', NULL, NULL, NULL, 1, 0)
end 

update [dbo].[Resources]
set
	 LastUpdatedDate='Apr 27 2015  2:52AM'
	,RelativeUriTemplateFull='/v4/citizenaccess/citizens?loginName={loginName}&expand={expand}&offset={offset}&limit={limit}&fields={fields}&lang={lang}'
	,LastUpdatedBy='admin'
where Id ='BE4ED385-D9B3-449F-9AC1-5EF47733B081'

update [dbo].[Resources]
set
	 LastUpdatedDate='Apr 27 2015  3:21AM'
	,RelativeUriTemplateFull='/v4/citizenaccess/profile?expand={expand}&fields={fields}&lang={lang}'
	,LastUpdatedBy='admin'
where Id ='B272B489-A640-45D3-A343-35D1D346F349'

update [dbo].[Resources]
set
	 LastUpdatedDate='Apr 27 2015  2:58AM'
	,LastUpdatedBy='Bryant-Tu'
	,ProxyAPI='/apis/v4/records/{recordId}/fees?fields={fields}&status={status}&lang={lang}'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700039'

update [dbo].[Resources]
set
	 LastUpdatedDate='Apr  9 2015  3:35AM'
	,AuthenticationType='0'
	,LastUpdatedBy='Bryant-Tu'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700030'

update [dbo].[Resources]
set
	 LastUpdatedDate='Apr 15 2015  8:50AM'
	,LastUpdatedBy='kay.li@beyondsoft.com'
	,ProxyAPI='/apis/v4/search/records/?offset={offset}&limit={limit}&expand={expand}&fields={fields}&lang={lang}'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700060'

if not exists(select * from [dbo].[Resources] where Id ='70D39230-C905-4C67-B35B-0B89395EED35' or ( HttpVerb='POST' and API='/v4/batch'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('70D39230-C905-4C67-B35B-0B89395EED35', '/v4/batch', 'POST', '/v4/batch', 'batch_request', 'batch_request', NULL, 0, 0, 'Jackie Yu', 'Apr 29 2015 10:41PM', 'Jackie Yu', 'Apr 29 2015 10:41PM', '/apis/v4/batch', 'All', NULL, 'TBD', NULL, NULL, NULL, 0, 0)
end


update [dbo].[Resources]
set
	 LastUpdatedDate='May  1 2015 12:35AM'
	,APIAttribute='0'
	,LastUpdatedBy='vsamaresan'
where Id ='5B3AC5BC-B057-47AD-81D2-90455FDCE430'

update [dbo].[Resources]
set
	 LastUpdatedDate='May  1 2015 12:47AM'
	,APIAttribute='0'
	,LastUpdatedBy='vsamaresan'
where Id ='E45E52AF-8C37-45DB-863C-9518536D3474'

update [dbo].[Resources]
set
	 LastUpdatedDate='May  1 2015 12:50AM'
	,APIAttribute='0'
	,LastUpdatedBy='vsamaresan'
where Id ='4CA7BF8D-3E9F-4CF5-A13C-84BF40BC9808'

update [dbo].[Resources]
set
	 LastUpdatedDate='May  1 2015 12:47AM'
	,APIAttribute='0'
	,LastUpdatedBy='vsamaresan'
where Id ='1067D3D7-7CDD-497B-91A8-457657992AAC'

update [dbo].[Resources]
set
	 LastUpdatedDate='May  1 2015 12:46AM'
	,APIAttribute='0'
	,LastUpdatedBy='vsamaresan'
where Id ='F9D63226-B7F5-4028-B628-2EF3A1CDAC7E'

update [dbo].[Resources]
set
	 LastUpdatedDate='May  1 2015 12:49AM'
	,APIAttribute='0'
	,LastUpdatedBy='vsamaresan'
where Id ='443AECFF-E7F4-468A-AAAD-69E6B9F64675'

update [dbo].[Resources]
set
	 LastUpdatedDate='May  1 2015 12:45AM'
	,APIAttribute='0'
	,LastUpdatedBy='vsamaresan'
where Id ='4A22D3DA-AA1F-4106-BAB0-E6F21C39BC50'


-- Update Search agencies as construct api
Update Resources set  isproxy=0, IsAAGovxmlAPI = 0 where id='C4012345-AAAA-BBBB-CCCC-D23456700234'


if not exists(select * from [dbo].[Resources] where Id ='7766ABAE-D7A3-4F50-8C4E-7A6F2E3498FC' or ( HttpVerb='GET' and API='/v3/imagestorage/{container}/{blobName}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('7766ABAE-D7A3-4F50-8C4E-7A6F2E3498FC', '/v3/imagestorage/{container}/{blobName}', 'GET', '/v3/imagestorage/{container}/{blobName}', 'get_storage_image', 'get_storage_image', NULL, 0, 1, 'xinter-peng', 'Jun 04 2015  4:50PM', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0)
end 


