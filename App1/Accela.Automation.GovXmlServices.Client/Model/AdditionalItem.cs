#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: AdditionalGroup.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 *
 *  Description:
 *  This is AdditionalGroup's model
 *
 *  Note
 *  Created By: Code Generator
 *
 * </pre>
 */

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for AdditionalItem.
	/// </summary>
	/// 
	
	public class AdditionalItem
	{
		public AdditionalItem()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "contextType")]
		public string contextType;

		[XmlElement(ElementName = "DataType")]
		public DataType dataType;

		[XmlElement(ElementName = "Name")]
		public string name;

		[XmlElement(ElementName = "Value")]
		public string val;

		[XmlElement(ElementName = "UnitOfMeasurement")]
		public string unitOfMeasurement;

		[XmlAttribute(AttributeName="action")]
		public string action;

        /// <summary>
        /// translate the security node
        /// </summary>
        [XmlElement(ElementName = "security")]
        public string security;

        [XmlElement(ElementName = "drillDown")]
        public string drillDown;
	}
}
