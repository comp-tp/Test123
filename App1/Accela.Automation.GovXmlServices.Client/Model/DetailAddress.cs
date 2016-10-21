#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: DetailAddress.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2011
*
*  Description:
*  Create By TIM-XU
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Summary description for DetailAddress.
    /// </summary>
    public class DetailAddress
    {
        public DetailAddress()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        //  Author:Winsean Wang
        //  Date:21/10/2008
        //  Desc:06ACC-01900
        //  added
        [XmlAttribute(AttributeName = "action")]
        public string action;
        //  end

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "addressFormat")]
        public string addressFormat;

        [XmlElement(ElementName = "houseNumber")]
        public string houseNumber;

        [XmlElement(ElementName = "houseNumberFraction")]
        public string houseNumberFraction;

        [XmlElement(ElementName = "streetDirection")]
        public string streetDirection;

        [XmlElement(ElementName = "streetName")]
        public string streetName;

        [XmlElement(ElementName = "streetSuffix")]
        public string streetSuffix;

        [XmlElement(ElementName = "streetSuffixDirection")]
        public string streetSuffixDirection;

        [XmlElement(ElementName = "unit")]
        public string unit;

        [XmlElement(ElementName = "unitEnd")]
        public string unitEnd;

        [XmlElement(ElementName = "unitType")]
        public string unitType;

        [XmlElement(ElementName = "urbanization")]
        public string urbanization;

        [XmlElement(ElementName = "City")]
        public string city;

        [XmlElement(ElementName = "CityIdentifier")]
        public Enumeration cityIdentifier;

        [XmlElement(ElementName = "County")]
        public string county;

        [XmlElement(ElementName = "State")]
        public string state;

        [XmlElement(ElementName = "PostalCode")]
        public string postalCode;

        [XmlElement(ElementName = "Country")]
        public string country;

        //Author:Liner
        //Date:2008-06-04
        //Desc:07588
        [XmlElement(ElementName = "GISObjects")]
        public GISObjects GISObjects;
        //end

        private string _isPrimary = "false";
        [XmlAttribute(AttributeName = "isPrimary")]
        public string IsPrimary
        {
            set
            {
                _isPrimary = value;
            }
            get
            {
                if (_isPrimary == null)
                    return null;
                return _isPrimary.Equals("true", System.StringComparison.OrdinalIgnoreCase) ? "true" : "false";
            }
        }
        //  end

        //  Author:Winsean Wang
        //  Date:10/29/2008
        //  Desc:06ACC-01900
        private string _refAddressType = string.Empty;
        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "ReferenceAddressType")]
        public string RefAddressType
        {
            set
            {
                _refAddressType = value;
            }
            get
            {
                return _refAddressType;
            }
        }
        //  end

        [XmlElement(ElementName = "Parcels")]
        public Parcel[] parcels;

        [XmlElement(ElementName = "ParcelIds")]
        public ParcelIds parcelIds;

        [XmlElement(ElementName = "XCoordinate")]
        public string xCoordinate;

        [XmlElement(ElementName = "YCoordinate")]
        public string yCoordinate;

        [XmlElement(ElementName = "AuditStatus")]
        public string auditStatus;

        [XmlElement(ElementName = "line1")]
        public string addressLine1;

        [XmlElement(ElementName = "line2")]
        public string addressLine2;

        [XmlElement(ElementName = "line3")]
        public string addressLine3;

        [XmlElement(ElementName = "neighborhoodPrefix")]
        public string neighberhoodPrefix;

        [XmlElement(ElementName = "neighborhood")]
        public string neighborhood;

        [XmlElement(ElementName = "inspectionDistrictPrefix")]
        public string inspectionDistrictPrefix;

        [XmlElement(ElementName = "inspectionDistrict")]
        public string inspectionDistrict;

        [XmlElement(ElementName = "secondaryRoad")]
        public string secondaryRoad;

        [XmlElement(ElementName = "secondaryRoadNumber")]
        public string secondaryRoadNumber;

        [XmlElement(ElementName = "description")]
        public string addressDescription;

        [XmlElement(ElementName = "distance")]
        public string distance;
    }
}
