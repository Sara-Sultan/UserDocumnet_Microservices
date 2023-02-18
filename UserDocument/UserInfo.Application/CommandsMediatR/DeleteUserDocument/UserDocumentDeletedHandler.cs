using Document.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Document.Application.CommandsMediatR.DeleteUser
{
    public class UserDocumentDeletedHandler : INotificationHandler<UserDeleted>
    {
        private readonly ILogger<UserDocumentDeletedHandler> _logger;

        public UserDocumentDeletedHandler(ILogger<UserDocumentDeletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserDeleted notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"User {notification.DeletedUserDocument.Id} was deleted.");
            return Task.CompletedTask;
        }
    }
}
