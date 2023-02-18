using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Document.Domain.Entities;

namespace Document.Application.Events
{

    public class UserDocumentCreated : INotification
    {
        public UserDocument NewUserDocument { get; }

        public UserDocumentCreated(UserDocument newUserDocument)
        {
            NewUserDocument = newUserDocument;
        }
    }

    public class UserDeleted : INotification
    {
        public UserDocument DeletedUserDocument { get; }

        public UserDeleted(UserDocument deletedUserDocument)
        {
            DeletedUserDocument = deletedUserDocument;
        }
    }


}
