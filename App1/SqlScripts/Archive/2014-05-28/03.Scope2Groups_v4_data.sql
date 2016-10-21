IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'get_record_contact_customforms_meta')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_contact_customforms_meta', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'get_record_contact_customforms')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_record_contact_customforms', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'update_record_contact_customforms')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'update_record_contact_customforms', N'System', getdate(), NULL, NULL) 
END

IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'get_settings_contact_type_customforms')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_contact_type_customforms', N'System', getdate(), NULL, NULL) 
END