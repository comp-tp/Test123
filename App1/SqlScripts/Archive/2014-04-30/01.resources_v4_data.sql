-- Record1:  Update : '/apis/v1/records/{recordId}/documentCategories?lang={lang}'  to '/apis/v4/records/{recordId}/documentCategories?lang={lang}'--
UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/documentCategories?lang={lang}' WHERE ID ='C4012345-AAAA-BBBB-CCCC-123456700033' AND API = '/v4/records/{recordId}/documentCategories'


-- Record2:  Update : '/apis/v1/records/{recordId}/fees?lang={lang}&fields={fields}&status={status}'  to '/apis/v4/records/{recordId}/fees?lang={lang}&fields={fields}&status={status}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/fees?lang={lang}&fields={fields}&status={status}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700039'    AND           API = '/v4/records/{recordId}/fees'


-- Record3:  Update : '/apis/v1/inspector?lang={lang}&departmentCode={department}'  to '/apis/v4/inspector?lang={lang}&departmentCode={department}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspector?lang={lang}&departmentCode={department}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700040'    AND           API = '/v4/inspectors'


-- Record4:  Update : '/apis/v1/inspector/{id}?lang={lang}'  to '/apis/v4/inspector/{id}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspector/{id}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700041'    AND           API = '/v4/inspectors/{id}'


-- Record5:  Update : '/apis/v1/reports/{reportId}?lang={lang}&module={module}'  to '/apis/v4/reports/{reportId}?lang={lang}&module={module}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/reports/{reportId}?lang={lang}&module={module}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700042'    AND           API = '/v4/reports/{reportId}'


-- Record6:  Update : '/apis/v1/reports/categories?lang={lang}&fields={fields}'  to '/apis/v4/reports/categories?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/reports/categories?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700043'    AND           API = '/v4/settings/reports/categories'


-- Record7:  Update : '/apis/v1/reports/describe?lang={lang}&fields={fields}&category={category}&module={module}'  to '/apis/v4/reports/describe?lang={lang}&fields={fields}&category={category}&module={module}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/reports/describe?lang={lang}&fields={fields}&category={category}&module={module}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700044'    AND           API = '/v4/settings/reports/definitions'


-- Record8:  Update : '/apis/v1/reports/describe/{reportId}?lang={lang}&fields={fields}'  to '/apis/v4/reports/describe/{reportId}?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/reports/describe/{reportId}?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700045'    AND           API = '/v4/settings/reports/definitions/{reportId}'


-- Record9:  Update : '/apis/v1/search/global?lang={lang}&query={query}&type={type}&modules={modules}&offset={offset}&limit={limit}&sort={sort}&direction={direction}'  to '/apis/v4/search/global?lang={lang}&query={query}&type={type}&modules={modules}&offset={offset}&limit={limit}&sort={sort}&direction={direction}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/search/global?lang={lang}&query={query}&type={type}&modules={modules}&offset={offset}&limit={limit}&sort={sort}&direction={direction}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700058'    AND           API = '/v4/search/global'


-- Record10:  Update : '/apis/v1/documents/{documentId}/download?lang={lang}&password={password}&userId={userId}'  to '/apis/v4/documents/{documentId}/download?lang={lang}&password={password}&userId={userId}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/documents/{documentId}/download?lang={lang}&password={password}&userId={userId}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700065'    AND           API = '/v4/documents/{documentId}/download'


-- Record11:  Update : '/apis/v1/documents/{documentIds}?lang={lang}&fields={fields}'  to '/apis/v4/documents/{documentIds}?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/documents/{documentIds}?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700066'    AND           API = '/v4/documents/{documentIds}'


-- Record12:  Update : '/apis/v1/settings/documents/categories?lang={lang}'  to '/apis/v4/settings/documents/categories?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/settings/documents/categories?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700067'    AND           API = '/v4/settings/documents/categories'


-- Record13:  Update : '/apis/v1/records/{recordId}/documents?group={group}&category={category}&userId={userId}&password={password}&lang={lang}'  to '/apis/v4/records/{recordId}/documents?group={group}&category={category}&userId={userId}&password={password}&lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/documents?group={group}&category={category}&userId={userId}&password={password}&lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700068'    AND           API = '/v4/records/{recordId}/documents'


-- Record14:  Update : '/apis/v1/records/{recordId}/documents?lang={lang}&fields={fields}'  to '/apis/v4/records/{recordId}/documents?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/documents?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700069'    AND           API = '/v4/records/{recordId}/documents'


-- Record15:  Update : '/apis/v1/records/{recordId}/documents/{documentIds}?userId={userId}&password={password}&lang={lang}'  to '/apis/v4/records/{recordId}/documents/{documentIds}?userId={userId}&password={password}&lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/documents/{documentIds}?userId={userId}&password={password}&lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700070'    AND           API = '/v4/records/{recordId}/documents/{documentIds}'


-- Record16:  Update : '/apis/v1/settings/conditions/types?lang={lang}'  to '/apis/v4/settings/conditions/types?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/settings/conditions/types?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700071'    AND           API = '/v4/settings/conditions/types'


-- Record17:  Update : '/apis/v1/settings/conditions/statuses?lang={lang}'  to '/apis/v4/settings/conditions/statuses?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/settings/conditions/statuses?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700072'    AND           API = '/v4/settings/conditions/statuses'


-- Record18:  Update : '/apis/v1/settings/conditions/priorities?lang={lang}'  to '/apis/v4/settings/conditions/priorities?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/settings/conditions/priorities?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700074'    AND           API = '/v4/settings/conditions/priorities'


-- Record19:  Update : '/apis/v1/inspections/{inspectionId}/conditionApprovals?lang={lang}&isNeedNoticeInfo={isNeedNoticeInfo}&effectiveDate={effectiveDate}&expirationDate={expirationDate}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/conditionApprovals?lang={lang}&isNeedNoticeInfo={isNeedNoticeInfo}&effectiveDate={effectiveDate}&expirationDate={expirationDate}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditionApprovals?lang={lang}&isNeedNoticeInfo={isNeedNoticeInfo}&effectiveDate={effectiveDate}&expirationDate={expirationDate}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700075'    AND           API = '/v4/inspections/{inspectionId}/conditionApprovals'


-- Record20:  Update : '/apis/v1/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700076'    AND           API = '/v4/inspections/{inspectionId}/conditionApprovals/{id}'


-- Record21:  Update : '/apis/v1/inspections/{inspectionId}/conditionApprovals?lang={lang}'  to '/apis/v4/inspections/{inspectionId}/conditionApprovals?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditionApprovals?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700077'    AND           API = '/v4/inspections/{inspectionId}/conditionApprovals'


-- Record22:  Update : '/apis/v1/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}'  to '/apis/v4/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700078'    AND           API = '/v4/inspections/{inspectionId}/conditionApprovals/{id}'


-- Record23:  Update : '/apis/v1/inspections/{inspectionId}/conditionApprovals/{ids}?lang={lang}'  to '/apis/v4/inspections/{inspectionId}/conditionApprovals/{ids}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditionApprovals/{ids}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700079'    AND           API = '/v4/inspections/{inspectionId}/conditionApprovals/{ids}'


-- Record24:  Update : '/apis/v1/inspections/{inspectionId}/conditions?lang={lang}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/conditions?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditions?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700080'    AND           API = '/v4/inspections/{inspectionId}/conditions'


-- Record25:  Update : '/apis/v1/inspections/{inspectionId}/conditions/{id}?lang={lang}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/conditions/{id}?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditions/{id}?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700081'    AND           API = '/v4/inspections/{inspectionId}/conditions/{id}'


-- Record26:  Update : '/apis/v1/inspections/{inspectionId}/conditions?lang={lang}'  to '/apis/v4/inspections/{inspectionId}/conditions?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditions?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700082'    AND           API = '/v4/inspections/{inspectionId}/conditions'


-- Record27:  Update : '/apis/v1/inspections/{inspectionId}/conditions/{id}?lang={lang}'  to '/apis/v4/inspections/{inspectionId}/conditions/{id}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditions/{id}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700083'    AND           API = '/v4/inspections/{inspectionId}/conditions/{id}'


-- Record28:  Update : '/apis/v1/inspections/{inspectionId}/conditions/{ids}?lang={lang}'  to '/apis/v4/inspections/{inspectionId}/conditions/{ids}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditions/{ids}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700084'    AND           API = '/v4/inspections/{inspectionId}/conditions/{ids}'


-- Record29:  Update : '/apis/v1/inspections/{inspectionId}/conditions/{id}/histories?lang={lang}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/conditions/{id}/histories?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/conditions/{id}/histories?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700085'    AND           API = '/v4/inspections/{inspectionId}/conditions/{id}/histories'


-- Record30:  Update : '/apis/v1/records/{recordId}/conditionApprovals?lang={lang}'  to '/apis/v4/records/{recordId}/conditionApprovals?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditionApprovals?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700086'    AND           API = '/v4/records/{recordId}/conditionApprovals'


-- Record31:  Update : '/apis/v1/records/{recordId}/conditionApprovals/{ids}?lang={lang}'  to '/apis/v4/records/{recordId}/conditionApprovals/{ids}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditionApprovals/{ids}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700087'    AND           API = '/v4/records/{recordId}/conditionApprovals/{ids}'


-- Record32:  Update : '/apis/v1/records/{recordId}/conditionApprovals?lang={lang}&fields={fields}'  to '/apis/v4/records/{recordId}/conditionApprovals?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditionApprovals?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700088'    AND           API = '/v4/records/{recordId}/conditionApprovals'


-- Record33:  Update : '/apis/v1/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}'  to '/apis/v4/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700089'    AND           API = '/v4/records/{recordId}/conditionApprovals/{id}'


-- Record34:  Update : '/apis/v1/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}'  to '/apis/v4/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700090'    AND           API = '/v4/records/{recordId}/conditionApprovals/{id}'


-- Record35:  Update : '/apis/v1/records/{recordId}/conditions?lang={lang}&fields={fields}'  to '/apis/v4/records/{recordId}/conditions?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditions?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700091'    AND           API = '/v4/records/{recordId}/conditions'


-- Record36:  Update : '/apis/v1/records/{recordId}/conditions/{id}?lang={lang}&fields={fields}'  to '/apis/v4/records/{recordId}/conditions/{id}?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditions/{id}?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700092'    AND           API = '/v4/records/{recordId}/conditions/{id}'


-- Record37:  Update : '/apis/v1/records/{recordId}/conditions?lang={lang}'  to '/apis/v4/records/{recordId}/conditions?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditions?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700093'    AND           API = '/v4/records/{recordId}/conditions'


-- Record38:  Update : '/apis/v1/records/{recordId}/conditions/{id}?lang={lang}'  to '/apis/v4/records/{recordId}/conditions/{id}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditions/{id}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700094'    AND           API = '/v4/records/{recordId}/conditions/{id}'


-- Record39:  Update : '/apis/v1/records/{recordId}/conditions/{ids}?lang={lang}'  to '/apis/v4/records/{recordId}/conditions/{ids}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/records/{recordId}/conditions/{ids}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700095'    AND           API = '/v4/records/{recordId}/conditions/{ids}'


-- Record40:  Update : '/apis/v1/settings/inspections/grades?lang={lang}&fields={fields}&group={group}'  to '/apis/v4/settings/inspections/grades?lang={lang}&fields={fields}&group={group}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/settings/inspections/grades?lang={lang}&fields={fields}&group={group}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700141'    AND           API = '/v4/settings/inspections/grades'


-- Record41:  Update : '/apis/v1/settings/inspections/statuses?lang={lang}&fields={fields}&group={group}'  to '/apis/v4/settings/inspections/statuses?lang={lang}&fields={fields}&group={group}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/settings/inspections/statuses?lang={lang}&fields={fields}&group={group}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700142'    AND           API = '/v4/settings/inspections/statuses'


-- Record42:  Update : '/apis/v1/inspections/{inspectionId}/comments?lang={lang}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/comments?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/comments?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700143'    AND           API = '/v4/inspections/{inspectionId}/comments'


-- Record43:  Update : '/apis/v1/inspections/{inspectionId}/checklists?lang={lang}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/checklists?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/checklists?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700146'    AND           API = '/v4/inspections/{inspectionId}/checklists'


-- Record44:  Update : '/apis/v1/inspections/{inspectionId}/checklists?lang={lang}'  to '/apis/v4/inspections/{inspectionId}/checklists?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/checklists?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700147'    AND           API = '/v4/inspections/{inspectionId}/checklists'


-- Record45:  Update : '/apis/v1/inspections/checklists/{checklistId}/checklistItems?lang={lang}&fields={fields}'  to '/apis/v4/inspections/checklists/{checklistId}/checklistItems?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/checklists/{checklistId}/checklistItems?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700148'    AND           API = '/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems'


-- Record46:  Update : '/apis/v1/inspections/checklists/{ids}?lang={lang}'  to '/apis/v4/inspections/checklists/{ids}?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/checklists/{ids}?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700149'    AND           API = '/v4/inspections/{inspectionId}/checklists/{ids}'


-- Record47:  Update : '/apis/v1/inspections/checklists/{checklistId}/histories?lang={lang}'  to '/apis/v4/inspections/checklists/{checklistId}/histories?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/checklists/{checklistId}/histories?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700150'    AND           API = '/v4/inspections/{inspectionId}/checklists/{checklistId}/histories'


-- Record48:  Update : '/apis/v1/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/histories?lang={lang}'  to '/apis/v4/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/histories?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/histories?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700151'    AND           API = '/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/histories'


-- Record49:  Update : '/apis/v1/inspections/checklists/{checklistId}/checklistItems?lang={lang}'  to '/apis/v4/inspections/checklists/{checklistId}/checklistItems?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/checklists/{checklistId}/checklistItems?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700152'    AND           API = '/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems'


-- Record50:  Update : '/apis/v1/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700153'    AND           API = '/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents'


-- Record51:  Update : '/apis/v1/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&group={group}&category={category}&userId={userId}&password={password}'  to '/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&group={group}&category={category}&userId={userId}&password={password}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&group={group}&category={category}&userId={userId}&password={password}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700154'    AND           API = '/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents'


-- Record52:  Update : '/apis/v1/inspections/{inspectionId}/documents?lang={lang}&fields={fields}'  to '/apis/v4/inspections/{inspectionId}/documents?lang={lang}&fields={fields}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/documents?lang={lang}&fields={fields}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700155'    AND           API = '/v4/inspections/{inspectionId}/documents'


-- Record53:  Update : '/apis/v1/inspections/{inspectionId}/documents?lang={lang}&group={group}&category={category}&userId={userId}&password={password}'  to '/apis/v4/inspections/{inspectionId}/documents?lang={lang}&group={group}&category={category}&userId={userId}&password={password}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/documents?lang={lang}&group={group}&category={category}&userId={userId}&password={password}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700156'    AND           API = '/v4/inspections/{inspectionId}/documents'


-- Record54:  Update : '/apis/v1/inspections/{inspectionId}/documents/{ids}?lang={lang}&userId={userId}&password={password}'  to '/apis/v4/inspections/{inspectionId}/documents/{ids}?lang={lang}&userId={userId}&password={password}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/{inspectionId}/documents/{ids}?lang={lang}&userId={userId}&password={password}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700157'    AND           API = '/v4/inspections/{inspectionId}/documents/{ids}'


-- Record55:  Update : '/apis/v1/inspections/availableDates?lang={lang}&typeId={typeId}&recordId={recordId}&startDate={startDate}&limit={limit}&offset={offset}'  to '/apis/v4/inspections/availableDates?lang={lang}&typeId={typeId}&recordId={recordId}&startDate={startDate}&limit={limit}&offset={offset}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/inspections/availableDates?lang={lang}&typeId={typeId}&recordId={recordId}&startDate={startDate}&limit={limit}&offset={offset}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700159'    AND           API = '/v4/inspections/availableDates'


-- Record56:  Update : '/apis/v1/settings/conditions/approval/types?lang={lang}'  to '/apis/v4/settings/conditions/approval/types?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/settings/conditions/approval/types?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700203'    AND           API = '/v4/settings/conditions/approval/types'


-- Record57:  Update : '/apis/v1/settings/conditions/approval/priorities?lang={lang}'  to '/apis/v4/settings/conditions/approval/priorities?lang={lang}'--

UPDATE RESOURCES SET PROXYAPI = '/apis/v4/settings/conditions/approval/priorities?lang={lang}'    WHERE        ID ='C4012345-AAAA-BBBB-CCCC-123456700204'    AND           API = '/v4/settings/conditions/approval/priorities'

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700234')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700234', N'/v4/search/agencies', N'POST', N'/v4/search/agencies?lang={lang}', N'search_agencies', N'Search Agency', N'Search Agency', 0, 0, N'System', N'2014-04-23', NULL, NULL, NULL, N'searchAgencies', N'All', N'7.3.1', NULL, N'Agencies', NULL)
END

update Resources set Name = 'get_settings_record_expierationStatuses' where Name = 'get_settings_record_expierationStatus' 
