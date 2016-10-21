#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: GetAssets.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By Tonee at 3/26/2009 7:31:00 PM
*  Notes:
* </pre>
*/

#endregion Header

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class Part : element
    {
        [XmlElement(ElementName = "Type")]
        public Type PartType;

        [XmlElement(ElementName = "Status")]
        public AAMStatus Status;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "PartInventoryId")]
        public PartInventoryId PartInventoryId;

        [XmlElement(ElementName = "unitCost")]
        public double UnitCost;

        [XmlElement(ElementName = "unitOfMeasure")]
        public string UnitOfMeasure;

        [XmlElement(ElementName = "partNumber")]
        public string PartNumber;

        [XmlElement(ElementName = "bin")]
        public string bin;

        [XmlElement(ElementName = "quantity")]
        public double Quantity;

        [XmlElement(ElementName = "TransactionDate")]
        public string TransactionDate;

        [XmlElement(ElementName = "Comments")]
        public string Comments;

        [XmlElement(ElementName = "Supplies")]
        public Supplies Supplies;

        [XmlElement(ElementName = "partDescription")]
        public string PartDescription;

        [XmlElement(ElementName = "partBrand")]
        public string PartBrand;

        [XmlElement(ElementName = "taxable")]
        public string Taxable;

        [XmlElement(ElementName = "altID")]
        public string AltID;

        [XmlElement(ElementName = "PartBrandIdentifier")]
        public PartBrandIdentifier PartBrandIdentifier;

        [XmlElement(ElementName = "DescriptionIdentifier")]
        public PartDescriptionIdentifier PartDescriptionIdentifier;

        [XmlElement(ElementName = "UnitOfMeasureIdentifier")]
        public UnitOfMeasurementIdentifier UnitOfMeasurementIdentifier;

        [XmlElement(ElementName = "workOrderTask")]
        public string WorkOrderTaskCode;

        [XmlElement(ElementName = "workOrderTaskCodeIndex")]
        public string WorkOrderTaskCodeIndex;

        [XmlElement(ElementName = "BudgetAccount")]
        public Identifier BudgetAccount;

        [XmlElement(ElementName = "BudgetNumber")]
        public Identifier BudgetNumber;
    }

    public class Parts : ElementList
    {
        [XmlElement(ElementName = "Part")]
        public Part[] Part;

    }

    public class PartBrandIdentifier : element
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;
    }

    public class PartDescriptionIdentifier : element
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;
    }

    public class UnitOfMeasurementIdentifier : element
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;
    }
}
