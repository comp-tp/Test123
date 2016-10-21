using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class CreateAssetResponse:OperationResponse
	{
		public CreateAssetResponse()
		{
		}
        [XmlElement(ElementName = "Asset")]
        public Asset asset;

        [XmlElement(ElementName = "AssetId")]
        public AssetId assetId;
	}
}
