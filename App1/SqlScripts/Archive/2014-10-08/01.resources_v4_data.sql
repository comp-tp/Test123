UPDATE [dbo].[Resources]
SET RelativeUriTemplateFull = '/v4/parcels/{parcelId}/owners?lang={lang}',
    ProxyAPI = '/apis/v4/parcels/{parcelId}/owners?lang={lang}'
WHERE id = 'C4012345-AAAA-BBBB-CCCC-123456700016'