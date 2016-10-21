using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model

{
	/// <summary>
	/// Summary description for HoldTypeIds.
	/// </summary>
	public class HoldTypeIds
	{
		public HoldTypeIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "HoldTypeId")]
		public HoldTypeId[] holdTypeId;
	}
}
