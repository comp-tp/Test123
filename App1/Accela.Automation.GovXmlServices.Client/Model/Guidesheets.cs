using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Guidesheets.
	/// </summary>
	public class Guidesheets
	{
		public Guidesheets()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Guidesheet")]
		public Guidesheet[] guidesheet;
	}
}
