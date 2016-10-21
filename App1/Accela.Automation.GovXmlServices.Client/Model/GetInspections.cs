#region Header

/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GetInspections.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 * 
 *  Description:
 *  This is GetInspections's model
 * 
 *  Note
 *  Created By: Code Generator
 *
 * </pre>
 */

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

	/// <summary>
	/// This operation requests inspection lists for a given inspector
	/// </summary>
	/// 

	public class GetInspections
	{
		public GetInspections()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;

		[XmlElement(ElementName = "CAPTypeId")]
		public CAPTypeId capTypeId;

		[XmlElement(ElementName = "CompactAddressId")]
		public CompactAddressId compactAddressId;

		[XmlElement(ElementName = "Contact")]
		public Contact contact;

		[XmlElement(ElementName = "DetailAddress")]
		public DetailAddress detailAddress;

		[XmlElement(ElementName = "InspectorId")]
		public InspectorId inspectorId;

	    [XmlElement(ElementName = "InspectionDistrictIds")]
		public InspectionDistrictIds inspectionDistrictIds;

	    [XmlElement(ElementName = "InspectionTypes")]
		public InspectionTypes inspectionTypes;

	    [XmlElement(ElementName = "InspectorIds")]
		public InspectorIds inspectorIds;

		[XmlElement(ElementName = "License")]
		public License license;

        [XmlElement(ElementName = "MapReference")]
        public MapReference mapReference;

        [XmlElement(ElementName = "ParcelId")]
		public ParcelId parcelId;

		[XmlElement(ElementName = "scheduledDateRanges")]
		public DateRanges scheduledDateRanges;

		[XmlElement(ElementName = "DateRange")]
		public DateRange dateRange;

		[XmlElement(ElementName = "DateRanges")]
		public DateRanges dateRanges;

		[XmlElement(ElementName = "dateFrom")]
		public string dateFrom;

		[XmlElement(ElementName = "dateTo")]
		public string dateTo;

		[XmlElement(ElementName = "openInspectionsOnly")]
		public bool openInspectionsOnly;

		[XmlElement(ElementName = "useCachedCAPs")]
		public string useCachedCAPs;

        [XmlElement(ElementName = "downloadRouteSheetOnly")]
        public bool downloadRouteSheetOnly;

        [XmlElement(ElementName = "returnElements")]
        public returnElements ReturnElements;

        //Author: Liner Lin
        //Date: 2010-8-17
        //Desc: Display Inspection Sequence Number 10ACC-03923.
        [XmlElement(ElementName = "ConfirmationNumbers")]
        public ConfirmationNumbers sequenceNumbers;

        [XmlElement(ElementName = "Districts")]
        public Districts districts;

        [XmlElement(ElementName = "Departments")]
        public Departments Departments;

        [XmlElement(ElementName = "CAP")]
        public CAPCondition CAP;

        [XmlElement(ElementName = "CAPTypeIds")]
        public CAPTypeIds capTypeIds;

        [XmlElement(ElementName = "InspectionStatus")]
        public Disposition Status;
	}
}
