/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: MessageModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class MessageModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string category { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayMessageIn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endEffectDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isRead { get; set; } 

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> messageID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string messageText { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string messageTitle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string messageType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string msgDept { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string msgStaff { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resMessageText { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> startEffectDate { get; set; }
    }
}