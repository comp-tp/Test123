#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssetCAListRequest.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU at 9/3/2009 5:56:03 PM
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
    ///  Get asset ca list request class
    /// </summary>
    public class GetAssetCAs : OperationRequest
    {
        #region Fields

        /// <summary>
        ///  the assessment id
        /// </summary>
        [XmlElement(ElementName = "assetCAId")]
        public string assetCAId;

        /// <summary>
        ///  the assessment type key
        /// </summary>
        [XmlElement(ElementName = "AssetCAType")]
        public AssetCAType AssetCAType;

        /// <summary>
        ///  the asset id
        /// </summary>
        [XmlElement(ElementName = "AssetId")]
        public string AssetId;

        /// <summary>
        /// The asset types
        /// </summary>
        [XmlElement(ElementName = "AssetTypes")]
        public AssetTypes assetTypes;

        /// <summary>
        ///  the department 
        /// </summary>
        [XmlElement(ElementName = "Departments")]
        public Departments Departments; 

        /// <summary>
        ///  the assessment status
        /// </summary>
        [XmlElement(ElementName = "AssetCAStatus")]
        public Status AssetCAStatus;

        /// <summary>
        ///  the comment
        /// </summary>
        [XmlElement(ElementName = "comment")]
        public string comment;

        /// <summary>
        ///  inspection date range
        /// </summary>
        [XmlElement(ElementName = "inspectionDateRanges")]
        public DateRange inspectionDateRanges;

        /// <summary>
        ///  scheduled date range
        /// </summary>
        [XmlElement(ElementName = "scheduledDateRanges")]
        public DateRange scheduledDateRanges;

        /// <summary>
        ///  the spent range
        /// </summary>
        [XmlElement(ElementName = "spentHoursRanges")]
        public Range spentHoursRanges;

        /// <summary>
        ///  the spent range
        /// </summary>
        [XmlElement(ElementName = "AssetIds")]
        public AssetIds AssetIds;

        [XmlElement(ElementName = "DateRanges")]
        public DateRanges dateRanges;

        /// <summary>
        /// Asset
        /// </summary>
        [XmlElement(ElementName = "Asset")]
        public Asset asset;

        #endregion Fields
    }
}