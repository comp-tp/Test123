 Insert into [dbo].[Scope2Groups] ([ID] ,[GroupID] ,[ScopeName] ,[CreatedBy] ,[CreatedDate] ,[LastUpdatedBy] ,[LastUpdatedDate]) 
  VALUES ('A78FDCB2-CE68-41EC-996D-2FF541EBCBE9',(Select ID from [dbo].[ScopeGroups] where Name='records'), 'get_record_contact_customtable_meta', 'System', '2016-07-14 17:19:43', NULL, NULL);
  
  Insert into [dbo].[Scope2Groups] ([ID] ,[GroupID] ,[ScopeName] ,[CreatedBy] ,[CreatedDate] ,[LastUpdatedBy] ,[LastUpdatedDate]) 
  VALUES ('0DAA64EC-9815-4B88-B758-5E2D402B7AA7',(Select ID from [dbo].[ScopeGroups] where Name='records'), 'update_record_contact_customtables', 'System', '2016-07-14 17:19:29', NULL, NULL);
  
  Insert into [dbo].[Scope2Groups] ([ID] ,[GroupID] ,[ScopeName] ,[CreatedBy] ,[CreatedDate] ,[LastUpdatedBy] ,[LastUpdatedDate]) 
  VALUES ('FE0D4EC0-58AE-4F55-97C2-AB5F227CEDA1',(Select ID from [dbo].[ScopeGroups] where Name='records'), 'get_record_contact_customtable_meta', 'System', '2016-07-14 17:19:14', NULL, NULL);
  
  Insert into [dbo].[Scope2Groups] ([ID] ,[GroupID] ,[ScopeName] ,[CreatedBy] ,[CreatedDate] ,[LastUpdatedBy] ,[LastUpdatedDate]) 
  VALUES ('9D5C6E5A-EBEA-4C8E-8714-AE63279CF77E',(Select ID from [dbo].[ScopeGroups] where Name='contacts'), 'get_settings_contact_type_customtables', 'System', '2016-07-14 17:19:54', NULL, NULL);
  
  Insert into [dbo].[Scope2Groups] ([ID] ,[GroupID] ,[ScopeName] ,[CreatedBy] ,[CreatedDate] ,[LastUpdatedBy] ,[LastUpdatedDate]) 
  VALUES ('EE389097-A865-4F21-9067-FF69EFC63B30',(Select ID from [dbo].[ScopeGroups] where Name='records'), 'get_record_contact_customtables', 'System', '2016-07-14 17:18:55', NULL, NULL);
