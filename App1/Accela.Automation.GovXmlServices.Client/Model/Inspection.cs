/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: ConfigureInfo.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 *
 *  Description:
 *  The class is used to write object to binary file or binary stream.
 *
 *  Note
 *  Created By: Inheritting from AW
 *  Create Date:
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Core inspection element.
	/// </summary>
	/// 
	
	public class Inspection
	{

		[XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public string globalId;
		
		[XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public string ownerHistory;

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "contextType")]
		public string contextType;

		[XmlElement(ElementName = "priority")]
		public string priority;

		[XmlElement(ElementName = "CAP")]
		public CAP cap;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;

		[XmlElement(ElementName = "CompactAddress")]
		public CompactAddress compactAddress;

		[XmlElement(ElementName = "DetailAddress")]
		public DetailAddress detailAddress;

		[XmlElement(ElementName = "Type")]
		public Type type;

		[XmlElement(ElementName = "InspectionStatus")]
		public InspectionStatus inspectionStatus;

		[XmlElement(ElementName = "Dispositions")]
		public Dispositions dispositions;

		[XmlElement(ElementName = "InspectionDate")]
		public string inspectionDate;

		[XmlElement(ElementName = "InspectionTime")]
		public string inspectionTime;

		[XmlElement(ElementName = "Inspector")]
		public Inspector inspector;

		[XmlElement(ElementName = "InspectorId")]
		public InspectorId inspectorId;

		[XmlElement(ElementName = "RequestComment")]
		public string requestComment;

		[XmlElement(ElementName = "RequestPhoneNum")]
		public String requestPhoneNum;

		[XmlElement(ElementName = "ResultComment")]
		public string resultComment;

		[XmlElement(ElementName = "Contacts")]
		public Contacts contacts;

		[XmlElement(ElementName = "InspectionRelations")]
		public InspectionRelations inspectionRelations;

		[XmlElement(ElementName = "Checklist")]
		public Checklist checklist;

		[XmlElement(ElementName = "Conditions")]
		public Conditions conditions;

		[XmlElement(ElementName = "DistanceAndTimes")]
		public DistanceAndTimes distanceAndTimes;

		[XmlElement(ElementName = "ElectronicSignatures")]
		public ElectronicSignatures electonicSignatures;

		[XmlElement(ElementName = "Guidesheets")]
		public Guidesheets guidesheets;

		[XmlElement(ElementName = "Holds")]
		public Holds holds;

		[XmlElement(ElementName = "SpatialDescriptors")]
		public SpatialDescriptors SpatialDescriptors;

		[XmlElement(ElementName = "RecordedBy")]
		public string recordedBy;

		[XmlElement(ElementName = "autoAssign")]
		public bool autoAssign;

		[XmlElement(ElementName = "InspectionUnitNumber")]
		public String inspectionUnitNumber;

		[XmlElement(ElementName = "StandardCommentsGroupIds")]
		public StandardCommentsGroupIds standardCommentsGroups;

		//Author: Robert Luo
		//Date: 2008-1-28
		//Desc: AW for FRD 07ACC-01939 (Guide Sheet Carry Over Items).
		[XmlElement(ElementName = "carryOverFlag")]
		public string carryOverFlag;
		//End.

		//Author:Liner
		//Date:2008-05-30
		//Desc:00973 GIS Viewer for Inspection List
		[XmlElement(ElementName = "GISObjects")]
		public GISObjects GISObjects;
		//end

		/// <summary>
		/// To support I18N in AMO, adds this GovXml definition.
		/// </summary>
		[XmlElement(ElementName = "InspectionUnitNumberIdentifier")]
		public InspectionUnitNumberIdentifier inspectionUnitNumberIdentifier;

		//Author: Pearl Luo
		//Date: 2010-6-14
		//Desc: fix bug for bug 28028.
		[XmlElement(ElementName = "inspectionUnit")]
		public string inspectionUnit;
		//End.

		//Author:Liner Lin
		//Date:2010-08-06
		//Desc:AMO Support for Billable & Overtime Flags for Inspections 10ACC-04485
		[XmlElement(ElementName = "overTime")]
		public string isOvertime;

		[XmlElement(ElementName = "inspBillable")]
		public string isBillable;
		//end

		//Author: Liner Lin
		//Date: 2010-8-17
		//Desc: Display Inspection Sequence Number 10ACC-03923.
		[XmlElement(ElementName = "confirmationNumber")]
		public string sequenceNumber;
		//end

		[XmlElement(ElementName = "TimeAccountings")]
		public TimeAccountings TimeAccountings;

		[XmlElement(ElementName = "guideSheetSecurity")]
		public string guideSheetSecurity;

		[XmlElement(ElementName = "Districts")]
		public Districts districts;

		[XmlElement(ElementName = "Department")]
		public Department Departments;

		[XmlElement(ElementName = "isDisplayCommentInACA")]
		public string isDisplayCommentInACA;

		[XmlElement(ElementName = "UserRolePrivilege")] 
		public UserRolePrivilege UserRolePrivilege;

		[XmlElement(ElementName = "inspectionContactNumber")]
		public string inspectionContactNumber;

		[XmlElement(ElementName = "firstName")]
		public string inspectionContactFirstName;

		[XmlElement(ElementName = "middleName")]
		public string inspectionContactMiddleName;

		[XmlElement(ElementName = "lastName")]
		public string inspectionContactLastName;

        [XmlElement(ElementName = "estimatedStartTime")]
        public string estimatedStartTime;

        [XmlElement(ElementName = "estimatedEndTime")]
        public string estimatedEndTime;

        [XmlElement(ElementName = "totalScore")]
        public string totalScore;

	}

	/// <summary>
	/// To support I18N in AMO, adds this GovXml definition.
	/// </summary>
	public class InspectionUnitNumberIdentifier
	{
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;
	}

	public class TimeAccountings
	{
		public TimeAccountings()
		{
			
		}
		[XmlElement(ElementName = "TimeAccounting")]
		public TimeAccounting[] TimeAccounting;
	}
}
