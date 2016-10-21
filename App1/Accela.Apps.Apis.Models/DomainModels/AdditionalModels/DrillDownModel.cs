using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.AdditionalModels
{
    
    [DataContract(Name = "drillDownSeries")]
    public class AdditionalDrillDownSeriesModel
    {

        [DataMember(Name = "parent", EmitDefaultValue = false)]
        public RelationshipModel ParentRelation { get; set; }

        [DataMember(Name = "child", EmitDefaultValue = false)]
        public RelationshipModel ChildRelation { get; set; }
    }

    [DataContract(Name = "relationship")]
    public class RelationshipModel
    {
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "enumerations", EmitDefaultValue = false)]
        public List<DrillDownEnumerationModel> Enumerations { get; set; }

    }


    [DataContract(Name = "drillDownEnumeration")]
    public class DrillDownEnumerationModel
    {

        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "enumerationType", EmitDefaultValue = false)]
        public string EnumerationType { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        ///  the property only for the child relationshipModel
        ///  the value eq it's id's part before first "-".(first key)
        /// </summary>
        [DataMember(Name = "link", EmitDefaultValue = false)]
        public string Link { get; set; }

        /// <summary>
        ///  the property only for the parent relationshipModel
        /// </summary>
        [DataMember(Name = "childLinks", EmitDefaultValue = false)]
        public List<DrillDownEnumerationLinkModel> ChildLinks { get; set; }
    }

    [DataContract(Name = "drillDownEnumerationLink")]
    public class  DrillDownEnumerationLinkModel
    {
        [DataMember(Name = "link", EmitDefaultValue = false)]
        public string Link { get; set; }
    }
}
