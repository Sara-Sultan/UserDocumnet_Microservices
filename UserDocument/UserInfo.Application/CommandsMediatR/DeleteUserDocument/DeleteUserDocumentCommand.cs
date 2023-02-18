using Document.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Application.CommandsMediatR
{
    public class DeleteUserDocumentCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
