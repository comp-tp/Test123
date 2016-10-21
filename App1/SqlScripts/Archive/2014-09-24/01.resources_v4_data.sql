IF EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/describe/create' AND [HttpVerb] = 'GET')
BEGIN
UPDATE [dbo].[Resources] SET [RelativeUriTemplateFull] = '/v4/records/describe/create?type={type}',[ProxyAPI] = '/apis/v4/records/describe/create?type={type}',[MethodNickName] = 'getRecordDescribe4Create' WHERE [API] = '/v4/records/describe/create' AND [HttpVerb] = 'GET';
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/parts/locations' AND [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/parts/locations', N'GET', N'/v4/settings/parts/locations?lang={lang}', N'get_part_locations', N'Get Part Locations', N'Get Part Locations', 0, 0, N'System',getdate(), Null, Null, N'/apis/v4/settings/parts/locations?lang={lang}', N'getPartLocations', N'7.3.3', null, N'Settings',  N'ALL', null,1) 
 End
IF EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/parts/locations' AND [HttpVerb] = 'GET')
BEGIN
UPDATE [dbo].[Resources] SET [Name] = 'get_part_locations',[ResourceGroupName] = 'Settings' WHERE [API] = '/v4/settings/parts/locations' AND [HttpVerb] = 'GET';
END

------- create_mileage  get_settings_standard_choices---
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/mileage' and [HttpVerb] = 'POST') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/mileage', N'POST', N'/v4/mileage', N'create_mileage', N'Create Mileage', N'Create Mileage', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/mileage', N'createMileage', N'7.3.3', null, N'Mileage',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/standardChoices/{id}' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/standardChoices/{id}', N'GET', N'/v4/settings/standardChoices/{id}?isActive={isActive}', N'get_settings_standard_choices', N'Get Standard Choices', N'Get Standard Choices', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/settings/standardChoices/{id}?isActive={isActive}', N'getStandardChoices', N'7.3.3', null, N'Settings',  N'All', null,1) 
 End 

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/payments/{paymentId}/apply' and [HttpVerb] = 'PUT') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/payments/{paymentId}/apply', N'PUT', N'/v4/records/{recordId}/payments/{paymentId}/apply', N'apply_record_payments', N'Apply Payment', N'Apply Payment', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/payments/{paymentId}/apply', N'applyPayment', N'7.3.3', null, N'Records',  N'Agency', null,1) 
 End 
 IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/fees/{ids}' and [HttpVerb] = 'DELETE') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/fees/{ids}', N'DELETE', N'/v4/records/{recordId}/fees/{ids}?lang={lang}', N'delete_record_fees', N'Delete Record Fees', N'Delete Record Fees', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/fees/{ids}?lang={lang}', N'deleteRecordFees', N'7.3.3', null, N'Records',  N'All', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/payments' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/payments', N'GET', N'/v4/payments?receiptId={receiptId}&paymentStatus={paymentStatus}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'get_payments', N'Get All Payments', N'Get All Payments', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/payments?receiptId={receiptId}&paymentStatus={paymentStatus}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'getPayments', N'7.3.3', null, N'Payments',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/payments/{paymentId}' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/payments/{paymentId}', N'GET', N'/v4/payments/{paymentId}?fields={fields}&lang={lang}', N'get_payment', N'Get Payment', N'Get Payment', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/payments/{paymentId}?fields={fields}&lang={lang}', N'getPayment', N'7.3.3', null, N'Payments',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/payments/histories' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/payments/histories', N'GET', N'/v4/payments/histories?id={id}&type={type}&receiptId={receiptId}&invoiceId={invoiceId}&dateFrom={dateFrom}&dateTo={dateTo}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'get_payment_histories', N'Get All Payment Histories', N'Get All Payment Histories', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/payments/histories?id={id}&type={type}&receiptId={receiptId}&invoiceId={invoiceId}&dateFrom={dateFrom}&dateTo={dateTo}&offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'getPaymentHistories', N'7.3.3', null, N'Payments',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/payments/histories/{id}' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/payments/histories/{id}', N'GET', N'/v4/payments/histories/{id}?fields={fields}&lang={lang}', N'get_payment_history', N'Get Payment History', N'Get Payment History', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/payments/histories/{id}?fields={fields}&lang={lang}', N'getPaymentHistory', N'7.3.3', null, N'Payments',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/payments/histories/{id}/fees' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/payments/histories/{id}/fees', N'GET', N'/v4/payments/histories/{id}/fees?fields={fields}&lang={lang}', N'get_payment_history_fees', N'Get All Payment History Fees', N'Get All Payment History Fees', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/payments/histories/{id}/fees?fields={fields}&lang={lang}', N'getPaymentHistoryFees', N'7.3.3', null, N'Payments',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/fees/histories' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/fees/histories', N'GET', N'/v4/records/{recordId}/fees/histories?fields={fields}&lang={lang}', N'get_record_fee_histories', N'Get All Record Fee Histories', N'Get All Record Fee Histories', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/fees/histories?fields={fields}&lang={lang}', N'getRecordFeeHistories', N'7.3.3', null, N'Records',  N'All', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/payments/histories' and [HttpVerb] = 'GET')
 BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/payments/histories', N'GET', N'/v4/records/{recordId}/payments/histories?fields={fields}&lang={lang}', N'get_record_payment_histories', N'Get All Record Payment Histories', N'Get All Record Payment Histories', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/payments/histories?fields={fields}&lang={lang}', N'getRecordPaymentHistories', N'7.3.3', null, N'Records',  N'All', null,1) 
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/payments/{paymentId}/void' and [HttpVerb] = 'PUT') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/payments/{paymentId}/void', N'PUT', N'/v4/payments/{paymentId}/void?lang={lang}', N'void_payment', N'Void Payment', N'Void Payment', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/payments/{paymentId}/void?lang={lang}', N'voidPayment', N'7.3.3', null, N'Payments',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/fees/{id}' and [HttpVerb] = 'PUT') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/fees/{id}', N'PUT', N'/v4/records/{recordId}/fees/{id}?lang={lang}', N'update_record_fee', N'Update Record Fee', N'Update Record Fee', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/fees/{id}?lang={lang}', N'updateRecordFee', N'7.3.3', null, N'Records',  N'Agency', null,1) 
 End



---add shopping cart
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/shoppingCart' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/shoppingCart', N'GET', N'/v4/shoppingCart?lang={lang}&fields={fields}', N'get_all_shoppingcart', N'Get All Shopping Cart Items', N'Get All Shopping Cart Items', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/shoppingCart?lang={lang}&fields={fields}', N'getShoppingCartItems', N'7.3.3', null, N'Shopping Cart',  N'Citizen', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/shoppingCart/{ids}' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/shoppingCart/{ids}', N'GET', N'/v4/shoppingCart/{ids}?lang={lang}&fields={fields}', N'get_shoppingcart', N'Get Shopping Cart Item', N'Get Shopping Cart Item', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/shoppingCart/{ids}?lang={lang}&fields={fields}', N'getShoppingCartItem', N'7.3.3', null, N'Shopping Cart',  N'Citizen', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/shoppingCart' and [HttpVerb] = 'POST') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/shoppingCart', N'POST', N'/v4/shoppingCart?lang={lang}', N'create_shoppingcart', N'Create Shopping Cart items', N'Create Shopping Cart items', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/shoppingCart?lang={lang}', N'createShoppingCartItems', N'7.3.3', null, N'Shopping Cart',  N'Citizen', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/shoppingCart/{ids}' and [HttpVerb] = 'DELETE') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/shoppingCart/{ids}', N'DELETE', N'/v4/shoppingCart/{ids}?lang={lang}', N'delete_shoppingcart', N'Delete Shopping Cart items', N'Delete Shopping Cart items', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/shoppingCart/{ids}?lang={lang}', N'deleteShoppingCartItems', N'7.3.3', null, N'Shopping Cart',  N'Citizen', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/shoppingCart/{id}' and [HttpVerb] = 'PUT') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/shoppingCart/{id}', N'PUT', N'/v4/shoppingCart/{id}?lang={lang}&fields={fields}', N'update_shoppingcart', N'Update Shopping Cart item', N'Update Shopping Cart item', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/shoppingCart/{id}?lang={lang}&fields={fields}', N'updateShoppingCartItem', N'7.3.3', null, N'Shopping Cart',  N'Citizen', null,1) 
 End 
---add shopping cart end.

---add announcements
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/announcements' and [HttpVerb] = 'GET') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/announcements', N'GET', N'/v4/announcements?fields={fields}&lang={lang}', N'get_announcements', N'Get Announcements', N'Get Announcements', 0, 0, N'System',getdate(), Null, Null, N'/apis/v4/announcements?fields={fields}&lang={lang}', N'getUserAnnouncements', N'7.3.3', null, N'Announcements',  N'All', null,1) 
 End 
---add announcements end.

--- add checklist status
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/inspections/checklists/statuses' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/inspections/checklists/statuses', N'GET', N'/v4/settings/inspections/checklists/statuses?group={group}', N'get_inspection_checklist_statuses', N'Get Checklists Statuses', N'Get Checklists Statuses', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/inspections/checklists/statuses?group={group}', N'getChecklistsStatuses', N'7.3.3', null, N'Inspections', null,N'All')
END
--- add checklist status end.


--- add estimateRecordFees
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/fees/estimate' and [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/records/{recordId}/fees/estimate', N'PUT', N'/v4/records/{recordId}/fees/estimate?lang={lang}&fields={fields}', N'estimate_record_fees', N'Estimate Record Fees', N'Estimate Record Fees', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/fees/estimate?lang={lang}&fields={fields}', N'estimateRecordFees', N'7.3.3', null, N'Records', null,N'All')
END
--- end estimateRecordFees

--- add Record Activities
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/activities' and [HttpVerb] = 'POST')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/records/{recordId}/activities', N'POST', N'/v4/records/{recordId}/activities?lang={lang}', N'create_record_activities', N'Create Record Activities', N'Create Record Activities', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/activities?lang={lang}', N'createRecordActivities', N'7.3.3', null, N'Records', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/activities' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/records/{recordId}/activities', N'GET', N'/v4/records/{recordId}/activities?lang={lang}&fields={fields}', N'get_record_activities', N'Get All Record Activities', N'Get All Activites for Record', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/activities?lang={lang}&fields={fields}', N'getRecordActivities', N'7.3.3', null, N'Records', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/activities/{id}' and [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/records/{recordId}/activities/{id}', N'PUT', N'/v4/records/{recordId}/activities/{id}?lang={lang}&fields={fields}', N'update_record_activity', N'Update Record Activity', N'Update Record Activity', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/activities/{id}?lang={lang}&fields={fields}', N'updateRecordActivity', N'7.3.3', null, N'Records', null,N'Agency')
END
--- edd Record Activities

--- add Record Activities setting
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/activities/types' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/activities/types', N'GET', N'/v4/settings/activities/types?lang={lang}&entityType={entityType}', N'get_settings_activity_types', N'Get All Activity Types', N'Get All Activity Types', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/activities/types?lang={lang}&entityType={entityType}', N'getActivityTypes', N'7.3.3', null, N'Settings', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/activities/statuses' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/activities/statuses', N'GET', N'/v4/settings/activities/statuses?lang={lang}', N'get_settings_activity_statuses', N'Get All Activity Statuses', N'Get All Activity Statuses', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/activities/statuses?lang={lang}', N'getActivityStatuses', N'7.3.3', null, N'Settings', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/activities/priorities' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/activities/priorities', N'GET', N'/v4/settings/activities/priorities?lang={lang}', N'get_settings_activity_priorities', N'Get All Activity Priorities', N'Get All Activity Priorities', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/activities/priorities?lang={lang}', N'getActivityPriorities', N'7.3.3', null, N'Settings', null,N'Agency')
END
--- end Record Activities setting


---add parts search
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/search/parts' and [HttpVerb] = 'POST')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/search/parts', N'POST', N'/v4/search/parts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'search_parts', N'Search Parts', N'Search Parts', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/search/parts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'searchParts', N'7.3.3', null, N'Searches', null,N'Agency')
END
---end parts search

---add parts and cost settings
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/costs/types' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/costs/types', N'GET', N'/v4/settings/costs/types?lang={lang}', N'get_settings_cost_types', N'Get Cost Types', N'Get Cost Types', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/costs/types?lang={lang}', N'getCostTypes', N'7.3.3', null, N'Settings', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/costs/accounts' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/costs/accounts', N'GET', N'/v4/settings/costs/accounts?lang={lang}', N'get_settings_cost_accounts', N'Get Cost Accounts', N'Get Cost Accounts', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/costs/accounts?lang={lang}', N'getCostAccounts', N'7.3.3', null, N'Settings', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/costs/unitTypes' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/costs/unitTypes', N'GET', N'/v4/settings/costs/unitTypes?lang={lang}', N'get_settings_cost_unit_types', N'Get Cost UnitTypes', N'Get Cost UnitTypes', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/costs/unitTypes?lang={lang}', N'getCostUnitTypes', N'7.3.3', null, N'Settings', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/costs/factors' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/costs/factors', N'GET', N'/v4/settings/costs/factors?lang={lang}', N'get_settings_cost_factors', N'Get Cost Factors', N'Get Cost Factors', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/costs/factors?lang={lang}', N'getCostFactors', N'7.3.3', null, N'Settings', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/parts/types' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/parts/types', N'GET', N'/v4/settings/parts/types?lang={lang}', N'get_settings_part_types', N'Get Part Types', N'Get Part Types', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/parts/types?lang={lang}', N'getPartTypes', N'7.3.3', null, N'Settings', null,N'Agency')
END
---end parts and cost settings


---add const item
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/costs/types/{typeName}/items' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/costs/types/{typeName}/items', N'GET', N'/v4/settings/costs/types/{typeName}/items?lang={lang}', N'get_settings_cost_items', N'Get Cost Items', N'Get Cost Items', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/costs/types/{typeName}/items?lang={lang}', N'getCostItems', N'7.3.3', null, N'settings', null,N'Agency')
END
---end cost item

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/search/costs' AND [HttpVerb] = 'POST') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/search/costs', N'POST', N'/v4/search/costs?offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'search_costs', N'Search Costs', N'Search Costs', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/search/costs?offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'searchCosts', N'7.3.3', null, N'Searches',  N'Agency', null,1) 
 End 
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/pickLists/{id}' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/pickLists/{id}', N'GET', N'/v4/settings/pickLists/{id}', N'get_settings_pick_list', N'Get Pick List', N'Get Pick List', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/pickLists/{id}', N'getPickList', N'7.3.3', null, N'Settings', null,N'All')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/pickLists' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/pickLists', N'GET', N'/v4/settings/pickLists', N'get_settings_pick_lists', N'Get All Pick Lists', N'Get All Pick Lists', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/pickLists', N'getAllPickLists', N'7.3.3', null, N'Settings', null,N'All')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/folderGroups' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/documents/folderGroups', N'GET', N'/v4/settings/documents/folderGroups?isActive={isActive}&lang={lang}', N'get_documents_folder_groups', N'Get Folder Groups', N'Get Folder Groups', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/documents/folderGroups?isActive={isActive}&lang={lang}', N'getFolderGroups', N'7.3.3', null, N'Documents', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/folders/{groupId}' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/documents/folders/{groupId}', N'GET', N'/v4/settings/documents/folders/{groupId}?isActive={isActive}&lang={lang}', N'get_documents_folders', N'Get Folders', N'Get Folders', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/documents/folders/{groupId}?isActive={isActive}&lang={lang}', N'getFolders', N'7.3.3', null, N'Documents', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/folderGroups' and [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/documents/folderGroups', N'PUT', N'/v4/settings/documents/folderGroups?lang={lang}', N'update_documents_folder_groups', N'Update Folder Groups', N'Update Folder Groups', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/documents/folderGroups?lang={lang}', N'updateFolderGroups', N'7.3.3', null, N'Documents', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/folders' and [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/documents/folders', N'PUT', N'/v4/settings/documents/folders?lang={lang}', N'update_documents_folders', N'Update Folders', N'Update Folders', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/documents/folders?lang={lang}', N'updateFolders', N'7.3.3', null, N'Documents', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/folders' and [HttpVerb] = 'POST')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/documents/folders', N'POST', N'/v4/settings/documents/folders?lang={lang}', N'create_documents_folders', N'Create Folders', N'Create Folders', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/documents/folders?lang={lang}', N'createFolders', N'7.3.3', null, N'Documents', null,N'Agency')
END
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/folders/{ids}' and [HttpVerb] = 'DELETE')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/settings/documents/folders/{ids}', N'DELETE', N'/v4/settings/documents/folders/{ids}?lang={lang}', N'delete_documents_folders', N'Delete Folders', N'Delete Folders', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/documents/folders/{ids}?lang={lang}', N'deleteFolders', N'7.3.3', null, N'Documents', null,N'Agency')
END


IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{ids}' and [HttpVerb] = 'DELETE')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription],[Applicability]) VALUES (newid(),N'/v4/records/{ids}', N'DELETE', N'/v4/records/{ids}', N'delete_records', N'Delete Records', N'Delete Records', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{ids}', N'deleteRecords', N'7.3.3', null, N'Records', null,N'All')
END


update resources
set authenticationType=1
where name in ('get_linked_accounts', 'get_account_profile')

--- update API 'search_inspections' , add '&expand={expand}' behind URL.

update resources set RelativeUriTemplateFull = '/v4/search/inspections?limit={limit}&offset={offset}&fields={fields}&lang={lang}&sort={sort}&direction={direction}&hasTotal={hasTotal}&fields={fields}&expand={expand}' ,
ProxyAPI = '/apis/v4/search/inspections?limit={limit}&offset={offset}&fields={fields}&lang={lang}&sort={sort}&direction={direction}&hasTotal={hasTotal}&fields={fields}&expand={expand}'
where Id = 'C4012345-AAAA-BBBB-CCCC-123456700059'

--- update API 'search_inspections' end.

---Add API 'Get Workflow Task Histories' and 'Get Workflow Task Comment Histories'
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE Id = '86F9D481-33CC-4CD0-8295-63928F6EE2A0')
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'86F9D481-33CC-4CD0-8295-63928F6EE2A0', N'/v4/records/{recordId}/workflowTasks/histories', N'GET', N'/v4/records/{recordId}/workflowTasks/histories?lang={lang}', N'get_record_workflow_task_histories', N'Get Workflow Task Histories', N'Get Workflow Task Histories', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/workflowTasks/histories?lang={lang}', N'getWorkflowTaskHistories', N'All', N'7.3.2', NULL, N'Records', null)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE Id = '86F9D481-33CC-4CD0-8295-63928F6EE2A1')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (N'86F9D481-33CC-4CD0-8295-63928F6EE2A1', N'/v4/records/{recordId}/workflowTasks/comments/histories', N'GET', N'/v4/records/{recordId}/workflowTasks/comments/histories?lang={lang}',N'get_record_workflow_task_comment_histories', N'Get Workflow Task Comment Histories', N'Get Workflow Task Comment Histories', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/workflowTasks/comments/histories?lang={lang}', N'getWorkflowTaskCommentHistories', N'All', N'7.3.2', NULL, N'Records',null)
END
---Add API 'Get Workflow Task Histories' and 'Get Workflow Task Comment Histories' end.

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700235')
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription])
	VALUES ( 'C4012345-AAAA-BBBB-CCCC-D23456700235', N'/v4/documents/{documentId}/thumbnail', N'GET', N'/v4/documents/{documentId}/thumbnail?height={height}&width={width}&password={password}&userId={userId}', N'get_document_thumbnail', N'Get Document Thumbnail', N'Get Document Thumbnail', 5, 0, N'System', getdate(), NULL, NULL, NULL, N'getDocumentThumbnail', N'All', N'7.3.2', NULL, N'Documents', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [Id] = N'8EBF1461-DF20-414F-AD09-1F668E4A413D')
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription])
	VALUES ( '8EBF1461-DF20-414F-AD09-1F668E4A413D', N'/v4/agencies/{name}/environments', N'GET', N'/v4/agencies/{name}/environments', N'get_agency_environments', N'Get Agency Environments', N'Get Agency Environments', 0, 0, N'System', getdate(), NULL, NULL, NULL, N'getAgencyEnvironments', N'All', N'7.3.2', NULL, N'Agencies', NULL)
END

--- update record mine , set 'staff' to 'user'

update resources set RelativeUriTemplateFull = '/v4/records/mine?lang={lang}&&type={type}&openedDateFrom={openedDateFrom}&openedDateTo={openedDateTo}&customId={customId}&module={module}&status={status}&assignedDateFrom={assignedDateFrom}&assignedDateTo={assignedDateTo}&completedDateFrom={completedDateFrom}&completedDateTo={completedDateTo}&completedByDepartment={completedByDepartment}&completedByUser={completedByUser}&closedDateFrom={closedDateFrom}&closedDateTo={closedDateTo}&closedByDepartment={closedByDepartment}&closedByUser={closedByUser}&expand={expand}'
,ProxyAPI = '/apis/v4/records/mine?lang={lang}&&type={type}&openedDateFrom={openedDateFrom}&openedDateTo={openedDateTo}&customId={customId}&module={module}&status={status}&assignedDateFrom={assignedDateFrom}&assignedDateTo={assignedDateTo}&completedDateFrom={completedDateFrom}&completedDateTo={completedDateTo}&completedByDepartment={completedByDepartment}&completedByUser={completedByUser}&closedDateFrom={closedDateFrom}&closedDateTo={closedDateTo}&closedByDepartment={closedByDepartment}&closedByUser={closedByUser}&expand={expand}'
where id = 'C4012345-AAAA-BBBB-CCCC-123456700030'

--- update record mine end.
---update search parcel
update resources set RelativeUriTemplateFull ='/v4/search/parcels?lang={lang}&offset={offset}&limit={limit}&expand={expand}',
		ProxyAPI='/apis/v4/search/parcels?lang={lang}&offset={offset}&limit={limit}&expand={expand}'
		where id = 'C4012345-AAAA-BBBB-CCCC-123456700063'
---update search parcel end.



-- Make POST /v4/search/records/location as a private API.
UPDATE [dbo].[Resources]
SET
	APIAttribute = 1
WHERE [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700205'





IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/timeAccounting' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/timeAccounting', N'GET', N'/v4/timeAccounting', N'get_timeaccounting', N'Get Time Accounting', N'Get Time Accounting', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/timeAccounting', N'getTimeAccounting', N'7.3.3', null, N'TimeAccounting',  N'Agency', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/timeAccounting' and [HttpVerb] = 'POST')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/timeAccounting', N'POST', N'/v4/timeAccounting', N'create_timeaccounting', N'Create Time Accounting', N'Create Time Accounting', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/timeAccounting', N'createTimeAccounting', N'7.3.3', null, N'TimeAccounting',  N'Agency', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/timeAccounting/{id}' and [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/timeAccounting/{id}', N'PUT', N'/v4/timeAccounting/{id}', N'update_timeaccounting', N'Update Time Accounting', N'Update Time Accounting', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/timeAccounting/{id}', N'updateTimeAccounting', N'7.3.3', null, N'TimeAccounting',  N'Agency', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/timeAccounting/{ids}' and [HttpVerb] = 'DELETE')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/timeAccounting/{ids}', N'DELETE', N'/v4/timeAccounting/{ids}', N'delete_timeaccounting', N'Delete Time Accounting', N'Delete Time Accounting', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/timeAccounting/{ids}', N'deleteTimeAccounting', N'7.3.3', null, N'TimeAccounting',  N'Agency', null,1)
 End

update [dbo].[Resources] set [ProxyAPI] = '/apis/v4/settings/timeAccounting/types?groupId={groupId}&userIds={userIds}&recordType={recordType}&lang={lang}' where [API] = '/v4/settings/timeAccounting/types' and [HttpVerb] = 'GET'


IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/partTransaction' and [HttpVerb] = 'POST')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/partTransaction', N'POST', N'/v4/records/{recordId}/partTransaction?fields={fields}&lang={lang}', N'create_record_parttransaction', N'Create Record Part Transaction', N'Create Record Part Transaction', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/partTransaction?fields={fields}&lang={lang}', N'createRecordPartTransaction', N'7.3.3', null, N'Records',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/partTransaction/{ids}' and [HttpVerb] = 'DELETE')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/partTransaction/{ids}', N'DELETE', N'/v4/records/{recordId}/partTransaction/{ids}?lang={lang}', N'void_record_parttransaction', N'Void Record Part Transaction', N'Void Record Part Transaction', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/partTransaction/{ids}?lang={lang}', N'voidRecordpartTransaction', N'7.3.3', null, N'Records',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/partTransaction' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/partTransaction', N'GET', N'/v4/records/{recordId}/partTransaction?fields={fields}&lang={lang}&offset={offset}&limit={limit}', N'get_record_parttransaction', N'Get Record Part Transaction', N'Get Record Part Transaction', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/partTransaction?fields={fields}&lang={lang}&offset={offset}&limit={limit}', N'getRecordPartTransaction', N'7.3.3', null, N'Records',  N'All', null,1)
 End


IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/parts/locations' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/parts/locations', N'GET', N'/v4/settings/parts/locations?lang={lang}', N'get_part_ locations', N'Get Part Locations', N'Get Part Locations', 0, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/parts/locations?lang={lang}', N'getPartLocations', N'7.3.3', null, N'settings',  N'ALL', null,1)
 End

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [Id] = N'C4012345-AAAA-BBBB-CCCC-123456709000')
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription])
	VALUES ( 'C4012345-AAAA-BBBB-CCCC-123456709000', N'/v4/async/result', N'GET', N'/v4/async/result?requestId={requestId}', N'get_async_result', N'Get Async Result', N'Get Async Result', 0, 0, N'System', getdate(), NULL, NULL, NULL, N'getAsyncResult', N'All', '', NULL, NULL, NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [Id] = N'C4012345-AAAA-BBBB-CCCC-123456709001')
BEGIN
	INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription])
	VALUES ( 'C4012345-AAAA-BBBB-CCCC-123456709001', N'/v3/async/result', N'GET', N'/v3/async/result?requestId={requestId}', N'get_async_result', N'Get Async Result', N'Get Async Result', 0, 0, N'System', getdate(), NULL, NULL, NULL, N'getAsyncResult', N'All', '', NULL, NULL, NULL)
END


update resources set api ='/v4/inspections/{id}/related', relativeUriTemplateFull='/v4/inspections/{id}/related?lang={lang}&relationship={relationship}&fields={fields}' where id='C4012345-AAAA-BBBB-CCCC-123456700136'

update resources set api ='/v4/inspections/{id}/related', relativeUriTemplateFull='/v4/inspections/{id}/related?lang={lang}' where id='C4012345-AAAA-BBBB-CCCC-123456700137'

update resources set api ='/v4/inspections/{id}/related/{childIds}', relativeUriTemplateFull='/v4/inspections/{id}/related/{childIds}?lang={lang}' where id='C4012345-AAAA-BBBB-CCCC-123456700138'

-- correct api url for api document to ensure api url same as swagger file
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms' where httpverb='GET' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms'
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/{formId}/meta' where httpverb='GET' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/{formId}/meta'
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/meta' where httpverb='GET' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/meta'
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables' where httpverb='GET' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables'
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/meta' where httpverb='GET' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/meta'
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}' where httpverb='GET' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}'
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}/meta' where httpverb='GET' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}/meta'
update resources set api='/v4/parcels/{parcelId}/owners' where httpverb='GET' and api='/v4/parcels/{id}/owners'
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms' where httpverb='PUT' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms'
update resources set api='/v4/inspections/{id}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables' where httpverb='PUT' and api='/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables'

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/records/{recordId}/folders' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/records/{recordId}/folders', N'GET', N'/v4/records/{recordId}/folders', N'get_record_virtual_folder', N'Get Record Virtual Folder', N'Get Record Virtual Folder', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/records/{recordId}/folders', N'getRecordVirtualFolder', N'7.3.3', null, N'Records',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/records/types/{id}/folders' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/records/types/{id}/folders', N'GET', N'/v4/settings/records/types/{id}/folders', N'get_record_type_virtual_folder', N'Get Record Type Virtual Folder', N'Get Record Type Virtual Folder', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/records/types/{id}/folders', N'getRecordtypeVirtualFolder', N'7.3.3', null, N'Settings',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/documents/EDMS' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/documents/EDMS', N'GET', N'/v4/settings/documents/EDMS', N'get_settings_EDMS', N'Get EDMS', N'Get EDMS', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/documents/EDMS', N'getEDMS', N'7.3.3', null, N'Documents',  N'All', null,1)
 End

 IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/documents/{documentId}' and [HttpVerb] = 'PUT')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/documents/{documentId}', N'PUT', N'/v4/documents/{documentId}', N'update_document', N'Update Document', N'Update Document', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/documents/{documentId}', N'updateDocument', N'7.3.3', null, N'Documents',  N'Agency', null,1)
 End
 IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/inspections/{inspectionId}/conditions/permission' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/inspections/{inspectionId}/conditions/permission', N'GET', N'/v4/inspections/{inspectionId}/conditions/permission', N'get_inspection_condition_permission', N'Get Inspections Conditions Permission', N'Get Inspections Conditions Permission', 5, 11, N'System',getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/conditions/permission', N'getInspectionsConditionsPermission', N'7.3.3', null, N'Inspections',  N'All', null,1)
 End
IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/settings/parts/locations' and [HttpVerb] = 'GET')
  BEGIN
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/settings/parts/locations', N'GET', N'/v4/settings/parts/locations?lang={lang}', N'get_part_ locations', N'Get Part Locations', N'Get Part Locations', 0, 11, N'System',getdate(), Null, Null, N'/apis/v4/settings/parts/locations?lang={lang}', N'getPartLocations', N'7.3.3', null, N'settings',  N'ALL', null,1)
 End

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE [API] = '/v4/search/parts' and [HttpVerb] = 'POST') 
  BEGIN 
INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[Applicability],[FIDDescription],[ISPROXY]) VALUES (newid(),N'/v4/search/parts', N'POST', N'/v4/search/parts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'search_parts', N'Search Parts', N'Search Parts', 5, 0, N'System',getdate(), Null, Null, N'/apis/v4/search/parts?offset={offset}&limit={limit}&fields={fields}&lang={lang}', N'searchParts', N'7.3.3', null, N'Searches',  N'Agency', null,1) 
 End 


update [Resources] set API = '/v4/shoppingCart/{ids}',RelativeUriTemplateFull = '/v4/shoppingCart/{ids}?lang={lang}',Name= 'delete_shoppingcart',displayName = 'Delete Shopping Cart',Description = 'Delete Shopping Cart',ProxyAPI = '/apis/v4/shoppingCart/{ids}?lang={lang}' where API = '/v4/shoppingCart/items/{ids}' and HttpVerb = 'DELETE';

update [Resources] set API = '/v4/shoppingCart',RelativeUriTemplateFull = '/v4/shoppingCart?fields={fields}&lang={lang}',NAME = 'get_all_shoppingcart',displayName = 'Get All Shopping Cart',Description = 'Get All Shopping Cart',ProxyAPI = '/apis/v4/shoppingCart?fields={fields}&lang={lang}' where API = '/v4/shoppingCart/items' and HttpVerb = 'GET';

update [Resources] set API = '/v4/shoppingCart/{ids}',RelativeUriTemplateFull = '/v4/shoppingCart/{ids}?fields={fields}&lang={lang}',NAME = 'get_shoppingcart',displayName = 'Get Shopping Cart',Description = 'Get Shopping Cart',ProxyAPI = '/apis/v4/shoppingCart/{ids}?fields={fields}&lang={lang}' where API = '/v4/shoppingCart/items/{ids}' and HttpVerb = 'GET';

update [Resources] set API = '/v4/shoppingCart',RelativeUriTemplateFull = '/v4/shoppingCart?lang={lang}',NAME = 'create_shoppingcart',displayName = 'Create Shopping Cart',Description = 'Create Shopping Cart',ProxyAPI = '/apis/v4/shoppingCart?lang={lang}' where API = '/v4/shoppingCart/items' and HttpVerb = 'POST';

update [Resources] set API = '/v4/shoppingCart/{id}',RelativeUriTemplateFull = '/v4/shoppingCart/{id}?fields={fields}&lang={lang}',NAME = 'update_shoppingcart',displayName = 'Update Shopping Cart',Description = 'Update Shopping Cart',ProxyAPI = '/apis/v4/shoppingCart/{id}?fields={fields}&lang={lang}' where API = '/v4/shoppingCart/items/{id}' and HttpVerb = 'PUT';

-- change api attribute
update resources set APIAttribute = 0 where APIAttribute=11

-- update api to remove end of '/'
update resources set api ='/v3p/records' where api ='/v3p/records/' and httpverb = 'GET'
update resources set api ='/v3p/professionals' where api ='/v3p/professionals/' and httpverb = 'GET'
update resources set api ='/v3p/search/professionals' where api ='/v3p/search/professionals/' and httpverb = 'POST'
update resources set api ='/v3p/search/records' where api ='/v3p/search/records/' and httpverb = 'POST'

-- correct v3 non proxy api
update resources set IsProxy =0 where api ='/v4/async/result' and httpverb = 'GET'
update resources set IsProxy =0 where api ='/v3/async/result' and httpverb = 'GET'
update resources set IsProxy =0 where api ='/v4/agencies/{name}/environments' and httpverb = 'GET'
update resources set IsProxy =0 where api ='/v3p1/records/{recordId}/conditions' and httpverb = 'GET'
update resources set IsProxy =0 where api ='/v3/civicheroapp/records/{id}/votes' and httpverb = 'POST'
update resources set IsProxy =0 where api ='/v3/a311agencyapp/records/{id}/usercomments' and httpverb = 'GET'
update resources set IsProxy =0 where api ='/v3/a311agencyapp/records/{id}/usercomments' and httpverb = 'POST'
update resources set IsProxy =0 where api ='/v3/civicheroapp/records/{id}/usercomments' and httpverb = 'POST'
update resources set IsProxy =0 where api ='/v3/a311civicapp/records/{id}/usercomments' and httpverb = 'GET'
update resources set IsProxy =0 where api ='/v3/inspectorapp/cleanupcache' and httpverb = 'GET'

-- set v3 proxy api thru govxml or light service
update resources set IsAAGovxmlAPI = 1 where api like '/v3/%' and isproxy =1

-- set v4 proxy api thru govxml
update resources set IsProxy = 1, IsAAGovxmlAPI = 1 where api = '/v4/search/records/location' and httpverb = 'POST '
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/agencies' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/agencies/{name}' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/agencies/{name}/environments' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/agencies/{name}/logo' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/appdata/{container}/{blobname}' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/appdata/{container}/{blobname}' and httpverb = 'PUT'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/appdata/{container}/{blobname}' and httpverb = 'DELETE'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/appsettings' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/documents/{documentId}/thumbnail' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/records/{recordId}/usercomments' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/records/{recordId}/usercomments' and httpverb = 'POST'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/records/{recordId}/votes' and httpverb = 'POST'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/records/{recordId}/votes' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/records/{recordId}/votes/summary' and httpverb = 'GET'
update resources set IsProxy = 1, IsAAGovxmlAPI = 1 where api = '/v4/settings/comments' and httpverb = 'GET'
update resources set IsProxy = 1, IsAAGovxmlAPI = 1 where api = '/v4/settings/comments/groups' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/civicid/profile' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/civicid/accounts' and httpverb = 'GET'
update resources set IsProxy = 0, IsAAGovxmlAPI = 0 where api = '/v4/civicid/accounts/{id}' and httpverb = 'GET'

update resources set APIAttribute = 1 where api='/batch' and httpverb='POST'
update resources set APIAttribute = 1 where api='/v4/async/result' and httpverb='GET'
update resources set APIAttribute = 1 where api='/v4/settings/standardChoices/{id}' and httpverb='GET'
update resources set APIAttribute = 1 where api='/v4/settings/documents/EDMS' and httpverb='GET'

update resources set IsProxy =1, ProxyAPI='/apis/v4/search/records/location' where api='/v4/search/records/location' and httpverb='POST'