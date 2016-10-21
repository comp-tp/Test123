using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Queue
{
    public static class QueueValidation
    {
        public static void CheckQueueName(string queueName)
        {
            if (string.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            var isValid = QueueNameValidation.IsNameValid(queueName);

            if (!isValid)
            {
                throw new ArgumentException("Queue names must be 3-63 characters in length and may contain lower-case alphanumeric characters and dashes. Dashes must be preceded and followed by an alphanumeric character.", "queueName");
            }
        }
    }
}
