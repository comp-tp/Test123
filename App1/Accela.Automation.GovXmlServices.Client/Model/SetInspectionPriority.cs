using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for SetInspectionPriority.
	/// </summary>
	public class SetInspectionPriority
	{
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Inspections")]
		public Inspections inspections;

		public SetInspectionPriority()
		{
		}
	}
}
