/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ParcelInfoModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ParcelInfoModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ParcelInfoModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAddressModel[] addressLists { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public OwnerModel[] ownerLists { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public OwnerModel ownerModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XParOwnerModel parOwnerModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ParcelModel parcelModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAddressModel RAddressModel { get; set; }

        /// <summary>
        /// Row Index
        /// </summary>
        public int RowIndex
        {
            get;
            set;
        }
    }
}
