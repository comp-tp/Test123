using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class ASIBusinessEntity : BusinessEntityBase, IASIBusinessEntity
    {
        public DrillDownValuesResponse GetASIDrilldownValue(string drillDownId, List<AdditionalGroupModel> asi)
        {
            DrillDownValuesResponse result = new DrillDownValuesResponse();
            string[] tmpIds = drillDownId.Split('-');

            if (tmpIds.Length == 3)
            {
                string groupId = tmpIds[0];
                string subGroupId = tmpIds[1];
                string fieldId = tmpIds[2];

                var tmpGroup = asi.Find(group => group.Identifier == groupId);

                if (tmpGroup != null
                    && tmpGroup.SubGroups != null)
                {
                    var tmpSubGroup = tmpGroup.SubGroups.Find(subGroup => subGroup.Identifier == subGroupId);

                    if (tmpSubGroup != null)
                    {
                        if (tmpSubGroup.DrillDownSeries != null
                            && tmpSubGroup.DrillDownSeries.Count > 0)
                        {
                            var tmpParentSerie = tmpSubGroup.DrillDownSeries.FindAll(serie => serie.ParentRelation != null && serie.ParentRelation.Identifier == fieldId);

                            if (tmpParentSerie != null
                                && tmpParentSerie.Count > 0)
                            {
                                result.ChildIds = new List<string>();

                                foreach (var child in tmpParentSerie)
                                {
                                    if (child.ChildRelation != null)
                                    {
                                        result.ChildIds.Add(child.ChildRelation.Identifier);
                                    }
                                }

                                result.Values = new List<DrillDownEnumerationModel>();

                                var tmpParent = tmpParentSerie[0];

                                if (tmpParent != null
                                    && tmpParent.ParentRelation != null
                                    && tmpParent.ParentRelation.Enumerations != null)

                                {
                                    foreach (var item in tmpParent.ParentRelation.Enumerations)
                                    {
                                        result.Values.Add(item);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public DrillDownValuesResponse GetASIDrilldownValueByParent(string drillDownId, string parentValueId, List<AdditionalGroupModel> asi)
        {
            DrillDownValuesResponse result = new DrillDownValuesResponse();

            string[] tmpIds = drillDownId.Split('-');

            if (tmpIds.Length == 3)
            {
                string groupId = tmpIds[0];
                string subGroupId = tmpIds[1];
                string fieldId = tmpIds[2];

                var tmpGroup = asi.Find(group => group.Identifier == groupId);

                if (tmpGroup != null
                    && tmpGroup.SubGroups != null)
                {
                    var tmpSubGroup = tmpGroup.SubGroups.Find(subGroup => subGroup.Identifier == subGroupId);

                    if (tmpSubGroup != null)
                    {
                        if (tmpSubGroup.DrillDownSeries != null
                            && tmpSubGroup.DrillDownSeries.Count > 0)
                        {
                            var tmpParentSerie = tmpSubGroup.DrillDownSeries.FindAll(serie => serie.ParentRelation != null && serie.ParentRelation.Identifier == fieldId);

                            if (tmpParentSerie != null
                                && tmpParentSerie.Count > 0)
                            {
                                result.ChildIds = new List<string>();

                                foreach (var child in tmpParentSerie)
                                {
                                    if (child.ChildRelation != null)
                                    {
                                        result.ChildIds.Add(child.ChildRelation.Identifier);
                                    }
                                }
                            }

                            var tmpChildSerie = tmpSubGroup.DrillDownSeries.Find(serie => serie.ChildRelation != null && serie.ChildRelation.Identifier == fieldId);

                            if (tmpChildSerie != null)
                            {
                                if (tmpChildSerie.ParentRelation != null
                                    && tmpChildSerie.ParentRelation.Enumerations != null
                                    && tmpChildSerie.ChildRelation != null
                                    && tmpChildSerie.ChildRelation.Enumerations != null)
                                {
                                    var tmpParentValue = tmpChildSerie.ParentRelation.Enumerations.Find(item => item.Identifier == parentValueId);

                                    if (tmpParentValue != null
                                        && tmpParentValue.ChildLinks != null
                                        && tmpParentValue.ChildLinks.Count > 0)
                                    {
                                        List<string> links = new List<string>();

                                        tmpParentValue.ChildLinks.ForEach(link => links.Add(link.Link));

                                        var tmpValues = tmpChildSerie.ChildRelation.Enumerations.FindAll(item => links.Contains(item.Link));

                                        if (tmpValues != null)
                                        {
                                            result.Values = new List<DrillDownEnumerationModel>();

                                            tmpValues.ForEach(item => result.Values.Add(item));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        public DrillDownValuesResponse GetASITDrilldownValue(string drillDownId, List<AdditionalTableModel> asit)
        {
            DrillDownValuesResponse result = new DrillDownValuesResponse();
            string[] tmpIds = drillDownId.Split('-');

            if (tmpIds.Length == 3)
            {
                string tableId = IdEscapeHelper.DecodeString(tmpIds[0]);
                string subId = tmpIds[1];
                string columnId = tmpIds[2];

                var tmpTable = asit.Find(table => table.Identifier == tableId);

                if (tmpTable != null
                    && tmpTable.DrillDownSeries != null)
                {
                    var tmpParentSerie = tmpTable.DrillDownSeries.FindAll(serie => serie.ParentRelation != null && serie.ParentRelation.Identifier == columnId);

                    if (tmpParentSerie != null
                        && tmpParentSerie.Count > 0)
                    {
                        result.ChildIds = new List<string>();

                        foreach (var serie in tmpParentSerie)
                        {
                            if (serie.ChildRelation != null)
                            {
                                result.ChildIds.Add(serie.ChildRelation.Identifier);
                            }
                        }

                        result.Values = new List<DrillDownEnumerationModel>();

                        var tmpParent = tmpParentSerie[0];

                        if (tmpParent != null
                            && tmpParent.ParentRelation != null)
                        {
                            foreach (var item in tmpParent.ParentRelation.Enumerations)
                            {
                                result.Values.Add(item);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public DrillDownValuesResponse GetASITDrilldownValueByParent(string drillDownId, string parentValueId, List<AdditionalTableModel> asit)
        {
            DrillDownValuesResponse result = new DrillDownValuesResponse();
            string[] tmpIds = drillDownId.Split('-');

            if (tmpIds.Length == 3)
            {
                string tableId = IdEscapeHelper.DecodeString(tmpIds[0]);
                string subId = tmpIds[1];
                string columnId = tmpIds[2];

                var tmpTable = asit.Find(table => table.Identifier == tableId);

                if (tmpTable != null
                    && tmpTable.DrillDownSeries != null)
                {
                    var tmpParentSerie = tmpTable.DrillDownSeries.FindAll(serie => serie.ParentRelation != null && serie.ParentRelation.Identifier == columnId);

                    if (tmpParentSerie != null
                        && tmpParentSerie.Count > 0)
                    {
                        result.ChildIds = new List<string>();

                        foreach (var serie in tmpParentSerie)
                        {
                            if (serie.ChildRelation != null)
                            {
                                result.ChildIds.Add(serie.ChildRelation.Identifier);
                            }
                        }
                    }

                    var tmpChildSerie = tmpTable.DrillDownSeries.Find(serie => serie.ChildRelation != null && serie.ChildRelation.Identifier == columnId);

                    if (tmpChildSerie != null)
                    {
                        if (tmpChildSerie.ParentRelation != null
                            && tmpChildSerie.ParentRelation.Enumerations != null
                            && tmpChildSerie.ChildRelation != null
                            && tmpChildSerie.ChildRelation.Enumerations != null)
                        {
                            var tmpParentValue = tmpChildSerie.ParentRelation.Enumerations.Find(item => item.Identifier == parentValueId);

                            if (tmpParentValue != null
                                && tmpParentValue.ChildLinks != null
                                && tmpParentValue.ChildLinks.Count > 0)
                            {
                                List<string> links = new List<string>();

                                tmpParentValue.ChildLinks.ForEach(link => links.Add(link.Link));

                                var tmpValues = tmpChildSerie.ChildRelation.Enumerations.FindAll(item => links.Contains(item.Link));

                                if (tmpValues != null)
                                {
                                    result.Values = new List<DrillDownEnumerationModel>();

                                    tmpValues.ForEach(item => result.Values.Add(item));
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }

}
