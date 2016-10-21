using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for CAPStatuses.
	/// </summary>
	public class CAPStatuses
	{
		public CAPStatuses()
		{
		}

		[XmlElement(ElementName = "CAPStatus")]
		public CAPStatus[] capStatus;
	}
}
