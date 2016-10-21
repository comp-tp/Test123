/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SimpleCapModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SimpleCapModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class SimpleCapModel : CapPage4ACAModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PersonModel personModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AddressModel addressModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AddressModel[] addressModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string appTypeAlias { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string arabicTradeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capClass { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapDetailModel capDetailModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapTypeModel capType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string englishTradeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> fileDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GISObjectModel[] gisObjects { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ParcelInfoModel[] parcelModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string relatedTradeLic { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resCapStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] serviceNames { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string specialText { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int relatedRecordsCount
        {
            get;

            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PersonModel delegatePersonModel
        {
            get;
            set;
        }
    }
}
