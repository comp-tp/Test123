using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ObjectResponse.
	/// </summary>
	public class OperationResponse
	{
		public OperationResponse()
		{
		}
		[XmlElement(ElementName = "System")]
		public Sys system;
	}
}
