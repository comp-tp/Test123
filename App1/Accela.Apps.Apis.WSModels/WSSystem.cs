using System;
using System.Net;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DTOs;

namespace Accela.Apps.Apis.WSModels
{
    /// <summary>
    /// System info class.
    /// </summary>
    [DataContract(Name = "system")]
    public class WSSystem
    {
        /// <summary>
        /// Http Status. one of HttpStatusCode enum.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// Detail info.
        /// </summary>
        [DataMember(Name = "detail", EmitDefaultValue = false)]
        public WSDetailInfo Detail
        {
            get;
            set;
        }

        /// <summary>
        /// Convert ResponseBase to WSSystem.
        /// </summary>
        /// <param name="responseBase">ResponseBase.</param>
        /// <returns>WSSystem.</returns>
        public static WSSystem FromEntityModel(ResponseBase responseBase)
        {          
            var wsSystem = new WSSystem();
            if (responseBase.Error != null)
            {
                switch (responseBase.Error.ErrorCode)
                {
                    case "404":
                        wsSystem.Status = 404;
                        break;
                    case "400":
                    case "403":
                        wsSystem.Status = int.Parse(responseBase.Error.ErrorCode);
                        break;
                    default:
                        wsSystem.Status = 500;
                        break;
                }
                
                wsSystem.Detail = WSDetailInfo.FromEntityModel(responseBase.Error);
                
                // TODO:
                //wsSystem.Detail.TraceID = Context.TraceID;
            }
            else
            {
                wsSystem.Status = (int)HttpStatusCode.OK;
                // TODO:
                //wsSystem.Detail = new WSDetailInfo() { TraceID = Context.TraceID };
            }

            return wsSystem;
        }

        public static WSSystem FromException(Exception exception)
        {
            WSSystem result = new WSSystem();

            if (exception != null)
            {
                result.Status = 500;

                // TODO:
                //var mobileException = exception as MobileException;

                //if (mobileException != null)
                //{
                //    result.Detail = new WSDetailInfo
                //    {
                //        Code = mobileException.ErrorCode,
                //        Message = mobileException.Message,
                //        TraceID = Context.TraceID
                //    };
                //}
                //else
                //{
                //    result.Detail = new WSDetailInfo
                //    {
                //        Code = "20000",
                //        Message = exception.Message,
                //        TraceID = Context.TraceID
                //    };
                //};
            }

            return result;
        }
    }

    /// <summary>
    /// System info detail class.
    /// </summary>
    [DataContract(Name = "detail")]
    public class WSDetailInfo
    {
        /// <summary>
        /// Code.
        /// </summary>
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Message.
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// More detail.
        /// </summary>
        [DataMember(Name = "more", EmitDefaultValue = false)]
        public string More
        {
            get;
            set;
        }

        /// <summary>
        /// Trace ID.
        /// </summary>
        [DataMember(Name = "traceid", EmitDefaultValue = false)]
        public string TraceID
        {
            get;
            set;
        }

        /// <summary>
        /// Convert detailInfo to clientDetailInfo
        /// </summary>
        /// <param name="detail">detail.</param>
        /// <returns>ClientDetailInfo</returns>
        public static WSDetailInfo FromEntityModel(ErrorMessage errorMessage)
        {
            return new WSDetailInfo()
            {
                Code = errorMessage.ErrorCode,
                Message = errorMessage.Message,
                // TODO:
                //TraceID = Context.TraceID                
            };
        }
    }
}
