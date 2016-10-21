using System.IO;
using System.Net;
using System.Net.Http;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Apis.Services.Handlers.Models;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/documents")]
    [APIControllerInfoAttribute(Name = "Documents", Group = "Entities", Order = 12, Description = "The following APIs are exposed to documents.")]
    public class DocumentsController : ControllerBase
    {
        /* 
        // ***** NOTICE *****
        //
        // The output returned doesn't have to be a serialized value but can also be raw data, like strings, binary data or stream.
        // So when downloading the binary file, we do not need to serialize the returned data.
        // Returns binary stream directly.
        //
        // ***** NOTICE ***** 
        */

        [Route("{id}")]
        [APIActionInfoAttribute(Name = "Download Attachment", Scope = "get_document", Order=2, Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Downloads an attachment with the attachment ID.")]
        public HttpResponseMessage GetAttachmentContent(string id, string token = null)
        {
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);

            var attachmentContentRequest = new AttachmentContentRequest()
            {
                AttachmentId = id
            };

            var response = this.ExcuteV1_2<AttachmentContentResponse, AttachmentContentRequest>(
                (o) =>
                {
                    return AttachmentBussinessEntity.GetAttachment(o);
                },
                attachmentContentRequest);

            if (response.Error == null)
            {
                if (response.FileContent != null)
                {
                    response.FileContent.Position = 0;
                }

                result.Content = new StreamContent(response.FileContent);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            }
            else
            {
                string error = JsonConverter.ToJson(response);

                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Content = new StringContent(error);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            return result;
        }

        [Route("{id}/thumbnail")]
        [APIActionInfoAttribute(Name = "Download Image Thumbnail", Scope = "get_thumbnail", Order=3, Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Downloads an image thumbnail given the attachment ID and the width and height of the thumbnail. Returns an error message if the attachment is not an image.")]
        public HttpResponseMessage GetAttachmentThumbnail(string id, int pixelWidth = 0, int pixelHeight = 0)
        {
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);

            var attachmentThumbRequest = new AttachmentThumbContentRequest()
            {
                AttachmentId = id,
                PixelWidth = pixelWidth,
                PixelHeight = pixelHeight
            };

            var response = this.ExcuteV1_2<AttachmentContentResponse, AttachmentThumbContentRequest>(
                (o) =>
                {
                    return AttachmentBussinessEntity.GetAttachmentThumbnail(o);
                },
                attachmentThumbRequest);

            if (response.Error == null && response.FileContent != null)
            {
                response.FileContent.Position = 0;

                result.Content = new StreamContent(response.FileContent);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            }
            else
            {
                string error = JsonConverter.ToJson(response);

                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Content = new StringContent(error);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            }

            return result;
        }
    }
}
