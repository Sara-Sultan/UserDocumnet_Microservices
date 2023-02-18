using System;
using System.Threading.Tasks;
using UserInfo.Application.RabbitMQSender;

namespace UserInfo.Application.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}
