using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Operation sent from Application Server when fatal errors occur.
	/// </summary>
	/// 
	
	public class FSystemOut
	{
		public FSystemOut(){}

		[XmlElement(ElementName = "System")]
		public Sys system;
	}
}
