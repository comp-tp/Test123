#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssets.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2011
*
*  Description:
*  Create By Tonee at 3/26/2009 7:31:00 PM
*  Notes:
* </pre>
*/

#endregion Header
using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Summary description for GetAssets.
    /// </summary>
    public class GetAssets : OperationRequest
    {
        public GetAssets()
        {
            //
            // TODO: Add constructor logic here
            //
        }

       [XmlElement(ElementName = "recordStatus")]
        public string recordStatus;

        [XmlElement(ElementName = "AssetIds")]
        public AssetIds assetIds;

        [XmlElement(ElementName = "Status")]
        public Status status;

        [XmlElement(ElementName = "Description")]
        public string description;

        [XmlElement(ElementName = "Comments")]
        public string comments;

        [XmlElement(ElementName = "AssetTypes")]
        public AssetTypes assetTypes;

        [XmlElement(ElementName = "DateOfServiceRange")]
        public DateRange dateOfServiceRange;

        [XmlElement(ElementName = "StatusDates")]
        public DateRange statusDatesRange;

        [XmlElement(ElementName = "CurrentValue")]
        public ValueRange currentValueRange;

        [XmlElement(ElementName = "GISObjects")] 
        public GISObjects GisObjects;

        [XmlElement(ElementName = "returnElements")]
        public returnElements ReturnElements;

        [XmlElement(ElementName = "DetailAddress")]
        public DetailAddress DetailAddress;

        [XmlElement(ElementName = "Asset")]
        public Asset asset;
    }
}
