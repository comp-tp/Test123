using System;
using System.Collections.Generic;
using System.Text;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// It corresponds to the dataitemChangeEnum type in GovXML.
    /// 
    /// </summary>
    [Flags]
    public enum DataitemChangeEnum
    {
        Add         =   1,
        Append      =   2,
        Delete      =   4,
        Existing    =   8,
        New         =   16,
        Replace     =   32,
        Readonly    =   64,
        Update      =   128

    }
}
