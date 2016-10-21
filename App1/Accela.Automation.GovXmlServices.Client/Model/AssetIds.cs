using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class AssetIds
	{
		public AssetIds()
		{
		}
		[XmlElement(ElementName="AssetId")]
		public AssetId[] assetId;
	}
}
