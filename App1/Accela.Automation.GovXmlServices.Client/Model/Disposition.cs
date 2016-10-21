#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: Status
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 *
 *  Description:Status
 *
 *
 *  Note
 *  Created By:
 *  Modified By:
 * </pre>
 */

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

    /// <summary>
    /// Summary description for Disposition.
    /// </summary>
    public class Disposition
    {
        #region Fields

        ///Author:Liner
        ///Date:2008-01-14
        ///Desc:06239
        [XmlElement(ElementName = "Applied")]
        public string Applied;

        /// <summary>
        /// status group
        /// </summary>
        [XmlElement(ElementName = "StatusGroup")]
        public Identifier StatusGroup;

        /// <summary>
        /// identifier display
        /// </summary>
        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        /// <summary>
        /// disposition keys
        /// </summary>
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        /// <summary>
        /// resolution type
        /// </summary>
        [XmlElement(ElementName = "resolutionType")]
        public string resolutionType;

        #endregion Fields

        #region Constructors

        public Disposition()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructors
    }
}