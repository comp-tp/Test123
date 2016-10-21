using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Automation.GovXmlServices.Client
{
    /// <summary>
    /// Use interface as Commnuicator object, it convient to do UT and ATTD.
    /// </summary>
    public interface ICommunicator
    {
        T Post<T>(string requestXml) where T : new();
    }

    public delegate void EventCommunicatorDelegate(string content);

    public interface IEventCommunicator
    {
        event EventCommunicatorDelegate BeforeExcute;
        event EventCommunicatorDelegate AfterExcute;
        event EventCommunicatorDelegate ExcuteError;
    }
}
