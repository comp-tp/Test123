/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AddressModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AddressModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    [DataContract]
    public partial class AddressModel : AddressBaseModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public DuplicatedAPOKeyModel[] duplicatedAPOKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> addressId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressType { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> displayParcelLink { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> distance { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberRangeEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberRangeStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> refAddressId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refAddressType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> secondaryRoadNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttributeModel[] templates { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitRangeEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitRangeStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> xcoordinator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> xcoordinatorEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> ycoordinator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> ycoordinatorEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayAddress
        {
            get;
            set;
        }
    }
}
