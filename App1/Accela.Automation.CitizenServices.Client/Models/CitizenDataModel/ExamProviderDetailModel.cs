#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ExamProviderDetailModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExamProviderDetailModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    public class ExamProviderDetailModel : ProviderDetailModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string drivingDirections { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string handicapAccessibleDes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isHandicapAccessible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string supportedLanguages { get; set; }
    }
}
