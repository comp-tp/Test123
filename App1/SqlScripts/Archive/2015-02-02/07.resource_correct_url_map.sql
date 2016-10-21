update resources 
set api ='/v4/inspections/{inspectionId}/related' , 
relativeuriTemplateFull='/v4/inspections/{inspectionId}/related?lang={lang}&relationship={relationship}&fields={fields}'
where id ='C4012345-AAAA-BBBB-CCCC-123456700136'

update resources 
set api ='/v4/inspections/{inspectionId}/related' , 
relativeuriTemplateFull='/v4/inspections/{inspectionId}/related?lang={lang}'
where id ='C4012345-AAAA-BBBB-CCCC-123456700137'

update resources 
set api ='/v4/inspections/{inspectionId}/related/{childInspectionIds}' , 
relativeuriTemplateFull='/v4/inspections/{inspectionId}/related/{childInspectionIds}?lang={lang}'
where id ='C4012345-AAAA-BBBB-CCCC-123456700138'

update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms' where  id ='C4012345-AAAA-BBBB-CCCC-123456700173'
update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms' where  id ='C4012345-AAAA-BBBB-CCCC-123456700174'
update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/meta' where  id ='C4012345-AAAA-BBBB-CCCC-123456700175'
update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/{formId}/meta' where id ='C4012345-AAAA-BBBB-CCCC-123456700176'
update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/meta' where  id ='C4012345-AAAA-BBBB-CCCC-123456700177'
update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}/meta' where   id ='C4012345-AAAA-BBBB-CCCC-123456700178'
update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables' where  id ='C4012345-AAAA-BBBB-CCCC-123456700179'
update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables' where  id ='C4012345-AAAA-BBBB-CCCC-123456700180'
update resources set api ='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}' where id ='C4012345-AAAA-BBBB-CCCC-123456700181'