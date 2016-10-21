#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssetCAListResponse.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU at 9/3/2009 5:57:03 PM
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
    ///  assesst ca list response class
    /// </summary>
    public class GetAssetCAsResponse : OperationResponse
    {
        #region Fields

        [XmlElement(ElementName = "AssetCAs")]
        public AssetCAs assetCAs;

        #endregion Fields
    }
}