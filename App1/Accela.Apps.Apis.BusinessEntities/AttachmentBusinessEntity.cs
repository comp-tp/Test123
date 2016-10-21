using Accela.Apps.Apis.BusinessEntities.ImageHelpers;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.Contexts;
using System;
using System.Collections.Generic;
using System.IO;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class AttachmentBusinessEntity : IAttachmentBusinessEntity
    {
        #region Private Variables

        private IImageCache _imageCache;
        private IAgencyAppContext _context;

        #endregion


        public AttachmentBusinessEntity(IAttachmentRepository attachmentRepository, IImageCache imageCache, IAgencyAppContext context)
        {
            this.AttachmentRepository = attachmentRepository;
            this._imageCache = imageCache;
            this._context = context;

        }

        private readonly IAttachmentRepository AttachmentRepository;
        
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
        public AttachmentsResponse GetAttachments(AttachmentsRequest request)
        {
            return AttachmentRepository.GetAttachments(request);
        }

        /// <summary>
        /// Get the special attachment (included stream info)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AttachmentResponse GetAttachment(AttachmentRequest request)
        {
            var result = new AttachmentResponse();
            var attachment = AttachmentRepository.GetAttachment(request);
            var bytes = attachment != null && !String.IsNullOrEmpty(attachment.Content) ? Convert.FromBase64String(attachment.Content) : null;

            if (bytes != null)
            {
                var attachmentStream = new MemoryStream(bytes);
                result.FileContent = attachmentStream;
            }

            return result;
        }

        /// <summary>
        /// Get Attachment content
        /// </summary>
        /// <param name="request">AttachmentContentRequest object</param>
        /// <returns>
        /// return attachment content
        /// </returns>
        public AttachmentContentResponse GetAttachment(AttachmentContentRequest request)
        {
            var result = new AttachmentContentResponse();
            var attachment = AttachmentRepository.GetAttachmentContent(request);
            var bytes = attachment != null && !String.IsNullOrEmpty(attachment.Content) ? Convert.FromBase64String(attachment.Content) : null;

            if (bytes != null)
            {
                var attachmentStream = new MemoryStream(bytes);
                result.FileContent = attachmentStream;
            }

            return result;
        }

        /// <summary>
        /// Gets the inspetion attachment thumbnail.
        /// </summary>
        /// <param name="request">AttachmentThumbContentRequest object</param>
        /// <returns>
        /// the inspetion attachment thumb.
        /// </returns>
        public AttachmentContentResponse GetAttachmentThumbnail(AttachmentThumbContentRequest request)
        {
            var result = new AttachmentContentResponse();
            var attachment = GetAttachmentThumbnailContent(request);
            var bytes = attachment != null && !String.IsNullOrEmpty(attachment.Content) ? Convert.FromBase64String(attachment.Content) : null;

            if (bytes != null)
            {
                var attachmentStream = new MemoryStream(bytes);
                result.FileContent = attachmentStream;
            }

            return result;
        }

        public AttachmentContentV4Response GetAttachmentThumbnail(AttachmentThumbnailContentV4Request request)
        {
            var infoRequest = new AttachmentV4Request
            {
                AttachmentId = request.AttachmentId
            };

            var attachmentInfo = AttachmentRepository.GetAttachmentV4Info(infoRequest);

            if (!ImageHelper.IsSupportContentType(attachmentInfo.ContentType))
            {
                throw new BadRequestException("The given document format is not supported.", String.Empty, ErrorCodes.data_validation_error_400);
            }

            request.Attachment = attachmentInfo;

            return GetAttachmentThumbnailContent(request);
        }

        public AttachmentContentV4Response GetAttachmentThumbnailContent(AttachmentThumbnailContentV4Request request)
        {
            var cachedAttachment = _imageCache.GetAttachmentFileThumbnailInfo(request.Attachment.CacheKey, _context);

            if (cachedAttachment == null) return GenerateAndCacheThumbnailDocument(request);

            var attachment = _imageCache.GetAttachmentFileThumbnail(request.Attachment.CacheKey, _context);

            if (attachment != null)
            {
                return new AttachmentContentV4Response
                {
                    ContentType = cachedAttachment.FileType,
                    FileContent = attachment
                };
            }

            return GenerateAndCacheThumbnailDocument(request);
        }

        public Attachment GetAttachmentThumbnailContent(AttachmentThumbContentRequest request)
        {
            Attachment result = null;

            if (request != null)
            {
                var cachedAttachment = _imageCache.GetAttachmentFileThumbnailInfo(request.AttachmentId, _context);

                if (cachedAttachment != null)
                {
                    var memoryStream = _imageCache.GetAttachmentFileThumbnail(request.AttachmentId, _context);

                    if (memoryStream != null)
                    {
                        cachedAttachment.Content = memoryStream != null ? StreamHelper.GetFileBase64String(memoryStream) : String.Empty;
                        result = cachedAttachment;
                    }
                }

                if (result == null)
                {
                    var contentRequest = new AttachmentContentRequest()
                    {
                        AttachmentId = request.AttachmentId,
                        EntityId = request.EntityId,
                        EntityType = request.EntityType,
                    };

                    var attachment = AttachmentRepository.GetAttachmentContent(contentRequest);
                    var cloneAttachment = JsonConverter.CloneObject<Attachment>(attachment);
                    cloneAttachment.Content = ImageHelper.ConvertToThumbnailBase64String(attachment.FileName, attachment.Content, request.PixelWidth, request.PixelHeight);

                    //cache attachment
                    _imageCache.CacheAttachment(cloneAttachment, true, _context);

                    result = cloneAttachment;
                }
            }

            return result;
        }


        private AttachmentContentV4Response GenerateAndCacheThumbnailDocument(AttachmentThumbnailContentV4Request request)
        {
            var result = new AttachmentContentV4Response();

            var rawDocument = AttachmentRepository.GetRawDocumentContent(request.AttachmentId);
            if (rawDocument == null) return result;

            var thumbnailDocument = ImageHelper.ConvertToThumbnail(rawDocument, request.Attachment.ContentType, request.PixelWidth, request.PixelHeight);

            result.ContentType = request.Attachment.ContentType;
            result.FileContent = thumbnailDocument;

            var cachedObject = new Attachment
            {
                Identifier = request.Attachment.CacheKey,
                FileName = request.Attachment.FileName,
                FileType = request.Attachment.ContentType,
                Content = StreamHelper.GetFileBase64String(thumbnailDocument)
            };

            _imageCache.CacheAttachment(cachedObject, true, _context);

            return result;
        }

        public UploadAttachmentDescResponse UploadAttachmentDesc(UploadAttachmentDescRequest request)
        {
            var result = AttachmentRepository.UploadAttachmentDesc(request);
            return result;
        }

        /// <summary>
        /// Creates the attachment.
        /// </summary>
        /// <param name="attachmentRequest">Upload attachment request.</param>
        /// <param name="stream">Upload attachment data stream.</param>
        /// <returns>The attachment key.</returns>
        public string CreateAttachment(AttachmentUploadRequest attachmentRequest, MemoryStream stream)
        {
            var result = AttachmentRepository.CreateAttachment(attachmentRequest, stream);
            return result;
        }

        public CreateAttachmentResponse CreateAttachment(CreateAttachmentRequest request)
        {
            return AttachmentRepository.CreateAttachment(request);
        }
    }
}
