#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: EDMSAdpaters.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2011
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
    //Author:Liner Lin
    //Date:2009-06-04
    //Desc:09ACC-03832_EDMS Adapter
    public class EDMSAdapters
    {
        public EDMSAdapters()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        [XmlElement(ElementName = "EDMSAdapter")]
        public EDMSAdapter[] edmsadapter;

        [XmlElement(ElementName = "fileTypes")]
        public string Type;
	}
}
