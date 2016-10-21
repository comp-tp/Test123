using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Threading;
using System.Net;
using System.Net.Security;
using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;
using Accela.Infrastructure.PubSub;

namespace Accela.Infrastructure.SQLServer.Test
{
    [TestFixture]
    public class PubSubServiceTestForESB
    {
        private string _endpointConnectionString = "Endpoint=sb://accelaesb2/ServiceBusDefaultNamespace;StsEndpoint=https://accelaesb2:9355/ServiceBusDefaultNamespace;RuntimePort=9354;ManagementPort=9355;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=F8cuQKbWVLphO8n7uxN1yEy9yBflZG1gMieWGycMnAg=";
        private string Topic_Name = "adminSettingUpdated";
        private bool _messageReceivedFromSB = false;
        private string _mssageContentFromSB = null;
        private IServiceBusConnectionStringSetting _mockSBConnSetting; 

        [SetUp]
        public void Init()
        {
            var mockConnectStringSetting = new Mock<IServiceBusConnectionStringSetting>();
            mockConnectStringSetting.Setup(m => m.Get()).Returns(_endpointConnectionString);
            _mockSBConnSetting = mockConnectStringSetting.Object;
        }

        [Test]
        public void Publiser_ThrowExceptionWithNullConstructParameter()
        {
            Assert.Throws(typeof(ArgumentNullException), delegate { new Publisher<IMessageEntity>(null); });

            var mockConnectStringSetting = new Mock<IServiceBusConnectionStringSetting>();
            mockConnectStringSetting.Setup(m => m.Get()).Returns(string.Empty);

            Assert.Throws(typeof(ArgumentNullException), delegate { new Publisher<IMessageEntity>(mockConnectStringSetting.Object); });
        }

        [Test]
        public void Subscription_ThrowExceptionWithNullConstructParameter()
        {
            Assert.Throws(typeof(ArgumentNullException), delegate { new Subscriber<IMessageEntity>(null); });

            var mockConnectStringSetting = new Mock<IServiceBusConnectionStringSetting>();
            mockConnectStringSetting.Setup(m => m.Get()).Returns(string.Empty);
            Assert.Throws(typeof(ArgumentNullException), delegate { new Subscriber<IMessageEntity>(mockConnectStringSetting.Object); });
        }

        [Test]
        public void Publish_ThrowExceptionWithoutTopicName()
        {
            var publisher = new Publisher<IMessageEntity>(_mockSBConnSetting);

            // no topic name
            Assert.Throws(typeof(ArgumentNullException), async delegate { await publisher.Publish(new Mock<IMessageEntity>().Object); });
        }

        [Test]
        public void Subscriber_ThrowExceptionWithoutTopicNameOrSubsriptionName()
        {
            var subscriber = new Subscriber<IMessageEntity>(_mockSBConnSetting);
            Assert.Throws(typeof(ArgumentNullException), async delegate { await subscriber.Subscribe(null, "subscription name"); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await subscriber.Subscribe("  ", "subscription name"); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await subscriber.Subscribe("topic", null); });
            Assert.Throws(typeof(ArgumentNullException), async delegate { await subscriber.Subscribe("topic", "  "); });
        }

        [Test]
        public async void PublishAndSubscriberThruAzureServieBus_ShouldSuccess()
        {
            //ESB: requires Microsoft.ServiceBus v2.1.2 or lower
            //Azure SB: requires Microsoft.ServiceBus v2.2.0 or above
            var subscriber = new Subscriber<MessageEntity>(_mockSBConnSetting);
                subscriber.OnMessageReceived += Subscribe_MessageReceived;
                await subscriber.Subscribe(Topic_Name, "UT_AzureSB_subscriber123");

                var publisher = new Publisher<MessageEntity>(_mockSBConnSetting);
                var message = new MessageEntity()
                {
                    TopicName = Topic_Name,
                    Contents = new List<string> { "ut_environment" }
                };
                await publisher.Publish(message);

                for (int i = 0; i < 10; i++)
                {
                    if (_messageReceivedFromSB)
                        break;
                    Thread.Sleep(1000);
                }

                Assert.AreEqual(true, _messageReceivedFromSB);
                Assert.AreEqual("ut_environment", _mssageContentFromSB);

        }

        private void Subscribe_MessageReceived(MessageEntity message)
        {
            if(message != null)
            {
                _mssageContentFromSB = message.Contents[0];
                _messageReceivedFromSB = true;
                Console.WriteLine(message.TopicName + "---" + message.Contents[0]);
            }
        }
    }
}
