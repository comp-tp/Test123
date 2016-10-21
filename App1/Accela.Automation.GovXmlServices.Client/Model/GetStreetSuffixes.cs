#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: GetStreetSuffixes.cs
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

    /// <summary>
    /// Get Street suffiexes from AA biz server.
    /// </summary>
    public class GetStreetSuffixes
    {
        /// <summary>
        /// Gets or sets  System property
        /// </summary>
        [XmlElement(ElementName = "System")]
        public Sys system
        {
            get;
            set;
        }
    }
}
