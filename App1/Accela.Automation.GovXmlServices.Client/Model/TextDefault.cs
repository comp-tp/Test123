#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: TextDefault.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
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
    public class TextDefault
    {
        /// <summary>
        /// Author:Liner
        /// Date:2008-01-07
        /// Desc:06239
        /// </summary>
        public TextDefault()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "Keys")]
        public Keys Keys;
       
        [XmlElement(ElementName = "Name")]
        public string ConditionName;

        [XmlElement(ElementName = "LongComment")]
        public string LongComment;

        [XmlElement(ElementName = "PublicDisplayMessage")]
        public string PubDisMessage;

        [XmlElement(ElementName = "ResolutionAction")]
        public string ResolutionAction;

        [XmlElement(ElementName = "ShortComment")]
        public string ShortComment;

        [XmlElement(ElementName = "DisplayConditionNotice")]
        public string DisplayConditionNotice;
        [XmlElement(ElementName = "IncludeInConditionName")]
        public string IncludeInConditionName;
        [XmlElement(ElementName = "IncludeInShortDescription")]
        public string IncludeInShortComment;
        [XmlElement(ElementName = "Inheritable")]
        public string Inheritable;

        /// <summary>
        /// Severity level of text default.
        /// </summary>
        [XmlElement(ElementName = "SeverityLevel")]
        public SeverityLevel SeverityLevel;

        [XmlElement(ElementName = "AdditionalInformation")]
        public AdditionalInformation additionalInformation;
    }
}
