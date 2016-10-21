#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: CostAccountIdentifier.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By Tim-XU at 9/25/2009

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

    public class CostAccountIdentifier : element
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;
    }
}
