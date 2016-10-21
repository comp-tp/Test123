using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.PubSub
{

    public class Subscriber<T> : ISubscriber<T> where T : IMessageEntity
    {
        public delegate void MessageReceivedHandler(T e);

        private string _endpointConnectionString;
        private MessagingFactory _messagingFactory;
        private NamespaceManager _namespaceManager;
        public event MessageReceivedHandler OnMessageReceived;

        public Subscriber(IServiceBusConnectionStringSetting sbConnectionStringSetting)
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
            _endpointConnectionString = serviceBusEndpointConnectionString;
            _messagingFactory = MessagingFactory.CreateFromConnectionString(_endpointConnectionString);
            _namespaceManager = NamespaceManager.CreateFromConnectionString(_endpointConnectionString);
        }

        public async Task Subscribe(string topicName,string subscriptionName)
        {
            if(string.IsNullOrWhiteSpace(topicName))
            {
                throw new ArgumentNullException(topicName);
            }

            if (string.IsNullOrWhiteSpace(subscriptionName))
            {
                throw new ArgumentNullException(subscriptionName);
            }

            var existSubscription = await _namespaceManager.SubscriptionExistsAsync(topicName, subscriptionName);
            SubscriptionClient subscriptionClient = null;

            if (!existSubscription)
            {
                SubscriptionDescription subscriptionDesc = new SubscriptionDescription(topicName, subscriptionName)
                {
                    EnableDeadLetteringOnFilterEvaluationExceptions = true,
                    EnableDeadLetteringOnMessageExpiration = true,
                    EnableBatchedOperations = true,
                    DefaultMessageTimeToLive = TimeSpan.FromMinutes(5),
                };

                await _namespaceManager.CreateSubscriptionAsync(subscriptionDesc); 
            }

            subscriptionClient = SubscriptionClient.CreateFromConnectionString(_endpointConnectionString, topicName, subscriptionName, ReceiveMode.ReceiveAndDelete);
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = true;
            options.MaxConcurrentCalls = 10;

            subscriptionClient.OnMessage((message) =>
            {
                try
                {
                    // Process message from subscription
                    var msg = message.GetBody<T>();
                    if (msg != null)
                    {
                        // raise message received event, the client-apis/oauth subsystems to process received message.
                        OnMessageReceived(msg);
                    }
                }
                catch (Exception ex)
                {
                    // Indicates a problem, unlock message in subscription
                    message.Abandon();
                }
            }, options);
        }

        public Task Unsubscribe(string topicName, string subscriptionName)
        {
            throw new NotImplementedException();
        }
    }
}
