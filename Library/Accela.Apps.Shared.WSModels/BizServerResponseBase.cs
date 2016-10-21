using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.WSModels
{
    [Serializable]
    [DataContract]
    public class BizServerResponseBase
    {
        public const int LOWER_VERSION_EMPTY_STATUS = -99;
        public const int EMPTY_STATUS = -1;

        private int? _status;

        [DataMember]
        public int status
        {
            get
            {
                int result;

                if (_status != null)
                {
                    result = _status.Value;
                }
                else if (responseStatus != null)
                {
                    int tempStatus;

                    if (int.TryParse(responseStatus.status, out tempStatus))
                    {
                        result = tempStatus;
                    }
                    else
                    {
                        result = LOWER_VERSION_EMPTY_STATUS;
                    }
                }
                else
                {
                    result = EMPTY_STATUS;
                }

                return result;
            }
            set { _status = value; }
        }

        private string _message;
        [DataMember]
        public string message
        {
            get
            {
                string result = null;

                if (!String.IsNullOrWhiteSpace(_message))
                {
                    result = _message;
                }
                else if (responseStatus != null && responseStatus.detail != null)
                {
                    result = responseStatus.detail.message;
                }
                else
                {
                    result = null;
                }

                return result;
            }

            set { _message = value; }
        }

        private string _code;
        [DataMember]
        public string code
        {
            get
            {
                string result = null;

                if (!String.IsNullOrWhiteSpace(_code))
                {
                    result = _code;
                }
                else if (responseStatus != null && responseStatus.detail != null)
                {
                    result = responseStatus.detail.code;
                }

                return result;
            }
            set { _code = value; }
        }

        private string _more;
        [DataMember]
        public string more
        {
            get
            {
                string result = null;

                if (!String.IsNullOrWhiteSpace(_more))
                {
                    result = _more;
                }
                else if (responseStatus != null && responseStatus.detail != null)
                {
                    result = responseStatus.detail.more;
                }

                return result;
            }
            set { _more = value; }
        }

        private string _traceId;
        [DataMember]
        public string traceId
        {
            get
            {
                string result = null;

                if (!String.IsNullOrWhiteSpace(_traceId))
                {
                    result = _traceId;
                }
                else if (responseStatus != null && responseStatus.detail != null)
                {
                    result = responseStatus.detail.traceid;
                }

                return result;
            }
            set { _traceId = value; }
        }

        [DataMember(Name = "responseStatus", EmitDefaultValue = false, Order = 1)]
        public BizServerResponseStatus responseStatus
        {
            get;
            set;
        }
    }
}
