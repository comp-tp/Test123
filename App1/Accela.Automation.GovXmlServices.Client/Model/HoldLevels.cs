using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for HoldLevels.
	/// </summary>
	public class HoldLevels
	{
		public HoldLevels()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="HoldLevel")]
		public HoldLevel[] holdLevel;
	}
}
