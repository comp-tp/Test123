#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: CreateDocumentList.cs
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
	/// Summary description for GetDocumentList.
	/// </summary>
	public class GetDocumentList:OperationRequest
	{
		public GetDocumentList()
		{
		}
		[XmlElement(ElementName="ObjectId")]
		public ObjectId objectId;

        [XmlElement(ElementName = "EDMSAdapters")]
        public EDMSAdapters EDMSAdapters;
	}
}
