/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefExaminationAppTypePKModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 * 
 *  Description:
 *  XRefExaminationAppTypePKModel4WS model..
 * 
 *  Notes:
 * $Id: XRefExaminationAppTypePKModel4WS.cs 137738 2009-07-06 06:52:41Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XRefExaminationAppTypeModel4WS))]
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class XRefExaminationAppTypePKModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string category { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string group { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long refExamNbr { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool refExamNbrSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type { get; set; }
    }
}
