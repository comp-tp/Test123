#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: Condition.cs
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
	/// Summary description for Condition.
	/// </summary>
	/// 
	
	public class Condition
	{
		public Condition()
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

		[XmlElement(ElementName = "SeverityLevel")]
		public SeverityLevel severityLevel;

		[XmlElement(ElementName = "Status")]
		///Author:Liner
        ///Date:2008-01-14
        ///Desc:06239
        //public ConditionStatus status;
        public Status status;
        //end

		[XmlElement(ElementName = "EffectiveDate")]
		public string effectiveDate;
		
		[XmlElement(ElementName = "ExpirationDate")]
		public string expirationDate;
		
		[XmlElement(ElementName = "ApplyDate")]
		public string applyDate;
		
		[XmlElement(ElementName = "Date")]
		public string date;

		[XmlElement(ElementName = "Time")]
		public string time;

		[XmlElement(ElementName = "DataType")]
		public DataType dataType;

		[XmlElement(ElementName = "Value")]
		public string val;

        //[XmlElement(ElementName = "Text")]
        //public string text;

		[XmlElement(ElementName = "RecordedBy")]
		public string recordedBy;

		[XmlAttribute(AttributeName="action")]
		public string action;

        /// <summary>
        /// Author:Liner
        /// Date:2008-01-15
        /// Desc:06239
        /// </summary>
        [XmlElement(ElementName = "Name")]
        public string ConditionName;

        [XmlElement(ElementName = "ShortComment")]
        public string ShortComment;

        [XmlElement(ElementName = "LongComment")]
        public string LongComment;

        [XmlElement(ElementName = "ResolutionAction")]
        public string ResolutionAction;

        [XmlElement(ElementName = "PublicDisplayMessage")]
        public string PublicDisplayMessage;

        //[XmlElement(ElementName = "LongCommentLength")]
        //public int LongCommentLength;

        //[XmlElement(ElementName = "ShortCommentLength")]
        //public int ShortCommentLength;

        //[XmlElement(ElementName = "ResolutionActionLength")]
        //public int ResolutionActionLength;

        //[XmlElement(ElementName = "PublicDisplayMessageLength")]
        //public int PublicDisplayMessageLength;

        //[XmlElement(ElementName = "ConditionNameLength")]
        //public int ConditionNameLength;


        [XmlElement(ElementName = "DisplayConditionNotice")]
        public string DisplayConditionNotice;
        [XmlElement(ElementName = "IncludeInConditionName")]
        public string IncludeInConditionName;
        [XmlElement(ElementName = "IncludeInShortDescription")]
        public string IncludeInShortDescription;
        [XmlElement(ElementName = "Inheritable")]
        public string Inheritable;

        [XmlElement(ElementName = "OpenCondition")]
        public string OpenCondition;

        //Author:Liner Lin
        //Date:2008-10-31
        //Desc:03707 Apply Parcel Conditions
        [XmlElement(ElementName = "ReadOnly")]
        public string ReadOnly;
        //end      
        [XmlElement(ElementName = "AdditionalInformation")]
        public AdditionalInformation additionalInformation;

        [XmlElement(ElementName = "ConditionGroup")]
        public ConditionGroup conditionGroup;

        [XmlElement(ElementName = "Priority")]
        public Enumeration conditionPriority;

        [XmlElement(ElementName = "conditionOfApproval")]
        public string conditionOfApproval;


        //add department to CAP
        [XmlElement(ElementName = "ActionByDepartment")]
        public Department actionByDepartment;
   
	}
}

