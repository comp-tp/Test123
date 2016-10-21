using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.Common
{
    public class IdEscapeHelper
    {
        /// <summary>
        /// Escape "-" to ".1"
        /// Escape "." to ".."
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EncodeString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            //str = str.Replace(".", "..");
            str = str.Replace(".", ".0");
            str = str.Replace("-", ".1");
            str = str.Replace("%", ".2");
            str = str.Replace("/", ".3");
            str = str.Replace("\\", ".4");
            str = str.Replace(":", ".5");
            str = str.Replace("*", ".6");
            str = str.Replace("\"", ".7");
            str = str.Replace("<", ".8");
            str = str.Replace(">", ".9");
            str = str.Replace("|", ".a");
            str = str.Replace("?", ".b");
            str = str.Replace(" ", ".c");
            str = str.Replace("&", ".d");
            str = str.Replace("#", ".e");
            return str;
        }

        /// <summary>
        /// Deescape ".1" to "-"
        /// Deescape ".." to "."
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DecodeString(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            string retu = "";
            int i = 0;
            int strLen = str.Length;
            while (i < strLen)
            {
                if (str[i] == '.')
                {
                    if ((i + 1) < strLen)
                    {
                        //if (str[i + 1] == '.')
                        if (str[i + 1] == '0')
                        {
                            retu += '.';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '1')
                        {
                            retu += '-';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '2')
                        {
                            retu += '%';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '3')
                        {
                            retu += '/';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '4')
                        {
                            retu += '\\';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '5')
                        {
                            retu += ':';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '6')
                        {
                            retu += '*';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '7')
                        {
                            retu += '"';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '8')
                        {
                            retu += '<';
                            i = i + 2;
                        }
                        else if (str[i + 1] == '9')
                        {
                            retu += '>';
                            i = i + 2;
                        }
                        else if (str[i + 1] == 'a')
                        {
                            retu += '|';
                            i = i + 2;
                        }
                        else if (str[i + 1] == 'b')
                        {
                            retu += '?';
                            i = i + 2;
                        }
                        else if (str[i + 1] == 'c')
                        {
                            retu += ' ';
                            i = i + 2;
                        }
                        else if (str[i + 1] == 'd')
                        {
                            retu += '&';
                            i = i + 2;
                        }
                        else if (str[i + 1] == 'e')
                        {
                            retu += '#';
                            i = i + 2;
                        }
                        else
                        {
                            retu += str[i];
                            i++;
                        }
                    }
                    else
                    {
                        retu += str[i];
                        i++;
                    }
                }
                else
                {
                    retu += str[i];
                    i++;
                }
            }

            return retu;
        }
    }
}