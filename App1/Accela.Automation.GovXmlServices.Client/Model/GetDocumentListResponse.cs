#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: CreateDocumentListResponse.cs
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
	/// Summary description for GetDocumentListResponse.
	/// </summary>
	public class GetDocumentListResponse:OperationResponse
	{
		public GetDocumentListResponse()
		{
		}
		[XmlElement(ElementName="DocumentSets")]
		public DocumentSets documentSets;

        [XmlElement(ElementName = "EDMSAdapters")]
        public EDMSAdapters EDMSAdapters;
	}
}
