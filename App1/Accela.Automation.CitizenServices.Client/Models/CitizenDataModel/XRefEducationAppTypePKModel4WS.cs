/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefEducationAppTypePKModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  XRefEducationAppTypePKModel4WS model..
 * 
 *  Notes:
 * $Id: XRefEducationAppTypePKModel4WS.cs 142354 2009-08-07 02:19:45Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XRefEducationAppTypeModel4WS))]
    
    [DataContract]
    
    
    
    public partial class XRefEducationAppTypePKModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string category
        { 
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string group
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long refEducationNbr
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subType
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type
        {
            get;
            set;
        }
    }
}
