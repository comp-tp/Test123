using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Operation sent from Application Server when fatal errors occur.
	/// </summary>
	/// 
	public class SystemResponse
	{
		public SystemResponse(){}

		[XmlElement(ElementName = "System")]
		public Sys system;
	}
}
