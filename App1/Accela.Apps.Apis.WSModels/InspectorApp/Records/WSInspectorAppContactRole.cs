using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract]
    public class WSInspectorAppContactRole : WSIdentifierBase
    {
        /// <summary>
        /// Convert domain RecordIdModel to WSContactRole. 
        /// </summary>
        /// <param name="recordIdModel">RecordIdModel.</param>
        /// <returns>WSContactRole.</returns>
        public static WSInspectorAppContactRole FromEntityModel(ContactRoleModel contactRoleModel)
        {
            if (contactRoleModel != null)
            {
                return new WSInspectorAppContactRole()
                {
                    Id = contactRoleModel.Identifier,
                    Display = contactRoleModel.Display
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSContactRole to ContactRoleModel.
        /// </summary>
        /// <param name="wsContactRole">WSContactRole.</param>
        /// <returns>ContactRoleModel.</returns>
        public static ContactRoleModel ToEntityModel(WSInspectorAppContactRole wsContactRole)
        {
            if (wsContactRole != null)
            {
                return new ContactRoleModel()
                {
                    Identifier = wsContactRole.Id,
                    Display = wsContactRole.Display
                };
            }
            return null;
        }
    }
}
