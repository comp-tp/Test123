/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: AuditLog.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 *  This is AuditLog's model
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
	/// Summary description for AuditLog.
	/// </summary>
	/// 

    public class AuditLog
    {
        public AuditLog()
        {     
        }

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "Entity")]
        public AuditEntity entity;

        [XmlElement(ElementName = "logAction")]
        public string logAction;

        [XmlElement(ElementName = "logDate")]
        public string logDate;

        [XmlElement(ElementName = "logTime")]
        public string logTime;

        [XmlElement(ElementName = "field")]
        public string field;

        [XmlElement(ElementName = "fieldValue")]
        public string fieldValue;

        [XmlElement(ElementName = "product")]
        public string product;

        [XmlElement(ElementName = "operator")]
        public string auditOperator;

        [XmlElement(ElementName = "relationShip")]
        public string relationship;
    }
}
