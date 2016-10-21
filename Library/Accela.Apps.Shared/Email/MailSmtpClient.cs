using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;
using Accela.Core.Logging;
using Accela.Core.Ioc;
using Accela.Core.Configurations;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Shared.Email
{
    /// <summary>
    /// MailSmtpClient
    /// </summary>
    public static class MailSmtpClient
    {
        //private readonly static Func<IConfiguration> ConfigurationSettingsProvider;
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }

        static MailSmtpClient()
        {
            //ConfigurationSettingsProvider = ConfigurationProvider.Instance.Get; //IocContainer.Resolve<IConfiguration>();
        }
        /// <summary>
        /// Sent Mail.
        /// </summary>
        /// <param name="to">A System.String that contains the address of the recipient of the e-mail message.</param>
        /// <param name="subject">A System.String that contains the subject text.</param>
        /// <param name="body">the message body.</param>
        /// <param name="cc">the address collection that contains the carbon copy (CC) recipients for this e-mail message.</param>
        /// <param name="bcc"> the address collection that contains the blind carbon copy (BCC) recipients for this e-mail message.</param>
        public static void SendEmail(List<string> to, string subject, string body, List<string> cc = null, List<string> bcc = null)
        {
            MailMessage message = new MailMessage();
            message.Subject = subject;
            message.Body = body;

            #region From

            MailAddress mailFromAddress = new MailAddress(From);

            message.From = mailFromAddress;
            message.IsBodyHtml = true;

            #endregion

            #region To
            string tokenTo = "";

            if (to != null)
            {
                foreach (string item in to)
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        message.To.Add(item);
                        tokenTo += item + ";";
                    }
                }
            }

            #endregion

            #region CC

            string tokenCC = "";

            if (cc != null)
            {
                foreach (string item in cc)
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        message.CC.Add(item);
                        tokenCC += item + ";";
                    }
                }
            }

            #endregion

            #region Bcc

            string tokenBcc = "";

            if (bcc != null)
            {
                foreach (string item in bcc)
                {
                    if (!String.IsNullOrEmpty(item))
                    {
                        message.Bcc.Add(item);
                        tokenBcc += item + ";";
                    }
                }
            }

            #endregion

            SmtpClient smtpClient = new SmtpClient(SmtpServer, SmtpPort);
            smtpClient.Credentials = new NetworkCredential(MailSenderAccount, MailSenderPassword);

            //smtpClient.Send(message);

            // Set the method that is called back when the send operation ends.
            smtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            string token = String.Format("{0}|{1}|{2}|{3}", Guid.NewGuid(), tokenTo, tokenCC, tokenBcc);
            smtpClient.SendAsync(message, token);
        }


        /// <summary>
        /// Send email completed callback event.
        /// </summary>
        /// <param name="sender">the event sender.</param>
        /// <param name="e">Provides data for the MethodNameCompleted event.</param>
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                // Get the unique identifier for this asynchronous operation.
                string token = (string)e.UserState;

                if (e.Cancelled)
                {
                    LogFactory.GetLog().Error("Sending email cancelled.", token);
                }
                if (e.Error != null)
                {
                    LogFactory.GetLog().Error("Sending email error.", token);
                }
            }
            catch { }
        }

        /// <summary>
        /// Gets the smtp server.
        /// </summary>
        private static string SmtpServer
        {
            get
            {
                return ConfigurationSettings.Get("SmtpServer");
            }
        }

        /// <summary>
        /// Gets the smtp port.
        /// </summary>
        private static int SmtpPort
        {
            get
            {
                string smtpPort = ConfigurationSettings.Get("SmtpPort");
                int port = Convert.ToInt32(smtpPort);

                if (port == 0)
                {
                    port = 25;
                }

                return port;
            }
        }

        /// <summary>
        /// Gets the mail sender account.
        /// </summary>
        private static string MailSenderAccount
        {
            get
            {
                return ConfigurationSettings.Get("MailSenderAccount");
            }
        }

        /// <summary>
        /// Gets the mail sender password.
        /// </summary>
        private static string MailSenderPassword
        {
            get
            {
                return ConfigurationSettings.Get("MailSenderPassword");
            }
        }

        /// <summary>
        /// Gets the mail from.
        /// </summary>
        private static string From
        {
            get
            {
                return ConfigurationSettings.Get("From");
            }
        }
    }
}
