
-- 1. update private api property
update resources set apiattribute=1,isproxy=1,isaagovxmlapi=1 where api like '%a311%' or api like '%civichero%' or api like '%/inspectorapp%'

-- 2. update v4 api as proxy
update resources set isproxy=1, isaagovxmlapi=0 where api like '/v4/%'

-- 3. v4 cloud own api, no need to be proxy
update resources set isproxy=0,isaagovxmlapi=0 where 
(api='/v4/appdata/{container}/{blobname}' and Httpverb='GET') or 
(api='/v4/appdata/{container}/{blobname}' and Httpverb='PUT') or 
(api='/v4/appdata/{container}/{blobname}' and Httpverb='DELETE') or 
(api='/v4/appsettings' and Httpverb='GET') or 
(api='/v4/agencies/{name}' and Httpverb='GET') or 
(api='/v4/agencies/{name}/logo' and Httpverb='GET') or 
(api='/v4/civicid/profile' and Httpverb='GET') or 
(api='/v4/civicid/accounts' and Httpverb='GET') or 
(api='/v4/agencies' and Httpverb='GET') or 
(api='/v4/agencies/{name}/environments' and Httpverb='GET') or
(api='/v4/civicid/accounts/{id}' and Httpverb='GET')

-- 3.1 v4 api implementation thur govxml
update resources set isaagovxmlapi=1 where 
(api='/v4/records/{recordId}/usercomments' and Httpverb='POST') or
(api='/v4/records/{recordId}/usercomments' and Httpverb='GET') or
(api='/v4/records/{recordId}/votes' and Httpverb='POST') or
(api='/v4/records/{recordId}/votes' and Httpverb='GET') or
(api='/v4/records/{recordId}/votes/summary' and Httpverb='GET') or
(api='/v4/search/agencies' and Httpverb='POST') or
(api='/v4/documents/{documentId}/thumbnail' and Httpverb='GET') or
(api='/v4/settings/comments' and Httpverb='GET') or
(api='/v4/settings/comments/groups' and Httpverb='GET') or
(api='/v4/search/records/location' and Httpverb='POST')

-- 4. set is as private api
update resources set apiattribute=1 where api='/v4/records/{recordId}/folders' and httpverb='GET'
-- 5. set is as public api
update resources set apiattribute=0 where api='/v4/records/{recordId}/fees' and httpverb='POST'

-- 6. update v3 api as proxy
update resources set isproxy=1, isaagovxmlapi=1 where api like '/v3/%'

-- 7. v3 cloud own api, no need to be proxy
update resources set isproxy=0,isaagovxmlapi=0 where (api='/v3/appdata/{container}/{blobname}' and Httpverb='GET') or 
(api='/v3/appdata/{container}/{blobname}' and Httpverb='PUT') or 
(api='/v3/appdata/{container}/{blobname}' and Httpverb='DELETE') or 
(api='/v3/gissettings' and Httpverb='GET') or 
(api='/v3/geo/geocode/reverse' and Httpverb='GET') or 
(api='/v3/geo/search/agencies' and Httpverb='POST') or 
(api='/v3/appsettings' and Httpverb='GET') or 
(api='/v3/gisserviceapp/service' and Httpverb='GET') or 
(api='/v3/agencies/{name}/logo' and Httpverb='GET') or 
(api='/v3/users/me' and Httpverb='GET') or 
(api='/v3/geo/geocode/geocodeaddresses' and Httpverb='POST') or 
(api='/v3/agencies/{name}' and Httpverb='GET') or 
(api ='/v3/async/result' or  api ='/v4/async/result')

-- 8. script/emse api
update resources set apiattribute=1,isproxy=1,isaagovxmlapi=0 where
(api='/v3/scripts/{id}' and Httpverb='POST') or
(api='/v4/scripts/{id}' and Httpverb='POST')

update resources set authenticationtype=5, apiattribute=1 where (api ='/v3/async/result' or  api ='/v4/async/result')