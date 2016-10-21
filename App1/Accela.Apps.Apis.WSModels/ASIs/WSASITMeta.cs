using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// Additional table model.
    /// contains ASI/ASIT info.
    /// </summary>
    [DataContract(Name = "ASITDescribe")]
    public class WSASITDescribe
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 1)]
        public string Id { get; set; }

        [DataMember(Name = "subId", EmitDefaultValue = false, Order = 4)]
        public string SubId { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "display", EmitDefaultValue = false, Order = 2)]
        public string Display { get; set; }

        [DataMember(Name = "subDisplay", EmitDefaultValue = false, Order = 5)]
        public string SubDisplay { get; set; }

        /// <summary>
        /// Gets or sets the data columns.
        /// </summary>
        /// <value>
        /// The data columns.
        /// </value>
        [DataMember(Name = "columns", EmitDefaultValue = false, Order = 9)]
        public List<WSASIColumn> Columns
        {
            get;
            set;
        }        

        /// <summary>
        /// Gets or sets the security.
        /// Full: full access
        /// Readonly: readonly
        /// None: no access
        /// </summary>
        /// <value>
        /// The security.
        /// </value>
        [DataMember(Name = "security", EmitDefaultValue = false, Order = 3)]
        public string Security
        {
            get;
            set;
        }

        [DataMember(Name = "subSecurity", EmitDefaultValue = false, Order = 6)]
        public string SubSecurity
        {
            get;
            set;
        }

        /// <summary>
        /// context type
        /// </summary>
        /// <value>
        /// The type of the context.
        /// </value>
        [DataMember(Name = "contextType", EmitDefaultValue = false, Order = 8)]
        public string ContextType
        {
            get;
            set;
        }

        /// <summary>
        /// description
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 7)]
        public string Description
        {
            get;
            set;
        }

        public static WSASITDescribe FromWSASIT(WSASIT wsasit)
        {
            WSASITDescribe wsasitDescribe = null;
            if (wsasit != null)
            {
                wsasitDescribe = new WSASITDescribe();
                wsasitDescribe.Columns = wsasit.Columns;
                wsasitDescribe.ContextType = wsasit.ContextType;
                wsasitDescribe.Description = wsasit.Description;
                wsasitDescribe.Display = wsasit.Display;
                wsasitDescribe.Id = wsasit.Id;
                wsasitDescribe.Security = wsasit.Security;
                wsasitDescribe.SubDisplay = wsasit.SubDisplay;
                wsasitDescribe.SubId = wsasit.SubId;
                wsasitDescribe.SubSecurity = wsasit.SubSecurity;

            }
            return wsasitDescribe;
        }

        public static List<WSASITDescribe> FromWSASITs(List<WSASIT> wsasits)
        {
            var wsasitDescribes = new List<WSASITDescribe>();
            if (wsasits != null && wsasits.Count > 0)
            {
                foreach (var wsasit in wsasits)
                {
                    wsasitDescribes.Add(FromWSASIT(wsasit));
                }
            }
            return wsasitDescribes;

        }
              
    }
}
