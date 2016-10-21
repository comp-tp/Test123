using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;
using Accela.Apps.Shared.Utils;

namespace Accela.Apps.Apis.WSModels.RecordConditions
{
    [DataContract(Name = "condition")]
    public class WSCondition : WSEntityState
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the ConditionName.
        /// </summary>
        [DataMember(Name = "conditionName", EmitDefaultValue = false)]
        public string ConditionName { get; set; }

        /// <summary>
        /// Gets or sets the condition's description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the condition's description
        /// </summary>
        [DataMember(Name = "longDescription", EmitDefaultValue = false)]
        public string LongDescription { get; set; }

        /// <summary>
        /// Gets or sets the condition type
        /// </summary>
        [DataMember(Name = "conditionType", EmitDefaultValue = false)]
        public WSConditionType ConditionType { get; set; }

        /// <summary>
        /// Gets or sets the condition's apply date
        /// </summary>
        [DataMember(Name = "applyDate", EmitDefaultValue = false)]
        public string ApplyDate { get; set; }

        /// <summary>
        /// Gets or sets the expiration date
        /// </summary>
        [DataMember(Name = "expirationDate", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the effective date
        /// </summary>
        [DataMember(Name = "effectiveDate", EmitDefaultValue = false)]
        public string EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the condition status type
        /// </summary>
        [DataMember(Name = "conditionStatus", EmitDefaultValue = false)]
        public WSConditionStatus ConditionStatus { get; set; }

        /// <summary>
        /// Condition's Severity
        /// </summary>
        [DataMember(Name = "severityLevel", EmitDefaultValue = false)]
        public WSSeverity SeverityLevel { get; set; }

        /// <summary>
        /// Gets or sets the display condition notice
        /// </summary>
        [DataMember(Name = "displayConditionNotice", EmitDefaultValue = false)]
        public bool? DisplayConditionNotice { get; set; }

        /// <summary>
        /// Gets or sets whether or not include in condition name
        /// </summary>
        [DataMember(Name = "includeInConditionName", EmitDefaultValue = false)]
        public bool? IncludeInConditionName { get; set; }

        /// <summary>
        /// Gets or sets whether or not include in short description
        /// </summary>
        [DataMember(Name = "includeInShortDescription", EmitDefaultValue = false)]
        public bool? IncludeInShortDescription { get; set; }

        /// <summary>
        /// Gets or sets whether or not inheritable
        /// </summary>
        [DataMember(Name = "inheritable", EmitDefaultValue = false)]
        public bool? Inheritable { get; set; }

        /// <summary>
        /// Gets or sets public display message
        /// </summary>
        [DataMember(Name = "publicDisplayMessage", EmitDefaultValue = false)]
        public string PublicDisplayMessage { get; set; }

        /// <summary>
        /// Gets or sets resolution action
        /// </summary>
        [DataMember(Name = "resolutionAction", EmitDefaultValue = false)]
        public string ResolutionAction { get; set; }

        /// <summary>
        /// Gets or sets condition's short comment
        /// </summary>
        [DataMember(Name = "shortComment", EmitDefaultValue = false)]
        public string ShortComment { get; set; }

        /// <summary>
        /// Gets or sets condition's long comment
        /// </summary>
        [DataMember(Name = "longComment", EmitDefaultValue = false)]
        public string LongComment { get; set; }

        /// <summary>
        /// Gets or sets whether or not it is open condition
        /// </summary>
        [DataMember(Name = "openCondition", EmitDefaultValue = false)]
        public bool? OpenCondition { get; set; }

        /// <summary>
        /// Gets or sets condition's group
        /// </summary>
        [DataMember(Name = "conditionGroup", EmitDefaultValue = false)]
        public WSConditionGroup ConditionGroup { get; set; }

        /// <summary>
        /// Gets or sets the condition is read only
        /// </summary>
        [DataMember(Name = "readOnly", EmitDefaultValue = false)]
        public bool? ReadOnly { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The WSCondition models.</param>
        /// <returns>ConditionModel models.</returns>
        public static ConditionModel[] ToEntityModels(WSCondition[] wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Froms the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static WSCondition[] FromEntityModels(ConditionModel[] entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">WSCondition.</param>
        /// <returns>ConditionModel.</returns>
        public static ConditionModel ToEntityModel(WSCondition wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new ConditionModel()
            {
                Identifier = wsModel.Id,
                Display = wsModel.Display,
                ConditionName = wsModel.ConditionName,
                Description = wsModel.Description,
                LongDescription = wsModel.LongDescription,
                ConditionType = WSConditionType.ToEntityModel(wsModel.ConditionType),
                ApplyDate = wsModel.ApplyDate,
                ExpirationDate = wsModel.ExpirationDate,
                EffectiveDate = wsModel.EffectiveDate,
                ConditionStatus = WSConditionStatus.ToEntityModel(wsModel.ConditionStatus),
                SeverityLevel = WSSeverity.ToEntityModel(wsModel.SeverityLevel),
                DisplayConditionNotice = BoolHelper.ToBoolString(wsModel.DisplayConditionNotice, BoolHelper.BoolStringType.YOrN),
                IncludeInConditionName = BoolHelper.ToBoolString(wsModel.IncludeInConditionName, BoolHelper.BoolStringType.YOrN),
                IncludeInShortDescription = BoolHelper.ToBoolString(wsModel.IncludeInShortDescription, BoolHelper.BoolStringType.YOrN),
                Inheritable = BoolHelper.ToBoolString(wsModel.Inheritable, BoolHelper.BoolStringType.YOrN),
                PublicDisplayMessage = wsModel.PublicDisplayMessage,
                ResolutionAction = wsModel.ResolutionAction,
                ShortComment = wsModel.ShortComment,
                LongComment = wsModel.LongComment,
                OpenCondition = BoolHelper.ToBoolString(wsModel.OpenCondition, BoolHelper.BoolStringType.TrueOrFalse),
                ConditionGroup = WSConditionGroup.ToEntityModel(wsModel.ConditionGroup),
                ReadOnly = BoolHelper.ToBoolString(wsModel.ReadOnly, BoolHelper.BoolStringType.TrueOrFalse),
                Action = WSEntityState.ConvertEntityStateToAction(wsModel.EntityState)
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSCondition FromEntityModel(ConditionModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSCondition()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display,
                ConditionName = entityModel.ConditionName,
                Description = entityModel.Description,
                LongDescription = entityModel.LongDescription,
                ConditionType = WSConditionType.FromEntityModel(entityModel.ConditionType),
                ApplyDate = entityModel.ApplyDate,
                ExpirationDate = entityModel.ExpirationDate,
                EffectiveDate = entityModel.EffectiveDate,
                ConditionStatus = WSConditionStatus.FromEntityModel(entityModel.ConditionStatus),
                SeverityLevel = WSSeverity.FromEntityModel(entityModel.SeverityLevel),
                DisplayConditionNotice = BoolHelper.IsTrueString(entityModel.DisplayConditionNotice),
                IncludeInConditionName = BoolHelper.IsTrueString(entityModel.IncludeInConditionName),
                IncludeInShortDescription = BoolHelper.IsTrueString(entityModel.IncludeInShortDescription),
                Inheritable = BoolHelper.IsTrueString(entityModel.Inheritable),
                PublicDisplayMessage = entityModel.PublicDisplayMessage,
                ResolutionAction = entityModel.ResolutionAction,
                ShortComment = entityModel.ShortComment,
                LongComment = entityModel.LongComment,
                OpenCondition = BoolHelper.IsTrueString(entityModel.OpenCondition),
                ConditionGroup = WSConditionGroup.FromEntityModel(entityModel.ConditionGroup),
                ReadOnly = BoolHelper.IsTrueString(entityModel.ReadOnly),
                EntityState = ConvertActionToEntityState(entityModel.Action)
            };

            return result;
        }
    }
}
