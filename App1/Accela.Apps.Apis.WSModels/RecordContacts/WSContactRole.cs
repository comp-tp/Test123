using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.WSModels.RecordContacts
{
    [DataContract]
    public class WSContactRole: WSIdentifierBase
    {
        /// <summary>
        /// Convert domain RecordIdModel to WSContactRole. 
        /// </summary>
        /// <param name="recordIdModel">RecordIdModel.</param>
        /// <returns>WSContactRole.</returns>
        public static WSContactRole FromEntityModel(ContactRoleModel contactRoleModel)
        {
            if (contactRoleModel != null)
            {
                return new WSContactRole()
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
        public static ContactRoleModel ToEntityModel(WSContactRole wsContactRole)
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
