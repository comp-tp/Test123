using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CAPTypeIds.
	/// </summary>
	public class CAPTypeIds
	{
		public CAPTypeIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "CAPTypeId")]
		public CAPTypeId[] capTypeId;
	}
}
