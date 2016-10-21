using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GuidesheetIds.
	/// </summary>
	public class GuidesheetIds
	{
		public GuidesheetIds()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "GuidesheetId")]
		public GuidesheetId[] guidesheetId;
	}
}
