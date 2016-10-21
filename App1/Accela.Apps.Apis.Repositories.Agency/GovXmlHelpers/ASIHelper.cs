using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class ASIHelper : GovXmlHelperBase
    {
        public static List<AdditionalGroupModel> ToClientAdditionGroups(AdditionalInformation xmlAddi)
        {
            List<AdditionalGroupModel> retu = null;
            if (xmlAddi != null && xmlAddi.additionalInformationGroup != null)
            {
                var xmlASI = xmlAddi.additionalInformationGroup.Where((o) => o.AddRemoveSubGroups == false).ToList();
                if (xmlASI != null && xmlASI.Count > 0)
                {
                    retu = new List<AdditionalGroupModel>();
                    foreach (var item in xmlASI)
                    {
                        retu.Add(ASIHelper.ToClientAdditionalGroup(item));
                    }
                }
            }

            return retu;
        }

        public static List<AdditionalInformationGroup> ToXMLAdditionalGroups(List<AdditionalGroupModel> clientGroups)
        {
            List<AdditionalInformationGroup> retus = null;
            if (clientGroups != null)
            {
                retus = new List<AdditionalInformationGroup>();
                foreach (var item in clientGroups)
                {
                    AdditionalInformationGroup xmlGroup = ASIHelper.ToXMLAdditionalGroup(item);
                    if (xmlGroup != null)
                    {
                        retus.Add(xmlGroup);
                    }
                }
            }

            return retus;
        }

        public static AdditionalInformationGroup ToXMLAdditionalGroup(AdditionalGroupModel clientGroup)
        {
            AdditionalInformationGroup xmlGroup = null;
            if (clientGroup != null)
            {
                xmlGroup = new AdditionalInformationGroup();
                xmlGroup.keys = KeysHelper.CreateXMLKeys(clientGroup.Identifier);
                xmlGroup.identifierDisplay = clientGroup.Display;
                xmlGroup.description = clientGroup.Description;
                xmlGroup.AddRemoveSubGroups = false;

                if (clientGroup.SubGroups != null)
                {
                    List<AdditionalInformationSubGroup> xmlSubGroups = new List<AdditionalInformationSubGroup>();
                    foreach (var clientSubGroup in clientGroup.SubGroups)
                    {
                        xmlSubGroups.Add(ASIHelper.ToXMLAdditionalSubGroup(clientSubGroup));
                    }

                    xmlGroup.additionalInformationSubGroup = xmlSubGroups.ToArray();
                }
            }

            return xmlGroup;
        }

        public static AdditionalInformationSubGroup ToXMLAdditionalSubGroup(AdditionalSubGroupModel clientSubGroup)
        {
            AdditionalInformationSubGroup xmlSubGroup = null;
            if (clientSubGroup != null)
            {
                xmlSubGroup = new AdditionalInformationSubGroup();
                xmlSubGroup.keys = KeysHelper.CreateXMLKeys(clientSubGroup.Identifier);
                if (clientSubGroup.IsStructural)
                {
                    xmlSubGroup.type = "structural";
                }
                else
                {
                    xmlSubGroup.type = "Data";
                }
                xmlSubGroup.identifierDisplay = clientSubGroup.Display;
                xmlSubGroup.action = CommonHelper.ToGovXmlAction(clientSubGroup.Action);

                if (clientSubGroup.Items != null)
                {
                    List<AdditionalItem> xmlItems = new List<AdditionalItem>();
                    foreach (var clientItem in clientSubGroup.Items)
                    {
                        xmlItems.Add(ASIHelper.ToXMLAdditionalItem(clientItem));
                    }

                    xmlSubGroup.additionalItems = new AdditionalItems();
                    xmlSubGroup.additionalItems.additionalItem = xmlItems.ToArray();
                }
            }

            return xmlSubGroup;
        }

        public static AdditionalItem ToXMLAdditionalItem(AdditionalItemModel clientItem)
        {
            AdditionalItem xmlItem = null;
            if (clientItem != null)
            {
                xmlItem = new AdditionalItem();
                xmlItem.val = clientItem.Value;
                xmlItem.keys = KeysHelper.CreateXMLKeys(clientItem.Identifier);
                xmlItem.identifierDisplay = clientItem.Display;
                xmlItem.name = clientItem.Name;
                //xmlItem.contextType = clientItem.ContextType;
                xmlItem.security = clientItem.Security;
                xmlItem.action = CommonHelper.ToGovXmlAction(clientItem.Action);
                xmlItem.dataType = new DataType();
                xmlItem.dataType.type = clientItem.Type;
                //here don't need pass enum to app server
                //xmlItem.dataType.enumerations = new Enumerations();
                xmlItem.dataType.inputRange = new Range();
                xmlItem.dataType.inputRange.minValue = clientItem.MinValue;
                xmlItem.dataType.inputRange.maxValue = clientItem.MaxValue;
                xmlItem.dataType.inputRequired = clientItem.InputRequired;

                xmlItem.drillDown = clientItem.IsDrillDown.ToString();

                if (clientItem.IsDrillDown)
                {
                    if (!String.IsNullOrEmpty(clientItem.ValueId))
                    {
                        var tmpValue = clientItem.ValueId.Split('-');

                        if (tmpValue != null
                            && tmpValue.Length == 2)
                        {
                            xmlItem.val = IdEscapeHelper.DecodeString(tmpValue[1]);
                        }
                    }
                }
            }

            return xmlItem;
        }

        public static AdditionalGroupModel ToClientAdditionalGroup(AdditionalInformationGroup xmlGroup)
        {
            AdditionalGroupModel clientGroup = null;
            if (xmlGroup != null)
            {
                clientGroup = new AdditionalGroupModel();
                clientGroup.Identifier = KeysHelper.ToStringKeys(xmlGroup.keys);
                clientGroup.Display = xmlGroup.identifierDisplay;
                clientGroup.Description = xmlGroup.description;

                clientGroup.Security = xmlGroup.security;

                if (xmlGroup.additionalInformationSubGroup != null)
                {
                    List<AdditionalSubGroupModel> clientSubGroups = new List<AdditionalSubGroupModel>();
                    foreach (var xmlSubGroup in xmlGroup.additionalInformationSubGroup)
                    {
                        clientSubGroups.Add(ASIHelper.ToClientAdditionalSubGroup(clientGroup.Identifier, xmlSubGroup));

                    }

                    clientGroup.SubGroups = clientSubGroups;
                }


            }

            return clientGroup;
        }

        public static AdditionalSubGroupModel ToClientAdditionalSubGroup(string groupKey, AdditionalInformationSubGroup xmlSubGroup)
        {
            AdditionalSubGroupModel clientSubGroup = null;
            if (xmlSubGroup != null)
            {
                clientSubGroup = new AdditionalSubGroupModel();
                clientSubGroup.Identifier = KeysHelper.ToStringKeys(xmlSubGroup.keys);
                clientSubGroup.Display = xmlSubGroup.identifierDisplay;

                clientSubGroup.Security = xmlSubGroup.security;

                clientSubGroup.Alias = xmlSubGroup.SubGroupAlias;

                if (xmlSubGroup.type != null && xmlSubGroup.type.ToLower() == "structural")
                {
                    clientSubGroup.IsStructural = true;
                }
                else
                {
                    clientSubGroup.IsStructural = false;
                }

                if (xmlSubGroup.additionalItems != null && xmlSubGroup.additionalItems.additionalItem != null)
                {
                    List<AdditionalItemModel> clientItems = new List<AdditionalItemModel>();
                    foreach (var xmlItem in xmlSubGroup.additionalItems.additionalItem)
                    {
                        clientItems.Add(ASIHelper.ToClientAdditionalItem(xmlItem));
                    }

                    clientSubGroup.Items = clientItems;
                }


                clientSubGroup.DrillDownSeries = ToClientDrillDown(xmlSubGroup.drillDown);

                List<string> drillDownList = new List<string>();
                List<string> drillDownParentList = new List<string>();
                List<string> drillDownChildList = new List<string>();
                List<string> drillDownRootList = new List<string>();

                if (xmlSubGroup.drillDown != null
                    && xmlSubGroup.drillDown.drillDownSeries != null
                    && xmlSubGroup.drillDown.drillDownSeries.Length > 0)
                {
                    foreach (var serie in xmlSubGroup.drillDown.drillDownSeries)
                    {
                        if (serie.parentRelation != null
                            && serie.childRelation != null)
                        {
                            var tmpParentKey = KeysHelper.ToStringKeys(serie.parentRelation.keys);

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

                            var tmpChildKey = KeysHelper.ToStringKeys(serie.childRelation.keys);

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
                }

                if (clientSubGroup.Items != null
                    && clientSubGroup.Items.Count > 0)
                {
                    foreach (var item in clientSubGroup.Items)
                    {
                        if (drillDownList.Contains(item.Identifier))
                        {
                            item.IsDrillDown = true;

                            if (drillDownRootList.Contains(item.Identifier))
                            {
                                item.IsDrillDownRoot = true;
                            }

                            // No need to encode the key for ASI.
                            item.DrillDownId = IdEscapeHelper.EncodeString(groupKey) + "-" + clientSubGroup.Identifier + "-" + item.Identifier;

                            if (!String.IsNullOrEmpty(item.Value))
                            {
                                if (clientSubGroup.DrillDownSeries != null)
                                {
                                    var tmpParentSerie = clientSubGroup.DrillDownSeries.Find(serie => serie.ParentRelation != null && serie.ParentRelation.Identifier == item.Identifier);

                                    if (tmpParentSerie != null)
                                    {
                                        if (tmpParentSerie.ParentRelation != null
                                            && tmpParentSerie.ParentRelation.Enumerations != null)
                                        {
                                            var tmpEscapeValue = IdEscapeHelper.EncodeString(item.Value);

                                            var tmpValue = tmpParentSerie.ParentRelation.Enumerations.Find(value => value.Identifier != null && value.Identifier.EndsWith(tmpEscapeValue));

                                            if (tmpValue != null)
                                            {
                                                item.Value = tmpValue.Display;
                                                item.ValueId = tmpValue.Identifier;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        var tmpChildSerie = clientSubGroup.DrillDownSeries.Find(serie => serie.ChildRelation != null && serie.ChildRelation.Identifier == item.Identifier);

                                        if (tmpChildSerie != null
                                            && tmpChildSerie.ChildRelation != null
                                            && tmpChildSerie.ChildRelation.Enumerations != null)
                                        {
                                            var tmpEscapeValue = IdEscapeHelper.EncodeString(item.Value);

                                            var tmpValue = tmpChildSerie.ChildRelation.Enumerations.Find(value => value.Identifier != null && value.Identifier.EndsWith(tmpEscapeValue));

                                            if (tmpValue != null)
                                            {
                                                item.Value = tmpValue.Display;
                                                item.ValueId = tmpValue.Identifier;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return clientSubGroup;
        }

        internal static List<AdditionalDrillDownSeriesModel> ToClientDrillDown(DrillDown drillDown)
        {
            if (drillDown != null)
            {
                var seriesModels = new List<AdditionalDrillDownSeriesModel>();
                if (drillDown.drillDownSeries != null)
                {

                    foreach (var series in drillDown.drillDownSeries)
                    {
                        seriesModels.Add(new AdditionalDrillDownSeriesModel
                                             {
                                                 ParentRelation = ToClientRelationship(series.parentRelation, true),
                                                 ChildRelation = ToClientRelationship(series.childRelation, false),
                                             });
                    }
                }

                return seriesModels;

            }
            return null;
        }

        internal static RelationshipModel ToClientRelationship(Relationship relationship, bool isParent)
        {
            if (relationship != null)
            {
                return new RelationshipModel()
                           {
                               Identifier = relationship.keys.ToStringKeys(),
                               Type = relationship.type,
                               Enumerations = ToClientDrillDownEnumerations(relationship.enumerations, isParent)
                           };
            }
            return null;
        }

        internal static List<DrillDownEnumerationModel> ToClientDrillDownEnumerations(DrillDownEnumerations drillDownEnumerations, bool isParent)
        {
            if (drillDownEnumerations != null && drillDownEnumerations.AMOEnumeration != null)
            {
                List<DrillDownEnumerationModel> models = new List<DrillDownEnumerationModel>();

                foreach (var enumeration in drillDownEnumerations.AMOEnumeration)
                {
                    var model = new DrillDownEnumerationModel()
                                    {
                                        Identifier = enumeration.keys.ToStringKeys(),
                                        Display = enumeration.identifierDisplay,
                                        Description = enumeration.description,
                                        EnumerationType = enumeration.enumerationType,
                                    };

                    if (isParent)
                    {
                        model.ChildLinks = ToClientDrillDownEnumerationLinks(enumeration.childValueKeys);
                    }
                    else
                    {
                        model.Link = enumeration.keys != null
                                     && enumeration.keys.key != null
                                     && enumeration.keys.key.Count() > 0
                                         ? enumeration.keys.key[0]
                                         : null;
                    }

                    models.Add(model);

                }
                return models;
            }

            return null;
        }

        private static List<DrillDownEnumerationLinkModel> ToClientDrillDownEnumerationLinks(Keys keys)
        {
            if (keys != null && keys.key != null)
            {
                List<DrillDownEnumerationLinkModel> models = new List<DrillDownEnumerationLinkModel>();
                foreach (var strKey in keys.key)
                {
                    models.Add(new DrillDownEnumerationLinkModel() { Link = strKey });
                }

                return models;
            }
            return null;
        }

        public static AdditionalItemModel ToClientAdditionalItem(AdditionalItem xmlItem)
        {
            AdditionalItemModel clientItem = null;
            if (xmlItem != null)
            {
                clientItem = new AdditionalItemModel();
                clientItem.Value = xmlItem.val;
                clientItem.Identifier = KeysHelper.ToStringKeys(xmlItem.keys);
                clientItem.Display = xmlItem.identifierDisplay;
                clientItem.Name = xmlItem.name;
                //this is request, need think it
                //xmlItem.contextType = clientItem.ContextType;
                clientItem.Security = xmlItem.security;

                if (xmlItem.dataType != null)
                {
                    clientItem.Type = xmlItem.dataType.fieldType;   //Gov xml begin to discard the data type field, use field type by default
                    if (string.IsNullOrEmpty(clientItem.Type))
                    {
                        clientItem.Type = xmlItem.dataType.type;    // AA 7.2 still uses type; backward compatibility
                    }
                    if (xmlItem.dataType.enumerations != null)
                    {
                        clientItem.Enumerations = ASITHelper.GetEnumerationLists(xmlItem.dataType.enumerations.AMOEnumeration);
                    }

                    if (xmlItem.dataType.inputRange != null)
                    {
                        clientItem.MaxValue = xmlItem.dataType.inputRange.maxValue;
                        clientItem.MinValue = xmlItem.dataType.inputRange.minValue;
                    }

                    clientItem.InputRequired = xmlItem.dataType.inputRequired;
                }

                clientItem.Value = xmlItem.val;

                if (!String.IsNullOrEmpty(xmlItem.drillDown))
                {
                    var upperDrillDown = xmlItem.drillDown.ToUpper();

                    if (upperDrillDown == "TRUE")
                    {
                        clientItem.IsDrillDown = true;
                    }
                }
            }

            return clientItem;
        }

        public static AdditionalResponse GetClientAdditionals(GetAdditionalInformationGroupsResponse response)
        {
            AdditionalResponse results = new AdditionalResponse();
            results.Additionals = new List<AdditionalGroupModel>();

            if (response.additionalInformation != null
                && response.additionalInformation.additionalInformationGroup != null)
            {
                foreach (var item in response.additionalInformation.additionalInformationGroup)
                {
                    AdditionalGroupModel group = ToClientAdditionalGroup(item);
                    if (group != null)
                    {
                        results.Additionals.Add(group);
                    }
                }
            }

            return results;
        }
    }
}
