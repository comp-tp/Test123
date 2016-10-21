using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Accela.Apps.Apis.Persistence
{
    public partial class ApiDataContext : DbContext
    {
        public ApiDataContext(string conntectionString)
            : base(conntectionString)
        {
        }
    }
}