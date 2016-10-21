#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: ValueRange.cs
*
*  Accela, Inc.
*  Copyright (C): 2010
*
*  Description:
*  Create By Tonee at 3/26/2009 7:31:00 PM
*  Notes:
* </pre>
*/

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class ValueRange
    {
        public ValueRange()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        [XmlElement(ElementName = "startingValue")]
        public string startingValue;

        [XmlElement(ElementName = "endingValue")]
        public string endingValue;
    }
}
