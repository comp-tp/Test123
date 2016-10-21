using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for UpdateAssetResponse.
	/// </summary>
    public class UpdateAssetResponse : OperationResponse
	{
		public UpdateAssetResponse()
		{

		}
        [XmlElement(ElementName = "Asset")]
        public Asset asset;

        [XmlElement(ElementName = "AssetId")]
        public AssetId assetId;
	}
}
