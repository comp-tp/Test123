using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Core
{
    public static class StringBuilderExtensions
    {
        public static string Substring(this StringBuilder instance, int startIndex, int length)
        {
            var substring = new char[length];
            int index = 0;
            for (int i = startIndex; i < startIndex + length; i++)
            {
                substring[index] = instance[i];
                index++;
            }
            return new string(substring);
        }

        public static StringBuilder Remove(this StringBuilder instance, char ch)
        {
            for (int i = 0; i < instance.Length; )
            {
                if (instance[i] == ch)
                    instance.Remove(i, 1);
                else
                    i++;
            }
            return instance;
        }

        public static StringBuilder RemoveFromEnd(this StringBuilder instance, int num)
        {
            return instance.Remove(instance.Length - num, num);
        }

        public static void Clear(this StringBuilder instance)
        {
            instance.Length = 0;
        }

        /// <summary>
        /// Trim left spaces of string
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static StringBuilder LTrim(this StringBuilder instance)
        {
            if (instance.Length != 0)
            {
                int length = 0;
                int num2 = instance.Length;
                while ((instance[length] == ' ') && (length < num2))
                {
                    length++;
                }
                if (length > 0)
                {
                    instance.Remove(0, length);
                }
            }
            return instance;
        }

        /// <summary>
        /// Trim right spaces of string
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static StringBuilder RTrim(this StringBuilder instance)
        {
            if (instance.Length != 0)
            {
                int length = instance.Length;
                int num2 = length - 1;
                while ((instance[num2] == ' ') && (num2 > -1))
                {
                    num2--;
                }
                if (num2 < (length - 1))
                {
                    instance.Remove(num2 + 1, (length - num2) - 1);
                }
            }
            return instance;
        }

        /// <summary>
        /// Trim spaces around string
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static StringBuilder Trim(this StringBuilder instance)
        {
            if (instance.Length != 0)
            {
                int length = 0;
                int num2 = instance.Length;
                while ((instance[length] == ' ') && (length < num2))
                {
                    length++;
                }
                if (length > 0)
                {
                    instance.Remove(0, length);
                    num2 = instance.Length;
                }
                length = num2 - 1;
                while ((instance[length] == ' ') && (length > -1))
                {
                    length--;
                }
                if (length < (num2 - 1))
                {
                    instance.Remove(length + 1, (num2 - length) - 1);
                }
            }
            return instance;
        }

        /// <summary>
        /// Get index of a char
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int IndexOf(this StringBuilder instance, char value)
        {
            return IndexOf(instance, value, 0);
        }

        /// <summary>
        /// Get index of a char starting from a given index
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="c"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int IndexOf(this StringBuilder instance, char value, int startIndex)
        {
            for (int i = startIndex; i < instance.Length; i++)
            {
                if (instance[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Get index of a string
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int IndexOf(this StringBuilder instance, string value)
        {
            return IndexOf(instance, value, 0, false);
        }

        /// <summary>
        /// Get index of a string from a given index
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="text"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static int IndexOf(this StringBuilder instance, string value, int startIndex)
        {
            return IndexOf(instance, value, startIndex, false);
        }

        /// <summary>
        /// Get index of a string with case option
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="text"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static int IndexOf(this StringBuilder instance, string value, bool ignoreCase)
        {
            return IndexOf(instance, value, 0, ignoreCase);
        }

        /// <summary>
        /// Get index of a string from a given index with case option
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="text"></param>
        /// <param name="startIndex"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static int IndexOf(this StringBuilder instance, string value, int startIndex, bool ignoreCase)
        {
            int num3;
            int length = value.Length;
            int num2 = (instance.Length - length) + 1;
            if (ignoreCase == false)
            {
                for (int i = startIndex; i < num2; i++)
                {
                    if (instance[i] == value[0])
                    {
                        num3 = 1;
                        while ((num3 < length) && (instance[i + num3] == value[num3]))
                        {
                            num3++;
                        }
                        if (num3 == length)
                        {
                            return i;
                        }
                    }
                }
            }
            else
            {
                for (int j = startIndex; j < num2; j++)
                {
                    if (char.ToLower(instance[j]) == char.ToLower(value[0]))
                    {
                        num3 = 1;
                        while ((num3 < length) && (char.ToLower(instance[j + num3]) == char.ToLower(value[num3])))
                        {
                            num3++;
                        }
                        if (num3 == length)
                        {
                            return j;
                        }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Determine whether a string starts with a given text
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool StartsWith(this StringBuilder instance, string value)
        {
            return StartsWith(instance, value, 0, false);
        }

        /// <summary>
        /// Determine whether a string starts with a given text (with case option)
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static bool StartsWith(this StringBuilder instance, string value, bool ignoreCase)
        {
            return StartsWith(instance, value, 0, ignoreCase);
        }

        /// <summary>
        /// Determine whether a string is begin with a given text
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static bool StartsWith(this StringBuilder instance, string value, int startIndex, bool ignoreCase)
        {
            int length = value.Length;
            int num2 = startIndex + length;
            if (ignoreCase == false)
            {
                for (int i = startIndex; i < num2; i++)
                {
                    if (instance[i] != value[i - startIndex])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = startIndex; j < num2; j++)
                {
                    if (char.ToLower(instance[j]) != char.ToLower(value[j - startIndex]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
