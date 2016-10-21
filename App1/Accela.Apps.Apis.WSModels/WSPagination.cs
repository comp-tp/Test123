using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs;

namespace Accela.Apps.Apis.WSModels
{
    [DataContract(Name = "page")]
    public class WSPagination
    {   
        [DataMember(Name = "totalRows", EmitDefaultValue = false)]        
        public int TotalRows { get; set; }

        [DataMember(Name = "hasMore", EmitDefaultValue = false)]
        public bool HasMore { get; set; }

        /// <summary>
        /// Convert pagination to client pagination.
        /// </summary>
        /// <param name="pagination">Pagination.</param>
        /// <returns>Client pagination.</returns>
        public static WSPagination FromEntityModel(Pagination pagination)
        {
            if (pagination != null)
            {
                return new WSPagination()
                {                   
                    TotalRows = pagination.TotalRows,    
                    HasMore = pagination.TotalRows - pagination.Offset - pagination.Limit > 0       
                };
            }
            return null;
        }
    }
}
