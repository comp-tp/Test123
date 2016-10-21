#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: EDMSAdapter.cs
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

    public class EDMSAdapter
    {
        public EDMSAdapter()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        [XmlElement(ElementName = "Keys")]
        public Keys Keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string IdentifierDisplay;

        [XmlElement(ElementName = "Username")]
        public string Username;

        [XmlElement(ElementName = "Password")]
        public string Password;

        [XmlElement(ElementName = "default")]
        public string Default;

        [XmlElement(ElementName = "requiresPassword")]
        public string requiresPassword;

        [XmlElement(ElementName = "maxSize")]
        public string size;
    }
}
