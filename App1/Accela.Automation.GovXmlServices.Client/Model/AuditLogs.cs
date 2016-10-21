/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: AuditLogs.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 *  This is AuditLogs's model
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
    public class AuditLogs
    {

        public AuditLogs()
        { }

        [XmlElement(ElementName = "AuditLog")]
        public AuditLog[] auditLog;
    }
}
