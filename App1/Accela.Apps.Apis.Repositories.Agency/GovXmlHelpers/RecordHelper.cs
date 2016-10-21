using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.CostModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;
using Accela.Apps.Apis.Models.DomainModels.PartModels;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Core.Ioc;
using Accela.Apps.Shared;
using Accela.Apps.Shared.FormatHelpers;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public delegate void a1<T>(T val);
    public delegate M[] a2<M>(M[] val);
    public delegate void a3<M>(M obj, string val);

    internal class RecordHelper : GovXmlHelperBase
    {
        private readonly string _bizServerVersion;
        private readonly bool _autoCorrectCoordinates;

        public RecordHelper(string bizServerVersion, bool autoCorrectCoordinates = false)
        {
            if (String.IsNullOrEmpty(bizServerVersion))
            {
                throw new ArgumentNullException("bizServerVersion cannot be null.");
            }

            _bizServerVersion = bizServerVersion;
            _autoCorrectCoordinates = autoCorrectCoordinates;
        }

        public static CreateRecordResponse ToClientRecordResponse(GovXML response)
        {
            CreateRecordResponse results = new CreateRecordResponse();

            if (response.initiateCAPResponse.system != null)
            {
                results.Events = CommonHelper.GetClientEventMessage(response.initiateCAPResponse.system.eventMessages);
            }

            if (response.initiateCAPResponse.cap != null)
            {
                results.RecordId = new RecordIdModel();
                results.RecordId.Identifier = KeysHelper.ToStringKeys(response.initiateCAPResponse.cap.keys);
                results.RecordId.Display = response.initiateCAPResponse.cap.identifierDisplay;

            }
            else if (response.initiateCAPResponse.capId != null)
            {
                results.RecordId = new RecordIdModel();
                results.RecordId.Identifier = KeysHelper.ToStringKeys(response.initiateCAPResponse.capId.keys);
                results.RecordId.Display = response.initiateCAPResponse.capId.identifierDisplay;
            }
            return results;
        }

        public UpdateRecordResponse ToUpdateRecordResponse(GovXML response)
        {
            UpdateRecordResponse results = new UpdateRecordResponse();

            if (response.UpdateCAPResponse.system != null)
            {
                results.Events = CommonHelper.GetClientEventMessage(response.UpdateCAPResponse.system.eventMessages);
            }

            if (response.UpdateCAPResponse.cap != null)
            {
                results.Record = ToClientRecord(response.UpdateCAPResponse.cap);

                if (_autoCorrectCoordinates)
                {
                    SetCoordinates(new List<RecordModel>() { results.Record });
                }
            }

            return results;
        }

        private static WorkOrderTasks ToXmlWorkOrderTaskObjects(List<WorkOrderTaskModel> workOrderTaskModels)
        {
            WorkOrderTasks tasks = null;
            if (workOrderTaskModels != null)
            {
                var xmlTasks = new List<WorkOrderTask>();
                foreach (WorkOrderTaskModel item in workOrderTaskModels)
                {
                    WorkOrderTask xmlTask = ToGovXmlWorkOrderTask(item);
                    if (xmlTask != null)
                    {
                        xmlTasks.Add(xmlTask);
                    }
                }

                tasks = new WorkOrderTasks();
                tasks.WorkOrderTask = xmlTasks.ToArray();
            }

            return tasks;
        }

        private static WorkOrderTask ToGovXmlWorkOrderTask(WorkOrderTaskModel workOrderTaskModel)
        {
            if (workOrderTaskModel != null)
            {
                return new WorkOrderTask
                           {
                               action = CommonHelper.ToGovXmlAction(workOrderTaskModel.Action),
                               Actual = workOrderTaskModel.Actual,
                               Comments = workOrderTaskModel.Comments,
                               Complete = workOrderTaskModel.Complete,
                               CompletedBy = workOrderTaskModel.CompletedBy,
                               CompletedDate = workOrderTaskModel.CompletedDate,
                               Description = workOrderTaskModel.Description,
                               Estimate = workOrderTaskModel.Estimate,
                               Order = workOrderTaskModel.Order,
                               ProcessCode = workOrderTaskModel.ProcessCode,
                               ProcessID = workOrderTaskModel.ProcessID,
                               StandardOperatingProcedures = workOrderTaskModel.StandardOperatingProcedures,
                               Status = workOrderTaskModel.Status,
                               StepNumber = workOrderTaskModel.StepNumber,
                               TaskCode = workOrderTaskModel.TaskCode,
                               TaskDescription = workOrderTaskModel.TaskDescription,
                               TotalCost = workOrderTaskModel.TotalCost,
                               Unit = workOrderTaskModel.Unit,
                               UpdatedBy = workOrderTaskModel.UpdatedBy,
                               UpdatedDate = workOrderTaskModel.UpdatedDate,
                               WorkflowTaskStatus = workOrderTaskModel.WorkflowTaskStatus,
                               TaskCodeIndex = workOrderTaskModel.TaskCodeIndex
                           };
            }
            return null;
        }

        private static Parts ToXmlPartsObjects(List<PartModel> partModels)
        {
            if (partModels == null) return null;

            return new Parts
            {
                Part = partModels.Select(ToGovXmlPart).Where(xmlPart => xmlPart != null).ToArray()
            };
        }

        private static Part ToGovXmlPart(PartModel item)
        {
            if (item == null) return null;

            return new Part
            {
                action = CommonHelper.ToGovXmlAction(item.Action),
                keys = KeysHelper.CreateXMLKeys(item.Id),
                AltID = item.AltID,
                Comments = item.Comments,
                identifierDisplay = item.Display,
                PartBrandIdentifier =
                    item.PartBrand == null
                        ? null
                        : new PartBrandIdentifier
                        {
                            keys = KeysHelper.CreateXMLKeys(item.PartBrand.Identifier),
                            identifierDisplay = item.PartBrand.Display
                        },
                PartBrand = item.PartBrand == null ? null : item.PartBrand.Display,
                PartType = item.PartType == null
                    ? null
                    : new Accela.Automation.GovXmlClient.Model.Type
                    {
                        keys = KeysHelper.CreateXMLKeys(item.PartType.Identifier),
                        identifierDisplay = item.PartType.Display
                    },
                PartDescriptionIdentifier =
                    item.PartDescription == null
                        ? null
                        : new PartDescriptionIdentifier
                        {
                            keys = KeysHelper.CreateXMLKeys(item.PartDescription.Identifier),
                            identifierDisplay = item.PartDescription.Display
                        },
                PartDescription = item.PartDescription == null ? null : item.PartDescription.Display,
                PartInventoryId =
                    item.PartInventory == null
                        ? null
                        : new PartInventoryId
                        {
                            keys = KeysHelper.CreateXMLKeys(item.PartInventory.Identifier),
                            identifierDisplay = item.PartInventory.Display
                        },
                Status = item.PartStatus == null
                    ? null
                    : new AAMStatus
                    {
                        keys = KeysHelper.CreateXMLKeys(item.PartStatus.Identifier),
                        date = item.PartStatus.Date,
                        name = item.PartStatus.Name,
                        time = item.PartStatus.Time,
                        val = item.PartStatus.Value
                    },
                Supplies = ToGovxmlPartSupplyObjects(item.PartSupplies),
                UnitOfMeasurementIdentifier =
                    item.PartUnitOfMeasurement == null
                        ? null
                        : new UnitOfMeasurementIdentifier
                        {
                            keys = KeysHelper.CreateXMLKeys(item.PartUnitOfMeasurement.Identifier),
                            identifierDisplay = item.PartUnitOfMeasurement.Display
                        },
                UnitOfMeasure = item.PartUnitOfMeasurement == null ? null : item.PartUnitOfMeasurement.Display,
                PartNumber = item.PartNumber,
                Quantity = item.Quantity,
                Taxable = item.Taxable,
                TransactionDate = item.TransactionDate,
                UnitCost = item.UnitCost,
                bin = item.Bin,
                WorkOrderTaskCode = item.WorkOrderTaskCode,
                WorkOrderTaskCodeIndex = item.WorkOrderTaskCodeIndex
            };
        }

        private static Supplies ToGovxmlPartSupplyObjects(List<PartSupplyModel> supplies)
        {
            if (supplies != null && supplies.Count > 0)
            {
                var supplyObjs = new Supplies();
                var suplyXmls = new List<Supply>();
                foreach (PartSupplyModel supply in supplies)
                {
                    suplyXmls.Add(new Supply
                                      {
                                          Keys = KeysHelper.CreateXMLKeys(supply.Identifier),
                                          IdentifierDisplay = supply.Display,
                                          LocationName = supply.LocationName,
                                          LocationSeq = supply.LocationSeq
                                      });
                }

                supplyObjs.Supply = suplyXmls.ToArray();

                return supplyObjs;
            }
            return null;
        }

        private static CostItems ToXmlCostsObjects(List<CostModel> costs)
        {
            if (costs == null) return null;

            return new CostItems
            {
                CostItem = costs.Select(ToXmlCostItem).Where(xmlCost => xmlCost != null).ToArray()
            };
        }

        private static CostItem ToXmlCostItem(CostModel cost)
        {
            if (cost != null)
            {
                return new CostItem
                           {
                               action = CommonHelper.ToGovXmlAction(cost.Action),
                               keys = KeysHelper.CreateXMLKeys(cost.Id),
                               Comments = cost.Comments,
                               identifierDisplay = cost.Display,
                               contextType = cost.ContextType,
                               CostAccount = cost.CostAccount == null ? null : cost.CostAccount.Display, // isolated.
                               CostAccountIdentifier =
                                   cost.CostAccount == null
                                       ? null
                                       : new CostAccountIdentifier
                                             {
                                                 keys = KeysHelper.CreateXMLKeys(cost.CostAccount.Identifier),
                                                 identifierDisplay = cost.CostAccount.Display
                                             },
                               CostDate = cost.CostDate,
                               CostFactor = cost.CostFactor,
                               CostFix = cost.CostFix,
                               CostItemTypeId =
                                   cost.CostItemType == null
                                       ? null
                                       : new Identifier
                                             {
                                                 keys = KeysHelper.CreateXMLKeys(cost.CostItemType.Identifier),
                                                 identifierDisplay = cost.CostItemType.Display
                                             },
                               TotalCost = cost.TotalCost,
                               UnitCost = cost.UnitCost,
                               Formula = cost.Formula,
                               SubGroup = cost.SubGroup,
                               Quantity = cost.Quantity,
                               Status = cost.Status == null
                                            ? null
                                            : new AAMStatus
                                                  {
                                                      keys = KeysHelper.CreateXMLKeys(cost.Status.Id),
                                                      name = cost.Status.Display
                                                  },
                               type = ToGovxmlTypeObject(cost.Type),
                               UnitOfMeasure = cost.UnitOfMeasureValue,
                               CostUnitOfMeasureIdentifier =
                                   cost.CostUnitOfMeasure == null
                                       ? null
                                       : new CostUnitOfMeasureIdentifier
                                             {
                                                 keys = KeysHelper.CreateXMLKeys(cost.CostUnitOfMeasure.Identifier),
                                                 identifierDisplay = cost.CostUnitOfMeasure.Display
                                             },
                               StartTime = cost.StartTime,
                               EndTime = cost.EndTime,
                               WorkOrderTaskCode = cost.WorkOrderTaskCode,
                               WorkOrderTaskCodeIndex = cost.WorkOrderTaskCodeIndex,
                               CostQuantities = ToXmlCostQuantities(cost.CostQuantities)
                           };
            }
            return null;
        }

        private static CostQuantities ToXmlCostQuantities(List<CostQuantityModel> costQuantities)
        {
            if (costQuantities == null)
            {
                return null;
            }

            return new CostQuantities
            {
                CostQuantity = costQuantities.Select(ToXmlCostQuantiy).Where(xmlCostQuantity => xmlCostQuantity != null).ToArray()
            };
        }

        private static CostQuantity ToXmlCostQuantiy(CostQuantityModel costQuantity)
        {
            if (costQuantity == null)
            {
                return null;
            }

            return new CostQuantity
            {
                costFactor = new Identifier { keys = KeysHelper.CreateXMLKeys(costQuantity.Id), identifierDisplay = costQuantity.Display},
                quantity = costQuantity.Quantity.ToString(CultureInfo.InvariantCulture)
            };
        }

        private static Accela.Automation.GovXmlClient.Model.Type ToGovxmlTypeObject(CostTypeModel costTypeModel)
        {
            if (costTypeModel != null)
            {
                var type = new Accela.Automation.GovXmlClient.Model.Type();
                type.keys = KeysHelper.CreateXMLKeys(costTypeModel.Id);
                type.identifierDisplay = costTypeModel.Display;
                return type;
            }
            return null;
        }

        private static CAPComments ToGovXmlComments(List<RecordCommentModel> recordComments)
        {
            if (recordComments == null) return null;
            CAPComments capComments = new CAPComments();
            List<CAPComment> capCommentLst = new List<CAPComment>();
            foreach (var recordComment in recordComments)
            {
                CAPComment capComment = new CAPComment()
                {
                    action = CommonHelper.ToGovXmlAction(recordComment.Action),
                    Comments = recordComment.Comments,
                    Date = recordComment.Date,
                    IdentifierDisplay = recordComment.Display,
                    ShowOnInspection = BoolHelper.ToBoolString(recordComment.ShowOnInspection, BoolHelper.BoolStringType.YOrN),
                    UserID = recordComment.UserId,
                    Keys = KeysHelper.CreateXMLKeys(recordComment.Id)
                };
                capCommentLst.Add(capComment);
            }

            capComments.comment = capCommentLst.ToArray();
            return capComments;
        }

        public RecordsResponse GetClientRecords(GetCAPsResponse xmlObj, bool ignoreCoordinatesSearch)
        {
            RecordsResponse results = new RecordsResponse();

            if (xmlObj.system != null)
            {
                //set page information
                results.PageInfo = CommonHelper.GetPaginationFromSystem(xmlObj.system);
                //results.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
            }

            if (xmlObj.caps != null
                && xmlObj.caps.cap != null
                && xmlObj.caps.cap.Length > 0)
            {
                results.Records = new List<RecordModel>();

                foreach (var record in xmlObj.caps.cap)
                {
                    /*
                     * No need to return the POS records.
                     * POS record is created in order to handle the payment.
                     * 
                     * For POS records, they have a characteristic that is the record type of them starts with an underline charactor ('_').
                     * 
                    //*/
                    if (record != null
                        && record.type != null
                        && record.type.keys != null)
                    {
                        string recordTypeId = record.type.keys.ToStringKeys();

                        if (!String.IsNullOrEmpty(recordTypeId)
                             && recordTypeId.StartsWith("_"))
                        {
                            continue;
                        }
                    }

                    results.Records.Add(ToClientRecord(record));
                }

                if (!ignoreCoordinatesSearch && _autoCorrectCoordinates)
                {
                    SetCoordinates(results.Records);
                }
            }

            if (results.Records != null)
            {
                /*
                 * 
                 * Let the results by default in descending order, that is from new to old.
                //*/
                results.Records = results.Records.OrderByDescending(record => record.OpenDate).ToList();
            }

            return results;
        }

        public void ToGovXmlFromCriteria(GetCAPs getRecords, RecordCriteria criteria, List<string> elements)
        {
            if (elements != null && elements.Count > 0)
            {
                getRecords.returnElements = new returnElements();
                getRecords.returnElements.returnElement = elements.ToArray();
            }

            if (!IsBizVersion705(_bizServerVersion))
            {
                getRecords.SortOrder = "OpenDate";
            }

            //RecordIds and Display logic
            //if there are record ids exist, the ignore the display criteria
            if (criteria.RecordIds != null && criteria.RecordIds.Count > 0)
            {
                getRecords.capIds = new CAPIds();
                getRecords.capIds.capId = new CAPId[criteria.RecordIds.Count];
                for (int i = 0; i < criteria.RecordIds.Count; i++)
                {
                    getRecords.capIds.capId[i] = new CAPId();
                    getRecords.capIds.capId[i].keys = KeysHelper.CreateXMLKeys(criteria.RecordIds[i]);
                }
            }
            else if (!string.IsNullOrWhiteSpace(criteria.Display))
            {
                getRecords.capIds = new CAPIds();
                getRecords.capIds.capId = new CAPId[1];
                getRecords.capIds.capId[0] = new CAPId();
                getRecords.capIds.capId[0].val = criteria.Display;
            }

            if (criteria.Displays != null && criteria.Displays.Count > 0)
            {
                getRecords.capIds = new CAPIds();
                getRecords.capIds.capId = new CAPId[criteria.Displays.Count];
                for (int i = 0; i < criteria.Displays.Count; i++)
                {
                    getRecords.capIds.capId[i] = new CAPId();
                    getRecords.capIds.capId[i].val = criteria.Displays[i];
                }
            }

            //record type
            ConvertStandartIds<CAPTypeIds, CAPTypeId>(criteria.RecordTypeIds,
             (o) => getRecords.capTypeIds = o,
             (o) => getRecords.capTypeIds.capTypeId = o,
             (o, val) => o.keys = KeysHelper.CreateXMLKeys(val));

            //record status -- CF-1102 rollback logic; pass filter to GovXML directly in case GovXML may enhance
            // GovXML does not support multiple values even though syntax is compatible with multiple values
            // so let GovXML to filter on status only when 1 value to filter
            // do in memeory filter in case of multiple values
            if (criteria.RecordStatusIds != null)  // && criteria.RecordStatusIds.Count == 1
            {
                ConvertStandartIds<CAPStatuses, CAPStatus>(criteria.RecordStatusIds,
                    (o) => getRecords.capStatuses = o,
                    (o) => getRecords.capStatuses.capStatus = o,
                    (o, val) => o.keys = KeysHelper.CreateXMLKeys(val));
            }

            //InspectionDistrictIds
            ConvertStandartIds<InspectionDistricts, InspectionDistrict>(criteria.InspectionDistrictIds,
                (o) => getRecords.inspectionDistricts = o,
                (o) => getRecords.inspectionDistricts.inspectionDistrict = o,
                (o, val) => o.keys = KeysHelper.CreateXMLKeys(val));

            //parcel ids
            //ConvertStandartIds<ParcelIds, ParcelId>(criteria.ParcelIds,
            //    (o) => getRecords.parcelIds = o,
            //    (o) => getRecords.parcelIds.parcelId = o,
            //    (o, val) => o.keys = KeysHelper.CreateXMLKeys(val));
            if (!String.IsNullOrEmpty(criteria.ParcelNumber))
            {
                getRecords.parcelId = new ParcelId();
                getRecords.parcelId.val = criteria.ParcelNumber + "%";
            }

            //Inspection Schedule Range
            getRecords.dateRange = GetDateRange(criteria.InspectionScheduledDateFrom, criteria.InspectionScheduledDateTo);

            //Record Schedule Range
            DateRange recordRange = GetDateRange(criteria.RecordScheduledDateFrom, criteria.RecordScheduledDateTo);
            if (recordRange != null)
            {
                getRecords.scheduleDate = new DateRanges();
                getRecords.scheduleDate.dateRange = new DateRange[1];
                getRecords.scheduleDate.dateRange[0] = recordRange;
            }

            getRecords.OpenDate = GetDateRange(criteria.OpenedDateFrom, criteria.OpenedDateTo);

            //Inspection Type Ids 
            ConvertStandartIds<InspectionTypes, InspectionType>(criteria.InspectionTypeIds,
                (o) => getRecords.inspectionTypes = o,
                (o) => getRecords.inspectionTypes.inspectionType = o,
                (o, val) => o.keys = KeysHelper.CreateXMLKeys(val));

            //Inspector Ids
            ConvertStandartIds<Inspectors, Accela.Automation.GovXmlClient.Model.Inspector>(criteria.InspectorIds,
                (o) => getRecords.inspectors = o,
                (o) => getRecords.inspectors.inspector = o,
                (o, val) => o.keys = KeysHelper.CreateXMLKeys(val));

            //keyword
            getRecords.keyword = criteria.Keyword;

            //ParentRecordId
            if (!string.IsNullOrWhiteSpace(criteria.ParentRecordId))
            {
                getRecords.parentCAPId = new CAPId() { keys = KeysHelper.CreateXMLKeys(criteria.ParentRecordId) };
            }

            //PartialRecordId
            if (!string.IsNullOrWhiteSpace(criteria.PartialRecordId))
            {
                getRecords.partialCAPId = new CAPId() { keys = KeysHelper.CreateXMLKeys(criteria.PartialRecordId) };
            }

            //SubsidiaryRecordId 
            if (!string.IsNullOrWhiteSpace(criteria.SubsidiaryRecordId))
            {
                getRecords.subsidiaryCAPId = new CAPId() { keys = KeysHelper.CreateXMLKeys(criteria.SubsidiaryRecordId) };
            }

            //Module type
            if (!string.IsNullOrWhiteSpace(criteria.moduleType))
            {
                getRecords.type = criteria.moduleType;
            }
            else
            {
                getRecords.type = "Permit";
            }

            //UseCachedRecords
            getRecords.useCachedCAPs = criteria.UseCachedRecords;

            //WithOpenInspectionsOnly 
            if (!string.IsNullOrWhiteSpace(criteria.WithOpenInspectionsOnly))
            {
                try
                {
                    getRecords.withOpenInspectionsOnly = bool.Parse(criteria.WithOpenInspectionsOnly);
                }
                catch { }
            }

            //AssetIds 
            ConvertStandartIds<AssetIds, AssetId>(criteria.AssetIds,
                (o) => getRecords.AssetIds = o,
                (o) => getRecords.AssetIds.assetId = o,
                (o, val) => o.keys = KeysHelper.CreateXMLKeys(val));

            //MaxRecordsPerAssetId
            getRecords.MaxRecordsPerAssetId = criteria.MaxRecordsPerAssetId;

            //Return elements.
            if (criteria.ReturnElements != null && criteria.ReturnElements.Count > 0)
            {
                getRecords.returnElements = new returnElements();
                getRecords.returnElements.returnElement = criteria.ReturnElements.ToArray();
            }

            // Address
            if (criteria.Address != null)
            {
                getRecords.detailAddress = new DetailAddress();
                getRecords.detailAddress.houseNumber = criteria.Address.HouseNumber;
                getRecords.detailAddress.streetName = criteria.Address.StreetName;
                getRecords.detailAddress.city = criteria.Address.City;
                getRecords.detailAddress.state = criteria.Address.State;
                getRecords.detailAddress.postalCode = criteria.Address.ZipCode;
                getRecords.detailAddress.streetDirection = criteria.Address.StreetDirection;
            }

            // Contact
            if (criteria.Contact != null)
            {
                getRecords.contact = new Contact();
                getRecords.contact.person = new Person();

                getRecords.contact.person.givenName = criteria.Contact.FirstName;
                getRecords.contact.person.familyName = criteria.Contact.LastName;

                if (!string.IsNullOrWhiteSpace(criteria.Contact.MiddleName))
                {
                    var middleNames = criteria.Contact.MiddleName.Split(' ');
                    getRecords.contact.person.middleNames = new MiddleNames();
                    getRecords.contact.person.middleNames.String = middleNames;
                }
            }

            // Staff
            if (criteria.StaffIds != null && criteria.StaffIds.Count > 0)
            {
                getRecords.Departments = new Departments();
                getRecords.Departments.Department = new Department[criteria.StaffIds.Count];
                for (int i = 0; i < criteria.StaffIds.Count; i++)
                {
                    getRecords.Departments.Department[i] = new Department();
                    getRecords.Departments.Department[i].Staff = new Staff();
                    getRecords.Departments.Department[i].Staff.StaffPerson = new StaffPerson[1];
                    getRecords.Departments.Department[i].Staff.StaffPerson[0] = new StaffPerson();
                    getRecords.Departments.Department[i].Staff.StaffPerson[0].keys = KeysHelper.CreateXMLKeys(criteria.StaffIds[i]);
                }
            }

            if (!string.IsNullOrWhiteSpace(criteria.Module))
            {
                getRecords.CAP = new CAPCondition();
                getRecords.CAP.Module = criteria.Module;
            }
        }

        private static DateRange GetDateRange(string from, string to)
        {
            DateRange range = null;
            if (!string.IsNullOrWhiteSpace(from) || !string.IsNullOrWhiteSpace(to))
            {
                range = new DateRange();

                int intFrom;
                if (int.TryParse(from, out intFrom))
                {
                    if (!string.IsNullOrWhiteSpace(from))
                    {
                        range.from = DateTimeFormat.ToMetaDateString(DateTime.UtcNow.AddDays(0 - int.Parse(from)));
                    }
                    if (!string.IsNullOrEmpty(to))
                    {
                        range.to = DateTimeFormat.ToMetaDateString(DateTime.UtcNow.AddDays(int.Parse(to)));
                    }
                }
                else
                {
                    range.from = from;
                    range.to = to;
                }
            }

            return range;
        }

        public static void ConvertStandartIds<T, M>(List<string> inputs, a1<T> firstVal, a2<M> secordVal, a3<M> keyVal)
            where T : class,new()
            where M : class,new()
        {
            if (inputs != null && inputs.Count > 0)
            {
                firstVal(new T());
                M[] list = secordVal(new M[inputs.Count]);

                for (int i = 0; i < inputs.Count; i++)
                {
                    list[i] = new M();
                    keyVal(list[i], inputs[i]);
                }
            }
        }

        public CAP ToXMLRecord(RecordModel clientRecord, ContextUser user)
        {
            CAP xmlRecord = new CAP();
            xmlRecord.keys = KeysHelper.CreateXMLKeys(clientRecord.Identifier);
            xmlRecord.identifierDisplay = clientRecord.Display;
            xmlRecord.description = clientRecord.Description;
            if (clientRecord.RecordType != null)
            {
                xmlRecord.type = new Automation.GovXmlClient.Model.Type();
                xmlRecord.type.keys = KeysHelper.CreateXMLKeys(clientRecord.RecordType.Identifier);
            }
            if (clientRecord.RecordStatus != null)
            {
                xmlRecord.status = new Status();
                xmlRecord.status.keys = KeysHelper.CreateXMLKeys(clientRecord.RecordStatus.Identifier);
            }

            xmlRecord.name = clientRecord.Name;
            xmlRecord.AssignedDate = clientRecord.AssignDate;
            xmlRecord.scheduleDate = clientRecord.ScheduleDate;
            xmlRecord.scheduleTime = clientRecord.ScheduleTime;
            xmlRecord.fileDate = clientRecord.OpenDate;

            if (!string.IsNullOrWhiteSpace(clientRecord.Priority))
            {
                xmlRecord.CAPDetail = new CAPDetail();
                xmlRecord.CAPDetail.Priority = clientRecord.Priority;
            }

            xmlRecord.Module = clientRecord.Module;
            xmlRecord.Department = ToXMLDepartment(clientRecord.Department);
            xmlRecord.StaffPerson = ToXMLStaffPerson(clientRecord.StaffPerson);
            //Addresses
            xmlRecord.addresses = AddressHelper.ToXmlAddresses(clientRecord.Addresses);

            //Conditions 
            xmlRecord.conditions = ConditionHelper.ToXMLConditions(clientRecord.Conditions);

            //contacts 
            ContactHelper contactHelper = new ContactHelper(_bizServerVersion);
            xmlRecord.contacts = contactHelper.ToXMLContacts(clientRecord.Contacts);

            //additional information and additional table information
            xmlRecord.additionalInformation = ToXMLAdditional(clientRecord);

            //parcels
            //xmlRecord.parcels = ParcelHelper.ToXMLParcels(clientRecord.Parcels);

            return xmlRecord;
        }

        private static AdditionalInformation ToXMLAdditional(RecordModel clientRecord)
        {
            AdditionalInformation result = null;

            List<AdditionalInformationGroup> xmlASI = ASIHelper.ToXMLAdditionalGroups(clientRecord.AdditionalInfo);
            List<AdditionalInformationGroup> xmlASIT = ASITHelper.BuildAsiAsit4Update(clientRecord.AdditionalTableInfo);

            if (xmlASI != null)
            {
                result = new AdditionalInformation();
                if (xmlASIT != null)
                {
                    result.additionalInformationGroup = xmlASI.Union(xmlASIT).ToArray();
                }
                else
                {
                    result.additionalInformationGroup = xmlASI.ToArray();
                }
            }

            return result;
        }

        public RecordModel ToClientRecord(CAP xmlRecord)
        {
            RecordModel clientRecord = new RecordModel();
            clientRecord.Identifier = KeysHelper.ToStringKeys(xmlRecord.keys);
            clientRecord.Display = xmlRecord.identifierDisplay;
            clientRecord.Description = xmlRecord.description;
            if (xmlRecord.type != null)
            {
                clientRecord.RecordType = new RecordTypeModel();
                clientRecord.RecordType.Identifier = KeysHelper.ToStringKeys(xmlRecord.type.keys);
                clientRecord.RecordType.Display = xmlRecord.type.identifierDisplay;
            }

            if (xmlRecord.status != null)
            {
                clientRecord.RecordStatus = new RecordStatusModel();
                clientRecord.RecordStatus.Identifier = KeysHelper.ToStringKeys(xmlRecord.status.keys);
                clientRecord.RecordStatus.Display = xmlRecord.status.IdentifierDisplay;
                if (string.IsNullOrWhiteSpace(clientRecord.RecordStatus.Display))
                {
                    clientRecord.RecordStatus.Display = xmlRecord.status.val;
                }
            }

            if (xmlRecord.CAPDetail != null)
            {
                clientRecord.AssignToInfo = new AssignToInfo();
                clientRecord.AssignToInfo.TotalJobCost = xmlRecord.CAPDetail.TotalJobCost;
                clientRecord.AssignToInfo.AssignDate = xmlRecord.CAPDetail.AsgnDate;
                clientRecord.AssignToInfo.AssignStaff = xmlRecord.CAPDetail.AsgnStaff;
                clientRecord.AssignToInfo.AssignDepartment = xmlRecord.CAPDetail.AsgnDept;
                clientRecord.AssignToInfo.ScheduledDate = xmlRecord.CAPDetail.ScheduledDate;
                clientRecord.AssignToInfo.CompleteDate = xmlRecord.CAPDetail.CompleteDate;
                clientRecord.AssignToInfo.Priority = xmlRecord.CAPDetail.Priority;
            }

            clientRecord.Name = xmlRecord.name;
            clientRecord.AssignDate = xmlRecord.AssignedDate;
            clientRecord.ScheduleDate = xmlRecord.scheduleDate;
            clientRecord.ScheduleTime = xmlRecord.scheduleTime;
            clientRecord.OpenDate = xmlRecord.fileDate;
            clientRecord.Module = xmlRecord.Module;
            clientRecord.Department = ToClientDepartment(xmlRecord.Department);
            clientRecord.StaffPerson = ToClientStaffPerson(xmlRecord.StaffPerson);
            if (xmlRecord.CAPDetail != null)
            {
                clientRecord.Priority = xmlRecord.CAPDetail.Priority;
            }


            //Addresses
            if (xmlRecord.addresses != null && xmlRecord.addresses.detailAddress != null)
            {
                clientRecord.Addresses = new List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel>();
                foreach (var item in xmlRecord.addresses.detailAddress)
                {
                    clientRecord.Addresses.Add(AddressHelper.ToClientAddress(item));
                }
            }
            else if (xmlRecord.compactAddresses != null && xmlRecord.compactAddresses.compactAddress != null)
            {
                clientRecord.Addresses = new List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel>();
                foreach (var item in xmlRecord.compactAddresses.compactAddress)
                {
                    clientRecord.Addresses.Add(AddressHelper.ToClientAddress(item));
                }
            }

            //Conditions 
            if (xmlRecord.conditions != null && xmlRecord.conditions.condition != null)
            {
                clientRecord.Conditions = new List<ConditionModel>();
                foreach (var item in xmlRecord.conditions.condition)
                {
                    clientRecord.Conditions.Add(ConditionHelper.ToClientCondition(item));
                }
            }

            //contacts and license
            if (xmlRecord.contacts != null && xmlRecord.contacts.contact != null)
            {
                ContactHelper contactHelper = new ContactHelper(_bizServerVersion);

                clientRecord.Contacts = new List<ContactModel>();
                foreach (var item in xmlRecord.contacts.contact)
                {
                    var clientContact = contactHelper.ToClientContact(item);
                    clientRecord.Contacts.Add(clientContact);
                }
            }

            if (xmlRecord.additionalInformation != null)
            {
                clientRecord.AdditionalInfo = ASIHelper.ToClientAdditionGroups(xmlRecord.additionalInformation);
                clientRecord.AdditionalTableInfo = ASITHelper.GetAsiAsit(xmlRecord.additionalInformation);
            }

            //parcels
            if (xmlRecord.parcels != null && xmlRecord.parcels.parcel != null)
            {
                ParcelHelper parcelHelper = new ParcelHelper(_bizServerVersion);

                clientRecord.Parcels = new List<ParcelModel>();
                foreach (var item in xmlRecord.parcels.parcel)
                {
                    clientRecord.Parcels.Add(parcelHelper.ToClientParcel(item));
                }
            }

            //parts
            if (xmlRecord.Parts != null && xmlRecord.Parts.Part != null)
            {
                clientRecord.Parts = new List<PartModel>();
                foreach (var item in xmlRecord.Parts.Part)
                {
                    clientRecord.Parts.Add(PartHelper.ToClientPart(item));
                }
            }

            // Costs
            if (xmlRecord.CostItems != null && xmlRecord.CostItems.CostItem != null)
            {
                clientRecord.Costs = new List<CostModel>();
                foreach (var item in xmlRecord.CostItems.CostItem)
                {
                    clientRecord.Costs.Add(CostHelper.ToClientCost(item));
                }
            }

            // Related relations.
            if (xmlRecord.capRelations != null && xmlRecord.capRelations.capRelation != null)
            {
                clientRecord.RelatedRecords = new List<RelatedRecordModel>();

                foreach (var item in xmlRecord.capRelations.capRelation)
                {
                    clientRecord.RelatedRecords.Add(RelatedRecordHelper.ToClientRelatedRecord(item));
                }
            }

            // Assets.
            if (xmlRecord.Assets != null && xmlRecord.Assets.asset != null)
            {
                clientRecord.Assets = new List<AssetModel>();
                foreach (var item in xmlRecord.Assets.asset)
                {
                    clientRecord.Assets.Add(AssetHelper.ToClientAsset(item));
                }
            }

            // Comments
            if (xmlRecord.comments != null && xmlRecord.comments.comment != null)
            {
                clientRecord.RecordComments = new List<RecordCommentModel>();
                foreach (var item in xmlRecord.comments.comment)
                {
                    clientRecord.RecordComments.Add(ToClientRecordComment(item));
                }
            }

            // Work order task
            clientRecord.WorkOrderTasks = WorkOrderTaskHelper.ToClientWorkOrderTasks(xmlRecord.WorkOrderTasks);

            if (xmlRecord.GISObjects != null && xmlRecord.GISObjects.GISObject != null)
            {
                clientRecord.GISObjects = new List<GISObjectModel>();
                foreach (var item in xmlRecord.GISObjects.GISObject)
                {
                    if (item != null)
                    {
                        clientRecord.GISObjects.Add(ToClientGISObject(item));
                    }
                }
            }

            return clientRecord;
        }

        private static RecordCommentModel ToClientRecordComment(CAPComment xmlComment)
        {
            if (xmlComment != null)
            {
                RecordCommentModel clientRecordComment = new RecordCommentModel()
                {
                    Id = KeysHelper.ToStringKeys(xmlComment.Keys),
                    Display = xmlComment.IdentifierDisplay,
                    UserId = xmlComment.UserID,
                    Action = xmlComment.action,
                    Date = xmlComment.Date,
                    ShowOnInspection = BoolHelper.GetBooleanByString(xmlComment.ShowOnInspection),
                    Comments = xmlComment.Comments
                };

                return clientRecordComment;
            }

            return null;
        }

        public static DepartmentModel ToClientDepartment(Department xmlObj)
        {
            DepartmentModel clientObj = null;
            if (xmlObj != null)
            {
                clientObj = new DepartmentModel();

                clientObj.Identifier = KeysHelper.ToStringKeys(xmlObj.keys);
                clientObj.Display = xmlObj.identifierDisplay;

                if (xmlObj.Staff != null && xmlObj.Staff.StaffPerson != null)
                {
                    clientObj.Inspectors = new List<InspectorModel>();
                    foreach (var staff in xmlObj.Staff.StaffPerson)
                    {
                        InspectorModel model = new InspectorModel();
                        model.Identifier = KeysHelper.ToStringKeys(staff.keys);
                        model.Name = staff.identifierDisplay;
                        clientObj.Inspectors.Add(model);
                    }
                }
            }

            return clientObj;
        }

        public static Department ToXMLDepartment(DepartmentModel clientObj)
        {
            Department xmlObj = null;
            if (clientObj != null)
            {
                xmlObj = new Department();
                xmlObj.keys = KeysHelper.CreateXMLKeys(clientObj.Identifier);
                xmlObj.identifierDisplay = clientObj.Display;
                if (clientObj.Inspectors != null)
                {
                    xmlObj.Staff = new Staff();
                    var xmlStaffs = new List<StaffPerson>();
                    foreach (InspectorModel model in clientObj.Inspectors)
                    {
                        var xmlStaff = new StaffPerson();
                        xmlStaff.keys = KeysHelper.CreateXMLKeys(model.Identifier);
                        xmlStaff.identifierDisplay = model.Name;
                        xmlStaffs.Add(xmlStaff);
                    }

                    xmlObj.Staff.StaffPerson = xmlStaffs.ToArray();
                }
            }
            return xmlObj;
        }

        public static StaffPersonModel ToClientStaffPerson(StaffPerson xmlObj)
        {
            StaffPersonModel clientObj = null;
            if (xmlObj != null)
            {
                clientObj = new StaffPersonModel();
                clientObj.Identifier = KeysHelper.ToStringKeys(xmlObj.keys);
                clientObj.Display = xmlObj.identifierDisplay;
                clientObj.FirstName = xmlObj.firstName;
                clientObj.LastName = xmlObj.lastName;
                clientObj.AuditStatus = xmlObj.auditStatus;
                clientObj.ServiceProviderCode = xmlObj.serviceProviderCode;
                clientObj.AgencyCode = xmlObj.agencyCode;
                clientObj.BureauCode = xmlObj.bureauCode;
                clientObj.DivisionCode = xmlObj.divisionCode;
                clientObj.SectionCode = xmlObj.sectionCode;
                clientObj.GroupCode = xmlObj.groupCode;
                clientObj.OfficeCode = xmlObj.officeCode;
                clientObj.UserStatus = xmlObj.userStatus;
            }
            return clientObj;
        }

        public static StaffPerson ToXMLStaffPerson(StaffPersonModel clientObj)
        {
            StaffPerson xmlObj = null;
            if (clientObj != null)
            {
                xmlObj = new StaffPerson();
                xmlObj.keys = KeysHelper.CreateXMLKeys(clientObj.Identifier);
                xmlObj.identifierDisplay = clientObj.Display;
                xmlObj.firstName = clientObj.FirstName;
                xmlObj.lastName = clientObj.LastName;
                xmlObj.auditStatus = clientObj.AuditStatus;
                xmlObj.serviceProviderCode = clientObj.ServiceProviderCode;
                xmlObj.agencyCode = clientObj.AgencyCode;
                xmlObj.bureauCode = clientObj.BureauCode;
                xmlObj.divisionCode = clientObj.DivisionCode;
                xmlObj.sectionCode = clientObj.SectionCode;
                xmlObj.groupCode = clientObj.GroupCode;
                xmlObj.officeCode = clientObj.OfficeCode;
                xmlObj.userStatus = clientObj.UserStatus;
            }

            return xmlObj;
        }

        private static void SetCoordinates(List<RecordModel> targetRecords)
        {
            var watch = Reflection.Startwatch();

            try
            {
                if (targetRecords != null)
                {
                    var _coordinateRepository = IocContainer.Resolve<ICoordinateRepository>();

                    var strAddresses = new List<string>();
                    for (int i = 0; i < targetRecords.Count; i++)
                    {
                        var record = targetRecords[i];
                        if (record.Addresses != null)
                        {
                            for (int j = 0; j < record.Addresses.Count; j++)
                            {
                                var address = record.Addresses[j];

                                if (address != null && string.IsNullOrWhiteSpace(address.XCoordinate) && string.IsNullOrWhiteSpace(address.YCoordinate))
                                {
                                    string addressInfo = AddressHelper.GetClientGeoAddressStringBy(address);
                                    if (!string.IsNullOrWhiteSpace(addressInfo))
                                    {
                                        strAddresses.Add(addressInfo);
                                    }
                                }

                                //Check whether valid coordinate, if it's invalid coordinate, System will filter it.
                                if (!string.IsNullOrEmpty(address.XCoordinate) && !string.IsNullOrEmpty(address.YCoordinate))
                                {
                                    double x;
                                    double y;
                                    var validX = double.TryParse(address.XCoordinate, out x);
                                    var validY = double.TryParse(address.YCoordinate, out y);
                                    if (!validX || !validY)
                                    {
                                        address.XCoordinate = null;
                                        address.YCoordinate = null;
                                    }
                                    else if ((x == 0 && y == 0) || (Math.Abs(x) > 180) || (Math.Abs(y) > 90))
                                    {
                                        address.XCoordinate = null;
                                        address.YCoordinate = null;
                                    }
                                }
                            }
                        }
                    }

                    var geocodeAddresses = _coordinateRepository.GetCoordinates(strAddresses.ToArray());

                    if (geocodeAddresses != null && geocodeAddresses.Length > 0)
                    {
                        int position = 0;
                        for (int i = 0; i < targetRecords.Count; i++)
                        {
                            var record = targetRecords[i];
                            if (record.Addresses != null)
                            {
                                for (int j = 0; j < record.Addresses.Count; j++)
                                {
                                    AddressModel address = record.Addresses[j];
                                    if (address != null && string.IsNullOrWhiteSpace(address.XCoordinate) &&
                                        string.IsNullOrWhiteSpace(address.YCoordinate))
                                    {
                                        string addressInfo = AddressHelper.GetClientGeoAddressStringBy(address);
                                        if (!string.IsNullOrWhiteSpace(addressInfo))
                                        {
                                            if (position >= geocodeAddresses.Length)
                                            {
                                                return;
                                            }

                                            var geocodeAddress = geocodeAddresses[position];
                                            position++;
                                            if (geocodeAddress != null && !Double.IsNaN(geocodeAddress.LocationX) &&
                                                !Double.IsNaN(geocodeAddress.LocationY))
                                            {
                                                address.XCoordinate = geocodeAddress.LocationX.ToString();
                                                address.YCoordinate = geocodeAddress.LocationY.ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch), "Map SetCoordinates for Record");
        }

        private static GISObjectModel ToClientGISObject(GISObject gisObject)
        {
            if (gisObject != null)
            {
                return new GISObjectModel
                           {
                               Id = gisObject.Keys.ToStringKeys(),
                               GISLayerId =
                                   gisObject.GISLayerId != null && gisObject.GISLayerId.Keys != null &&
                                   gisObject.GISLayerId.Keys.key != null
                                       ? gisObject.GISLayerId.Keys.key[0]
                                       : null,
                               MapServiceId =
                                   gisObject.MapServerID.Keys != null && gisObject.MapServerID.Keys.key != null
                                       ? gisObject.MapServerID.Keys.key[0]
                                       : null,
                               Display = gisObject.IdentifierDisplay
                           };
            }

            return null;
        }

        public static GISObjects ToXMLGISObjects(List<GISObjectModel> clientObjs)
        {
            GISObjects retus = null;
            if (clientObjs != null)
            {
                var xmlContacts = new List<GISObject>();
                foreach (GISObjectModel item in clientObjs)
                {
                    GISObject xmlContact = ToGovXMLGISObject(item);
                    if (xmlContact != null)
                    {
                        xmlContacts.Add(xmlContact);
                    }
                }

                retus = new GISObjects();
                retus.GISObject = xmlContacts.ToArray();
            }

            return retus;
        }

        public static GISObject ToGovXMLGISObject(GISObjectModel gisObject)
        {
            GISObject retu = null;
            if (gisObject != null)
            {
                retu = new GISObject();
                retu.Keys = KeysHelper.CreateXMLKeys(gisObject.Id);
                retu.action = CommonHelper.ToGovXmlAction(gisObject.Action);
                if (retu.Keys == null)
                {
                    retu.Keys = new Keys();
                    retu.Keys.key = new string[2];
                    retu.Keys.key[0] = gisObject.GISLayerId;
                    retu.Keys.key[1] = gisObject.Display;
                }
                if (gisObject.Display != null)
                {
                    retu.IdentifierDisplay = gisObject.Display;
                }

                if (gisObject.GISLayerId != null)
                {
                    retu.GISLayerId = new GISLayerId();
                    retu.GISLayerId.Keys = new Keys();
                    retu.GISLayerId.Keys.key = new string[1];
                    retu.GISLayerId.Keys.key[0] = gisObject.GISLayerId;
                }

                if (gisObject.MapServiceId != null)
                {
                    retu.MapServerID = new MapServerID();
                    retu.MapServerID.Keys = new Keys();
                    retu.MapServerID.Keys.key = new string[1];
                    retu.MapServerID.Keys.key[0] = gisObject.MapServiceId;
                }
            }

            return retu;
        }

        public InitiateCAP ToXMLCreateRecord(RecordModel recordModel)
        {
            InitiateCAP initiateCAP = new InitiateCAP();
            initiateCAP.finalizeNow = "true";
            initiateCAP.ShortNotes = recordModel.ShortNotes;

            if (!string.IsNullOrEmpty(recordModel.TemplateName))
            {
                initiateCAP.TemplateName = recordModel.TemplateName;
                return initiateCAP;
            }

            RecordModel clientRecord = recordModel;
            if (clientRecord.RecordType != null)
            {
                initiateCAP.capTypeId = new CAPTypeId();
                initiateCAP.capTypeId.keys = KeysHelper.CreateXMLKeys(clientRecord.RecordType.Identifier);
            }

            initiateCAP.description = clientRecord.Description;

            if (clientRecord.RecordStatus != null)
            {
                initiateCAP.status = new Status();
                initiateCAP.status.keys = KeysHelper.CreateXMLKeys(clientRecord.RecordStatus.Identifier);
            }

            Addresses xmlAddresses = AddressHelper.ToXmlAddresses(clientRecord.Addresses);
            if (xmlAddresses != null)
            {
                initiateCAP.Addresses = new DetailAddresses();
                initiateCAP.Addresses.detailAddress = xmlAddresses.detailAddress;
            }

            ContactHelper contactHelper = new ContactHelper(_bizServerVersion);
            initiateCAP.contacts = contactHelper.ToXMLContacts(clientRecord.Contacts);
            initiateCAP.parcelIds = ParcelHelper.ToGovXmlIds(clientRecord.Parcels, false);
            initiateCAP.comments = ToGovXmlComments(clientRecord.RecordComments);
            initiateCAP.Department = ToXMLDepartment(clientRecord.Department);
            initiateCAP.StaffPerson = ToXMLStaffPerson(clientRecord.StaffPerson);
            initiateCAP.AssignedDate = clientRecord.AssignDate;
            initiateCAP.scheduleDate = clientRecord.ScheduleDate;
            initiateCAP.scheduleTime = clientRecord.ScheduleTime;
            initiateCAP.fileDate = clientRecord.OpenDate;

            if (!string.IsNullOrWhiteSpace(clientRecord.Priority))
            {
                initiateCAP.CAPDetail = new CAPDetail();
                initiateCAP.CAPDetail.Priority = clientRecord.Priority;
            }

            initiateCAP.additionalInformation = ToXMLAdditional(clientRecord);

            initiateCAP.GISObjects = ToXMLGISObjects(clientRecord.GISObjects);

            initiateCAP.CostItems = ToXmlCostsObjects(clientRecord.Costs);
            initiateCAP.Parts = ToXmlPartsObjects(clientRecord.Parts);
            initiateCAP.WorkOrderTasks = ToXmlWorkOrderTaskObjects(clientRecord.WorkOrderTasks);
            initiateCAP.Assets = ToXmlAssetObjects(clientRecord.Assets);

            return initiateCAP;
        }

        private static Assets ToXmlAssetObjects(List<AssetModel> assetModels)
        {
            Assets assets = null;
            if (assetModels != null)
            {
                var xmlAssets = new List<Asset>();
                foreach (AssetModel item in assetModels)
                {
                    Asset xmlAsset = AssetHelper.ToCovXmlAsset(item);
                    if (xmlAsset != null)
                    {
                        xmlAssets.Add(xmlAsset);
                    }
                }

                assets = new Assets();
                assets.asset = xmlAssets.ToArray();
            }
            return assets;
        }

        public UpdateCAP ToXmlUpdateRecord(RecordModel recordModel)
        {
            UpdateCAP updateCAP = new UpdateCAP();

            RecordModel clientRecord = recordModel;

            if (clientRecord.RecordType != null)
            {
                updateCAP.type = new Accela.Automation.GovXmlClient.Model.Type();
                updateCAP.type.keys = KeysHelper.CreateXMLKeys(clientRecord.RecordType.Identifier);
            }

            if (clientRecord.Identifier != null)
            {
                updateCAP.capId = new CAPId();
                updateCAP.capId.keys = KeysHelper.CreateXMLKeys(clientRecord.Identifier);
            }

            if (clientRecord.RecordStatus != null)
            {
                updateCAP.status = new Status();
                updateCAP.status.keys = KeysHelper.CreateXMLKeys(clientRecord.RecordStatus.Identifier);
            }

            updateCAP.description = clientRecord.Description;

            updateCAP.addresses = AddressHelper.ToXmlAddresses(clientRecord.Addresses);

            ContactHelper contactHelper = new ContactHelper(_bizServerVersion);
            updateCAP.contacts = contactHelper.ToXMLContacts(clientRecord.Contacts);
            updateCAP.parcelIds = ParcelHelper.ToGovXmlIds(clientRecord.Parcels, true);
            updateCAP.conditions = ConditionHelper.ToXMLConditions(clientRecord.Conditions);
            updateCAP.comments = ToGovXmlComments(clientRecord.RecordComments);

            updateCAP.Department = ToXMLDepartment(clientRecord.Department);
            updateCAP.StaffPerson = ToXMLStaffPerson(clientRecord.StaffPerson);
            updateCAP.AssignedDate = clientRecord.AssignDate;
            updateCAP.scheduleDate = clientRecord.ScheduleDate;
            updateCAP.scheduleTime = clientRecord.ScheduleTime;
            updateCAP.fileDate = clientRecord.OpenDate;

            if (!string.IsNullOrWhiteSpace(clientRecord.Priority))
            {
                updateCAP.CAPDetail = new CAPDetail();
                updateCAP.CAPDetail.Priority = clientRecord.Priority;
            }

            if ( clientRecord.AssignToInfo != null)
            {
                if (updateCAP.CAPDetail==null)
                {
                    updateCAP.CAPDetail = new CAPDetail();
                }
                updateCAP.CAPDetail.AsgnDate = clientRecord.AssignToInfo.AssignDate;
                updateCAP.CAPDetail.AsgnDept = clientRecord.AssignToInfo.AssignDepartment;
                updateCAP.CAPDetail.AsgnStaff = clientRecord.AssignToInfo.AssignStaff;
                updateCAP.CAPDetail.CompleteDate = clientRecord.AssignToInfo.CompleteDate;
                updateCAP.CAPDetail.ScheduledDate = clientRecord.AssignToInfo.ScheduledDate;
                updateCAP.CAPDetail.TotalJobCost = clientRecord.AssignToInfo.TotalJobCost;
            }

            updateCAP.additionalInformation = ToXMLAdditional(clientRecord);

            updateCAP.Assets = ToXmlAssetObjects(clientRecord.Assets);

            updateCAP.WorkOrderTasks = ToXmlWorkOrderTaskObjects(clientRecord.WorkOrderTasks);

            updateCAP.CostItems = ToXmlCostsObjects(clientRecord.Costs);

            updateCAP.Parts = ToXmlPartsObjects(clientRecord.Parts);

            return updateCAP;
        }

        public static RecordPrioritiesResponse ToClientRecordPriorities(GetStandardChoicesResponse getStandardChoicesResponse)
        {
            var result = new RecordPrioritiesResponse();

            if (getStandardChoicesResponse != null
                && getStandardChoicesResponse.standardChoices != null
                && getStandardChoicesResponse.standardChoices.AMOEnumeration != null
                && getStandardChoicesResponse.standardChoices.AMOEnumeration.Length > 0)
            {
                result.Priorities = new List<RecordPriorityModel>();

                foreach (var entry in getStandardChoicesResponse.standardChoices.AMOEnumeration)
                {
                    result.Priorities.Add(new RecordPriorityModel { Id = entry.keys.ToStringKeys(), Display = entry.identifierDisplay });
                }
            }

            return result;
        }

        public static RecordStatusesResponse ToClientRecordDispositions(GetDispositionsResponse getDispositionsResponse)
        {
            var results = new RecordStatusesResponse();

            if (getDispositionsResponse.system != null)
            {
                results.Events = CommonHelper.GetClientEventMessage(getDispositionsResponse.system.eventMessages);
            }

            results.RecordStatuses = new List<RecordStatusModel>();

            if (getDispositionsResponse.dispositions != null
                && getDispositionsResponse.dispositions.disposition != null
                && getDispositionsResponse.dispositions.disposition.Length > 0)
            {
                foreach (var recordDisposition in getDispositionsResponse.dispositions.disposition)
                {
                    RecordStatusModel clientStatus = new RecordStatusModel();
                    clientStatus.Identifier = KeysHelper.ToStringKeys(recordDisposition.keys);
                    clientStatus.Display = recordDisposition.identifierDisplay;
                    results.RecordStatuses.Add(clientStatus);
                }
            }

            return results;
        }
    }
}
