
if not exists(select * from [dbo].[Scope2Groups] where Id ='4D358871-34F3-4BB6-AE07-1027A8F54F18' or ( ScopeName='add_contact_conditions' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('4D358871-34F3-4BB6-AE07-1027A8F54F18', '1607A807-07C0-43FF-A914-F840EF2580A7', 'add_contact_conditions', 'david.jiang', 'Feb 10 2015  2:01AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='86C7F0F7-B9B3-418F-8608-FB7E1AED35B5' or ( ScopeName='delete_contact_conditions' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('86C7F0F7-B9B3-418F-8608-FB7E1AED35B5', '1607A807-07C0-43FF-A914-F840EF2580A7', 'delete_contact_conditions', 'Enhui', 'Feb 26 2015  9:50PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='E202E62E-A8D7-4AE5-89F6-E6B773D48CB5' or ( ScopeName='get_contact_customform_meta' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('E202E62E-A8D7-4AE5-89F6-E6B773D48CB5', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_customform_meta', 'ashley.zou@beyondsoft.com', 'Feb 11 2015  7:27AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='0E7B89A2-9BE8-403E-99CD-283A2B4EDB7D' or ( ScopeName='get_contact_customtable_meta' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('0E7B89A2-9BE8-403E-99CD-283A2B4EDB7D', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_customtable_meta', 'david.jiang', 'Feb 27 2015  6:31AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='87B5DF19-6F08-4F03-B9D6-8FB874A9942F' or ( ScopeName='get_contact_customtables' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('87B5DF19-6F08-4F03-B9D6-8FB874A9942F', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_customtables', 'B', 'Feb  9 2015  1:39AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='C6FBFEE9-57BA-4111-9037-189F99E5E301' or ( ScopeName='get_contacts_customforms' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('C6FBFEE9-57BA-4111-9037-189F99E5E301', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contacts_customforms', 'moss.li@beyondsoft.com', 'Feb 26 2015  9:03AM', NULL, NULL)
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

if not exists(select * from [dbo].[Scope2Groups] where Id ='AC9BBBB3-8CF3-4C0F-B4D4-E67E97048C67' or ( ScopeName='update_contact_condition' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('AC9BBBB3-8CF3-4C0F-B4D4-E67E97048C67', '1607A807-07C0-43FF-A914-F840EF2580A7', 'update_contact_condition', 'Enhui', 'Feb 26 2015  9:48PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='F86AED1D-9B3A-4B54-950F-FF07799A0F57' or ( ScopeName='update_contact_customtables' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('F86AED1D-9B3A-4B54-950F-FF07799A0F57', '1607A807-07C0-43FF-A914-F840EF2580A7', 'update_contact_customtables', 'Bryant-Tu', 'Feb 13 2015  7:14AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='20D188FC-AA93-4970-8439-EAB98CC33CCC' or ( ScopeName='update_contacts_customforms' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('20D188FC-AA93-4970-8439-EAB98CC33CCC', '1607A807-07C0-43FF-A914-F840EF2580A7', 'update_contacts_customforms', 'kay.li@beyondsoft.com', 'Feb 27 2015  9:09AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='7E6E1111-1EB7-4EC9-9D05-CE3C28A55A07' or ( ScopeName='add_citizenaccess_user_contacts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('7E6E1111-1EB7-4EC9-9D05-CE3C28A55A07', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'add_citizenaccess_user_contacts', 'jing', 'Mar  2 2015  9:24PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='724E1EC4-1D32-4B05-AD4D-6FD587C77BB4' or ( ScopeName='delete_citizenaccess_user_contacts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('724E1EC4-1D32-4B05-AD4D-6FD587C77BB4', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'delete_citizenaccess_user_contacts', 'jing', 'Mar  2 2015  9:33PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='1174B530-FCBC-4317-AA3C-031E851C6857' or ( ScopeName='get_citizenaccess_user_contacts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('1174B530-FCBC-4317-AA3C-031E851C6857', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_user_contacts', 'jing', 'Mar  2 2015  9:24PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='7DCA0DC1-7056-4342-B3A2-44D55D26FEE1' or ( ScopeName='get_citizenaccess_user_profile' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('7DCA0DC1-7056-4342-B3A2-44D55D26FEE1', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_user_profile', 'jing', 'Mar  2 2015  9:21PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='985A77C9-B1B6-4479-A5D4-07713B9FB0EF' or ( ScopeName='get_user_profile' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('985A77C9-B1B6-4479-A5D4-07713B9FB0EF', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_user_profile', 'kay.li@beyondsoft.com', 'Feb 24 2015  3:00AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='A920A56C-4EA2-418F-95ED-F9E1ADD272BA' or ( ScopeName='register_citizenaccess_user' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('A920A56C-4EA2-418F-95ED-F9E1ADD272BA', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'register_citizenaccess_user', 'jing', 'Mar  2 2015  9:27PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='759FB5E9-8012-4BDA-A31D-7333E8B2C8E0' or ( ScopeName='get_inspections_checkavailability' and GroupId='90F34533-9753-4802-8553-4D239CD1336C'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('759FB5E9-8012-4BDA-A31D-7333E8B2C8E0', '90F34533-9753-4802-8553-4D239CD1336C', 'get_inspections_checkavailability', 'moss.li@beyondsoft.com', 'Feb  9 2015  3:21AM', NULL, NULL)
end 

delete from [dbo].[Scope2Groups] where Id ='5112A996-B1D7-4763-BF75-921553729C8C'
