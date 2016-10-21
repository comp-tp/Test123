using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DTOs
{
    public class ContextParameter
    {
        /// <summary>
        /// Gets or sets AppId.
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets agency name.
        /// </summary>
        public string AgencyName { get; set; }

        /// <summary>
        /// Gets or set ServiceProvCode.
        /// </summary>
        public string ServiceProvCode { get; set; }

        /// <summary>
        /// Gets or sets Agency UserId.
        /// </summary>
        public string AgencyUserId { get; set; }

        /// <summary>
        /// Gets or sets Agency User Name.
        /// </summary>
        public string AgencyUserName { get; set; }

        /// <summary>
        /// Gets or sets Token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets Environment Name.
        /// </summary>
        public string EnvironmnetName { get; set; }

        /// <summary>
        /// Gets or sets Language.
        /// </summary>
        public string Language { get; set; }
    }
}
