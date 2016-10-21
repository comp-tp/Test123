using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.PubSub
{
    public class MessageEntity : IMessageEntity
    {
        public string TopicName { get; set; }
        public List<string> Contents{ get; set; }
    }
}
