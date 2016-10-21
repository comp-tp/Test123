using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Inspectors.
	/// </summary>
	public class Inspectors
	{
		public Inspectors()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Inspector")]
		public Inspector[] inspector;

	}
}
