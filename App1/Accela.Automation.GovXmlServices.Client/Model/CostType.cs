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

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CostType :  element
    {
        public CostType()
        {
        }

        [XmlElement(ElementName = "Keys")]
        public Keys Keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "CostItemTypes")]
        public CostItemTypes CostItemTypes;

    }

    public class CostTypes  : ElementList
    {
        [XmlElement(ElementName = "CostType")]
        public CostType[] CostType;

    }


    public class CostItemTypes : ElementList
    {
        [XmlElement(ElementName = "CostItemType")]
        public CostItemType[] CostItemType;

    }
    public class CostItemType: element
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "costItem")]
        public string CostItem;
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
        [XmlElement(ElementName = "formula")]
        public string Formula;
        [XmlElement(ElementName = "subGroup")]
        public string SubGroup;
        [XmlElement(ElementName = "costAccount")]
        public string CostAccount;
        [XmlElement(ElementName = "CostAccountIdentifier")]
        public CostAccountIdentifier CostAccountIdentifier;
    }

    public class CostFactors : ElementList
    {
        [XmlElement(ElementName = "CostFactor")]
        public CostFactor[] CostFactor;
    }
    public class CostFactor : Identifier
    {
    }
}
