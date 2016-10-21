/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AppSpecificInfoGroupModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AppSpecificInfoGroupModel4WS.cs 213067 2012-02-08 01:21:12Z ACHIEVO\alan.hu $.
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
    
    
    
    public partial class AppSpecificInfoGroupModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkBoxDesc
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkBoxGroup
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string checkBoxInd
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int columnLayout
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string columnArrangement
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AppSpecificInfoModel4WS[] fields
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string instruction
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string labelDisplay
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resGroupName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resInstruction
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tableGroupName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupInstruction
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resGroupInstruction
        {
            get;
            set;
        }
    }
}
