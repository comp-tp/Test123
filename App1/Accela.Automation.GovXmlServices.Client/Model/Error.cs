using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Error handling element
	/// </summary>
	/// 
	
	public class Error
	{
		public Error(){}

		[XmlElement(ElementName = "ErrorCode")]
		public string errorCode;

		[XmlElement(ElementName = "ErrorClass")]
		public string errorClass;

		[XmlElement(ElementName = "ErrorDetail")]
		public string errorDetail;

		[XmlElement(ElementName = "ErrorMessage")]
		public string errorMessage;

	}
}
