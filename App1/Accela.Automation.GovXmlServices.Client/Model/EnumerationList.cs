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
	/// Summary description for EnumerationList.
	/// </summary>
	public class EnumerationList
	{
		public EnumerationList()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "id")]
		public string id;

		[XmlElement(ElementName = "enumeration")]
		public StringList enumeration;

        [XmlElement(ElementName = "Enumerations")]
        public Enumerations Enumerations;
	}
}
