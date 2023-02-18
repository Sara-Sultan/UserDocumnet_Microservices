using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Document.Application.RabbitMQSender
{
    public interface IRabbitMQUserMessageSender
    {
        void SendMessage(BaseMessage baseMessage, String queueName);
    }
}
