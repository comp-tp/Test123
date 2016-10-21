#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: UpdateAssetCARequest.cs
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

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

    /// <summary>
    ///  Update asset ca request class
    /// </summary>
    public class UpdateAssetCA : OperationRequest
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