/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefEducationAppTypeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  XRefEducationAppTypeModel4WS model..
 * 
 *  Notes:
 * $Id: XRefEducationAppTypeModel4WS.cs 152236 2009-10-21 08:41:31Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class XRefEducationAppTypeModel4WS : XRefEducationAppTypePKModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string required
        {
            get;
            set;
        }
    }
}
