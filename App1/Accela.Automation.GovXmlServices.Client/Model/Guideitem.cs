/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GuideItem.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 * 
 *  Description:
 *  This is GuideItem's model
 * 
 *  Note
 *  Created By: Code Generator
 *
 * </pre>
 */
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Summary description for Guideitem.
    /// </summary>
    public class Guideitem
    {
        public Guideitem()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string globalId;

        [XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
        public string ownerHistory;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "contextType")]
        public string contextType;

        [XmlElement(ElementName = "Type")]
        public Type type;

        [XmlElement(ElementName = "Description")]
        public string description;

        [XmlElement(ElementName = "Date")]
        public string date;

        [XmlElement(ElementName = "Time")]
        public string time;

        [XmlElement(ElementName = "DataType")]
        public DataType dataType;

        [XmlElement(ElementName = "Value")]
        public string dataValue;

        [XmlElement(ElementName = "Text")]
        public string text;

        [XmlElement(ElementName = "applicability")]
        public string applicability;

        /// <summary>
        /// this is for multiple language, we have keep applicability to compatibility before.
        /// </summary>
        [XmlElement(ElementName = "Status")]
        public Enumeration Status;

        [XmlElement(ElementName = "applicabilityEnumerationListId")]
        public string applicabilityEnumerationListId;

        [XmlElement(ElementName = "correctionCode")]
        public string correctionCode;

        [XmlElement(ElementName = "violationCode")]
        public string violationCode;

        [XmlElement(ElementName = "critical")]
        public string critical;

        [XmlElement(ElementName = "RecordedBy")]
        public string recordedBy;

        [XmlElement(ElementName = "defaultValue")]
        public string defaultValue;

        [XmlElement(ElementName = "maxValue")]
        public string maxValue;

        [XmlElement(ElementName = "class")]
        public string Class;

        [XmlElement(ElementName = "StandardCommentsGroupIds")]
        public StandardCommentsGroupIds standardCommentsGroupIds;

        //Author: Robert Luo
        //Date: 2008-1-28
        //Desc: AW for FRD 07ACC-01939 (Guide Sheet Carry Over Items).
        [XmlElement(ElementName = "carryOverFlag")]
        public string carryOverFlag;
        //End.

        //Author:Liner Lin
        //Date:2008-10-25
        //Desc:08ACC-06267 GuideSheet Templated Data
        [XmlElement(ElementName = "AdditionalInformation")]
        public AdditionalInformation additionalInformation;
        //end

        [XmlElement(ElementName = "DescriptionEnumeration")]
        public Enumeration DescriptionEnumeration;
    }
}
