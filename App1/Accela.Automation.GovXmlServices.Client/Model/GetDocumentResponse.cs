#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: CreateDocumentResponse.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetDocumentResponse.
	/// </summary>
	public class GetDocumentResponse:OperationResponse
	{
		public GetDocumentResponse()
		{
		}
		[XmlElement(ElementName="Document")]
		public Document document;

        [XmlElement(ElementName = "EDMSAdapter")]
        public EDMSAdapter EDMSAdapter;
	}
}
