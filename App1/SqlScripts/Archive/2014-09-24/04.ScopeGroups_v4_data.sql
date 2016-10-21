IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE [Name] = 'shoppingcart') 
 BEGIN 
INSERT INTO [dbo].[ScopeGroups] ([ID],[Name],[Description],[CreatedBy],[CreatedDate],[LastUpdatedBy],[LastUpdatedDate]) VALUES ('7A0B2774-96E8-490F-8F76-98580BB1ED39' ,'shoppingcart',null,'System',getdate(),'System',getdate())
END

IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE [Name] = 'announcements') 
 BEGIN 
INSERT INTO [dbo].[ScopeGroups] ([ID],[Name],[Description],[CreatedBy],[CreatedDate],[LastUpdatedBy],[LastUpdatedDate]) VALUES ('9B1E9235-1EF8-46CF-AD57-C6521E61FA0E','announcements',null,'System',getdate(),'System',getdate())
END

IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE [Name] = 'parts') 
 BEGIN 
INSERT INTO [dbo].[ScopeGroups] ([ID],[Name],[Description],[CreatedBy],[CreatedDate],[LastUpdatedBy],[LastUpdatedDate]) VALUES ('9AFAC561-FFAD-40C4-B128-C6169DB58FFD','parts',null,'System',getdate(),'System',getdate())
END

IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE [Name] = 'costs') 
 BEGIN 
INSERT INTO [dbo].[ScopeGroups] ([ID],[Name],[Description],[CreatedBy],[CreatedDate],[LastUpdatedBy],[LastUpdatedDate]) VALUES ('39934F23-DDEA-4D9E-A6CD-1A703BBDFE3E','costs',null,'System',getdate(),'System',getdate())
END

------- create_mileage ---
IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE [Name] = 'mileage') 
 BEGIN 
INSERT INTO [dbo].[ScopeGroups] ([ID],[Name],[Description],[CreatedBy],[CreatedDate],[LastUpdatedBy],[LastUpdatedDate]) VALUES ('55E54602-4577-4D96-A529-C145DF845DFF','mileage',null,'System',getdate(),'System',getdate())
END

IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE [Name] = 'timeaccounting') 
BEGIN 
INSERT INTO [dbo].[ScopeGroups] ([ID],[Name],[Description],[CreatedBy],[CreatedDate],[LastUpdatedBy],[LastUpdatedDate]) VALUES ('0407EF3B-D3BF-48A8-8C1A-2EF8A989121D','timeaccounting',null,'System',getdate(),'System',getdate())
END

