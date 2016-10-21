using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Repositories.GovXmlQueries;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class ChecklistHelper : GovXmlHelperBase 
    {
        /// <summary>
        /// Get Client check list from GoxXml
        /// </summary>
        /// <param name="xmlObjs">Guide sheets object(GovXml)</param>
        /// <returns>return converted check list model list</returns>
        public static List<ChecklistModel> GetClientChecklists(Guidesheets xmlObjs)
        {
            List<ChecklistModel> results=null;
            if (xmlObjs != null && xmlObjs.guidesheet != null)
            {
                results = new List<ChecklistModel>();
                foreach (var xmlObj in xmlObjs.guidesheet)
                {
                    ChecklistModel checklist = new ChecklistModel();

                    if (xmlObj.keys != null)
                    {
                        checklist.Identifier = xmlObj.keys.ToStringKeys();
                        checklist.ChecklistGroups = GetClientChecklistGroup(xmlObj.guidesheetGroups);
                        checklist.Subject = xmlObj.identifierDisplay;
                        checklist.Label = xmlObj.label;
                        checklist.ChecklistItems = GetClientChecklistItems(xmlObj);
                        var totalScore = GetTotalScore(checklist.ChecklistItems);
                        checklist.TotalScore = totalScore == null ? String.Empty : totalScore.Value.ToString(CultureInfo.InvariantCulture);
                        results.Add(checklist);
                    }
                }
            }

            return results;
        }

        public static List<ChecklistGroupModel> GetClientChecklistGroup(GuidesheetGroups guidesheetGroups)
        {
            List<ChecklistGroupModel> checkListGroups = new List<ChecklistGroupModel>();
            if (guidesheetGroups != null && guidesheetGroups.guidesheetGroups != null && guidesheetGroups.guidesheetGroups.Count() > 0)
            {
                foreach (var guidesheetGroup in guidesheetGroups.guidesheetGroups)
                {
                    checkListGroups.Add(new ChecklistGroupModel() { Identifier = guidesheetGroup.keys.ToStringKeys(), Display = guidesheetGroup.identifierDisplay });
                }
            }
            return checkListGroups;
        }

        /*
         
        /// <summary>
        /// Gets the checklists.
        /// </summary>
        /// <param name="inspectionsQuery">The inspections query.</param>
        /// <returns>
        /// the check lists.
        /// </returns>
        public static List<ChecklistModel> GetChecklists(InspectionsQuery inspectionsQuery)
        {
            List<ChecklistModel> result = null;

            var inspResponse = InspectionHelper.GetInspections(inspectionsQuery);

            if (inspResponse != null && inspResponse.Inspections.Count > 0 && inspResponse.Inspections[0].Checklists != null)
            {
                result = new List<ChecklistModel>(inspResponse.Inspections[0].Checklists);
            }

            return result;
        }

        /// <summary>
        /// Gets the checklist items.
        /// </summary>
        /// <param name="inspectionsQuery">The inspections query.</param>
        /// <param name="checklistId">The checklist id.</param>
        /// <returns>
        /// the check list items.
        /// </returns>
        public static List<ChecklistItemModel> GetChecklistItems(InspectionsQuery inspectionsQuery, string checklistId)
        {
            List<ChecklistItemModel> result = null;

            var inspections = InspectionHelper.GetInspections(inspectionsQuery);

            if (inspections != null && inspections.Inspections.Count > 0 && inspections.Inspections[0].Checklists != null)
            {
                var currentChecklist = (from c in inspections.Inspections[0].Checklists
                                      where c.Identifier == checklistId
                                      select c).FirstOrDefault();
                result = currentChecklist != null ? new List<ChecklistItemModel>(currentChecklist.ChecklistItems) : null;
            }

            return result;
        }

        //*/

        /// <summary>
        /// Builds the checklists for update.
        /// </summary>
        /// <param name="checklists">The checklists.</param>
        /// <returns>the checklists for update.</returns>
        public static Guidesheets BuildChecklists4Update(List<ChecklistModel> checklists, string bizVersion)
        {
            Guidesheets result = null;

            if (checklists != null)
            {
                result = new Guidesheets();
                var guidesheetArray = (from cl in checklists
                                       where cl != null
                                       let key = new Keys()
                                       select new Guidesheet()
                                       {
                                           keys = KeysHelper.CreateXMLKeys(cl.Identifier),
                                           identifierDisplay = cl.Subject,
                                           contextType = CommonHelper.ToGovXmlAction(cl.Action),
                                           label=cl.Label,
                                           guideitems = BuildChecklistItems4Update(cl.ChecklistItems, bizVersion)
                                           //guidesheetGroups
                                           //enumerationLists
                                       }).ToArray();
                result.guidesheet = guidesheetArray;
            }

            return result;
        }

        /// <summary>
        /// Builds the checklist items for update.
        /// </summary>
        /// <param name="checklistItems">The checklist items.</param>
        /// <returns>the checklist items for update.</returns>
        public static Guideitems BuildChecklistItems4Update(List<ChecklistItemModel> checklistItems, string bizVersion)
        {
            Guideitems result = null;

            if (checklistItems != null)
            {
                result = new Guideitems();
                var guidesheetItemArray = (from ci in checklistItems
                                           where ci != null
                                           let key = new Keys()
                                           select ToXMLGuideItem(ci, bizVersion)).ToArray();

                result.guideitem = guidesheetItemArray;
            }

            return result;
        }

        private static Guideitem ToXMLGuideItem(ChecklistItemModel ci, string bizVersion)
        {
            Guideitem item = new Guideitem();
            item.contextType = CommonHelper.ToGovXmlAction(ci.Action);
            item.keys = KeysHelper.CreateXMLKeys(ci.Identifier);
            item.description = ci.Content;
            if (ci.Status != null)
            {
                if (IsBizVersion705(bizVersion))
                {
                    //item.applicability = ci.Status.Display;

                    // In order to support I18N, we should not use the value of display field, because it will be non-english, and the GovXML 
                    // server will treat this value as a PK.

                    // Should decode this key.
                    item.applicability = IdEscapeHelper.DecodeString(ci.Status.Identifier);
                }
                else
                {
                    item.Status = new Enumeration()
                    {
                        keys = KeysHelper.CreateXMLKeys(ci.Status.Identifier),
                        identifierDisplay = ci.Status.Display,
                        description = ci.Status.Display,
                        enumerationType = ci.Status.Type
                    };
                }
            }
            
            // In order to support I18N, some agency need these locale information; others do not need.
            // Anyway, we pass these information to the GovXML.
            if (ci.Description != null)
            {
                item.DescriptionEnumeration = new Enumeration
                {
                    keys = KeysHelper.CreateXMLKeys(ci.Description.ID),
                    identifierDisplay = ci.Description.Display
                };
            }
            // End

            item.text = ci.Comments;
            item.maxValue = ci.MaxScore;
            item.dataValue = ci.Score;
            item.applicabilityEnumerationListId = ci.StatusGroup == null ? null : ci.StatusGroup.Identifier;

            if (!String.IsNullOrEmpty(ci.ViolationCode))
            {
                item.violationCode = ci.ViolationCode;
            }

            if (!String.IsNullOrEmpty(ci.Critical))
            {
                item.critical = ci.Critical;
            }

            if (!String.IsNullOrEmpty(ci.RecordedBy))
            {
                item.recordedBy = ci.RecordedBy;
            }

            if (!String.IsNullOrEmpty(ci.CarryOverFlag))
            {
                item.carryOverFlag = ci.CarryOverFlag;
            }

            if (ci.AdditionalInfo != null && ci.AdditionalInfo.Count > 0)
            {
                List<AdditionalInformationGroup> xmlASI = ASIHelper.ToXMLAdditionalGroups(ci.AdditionalInfo);
                List<AdditionalInformationGroup> xmlASIT = ASITHelper.BuildAsiAsit4Update(ci.AdditionalTableInfo);

                if (xmlASI != null)
                {
                    item.additionalInformation = new AdditionalInformation();
                    if (xmlASIT != null)
                    {
                        item.additionalInformation.additionalInformationGroup = xmlASI.Union(xmlASIT).ToArray();
                    }
                    else
                    {
                        item.additionalInformation.additionalInformationGroup = xmlASI.ToArray();
                    }
                }

            }
            return item;
        }

        /// <summary>
        /// Get client check list item
        /// </summary>
        /// <param name="guideSheet">The guide sheet.</param>
        /// <returns>
        /// Convertd check list item model list
        /// </returns>
        private static List<ChecklistItemModel> GetClientChecklistItems(Guidesheet guideSheet)
        {
            Guideitems guideitems = guideSheet == null ? null : guideSheet.guideitems;
            List<ChecklistItemModel> results = null;

            if (guideitems != null && guideitems.guideitem != null)
            {
                results = new List<ChecklistItemModel>();
                foreach (var xmlObj in guideitems.guideitem)
                {
                    ChecklistItemModel checklistItem = new ChecklistItemModel();
                    if (xmlObj.keys != null)
                    {
                        checklistItem.Identifier = xmlObj.keys.ToStringKeys();
                        checklistItem.Content = xmlObj.description;
                        if (xmlObj.DescriptionEnumeration != null)
                        {
                            checklistItem.Description = new DescriptionModel();
                            checklistItem.Description.ID = xmlObj.DescriptionEnumeration.keys.ToStringKeys();
                            checklistItem.Description.Display = xmlObj.DescriptionEnumeration.identifierDisplay;
                        }
                        if (xmlObj.Status != null)
                        {
                            checklistItem.StatusVisible = true;
                            checklistItem.Status = GetChecklistItemStatus(xmlObj.Status);
                        }
                        else
                        {
                            checklistItem.StatusVisible = false;
                        }

                        checklistItem.Comments = xmlObj.text;
                        if (checklistItem.Comments != null)
                        {
                            checklistItem.CommentVisible = true;
                        }
                        else
                        {
                            checklistItem.CommentVisible = false;
                        }

                        if (!string.IsNullOrWhiteSpace(xmlObj.maxValue))
                        {
                            checklistItem.MaxScore = xmlObj.maxValue;
                        }

                        if (!string.IsNullOrWhiteSpace(xmlObj.identifierDisplay))
                        {
                            checklistItem.Display = xmlObj.identifierDisplay;
                        }

                        if (!string.IsNullOrWhiteSpace(xmlObj.defaultValue))
                        {
                            checklistItem.DefaultScore = xmlObj.defaultValue;
                        }

                        if (!string.IsNullOrWhiteSpace(xmlObj.dataValue))
                        {
                            checklistItem.ScoreVisible = true;
                            checklistItem.Score = xmlObj.dataValue;
                        }
                        else
                        {
                            checklistItem.ScoreVisible = false;
                        }

                        if (!string.IsNullOrWhiteSpace(xmlObj.applicabilityEnumerationListId))
                        {
                            checklistItem.StatusGroup = GetChecklistItemStatusGroup(guideSheet, xmlObj);
                            ChecklistItemStatus matchedStatus = null;

                            if (checklistItem.Status != null && checklistItem.StatusGroup != null && checklistItem.StatusGroup.ChecklistItemStatuses != null)
                            {
                                matchedStatus = checklistItem.StatusGroup.ChecklistItemStatuses.Where(p=>p.Identifier==checklistItem.Status.Identifier).FirstOrDefault();
                            }

                            if (matchedStatus != null)
                            {
                                checklistItem.Status.Type = matchedStatus.Type;
                            }
                        }

                        if (xmlObj.additionalInformation != null && xmlObj.additionalInformation.additionalInformationGroup != null && xmlObj.additionalInformation.additionalInformationGroup[0] != null)
                        {
                            checklistItem.AdditionalInfo = ASIHelper.ToClientAdditionGroups(xmlObj.additionalInformation);
                            checklistItem.AdditionalTableInfo = ASITHelper.GetAsiAsit(xmlObj.additionalInformation);
                            checklistItem.AdditionalVisible = true;
                        }
                        else
                        {
                            checklistItem.AdditionalVisible = false;
                        }

                        //Additional parse

                        if (!String.IsNullOrEmpty(xmlObj.violationCode))
                        {
                            checklistItem.ViolationCode = xmlObj.violationCode;
                        }

                        if (!String.IsNullOrEmpty(xmlObj.critical))
                        {
                            checklistItem.Critical = xmlObj.critical;
                        }

                        if (!String.IsNullOrEmpty(xmlObj.recordedBy))
                        {
                            checklistItem.RecordedBy = xmlObj.recordedBy;
                        }

                        if (!String.IsNullOrEmpty(xmlObj.carryOverFlag))
                        {
                            checklistItem.CarryOverFlag = xmlObj.carryOverFlag;
                        }

                        results.Add(checklistItem);
                    }

                }
            }

            return results;
        }

        /// <summary>
        /// Gets the checklist item status group.
        /// </summary>
        /// <param name="guideSheet">The guide sheet.</param>
        /// <param name="guideSheetItem">The guide sheet item.</param>
        /// <returns>the checklist item status group.</returns>
        private static ChecklistItemStatusGroup GetChecklistItemStatusGroup(Guidesheet guideSheet, Guideitem guideSheetItem)
        {
            ChecklistItemStatusGroup result = null;

            if (guideSheet != null && guideSheet.enumerationLists!=null && guideSheet.enumerationLists.enumerationList!=null && guideSheetItem != null)
            {
                result = new ChecklistItemStatusGroup();
                var targetEnumeration = (from el in guideSheet.enumerationLists.enumerationList
                                        where el.id==guideSheetItem.applicabilityEnumerationListId
                                        select el).FirstOrDefault();

                if (targetEnumeration != null && targetEnumeration.Enumerations != null && targetEnumeration.Enumerations.AMOEnumeration != null)
                {
                    var statusList = (from s in targetEnumeration.Enumerations.AMOEnumeration
                                      let status = GetChecklistItemStatus(s)
                                      select status).ToList();
                    result.ChecklistItemStatuses = statusList;
                }
                
                result.Identifier = guideSheetItem.applicabilityEnumerationListId;
            }

            return result;
        }

        /// <summary>
        /// Gets the checklist item status.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>the checklist item status.</returns>
        private static ChecklistItemStatus GetChecklistItemStatus(Enumeration enumeration)
        {
            ChecklistItemStatus result = null;

            if (enumeration != null)
            {
                result = new ChecklistItemStatus();

                if (enumeration.keys != null)
                {
                    result.Identifier = enumeration.keys.ToStringKeys();
                }

                result.Display = enumeration.identifierDisplay;
                result.Type = enumeration.enumerationType;
            }

            return result;
        }

        /// <summary>
        /// Gets the total score.
        /// </summary>
        /// <param name="checkListItemModelList">The check list item model list.</param>
        /// <returns>the total score.</returns>
        private static double? GetTotalScore(List<ChecklistItemModel> checkListItemModelList)
        {
            double? result = null;

            if (checkListItemModelList != null && checkListItemModelList.Count > 0)
            {
                var tempResult = checkListItemModelList.Sum(c => c != null && !String.IsNullOrWhiteSpace(c.Score) ? Convert.ToDouble(c.Score) : 0);
                result = tempResult;
            }

            return result;
        }
    }
}
