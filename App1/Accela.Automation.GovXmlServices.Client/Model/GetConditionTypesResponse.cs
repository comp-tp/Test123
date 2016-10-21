using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for GetConditionTypesResponse.
	/// </summary>
	public class GetConditionTypesResponse
	{
		public GetConditionTypesResponse()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;
	
		[XmlElement(ElementName = "ConditionTypes")]
		public ConditionTypes conditionTypes;
	}
}
