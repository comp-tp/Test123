#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: StreetDirections.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 *
 *  Description:
 *
 *
 *  Note
 *  Created By: Daniel Deng
 *
 * </pre>
 */

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

    public class GISEnumeration
    {
        #region Properties

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string IdentifierDisplay
        {
            get;
            set;
        }

        [XmlElement(ElementName = "Keys")]
        public Keys Keys
        {
            get;
            set;
        }

        #endregion Properties
    }

    public class StreetDirections
    {
        #region Properties

        [XmlElement(ElementName = "StreetDirectionsEnumerations")]
        public StreetDirectionsEnumerations StreetDirectionsEnumerations
        {
            get;
            set;
        }

        #endregion Properties
    }

    public class StreetDirectionsEnumerations
    {
        #region Properties

        [XmlElement(ElementName = "Enumeration")]
        public GISEnumeration[] Enumerations
        {
            get;
            set;
        }

        #endregion Properties
    }
}