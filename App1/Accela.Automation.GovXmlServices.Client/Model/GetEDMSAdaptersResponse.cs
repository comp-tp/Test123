#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetEDMSAdaptersResponse.cs
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

    public class GetEDMSAdaptersResponse:OperationResponse
	{
        //Author:Liner Lin
        //Date:2009-06-04
        //Desc:09ACC-03832_EDMS Adapter
        public GetEDMSAdaptersResponse()
		{

		}
        [XmlElement(ElementName = "EDMSAdapters")]
        public EDMSAdapters EDMSAdapters;
	}
}
