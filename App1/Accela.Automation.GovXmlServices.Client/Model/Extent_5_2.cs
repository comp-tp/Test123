using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Extent_5_2.
	/// </summary>
	public class Extent_5_2
	{
		public Extent_5_2()
		{
		}
		[XmlElement(ElementName = "Radius")]
		public Radius_5_2 radius;
	}
}
