//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accela.Infrastructure.Storage.SQLServer.Binary
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlobItem
    {
        public System.Guid Id { get; set; }
        public long RowNumber { get; set; }
        public System.Guid ContainerId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    
        public virtual BlobContainer BlobContainer { get; set; }
    }
}
