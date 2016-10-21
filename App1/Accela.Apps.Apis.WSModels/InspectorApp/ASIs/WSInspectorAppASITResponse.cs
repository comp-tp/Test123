using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    [DataContract(Name = "GetASITInfoResponse")]
    public class WSInspectorAppASITResponse : WSResponseBase
    {
        /// <summary>
        /// Additional Info
        /// </summary>
        [DataMember(Name = "ASITs", EmitDefaultValue = false)]
        public List<WSInspectorAppASIT> RecordASIT { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="recordsResponse">Records response.</param>
        /// <returns>Web service record response.</returns>
        public static WSInspectorAppASITResponse FromEntityModel(AdditionalTableResponse asitResponse)
        {
            return new WSInspectorAppASITResponse()
            {
                RecordASIT = GetASITModel(asitResponse)
            };
        }

        public static List<WSInspectorAppASIT> GetASITModel(List<AdditionalTableModel> asits)
        {
            var wsAsitModels = new List<WSInspectorAppASIT>();
            if (asits != null && asits.Count > 0)
            {
                foreach (var asitModel in asits)
                {
                    WSInspectorAppASIT asit = new WSInspectorAppASIT()
                    {
                        Id = asitModel.Identifier,
                        Display = asitModel.Display,
                        SubDisplay = asitModel.SubDisplay,
                        Description = asitModel.Description,
                        ContextType = asitModel.ContextType,
                        Security = asitModel.Security,
                        SubId = asitModel.SubIdentifier,
                        //DrillDownSeries = WSDrillDownSeries.FromEntityModel(asitModel.DrillDownSeries),
                        SubSecurity = asitModel.SubSecurity,
                        Columns = ToRecordASITColumns(asitModel.Columns, asitModel.DrillDownSeries),
                        Rows = ToRecordASITRows(asitModel.Rows)
                    };
                    wsAsitModels.Add(asit);
                }
            }

            return wsAsitModels;
        }

        private static List<WSInspectorAppASIT> GetASITModel(AdditionalTableResponse asitResponse)
        {
            if (asitResponse == null || asitResponse.AdditionalTables == null)
            {
                return null;
            }

            List<WSInspectorAppASIT> asitModel = new List<WSInspectorAppASIT>();
            foreach (AdditionalTableModel addtModel in asitResponse.AdditionalTables)
            {
                WSInspectorAppASIT asit = new WSInspectorAppASIT()
                {
                    Id = addtModel.Identifier,
                    Display = addtModel.Display,
                    SubDisplay = addtModel.SubDisplay,
                    Description = addtModel.Description,
                    ContextType = addtModel.ContextType,
                    Security = addtModel.Security,
                    SubId = addtModel.SubIdentifier,
                    //DrillDownSeries = WSDrillDownSeries.FromEntityModel(addtModel.DrillDownSeries),
                    SubSecurity = addtModel.SubSecurity,
                    Columns = ToRecordASITColumns(addtModel.Columns, addtModel.DrillDownSeries),
                    Rows = ToRecordASITRows(addtModel.Rows)
                };
                asitModel.Add(asit);
            }

            return asitModel;
        }


        private static List<WSInspectorAppASIRow> ToRecordASITRows(List<AdditionalRowModel> rows)
        {
            if (rows == null)
            {
                return null;
            }
            List<WSInspectorAppASIRow> asiRows = new List<WSInspectorAppASIRow>();
            foreach (AdditionalRowModel row in rows)
            {
                WSInspectorAppASIRow asiRow = new WSInspectorAppASIRow()
                {
                    EntityState = WSEntityState.ConvertActionToEntityState(row.Action),
                    Display = row.Display,
                    Id = row.Identifier,
                    Values = ToASIValues(row.Values)
                };

                asiRows.Add(asiRow);
            }

            return asiRows;
        }

        private static List<WSInspectorAppASIValueModel> ToASIValues(List<AdditionalValueModel> values)
        {
            if (values == null) return null;
            List<WSInspectorAppASIValueModel> ASIValues = new List<WSInspectorAppASIValueModel>();
            foreach (AdditionalValueModel value in values)
            {
                WSInspectorAppASIValueModel asiValue = new WSInspectorAppASIValueModel()
                {
                    EntityState = WSEntityState.ConvertActionToEntityState(value.Action),
                    Id = value.Identifier,
                    Value = value.Value,
                    ValueId = value.ValueId
                };

                ASIValues.Add(asiValue);
            }
            return ASIValues;
        }

        private static List<WSInspectorAppASIColumn> ToRecordASITColumns(List<AdditionalColumnModel> columns, List<AdditionalDrillDownSeriesModel> drillDownSeries = null)
        {
            if (columns == null)
            {
                return null;
            }
            List<WSInspectorAppASIColumn> ASIcolumns = new List<WSInspectorAppASIColumn>();
            foreach (AdditionalColumnModel column in columns)
            {
                WSInspectorAppASIColumn asiColmun = new WSInspectorAppASIColumn()
                {
                    EntityState = WSEntityState.ConvertActionToEntityState(column.Action),
                    Display = column.Display,
                    Id = column.Identifier,
                    DefaultValue = column.DefaultValue,
                    InputRequired = column.InputRequired,
                    MaxValue = column.MaxValue,
                    MinValue = column.MinValue,
                    Name = column.Name,
                    Readonly = column.Readonly,
                    Security = column.Security,
                    Type = column.Type,
                    UnitOfMeasurement = column.UnitOfMeasurement,
                    IsDrillDown = column.IsDrillDown,
                    IsDrillDownRoot = column.IsDrillDownRoot,
                    DrillDownId = column.DrillDownId
                };

                if (column.Enumerations != null)
                {
                    asiColmun.Enumerations = new List<WSInspectorAppEnumeration>();

                    column.Enumerations.ForEach(item => asiColmun.Enumerations.Add(new WSInspectorAppEnumeration
                                                                                    {
                                                                                        Id = item.Identifier,
                                                                                        Display = item.Display
                                                                                    }));
                }

                if (asiColmun.IsDrillDown)
                {
                    var childIds = new List<string>();
                    if (drillDownSeries != null && drillDownSeries.Count > 0)
                    {
                        foreach (var drillDownSerie in drillDownSeries)
                        {
                            if (drillDownSerie.ParentRelation.Identifier.Equals(asiColmun.Id, System.StringComparison.InvariantCultureIgnoreCase))
                            {
                                childIds.Add(drillDownSerie.ChildRelation.Identifier);
                            }
                        }
                    }
                    if (childIds != null && childIds.Count > 0)
                    {
                        asiColmun.DrillDwonChilds = childIds;
                    }
                }

                ASIcolumns.Add(asiColmun);
            }

            return ASIcolumns;
        }

    }
}
