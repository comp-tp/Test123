--invoices --
IF NOT EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE [Name] = 'invoices') 
 BEGIN 
INSERT INTO [dbo].[ScopeGroups] ([ID],[Name],[Description],[CreatedBy],[CreatedDate],[LastUpdatedBy],[LastUpdatedDate]) VALUES ('BE701FD3-1F9A-4B26-83C8-4EAAD11407C6' ,'invoices',null,'System',getdate(),'System',getdate())
END
--invoices end --

--delete cashier  --
IF EXISTS(SELECT * FROM [dbo].[ScopeGroups] WHERE [Name] = 'cashier') 
 BEGIN 
DELETE FROM [dbo].[ScopeGroups] WHERE [Name] = 'cashier'
END
--delete cashier end --
