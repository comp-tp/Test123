using Accela.Apps.Shared.Exceptions;
using Accela.Core.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Accela.Apps.Shared.Email
{
    public class MailHelper
    {
        public static void SendEmail(List<string> to, string subject, string body, List<string> cc = null, List<string> bcc = null)
        {
            List<object> parameter = new List<object>();
            parameter.Add(to);
            parameter.Add(subject);
            parameter.Add(body);
            parameter.Add(cc);
            parameter.Add(bcc);
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadSendEmail));
            thread.Start(parameter);

        }

        public static bool CheckEmail(string emailAddress)
        {
            string strPattern = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(emailAddress, strPattern))
            {
                return true;
            }

            return false;
        }

        private static void ThreadSendEmail(object parameter)
        {
            try
            {
                List<object> items = parameter as List<object>;
                MailSmtpClient.SendEmail(items[0] as List<string>
                    , items[1] as string
                    , items[2] as string
                    , items[3] as List<string>
                    , items[4] as List<string>);
            }
            catch (Exception ex)
            {
                try
                {
                    var items = parameter as List<object>;
                    var builder = new StringBuilder();
                    builder.AppendFormat("Parameters Info as below:");

                    var toList = items != null && items.Count > 0 ? items[0] as List<string> : null;
                    var to = toList != null ? String.Join("", toList.ToArray()) : String.Empty;
                    builder.AppendFormat(" To:{0}", to);

                    var subject = items != null && items.Count > 0 ? items[1] as string : String.Empty;
                    builder.AppendFormat(" Subject:{0}", subject);

                    //var body = items != null && items.Count > 1 ? items[2] as string : String.Empty;
                    //builder.AppendFormat(" Body:{0}", body);

                    var ccList = items != null && items.Count > 2 ? items[3] as List<string> : null;
                    var cc = ccList != null ? String.Join("", ccList.ToArray()) : String.Empty;
                    builder.AppendFormat(" CC:{0}", cc);

                    var bccList = items != null && items.Count > 2 ? items[3] as List<string> : null;
                    var bcc = bccList != null ? String.Join("", bccList.ToArray()) : String.Empty;
                    builder.AppendFormat(" BCC:{0}", bcc);

                    var parameterString = builder.ToString();

                    LogFactory.GetLog().Error(ex.Message, ex.TraceInformation() + "\r\n" + parameterString);
                }
                catch { }
            }
        }
    }
}
