
namespace Accela.Apps.Apis.Services
{
    public static  class Constants
    {
        public const int DEFAULT_ROW_LIMIST = 20;

        internal const string PROPERTIES_KEY_RESOURCE_MODEL = "ResourceModel";

        internal const string PROPERTIES_KEY_CONTEXT = "x-accela-internal-context";

        internal const string PROPERTIES_KEY_CHILDAPI_FROM_BATCHREQUEST = "child_api_from_batch_request";

        public enum RemoteSystems
        {
            BizServer = 0,
            ConstructAdmin = 1,
            ConstructUser = 2,
            ConstructDeveloper = 3,
            ConstructAuth = 4
        }
    }
}