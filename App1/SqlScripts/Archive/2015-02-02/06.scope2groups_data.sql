--remove get_settings_EDMS
IF EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_EDMS' AND [GroupID] = '4912f2ee-2c19-4ebb-a139-7d47f1378c94') 
  BEGIN 
DELETE FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_EDMS' AND [GroupID] = '4912f2ee-2c19-4ebb-a139-7d47f1378c94'
END 
--remove get_settings_EDMS end

--get_settings_document_sources,create_inspection_checklist_item_customforms,create_inspection_comments,update_inspection_comments,update_checklist_items
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_document_sources' AND [GroupID] = '4912f2ee-2c19-4ebb-a139-7d47f1378c94') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'4912f2ee-2c19-4ebb-a139-7d47f1378c94',N'get_settings_document_sources',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'create_inspection_checklist_item_customforms' AND [GroupID] = '90f34533-9753-4802-8553-4d239cd1336c') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'90f34533-9753-4802-8553-4d239cd1336c',N'create_inspection_checklist_item_customforms',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'create_inspection_comments' AND [GroupID] = '90f34533-9753-4802-8553-4d239cd1336c') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'90f34533-9753-4802-8553-4d239cd1336c',N'create_inspection_comments',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'update_inspection_comments' AND [GroupID] = '90f34533-9753-4802-8553-4d239cd1336c') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'90f34533-9753-4802-8553-4d239cd1336c',N'update_inspection_comments',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'update_checklist_items' AND [GroupID] = '90f34533-9753-4802-8553-4d239cd1336c') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'90f34533-9753-4802-8553-4d239cd1336c',N'update_checklist_items',N'System',getdate(),NULL,NULL) 
END 
--get_settings_document_sources,create_inspection_checklist_item_customforms,create_inspection_comments,update_inspection_comments,update_checklist_items end

---refund_payment
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'refund_payment' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3057' ) 
 BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057',N'refund_payment',N'System',getdate(),NULL,NULL) 
END 
---refund_payment end


--get_settings_invoices_void_reasons get_settings_payments_refund_reasons  get_settings_payments_void_reasons
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_invoices_void_reasons' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_invoices_void_reasons',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_payments_refund_reasons' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_payments_refund_reasons',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_payments_void_reasons' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054',N'get_settings_payments_void_reasons',N'System',getdate(),NULL,NULL) 
END 
--get_settings_invoices_void_reasons get_settings_payments_refund_reasons  get_settings_payments_void_reasons end

--remove get_settings_condition_approval_priorities,get_settings_condition_approval_types
IF EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_condition_approval_priorities' AND [GroupID] = '3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6') 
  BEGIN 
DELETE FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_condition_approval_priorities' AND [GroupID] = '3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6'
END 

IF EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_condition_approval_types' AND [GroupID] = '3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6') 
  BEGIN 
DELETE FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_condition_approval_types' AND [GroupID] = '3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6'
END 
--remove get_settings_condition_approval_priorities,get_settings_condition_approval_types end

--void_invoice --
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'void_invoice' AND [GroupID] = 'BE701FD3-1F9A-4B26-83C8-4EAAD11407C6') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'BE701FD3-1F9A-4B26-83C8-4EAAD11407C6',N'void_invoice',N'System',getdate(),NULL,NULL) 
END 
--void_invoice end --

-- generate_receipt void_record_payment void_record_fee --
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'generate_receipt' AND [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'generate_receipt',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'void_record_payment' AND [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'void_record_payment',N'System',getdate(),NULL,NULL) 
END 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'void_record_fee' AND [GroupID] = 'baf4f245-0fac-4418-b529-18358aa1ea34') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'baf4f245-0fac-4418-b529-18358aa1ea34',N'void_record_fee',N'System',getdate(),NULL,NULL) 
END 
-- generate_receipt void_record_payment void_record_fee end --

--get_asset_parts --
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_asset_parts' AND [GroupID] = '350c43b6-1747-4966-96f4-c30cf2b09bc7') 
  BEGIN 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(),N'350c43b6-1747-4966-96f4-c30cf2b09bc7',N'get_asset_parts',N'System',getdate(),NULL,NULL) 
END
--get_asset_parts end -- 

--delete get_settings_fees -- 
IF EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_settings_fees' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3056') 
  BEGIN 
DELETE FROM [dbo].[Scope2Groups] WHERE [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3056' AND [ScopeName] = 'get_settings_fees'
END

IF EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE [ScopeName] = 'get_transaction' AND [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3056') 
  BEGIN 
DELETE FROM [dbo].[Scope2Groups] WHERE [GroupID] = '3649EBCE-C5C9-4C79-BD92-E37A0C9C3056' AND [ScopeName] = 'get_transaction'
END
--delete get_settings_fees -- 


if not exists(select * from [dbo].[Scope2Groups] where Id ='37B6C0F1-7BF2-45FB-8D01-CB5B8230B903' or ( ScopeName='get_contact_records' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('37B6C0F1-7BF2-45FB-8D01-CB5B8230B903', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_records', 'bryant.tu', 'Dec  8 2014  8:10AM', NULL, NULL)
end 

if not exists(select * from [dbo].[Scope2Groups] where Id ='A65641A4-022D-43FB-8C51-18EA976B000D' or ( ScopeName='get_settings_usergroups' and GroupId='3649EBCE-C5C9-4C79-BD92-E37A0C9C3054'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('A65641A4-022D-43FB-8C51-18EA976B000D', '3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', 'get_settings_usergroups', 'Waikei.Tam', 'Dec 10 2014  7:11AM', NULL, NULL)
end 
