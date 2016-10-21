#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: GetConditionTypes.cs
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
	/// Summary description for GetConditionTypes.
	/// </summary>
	public class GetConditionTypes
	{
		public GetConditionTypes()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

        [XmlElement(ElementName = "returnElements")]
        public returnElements returnElements;
	
		[XmlElement(ElementName = "contextType")]
		public string contextType;
	
		[XmlElement(ElementName = "CAPIds")]
		public CAPIds capIds;
	
		[XmlElement(ElementName = "CAPTypeIds")]
		public CAPTypeIds capTypeIds;
	
		[XmlElement(ElementName = "DateRanges")]
		public DateRanges dateRanges;
	
		[XmlElement(ElementName = "InspectionIds")]
		public InspectionIds inspectionIds;
	
		[XmlElement(ElementName = "InspectionTypes")]
		public InspectionTypes inspectionTypes;
	}
}
