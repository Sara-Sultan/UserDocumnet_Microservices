using Document.Application.RabbitMQSender;
using System;
using System.Threading.Tasks;

namespace Document.Application.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}
