using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Automation.CitizenServices.Client.Models;
using Accela.Automation.CitizenServices.Client.Models.Response.Document;

namespace Accela.Apps.Apis.Repositories.CitizenHelpers
{
    public class CitizenAttachmentHelper
    {
        public static Attachment ToEntityAttachment(GetDocumentContentResponse response)
        {
            if (response == null)
            { return null; }

            Attachment attachment = new Attachment()
            {
                FileName = response.result.fileName,
                FileType = response.result.docType,
                Content = response.result.documentContent.docContentStream
            };

            return attachment;
        }

        public static Attachment ToClientEntity(Accela.ACA.WSProxy.DocumentModel citizenDocumentModel)
        {
            Attachment attachment = null;
            if (citizenDocumentModel != null)
            {
                attachment = new Attachment();
                attachment.FileType = citizenDocumentModel.fileDbType;

                // We should use the document number to identify a document instead of file key
                // even if, in some agencies, they have the same value.
                //attachment.Identifier = citizenDocumentModel.fileKey;
                attachment.Identifier = citizenDocumentModel.documentNo.HasValue ? citizenDocumentModel.documentNo.ToString() : String.Empty;

                attachment.Description = citizenDocumentModel.docDescription;
                attachment.AttachmentType = citizenDocumentModel.docType;
                attachment.FileName = citizenDocumentModel.fileName;
                if (citizenDocumentModel.fileSize.HasValue)
                {
                    attachment.FileSize = (int)citizenDocumentModel.fileSize;
                }
            }

            return attachment;
        }

        public static AttachmentsResponse GetAttachmentsResponse(CitizenRecordDocumentsResponse citizenRecordDocumentsResponse)
        {
            var attachmentsResponse = new AttachmentsResponse();
            attachmentsResponse.Attachments = new List<Attachment>();
            if (citizenRecordDocumentsResponse != null && 
                citizenRecordDocumentsResponse.result != null && 
                citizenRecordDocumentsResponse.result.Count > 0)
            {                
                foreach (var attachement in citizenRecordDocumentsResponse.result)
                {
                    attachmentsResponse.Attachments.Add(ToClientEntity(attachement));
                }
            }
            return attachmentsResponse;
        }

    }
}
