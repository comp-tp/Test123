using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract]
    public class WSInspectorAppSeverity : WSIdentifierBase
    {
        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">WSInspectorAppSeverity.</param>
        /// <returns>SeverityModel.</returns>
        public static SeverityModel ToEntityModel(WSInspectorAppSeverity wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new SeverityModel()
            {
                Identifier = wsModel.Id,
                Display = wsModel.Display
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSInspectorAppSeverity FromEntityModel(SeverityModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSInspectorAppSeverity()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display
            };

            return result;
        }
    }
}
