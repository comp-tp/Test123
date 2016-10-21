using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Resources;
using Accela.Apps.Apis.WSModels.Records;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    public delegate T ExcuteService<T, M>(M request)
        where T : ResponseBase
        where M : RequestBase;

    public delegate AttachmentContentResponse ExcuteServiceDownload<M>(M request)
        where M : RequestBase;

    public class ControllerBase : ApiController
    {

        private IAttachmentBusinessEntity _attachmentBusinessEntity;
        protected IAttachmentBusinessEntity AttachmentBussinessEntity
        {
            get
            {
                if (_attachmentBusinessEntity == null)
                {
                    //Dictionary<string, object> ctorParams = MakeConstructorParameters();
                    _attachmentBusinessEntity = IocContainer.Resolve<IAttachmentBusinessEntity>();
                }

                return _attachmentBusinessEntity;
            }
        }

        public ControllerBase()
        {

        }

        #region Propertis

        /// <summary>
        /// log the transaction log
        /// </summary>
        /// <param name="obj">object for log to</param>
        /// <param name="logName">log name, like Get Job List</param>
        protected void LogTranscation(object obj, string logName)
        {
            // TODO:
            // Changes the below code later.
            //if (Log.IsTransactionEnabled)
            //{
            //    string content = "";
            //    if (obj != null)
            //    {
            //        content = JsonConverter.ToJson(obj);
            //    }

            //    Log.Transaction(logName, content, "ServiceBase.LogTranscation");
            //}
        }

        /// <summary>
        /// Log service.
        /// </summary>
        /// <typeparam name="T">Response model.</typeparam>
        /// <typeparam name="M">Request model.</typeparam>
        /// <param name="action">Method.</param>
        /// <param name="request">Request model parameter.</param>
        /// <returns>Response object.</returns>
        protected T Excute<T, M>(ExcuteService<T, M> action, M request)
            where T : ResponseBase
            where M : RequestBase
        {
            T result = default(T);
            LogTranscation(request, "client_request_" + typeof(M).Name);

            if (action != null)
            {
                result = action(request);
            }

            LogTranscation(result, "client_response_" + typeof(T).Name);
            return result;
        }

        /// <summary>
        /// Log service.
        /// </summary>
        /// <typeparam name="T">Response model.</typeparam>
        /// <typeparam name="M">Request model.</typeparam>
        /// <param name="action">Method.</param>
        /// <param name="request">Request model parameter.</param>
        /// <returns>Response object.</returns>
        protected T ExcuteV1_2<T, M>(ExcuteService<T, M> action, M request)
            where T : ResponseBase, new()
            where M : RequestBase
        {
            T result = new T();
            LogTranscation(request, "client_request_" + typeof(M).Name);

            result.Error = new ErrorMessage();

            if (action != null)
            {
                result = action(request);
            }

            LogTranscation(result, "client_response_" + typeof(T).Name);

            return result;
        }

        /// <summary>
        /// Download attachment log service.
        /// </summary>
        /// <typeparam name="M">Request model.</typeparam>
        /// <param name="action">Download method.</param>
        /// <param name="request">Request model parameter.</param>
        /// <returns>Attachment data stream.</returns>
        protected AttachmentContentResponse Excute<M>(ExcuteServiceDownload<M> action, M request)
            where M : RequestBase
        {
            LogTranscation(request, "client_request_" + typeof(M).Name);
            if (action != null)
            {
                return action(request);
            }
            LogTranscation(null, "client_response_" + typeof(M).Name);
            throw new ArgumentNullException("Action can not be null.");
        }

        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        protected ILog Log
        {
            get
            {
                // It called ObjectFactory in the old DLL - Accela.Apps.Shared.dll
                //return ObjectFactory.GetLog();

                // TODO:
                // Remove the above code later.
                // Uses the new DLL
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        #endregion Propertis

        protected CreateAttachmentResponse UploadFile(string entityId, string entityType, string lang)
        {
            //try
            //{
            CreateAttachmentRequest request = null;

            // NOTE: System.Web.HttpContext.Current is null for async API
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new InvalidOperationException(MobileResources.GetString("document_upload_file_required"));
            }

            // http://stackoverflow.com/questions/15201255/request-content-readasmultipartasync-never-returns
            IEnumerable<HttpContent> parts = null;
            Task.Factory
                .StartNew(() => parts = Request.Content.ReadAsMultipartAsync().Result.Contents,
                    CancellationToken.None,
                    TaskCreationOptions.LongRunning, // guarantees separate thread
                    TaskScheduler.Default)
                .Wait();
            if (parts == null)
            {
                throw new InvalidOperationException(MobileResources.GetString("document_upload_file_required"));
            }

            string fileInfo = null;
            string fileName = null;
            Stream fileStream = null;
            foreach(var content in parts)
            {
                if ("fileInfo".Equals(content.Headers.ContentDisposition.Name) ||
                    "\"fileInfo\"".Equals(content.Headers.ContentDisposition.Name))
                {
                    var formData = content.ReadAsStringAsync().Result;
                    fileInfo = formData;
                }
                else
                {
                    fileStream = content.ReadAsStreamAsync().Result;
                    fileName = content.Headers.ContentDisposition.FileName;
                }
                if (fileInfo != null && fileStream != null) break;
            }

            if (fileStream == null)
            {
                throw new Exception(MobileResources.GetString("document_upload_file_required"));
            }

            if (!string.IsNullOrWhiteSpace(fileInfo))
            {
                request = JsonConverter.FromJsonTo<CreateAttachmentRequest>(fileInfo);
            }
            else
            {
                request = new CreateAttachmentRequest();
            }

            request.EntityId = entityId;
            request.EntityType = entityType;

            if (request.Attachment == null)
            {
                request.Attachment = new Attachment();
            }

            if (string.IsNullOrWhiteSpace(request.Attachment.FileName))
            {
                request.Attachment.FileName = fileName;
            }

            request.FileContent = fileStream;

            return ExcuteV1_2<CreateAttachmentResponse, CreateAttachmentRequest>((o) =>
            {
                return AttachmentBussinessEntity.CreateAttachment(o);
            }, request);
        }

        protected RangeParameter SplitRangeParameter(string rangeParameter)
        {
            if (!String.IsNullOrEmpty(rangeParameter))
            {
                RangeParameter rangePara = new RangeParameter();
                string[] rangeParaList = rangeParameter.Split('-');
                rangePara.From = rangeParaList[0];
                if (rangeParaList.Length > 1)
                {
                    rangePara.To = rangeParaList[1];
                }

                return rangePara;
            }
            else
            {
                return null;
            }
        }

        protected string[] SpliteDateRange(string dataRange)
        {
            string[] results = new string[2];

            if (!string.IsNullOrWhiteSpace(dataRange))
            {
                var dateRange = SplitRangeParameter(dataRange);

                CultureInfo enUS = new CultureInfo("en-US");

                string dateFormatForRange = "yyyyMMdd" ;
                string dateFormatForMeta = "yyyy-MM-dd";

                //string today = DateTime.Today.ToString(dateFormatForMeta);

                DateTime from = DateTime.Today;

                if (!string.IsNullOrWhiteSpace(dateRange.From))
                {
                    if (DateTime.TryParseExact(dateRange.From, dateFormatForRange, enUS, DateTimeStyles.None, out from))
                    {
                        results[0] = from.ToString(dateFormatForMeta);
                    }
                }

                DateTime to = DateTime.Today;

                if (!string.IsNullOrWhiteSpace(dateRange.To))
                {
                    if (DateTime.TryParseExact(dateRange.To, dateFormatForRange, enUS, DateTimeStyles.None, out to))
                    {
                        results[1] = to.ToString(dateFormatForMeta);
                    }
                }
            }

            return results;
        }

        protected List<string> GetReturnElements(string expand)
        {
            List<string> sysElements = new List<string>() { "Basic", "All", "Addresses", "Parcels", "Conditions/Holds", "Contacts", "AdditionalInformation", "GISObjects", "Costings", "Assets", "Parts", "Comments" };

            List<string> reqElements = SpliteIdsToList(expand);

            List<string> resElements = new List<string>();
            if (reqElements != null && reqElements.Count > 0)
            {
                foreach (var reqElement in reqElements)
                {
                    var resElement = sysElements.Find(e => e.Equals(reqElement, StringComparison.InvariantCultureIgnoreCase));
                    if (resElement != null)
                    {
                        resElements.Add(resElement);
                    }
                }
            }

            return resElements;
        }

        protected List<string> SpliteIdsToList(string ids)
        {
            List<string> retu = null;
            if (!string.IsNullOrWhiteSpace(ids))
            {
                retu = new List<string>();
                foreach (var id in ids.Split(",".ToCharArray()))
                {
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        retu.Add(id);
                    }
                }
            }

            return retu;
        }


        /// <summary>
        /// AMO StartRow begin from index 1  (whatever input 0/-1/-100/-232432), 
        /// so we ajust the index to avoid the data's duplicate.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        protected void SetPageRangeToRequest(RequestBase request, int offset, int limit)
        {
            request.Offset = offset < 0 ? 0 : offset;
            request.Limit = HandleDefaultLimitValue(limit);
        }

        private int HandleDefaultLimitValue(int limit)
        {
            int result = limit;

            if (limit <= 0)
            {
                result = 20;
            }
            if (limit >= 1000)
            {
                result = 1000;
            }
            return result;
        }

        public string ParseUID(string uid, IAgencyAppContext agencyContext)
        {
            string agencyName;
            string environmentName;
            string recordId = String.Empty;

            if (WSRecordBase.ParseUID(uid, out agencyName, out environmentName, out recordId))
            {
                agencyContext.Agency = agencyName;
                agencyContext.EnvName = environmentName;
                var agencySettingService = IocContainer.Resolve<Admin.Agency.Client.IAgencySettingsService>();
                var agencyModel = agencySettingService.GetAgency(agencyName);
                if (agencyModel != null && !String.IsNullOrEmpty(agencyModel.ServiceProviderCode))
                {
                    agencyContext.ServProvCode = agencyModel.ServiceProviderCode;
                }
            }

            return recordId;
        }
    }

    public class RangeParameter
    {
        public string From { get; set; }
        public string To { get; set; }
    }
}
