using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels;

namespace Accela.Apps.Apis.WSModels
{
    [DataContract]
    public class WSAction : WSDataModel
    {
        public const string NORMAL = "Normal";
        public const string ADDED = "Added";
        public const string UPDATED = "Updated";
        public const string DELETED = "Deleted";

        /// <summary>
        /// The action have below value
        /// "" or "Normal"
        /// "Added"
        /// "Deleted"
        /// "Updated"
        /// </summary>
        [DataMember(Name = "action", EmitDefaultValue = false)]
        public string Action { get; set; }

        /// <summary>
        /// Convert ActionDataModel to WSAction.
        /// </summary>
        /// <param name="actionDataModel">ActionDataModel.</param>
        /// <returns>WSAction.</returns>
        public static WSAction FromEntityModel(ActionDataModel actionDataModel)
        {
            if (actionDataModel != null)
            {
                return new WSAction()
                {
                    Action = actionDataModel.Action
                };
            }

            return null;
        }

        /// <summary>
        /// Convert WSAction to ActionDataModel.
        /// </summary>
        /// <param name="wsAction">WSAction.</param>
        /// <returns>ActionDataModel.</returns>
        public ActionDataModel ToEnityModel(WSAction wsAction)
        {
            if (wsAction != null)
            {
                return new ActionDataModel()
                {
                    Action = wsAction.Action
                };
            }

            return null;
        }
    }
}
