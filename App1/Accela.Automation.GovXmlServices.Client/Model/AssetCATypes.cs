#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: AssetCATypes.cs
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
    /// Summary description for AssetCATypes.
    /// </summary>
    public class AssetCATypes : ElementList
    {
        #region Fields

        /// <summary>
        ///  the asset CA types summary
        /// </summary>
        [XmlElement(ElementName = "AssetCAType")]
        public AssetCAType[] assetCATypes;

        #endregion Fields
    }
}