using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    /// <summary>
    /// asi asit helper
    /// </summary>
    internal class ASITHelper : GovXmlHelperBase 
    {
        public static List<AdditionalTableModel> GetCAAsits(AdditionalInformation asiAsitInfo)
        {
            List<AdditionalTableModel> result = new List<AdditionalTableModel>();

            if (asiAsitInfo != null && asiAsitInfo.additionalInformationGroup != null)
            {
                result = GetAsitList(asiAsitInfo.additionalInformationGroup);
            }

            return result;
        }

        private static List<AdditionalTableModel> GetAsitList(IEnumerable<AdditionalInformationGroup> asitList)
        {
            var additionalTableModels = new List<AdditionalTableModel>();
            if (asitList != null)
            {
                foreach (var asit in asitList)
                {
                    if (asit != null)
                    {
                        AdditionalTableModel tableModel = new AdditionalTableModel();

                        tableModel.Identifier = asit.keys.ToStringKeys();
                        tableModel.Display = asit.identifierDisplay;
                        tableModel.Security = asit.security;

                        tableModel.Description = asit.description;
                        tableModel.ContextType = asit.contextType;

                        tableModel.SubIdentifier = GetSubIdentifier(asit.additionalInformationSubGroup);
                        tableModel.SubDisplay = GetSubDisplay(asit.additionalInformationSubGroup);
                        tableModel.SubSecurity = GetSubSecurity(asit.additionalInformationSubGroup);

                        tableModel.DrillDownSeries = GetSubDrillDown(asit.additionalInformationSubGroup);

                        tableModel.Columns = GetColumns(asit.additionalInformationSubGroup);

                        tableModel.Rows = GetRows(false, asit.additionalInformationSubGroup);

                        ApplyDrillDownSettings(tableModel);

                        additionalTableModels.Add(tableModel);
                    }
                }
            }

            return additionalTableModels;
        }

        /// <summary>
        /// Gets the asi asit.
        /// </summary>
        /// <param name="asiAsitInfo">The asi asit info.</param>
        /// <returns></returns>
        public static List<AdditionalTableModel> GetAsiAsit(AdditionalInformation asiAsitInfo)
        {
            List<AdditionalTableModel> result = new List<AdditionalTableModel>();

            if (asiAsitInfo != null
                && asiAsitInfo.additionalInformationGroup != null)
            {
                var asitList = asiAsitInfo.additionalInformationGroup.Where(item => item.AddRemoveSubGroups == true);

                if (asitList != null)
                {
                    foreach (var asit in asitList)
                    {
                        if (asit != null)
                        {
                            AdditionalTableModel tableModel = new AdditionalTableModel();

                            tableModel.Identifier = asit.keys.ToStringKeys();
                            tableModel.Display = asit.identifierDisplay;
                            tableModel.Security = asit.security;

                            tableModel.Description = asit.description;
                            tableModel.ContextType = asit.contextType;

                            tableModel.SubIdentifier = GetSubIdentifier(asit.additionalInformationSubGroup);
                            tableModel.SubDisplay = GetSubDisplay(asit.additionalInformationSubGroup);
                            tableModel.SubSecurity = GetSubSecurity(asit.additionalInformationSubGroup);
                            tableModel.SubAlias = GetSubAlias(asit.additionalInformationSubGroup);

                            tableModel.DrillDownSeries = GetSubDrillDown(asit.additionalInformationSubGroup);

                            tableModel.Columns = GetColumns(asit.additionalInformationSubGroup);

                            tableModel.Rows = GetRows(false, asit.additionalInformationSubGroup);

                            ApplyDrillDownSettings(tableModel);

                            result.Add(tableModel);
                        }
                    }
                }
            }

            return result;
        }

        private static void ApplyDrillDownSettings(AdditionalTableModel tableModel)
        {
            if (tableModel.DrillDownSeries != null)
            {
                List<string> drillDownList = new List<string>();
                List<string> drillDownParentList = new List<string>();
                List<string> drillDownChildList = new List<string>();
                List<string> drillDownRootList = new List<string>();

                foreach (var serie in tableModel.DrillDownSeries)
                {
                    if (serie.ParentRelation != null
                        && serie.ChildRelation != null)
                    {
                        var tmpParentKey = serie.ParentRelation.Identifier;

                        if (!drillDownParentList.Contains(tmpParentKey))
                        {
                            drillDownParentList.Add(tmpParentKey);

                            if (!drillDownChildList.Contains(tmpParentKey)
                                && !drillDownRootList.Contains(tmpParentKey))
                            {
                                drillDownRootList.Add(tmpParentKey);
                            }
                        }

                        if (!drillDownList.Contains(tmpParentKey))
                        {
                            drillDownList.Add(tmpParentKey);
                        }

                        var tmpChildKey = serie.ChildRelation.Identifier;

                        if (!drillDownChildList.Contains(tmpChildKey))
                        {
                            drillDownChildList.Add(tmpChildKey);
                        }

                        if (!drillDownList.Contains(tmpChildKey))
                        {
                            drillDownList.Add(tmpChildKey);
                        }
                    }
                }

                if (tableModel.Columns != null
                    && tableModel.Columns.Count > 0)
                {
                    foreach (var column in tableModel.Columns)
                    {
                        if (drillDownList.Contains(column.Identifier))
                        {
                            column.IsDrillDown = true;

                            if (drillDownRootList.Contains(column.Identifier))
                            {
                                column.IsDrillDownRoot = true;
                            }

                            // It seems like only the group key maybe conbine with two separated key.
                            column.DrillDownId = IdEscapeHelper.EncodeString(tableModel.Identifier) + "-" + tableModel.SubIdentifier + "-" + column.Identifier;
                        }
                    }
                }

                if (tableModel.Rows != null
                    && tableModel.Rows.Count > 0)
                {
                    foreach (var row in tableModel.Rows)
                    {
                        if (row != null
                            && row.Values != null
                            && row.Values.Count > 0)
                        {
                            foreach (var value in row.Values)
                            {
                                var tmpParentSerie = tableModel.DrillDownSeries.Find(serie => serie.ParentRelation != null && serie.ParentRelation.Identifier == value.Identifier);

                                if (tmpParentSerie != null)
                                {
                                    if (tmpParentSerie.ParentRelation != null
                                        && tmpParentSerie.ParentRelation.Enumerations != null)
                                    {
                                        var tmpEscapeValue = IdEscapeHelper.EncodeString(value.Value);

                                        var tmpValue = tmpParentSerie.ParentRelation.Enumerations.Find(v => v.Identifier != null && v.Identifier.EndsWith(tmpEscapeValue));

                                        if (tmpValue != null)
                                        {
                                            value.Value = tmpValue.Display;
                                            value.ValueId = tmpValue.Identifier;
                                        }
                                    }
                                }
                                else
                                {
                                    var tmpChildSerie = tableModel.DrillDownSeries.Find(serie => serie.ChildRelation != null && serie.ChildRelation.Identifier == value.Identifier);

                                    if (tmpChildSerie != null)
                                    {
                                        if (tmpChildSerie.ChildRelation != null
                                            && tmpChildSerie.ChildRelation.Enumerations != null)
                                        {
                                            var tmpEscapeValue = IdEscapeHelper.EncodeString(value.Value);

                                            var tmpValue = tmpChildSerie.ChildRelation.Enumerations.Find(v => v.Identifier != null && v.Identifier.EndsWith(tmpEscapeValue));

                                            if (tmpValue != null)
                                            {
                                                value.Value = tmpValue.Display;
                                                value.ValueId = tmpValue.Identifier;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

     

        /// <summary>
        /// Builds the asi asit for update.
        /// *** detailed grouping logic:
        /// For ASI:
        ///     all subgroup are in one group.
        ///     each subgroup contains one row.
        ///     for example.
        ///     <ASIgroup>
        ///         <key>original AA group A key</key>
        ///         <ASIsubgroup>
        ///             <key>original AA sub-group A key</key>
        ///         </ASIsubgroup>
        ///         <ASIsubgroup>
        ///             <key>original AA sub-group B key</key>
        ///         </ASIsubgroup>
        ///     </ASIgroup>
        ///     
        /// For ASIT:
        ///     each group contains only data of one subgroup.
        ///     each subgroup represents one row.
        ///     for example.
        ///     <ASITgroup>
        ///         <key>original AA group A key + original AA sub-group A key</key>
        ///         <ASITsubgroup>
        ///             <key>original AA sub-group A key</key>
        ///         </ASITsubgroup>
        ///         <ASITsubgroup>
        ///             <key>original AA sub-group A key</key>
        ///         </ASITsubgroup>
        ///     </ASITgroup>
        /// 
        /// *** detailed action logic:
        /// For ASI/ASIT:
        /// 1. when no data operated in one sub-group:
        ///     AdditionalInformationSubGroup.type=""
        ///     AdditionalInformationSubGroup.action=""
        ///     each AdditionalItem.action=""
        ///     
        /// 2. when data added in one sub-group:
        ///     AdditionalInformationSubGroup.type="Data"
        ///     AdditionalInformationSubGroup.action="Add"
        ///     each AdditionalItem.action="Add"
        ///     
        /// 3. when data deleted in one sub-group:
        ///     AdditionalInformationSubGroup.type="Data"
        ///     AdditionalInformationSubGroup.action="Delete"
        ///     each AdditionalItem.action="Update"
        ///     
        /// 4. when data updated in one sub-group:
        ///     AdditionalInformationSubGroup.type="Data"
        ///     AdditionalInformationSubGroup.action="" or "Update"
        ///     each AdditionalItem.action="Update"
        /// </summary>
        /// <param name="additionalTableModel">The additional table model.</param>
        /// <returns>the asi asit for update.</returns>
        public static List<AdditionalInformationGroup> BuildAsiAsit4Update(List<AdditionalTableModel> additionalTableModel)
        {
            List<AdditionalInformationGroup> results = null;

            if (additionalTableModel != null)
            {
                results = new List<AdditionalInformationGroup>();
                var asitGroupArray = (from t in additionalTableModel
                                      where t != null
                                      select new AdditionalInformationGroup()
                                      {
                                          AddRemoveSubGroups = true,
                                          keys = KeysHelper.CreateXMLKeys(t.Identifier),
                                          identifierDisplay = t.Display,
                                          contextType = t.ContextType,
                                          security = t.Security,
                                          additionalInformationSubGroup = BuildAsiAsitSubGroup4Update(t, t.Columns, t.Rows)
                                      }).ToArray();
                results = asitGroupArray.ToList();
            }

            return results;
        }

        /// <summary>
        /// Builds the asi asit sub group for update.
        /// </summary>
        /// <param name="isASI">if set to <c>true</c> [is ASI].</param>
        /// <param name="currentTable">The current table.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="rows">The rows.</param>
        /// <returns>
        /// the asi asit sub group for update.
        /// </returns>
        private static AdditionalInformationSubGroup[] BuildAsiAsitSubGroup4Update(AdditionalTableModel currentTable, List<AdditionalColumnModel> columns, List<AdditionalRowModel> rows)
        {
            AdditionalInformationSubGroup[] result = null;
            List<AdditionalInformationSubGroup> tempResult = null;

            if (columns != null)
            {
                tempResult = new List<AdditionalInformationSubGroup>();

                var subGroupKeys = KeysHelper.CreateXMLKeys(currentTable.SubIdentifier);
                if (subGroupKeys == null || subGroupKeys.key == null || subGroupKeys.key.Length == 0)
                {
                    var identifier = currentTable.Identifier.Split(',')[1];
                    subGroupKeys = KeysHelper.CreateXMLKeys(identifier);
                }

                //build structure
                AdditionalInformationSubGroup strcuture = new AdditionalInformationSubGroup();
                strcuture.type = "Structural";
                strcuture.action = "Existing";
                strcuture.security = currentTable.Security;
                strcuture.keys = subGroupKeys;
                strcuture.identifierDisplay = currentTable.SubDisplay;
                strcuture.additionalItems = new AdditionalItems();
                strcuture.additionalItems.additionalItem = BuildAsiAsitItems4Update(null, columns);
                tempResult.Add(strcuture);

                if (rows != null && rows.Count >= 1)
                {
                    var subGroupType = "Data";

                    foreach (var row in rows)
                    {
                        var subGroup = new AdditionalInformationSubGroup();
                        subGroup.security = currentTable.Security;
                        if (string.IsNullOrWhiteSpace(row.Identifier))
                        {
                            subGroup.keys = new Keys()
                            {
                                key = subGroupKeys.key.ToArray()
                            };
                        }
                        else
                        {
                            subGroup.keys = KeysHelper.CreateXMLKeys(row.Identifier); ;
                        }
                       
                        subGroup.identifierDisplay = currentTable.SubDisplay;
                        if (string.IsNullOrWhiteSpace(subGroup.identifierDisplay))
                        {
                            subGroup.identifierDisplay = currentTable.Display;
                        }

                        subGroup.action = CommonHelper.ToGovXmlAction(row.Action);
                        subGroup.type = subGroupType;
                        subGroup.additionalItems = new AdditionalItems();
                        subGroup.additionalItems.additionalItem = BuildAsiAsitItems4Update(row, columns);
                        tempResult.Add(subGroup);
                    }

                    //Get Max Rows and put rows into sub group keys
                    //1. Get max row number
                    int maxNumber = -1;

                    //2. Set row number if sub group didn't have row number
                    foreach (var xmlSubGroup in tempResult)
                    {
                        if (xmlSubGroup.type == "Data" && xmlSubGroup.keys.key.Length == 1)
                        {
                            xmlSubGroup.keys.key = new string[] { xmlSubGroup.keys.key[0], maxNumber.ToString() };
                            maxNumber--;
                        }
                    }
                }

                result = tempResult.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Builds the asi asit items4 update.
        /// </summary>
        /// <param name="isASI">if set to <c>true</c> [is ASI].</param>
        /// <param name="currentRow">The current row.</param>
        /// <param name="columns">The columns.</param>
        /// <returns>
        /// the asi asit items4 update.
        /// </returns>
        private static AdditionalItem[] BuildAsiAsitItems4Update(AdditionalRowModel currentRow, List<AdditionalColumnModel> columns)
        {
            var tempresult = new List<AdditionalItem>();

            for (int i = 0; i < columns.Count; i++)
            {
                AdditionalValueModel currentValue = null;
                if (currentRow != null)
                {
                    currentValue = currentRow.Values[i];
                }

                var currentColumn = columns[i];
                var keys = KeysHelper.CreateXMLKeys(currentColumn.Identifier);
                var tempItem = new AdditionalItem()
                {
                    keys = KeysHelper.CreateXMLKeys(currentColumn.Identifier),
                    name = currentColumn.Name,
                    val = currentValue == null ? String.Empty : currentValue.Value,
                    action = currentRow == null ? null : CommonHelper.ToGovXmlAction(currentRow.Action),
                    identifierDisplay = currentColumn.Display,
                    dataType = new DataType()
                    {
                        readOnly = currentColumn.Readonly,
                        type = currentColumn.Type,
                        inputRequired = currentColumn.InputRequired,
                        inputRange = currentColumn.MaxValue == 0 && currentColumn.MinValue == 0 ? null :
                        new Range()
                        {
                            maxValue = currentColumn.MaxValue,
                            minValue = currentColumn.MinValue
                        },
                    },
                    security = currentColumn.Security,
                    unitOfMeasurement = currentColumn.UnitOfMeasurement,
                    drillDown = currentColumn.IsDrillDown.ToString()
                };

                if (currentRow != null 
                    && currentValue != null)
                {
                    if (currentColumn != null
                        && currentColumn.IsDrillDown)
                    {
                        if (!String.IsNullOrEmpty(currentValue.ValueId))
                        {
                            var tmpValue = currentValue.ValueId.Split('-');

                            if (tmpValue != null
                                && tmpValue.Length == 2)
                            {
                                tempItem.val = IdEscapeHelper.DecodeString(tmpValue[1]);
                            }
                        }
                    }
                }

                tempresult.Add(tempItem);
            }

            var result = tempresult.ToArray();
            return result;
        }

        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <param name="subGroups">The sub groups.</param>
        /// <returns>the additional columns.</returns>
        private static List<AdditionalColumnModel> GetColumns(AdditionalInformationSubGroup[] subGroups)
        {
            List<AdditionalColumnModel> result = null;

            if (subGroups != null && subGroups.Length > 0)
            {
                var structure = subGroups.SingleOrDefault((o) => o.type != null && o.type.ToLower() == "structural");
                if (structure == null)
                {
                    structure = subGroups[0];
                }

                if (structure.additionalItems != null && structure.additionalItems.additionalItem != null)
                {
                    result = (from i in structure.additionalItems.additionalItem
                              select new AdditionalColumnModel()
                              {
                                  Identifier = i.keys.ToStringKeys(),
                                  Display = i.identifierDisplay,
                                  Name = i.name,
                                  //Gov xml begin to discard the data type field, changed to use field type as default, while use type if fieldtype is empty for backward compatibility
                                  Type = i.dataType == null ? String.Empty : (string.IsNullOrEmpty(i.dataType.fieldType)? i.dataType.type : i.dataType.fieldType),
                                  DefaultValue = i.val,
                                  Enumerations = i.dataType == null || i.dataType.enumerations == null ? null : GetEnumerationLists(i.dataType.enumerations.AMOEnumeration),
                                  InputRequired = i.dataType == null ? false : i.dataType.inputRequired,
                                  MaxValue = i.dataType == null || i.dataType.inputRange == null ? 0 : i.dataType.inputRange.maxValue,
                                  MinValue = i.dataType == null || i.dataType.inputRange == null ? 0 : i.dataType.inputRange.minValue,
                                  Security = i.security,
                                  Readonly = i.dataType == null ? false : i.dataType.readOnly,
                                  UnitOfMeasurement = i.unitOfMeasurement,
                                  //IsDrillDown = !String.IsNullOrEmpty(i.drillDown) && i.drillDown.ToUpper() == "TRUE" ? true : false
                              }).ToList();
                }
            }

            return result;
        }

        private static string GetSubIdentifier(AdditionalInformationSubGroup[] subGroups)
        {
            if (subGroups != null && subGroups.Length > 0)
            {
                var structure = subGroups.SingleOrDefault((o) =>o.type!=null && o.type.ToLower() == "structural");
                if (structure == null)
                {
                    structure = subGroups[0];
                }

                return KeysHelper.ToStringKeys(structure.keys);
            }

            return null;
        }

        private static List<AdditionalDrillDownSeriesModel> GetSubDrillDown(AdditionalInformationSubGroup[] subGroups)
        {
            if (subGroups != null && subGroups.Length > 0)
            {
                var structure = subGroups.SingleOrDefault((o) => o.type != null && o.type.ToLower() == "structural");
                if (structure == null)
                {
                    structure = subGroups[0];
                }

                return ASIHelper.ToClientDrillDown(structure.drillDown);
            }

            return null;
        }

        private static string GetSubDisplay(AdditionalInformationSubGroup[] subGroups)
        {
            if (subGroups != null && subGroups.Length > 0)
            {
                var structure = subGroups.SingleOrDefault((o) => o.type != null && o.type.ToLower() == "structural");
                if (structure == null)
                {
                    structure = subGroups[0];
                }

                return structure.identifierDisplay;
            }

            return null;
        }

        private static string GetSubSecurity(AdditionalInformationSubGroup[] subGroups)
        {
            if (subGroups != null && subGroups.Length > 0)
            {
                var structure = subGroups.SingleOrDefault((o) => o.type != null && o.type.ToLower() == "structural");

                if (structure == null)
                {
                    structure = subGroups[0];
                }

                return structure.security;
            }

            return null;
        }

        private static string GetSubAlias(AdditionalInformationSubGroup[] subGroups)
        {
            if (subGroups != null && subGroups.Length > 0)
            {
                var structure = subGroups.SingleOrDefault((o) => o.type != null && o.type.ToLower() == "structural");

                if (structure == null)
                {
                    structure = subGroups[0];
                }

                return structure.SubGroupAlias;
            }

            return null;
        }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <param name="isASI">if set to <c>true</c> [is ASI].</param>
        /// <param name="subGroups">The sub groups.</param>
        /// <returns>
        /// the additional rows.
        /// </returns>
        private static List<AdditionalRowModel> GetRows(bool isASI, AdditionalInformationSubGroup[] subGroups)
        {
            List<AdditionalRowModel> result = null;

            if (subGroups != null)
            {
                var drillDownSeries = GetSubDrillDown(subGroups);

                result = (from s in subGroups
                          where s != null
                          && (isASI || s.type != "Structural")
                          select new AdditionalRowModel()
                          {
                              Identifier = s.keys.ToStringKeys(),
                              Display = s.identifierDisplay,
                              Action = s.action,
                              Values = GetValues(drillDownSeries, s)
                          }).ToList();
            }

            return result;
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="subGroup">The sub group.</param>
        /// <returns>the additional values.</returns>
        private static List<AdditionalValueModel> GetValues(List<AdditionalDrillDownSeriesModel> drillDownSeries, AdditionalInformationSubGroup subGroup)
        {
            List<AdditionalValueModel> result = null;

            if (subGroup != null && subGroup.additionalItems != null && subGroup.additionalItems.additionalItem != null && subGroup.additionalItems.additionalItem.Length > 0)
            {
                result = (from i in subGroup.additionalItems.additionalItem
                          where i != null
                          select new AdditionalValueModel()
                          {
                              Identifier = i.keys.ToStringKeys(),
                              Value = i.val,
                              Action = i.action
                          }).ToList();


            }

            return result;
        }

        /// <summary>
        /// Gets the enumeration lists.
        /// </summary>
        /// <param name="enumerationArray">The enumeration lists.</param>
        /// <returns>the enumeration lists.</returns>
        public static List<EnumerationModel> GetEnumerationLists(Enumeration[] enumerationArray)
        {
            List<EnumerationModel> result = null;

            if (enumerationArray != null)
            {
                result = (from e in enumerationArray
                          where e != null
                          select new EnumerationModel()
                          {
                              Identifier = (e.keys!=null && e.keys.key!=null && e.keys.key.Length==1)?e.keys.key[0]:KeysHelper.ToStringKeys(e.keys),
                              Display = e.identifierDisplay
                          }).ToList();
            }

            return result;
        }
    }
}
