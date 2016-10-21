/**
* <pre>
*
*  Accela Mobile Office
*  File: GetCAPs.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2011
*
*  Description:
*  Create By Robert at 9/25/2009
*  Notes:
* </pre>
*/

namespace Accela.Automation.GovXmlClient.Model
{
    using System;
    using System.Xml.Serialization;

	/// <summary>
	/// Summary description for FGetCAPListByCollectionIn.
	/// </summary>
	public class GetCAPs
	{
		public GetCAPs()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "returnElements")]
		public returnElements returnElements;

		[XmlElement(ElementName = "CAPIds")]
		public CAPIds capIds;

		[XmlElement(ElementName = "CAPTypeId")]
		public CAPTypeId capTypeId;

		[XmlElement(ElementName = "CAPTypeIds")]
		public CAPTypeIds capTypeIds;

		[XmlElement(ElementName = "CAPStatuses")]
		public CAPStatuses capStatuses;

		[XmlElement(ElementName = "InspectionDistricts")]
		public InspectionDistricts inspectionDistricts;

		[XmlElement(ElementName = "CompactAddressId")]
		public CompactAddressId compactAddressId;

		[XmlElement(ElementName = "Contact")]
		public Contact contact;

		[XmlElement(ElementName = "DetailAddress")]
		public DetailAddress detailAddress;

		[XmlElement(ElementName = "License")]
		public License license;

		[XmlElement(ElementName = "ParcelId")]
		public ParcelId parcelId;

		[XmlElement(ElementName = "DateRange")]
		public DateRange dateRange;

		[XmlElement(ElementName = "DateRanges")]
		public DateRanges dateRanges;

		[XmlElement(ElementName = "InspectionTypes")]
		public InspectionTypes inspectionTypes;

		[XmlElement(ElementName = "Inspectors")]
		public Inspectors inspectors;

		[XmlElement(ElementName = "keyword")]
		public string keyword;

		[XmlElement(ElementName = "parentCAPId")]
		public CAPId parentCAPId;

		[XmlElement(ElementName = "partialCAPId")]
		public CAPId partialCAPId;

		[XmlElement(ElementName = "subsidiaryCAPId")]
		public CAPId subsidiaryCAPId;

		[XmlElement(ElementName = "type")]
		public string type;

		[XmlElement(ElementName = "useCachedCAPs")]
		public string useCachedCAPs;

		[XmlElement(ElementName = "withOpenInspectionsOnly")]
		public bool withOpenInspectionsOnly;

		[XmlElement(ElementName = "SpatialDescriptors")]
		public SpatialDescriptors spatialDescriptors;

        //Author: Robert Luo
        //Date: 2008-03-05
        //Desc: 07ACC-07588_EnhancedCAPCriteria
        [XmlElement(ElementName = "Departments")]
        public Departments Departments;
        //End.

        //Author: Robert Luo
        //Date: 2008-05-23
        //Desc: 08ACC-00976_AssetWorkOrderHistory
        [XmlElement(ElementName = "AssetIds")]
        public AssetIds AssetIds;
        [XmlElement(ElementName = "MaxRecordsPerAssetId")]
        public string MaxRecordsPerAssetId;
        //End.

        [XmlElement(ElementName = "ScheduleDate")]
        public DateRanges scheduleDate;

	    [XmlElement(ElementName = "ParcelIds")] 
        public ParcelIds parcelIds;

        [XmlElement(ElementName = "OpenDate")]
        public DateRange OpenDate;

        [XmlElement(ElementName = "CAP")]
        public CAPCondition CAP;

        [XmlElement(ElementName = "SortOrder")]
        public string SortOrder;
	}

    public class CAPCondition
    {
        [XmlElement(ElementName = "module")]
        public string Module; 
    }
}
