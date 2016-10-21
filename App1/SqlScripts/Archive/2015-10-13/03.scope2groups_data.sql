
if not exists(select * from [dbo].[Scope2Groups] where Id ='39F0565A-4D24-45BC-932D-0B9712E78CE9' or ( ScopeName='get_parcel_conditions' and GroupId='5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('39F0565A-4D24-45BC-932D-0B9712E78CE9', '5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD', 'get_parcel_conditions', 'kevin.tang', 'Dec 25 2014  6:57AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='C022EA7B-C422-4E11-B215-14E1C012C471' or ( ScopeName='create_documentreview_documents_comments' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('C022EA7B-C422-4E11-B215-14E1C012C471', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'create_documentreview_documents_comments', 'kay.li@beyondsoft.com', 'Feb  2 2015  8:39AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='A65641A4-022D-43FB-8C51-18EA976B000D' or ( ScopeName='get_settings_usergroups' and GroupId='3649EBCE-C5C9-4C79-BD92-E37A0C9C3054'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('A65641A4-022D-43FB-8C51-18EA976B000D', '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', 'get_settings_usergroups', 'Waikei.Tam', 'Dec 10 2014  7:11AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='43F3A1A3-CD67-4AE7-898C-4BB8FE8FBD71' or ( ScopeName='get_citizen_users' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('43F3A1A3-CD67-4AE7-898C-4BB8FE8FBD71', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizen_users', 'kevin.tang@beyondsoft.com', 'Aug  5 2015  8:12AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='00474ADF-41A8-457A-A129-50C2849EB514' or ( ScopeName='create_documentreview_records_documents' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('00474ADF-41A8-457A-A129-50C2849EB514', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'create_documentreview_records_documents', 'kay.li@beyondsoft.com', 'Feb  2 2015  8:58AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='8D8E7614-3DEA-4564-9DE1-54A936062DA2' or ( ScopeName='get_subscription' and GroupId='7CA61FE8-F27E-4BC5-AC2B-387746A246B6'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('8D8E7614-3DEA-4564-9DE1-54A936062DA2', '7CA61FE8-F27E-4BC5-AC2B-387746A246B6', 'get_subscription', 'Bryant-Tu', 'Feb  9 2015  6:55AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='48138900-6D8C-4BDA-9399-58B486634530' or ( ScopeName='get_record_workflowtasks_customforms' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('48138900-6D8C-4BDA-9399-58B486634530', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'get_record_workflowtasks_customforms', 'kay.li@beyondsoft.com', 'Jan 13 2015  5:38AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='FA30AFB0-032A-48F9-BA66-61E5BBB25824' or ( ScopeName='update_documentreview_documents_comments' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('FA30AFB0-032A-48F9-BA66-61E5BBB25824', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'update_documentreview_documents_comments', 'kay.li@beyondsoft.com', 'Feb  2 2015  8:59AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='83095028-5071-485E-9D37-629FD97D2B5A' or ( ScopeName='delete_subscriptions' and GroupId='7CA61FE8-F27E-4BC5-AC2B-387746A246B6'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('83095028-5071-485E-9D37-629FD97D2B5A', '7CA61FE8-F27E-4BC5-AC2B-387746A246B6', 'delete_subscriptions', 'Bryant-Tu', 'Feb  9 2015  6:54AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='63AC68C6-5001-4B6D-BD79-63B49A627DDB' or ( ScopeName='update_documentreview_documents_tasks' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('63AC68C6-5001-4B6D-BD79-63B49A627DDB', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'update_documentreview_documents_tasks', 'kay.li@beyondsoft.com', 'Feb  2 2015  8:59AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='86D9C031-33C0-4AE6-A5BF-678039CB0B20' or ( ScopeName='get_subscriptions' and GroupId='7CA61FE8-F27E-4BC5-AC2B-387746A246B6'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('86D9C031-33C0-4AE6-A5BF-678039CB0B20', '7CA61FE8-F27E-4BC5-AC2B-387746A246B6', 'get_subscriptions', 'Bryant-Tu', 'Feb  9 2015  6:54AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='AA26FD4F-27CF-4F0D-A30D-67C9D8A63D5E' or ( ScopeName='create_documentreview_records_documents_checkin' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('AA26FD4F-27CF-4F0D-A30D-67C9D8A63D5E', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'create_documentreview_records_documents_checkin', 'kay.li@beyondsoft.com', 'Feb  2 2015  8:58AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='2C60B2CC-67B3-4F8F-BDB2-70094C6B8844' or ( ScopeName='get_addresses_conditions' and GroupId='7E7B200C-5A80-455B-9EE5-719DD8158B6E'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('2C60B2CC-67B3-4F8F-BDB2-70094C6B8844', '7E7B200C-5A80-455B-9EE5-719DD8158B6E', 'get_addresses_conditions', 'Enhui', 'Feb  4 2015 12:52AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='80FB212B-8AEF-4F41-A641-7085829FDAD8' or ( ScopeName='get_settings_inspection_type' and GroupId='90F34533-9753-4802-8553-4D239CD1336C'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('80FB212B-8AEF-4F41-A641-7085829FDAD8', '90F34533-9753-4802-8553-4D239CD1336C', 'get_settings_inspection_type', 'SystemImportor', 'Dec  2 2014  2:25AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='37122F6F-5A02-495B-A625-7AE335B1F004' or ( ScopeName='create_subscriptions' and GroupId='7CA61FE8-F27E-4BC5-AC2B-387746A246B6'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('37122F6F-5A02-495B-A625-7AE335B1F004', '7CA61FE8-F27E-4BC5-AC2B-387746A246B6', 'create_subscriptions', 'Bryant-Tu', 'Feb  9 2015  6:56AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='9B352B18-D95C-40B6-8CF5-7C313BEB3472' or ( ScopeName='get_record_workflow_task_customform_meta' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('9B352B18-D95C-40B6-8CF5-7C313BEB3472', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'get_record_workflow_task_customform_meta', 'ashley.zou@beyondsoft.com', 'Jan 22 2015  3:32AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='F03FEA30-10CD-42B6-BA20-925E2F0E7466' or ( ScopeName='get_user_profile' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('F03FEA30-10CD-42B6-BA20-925E2F0E7466', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_user_profile', 'kay.li@beyondsoft.com', 'Feb  9 2015  1:31PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='F1D2DEBA-291B-440E-AD5C-98FD7950A7BB' or ( ScopeName='get_record_gisobjects' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('F1D2DEBA-291B-440E-AD5C-98FD7950A7BB', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'get_record_gisobjects', 'kay.li@beyondsoft.com', 'Jan 14 2015  9:26AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='DE5BCA59-08BC-44DC-A690-A2D67B86C121' or ( ScopeName='get_contact_conditions' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('DE5BCA59-08BC-44DC-A690-A2D67B86C121', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_conditions', 'pdhanore', 'Dec 18 2014 12:53AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='1A0CFDD5-500A-49E3-B0C6-A3F11EB8B0F9' or ( ScopeName='get_settings_asset_recordtypes' and GroupId='3649EBCE-C5C9-4C79-BD92-E37A0C9C3054'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('1A0CFDD5-500A-49E3-B0C6-A3F11EB8B0F9', '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', 'get_settings_asset_recordtypes', 'ashley.zou@beyondsoft.com', 'Jan  7 2015  6:07AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='4E19AB7E-B168-4604-BB5A-A8C1642C962C' or ( ScopeName='get_owner_conditions' and GroupId='E4012277-3AF1-4A36-9114-EAD669601B1B'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('4E19AB7E-B168-4604-BB5A-A8C1642C962C', 'E4012277-3AF1-4A36-9114-EAD669601B1B', 'get_owner_conditions', 'david.jiang', 'Dec 31 2014 12:36PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='638CE202-AAF9-4C56-B131-AD59D41BA19E' or ( ScopeName='get_documentreview_documents_comments' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('638CE202-AAF9-4C56-B131-AD59D41BA19E', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'get_documentreview_documents_comments', 'kay.li@beyondsoft.com', 'Feb  2 2015  8:21AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='24773B15-9E8D-471B-80D4-B0E2300F5B49' or ( ScopeName='get_inspections_checkavailability' and GroupId='90F34533-9753-4802-8553-4D239CD1336C'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('24773B15-9E8D-471B-80D4-B0E2300F5B49', '90F34533-9753-4802-8553-4D239CD1336C', 'get_inspections_checkavailability', 'Jackie', 'Sep 18 2015  9:41PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='6EF7ED92-6B3B-4E17-BC22-C1FADC94C0BA' or ( ScopeName='search_records' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('6EF7ED92-6B3B-4E17-BC22-C1FADC94C0BA', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'search_records', 'SystemImportor', 'Dec  2 2014  2:25AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='16919C21-3BBC-48DE-9EB6-C61E92E3B261' or ( ScopeName='update_subscription' and GroupId='7CA61FE8-F27E-4BC5-AC2B-387746A246B6'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('16919C21-3BBC-48DE-9EB6-C61E92E3B261', '7CA61FE8-F27E-4BC5-AC2B-387746A246B6', 'update_subscription', 'Bryant-Tu', 'Feb  9 2015  6:57AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='FF0DC515-C163-4103-918D-C666D0C7F783' or ( ScopeName='get_contacts_conditions' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('FF0DC515-C163-4103-918D-C666D0C7F783', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contacts_conditions', 'pdhanore', 'Dec 17 2014  6:53PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='37B6C0F1-7BF2-45FB-8D01-CB5B8230B903' or ( ScopeName='get_contact_records' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('37B6C0F1-7BF2-45FB-8D01-CB5B8230B903', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_records', 'bryant.tu', 'Dec  8 2014  8:10AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='5FA19F2E-7305-4C4A-8024-CC2632E59EFF' or ( ScopeName='delete_documentreview_documents_comments' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('5FA19F2E-7305-4C4A-8024-CC2632E59EFF', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'delete_documentreview_documents_comments', 'kay.li@beyondsoft.com', 'Feb  2 2015  8:18AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='4009C535-FA24-4051-B360-CF115C30459F' or ( ScopeName='get_inspectors' and GroupId='90F34533-9753-4802-8553-4D239CD1336C'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('4009C535-FA24-4051-B360-CF115C30459F', '90F34533-9753-4802-8553-4D239CD1336C', 'get_inspectors', 'SystemImportor', 'Dec  2 2014  2:25AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='5D0A22A5-F87A-4C5A-9C28-D2FC86318297' or ( ScopeName='get_record_workflow_task_customforms_meta' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('5D0A22A5-F87A-4C5A-9C28-D2FC86318297', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'get_record_workflow_task_customforms_meta', 'ashley.zou@beyondsoft.com', 'Jan 22 2015  3:32AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='6DB07694-7DA7-4BB3-932F-E14256CF2AF0' or ( ScopeName='get_professionals_conditions' and GroupId='5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('6DB07694-7DA7-4BB3-932F-E14256CF2AF0', '5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', 'get_professionals_conditions', 'Enhui', 'Jan 14 2015  6:11PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='7964A8D8-F487-4DB3-837C-E2C1692BF0CF' or ( ScopeName='update_record_workflow_task_customforms' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('7964A8D8-F487-4DB3-837C-E2C1692BF0CF', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'update_record_workflow_task_customforms', 'Bryant-Tu', 'Jan 12 2015  2:16AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='E370ECAB-C280-4024-BEB0-EA8ECDB09F63' or ( ScopeName='get_record_workflow_task_customforms' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('E370ECAB-C280-4024-BEB0-EA8ECDB09F63', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'get_record_workflow_task_customforms', 'david.jiang', 'Jan 14 2015  6:29AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='A4399270-C67F-4C92-97A6-F44394783861' or ( ScopeName='get_user' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('A4399270-C67F-4C92-97A6-F44394783861', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_user', 'kevin.tang@beyondsoft.com', 'Aug  5 2015  8:20AM', NULL, NULL)
end 
