#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: GetStreetSuffixesResponse.cs
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

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Get Street suffixes Response
    /// </summary>
    public class GetStreetSuffixesResponse
    {
        /// <summary>
        /// Gets or sets System.
        /// </summary>
        [XmlElement(ElementName = "System")]
        public Sys system
        {
            get;
            set;
        }

        [XmlElement(ElementName = "StreetSuffixes")]
        public StreetSuffixes StreetSuffixes
        {
            get;
            set;
        }
    }

    public class StreetSuffixes
    {
        [XmlElement(ElementName = "StreetSuffixesEnumerations")]
        public StreetSuffixesEnumerations StreetSuffixesEnumerations
        {
            get;
            set;
        }
    }

    public class StreetSuffixesEnumerations
    {
        [XmlElement(ElementName = "Enumeration")]
        public GISEnumeration[] Enumerations
        {
            get;
            set;
        }
    }
}
