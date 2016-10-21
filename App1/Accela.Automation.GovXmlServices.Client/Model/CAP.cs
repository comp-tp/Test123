/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: CAP.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2012
 * 
 *  Description:
 *  This is CAP's model
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
    /// <summary>
    /// Summary description for CAP.
    /// </summary>
    /// 

    public class CAP
    {
        public CAP()
        {
            //
            // TODO: Add constructor logic here
            //
        }

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

        [XmlElement(ElementName = "Type")]
        public Type type;

        [XmlElement(ElementName = "FileDate")]
        public string fileDate;

        [XmlElement(ElementName = "Status")]
        public Status status;

        [XmlElement(ElementName = "Description")]
        public string description;

        [XmlElement(ElementName = "Name")]
        public string name;

        [XmlElement(ElementName = "Dispositions")]
        public Dispositions dispositions;

        [XmlElement(ElementName = "Addresses")]
        public Addresses addresses;

        [XmlElement(ElementName = "CompactAddresses")]
        public CompactAddresses compactAddresses;

        [XmlElement(ElementName = "Parcels")]
        public Parcels parcels;

        [XmlElement(ElementName = "CAPRelations")]
        public CAPRelations capRelations;

        [XmlElement(ElementName = "Checklist")]
        public Checklist checklist;

        [XmlElement(ElementName = "Conditions")]
        public Conditions conditions;

        [XmlElement(ElementName = "Contacts")]
        public Contacts contacts;

        [XmlElement(ElementName = "GISObjects")]
        public GISObjects GISObjects;

        [XmlElement(ElementName = "Holds")]
        public Holds holds;

        [XmlElement(ElementName = "Inspections")]
        public Inspections inspections;

        //[XmlElement(ElementName = "SpatialDescriptors")]
        //public SpatialDescriptors spatialDescriptors;

        //[XmlElement(ElementName = "SpatialObjects")]
        //public SpatialObjects spatialObjects;

        //[XmlElement(ElementName = "Worksheet")]
        //public Worksheet worksheet;

        [XmlElement(ElementName = "AdditionalInformation")]
        public AdditionalInformation additionalInformation;

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

        //add department to CAP
        [XmlElement(ElementName = "Department")]
        public Department Department;
        //add staffperson to CAP
        [XmlElement(ElementName = "StaffPerson")]
        public StaffPerson StaffPerson;

        [XmlElement(ElementName = "CAPDetail")]
        public CAPDetail CAPDetail;

        //Author:Daniel Deng
        //Date:2009-8-26
        //Desc:add module type
        [XmlElement(ElementName = "module")]
        public string Module;
        //end

        //Author:Daniel Wu
        //Date:2009-9-1
        //Desc:add schedule date and time
        [XmlElement(ElementName = "ScheduleDate")]
        public string scheduleDate;

        [XmlElement(ElementName = "ScheduleTime")]
        public string scheduleTime;

        [XmlElement(ElementName = "Comments")]
        public CAPComments comments;

        [XmlElement(ElementName = "AssignedDate")]
        public string AssignedDate;

        //[XmlElement(ElementName = "ActivitySummaries")]
        //public ActivitySummarys activitySummaries;

        //[XmlElement(ElementName = "Activities")]
        //public Activitys activitys;
        //end	

        //Added by robert in 6/19/2012
        [XmlElement(ElementName = "WorkOrderTasks")]
        public WorkOrderTasks WorkOrderTasks;
    }

    /// <summary>
    /// to match current govxml
    /// in current govxml, AsgnDept and AsgnStaff in CAPDetail
    /// </summary>
    public class CAPDetail
    {
        [XmlElement(ElementName = "TotalJobCost")]
        public string TotalJobCost;

        [XmlElement(ElementName = "AsgnDept")]
        public string AsgnDept;

        [XmlElement(ElementName = "AsgnStaff")]
        public string AsgnStaff;

        //add assigndate to CAP
        [XmlElement(ElementName = "AsgnDate")]
        public string AsgnDate;
        //add cap completedate
        [XmlElement(ElementName = "CompleteDate")]
        public string CompleteDate;

        [XmlElement(ElementName = "ScheduledDate")]
        public string ScheduledDate;        
        
        /// <summary>
        /// Added by robert.
        /// It becuase code officer need the field
        /// </summary>
        [XmlElement(ElementName = "Priority")]
        public string Priority;
    }
}
