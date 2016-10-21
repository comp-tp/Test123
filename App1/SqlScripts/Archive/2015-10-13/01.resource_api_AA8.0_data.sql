
if not exists(select * from [dbo].[Resources] where Id ='951C399F-D79D-4D98-ABBD-03BD564D1572' or ( HttpVerb='PUT' and API='/v4/subscriptions/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('951C399F-D79D-4D98-ABBD-03BD564D1572', '/v4/subscriptions/{id}', 'PUT', '/v4/subscriptions/{id}?lang={lang}', 'update_subscription', 'update_subscription', NULL, 2, 0, 'Bryant-Tu', 'Feb  9 2015  6:57AM', 'Bryant-Tu', 'Feb  9 2015  7:53AM', '/apis/v4/subscriptions/{id}?lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='8165B58E-7A76-4F7F-95DF-0A08AC8C3DAF' or ( HttpVerb='PUT' and API='/v4/records/{recordId}/workflowTasks/{taskId}/customForms'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('8165B58E-7A76-4F7F-95DF-0A08AC8C3DAF', '/v4/records/{recordId}/workflowTasks/{taskId}/customForms', 'PUT', '/v4/records/{recordId}/workflowTasks/{taskId}/customForms?lang={lang}', 'update_record_workflow_task_customforms', 'update_record_workflow_task_customforms', NULL, 5, 0, 'Bryant-Tu', 'Jan 12 2015  2:16AM', 'Bryant.Tu', 'Jan 14 2015  3:34AM', '/apis/v4/records/{recordId}/workflowTasks/{taskId}/customForms?lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='C4012345-AAAA-BBBB-CCCC-123456700040' or ( HttpVerb='GET' and API='/v4/inspectors'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('C4012345-AAAA-BBBB-CCCC-123456700040', '/v4/inspectors', 'GET', '/v4/inspectors?lang={lang}&department={department}', 'get_inspectors', 'Get All Inspectors', 'Get Inspectors', 5, 0, 'SystemImportor', 'Dec  2 2014  2:25AM', 'vsamaresan', 'May  5 2015 10:04PM', '/apis/v4/inspectors?department={department}&lang={lang}', 'Agency', 'getInspect', '7.3.2', NULL, 'Inspections', NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='C4012345-AAAA-BBBB-CCCC-123456700057' or ( HttpVerb='POST' and API='/v4/search/contacts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('C4012345-AAAA-BBBB-CCCC-123456700057', '/v4/search/contacts', 'POST', '/v4/search/contacts?lang={lang}&offset={offset}&limit={limit}', 'search_contacts', 'Search Contacts', 'Search Contacts', 5, 0, 'SystemImportor', 'Dec  2 2014  2:25AM', NULL, NULL, '/apis/v4/search/contacts?lang={lang}&offset={offset}&limit={limit}', 'All', 'searchCont', '7.3.2', NULL, 'Searches', NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='C4012345-AAAA-BBBB-CCCC-123456700140' or ( HttpVerb='GET' and API='/v4/settings/inspections/types/{ids}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('C4012345-AAAA-BBBB-CCCC-123456700140', '/v4/settings/inspections/types/{ids}', 'GET', '/v4/settings/inspections/types/{ids}?lang={lang}&fields={fields}', 'get_settings_inspection_type', 'Get Inspection Types', 'Get Inspection Types', 5, 0, 'SystemImportor', 'Dec  2 2014  2:25AM', NULL, NULL, '/apis/v4/settings/inspections/types/{ids}?lang={lang}&fields={fields}', 'All', 'getInspect', '7.3.2', NULL, 'Inspections', NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='6D456DA1-34DB-48F2-854C-1C1F0A4AFD4D' or ( HttpVerb='GET' and API='/v4/users/{ids}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('6D456DA1-34DB-48F2-854C-1C1F0A4AFD4D', '/v4/users/{ids}', 'GET', '/v4/users/{ids}?fields={fields}&lang={lang}', 'get_user', 'get_user', NULL, 5, 0, 'kevin.tang@beyondsoft.com', 'Aug  5 2015  8:20AM', 'kevin.tang@beyondsoft.com', 'Aug  5 2015  8:22AM', '/apis/v4/users/{ids}?fields={fields}&lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='E4AB4D74-05D5-4865-B308-2C4442EBF850' or ( HttpVerb='GET' and API='/v4/records/{recordId}/workflowTasks/{taskId}/customForms'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('E4AB4D74-05D5-4865-B308-2C4442EBF850', '/v4/records/{recordId}/workflowTasks/{taskId}/customForms', 'GET', '/v4/records/{recordId}/workflowTasks/{taskId}/customForms?lang={lang}', 'get_record_workflow_task_customforms', 'get_records_workflowtasks_customforms', NULL, 5, 0, 'david.jiang', 'Jan 12 2015  2:41AM', 'david.jiang', 'Jan 14 2015  6:29AM', '/apis/v4/records/{recordId}/workflowTasks/{taskId}/customForms?lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='75A0BBAF-4C05-4B86-8EEF-3187F1B50589' or ( HttpVerb='DELETE' and API='/v4/subscriptions/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('75A0BBAF-4C05-4B86-8EEF-3187F1B50589', '/v4/subscriptions/{id}', 'DELETE', '/v4/subscriptions/{id}?lang={lang}', 'delete_subscriptions', 'delete_subscriptions', NULL, 2, 0, 'Bryant-Tu', 'Feb  9 2015  6:54AM', 'Bryant-Tu', 'Feb  9 2015  7:53AM', '/apis/v4/subscriptions/{id}?lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='460C74C4-65EE-48A7-9BA9-43986AE72708' or ( HttpVerb='GET' and API='/v4/settings/userGroups'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('460C74C4-65EE-48A7-9BA9-43986AE72708', '/v4/settings/userGroups', 'GET', '/v4/settings/userGroups?module={module}&fields={fields}&lang={lang}', 'get_settings_usergroups', 'get_settings_usergroups', NULL, 5, 0, 'Waikei.Tam', 'Dec 10 2014  7:11AM', 'Waikei.Tam', 'Dec 10 2014  8:19AM', '/apis/v4/settings/userGroups?module={module}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='664F2579-2A38-428A-9403-4741F53CE8F2' or ( HttpVerb='POST' and API='/v4/search/assets'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('664F2579-2A38-428A-9403-4741F53CE8F2', '/v4/search/assets', 'POST', '/v4/search/assets?fields={fields}&lang={lang}', 'search_assets', 'search_assets', NULL, 5, 0, 'kay.li', 'Dec 26 2014  3:21AM', 'kay.li@beyondsoft.com', 'Dec 30 2014  9:47AM', '/apis/v4/search/assets?fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='3B0CB71A-EF15-4935-9973-62BCD94921EC' or ( HttpVerb='GET' and API='/v4/contacts/{id}/records'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('3B0CB71A-EF15-4935-9973-62BCD94921EC', '/v4/contacts/{id}/records', 'GET', '/v4/contacts/{id}/records?types={types}&statuses={statuses}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_contact_records', 'get_contact_records', NULL, 5, 0, 'bryant.tu', 'Dec  8 2014  8:10AM', NULL, NULL, '/apis/v4/contacts/{id}/records?types={types}&statuses={statuses}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='2FC20468-DAED-4284-9D7C-64B8783C158A' or ( HttpVerb='GET' and API='/v4/subscriptions/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('2FC20468-DAED-4284-9D7C-64B8783C158A', '/v4/subscriptions/{id}', 'GET', '/v4/subscriptions/{id}?lang={lang}', 'get_subscription', 'get_subscription', NULL, 2, 0, 'Bryant-Tu', 'Feb  9 2015  6:55AM', 'Bryant-Tu', 'Feb  9 2015  7:53AM', '/apis/v4/subscriptions/{id}?lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='08FC1F2F-3585-4B54-8B01-792220FBA5CE' or ( HttpVerb='GET' and API='/v4/records/{recordId}/workflowTasks/{taskId}/customForms/meta'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('08FC1F2F-3585-4B54-8B01-792220FBA5CE', '/v4/records/{recordId}/workflowTasks/{taskId}/customForms/meta', 'GET', '/v4/records/{recordId}/workflowTasks/{taskId}/customForms/meta?fields={fields}&lang={lang}', 'get_record_workflow_task_customforms_meta', 'get_records_workflowtasks_customforms_meta', NULL, 5, 0, 'ashley.zou@beyondsoft.com', 'Jan 22 2015  3:05AM', 'ashley.zou@beyondsoft.com', 'Jan 26 2015  6:05AM', '/apis/v4/records/{recordId}/workflowTasks/{taskId}/customForms/meta?fields={fields}&lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='279CB647-C26A-47AD-ADFB-81EDBFF344FD' or ( HttpVerb='GET' and API='/v4/owners/{ownerId}/conditions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('279CB647-C26A-47AD-ADFB-81EDBFF344FD', '/v4/owners/{ownerId}/conditions', 'GET', '/v4/owners/{ownerId}/conditions?type={type}&name={name}&status={status}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_owner_conditions', 'get_owner_conditions', NULL, 5, 0, 'david.jiang', 'Dec 31 2014 12:36PM', 'david.jiang', 'Jan 12 2015  2:37AM', '/apis/v4/owners/{ownerId}/conditions?type={type}&name={name}&status={status}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='A4AABD48-72DA-4110-A309-93DF64FA63A1' or ( HttpVerb='GET' and API='/v4/records/{recordId}/workflowTasks/{taskId}/customForms/{formId}/meta'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('A4AABD48-72DA-4110-A309-93DF64FA63A1', '/v4/records/{recordId}/workflowTasks/{taskId}/customForms/{formId}/meta', 'GET', '/v4/records/{recordId}/workflowTasks/{taskId}/customForms/{formId}/meta?lang={lang}', 'get_record_workflow_task_customform_meta', 'get_records_workflowtasks_customforms_meta', NULL, 5, 0, 'ashley.zou@beyondsoft.com', 'Jan 22 2015  1:58AM', 'ashley.zou@beyondsoft.com', 'Jan 26 2015  6:05AM', '/apis/v4/records/{recordId}/workflowTasks/{taskId}/customForms/{formId}/meta?lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='85375AD3-D87B-40FA-8FCC-93F9059706B0' or ( HttpVerb='GET' and API='/v4/parcels/{parcelId}/conditions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('85375AD3-D87B-40FA-8FCC-93F9059706B0', '/v4/parcels/{parcelId}/conditions', 'GET', '/v4/parcels/{parcelId}/conditions?type={type}&name={name}&status={status}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_parcel_conditions', 'get_parcel_conditions', NULL, 5, 0, 'kevin.tang', 'Dec 25 2014  6:57AM', 'kevin.tang', 'Jan  9 2015  1:16AM', '/apis/v4/parcels/{parcelId}/conditions?type={type}&name={name}&status={status}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='90DAFB69-1F27-4E81-9A48-A80F18E583E4' or ( HttpVerb='GET' and API='/v4/professionals/{id}/conditions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('90DAFB69-1F27-4E81-9A48-A80F18E583E4', '/v4/professionals/{id}/conditions', 'GET', '/v4/professionals/{id}/conditions?type={type}&name={name}&status={status}&fields={fields}&offset={offset}&limit={limit}&lang={lang}', 'get_professionals_conditions', 'get_professionals_conditions', NULL, 5, 0, 'Enhui', 'Jan 14 2015  6:11PM', 'Enhui', 'Feb 12 2015  6:33PM', '/apis/v4/professionals/{id}/conditions?type={type}&name={name}&status={status}&fields={fields}&offset={offset}&limit={limit}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='5D5077E0-F881-4F66-BA7D-B0AEF2FAF570' or ( HttpVerb='GET' and API='/v4/addresses/{id}/conditions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('5D5077E0-F881-4F66-BA7D-B0AEF2FAF570', '/v4/addresses/{id}/conditions', 'GET', '/v4/addresses/{id}/conditions?type={type}&name={name}&status={status}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_addresses_conditions', 'get_addresses_conditions', NULL, 5, 0, 'Enhui', 'Feb  4 2015 12:52AM', 'kay.li', 'Feb  5 2015  7:02AM', '/apis/v4/addresses/{id}/conditions?type={type}&name={name}&status={status}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='6A7D1422-F8F3-4782-A263-BB617CA77C8C' or ( HttpVerb='GET' and API='/v4/settings/assettypes/recordtypes'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('6A7D1422-F8F3-4782-A263-BB617CA77C8C', '/v4/settings/assettypes/recordtypes', 'GET', '/v4/settings/assettypes/recordtypes?assetGroup={assetGroup}&assetType={assetType}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_settings_asset_recordtypes', 'get_settings_asset_recordtypes', NULL, 5, 0, 'ashley.zou@beyondsoft.com', 'Jan  7 2015  6:07AM', 'ashley.zou@beyondsoft.com', 'Jan  9 2015  2:52AM', '/apis/v4/settings/assettypes/recordtypes?assetGroup={assetGroup}&assetType={assetType}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'Agency', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='6F25A403-9470-4012-9F18-C9616502B1FD' or ( HttpVerb='GET' and API='/v4/subscriptions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('6F25A403-9470-4012-9F18-C9616502B1FD', '/v4/subscriptions', 'GET', '/v4/subscriptions?applicationId={applicationId}&eventName={eventName}&callbackUrl={callbackUrl}&offset={offset}&limit={limit}&lang={lang}', 'get_subscriptions', 'get_subscriptions', NULL, 2, 0, 'Bryant-Tu', 'Feb  9 2015  6:54AM', 'Bryant-Tu', 'Feb  9 2015  7:53AM', '/apis/v4/subscriptions?applicationId={applicationId}&eventName={eventName}&callbackUrl={callbackUrl}&offset={offset}&limit={limit}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='A55B692F-0409-4788-AFF5-D3375D1AEC72' or ( HttpVerb='GET' and API='/v4/citizenaccess/citizens/{ids}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('A55B692F-0409-4788-AFF5-D3375D1AEC72', '/v4/citizenaccess/citizens/{ids}', 'GET', '/v4/citizenaccess/citizens/{ids}?expand={expand}&fields={fields}&lang={lang}', 'get_citizen_users', 'get_citizen_users', NULL, 5, 0, 'kevin.tang@beyondsoft.com', 'Aug  5 2015  8:12AM', 'kevin.tang@beyondsoft.com', 'Aug  5 2015  8:14AM', '/apis/v4/citizens/{ids}?expand={expand}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='8D0E09FF-B563-46E8-92C3-F1D1AD9DE748' or ( HttpVerb='GET' and API='/v4/records/{recordId}/gisobjects'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('8D0E09FF-B563-46E8-92C3-F1D1AD9DE748', '/v4/records/{recordId}/gisobjects', 'GET', '/v4/records/{recordId}/gisobjects?fields={fields}&lang={lang}', 'get_record_gisobjects', 'get_records_gisobjects', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Jan 13 2015  3:38AM', 'kay.li@beyondsoft.com', 'Sep 16 2015  7:36AM', '/apis/v4/records/{recordId}/gisobjects?limit={limit}&offset={offset}&fields={fields}&lang={lang}', 'All', NULL, '8.0', NULL, NULL, NULL, 1, 0)
end 

update [dbo].[Resources]
set
	 LastUpdatedDate='Apr 14 2015  9:19AM'
	,LastUpdatedBy='david.jiang'
	,ProxyAPI='/apis/v4/settings/records/types?offset={offset}&limit={limit}&module={module}&isFeeEstimate={isFeeEstimate}&expand={expand}&filterName={filterName}&fields={fields}&lang={lang}'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700038'

update [dbo].[Resources]
set
	 LastUpdatedDate='Aug 12 2015  7:07AM'
	,LastUpdatedBy='galen.zhang@beyondosoft.com'
	,ProxyAPI='/apis/v4/records/?type={type}&openedDateFrom={openedDateFrom}&openedDateTo={openedDateTo}&customId={customId}&module={module}&status={status}&assignedToDepartment={assignedToDepartment}&assignedUser={assignedUser}&assignedDateFrom={assignedDateFrom}&assignedDateTo={assignedDateTo}&completedDateFrom={completedDateFrom}&completedDateTo={completedDateTo}&statusDateFrom={statusDateFrom}&statusDateTo={statusDateTo}&updateDateFrom={updateDateFrom}&updateDateTo={updateDateTo}&completedByDepartment={completedByDepartment}&completedByUser={completedByUser}&closedDateFrom={closedDateFrom}&closedDateTo={closedDateTo}&closedByDepartment={closedByDepartment}&closedByUser={closedByUser}&recordClass={recordClass}&limit={limit}&offset={offset}&fields={fields}&lang={lang}'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700029'


update [dbo].[Resources]
set
	 LastUpdatedDate='Sep 18 2015  9:42PM'
	,RelativeUriTemplateFull='/v4/inspections/checkAvailability?recordId={recordId}&inspectionTypeId={inspectionTypeId}&startdDate={startdDate}&startDate={startDate}&endDate={endDate}&inspectionId={inspectionId}&department={department}&fields={fields}&lang={lang}'
	,AuthenticationType='5'
	,LastUpdatedBy='Jackie'
	,ProxyAPI='/apis/v4/inspections/checkAvailability?recordId={recordId}&inspectionTypeId={inspectionTypeId}&startdDate={startdDate}&startDate={startDate}&endDate={endDate}&inspectionId={inspectionId}&department={department}&fields={fields}&lang={lang}'
	,SupportedAAVersions='8.0'
where Id ='C94C60CF-5EF6-4509-81EC-A0944E1EADB8'

update [dbo].[Resources]
set
	 LastUpdatedDate='Aug 12 2015  7:07AM'
	,AuthenticationType='5'
	,LastUpdatedBy='galen.zhang@beyondosoft.com'
	,ProxyAPI='/apis/v4/records/mine?type={type}&openedDateFrom={openedDateFrom}&openedDateTo={openedDateTo}&customId={customId}&module={module}&status={status}&assignedDateFrom={assignedDateFrom}&assignedDateTo={assignedDateTo}&completedDateFrom={completedDateFrom}&completedDateTo={completedDateTo}&completedByDepartment={completedByDepartment}&completedByUser={completedByUser}&closedDateFrom={closedDateFrom}&closedDateTo={closedDateTo}&statusDateFrom={statusDateFrom}&statusDateTo={statusDateTo}&updateDateFrom={updateDateFrom}&updateDateTo={updateDateTo}&closedByDepartment={closedByDepartment}&closedByUser={closedByUser}&recordClass={recordClass}&types={types}&modules={modules}&expand={expand}&statusTypes={statusTypes}&limit={limit}&offset={offset}&fields={fields}&lang={lang}'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700030'


update [dbo].[Resources]
set
	Applicability='Agency'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700041'

update [dbo].[Resources]
set
	 LastUpdatedDate='Sep 17 2015  5:52AM'
	,RelativeUriTemplateFull='/v4/search/records/?offset={offset}&limit={limit}&expand={expand}&fields={fields}&lang={lang}'
	,LastUpdatedBy='galen.zhang@beyondosoft.com'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700060'

update [dbo].[Resources]
set
	AuthenticationType='5'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700134'

update [dbo].[Resources]
set
	 LastUpdatedDate='Aug 12 2015  7:10AM'
	,AuthenticationType='5'
	,LastUpdatedBy='galen.zhang@beyondosoft.com'
	,ProxyAPI='/apis/v4/records?fields={fields}&lang={lang}'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700025'
