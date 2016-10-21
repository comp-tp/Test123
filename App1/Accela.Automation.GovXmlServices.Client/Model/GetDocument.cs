#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetDocument.cs
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
	/// Summary description for GetDocument.
	/// </summary>
	public class GetDocument:OperationRequest
	{
		public GetDocument()
		{
		}
		[XmlElement(ElementName="DocumentId")]
		public DocumentId documentId;

        [XmlElement(ElementName = "EDMSAdapter")]
        public EDMSAdapter EDMSAdapter;
	}
}
