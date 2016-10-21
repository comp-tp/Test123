using System;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IASIBusinessEntity : IBusinessEntity
    {
        DrillDownValuesResponse GetASIDrilldownValue(string drillDownId, List<AdditionalGroupModel> asi);
        
        DrillDownValuesResponse GetASIDrilldownValueByParent(string drillDownId, string parentValueId, List<AdditionalGroupModel> asi);
        
        DrillDownValuesResponse GetASITDrilldownValue(string drillDownId, List<AdditionalTableModel> asit);
        
        DrillDownValuesResponse GetASITDrilldownValueByParent(string drillDownId, string parentValueId, List<AdditionalTableModel> asit);
    }
}
