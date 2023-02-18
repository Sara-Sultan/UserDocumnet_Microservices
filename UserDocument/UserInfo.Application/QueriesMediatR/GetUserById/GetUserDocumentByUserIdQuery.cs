using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Application.QueriesMediatR
{
    public class GetUserDocumentByUserIdQuery : IRequest<UserDocumentDisplay>
    {
        public int UserId { get; set; }
    }
}
