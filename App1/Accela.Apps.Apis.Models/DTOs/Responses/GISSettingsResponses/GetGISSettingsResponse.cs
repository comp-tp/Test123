/**
 * <pre>
 * 
 *  Accela Mobile Server
 *  File: GetGISSettingsResponse.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 *  
 * 
 *  Note
 *  Created By: carver li
 * </pre>
 */
using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using System;

namespace Accela.Apps.Apis.Models.DTOs.Responses.GISSettingsResponses
{
    [DataContract]
    [Serializable]
    public class GetGISSettingsResponse : ResponseBase
    {
        [DataMember(Name = "mapServices")]
        public List<MapServiceModel> MapServices { get; set; }

        [DataMember(Name = "parcelGISAttribute")]
        public ParcelGISAttributeModel ParcelGISAttribute { get; set; }

        [DataMember(Name = "geocodeRoutingSettings")]
        public GeocodeRoutingServiceSettings GeocodeRoutingSettings { get; set; }
    }
}
