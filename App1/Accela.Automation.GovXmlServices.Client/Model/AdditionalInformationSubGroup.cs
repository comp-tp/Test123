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
using Accela.Automation.GovXmlServices.Client.Model;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for AdditionalInformationGroup.
	/// </summary>
	public class AdditionalInformationSubGroup
	{
		public AdditionalInformationSubGroup()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "AdditionalItems")]
		public AdditionalItems additionalItems;

		[XmlAttribute(AttributeName="action")]
		public string action;

		/// <summary>
		/// translate the security node
		/// </summary>
		[XmlElement(ElementName = "security")]
		public string security;

		/// <summary>
		/// structural
		/// data
		/// </summary>
		[XmlAttribute(AttributeName = "type")]
		public string type;

		[XmlElement(ElementName = "DrillDown")]
		public DrillDown drillDown;

		[XmlElement(ElementName = "SubGroupAlias")]
		public string SubGroupAlias;
	}
}
