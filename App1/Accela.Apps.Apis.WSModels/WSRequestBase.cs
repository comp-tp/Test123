using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels
{
    [DataContract]
    public class WSRequestBase
    {

        /// <summary>
        /// The current cloud user.
        /// </summary>
        //public CloudUser CurrentUser { get; set; }

        //private SystemInfo _systemInfo;

        public int Offset { get; set; }

        public int Limit { get; set; }

        ///// <summary>
        ///// The request client system info.
        ///// </summary>
        //public SystemInfo SystemInfo
        //{
        //    get
        //    {
        //        if (_systemInfo == null)
        //        {
        //            _systemInfo = new SystemInfo();
        //        }

        //        return _systemInfo;
        //    }
        //    set
        //    {
        //        _systemInfo = value;
        //    }
        //}
    }
}
