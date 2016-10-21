-- Make POST /v4/search/records/location as a private API.
UPDATE [dbo].[Resources]
SET
	APIAttribute = 1
WHERE [Id] = N'C4012345-AAAA-BBBB-CCCC-123456700205'

update resources set displayname='Get All Custom Form Settings for Checklist Item' where id='C4012345-AAAA-BBBB-CCCC-123456700171'

update resources set displayname='Get All Custom Table Settings for Checklist Item' where id='C4012345-AAAA-BBBB-CCCC-123456700170'

update resources set displayname='Get Custom Table Metadata for Record' where id='C4012345-AAAA-BBBB-CCCC-123456700005'

update resources set displayname='Get All Custom Form Settings for Contact Type',description='Get all custom form settings for specified contact type.' where id='245044D7-76DE-4146-943E-FCA026223C17'

update resources set displayname='Get All Time Accounting Groups',description='Get all time accounting groups, optionally for specified userids.' where id='C401E345-AAAA-BBBB-CCCC-1234F6700050'

update resources set displayname='Get All Time Accounting Type',description='Get all time accounting types for specified time accounting groups, optionally for specified userids and record type.' where id='C401E345-AAAA-BBBB-CCCC-1234F6700051'


