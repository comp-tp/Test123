IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE  [Id] = N'689DF941-C0F2-4917-BBEE-19A680BC1985') 
BEGIN
    INSERT [dbo].[ScopeGroups] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'689DF941-C0F2-4917-BBEE-19A680BC1985', N'open_data', N'', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE  [Id] = N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6') 
BEGIN
    INSERT [dbo].[ScopeGroups] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'3E09D6E1-D3F7-43A5-B0E1-D3837789ADE6', N'conditions', N'', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE  [Id] = N'6E09C6E2-D3F7-43A5-B0E1-D3837789ADE6') 
BEGIN
    INSERT [dbo].[ScopeGroups] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'6E09C6E2-D3F7-43A5-B0E1-D3837789ADE6', N'workflows', N'', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE  [Id] = N'7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6') 
BEGIN
    INSERT [dbo].[ScopeGroups] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'7E09C6E2-D3F7-43A5-B0E1-D3837789ADE6', N'civicid', N'', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE  [Id] = N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6') 
BEGIN
    INSERT [dbo].[ScopeGroups] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'5E09D6E2-D3F7-43A5-B0E1-D3837789ADE6', N'professionals', N'', N'System', getdate(), NULL, NULL) 
END
 
IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE  [Id] = N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056') 
BEGIN
    INSERT [dbo].[ScopeGroups] ([Id], [Name], [Description], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (N'3649EBCE-C5C9-4C79-BD92-E37A0C9C3056', N'cashier', N'', N'System', getdate(), NULL, NULL) 
END
 
