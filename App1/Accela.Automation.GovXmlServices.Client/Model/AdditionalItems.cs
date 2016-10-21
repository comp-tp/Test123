using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for AdditionalItems.
	/// </summary>
	public class AdditionalItems
	{
		public AdditionalItems()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "AdditionalItem")]
		public AdditionalItem[] additionalItem;
	}
}
