--update existing uri and httpverb
update [dbo].[API_DOC_API_DESCRIPTIONS]  set api=r.api,http_verb=r.httpverb,title=displayname, last_updated_date=getdate(),last_updated_by='updatedBySync'
from [dbo].[API_DOC_API_DESCRIPTIONS] a
inner join
    resources r
on a.resource_id = r.id;

-- insert new api
insert into dbo.API_DOC_API_DESCRIPTIONS(id,resource_id,api,http_VERb,title,[description],created_by,created_date)
select newid(), id,api,httpverb,displayname,[description],'importbySql',getdate() 
from resources 
where (api like '%/v4/%' or  api = '/oauth2/token' or api like '%batch%')
and id not in (select resource_id from API_DOC_API_DESCRIPTIONS)
and (api!='/v4/search/dataquery' and api!='/v4/scripts/{id}')
;
