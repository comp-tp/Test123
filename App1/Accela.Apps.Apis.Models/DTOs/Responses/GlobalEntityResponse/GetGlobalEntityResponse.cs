using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.GlobalEntityModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.GlobalEntityResponse
{
    public class GetGlobalEntityResponse : ResponseBase
    {
        public GlobalEntityModel Record { get; set; }
    }
}
