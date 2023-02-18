using UserInfo.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Application.CommandsMediatR
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
