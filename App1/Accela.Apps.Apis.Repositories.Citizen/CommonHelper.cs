
using System;
namespace Accela.Apps.Apis.Repositories.Citizen
{
    internal static class CommonHelper
    {
        /*
        /// <summary>
        /// Get Service Provider Code by agency name.
        /// </summary>
        /// <param name="agencyName">agency name.</param>
        /// <returns>Service Provider Code.</returns>
        public static string GetServProvCode(string agencyName)
        {
            IAgencyRepository repository = IocContainer.Resolve<IAgencyRepository>();
            string servProvCode = repository.GetServProvCode(agencyName);
            return servProvCode;
        }
        //*/

        public static string ToCitizenDateTimeString(string originalDate)
        {
            DateTime resultDate;

            if (DateTime.TryParse(originalDate, out resultDate))
            {
                string citizenStringDateFormat = "MM/dd/yyyy HH:mm:ss";

                return resultDate.ToString(citizenStringDateFormat);
            }

            return String.Empty;
        }

        public static DateTime? ToUTCDateTime(long? ticksSince1970)
        {
            DateTime? result = null;
            if (ticksSince1970 != null)
            {
                result = (new DateTime(1970, 1, 1)).ToUniversalTime().AddMilliseconds(ticksSince1970.Value);
            }

            return result;
        }

        public static string ToUTCDateTimeString(long? ticksSince1970)
        {
            string result = null;
            if (ticksSince1970 != null)
            {
                DateTime tem = (new DateTime(1970, 1, 1)).ToUniversalTime().AddMilliseconds(ticksSince1970.Value);
                result = tem.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return result;
        }

        public static string ToUTCDateString(long? ticksSince1970)
        {
            string result = null;
            if (ticksSince1970 != null)
            {
                DateTime tem = (new DateTime(1970, 1, 1)).ToUniversalTime().AddMilliseconds(ticksSince1970.Value);
                result = tem.ToString("yyyy-MM-dd");
            }

            return result;
        }

        public static string ToUTCDateTimeString(string ticksSince1970)
        {
            string result = null;
            if (ticksSince1970 != null)
            {
                result=ToUTCDateTimeString(long.Parse(ticksSince1970));
            }

            return result;
        }

        public static string ToUTCDateString(string ticksSince1970)
        {
            string result = null;
            if (ticksSince1970 != null)
            {
                result=ToUTCDateString(long.Parse(ticksSince1970));
            }

            return result;
        }

        public static string ToEntityDateTimeString(string acaString)
        {
            if (!String.IsNullOrWhiteSpace(acaString))
            {
                DateTime tempDate;

                string entityDateTimeFormat = "yyyy-MM-dd HH:mm:ss";

                if (DateTime.TryParse(acaString, out tempDate))
                {
                    return tempDate.ToString(entityDateTimeFormat);
                }
                else
                {
                    long tempTicks;

                    if (long.TryParse(acaString, out tempTicks))
                    {
                        DateTime since1970 = new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime().AddMilliseconds(tempTicks);

                        return since1970.ToString(entityDateTimeFormat);
                    }
                }
            }

            return acaString;
        }

        public static string ToEntityDateString(string acaString)
        {
            if (!String.IsNullOrWhiteSpace(acaString))
            {
                DateTime tempDate;

                string entityDateFormat = "yyyy-MM-dd";

                if (DateTime.TryParse(acaString, out tempDate))
                {
                    return tempDate.ToString(entityDateFormat);
                }
                else
                {
                    long tempTicks;

                    if (long.TryParse(acaString, out tempTicks))
                    {
                        DateTime since1970 = new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime().AddMilliseconds(tempTicks);

                        return since1970.ToString(entityDateFormat);
                    }
                }
            }

            return acaString;
        }

        public static string ToEntityTimeString(string acaString)
        {
            if (!String.IsNullOrWhiteSpace(acaString))
            {
                DateTime tempDate;

                string entityTimeFormat = "HH:mm:ss";

                if (DateTime.TryParse(acaString, out tempDate))
                {
                    return tempDate.ToString(entityTimeFormat);
                }
                else
                {
                    long tempTicks;

                    if (long.TryParse(acaString, out tempTicks))
                    {
                        DateTime since1970 = new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime().AddMilliseconds(tempTicks);

                        return since1970.ToString(entityTimeFormat);
                    }
                }
            }

            return acaString;
        }

        public static string ToACADateTimeString(string entityString)
        {
            if (!String.IsNullOrWhiteSpace(entityString))
            {
                DateTime tempDate;

                string entityDateTimeFormat = "MM/dd/yyyy HH:mm:ss";

                if (DateTime.TryParse(entityString, out tempDate))
                {
                    return tempDate.ToString(entityDateTimeFormat);
                }
            }

            return entityString;
        }

        public static string ToACADateString(string entityString)
        {
            if (!String.IsNullOrWhiteSpace(entityString))
            {
                DateTime tempDate;

                if (DateTime.TryParse(entityString, out tempDate))
                {
                    string entityDateFormat = "MM/dd/yyyy";

                    return tempDate.ToString(entityDateFormat);
                }
            }

            return entityString;
        }

        public static string ToACATimeString(string entityString)
        {
            if (!String.IsNullOrWhiteSpace(entityString))
            {
                DateTime tempDate;

                if (DateTime.TryParse(entityString, out tempDate))
                {
                    string entityTimeFormat = "HH:mm:ss";

                    return tempDate.ToString(entityTimeFormat);
                }
            }

            return entityString;
        }

        public static string ToACAISODateTimeString(string entityString)
        {
            if (!String.IsNullOrWhiteSpace(entityString))
            {
                DateTime tempDate;

                if (DateTime.TryParse(entityString, out tempDate))
                {
                    return tempDate.ToString("o");
                }
            }

            return entityString;
        }

        public static string ToACAISODateString(string entityString)
        {
            if (!String.IsNullOrWhiteSpace(entityString))
            {
                DateTime tempDate;

                if (DateTime.TryParse(entityString, out tempDate))
                {
                    string entityDateFormat = "yyyy-MM-dd";

                    return tempDate.ToString(entityDateFormat);
                }
            }

            return entityString;
        }

        public static string ToACAISOTimeString(string entityString)
        {
            if (!String.IsNullOrWhiteSpace(entityString))
            {
                DateTime tempDate;

                if (DateTime.TryParse(entityString, out tempDate))
                {
                    string entityTimeFormat = "HH:mm:ss";

                    return tempDate.ToString(entityTimeFormat);
                }
            }

            return entityString;
        }
    }
}
