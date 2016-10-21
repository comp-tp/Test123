/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File: InitiateCAP.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 *
 *  Description:
 *  All DataModel class must inherit the class.
 *
 *  Note
 *  Created By: Robert Luo
 * </pre>
 */

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for UpdateCAP.
	/// </summary>
	public class UpdateCAP
	{
		public UpdateCAP()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName="contextType")]
		public string contextType;

		[XmlElement(ElementName="CAPId")]
		public CAPId capId;

		[XmlElement(ElementName = "AdditionalInformation")]
		public AdditionalInformation additionalInformation;

		[XmlElement(ElementName = "Addresses")]
		public Addresses addresses;

		[XmlElement(ElementName = "CAPRelations")]
		public CAPRelations capRelations;

		[XmlElement(ElementName = "CompactAddresses")]
		public CompactAddresses compactAddresses;

		[XmlElement(ElementName = "Checklist")]
		public Checklist checklist;

		[XmlElement(ElementName = "Conditions")]
		public Conditions conditions;

		[XmlElement(ElementName = "Contacts")]
		public Contacts contacts;

		[XmlElement(ElementName = "Description")]
		public string description;

		[XmlElement(ElementName = "FileDate")]
		public string fileDate;

		[XmlElement(ElementName = "GISObjects")]
		public GISObjects GISObjects;

		[XmlElement(ElementName = "Holds")]
		public Holds holds;

		[XmlElement(ElementName = "ParcelIds")]
		public ParcelIds parcelIds;

		[XmlElement(ElementName = "Parcels")]
		public Parcels parcels;

		[XmlElement(ElementName = "SpatialDescriptors")]
		public SpatialDescriptors spatialDescriptors;

		[XmlElement(ElementName = "SpatialObjects")]
		public SpatialObjects spatialObjects;

		[XmlElement(ElementName = "Status")]
		public Status status;

		[XmlElement(ElementName = "Type")]
		public Type type;

		[XmlElement(ElementName = "Worksheets")]
		public Worksheets worksheets;

        [XmlElement(ElementName = "Assets")]
        public Assets Assets;

        //Author:Robert Luo
        //Date:2008-01-23
        //Desc:CAP Cost Items and Parts for Assets(06ACC-00458)
        [XmlElement(ElementName = "CostItems")]
        public CostItems CostItems;
        [XmlElement(ElementName = "Parts")]
        public Parts Parts;
        //End.

        [XmlElement(ElementName = "Department")]
        public Department Department;

        [XmlElement(ElementName = "StaffPerson")]
        public StaffPerson StaffPerson;

        [XmlElement(ElementName = "AssignedDate")]
        public string AssignedDate;

        //Author:Daniel Wu
        //Date:2009-9-2
        //Desc:add schedule date and time
        [XmlElement(ElementName = "ScheduleDate")]
        public string scheduleDate;

        [XmlElement(ElementName = "ScheduleTime")]
        public string scheduleTime;
        //end
        [XmlElement(ElementName = "Comments")]
        public CAPComments comments;

        /// <summary>
        /// Added by robert at 7/5/2012
        /// Because code office need save priority field.
        /// </summary>
        [XmlElement(ElementName = "CAPDetail")]
        public CAPDetail CAPDetail;

        [XmlElement(ElementName = "WorkOrderTasks")]
        public WorkOrderTasks WorkOrderTasks;
	}
}
