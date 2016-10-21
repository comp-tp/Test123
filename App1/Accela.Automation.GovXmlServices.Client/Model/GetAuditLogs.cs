#region Header

/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GetAuditLogs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:Get Audit Logs
 *  
 * 
 *  Note
 *  Created By:Liner.Lin
 * </pre>
 */

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
     using System.Xml.Serialization;

	/// <summary>
    /// Summary description for GetAuditLogs.
	/// </summary>
    public class GetAuditLogs
    {
        public GetAuditLogs()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "System")]
        public Sys system;

        /// <summary>
        /// CAP ID
        /// </summary>
        [XmlElement(ElementName = "entityId")]
        public string entityId;

        [XmlElement(ElementName = "entityType")]
        public string entityType;

        [XmlElement(ElementName = "EntityKeys")]
        public Keys entityKey;

        [XmlElement(ElementName = "field")]
        public string field;

        [XmlElement(ElementName = "fieldValue")]
        public string fieldValue;

        [XmlElement(ElementName = "DateRange")]
        public DateRange dateRange;        

        [XmlElement(ElementName = "InspectorId")]
        public InspectorId inspectorId;

        [XmlElement(ElementName = "OrderBy")]
        public Enumerations orderBy;
    }     
}
