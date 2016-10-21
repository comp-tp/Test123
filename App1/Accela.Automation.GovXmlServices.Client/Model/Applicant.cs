using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Applicant.
	/// </summary>
	public class Applicant
	{
		public Applicant()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Contact")]
		public Contact contact;
	}
}
