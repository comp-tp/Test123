#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: GetStreetDirectionsResponse.cs
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

namespace Accela.GIS.GovXml.Model
{
    using System.Xml.Serialization;
    using Accela.Automation.GovXmlClient.Model;

    /// <summary>
    /// Get Street directions Response
    /// </summary>
    public class GetStreetDirectionsResponse
    {
        #region Properties

        [XmlElement(ElementName = "StreetDirections")]
        public StreetDirections StreetDirections
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets System.
        /// </summary>
        [XmlElement(ElementName = "System")]
        public Sys system
        {
            get;
            set;
        }

        #endregion Properties
    }
}