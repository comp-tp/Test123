#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: CreateDocument.cs
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
	/// Summary description for CreateDocument.
	/// </summary>
	public class CreateDocument:OperationRequest
	{
		public CreateDocument()
		{
		}
		[XmlElement(ElementName="ObjectId")]
		public ObjectId objectId;

		[XmlElement(ElementName="Document")]
		public Document document;

        [XmlElement(ElementName = "EDMSAdapter")]
        public EDMSAdapter edmsAdapter;
	}
}
