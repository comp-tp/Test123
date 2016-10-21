IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057', N'get_settings_fees', N'System', getdate(), NULL, NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057', N'get_transaction', N'System', getdate(), NULL, NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057', N'create_payments', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'get_civicid_profile')
BEGIN
update scope2groups set scopename='get_civicid_profile'
where scopename='get_my_civicid_profile'

INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_linked_accounts', N'System', getdate(), NULL, NULL) 
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6', N'get_account_profile', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'get_contacts')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'1607A807-07C0-43FF-A914-F840EF2580A7', N'get_contacts', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'get_settings_record_expierationStatuses')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_settings_record_expierationStatuses', N'System', getdate(), NULL, NULL) 
END