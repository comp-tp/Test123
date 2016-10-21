using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;

namespace Accela.Apps.Apis.WSModels.Documents
{
    [DataContract(Name = "getDocumentsResponse")]
    public class WSDocumentsResponse : WSPagedResponse
    {
        [DataMember(Name = "documents", EmitDefaultValue = false)]
        public List<WSDocument> Documents { get; set; }

        public static WSDocumentsResponse FromEntityModel(AttachmentsResponse entityResponse)
        {
            if (entityResponse == null || entityResponse.Attachments == null || entityResponse.Attachments.Count == 0)
            {
                return new WSDocumentsResponse
                {
                };
            }

            WSDocumentsResponse response = new WSDocumentsResponse
            {
            };

            response.PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo);

            response.Documents = new List<WSDocument>();

            entityResponse.Attachments.ForEach(model => response.Documents.Add(WSDocument.FromEntityModel(model)));

            return response;
        }
    }
}
