IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'get_settings_time_accounting_types')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_time_accounting_types', N'System', getdate(), NULL, NULL) 
END
IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [ScopeName] = N'get_settings_time_accounting_groups')
BEGIN
INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3054', N'get_settings_time_accounting_groups', N'System', getdate(), NULL, NULL) 
END

