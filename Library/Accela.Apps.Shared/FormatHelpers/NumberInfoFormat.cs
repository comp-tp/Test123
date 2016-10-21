using System;

namespace Accela.Apps.Shared.FormatHelpers
{
    public class NumberInfoFormat
    {
        public static string NumberFormat { get; set; }

        public static string ToAMONumberString(int i)
        {
            string result = string.Empty;
            try
            {
                result = i.ToString(NumberFormat);
            }
            catch
            {
                result = i.ToString();
            }
            return result;
        }

        public static string ToAMONumberString(long l)
        {
            string result = string.Empty;
            try
            {
                result = l.ToString(NumberFormat);
            }
            catch
            {
                result = l.ToString();
            }
            return result;
        }

        public static string ToAMONumberString(float f)
        {
            string result = string.Empty;
            try
            {
                result = f.ToString(NumberFormat);
            }
            catch
            {
                result = f.ToString();
            }
            return result;
        }

        public static string ToAMONumberString(decimal dec)
        {
            string result = string.Empty;
            try
            {
                result = dec.ToString(NumberFormat);
            }
            catch
            {
                result = dec.ToString();
            }
            return result;
        }

        public static string ToAMONumberString(string str)
        {
            string result = string.Empty;
            decimal temp;
            decimal.TryParse(str, out temp);
            try
            {
                result = temp.ToString(NumberFormat);
            }
            catch
            {
                result = temp.ToString();
            }
            return result;
        }

        public static string IntFormat { get; set; }

        public static string ToAMONumberInt(int i)
        {
            string result = string.Empty;
            try
            {
                result = i.ToString(IntFormat);
            }
            catch
            {
                result = i.ToString();
            }
            return result;
        }
        public static string ToAMONumberInt(long l)
        {
            string result = string.Empty;
            try
            {
                result = l.ToString(IntFormat);
            }
            catch
            {
                result = l.ToString();
            }
            return result;
        }

        public static int ToAMOInt(string str)
        {
            int result;
            int.TryParse(str, out result);
            return result;
        }
        public static int ToAMOLong(string str)
        {
            int result;
            Int32.TryParse(str.Replace(IntFormat,""), out result);
            return result;
        }
    }
}
