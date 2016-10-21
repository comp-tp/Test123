using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Queue
{
    public class QueueNameValidation
    {
        public static bool IsNameValid(string name)
        {
            // "Queue names must be 3-63 characters in length and may contain lower-case alphanumeric characters and dashes. Dashes must be preceded and followed by an alphanumeric character."

            string validBlobContainerNameRegex = @"^(([a-z\d]((-(?=[a-z\d]))|([a-z\d])){2,62})|(\$root))$";
            Regex reg = new Regex(validBlobContainerNameRegex);

            if (reg.IsMatch(name))
            {
                return true;
            }

            return false;
        }
    }
}
