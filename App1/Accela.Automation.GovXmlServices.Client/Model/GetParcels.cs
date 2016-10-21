#region Header

/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GetParcels
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 * 
 *  Description:Status
 *  
 * 
 *  Note
 *  Created By:
 *  Modified By:
 * </pre>
 */

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System.Xml.Serialization;

	/// <summary>
	/// Summary description for FGetParcelListByCollectionIn.
	/// </summary>
	public class GetParcels
	{
		public GetParcels()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "returnElements")]
		public returnElements returnElements;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;
		
		[XmlElement(ElementName = "CAPStatuses")]
		public CAPStatuses capStatuses;

		[XmlElement(ElementName = "Contact")]
		public Contact contact;

		[XmlElement(ElementName = "DateRange")]
		public DateRange dateRange;

		[XmlElement(ElementName = "DetailAddress")]
		public DetailAddress detailAddress;

		[XmlElement(ElementName = "ParcelId")]
		public ParcelId parcelId;

		[XmlElement(ElementName = "SpatialDescriptors")]
		public SpatialDescriptors spatialDescriptors;

        [XmlElement(ElementName = "ParcelIds")]
        public ParcelIds ParcelIds;

        [XmlElement(ElementName = "GISObjects")]
        public GISObjects GisObjects;

        [XmlElement(ElementName = "returnDisableParcels")]
        public bool returnDisabledParcels;

        [XmlElement(ElementName = "returnRefParcels")]
        public bool returnRefParcels;
	}
}
