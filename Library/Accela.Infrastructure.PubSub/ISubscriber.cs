using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.PubSub
{
    public interface ISubscriber<T> where T : IMessageEntity
    {
        Task Subscribe(string topicName, string subscriptionName);
        Task Unsubscribe(string topicName, string subscriptionName);         
    }
}
