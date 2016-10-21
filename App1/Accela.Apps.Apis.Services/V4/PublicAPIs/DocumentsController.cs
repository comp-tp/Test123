using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;

using System.Web.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v4/documents")]
    public class DocumentsV4Controller : ControllerBase
    {
        /* 
         * ***** NOTICE *****
         *
         * The output returned doesn't have to be a serialized value but can also be raw data, like strings, binary data or stream.
         * So when downloading the binary file, we do not need to serialize the returned data.
         * Returns binary stream directly.
         *
        //*/

        [Route("{id}/thumbnail")]
        public HttpResponseMessage GetAttachmentThumbnail(string id, int pixelWidth = 0, int pixelHeight = 0)
        {
            var result = Request.CreateResponse(HttpStatusCode.OK);

            var attachmentThumbnailRequest = new AttachmentThumbnailContentV4Request()
            {
                AttachmentId = id,
                PixelWidth = pixelWidth,
                PixelHeight = pixelHeight
            };

            var response = this.ExcuteV1_2<AttachmentContentV4Response, AttachmentThumbnailContentV4Request>(
                (o) => AttachmentBussinessEntity.GetAttachmentThumbnail(o),
                attachmentThumbnailRequest);

            if (response.FileContent != null)
            {
                response.FileContent.Position = 0;
                result.Content = new StreamContent(response.FileContent);
                result.Content.Headers.ContentType = !String.IsNullOrEmpty(response.ContentType) ? new MediaTypeHeaderValue(response.ContentType) : new MediaTypeHeaderValue("application/octet-stream");
            }
            else
            {
                result.StatusCode = HttpStatusCode.NoContent;
            }

            return result;
        }
    }
}
