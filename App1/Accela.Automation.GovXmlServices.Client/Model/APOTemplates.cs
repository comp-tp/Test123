#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: APOTemplates.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2011
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
	
	public class APOTemplates
	{
        public APOTemplates()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        [XmlElement(ElementName = "APOTemplate", IsNullable = true)]
        public APOTemplate[] APOTemplate;
	}
    public class APOTemplate
    {
        public APOTemplate()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "templateType")]
        public string templateType;

        [XmlElement(ElementName = "APOFields")]
        public APOFields APOFields;
    }
}
