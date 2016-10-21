using Accela.Infrastructure.PubSub;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.PubSub
{
    public class Publisher<T> : IPublisher<T> where T : IMessageEntity
    {
        private MessagingFactory _messagingFactory;
            
        public Publisher(IServiceBusConnectionStringSetting sbConnectionStringSetting)
        {
            if (sbConnectionStringSetting == null)
            {
                throw new ArgumentNullException("sbConnectionStringSetting");
            }
            var serviceBusEndpointConnectionString = sbConnectionStringSetting.Get();
            if (string.IsNullOrWhiteSpace(serviceBusEndpointConnectionString))
            {
                throw new ArgumentNullException("sbConnectionStringSetting.Get()");
            }

            _messagingFactory = MessagingFactory.CreateFromConnectionString(serviceBusEndpointConnectionString);
        }

        public async Task Publish(T message)
        {
            if(message == null)
            {
                throw new ArgumentNullException("message");
            }

            if(string.IsNullOrWhiteSpace(message.TopicName))
            {
                throw new ArgumentNullException("message.TopicName");
            }
            // reuse messageSender client
            MessageSender messageSender = await GetMessageSender((message as IMessageEntity).TopicName);

            BrokeredMessage bm = new BrokeredMessage(message);
            await messageSender.SendAsync(bm);
        }

        private Dictionary<string, MessageSender> _messageSenders = new Dictionary<string, MessageSender>();
        private async Task<MessageSender> GetMessageSender(string topicName)
        {
            if(!_messageSenders.ContainsKey(topicName))
            {
                MessageSender messageSender = await _messagingFactory.CreateMessageSenderAsync(topicName);
                _messageSenders.Add(topicName, messageSender);
                return messageSender;
            }
            else
            {
                return _messageSenders[topicName];
            }
        }
    }
}
