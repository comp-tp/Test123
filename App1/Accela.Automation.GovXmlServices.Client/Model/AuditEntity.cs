/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: AuditEntity.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 *  This is AuditEntity's model
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
    public class AuditEntity
    {
        public AuditEntity()
        {}

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "entityId")]
        public string entityId;

        [XmlElement(ElementName = "entityType")]
        public string entityType;
    }
}
