IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'4912F2EE-2C19-4EBB-A139-7D47F1378C94' AND [ScopeName] = N'get_document_thumbnail')
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate])
    VALUES (newid(), N'4912F2EE-2C19-4EBB-A139-7D47F1378C94', N'get_document_thumbnail', N'System', getdate(), NULL, NULL)
END