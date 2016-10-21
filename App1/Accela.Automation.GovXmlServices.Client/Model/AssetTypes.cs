using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class AssetTypes:ElementList
	{
		public AssetTypes()
		{
		}
		[XmlElement(ElementName="AssetType")]
		public AssetType[] assetType;
	}
}
