
if not exists(select * from [dbo].[ScopeGroups] where Id ='CF0CB476-B950-4EEC-8709-335791ECE53A' or Name='gis_objects')
begin
	insert [dbo].[ScopeGroups](Id, Name, Description, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('CF0CB476-B950-4EEC-8709-335791ECE53A', 'gis_objects', NULL, 'admin', 'Jan 13 2015  3:27AM', 'admin', 'Jan 13 2015  3:27AM')
end 

if not exists(select * from [dbo].[ScopeGroups] where Id ='7CA61FE8-F27E-4BC5-AC2B-387746A246B6' or Name='subscriptions')
begin
	insert [dbo].[ScopeGroups](Id, Name, Description, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('7CA61FE8-F27E-4BC5-AC2B-387746A246B6', 'subscriptions', NULL, 'admin', 'Feb  9 2015  6:52AM', NULL, NULL)
end 

