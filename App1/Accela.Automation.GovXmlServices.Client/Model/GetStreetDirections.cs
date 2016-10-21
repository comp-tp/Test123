#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: GetStreetDirections.cs
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

    public class GetStreetDirections
    {
        #region Fields

        [XmlElement(ElementName = "System")]
        public Sys system;

        #endregion Fields

        #region Constructors

        public GetStreetDirections()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructors
    }
}