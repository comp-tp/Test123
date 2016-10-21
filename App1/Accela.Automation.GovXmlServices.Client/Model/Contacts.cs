using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Contacts.
	/// </summary>
	/// 
	
	public class Contacts
	{
		public Contacts()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Contact", IsNullable = true)]
		public Contact[] contact;
	}
}
