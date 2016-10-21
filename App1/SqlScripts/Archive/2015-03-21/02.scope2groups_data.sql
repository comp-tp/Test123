if not exists(select * from [dbo].[Scope2Groups] where Id ='FAA7B025-826D-43BA-B59B-97A935332E9E' or ( ScopeName='get_contact_conditions' and GroupId='1607A807-07C0-43FF-A914-F840EF2580A7'))
begin
	insert [dbo].[Scope2Groups](Id, GroupId, ScopeName, CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate)
	values('FAA7B025-826D-43BA-B59B-97A935332E9E', '1607A807-07C0-43FF-A914-F840EF2580A7', 'get_contact_conditions', 'kevintang', 'Mar 11 2015  2:19AM', NULL, NULL)
end 

