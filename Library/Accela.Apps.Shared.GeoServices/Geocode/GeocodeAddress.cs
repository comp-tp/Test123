using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.GeoServices
{
    /// <summary>
    /// Geocode Address
    /// </summary>
    [DataContract]
    public class GeocodeAddress
    {
        /// <summary>
        /// Gets or sets the no.
        /// </summary>
        /// <value>
        /// The no.
        /// </value>
        [DataMember]
        public int No
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location X.
        /// </summary>
        /// <value>
        /// The location X.
        /// </value>
        [DataMember]
        public double LocationX
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the location Y.
        /// </summary>
        /// <value>
        /// The location Y.
        /// </value>
        [DataMember]
        public double LocationY
        {
            get;
            set;
        }
    }
}
