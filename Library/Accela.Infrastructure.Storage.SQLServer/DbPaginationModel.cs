using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage.SQLServer
{
    internal class DbPaginationModel
    {
        public long LastCount { get; set; }

        public static DbPaginationModel ConvertFrom(string continuationToken)
        {
            DbPaginationModel result = null;

            if (!String.IsNullOrWhiteSpace(continuationToken))
            {
                int lastCountTemp;
                if (int.TryParse(continuationToken, out lastCountTemp))
                {
                    result = new DbPaginationModel()
                    {
                        LastCount = lastCountTemp
                    };
                }
            }

            return result;
        }

        public static string ConvertToToken(DbPaginationModel dbPaginationModel)
        {
            string result = null;

            if (dbPaginationModel != null)
            {
                if (dbPaginationModel.LastCount > 0)
                {
                    result = dbPaginationModel.LastCount.ToString(CultureInfo.InvariantCulture);
                }
            }

            return result;
        }
    }
}
