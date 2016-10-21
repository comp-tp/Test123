using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    [DataContract(Name = "GetASIInfoResponse")]
    public class WSInspectorAppASIResponse : WSResponseBase
    {
        /// <summary>
        /// Additional Info
        /// </summary>
        [DataMember(Name = "ASIs", EmitDefaultValue = false)]
        public List<WSInspectorAppASI> ASIs { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="recordsResponse">Records response.</param>
        /// <returns>WSASIResponse.</returns>
        public static WSInspectorAppASIResponse FromEntityModel(AdditionalResponse addiResponse)
        {
            return new WSInspectorAppASIResponse()
            {
                ASIs = GetASIModel(addiResponse)
            };
        }

        public static WSInspectorAppASI FromEntityModel(AdditionalGroupModel additionalGroupModel)
        {
            WSInspectorAppASI wsASI = null;
            if (additionalGroupModel != null)
            {
                wsASI = new WSInspectorAppASI()
                {
                    Id = additionalGroupModel.Identifier,
                    Display = additionalGroupModel.Display,
                    Description = additionalGroupModel.Description,
                    Security = additionalGroupModel.Security,
                    SubGroups = ToRecordASISubGroup(additionalGroupModel.SubGroups)
                };
            }
            return wsASI;
        }

        public static List<WSInspectorAppASI> GetASIModel(AdditionalResponse addiResponse)
        {
            if (addiResponse == null || addiResponse.Additionals == null || addiResponse.Additionals.Count == 0) return null;
            List<WSInspectorAppASI> asiModel = new List<WSInspectorAppASI>();
            foreach (AdditionalGroupModel addModel in addiResponse.Additionals)
            {
                WSInspectorAppASI asi = new WSInspectorAppASI()
                {
                    Id = addModel.Identifier,
                    Display = addModel.Display,
                    Description = addModel.Description,
                    Security = addModel.Security,
                    SubGroups = ToRecordASISubGroup(addModel.SubGroups)
                };
                asiModel.Add(asi);
            }

            return asiModel;
        }

        private static List<WSInspectorAppASISubGroup> ToRecordASISubGroup(List<AdditionalSubGroupModel> subGroup)
        {
            if (subGroup == null || subGroup.Count == 0) return null;
            List<WSInspectorAppASISubGroup> subASILst = new List<WSInspectorAppASISubGroup>();
            foreach (AdditionalSubGroupModel subModel in subGroup)
            {
                WSInspectorAppASISubGroup subASI = new WSInspectorAppASISubGroup()
                {
                    EntityState = WSEntityState.ConvertActionToEntityState(subModel.Action),
                    Display = subModel.Display,
                    Id = subModel.Identifier,
                    Security = subModel.Security,
                    Items = ToRecordASIItem(subModel.Items, subModel.DrillDownSeries),
                    //DrillDownSeries = WSDrillDownSeries.FromEntityModel(subModel.DrillDownSeries)
                };

                subASILst.Add(subASI);
            }

            return subASILst;
        }

        private static List<WSInspectorAppASIItem> ToRecordASIItem(List<AdditionalItemModel> addItemLst, List<AdditionalDrillDownSeriesModel> drillDownSeries = null)
        {
            if (addItemLst == null || addItemLst.Count == 0) return null;
            List<WSInspectorAppASIItem> recordASIItemLst = new List<WSInspectorAppASIItem>();
            foreach (AdditionalItemModel addItem in addItemLst)
            {
                WSInspectorAppASIItem asiItem = new WSInspectorAppASIItem()
                {
                    EntityState = WSEntityState.ConvertActionToEntityState(addItem.Action),
                    DefaultValue = addItem.DefaultValue,
                    Display = addItem.Display,
                    Id = addItem.Identifier,
                    InputRequired = addItem.InputRequired,
                    MaxValue = addItem.MaxValue,
                    MinValue = addItem.MinValue,
                    Name = addItem.Name,
                    Readonly = addItem.Readonly,
                    Security = addItem.Security,
                    Type = addItem.Type,
                    UnitOfMeasurement = addItem.UnitOfMeasurement,
                    Value = addItem.Value,
                    IsDrillDown = addItem.IsDrillDown,
                    IsDrillDownRoot = addItem.IsDrillDownRoot,
                    DrillDownId = addItem.DrillDownId,
                    ValueId = addItem.ValueId
                };

                if (addItem.Enumerations != null)
                {
                    asiItem.Enumerations = new List<WSInspectorAppEnumeration>();

                    addItem.Enumerations.ForEach(item => asiItem.Enumerations.Add(new WSInspectorAppEnumeration
                                                                                    {
                                                                                        Id = item.Identifier,
                                                                                        Display = item.Display
                                                                                    }));
                }

                if (asiItem.IsDrillDown)
                {
                    var childIds = new List<string>();
                    if (drillDownSeries != null && drillDownSeries.Count > 0)
                    {
                        foreach (var drillDownSerie in drillDownSeries)
                        {
                            if (drillDownSerie.ParentRelation.Identifier.Equals(asiItem.Id, System.StringComparison.InvariantCultureIgnoreCase))
                            {
                                childIds.Add(drillDownSerie.ChildRelation.Identifier);
                            }
                        }
                    }
                    if (childIds != null && childIds.Count > 0)
                    {
                        asiItem.DrillDwonChilds = childIds;
                    }
                }

                recordASIItemLst.Add(asiItem);
            }

            return recordASIItemLst;
        }

        public static List<WSInspectorAppASI> GetASIModel(List<AdditionalGroupModel> additionals)
        {
            var wsasis = new List<WSInspectorAppASI>();
            if (additionals != null && additionals.Count > 0)
            {
                foreach (var additional in additionals)
                {
                    WSInspectorAppASI asi = new WSInspectorAppASI()
                    {
                        Id = additional.Identifier,
                        Display = additional.Display,
                        Description = additional.Description,
                        Security = additional.Security,
                        SubGroups = ToRecordASISubGroup(additional.SubGroups)
                    };
                    wsasis.Add(asi);
                }
            }

            return wsasis;
        }

        
    }
}
