/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GuideItem.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
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
	/// Summary description for Enumeration.
	/// </summary>
	/// 
	public class StringList
	{
		public StringList()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "String", IsNullable = true)]
		public string[] str;
	}

    public class Enumerations
    {
        [XmlElement(ElementName = "Enumeration")]
        public Enumeration[] AMOEnumeration;
    }
    public class Enumeration
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        /// <summary>
        /// <xsd:simpleType name="enumerationType">
        ///       <xsd:restriction base="xsd:string">
        ///              <xsd:enumeration value="N/A"/>
        ///              <xsd:enumeration value="Approved"/>
        ///              <xsd:enumeration value="Denied"/>
        ///              <xsd:enumeration value="Informational"/>
        ///       </xsd:restriction>
        ///</xsd:simpleType>
        /// </summary>
        [XmlElement(ElementName = "EnumerationType")]
        public string enumerationType;

        [XmlElement(ElementName = "description")]
        public string description;
    }

}
