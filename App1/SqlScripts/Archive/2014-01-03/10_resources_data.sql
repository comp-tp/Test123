IF NOT EXISTS(SELECT * FROM [dbo].[Resources] WHERE Id = '86F9D481-33CC-4CD0-8295-63928F6EE2A9')
		INSERT [dbo].[Resources] ([Id], [API], [HttpVerb], [RelativeUriTemplateFull], [Name], [DisplayName], [Description], [AuthenticationType], [APIAttribute], [CreatedBy], [CreatedDate], [LastUpdatedBy], [LastUpdatedDate], [ProxyAPI])VALUES (N'86F9D481-33CC-4CD0-8295-63928F6EE2A9',N'/v3p1/records/{recordId}/conditions',N'GET',N'/v3p1/records/{recordId}/conditions?lang={lang}',N'get_record_conditions',N'get record conditions',N'Get record conditions',5,0,N'System',getdate(),NULL,NULL,null);