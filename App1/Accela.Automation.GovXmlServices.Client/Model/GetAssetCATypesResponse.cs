#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssetCATypeResponse.cs
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
    ///  the get asset CA type response class
    /// </summary>
    public class GetAssetCATypesResponse : OperationResponse
    {
        #region Fields

        /// <summary>
        /// asset ca types
        /// </summary>
        [XmlElement(ElementName = "AssetCATypes")]
        public AssetCATypes assetCATypes;

        #endregion Fields
    }
}