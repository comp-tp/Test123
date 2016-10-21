update resources set isProxy=1, ProxyAPI='/apis/v3p/agencies/{name}', ProxyRemoteServerName='ConstructAdmin' where api='/v3/agencies/{name}' and httpverb='GET'
update resources set isProxy=1, ProxyAPI='/apis/v4/agencies/{name}', ProxyRemoteServerName='ConstructAdmin' where api='/v4/agencies/{name}' and httpverb='GET'
update resources set isProxy=1, ProxyAPI='/apis/v4/agencies/{name}/logo', ProxyRemoteServerName='ConstructAdmin' where api='/v3/agencies/{name}/logo' and httpverb='GET'
update resources set isProxy=1, ProxyAPI='/apis/v4/agencies/{name}/logo', ProxyRemoteServerName='ConstructAdmin' where api='/v4/agencies/{name}/logo' and httpverb='GET'
update resources set isProxy=1, ProxyAPI='/apis/v4/agencies?name={name}&offset={offset}&limit={limit}', RelativeUriTemplateFull='/v4/agencies?name={name}&offset={offset}&limit={limit}', ProxyRemoteServerName='ConstructAdmin' where api='/v4/agencies' and httpverb='GET'
update resources set isProxy=1, ProxyAPI='/apis/v4/agencies/{name}/environments', ProxyRemoteServerName='ConstructAdmin' where api='/v4/agencies/{name}/environments' and httpverb='GET'
update resources set isProxy=1, ProxyAPI='/apis/v3p/search/agencies?lang={lang}', ProxyRemoteServerName='ConstructAdmin' where api='/v3/geo/search/agencies' and httpverb='POST'
update resources set isProxy=1, ProxyAPI='/apis/v4/search/agencies?lang={lang}', ProxyRemoteServerName='ConstructAdmin' where api='/v4/search/agencies' and httpverb='POST'

update resources set isProxy=1, ProxyAPI='/apis/v3p/gisserviceapp/service?lang={lang}&agencyName={agency}', RelativeUriTemplateFull='/v3/gisserviceapp/service/?lang={lang}&agencyName={agency}', ProxyRemoteServerName='ConstructAdmin' where api='/v3/gisserviceapp/service' and httpverb='GET'
update resources set isProxy=1, ProxyAPI='/apis/v3p/gissettings?agency={agency}', ProxyRemoteServerName='ConstructAdmin' where api='/v3/gissettings' and httpverb='GET'

Insert into [dbo].[Resources] ([Id],[API],[HttpVerb],[RelativeUriTemplateFull],[Name],[Description],[AuthenticationType],[CreatedBy],[CreatedDate],[ProxyAPI],[IsProxy],[IsAAGovxmlAPI],[ProxyRemoteServerName])
VALUES ('C4012345-AAAA-BBBB-CCCC-123456700240',	'/v4/agencies/{name}/environments/{env}/status','GET','/v4/agencies/{name}/environments/{env}/status','get_agency_environment_status','Get agency environment status.',0,'System',CURRENT_TIMESTAMP,	'/apis/v4/agencies/{name}/environments/{env}/status',1,	0,	'ConstructAdmin')
