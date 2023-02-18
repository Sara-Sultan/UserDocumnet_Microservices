using UserInfo.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserInfo.Application.CommandsMediatR.DeleteUser
{
    public class UserDeletedHandler : INotificationHandler<UserDeleted>
    {
        private readonly ILogger<UserDeletedHandler> _logger;

        public UserDeletedHandler(ILogger<UserDeletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserDeleted notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"User {notification.DeletedUser.Id} was deleted.");
            return Task.CompletedTask;
        }
    }
}
