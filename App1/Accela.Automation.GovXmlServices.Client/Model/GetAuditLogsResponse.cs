#region Header

/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GetAuditLogsResponse
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:Get Audit Logs Response
 *  
 * 
 *  Note
 *  Created By:Liner.Lin
 * </pre>
 */

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetAssetTypesResponse.
	/// </summary>
	public class GetAuditLogsResponse:OperationResponse
	{
		public GetAuditLogsResponse()
		{
		}
 
        [XmlElement(ElementName = "AuditLogs")]
        public AuditLogs auditLogs;
	}
}
 