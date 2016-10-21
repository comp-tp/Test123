#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: AssetCA.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU at 9/2/2009 2:07:03 PM
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
    ///  AssetCA module
    /// </summary>
    public class AssetCA
    {
        #region Fields

        /// <summary>
        ///  the assessment keys
        /// </summary>
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        /// <summary>
        /// the display
        /// </summary>
        [XmlElement(ElementName = "IdentifierDisplay")]
        public string IdentifierDisplay;

        /// <summary>
        ///  the context type
        /// </summary>
        [XmlElement(ElementName = "contextType")]
        public string contextType;

        /// <summary>
        ///  the asset object
        /// </summary>
        [XmlElement(ElementName = "Asset")]
        public Asset asset;

        /// <summary>
        ///  the status object
        /// </summary>
        [XmlElement(ElementName = "AssetCAStatus")]
        public Status status;

        /// <summary>
        /// AssessmentType module
        /// </summary>
        [XmlElement(ElementName = "AssetCAType")]
        public AssetCAType assetCAType;

        /// <summary>
        ///  the schedule date
        /// </summary>
        [XmlElement(ElementName = "ScheduleDate")]
        public string scheduleDate;

        /// <summary>
        ///  the schedule time
        /// </summary>
        [XmlElement(ElementName = "ScheduleTime")]
        public string scheduleTime;

        /// <summary>
        ///  the inspection date
        /// </summary>
        [XmlElement(ElementName = "InspectionDate")]
        public string inspectionDate;

        /// <summary>
        /// the inspection time
        /// </summary>
        [XmlElement(ElementName = "InspectionTime")]
        public string inspectionTime;

        /// <summary>
        /// add department to CAP
        /// </summary>
        [XmlElement(ElementName = "Department")]
        public Department department;

        /// <summary>
        /// add staffperson to CAP
        /// </summary>
        [XmlElement(ElementName = "StaffPerson")]
        public StaffPerson staffPerson;

        /// <summary>
        /// the time spent object
        /// </summary>
        [XmlElement(ElementName = "TimeSpent")]
        public double timeSpent;

        /// <summary>
        ///  the comments
        /// </summary>
        [XmlElement(ElementName = "comment")]
        public string comment;

        /// <summary>
        ///  Asset CA id 
        /// </summary>
        [XmlElement(ElementName = "AssetCAId")]
        public string assetCAId;

        /// <summary>
        ///  the additional information
        /// </summary>
        [XmlElement(ElementName = "AdditionalInformation")]
        public AdditionalInformation additionalInformation;

        /// <summary>
        ///  action type
        /// </summary>
        [XmlAttribute(AttributeName = "action")]
        public string action;

        /// <summary>
        ///the asset cap type description
        /// </summary>
        [XmlElement(ElementName = "Description")]
        public string description;

        /// <summary>
        ///  the Observation information
        /// </summary>
        [XmlElement(ElementName = "Observation")]
        public AdditionalInformation observation;

        #endregion Fields
    }
}