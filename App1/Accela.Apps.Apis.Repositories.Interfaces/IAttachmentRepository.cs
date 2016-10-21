using System.IO;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IAttachmentRepository : IRepository
    {
        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the inspetion attachments
        /// </returns>
        AttachmentsResponse GetAttachments(AttachmentsRequest request);

        /// <summary>
        /// Gets the attachment.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the inspetion attachment.</returns>
        Attachment GetAttachmentContent(AttachmentContentRequest request);

        /// <summary>
        /// Creates the attachment.
        /// </summary>
        /// <param name="attachmentRequest">Upload attachment request.</param>
        /// <param name="stream">Upload attachment data stream.</param>
        /// <returns>The attachment key.</returns>
        string CreateAttachment(AttachmentUploadRequest attachmentRequest, MemoryStream stream);

        /// <summary>
        /// upload attachment desciption into cloud
        /// </summary>
        /// <param name="request">attachment description information</param>
        /// <returns>return keys</returns>
        UploadAttachmentDescResponse UploadAttachmentDesc(UploadAttachmentDescRequest request);

        /// <summary>
        /// Create Attachment 
        /// </summary>
        /// <param name="request">created request content</param>
        /// <returns>return file identifier</returns>
        CreateAttachmentResponse CreateAttachment(CreateAttachmentRequest request);

        /// <summary>
        /// Get the sepecial attachment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Attachment GetAttachment(AttachmentRequest request);

        /// <summary>
        /// V4
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AttachmentV4Model GetAttachmentV4Info(AttachmentV4Request request);

        /// <summary>
        /// V4
        /// </summary>
        /// <param name="attachmentId"></param>
        /// <returns></returns>
        Stream GetRawDocumentContent(string attachmentId);
    }
}
