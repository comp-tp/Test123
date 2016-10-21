using System;
//using Accela.Azure.Server.Toolkits.Persistences.DBAttribute;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    /// <summary>
    /// Attachments class
    /// </summary>
    [DataContract]
    public class Attachment : DataModel
    {
        #region Properties
        
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// This is primary keys in server side
        /// if the property is null or empty, the mean the record is created by client and it didn't sync to server yet.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        [DataMember(Name = "fileName", EmitDefaultValue = false)]
        public string FileName { get; set; }
        /// <summary>
        /// Gets or sets the file type.
        /// </summary>
        [DataMember(Name = "fileType", EmitDefaultValue = false)]
        public string FileType { get; set; }

        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        /// <value>
        /// The size of the file.
        /// </value>
        [DataMember(Name = "fileSize", EmitDefaultValue = false)]
        public int FileSize { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }

        public string AttachmentType { get; set; }

        #endregion Properties
    }
}