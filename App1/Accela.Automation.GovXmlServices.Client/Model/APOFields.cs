/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File:APOFields.cs
 * 
 *  Accela, Inc.
 *  Copyright (C):2011
 * 
 *  Description:
 *  All DataModel class must inherit the class.
 * 
 *  Note
 *  Created By:derek zhan
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Addresses.
	/// </summary>
	/// 
    public class APOFields
    {
        public APOFields()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "APOField", IsNullable = true)]
        public APOField[] APOField;
    }
    public  class  APOField
    {
        
        public APOField()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "recordSearchable ")]
        public string recordSearchable;

        [XmlElement(ElementName = "AdditionalItem")]
        public AdditionalItem AdditionalItem;
    }
}
