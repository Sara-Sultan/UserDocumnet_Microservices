using Document.Application.CommandsMediatR;
using Document.Application.RabbitMQSender;
using MediatR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Document.Application.Messaging
{
    public class RabbitMQRemoveUserDocConsumer : BackgroundService
    {
        private readonly IMediator _mediator;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQRemoveUserDocConsumer(IMediator mediator )
        {
            _mediator = mediator;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "RemoveUserDoc", false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                RemoveUserDocumentDto removeUserDocumentDto = JsonConvert.DeserializeObject<RemoveUserDocumentDto>(content);
                HandleMessage(removeUserDocumentDto).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("RemoveUserDoc", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(RemoveUserDocumentDto removeUserDocumentDto)
        {
           
            try
            {
                DeleteUserDocumentCommand command = new DeleteUserDocumentCommand();
                command.UserId = removeUserDocumentDto.UserId;
                var response = await _mediator.Send(command);
            }
            catch (Exception e)
            {
                //log
                throw;
            }
        }
    }
}
