-- populate xxx fields from /v4/xxx API (Ex. /v4/addresses) to all API (Ex. /v4/contacts/{id}/addresses)

select api.api, o.name, tf.name, tf.id, *
from api_object_fields tf
join api_objects o on tf.object_or_param_id = o.id
join api_parameters p on o.parameter_id=p.id
join API_DOC_API_DESCRIPTIONS api on p.resource_Id=api.resource_Id
where object_or_param_id in (
'c86f05ce-a15f-4c65-917b-a825a88bb082',
'662eaf6e-08ec-41d3-863a-9704a4aeb036',
'd5d9eacc-067b-4e37-976c-28118bb15c7d',
'5302e4be-2270-482a-a192-c4a183fc6f44',
'bc30125c-9779-476c-beda-b1b9bc49b314',
'6d19f550-74d2-4b9a-b160-31ea4cce238a',
'82076e7b-092e-498c-b7de-153746bc8690',
'504d4c65-7dce-4415-85c4-2fdbec65c1d7',
'd56bbb60-4158-4ca5-a7f8-f3357266f124',
'868047b2-674d-4b6e-93d0-da33692e6d3d',
'868047b2-674d-4b6e-93d0-da33692e6d3d'
)
and label_id is null


-- GET /v4/addresses
exec API_DOC_FIELD_LABEL_POPULATE 'c86f05ce-a15f-4c65-917b-a825a88bb082', 'address', 'addresses'

-- GET /v4/parcels
exec API_DOC_FIELD_LABEL_POPULATE '662eaf6e-08ec-41d3-863a-9704a4aeb036', 'parcel', 'parcels'

-- GET /v4/owners
exec API_DOC_FIELD_LABEL_POPULATE 'd5d9eacc-067b-4e37-976c-28118bb15c7d', 'owner', 'owners'

-- POST /v4/contacts
exec API_DOC_FIELD_LABEL_POPULATE '5302e4be-2270-482a-a192-c4a183fc6f44', 'contact', 'contacts'

-- GET /v4/professionals
exec API_DOC_FIELD_LABEL_POPULATE 'bc30125c-9779-476c-beda-b1b9bc49b314', 'professional', 'professionals'

-- GET /v4/conditions/standard -- API URL to be changed
exec API_DOC_FIELD_LABEL_POPULATE '868047b2-674d-4b6e-93d0-da33692e6d3d', 'condition', 'conditions'
exec API_DOC_FIELD_LABEL_POPULATE '868047b2-674d-4b6e-93d0-da33692e6d3d', 'conditionApproval', 'conditionApprovals'

-- GET /v4/inspections
exec API_DOC_FIELD_LABEL_POPULATE '6d19f550-74d2-4b9a-b160-31ea4cce238a', 'inspection', 'inspections'

-- GET /v4/inspectors
exec API_DOC_FIELD_LABEL_POPULATE '55a299eb-2b05-4456-a278-0ebb60004ea8', 'inspector', 'inspectors'

-- GET /v4/records/{recordIds}
exec API_DOC_FIELD_LABEL_POPULATE '82076e7b-092e-498c-b7de-153746bc8690', 'record', 'records'

-- GET /v4/records/{recordId}/fees
exec API_DOC_FIELD_LABEL_POPULATE 'e5204da9-8303-4e0b-b373-a451b050b95f', 'fee', 'fees'

-- GET /v4/documents/{documentIds}
exec API_DOC_FIELD_LABEL_POPULATE '504d4c65-7dce-4415-85c4-2fdbec65c1d7', 'document', 'documents'

-- GET /v4/records/{recordId}/workflowTasks/{id}
exec API_DOC_FIELD_LABEL_POPULATE 'd56bbb60-4158-4ca5-a7f8-f3357266f124', 'workflowTask', 'workflowTasks'
