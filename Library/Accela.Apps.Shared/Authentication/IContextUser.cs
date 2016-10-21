using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.DataModel
{

    public interface IContextUser
    {
        Guid Id { get; set; }
        string Agency { get; set; }
        Guid AgencyID { get; set; }
        string LoginName { get; set; }
        string Environment { get; set; }

        string Password { get; set; }
        string Language { get; set; }
        string InspectorIdentifier { get; set; }
        IContextUser Clone();
    }
}
