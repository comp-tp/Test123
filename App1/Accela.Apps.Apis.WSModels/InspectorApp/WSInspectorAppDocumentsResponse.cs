using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppDocumentsResponse:WSPagedResponse
    {
        [DataMember(Name = "documents", EmitDefaultValue = false)]
        public List<WSInspectorAppDocument> Documents { get; set; }

        public static WSInspectorAppDocumentsResponse FromEntityModel(AttachmentsResponse entityResponse)
        {
            if (entityResponse == null || entityResponse.Attachments == null || entityResponse.Attachments.Count == 0)
            {
                return new WSInspectorAppDocumentsResponse
                {
                };
            }

            WSInspectorAppDocumentsResponse response = new WSInspectorAppDocumentsResponse
            {
            };

            response.PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo);

            response.Documents = new List<WSInspectorAppDocument>();

            entityResponse.Attachments.ForEach(model => response.Documents.Add(WSInspectorAppDocument.FromEntityModel(model)));

            return response;
        }
    }
}
