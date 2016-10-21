using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Dispositions.
	/// </summary>
	public class Dispositions
	{
		public Dispositions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Disposition")]
		public Disposition[] disposition;
	}
}
