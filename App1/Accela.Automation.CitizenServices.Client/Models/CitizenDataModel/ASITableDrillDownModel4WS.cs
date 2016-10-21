/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ASITableDrillDownModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ASITableDrillDownModel4WS.cs 136284 2009-06-25 10:10:38Z ACHIEVO\jackie.yu $.
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
    
    [DataContract]
    
    
    
    public partial class ASITableDrillDownModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string applyTo
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispEntityKey2
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long drillId
        {
            get;
            set;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool drillIdSpecified
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string drillName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string drillType
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityKey1
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityKey2
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primaryFlag
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ASITableDrillDSeriesModel4WS[] seriesModelList
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode
        {
            get;
            set;
        }
    }
}
