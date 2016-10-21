using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.DataModel;
using Accela.Core.Logging;
using Accela.Apps.Shared.Toolkits.Encrypt;
using System.Threading.Tasks;
using Accela.Apps.Apis.Common;
using Accela.Core.Ioc;
using Accela.Infrastructure.Storage;
using Accela.Apps.Shared.Contexts;


namespace Accela.Apps.Apis.Repositories.Agency
{
    /// <summary>
    /// Inspection Cache Class.
    /// </summary>
    public sealed class InspectionCache : CacheBase
    {
        private const string KEY_ONE_INSPECTION = "OneInspection";
        private const string KEY_ATTACHMENT_FILE_INFO = "AttachmentFileInfo";
        private const string KEY_ATTACHMENT_FILE_STREAM = "AttachmentFileStream";
        private const string KEY_ATTACHMENT_FILETHUMBNAIL_INFO = "AttachmentFileThumbnailInfo";
        private const string KEY_ATTACHMENT_FILETHUMBNAIL_STREAM = "AttachmentFileThumbnailStream";

        //private static IAgencyAppContext agencyAppContext = ServiceLocator.Resolve<IAgencyAppContext>();
        private static readonly InspectionCache instance = new InspectionCache();

        private readonly IMobileEntityRepository<InspectionModel> _oneInspectionMECache;
        private readonly IMobileEntityRepository<Attachment> _attachmentMECache;
        private readonly IBinaryStorage _binaryStorage;

        /// <summary>
        /// Inspection cache class's structor.
        /// </summary>
        private InspectionCache(): base()
        {
            _oneInspectionMECache = IocContainer.Resolve<IMobileEntityRepository<InspectionModel>>();
            _attachmentMECache = IocContainer.Resolve<IMobileEntityRepository<Attachment>>();
            _binaryStorage = IocContainer.Resolve<IBinaryStorage>();
        }

        /// <summary>
        /// Get InpectionCache instance.
        /// </summary>
        public static InspectionCache Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Caches the job list related data.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="jobList">The job list.</param>
        public void CacheJobListRelatedData(List<InspectionModel> jobList, IAgencyAppContext agencyContext)
        {
            var watch = Reflection.Startwatch();

            if (jobList != null && jobList.Count > 0)
            {
                foreach (var inspection in jobList)
                {
                    CacheOneInspectionData(inspection, agencyContext);
                }
            }

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch), "Performance - CacheJobListRelatedData()");
        }

        /// <summary>
        /// Caches the one inspection data.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionModel">The inspection model.</param>
        public void CacheOneInspectionData(InspectionModel inspectionModel, IAgencyAppContext agencyContext)
        {
            if (inspectionModel != null)
            {
                var watch = Reflection.Startwatch();
                InspectionModel cloneInsp = Accela.Apps.Shared.JsonConverter.CloneObject<InspectionModel>(inspectionModel);
                
                // TODO:
                // Changed the below code later.
                //ObjectFactory.GetLog().Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch), "Performance - JsonConverter.CloneObject<InspectionModel>(inspectionModel)", "");
                //LogFactory.GetLog().Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch), "Performance - JsonConverter.CloneObject<InspectionModel>(inspectionModel)", "");

                //var clone = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        CacheOneInspection(cloneInsp, agencyContext);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            Log.Error(ex, "InspectionCache.CacheOneInspectionData");
                        }
                        catch { }
                    }
                //});
            }
        }

        /// <summary>
        /// Caches the attachment based on entity type.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="attachment">The attachment.</param>
        /// <param name="entityTypes">The entity types.</param>
        public void CacheAttachment(Attachment attachment, bool isThumbnail, IAgencyAppContext agencyContext)
        {
            if (attachment != null)
            {
                //var clone = Context.Clone();

                //Task.Factory.StartNew(() =>
                //{
                    try
                    {
                        //Context.SetContext(clone);
                        
                        var entityType4Info = isThumbnail ? EntityTypes.AttachmentFileThumbnailInfo : EntityTypes.AttachmentFileInfo;
                        var cacheKey4Info = GetCacheKey(entityType4Info, attachment.Identifier);
                        DoCache(_attachmentMECache, entityType4Info, attachment, cacheKey4Info, agencyContext);
                        
                        var entityType4Stream = isThumbnail ? EntityTypes.AttachmentFileThumbnailStream : EntityTypes.AttachmentFileStream;
                        var cacheKey4Stream = GetCacheKey(entityType4Stream, attachment.Identifier);
                        DoCache(_attachmentMECache, entityType4Stream, attachment, cacheKey4Stream, agencyContext);

                        var scope4Stream = QueryHelpler.GetEntityScope(entityType4Stream, agencyContext);
                        var blobContainer = agencyContext.ContextUser.Id.ToString();
                        var blobName = _attachmentMECache.BuildBlobName(scope4Stream, MD5Helper.GetMd5Hash(cacheKey4Stream));
                        var bytes = !String.IsNullOrEmpty(attachment.Content) ? Convert.FromBase64String(attachment.Content) : null;

                        if (bytes != null)
                        {
                            var attachmentStream = new MemoryStream(bytes);

                            //BlobHelper helper = new BlobHelper(AzureConfiguration.GetStorageAccount(ConnectionStrings.ApiStorageSettingName));
                            //helper.UploadFromStream(blobContainer, blobName, attachmentStream);
                            _binaryStorage.CreateNewOrUpdate(blobContainer, blobName, attachmentStream);
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
                //});
            }
        }

        /// <summary>
        /// Gets the attachment file info.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the attachment file info.</returns>
        public Attachment GetAttachmentFileInfo(string attachmentId, IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentFileInfo, agencyContext);
            var cacheKey = GetCacheKey(EntityTypes.AttachmentFileInfo, attachmentId);
            var cachedAttachment = _attachmentMECache.GetObjectById<Attachment>(scope, cacheKey);
            return cachedAttachment;
        }

        /// <summary>
        /// Gets the attachment file.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the attachment file.</returns>
        public MemoryStream GetAttachmentFile(string attachmentId, IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentFileStream, agencyContext);
            var cacheKey = GetCacheKey(EntityTypes.AttachmentFileStream, attachmentId);

            IContextUser user = agencyContext.ContextUser;
            var blobContainer = user != null && user.Id != null ? user.Id.ToString() : String.Empty;
            var blobName = _attachmentMECache.BuildBlobName(scope, MD5Helper.GetMd5Hash(cacheKey));

            //BlobHelper helper = new BlobHelper(AzureConfiguration.GetStorageAccount(ConnectionStrings.ApiStorageSettingName));
            //var memoryStream = !String.IsNullOrWhiteSpace(blobContainer) && !String.IsNullOrWhiteSpace(blobName) ? helper.DownloadFromStream(blobContainer, blobName) : null;
            MemoryStream memoryStream = null;

            if (!String.IsNullOrWhiteSpace(blobContainer) && !String.IsNullOrWhiteSpace(blobName))
            {
                var stream = _binaryStorage.ReadAsStream(blobContainer, blobName);

                if (stream != null)
                {
                    memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                }
            }

            return memoryStream;
        }

        /// <summary>
        /// Gets the attachment file thumbnail info.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the attachment file thumbnail info.</returns>
        public Attachment GetAttachmentFileThumbnailInfo(string attachmentId, IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentFileThumbnailInfo, agencyContext);
            var cacheKey = GetCacheKey(EntityTypes.AttachmentFileThumbnailInfo, attachmentId);
            var cachedAttachment = _attachmentMECache.GetObjectById<Attachment>(scope, cacheKey);
            return cachedAttachment;
        }

        /// <summary>
        /// Gets the attachment file thumbnail.
        /// </summary>
        /// <param name="attachmentId">The attachment id.</param>
        /// <returns>the attachment file thumbnail.</returns>
        public MemoryStream GetAttachmentFileThumbnail(string attachmentId, IAgencyAppContext agencyContext)
        {
            var scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentFileThumbnailStream, agencyContext);
            var cacheKey = GetCacheKey(EntityTypes.AttachmentFileThumbnailStream, attachmentId);

            IContextUser user = agencyContext.ContextUser;
            var blobContainer = user != null && user.Id != null ? user.Id.ToString() : String.Empty;
            var blobName = _attachmentMECache.BuildBlobName(scope, MD5Helper.GetMd5Hash(cacheKey));

            //BlobHelper helper = new BlobHelper(AzureConfiguration.GetStorageAccount(ConnectionStrings.ApiStorageSettingName));
            //var memoryStream = !String.IsNullOrWhiteSpace(blobContainer) && !String.IsNullOrWhiteSpace(blobName) ? helper.DownloadFromStream(blobContainer, blobName) : null;
            MemoryStream memoryStream = null;

            if (!String.IsNullOrWhiteSpace(blobContainer) && !String.IsNullOrWhiteSpace(blobName))
            {
                var stream = _binaryStorage.ReadAsStream(blobContainer, blobName);

                if (stream != null)
                {
                    memoryStream = new MemoryStream();
                    stream.CopyTo(memoryStream);
                }
            }

            return memoryStream;
        }

        /// <summary>
        /// Updates the inspection related data.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionModel">The inspection model.</param>
        public void UpdateInspectionRelatedData(InspectionModel inspectionModel, IAgencyAppContext agencyContext)
        {
            if (inspectionModel != null)
            {
                CacheOneInspection(inspectionModel, agencyContext);
            }
        }

        /// <summary>
        /// Gets the inspection.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionIdentifier">The inspection identifier.</param>
        /// <returns>the inspection model.</returns>
        public InspectionModel GetInspection(EntityTypes entityType, string inspectionIdentifier, IAgencyAppContext agencyContext)
        {
            InspectionModel result = null;

            if (agencyContext.ContextUser != null && !String.IsNullOrWhiteSpace(inspectionIdentifier))
            {
                var scope = QueryHelpler.GetEntityScope(entityType, agencyContext);
                var cacheKey = this.GetCacheKey(EntityTypes.Inspection, inspectionIdentifier);
                result = _oneInspectionMECache.GetObjectById<InspectionModel>(scope, cacheKey);
            }

            return result;
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

        /// <summary>
        /// Caches the job list.
        /// </summary>
        /// <param name="cloudUser">current cloud user.</param>
        /// <param name="jobList">The job list.</param>
        private void CacheOneInspection(InspectionModel insp, IAgencyAppContext agencyContext)
        {
            if (insp != null)
            {
                var scope = QueryHelpler.GetEntityScope(EntityTypes.Inspection, agencyContext);
                var cacheKey = this.GetCacheKey(EntityTypes.Inspection, insp.Identifier);
                var cacheData = Accela.Apps.Shared.JsonConverter.ToJson(insp);
                var entity = this.BuildMobileEntity(scope, cacheKey, cacheData);
                this._oneInspectionMECache.DeleteEntity(entity);
                this._oneInspectionMECache.InsertEntity(entity);
            }
        }
    }
}