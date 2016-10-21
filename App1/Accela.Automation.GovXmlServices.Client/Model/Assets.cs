using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Assets
	{
		public Assets()
		{
		}
		[XmlElement(ElementName="Asset")]
		public Asset[] asset;
	}
}
