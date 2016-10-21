﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "GetAssetsResponse")]
    public class WSAssetsResponse : WSPagedResponse
    {
        [DataMember(Name = "assets", EmitDefaultValue = false, Order = 3)]
        public List<WSAsset> Assets { get; set; }

        /// <summary>
        /// Convert biz response to service response.
        /// </summary>
        /// <param name="recordsResponse">Assets response.</param>
        /// <returns>Web service Asset response.</returns>
        public static WSAssetsResponse FromEntityModel(AssetsResponse response)
        {
            return new WSAssetsResponse()
            {
                Assets = GetWSAssets(response),
                PageInfo = WSPagination.FromEntityModel(response.PageInfo)
            };
        }

        /// <summary>
        /// Get assets.
        /// </summary>
        /// <param name="recordsResponse">Biz assets response</param>
        /// <returns>Web service asset collection.</returns>
        private static List<WSAsset> GetWSAssets(AssetsResponse response)
        {
            List<WSAsset> wsAssets = new List<WSAsset>();
            if (response.Assets != null && response.Assets.Count > 0)
            {
                response.Assets.ForEach(r => wsAssets.Add(WSAsset.FromEntityModel(r)));
            }

            return wsAssets;
        }
    }
}