using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.Portals;

namespace Accela.Apps.Apis.WSModels.Agency
{
    [DataContract(Name = "agency")]
    public class WSAgency
    {
        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Service Provider Code
        /// </summary>
        [DataMember(Name = "serviceProviderCode", EmitDefaultValue = false)]
        public string ServiceProviderCode { get; set; }

        /// <summary>
        /// Enabled
        /// </summary>
        [DataMember(Name = "enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Agency full name.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Is Hosted ACA.
        /// </summary>
        [DataMember(Name = "hostedACA")]
        public bool HostedACA { get; set; }

        /// <summary>
        /// Is For Demo or QA Agency.
        /// </summary>
        [DataMember(Name="isForDemo")]
        public bool IsForDemo { get; set; }

        /// <summary>
        /// Icon name.
        /// </summary>
        [DataMember(Name = "iconName", EmitDefaultValue = false)]
        public string IconName { get; set; }

        public static List<WSAgency> FromEntitiesModel(List<AgencyModel> entities)
        {
            List<WSAgency> result = null;

            if (entities != null)
            {
                result = entities.Select(p => FromEntityModel(p)).ToList();
            }

            return result;
        }

        public static WSAgency FromEntityModel(AgencyModel entity)
        {
            WSAgency result = null;

            if (entity != null)
            {
                if(!string.IsNullOrEmpty(entity.IconName))
                {
                    entity.IconName = entity.IconName.Substring(entity.IconName.LastIndexOf("/") + 1);
                }

                result = new WSAgency()
                {
                    DisplayName = entity.DisplayName,
                    Enabled = entity.Enable,
                    HostedACA = entity.HostedACA,
                    IsForDemo =entity.IsForDemo,
                    IconName = entity.IconName,
                    Name = entity.Name,
                    ServiceProviderCode = entity.ServiceProviderCode
                };
            }

            return result;
        }
    }
}
