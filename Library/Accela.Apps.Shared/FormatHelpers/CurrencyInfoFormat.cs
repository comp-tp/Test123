using System;

namespace Accela.Apps.Shared.FormatHelpers
{
    public class CurrencyInfoFormat
    {
        public static string CurrencyFormat { get; set; }

        public static string ToAMOCurrencyString(decimal dec)
        {
            string result = string.Empty;
            try
            {
                result = dec.ToString(CurrencyFormat);
            }
            catch
            {
                result = dec.ToString();
            }
            return result;
        }

        public static string ToAMOCurrencyString(double dou)
        {
            string result = string.Empty;
            try
            {
                result = dou.ToString(CurrencyFormat);
            }
            catch
            {
                result = dou.ToString();
            }
            return result;
        }

        public static string ToAMOCurrencyString(float f)
        {
            string result = string.Empty;
            try
            {
                result = f.ToString(CurrencyFormat);
            }
            catch
            {
                result = f.ToString();
            }
            return result;
        }

        public static string ToAMOCurrencyString(int i)
        {
            string result = string.Empty;
            try
            {
                result = i.ToString(CurrencyFormat);
            }
            catch
            {
                result = i.ToString();
            }
            return result;
        }

        public static string ToAMOCurrencyString(long l)
        {
            string result = string.Empty;
            try
            {
                result = l.ToString(CurrencyFormat);
            }
            catch
            {
                result = l.ToString();
            }
            return result;
        }

        public static decimal ToAMOCurrency(string str)
        {
            decimal temp;
            decimal.TryParse(str.Replace(CurrencyFormat,""),out temp);
            return temp;
        }
    }
}
