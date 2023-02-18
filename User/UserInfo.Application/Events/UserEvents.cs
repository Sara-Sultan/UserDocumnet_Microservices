using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using UserInfo.Domain.Entities;

namespace UserInfo.Application.Events
{

    public class UserCreated : INotification
    {
        public User NewUser { get; }

        public UserCreated(User newUser)
        {
            NewUser = newUser;
        }
    }

    public class UserDeleted : INotification
    {
        public User DeletedUser { get; }

        public UserDeleted(User deletedUser)
        {
            DeletedUser = deletedUser;
        }
    }


}


