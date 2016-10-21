------- create_mileage  get_settings_standard_choices---
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'create_mileage' AND [GroupID] = '55E54602-4577-4D96-A529-C145DF845DFF') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'55E54602-4577-4D96-A529-C145DF845DFF',N'create_mileage',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_standard_choices' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_standard_choices',N'System',getdate(),NULL,NULL) 
END 

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_workflow_task_comment_histories')
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_workflow_task_comment_histories', N'System', getdate(), NULL, NULL)
END
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_workflow_task_histories')
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_workflow_task_histories', N'System', getdate(), NULL, NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'4912F2EE-2C19-4EBB-A139-7D47F1378C94' AND [ScopeName] = N'get_document_thumbnail')
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate])
    VALUES (newid(), N'4912F2EE-2C19-4EBB-A139-7D47F1378C94', N'get_document_thumbnail', N'System', getdate(), NULL, NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'ADF9D0CA-7CCA-491F-94C1-4019D731B477' AND [ScopeName] = N'get_agency_environments')
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate])
    VALUES (newid(), N'ADF9D0CA-7CCA-491F-94C1-4019D731B477', N'get_agency_environments', N'System', getdate(), NULL, NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_part_locations' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_part_locations',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'apply_record_payments' AND [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'apply_record_payments',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'delete_record_fees' AND [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'delete_record_fees',N'System',getdate(),NULL,NULL) 
END  
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_payments' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057',N'get_payments',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_payment' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057',N'get_payment',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_payment_histories' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057',N'get_payment_histories',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_payment_history' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057',N'get_payment_history',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_payment_history_fees' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057',N'get_payment_history_fees',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_record_fee_histories' AND [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'get_record_fee_histories',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_record_payment_histories' AND [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'get_record_payment_histories',N'System',getdate(),NULL,NULL) 
END
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'create_shoppingcart' AND [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'create_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'delete_shoppingcart' AND [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'delete_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_all_shoppingcart' AND [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'get_all_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_shoppingcart' AND [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'get_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'update_shoppingcart' AND [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'update_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'search_costs' AND [GroupID] = '39934F23-DDEA-4D9E-A6CD-1A703BBDFE3E') 
BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'39934F23-DDEA-4D9E-A6CD-1A703BBDFE3E',N'search_costs',N'System',getdate(),NULL,NULL) 
END
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'void_payment' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057',N'void_payment',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'update_record_fee' AND [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'update_record_fee',N'System',getdate(),NULL,NULL) 
END

---add shopping cart
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_all_shoppingcart' AND  [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'get_all_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_shoppingcart' AND  [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'get_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'create_shoppingcart' AND  [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'create_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'delete_shoppingcart' AND  [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'delete_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'update_shoppingcart' AND  [GroupID] = '7A0B2774-96E8-490F-8F76-98580BB1ED39') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'7A0B2774-96E8-490F-8F76-98580BB1ED39',N'update_shoppingcart',N'System',getdate(),NULL,NULL) 
END 
---add shopping cart end.

---add announcements
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_announcements' AND [GroupID] = '9B1E9235-1EF8-46CF-AD57-C6521E61FA0E') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'9B1E9235-1EF8-46CF-AD57-C6521E61FA0E',N'get_announcements',N'System',getdate(),NULL,NULL) 
END 
---add announcements end.

---add checklist status
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'90f34533-9753-4802-8553-4d239cd1336c',N'get_inspection_checklist_statuses',N'System',getdate(),NULL,NULL) 
---add checklist status end 

---add estimate_record_fees
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'estimate_record_fees',N'System',getdate(),NULL,NULL) 
---end estimate_record_fees


--- add Record Activities
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'create_record_activities',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'get_record_activities',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'update_record_activity',N'System',getdate(),NULL,NULL) 
--- edd Record Activities
--- add Record Activities Settings
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_activity_types',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_activity_statuses',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_activity_priorities',N'System',getdate(),NULL,NULL) 
--- add Record Activities Settings

--- add part search
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'9AFAC561-FFAD-40C4-B128-C6169DB58FFD',N'search_parts',N'System',getdate(),NULL,NULL) 
--- end part search

--- add part cost settings
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_cost_types',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_cost_accounts',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_cost_unit_types',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_cost_factors',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_part_types',N'System',getdate(),NULL,NULL) 
--- end part cost settings

--- add share dropdown
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_shared_dropdown_list_detail',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_shared_dropdown_list',N'System',getdate(),NULL,NULL) 
--- end share dropdown

--- add cost item
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_cost_items',N'System',getdate(),NULL,NULL) 
--- end cost item

--- delete create payment from group 'cashier'
delete from Scope2Groups where  Scope2Groups.scopename='create_payments' and id in  (SELECT Scope2Groups.id FROM  Scope2Groups,scopegroups where Scope2Groups.scopename = 'create_payments' and scopegroups.name = 'cashier' and Scope2Groups.groupid=scopegroups.id)
--- end delete create payment from group 'cashier'


IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'search_costs' AND [GroupID] = '39934F23-DDEA-4D9E-A6CD-1A703BBDFE3E') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'39934F23-DDEA-4D9E-A6CD-1A703BBDFE3E',N'search_costs',N'System',getdate(),NULL,NULL) 
END 


INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_pick_list',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_pick_lists',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'4912f2ee-2c19-4ebb-a139-7d47f1378c94',N'get_documents_folder_groups',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'4912f2ee-2c19-4ebb-a139-7d47f1378c94',N'get_documents_folders',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'4912f2ee-2c19-4ebb-a139-7d47f1378c94',N'update_documents_folder_groups',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'4912f2ee-2c19-4ebb-a139-7d47f1378c94',N'update_documents_folders',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'4912f2ee-2c19-4ebb-a139-7d47f1378c94',N'create_documents_folders',N'System',getdate(),NULL,NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'4912f2ee-2c19-4ebb-a139-7d47f1378c94',N'delete_documents_folders',N'System',getdate(),NULL,NULL) 

INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'delete_records',N'System',getdate(),NULL,NULL) 


IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'search_parts' AND [GroupID] = '9AFAC561-FFAD-40C4-B128-C6169DB58FFD' ) 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'9AFAC561-FFAD-40C4-B128-C6169DB58FFD',N'search_parts',N'System',getdate(),NULL,NULL) 
END 

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'delete_timeaccounting' AND  [GroupID] = '0407EF3B-D3BF-48A8-8C1A-2EF8A989121D') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'0407EF3B-D3BF-48A8-8C1A-2EF8A989121D',N'delete_timeaccounting',N'System',getdate(),NULL,NULL) 
END 

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_timeaccounting' AND  [GroupID] = '0407EF3B-D3BF-48A8-8C1A-2EF8A989121D') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'0407EF3B-D3BF-48A8-8C1A-2EF8A989121D',N'get_timeaccounting',N'System',getdate(),NULL,NULL) 
END 

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'create_timeaccounting' AND  [GroupID] = '0407EF3B-D3BF-48A8-8C1A-2EF8A989121D') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'0407EF3B-D3BF-48A8-8C1A-2EF8A989121D',N'create_timeaccounting',N'System',getdate(),NULL,NULL) 
END 

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'update_timeaccounting' AND  [GroupID] = '0407EF3B-D3BF-48A8-8C1A-2EF8A989121D') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'0407EF3B-D3BF-48A8-8C1A-2EF8A989121D',N'update_timeaccounting',N'System',getdate(),NULL,NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_inspection_condition_permission' AND  [GroupID] = '90f34533-9753-4802-8553-4d239cd1336c') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'90f34533-9753-4802-8553-4d239cd1336c', 'get_inspection_condition_permission',N'System',getdate(),NULL,NULL) 
END 

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_record_parttransaction' AND  [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'baf4f245-0fac-4418-b529-18358aa1ea34', 'get_record_parttransaction',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'create_record_parttransaction' AND  [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'baf4f245-0fac-4418-b529-18358aa1ea34', 'create_record_parttransaction',N'System',getdate(),NULL,NULL) 
END 

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'void_record_parttransaction' AND  [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'baf4f245-0fac-4418-b529-18358aa1ea34', 'void_record_parttransaction',N'System',getdate(),NULL,NULL) 
END
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_record_type_virtual_folder' AND  [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', 'get_record_type_virtual_folder',N'System',getdate(),NULL,NULL) 
END


IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_record_virtual_folder' AND  [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'baf4f245-0fac-4418-b529-18358aa1ea34', 'get_record_virtual_folder',N'System',getdate(),NULL,NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'update_document' AND  [GroupID] = '4912f2ee-2c19-4ebb-a139-7d47f1378c94') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'4912f2ee-2c19-4ebb-a139-7d47f1378c94', 'update_document',N'System',getdate(),NULL,NULL) 
END


IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_EDMS' AND  [GroupID] = '4912f2ee-2c19-4ebb-a139-7d47f1378c94') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'4912f2ee-2c19-4ebb-a139-7d47f1378c94', 'get_settings_EDMS',N'System',getdate(),NULL,NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_app_settings' AND  [GroupID] = '97FB6FA2-01A1-4EEB-B1E7-3528C848DC2D') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'97FB6FA2-01A1-4EEB-B1E7-3528C848DC2D', 'get_app_settings',N'System',getdate(),NULL,NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'search_agencies' AND  [GroupID] = 'ADF9D0CA-7CCA-491F-94C1-4019D731B477') 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),'ADF9D0CA-7CCA-491F-94C1-4019D731B477', 'search_agencies',N'System',getdate(),NULL,NULL) 
END