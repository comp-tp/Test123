
if not exists(select * from [dbo].[ScopeGroups] where Id ='9CF3BF93-FDAA-42C4-8AC7-64F12C07DD54' or Name='trustaccounts')
begin
	insert [dbo].[ScopeGroups](Id, Name, Description, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('9CF3BF93-FDAA-42C4-8AC7-64F12C07DD54', 'trustaccounts', NULL, 'admin', 'Mar 12 2015  6:48AM', NULL, NULL)
end 
