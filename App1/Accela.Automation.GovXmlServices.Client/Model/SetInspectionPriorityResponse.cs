using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for SetInspectionPriorityResponse.
	/// </summary>
	public class SetInspectionPriorityResponse
	{
		[XmlElement(ElementName = "System")]
		public Sys system;

		public SetInspectionPriorityResponse()
		{
		}
	}
}
