IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'delete_contacts') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'delete_contacts', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'E809C667-59D5-4762-8D7D-785FB75EA67C' AND [ScopeName] = N'create_report') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'E809C667-59D5-4762-8D7D-785FB75EA67C', N'create_report', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'delete_inspection_timeaccounting') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'delete_inspection_timeaccounting', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_parcel') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_parcel', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspector') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspector', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_contacts') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_contacts', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'E809C667-59D5-4762-8D7D-785FB75EA67C' AND [ScopeName] = N'get_settings_report_categories') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'E809C667-59D5-4762-8D7D-785FB75EA67C', N'get_settings_report_categories', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspectors') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspectors', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_professional') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_professional', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_settings_address_street_suffixes') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_settings_address_street_suffixes', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'get_settings_contact_salutations') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'get_settings_contact_salutations', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_professionals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_professionals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_condition_statuses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_condition_statuses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_professional_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_professional_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056' AND [ScopeName] = N'get_settings_fees') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056', N'get_settings_fees', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'ADF9D0CA-7CCA-491F-94C1-4019D731B477' AND [ScopeName] = N'get_agencies') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'ADF9D0CA-7CCA-491F-94C1-4019D731B477', N'get_agencies', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_customtable_meta') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_customtable_meta', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_workflow_task') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_workflow_task', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'cancel_inspection') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'cancel_inspection', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'update_contact') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'update_contact', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_records') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_records', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'create_contacts') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'create_contacts', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'result_inspection') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'result_inspection', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_documents') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_documents', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_condition_approval') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_condition_approval', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_customform_meta') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_customform_meta', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'search_inspections') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'search_inspections', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_document') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_document', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_votes') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_votes', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_histories') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_histories', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_condition_approvals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_condition_approvals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_condition_approval') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_condition_approval', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_condition_approval') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_condition_approval', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'E4012277-3AF1-4A36-9114-EAD669601B1B' AND [ScopeName] = N'get_owners') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'E4012277-3AF1-4A36-9114-EAD669601B1B', N'get_owners', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'delete_inspections') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'delete_inspections', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_professional_salutations') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_professional_salutations', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_statuses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_statuses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_condition_priorities') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_condition_priorities', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'search_contacts') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'search_contacts', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_settings_record_type_customform') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_settings_record_type_customform', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'create_inspection_checklists') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'create_inspection_checklists', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'ADF9D0CA-7CCA-491F-94C1-4019D731B477' AND [ScopeName] = N'get_agency_logo') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'ADF9D0CA-7CCA-491F-94C1-4019D731B477', N'get_agency_logo', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_items') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_items', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_workflow_task') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_workflow_task', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_address') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_address', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_conditions_standard') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'get_conditions_standard', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'create_inspection_documents') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'create_inspection_documents', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_parcels') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_parcels', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_histories') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_histories', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_related') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_related', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'delete_inspection_checklists') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'delete_inspection_checklists', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_condition') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_condition', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_checklist_groups') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_checklist_groups', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_professionals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_professionals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_my_civicid_profile') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_my_civicid_profile', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_conditions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_conditions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056' AND [ScopeName] = N'get_transaction') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056', N'get_transaction', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD' AND [ScopeName] = N'search_parcels') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD', N'search_parcels', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_checklist_item_customform') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_checklist_item_customform', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054' AND [ScopeName] = N'get_settings_standard_comment_groups') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_standard_comment_groups', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_address') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_address', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD' AND [ScopeName] = N'get_parcel_owners') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD', N'get_parcel_owners', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_inspection_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_inspection_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_customtables') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_customtables', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_comments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_comments', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'search_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'search_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054' AND [ScopeName] = N'get_settings_modules') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_modules', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'A8AEE62B-E6FB-407E-87AE-471122F1A89A' AND [ScopeName] = N'update_my_profile') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'A8AEE62B-E6FB-407E-87AE-471122F1A89A', N'update_my_profile', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_contact_address') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_contact_address', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'4912F2EE-2C19-4EBB-A139-7D47F1378C94' AND [ScopeName] = N'download_document') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'4912F2EE-2C19-4EBB-A139-7D47F1378C94', N'download_document', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054' AND [ScopeName] = N'get_settings_departments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_departments', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_condition') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_condition', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054' AND [ScopeName] = N'get_settings_standard_comments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_standard_comments', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_parcels') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_parcels', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_invoice') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_invoice', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_related') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_related', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_comment') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_comment', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_comments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_comments', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'schedule_pending_inspection') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'schedule_pending_inspection', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_customforms') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_customforms', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_customtables_meta') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_customtables_meta', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'ADF9D0CA-7CCA-491F-94C1-4019D731B477' AND [ScopeName] = N'get_my_linked_accounts') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'ADF9D0CA-7CCA-491F-94C1-4019D731B477', N'get_my_linked_accounts', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD' AND [ScopeName] = N'get_parcel_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD', N'get_parcel_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_create_record_describe') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_create_record_describe', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_additional') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_additional', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'update_inspection_condition') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'update_inspection_condition', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_condition_approvals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_condition_approvals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_conditions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_conditions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'E4012277-3AF1-4A36-9114-EAD669601B1B' AND [ScopeName] = N'search_owners') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'E4012277-3AF1-4A36-9114-EAD669601B1B', N'search_owners', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_professional') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_professional', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_settings_address_street_fractions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_settings_address_street_fractions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_settings_record_statuses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_settings_record_statuses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_customtables') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_customtables', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'E809C667-59D5-4762-8D7D-785FB75EA67C' AND [ScopeName] = N'get_settings_report_definitions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'E809C667-59D5-4762-8D7D-785FB75EA67C', N'get_settings_report_definitions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'create_inspection_checklist_item_document') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'create_inspection_checklist_item_document', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_settings_record_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_settings_record_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_contact_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_contact_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'update_inspection_timeaccounting') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'update_inspection_timeaccounting', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_professionals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_professionals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_my_records') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_my_records', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_comments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_comments', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'get_settings_contact_races') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'get_settings_contact_races', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_documents') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_documents', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_location') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_location', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_timeaccounting') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_timeaccounting', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_condition_histories') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_condition_histories', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_customforms_meta') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_customforms_meta', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_customforms') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_customforms', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'4912F2EE-2C19-4EBB-A139-7D47F1378C94' AND [ScopeName] = N'get_settings_document_categories') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'4912F2EE-2C19-4EBB-A139-7D47F1378C94', N'get_settings_document_categories', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'update_inspection_checklist_item_customforms') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'update_inspection_checklist_item_customforms', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_votes_summary') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_votes_summary', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'get_settings_contact_relations') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'get_settings_contact_relations', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_condition_approvals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_condition_approvals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_related') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_related', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'delete_inspection_related') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'delete_inspection_related', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_owners') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_owners', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'assign_inspections') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'assign_inspections', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspections') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspections', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_related') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_related', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_address_parcels') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_address_parcels', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054' AND [ScopeName] = N'get_settings_department_staffs') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_department_staffs', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_customforms_meta') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_customforms_meta', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_condition_approval_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_condition_approval_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_workflow_task_statuses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_workflow_task_statuses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_workflow_tasks') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_workflow_tasks', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_inspection_type') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_inspection_type', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_customtables_meta') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_customtables_meta', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'689DF941-C0F2-4917-BBEE-19A680BC1985' AND [ScopeName] = N'open_data_query') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'689DF941-C0F2-4917-BBEE-19A680BC1985', N'open_data_query', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_settings_address_unit_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_settings_address_unit_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'A8AEE62B-E6FB-407E-87AE-471122F1A89A' AND [ScopeName] = N'get_my_profile') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'A8AEE62B-E6FB-407E-87AE-471122F1A89A', N'get_my_profile', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_settings_address_countries') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_settings_address_countries', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_inspection_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_inspection_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_customform_meta') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_customform_meta', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_documents') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_documents', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_checklist_item_customtable') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_checklist_item_customtable', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_owners') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_owners', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_condition_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_condition_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_contact') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_contact', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_customforms') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_customforms', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_condition_approval_statuses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_condition_approval_statuses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'create_inspection_timeaccounting') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'create_inspection_timeaccounting', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD' AND [ScopeName] = N'get_parcel') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD', N'get_parcel', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'get_contact_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'get_contact_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'4912F2EE-2C19-4EBB-A139-7D47F1378C94' AND [ScopeName] = N'get_document') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'4912F2EE-2C19-4EBB-A139-7D47F1378C94', N'get_document', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_customtable') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_customtable', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_owners') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_owners', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056' AND [ScopeName] = N'get_settings_record_type_feeschedules') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_settings_record_type_feeschedules', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'update_inspection') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'update_inspection', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_inspection_grades') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_inspection_grades', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'finalize_record') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'finalize_record', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_customtable_meta') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_customtable_meta', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'delete_inspection_condition_approvals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'delete_inspection_condition_approvals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'create_inspection_conditions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'create_inspection_conditions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_settings_construction_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_settings_construction_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_parcels') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_parcels', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_settings_record_type_customtable') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_settings_record_type_customtable', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_conditions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_conditions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_additional') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_additional', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_professional_license_boards') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_professional_license_boards', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'search_professionals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', N'search_professionals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_condition') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_condition', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'create_inspection_condition_approvals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'create_inspection_condition_approvals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'schedule_inspection') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'schedule_inspection', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'reschedule_inspection') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'reschedule_inspection', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklists') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklists', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_conditions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_conditions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'delete_inspection_conditions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'delete_inspection_conditions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_document_categories') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_document_categories', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_settings_address_street_directions') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_settings_address_street_directions', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'search_records') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'search_records', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054' AND [ScopeName] = N'get_settings_drilldown') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_drilldown', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'create_contact_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'create_contact_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_vote') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_vote', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_contact_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_contact_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_user_comment') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_user_comment', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_contacts') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_contacts', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_inspection_statuses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_inspection_statuses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_condition_approvals_standard') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'get_condition_approvals_standard', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056' AND [ScopeName] = N'create_payments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056', N'create_payments', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'6E09C6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_my_workflow_tasks') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'6E09C6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_my_workflow_tasks', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_record_fees') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_fees', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'delete_inspection_documents') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'delete_inspection_documents', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_customtable') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_customtable', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_fees') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_fees', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_professionals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_professionals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_settings_condition_approval_priorities') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'get_settings_condition_approval_priorities', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'ADF9D0CA-7CCA-491F-94C1-4019D731B477' AND [ScopeName] = N'get_agency') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'ADF9D0CA-7CCA-491F-94C1-4019D731B477', N'get_agency', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_user_comments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_user_comments', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_customtables') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_customtables', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_condition_approvals') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_condition_approvals', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_inspection_checklists') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_inspection_checklists', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'7E7B200C-5A80-455B-9EE5-719DD8158B6E' AND [ScopeName] = N'get_settings_address_states') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E7B200C-5A80-455B-9EE5-719DD8158B6E', N'get_settings_address_states', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'get_settings_contact_types') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'get_settings_contact_types', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'get_settings_contact_preferredChannels') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'get_settings_contact_preferredChannels', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_contact_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_contact_addresses', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'create_inspection_related') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'create_inspection_related', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_documents') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_documents', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_checklist_item_histories') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_checklist_item_histories', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'update_record_owner') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_owner', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD' AND [ScopeName] = N'get_parcels') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E17EA0C-DF5B-4415-AC3A-AC62DEB6BFCD', N'get_parcels', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_comments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_comments', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6' AND [ScopeName] = N'get_professional_records') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_professional_records', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_settings_inspection_checklist') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_settings_inspection_checklist', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'delete_record_contacts') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'delete_record_contacts', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'1607A807-07C0-43FF-A914-F840EF2580A7' AND [ScopeName] = N'get_contact') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'get_contact', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_record_inspections') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_inspections', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'update_inspection_checklist_items') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'update_inspection_checklist_items', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'E4012277-3AF1-4A36-9114-EAD669601B1B' AND [ScopeName] = N'get_owner') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'E4012277-3AF1-4A36-9114-EAD669601B1B', N'get_owner', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'create_partial_record') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_partial_record', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054' AND [ScopeName] = N'get_settings_priorities') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_priorities', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'update_inspection_condition_approval') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'update_inspection_condition_approval', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'update_inspection_checklist_item_customtables') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'update_inspection_checklist_item_customtables', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'E809C667-59D5-4762-8D7D-785FB75EA67C' AND [ScopeName] = N'get_settings_report_definition') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'E809C667-59D5-4762-8D7D-785FB75EA67C', N'get_settings_report_definition', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'90F34533-9753-4802-8553-4D239CD1336C' AND [ScopeName] = N'get_inspection_available_dates') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'90F34533-9753-4802-8553-4D239CD1336C', N'get_inspection_available_dates', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA35' AND [ScopeName] = N'create_record_fees') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'create_record_fees', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA36' AND [ScopeName] = N'get_record_payment') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_payment', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA37' AND [ScopeName] = N'get_record_payments') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_payments', N'System', getdate(), NULL, NULL) 
END








---- Migration
UPDATE Scope2Groups set groupId='ADF9D0CA-7CCA-491F-94C1-4019D731B477'
where ScopeName='search_agencies_by_geo'
DELETE ScopeGroups where name='agency_locator'