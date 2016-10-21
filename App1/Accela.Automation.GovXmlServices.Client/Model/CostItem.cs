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
    public class CostItem : element
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "contextType")]
        public string contextType;

        [XmlElement(ElementName = "Type")]
        public Type type;


        [XmlElement(ElementName = "CostDate")]
        public string CostDate;

        [XmlElement(ElementName = "quantity")]
        public double Quantity;

        [XmlElement(ElementName = "CostItemTypeId")]
        public Identifier CostItemTypeId;

        [XmlElement(ElementName = "Status")]
        public AAMStatus Status;


        [XmlElement(ElementName = "costFix")]
        public double CostFix;

        [XmlElement(ElementName = "costFactor")]
        public string CostFactor;

        [XmlElement(ElementName = "unitCost")]
        public double UnitCost;

        [XmlElement(ElementName = "unitOfMeasure")]
        public string UnitOfMeasure;

        [XmlElement(ElementName = "CostUnitOfMeasureIdentifier")]
        public CostUnitOfMeasureIdentifier CostUnitOfMeasureIdentifier;

        [XmlElement(ElementName = "totalCost")]
        public double TotalCost;

        [XmlElement(ElementName = "formula")]
        public string Formula;

        [XmlElement(ElementName = "subGroup")]
        public string SubGroup;

        [XmlElement(ElementName = "costAccount")]
        public string CostAccount;

        [XmlElement(ElementName = "CostAccountIdentifier")]
        public CostAccountIdentifier CostAccountIdentifier;

        [XmlElement(ElementName = "Comments")]
        public string Comments;

        [XmlElement(ElementName = "CostQuantities")]
        public CostQuantities CostQuantities;

        [XmlElement(ElementName = "startTime")]
        public string StartTime;

        [XmlElement(ElementName = "endTime")]
        public string EndTime;

        [XmlElement(ElementName = "workOrderTask")]
        public string WorkOrderTaskCode;

        [XmlElement(ElementName = "workOrderTaskCodeIndex")]
        public string WorkOrderTaskCodeIndex;
    }

    public class CostItems : ElementList
    {
        [XmlElement(ElementName = "CostItem")]
        public CostItem[] CostItem;
    }

    public class CostQuantities
    {
        [XmlElement(ElementName = "CostQuantity")]
        public CostQuantity[] CostQuantity;
    }

    public class CostQuantity
    {
        [XmlElement(ElementName = "CostFactorIdentifier")]
        public Identifier costFactor;

        [XmlElement(ElementName = "quantity")]
        public string quantity;
    }
}
