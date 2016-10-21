using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class AssetHelper : GovXmlHelperBase
    {
        public static void ToGovXmlFromCriteria(GetAssets getAssets, AssetCriteria criteria, List<string> elements)
        {
            if (elements != null && elements.Count > 0)
            {
                getAssets.ReturnElements = new returnElements();
                getAssets.ReturnElements.returnElement = elements.ToArray();
            }

            //AssetIds and Display logic
            //if there are asset ids exist, the ignore the display criteria
            if (criteria.AssetIds != null && criteria.AssetIds.Count > 0)
            {
                getAssets.assetIds = new AssetIds();
                getAssets.assetIds.assetId = new AssetId[criteria.AssetIds.Count];
                for (int i = 0; i < criteria.AssetIds.Count; i++)
                {
                    getAssets.assetIds.assetId[i] = new AssetId();
                    getAssets.assetIds.assetId[i].keys = KeysHelper.CreateXMLKeys(criteria.AssetIds[i]);
                }
            }
            else if (!string.IsNullOrWhiteSpace(criteria.Display))
            {
                getAssets.assetIds = new AssetIds();
                getAssets.assetIds.assetId = new AssetId[1];
                getAssets.assetIds.assetId[0] = new AssetId();
                getAssets.assetIds.assetId[0].identifierDisplay = criteria.Display;
            }

            //query criteria about asset type 
            if (criteria.AssetTypeIds != null && criteria.AssetTypeIds.Count > 0)
            {
                getAssets.assetTypes = new AssetTypes();
                getAssets.assetTypes.assetType = new AssetType[criteria.AssetTypeIds.Count];
                for (int i = 0; i < criteria.AssetTypeIds.Count; i++)
                {
                    getAssets.assetTypes.assetType[i] = new AssetType();
                    getAssets.assetTypes.assetType[i].keys = KeysHelper.CreateXMLKeys(criteria.AssetTypeIds[i]);
                }
            }

            //query criteria about asset status date range
            DateRange statusDateRange = Utility.GetDataRange(criteria.StatusDateFrom, criteria.StatusDateTo);
            if (statusDateRange != null)
            {
                getAssets.statusDatesRange = statusDateRange;
            }

            //query criteria about asset date of service range
            DateRange dateOfServiceRange = Utility.GetDataRange(criteria.DateOfServiceFrom, criteria.DateOfServiceTo);
            if (dateOfServiceRange != null)
            {
                getAssets.dateOfServiceRange = dateOfServiceRange;
            }

            //query criteria about asset current value
            if (!string.IsNullOrWhiteSpace(criteria.CurrentValueFrom) || !string.IsNullOrWhiteSpace(criteria.CurrentValueTo))
            {
                getAssets.currentValueRange = new ValueRange()
                {
                    startingValue = criteria.CurrentValueFrom,
                    endingValue = criteria.CurrentValueTo
                };
            }

            //query criteria about asset type 
            if (criteria.AssetStatus != null)
            {
                getAssets.status = new Status();
                getAssets.status.keys = KeysHelper.CreateXMLKeys(criteria.AssetStatus);
            }

            //query creiteria about asset description
            if (!string.IsNullOrWhiteSpace(criteria.Description))
            {
                getAssets.description = criteria.Description;
            }

            //query creiteria about asset comments
            if (!string.IsNullOrWhiteSpace(criteria.Comments))
            {
                getAssets.comments = criteria.Comments;
            }

            //query creiteria about detail address.
            if (criteria.DetailAddress != null)
            {             
                getAssets.DetailAddress = new Accela.Automation.GovXmlClient.Model.DetailAddress();
                getAssets.DetailAddress.houseNumber = criteria.DetailAddress.HouseNumber;
                getAssets.DetailAddress.streetName = criteria.DetailAddress.StreetName;
                getAssets.DetailAddress.city = criteria.DetailAddress.City;
                getAssets.DetailAddress.state = criteria.DetailAddress.State;
                getAssets.DetailAddress.postalCode = criteria.DetailAddress.ZipCode;
            }

            if (!String.IsNullOrEmpty(criteria.Name))
            {
                getAssets.asset = new Asset();
                getAssets.asset.Name = criteria.Name;
            }
        }

        public static void ToGovXmlFromAssetSearchCriteria(GetAssets getAssets, AssetSearchCriteria criteria, List<string> elements)
        {
            getAssets.recordStatus = "Active";

            if (elements != null && elements.Count > 0)
            {
                getAssets.ReturnElements = new returnElements();
                getAssets.ReturnElements.returnElement = elements.ToArray();
            }

            if (criteria.GisObjects != null && criteria.GisObjects.Count > 0)
            {
                getAssets.GisObjects = new GISObjects();
                getAssets.GisObjects.GISObject = new GISObject[criteria.GisObjects.Count];
                for (int i = 0; i < criteria.GisObjects.Count; i++)
                {
                    var criteriaGisObj = criteria.GisObjects[i];

                    getAssets.GisObjects.GISObject[i] = new GISObject();

                    if (!string.IsNullOrWhiteSpace(criteriaGisObj.ID))
                    {
                        getAssets.GisObjects.GISObject[i].Keys = KeysHelper.CreateXMLKeys(criteriaGisObj.ID);
                    }

                    if (!string.IsNullOrWhiteSpace(criteriaGisObj.MapService))
                    {
                        getAssets.GisObjects.GISObject[i].MapServerID = new MapServerID();
                        getAssets.GisObjects.GISObject[i].MapServerID.Keys = KeysHelper.CreateXMLKeys(criteriaGisObj.MapService);
                    }

                    if (!string.IsNullOrWhiteSpace(criteriaGisObj.GISLayer))
                    {
                        getAssets.GisObjects.GISObject[i].GISLayerId = new GISLayerId();
                        getAssets.GisObjects.GISObject[i].GISLayerId.Keys = KeysHelper.CreateXMLKeys(criteriaGisObj.GISLayer);
                    }
                }
            }
        }

        public static AssetsResponse GetClientAssets(GetAssetsResponse xmlObj, bool ignoreCoordinatesSearch)
        {
            AssetsResponse results = new AssetsResponse();

            if (xmlObj.system != null)
            {
                //set pageinformation
                results.PageInfo = CommonHelper.GetPaginationFromSystem(xmlObj.system);
                results.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
            }

            if (xmlObj.assets != null
                && xmlObj.assets.asset != null
                && xmlObj.assets.asset.Length > 0)
            {
                results.Assets = new List<AssetModel>();
                foreach (var asset in xmlObj.assets.asset)
                {
                    results.Assets.Add(ToClientAsset(asset));
                }
            }

            return results;
        }

        /// <summary>
        /// Gets the client asset statuses.
        /// </summary>
        /// <param name="xmlObj">The XML obj.</param>
        /// <returns>the client asset statuses.</returns>
        public static AssetStatusesResponse GetClientAssetStatuses(GetDispositionsResponse xmlObj)
        {
            var results = new AssetStatusesResponse();

            if (xmlObj.system != null)
            {
                results.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
            }

            if (xmlObj.dispositions != null
                && xmlObj.dispositions.disposition != null
                && xmlObj.dispositions.disposition.Length > 0)
            {
                results.Statuses = new List<AssetStatusModel>();
                foreach (var assetStatus in xmlObj.dispositions.disposition)
                {
                    results.Statuses.Add(ToClientAssetStatus(assetStatus));
                }
            }

            return results;
        }

        /// <summary>
        /// Convert to the client asset status.
        /// </summary>
        /// <param name="xmlStatus">The XML status.</param>
        /// <returns>the client asset status.</returns>
        private static AssetStatusModel ToClientAssetStatus(Disposition xmlStatus)
        {
            var result = new AssetStatusModel()
            {
                Id = KeysHelper.ToStringKeys(xmlStatus.keys),
                Display = xmlStatus.identifierDisplay,

            };

            return result;
        }

        /// <summary>
        /// convert xml model to asset model
        /// </summary>
        /// <param name="xmlAsset">response from app server</param>
        /// <returns>asset model</returns>
        public static AssetModel ToClientAsset(Asset xmlAsset)
        {
            AssetModel clientAsset = new AssetModel()
            {
                Id = KeysHelper.ToStringKeys(xmlAsset.keys),
                Display = xmlAsset.identifierDisplay,
                Action = xmlAsset.action,
                Comments = xmlAsset.comments,
                ContextType = xmlAsset.contextType,
                DateOfService = xmlAsset.dateOfService,
                StartDate = xmlAsset.startDate,
                EndDate = xmlAsset.endDate,
                StatusDates = xmlAsset.statusDates,
                Description = xmlAsset.description,
                ClassType = xmlAsset.classType,
                AssetName = xmlAsset.Name
            };

            //get asset type info
            if (xmlAsset.type != null)
            {
                clientAsset.AssetType = new AssetTypeModel();
                clientAsset.AssetType.Display = xmlAsset.type.identifierDisplay;
                clientAsset.AssetType.Id = KeysHelper.ToStringKeys(xmlAsset.type.keys);
            }

            //get asset status
            if (xmlAsset.status != null)
            {
                clientAsset.AssetStatus = new AssetStatusModel()
                {
                    Id = KeysHelper.ToStringKeys(xmlAsset.status.keys),
                    Display = xmlAsset.status.name
                };
            }

            //get asset parent
            if (xmlAsset.AssetParentID != null)
            {
                clientAsset.AssetParent = new AssetParentModel()
                {
                    Id = KeysHelper.ToStringKeys(xmlAsset.AssetParentID.keys),
                    Display = xmlAsset.AssetParentID.identifierDisplay
                };
            }

            if (xmlAsset.additionalInformation != null)
            {
                clientAsset.AdditionalInformation = ASIHelper.ToClientAdditionGroups(xmlAsset.additionalInformation);
                clientAsset.AdditionalTables = ASITHelper.GetAsiAsit(xmlAsset.additionalInformation);
            }

            clientAsset.CurrentValue = xmlAsset.currentValue.ToString();
            clientAsset.SalvageValue = xmlAsset.salvageValue.ToString();
            clientAsset.StartValue = xmlAsset.startValue.ToString();
            clientAsset.UsefulLife = xmlAsset.usefulLife.ToString();
            clientAsset.DepreciationAmount = xmlAsset.depreciationAmount.ToString();
            clientAsset.DepreciationValue = xmlAsset.depreciationValue.ToString();

            if (xmlAsset.GISObjects != null
                && xmlAsset.GISObjects.GISObject != null
                && xmlAsset.GISObjects.GISObject.Length > 0)
            {
                clientAsset.GISObjects = new List<GISObjectModel>();

                foreach (var gisObject in xmlAsset.GISObjects.GISObject)
                {
                    clientAsset.GISObjects.Add(ToClientGISObject(gisObject));
                }
            }

            if (xmlAsset.shortNotes != null)
            {
                clientAsset.ShortNotes = xmlAsset.shortNotes;
            }

            return clientAsset;
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

        public static AssetTypesResponse GetClientAssetTypes(GetAssetTypesResponse xmlObj)
        {
            AssetTypesResponse response = new AssetTypesResponse();

            if (xmlObj.system != null)
            {
                response.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
            }

            if (xmlObj.assetTypes != null
                && xmlObj.assetTypes.assetType != null
                && xmlObj.assetTypes.assetType.Length > 0)
            {
                response.Types = new List<AssetTypeModel>();

                foreach (var type in xmlObj.assetTypes.assetType)
                {
                    AssetTypeModel clientObj = new AssetTypeModel();
                    clientObj.Id = KeysHelper.ToStringKeys(type.keys);
                    clientObj.Display = type.identifierDisplay;
                    clientObj.GISIDFieldName = type.GISIdForAssetId;
                    clientObj.Group = type.Group;

                    clientObj.GISService = type.GISService;

                    if (type.GISLayerId != null)
                    {
                        clientObj.GISLayer = new GISLayerModel
                        {
                            Id = KeysHelper.ToStringKeys(type.GISLayerId.keys),
                            Display = type.GISLayerId.identifierDisplay
                        };
                    }

                    response.Types.Add(clientObj);
                }
            }

            return response;
        }

        public static AssetUnitTypesResponse GetAssetUnitTypes(GetStandardChoicesResponse response)
        {
            var result = new AssetUnitTypesResponse();

            if (response.system != null)
            {
                result.PageInfo = CommonHelper.GetPaginationFromSystem(response.system);
                result.Events = CommonHelper.GetClientEventMessage(response.system.eventMessages);
            }

            result.AssetUnitTypes = new List<AssetUnitTypesModel>();
            if (response.standardChoices != null &&
                response.standardChoices.AMOEnumeration != null &&
                response.standardChoices.AMOEnumeration.Length > 0)
            {
                foreach (var AssetUnitTypes in response.standardChoices.AMOEnumeration)
                {
                    var assetUnitTypesModel = new AssetUnitTypesModel();
                    assetUnitTypesModel.Id = KeysHelper.ToStringKeys(AssetUnitTypes.keys);
                    assetUnitTypesModel.IdentifierDisplay = AssetUnitTypes.identifierDisplay;
                    assetUnitTypesModel.Description = AssetUnitTypes.description;
                    assetUnitTypesModel.Type = AssetUnitTypes.enumerationType;
                    result.AssetUnitTypes.Add(assetUnitTypesModel);
                }

            }
            return result;
        }

        public static Asset ToCovXmlAsset(AssetModel model)
        {
            Asset asset = new Asset();

            if (model != null
                && !String.IsNullOrWhiteSpace(model.Action)
                && model.Action.ToLower() != "existing"
                && model.Action.ToLower() != "normal")
            {
                asset.action = CommonHelper.ToGovXmlAction(model.Action);

                if (!String.IsNullOrWhiteSpace(model.Id))
                {
                    asset.keys = KeysHelper.CreateXMLKeys(model.Id);
                }

                if (!String.IsNullOrWhiteSpace(model.Display))
                {
                    asset.identifierDisplay = model.Display;
                }

                if (!String.IsNullOrWhiteSpace(model.Comments))
                {
                    asset.comments = model.Comments;
                }

                if (!String.IsNullOrWhiteSpace(model.ContextType))
                {
                    asset.contextType = model.ContextType;
                }

                if (!String.IsNullOrWhiteSpace(model.CurrentValue))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.CurrentValue, out tempValue);

                    asset.currentValue = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.DateOfService))
                {
                    asset.dateOfService = model.DateOfService;
                }

                if (!String.IsNullOrWhiteSpace(model.DepreciationAmount))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.DepreciationAmount, out tempValue);

                    asset.depreciationAmount = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.DepreciationValue))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.DepreciationValue, out tempValue);

                    asset.depreciationAmount = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.Description))
                {
                    asset.description = model.Description;
                }


                if (!String.IsNullOrWhiteSpace(model.EndDate))
                {
                    asset.endDate = model.EndDate;
                }

                if (!String.IsNullOrWhiteSpace(model.SalvageValue))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.SalvageValue, out tempValue);

                    asset.salvageValue = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.StartDate))
                {
                    asset.startDate = model.StartDate;
                }

                if (!String.IsNullOrWhiteSpace(model.StartValue))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.StartValue, out tempValue);

                    asset.startValue = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.StatusDates))
                {
                    asset.statusDates = model.StatusDates;
                }

                if (!String.IsNullOrWhiteSpace(model.UsefulLife))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.UsefulLife, out tempValue);

                    asset.usefulLife = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.ClassType))
                {
                    asset.classType = model.ClassType;
                }

                if (model.AssetType != null && (!String.IsNullOrWhiteSpace(model.AssetType.Id) || !String.IsNullOrWhiteSpace(model.AssetType.Display)))
                {

                    asset.type = new Automation.GovXmlClient.Model.Type();

                    if (!string.IsNullOrWhiteSpace(model.AssetType.Id))
                    {
                        asset.type.keys = KeysHelper.CreateXMLKeys(model.AssetType.Id);
                    }


                    if (!String.IsNullOrWhiteSpace(model.AssetType.Display))
                    {
                        asset.type.identifierDisplay = model.AssetType.Display;
                    }
                }

                if (model.AssetStatus != null)
                {
                    asset.status = new Status();
                    asset.status.keys = KeysHelper.CreateXMLKeys(model.AssetStatus.Id);

                    if (!String.IsNullOrWhiteSpace(model.AssetStatus.Display))
                    {
                        asset.status.name = model.AssetStatus.Display;
                    }
                }

                if (!String.IsNullOrWhiteSpace(model.AssetName))
                {
                    asset.Name = model.AssetName;
                }

                if (model.AssetParent != null)
                {
                    model.AssetParent = new AssetParentModel();

                    if (!String.IsNullOrWhiteSpace(model.AssetParent.Id))
                    {
                        asset.AssetParentID.keys = KeysHelper.CreateXMLKeys(model.AssetParent.Id);
                    }
                }
            }

            return asset;
        }

        public static Asset ToXMLCreateAsset(CreateAssetRequest request)
        {
            var asset = new Asset();

            AssetModel model = request.Asset;

            if (model != null)
            {
                if (!String.IsNullOrWhiteSpace(model.Id))
                {
                    asset.identifierDisplay = model.Id;
                }

                if (model.AssetType != null)
                {
                    asset.type = new Automation.GovXmlClient.Model.Type();
                    asset.type.keys = KeysHelper.CreateXMLKeys(model.AssetType.Id);

                    if (!String.IsNullOrWhiteSpace(model.AssetType.Display))
                    {
                        asset.type.identifierDisplay = model.AssetType.Display;
                    }
                }

                if (model.AssetStatus != null)
                {
                    asset.status = new Status();
                    asset.status.keys = KeysHelper.CreateXMLKeys(model.AssetStatus.Id);

                    if (!String.IsNullOrWhiteSpace(model.AssetStatus.Display))
                    {
                        asset.status.name = model.AssetStatus.Display;
                    }
                }

                if (!String.IsNullOrWhiteSpace(model.Description))
                {
                    asset.description = model.Description;
                }

                if (!String.IsNullOrWhiteSpace(model.Comments))
                {
                    asset.comments = model.Comments;
                }

                if (!String.IsNullOrWhiteSpace(model.StartValue))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.StartValue, out tempValue);

                    asset.startValue = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.UsefulLife))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.UsefulLife, out tempValue);

                    asset.usefulLife = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.DateOfService))
                {
                    asset.dateOfService = model.DateOfService;
                }

                if (!String.IsNullOrWhiteSpace(model.SalvageValue))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.SalvageValue, out tempValue);

                    asset.salvageValue = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.CurrentValue))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.CurrentValue, out tempValue);

                    asset.currentValue = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.StartDate))
                {
                    asset.startDate = model.StartDate;
                }

                if (!String.IsNullOrWhiteSpace(model.EndDate))
                {
                    asset.endDate = model.EndDate;
                }

                if (!String.IsNullOrWhiteSpace(model.DepreciationAmount))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.DepreciationAmount, out tempValue);

                    asset.depreciationAmount = tempValue;
                }

                if (!String.IsNullOrWhiteSpace(model.DepreciationValue))
                {
                    double tempValue = 0.0;

                    Double.TryParse(model.DepreciationValue, out tempValue);

                    asset.depreciationValue = tempValue;
                }
            }

            return asset;
        }

        public static Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse.CreateAssetResponse ToClientAssetResponse(Automation.GovXmlClient.Model.CreateAssetResponse govXMLObject)
        {
            Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse.CreateAssetResponse response = new Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse.CreateAssetResponse();

            if (govXMLObject != null)
            {
                if (govXMLObject.system != null)
                {
                    response.Events = CommonHelper.GetClientEventMessage(govXMLObject.system.eventMessages);
                }

                if (govXMLObject.asset != null)
                {
                    response.Asset = AssetHelper.ToClientAsset(govXMLObject.asset);
                }
            }

            return response;
        }

        internal static List<AssetCAModel> GetClientAssetCAs(List<AssetCA> assetCAs)
        {
            List<AssetCAModel> assetCAModels = new List<AssetCAModel>();
            if (assetCAs != null && assetCAs.Count > 0)
            {
                assetCAs.ForEach(asset => assetCAModels.Add(GetClientAssetCA(asset)));
            }
            return assetCAModels;
        }

        internal static AssetCAModel GetClientAssetCA(AssetCA assetCA)
        {
            AssetCAModel assetCAModel = null;
            if (assetCA != null)
            {
                assetCAModel = new AssetCAModel();
                assetCAModel.Identifier = KeysHelper.ToStringKeys(assetCA.keys);
                assetCAModel.Display = assetCA.IdentifierDisplay;

                if (assetCA.asset != null)
                {
                    assetCAModel.CAAsset = GetClientCAAsset(assetCA.asset);
                }

                if (assetCA.status != null)
                {
                    assetCAModel.Status = new AssetCAStatusModel();
                    assetCAModel.Status.Identifier = KeysHelper.ToStringKeys(assetCA.status.keys);
                    assetCAModel.Status.Display = assetCA.status.IdentifierDisplay;
                    assetCAModel.Status.Name = assetCA.status.name;
                }

                if (assetCA.assetCAType != null)
                {
                    assetCAModel.Type = new AssetCATypeModel();
                    assetCAModel.Type.Identifier = KeysHelper.ToStringKeys(assetCA.assetCAType.keys);
                    assetCAModel.Type.Display = assetCA.assetCAType.identifierDisplay;
                }

                assetCAModel.ScheduleDate = assetCA.scheduleDate;
                assetCAModel.ScheduleTime = assetCA.scheduleTime;
                assetCAModel.InspectionDate = assetCA.inspectionDate;
                assetCAModel.InspectionTime = assetCA.inspectionTime;

                if (assetCA.department != null)
                {
                    assetCAModel.Department = GetClientAssetCADepartment(assetCA.department);
                }

                if (assetCA.staffPerson != null)
                {
                    assetCAModel.StaffPerson = GetClientAssetCAStaffPerson(assetCA.staffPerson);
                }

                assetCAModel.TimeSpent = assetCA.timeSpent.ToString();
                assetCAModel.Comment = assetCA.comment;

                if (assetCA.additionalInformation != null)
                {
                    assetCAModel.AdditionalInformations = ASIHelper.ToClientAdditionGroups(assetCA.additionalInformation);
                }

                if (assetCA.observation != null)
                {
                    assetCAModel.Observations = ASITHelper.GetCAAsits(assetCA.observation);
                }
            }
            return assetCAModel;
        }

        internal static AssetCADepartmentModel GetClientAssetCADepartment(Department department)
        {
            AssetCADepartmentModel assetCADepartmentModel = null;
            if (department != null)
            {
                assetCADepartmentModel = new AssetCADepartmentModel();
                assetCADepartmentModel.Identifier = KeysHelper.ToStringKeys(department.keys);
                assetCADepartmentModel.Display = department.identifierDisplay;
                assetCADepartmentModel.AgencyCode = department.agencyCode;
                assetCADepartmentModel.BureauCode = department.bureauCode;
                assetCADepartmentModel.DivisionCode = department.divisionCode;
                assetCADepartmentModel.SectionCode = department.sectionCode;
                assetCADepartmentModel.GroupCode = department.groupCode;
                assetCADepartmentModel.SubgroupCode = department.subgroupCode;
                assetCADepartmentModel.SubgroupCodeDesc = department.subgroupDesc;

                if (department.Staff != null && department.Staff.StaffPerson != null && department.Staff.StaffPerson.Count() > 0)
                {
                    assetCADepartmentModel.Staff = new List<AssetCAStaffPersonModel>();
                    foreach (var staffPerson in department.Staff.StaffPerson)
                    {
                        assetCADepartmentModel.Staff.Add(GetClientAssetCAStaffPerson(staffPerson));
                    }
                }
            }
            return assetCADepartmentModel;
        }

        internal static Department ToGovXmlAssetCADepartment(AssetCADepartmentModel assetCADepartmentModel)
        {
            Department department = null;
            if (assetCADepartmentModel != null)
            {
                department = new Department();
                department.keys = KeysHelper.CreateXMLKeys(assetCADepartmentModel.Identifier);
                department.identifierDisplay = assetCADepartmentModel.Display;
                department.agencyCode = assetCADepartmentModel.AgencyCode;
                department.bureauCode = assetCADepartmentModel.BureauCode;
                department.divisionCode = assetCADepartmentModel.DivisionCode;
                department.sectionCode = assetCADepartmentModel.SectionCode;
                department.groupCode = assetCADepartmentModel.GroupCode;
                department.subgroupCode = assetCADepartmentModel.SubgroupCode;
                department.subgroupDesc = assetCADepartmentModel.SubgroupCodeDesc;

                if (assetCADepartmentModel.Staff != null && assetCADepartmentModel.Staff.Count() > 0)
                {
                    department.Staff = new Staff();
                    department.Staff.StaffPerson = new StaffPerson[assetCADepartmentModel.Staff.Count];


                    assetCADepartmentModel.Staff = new List<AssetCAStaffPersonModel>();
                    int i = 0;
                    foreach (var staff in assetCADepartmentModel.Staff)
                    {
                        department.Staff.StaffPerson[i] = ToGovXmlAssetCAStaffPerson(staff);
                        i++;
                    }
                }
            }
            return department;
        }

        internal static StaffPerson ToGovXmlAssetCAStaffPerson(AssetCAStaffPersonModel assetCAStaffPersonModel)
        {
            StaffPerson staffPerson = null;
            if (assetCAStaffPersonModel != null)
            {
                staffPerson = new StaffPerson();
                staffPerson.keys = KeysHelper.CreateXMLKeys(assetCAStaffPersonModel.Identifier);
                staffPerson.identifierDisplay = assetCAStaffPersonModel.Display;
                staffPerson.firstName = assetCAStaffPersonModel.FirstName;
                staffPerson.lastName = assetCAStaffPersonModel.LastName;
                staffPerson.auditStatus = assetCAStaffPersonModel.AuditStatus;
                staffPerson.serviceProviderCode = assetCAStaffPersonModel.ServiceProviderCode;
                staffPerson.userId = assetCAStaffPersonModel.UserID;
                staffPerson.agencyCode = assetCAStaffPersonModel.AgencyCode;
                staffPerson.bureauCode = assetCAStaffPersonModel.BureauCode;
                staffPerson.divisionCode = assetCAStaffPersonModel.DivisionCode;
                staffPerson.sectionCode = assetCAStaffPersonModel.SectionCode;
                staffPerson.groupCode = assetCAStaffPersonModel.GroupCode;
                staffPerson.officeCode = assetCAStaffPersonModel.OfficeCode;
            }
            return staffPerson;
        }

        internal static AssetCAStaffPersonModel GetClientAssetCAStaffPerson(StaffPerson staffPerson)
        {
            AssetCAStaffPersonModel assetCAStaffPersonModel = null;
            if (staffPerson != null)
            {
                assetCAStaffPersonModel = new AssetCAStaffPersonModel();
                assetCAStaffPersonModel.Identifier = KeysHelper.ToStringKeys(staffPerson.keys);
                assetCAStaffPersonModel.Display = staffPerson.identifierDisplay;
                assetCAStaffPersonModel.FirstName = staffPerson.firstName;
                assetCAStaffPersonModel.LastName = staffPerson.lastName;
                assetCAStaffPersonModel.AuditStatus = staffPerson.auditStatus;
                assetCAStaffPersonModel.ServiceProviderCode = staffPerson.serviceProviderCode;
                assetCAStaffPersonModel.UserID = staffPerson.userId;
                assetCAStaffPersonModel.AgencyCode = staffPerson.agencyCode;
                assetCAStaffPersonModel.BureauCode = staffPerson.bureauCode;
                assetCAStaffPersonModel.DivisionCode = staffPerson.divisionCode;
                assetCAStaffPersonModel.SectionCode = staffPerson.sectionCode;
                assetCAStaffPersonModel.GroupCode = staffPerson.groupCode;
                assetCAStaffPersonModel.OfficeCode = staffPerson.officeCode;
            }
            return assetCAStaffPersonModel;
        }

        internal static CAAssetModel GetClientCAAsset(Asset assetCA)
        {
            CAAssetModel assetCAModel = null;
            if (assetCA != null)
            {
                assetCAModel = new CAAssetModel();
                assetCAModel.Identifier = KeysHelper.ToStringKeys(assetCA.keys);
                assetCAModel.Display = assetCA.identifierDisplay;

                if (assetCA.type != null)
                {
                    assetCAModel.Type = new AssetTypeModel();
                    assetCAModel.Type.Id = KeysHelper.ToStringKeys(assetCA.type.keys);
                    assetCAModel.Type.Display = assetCA.type.identifierDisplay;
                }

                if (assetCA.descriptionIdentifier != null)
                {
                    assetCAModel.Description = new AssetDescriptionModel();
                    assetCAModel.Description.Identifier = KeysHelper.ToStringKeys(assetCA.descriptionIdentifier.keys);
                    assetCAModel.Description.Display = assetCA.descriptionIdentifier.identifierDisplay;
                }

                assetCAModel.Name = assetCA.Name;
            }

            return assetCAModel;
        }

        public static AssetCATypesResponse GetAssetCATypes(GetAssetCATypesResponse response)
        {
            if (response == null
                || response.assetCATypes == null
                || response.assetCATypes.assetCATypes == null
                || response.assetCATypes.assetCATypes.Length == 0)
            {
                return null;
            }

            var result = new AssetCATypesResponse();

            result.AssetCATypes = new List<AssetCATypeModel>();
            if (response != null && response.assetCATypes != null
               && response.assetCATypes.assetCATypes != null
               && response.assetCATypes.assetCATypes.Length > 0)
            {
                foreach (var AssetCATypes in response.assetCATypes.assetCATypes)
                {
                    var assetCATypesModel = new AssetCATypeModel();
                    assetCATypesModel.Display = AssetCATypes.identifierDisplay;
                    assetCATypesModel.Identifier = KeysHelper.ToStringKeys(AssetCATypes.keys);
                    result.AssetCATypes.Add(assetCATypesModel);
                }
            }

            return result;
        }

        public static AdditionalGroupResponse ToClientAdditionalGroups(GetAdditionalInformationGroupsResponse response)
        {
            var results = new AdditionalGroupResponse();

            if (response.additionalInformation != null
                && response.additionalInformation.additionalInformationGroup != null
                && response.additionalInformation.additionalInformationGroup.Length > 0)
            {
                results.AdditionalGroups = new List<AdditionalGroupModel>();
                foreach (var additionalGroup in response.additionalInformation.additionalInformationGroup)
                {
                    results.AdditionalGroups.Add(RecordTypeHelper.ToClientAdditionalGroup(additionalGroup));
                }
            }

            return results;
        }
    }
}
