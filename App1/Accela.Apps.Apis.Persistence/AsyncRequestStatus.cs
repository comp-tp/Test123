//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accela.Apps.Apis.Persistence
{
    using System;
    using System.Collections.Generic;
    
    public partial class AsyncRequestStatus
    {
        public string RequestID { get; set; }
        public string Status { get; set; }
        public string HttpMethod { get; set; }
        public string RequestUrl { get; set; }
        public string RequestDataBlobUrl { get; set; }
        public string ResponseDataBlobUrl { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    }
}
