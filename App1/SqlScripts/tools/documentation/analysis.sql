-- total count of fields
select count(*)
from api_object_fields

-- total fields labeled
select count(*)
from api_object_fields
where label_id is not null

-- fields not labeled
select name, count(*)
from api_object_fields
where label_id is null
group by name
order by name


select o.name, tf.name, count(*)
from api_object_fields tf
join api_objects o on tf.object_or_param_id = o.id
where label_id is null
--and name like '%Id'
group by o.name, tf.name
order by 3 desc


-- unique field names
select name, count(*)
from api_object_fields
group by name
order by 1, 2

select name, count(*)
from api_objects
group by name
order by 1, 2

select top 10 SUBSTRING(name, CHARINDEX('.', name)+1, LEN(name)-CHARINDEX('.', name))
from api_objects
where CHARINDEX('.', name)>0

select top 10 name
from api_objects
where CHARINDEX('.', name)=0



-- object not root and parent object not exist -- invalid
select * from api_objects
where name!='root' and parent_object_id not in 
(select oroot.id
from api_objects oroot
)

-- object not root and parent object is null -- invalid
select * from api_objects
where name!='root' and parent_object_id is null

-- duplicated field -- invalid
select object_or_param_id, name, count(id)
from api_object_fields
group by object_or_param_id, name
having count(id)>1

-- root w/o parameter? -- invalid?
select * from api_objects
where name='root' and parameter_id not in (
select p.id
from api_parameters p)


-- root w/o parameter? -- invalid object?
select * from api_objects
where parent_object_id=parameter_id and parameter_id not in (
select p.id
from api_parameters p)


-- fields in invalid object?
select * from
api_object_fields
where object_or_param_id in (
select o.id from api_objects o
where parent_object_id=parameter_id and parameter_id not in (
select p.id
from api_parameters p)
)