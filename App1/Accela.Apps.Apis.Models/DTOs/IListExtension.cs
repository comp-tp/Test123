using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Accela.Apps.Apis.Models.DTOs
{
    public static class IListExtension
    {
        /// <summary>
        /// Sets Emit fields. if empty or null, emit all fields.
        /// </summary>
        public static void SetEmitFields(this IList list, List<string> emitFields)
        {
            if (list != null && emitFields != null && emitFields.Count > 0)
            {
                foreach (object model in list)
                {
                    IDataModel tmp = model as IDataModel;
                    if (tmp != null)
                    {
                        tmp.EmitFields = emitFields;
                    }
                }
            }
        }


        /// <summary>
        /// Sets Emit fields. if empty or null, emit all fields.
        /// </summary>
        public static void SetEmitFields(this IList list, string emitFields)
        {
            if (String.IsNullOrEmpty(emitFields))
            {
                return;
            }

            SetEmitFields(list, emitFields.Split(new char[] { ',' }).ToList<string>());
        }

        /// <summary>
        /// Sets ignore Emit fields.
        /// </summary>
        public static void SetIgnoreEmitFields(this IList list, List<string> ignoreEmitFields)
        {
            if (list != null && ignoreEmitFields != null && ignoreEmitFields.Count > 0)
            {
                foreach (object model in list)
                {
                    IDataModel tmp = model as IDataModel;
                    if (tmp != null)
                    {
                        tmp.IgnoreEmitFields = ignoreEmitFields;
                    }
                }
            }
        }


        /// <summary>
        /// Override. Sets ignore Emit fields.
        /// </summary>
        public static void SetIgnoreEmitFields(this IList list, string ignoreEmitFields)
        {
            if (String.IsNullOrEmpty(ignoreEmitFields))
            {
                return;
            }

            SetIgnoreEmitFields(list, ignoreEmitFields.Split(new char[] { ',' }).ToList<string>());
        }
    }
}
