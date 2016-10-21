/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: JAXBUTModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: JAXBUTModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class JAXBUTModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> bigBoolean { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> bigDouble { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<float> bigFloat { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> bigInteger { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> bigLong { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool smallBoolean { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ushort smallChar { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double smallDouble { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public float smallFload { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int smallInt { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long smallLong { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> testDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] testList { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string noSetField
        {
            get;
            set;
        }
    }
}
