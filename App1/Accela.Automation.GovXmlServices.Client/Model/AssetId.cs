using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class AssetId:Identifier
	{
		public AssetId()
		{
		}
		[XmlElement(ElementName="TrackingNumber")]
		public int trackingNumber;
	}
}
