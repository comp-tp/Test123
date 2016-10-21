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
    
    public partial class GlobalEntity
    {
        public GlobalEntity()
        {
            this.GeoCoordinates = new HashSet<GeoCoordinate>();
            this.Images = new HashSet<Image>();
        }
    
        public System.Guid ID { get; set; }
        public string EntityID { get; set; }
        public string EntityType { get; set; }
        public string AgencyName { get; set; }
        public string Environment { get; set; }
        public string Status { get; set; }
        public Nullable<System.Guid> CloudUserID { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public string UDF4 { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<System.DateTime> OpenedDate { get; set; }
        public string AssignTo { get; set; }
        public int IsPrivate { get; set; }
    
        public virtual ICollection<GeoCoordinate> GeoCoordinates { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}