#region Header

/**
* <pre>
*  Accela Citizen Access
*  File: ContactAddressPKModel.cs
*
*  Accela, Inc.
*  Copyright (C): 2011
*
*  Description: Contact Address PK model.
*
*  Notes:
* $Id: ContactAddressPKModel.cs 210786 2011-12-27 09:54:22Z ACHIEVO\daly.zeng $.
*  Revision History
*  Date,            Who,        What
*  Dec 5, 2011      Alan Hu     Initial.
* </pre>
*/

#endregion
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ContactAddressPKModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> addressID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
