IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'BAF4F245-0FAC-4418-B529-18358AA1EA34' AND [ScopeName] = N'get_records_location')
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'BAF4F245-0FAC-4418-B529-18358AA1EA34', N'get_records_location', N'System', getdate(), NULL, NULL)
END
