
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE type=N'F' and referenced_object_id = OBJECT_ID(N'[dbo].[ScopeGroups]') AND parent_object_id = OBJECT_ID(N'[dbo].[Scope2Groups]'))
BEGIN
	ALTER TABLE Scope2Groups
		ADD FOREIGN KEY (GroupId)
		REFERENCES ScopeGroups(Id)
END
