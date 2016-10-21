using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using System.Collections.Generic;

namespace Accela.Apps.Apis.WSModels.Location
{
    [DataContract(Name = "gisObject")]
    public class WSGISObject : WSEntityState
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

        public static WSGISObject FromEntityModel(GISObjectModel gisObjectModel)
        {
            if (gisObjectModel != null)
            {
                return new WSGISObject()
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

        public static List<WSGISObject> FromEntityModels(List<GISObjectModel> gisObjectModels)
        {
            var wsGisObjects = new List<WSGISObject>();
            if (gisObjectModels != null && gisObjectModels.Count > 0)
            {
                gisObjectModels.ForEach(g => wsGisObjects.Add(FromEntityModel(g)));         
            }
            return wsGisObjects;
        }

        public static GISObjectModel ToEntityModel(WSGISObject wsObj)
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
