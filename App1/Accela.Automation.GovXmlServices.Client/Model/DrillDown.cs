using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class DrillDown
    {
        public DrillDown()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "DrillDownSeries")]
        public AdditionalDrillDownSeries[] drillDownSeries;
    }

    public class AdditionalDrillDownSeries
    {
        public AdditionalDrillDownSeries()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "ParentRelation")]
        public Relationship parentRelation;

        [XmlElement(ElementName = "ChildRelation")]
        public Relationship childRelation;
    }

    public class Relationship
    {
        public Relationship()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "Enumerations")]
        public DrillDownEnumerations enumerations;

        [XmlElement(ElementName = "type")]
        public string type;
    }

    public class DrillDownEnumerations
    {
        public DrillDownEnumerations()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "Enumeration")]
        public DrillDownEnumeration[] AMOEnumeration;
    }

    public class DrillDownEnumeration
    {
        public DrillDownEnumeration()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "EnumerationType")]
        public string enumerationType;

        [XmlElement(ElementName = "description")]
        public string description;

        [XmlElement(ElementName = "ChildKeys")]
        public Keys childValueKeys;
    }
}
