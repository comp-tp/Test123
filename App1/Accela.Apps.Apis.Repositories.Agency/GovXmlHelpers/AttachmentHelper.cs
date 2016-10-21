using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    /// <summary>
    /// attachment helper
    /// </summary>
    internal class AttachmentHelper : GovXmlHelperBase
    {
        public static string GetFileBase64String(Stream stream)
        {
            string result = String.Empty;

            if (stream != null)
            {
                stream.Position = 0;
                int streamLength = (int)stream.Length;
                var bytes = new byte[streamLength];
                stream.Read(bytes, 0, streamLength);
                result = Convert.ToBase64String(bytes);
            }

            return result;
        }

        public static AttachmentsResponse GetClientAttachments(GetDocumentListResponse xmlObj)
        {
            AttachmentsResponse results = null;
            List<Attachment> tempResults = null;

            if (xmlObj.documentSets != null && xmlObj.documentSets.documentSet != null && xmlObj.documentSets.documentSet[0].documents != null && xmlObj.documentSets.documentSet[0].documents.document != null && xmlObj.documentSets.documentSet[0].documents.document.Length > 0)
            {
                tempResults = new List<Attachment>();

                foreach (var document in xmlObj.documentSets.documentSet[0].documents.document)
                {
                    var attachment = GetResponsedAttachment(document);
                    tempResults.Add(attachment);
                }

                results = new AttachmentsResponse()
                {
                    Attachments = tempResults
                };
            }

            return results;
        }

        private static Attachment GetResponsedAttachment(Document xmlObj)
        {
            Attachment result = null;

            if (xmlObj != null)
            {
                result = new Attachment();
                result.Description = xmlObj.description;
                result.Identifier = xmlObj.Keys.ToStringKeys();

                if (xmlObj.documentLocators != null && xmlObj.documentLocators.electronicFileLocator != null)
                {
                    result.FileName = xmlObj.documentLocators.electronicFileLocator.fileName;

                    result.FileType = xmlObj.documentLocators.electronicFileLocator.fileType;

                    double fileSize = 0;

                    if (double.TryParse(xmlObj.documentLocators.electronicFileLocator.fileSize, out fileSize))
                    {
                        result.FileSize = (int)fileSize;
                    }
                }

                if (!String.IsNullOrEmpty(xmlObj.content))
                {
                    result.Content = xmlObj.content;
                }

                if (xmlObj.type != null
                    && xmlObj.type.keys != null)
                {
                    result.AttachmentType = KeysHelper.ToStringKeys(xmlObj.type.keys);
                }
            }
            return result;
        }

        public static Attachment GetClientAttachment(GetDocumentResponse getDocumentResponse)
        {
            Attachment result = null;

            if (getDocumentResponse != null
                && getDocumentResponse.document != null)
            {
                var tmpDocument = getDocumentResponse.document;

                result = new Attachment();
                result.Description = tmpDocument.description;
                result.Identifier = tmpDocument.Keys.ToStringKeys();

                if (tmpDocument.documentLocators != null && tmpDocument.documentLocators.electronicFileLocator != null)
                {
                    result.FileName = tmpDocument.documentLocators.electronicFileLocator.fileName;

                    result.FileType = tmpDocument.documentLocators.electronicFileLocator.fileType;

                    double fileSize = 0;

                    if (double.TryParse(tmpDocument.documentLocators.electronicFileLocator.fileSize, out fileSize))
                    {
                        result.FileSize = (int)fileSize;
                    }
                }

                if (!String.IsNullOrEmpty(tmpDocument.content))
                {
                    result.Content = tmpDocument.content;
                }

                if (tmpDocument.type != null
                    && tmpDocument.type.keys != null)
                {
                    result.AttachmentType = KeysHelper.ToStringKeys(tmpDocument.type.keys);
                }
            }

            return result;
        }

        public static Document GetXMLDocument(Attachment attachment, Stream stream)
        {
            Document document = new Document();

            int fileSize = (int)stream.Length;
            string fileBase64String = GetFileBase64String(stream);
            document.content = fileBase64String;

            document.documentLocators = new DocumentLocators();
            document.documentLocators.electronicFileLocator = new ElectronicFileLocator();
            document.documentLocators.electronicFileLocator.fileName = attachment.FileName;
            document.description = attachment.Description;
            document.documentLocators.electronicFileLocator.fileSize = fileSize.ToString(CultureInfo.InvariantCulture);

            return document;
        }

        public static CreateAttachmentResponse ToClientDocument(CreateDocumentResponse createDocumentResponse)
        {
            CreateAttachmentResponse result = new CreateAttachmentResponse();

            if (createDocumentResponse != null
                && createDocumentResponse.documentId != null
                && createDocumentResponse.documentId.keys != null)
            {
                result.Identifier = createDocumentResponse.documentId.keys.ToStringKeys();
            }

            return result;
        }

        public static DocumentTypesResponse ToClientDocumentType(GetDocumentGroupsResponse response)
        {
            if (response == null || response.DocumentGroups == null || response.DocumentGroups.DocumentGroup == null || response.DocumentGroups.DocumentGroup.Length == 0)
            {
                return null;
            }

            var result = new DocumentTypesResponse();

            if (response.system != null)
            {
                result.PageInfo = CommonHelper.GetPaginationFromSystem(response.system);
                result.Events = CommonHelper.GetClientEventMessage(response.system.eventMessages);
            }

            result.DocumentGroup = new List<DocumentGroupModel>();
            foreach (var DocumentGroup in response.DocumentGroups.DocumentGroup)
            {
                var documentGroupModel = new DocumentGroupModel();
                documentGroupModel.Identifier = DocumentGroup.keys.ToStringKeys();
                documentGroupModel.Dispaly = DocumentGroup.identifierDisplay;
                if (DocumentGroup.documentTypes != null
                    && DocumentGroup.documentTypes.DocumentType != null
                    && DocumentGroup.documentTypes.DocumentType.Length > 0)
                {
                    documentGroupModel.DocumentType = new List<DocumentTypeModel>();
                    foreach (var DocumentType in DocumentGroup.documentTypes.DocumentType)
                    {
                        DocumentTypeModel documentTypeModel = new DocumentTypeModel();
                        documentTypeModel.Identifier = KeysHelper.ToStringKeys(DocumentType.keys);
                        documentTypeModel.Display = DocumentType.identifierDisplay;
                        documentTypeModel.Download = DocumentType.autoDownload;
                        documentTypeModel.Description = DocumentType.description;
                        documentGroupModel.DocumentType.Add(documentTypeModel);
                    }

                }
                result.DocumentGroup.Add(documentGroupModel);
            }
            return result;
        }
    }
}
