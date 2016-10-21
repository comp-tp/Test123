using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetCAPInspectionTypeListOut.
	/// </summary>
	public class FGetCAPInspectionTypeListOut
	{
		public FGetCAPInspectionTypeListOut()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CapTypes")]
		public CAPTypes capTypes;
	}
}
