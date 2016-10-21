#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: AssetCAType.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU at 9/3/2009 4:46:03 PM
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

    /// <summary>
    ///  the asset ca type class
    /// </summary>
    public class AssetCAType : element
    {
        #region Fields

        /// <summary>
        ///  the asset cap type keys
        /// </summary>
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        /// <summary>
        /// the asset cap type display
        /// </summary>
        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        /// <summary>
        ///the asset cap type description
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string description;

        /// <summary>
        /// the asset cap type additionalInformationGroupIds
        /// </summary>
        [XmlElement(ElementName = "AdditionalInformationGroupIds")]
        public AdditionalInformationGroupIds additionalInformationGroupIds;

        #endregion Fields
    }
}