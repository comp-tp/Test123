using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract]
    public class WSInspector : WSDataModel
    {
        /// <summary>
        /// Gets or sets the inspector key.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the inspector.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public virtual string Display { get; set; }

        /// <summary>
        /// Convert WSInspector to InspectorModel.
        /// </summary>
        /// <param name="wsInspector">WSInspector.</param>
        /// <returns>InspectorModel.</returns>
        public static InspectorModel ToEntityModel(WSInspector wsInspector)
        {
            if (wsInspector != null)
            {
                return new InspectorModel()
                {
                    Identifier = wsInspector.Id,
                    Name = wsInspector.Display
                };
            };
            return null;
        }

        /// <summary>
        /// Convert WSInspector list to InspectorModel collection.
        /// </summary>
        /// <param name="wsInspectors">WSInspector list.</param>
        /// <returns>InspectorModel collection.</returns>
        public static List<InspectorModel> ToEntityModels(List<WSInspector> wsInspectors)
        {
            if (wsInspectors != null && wsInspectors.Count > 0)
            {
                var inspectorModels = new List<InspectorModel>();
                foreach (var wsInspector in wsInspectors)
                {
                    inspectorModels.Add(ToEntityModel(wsInspector));
                };
                return inspectorModels;
            }
            return null;
        }

        /// <summary>
        /// Convert WSInspector to InspectorModel.
        /// </summary>
        /// <param name="inspectorModel">InspectorModel.</param>
        /// <returns>WSInspector.</returns>
        public static WSInspector FromEntityModel(InspectorModel inspectorModel)
        {
            if (inspectorModel != null)
            {
                return new WSInspector()
                {
                    Id = inspectorModel.Identifier,
                    Display = inspectorModel.Name
                };
            }
            return null;
        }

        /// <summary>
        /// Convert InspectorModel list to WSInspector list.
        /// </summary>
        /// <param name="inspectorModels">InspectorModel list.</param>
        /// <returns>WSInspector list.</returns>
        public static List<WSInspector> FromEntityModels(List<InspectorModel> inspectorModels)
        {
            if (inspectorModels != null && inspectorModels.Count > 0)
            {
                var wsInspectors = new List<WSInspector>();
                foreach (var inspectorModel in inspectorModels)
                {
                    wsInspectors.Add(FromEntityModel(inspectorModel));
                };
                return wsInspectors;
            }
            return null;
        }
    }
}
