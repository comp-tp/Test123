IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE  [Id] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057') 
BEGIN
    INSERT [dbo].[ScopeGroups] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3057', N'payments', N'', N'System', getdate(), NULL, NULL) 
END
