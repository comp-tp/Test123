using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Accela.Core.Serialization
{
    public class SerializerSettings
    {
        public Formatting Formatting { get; set; }
        public int? MaxDepth { get; set; }
    }

    #region Formatting
    public enum Formatting
    {
        None = 0,
        Indented = 1
    }
    #endregion Formatting
}
