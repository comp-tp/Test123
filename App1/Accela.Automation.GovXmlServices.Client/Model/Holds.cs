using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Holds.
	/// </summary>
	/// 
	
	public class Holds
	{
		public Holds()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Hold", IsNullable = true)]
		public Hold[] hold;
	}
}
