using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MediatR;
using Azure.Messaging.ServiceBus;
using Document.Application.MessageBus;
using Document.Application.RabbitMQSender;
using Document.Application.CommandsMediatR;

namespace Document.Application.Messaging
{
    public class AzureServiceBusConsumer : IAzureServiceBusConsumer
    {
        private readonly string serviceBusConnectionString;
        private readonly string subscriptionAddNewUser;
        private readonly string subscriptionDeleteuser;
        private readonly string addnewuserdocumnetTopic;
        private readonly string deleteuserdocumnetTopic;

        private readonly IMediator _mediator;

        private ServiceBusProcessor addUserProcessor;
        private ServiceBusProcessor deleteUserProcessor;

        private readonly IConfiguration _configuration;
        private readonly IMessageBus _messageBus;

        public AzureServiceBusConsumer(IMediator mediator, IConfiguration configuration
            , IMessageBus messageBus)
        {
            _mediator = mediator;
            _configuration = configuration;
            _messageBus = messageBus;

            serviceBusConnectionString = _configuration.GetSection("ServiceBusConnectionString").Value;
            subscriptionAddNewUser = _configuration.GetSection("SubscriptionAdduserDocumnet").Value;
            subscriptionDeleteuser = _configuration.GetSection("SubscriptiondeleteuserDocumnet").Value;
            addnewuserdocumnetTopic = _configuration.GetSection("addnewuserdocumnetTopic").Value;
            deleteuserdocumnetTopic = _configuration.GetSection("deleteuserdocumnetTopic").Value;



            var client = new ServiceBusClient(serviceBusConnectionString);

            addUserProcessor = client.CreateProcessor(addnewuserdocumnetTopic, subscriptionAddNewUser);
            deleteUserProcessor = client.CreateProcessor(deleteuserdocumnetTopic, subscriptionDeleteuser);


        }

        public async Task Start()
        {
            addUserProcessor.ProcessMessageAsync += OnAddUserMessageReceived;
            addUserProcessor.ProcessErrorAsync += ErrorHandler;
            await addUserProcessor.StartProcessingAsync();

            deleteUserProcessor.ProcessMessageAsync += OnDeleteUserMessageReceived;
            deleteUserProcessor.ProcessErrorAsync += ErrorHandler;
            await deleteUserProcessor.StartProcessingAsync();

        }
        public async Task Stop()
        {
            await addUserProcessor.StopProcessingAsync();
            await addUserProcessor.DisposeAsync();

            await deleteUserProcessor.StopProcessingAsync();
            await deleteUserProcessor.DisposeAsync();
        }
        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        private async Task OnAddUserMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            AddNewUserDocumentDto addNewUserDocumentDto = JsonConvert.DeserializeObject<AddNewUserDocumentDto>(body);

            AddNewUserDocumentCommand command = new AddNewUserDocumentCommand();
            command.UserId = addNewUserDocumentDto.UserId;
            command.FilePath = addNewUserDocumentDto.FilePath;
            var response = await _mediator.Send(command);

            await args.CompleteMessageAsync(args.Message);


        }

        private async Task OnDeleteUserMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            RemoveUserDocumentDto removeUserDocumentDto = JsonConvert.DeserializeObject<RemoveUserDocumentDto>(body);

            DeleteUserDocumentCommand command = new DeleteUserDocumentCommand();
            command.UserId = removeUserDocumentDto.UserId;
            var response = await _mediator.Send(command);

            await args.CompleteMessageAsync(args.Message);

        }

    }
}
