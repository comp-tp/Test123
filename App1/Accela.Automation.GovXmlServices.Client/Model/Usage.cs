/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: Usage.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Note
 *  Created By: Pearl Luo
 *
 * </pre>
 */
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Usage
	{
		public Usage()
		{
		}

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "AssetId")]
        public AssetId assetId;

        [XmlElement(ElementName = "reading")]
        public double reading;

        [XmlElement(ElementName = "difference")]
        public double difference;

        [XmlElement(ElementName = "UnitType")]
        public Type unitType;

        [XmlElement(ElementName = "readingDate")]
        public string readingDate;

        [XmlElement(ElementName = "ReadingByDepartment")]
        public Department department;

        [XmlElement(ElementName = "ReadingByStaff")]
        public StaffPerson readingByStaff;

        [XmlElement(ElementName = "CapId")]
        public CAPId capId;

        [XmlElement(ElementName = "generatedWO")]
        public string generatedWO;

        [XmlElement(ElementName = "comments")]
        public string comments;

        [XmlAttribute(AttributeName = "action")]
        public string action;	
	}
}
