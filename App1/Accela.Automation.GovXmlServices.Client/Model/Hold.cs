using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Hold.
	/// </summary>
	/// 
	
	public class Hold : Condition
	{
		public Hold()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "HoldLevel")]
		public HoldLevel holdLevel;
	}
}
