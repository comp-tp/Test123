using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using System.IO;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IAttachmentBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Gets the inspetion attachments.
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
        /// get the special attachment(included the stream info)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AttachmentResponse GetAttachment(AttachmentRequest request);

        /// <summary>
        /// Gets the inspetion attachment.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>
        /// the inspetion attachment.
        /// </returns>
        AttachmentContentResponse GetAttachment(AttachmentContentRequest request);

        /// <summary>
        /// Upload attachment desc
        /// </summary>
        /// <param name="desc">desc of file</param>
        /// <param name="inspectionId">inspection id that the attachment belong to</param>
        /// <param name="fileName">attachment file name</param>
        /// <returns>return upload attachment response</returns>
        UploadAttachmentDescResponse UploadAttachmentDesc(UploadAttachmentDescRequest request);

        /// <summary>
        /// Creates the attachment.
        /// </summary>
        /// <param name="attachmentRequest">Upload attachment request.</param>
        /// <param name="stream">Upload attachment data stream.</param>
        /// <returns>The attachment key.</returns>
        string CreateAttachment(AttachmentUploadRequest attachmentRequest, MemoryStream stream);

        /// <summary>
        /// Create Attachment 
        /// </summary>
        /// <param name="request">created request content</param>
        /// <returns>return file identifier</returns>
        CreateAttachmentResponse CreateAttachment(CreateAttachmentRequest request);

        /// <summary>
        /// Gets the inspetion attachment thumbnail.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="attachmentId">The attachment id.</param>
        /// <param name="pixelWidth">The pixel width.</param>
        /// <param name="pixelHeight">The pixel height.</param>
        /// <returns>
        /// the inspetion attachment thumb.
        /// </returns>
        AttachmentContentResponse GetAttachmentThumbnail(AttachmentThumbContentRequest request);

        AttachmentContentV4Response GetAttachmentThumbnail(AttachmentThumbnailContentV4Request request);
    }
}
