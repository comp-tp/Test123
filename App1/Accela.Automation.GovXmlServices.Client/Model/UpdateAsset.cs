using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for UpdateAsset.
	/// </summary>
    public class UpdateAsset : OperationRequest
	{
		public UpdateAsset()
		{
		}
        [XmlElement(ElementName = "Asset")]
        public Asset asset;
    }
}
