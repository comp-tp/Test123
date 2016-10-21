/* Post 3.4.0 Release Updates */

Insert into [dbo].[Resources] ([Id] ,[API] ,[HttpVerb],[RelativeUriTemplateFull] ,[Name] ,[Description] ,[AuthenticationType] ,[CreatedBy] ,[CreatedDate]  ,[IsProxy] ,[IsAAGovxmlAPI])
VALUES ('C4012345-AAAA-BBBB-CCCC-123456700250', '/apis/v3/resources/{id}', 'GET','/apis/v3/resources/{id}?cache={cache}', 'get_resources', 'Returns an API with Id', 3, 'System', GETDATE(),  0, 0)

UPDATE [dbo].[Resources]
SET [RelativeUriTemplateFull]= '/apis/v3/resources?api={api}&httpmethod={httpmethod}&cache={cache}'
WHERE API='/apis/v3/resources' AND HttpVerb='GET';


Insert into [dbo].[Resources] ([Id] ,[API] ,[HttpVerb],[RelativeUriTemplateFull] ,[Name] ,[Description] ,[AuthenticationType] ,[CreatedBy] ,[CreatedDate]  ,[IsProxy] ,[IsAAGovxmlAPI])
VALUES ('C4012345-AAAA-BBBB-CCCC-123456700251', '/apis/v3/resources', 'POST','/apis/v3/resources', 'create_resources', 'Creates an API resource.', 3, 'System', GETDATE(),  0, 0)

Insert into [dbo].[Resources] ([Id] ,[API] ,[HttpVerb],[RelativeUriTemplateFull] ,[Name] ,[Description] ,[AuthenticationType] ,[CreatedBy] ,[CreatedDate]  ,[IsProxy] ,[IsAAGovxmlAPI])
VALUES ('C4012345-AAAA-BBBB-CCCC-123456700252', '/apis/v3/resources/{id}', 'PUT','/apis/v3/resources/{id}', 'update_resource', 'Update an API resource.', 3, 'System', GETDATE(),  0, 0)


Insert into [dbo].[Resources] ([Id] ,[API] ,[HttpVerb],[RelativeUriTemplateFull] ,[Name] ,[Description] ,[AuthenticationType] ,[CreatedBy] ,[CreatedDate]  ,[IsProxy] ,[IsAAGovxmlAPI])
VALUES ('C4012345-AAAA-BBBB-CCCC-123456700253', '/apis/v3/resources/{id}', 'DELETE','/apis/v3/resources/{id}', 'delete_resource', 'Delete an API resource.', 3, 'System', GETDATE(),  0, 0)


update resources set name='get_record_contact_customforms_meta' where api='/v4/records/{recordId}/contacts/{contactId}/customForms/meta' and HttpVerb='GET'


/*updates civicid related apis to use service proxy*/


update resources set IsProxy=1, proxyapi='/apis/v4/civicid/profile?lang={lang}', ProxyRemoteServerName='ConstructUser', LastUpdatedDate='2016-07-08',LastUpdatedBy='Jackie' where HttpVerb='GET' and API='/v4/civicid/profile'

update resources set IsProxy=1, proxyapi='/apis/v4/civicid/accounts?lang={lang}', ProxyRemoteServerName='ConstructUser', LastUpdatedDate='2016-07-08',LastUpdatedBy='Jackie' where HttpVerb='GET' and API='/v4/civicid/accounts'

update resources set IsProxy=0, proxyapi='/apis/v4/civicid/accounts/{id}?lang={lang}', ProxyRemoteServerName=null, LastUpdatedDate='2016-08-24',LastUpdatedBy='Jackie' where HttpVerb='GET' and API='/v4/civicid/accounts/{id}'

update resources set IsProxy=1, proxyapi='/apis/v4/civicid/accounts?lang={lang}', ProxyRemoteServerName='ConstructUser', LastUpdatedDate='2016-07-08',LastUpdatedBy='Jackie' where HttpVerb='POST' and API='/v4/civicid/accounts'

update resources set IsProxy=1, proxyapi='/apis/v4/civicid/accounts/{id}?lang={lang}', ProxyRemoteServerName='ConstructUser', LastUpdatedDate='2016-07-08',LastUpdatedBy='Jackie' where HttpVerb='DELETE' and API='/v4/civicid/accounts/{id}'

update resources set IsProxy=1, proxyapi='/apis/v4/civicid/profile?lang={lang}', ProxyRemoteServerName='ConstructUser', LastUpdatedDate='2016-07-08',LastUpdatedBy='Jackie' where HttpVerb='GET' and API='/v3/users/me'


/* oauth token api*/

update resources set IsProxy=1, Name='get_oauth2_token', proxyapi='/oauth2/token', ProxyRemoteServerName='ConstructAuth', LastUpdatedDate='2016-07-13',LastUpdatedBy='Vinay' where HttpVerb='POST' and API='/oauth2/token'


/* Remove civicheroapp apis */

DELETE FROM from [dbo].[Resources] where
((HttpVerb='POST' and API='/v3/civicheroapp/records') OR 
(HttpVerb='GET'	and API='/v3/civicheroapp/records/{id}') OR 
(HttpVerb='GET'	and API='/v3/civicheroapp/records/{id}/addresses') OR 
(HttpVerb='GET'	and API='/v3/civicheroapp/records/{id}/documents') OR 
(HttpVerb='POST' and API='/v3/civicheroapp/records/{id}/documents') OR 
(HttpVerb='GET'	and API='/v3/civicheroapp/records/{id}/useractivitiessummary') OR 
(HttpVerb='GET'	and API='/v3/civicheroapp/records/{id}/usercomments') OR 
(HttpVerb='POST' and API='/v3/civicheroapp/records/{id}/usercomments') OR 
(HttpVerb='GET'	and API='/v3/civicheroapp/records/{id}/votes') OR 
(HttpVerb='POST' and API='/v3/civicheroapp/records/{id}/votes') OR 
(HttpVerb='GET'	and API='/v3/civicheroapp/records/{recordId}/documents/{documentId}') OR 
(HttpVerb='GET'	and API='/v3/civicheroapp/records/mine') OR 
(HttpVerb='POST' and API='/v3/civicheroapp/search/records') OR 
(HttpVerb='POST' and API='/v3/a311civicapp/records') OR 
(HttpVerb='GET'	and API='/v3/a311civicapp/records/{id}') OR 
(HttpVerb='POST' and API='/v3/a311civicapp/records/{id}/follow') OR 
(HttpVerb='POST' and API='/v3/a311civicapp/records/{id}/unfollow') OR 
(HttpVerb='GET'	and API='/v3/a311civicapp/records/{id}/usercomments') OR 
(HttpVerb='POST' and API='/v3/a311civicapp/records/{id}/usercomments') OR 
(HttpVerb='GET'	and API='/v3/a311civicapp/records/mine') OR 
(HttpVerb='POST' and API='/v3/a311civicapp/search/records') OR
(HttpVerb='GET'	and API='/v3/records/{id}/usercomments') OR 
(HttpVerb='POST' and API='/v3/records/{id}/usercomments') OR
(HttpVerb='GET' and API='/v4/records/{recordId}/usercomments') OR   
(HttpVerb='POST' and API='/v4/records/{recordId}/usercomments') OR   	
(HttpVerb='GET'	and API='/v3/records/{id}/votes') OR 
(HttpVerb='POST' and API='/v3/records/{id}/votes') OR  
(HttpVerb='GET' and API='/v3/records/{id}/useractivitiessummary') OR 
(HttpVerb='GET'	and API='/v4/records/{recordId}/votes') OR 
(HttpVerb='POST' and API='/v4/records/{recordId}/votes') OR 
(HttpVerb='GET' and API='/v4/records/{recordId}/votes/summary')); 

DELETE from [dbo].[Scope2Groups] where ScopeName in (
'a311citizen_add_user_comment',
'a311citizen_create_record',
'a311citizen_follow_record',
'a311citizen_get_my_record',
'a311citizen_get_record_detail',
'a311citizen_get_user_comment',
'a311citizen_search_record',
'a311citizen_unfollow_record',
'civichero_add_user_comment',
'civichero_create_document',
'civichero_create_record',
'civichero_get_addresses',
'civichero_get_document_by_id',
'civichero_get_documents',
'civichero_get_my_record',
'civichero_get_my_vote',
'civichero_get_record',
'civichero_get_user_activities_summary',
'civichero_get_user_comment',
'get_record_user_comments',
'create_record_user_comments',
'civichero_make_vote',
'civichero_search_record',
'create_record_vote',
'get_record_votes',
'get_record_user_activities_summary',
'get_record_votes_summary');

DELETE from [dbo].[ScopeGroups] where Name in ('civic_hero_app','a311_app');




