using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels
{
    [DataContract]
    public class DataModel : IDataModel
    {
        /// <summary>
        /// Emit fields. if empty or null, emit all fields.
        /// </summary>
        public List<string> EmitFields
        {
            get;
            set;
        }

        /// <summary>
        /// Ignore Emit fields.
        /// </summary>
        public List<string> IgnoreEmitFields
        {
            get;
            set;
        }

        public void OnValueChanged(string propertyName)
        {

        }

        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            if ((EmitFields == null || EmitFields.Count == 0) && (IgnoreEmitFields == null || IgnoreEmitFields.Count == 0))
            {
                return;
            }

            PropertyInfo[] properyInfos = this.GetType().GetProperties();
            foreach (PropertyInfo info in properyInfos)
            {
                bool isEmitField = false;

                //set emit fields
                if (EmitFields == null || EmitFields.Count == 0)
                {
                    isEmitField = true;
                }
                else
                {
                    foreach (string emitField in EmitFields)
                    {
                        if (emitField.Equals(info.Name, StringComparison.InvariantCultureIgnoreCase))
                        {
                            isEmitField = true;
                            break;
                        }
                    }
                }

                // remove ignore fields
                if (IgnoreEmitFields != null && IgnoreEmitFields.Count > 0)
                {
                    foreach (string ignoreEmitField in IgnoreEmitFields)
                    {
                        if (ignoreEmitField.Equals(info.Name, StringComparison.InvariantCultureIgnoreCase))
                        {
                            isEmitField = false;
                            break;
                        }
                    }
                }

                if (!isEmitField)
                {
                    info.SetValue(this, null,null);
                }
            }
        }

        //[OnSerialized]
        //void OnSerialized(StreamingContext context)
        //{
        //}

        //[OnDeserializing]
        //public void OnDeserializing(StreamingContext context)
        //{
        
        //}

        //[OnDeserialized]
        //void OnDeserialized(StreamingContext context)
        //{
        //}
    }
}
