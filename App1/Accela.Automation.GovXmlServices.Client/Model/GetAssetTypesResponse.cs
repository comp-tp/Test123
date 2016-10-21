using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetAssetTypesResponse.
	/// </summary>
	public class GetAssetTypesResponse:OperationResponse
	{
		public GetAssetTypesResponse()
		{
		}
		[XmlElement(ElementName="AssetTypes")]
		public AssetTypes assetTypes;
	}
}
