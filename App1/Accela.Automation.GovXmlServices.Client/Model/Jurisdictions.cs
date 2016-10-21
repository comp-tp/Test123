using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Jurisdictions.
	/// </summary>
	public class Jurisdictions
	{
		public Jurisdictions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Jurisdiction")]
		public Jurisdiction[] jurisdiction;
	}
}
