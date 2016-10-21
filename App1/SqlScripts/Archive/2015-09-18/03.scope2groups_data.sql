
if not exists(select * from [dbo].[Scope2Groups] where Id ='B4731C24-3C30-485B-834C-9759A08A5AC0' or ( ScopeName='get_settings_inspection_type' and GroupId='90F34533-9753-4802-8553-4D239CD1336C'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('B4731C24-3C30-485B-834C-9759A08A5AC0', '90F34533-9753-4802-8553-4D239CD1336C', 'get_settings_inspection_type', 'ashley.zou@beyondsoft.com', 'Apr  3 2015  2:42AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='E289EC42-20F1-4CBF-B18A-0AA7B500EE36' or ( ScopeName='get_settings_inspection_types' and GroupId='90F34533-9753-4802-8553-4D239CD1336C'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('E289EC42-20F1-4CBF-B18A-0AA7B500EE36', '90F34533-9753-4802-8553-4D239CD1336C', 'get_settings_inspection_types', 'ashley.zou@beyondsoft.com', 'Apr  3 2015  2:45AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='72AE9D28-D845-46AA-9037-AA90BE03A42A' or ( ScopeName='search_records' and GroupId='BAF4F245-0FAC-4418-B529-18358AA1EA34'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('72AE9D28-D845-46AA-9037-AA90BE03A42A', 'BAF4F245-0FAC-4418-B529-18358AA1EA34', 'search_records', 'kay.li@beyondsoft.com', 'Apr 14 2015  7:29AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='551BEE07-5EE1-4FDA-8E33-9B9D640CF559' or ( ScopeName='payments_initialize' and GroupId='3649EBCE-C5C9-4C79-BD92-E37A0C9C3057'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('551BEE07-5EE1-4FDA-8E33-9B9D640CF559', '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057', 'payments_initialize', 'moss.li@beyondsoft.com', 'Apr 16 2015  9:44AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='F8044C95-2059-4670-B791-59AE59DFA673' or ( ScopeName='create_civicid_accounts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('F8044C95-2059-4670-B791-59AE59DFA673', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'create_civicid_accounts', 'vsamaresan', 'Apr  7 2015 11:07PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='242FBF4F-0984-4B27-8981-AE20313ED201' or ( ScopeName='get_citizenaccess_citizens_delegates' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('242FBF4F-0984-4B27-8981-AE20313ED201', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_citizens_delegates', 'Enhui', 'Apr  1 2015 11:39PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='6A547E15-3801-45BD-92F4-22C84BAB7B4C' or ( ScopeName='get_citizenaccess_citizens_invitations' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('6A547E15-3801-45BD-92F4-22C84BAB7B4C', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_citizens_invitations', 'Enhui', 'Apr  1 2015 11:40PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='24BB9A82-7859-4258-82B9-0B5A6F0FA6E9' or ( ScopeName='get_citizenaccess_trustaccounts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('24BB9A82-7859-4258-82B9-0B5A6F0FA6E9', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizenaccess_trustaccounts', 'Bryant-Tu', 'Apr 23 2015  6:39AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='F452C9DF-D425-417F-9A9A-F1E18735EACB' or ( ScopeName='get_citizens_accounts' and GroupId='A8AEE62B-E6FB-407E-87AE-471122F1A89A'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('F452C9DF-D425-417F-9A9A-F1E18735EACB', 'A8AEE62B-E6FB-407E-87AE-471122F1A89A', 'get_citizens_accounts', 'Bryant-Tu', 'Apr 21 2015  1:55AM', NULL, NULL)
end 

delete from [dbo].[Scope2Groups] where Id ='576FD28F-6068-45DA-98BC-04910684AD85'

delete from [dbo].[Scope2Groups] where Id ='80FB212B-8AEF-4F41-A641-7085829FDAD8'

delete from [dbo].[Scope2Groups] where Id ='F5EFACAD-B0EA-4BD8-81C7-7D9C5BDC7A45'

delete from [dbo].[Scope2Groups] where Id ='0CFDDF38-87D6-479C-9F61-B434A4D07781'

delete from [dbo].[Scope2Groups] where Id ='6EF7ED92-6B3B-4E17-BC22-C1FADC94C0BA'

delete from [dbo].[Scope2Groups] where Id ='6797D411-F0A3-44CA-BD38-D612723981B9'

if not exists(select * from [dbo].[Scope2Groups] where Id ='98EC867A-3286-4F22-83B7-5833D5653EBF' or ( ScopeName='delete_civicid_accounts' and GroupId='7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('98EC867A-3286-4F22-83B7-5833D5653EBF', '7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6', 'delete_civicid_accounts', 'vsamaresan', 'Apr 30 2015 11:02PM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='F56A972D-38AA-4E3F-897E-E3D593C1A8FD' or ( ScopeName='create_civicid_accounts' and GroupId='7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('F56A972D-38AA-4E3F-897E-E3D593C1A8FD', '7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6', 'create_civicid_accounts', 'vsamaresan', 'Apr 30 2015 10:58PM', NULL, NULL)
end 

delete from [dbo].[Scope2Groups] where Id ='F8044C95-2059-4670-B791-59AE59DFA673'

delete from [dbo].[Scope2Groups] where Id ='40E24B79-F2BD-4D57-AAAF-62E0726A3F22'


if not exists(select * from [dbo].[Scope2Groups] where Id ='72C0D4F3-346B-4497-97BF-1F94C23254D7' or ( ScopeName='create_documentreview_records_documents' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('72C0D4F3-346B-4497-97BF-1F94C23254D7', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'create_documentreview_records_documents', 'vsamaresan', 'May  1 2015 12:21AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='A28738DF-B858-4D42-90F1-3A4797093C5F' or ( ScopeName='create_documentreview_records_documents_checkin' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('A28738DF-B858-4D42-90F1-3A4797093C5F', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'create_documentreview_records_documents_checkin', 'vsamaresan', 'May  1 2015 12:22AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='1C2704BD-0261-4813-B5DC-400F367B3FAC' or ( ScopeName='delete_documentreview_documents_comments' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('1C2704BD-0261-4813-B5DC-400F367B3FAC', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'delete_documentreview_documents_comments', 'vsamaresan', 'May  1 2015 12:18AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='2509C732-1DBF-4F6E-B5D3-68ED8204CDB4' or ( ScopeName='update_documentreview_documents_comments' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('2509C732-1DBF-4F6E-B5D3-68ED8204CDB4', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'update_documentreview_documents_comments', 'vsamaresan', 'May  1 2015 12:25AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='2BD5227F-E282-44F7-9746-AAD2B819AAAB' or ( ScopeName='update_documentreview_documents_tasks' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('2BD5227F-E282-44F7-9746-AAD2B819AAAB', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'update_documentreview_documents_tasks', 'vsamaresan', 'May  1 2015 12:20AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='FFE06A39-03EA-4084-BC5A-BE730D44B186' or ( ScopeName='create_documentreview_documents_comments' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('FFE06A39-03EA-4084-BC5A-BE730D44B186', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'create_documentreview_documents_comments', 'vsamaresan', 'May  1 2015 12:25AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='D6352F0A-720A-4371-BBA0-D362F8D14827' or ( ScopeName='get_documentreview_documents_comments' and GroupId='4912F2EE-2C19-4EBB-A139-7D47F1378C94'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('D6352F0A-720A-4371-BBA0-D362F8D14827', '4912F2EE-2C19-4EBB-A139-7D47F1378C94', 'get_documentreview_documents_comments', 'vsamaresan', 'May  1 2015 12:26AM', NULL, NULL)
end 

