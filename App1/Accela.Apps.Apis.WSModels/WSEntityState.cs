using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels;

namespace Accela.Apps.Apis.WSModels
{
    [DataContract]
    public class WSEntityState : WSDataModel
    {
        public const string UNCHANGED = "Unchanged";
        public const string ADDED = "Added";
        public const string MODIFIED = "Modified";
        public const string DELETED = "Deleted";
        public const string DETACHED = "Detached";


        /// <summary>
        /// The action have below value
        /// "" or "Normal"
        /// "Added"
        /// "Deleted"
        /// "Updated"
        /// </summary>
        [DataMember(Name = "entityState", EmitDefaultValue = false)]
        public string EntityState { get; set; }

        /// <summary>
        /// Convert ActionDataModel to WSEntityState.
        /// </summary>
        /// <param name="actionDataModel">ActionDataModel.</param>
        /// <returns>WSEntityState.</returns>
        public static WSEntityState FromEntityModel(ActionDataModel actionDataModel)
        {
            if (actionDataModel != null)
            {
                return new WSEntityState()
                {
                    EntityState = ConvertActionToEntityState(actionDataModel.Action)
                };
            }

            return null;
        }

        /// <summary>
        /// Convert Action to EntityState.
        /// </summary>
        /// <param name="actionName">ActionName.</param>
        /// <returns>EntityState name.</returns>
        public static string ConvertActionToEntityState(string actionName)
        { 
            switch(actionName)
            {
                case ActionDataModel.NORMAL : 
                    return WSEntityState.UNCHANGED;
                case ActionDataModel.ADDED :
                    return WSEntityState.ADDED;
                case ActionDataModel.UPDATED :
                    return WSEntityState.MODIFIED;
                case ActionDataModel.DELETED :
                    return WSEntityState.DELETED;
                default:
                    return WSEntityState.UNCHANGED;
            };
        }


        /// <summary>
        /// Convert WSEntityState to ActionDataModel.
        /// </summary>
        /// <param name="wsEntityState">WSEntityState.</param>
        /// <returns>ActionDataModel.</returns>
        public static ActionDataModel ToEnityModel(WSEntityState wsEntityState)
        {
            if (wsEntityState != null)
            {
                return new ActionDataModel()
                {
                    Action = ConvertEntityStateToAction(wsEntityState.EntityState)
                };
            }

            return null;
        }

        /// <summary>
        /// Convert EntityState to Action.
        /// </summary>
        /// <param name="entityStateName">EntityStateName.</param>
        /// <returns>Action.</returns>
        public static string ConvertEntityStateToAction(string entityStateName)
        {
            switch (entityStateName)
            {
                case WSEntityState.UNCHANGED:
                    return ActionDataModel.NORMAL;
                case WSEntityState.ADDED:
                    return ActionDataModel.ADDED;
                case WSEntityState.MODIFIED:
                    return ActionDataModel.UPDATED;
                case WSEntityState.DELETED:
                    return ActionDataModel.DELETED;
                default:
                    return ActionDataModel.NORMAL;
            };
        }

    }
}
