using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Checklist.
	/// </summary>
	/// 
	
	public class Checklist
	{
		public Checklist()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Checkitem", IsNullable = true)]
		public Checkitem[] checkitem;
	}
}
