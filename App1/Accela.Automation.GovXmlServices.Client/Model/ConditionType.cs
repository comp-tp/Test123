#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: ConditionType.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2010
 *
 *  Description:
 *  All DataModel class must inherit the class.
 *
 *  Note
 *  Created By: code generator
 * </pre>
 */

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ConditionType.
	/// </summary>
	public class ConditionType
	{
		public ConditionType()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Keys")]
		public Keys keys;
		
		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "Dispositions")]
		public Dispositions dispositions;

		[XmlElement(ElementName = "SeverityLevels")]
		public SeverityLevels severityLevels;

        /// <summary>
        /// Authour:Liner
        /// Date:2008-01-15
        /// Desc:06239
        /// </summary>
        [XmlElement(ElementName = "TextDefaults")]
        public TextDefaults TextDefaults;

        [XmlElement(ElementName = "LongCommentLength")]
        public int LongCommentLength;

        [XmlElement(ElementName = "ShortCommentLength")]
        public int ShortCommentLength;

        [XmlElement(ElementName = "ResolutionActionLength")]
        public int ResolutionActionLength;

        [XmlElement(ElementName = "PublicDisplayMessageLength")]
        public int PublicDisplayMessageLength;

        [XmlElement(ElementName = "NameLength")]
        public int ConditionNameLength;

        [XmlElement(ElementName = "AdditionalInformationGroupIds")]
        public AdditionalInformationGroupIds additionalInformationGroupIds;
	}
}
