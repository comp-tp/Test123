using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.GeoRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Geo
{
    [DataContract]
    public class WSGetCoordinatesByAddressesRequest : RequestBase
    {
        [DataMember(Name = "records")]
        public WSGeoSingleLineItem[] records { get; set; }

        [DataMember(Name = "outSR")]
        public string OutSR { get; set; }

        [DataMember(Name = "cacheEnabled")]
        public bool CacheEnabled { get; set; }

        public static GeoGetCoordinatesByAddressesRequest ToEntityModel(WSGetCoordinatesByAddressesRequest model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new GeoGetCoordinatesByAddressesRequest();

            if (model.records != null && model.records.Length > 0)
            {
                var addresses = (from s in model.records
                                 select s.Attributes.SingleLineInput).ToArray();

                result.Addresses = addresses;
                result.OutSR = model.OutSR;
                result.CacheEnabled = model.CacheEnabled;
            }

            return result;
        }
    }
}
