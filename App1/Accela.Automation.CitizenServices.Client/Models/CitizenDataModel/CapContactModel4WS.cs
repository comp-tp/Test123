/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapContactModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapContactModel4WS.cs 172912 2010-05-17 08:16:04Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class CapContactModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string componentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactOnSRChange { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PeopleModel4WS people { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string personType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refContactNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accessLevel
        {
            get;
            set;
        }
    }
}
