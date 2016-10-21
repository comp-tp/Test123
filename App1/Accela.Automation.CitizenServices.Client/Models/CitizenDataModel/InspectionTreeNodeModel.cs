#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: InspectionTreeNodeModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 *
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class InspectionTreeNodeModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public InspectionTreeNodeModel[] children { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool firstChild { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public InspectionModel inspectionModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool lastChild { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int level { get; set; }
    }
}
