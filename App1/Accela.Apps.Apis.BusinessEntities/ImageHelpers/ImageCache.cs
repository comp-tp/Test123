using Accela.Apps.Apis.Common;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Repositories;
using Accela.Apps.Apis.Repositories.Agency;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Core.Ioc;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.DataModel;
using Accela.Apps.Shared.Toolkits.Encrypt;
using Accela.Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.BusinessEntities.ImageHelpers
{
    public class ImageCache : CacheBase, IImageCache, IBusinessEntity
    {
        private const string KEY_ONE_INSPECTION = "OneInspection";
        private const string KEY_ATTACHMENT_FILE_INFO = "AttachmentFileInfo";
        private const string KEY_ATTACHMENT_FILE_STREAM = "AttachmentFileStream";
        private const string KEY_ATTACHMENT_FILETHUMBNAIL_INFO = "AttachmentFileThumbnailInfo";
        private const string KEY_ATTACHMENT_FILETHUMBNAIL_STREAM = "AttachmentFileThumbnailStream";

        //private static IAgencyAppContext agencyAppContext = ServiceLocator.Resolve<IAgencyAppContext>();
        //private static readonly ImageCache instance = new ImageCache();

        private IMobileEntityRepository<Attachment> _attachmentMECache;
        private IBinaryStorage _binaryStorage;

        /// <summary>
        /// Inspection cache class's structor.
        /// </summary>
        public ImageCache(IMobileEntityRepository<Attachment> mobileEntityRep, IBinaryStorage binaryStorage)
            : base()
        {
            if(mobileEntityRep == null)
            {
                throw new ArgumentNullException("mobileEntityRep");
            }

            if (binaryStorage == null)
            {
                throw new ArgumentNullException("binaryStorage");
            }

            _attachmentMECache = mobileEntityRep;
            _binaryStorage = binaryStorage;
        }

        ///// <summary>
        ///// Get InpectionCache instance.
        ///// </summary>
        //public static ImageCache Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}

        /// <summary>
        /// Caches the attachment based on entity type.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="attachment">The attachment.</param>
        /// <param name="entityTypes">The entity types.</param>
        public void CacheAttachment(Attachment attachment, bool isThumbnail, IAgencyAppContext context)
        {
            if (attachment != null)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var entityType4Info = isThumbnail ? EntityTypes.AttachmentFileThumbnailInfo : EntityTypes.AttachmentFileInfo;
                        var cacheKey4Info = GetCacheKey(entityType4Info, attachment.Identifier);
                        DoCache(_attachmentMECache, entityType4Info, attachment, cacheKey4Info, context);
                        
                        var entityType4Stream = isThumbnail ? EntityTypes.AttachmentFileThumbnailStream : EntityTypes.AttachmentFileStream;
                        var cacheKey4Stream = GetCacheKey(entityType4Stream, attachment.Identifier);
                        DoCache(_attachmentMECache, entityType4Stream, attachment, cacheKey4Stream, context);

                        var scope4Stream = QueryHelpler.GetEntityScope(entityType4Stream, context);
                        var blobContainer = context.ContextUser.Id.ToString();
                        var blobName = _attachmentMECache.BuildBlobName(scope4Stream, MD5Helper.GetMd5Hash(cacheKey4Stream));
                        var bytes = !String.IsNullOrEmpty(attachment.Content) ? Convert.FromBase64String(attachment.Content) : null;

                        if (bytes != null)
                        {
                            var attachmentStream = new MemoryStream(bytes);

                            _binaryStorage.CreateNewOrUpdate(blobContainer, blobName, attachmentStream);
                            //BlobHelper helper = new BlobHelper(AzureConfiguration.GetStorageAccount(ConnectionStrings.ApiStorageSettingName));
                            //helper.UploadFromStream(blobContainer, blobName, attachmentStream);
                        }
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "InspectionCache.CacheAttachment");
                        }
                        catch { }
                    }
                });
            }
        }

        /// <summary>
        /// Gets the attachment file info.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the attachment file info.</returns>
        public Attachment GetAttachmentFileInfo(string attachmentId, IAgencyAppContext context)
        {
            try
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentFileInfo, context);
                var cacheKey = GetCacheKey(EntityTypes.AttachmentFileInfo, attachmentId);
                var cachedAttachment = _attachmentMECache.GetObjectById<Attachment>(scope, cacheKey);
                return cachedAttachment;
            }
            catch (Exception e)
            {
                // don't let cache blocks usage
                Log.Error(e, "ImageCache.GetCache");
                return null;
            }
        }

        /// <summary>
        /// Gets the attachment file.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the attachment file.</returns>
        public MemoryStream GetAttachmentFile(string attachmentId, IAgencyAppContext context)
        {
            MemoryStream memoryStream = null;

            try
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentFileStream, context);
                var cacheKey = GetCacheKey(EntityTypes.AttachmentFileStream, attachmentId);

                IContextUser user = context.ContextUser;
                var blobContainer = user != null && user.Id != null ? user.Id.ToString() : String.Empty;
                var blobName = _attachmentMECache.BuildBlobName(scope, MD5Helper.GetMd5Hash(cacheKey));

                //BlobHelper helper = new BlobHelper(AzureConfiguration.GetStorageAccount(ConnectionStrings.ApiStorageSettingName));

                if (!String.IsNullOrWhiteSpace(blobContainer) && !String.IsNullOrWhiteSpace(blobName))
                {
                    var stream = _binaryStorage.ReadAsStream(blobContainer, blobName);

                    if (stream != null)
                    {
                        memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);
                    }
                }
            }
            catch (Exception e)
            {
                // don't let cache blocks usage
                Log.Error(e, "ImageCache.GetCache");
            }

            return memoryStream;
        }

        /// <summary>
        /// Gets the attachment file thumbnail info.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the attachment file thumbnail info.</returns>
        public Attachment GetAttachmentFileThumbnailInfo(string attachmentId, IAgencyAppContext context)
        {
            try
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentFileThumbnailInfo, context);
                var cacheKey = GetCacheKey(EntityTypes.AttachmentFileThumbnailInfo, attachmentId);
                var cachedAttachment = _attachmentMECache.GetObjectById<Attachment>(scope, cacheKey);
                return cachedAttachment;
            }
            catch (Exception e)
            {
                // don't let cache blocks usage
                Log.Error(e, "ImageCache.GetCache");
                return null;
            }
        }

        /// <summary>
        /// Gets the attachment file thumbnail.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the attachment file thumbnail.</returns>
        public MemoryStream GetAttachmentFileThumbnail(string attachmentId, IAgencyAppContext context)
        {
            MemoryStream memoryStream = null;
            try
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentFileThumbnailStream, context);
                var cacheKey = GetCacheKey(EntityTypes.AttachmentFileThumbnailStream, attachmentId);

                IContextUser user = context.ContextUser;
                var blobContainer = user != null && user.Id != null ? user.Id.ToString() : String.Empty;
                var blobName = _attachmentMECache.BuildBlobName(scope, MD5Helper.GetMd5Hash(cacheKey));

                //BlobHelper helper = new BlobHelper(AzureConfiguration.GetStorageAccount(ConnectionStrings.ApiStorageSettingName));
                //var memoryStream = !String.IsNullOrWhiteSpace(blobContainer) && !String.IsNullOrWhiteSpace(blobName) ? helper.DownloadFromStream(blobContainer, blobName) : null;

                if (!String.IsNullOrWhiteSpace(blobContainer) && !String.IsNullOrWhiteSpace(blobName))
                {
                    var stream = _binaryStorage.ReadAsStream(blobContainer, blobName);

                    if (stream != null)
                    {
                        memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);
                    }
                }
            }
            catch (Exception e)
            {
                // don't let cache blocks usage
                Log.Error(e, "ImageCache.GetCache");
            }
            return memoryStream;
        }

        /// <summary>
        /// Gets the cache key.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="identifier">The identifier.</param>
        /// <returns>the cache key.</returns>
        private string GetCacheKey(EntityTypes entityType, string identifier)
        {
            string result = String.Empty;

            switch (entityType)
            {
                case  EntityTypes.Inspection:
                    result = String.Format("{0}_{1}", KEY_ONE_INSPECTION, identifier);
                    break;
                case EntityTypes.AttachmentFileInfo:
                    result = String.Format("{0}_{1}", KEY_ATTACHMENT_FILE_INFO, identifier);
                    break;
                case EntityTypes.AttachmentFileStream:
                    result = String.Format("{0}_{1}", KEY_ATTACHMENT_FILE_STREAM, identifier);
                    break;
                case EntityTypes.AttachmentFileThumbnailInfo:
                    result = String.Format("{0}_{1}", KEY_ATTACHMENT_FILETHUMBNAIL_INFO, identifier);
                    break;
                case EntityTypes.AttachmentFileThumbnailStream:
                    result = String.Format("{0}_{1}", KEY_ATTACHMENT_FILETHUMBNAIL_STREAM, identifier);
                    break;
                default:
                    result = identifier;
                    break;
            }

            return result;
        }

    }
}
