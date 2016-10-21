using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract]
    public class WSProjectInformation
    {
        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }

        [DataMember(Name = "recordType", EmitDefaultValue = false)]
        public string RecordType { get; set; }

        [DataMember(Name = "shortComments", EmitDefaultValue = false)]
        public string ShortComments { get; set; }

        public static List<WSProjectInformation> FromEntityModels(List<ProjectInformationModel> models)
        {
            List<WSProjectInformation> result = null;

            if (models != null && models.Count > 0)
            {
                result = models.Select(p => FromEntityModel(p)).ToList();
            }

            return result;
        }

        public static WSProjectInformation FromEntityModel(ProjectInformationModel model)
        {
            WSProjectInformation result = null;

            if (model != null)
            {
                result = new WSProjectInformation()
                {
                    RecordId = model.RecordId,
                    RecordType = model.RecordType,
                    ShortComments = model.ShortComments
                };
            }

            return result;
        }
    }
}
