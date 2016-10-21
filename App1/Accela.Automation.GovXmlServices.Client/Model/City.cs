using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for City.
	/// </summary>
	public class City
	{
		public City()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Display")]
		public string display;
	}
}
