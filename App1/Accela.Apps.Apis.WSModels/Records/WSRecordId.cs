using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordId : WSIdentifierBase
    {

        /// <summary>
        /// Convert domain RecordIdModel to WSRecordId. 
        /// </summary>
        /// <param name="recordIdModel">RecordIdModel.</param>
        /// <returns>WSRecordId.</returns>
        public static WSRecordId FromEntityModel(RecordIdModel recordIdModel)
        {
            if (recordIdModel != null)
            {
                return new WSRecordId()
                {
                    Id = recordIdModel.Identifier,
                    Display = recordIdModel.Display
                };
            }
            return null;
        }
    }
}
