using Accela.Apps.Apis.Models.DomainModels.GISModels;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract(Name = "gisObject")]
    public class WSGISObjectV4 : WSEntityState
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets layerId
        /// </summary>
        [DataMember(Name = "layerId", EmitDefaultValue = false)]
        public string LayerId
        {
            get;
            set;
        }

        /// <summary>
        ///Gets or sets mapService
        /// </summary>
        [DataMember(Name = "mapService", EmitDefaultValue = false)]
        public string MapService
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        [DataMember(Name = "featureId", EmitDefaultValue = false)]
        public string FeatureId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Feature Id Field Name
        /// </summary>
        [DataMember(Name = "featureIdFieldName", EmitDefaultValue = false)]
        public string FeatureIdFieldName
        {
            get;
            set;
        }

        public static WSGISObjectV4 FromEntityModel(GISObjectModel gisObjectModel)
        {
            if (gisObjectModel != null)
            {
                return new WSGISObjectV4()
                {
                    Id = gisObjectModel.Id,
                    LayerId = gisObjectModel.GISLayerId,
                    MapService = gisObjectModel.MapServiceId,
                    FeatureId = gisObjectModel.Display,
                    FeatureIdFieldName=gisObjectModel.FeatureIDFieldName,
                    EntityState = WSEntityState.ConvertActionToEntityState(gisObjectModel.Action)
                };
            }

            return null;
        }

        public static List<WSGISObjectV4> FromEntityModels(List<GISObjectModel> gisObjectModels)
        {
            var wsGisObjects = new List<WSGISObjectV4>();
            if (gisObjectModels != null && gisObjectModels.Count > 0)
            {
                gisObjectModels.ForEach(g => wsGisObjects.Add(FromEntityModel(g)));         
            }
            return wsGisObjects;
        }

        public static GISObjectModel ToEntityModel(WSGISObjectV4 wsObj)
        {
            GISObjectModel entityObj = null;
            if (wsObj != null)
            {
                entityObj = new GISObjectModel();
                entityObj.Id = wsObj.Id;
                entityObj.Display = wsObj.FeatureId;
                entityObj.MapServiceId = wsObj.MapService;
                entityObj.GISLayerId = wsObj.LayerId;
                entityObj.FeatureIDFieldName = wsObj.FeatureIdFieldName;
                entityObj.Action = WSEntityState.ConvertEntityStateToAction(wsObj.EntityState);
            }

            return entityObj;
        }
    }
}
