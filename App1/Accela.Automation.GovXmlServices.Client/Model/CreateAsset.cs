using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class CreateAsset:OperationRequest
	{
		public CreateAsset()
		{

		}
        [XmlElement(ElementName = "Asset")]
        public Asset asset;
	}
}
