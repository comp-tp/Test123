
update  resources set AuthenticationType = 0  where (httpverb='GET' and API='/v4/records/describe/create') or 
 (httpverb='POST' and API='/v4/records/initialize') or 
  (httpverb='POST' and API='/v4/records/{recordId}/finalize') or 
   (httpverb='POST' and API='/v4/records') or 
    (httpverb='GET' and API='/v4/settings/records/types') or 
	 (httpverb='GET' and API='/v4/settings/records/types/{id}/statuses') 
	 
if not exists(select * from [dbo].[Resources] where Id ='F16BF9B1-4CB6-4107-A34D-04ED4346306D' or ( HttpVerb='GET' and API='/v4/contacts/{id}/customForms'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('F16BF9B1-4CB6-4107-A34D-04ED4346306D', '/v4/contacts/{id}/customForms', 'GET', '/v4/contacts/{id}/customForms?lang={lang}', 'get_contacts_customforms', 'get_contacts_customforms', NULL, 5, 0, 'moss.li@beyondsoft.com', 'Feb 26 2015  9:03AM', 'Cherie', 'Feb 27 2015  6:17AM', '/apis/v4/contacts/{id}/customForms?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='980AB926-09AE-49CC-A5C0-0E6D859A9DA2' or ( HttpVerb='POST' and API='/v4/contacts/{id}/conditions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('980AB926-09AE-49CC-A5C0-0E6D859A9DA2', '/v4/contacts/{id}/conditions', 'POST', '/v4/contacts/{id}/conditions?fields={fields}&lang={lang}', 'add_contact_conditions', 'update_contact_conditions', NULL, 5, 0, 'david.jiang', 'Feb  9 2015  2:01AM', 'david.jiang', 'Mar  2 2015 12:34AM', '/apis/v4/contacts/{id}/conditions?fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='DDEC47C0-9FEF-4B2D-903A-39C835D26DD6' or ( HttpVerb='DELETE' and API='/v4/contacts/{contactId}/conditions/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('DDEC47C0-9FEF-4B2D-903A-39C835D26DD6', '/v4/contacts/{contactId}/conditions/{id}', 'DELETE', '/v4/contacts/{contactId}/conditions/{id}?lang={lang}', 'delete_contact_conditions', 'delete_contact_condition', NULL, 5, 0, 'Enhui', 'Feb 26 2015  6:44PM', 'Enhui', 'Feb 27 2015  9:24PM', '/apis/v4/contacts/{contactId}/conditions/{id}?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

update [dbo].[Resources]
set
	 LastUpdatedDate='Feb 13 2015  6:10AM'
	,AuthenticationType='0'
	,LastUpdatedBy='Don Liang'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700025'

update [dbo].[Resources]
set
	 LastUpdatedDate='Feb 13 2015  6:09AM'
	,AuthenticationType='0'
	,LastUpdatedBy='Don Liang'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700027'

if not exists(select * from [dbo].[Resources] where Id ='2C9E51EB-1067-4AA1-8592-6BCAF9F34FD8' or ( HttpVerb='PUT' and API='/v4/contacts/{id}/customForms'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('2C9E51EB-1067-4AA1-8592-6BCAF9F34FD8', '/v4/contacts/{id}/customForms', 'PUT', '/v4/contacts/{id}/customForms?lang={lang}', 'update_contacts_customforms', 'update_contacts_customforms', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Feb 27 2015  9:09AM', 'kay.li@beyondsoft.com', 'Feb 27 2015  9:09AM', '/apis/v4/contacts/{id}/customForms?lang={lang}', 'Agency', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='5E0DECCF-85A8-4FAA-9ECE-8113D187EDCD' or ( HttpVerb='GET' and API='/v4/contacts/{contactId}/customTables/{tableId}/meta'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('5E0DECCF-85A8-4FAA-9ECE-8113D187EDCD', '/v4/contacts/{contactId}/customTables/{tableId}/meta', 'GET', '/v4/contacts/{contactId}/customTables/{tableId}/meta?fields={fields}&lang={lang}', 'get_contact_customtable_meta', 'get_contact_customtables_meta', NULL, 5, 0, 'david.jiang', 'Feb 26 2015  7:01AM', 'david.jiang', 'Feb 27 2015  6:31AM', '/apis/v4/contacts/{contactId}/customTables/{tableId}/meta?fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='478DF143-89C2-4125-8DC7-9C8BC0E7FFD1' or ( HttpVerb='GET' and API='/v4/contacts/{id}/customForms/meta'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('478DF143-89C2-4125-8DC7-9C8BC0E7FFD1', '/v4/contacts/{id}/customForms/meta', 'GET', '/v4/contacts/{id}/customForms/meta?fields={fields}&lang={lang}', 'get_contacts_customforms_meta', 'get_contacts_customforms_meta', NULL, 5, 0, 'ashley.zou@beyondsoft.com', 'Feb  9 2015  3:08AM', 'ashley.zou@beyondsoft.com', 'Feb 11 2015  7:26AM', '/apis/v4/contacts/{id}/customForms/meta?fields={fields}&lang={lang}', 'Agency', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='772430DE-254C-408E-B645-A025B2C400AB' or ( HttpVerb='PUT' and API='/v4/contacts/{contactId}/customTables'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('772430DE-254C-408E-B645-A025B2C400AB', '/v4/contacts/{contactId}/customTables', 'PUT', '/v4/contacts/{contactId}/customTables?lang={lang}', 'update_contact_customtables', 'update_contact_customtables', NULL, 5, 0, 'Bryant-Tu', 'Feb 13 2015  7:14AM', 'Bryant-Tu', 'Feb 13 2015  7:14AM', '/apis/v4/contacts/{contactId}/customTables?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='C94C60CF-5EF6-4509-81EC-A0944E1EADB8' or ( HttpVerb='GET' and API='/v4/inspections/checkAvailability'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('C94C60CF-5EF6-4509-81EC-A0944E1EADB8', '/v4/inspections/checkAvailability', 'GET', '/v4/inspections/checkAvailability?recordId={recordId}&inspectionTypeId={inspectionTypeId}&startdDate={startdDate}&endDate={endDate}&inspectionId={inspectionId}&department={department}&fields={fields}&lang={lang}', 'get_inspections_checkavailability', 'get_inspections_checkavailability', NULL, 5, 1, 'moss.li@beyondsoft.com', 'Feb  9 2015  3:21AM', 'vsamaresan', 'Mar  2 2015  6:48PM', '/apis/v4/inspections/checkAvailability?recordId={recordId}&inspectionTypeId={inspectionTypeId}&startdDate={startdDate}&endDate={endDate}&inspectionId={inspectionId}&department={department}&fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='3E17C4D4-EED5-4D3C-B69D-A6B09485C926' or ( HttpVerb='POST' and API='/v4/contacts/{contactId}/conditions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('3E17C4D4-EED5-4D3C-B69D-A6B09485C926', '/v4/contacts/{contactId}/conditions', 'POST', '/v4/contacts/{contactId}/conditions?lang={lang}', 'add_contact_conditions', 'add_contact_conditions', NULL, 5, 0, 'david.jiang', 'Feb 26 2015  8:37AM', 'Cherie', 'Feb 27 2015  6:18AM', '/apis/v4/contacts/{contactId}/conditions?lang={lang}', 'Agency', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

update [dbo].[Resources]
set
	 LastUpdatedDate='Feb 13 2015  6:11AM'
	,AuthenticationType='0'
	,LastUpdatedBy='Don Liang'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700134'

update [dbo].[Resources]
set
	 LastUpdatedDate='Feb 28 2015 12:07AM'
	,AuthenticationType='0'
	,LastUpdatedBy='jackie'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700214'

if not exists(select * from [dbo].[Resources] where Id ='A2B6FE20-0630-4210-BE61-B9813703D91C' or ( HttpVerb='GET' and API='/v4/contacts/{contactId}/customTables'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('A2B6FE20-0630-4210-BE61-B9813703D91C', '/v4/contacts/{contactId}/customTables', 'GET', '/v4/contacts/{contactId}/customTables?fields={fields}&lang={lang}', 'get_contact_customtables', 'get_contact_customtables', NULL, 5, 0, 'B', 'Feb  9 2015  1:39AM', 'B', 'Feb  9 2015  1:43AM', '/apis/v4/contacts/{contactId}/customTables?fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='46B448FD-0A43-4099-BC55-D8843323D978' or ( HttpVerb='GET' and API='/v4/contacts/{contactId}/customTables/meta'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('46B448FD-0A43-4099-BC55-D8843323D978', '/v4/contacts/{contactId}/customTables/meta', 'GET', '/v4/contacts/{contactId}/customTables/meta?fields={fields}&lang={lang}', 'get_contacts_customtables_meta', 'get_contact_customtables_meta', NULL, 5, 0, 'david.jiang', 'Feb 26 2015  6:57AM', 'david.jiang', 'Feb 27 2015  6:33AM', '/apis/v4/contacts/{contactId}/customTables/meta?fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='CF8685A3-0F9C-4884-A950-DD05055A9CE4' or ( HttpVerb='PUT' and API='/v4/contacts/{contactId}/conditions/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('CF8685A3-0F9C-4884-A950-DD05055A9CE4', '/v4/contacts/{contactId}/conditions/{id}', 'PUT', '/v4/contacts/{contactId}/conditions/{id}?lang={lang}', 'update_contact_condition', 'update_contacts_conditions', NULL, 5, 0, 'Enhui', 'Feb 25 2015  8:50PM', 'Enhui', 'Feb 26 2015  9:49PM', '/apis/v4/contacts/{contactId}/conditions/{id}?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='016D4550-8D03-47B2-AB01-E60E7C24B86C' or ( HttpVerb='GET' and API='/v4/contacts/{id}/customForms/{formId}/meta'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('016D4550-8D03-47B2-AB01-E60E7C24B86C', '/v4/contacts/{id}/customForms/{formId}/meta', 'GET', '/v4/contacts/{id}/customForms/{formId}/meta?lang={lang}', 'get_contact_customform_meta', 'get_contact_customform_meta', NULL, 5, 0, 'ashley.zou@beyondsoft.com', 'Feb  9 2015  3:10AM', 'ashley.zou@beyondsoft.com', 'Feb 11 2015  7:27AM', '/apis/v4/contacts/{id}/customForms/{formId}/meta?lang={lang}', 'Agency', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 


-- All Citizen Access citizen/me
-- CONTACTS - GET
if exists(select * from [dbo].[Resources] where Id ='6CC4ADEF-ED36-4E5E-8127-B749C8D82009' or ( HttpVerb='GET' and API='/v4/civicid/citizenaccess/contacts'))
begin
	DELETE FROM [dbo].[Resources] where Id ='6CC4ADEF-ED36-4E5E-8127-B749C8D82009' or ( HttpVerb='GET' and API='/v4/civicid/citizenaccess/contacts')
end
if not exists(select * from [dbo].[Resources] where Id ='6CC4ADEF-ED36-4E5E-8127-B749C8D82009' or ( HttpVerb='GET' and API='/v4/civicid/citizenaccess/contacts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('6CC4ADEF-ED36-4E5E-8127-B749C8D82009', '/v4/civicid/citizenaccess/contacts', 'GET', '/v4/civicid/citizenaccess/contacts?fields={fields}&lang={lang}', 'get_citizenaccess_user_contacts', 'get_citizens_me_contacts', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:40AM', 'jing', 'Mar  2 2015  9:25PM', '/apis/v4/citizens/me/contacts?fields={fields}&lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end

-- CONTACTS - POST
if exists(select * from [dbo].[Resources] where Id ='AE6F3E0E-DE60-4E40-9C8D-5571DCCCEDB3' or ( HttpVerb='POST' and API='/v4/civicid/citizenaccess/contacts'))
begin
	DELETE FROM [dbo].[Resources] where Id ='AE6F3E0E-DE60-4E40-9C8D-5571DCCCEDB3' or ( HttpVerb='POST' and API='/v4/civicid/citizenaccess/contacts')
end
if not exists(select * from [dbo].[Resources] where Id ='AE6F3E0E-DE60-4E40-9C8D-5571DCCCEDB3' or ( HttpVerb='POST' and API='/v4/civicid/citizenaccess/contacts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('AE6F3E0E-DE60-4E40-9C8D-5571DCCCEDB3', '/v4/civicid/citizenaccess/contacts', 'POST', '/v4/civicid/citizenaccess/contacts?lang={lang}', 'add_citizenaccess_user_contacts', 'add_user_profile', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:42AM', 'jing', 'Mar  2 2015  9:28PM', '/apis/v4/citizens/me/contacts?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

-- CONTACTS - DELETE
if exists(select * from [dbo].[Resources] where Id ='77C59EA8-902A-4C61-A027-406EBE50468B' or ( HttpVerb='DELETE' and API='/v4/civicid/citizenaccess/contacts/{ids}'))
begin
	DELETE FROM [dbo].[Resources] where Id ='77C59EA8-902A-4C61-A027-406EBE50468B' or ( HttpVerb='DELETE' and API='/v4/civicid/citizenaccess/contacts/{ids}')
end
if not exists(select * from [dbo].[Resources] where Id ='77C59EA8-902A-4C61-A027-406EBE50468B' or ( HttpVerb='DELETE' and API='/v4/civicid/citizenaccess/contacts/{ids}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('77C59EA8-902A-4C61-A027-406EBE50468B', '/v4/civicid/citizenaccess/contacts/{ids}', 'DELETE', '/v4/civicid/citizenaccess/contacts/{ids}?lang={lang}', 'delete_citizenaccess_user_contacts', 'delete_user_profile', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:46AM', 'jing', 'Mar  2 2015  9:33PM', '/apis/v4/citizens/me/contacts/{ids}?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

-- REGISTER - POST
if exists(select * from [dbo].[Resources] where Id ='F01AD3EA-D26F-40FA-B257-607CDE94C05B' or ( HttpVerb='POST' and API='/v4/civicid/citizenaccess/register'))
begin
	DELETE FROM [dbo].[Resources] where Id ='F01AD3EA-D26F-40FA-B257-607CDE94C05B' or ( HttpVerb='POST' and API='/v4/civicid/citizenaccess/register')
end
if not exists(select * from [dbo].[Resources] where Id ='F01AD3EA-D26F-40FA-B257-607CDE94C05B' or ( HttpVerb='POST' and API='/v4/civicid/citizenaccess/register'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('F01AD3EA-D26F-40FA-B257-607CDE94C05B', '/v4/civicid/citizenaccess/register', 'POST', '/v4/civicid/citizenaccess/register?lang={lang}', 'register_citizenaccess_user', 'register_citizen', NULL, 0, 0, 'moss.li@beyondsoft.com', 'Feb 25 2015  2:58AM', 'vsamaresan', 'Mar  2 2015 10:13PM', '/apis/v4/citizens/register?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

-- PROFILE - GET
if exists(select * from [dbo].[Resources] where Id ='C3BA685F-632C-4353-B945-5276B33AD77C' or ( HttpVerb='GET' and API='/v4/civicid/citizenaccess/profile'))
begin
	DELETE FROM [dbo].[Resources] where Id ='C3BA685F-632C-4353-B945-5276B33AD77C' or ( HttpVerb='GET' and API='/v4/civicid/citizenaccess/profile')
end
if not exists(select * from [dbo].[Resources] where Id ='C3BA685F-632C-4353-B945-5276B33AD77C' or ( HttpVerb='GET' and API='/v4/civicid/citizenaccess/profile'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('C3BA685F-632C-4353-B945-5276B33AD77C', '/v4/civicid/citizenaccess/profile', 'GET', '/v4/civicid/citizenaccess/profile?fields={fields}&lang={lang}', 'get_citizenaccess_user_profile', 'get_civicid_citizenaccess_profile', NULL, 5, 0, 'vsamaresan', 'Feb 25 2015 12:09AM', 'jing', 'Mar  2 2015 10:36PM', '/apis/v4/citizens/me?agencyName={agencyName}&fields={fields}&lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

