using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Repositories.GovXmlQueries;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class InspectionTypeHelper : GovXmlHelperBase 
    {
        /*
        /// <summary>
        /// Get inspection type list.
        /// </summary>
        /// <param name="queryCondition">Query Condition.</param>
        /// <returns>InspectionTypeModel list.</returns>
        public static InspectionTypeResponse GetInspetionTypes(QueryBase queryCondition)
        {
            GovXML govXmlIn = new GovXML();

            GetInspectionTypes getInspectionTypes = new GetInspectionTypes();
            getInspectionTypes.system = CommonHelper.GetSystem();
            getInspectionTypes.system.startRow = queryCondition.RowStart;
            getInspectionTypes.system.maxRows = queryCondition.PageSize;

            govXmlIn.getInspectionTypes = getInspectionTypes;
            GovXML response = CommonHelper.Post(govXmlIn, govXmlIn.getInspectionTypes.system,
                                                (o) =>
                                                o.getInspectionTypesResponse == null
                                                    ? null
                                                    : o.getInspectionTypesResponse.system);

            InspectionTypeResponse results = GetClientInspectionTypes(response.getInspectionTypesResponse.inspectionTypeSets);
            Sys sys = response.getInspectionTypesResponse.system;
            results.PageInfo = CommonHelper.GetPaginationFromSystem(sys);
            

            return results;
        }
        //*/

        /*
        /// <summary>
        /// Get inspection type list.
        /// </summary>
        /// <param name="queryCondition">Query Condition.</param>
        /// <returns>InspectionTypeModel list.</returns>
        public static InspectionTypeResponse GetInspetionTypes(InspectionTypeRequest request)
        {
            GovXML govXmlIn = new GovXML();

            govXmlIn.getInspectionTypes = new GetInspectionTypes();
            govXmlIn.getInspectionTypes.system = CommonHelper.GetSystem(request );

            GovXML response = CommonHelper.Post(govXmlIn, govXmlIn.getInspectionTypes.system,
                                                (o) =>
                                                o.getInspectionTypesResponse == null
                                                    ? null
                                                    : o.getInspectionTypesResponse.system);

            InspectionTypeResponse results = GetClientInspectionTypes(response.getInspectionTypesResponse.inspectionTypeSets);
            results.PageInfo = CommonHelper.GetPaginationFromSystem(response.getInspectionTypesResponse.system);
            return results;
        }
        //*/

        /*
        /// <summary>
        /// Gets the inspection statuses.
        /// </summary>
        /// <param name="queryCondition">The query condition.</param>
        /// <param name="inspectionTypeId">The inspection type id.</param>
        /// <returns>the inspection statuses.</returns>
        public static PagedList<InspectionStatusModel> GetInspectionStatuses(QueryBase queryCondition,
                                                                             string inspectionTypeId)
        {
            PagedList<InspectionStatusModel> result = null;
            InspectionTypeResponse inspTypes = InspectionTypeHelper.GetInspetionTypes(queryCondition);
            var statusListLinqResult = (from t in inspTypes.InspectionTypes
                                        where t.Identifier == inspectionTypeId
                                        from s in t.StatusList
                                        select s).DefaultIfEmpty();
            var statusList = statusListLinqResult != null ? statusListLinqResult.ToList() : null;

            if (statusList != null && statusList.Count > 0)
            {
                result = new PagedList<InspectionStatusModel>(statusList, 0, statusList.Count);
            }

            return result;
        }
        //*/

        /*
        /// <summary>
        /// Convert XML inspection type into client inspection
        /// </summary>
        /// <param name="xmlInspTypeSets">gov xml inspection type object</param>
        /// <returns>return converted inspection type model</returns>
        private static InspectionTypeResponse GetClientInspectionTypes(InspectionTypeSets xmlInspTypeSets)
        {
            InspectionTypeResponse results = null;

            if (xmlInspTypeSets != null && xmlInspTypeSets.inspectionTypeSet != null &&
                xmlInspTypeSets.inspectionTypeSet.Length > 0)
            {
                results = new InspectionTypeResponse();
                results.InspectionTypes = new List<InspectionTypeModel>();
                foreach (var xmlInspTypeSet in xmlInspTypeSets.inspectionTypeSet)
                {
                    var xmlObjs = xmlInspTypeSet.inspectionTypes;

                    if (xmlObjs != null && xmlObjs.inspectionType != null && xmlObjs.inspectionType.Length > 0)
                    {
                        foreach (var xmlObj in xmlObjs.inspectionType)
                        {
                            InspectionTypeModel inspType = new InspectionTypeModel();
                            if (xmlObj.keys != null)
                            {
                                inspType.Identifier = xmlObj.keys.ToStringKeys();
                            }
                            inspType.Display = xmlObj.identifierDisplay;
                            inspType.StatusList = GetClientInspectionStatusList(xmlObj.dispositions);
                            results.InspectionTypes.Add(inspType);
                        }
                    }
                }
            }
       
            return results;
        }

        // */

        /*
        /// <summary>
        /// Get all the system inspection groups 
        /// </summary>
        public static IList<InspectionGroupModel> GetClientInspectionGroups()
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getInspectionTypes = new GetInspectionTypes() {system = CommonHelper.GetSystem()};


            GovXML govXmlOut = CommonHelper.Post(govXmlIn, govXmlIn.getInspectionTypes.system,
                                                 (o) =>
                                                 o.getInspectionTypesResponse == null
                                                     ? null
                                                     : o.getInspectionTypesResponse.system);


            IList<InspectionGroupModel> groups = new List<InspectionGroupModel>();
            var xmlGroups = govXmlOut.getInspectionTypesResponse;
            if (xmlGroups != null && xmlGroups.inspectionTypeSets != null &&
                xmlGroups.inspectionTypeSets.inspectionTypeSet != null)
            {

                InspectionGroupModel groupModel;
                foreach (var inspectionTypeSet in xmlGroups.inspectionTypeSets.inspectionTypeSet)
                {
                    groupModel = new InspectionGroupModel
                                     {
                                         Identifier = inspectionTypeSet.keys.ToStringKeys(),
                                         Display = inspectionTypeSet.identifierDisplay
                                     };

                    if (inspectionTypeSet.inspectionTypes != null &&
                        inspectionTypeSet.inspectionTypes.inspectionType != null)
                    {
                        groupModel.Types = new List<SystemInspectionTypeModel>();
                        SystemInspectionTypeModel systemInspectionTypeModel;
                        foreach (var inspectionType in inspectionTypeSet.inspectionTypes.inspectionType)
                        {
                            systemInspectionTypeModel = new SystemInspectionTypeModel();
                            systemInspectionTypeModel.Identifier = inspectionType.keys.ToStringKeys();
                            systemInspectionTypeModel.Display = inspectionType.identifierDisplay;

                            if (inspectionType.guidesheetGroups != null
                                && inspectionType.guidesheetGroups.guidesheetGroups != null
                                && inspectionType.guidesheetGroups.guidesheetGroups.Length > 0)
                            {
                                systemInspectionTypeModel.ChecklistGroup = new ChecklistGroupModel()
                                                                               {
                                                                                   Identifier =
                                                                                       inspectionType.guidesheetGroups.
                                                                                       guidesheetGroups[0].keys.
                                                                                       ToStringKeys(),
                                                                                   Display =
                                                                                       inspectionType.guidesheetGroups.
                                                                                       guidesheetGroups[0].
                                                                                       identifierDisplay
                                                                               };
                            }

                            if (inspectionType.dispositions != null && inspectionType.dispositions.disposition != null)
                            {
                                systemInspectionTypeModel.Status = new List<InspectionStatusModel>();
                                InspectionStatusModel statusModel;
                                foreach (var disposition in inspectionType.dispositions.disposition)
                                {
                                    statusModel = new InspectionStatusModel
                                                      {
                                                          Identifier = disposition.keys.ToStringKeys(),
                                                          Display = disposition.identifierDisplay,
                                                          Type = disposition.resolutionType
                                                      };
                                    systemInspectionTypeModel.Status.Add(statusModel);
                                }
                            }

                            groupModel.Types.Add(systemInspectionTypeModel);
                        }


                    }
                    groups.Add(groupModel);

                }

            }

            return groups;
        }
        //*/

        /// <summary>
        /// Convert inspection status from dispositions
        /// </summary>
        /// <param name="xmlObjs">Gov xml objects</param>
        /// <returns>reture converted inspectno status model</returns>
        private static List<InspectionStatusModel> GetClientInspectionStatusList(Dispositions xmlObjs)
        {
            List<InspectionStatusModel> results = null;

            if (xmlObjs != null && xmlObjs.disposition != null && xmlObjs.disposition.Length > 0)
            {
                results = new List<InspectionStatusModel>();
                foreach (var xmlObj in xmlObjs.disposition)
                {
                    if (xmlObj.resolutionType != null && xmlObj.resolutionType == "NA"
                        && xmlObj.identifierDisplay != null && xmlObj.identifierDisplay == "NA")
                    {
                        continue;
                    }

                    InspectionStatusModel inspStatus = new InspectionStatusModel();
                    if (xmlObj.keys != null)
                    {
                        inspStatus.Identifier = xmlObj.keys.ToStringKeys();
                    }

                    inspStatus.Display = xmlObj.identifierDisplay;

                    //the logic need notice. currently, in the status, server didn't return the type.
                    //but the type is put in the keys. the keys consist by Type and Status Key two part
                    if (xmlObj.keys != null && xmlObj.keys.key != null && xmlObj.keys.key.Length > 0)
                    {
                        inspStatus.Type = xmlObj.keys.key[0];
                    }

                    results.Add(inspStatus);
                }
            }

            return results;
        }

        public static InspectionTypeResponse ToClientInspectionTypes(GetInspectionTypesResponse getInspectionTypesResponse)
        {
            InspectionTypeResponse results = null;

            if (getInspectionTypesResponse != null
                && getInspectionTypesResponse.inspectionTypeSets != null
                && getInspectionTypesResponse.inspectionTypeSets.inspectionTypeSet != null &&
                getInspectionTypesResponse.inspectionTypeSets.inspectionTypeSet.Length > 0)
            {
                results = new InspectionTypeResponse();
                results.InspectionTypes = new List<InspectionTypeModel>();
                foreach (var xmlInspTypeSet in getInspectionTypesResponse.inspectionTypeSets.inspectionTypeSet)
                {
                    var xmlObjs = xmlInspTypeSet.inspectionTypes;

                    if (xmlObjs != null && xmlObjs.inspectionType != null && xmlObjs.inspectionType.Length > 0)
                    {
                        foreach (var xmlObj in xmlObjs.inspectionType)
                        {
                            InspectionTypeModel inspType = new InspectionTypeModel();
                            if (xmlObj.keys != null)
                            {
                                inspType.Identifier = xmlObj.keys.ToStringKeys();
                            }
                            inspType.Display = xmlObj.identifierDisplay;
                            inspType.StatusList = GetClientInspectionStatusList(xmlObj.dispositions);
                            results.InspectionTypes.Add(inspType);
                        }
                    }
                }
            }

            return results;
        }


        public static IList<InspectionGroupModel> ToClientInspectionGroups(GetInspectionTypesResponse getInspectionTypesResponse)
        {
            IList<InspectionGroupModel> groups = new List<InspectionGroupModel>();
            var xmlGroups = getInspectionTypesResponse;
            if (xmlGroups != null && xmlGroups.inspectionTypeSets != null &&
                xmlGroups.inspectionTypeSets.inspectionTypeSet != null)
            {

                InspectionGroupModel groupModel;
                foreach (var inspectionTypeSet in xmlGroups.inspectionTypeSets.inspectionTypeSet)
                {
                    groupModel = new InspectionGroupModel
                    {
                        Identifier = inspectionTypeSet.keys.ToStringKeys(),
                        Display = inspectionTypeSet.identifierDisplay
                    };

                    if (inspectionTypeSet.inspectionTypes != null &&
                        inspectionTypeSet.inspectionTypes.inspectionType != null)
                    {
                        groupModel.Types = new List<SystemInspectionTypeModel>();
                        SystemInspectionTypeModel systemInspectionTypeModel;
                        foreach (var inspectionType in inspectionTypeSet.inspectionTypes.inspectionType)
                        {
                            systemInspectionTypeModel = new SystemInspectionTypeModel();
                            systemInspectionTypeModel.Identifier = inspectionType.keys.ToStringKeys();
                            systemInspectionTypeModel.Display = inspectionType.identifierDisplay;

                            if (inspectionType.guidesheetGroups != null
                                && inspectionType.guidesheetGroups.guidesheetGroups != null
                                && inspectionType.guidesheetGroups.guidesheetGroups.Length > 0)
                            {
                                systemInspectionTypeModel.ChecklistGroup = new ChecklistGroupModel()
                                {
                                    Identifier =
                                        inspectionType.guidesheetGroups.
                                        guidesheetGroups[0].keys.
                                        ToStringKeys(),
                                    Display =
                                        inspectionType.guidesheetGroups.
                                        guidesheetGroups[0].
                                        identifierDisplay
                                };
                            }

                            if (inspectionType.dispositions != null && inspectionType.dispositions.disposition != null)
                            {
                                systemInspectionTypeModel.Status = new List<InspectionStatusModel>();
                                InspectionStatusModel statusModel;
                                foreach (var disposition in inspectionType.dispositions.disposition)
                                {
                                    statusModel = new InspectionStatusModel
                                    {
                                        Identifier = disposition.keys.ToStringKeys(),
                                        Display = disposition.identifierDisplay,
                                        Type = disposition.resolutionType
                                    };
                                    systemInspectionTypeModel.Status.Add(statusModel);
                                }
                            }

                            groupModel.Types.Add(systemInspectionTypeModel);
                        }


                    }
                    groups.Add(groupModel);

                }

            }

            return groups;
        }
    }
}
