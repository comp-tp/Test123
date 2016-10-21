using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Core.Resources
{
    public class Message
    {
        public string Value { get; set; }
        public MessageType Type { get; set; }
        public object Sender { get; set; }

        public override string ToString()
        {
            return this.Value;
        }
    }
    #region MessageType
    public enum MessageType
    {
        Undefined = 0,
        Information = 1,
        Warning = 2,
        Error = 4,
        Success = 8
    }
    #endregion MessageType
}
