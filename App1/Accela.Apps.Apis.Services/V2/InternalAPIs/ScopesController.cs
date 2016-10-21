using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Shared;
using System.Web.Http;
using Accela.Apps.Apis.WSModels.Scopes;
using Accela.Core.Ioc;

namespace Accela.Apps.Apis.Services.V2.InternalAPIs
{
    [RoutePrefix("apis/v3/scopes")]
    public class ScopesController : ControllerBase
    {
        private IScopeBusinessEntity _scopeBusinessEntity;
        private IScopeBusinessEntity ScopeBusinessEntity
        {
            get
            {
                if (_scopeBusinessEntity == null)
                {
                    _scopeBusinessEntity = IocContainer.Resolve<IScopeBusinessEntity>();
                }

                return _scopeBusinessEntity;
            }
        }

        [Route("")]
        public WSScopesResponse GetScopes(string expand = null)
        {
            WSScopesResponse result = null;
            var scopes = ScopeBusinessEntity.GetScopes();

            if (scopes != null)
            {
                result = new WSScopesResponse();
                result.Scopes = WSScope.FromBusinessEntities(scopes);
            }

            return result;
        }
    }
}
