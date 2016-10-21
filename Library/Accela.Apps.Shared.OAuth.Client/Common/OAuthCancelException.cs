using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.OAuth
{
    public class OAuthCancelException : Exception
    {
        public OAuthCancelException()
        {
        }

        public OAuthCancelException(string message)
            : base(message)
        {
        }
    }
}
