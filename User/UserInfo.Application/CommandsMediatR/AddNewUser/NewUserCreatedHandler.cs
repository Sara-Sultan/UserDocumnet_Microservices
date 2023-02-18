using UserInfo.Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UserInfo.Application.CommandsMediatR
{
    public class NewUserCreatedHandler : INotificationHandler<UserCreated>
    {

        private readonly ILogger<NewUserCreatedHandler> _logger;

        public NewUserCreatedHandler(ILogger<NewUserCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"User {notification.NewUser.Id} was added to data base.");
            return Task.CompletedTask;
        }

   
    }
}
