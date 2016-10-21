-- set common labels like lang, fields, value, text, 



UPDATE api_object_fields
SET label_id = 'api.common.responseStatus', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id, o.name
from api_object_fields tf
join api_objects o on tf.object_or_param_id = o.id
where tf.name='status' and o.name='root'


-- lang, fields are in URL parameters
UPDATE api_object_fields
SET label_id = 'api.common.i18n.lang', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'lang'

UPDATE api_object_fields
SET label_id = 'api.common.fields', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'fields'

UPDATE api_object_fields
SET label_id = 'api.common.limit', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'limit'

UPDATE api_object_fields
SET label_id = 'api.common.offset', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'offset'


UPDATE api_object_fields
SET label_id = 'api.common.id', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'id'

UPDATE api_object_fields
SET label_id = 'api.common.ids', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'ids'

UPDATE api_object_fields
SET label_id = 'api.common.recordId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'recordId'

UPDATE api_object_fields
SET label_id = 'api.common.inspectionId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'inspectionId'


UPDATE api_object_fields
SET label_id = 'api.common.addressId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'addressId'

UPDATE api_object_fields
SET label_id = 'api.common.parcelId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'parcelId'

UPDATE api_object_fields
SET label_id = 'api.common.ownerId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'ownerId'


UPDATE api_object_fields
SET label_id = 'api.common.contactId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'contactId'

UPDATE api_object_fields
SET label_id = 'api.common.professionalId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'professionalId'


UPDATE api_object_fields
SET label_id = 'api.common.documentId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'documentId'

UPDATE api_object_fields
SET label_id = 'api.common.commentId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'commentId'


UPDATE api_object_fields
SET label_id = 'api.common.checklistId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'checklistId'

UPDATE api_object_fields
SET label_id = 'api.common.checklistItemId', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id
from api_object_fields tf
-- join api_parameters p on tf.object_or_param_id = p.id
where tf.name = 'checklistItemId'


-- value & text are in objects

UPDATE api_object_fields
SET label_id = 'api.common.result', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id, o.name
from api_object_fields tf
join api_objects o on tf.object_or_param_id = o.id
where tf.name='result' and o.name='root'

UPDATE api_object_fields
SET label_id = 'api.common.id', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id, o.name
from api_object_fields tf
join api_objects o on tf.object_or_param_id = o.id
where tf.name='id'

UPDATE api_object_fields
SET label_id = 'api.common.serviceProviderCode', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id, o.name
from api_object_fields tf
join api_objects o on tf.object_or_param_id = o.id
where tf.name='serviceProviderCode'

UPDATE api_object_fields
SET label_id = 'api.common.i18n.value', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id, o.name
from api_object_fields tf
join api_objects o on tf.object_or_param_id = o.id
where tf.name='value'

UPDATE api_object_fields
SET label_id = 'api.common.i18n.text', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id, o.name
from api_object_fields tf
join api_objects o on tf.object_or_param_id = o.id
where tf.name='text'

UPDATE api_object_fields
SET label_id = 'cap.capID.trackingID.label', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id, o.name
from api_object_fields tf
-- join api_objects o on tf.object_or_param_id = o.id
where tf.name='trackingId'

UPDATE api_object_fields
SET label_id = 'cap.capdetail.altid.label', last_updated_by='API_DOC_SQL', last_updated_date=getDate()
-- select tf.object_or_param_id, tf.id, tf.name, tf.label_id, o.name
from api_object_fields tf
-- join api_objects o on tf.object_or_param_id = o.id
where tf.name='customId'
