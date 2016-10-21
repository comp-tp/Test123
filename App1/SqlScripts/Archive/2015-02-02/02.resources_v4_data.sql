---remove get_settings_EDMS
IF  EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/EDMS' AND [HttpVerb] = 'GET')
  BEGIN
DELETE FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/EDMS' AND [HttpVerb] = 'GET'
 End
---remove get_settings_EDMS end

---add missing API
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/sources' AND [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/documents/sources', N'GET', N'/v4/settings/documents/sources?lang={lang}&&userId={userId}', N'get_settings_document_sources', N'Get Document Sources', N'Get Document Sources', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/settings/documents/sources?lang={lang}&&userId={userId}', N'getDocumentSources', N'7.3.3.1', null, N'Documents',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms' AND [HttpVerb] = 'POST')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms', N'POST', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms?lang={lang}', N'create_inspection_checklist_item_customforms', N'Create Inspection Checklist Custom Forms', N'Create Inspection Checklist Custom Forms', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms?lang={lang}', N'createInspectionChecklistCustomForms', N'7.3.2', null, N'Inspections',  N'Agency', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/inspections/{inspectionId}/comments' AND [HttpVerb] = 'POST')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/inspections/{inspectionId}/comments', N'POST', N'/v4/inspections/{inspectionId}/comments?lang={lang}&comment={comment}&commentType={commentType}', N'create_inspection_comments', N'Creata Inspection Comments', N'Creata Inspection Comments', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/comments?lang={lang}&comment={comment}&commentType={commentType}', N'creataInspectionComments', N'7.3.2', null, N'Inspections',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/inspections/{inspectionId}/comments' AND [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/inspections/{inspectionId}/comments', N'PUT', N'/v4/inspections/{inspectionId}/comments?lang={lang}&comment={comment}&commentType={commentType}', N'update_inspection_comments', N'Update Inspection Comments', N'Update Inspection Comments', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/comments?lang={lang}&comment={comment}&commentType={commentType}', N'updateInspectionComments', N'7.3.2', null, N'Inspections',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/inspections/checklists/{id}/checklistItems' AND [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/inspections/checklists/{id}/checklistItems', N'PUT', N'/v4/inspections/checklists/{id}/checklistItems?lang={lang}', N'update_checklist_items', N'Update CheckList Items', N'Update CheckList Items', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/inspections/checklists/{id}/checklistItems?lang={lang}', N'updateCheckListItems', N'7.3.2', null, N'Inspections',  N'All', null,1)
 End
---add missing API

-----/v4/payments/refund
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/payments/refund' and [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/payments/refund', N'PUT', N'/v4/payments/refund?lang={lang}', N'refund_payment', N'Refund Payment', N'Refund Payment', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/payments/refund?lang={lang}', N'refundPayment', N'7.3.3.1', null, N'Payments',  N'Agency', null,1)
 End
-----/v4/payments/refund end

--/v4/settings/invoices/voidReasons,/v4/settings/payments/refundReasons,/v4/settings/payments/voidReasons
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/invoices/voidReasons' AND [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/invoices/voidReasons', N'GET', N'/v4/settings/invoices/voidReasons?lang={lang}', N'get_settings_invoices_void_reasons', N'Get Invoice Void Reasons', N'Get Invoice Void Reasons', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/settings/invoices/voidReasons?lang={lang}', N'getInvoiceVoidReasons', N'7.3.3.1', null, N'Settings',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/payments/refundReasons' AND [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/payments/refundReasons', N'GET', N'/v4/settings/payments/refundReasons?lang={lang}', N'get_settings_payments_refund_reasons', N'Get Payment Refund Reasons', N'Get Payment Refund Reasons', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/settings/payments/refundReasons?lang={lang}', N'getPaymentRefundReasons', N'7.3.3.1', null, N'Settings',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/payments/voidReasons' AND [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/payments/voidReasons', N'GET', N'/v4/settings/payments/voidReasons?lang={lang}', N'get_settings_payments_void_reasons', N'Get Payment Void Reasons', N'Get Payment Void Reasons', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/settings/payments/voidReasons?lang={lang}', N'getPaymentVoidReasons', N'7.3.3.1', null, N'Settings',  N'All', null,1)
 End
--/v4/settings/invoices/voidReasons,/v4/settings/payments/refundReasons,/v4/settings/payments/voidReasons  end

-- update API to private
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/payments/refund' AND [HttpVerb] = 'PUT';
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/payments/{paymentId}/void' AND [HttpVerb] = 'PUT';
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/payments' AND [HttpVerb] = 'GET';
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/payments/{paymentId}' AND [HttpVerb] = 'GET';
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/payments/histories' AND [HttpVerb] = 'GET';
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/payments/histories/{id}' AND [HttpVerb] = 'GET'
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/payments/histories/{id}/fees' AND [HttpVerb] = 'GET'
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/settings/payments/voidReasons' AND [HttpVerb] = 'GET'
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/settings/payments/refundReasons' AND [HttpVerb] = 'GET'
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/records/{recordId}/payments/{paymentId}/apply' AND [HttpVerb] = 'PUT'
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/records/{recordId}/fees/{id}' AND [HttpVerb] = 'PUT'
UPDATE [dbo].[Resources] SET [APIAttribute] = 1 WHERE [API] = '/v4/records/{recordId}/fees/{ids}' AND [HttpVerb] = 'DELETE'
-- update API to private end

--Remove get_settings_condition_approval_priorities, get_settings_condition_approval_types
IF EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/conditions/approval/priorities' AND [HttpVerb] = 'GET')
  BEGIN
DELETE FROM [dbo].[Resources] WHERE [API] = '/v4/settings/conditions/approval/priorities' AND [HttpVerb] = 'GET'
 End

IF EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/conditions/approval/types' AND [HttpVerb] = 'GET')
  BEGIN
DELETE FROM [dbo].[Resources] WHERE[API] = '/v4/settings/conditions/approval/types' AND [HttpVerb] = 'GET'
 End
--Remove get_settings_condition_approval_priorities, get_settings_condition_approval_types end


UPDATE [dbo].[Resources]
SET RelativeUriTemplateFull = '/v4/parcels/{parcelId}/owners?lang={lang}',
    ProxyAPI = '/apis/v4/parcels/{parcelId}/owners?lang={lang}'
WHERE id = 'C4012345-AAAA-BBBB-CCCC-123456700016'

--void_invoice --
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/invoices/{invoiceId}/void' AND [HttpVerb] = 'PUT') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/invoices/{invoiceId}/void', N'PUT', N'/v4/invoices/{invoiceId}/void?lang={lang}', N'void_invoice', N'Void Invoice', N'Void Invoice', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/invoices/{invoiceId}/void?lang={lang}', N'voidInvoice', N'7.3.3.1', null, N'Invoices',  N'Agency', null,1) 
 End 
--void_invoice end -- 

--update document folders --
UPDATE [dbo].[Resources]
SET API = '/v4/settings/documents/folders', 
RelativeUriTemplateFull = '/v4/settings/documents/folders?groupId={groupId}&isActive={isActive}&lang={lang}',
ProxyAPI = '/apis/v4/settings/documents/folders?groupId={groupId}&isActive={isActive}&lang={lang}', [APIAttribute] = 1
WHERE [API] = '/v4/settings/documents/folders/{groupId}' AND [HttpVerb] = 'GET' 
--update document folders end --

--Quick Query API --
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/quickQueries' AND [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/quickQueries', N'GET', N'/v4/quickQueries', N'get_quick_queries', N'get quick queries', N'get quick queries', 5, 1, N'System',getdate(), Null, Null, N'/apis/v4/quickQueries', N'getQuickQueries', N'7.3.3.1', null, null,  N'All', null,1) 
 End 
 
 IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/quickQueries/{id}' AND [HttpVerb] = 'POST') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/quickQueries/{id}', N'POST', N'/v4/quickQueries/{id}?fields={fields}&offset={offset}&limit={limit}', N'run_quick_query', N'run quick query', N'run quick query', 5, 1, N'System',getdate(), Null, Null, N'/apis/v4/quickQueries/{id}?fields={fields}&offset={offset}&limit={limit}', N'runQuickQuery', N'7.3.3.1', null, null,  N'All', null,1) 
 End 
--Quick Query API end -- 

-- generate_receipt void_record_payment void_record_fee --
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/payments/generatereceipt' AND [HttpVerb] = 'POST') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/payments/generatereceipt', N'POST', N'/v4/records/{recordId}/payments/generatereceipt?fields={fields}&lang={lang}', N'generate_receipt', N'Generate Receipt', N'Generate Receipt', 5, 1, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/payments/generatereceipt?fields={fields}&lang={lang}', N'generateReceipt', N'7.3.3.1', null, N'Records',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/payments/void' AND [HttpVerb] = 'POST') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/payments/void', N'POST', N'/v4/records/{recordId}/payments/void?fields={fields}&lang={lang}&isPos={isPos}&posTransSeq={posTransSeq}&defaultDate={defaultDate}&cashdrawerId={cashdrawerId}&workstationId={workstationId}&cashier={cashier}&terminal={terminal}&sessionId={sessionId}', N'void_record_payment', N'Void Record Payment', N'Void Record Payment', 5, 1, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/payments/void?fields={fields}&lang={lang}&isPos={isPos}&posTransSeq={posTransSeq}&defaultDate={defaultDate}&cashdrawerId={cashdrawerId}&workstationId={workstationId}&cashier={cashier}&terminal={terminal}&sessionId={sessionId}', N'voidRecordPayment', N'7.3.3.1', null, N'Records',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/fees/void' AND [HttpVerb] = 'POST') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/fees/void', N'POST', N'/v4/records/{recordId}/fees/void?fields={fields}&lang={lang}&isPos={isPos}&posTransSeq={posTransSeq}&sessionId={sessionId}', N'void_record_fee', N'Void Record Fee', N'Void Record Fee', 5, 1, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/fees/void?fields={fields}&lang={lang}&isPos={isPos}&posTransSeq={posTransSeq}&sessionId={sessionId}', N'voidRecordFee', N'7.3.3.1', null, N'Records',  N'Agency', null,1) 
 End 
-- generate_receipt void_record_payment void_record_fee end --

--get_asset_parts --
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/assets/{assetId}/parts' AND [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/assets/{assetId}/parts', N'GET', N'/v4/assets/{assetId}/parts?fields={fields}&lang={lang}&offset={offset}&limit={limit}&status={status}&type={type}', N'get_asset_parts', N'Get Asset Part List', N'Get Asset Part List', 5, 1, N'System',getdate(), Null, Null, N'/apis/v4/assets/{assetId}/parts?fields={fields}&lang={lang}&offset={offset}&limit={limit}&status={status}&type={type}', N'getAssetPartsByAssetSeqNbr', N'7.3.3.1', null, N'Assets',  N'Agency', null,1) 
 End 
--get_asset_parts end --