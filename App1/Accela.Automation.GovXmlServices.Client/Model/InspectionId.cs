using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionId.
	/// </summary>
	public class InspectionId
	{
		public InspectionId()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

	}
}
