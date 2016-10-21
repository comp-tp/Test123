UPDATE [dbo].[Resources]
SET
	API = '/v4/search/records/location',
	HttpVerb = 'POST',
	RelativeUriTemplateFull = '/v4/search/records/location',
	Name = 'get_records_location',
	MethodNickName='getRecordsLocation',
	LastUpdatedBy = 'System',
	LastUpdatedDate = '2014-05-14'
WHERE [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700205'