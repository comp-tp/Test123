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
    
    public partial class ScopeGroup
    {
        public ScopeGroup()
        {
            this.Scope2Groups = new HashSet<Scope2Group>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    
        public virtual ICollection<Scope2Group> Scope2Groups { get; set; }
    }
}