/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EdmsPolicyModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EdmsPolicyModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{/// <remarks/>
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class EdmsPolicyModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string configuration { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data5 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool defaultRight { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool defaultRightSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool deleteRight { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool deleteRightSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool downloadRight { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool downloadRightSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long policySeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sourceName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool uploadRight { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool uploadRightSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool viewRight { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool viewRightSpecified { get; set; }
    }
    
}
