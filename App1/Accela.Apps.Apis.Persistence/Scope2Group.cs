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
    
    public partial class Scope2Group
    {
        public System.Guid ID { get; set; }
        public System.Guid GroupID { get; set; }
        public string ScopeName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    
        public virtual ScopeGroup ScopeGroup { get; set; }
    }
}