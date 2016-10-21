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
	/// Summary description for AdditionalInformationGroup.
	/// </summary>
	public class AdditionalInformationGroup
	{
		public AdditionalInformationGroup()
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

		[XmlElement(ElementName = "Description")]
		public string description;

		[XmlElement(ElementName = "AdditionalInformationSubGroup")]
		public AdditionalInformationSubGroup[] additionalInformationSubGroup;

		[XmlElement(ElementName = "EnumerationLists")]
		public EnumerationLists enumerationLists;

		[XmlElement(ElementName ="addRemoveSubGroups")]
		public bool AddRemoveSubGroups;

        /// <summary>
        /// translate the security node
        /// </summary>
        [XmlElement(ElementName="security")]
        public string security;
	}
}
