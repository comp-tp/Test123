#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AppSpecificTableGroupModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AppSpecificTableGroupModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [DataContract]
    public partial class AppSpecificTableGroupModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capIDModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AppSpecificInfoModel[] searchInfoModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AppSpecificTableGroupModelEntry[] tablesMap { get; set; }
    }
}
