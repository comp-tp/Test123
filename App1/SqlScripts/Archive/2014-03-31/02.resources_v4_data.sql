IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700001')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700001', N'/v4/records/{recordId}/customTables', N'GET', N'/v4/records/{recordId}/customTables?lang={lang}', N'get_record_customtables', N'Get Record Custom Tables', N'Get Record Custom Tables', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customTables?lang={lang}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', N'(8411R||8395R||8209R) && 8270R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700002')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700002', N'/v4/records/{recordId}/customTables/{tableId}', N'GET', N'/v4/records/{recordId}/customTables/{tableId}?lang={lang}', N'get_record_customtable', N'Get Record Custom Table', N'Get Record Custom Table', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customTables/{tableId}?lang={lang}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', N'(8411R||8395R||8209R) && 8270R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700003')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700003', N'/v4/records/{recordId}/customTables', N'PUT', N'/v4/records/{recordId}/customTables?lang={lang}', N'update_record_customtables', N'Update Record Custom Tables', N'Update Record Custom Tables', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customTables?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700004')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700004', N'/v4/records/{recordId}/customTables/meta', N'GET', N'/v4/records/{recordId}/customTables/meta?lang={lang}', N'get_record_customtables_meta', N'Get Record Custom Tables Meta', N'Get Record Custom Tables Meta', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customTables/meta?lang={lang}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700005')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700005', N'/v4/records/{recordId}/customTables/{tableId}/meta', N'GET', N'/v4/records/{recordId}/customTables/{tableId}/meta?lang={lang}', N'get_record_customtable_meta', N'Get Record Custom Table Meta', N'Get Record Custom Table Meta', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customTables/{tableId}/meta?lang={lang}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700006')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700006', N'/v4/records/{recordId}/customForms', N'GET', N'/v4/records/{recordId}/customForms?lang={lang}', N'get_record_customforms', N'Get Record custom Forms', N'Get Record custom Forms', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customForms?lang={lang}', N'getRecordc', N'All', N'7.3.1', NULL, N'Records', N'(8411R||8395R||8209R) && 8073R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700007')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700007', N'/v4/records/{recordId}/customForms/meta', N'GET', N'/v4/records/{recordId}/customForms/meta?lang={lang}', N'get_record_customforms_meta', N'Get Record custom Forms Meta', N'Get Record custom Forms Meta', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customForms/meta?lang={lang}', N'getRecordc', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700008')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700008', N'/v4/records/{recordId}/customForms', N'PUT', N'/v4/records/{recordId}/customForms?lang={lang}', N'update_record_customforms', N'Update Record custom Forms', N'Update Record custom Forms', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customForms?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700009')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700009', N'/v4/records/{recordId}/customForms/{formId}/meta', N'GET', N'/v4/records/{recordId}/customForms/{formId}/meta?lang={lang}', N'get_record_customform_meta', N'Get Record custom Form Meta', N'Get Record custom Form Meta', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/customForms/{formId}/meta?lang={lang}', N'getRecordc', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700010')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700010', N'/v4/settings/drillDowns/{drillId}', N'GET', N'/v4/settings/drillDowns/{drillId}?lang={lang}&parentValue={parentValue}', N'get_settings_drilldown', N'Get Drilldown', N'Get Drilldown', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/drillDown/{drillId}?lang={lang}&parentValue={parentValue}', N'getDrillDo', N'All', N'7.3.1', NULL, N'Settings', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700011')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700011', N'/v4/records/{recordId}/parcels', N'GET', N'/v4/records/{recordId}/parcels?lang={lang}', N'get_record_parcels', N'Get Record Parcels', N'Get Record Parcels', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/parcels?lang={lang}', N'getRecordP', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700012')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700012', N'/v4/records/{recordId}/parcels', N'POST', N'/v4/records/{recordId}/parcels?lang={lang}', N'create_record_parcels', N'Create Record Parcels', N'Create Record Parcels', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/parcels?lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700013')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700013', N'/v4/records/{recordId}/parcels/{id}', N'PUT', N'/v4/records/{recordId}/parcels/{id}?lang={lang}', N'update_record_parcel', N'Update Record Parcel', N'Update Record Parcel', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/parcels/{id}?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700014')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700014', N'/v4/records/{recordId}/parcels/{ids}', N'DELETE', N'/v4/records/{recordId}/parcels/{ids}?lang={lang}', N'delete_record_parcels', N'Delete Record Parcels', N'Delete Record Parcels', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/parcels/{ids}?lang={lang}', N'deleteReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700015')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700015', N'/v4/parcels/{id}/addresses', N'GET', N'/v4/parcels/{id}/addresses?lang={lang}', N'get_parcel_addresses', N'Get Parcel Addresses', N'Get Parcel Addresses', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/parcels/{id}/addresses?lang={lang}', N'getParcelA', N'All', N'7.3.1', NULL, N'Parcels', N'0006R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700016')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700016', N'/v4/parcels/{id}/owners', N'GET', N'/v4/parcels/{id}/owners?lang={lang}', N'get_parcel_owners', N'Get Parcel Owners', N'Get Parcel Owners', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/parcels/{id}/owners?lang={lang}', N'getParcelO', N'All', N'7.3.1', NULL, N'Parcels', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700017')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700017', N'/v4/parcels', N'GET', N'/v4/parcels?streetStart={streetStart}&section={section}&streetName={streetName}&streetType={streetType}&range={range}&isPrimary={isPrimary}&fullName={fullName}&city={city}&township={township}&parcelNumber={parcelNumber}&streetEnd={streetEnd}&lot={lot}&offset={offset}&limit={limit}&lang={lang}', N'get_parcels', N'Get Parcels', N'Get Parcels', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/parcels?streetStart={streetStart}&section={section}&streetName={streetName}&streetType={streetType}&range={range}&isPrimary={isPrimary}&fullName={fullName}&city={city}&township={township}&parcelNumber={parcelNumber}&streetEnd={streetEnd}&lot={lot}&offset={offset}&limit={limit}&lang={lang}', N'getParcels', N'All', N'7.3.1', NULL, N'Parcels', N'0005R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700018')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700018', N'/v4/parcels/{id}', N'GET', N'/v4/parcels/{id}?lang={lang}', N'get_parcel', N'Get Parcel', N'Get Parcel', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/parcels/{id}?lang={lang}', N'getParcel', N'All', N'7.3.1', NULL, N'Parcels', N'0005R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700019')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700019', N'/v4/records/{recordId}/additional', N'GET', N'/v4/records/{recordId}/additional?lang={lang}', N'get_record_additional', N'Get Record Additional', N'Get Record Additional', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/additional?lang={lang}', N'getRecordA', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700020')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700020', N'/v4/records/{recordId}/additional', N'PUT', N'/v4/records/{recordId}/additional?lang={lang}', N'update_record_additional', N'Update Record Additional', N'Update Record Additional', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/additional?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700021')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700021', N'/v4/records/{recordId}/comments', N'GET', N'/v4/records/{recordId}/comments?lang={lang}', N'get_record_comments', N'Get Record Comments', N'Get Record Comments', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/comments?lang={lang}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700022')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700022', N'/v4/records/{recordId}/comments/{id}', N'PUT', N'/v4/records/{recordId}/comments/{id}?lang={lang}', N'update_record_comment', N'Update Record Comment', N'Update Record Comment', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/comments/{id}?lang={lang}', N'updateReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700023')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700023', N'/v4/records/{recordId}/comments/{ids}', N'DELETE', N'/v4/records/{recordId}/comments/{ids}?lang={lang}', N'delete_record_comments', N'Delete Record Comments', N'Delete Record Comments', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/comments/{ids}?lang={lang}', N'deleteReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700024')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700024', N'/v4/records/{recordId}/comments', N'POST', N'/v4/records/{recordId}/comments?lang={lang}', N'create_record_comments', N'Create Record Comments', N'Create Record Comments', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/comments?lang={lang}', N'createReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700025')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700025', N'/v4/records', N'POST', N'/v4/records?lang={lang}', N'create_record', N'Create Record', N'Create Record', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records?lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700026')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700026', N'/v4/records/initialize', N'POST', N'/v4/records/initialize?lang={lang}&isFeeEstimate={isFeeEstimate}', N'create_partial_record', N'Create Partial Record', N'Create Partial Record', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/initialize?lang={lang}&isFeeEstimate={isFeeEstimate}', N'createPart', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700027')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700027', N'/v4/records/{recordId}/finalize', N'POST', N'/v4/records/{recordId}/finalize?lang={lang}', N'finalize_record', N'Finalize Record', N'Finalize Record', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/finalize?lang={lang}', N'finalizeRe', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700028')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700028', N'/v4/records/{ids}', N'GET', N'/v4/records/{ids}?lang={lang}', N'get_record', N'Get Record', N'Get Record', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{ids}?lang={lang}', N'getRecord', N'All', N'7.3.1', NULL, N'Records', N'8411R||8395R||8209R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700029')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700029', N'/v4/records', N'GET', N'/v4/records?type={type}&openDateFrom={openDateFrom}&openDateTo={openDateTo}&customId={customId}&module={module}&status={status}&statusDateFrom={statusDateFrom}&statusDateTo={statusDateTo}&assignDateFrom={assignDateFrom}&assignDateTo={assignDateTo}&completeDateFrom={completeDateFrom}&completeDateTo={completeDateTo}&completeDepartment={completeDepartment}&completeStaff={completeStaff}&closedDateFrom={closedDateFrom}&closedDateTo={closedDateTo}&closedDepartment={closedDepartment}&closedStaff={closedStaff}&limit={limit}&offset={offset}&fields={fields}&lang={lang}', N'get_records', N'Get Records', N'Get Records', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records?type={type}&openDateFrom={openDateFrom}&openDateTo={openDateTo}&customId={customId}&module={module}&status={status}&statusDateFrom={statusDateFrom}&statusDateTo={statusDateTo}&assignDateFrom={assignDateFrom}&assignDateTo={assignDateTo}&completeDateFrom={completeDateFrom}&completeDateTo={completeDateTo}&completeDepartment={completeDepartment}&completeStaff={completeStaff}&closedDateFrom={closedDateFrom}&closedDateTo={closedDateTo}&closedDepartment={closedDepartment}&closedStaff={closedStaff}&limit={limit}&offset={offset}&fields={fields}&lang={lang}', N'getRecords', N'All', N'7.3.1', NULL, N'Records', N'8411R||8395R||8209R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700030')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700030', N'/v4/records/mine', N'GET', N'/v4/records/mine?lang={lang}&&type={type}&openedDateFrom={openedDateFrom}&openedDateTo={openedDateTo}&customId={customId}&module={module}&status={status}&assignedDateFrom={assignedDateFrom}&assignedDateTo={assignedDateTo}&completedDateFrom={completedDateFrom}&completedDateTo={completedDateTo}&completedByDepartment={completedByDepartment}&completedByStaff={completedByStaff}&closedDateFrom={closedDateFrom}&closedDateTo={closedDateTo}&closedByDepartment={closedByDepartment}&closedByStaff={closedByStaff}&limit={limit}&offset={offset}', N'get_my_records', N'Get My Records', N'Get My Records', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/mine?lang={lang}&&type={type}&openedDateFrom={openedDateFrom}&openedDateTo={openedDateTo}&customId={customId}&module={module}&status={status}&assignedDateFrom={assignedDateFrom}&assignedDateTo={assignedDateTo}&completedDateFrom={completedDateFrom}&completedDateTo={completedDateTo}&completedByDepartment={completedByDepartment}&completedByStaff={completedByStaff}&closedDateFrom={closedDateFrom}&closedDateTo={closedDateTo}&closedByDepartment={closedByDepartment}&closedByStaff={closedByStaff}&limit={limit}&offset={offset}', N'getMyRecor', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700031')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700031', N'/v4/records/{recordIds}/inspectionTypes', N'GET', N'/v4/records/{recordIds}/inspectionTypes?lang={lang}', N'get_record_inspection_types', N'Get Record Inspection Types', N'Get Record Inspection Types', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordIds}/inspectionTypes?lang={lang}', N'getRecordI', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700032')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700032', N'/v4/records/{recordId}/inspections', N'GET', N'/v4/records/{recordId}/inspections?lang={lang}&offset={offset}&limit={limit}', N'get_record_inspections', N'Get Record Inspections', N'Get Record Inspections', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/inspections?lang={lang}&offset={offset}&limit={limit}', N'getRecordI', N'All', N'7.3.1', NULL, N'Records', N'(8411R||8395R||8209R) && 8145F && 8144F')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700033')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700033', N'/v4/records/{recordId}/documentCategories', N'GET', N'/v4/records/{recordId}/documentCategories?lang={lang}', N'get_record_document_categories', N'Get Record Document Categories', N'Get Record Document Categories', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/documentCategories?lang={lang}', N'getRecordD', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700034')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700034', N'/v4/records/{id}', N'PUT', N'/v4/records/{id}?lang={lang}', N'update_record', N'Update Record Detail', N'Update Record Detail', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{id}?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700035')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700035', N'/v4/settings/records/types/{id}/customForms', N'GET', N'/v4/settings/records/types/{id}/customForms?lang={lang}', N'get_settings_record_type_customform', N'Get Record Type Custom Forms', N'Get Record Type Custom Forms', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/records/types/{id}/customForms?lang={lang}', N'getRecordT', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700036')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700036', N'/v4/settings/records/types/{id}/customTables', N'GET', N'/v4/settings/records/types/{id}/customTables?lang={lang}', N'get_settings_record_type_customtable', N'Get Record Type Custom Tables', N'Get Record Type Custom Tables', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/records/types/{id}/customTables?lang={lang}', N'getRecordT', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700037')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700037', N'/v4/settings/records/constructionTypes', N'GET', N'/v4/settings/records/constructionTypes?lang={lang}', N'get_settings_construction_types', N'Get Record Construction Types', N'Get Record Construction Types', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/records/constructionTypes?lang={lang}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700038')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700038', N'/v4/settings/records/types', N'GET', N'/v4/settings/records/types?lang={lang}', N'get_settings_record_types', N'Get Record Types', N'Get Record Types', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/records/types?lang={lang}', N'getRecordT', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700039')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700039', N'/v4/records/{recordId}/fees', N'GET', N'/v4/records/{recordId}/fees?lang={lang}&fields={fields}&status={status}', N'get_record_fees', N'Get Record Fees', N'Get Record Fees', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/fees?lang={lang}&fields={fields}&status={status}', N'getRecordF', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700040')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700040', N'/v4/inspectors', N'GET', N'/v4/inspectors?lang={lang}&department={department}', N'get_inspectors', N'Get Inspectors', N'Get Inspectors', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspector?lang={lang}&department={department}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700041')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700041', N'/v4/inspectors/{id}', N'GET', N'/v4/inspectors/{id}?lang={lang}', N'get_inspector', N'Get Inspector', N'Get Inspector', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspector/{id}?lang={lang}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700042')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700042', N'/v4/reports/{reportId}', N'POST', N'/v4/reports/{reportId}?lang={lang}&module={module}', N'create_report', N'Create Report', N'Create report by specific report id and paramters.', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/reports/{reportId}?lang={lang}&module={module}', N'createRepo', N'All', N'7.3.1', NULL, N'Reports', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700043')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700043', N'/v4/settings/reports/categories', N'GET', N'/v4/settings/reports/categories?lang={lang}&fields={fields}', N'get_settings_report_categories', N'Get Report Categories', N'Returns a list of report category.', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/reports/categories?lang={lang}&fields={fields}', N'getReportC', N'All', N'7.3.1', NULL, N'Reports', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700044')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700044', N'/v4/settings/reports/definitions', N'GET', N'/v4/settings/reports/definitions?lang={lang}&fields={fields}&category={category}&module={module}', N'get_settings_report_definitions', N'Get Reports Definition', N'Returns the definition of all reports.', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/reports/describe?lang={lang}&fields={fields}&category={category}&module={module}', N'getReports', N'All', N'7.3.1', NULL, N'Reports', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700045')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700045', N'/v4/settings/reports/definitions/{reportId}', N'GET', N'/v4/settings/reports/definitions/{reportId}?lang={lang}&fields={fields}', N'get_settings_report_definition', N'Get Report Definition', N'Returns the definition of a given report.', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/reports/describe/{reportId}?lang={lang}&fields={fields}', N'getReportD', N'All', N'7.3.1', NULL, N'Reports', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700046')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700046', N'/v4/scripts/{id}', N'POST', N'/v4/scripts/{id}?lang={lang}', N'run_emse_script', N'Run EMSE Script', N'Run EMSE Script', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/scripts/{id}?lang={lang}', N'runEMSEScr', N'Agency', N'7.3.1', NULL, N'Scripts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700047')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700047', N'/v4/inspections/{inspectionId}/timeAccounting', N'GET', N'/v4/inspections/{inspectionId}/timeAccounting?lang={lang}', N'get_inspection_timeaccounting', N'Get Inspection Time Accounting Entries', N'Get Inspection Time Accounting Entries', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/timeAccounting?lang={lang}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700048')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700048', N'/v4/inspections/{inspectionId}/timeAccounting', N'POST', N'/v4/inspections/{inspectionId}/timeAccounting?lang={lang}', N'create_inspection_timeaccounting', N'Create Inspection Time Accounting Entries', N'Create Inspection Time Accounting Entries', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/timeAccounting?lang={lang}', N'createInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700049')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700049', N'/v4/inspections/{inspectionId}/timeAccounting/{ids}', N'DELETE', N'/v4/inspections/{inspectionId}/timeAccounting/{ids}?lang={lang}', N'delete_inspection_timeaccounting', N'Delete Inspection Time Accounting Entries', N'Delete Inspection Time Accounting Entries', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/timeAccounting/{ids}?lang={lang}', N'deleteInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700050')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700050', N'/v4/inspections/{inspectionId}/timeAccounting/{id}', N'PUT', N'/v4/inspections/{inspectionId}/timeAccounting/{id}?lang={lang}', N'update_inspection_timeaccounting', N'Update Inspection Time Accounting Entries', N'Update Inspection Time Accounting Entries', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/timeAccounting/{id}?lang={lang}', N'updateInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700053')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700053', N'/v4/records/{recordId}/workflowTasks', N'GET', N'/v4/records/{recordId}/workflowTasks?lang={lang}&fields={fields}', N'get_record_workflow_tasks', N'Get Workflow Tasks', N'Get Workflow Tasks', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/workflowTasks?lang={lang}&fields={fields}', N'getWorkflo', N'All', N'7.3.1', NULL, N'Records', N'8132R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700054')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700054', N'/v4/records/{recordId}/workflowTasks/{id}', N'GET', N'/v4/records/{recordId}/workflowTasks/{id}?lang={lang}&fields={fields}', N'get_record_workflow_task', N'Get Workflow Task', N'Get Workflow Task', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/workflowTasks/{id}?lang={lang}&fields={fields}', N'getWorkflo', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700055')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700055', N'/v4/records/{recordId}/workflowTasks/{id}', N'PUT', N'/v4/records/{recordId}/workflowTasks/{id}?lang={lang}&fields={fields}', N'update_record_workflow_task', N'Update Workflow Task', N'Update Workflow Task', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/workflowTasks/{id}?lang={lang}&fields={fields}', N'updateWork', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700056')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700056', N'/v4/workflowTasks/mine', N'GET', N'/v4/workflowTasks/mine?lang={lang}&offset={offset}&limit={limit}&fields={fields}', N'get_my_workflow_tasks', N'Get My Workflow Tasks', N'Get My Workflow Tasks', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/workflowTasks/mine?lang={lang}&offset={offset}&limit={limit}&fields={fields}', N'getMyWorkf', N'Agency', N'7.3.1', NULL, N'Work Flow', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700057')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700057', N'/v4/search/contacts', N'POST', N'/v4/search/contacts?lang={lang}&offset={offset}&limit={limit}', N'search_contacts', N'Search Contacts', N'Search Contacts', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/search/contacts?lang={lang}&offset={offset}&limit={limit}', N'searchCont', N'All', N'7.3.1', NULL, N'Searches', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700058')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700058', N'/v4/search/global', N'GET', N'/v4/search/global?lang={lang}&query={query}&type={type}&modules={modules}&offset={offset}&limit={limit}&sort={sort}&direction={direction}', N'global_search', N'Global Search', N'Global Search API allow user to search various resource by unique interface.', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/search/global?lang={lang}&query={query}&type={type}&modules={modules}&offset={offset}&limit={limit}&sort={sort}&direction={direction}', N'globalSear', N'All', N'7.3.1', NULL, N'Searches', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700059')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700059', N'/v4/search/inspections', N'POST', N'/v4/search/inspections?limit={limit}&offset={offset}&fields={fields}&lang={lang}&sort={sort}&direction={direction}&hasTotal={hasTotal}&fields={fields}', N'search_inspections', N'Search Inspections', N'Search Inspections', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/search/inspections?limit={limit}&offset={offset}&fields={fields}&lang={lang}&sort={sort}&direction={direction}&hasTotal={hasTotal}&fields={fields}', N'searchInsp', N'All', N'7.3.1', NULL, N'Searches', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700060')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700060', N'/v4/search/records', N'POST', N'/v4/search/records?lang={lang}&offset={offset}&limit={limit}&fields={fields}&sort={sort}&direction={direction}', N'search_records', N'Search Records', N'Search Records', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/search/records?lang={lang}&offset={offset}&limit={limit}&fields={fields}&sort={sort}&direction={direction}', N'searchReco', N'All', N'7.3.1', NULL, N'Searches', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700061')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700061', N'/v4/search/owners', N'POST', N'/v4/search/owners?lang={lang}&offset={offset}&limit={limit}&fields={fields}', N'search_owners', N'Search Owners', N'Search Owners', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/search/owners?lang={lang}&offset={offset}&limit={limit}&fields={fields}', N'searchOwne', N'All', N'7.3.1', NULL, N'Searches', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700062')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700062', N'/v4/search/professionals', N'POST', N'/v4/search/professionals?lang={lang}&offset={offset}&limit={limit}&fields={fields}', N'search_professionals', N'Search Professionals', N'Search  Professionals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/search/professionals?lang={lang}&offset={offset}&limit={limit}&fields={fields}', N'searchProf', N'All', N'7.3.1', NULL, N'Searches', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700063')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700063', N'/v4/search/parcels', N'POST', N'/v4/search/parcels?lang={lang}&offset={offset}&limit={limit}', N'search_parcels', N'Search Parcels', N'Search Parcels', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/search/parcels?lang={lang}&offset={offset}&limit={limit}', N'searchParc', N'All', N'7.3.1', NULL, N'Searches', N'0005R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700064')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700064', N'/v4/search/addresses', N'POST', N'/v4/search/addresses?lang={lang}&offset={offset}&limit={limit}', N'search_addresses', N'Search Addresses', N'Search Addresses', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/search/addresses?lang={lang}&offset={offset}&limit={limit}', N'searchAddr', N'All', N'7.3.1', NULL, N'Searches', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700065')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700065', N'/v4/documents/{documentId}/download', N'GET', N'/v4/documents/{documentId}/download?lang={lang}&password={password}&userId={userId}', N'download_document', N'Download document', N'Download document', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/documents/{documentId}/download?lang={lang}&password={password}&userId={userId}', N'downloadDo', N'All', N'7.3.1', NULL, N'Documents', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700066')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700066', N'/v4/documents/{documentIds}', N'GET', N'/v4/documents/{documentIds}?lang={lang}&fields={fields}', N'get_document', N'Get Document', N'Get Document', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/documents/{documentIds}?lang={lang}&fields={fields}', N'getDocumen', N'All', N'7.3.1', NULL, N'Documents', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700067')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700067', N'/v4/settings/documents/categories', N'GET', N'/v4/settings/documents/categories?lang={lang}', N'get_settings_document_categories', N'Get Document Categories', N'Get Document Categories', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/settings/documents/categories?lang={lang}', N'getDocumen', N'All', N'7.3.1', NULL, N'Documents', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700068')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700068', N'/v4/records/{recordId}/documents', N'POST', N'/v4/records/{recordId}/documents?userId={userId}&password={password}&lang={lang}', N'create_record_documents', N'Create Record Document', N'Create Record Document', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/documents?group={group}&category={category}&userId={userId}&password={password}&lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700069')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700069', N'/v4/records/{recordId}/documents', N'GET', N'/v4/records/{recordId}/documents?fields={fields}&lang={lang}', N'get_record_documents', N'Get Record Documents', N'Get Record Documents', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/documents?lang={lang}&fields={fields}', N'getRecordD', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700070')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700070', N'/v4/records/{recordId}/documents/{documentIds}', N'DELETE', N'/v4/records/{recordId}/documents/{documentIds}?userId={userId}&password={password}&lang={lang}', N'delete_record_document', N'Delete Record Document', N'Delete Record Document', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/documents/{documentIds}?userId={userId}&password={password}&lang={lang}', N'deleteReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700071')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700071', N'/v4/settings/conditions/types', N'GET', N'/v4/settings/conditions/types?lang={lang}', N'get_settings_condition_types', N'Get Condition Types', N'Get Condition Types', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/settings/conditions/types?lang={lang}', N'getConditi', N'Agency', N'7.3.1', NULL, N'Conditions', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700072')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700072', N'/v4/settings/conditions/statuses', N'GET', N'/v4/settings/conditions/statuses?lang={lang}', N'get_settings_condition_statuses', N'Get Condition Statuses', N'Get Condition Statuses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/settings/conditions/statuses?lang={lang}', N'getConditi', N'Agency', N'7.3.1', NULL, N'Conditions', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700073')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700073', N'/v4/settings/conditionApprovals/statuses', N'GET', N'/v4/settings/conditionApprovals/statuses?lang={lang}', N'get_settings_condition_approval_statuses', N'Get Condition Approval Statuses', N'Get Condition Approval Statuses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/conditionApprovals/statuses?lang={lang}', N'getConditi', N'Agency', N'7.3.1', NULL, N'Conditions', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700074')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700074', N'/v4/settings/conditions/priorities', N'GET', N'/v4/settings/conditions/priorities?lang={lang}', N'get_settings_condition_priorities', N'Get Condition Priorities', N'Get Condition Priorities', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/settings/conditions/priorities?lang={lang}', N'getConditi', N'Agency', N'7.3.1', NULL, N'Conditions', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700075')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700075', N'/v4/inspections/{inspectionId}/conditionApprovals', N'GET', N'/v4/inspections/{inspectionId}/conditionApprovals?lang={lang}&isNeedNoticeInfo={isNeedNoticeInfo}&effectiveDate={effectiveDate}&expirationDate={expirationDate}&fields={fields}', N'get_inspection_condition_approvals', N'Get Inspection Condition Approvals', N'Get Inspection Condition Approvals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditionApprovals?lang={lang}&isNeedNoticeInfo={isNeedNoticeInfo}&effectiveDate={effectiveDate}&expirationDate={expirationDate}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700076')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700076', N'/v4/inspections/{inspectionId}/conditionApprovals/{id}', N'GET', N'/v4/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}&fields={fields}', N'get_inspection_condition_approval', N'Get Inspection Condition Approval', N'Get Inspection Condition Approval', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700077')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700077', N'/v4/inspections/{inspectionId}/conditionApprovals', N'POST', N'/v4/inspections/{inspectionId}/conditionApprovals?lang={lang}', N'create_inspection_condition_approvals', N'Create Inspection Condition Approvals', N'Create Inspection Condition Approvals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditionApprovals?lang={lang}', N'createinsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700078')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700078', N'/v4/inspections/{inspectionId}/conditionApprovals/{id}', N'PUT', N'/v4/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}', N'update_inspection_condition_approval', N'Update Inspection Condition Approval', N'Update Inspection Condition Approval', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditionApprovals/{id}?lang={lang}', N'updateinsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700079')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700079', N'/v4/inspections/{inspectionId}/conditionApprovals/{ids}', N'DELETE', N'/v4/inspections/{inspectionId}/conditionApprovals/{ids}?lang={lang}', N'delete_inspection_condition_approvals', N'Delete Inspection Condition Approvals', N'Delete Inspection Condition Approvals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditionApprovals/{ids}?lang={lang}', N'deleteInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700080')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700080', N'/v4/inspections/{inspectionId}/conditions', N'GET', N'/v4/inspections/{inspectionId}/conditions?lang={lang}&fields={fields}', N'get_inspection_conditions', N'Get Inspection Conditions', N'Get Inspection Conditions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditions?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700081')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700081', N'/v4/inspections/{inspectionId}/conditions/{id}', N'GET', N'/v4/inspections/{inspectionId}/conditions/{id}?lang={lang}&fields={fields}', N'get_inspection_condition', N'Get Inspection Condition ', N'Get Inspection Condition ', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditions/{id}?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700082')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700082', N'/v4/inspections/{inspectionId}/conditions', N'POST', N'/v4/inspections/{inspectionId}/conditions?lang={lang}', N'create_inspection_conditions', N'Create Inspection Conditions', N'Create Inspection Conditions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditions?lang={lang}', N'createinsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700083')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700083', N'/v4/inspections/{inspectionId}/conditions/{id}', N'PUT', N'/v4/inspections/{inspectionId}/conditions/{id}?lang={lang}', N'update_inspection_condition', N'Update Inspection Condition', N'Update Inspection Condition', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditions/{id}?lang={lang}', N'updateinsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700084')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700084', N'/v4/inspections/{inspectionId}/conditions/{ids}', N'DELETE', N'/v4/inspections/{inspectionId}/conditions/{ids}?lang={lang}', N'delete_inspection_conditions', N'Delete Inspection Conditions', N'Delete Inspection Conditions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditions/{ids}?lang={lang}', N'deleteInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700085')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700085', N'/v4/inspections/{inspectionId}/conditions/{id}/histories', N'GET', N'/v4/inspections/{inspectionId}/conditions/{id}/histories?lang={lang}&fields={fields}', N'get_inspection_condition_histories', N'Get Inspection Condition Histories', N'Get Inspection Condition Histories', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/conditions/{id}/histories?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700086')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700086', N'/v4/records/{recordId}/conditionApprovals', N'POST', N'/v4/records/{recordId}/conditionApprovals?lang={lang}', N'create_record_condition_approvals', N'Create Record Condition Approvals', N'Create Record Condition Approvals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditionApprovals?lang={lang}', N'createReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700087')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700087', N'/v4/records/{recordId}/conditionApprovals/{ids}', N'DELETE', N'/v4/records/{recordId}/conditionApprovals/{ids}?lang={lang}', N'delete_record_condition_approvals', N'Delete Record Condition Approvals', N'Delete Record Condition Approvals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditionApprovals/{ids}?lang={lang}', N'deleteReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700088')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700088', N'/v4/records/{recordId}/conditionApprovals', N'GET', N'/v4/records/{recordId}/conditionApprovals?lang={lang}&fields={fields}', N'get_record_condition_approvals', N'Get Record Condition Approvals', N'Get Record Condition Approvals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditionApprovals?lang={lang}&fields={fields}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700089')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700089', N'/v4/records/{recordId}/conditionApprovals/{id}', N'GET', N'/v4/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}', N'get_record_condition_approval', N'Get Record Condition Approval', N'Get Record Condition Approval', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700090')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700090', N'/v4/records/{recordId}/conditionApprovals/{id}', N'PUT', N'/v4/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}', N'update_record_condition_approval', N'Update Record Condition Approval', N'Update Record Condition Approval', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditionApprovals/{id}?lang={lang}&fields={fields}', N'updateReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700091')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700091', N'/v4/records/{recordId}/conditions', N'GET', N'/v4/records/{recordId}/conditions?lang={lang}&fields={fields}', N'get_record_conditions', N'Get Record Conditions', N'Get Record Conditions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditions?lang={lang}&fields={fields}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700092')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700092', N'/v4/records/{recordId}/conditions/{id}', N'GET', N'/v4/records/{recordId}/conditions/{id}?lang={lang}&fields={fields}', N'get_record_condition', N'Get Record Condition', N'Get Record Condition', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditions/{id}?lang={lang}&fields={fields}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700093')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700093', N'/v4/records/{recordId}/conditions', N'POST', N'/v4/records/{recordId}/conditions?lang={lang}', N'create_record_conditions', N'Create Record Conditions', N'Create Record Conditions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditions?lang={lang}', N'createReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700094')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700094', N'/v4/records/{recordId}/conditions/{id}', N'PUT', N'/v4/records/{recordId}/conditions/{id}?lang={lang}', N'update_record_condition', N'Update Record Condition', N'Update Record Condition', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditions/{id}?lang={lang}', N'updateReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700095')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700095', N'/v4/records/{recordId}/conditions/{ids}', N'DELETE', N'/v4/records/{recordId}/conditions/{ids}?lang={lang}', N'delete_record_conditions', N'Delete Record Conditions', N'Delete Record Conditions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/records/{recordId}/conditions/{ids}?lang={lang}', N'deleteReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700096')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700096', N'/v4/conditionApprovals/standard', N'GET', N'/v4/conditionApprovals/standard?lang={lang}&type={type}&group={group}&name={name}&severity={severity}&publicDisplayMessage={publicDisplayMessage}&inheritable={inheritable}&priority={priority}&shortComments={shortComments}&longComments={longComments}&resolutionAction={resolutionAction}&includeNameInNotice={includeNameInNotice}&includeShortCommentsInNotice={includeShortCommentsInNotice}&displayNoticeInAgency={displayNoticeInAgency}&displayNoticeInCitizens={displayNoticeInCitizens}&displayNoticeInCitizensFee={displayNoticeInCitizensFee}&offset={offset}&limit={limit}&sort={sort}&direction={direction}&fields={fields}', N'get_condition_approvals_standard', N'Get Standard Condition Approvals', N'Get Standard Condition Approvals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/conditionApprovals/standard?lang={lang}&type={type}&group={group}&name={name}&severity={severity}&publicDisplayMessage={publicDisplayMessage}&inheritable={inheritable}&priority={priority}&shortComments={shortComments}&longComments={longComments}&resolutionAction={resolutionAction}&includeNameInNotice={includeNameInNotice}&includeShortCommentsInNotice={includeShortCommentsInNotice}&displayNoticeInAgency={displayNoticeInAgency}&displayNoticeInCitizens={displayNoticeInCitizens}&displayNoticeInCitizensFee={displayNoticeInCitizensFee}&offset={offset}&limit={limit}&sort={sort}&direction={direction}&fields={fields}', N'getStandar', N'Agency', N'7.3.1', NULL, N'Conditions', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700097')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700097', N'/v4/conditions/standard', N'GET', N'/v4/conditions/standard?lang={lang}&type={type}&group={group}&name={name}&severity={severity}&publicDisplayMessage={publicDisplayMessage}&inheritable={inheritable}&priority={priority}&shortComments={shortComments}&longComments={longComments}&resolutionAction={resolutionAction}&includeNameInNotice={includeNameInNotice}&includeShortCommentsInNotice={includeShortCommentsInNotice}&displayNoticeInAgency={displayNoticeInAgency}&displayNoticeInCitizens={displayNoticeInCitizens}&displayNoticeInCitizensFee={displayNoticeInCitizensFee}&offset={offset}&limit={limit}&sort={sort}&direction={direction}&fields={fields}', N'get_conditions_standard', N'Get Standard Conditions', N'Get Standard Conditions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/conditions/standard?lang={lang}&type={type}&group={group}&name={name}&severity={severity}&publicDisplayMessage={publicDisplayMessage}&inheritable={inheritable}&priority={priority}&shortComments={shortComments}&longComments={longComments}&resolutionAction={resolutionAction}&includeNameInNotice={includeNameInNotice}&includeShortCommentsInNotice={includeShortCommentsInNotice}&displayNoticeInAgency={displayNoticeInAgency}&displayNoticeInCitizens={displayNoticeInCitizens}&displayNoticeInCitizensFee={displayNoticeInCitizensFee}&offset={offset}&limit={limit}&sort={sort}&direction={direction}&fields={fields}', N'getStandar', N'Agency', N'7.3.1', NULL, N'Conditions', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700098')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700098', N'/v4/records/{recordId}/contacts', N'GET', N'/v4/records/{recordId}/contacts?lang={lang}&fields={fields}', N'get_record_contacts', N'Get Record Contacts', N'Get Record Contacts', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/contacts?lang={lang}&fields={fields}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', N'(8411R||8395R||8209R) && 8031R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700099')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700099', N'/v4/settings/contacts/types', N'GET', N'/v4/settings/contacts/types?lang={lang}&module={module}', N'get_settings_contact_types', N'Get Contact Types', N'Get Contact Types', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/contacts/types?lang={lang}&module={module}', N'getContact', N'All', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700100')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700100', N'/v4/settings/contacts/relations', N'GET', N'/v4/settings/contacts/relations?lang={lang}', N'get_settings_contact_relations', N'Get Contact Relations', N'Get Contact Relations', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/contacts/relations?lang={lang}', N'getContact', N'All', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700101')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700101', N'/v4/settings/contacts/salutations', N'GET', N'/v4/settings/contacts/salutations?lang={lang}', N'get_settings_contact_salutations', N'Get Contact Salutations', N'Get Contact Salutations', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/contacts/salutations?lang={lang}', N'getContact', N'All', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700102')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700102', N'/v4/settings/contacts/races', N'GET', N'/v4/settings/contacts/races?lang={lang}', N'get_settings_contact_races', N'Get Contact Races', N'Get Contact Races', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/contacts/races?lang={lang}', N'getContact', N'All', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700103')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700103', N'/v4/settings/contacts/preferredChannels', N'GET', N'/v4/settings/contacts/preferredChannels?lang={lang}', N'get_settings_contact_preferredChannels', N'Get Contact Preferred Channels', N'Get Contact Preferred Channels', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/contacts/preferredChannels?lang={lang}', N'getContact', N'All', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700104')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700104', N'/v4/contacts/{ids}', N'GET', N'/v4/contacts/{ids}?lang={lang}&fields={fields}', N'get_contact', N'Get Contacts', N'Get Contacts', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/contacts/{ids}?lang={lang}&fields={fields}', N'getContact', N'All', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700105')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700105', N'/v4/contacts', N'POST', N'/v4/contacts?lang={lang}', N'create_contacts', N'Create Contacts', N'Create Contacts', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/contacts?lang={lang}', N'createCont', N'All', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700106')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700106', N'/v4/contacts/{id}', N'PUT', N'/v4/contacts/{id}?lang={lang}', N'update_contact', N'Update Contact', N'Update Contact', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/contacts/{id}?lang={lang}', N'updateCont', N'Agency', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700107')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700107', N'/v4/contacts/{ids}', N'DELETE', N'/v4/contacts/{ids}?lang={lang}', N'delete_contacts', N'Delete Contacts', N'Delete Contacts', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/contacts/{ids}?lang={lang}', N'deleteCont', N'Agency', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700108')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700108', N'/v4/contacts/{id}/addresses', N'POST', N'/v4/contacts/{id}/addresses?lang={lang}', N'create_contact_addresses', N'Create Contact Addresses', N'Create Contact Addresses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/contacts/{id}/addresses?lang={lang}', N'createCont', N'Agency', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700109')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700109', N'/v4/contacts/{id}/addresses', N'GET', N'/v4/contacts/{id}/addresses?lang={lang}&fields={fields}&offset={offset}&limit={limit}', N'get_contact_addresses', N'Get Contact Addresses', N'Get Contact Addresses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/contacts/{id}/addresses?lang={lang}&fields={fields}&offset={offset}&limit={limit}', N'getContact', N'All', N'7.3.1', NULL, N'Contacts', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700110')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700110', N'/v4/records/{recordId}/contacts', N'POST', N'/v4/records/{recordId}/contacts?lang={lang}&fields={fields}', N'create_record_contacts', N'Create Record Contacts', N'Create Record Contacts', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/contacts?lang={lang}&fields={fields}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700111')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700111', N'/v4/records/{recordId}/contacts/{id}', N'PUT', N'/v4/records/{recordId}/contacts/{id}?lang={lang}&fields={fields}', N'update_record_contact', N'Update Record Contact', N'Update Record Contact', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/contacts/{id}?lang={lang}&fields={fields}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700112')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700112', N'/v4/records/{recordId}/contacts/{ids}', N'DELETE', N'/v4/records/{recordId}/contacts/{ids}?lang={lang}&fields={fields}', N'delete_record_contacts', N'Delete Record Contacts', N'Delete Record Contacts', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/contacts/{ids}?lang={lang}&fields={fields}', N'deleteReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700113')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700113', N'/v4/owners', N'GET', N'/v4/owners?fullName={fullName}&firstName={firstName}&lastName={lastName}&parcelId={parcelId}&email={email}&city={city}&state={state}&country={country}&limit={limit}&offset={offset}&fields={fields}&lang={lang}', N'get_owners', N'Get Owners', N'Get Owners', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/owners?fullName={fullName}&firstName={firstName}&lastName={lastName}&parcelId={parcelId}&email={email}&city={city}&state={state}&country={country}&limit={limit}&offset={offset}&fields={fields}&lang={lang}', N'getOwners', N'All', N'7.3.1', NULL, N'Owners', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700114')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700114', N'/v4/owners/{id}', N'GET', N'/v4/owners/{id}?lang={lang}&fields={fields}', N'get_owner', N'Get Owner', N'Get Owner', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/owners/{id}?lang={lang}&fields={fields}', N'getOwner', N'All', N'7.3.1', NULL, N'Owners', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700115')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700115', N'/v4/records/{recordId}/owners', N'GET', N'/v4/records/{recordId}/owners?lang={lang}&fields={fields}', N'get_record_owners', N'Get Record Owners', N'Get Record Owners', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/owners?lang={lang}&fields={fields}', N'getRecordO', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700116')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700116', N'/v4/records/{recordId}/owners', N'POST', N'/v4/records/{recordId}/owners?lang={lang}', N'create_record_owners', N'Create Record Owners', N'Create Record Owners', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/owners?lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700117')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700117', N'/v4/records/{recordId}/owners/{id}', N'PUT', N'/v4/records/{recordId}/owners/{id}?lang={lang}', N'update_record_owner', N'Update Record Owner', N'Update Record Owner', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/owners/{id}?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700118')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700118', N'/v4/records/{recordId}/owners/{ids}', N'DELETE', N'/v4/records/{recordId}/owners/{ids}?lang={lang}', N'delete_record_owners', N'Delete Record Owners', N'Delete Record Owners', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/owners/{ids}?lang={lang}', N'deleteReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700119')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700119', N'/v4/records/{recordId}/professionals', N'GET', N'/v4/records/{recordId}/professionals?lang={lang}&fields={fields}', N'get_record_professionals', N'Get Record Licensed Professionals', N'Get Record Licensed Professionals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/professionals?lang={lang}&fields={fields}', N'getProfess', N'All', N'7.3.1', NULL, N'Records', N'(8411R||8395R||8209R) && 8032R')
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700120')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700120', N'/v4/records/{recordId}/professionals', N'POST', N'/v4/records/{recordId}/professionals?lang={lang}', N'create_record_professionals', N'Create Record Licensed Professionals', N'Create Record Licensed Professionals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/professionals?lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700121')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700121', N'/v4/records/{recordId}/professionals/{ids}', N'DELETE', N'/v4/records/{recordId}/professionals/{ids}?lang={lang}', N'delete_record_professionals', N'Delete Record Licensed Professionals', N'Delete Record Licensed Professionals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/professionals/{ids}?lang={lang}', N'deleteReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700122')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700122', N'/v4/records/{recordId}/professionals/{id}', N'PUT', N'/v4/records/{recordId}/professionals/{id}?lang={lang}', N'update_record_professional', N'Update Record Licensed Professionals', N'Update Record Licensed Professionals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/professionals/{id}?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700123')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700123', N'/v4/settings/professionals/types', N'GET', N'/v4/settings/professionals/types?lang={lang}', N'get_settings_professional_types', N'Get Professional Types', N'Get Professional Types', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/professionals/types?lang={lang}', N'getProfess', N'All', N'7.3.1', NULL, N'Professionals', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700124')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700124', N'/v4/settings/professionals/licenseBoards', N'GET', N'/v4/settings/professionals/licenseBoards?lang={lang}', N'get_settings_professional_license_boards', N'Get Professional License Boards', N'Get Professional License Boards', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/professionals/licenseBoards?lang={lang}', N'getProfess', N'All', N'7.3.1', NULL, N'Professionals', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700125')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700125', N'/v4/settings/professionals/salutations', N'GET', N'/v4/settings/professionals/salutations?lang={lang}', N'get_settings_professional_salutations', N'Get Professional Salutations', N'Get Professional Salutations', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/professionals/salutations?lang={lang}', N'getProfess', N'All', N'7.3.1', NULL, N'Professionals', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700126')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700126', N'/v4/professionals/{ids}', N'GET', N'/v4/professionals/{ids}?lang={lang}&fields={fields}', N'get_professional', N'Get Professional', N'Get Professional', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/professionals/{ids}?lang={lang}&fields={fields}', N'getProfess', N'All', N'7.3.1', NULL, N'Professionals', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700127')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700127', N'/v4/professionals', N'GET', N'/v4/professionals?lang={lang}&id={id}&licenseType={licenseType}&licenseNumber={licenseNumber}&licenseState={licenseState}&state={state}&country={country}&firstName={firstName}&middleName={middleName}&lastName={lastName}&email={email}&addressLine1={addressLine1}&addressLine2={addressLine2}&addressLine3={addressLine3}&businessLicense={businessLicense}&businessName={businessName}&city={city}&licenseExpirationDate={licenseExpirationDate}&licenseIssueDate={licenseIssueDate}&lastRenewalDate={lastRenewalDate}&title={title}&offset={offset}&limit={limit}&fields={fields}', N'get_professionals', N'Get Professionals', N'Get Professionals', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/professionals?lang={lang}&id={id}&licenseType={licenseType}&licenseNumber={licenseNumber}&licenseState={licenseState}&state={state}&country={country}&firstName={firstName}&middleName={middleName}&lastName={lastName}&email={email}&addressLine1={addressLine1}&addressLine2={addressLine2}&addressLine3={addressLine3}&businessLicense={businessLicense}&businessName={businessName}&city={city}&licenseExpirationDate={licenseExpirationDate}&licenseIssueDate={licenseIssueDate}&lastRenewalDate={lastRenewalDate}&title={title}&offset={offset}&limit={limit}&fields={fields}', N'getProfess', N'All', N'7.3.1', NULL, N'Professionals', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700128')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700128', N'/v4/professionals/{id}/records', N'GET', N'/v4/professionals/{id}/records?lang={lang}&offset={offset}&limit={limit}&fields={fields}', N'get_professional_records', N'Get Professional Records', N'Get Professional Records', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/professionals/{id}/records?lang={lang}&offset={offset}&limit={limit}&fields={fields}', N'getProfess', N'All', N'7.3.1', NULL, N'Professionals', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700129')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700129', N'/v4/records/{recordId}/related', N'POST', N'/v4/records/{recordId}/related?lang={lang}', N'create_record_related', N'Create Record Related', N'Create Record Related', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/related?lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700130')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700130', N'/v4/records/{recordId}/related/{childIds}', N'DELETE', N'/v4/records/{recordId}/related/{childIds}?lang={lang}', N'delete_record_related', N'Delete Record Related', N'Delete Record Related', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/related/{childIds}?lang={lang}', N'deleteReco', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700131')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700131', N'/v4/records/{recordId}/related', N'GET', N'/v4/records/{recordId}/related?relationship={relationship}&lang={lang}&fields={fields}', N'get_record_related', N'Get Record Related', N'Get Record Related', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/related?relationship={relationship}&lang={lang}&fields={fields}', N'getRelated', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700132')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700132', N'/v4/settings/departments', N'GET', N'/v4/settings/departments?lang={lang}', N'get_settings_departments', N'Get Departments', N'Get Departments', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/departments?lang={lang}', N'getDepartm', N'Agency', N'7.3.1', NULL, N'Agencies', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700133')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700133', N'/v4/settings/departments/{id}/staffs', N'GET', N'/v4/settings/departments/{id}/staffs?lang={lang}', N'get_settings_department_staffs', N'Get Department Staffs', N'Get Department Staffs', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/departments/{id}/staffs?lang={lang}', N'getDepartm', N'Agency', N'7.3.1', NULL, N'Agencies', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700134')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700134', N'/v4/settings/records/types/{id}/statuses', N'GET', N'/v4/settings/records/types/{id}/statuses?lang={lang}', N'get_settings_record_statuses', N'Get Record Statuses', N'Get Record Statuses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/records/types/{id}/statuses?lang={lang}', N'getRecordS', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700135')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700135', N'/v4/settings/priorities', N'GET', N'/v4/settings/priorities?lang={lang}', N'get_settings_priorities', N'Get Priorities', N'Get Priorities', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/priorities?lang={lang}', N'getPriorit', N'All', N'7.3.1', NULL, N'Settings', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700136')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700136', N'/v4/inspections/{inspectionId}/related', N'GET', N'/v4/inspections/{inspectionId}/related?lang={lang}&relationship={relationship}&fields={fields}', N'get_inspection_related', N'Get Inspection Related', N'Get Inspection Related', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/related?lang={lang}&relationship={relationship}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700137')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700137', N'/v4/inspections/{inspectionId}/related', N'POST', N'/v4/inspections/{inspectionId}/related?lang={lang}', N'create_inspection_related', N'Create Inspection Related', N'Create Inspection Related', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/related?lang={lang}', N'createInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700138')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700138', N'/v4/inspections/{inspectionId}/related/{childIds}', N'DELETE', N'/v4/inspections/{inspectionId}/related/{childIds}?lang={lang}', N'delete_inspection_related', N'Delete Inspection Related', N'Delete Inspection Related', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/related/{childIds}?lang={lang}', N'deleteInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700139')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700139', N'/v4/settings/inspections/types', N'GET', N'/v4/settings/inspections/types?lang={lang}&offset={offset}&limit={limit}&fields={fields}&group={group}', N'get_settings_inspection_types', N'Get Inspection Groups ', N'Get Inspection Groups ', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/inspections/types?lang={lang}&offset={offset}&limit={limit}&fields={fields}&group={group}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700140')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700140', N'/v4/settings/inspections/types/{ids}', N'GET', N'/v4/settings/inspections/types/{ids}?lang={lang}&fields={fields}', N'get_settings_inspection_type', N'Get Inspection Types', N'Get Inspection Types', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/inspections/types/{ids}?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700141')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700141', N'/v4/settings/inspections/grades', N'GET', N'/v4/settings/inspections/grades?lang={lang}&fields={fields}&group={group}', N'get_settings_inspection_grades', N'Get Inspection Grades', N'Get Inspection Grades', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/settings/inspections/grades?lang={lang}&fields={fields}&group={group}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700142')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700142', N'/v4/settings/inspections/statuses', N'GET', N'/v4/settings/inspections/statuses?lang={lang}&fields={fields}&group={group}', N'get_settings_inspection_statuses', N'Get Inspection Statuses', N'Get Inspection Statuses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/settings/inspections/statuses?lang={lang}&fields={fields}&group={group}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700143')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700143', N'/v4/inspections/{inspectionId}/comments', N'GET', N'/v4/inspections/{inspectionId}/comments?lang={lang}&fields={fields}', N'get_inspection_comments', N'Get Inspection Comments', N'Get Inspection Comments', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/comments?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700144')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700144', N'/v4/inspections/{ids}', N'GET', N'/v4/inspections/{ids}?lang={lang}&fields={fields}', N'get_inspection', N'Get Inspection', N'Get Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{ids}?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700145')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700145', N'/v4/inspections/{inspectionIds}/histories', N'GET', N'/v4/inspections/{inspectionIds}/histories?lang={lang}&fields={fields}', N'get_inspection_histories', N'Get Inspection Histories', N'Get Inspection Histories', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionIds}/histories?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700146')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700146', N'/v4/inspections/{inspectionId}/checklists', N'GET', N'/v4/inspections/{inspectionId}/checklists?lang={lang}&fields={fields}', N'get_inspection_checklists', N'Get Inspection Checklists', N'Get Inspection Checklists', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/checklists?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700147')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700147', N'/v4/inspections/{inspectionId}/checklists', N'POST', N'/v4/inspections/{inspectionId}/checklists?lang={lang}', N'create_inspection_checklists', N'Create Inspection Checklist', N'Create Inspection Checklist', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/checklists?lang={lang}', N'createInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700148')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700148', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems?lang={lang}&fields={fields}', N'get_inspection_checklist_items', N'Get Inspection Checklist Items', N'Get Inspection Checklist Items', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/checklists/{checklistId}/checklistItems?lang={lang}&fields={fields}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700149')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700149', N'/v4/inspections/{inspectionId}/checklists/{ids}', N'DELETE', N'/v4/inspections/{inspectionId}/checklists/{ids}?lang={lang}', N'delete_inspection_checklists', N'Delete Inspection Checklists', N'Delete Inspection Checklists', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/checklists/{ids}?lang={lang}', N'deleteInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700150')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700150', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/histories', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/histories?lang={lang}', N'get_inspection_checklist_histories', N'Get Inspection Checklist Histories', N'Get Inspection Checklist Histories', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/checklists/{checklistId}/histories?lang={lang}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700151')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700151', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/histories', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/histories?lang={lang}', N'get_inspection_checklist_item_histories', N'Get Inspection Checklist Item Histories', N'Get Inspection Checklist Item Histories', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/histories?lang={lang}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700152')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700152', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems', N'PUT', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems?lang={lang}', N'update_inspection_checklist_items', N'Update Inspection Checklist Items', N'Update Inspection Checklist Items', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/checklists/{checklistId}/checklistItems?lang={lang}', N'updateInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700153')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700153', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&fields={fields}', N'get_inspection_checklist_item_documents', N'Get Inspection Checklist Documents', N'Get Inspection Checklist Documents', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&fields={fields}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700154')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700154', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents', N'POST', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&userId={userId}&password={password}', N'create_inspection_checklist_item_document', N'Create Inspection Checklist Document', N'Create Inspection Checklist Document', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/documents?lang={lang}&group={group}&category={category}&userId={userId}&password={password}', N'createInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700155')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700155', N'/v4/inspections/{inspectionId}/documents', N'GET', N'/v4/inspections/{inspectionId}/documents?lang={lang}&fields={fields}', N'get_inspection_documents', N'Get Inspection Documents', N'Get Inspection Documents', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/documents?lang={lang}&fields={fields}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700156')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700156', N'/v4/inspections/{inspectionId}/documents', N'POST', N'/v4/inspections/{inspectionId}/documents?lang={lang}&userId={userId}&password={password}', N'create_inspection_documents', N'Create Inspection Document', N'Create Inspection Document', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/documents?lang={lang}&group={group}&category={category}&userId={userId}&password={password}', N'createInsp', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700157')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700157', N'/v4/inspections/{inspectionId}/documents/{ids}', N'DELETE', N'/v4/inspections/{inspectionId}/documents/{ids}?lang={lang}&userId={userId}&password={password}', N'delete_inspection_documents', N'Delete Inspection Documents', N'Delete Inspection Documents', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/{inspectionId}/documents/{ids}?lang={lang}&userId={userId}&password={password}', N'deleteInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700158')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700158', N'/v4/inspections/schedule', N'POST', N'/v4/inspections/schedule?lang={lang}', N'schedule_inspection', N'Schedule Inspection', N'Schedule Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/schedule?lang={lang}', N'scheduleIn', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700159')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700159', N'/v4/inspections/availableDates', N'GET', N'/v4/inspections/availableDates?lang={lang}&typeId={typeId}&recordId={recordId}&startDate={startDate}&limit={limit}&offset={offset}', N'get_inspection_available_dates', N'Get Inspection Available Dates', N'Get Inspection Available Dates', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/inspections/availableDates?lang={lang}&typeId={typeId}&recordId={recordId}&startDate={startDate}&limit={limit}&offset={offset}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700160')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700160', N'/v4/inspections/{id}/schedule', N'PUT', N'/v4/inspections/{id}/schedule?lang={lang}', N'schedule_pending_inspection', N'Schedule Pending Inspection', N'Schedule Pending Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{id}/schedule?lang={lang}', N'schedulePe', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700161')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700161', N'/v4/inspections/{id}/reschedule', N'PUT', N'/v4/inspections/{id}/reschedule?lang={lang}', N'reschedule_inspection', N'Reschedule Inspection', N'Reschedule Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{id}/reschedule?lang={lang}', N'reschedule', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700162')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700162', N'/v4/inspections/{ids}/cancel', N'DELETE', N'/v4/inspections/{ids}/cancel?lang={lang}', N'cancel_inspection', N'Cancel Inspection', N'Cancel Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{ids}/cancel?lang={lang}', N'cancelInsp', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700163')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700163', N'/v4/inspections/{id}', N'PUT', N'/v4/inspections/{id}?lang={lang}', N'update_inspection', N'Update Inspection', N'Update Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{id}?lang={lang}', N'updateInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700164')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700164', N'/v4/inspections/{id}/result', N'PUT', N'/v4/inspections/{id}/result?lang={lang}', N'result_inspection', N'Result Inspection', N'Result Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{id}/result?lang={lang}', N'resultInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700165')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700165', N'/v4/inspections/{ids}/assign', N'PUT', N'/v4/inspections/{ids}/assign?lang={lang}&inspectorId={inspectorId}', N'assign_inspections', N'Assign Inspection', N'Assign Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{ids}/assign?lang={lang}&inspectorId={inspectorId}', N'assignInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700166')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700166', N'/v4/inspections/{ids}', N'DELETE', N'/v4/inspections/{ids}?lang={lang}', N'delete_inspections', N'Delete Inspection', N'Delete Inspection', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{ids}?lang={lang}', N'deleteInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700167')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700167', N'/v4/inspections', N'GET', N'/v4/inspections?module={module}&types={types}&scheduledDateFrom={scheduledDateFrom}&scheduledDateTo={scheduledDateTo}&inspectorIds={inspectorIds}&offset={offset}&limit={limit}&lang={lang}', N'get_inspections', N'Get Inspections', N'Get Inspections', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections?lang={lang}&types={types}&scheduledDateFrom={scheduledDateFrom}&scheduledDateTo={scheduledDateTo}&inspectorIds={inspectorIds}&districtIds={districtIds}&offset={offset}&limit={limit}&module={module}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700168')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700168', N'/v4/settings/inspections/checklists', N'GET', N'/v4/settings/inspections/checklists?lang={lang}&group={group}', N'get_settings_inspection_checklists', N'Get Checklist Settings', N'Get Checklist Settings', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/inspections/checklists?lang={lang}&group={group}&fields={fields}&offset={offset}&limit={limit}', N'getCheckli', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700169')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700169', N'/v4/settings/inspections/checklists/{ids}', N'GET', N'/v4/settings/inspections/checklists/{ids}?lang={lang}&fields={fields}', N'get_settings_inspection_checklist', N'Get Checklist Setting', N'Get Checklist Setting', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/inspections/checklists/{ids}?lang={lang}&fields={fields}', N'getCheckli', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700170')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700170', N'/v4/settings/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables', N'GET', N'/v4/settings/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables?lang={lang}', N'get_settings_checklist_item_customtable', N'Get Checklist Item Custom Table Settings', N'Get Checklist Item Custom Table Settings', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables?lang={lang}', N'getCheckli', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700171')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700171', N'/v4/settings/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms', N'GET', N'/v4/settings/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms?lang={lang}', N'get_settings_checklist_item_customform', N'Get Checklist Item Custom Form Settings', N'Get Checklist Item Custom Form Settings', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms?lang={lang}', N'getCheckli', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700172')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700172', N'/v4/settings/inspections/checklistsGroups', N'GET', N'/v4/settings/inspections/checklistsGroups?lang={lang}', N'get_settings_checklist_groups', N'Get Inspection Checklist Groups', N'Get Inspection Checklist Groups', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/inspections/checklistsGroups?lang={lang}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700173')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700173', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms?lang={lang}&fields={fields}', N'get_inspection_checklist_item_customforms', N'Get Inspection Checklist Custom Forms', N'Get Inspection Checklist Custom Forms', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms?lang={lang}&fields={fields}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700174')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700174', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms', N'PUT', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms?lang={lang}', N'update_inspection_checklist_item_customforms', N'Update Inspection Checklist Custom Forms', N'Update Inspection Checklist Custom Forms', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms?lang={lang}', N'updateInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700175')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700175', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/meta', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/meta?lang={lang}', N'get_inspection_checklist_item_customforms_meta', N'Get Inspection Checklist Custom Forms Settings', N'Get Inspection Checklist Custom Forms Settings', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/meta?lang={lang}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700176')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700176', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/{formId}/meta', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/{formId}/meta?lang={lang}', N'get_inspection_checklist_item_customform_meta', N'Get Inspection Checklist Custom Form Settings', N'Get Inspection Checklist Custom Form Settings', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customForms/{formId}/meta?lang={lang}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700177')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700177', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/meta', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/meta?lang={lang}&fields={fields}', N'get_inspection_checklist_item_customtables_meta', N'Get Inspection Checklist Custom Tables Settings', N'Get Inspection Checklist Custom Tables Settings', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/meta?lang={lang}&fields={fields}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700178')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700178', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}/meta', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}/meta?lang={lang}&fields={fields}', N'get_inspection_checklist_item_customtable_meta', N'Get Inspection Checklist Custom Table Settings', N'Get Inspection Checklist Custom Table Settings', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}/meta?lang={lang}&fields={fields}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700179')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700179', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables', N'PUT', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables?lang={lang}&fields={fields}', N'update_inspection_checklist_item_customtables', N'Update Inspection Checklist Custom Tables', N'Update Inspection Checklist Custom Tables', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables?lang={lang}&fields={fields}', N'updateInsp', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700180')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700180', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables?lang={lang}&fields={fields}', N'get_inspection_checklist_item_customtables', N'Get Inspection Checklist Custom Tables', N'Get Inspection Checklist Custom Tables', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables?lang={lang}&fields={fields}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700181')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700181', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}', N'GET', N'/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}?lang={lang}&fields={fields}', N'get_inspection_checklist_item_customtable', N'Get Inspection Checklist Custom Table', N'Get Inspection Checklist Custom Table', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/{inspectionId}/checklists/{checklistId}/checklistItems/{checklistItemId}/customTables/{tableId}?lang={lang}&fields={fields}', N'getInspect', N'Agency', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700182')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700182', N'/v4/records/{recordId}/addresses', N'GET', N'/v4/records/{recordId}/addresses?lang={lang}&isPrimary={isPrimary}&fields={fields}', N'get_record_addresses', N'Get Record Addresses', N'Get Record Addresses', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/addresses?lang={lang}&isPrimary={isPrimary}&fields={fields}', N'getRecordA', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700183')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700183', N'/v4/records/{recordId}/addresses', N'POST', N'/v4/records/{recordId}/addresses?lang={lang}', N'create_record_addresses', N'Create Record Addresses', N'Create Record Addresses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/addresses?lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700184')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700184', N'/v4/records/{recordId}/addresses/{id}', N'PUT', N'/v4/records/{recordId}/addresses/{id}?lang={lang}', N'update_record_address', N'Update Record Address', N'Update Record Address', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/addresses/{id}?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700185')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700185', N'/v4/records/{recordId}/addresses/{ids}', N'DELETE', N'/v4/records/{recordId}/addresses/{ids}?lang={lang}', N'delete_record_addresses', N'Delete Record Addresses', N'Delete Record Addresses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/addresses/{ids}?lang={lang}', N'deleteReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700186')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700186', N'/v4/settings/addresses/states', N'GET', N'/v4/settings/addresses/states?lang={lang}', N'get_settings_address_states', N'Get Address States', N'Get Address States', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/addresses/states?lang={lang}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700187')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700187', N'/v4/settings/addresses/countries', N'GET', N'/v4/settings/addresses/countries?lang={lang}', N'get_settings_address_countries', N'Get Address Countries', N'Get Address Countries', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/addresses/countries?lang={lang}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700188')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700188', N'/v4/settings/addresses/streetSuffixes', N'GET', N'/v4/settings/addresses/streetSuffixes?lang={lang}', N'get_settings_address_street_suffixes', N'Get Address Street Suffixes', N'Get Address Street Suffixes', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/addresses/streetSuffixes?lang={lang}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700189')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700189', N'/v4/settings/addresses/streetDirections', N'GET', N'/v4/settings/addresses/streetDirections?lang={lang}', N'get_settings_address_street_directions', N'Get Address Street Directions', N'Get Address Street Directions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/addresses/streetDirections?lang={lang}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700190')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700190', N'/v4/settings/addresses/streetFractions', N'GET', N'/v4/settings/addresses/streetFractions?lang={lang}', N'get_settings_address_street_fractions', N'Get Address Street Fractions', N'Get Address Street Fractions', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/addresses/streetFractions?lang={lang}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700191')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700191', N'/v4/settings/addresses/unitTypes', N'GET', N'/v4/settings/addresses/unitTypes?lang={lang}', N'get_settings_address_unit_types', N'Get Addresses Unit Types', N'Get Addresses Unit Types', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/addresses/unitTypes?lang={lang}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700192')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700192', N'/v4/addresses', N'GET', N'/v4/addresses?lang={lang}&id={id}&type={type}&isPrimary={isPrimary}&streetName={streetName}&streetStart={streetStart}&direction={direction}&streetSuffixDirection={streetSuffixDirection}&streetSuffix={streetSuffix}&city={city}&country={country}&state={state}&limit={limit}&offset={offset}&fields={fields}', N'get_addresses', N'Get Addresses', N'Get Addresses', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/addresses?lang={lang}&id={id}&type={type}&isPrimary={isPrimary}&streetName={streetName}&streetStart={streetStart}&direction={direction}&streetSuffixDirection={streetSuffixDirection}&streetSuffix={streetSuffix}&city={city}&country={country}&state={state}&limit={limit}&offset={offset}&fields={fields}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700193')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700193', N'/v4/addresses/{id}', N'GET', N'/v4/addresses/{id}?lang={lang}&fields={fields}', N'get_address', N'Get Address', N'Get Address', 0, 11, N'System', getdate(), Null, Null, N'/apis/v4/addresses/{id}?lang={lang}&fields={fields}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700194')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700194', N'/v4/appdata/{container}/{blobname}', N'GET', N'/v4/appdata/{container}/{blobname}/?lang={lang}&appid={appid}', N'get_app_data', N'Get App Specific Data', N'Retrieves app data matching the container and blob name. The two parameters are defined by the invoker (an app) and must be unique.', 2, 1, N'System', getdate(), Null, Null, NULL, N'getAppData', N'All', N'All', NULL, N'App', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700195')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700195', N'/v4/appdata/{container}/{blobname}', N'PUT', N'/v4/appdata/{container}/{blobname}/?lang={lang}&appid={appid}', N'update_app_data', N'Update App Specific Data', N'Stores app data in the Cloud based on the container and blob name. If the two parameters exist in the Cloud already, the API will override them; otherwise, the API will create them in the Cloud. The two parameters are defined by the invoker (an app) and must be unique.', 2, 1, N'System', getdate(), Null, Null, NULL, N'updateAppD', N'All', N'All', NULL, N'App', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700196')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700196', N'/v4/appdata/{container}/{blobname}', N'DELETE', N'/v4/appdata{container}/{blobname}/?lang={lang}&appid={appid}', N'delete_app_data', N'Delete App Specific Data', N'Deletes app data based on the container and blob name. No error will be returned if neither of the parameters exists in the Cloud.', 2, 1, N'System', getdate(), Null, Null, NULL, N'deleteAppD', N'All', N'All', NULL, N'App', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700197')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700197', N'/v4/appsettings', N'GET', N'/v4/appsettings/?keys={keys}', N'get_app_settings', N'Get App Settings', N'Gets a list of settings of the given App', 2, 0, N'System', getdate(), Null, Null, NULL, N'getAppSett', N'All', N'All', NULL, N'App', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700198')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700198', N'/v4/settings/comments', N'GET', N'/v4/settings/comments?groups={groups}&lang={lang}&offset={offset}&limit={limit}', N'get_settings_standard_comments', N'Get Standard Comments', N'Get Standard Comments.', 5, 0, N'System', getdate(), Null, Null, NULL, N'getStandar', N'Agency', N'7.3.1', NULL, N'Settings', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700199')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700199', N'/v4/settings/comments/groups', N'GET', N'/v4/settings/comments/groups?lang={lang}&offset={offset}&limit={limit}', N'get_settings_standard_comment_groups', N'Get Standard Comment Groups', N'Get Standard Comment Groups.', 5, 0, N'System', getdate(), Null, Null, NULL, N'getStandar', N'Agency', N'7.3.1', NULL, N'Settings', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700201')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700201', N'/v4/agencies/{name}', N'GET', N'/v4/agencies/{name}', N'get_agency', N'Get Agency', N'Get agency information by its name.', 5, 0, N'System', getdate(), Null, Null, NULL, N'getAgency', N'All', N'All', NULL, N'Agencies', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700202')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700202', N'/v4/agencies/{name}/logo', N'GET', N'/v4/agencies/{name}/logo', N'get_agency_logo', N'Get Agency Logo', N'Get agency logo by its name.', 5, 0, N'System', getdate(), Null, Null, NULL, N'getAgencyL', N'All', N'All', NULL, N'Agencies', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700203')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700203', N'/v4/settings/conditions/approval/types', N'GET', N'/v4/settings/conditions/approval/types?lang={lang}', N'get_settings_condition_approval_types', N'Get Condition Approval Types', N'Get Condition Approval Types', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/settings/conditions/approval/types?lang={lang}', N'getConditi', N'Agency', N'7.3.1', NULL, N'Conditions', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700204')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700204', N'/v4/settings/conditions/approval/priorities', N'GET', N'/v4/settings/conditions/approval/priorities?lang={lang}', N'get_settings_condition_approval_priorities', N'Get Condition Approval Priorities', N'Get Condition Approval Priorities', 5, 11, N'System', getdate(), Null, Null, N'/apis/v1/settings/conditions/approval/priorities?lang={lang}', N'getConditi', N'Agency', N'7.3.1', NULL, N'Conditions', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700205')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700205', N'/v4/records/{recordId}/location', N'GET', N'/v4/records/{recordId}/location?lang={lang}', N'get_record_location', N'Get Record Location', N'Get the record''s location by record id and some specified parameters.', 5, 0, N'System', getdate(), Null, Null, NULL, N'getRecordL', N'Agency', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700206')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700206', N'/v4/records/{recordId}/usercomments', N'POST', N'/v4/records/{recordId}/usercomments/?lang={lang}', N'create_record_user_comment', N'Create Record User Comment', N'Get the record''s project informations by record id and some specified parameters.', 5, 0, N'System', getdate(), Null, Null, NULL, N'createReco', N'Citizen', N'All', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700207')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700207', N'/v4/records/{recordId}/usercomments', N'GET', N'/v4/records/{recordId}/usercomments/?lang={lang}&offset={offset}&limit={limit}', N'get_record_user_comments', N'Get Record User Comments', N'Get the record''s project informations by record id and some specified parameters.', 5, 0, N'System', getdate(), Null, Null, NULL, N'getRecordU', N'Citizen', N'All', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700208')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700208', N'/v4/records/{recordId}/votes', N'POST', N'/v4/records/{recordId}/votes/?Lang={LANG}', N'create_record_vote', N'Create Record Vote', N'Create Record Vote', 5, 0, N'System', getdate(), Null, Null, NULL, N'createReco', N'Citizen', N'All', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700209')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700209', N'/v4/records/{recordId}/votes', N'GET', N'/v4/records/{recordId}/votes/?Lang={LANG}', N'get_record_votes', N'Get Record Votes', N'Get Record Votes', 5, 0, N'System', getdate(), Null, Null, NULL, N'getRecordV', N'Citizen', N'All', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700210')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700210', N'/v4/records/{recordId}/votes/summary', N'GET', N'/v4/records/{recordId}/votessummary/?Lang={LANG}', N'get_record_votes_summary', N'Get Record Votes Summary', N'Get Record Votes Summary', 5, 0, N'System', getdate(), Null, Null, NULL, N'getUserAct', N'All', N'All', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700211')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700211', N'/v4/civicid/profile', N'GET', N'/v4/civicid/profile?lang={lang}', N'get_civicid_profile', N'Get Profile for Current Civic ID', N'Get Profile for Current Civic ID', 1, 0, N'System', getdate(), Null, Null, NULL, N'getCivicID', N'All', N'7.3.1', NULL, N'Civic ID', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700212')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700212', N'/v4/settings/modules', N'GET', N'/v4/settings/modules/?lang={lang}', N'get_settings_modules', N'Get Modules', N'Get a list of available modules.', 5, 0, N'System', getdate(), Null, Null, NULL, N'getModules', N'All', N'7.3.1', NULL, N'Settings', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700213')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700213', N'/v4/records/{recordId}/fees', N'POST', N'/v4/records/{recordId}/fees?lang={lang}', N'create_record_fees', N'Create Record Fees', N'Create Record Fees', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/fees?lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700214')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700214', N'/v4/records/describe/create', N'GET', N'/v4/records/describe/create', N'get_create_record_describe', N'Describe Create Record', N'Describe Create Record', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/describe/create', N'getCreateR', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700215')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700215', N'/v4/payments', N'POST', N'/v4/payments?lang={lang}', N'create_payments', N'Create Payment', N'Create Payment', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/cashier/payments?lang={lang}', N'createPaym', N'All', N'7.3.1', NULL, N'Cashier', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700216')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700216', N'/v4/records/{recordId}/workflowTasks/{id}/statuses', N'GET', N'/v4/records/{recordId}/workflowTasks/{id}/statuses?lang={lang}', N'get_record_workflow_task_statuses', N'Get Workflow Task Statuses', N'Get Workflow Task Statuses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/workflowTasks/{id}/statuses?lang={lang}', N'getWorkflo', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700217')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700217', N'/v4/settings/records/types/{id}/fees/schedules', N'GET', N'/v4/settings/records/types/{id}/fees/schedules', N'get_settings_record_type_feeschedules', N'Get Record Type Fee Schedules', N'Get Record Type Fee Schedules', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/records/types/{id}/fees/schedules', N'getRecordT', N'All', N'7.3.1', NULL, N'Cashier', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700218')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700218', N'/v4/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/statuses', N'GET', N'/v4/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/statuses?lang={lang}', N'get_inspection_checklist_item_statuses', N'Get Inspection ChecklistItem Statuses', N'Get Inspection ChecklistItem Statuses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/inspections/checklists/{checklistId}/checklistItems/{checklistItemId}/statuses?lang={lang}', N'getInspect', N'All', N'7.3.1', NULL, N'Inspections', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700219')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700219', N'/v4/addresses/{id}/parcels', N'GET', N'/v4/addresses/{id}/parcels?lang={lang}&fields={fields}', N'get_address_parcels', N'Get Address Parcels', N'Get Address Parcels', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/addresses/{id}/parcels?lang={lang}&fields={fields}', N'getAddress', N'All', N'7.3.1', NULL, N'Addresses', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700220')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700220', N'/v4/records/{recordId}/contacts/{contactId}/addresses', N'GET', N'/v4/records/{recordId}/contacts/{contactId}/addresses?lang={lang}', N'get_record_contact_addresses', N'Get Record Contact Addresses', N'Get Record Contact Addresses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/contacts/{contactId}/addresses?lang={lang}', N'getRecordC', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700221')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700221', N'/v4/records/{recordId}/contacts/{contactId}/addresses', N'POST', N'/v4/records/{recordId}/contacts/{contactId}/addresses?lang={lang}', N'create_record_contact_addresses', N'Create Record Contact Addresses', N'Create Record Contact Addresses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/contacts/{contactId}/addresses?lang={lang}', N'createReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700222')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700222', N'/v4/records/{recordId}/contacts/{contactId}/addresses/{ids}', N'DELETE', N'/v4/records/{recordId}/contacts/{contactId}/addresses/{ids}?lang={lang}', N'delete_record_contact_addresses', N'Delete Record Contact Addresses', N'Delete Record Contact Addresses', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/contacts/{contactId}/addresses/{ids}?lang={lang}', N'deleteReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700223')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700223', N'/v4/records/{recordId}/contacts/{contactId}/addresses/{id}', N'PUT', N'/v4/records/{recordId}/contacts/{contactId}/addresses/{id}?lang={lang}', N'update_record_contact_address', N'Update Record Contact Address', N'Update Record Contact Address', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/contacts/{contactId}/addresses/{id}?lang={lang}', N'updateReco', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700224')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700224', N'/v4/civicid/accounts', N'GET', N'/v4/civicid/accounts?lang={lang}', N'get_linked_accounts', N'Get Linked Accounts', N'Get Linked Accounts', 4, 0, N'System', getdate(), Null, Null, NULL, N'getCivicID', N'All', N'7.3.1', NULL, N'Civic ID', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700225')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700225', N'/v4/agencies', N'GET', N'/v4/agencies', N'get_agencies', N'Get Agencies', N'Get enabled agencies.', 5, 0, N'System', getdate(), Null, Null, NULL, N'getAgencie', N'All', N'All', NULL, N'Agencies', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-1234567A0001')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-1234567A0001', N'/batch', N'POST', N'/batch', N'batch_request', N'Batch Request', N'Batch Request', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/batch', N'batchReque', N'All', N'7.3.1', NULL, N'Batches', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700224')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700224', N'/v4/records/{recordId}/invoices', N'POST', N'/v4/records/{recordId}/invoices?lang={lang}', N'create_invoice', N'Create Invoice', N'Create Invoice', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/invoices?lang={lang}', N'invoiceRec', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700226')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700226', N'/v4/transactions/{ids}', N'GET', N'/v4/transactions/{ids}?lang={lang}&fields={fields}', N'get_transaction', N'Get Payment Transaction', N'Get Payment Transaction', 5, 11, N'System', getdate(), Null, Null, N'/apis/agency/transactions/{ids}?lang={lang}&fields={fields}', N'getTransac', N'All', N'7.3.1', NULL, N'Cashier', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700227')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700227', N'/v4/settings/fees', N'GET', N'/v4/settings/fees?schedule={schedule}&version={version}&lang={lang}&fields={fields}', N'get_settings_fees', N'Get Fee Settings', N'Get Fee Settings', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/settings/fees?schedule={schedule}&version={version}&lang={lang}&fields={fields}', N'getFeeItem', N'All', N'7.3.1', NULL, N'Cashier', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700228')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700228', N'/v4/search/dataquery', N'POST', N'/v4/search/dataquery?offset={offset}&limit={limit}', N'open_data_query', N'Open Data Query', N'Query data by specified SQL statement', 5, 11, N'System', getdate(), Null, Null, N'/apis/search/sqlquery?offset={offset}&limit={limit}', N'sqlquery', N'All', N'7.3.1', NULL, N'OpenData', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700229')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-123456700229', N'/v4/civicid/accounts/{id}', N'GET', N'/v4/civicid/accounts/{id}?lang={lang}', N'get_account_profile', N'Get Account Profile', N'Get Account Profile', 4, 0, N'System', N'2014-03-27', NULL, NULL, NULL, N'getAccountProfile', 'All', '7.3.1', NULL,'Civic ID', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700230')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700230', N'/v4/records/{recordId}/payments', N'GET', N'/v4/records/{recordId}/payments?lang={lang}', N'get_record_payments', N'Get Record Payments', N'Get Record Payments', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/payments?lang={lang}', N'getRecordPayments', N'All', N'7.3.1', NULL, N'Records', NULL)
END

IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE  [Id] = N'C4012345-AAAA-BBBB-CCCC-D23456700231')
BEGIN
    INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI],[MethodNickName],[Applicability],[SupportedAAVersions],[SupportedAPIVersions],[ResourceGroupName],[FIDDescription]) VALUES (  N'C4012345-AAAA-BBBB-CCCC-D23456700231', N'/v4/records/{recordId}/payments/{paymentId}', N'GET', N'/v4/records/{recordId}/payments/{paymentId}?lang={lang}', N'get_record_payment', N'Get Record Payment', N'Get Record Payment', 5, 11, N'System', getdate(), Null, Null, N'/apis/v4/records/{recordId}/payments/{paymentId}?lang={lang}', N'getRecordPayment', N'All', N'7.3.1', NULL, N'Records', NULL)
END
