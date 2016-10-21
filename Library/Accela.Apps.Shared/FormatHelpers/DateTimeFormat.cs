using System;
using System.Globalization;

namespace Accela.Apps.Shared.FormatHelpers
{
    public class DateTimeFormat
    {
        /// <summary>
        /// DATE TIME FORMATE1
        /// </summary>
        private const string DATETIME_FORMAT1 = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// DATE TIME FORMATE2
        /// </summary>
        private const string DATETIME_FORMAT2 = "yyyy-MM-dd hh:mm ttt";

        /// <summary>
        /// DATE TIME FORMATE3
        /// </summary>
        private const string DATETIME_FORMAT3 = "yyyy-MM-dd hh:mm";

        /// <summary>
        /// DATE TIME FORMATE4
        /// </summary>
        private const string DATETIME_FORMAT4 = "yyyy-MM-dd HH:mm ttt";

        /// <summary>
        /// DATE TIME FORMATE5
        /// </summary>
        private const string DATETIME_FORMAT5 = "yyyy-MM-dd hh:mm:ss";

        public static string UITimeFormat { get; set; }
        public static string UIDateTimeFormat { get; set; }
        /// <summary>
        /// convert date object to standard(our) date format string. The format is “yyyy-MM-dd”
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToMetaDateString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// convert date object to standard(our) date time format string. The format is “yyyy-MM-dd HH:mm:ss”
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToMetaDateTimeString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// convert date object to standard(our) date time format string. The format is “HH:mm:ss”
        /// </summary>
        /// <returns></returns>
        public static string ToMetaTimeString(DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Convert string to Date object. The string should be standard format. like “yyyy-MM-dd”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateFromMetaDateString(String str)
        {
            System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
            return DateTime.ParseExact(str, "yyyy-MM-dd", format);
        }

        /// <summary>
        /// Convert string to Date object. The string should be standard format. like “yyyy-MM-dd”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateFromMetaDateTimeString(String str)
        {
            System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
            string[] metaFormat = new string[]
            {
                DATETIME_FORMAT1,
                DATETIME_FORMAT2,
                DATETIME_FORMAT3,
                DATETIME_FORMAT4,
                DATETIME_FORMAT5,
                "yyyy-MM-dd"
            };

            return DateTime.ParseExact(str, metaFormat, DateTimeFormatInfo.CurrentInfo, DateTimeStyles.None);
        }

        /// <summary>
        /// Convert string to Date object. The string should be UI Date format. like “MM/dd/yyyy”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateFromUIDateString(string str, string uiDateFormat = null)
        {
            if (string.IsNullOrEmpty(uiDateFormat))
            {
                return DateTime.Parse(str);
            }
            else
            {
                System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
                return DateTime.ParseExact(str, uiDateFormat, format);
            }
        }

        /// <summary>
        /// Convert string to Date time object. The string should be standard format. “yyyy-MM-dd HH:mm:dd”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromMetaDateTimeString(string str)
        {
            System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
            return DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", format);
        }

        /// <summary>
        /// Convert string to time object. The string should be standard format. like “MM/dd/yyyy HH:mm”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromUIDateTimeString(string str)
        {
            if (string.IsNullOrEmpty(UIDateTimeFormat))
            {
                return DateTime.Parse(str);
            }
            else
            {
                System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
                return DateTime.ParseExact(str, UIDateTimeFormat, format);
            }
        }

        /// <summary>
        /// Convert string to time object. The string should be standard format. like “HH:mm:ss”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToTimeFromMetaTimeString(string str)
        {
            System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
            return DateTime.ParseExact(str, "HH:mm:ss", format);
        }

        /// <summary>
        /// Convert string to time object. The string should be UI Date time format. like “HH:mm”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToTimeFromUITimeString(string str)
        {
            if (string.IsNullOrEmpty(UITimeFormat))
            {
                return DateTime.Parse(str);
            }
            else
            {
                System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
                return DateTime.ParseExact(str, UITimeFormat, format);
            }
        }

        /// <summary>
        /// Convert the UI Date string to Meta date string. For example: convert “08/25/2011” to “2011-08-25”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMetaDateStringFromUIDateString(string str, string uiDateFormat = null)
        {
            DateTime tempDate = new DateTime();
            if (string.IsNullOrEmpty(uiDateFormat))
            {
                if (!DateTime.TryParse(str, out tempDate))
                {
                    return str;
                }
            }
            else
            {
                System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
                if (!DateTime.TryParseExact(str, uiDateFormat, format, DateTimeStyles.None, out tempDate))
                {
                    return str;
                }
            }

            return tempDate.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Convert the UI time string to Meta time string. For example: convert “14:12” to “14:12:00”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMetaTimeStringFromUITimeString(string str)
        {
            DateTime tempDate = new DateTime();
            if (!CheckStr(str)) return str;
            if (string.IsNullOrEmpty(UITimeFormat))
            {
                tempDate = DateTime.Parse(str);
            }
            else
            {
                System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
                tempDate = DateTime.ParseExact(str, UITimeFormat, format);
            }
            return tempDate.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Convert the UI Date time string to Meta date time string. For example: convert “08/25/2011 14:12” to “2011-08-25 14:12:00”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToMetaDateTimeStringFromUIDateTimeString(string str)
        {
            DateTime tempDate = new DateTime();
            if (!CheckStr(str)) return str;
            if (string.IsNullOrEmpty(UIDateTimeFormat))
            {
                tempDate = DateTime.Parse(str);
            }
            else
            {
                System.IFormatProvider format = new System.Globalization.CultureInfo("en-US");
                tempDate = DateTime.ParseExact(str, UIDateTimeFormat, format);
            }
            return tempDate.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Convert the Meta Date string to UI date string. For example: convert “2011-08-25” to “08/25/2011”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUIDateStringFromMetaDateString(string str, string uiDateFormat = null)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }

            DateTime tempDate = Convert.ToDateTime(str);
            if (string.IsNullOrEmpty(uiDateFormat))
            {
                return tempDate.ToString();
            }
            else
            {
                return tempDate.ToString(uiDateFormat);
            }
        }

        /// <summary>
        /// Convert the Meta time string to UI time string. For example: convert “14:12:23” to “14:12”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUITimeStringFromMetaTimeString(string str)
        {
            if (!CheckStr(str))
            {
                return str;
            }

            DateTime tempDate = Convert.ToDateTime(str);
            if (string.IsNullOrEmpty(UITimeFormat))
            {
                return tempDate.ToString();
            }
            else
            {
                return tempDate.ToString(UITimeFormat);
            }
        }

        /// <summary>
        /// Convert the Meta date time string to UI date time string. For example: convert “2011-08-25 14:12:23” to “08/25/2011 14:12”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUIDateTimeStringFromMetaDateTimeString(string str)
        {
            DateTime tempDate = Convert.ToDateTime(str);
            if (string.IsNullOrEmpty(UIDateTimeFormat))
            {
                return tempDate.ToString();
            }
            else
            {
                return tempDate.ToString(UIDateTimeFormat);
            }
        }

        /// <summary>
        /// Convert the Meta date time string to UI date time string. For example: convert “2011-08-25 14:12:23” to “08/25/2011 14:12”
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUIDateTimeString(DateTime? date)
        {
            if (date==null)
            {
                return "";
            }
            else
            {
                return date.Value.ToString(UIDateTimeFormat);
            }
        }


        private static bool CheckStr(string str)
        {
            string[] strs = { "AM", "PM", "Any Time" };
            foreach (string item in strs)
            {
                if (str.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
