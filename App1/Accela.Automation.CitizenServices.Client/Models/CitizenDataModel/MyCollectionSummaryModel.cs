/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: MyCollectionSummaryModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: MyCollectionSummaryModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class MyCollectionSummaryModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double feeDue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double feePaid { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int inspectionApproved { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int inspectionCanceled { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int inspectionDenied { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int inspectionPending { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int inspectionRescheduled { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int inspectionScheduled { get; set; }
    }
}
