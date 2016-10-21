#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: AssetCAs.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU at 9/3/2009 5:50:03 PM
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
    ///  asset ca module
    /// </summary>
    public class AssetCAs 
    {
        #region Fields

        /// <summary>
        ///  the asset ca module
        /// </summary>
        [XmlElement(ElementName = "AssetCA")]
        public AssetCA[] assetCA;

        #endregion Fields
    }
}