using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4.AppDatas
{
    [DataContract(Name = "saveAppDataRequest")]
    public class WSSaveAppDataV4Request
    {
        [DataMember(Name = "appData")]
        public string AppData { get; set; }
    }
}
