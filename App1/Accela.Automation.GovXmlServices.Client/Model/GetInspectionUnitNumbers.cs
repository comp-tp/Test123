using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetInspectionUnitNumbers.
	/// </summary>
	public class GetInspectionUnitNumbers
	{
		public GetInspectionUnitNumbers()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

	}
}