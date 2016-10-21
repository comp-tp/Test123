#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: CostAccountIdentifier.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By Tim-XU at 9/25/2009

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class PartInventory : element
    {
        public PartInventory()
        { }
        [XmlElement(ElementName = "Type")]
        public Type PartType;

        [XmlElement(ElementName = "Status")]
        public Status Status;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;


        [XmlElement(ElementName = "unitCost")]
        public double UnitCost;

        [XmlElement(ElementName = "unitOfMeasure")]
        public string UnitOfMeasure;

        [XmlElement(ElementName = "partNumber")]
        public string PartNumber;

        [XmlElement(ElementName = "totalSupply")]
        public double TotalSupply;

        [XmlElement(ElementName = "Supplies")]
        public Supplies Supplies;

        [XmlElement(ElementName = "taxable")]
        public string Taxable;

        [XmlElement(ElementName = "Comments")]
        public string Comments;

        [XmlElement(ElementName = "partBrand")]
        public string PartBrand;

        [XmlElement(ElementName = "partDescription")]
        public string PartDescription;

        [XmlElement(ElementName = "PartBrandIdentifier")]
        public PartBrandIdentifier PartBrandIdentifier;

        [XmlElement(ElementName = "DescriptionIdentifier")]
        public PartDescriptionIdentifier PartDescriptionIdentifier;

        [XmlElement(ElementName = "UnitOfMeasureIdentifier")]
        public UnitOfMeasurementIdentifier UnitOfMeasurementIdentifier;
    }

    public class PartInventories : ElementList
    {
        public PartInventories()
        { }
        [XmlElement(ElementName = "PartInventory")]
        public PartInventory[] PartInventory;


    }

    public class PartInventoryId : Identifier
    {
        public PartInventoryId()
        { }

       
    }

    public class PartInventoryIds : ElementList
    {
        public PartInventoryIds()
        { }
        [XmlElement(ElementName = "PartInventoryId")]
        public PartInventoryId[] PartInventoryId;

    }

    public class Supply : element
    {
        public Supply()
        {
        }
        [XmlElement(ElementName = "Keys")]
        public Keys Keys;
        [XmlElement(ElementName = "IdentifierDisplay")]
        public string IdentifierDisplay;
        [XmlElement(ElementName = "locationName")]
        public string LocationName;
        [XmlElement(ElementName = "locationSeq")]
        public int LocationSeq;

    }

    public class Supplies : ElementList
    {
        public Supplies()
        { }

        [XmlElement(ElementName = "Supply")]
        public Supply[] Supply;

    }
}
