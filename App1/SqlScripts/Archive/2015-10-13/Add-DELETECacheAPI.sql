SELECT newid()

if not exists(select * from [dbo].[Resources] where Id ='9C3B8A04-F167-440F-959A-84C3D1AD9F49' or ( HttpVerb='DELETE' and API='/apis/v3/caches/{cahceType}/{cacheKey}'))
begin
	insert [dbo].[Resources](Id, API, HttpVerb, RelativeUriTemplateFull, Name, DisplayName, [Description], AuthenticationType, APIAttribute, 
	
	CreatedBy, CreatedDate, LastUpdatedBy, LastUpdatedDate, 
	
	ProxyAPI, Applicability, MethodNickName, SupportedAAVersions, SupportedAPIVersions, ResourceGroupName, FIDDescription, IsProxy, IsAAGovxmlAPI)
	values('9C3B8A04-F167-440F-959A-84C3D1AD9F49', '/apis/v3/caches/cahceType/cacheKey', 'DELETE', '/apis/v3/caches/{cahceType}/{cacheKey}', 
	
	'remove_cache_key_from_provider', 
	'Remove Cache Key from Provider Redis, InMemory, all', 
	NULL, 
	3, 
	0, 
	
	'pshetty@accela.com', 'Jun 16 2015  6:39AM', 'pshetty@accela.com', 'Jun 16 2015  6:32AM', 
	
	NULL, 
	NULL, 
	'DELETECACHE', 
	NULL, 
	NULL, 
	NULL, 
	NULL, 
	0, 
	0)
end 