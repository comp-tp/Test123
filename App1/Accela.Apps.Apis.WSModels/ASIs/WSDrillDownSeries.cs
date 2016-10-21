using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    [DataContract(Name = "drillDownSeries")]
    public class WSDrillDownSeries
    {

        [DataMember(Name = "parent", EmitDefaultValue = false)]
        public WSRelationshipForParent ParentRelation { get; set; }

        [DataMember(Name = "child", EmitDefaultValue = false)]
        public WSRelationshipForChild ChildRelation { get; set; }


        internal static List<WSDrillDownSeries> FromEntityModel(List<AdditionalDrillDownSeriesModel> drillDownModels)
        {
            if (drillDownModels != null)
            {
                List<WSDrillDownSeries> series = new List<WSDrillDownSeries>();

                foreach (var dds in  drillDownModels)
                {
                    series.Add(new WSDrillDownSeries()
                                   {
                                       ParentRelation = WSRelationshipForParent.FromEntityModel(dds.ParentRelation),
                                       ChildRelation = WSRelationshipForChild.FromEntityModel(dds.ChildRelation)
                                   });
                }

                return series;

            }
            return null;
        }

    }



    [DataContract(Name = "relationshipParent")]
    public class WSRelationshipForParent
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "enumerations", EmitDefaultValue = false)]
        public List<WSDrillDownEnumerationForParent> Enumerations { get; set; }

        internal static WSRelationshipForParent FromEntityModel(RelationshipModel relationshipModel)
        {
            if (relationshipModel != null)
            {
                var wsRelationship = new WSRelationshipForParent()
                                         {
                                             Id = relationshipModel.Identifier,
                                             Type = relationshipModel.Type
                                         };

                if (relationshipModel.Enumerations != null)
                {
                    wsRelationship.Enumerations = new List<WSDrillDownEnumerationForParent>();
                    foreach (var enumeration in relationshipModel.Enumerations)
                    {
                        wsRelationship.Enumerations.Add(WSDrillDownEnumerationForParent.FromEntityModel(enumeration));
                    }
                }

                return wsRelationship;
            }
            return null;
        }
    }

    [DataContract(Name = "relationshipChild")]
    public class WSRelationshipForChild
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "enumerations", EmitDefaultValue = false)]
        public List<WSDrillDownEnumerationForChild> Enumerations { get; set; }

        internal static WSRelationshipForChild FromEntityModel(RelationshipModel relationshipModel)
        {
            if (relationshipModel != null)
            {
                var wsRelationship = new WSRelationshipForChild()
                                         {
                                             Id = relationshipModel.Identifier,
                                             Type = relationshipModel.Type
                                         };

                if (relationshipModel.Enumerations != null)
                {
                    wsRelationship.Enumerations = new List<WSDrillDownEnumerationForChild>();
                    foreach (var enumeration in relationshipModel.Enumerations)
                    {
                        wsRelationship.Enumerations.Add(WSDrillDownEnumerationForChild.FromEntityModel(enumeration));
                    }
                }

                return wsRelationship;


            }
            return null;
        }
    }



    [DataContract(Name = "drillDownEnumerationParent")]
    public class WSDrillDownEnumerationForParent
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "enumerationType", EmitDefaultValue = false)]
        public string EnumerationType { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }
        /// <summary>
        /// the property only for the parent relationship
        /// </summary>
        [DataMember(Name = "childLinks", EmitDefaultValue = false)]
        public List<WSChilidLink> ChildLinks { get; set; }


        internal static WSDrillDownEnumerationForParent FromEntityModel(DrillDownEnumerationModel enumeration)
        {
            if (enumeration != null)
            {
                var wsEnumeration = new WSDrillDownEnumerationForParent()
                                        {
                                            Id = enumeration.Identifier,
                                            Description = enumeration.Description,
                                            Display = enumeration.Display,
                                            EnumerationType = enumeration.EnumerationType
                                        };

                if (enumeration.ChildLinks != null)
                {
                    wsEnumeration.ChildLinks = new List<WSChilidLink>();
                    foreach (var childLink in enumeration.ChildLinks)
                    {
                        wsEnumeration.ChildLinks.Add(new WSChilidLink()
                                                         {
                                                             Link = childLink.Link
                                                         });
                    }
                }

                return wsEnumeration;
            }
            return null;
        }
    }

    [DataContract(Name = "drillDownEnumerationChild")]
    public class WSDrillDownEnumerationForChild
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "enumerationType", EmitDefaultValue = false)]
        public string EnumerationType { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        ///  the property only for the child relationship
        ///  it's value eq the id'strings before first '-' (the first key).
        /// </summary>
        [DataMember(Name = "link", EmitDefaultValue = false)]
        public string Link { get; set; }

        internal static WSDrillDownEnumerationForChild FromEntityModel(DrillDownEnumerationModel enumeration)
        {
            if (enumeration != null)
            {
                return new WSDrillDownEnumerationForChild
                           {
                               Id = enumeration.Identifier,
                               Description = enumeration.Description,
                               Display = enumeration.Display,
                               EnumerationType = enumeration.EnumerationType,
                               Link = enumeration.Link
                           };


            }
            return null;
        }
    }


    [DataContract(Name = "chlidLink")]
    public class WSChilidLink
    {
        [DataMember(Name = "link", EmitDefaultValue = false)]
        public string Link { get; set; }
    }
}
