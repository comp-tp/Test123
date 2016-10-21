using System;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordsGeoSearchRequest : WSRequestBase
    {
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public WSRecordGeoFilter RecordFilter { get; set; }

        public static RecordsGeoRequest ToEntityModel(WSRecordsGeoSearchRequest wsRecordsGeoSearchRequest)
        {
            RecordsGeoRequest result = new RecordsGeoRequest();

            if (wsRecordsGeoSearchRequest != null
                && wsRecordsGeoSearchRequest.RecordFilter != null)
            {
                if (wsRecordsGeoSearchRequest.RecordFilter.BBoxValue != null)
                {
                    result.BBoxValue = new BBox()
                    {
                        XMin = wsRecordsGeoSearchRequest.RecordFilter.BBoxValue.XMin,
                        XMax = wsRecordsGeoSearchRequest.RecordFilter.BBoxValue.XMax,
                        YMin = wsRecordsGeoSearchRequest.RecordFilter.BBoxValue.YMin,
                        YMax = wsRecordsGeoSearchRequest.RecordFilter.BBoxValue.YMax
                    };
                }
                else
                {
                    if (wsRecordsGeoSearchRequest.RecordFilter.GeoCircle != null)
                    {
                        result.GeoCircle = new GeoCircle
                        {
                            CenterX = wsRecordsGeoSearchRequest.RecordFilter.GeoCircle.CenterX,
                            CenterY = wsRecordsGeoSearchRequest.RecordFilter.GeoCircle.CenterY,
                            Radius = wsRecordsGeoSearchRequest.RecordFilter.GeoCircle.Radius
                        };
                    }
                }

                //if (!String.IsNullOrWhiteSpace(wsRecordsGeoSearchRequest.RecordFilter.CivicId))
                if (wsRecordsGeoSearchRequest.RecordFilter.CivicId != Guid.Empty)
                {
                    result.CivicId = wsRecordsGeoSearchRequest.RecordFilter.CivicId;
                }
            }

            return result;
        }
    }
}
