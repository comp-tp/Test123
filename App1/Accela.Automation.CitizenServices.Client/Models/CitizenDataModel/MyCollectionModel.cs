/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: MyCollectionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: MyCollectionModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class MyCollectionModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> capAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string collectionDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> collectionId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string collectionName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public MyCollectionSummaryModel myCollectionSummaryModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleCapModel[] simpleCapModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userId { get; set; }
    }
}
