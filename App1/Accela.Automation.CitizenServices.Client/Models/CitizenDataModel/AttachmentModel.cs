#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: AttachmentModel.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 *
 *  Description:
 *
 *  Notes:
 * $Id: AttachmentModel.cs 144261 2009-08-26 10:23:37Z ACHIEVO\jackie.yu $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://model.webservice.accela.com")]
    public partial class AttachmentModel {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fileName
        {
            get;

            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fileType
        {
            get;

            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public byte[] attachmentContent
        {
            get;

            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID
        {
            get;

            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode
        {
            get;

            set;
        }
    }
}
