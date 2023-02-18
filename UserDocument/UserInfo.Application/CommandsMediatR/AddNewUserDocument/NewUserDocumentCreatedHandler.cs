using Document.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Document.Application.CommandsMediatR
{
    public class NewUserDocumentCreatedHandler : INotificationHandler<UserDocumentCreated>
    {

        private readonly ILogger<NewUserDocumentCreatedHandler> _logger;

        public NewUserDocumentCreatedHandler(ILogger<NewUserDocumentCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserDocumentCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"User {notification.NewUserDocument.Id} was added to data base.");
            return Task.CompletedTask;
        }

   
    }
}
