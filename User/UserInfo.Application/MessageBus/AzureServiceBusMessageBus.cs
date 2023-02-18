
using Azure.Messaging.ServiceBus;
using UserInfo.Application.MessageBus;
using UserInfo.Application.RabbitMQSender;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo.Application.MessageBus
{
    public class AzureServiceBusMessageBus : IMessageBus
    {
        //can be improved
        private string connectionString = "Endpoint=sb://userdocumnet.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ZFgWyz1ILn/qWAfRfB+63T0QYfaaP2MizMxcrtQcR9I=";

        public async Task PublishMessage(BaseMessage message, string topicName)
        {

            await using var client = new ServiceBusClient(connectionString);

            ServiceBusSender sender = client.CreateSender(topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            ServiceBusMessage finalMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await sender.SendMessageAsync(finalMessage);

            await client.DisposeAsync();
        }
    }
}
