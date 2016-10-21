using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Statuses.
	/// </summary>
	public class Statuses
	{
		public Statuses()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Status")]
		public Status[] status;
	}
}
