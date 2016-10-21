-- populate address fields to all API

-- 1. get fields from /v4/addrsses API 
select *
from api_object_fields
where object_or_param_id='c86f05ce-a15f-4c65-917b-a825a88bb082'

-- 2. get fields in address model in APIs
select object_or_param_id, id, name, label_id
from api_object_fields
where object_or_param_id in (
	select o.id
	from api_objects o
	join api_parameters p on o.parameter_id=p.id
	join API_DOC_API_DESCRIPTIONS ad on p.resource_id=ad.resource_id
	where o.parameter_id is not null and o.parameter_id!=''
	 and ( o.name like '%address' or  o.name like '%addresses'
	  or ad.api like '%/address' or ad.api like '%/addresses'
	  ) 
)
order by object_or_param_id, name

-- 3. populate field values
UPDATE api_object_fields
SET label_id = sf.label_id
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
FROM
    api_object_fields tf
JOIN
    (select name, label_id, object_or_param_id
	from api_object_fields
    where object_or_param_id='c86f05ce-a15f-4c65-917b-a825a88bb082'
	and label_id is not null
	) sf
	on tf.name=sf.name
where 
tf.object_or_param_id!=sf.object_or_param_id
and tf.object_or_param_id in (
	select o.id
	from api_objects o
	join api_parameters p on o.parameter_id=p.id
	join API_DOC_API_DESCRIPTIONS ad on p.resource_id=ad.resource_id
	where ( o.name like '%address' or  o.name like '%addresses'
	  or ad.api like '%/address' or ad.api like '%/addresses'
	  ) 
) 
-- order by object_or_param_id, name


select name, count(id), count(label_id)
from api_object_fields
where object_or_param_id in (
	select o.id
	from api_objects o
	join api_parameters p on o.parameter_id=p.id
	join API_DOC_API_DESCRIPTIONS ad on p.resource_id=ad.resource_id
	where o.parameter_id is not null and o.parameter_id!=''
	 and ( o.name like '%address' or  o.name like '%addresses'
	  or ad.api like '%/address' or ad.api like '%/addresses'
	  ) 
)
group by name
order by name


-- all API JSON with address model
select ad.api, o.id, o.name, p.id, p.parameter_name
from api_objects o
join api_parameters p on o.parameter_id=p.id
join API_DOC_API_DESCRIPTIONS ad on p.resource_id=ad.resource_id
where o.parameter_id is not null and o.parameter_id!=''
 and ( o.name like '%address' or  o.name like '%addresses'
  or ad.api like '%/address' or ad.api like '%/addresses'
  ) 
order by api, o.name



-- remove useless fields
delete from api_object_fields
where object_or_param_id not in 
(
	select id from api_objects
	union
	select id from api_parameters
)

-- remove useless API doc
delete from API_DOC_API_DESCRIPTIONS
where resource_id not in
(select id from resources)