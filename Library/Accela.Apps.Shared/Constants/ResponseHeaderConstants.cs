using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.APIHandlers
{
    public static class ResponseHeaderConstants
    {
        public const string X_Standard_Header_Authorization = "Authorization";
        public const string X_Accela_Header_AppId = "x-accela-appid";
        public const string X_Accela_Header_AppVersion = "x-accela-appversion";
        public const string X_Accela_Header_AppSecret = "x-accela-appsecret";
        public const string X_Accela_Header_Environment = "x-accela-environment";
        public const string X_Accela_Header_Agency = "x-accela-agency";
        public const string X_Accela_Header_ClientPlatform = "x-accela-appplatform";

        public const string X_Accela_Header_TraceId = "x-accela-traceId";
        public const string X_Accela_Header_Error_Code = "x-accela-resp-code";
        public const string X_Accela_Header_Error_Message = "x-accela-resp-message";

        //public const string X_Accela_Header_SubSystem_Environment = "x-accela-subsystem-environment";
        public const string X_Accela_Header_SubSystem_User = "x-accela-subsystem-user";
        public const string X_Accela_Header_Civic_ID = "x-accela-civicId";

        public const string X_Accela_Header_SubSystem_Caller = "x-accela-subsystem-caller";
        public const string X_Accela_Header_SubSystem_CallSequence = "x-accela-subsystem-callsequence";
        public const string X_Accela_Header_SubSystem_AccessKey = "x-accela-subsystem-accesskey";


        public const string X_Accela_Header_SubSystem_Original_HttpStatus = "x-accela-original-httpstatus";

        public const string X_Accela_Header_User_Agent_Value = "Accela/Construct";

        public const string X_Accela_Header_Gateway_Version = "x-accela-resp-gateway-version";

    }
}
