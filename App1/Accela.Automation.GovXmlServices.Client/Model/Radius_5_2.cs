using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Radius_5_2.
	/// </summary>
	public class Radius_5_2
	{
		public Radius_5_2()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlAttribute(AttributeName="unit")]
		public string unit;

		[XmlText()]
		public string text;
	}
}
