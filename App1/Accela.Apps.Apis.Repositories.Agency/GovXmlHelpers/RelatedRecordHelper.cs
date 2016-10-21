using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class RelatedRecordHelper
    {
        public static RelatedRecordModel ToClientRelatedRecord(CAPRelation xmlRelatedRecord)
        {
            RelatedRecordModel resultModel = null;

            if (xmlRelatedRecord != null)
            {
                resultModel = new RelatedRecordModel();

                resultModel.Id = KeysHelper.ToStringKeys(xmlRelatedRecord.capId.keys);

                resultModel.Relationship = xmlRelatedRecord.contextType;
            }

            return resultModel;
        }
    }
}
