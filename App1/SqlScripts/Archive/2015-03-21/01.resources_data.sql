
if not exists(select * from [dbo].[Resources] where Id ='3A2CC411-E603-4B5C-B3DD-0297D6DA878F' or ( HttpVerb='PUT' and API='/v4/announcements/{ids}/read'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('3A2CC411-E603-4B5C-B3DD-0297D6DA878F', '/v4/announcements/{ids}/read', 'PUT', '/v4/announcements/{ids}/read?lang={lang}', 'update_announcements_read', 'update_announcements_read', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Mar 13 2015  9:09AM', 'kay.li@beyondsoft.com', 'Mar 13 2015  9:47AM', '/apis/v4/announcements/{ids}/read?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='F16BF9B1-4CB6-4107-A34D-04ED4346306D' or ( HttpVerb='GET' and API='/v4/contacts/{id}/customForms'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('F16BF9B1-4CB6-4107-A34D-04ED4346306D', '/v4/contacts/{id}/customForms', 'GET', '/v4/contacts/{id}/customForms?lang={lang}', 'get_contacts_customforms', 'get_contacts_customforms', NULL, 5, 0, 'moss.li@beyondsoft.com', 'Feb 26 2015  9:03AM', 'pdhanore', 'Mar  4 2015  9:30PM', '/apis/v4/contacts/{id}/customForms?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='7054C7CC-65D3-4ADA-936D-0A2714C54341' or ( HttpVerb='PUT' and API='/v4/contacts/{contactId}/addresses/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('7054C7CC-65D3-4ADA-936D-0A2714C54341', '/v4/contacts/{contactId}/addresses/{id}', 'PUT', '/v4/contacts/{contactId}/addresses/{id}?lang={lang}', 'update_contacts_addresses', 'update_contacts_addresses', NULL, 5, 0, 'moss.li@beyondsoft.com', 'Mar 11 2015  7:51AM', 'moss.li@beyondsoft.com', 'Mar 11 2015  7:52AM', '/apis/v4/contacts/{contactId}/addresses/{id}?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='3CE906AF-6DB0-41CC-950A-12FF394C9A80' or ( HttpVerb='DELETE' and API='/v4/citizenaccess/citizens/{id}/contacts/{contactIds}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('3CE906AF-6DB0-41CC-950A-12FF394C9A80', '/v4/citizenaccess/citizens/{id}/contacts/{contactIds}', 'DELETE', '/v4/citizenaccess/citizens/{id}/contacts/{contactIds}?lang={lang}', 'delete_citizenaccess_citizens_contacts', 'delete_citizens_contacts', NULL, 5, 0, 'Enhui', 'Mar 14 2015  1:31AM', 'Don Liang', 'Mar 17 2015  3:09AM', '/apis/v4/citizens/{id}/contacts/{contactIds}?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

update [dbo].[Resources]
set
	 LastUpdatedDate='Feb 13 2015  6:09AM'
	,AuthenticationType='0'
	,LastUpdatedBy='Don Liang'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700027'

if not exists(select * from [dbo].[Resources] where Id ='618A9594-4102-4EDE-ABD9-2552EEACE225' or ( HttpVerb='GET' and API='/v4/civicid/citizenaccess/professionals'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('618A9594-4102-4EDE-ABD9-2552EEACE225', '/v4/civicid/citizenaccess/professionals', 'GET', '/v4/civicid/citizenaccess/professionals?fields={fields}&lang={lang}', 'get_citizenaccess_user_professionals', 'get_user_profile', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:39AM', 'Cherie', 'Mar  2 2015 10:50PM', '/apis/v4/citizens/me/professionals?fields={fields}&lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='B272B489-A640-45D3-A343-35D1D346F349' or ( HttpVerb='GET' and API='/v4/citizenaccess/profile'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('B272B489-A640-45D3-A343-35D1D346F349', '/v4/citizenaccess/profile', 'GET', '/v4/citizenaccess/profile?fields={fields}&lang={lang}', 'get_citizenaccess_user_profile', 'get_citizenaccess_user_profile', NULL, 5, 0, 'Don Liang', 'Mar  4 2015  5:55AM', 'Don Liang', 'Mar 17 2015  6:29AM', '/apis/v4/citizens/me?fields={fields}&lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='DDEC47C0-9FEF-4B2D-903A-39C835D26DD6' or ( HttpVerb='DELETE' and API='/v4/contacts/{contactId}/conditions/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('DDEC47C0-9FEF-4B2D-903A-39C835D26DD6', '/v4/contacts/{contactId}/conditions/{id}', 'DELETE', '/v4/contacts/{contactId}/conditions/{id}?lang={lang}', 'delete_contact_conditions', 'delete_contact_condition', NULL, 5, 0, 'Enhui', 'Feb 26 2015  6:44PM', 'Enhui', 'Feb 27 2015  9:24PM', '/apis/v4/contacts/{contactId}/conditions/{id}?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='77C59EA8-902A-4C61-A027-406EBE50468B' or ( HttpVerb='DELETE' and API='/v4/citizenaccess/contacts/{ids}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('77C59EA8-902A-4C61-A027-406EBE50468B', '/v4/citizenaccess/contacts/{ids}', 'DELETE', '/v4/citizenaccess/contacts/{ids}?lang={lang}', 'delete_citizenaccess_user_contacts', 'delete_user_profile', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:46AM', 'Don Liang', 'Mar 17 2015  6:12AM', '/apis/v4/citizens/me/contacts/{ids}?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

update [dbo].[Resources]
set
	 LastUpdatedDate='Feb 13 2015  6:10AM'
	,AuthenticationType='0'
	,LastUpdatedBy='Don Liang'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700025'

if not exists(select * from [dbo].[Resources] where Id ='CD33486E-B864-4EBD-BE5D-443739870E66' or ( HttpVerb='POST' and API='/v4/citizenaccess/citizens/{id}/contacts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('CD33486E-B864-4EBD-BE5D-443739870E66', '/v4/citizenaccess/citizens/{id}/contacts', 'POST', '/v4/citizenaccess/citizens/{id}/contacts?lang={lang}', 'create_citizenaccess_citizens_contacts', 'create_citizens_contacts', NULL, 5, 0, 'Enhui', 'Mar 13 2015  7:40AM', 'Don Liang', 'Mar 17 2015  3:07AM', '/apis/v4/citizens/{id}/contacts?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='3754E633-E396-4B8F-A3C8-51C3C70F3707' or ( HttpVerb='POST' and API='/v4/civicid/accounts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('3754E633-E396-4B8F-A3C8-51C3C70F3707', '/v4/civicid/accounts', 'POST', '/v4/civicid/accounts?lang={lang}', 'create_civicid_accounts', 'create_civicid_accounts', NULL, 1, 1, 'vsamaresan', 'Mar  5 2015  8:01PM', 'vsamaresan', 'Mar 16 2015  7:55PM', '/apis/v4/civicid/accounts?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 0, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='AE6F3E0E-DE60-4E40-9C8D-5571DCCCEDB3' or ( HttpVerb='POST' and API='/v4/citizenaccess/contacts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('AE6F3E0E-DE60-4E40-9C8D-5571DCCCEDB3', '/v4/citizenaccess/contacts', 'POST', '/v4/citizenaccess/contacts?lang={lang}', 'add_citizenaccess_user_contacts', 'add_user_profile', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:42AM', 'Don Liang', 'Mar 17 2015  6:08AM', '/apis/v4/citizens/me/contacts?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='BE4ED385-D9B3-449F-9AC1-5EF47733B081' or ( HttpVerb='GET' and API='/v4/citizenaccess/citizens'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('BE4ED385-D9B3-449F-9AC1-5EF47733B081', '/v4/citizenaccess/citizens', 'GET', '/v4/citizenaccess/citizens?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_citizenaccess_citizens', 'get_users', NULL, 5, 0, 'Bryant-Tu', 'Mar 13 2015  8:33AM', 'Don Liang', 'Mar 17 2015  3:11AM', '/apis/v4/citizens?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='F01AD3EA-D26F-40FA-B257-607CDE94C05B' or ( HttpVerb='POST' and API='/v4/citizenaccess/register'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('F01AD3EA-D26F-40FA-B257-607CDE94C05B', '/v4/citizenaccess/register', 'POST', '/v4/citizenaccess/register?lang={lang}', 'register_citizenaccess_user', 'register_citizen', NULL, 0, 0, 'moss.li@beyondsoft.com', 'Feb 25 2015  2:58AM', 'kay.li@beyondsoft.com', 'Mar 18 2015  4:31AM', '/apis/v4/citizens/register?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

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

if not exists(select * from [dbo].[Resources] where Id ='062D0CA0-F63D-449A-A513-8136640762FE' or ( HttpVerb='POST' and API='/v4/civicid/citizenaccess/professionals'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('062D0CA0-F63D-449A-A513-8136640762FE', '/v4/civicid/citizenaccess/professionals', 'POST', '/v4/civicid/citizenaccess/professionals?lang={lang}', 'add_citizenaccess_user_professional', 'add_user_profile', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:44AM', 'Cherie', 'Mar  2 2015 10:50PM', '/apis/v4/citizens/me/professionals?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
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

update [dbo].[Resources]
set
	 LastUpdatedDate='Mar 10 2015  6:50AM'
	,LastUpdatedBy='kevintang'
	,ProxyAPI='/apis/v4/search/contacts?offset={offset}&limit={limit}&fields={fields}&lang={lang}'
where Id ='C4012345-AAAA-BBBB-CCCC-123456700057'

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

if not exists(select * from [dbo].[Resources] where Id ='7715EEE9-5B03-42A9-8332-A295935BF747' or ( HttpVerb='DELETE' and API='/v4/civicid/accounts/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('7715EEE9-5B03-42A9-8332-A295935BF747', '/v4/civicid/accounts/{id}', 'DELETE', '/v4/civicid/accounts/{id}?lang={lang}', 'delete_civicid_accounts', 'delete_civicid_accounts', NULL, 1, 1, 'vsamaresan', 'Mar  5 2015  8:05PM', 'vsamaresan', 'Mar 16 2015  7:54PM', '/apis/v4/civicid/accounts/{id}?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 0, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='3E17C4D4-EED5-4D3C-B69D-A6B09485C926' or ( HttpVerb='POST' and API='/v4/contacts/{contactId}/conditions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('3E17C4D4-EED5-4D3C-B69D-A6B09485C926', '/v4/contacts/{contactId}/conditions', 'POST', '/v4/contacts/{contactId}/conditions?lang={lang}', 'add_contact_conditions', 'add_contact_conditions', NULL, 5, 0, 'david.jiang', 'Feb 26 2015  8:37AM', 'Cherie', 'Feb 27 2015  6:18AM', '/apis/v4/contacts/{contactId}/conditions?lang={lang}', 'Agency', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='E5FEACFB-8438-4BB7-8BB0-AFAFC861FCF9' or ( HttpVerb='GET' and API='/v4/citizenaccess/citizens/{id}/accounts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('E5FEACFB-8438-4BB7-8BB0-AFAFC861FCF9', '/v4/citizenaccess/citizens/{id}/accounts', 'GET', '/v4/citizenaccess/citizens/{id}/accounts?id={id}&lang={lang}', 'get_citizens_accounts', 'get_citizens_accounts', NULL, 5, 0, 'Enhui', 'Mar 16 2015 10:32PM', 'moss.li@beyondsoft.com', 'Mar 17 2015 12:18PM', '/apis/V4/citizens/{id}/accounts?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='01F86934-DE85-46FF-9D81-B17B6F43C6A5' or ( HttpVerb='GET' and API='/v4/contacts/{contactId}/conditions'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('01F86934-DE85-46FF-9D81-B17B6F43C6A5', '/v4/contacts/{contactId}/conditions', 'GET', '/v4/contacts/{contactId}/conditions?type={type}&name={name}&status={status}&fields={fields}&offset={offset}&limit={limit}&lang={lang}', 'get_contact_conditions', 'get_contact_conditions', NULL, 5, 0, 'kevintang', 'Mar 11 2015  2:19AM', 'kevintang', 'Mar 11 2015  2:20AM', '/apis/v4/contacts/{contactId}/conditions?type={type}&name={name}&status={status}&fields={fields}&offset={offset}&limit={limit}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='9C1B9FE8-4589-4CD2-9867-B55C497A9F1D' or ( HttpVerb='POST' and API='/v4/payments/completeOnlinePayment'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('9C1B9FE8-4589-4CD2-9867-B55C497A9F1D', '/v4/payments/completeOnlinePayment', 'POST', '/v4/payments/completeOnlinePayment?fields={fields}&lang={lang}', 'create_payments_completeonlinepayment', 'create_payments_completeonlinepayment', NULL, 5, 0, 'moss.li@beyondsoft.com', 'Mar  4 2015  2:39AM', 'moss.li@beyondsoft.com', 'Mar  4 2015  6:09AM', '/apis/v4/payments/completeOnlinePayment?fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='6CC4ADEF-ED36-4E5E-8127-B749C8D82009' or ( HttpVerb='GET' and API='/v4/citizenaccess/contacts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('6CC4ADEF-ED36-4E5E-8127-B749C8D82009', '/v4/citizenaccess/contacts', 'GET', '/v4/citizenaccess/contacts?fields={fields}&lang={lang}', 'get_citizenaccess_user_contacts', 'get_citizens_me_contacts', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:40AM', 'Don Liang', 'Mar 17 2015  6:16AM', '/apis/v4/citizens/me/contacts?fields={fields}&lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='A2B6FE20-0630-4210-BE61-B9813703D91C' or ( HttpVerb='GET' and API='/v4/contacts/{contactId}/customTables'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('A2B6FE20-0630-4210-BE61-B9813703D91C', '/v4/contacts/{contactId}/customTables', 'GET', '/v4/contacts/{contactId}/customTables?fields={fields}&lang={lang}', 'get_contact_customtables', 'get_contact_customtables', NULL, 5, 0, 'B', 'Feb  9 2015  1:39AM', 'B', 'Feb  9 2015  1:43AM', '/apis/v4/contacts/{contactId}/customTables?fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='6FBF600A-73BF-4781-92D9-D2179D444F0A' or ( HttpVerb='DELETE' and API='/v4/civicid/citizenaccess/professionals/{ids}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('6FBF600A-73BF-4781-92D9-D2179D444F0A', '/v4/civicid/citizenaccess/professionals/{ids}', 'DELETE', '/v4/civicid/citizenaccess/professionals/{ids}?lang={lang}', 'delete_citizenaccess_user_profile', 'delete_user_profile', NULL, 5, 1, 'kay.li@beyondsoft.com', 'Feb 25 2015  2:46AM', 'Cherie', 'Mar  2 2015 10:30PM', '/apis/v4/citizens/me/professionals/{ids}?lang={lang}', 'Citizen', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='3944BB41-48C2-46FC-9EED-D2C8F0DC24D2' or ( HttpVerb='GET' and API='/v4/trustAccounts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('3944BB41-48C2-46FC-9EED-D2C8F0DC24D2', '/v4/trustAccounts', 'GET', '/v4/trustAccounts/?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_trustaccounts', 'get_trustaccounts', NULL, 5, 0, 'Bryant-Tu', 'Mar 12 2015  6:52AM', 'Bryant-Tu', 'Mar 12 2015  6:52AM', '/apis/v4/trustAccounts/?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
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

if not exists(select * from [dbo].[Resources] where Id ='87DE6F2F-6D1A-4521-B0AB-E17CEFAF823A' or ( HttpVerb='PUT' and API='/v4/citizenaccess/citizens/{id}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('87DE6F2F-6D1A-4521-B0AB-E17CEFAF823A', '/v4/citizenaccess/citizens/{id}', 'PUT', '/v4/citizenaccess/citizens/{id}?lang={lang}', 'update_citizenaccess_citizens', 'update_citizens', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Mar 13 2015  8:12AM', 'Don Liang', 'Mar 17 2015  5:21AM', '/apis/v4/citizens/{id}?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='C7A8DC6C-C288-499B-81AD-E4D868A84CA1' or ( HttpVerb='GET' and API='/v4/records/{recordId}/trustAccounts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('C7A8DC6C-C288-499B-81AD-E4D868A84CA1', '/v4/records/{recordId}/trustAccounts', 'GET', '/v4/records/{recordId}/trustAccounts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'get_record_trustaccounts', 'get_record_trustaccounts', NULL, 5, 0, 'Bryant-Tu', 'Mar 12 2015  6:54AM', 'Bryant-Tu', 'Mar 12 2015  6:54AM', '/apis/v4/records/{recordId}/trustAccounts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='016D4550-8D03-47B2-AB01-E60E7C24B86C' or ( HttpVerb='GET' and API='/v4/contacts/{id}/customForms/{formId}/meta'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('016D4550-8D03-47B2-AB01-E60E7C24B86C', '/v4/contacts/{id}/customForms/{formId}/meta', 'GET', '/v4/contacts/{id}/customForms/{formId}/meta?lang={lang}', 'get_contact_customform_meta', 'get_contact_customform_meta', NULL, 5, 0, 'ashley.zou@beyondsoft.com', 'Feb  9 2015  3:10AM', 'ashley.zou@beyondsoft.com', 'Feb 11 2015  7:27AM', '/apis/v4/contacts/{id}/customForms/{formId}/meta?lang={lang}', 'Agency', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='9E72E5BF-8CF9-46AB-9066-ED392748DA23' or ( HttpVerb='PUT' and API='/v4/citizenaccess/citizens/{id}/accounts'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('9E72E5BF-8CF9-46AB-9066-ED392748DA23', '/v4/citizenaccess/citizens/{id}/accounts', 'PUT', '/v4/citizenaccess/citizens/{id}/accounts?lang={lang}', 'update_citizenaccess_citizens_accounts', 'update_citizens_accounts', NULL, 5, 0, 'Enhui', 'Mar 16 2015 10:10PM', 'moss.li@beyondsoft.com', 'Mar 17 2015 12:35PM', '/apis/V4/citizens/{id}/accounts?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='953F7ACF-1B15-4470-8EEC-FABDB7BF3251' or ( HttpVerb='PUT' and API='/v4/citizenaccess/citizens/{id}/password'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('953F7ACF-1B15-4470-8EEC-FABDB7BF3251', '/v4/citizenaccess/citizens/{id}/password', 'PUT', '/v4/citizenaccess/citizens/{id}/password?lang={lang}', 'update_citizenaccess_citizens_password', 'update_citizens_password', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Mar 17 2015  8:22AM', 'Don Liang', 'Mar 17 2015  8:30AM', '/apis/v4/citizens/{id}/password?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 

if not exists(select * from [dbo].[Resources] where Id ='17DB2F68-8CA7-4140-93DF-FDC0B3B7ECDA' or ( HttpVerb='POST' and API='/v4/citizenaccess/citizens'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('17DB2F68-8CA7-4140-93DF-FDC0B3B7ECDA', '/v4/citizenaccess/citizens', 'POST', '/v4/citizenaccess/citizens?lang={lang}', 'create_citizenaccess_citizens', 'create_clerk', NULL, 5, 0, 'kay.li@beyondsoft.com', 'Mar 17 2015  5:15AM', 'kay.li@beyondsoft.com', 'Mar 17 2015  6:45AM', '/apis/v4/citizens?lang={lang}', 'All', NULL, '7.3.3.4', NULL, NULL, NULL, 1, 0)
end 
