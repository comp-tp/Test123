/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EntityPKModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EntityPKModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NoticeConditionModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class EntityPKModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string key1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string key2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string key3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long seq1 { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool seq1Specified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long seq2 { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool seq2Specified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int entityType { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool entityTypeSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
