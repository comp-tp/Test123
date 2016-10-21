IF NOT EXISTS(SELECT * FROM [dbo].[Scope2Groups] WHERE  [GroupID] = N'E3A13EAC-EAC9-42C0-A86F-EA59F79750E7' AND [ScopeName] = N'geocode_addresses') 
BEGIN
    INSERT [dbo].[Scope2Groups] ([Id], [GroupID], [ScopeName], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate]) VALUES (newid(), N'E3A13EAC-EAC9-42C0-A86F-EA59F79750E7', N'geocode_addresses', N'System', getdate(), NULL, NULL) 
END
 