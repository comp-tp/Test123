using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    [DataContract(Name = "drillDownSeries")]
    public class WSInspectorAppDrillDownSeries
    {

        [DataMember(Name = "parent", EmitDefaultValue = false)]
        public WSInspectorAppRelationshipForParent ParentRelation { get; set; }

        [DataMember(Name = "child", EmitDefaultValue = false)]
        public WSInspectorAppRelationshipForChild ChildRelation { get; set; }


        internal static List<WSInspectorAppDrillDownSeries> FromEntityModel(List<AdditionalDrillDownSeriesModel> drillDownModels)
        {
            if (drillDownModels != null)
            {
                List<WSInspectorAppDrillDownSeries> series = new List<WSInspectorAppDrillDownSeries>();

                foreach (var dds in  drillDownModels)
                {
                    series.Add(new WSInspectorAppDrillDownSeries()
                                   {
                                       ParentRelation = WSInspectorAppRelationshipForParent.FromEntityModel(dds.ParentRelation),
                                       ChildRelation = WSInspectorAppRelationshipForChild.FromEntityModel(dds.ChildRelation)
                                   });
                }

                return series;

            }
            return null;
        }

    }



    [DataContract(Name = "relationshipParent")]
    public class WSInspectorAppRelationshipForParent
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "enumerations", EmitDefaultValue = false)]
        public List<WSInspectorAppDrillDownEnumerationForParent> Enumerations { get; set; }

        internal static WSInspectorAppRelationshipForParent FromEntityModel(RelationshipModel relationshipModel)
        {
            if (relationshipModel != null)
            {
                var wsRelationship = new WSInspectorAppRelationshipForParent()
                                         {
                                             Id = relationshipModel.Identifier,
                                             Type = relationshipModel.Type
                                         };

                if (relationshipModel.Enumerations != null)
                {
                    wsRelationship.Enumerations = new List<WSInspectorAppDrillDownEnumerationForParent>();
                    foreach (var enumeration in relationshipModel.Enumerations)
                    {
                        wsRelationship.Enumerations.Add(WSInspectorAppDrillDownEnumerationForParent.FromEntityModel(enumeration));
                    }
                }

                return wsRelationship;
            }
            return null;
        }
    }

    [DataContract(Name = "relationshipChild")]
    public class WSInspectorAppRelationshipForChild
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "enumerations", EmitDefaultValue = false)]
        public List<WSInspectorAppDrillDownEnumerationForChild> Enumerations { get; set; }

        internal static WSInspectorAppRelationshipForChild FromEntityModel(RelationshipModel relationshipModel)
        {
            if (relationshipModel != null)
            {
                var wsRelationship = new WSInspectorAppRelationshipForChild()
                                         {
                                             Id = relationshipModel.Identifier,
                                             Type = relationshipModel.Type
                                         };

                if (relationshipModel.Enumerations != null)
                {
                    wsRelationship.Enumerations = new List<WSInspectorAppDrillDownEnumerationForChild>();
                    foreach (var enumeration in relationshipModel.Enumerations)
                    {
                        wsRelationship.Enumerations.Add(WSInspectorAppDrillDownEnumerationForChild.FromEntityModel(enumeration));
                    }
                }

                return wsRelationship;


            }
            return null;
        }
    }



    [DataContract(Name = "drillDownEnumerationParent")]
    public class WSInspectorAppDrillDownEnumerationForParent
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
        public List<WSInspectorAppChilidLink> ChildLinks { get; set; }


        internal static WSInspectorAppDrillDownEnumerationForParent FromEntityModel(DrillDownEnumerationModel enumeration)
        {
            if (enumeration != null)
            {
                var wsEnumeration = new WSInspectorAppDrillDownEnumerationForParent()
                                        {
                                            Id = enumeration.Identifier,
                                            Description = enumeration.Description,
                                            Display = enumeration.Display,
                                            EnumerationType = enumeration.EnumerationType
                                        };

                if (enumeration.ChildLinks != null)
                {
                    wsEnumeration.ChildLinks = new List<WSInspectorAppChilidLink>();
                    foreach (var childLink in enumeration.ChildLinks)
                    {
                        wsEnumeration.ChildLinks.Add(new WSInspectorAppChilidLink()
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
    public class WSInspectorAppDrillDownEnumerationForChild
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

        internal static WSInspectorAppDrillDownEnumerationForChild FromEntityModel(DrillDownEnumerationModel enumeration)
        {
            if (enumeration != null)
            {
                return new WSInspectorAppDrillDownEnumerationForChild
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
    public class WSInspectorAppChilidLink
    {
        [DataMember(Name = "link", EmitDefaultValue = false)]
        public string Link { get; set; }
    }
}
