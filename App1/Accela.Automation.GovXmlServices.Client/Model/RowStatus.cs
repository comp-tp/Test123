using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for RowStatus.
	/// </summary>
	public class RowStatus
	{
		public RowStatus()
		{
			//
			// TODO: Add constructor logic here
			//
		}

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
