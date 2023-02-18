using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Application.CommandsMediatR
{
    public class AddNewUserDocumentCommand : IRequest
    {
        public int UserId { get; set; }
        public string FilePath { get; set; }
    }
}
