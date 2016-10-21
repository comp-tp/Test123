using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.IO;

namespace Accela.Automation.CitizenServices.Client.Models.Request.Document
{
    [DataContract(Name = "DocumentModel")]
    public class CreateDocumentRequest
    {
        [DataMember]
        public string serviceProviderCode { get; set; }

        [DataMember]
        public string moduleName { get; set; }

        [DataMember]
        public string fileName { get; set; }

        [DataMember]
        public string entityID { get; set; }

        [DataMember]
        public string entityType { get; set; }

        [DataMember]
        public DocumentContentModel documentContent { get; set; }

        [DataMember]
        public CapID capID { get; set; }

        //public static CreateDocumentRequest FromEntityModel(CreateAttachmentRequest entityModel)
        //{
        //    if (entityModel != null)
        //    {
        //        string[] capIds = entityModel.EntityId.Split('-');
        //        return new CreateDocumentRequest()
        //        {
        //            EntityID = entityModel.EntityId,
        //            EntityType = entityModel.EntityType,
        //            FileName = entityModel.Attachment.FileName,
        //            ContentModel = new DocumentContentModel() { docContentStream = GetFileContent(entityModel.FileContent) },
        //            CapId = new CapID()
        //            {
        //                ID1 = capIds[0],
        //                ID2 = capIds[1],
        //                ID3 = capIds[2]
        //            }
        //        };
        //    }

        //    return null;
        //}

        private static byte[] GetFileContent(Stream stream)
        {
            if (stream != null)
            {
                stream.Position = 0;
                int streamLength = (int)stream.Length;
                var bytes = new byte[streamLength];
                stream.Read(bytes, 0, streamLength);
                string strBase64 = Convert.ToBase64String(bytes);
                return Convert.FromBase64String(strBase64);
            }

            return null;
        }
    }
}