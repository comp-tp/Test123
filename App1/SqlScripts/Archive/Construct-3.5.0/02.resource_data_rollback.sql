update resources set IsProxy=0, ProxyRemoteServerName=null where ProxyRemoteServerName='ConstructUser'


update resources set IsProxy=0, proxyapi=null, ProxyRemoteServerName=null
where HttpVerb='POST' and API='/oauth2/token'
