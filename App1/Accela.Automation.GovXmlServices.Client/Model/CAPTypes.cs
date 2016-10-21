using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CAPTypes.
	/// </summary>
	public class CAPTypes
	{
		public CAPTypes()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "CAPType")]
		public CAPType[] capType;
	}
}
