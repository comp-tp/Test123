using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Shared.APIHandlers;
using Accela.Infrastructure.Configurations;

using System.Web.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Accela.Apps.Apis.Services.V2.PrivateAPIs
{
    [RoutePrefix("v4/images")]
    [APIControllerInfoAttribute(Name = "ImageStorage", Description = "Image storage service.")]
    public class ImagesController : ControllerBase
    {

        private readonly IConfigurationReader configurationReader;
        public ImagesController(IConfigurationReader configurationReader)
        {
            this.configurationReader = configurationReader;
        }

        [HttpGet]
        [Route("{container}/{blobName}")]
        public async Task<Stream> DownloadImage(string container, string blobName)
        {
            var uri = new Uri(BuildBlobUrl(container, blobName));
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(ResponseHeaderConstants.X_Accela_Header_SubSystem_AccessKey, configurationReader.Get("InternalAPI_AccessKey"));
            var result = await httpClient.GetStreamAsync(uri);

            return result;
        }

        private string BuildBlobUrl(string container, string blobName)
        {
            var userServerUrl = configurationReader.Get("Ref_InternalAPI_User");
            var result = string.Format("{0}/images/{1}/{2}", userServerUrl, container, blobName);
            return result;
        }
    }
}
