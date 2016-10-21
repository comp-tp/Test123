using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ObjectRequest.
	/// </summary>
	public class OperationRequest
	{
		public OperationRequest()
		{
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "Options")]
		public Options options;
	}
}
