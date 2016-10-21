using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Core.Ioc;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ASISecurityBusinessEntity : IASISecurityBusinessEntity
    {
        

        public ASISecurityBusinessEntity(IRecordBusinessEntity recordBusinessEntity, IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.recordBusinessEntity = recordBusinessEntity;
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        #region Properties

        //private IReferenceBusinessEntity _referenceBusinessEntity = null;
        private readonly IReferenceBusinessEntity referenceBusinessEntity;
        //{
        //    get
        //    {
        //        if (_referenceBusinessEntity == null)
        //        {
        //            //Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _referenceBusinessEntity = ServiceLocator.Resolve<IReferenceBusinessEntity>();
        //        }

        //        return _referenceBusinessEntity; 
        //    }
        //}

        //private IRecordBusinessEntity _recordBusinessEntity = null;
        private readonly IRecordBusinessEntity recordBusinessEntity;
        //{
        //    get
        //    {
        //        if (_recordBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _recordBusinessEntity = IocContainer.Resolve<IRecordBusinessEntity>(ctorParams);
        //        }

        //        return _recordBusinessEntity;
        //    }
        //}

        #endregion

        #region Remove Data

        public void RemoveASIInvisableItems(List<AdditionalGroupModel> groups)
        {
            if (groups == null)
            {
                return;
            }

            RemoveGroups(groups);

            foreach (var group in groups)
            {
                RemoveSubGroups(group.SubGroups);
            }
        }

        #region Remove ASI Data

        private void RemoveGroups(List<AdditionalGroupModel> groups)
        {
            if (groups == null)
            {
                return;
            }

            groups.RemoveAll(ShouldRemoveGroupItem);
        }

        private void RemoveSubGroups(List<AdditionalSubGroupModel> subGroups)
        {
            if (subGroups == null)
            {
                return;
            }

            subGroups.RemoveAll(ShouldRemoveSubGroupItem);

            foreach (var item in subGroups)
            {
                RemoveItems(item.Items);
            }
        }

        private void RemoveItems(List<AdditionalItemModel> items)
        {
            if (items == null)
            {
                return;
            }

            items.RemoveAll(ShouldRemoveItem);
        }

        private bool ShouldRemoveGroupItem(AdditionalGroupModel additionalGroupModel)
        {
            return _ShouldRemoveItemImp(additionalGroupModel.Security);
        }
        
        private bool ShouldRemoveSubGroupItem(AdditionalSubGroupModel additionalSubGroupModel)
        {
            return _ShouldRemoveItemImp(additionalSubGroupModel.Security);
        }

        private bool ShouldRemoveItem(AdditionalItemModel item)
        {
            return _ShouldRemoveItemImp(item.Security);
        }

        private bool _ShouldRemoveItemImp(string securityValue)
        {
            bool result = false;

            if (!String.IsNullOrWhiteSpace(securityValue))
            {
                string securityValueUpper = securityValue.ToUpper();

                if (securityValueUpper.CompareTo(SecurityNoneValue) == 0)
                {
                    result = true;
                }
            }

            return result;
        }

        #endregion

        public void RemoveASITInvisableItems(List<AdditionalTableModel> tables)
        {
            if (tables == null)
            {
                return;
            }

            RemoveTableItems(tables);

            foreach (var table in tables)
            {
                RemoveColumnsAndRows(table.Columns, table.Rows);
            }
        }
        
        #region Remove ASIT Data
        
        private void RemoveTableItems(List<AdditionalTableModel> tables)
        {
            if (tables == null)
            {
                return;
            }

            tables.RemoveAll(ShouldRemoveTableItem);
        }

        private void RemoveColumnsAndRows(List<AdditionalColumnModel> columns, List<AdditionalRowModel> rows)
        {
            if (columns == null)
            {
                return;
            }

            List<string> hiddenColumnIds = new List<string>();

            columns.FindAll(column => column.Security == SecurityNoneValue).ForEach(item => hiddenColumnIds.Add(item.Identifier));

            columns.RemoveAll(column => hiddenColumnIds.Contains(column.Identifier));

            if (rows != null)
	        {
                rows.ForEach(row => 
                    {
                        if (row.Values != null)
	                    {
                            row.Values.RemoveAll(value => hiddenColumnIds.Contains(value.Identifier));
	                    }
                    });
	        }
        }

        private bool ShouldRemoveColumn(AdditionalColumnModel additionalColumnModel)
        {
            return _ShouldRemoveItemImp(additionalColumnModel.Security);
        }

        private bool ShouldRemoveTableItem(AdditionalTableModel additionalTableModel)
        {
            return _ShouldRemoveItemImp(additionalTableModel.Security) || _ShouldRemoveItemImp(additionalTableModel.SubSecurity);
        }

        #endregion

        #endregion

        #region Attach Data For Creation

        public void AttachInvisableItemsForCreation(RecordTypeModel recordType, List<AdditionalGroupModel> asis, List<AdditionalTableModel> asits)
        {
            if (recordType == null)
            {
                return;
            }

            if (String.IsNullOrWhiteSpace(recordType.Identifier))
            {
                return;
            }

            AttachASIsForCreation(recordType, asis);

            AttachASITsForCreation(recordType, asits);
        }

        #region Attach ASIs For Creation - Need to fetch reference data

        private void AttachASIsForCreation(RecordTypeModel recordType, List<AdditionalGroupModel> asis)
        {
            AdditionalRequest asiRequest = new AdditionalRequest
            {
                RelatedId = recordType.Identifier
            };

            AdditionalResponse referenceASI = referenceBusinessEntity.GetAllRecordTypeAdditionals(asiRequest);

            AttachASIsForCreationImp(asis, referenceASI.Additionals);
        }

        private void AttachASIsForCreationImp(List<AdditionalGroupModel> asis, List<AdditionalGroupModel> referenceASIs)
        {
            if (referenceASIs == null)
            {
                return;
            }

            if (asis == null)
            {
                throw new BadRequestException("Request rejected for obsolete user-defined fields. Please synchronize the user-defined information and record type definitions, and then try to create the record again.");
            }

            if (asis.Count == 0)
            {
                referenceASIs.ForEach(group =>
                    {
                        if (group.SubGroups != null)
                        {
                            group.SubGroups.ForEach(subGroup =>
                                {
                                    subGroup.Action = "Added";

                                    if (subGroup.Items != null)
                                    {
                                        subGroup.Items.ForEach(item => item.Action = "Added");
                                    }
                                });
                        }
                    });

                asis.AddRange(referenceASIs);

                return;
            }

            AttachGroups(asis, referenceASIs);
        }

        #endregion

        #region Attach ASITs For Creation - Need to fetch reference data

        private void AttachASITsForCreation(RecordTypeModel recordType, List<AdditionalTableModel> asits)
        {
            AdditionalTableRequest asitRequest = new AdditionalTableRequest
            {
                RelatedId = recordType.Identifier
            };

            AdditionalTableResponse referenceASIT = referenceBusinessEntity.GetAllRecordTypeAdditionalTables(asitRequest);

            AttachASITsForCreationImp(asits, referenceASIT.AdditionalTables);
        }

        private void AttachASITsForCreationImp(List<AdditionalTableModel> asits, List<AdditionalTableModel> referenceASITs)
        {
            if (referenceASITs == null)
            {
                return;
            }

            if (asits == null)
            {
                throw new BadRequestException("Request rejected for obsolete user-defined fields. Please synchronize the user-defined information and record type definitions, and then try to create the record again.");
            }

            if (asits.Count == 0)
            {
                asits.AddRange(referenceASITs);

                return;
            }

            AttachTables(asits, referenceASITs);
        }

        #endregion

        #endregion

        #region Attach Data For Update

        public void AttachInvisableItemsForUpdate(string recordId, List<AdditionalGroupModel> asis, List<AdditionalTableModel> asits)
        {
            if (String.IsNullOrWhiteSpace(recordId))
            {
                return;
            }

            AttachASIsForUpdate(recordId, asis);

            AttachASITsForUpdate(recordId, asits);
        }

        #region Attach ASIs For Update - Need to fetch daily data

        private void AttachASIsForUpdate(string recordId, List<AdditionalGroupModel> asis)
        {
            AdditionalRequest request = new AdditionalRequest
            {
                RelatedId = recordId
            };

            AdditionalResponse dailyASIs = recordBusinessEntity.GetAllRecordAdditionals(request);

            AttachASIsForUpdateImp(asis, dailyASIs.Additionals);
        }

        private void AttachASIsForUpdateImp(List<AdditionalGroupModel> asis, List<AdditionalGroupModel> dailyASIs)
        {
            if (dailyASIs == null)
            {
                return;
            }

            if (asis == null)
            {
                throw new BadRequestException("Request rejected for obsolete user-defined fields. Please synchronize the user-defined information and record type definitions, and then try to create the record again.");
            }
            
            if (asis.Count == 0)
            {
                dailyASIs.ForEach(group =>
                {
                    if (group.SubGroups != null)
                    {
                        group.SubGroups.ForEach(subGroup =>
                        {
                            subGroup.Action = ActionDataModel.NORMAL;

                            if (subGroup.Items != null)
                            {
                                subGroup.Items.ForEach(item =>
                                    {
                                        if (String.IsNullOrEmpty(item.Action))
	                                    {
                                            item.Action = ActionDataModel.NORMAL;
	                                    }
                                    });
                            }
                        });
                    }
                });

                asis.AddRange(dailyASIs);

                return;
            }

            AttachGroups(asis, dailyASIs, true);
        }

        #endregion

        #region Attach ASITs For Update - Need to fetch daily data

        private void AttachASITsForUpdate(string recordId, List<AdditionalTableModel> asits)
        {
            AdditionalTableRequest request = new AdditionalTableRequest
            {
                RelatedId = recordId
            };

            AdditionalTableResponse dailyASITs = recordBusinessEntity.GetAllRecordAdditionalTables(request);

            AttachASITsForUpdateImp(asits, dailyASITs.AdditionalTables);
        }

        private void AttachASITsForUpdateImp(List<AdditionalTableModel> asits, List<AdditionalTableModel> dailyASITs)
        {
            if (dailyASITs == null)
            {
                return;
            }

            if (asits == null)
            {
                throw new BadRequestException("Request rejected for obsolete user-defined fields. Please synchronize the user-defined information and record type definitions, and then try to create the record again.");
            }

            if (asits.Count == 0)
            {
                asits.AddRange(dailyASITs);

                return;
            }

            AttachTables(asits, dailyASITs);
        }

        #endregion

        #endregion

        #region Attach Data Implementation

        #region Attach ASIs

        private void AttachGroups(List<AdditionalGroupModel> asis, List<AdditionalGroupModel> referenceASIs, bool isUpdated = false)
        {
            var refReadonlyAndHiddenGroups = referenceASIs.FindAll(group => group.Security == SecurityReadOnlyValue || group.Security == SecurityNoneValue);

            var deletedGroups = asis.Intersect(refReadonlyAndHiddenGroups, new AdditionalGroupComparer());

            asis.RemoveAll(group => deletedGroups.Contains(group));

            foreach (var group in asis)
            {
                if (group == null)
                {
                    continue;
                }

                var refGroup = referenceASIs.Find(rGroup => rGroup.Identifier == group.Identifier);

                if (refGroup == null)
                {
                    continue;
                }

                if (group.SubGroups != null)
                {
                    AttachSubGroups(group, refGroup, isUpdated);
                }
            }

            asis.AddRange(refReadonlyAndHiddenGroups);
        }

        private void AttachSubGroups(AdditionalGroupModel group, AdditionalGroupModel refGroup, bool isUpdated)
        {
            var tmpRefReadonlyAndHiddenSubGroups = refGroup.SubGroups.FindAll(sg => sg.Security == SecurityReadOnlyValue || sg.Security == SecurityNoneValue);

            if (tmpRefReadonlyAndHiddenSubGroups != null)
            {
                var deletedSubGroups = group.SubGroups.Intersect(tmpRefReadonlyAndHiddenSubGroups, new AdditionalSubGroupComparer());

                group.SubGroups.RemoveAll(subGroup => deletedSubGroups.Contains(subGroup));

                foreach (var subGroup in group.SubGroups)
                {
                    AttachItems(refGroup, subGroup);
                }

                group.SubGroups.AddRange(tmpRefReadonlyAndHiddenSubGroups);

                group.SubGroups.ForEach(subGroup =>
                {
                    if (isUpdated)
                    {
                        subGroup.Action = ActionDataModel.NORMAL;
                    }
                    else
                    {
                        subGroup.Action = ActionDataModel.ADDED;
                    }

                    if (subGroup.Items != null)
                    {
                        subGroup.Items.ForEach(item => 
                        {
                            if (isUpdated)
                            {
                                item.Action = ActionDataModel.UPDATED;
                            }
                            else
                            {
                                item.Action = ActionDataModel.ADDED;
                            }
                        });
                    }
                });
            }
        }

        private void AttachItems(AdditionalGroupModel refGroup, AdditionalSubGroupModel subGroup)
        {
            var refSubGroup = refGroup.SubGroups.Find(sg => sg.Identifier == subGroup.Identifier);

            if (subGroup.Items != null)
            {
                var tmpRefReadonlyAndHiddenItems = refSubGroup.Items.FindAll(item => item.Security == SecurityReadOnlyValue || item.Security == SecurityNoneValue);

                if (tmpRefReadonlyAndHiddenItems != null)
                {
                    var deletedItems = subGroup.Items.Intersect(tmpRefReadonlyAndHiddenItems, new AdditionalItemComparer());

                    subGroup.Items.RemoveAll(item => deletedItems.Contains(item));

                    subGroup.Items.AddRange(tmpRefReadonlyAndHiddenItems);

                    //subGroup.Items.ForEach(item =>
                    //    {
                    //        if (String.IsNullOrEmpty(item.Action))
                    //        {
                    //            item.Action = ActionDataModel.NORMAL; 
                    //        }
                    //    });
                }
            }
        }

        #endregion

        #region Attach ASIT

        private void AttachTables(List<AdditionalTableModel> asits, List<AdditionalTableModel> referenceASITs)
        {
            var refReadonlyAndHiddenTables = referenceASITs.FindAll(table => table.Security == SecurityReadOnlyValue || table.Security == SecurityNoneValue);

            var deletedTables = asits.Intersect(refReadonlyAndHiddenTables, new AdditionalTableComparer());

            asits.RemoveAll(table => deletedTables.Contains(table));

            AttachColumnsAndRows(asits, referenceASITs);

            refReadonlyAndHiddenTables.ForEach(table =>
            {
                if (table.Columns != null)
                {
                    table.Columns.ForEach(column => column.Action = ActionDataModel.NORMAL);

                    if (table.Rows == null)
                    {
                        table.Rows = new List<AdditionalRowModel>();
                    }

                    var tmpRowItem = new AdditionalRowModel();

                    tmpRowItem.Values = new List<AdditionalValueModel>();

                    table.Columns.ForEach(column =>
                    {
                        tmpRowItem.Identifier = table.SubIdentifier;
                        tmpRowItem.Display = table.SubDisplay;
                        tmpRowItem.Action = "Added";
                        tmpRowItem.Values.Add(new AdditionalValueModel
                        {
                            Identifier = column.Identifier,
                            Value = column.DefaultValue,
                            Action = "Added"
                        });
                    });

                    table.Rows.Add(tmpRowItem);
                }
            });

            asits.AddRange(refReadonlyAndHiddenTables);
        }

        internal void AttachColumnsAndRows(List<AdditionalTableModel> asits, List<AdditionalTableModel> referenceASITs)
        {
            foreach (var table in asits)
            {
                if (table == null)
                {
                    continue;
                }

                var refTable = referenceASITs.Find(rTable => rTable.Identifier == table.Identifier && rTable.SubIdentifier == table.SubIdentifier);

                if (refTable == null)
                {
                    throw new BadRequestException("Request rejected for obsolete user-defined fields. Please synchronize the user-defined information and record type definitions, and then try to create the record again.");
                }

                table.Display = refTable.Display;
                table.SubDisplay = refTable.SubDisplay;

                if (table.Columns == null)
                {
                    continue;
                }

                if (refTable.Columns == null)
                {
                    throw new BadRequestException("Request rejected for obsolete user-defined fields. Please synchronize the user-defined information and record type definitions, and then try to create the record again.");
                }

                var refReadonlyAndHiddenColumns = refTable.Columns.FindAll(column => column.Security == SecurityReadOnlyValue || column.Security == SecurityNoneValue);

                List<string> refReadonlyAndHiddenColumnIds = new List<string>();

                List<AdditionalValueModel> refReadonlyAndHiddenRows = new List<AdditionalValueModel>();

                if (refReadonlyAndHiddenColumns != null)
                {
                    refReadonlyAndHiddenColumns.ForEach(item => refReadonlyAndHiddenColumnIds.Add(item.Identifier));

                    refReadonlyAndHiddenColumns.ForEach(item => refReadonlyAndHiddenRows.Add(new AdditionalValueModel
                    {
                        Identifier = item.Identifier,
                        Value = item.DefaultValue,
                        Action = "Added"
                    }));
                }

                table.Columns.RemoveAll(column => refReadonlyAndHiddenColumnIds.Contains(column.Identifier));

                if (table.Rows != null)
                {
                    table.Rows.ForEach(row =>
                    {
                        if (row.Values != null)
                        {
                            row.Values.RemoveAll(value => refReadonlyAndHiddenColumnIds.Contains(value.Identifier));
                        }

                        // CF-1431, need to distinguish 2 cases for row values
                        var refRow = (refTable.Rows==null)?null:refTable.Rows.Find(value => value.Identifier == row.Identifier);
                        if (refRow == null)
                        {
                            // Case 1. row data does not exist, use default value
                            row.Values.AddRange(refReadonlyAndHiddenRows);
                        }
                        else
                        {
                            // Case 2. row data already exist, use value from referenceASITs
                            var refRowValues = refRow.Values.FindAll(column => refReadonlyAndHiddenColumnIds.Contains(column.Identifier));
                            row.Values.AddRange(refRowValues);
                        }

                        row.Values.ForEach(value =>
                            {
                                if (String.IsNullOrEmpty(value.Action))
                                {
                                    value.Action = "Updated"; 
                                }
                            });

                        if (String.IsNullOrEmpty(row.Action))
                        {
                            row.Action = "Updated";
                        }
                    });
                }

                table.Columns.ForEach(column =>
                {
                    var refColumn = refTable.Columns.Find(c => c.Identifier == column.Identifier);

                    //column.Action = "Added";
                    if (refColumn != null)
                    {
                        column.Display = refColumn.Display;
                        column.Name = refColumn.Name;
                    }
                });

                table.Columns.AddRange(refReadonlyAndHiddenColumns);
            }
        }

        #endregion

        #endregion

        #region Const String

        const string SecurityNoneValue = "N";
        const string SecurityFullValue = "F";
        const string SecurityReadOnlyValue = "R";

        #endregion
    }
}
