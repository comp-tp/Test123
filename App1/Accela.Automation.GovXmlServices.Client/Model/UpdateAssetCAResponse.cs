#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: UpdateAssetCAResponse.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU at 9/11/2009 2:15:03 PM
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    ///  this is asset ca response class
    /// </summary>
    public class UpdateAssetCAResponse : OperationResponse
    {
        #region Fields

        /// <summary>
        ///  this is asset ca use to update
        /// </summary>
        [XmlElement(ElementName = "AssetCA")]
        public AssetCA assetCA;

        #endregion Fields
    }
}