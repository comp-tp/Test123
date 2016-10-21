/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: CAP.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 *  This is CAP type's model
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
	/// Summary description for CAPType.
	/// </summary>
	public class CAPType
	{
		public CAPType()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;
		
		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "AdditionalInformationGroupIds")]
		public AdditionalInformationGroupIds additionalInformationGroupIds;

		[XmlElement(ElementName = "ConditionTypeIds")]
		public ConditionTypeIds conditionTypeIds;

		[XmlElement(ElementName = "Dispositions")]
		public Dispositions dispositions;
		
		[XmlElement(ElementName = "HoldTypeIds")]
		public HoldTypeIds holdTypeIds;

		[XmlElement(ElementName = "InspectionTypeSetIds")]
		public InspectionTypeSetIds inspectionTypeSetIds;

		[XmlElement(ElementName = "Roles")]
		public Roles roles;

        //Author: Robert Luo
        //Date: 2007-12-10
        //Desc: 4384-[650]Upload Files from CAP forms
        [XmlElement(ElementName = "DocumentGroupIds")]
        public DocumentGroupIds DocumentGroupIds;
        //End.

        //Author:Liner Lin
        //Date:2008-11-18
        //Desc:07ACC-02323 Standard Comments
        [XmlElement(ElementName = "StandardCommentsGroupIds")]
        public StandardCommentsGroupIds standardCommentsGroups;
        //end

        //Author:Daniel Deng
        //Date:2009-8-26
        //Desc:add module type
        [XmlElement(ElementName = "module")]
        public string Module;
        //end

        /// <summary>
        /// group display value
        /// </summary>
	    [XmlElement(ElementName = "Group")] 
        public string Group;

        /// <summary>
        /// sub group display value
        /// </summary>
        [XmlElement(ElementName = "SubGroup")]
        public string SubGroup;

        /// <summary>
        /// category display value
        /// </summary>
        [XmlElement(ElementName = "Category")]
        public string Category;

        /// <summary>
        /// type display value
        /// </summary>
        [XmlElement(ElementName = "type")]
        public string Type;

        /// <summary>
        /// GIS Service value
        /// </summary>
	    [XmlElement(ElementName = "GisService")] 
        public string GISService;

        /// <summary>
        /// edit layer of cap type
        /// </summary>
        [XmlElement(ElementName = "GISLayerId")]
        public Identifier GISLayerId;

        [XmlElement(ElementName = "applicationTypeSecurity")]
        public string ApplicationTypeSecurity;
	}
}
