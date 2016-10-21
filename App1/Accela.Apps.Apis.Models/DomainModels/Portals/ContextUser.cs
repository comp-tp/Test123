using System;
using Accela.Apps.Shared.DataModel;

// TODO:
// This class does not belong to this project.
// It comes from the User subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    public class ContextUser : IContextUser
    {
        public Guid Id { get; set; }

        /// <summary>
        /// agency display name.
        /// </summary>
        /// <remarks>
        /// e.g. Accela_Dev, Accela_Prod. After login, the value is set to servProvCode.
        /// in backend we always use servPorvCode as communication.
        /// </remarks>
        public string Agency { get; set; }
        public Guid AgencyID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public string Environment { get; set; }
        public string InspectorIdentifier { get; set; }

        public IContextUser Clone()
        {
            IContextUser user = new ContextUser();
            user.Agency = this.Agency;
            user.AgencyID = this.AgencyID;
            user.Environment = this.Environment;
            user.Id = this.Id;
            user.InspectorIdentifier = this.InspectorIdentifier;
            user.Language = this.Language;
            user.Password = this.Password;
            user.LoginName = this.LoginName;

            return user;
        } 

        /// <summary>
        /// Idicates whether the user has the claim. 
        /// </summary>
        /// <param name="claim">The claim to check.</param>
        /// <returns>true/false.</returns>
        public bool HasClaim(string claim)
        {
            bool isExist = true;

            return isExist;
        }
    }
}
