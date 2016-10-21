#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: ConditionGroup.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2011
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
	public class ConditionGroup
	{
        public ConditionGroup()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;


        [XmlElement(ElementName = "ConditionTypes")]
        public ConditionTypes conditionTypes;

		
	}
}
