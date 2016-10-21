
-------- missing API document: expect empty result; need to provide document for the API
select * from resources
where id not in
(select resource_id from API_DOC_API_DESCRIPTIONS)
and api like '/v4/%' and api!='/v4/search/dataquery'

-------- useless API document: expect empty result; need to delete if resource_id is not typo and all API has document
select * from API_DOC_API_DESCRIPTIONS
where resource_id not in
(select r.id from resources r)

-------- useless parameters: expect empty result
select * from api_parameters
where resource_id not in
(select a.resource_id from API_DOC_API_DESCRIPTIONS a)

-------- useless fields: expect empty result
select * from api_objects
where parent_object_id is null and parameter_id not in
(select p.id from api_parameters p)

-------- useless fields: expect empty result
select * from api_object_fields
where object_or_param_id not in
(select p.id from api_parameters p)
and 
object_or_param_id not in
(select o.id from api_objects o)
