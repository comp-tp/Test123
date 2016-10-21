using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IASISecurityBusinessEntity : IBusinessEntity
    {
        void RemoveASIInvisableItems(List<AdditionalGroupModel> groups);

        void RemoveASITInvisableItems(List<AdditionalTableModel> tables);

        void AttachInvisableItemsForCreation(RecordTypeModel recordType, List<AdditionalGroupModel> asis, List<AdditionalTableModel> asits);

        void AttachInvisableItemsForUpdate(string recordId, List<AdditionalGroupModel> asis, List<AdditionalTableModel> asits);
    }
}
