using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    [DataContract(Name = "GetASIInfoResponse")]
    public class WSASIResponse : WSResponseBase
    {
        /// <summary>
        /// Additional Info
        /// </summary>
        [DataMember(Name = "ASIs", EmitDefaultValue = false)]
        public List<WSASI> ASIs { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="recordsResponse">Records response.</param>
        /// <returns>WSASIResponse.</returns>
        public static WSASIResponse FromEntityModel(AdditionalResponse addiResponse)
        {
            return new WSASIResponse()
            {
                ASIs = GetASIModel(addiResponse)
            };
        }

        public static WSASI FromEntityModel(AdditionalGroupModel additionalGroupModel)
        {
            WSASI wsASI = null;
            if (additionalGroupModel != null)
            {
                wsASI = new WSASI()
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

        public static List<WSASI> GetASIModel(AdditionalResponse addiResponse)
        {
            if (addiResponse == null || addiResponse.Additionals == null || addiResponse.Additionals.Count == 0) return null;
            List<WSASI> asiModel = new List<WSASI>();
            foreach (AdditionalGroupModel addModel in addiResponse.Additionals)
            {
                WSASI asi = new WSASI()
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

        private static List<WSASISubGroup> ToRecordASISubGroup(List<AdditionalSubGroupModel> subGroup)
        {
            if (subGroup == null || subGroup.Count == 0) return null;
            List<WSASISubGroup> subASILst = new List<WSASISubGroup>();
            foreach (AdditionalSubGroupModel subModel in subGroup)
            {
                WSASISubGroup subASI = new WSASISubGroup()
                {
                    EntityState = WSEntityState.ConvertActionToEntityState(subModel.Action),
                    Display = subModel.Display,
                    Id = subModel.Identifier,
                    Security = subModel.Security,
                    Alias = subModel.Alias,
                    Items = ToRecordASIItem(subModel.Items, subModel.DrillDownSeries),                    
                    //DrillDownSeries = WSDrillDownSeries.FromEntityModel(subModel.DrillDownSeries)
                };

                subASILst.Add(subASI);
            }

            return subASILst;
        }

        private static List<WSASIItem> ToRecordASIItem(List<AdditionalItemModel> addItemLst, List<AdditionalDrillDownSeriesModel> drillDownSeries = null)
        {
            if (addItemLst == null || addItemLst.Count == 0) return null;
            List<WSASIItem> recordASIItemLst = new List<WSASIItem>();
            foreach (AdditionalItemModel addItem in addItemLst)
            {
                WSASIItem asiItem = new WSASIItem()
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
                    asiItem.Enumerations = new List<WSEnumeration>();

                    addItem.Enumerations.ForEach(item => asiItem.Enumerations.Add(new WSEnumeration
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

        public static List<WSASI> GetASIModel(List<AdditionalGroupModel> additionals)
        {
            var wsasis = new List<WSASI>();
            if (additionals != null && additionals.Count > 0)
            {
                foreach (var additional in additionals)
                {
                    WSASI asi = new WSASI()
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
