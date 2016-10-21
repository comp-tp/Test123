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
	public class InitiateCAP
	{
		public InitiateCAP()
		{
            //  Author:Winsean Wang
            //  Date:10/07/2008
            //  Desc:06ACC-01900
            _detailAddresses = new DetailAddresses();
            //  end
        }

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAPTypeId")]
		public CAPTypeId capTypeId;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;

		[XmlElement(ElementName = "FileDate")]
		public string fileDate;

		[XmlElement(ElementName = "Status")]
		public Status status;

		[XmlElement(ElementName = "Description")]
		public string description;

		[XmlElement(ElementName = "CompactAddressId")]
		public CompactAddressId compactAddressId;

        //  Author:Winsean Wang
        //  Date:10/07/2008
        //  Desc:06ACC-01900
        private DetailAddresses _detailAddresses = null;

        /// <summary>
        /// Indicates addresses the CAP owns.
        /// </summary>
        [XmlElement(ElementName = "DetailAddresses")]
        public DetailAddresses Addresses
        {
            get
            {
                return _detailAddresses;
            }
            set
            {
                _detailAddresses = value;
            }
        }
        //  end

		[XmlElement(ElementName = "GISObjects")]
		public GISObjects GISObjects;

		[XmlElement(ElementName = "ParcelIds")]
		public ParcelIds parcelIds;

		[XmlElement(ElementName = "Parcels")]
		public Parcels parcels;

		[XmlElement(ElementName = "Applicant")]
		public Applicant applicant;

		[XmlElement(ElementName = "Contacts")]
		public Contacts contacts;

		[XmlElement(ElementName = "Licenses")]
		public Licenses licenses;

		[XmlElement(ElementName = "AdditionalInformation")]
		public AdditionalInformation additionalInformation;

		[XmlElement(ElementName = "parentCAPIds")]
		public ParentCAPIds parentCAPIds;

		[XmlElement(ElementName = "finalizeNow")]
		public string finalizeNow;

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

        /// <summary>
        /// Added by Joe at 10/09/2012 
        /// Becuase creating record by WorkOrderTemplate need this XmlNode.
        /// </summary>
        [XmlElement(ElementName = "WorkOrderTasks")]
	    public WorkOrderTasks WorkOrderTasks;

        [XmlElement(ElementName = "templateName")]
        public string TemplateName;

        [XmlElement(ElementName = "shortNotes")]
        public string ShortNotes;

	}
}
