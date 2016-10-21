/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: labelValueBean.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: labelValueBean.cs 130107 2009-05-11 12:23:56Z  
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://webservice.onlinePayment.cashier.finance.aa.accela.com")]
    public partial class LabelValueBean
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string label { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string value { get; set; }
    }

}
