using Accela.Apps.Shared.Contexts;
using System;
namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IImageCache
    {
        void CacheAttachment(Accela.Apps.Apis.Models.DomainModels.ReferenceModels.Attachment attachment, bool isThumbnail, IAgencyAppContext context);
        System.IO.MemoryStream GetAttachmentFile(string attachmentId, IAgencyAppContext context);
        Accela.Apps.Apis.Models.DomainModels.ReferenceModels.Attachment GetAttachmentFileInfo(string attachmentId, IAgencyAppContext context);
        System.IO.MemoryStream GetAttachmentFileThumbnail(string attachmentId, IAgencyAppContext context);
        Accela.Apps.Apis.Models.DomainModels.ReferenceModels.Attachment GetAttachmentFileThumbnailInfo(string attachmentId, IAgencyAppContext context);
    }
}
