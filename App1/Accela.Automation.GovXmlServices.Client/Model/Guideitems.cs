using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Guideitems.
	/// </summary>
	public class Guideitems
	{
		public Guideitems()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Guideitem")]
			public Guideitem[] guideitem;
	}
}
