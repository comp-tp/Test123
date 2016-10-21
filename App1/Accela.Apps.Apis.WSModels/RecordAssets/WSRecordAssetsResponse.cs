using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.WSModels.Assets;

namespace Accela.Apps.Apis.WSModels.RecordAssets
{
    [DataContract(Name = "getAssetsResponse")]
    public class WSRecordAssetsResponse : WSResponseBase
    {
        [DataMember(Name = "assets", EmitDefaultValue = false)]
        public List<WSAsset> Assets { get; set; }

        /// <summary>
        /// Convert RecordAssetsResponse to WSRecordAssetsResponse.
        /// </summary>
        /// <param name="recordAssetsResponse">AssetsResponse.</param>
        /// <returns>WSRecordAssetsResponse.</returns>
        public static WSRecordAssetsResponse FromEntityModel(RecordAssetsResponse recordAssetsResponse)
        {
            return new WSRecordAssetsResponse()
            {
                Assets = GetAssets(recordAssetsResponse)
            };
        }

        /// <summary>
        /// Get assets.
        /// </summary>
        /// <param name="recordAssetsResponse">RecordAssetsResponse.</param>
        /// <returns>WSAsset collection.</returns>
        private static List<WSAsset> GetAssets(RecordAssetsResponse recordAssetsResponse)
        {
            List<WSAsset> wsAssets = null;
            if (recordAssetsResponse.Assets != null && recordAssetsResponse.Assets.Count > 0)
            {
                wsAssets = new List<WSAsset>();
                recordAssetsResponse.Assets.ForEach(c => wsAssets.Add(WSAsset.FromEntityModel(c)));
            }
            return wsAssets;
        }
    }
}
