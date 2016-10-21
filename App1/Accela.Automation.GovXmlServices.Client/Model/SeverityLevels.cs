using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for SeverityLevels.
	/// </summary>
	public class SeverityLevels
	{
		public SeverityLevels()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "SeverityLevel")]
		public SeverityLevel[] severityLevel;
	}
}
