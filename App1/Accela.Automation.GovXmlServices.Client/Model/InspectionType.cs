/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: InspectionType.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Note
 *  Created By: Robert Luo
 *
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionType.
	/// </summary>
	public class InspectionType
	{
		public InspectionType()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;
		
		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "InspectionStatus")]
		public InspectionStatus inspectionStatus;

		[XmlElement(ElementName = "Dispositions")]
		public Dispositions dispositions;

		[XmlElement(ElementName = "GuidesheetIds")]
		public GuidesheetIds guidesheetIds;

		[XmlElement(ElementName = "autoAssign")]
		public bool autoAssign;

		[XmlElement(ElementName = "inspectionUnit")]
		public string inspectionUnit;

		[XmlElement(ElementName = "maxTotalGuidesheetsValue")]
		public string maxTotalGuidesheetsValue;

		[XmlElement(ElementName="useDefaultGuidesheets")]
		public string useDefaultGuidesheets;

        [XmlElement(ElementName = "StandardCommentsGroupIds")]
        public StandardCommentsGroupIds standardCommentsGroups;

        [XmlElement(ElementName = "GuidesheetGroups")]
        public GuidesheetGroups guidesheetGroups;

        //Author: Robert Luo
        //Date: 2008-1-28
        //Desc: AW for FRD 07ACC-01939 (Guide Sheet Carry Over Items).
        [XmlElement(ElementName = "carryOverFlag")]
        public string carryOverFlag;
        //End.

        [XmlElement(ElementName = "timeAccountSecurity")]
        public string timeAccountSecurity;
	}
}
