/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ACAModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SimpleTaskItemModel4WS.cs 209458 2011-12-12 06:03:07Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using Accela.ACA.WSProxy.WSModel;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class SimpleTaskItemModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string PRelationID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string PTaskName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string g6StatDd { get; set; }

        /// <remarks/>
       [DataMember(EmitDefaultValue=false)]
        public string ga_fname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ga_lname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ga_mname { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TaskItemModel4WS[] historyTaskItems { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isMasterProcess { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isRestrictView4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string levelID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string proDes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string r1ProcessCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resPTaskName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resProDes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resSdAppDes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string restrictRole { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sdAppDes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sdChk1 { get; set; }

        /// <remarks/>
       [DataMember(EmitDefaultValue=false)]
        public string sdChk2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StandardCommentModel4WS[] standardComments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string stpNum { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TaskSpecificInfoModel4WS[] taskSpecItems { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public UserRolePrivilegeModel userRolePrivilegeModel { get; set; }

        [DataMember(EmitDefaultValue=false)]
        public string refActStatusFlag { get; set; }
    }

}
