/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: Sys.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2008-2009
 * 
 *  Description:
 * 
 *  Note
 *  Created By: Robert Luo
 * </pre>
 */
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Equivalent of "System" in GovXML (the compiler won't allow use of that name).
	/// </summary>
	/// 
	public class Sys
	{
		public Sys() {}

		public Sys(string serviceProviderCode)
		{
//			this.xmlVersion = GovXML.XML_VERSION;
			this.serviceProviderCode = serviceProviderCode;
            this.context = "AccelaMobileOffice";
		}

		[XmlElement(ElementName = "XMLVersion")]
		public string xmlVersion;

		[XmlElement(ElementName = "SenderVersion")]
		public string senderVersion;

		[XmlElement(ElementName = "ServiceProviderCode")]
		public string serviceProviderCode;

		[XmlElement(ElementName = "Username")]
		public string username;

		[XmlElement(ElementName = "MaxRows")]
		public int maxRows;

		[XmlElement(ElementName = "StartRow")]
		public int startRow;

		[XmlElement(ElementName = "EndRow")]
		public int endRow;

		[XmlElement(ElementName = "TotalRows")]
		public int totalRows;

		[XmlElement(ElementName = "ApplicationState")]
		public string applicationState;

		[XmlElement(ElementName = "Context")]
		public string context;

		[XmlElement(ElementName = "Error")]
		public Error error;

		[XmlElement(ElementName = "Messages")]
		public EventMessages eventMessages;
		/// <summary>
		/// Deprecated format for error reporting.  Use "Error" class instead where possible.
		/// </summary>
		[XmlElement(ElementName = "ErrorCode")]
		public string errorCode;

		[XmlElement(ElementName = "ErrorMessage")]
		public string errorMessage;

        [XmlElement(ElementName = "LanguageID")]
        public string language;

	}
}
