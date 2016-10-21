/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapIDModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapIDModel4WS.cs 184822 2010-11-18 09:35:14Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class CapIDModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string customID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long trackingID { get; set; }

        /// <summary>
        /// overload equals method
        /// </summary>
        /// <param name="obj">CapIDModel4WS object</param>
        /// <returns>Boolean value.</returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (!(obj is CapIDModel4WS))
            {
                return false;
            }

            CapIDModel4WS capID = (CapIDModel4WS)obj;
            if ((this.id1 == null && capID.id1 != null) || (this.id1 != null && capID.id1 == null) || !this.id1.Equals(capID.id1) ||
                (this.id2 == null && capID.id2 != null) || (this.id2 != null && capID.id2 == null) || !this.id2.Equals(capID.id2) ||
                (this.id3 == null && capID.id3 != null) || (this.id3 != null && capID.id3 == null) || !this.id3.Equals(capID.id3) ||
                (this.serviceProviderCode == null && capID.serviceProviderCode != null) ||
                (this.serviceProviderCode != null && capID.serviceProviderCode == null) ||
                !this.serviceProviderCode.Equals(capID.serviceProviderCode))
            {
                return false;
            }

            return true;	
	    }

        /// <summary>
        /// Get Cap ID Model Key String
        /// </summary>
        /// <returns>key string</returns>
        public string toKey()
        {
            if (this.id1 == null)
            {
                return string.Empty;
            }
            else
            {
                return this.serviceProviderCode + "-" + this.id1 + "-" + this.id2 + "-" + this.id3;
            }
        }
    }
   
}
