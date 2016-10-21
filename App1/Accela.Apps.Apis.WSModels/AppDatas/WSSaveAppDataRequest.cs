using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.AppDatas
{
    [DataContract(Name = "saveAppDataRequest")]
    public class WSSaveAppDataRequest
    {
        [DataMember(Name = "appData")]
        public string AppData { get; set; }
    }
}
