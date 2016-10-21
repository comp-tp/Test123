
if not exists(select * from [dbo].[Scope2Groups] where Id ='DF732FD5-1A6F-4163-B092-001EA90E2FEB' or ( ScopeName='update_citizenaccess_citizens_password' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('DF732FD5-1A6F-4163-B092-001EA90E2FEB', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'update_citizenaccess_citizens_password', 'Don Liang', 'Mar 17 2015  8:30AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='B8A45647-5578-4962-8C09-0173FD7EF440' or ( ScopeName='get_citizens_accounts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('B8A45647-5578-4962-8C09-0173FD7EF440', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizens_accounts', 'Enhui', 'Mar 16 2015 10:32PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='1174B530-FCBC-4317-AA3C-031E851C6857' or ( ScopeName='get_citizenaccess_user_contacts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('1174B530-FCBC-4317-AA3C-031E851C6857', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_user_contacts', 'jing', 'Mar  2 2015  9:24PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='985A77C9-B1B6-4479-A5D4-07713B9FB0EF' or ( ScopeName='get_user_profile' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('985A77C9-B1B6-4479-A5D4-07713B9FB0EF', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_user_profile', 'kay.li@beyondsoft.com', 'Feb 24 2015  3:00AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='0F424673-CBEA-4E1F-84B0-0CBE9FA376E3' or ( ScopeName='get_citizenaccess_user_profile' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('0F424673-CBEA-4E1F-84B0-0CBE9FA376E3', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_user_profile', 'Don Liang', 'Mar  4 2015  5:55AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='4D358871-34F3-4BB6-AE07-1027A8F54F18' or ( ScopeName='add_contact_conditions' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('4D358871-34F3-4BB6-AE07-1027A8F54F18', '1607A807-07C0-43FF-A914-F840EF2580A7', 'add_contact_conditions', 'david.jiang', 'Feb 10 2015  2:01AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='C6FBFEE9-57BA-4111-9037-189F99E5E301' or ( ScopeName='get_contacts_customforms' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('C6FBFEE9-57BA-4111-9037-189F99E5E301', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contacts_customforms', 'moss.li@beyondsoft.com', 'Feb 26 2015  9:03AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='0E7B89A2-9BE8-403E-99CD-283A2B4EDB7D' or ( ScopeName='get_contact_customtable_meta' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('0E7B89A2-9BE8-403E-99CD-283A2B4EDB7D', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_customtable_meta', 'david.jiang', 'Feb 27 2015  6:31AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='D5368964-67A6-4A50-BAF5-5C731A38E911' or ( ScopeName='add_citizenaccess_user_professional' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('D5368964-67A6-4A50-BAF5-5C731A38E911', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'add_citizenaccess_user_professional', 'jing', 'Mar  2 2015  9:28PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='40E24B79-F2BD-4D57-AAAF-62E0726A3F22' or ( ScopeName='delete_civicid_accounts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('40E24B79-F2BD-4D57-AAAF-62E0726A3F22', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'delete_civicid_accounts', 'vsamaresan', 'Mar  5 2015  8:05PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='ACA10E68-40BA-45DE-BBE5-63A1D7F3FB51' or ( ScopeName='update_contacts_addresses' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('ACA10E68-40BA-45DE-BBE5-63A1D7F3FB51', '1607A807-07C0-43FF-A914-F840EF2580A7', 'update_contacts_addresses', 'moss.li@beyondsoft.com', 'Mar 11 2015  7:51AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='8CF5CDB4-3F46-423F-8B89-64E087936C77' or ( ScopeName='get_contacts_customforms_meta' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('8CF5CDB4-3F46-423F-8B89-64E087936C77', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contacts_customforms_meta', 'ashley.zou@beyondsoft.com', 'Feb  9 2015  3:08AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='B0684988-D0C3-4866-A94D-6A1AC7C18361' or ( ScopeName='get_contacts_customtables_meta' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('B0684988-D0C3-4866-A94D-6A1AC7C18361', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contacts_customtables_meta', 'david.jiang', 'Feb 27 2015  6:33AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='724E1EC4-1D32-4B05-AD4D-6FD587C77BB4' or ( ScopeName='delete_citizenaccess_user_contacts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('724E1EC4-1D32-4B05-AD4D-6FD587C77BB4', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'delete_citizenaccess_user_contacts', 'jing', 'Mar  2 2015  9:33PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='759FB5E9-8012-4BDA-A31D-7333E8B2C8E0' or ( ScopeName='get_inspections_checkavailability' and GroupId='90F34533-9753-4802-8553-4D239CD1336C'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('759FB5E9-8012-4BDA-A31D-7333E8B2C8E0', '90F34533-9753-4802-8553-4D239CD1336C', 'get_inspections_checkavailability', 'moss.li@beyondsoft.com', 'Feb  9 2015  3:21AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='05ADD799-3311-4A41-A46D-73D674366569' or ( ScopeName='get_trustaccounts' and GroupId='9CF3BF93-FDAA-42C4-8AC7-64F12C07DD54'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('05ADD799-3311-4A41-A46D-73D674366569', '9CF3BF93-FDAA-42C4-8AC7-64F12C07DD54', 'get_trustaccounts', 'Bryant-Tu', 'Mar 12 2015  6:52AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='A06AE3EF-88EF-43B1-AE7E-78906A0EC6CA' or ( ScopeName='update_citizenaccess_citizens_accounts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('A06AE3EF-88EF-43B1-AE7E-78906A0EC6CA', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'update_citizenaccess_citizens_accounts', 'Don Liang', 'Mar 17 2015  6:43AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='F5EFACAD-B0EA-4BD8-81C7-7D9C5BDC7A45' or ( ScopeName='create_civicid_accounts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('F5EFACAD-B0EA-4BD8-81C7-7D9C5BDC7A45', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'create_civicid_accounts', 'vsamaresan', 'Mar  5 2015  8:01PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='AF02FD9B-BADC-482C-9488-7F46574740E5' or ( ScopeName='create_citizenaccess_citizens_contacts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('AF02FD9B-BADC-482C-9488-7F46574740E5', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'create_citizenaccess_citizens_contacts', 'Don Liang', 'Mar 17 2015  3:07AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='87B5DF19-6F08-4F03-B9D6-8FB874A9942F' or ( ScopeName='get_contact_customtables' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('87B5DF19-6F08-4F03-B9D6-8FB874A9942F', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_customtables', 'B', 'Feb  9 2015  1:39AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='FAA7B025-826D-43BA-B59B-97A935332E9E' or ( ScopeName='get_contact_conditions' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('FAA7B025-826D-43BA-B59B-97A935332E9E', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_conditions', 'kevintang', 'Mar 11 2015  2:19AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='E7682F7B-FBF6-406C-84CC-A39CD6F01808' or ( ScopeName='delete_citizenaccess_citizens_contacts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('E7682F7B-FBF6-406C-84CC-A39CD6F01808', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'delete_citizenaccess_citizens_contacts', 'Don Liang', 'Mar 17 2015  3:09AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='7A6FA125-130E-4355-9BE7-B3B232CD934C' or ( ScopeName='get_citizenaccess_user_professionals' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('7A6FA125-130E-4355-9BE7-B3B232CD934C', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_user_professionals', 'jing', 'Mar  2 2015  9:28PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='D3AE38F0-FA0D-4931-B81D-C6C646828831' or ( ScopeName='get_record_trustaccounts' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('D3AE38F0-FA0D-4931-B81D-C6C646828831', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'get_record_trustaccounts', 'Bryant-Tu', 'Mar 12 2015  6:54AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='21A38849-61CB-4387-8C6D-C883681F48DB' or ( ScopeName='get_citizenaccess_citizens' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('21A38849-61CB-4387-8C6D-C883681F48DB', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_citizens', 'Don Liang', 'Mar 17 2015  3:11AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='DF1BF017-944B-4E1A-BAC7-C96F8368EA0A' or ( ScopeName='create_citizenaccess_citizens' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('DF1BF017-944B-4E1A-BAC7-C96F8368EA0A', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'create_citizenaccess_citizens', 'kay.li@beyondsoft.com', 'Mar 17 2015  6:44AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='7E6E1111-1EB7-4EC9-9D05-CE3C28A55A07' or ( ScopeName='add_citizenaccess_user_contacts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('7E6E1111-1EB7-4EC9-9D05-CE3C28A55A07', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'add_citizenaccess_user_contacts', 'jing', 'Mar  2 2015  9:24PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='8E63FB82-4E8A-4F10-B9C7-D72E92E9034D' or ( ScopeName='update_citizenaccess_citizens' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('8E63FB82-4E8A-4F10-B9C7-D72E92E9034D', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'update_citizenaccess_citizens', 'Don Liang', 'Mar 17 2015  5:21AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='AC9BBBB3-8CF3-4C0F-B4D4-E67E97048C67' or ( ScopeName='update_contact_condition' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('AC9BBBB3-8CF3-4C0F-B4D4-E67E97048C67', '1607A807-07C0-43FF-A914-F840EF2580A7', 'update_contact_condition', 'Enhui', 'Feb 26 2015  9:48PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='E202E62E-A8D7-4AE5-89F6-E6B773D48CB5' or ( ScopeName='get_contact_customform_meta' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('E202E62E-A8D7-4AE5-89F6-E6B773D48CB5', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_customform_meta', 'ashley.zou@beyondsoft.com', 'Feb 11 2015  7:27AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='20D188FC-AA93-4970-8439-EAB98CC33CCC' or ( ScopeName='update_contacts_customforms' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('20D188FC-AA93-4970-8439-EAB98CC33CCC', '1607A807-07C0-43FF-A914-F840EF2580A7', 'update_contacts_customforms', 'kay.li@beyondsoft.com', 'Feb 27 2015  9:09AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='E04B804D-8448-4169-ABA9-EDD50B7EB687' or ( ScopeName='delete_citizenaccess_user_profile' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('E04B804D-8448-4169-ABA9-EDD50B7EB687', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'delete_citizenaccess_user_profile', 'jing', 'Mar  2 2015  9:22PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='A920A56C-4EA2-418F-95ED-F9E1ADD272BA' or ( ScopeName='register_citizenaccess_user' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('A920A56C-4EA2-418F-95ED-F9E1ADD272BA', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'register_citizenaccess_user', 'jing', 'Mar  2 2015  9:27PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='86C7F0F7-B9B3-418F-8608-FB7E1AED35B5' or ( ScopeName='delete_contact_conditions' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('86C7F0F7-B9B3-418F-8608-FB7E1AED35B5', '1607A807-07C0-43FF-A914-F840EF2580A7', 'delete_contact_conditions', 'Enhui', 'Feb 26 2015  9:50PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='B4C04541-EF83-4F17-9AFF-FC3D64C7353A' or ( ScopeName='create_payments_completeonlinepayment' and GroupId='3649EBCE-C5C9-4C79-BD92-E37A0C9C3057'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('B4C04541-EF83-4F17-9AFF-FC3D64C7353A', '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057', 'create_payments_completeonlinepayment', 'moss.li@beyondsoft.com', 'Mar  4 2015  2:39AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='26944552-9706-4E55-B6AE-FD6EE27500AC' or ( ScopeName='update_announcements_read' and GroupId='9B1E9235-1EF8-46CF-AD57-C6521E61FA0E'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('26944552-9706-4E55-B6AE-FD6EE27500AC', '9B1E9235-1EF8-46CF-AD57-C6521E61FA0E', 'update_announcements_read', 'kay.li@beyondsoft.com', 'Mar 13 2015  9:09AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='F86AED1D-9B3A-4B54-950F-FF07799A0F57' or ( ScopeName='update_contact_customtables' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('F86AED1D-9B3A-4B54-950F-FF07799A0F57', '1607A807-07C0-43FF-A914-F840EF2580A7', 'update_contact_customtables', 'Bryant-Tu', 'Feb 13 2015  7:14AM', NULL, NULL)
end 

delete from [dbo].[Scope2Groups] where Id ='5112A996-B1D7-4763-BF75-921553729C8C'
