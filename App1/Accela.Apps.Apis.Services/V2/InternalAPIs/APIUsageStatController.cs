using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttributeRouting;
using Accela.Apps.Shared;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using AttributeRouting.Web.Http;

namespace Accela.Apps.Apis.Services.V2.InternalAPIs
{
    [RoutePrefix("apis/v3/stat")]
    public class APIUsageStatController : ControllerBase
    {
        //private IAPIUsageBusinessEntity _statBiz;
        private readonly IAPIUsageBusinessEntity statBiz;
        //{
        //    get
        //    {
        //        if (_statBiz == null)
        //        {
        //            _statBiz = IocContainer.Resolve<IAPIUsageBusinessEntity>();
        //        }

        //        return _statBiz;
        //    }
        //}

        public APIUsageStatController(IAPIUsageBusinessEntity statBiz)
        {
            this.statBiz = statBiz;
        }

        [GET("agencies/mostactive")]
        public List<String> GetMostActiveAgencies()
        {
            var result = statBiz.MostActiveAgencies();
            return result;
        }

        [GET("apps/mostactive")]
        public List<String> GetMostActiveApps()
        {
            var result = statBiz.MostActiveApps();
            return result;
        }
    }
}
