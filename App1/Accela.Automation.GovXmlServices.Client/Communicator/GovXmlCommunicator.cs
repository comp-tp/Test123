#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: AuthenticateUser.cs
*
*  Accela, Inc.
*  Copyright (C): 2008-2010
*
*  Description:
*  Create By SYSTEM
*  Notes:
* </pre>
*/

#endregion Header

namespace Accela.Automation.GovXmlClient.Model.Communicators
{
    using System;
    using System.Web;
    using Accela.Automation.GovXmlServices.Client;
    using Accela.Core.Logging;
    using Accela.Apps.Shared.Gateway.Client;
    using Accela.Apps.Shared.Contants;
    using Accela.Apps.Shared;

    /// <summary>
    /// Summary description for AppServerCommunicator.
    /// </summary>
    public class GovXmlCommunicator : ICommunicator, IEventCommunicator
    {
        #region event
        public event EventCommunicatorDelegate BeforeExcute;

        public event EventCommunicatorDelegate AfterExcute;

        public event EventCommunicatorDelegate ExcuteError;
        #endregion

        private readonly IGatewayClient _gatewayClient;

        public GovXmlCommunicator(IGatewayClient gatewayClient)
        {
            if (gatewayClient == null)
            {
                throw new ArgumentNullException("gatewayClient");
            }

            _gatewayClient = gatewayClient;
        }

        #region Methods

        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        private static ILog Log
        {
            get
            {
                return LogFactory.GetLog();
            }
        }

        private static string GATE_RETURN_ERROR = "500-Gateway";

        //404-Unable to connect to the remote server.
        private static string UNABLE_ACCESS_BIZSERVER = "404-";

        /// <summary>
        /// Posts GovXml request to Biz Server
        /// </summary>
        /// <param name="requestXml">GovXml Request</param>
        /// <returns>GovXml Response</returns>
        public T Post<T>(string requestXml) where T : new()
        {
            try
            {
                OnBeforeExcute(requestXml);

                // 4. Send Request And Get Response
                string responseString = SendRequestAndGetResponse(requestXml);

                responseString = responseString.Replace("xmlns=\"http://www.accela.com/schema/AccelaWirelessXML\"", "xmlns=\"http://www.accela.com/schema/AccelaOpenSystemInterfaceXML\"");

                OnAfterExcute(responseString);

                // 6. convert response string to object
                var govXmlRet = XmlConverter.FromXmlTo<T>(responseString);
 
                return govXmlRet;
            }
            catch (Exception ex)
            {
                OnExcuteError(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Send request to server and get response from server
        /// </summary>
        /// <param name="requestXml">content that it need send to server</param>
        /// <param name="request">the http request instance that contruct before</param>
        /// <returns>return server's response</returns>
        private string
            SendRequestAndGetResponse(string requestXml)
        {
            string postData = "xmlin=" + HttpUtility.UrlEncode(requestXml) + "&origin=AMO";

            string responseString = _gatewayClient.PostSync(ApiTypes.GovXml, "/wireless/GovXMLServlet",postData);

            postData = null;
            // if it is gateway exception
            if (responseString.StartsWith(GATE_RETURN_ERROR, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception(responseString);
            }
            else if (responseString.StartsWith(UNABLE_ACCESS_BIZSERVER))
            {
                throw new Exception("Unable to connect to backend business server.");
            }
            else
            {
                // TODO comment: Why remove leading < character?
                int repIdx = responseString.IndexOf("<", 0);
                if (repIdx > 0)
                {
                    responseString = responseString.Remove(0, repIdx);
                }
            }

            return responseString;
        }


        protected void OnBeforeExcute(string content)
        {
            if (this.BeforeExcute != null)
            {
                this.BeforeExcute(content);
            }
        }

        protected void OnAfterExcute(string content)
        {
            if (this.AfterExcute != null)
            {
                this.AfterExcute(content);
            }
        }

        protected void OnExcuteError(string content)
        {
            if (this.ExcuteError != null)
            {
                this.ExcuteError(content);
            }
        }

        #endregion Methods
    }

}