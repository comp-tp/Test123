using Accela.Apps.Apis.Models.DTOs.Requests.ParcelRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using Accela.Automation.GovXmlClient.Model;


namespace Accela.Apps.Apis.Repositories.Agency
{
    /// <summary>
    /// Parcel repository class
    /// </summary>
    public class ParcelRepository : RepositoryBase, IParcelRepository
    {
        private string _bizServerVersion;
        //public ParcelRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //    _bizServerVersion = this.Environment.BizServerVersion;
        //}

        public ParcelRepository(IAgencyAppContext contextEntity)
            : base(contextEntity)
        {
            _bizServerVersion = this.Environment == null ? "" : this.Environment.BizServerVersion;
        }

        /// <summary>
        /// Get parcels according request's criteria
        /// </summary>
        /// <param name="request">ParcelsRequest object</param>
        /// <returns>ParcelsResponse object</returns>
        public ParcelsResponse GetParcels(ParcelsRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getParcels = new GetParcels();
            govXmlIn.getParcels.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getParcels.returnRefParcels = true;

            ParcelHelper.ToGovXmlFromCriteria(govXmlIn.getParcels, request.Criteria, request.Elements);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getParcels.system,
                (o) => o.getParcelsResponse == null ? null : o.getParcelsResponse.system);

            ParcelHelper parcelHelper = new ParcelHelper(_bizServerVersion);
            ParcelsResponse results = parcelHelper.GetClientParcels(response.getParcelsResponse, request.IgnoreCoordinatesSearch);

            return results;
        }
    }
}
